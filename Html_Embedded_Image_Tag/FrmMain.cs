using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Html_Embedded_Image_Tag
{
    public partial class FrmMain : Form
    {
        #region Private Fields

        Dictionary<string, string> mimeTable = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        #endregion Private Fields

        #region Public Constructors

        public FrmMain()
        {
            InitializeComponent();
            TxtOutput.MaxLength = int.MaxValue;
            PopulateMimeTypes();
        }

        #endregion Public Constructors

        #region Private Methods

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.svg;"
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TxtFile.Text = dlg.FileName;
                }
            }
        }

        private void BtnClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(TxtOutput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to send data to the clipboard.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void ChkFullTag_CheckedChanged(object sender, EventArgs e)
        {
            ChkSize.Enabled = ChkFullTag.Checked;
            if (!ChkSize.Enabled)
            {
                ChkSize.Checked = false;
            }
        }

        private void ClipboardWatcher_Tick(object sender, EventArgs e)
        {
            RadClipboard.Enabled = Clipboard.ContainsImage();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();

            UserOptions.Load();
            ChkFullTag.Checked = UserOptions.Properties.Include_Tag;
            ChkSize.Checked = UserOptions.Properties.Include_Size;

            if (args.Length == 2)
            {
                string file = args[1];
                if (!File.Exists(file))
                {
                    ShowErrorMessage("The file passed does not exist.");
                    return;
                }
                string format, ext = Path.GetExtension(file);
                if (!mimeTable.TryGetValue(ext, out format))
                {
                    ShowErrorMessage("The file passed is not a valid format.");
                    return;
                }
                TxtFile.Text = file;
                Generate();
            }

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserOptions.Properties.Include_Size = ChkSize.Checked;
            UserOptions.Properties.Include_Tag = ChkFullTag.Checked;
            UserOptions.Save();
        }

        private void Generate()
        {
            byte[] src = null;
            string format = null;
            string alt = null;
            string size = null;
            try
            {
                if (RadFile.Checked)
                {
                    if (File.Exists(TxtFile.Text))
                    {
                        string ext = Path.GetExtension(TxtFile.Text);
                        if (ChkSize.Checked)
                        {
                            if (ext.Equals(".svg", StringComparison.OrdinalIgnoreCase))
                            {
                                XmlDocument svg = new XmlDocument();
                                svg.Load(TxtFile.Text);
                                size = $" height=\"{svg.DocumentElement.GetAttribute("height")}\" width=\"{svg.DocumentElement.GetAttribute("width")}\" ";
                            }
                            else if (mimeTable.ContainsKey(ext))
                            {
                                using (Image img = Image.FromFile(TxtFile.Text))
                                {
                                    size = $" height=\"{img.Height}\" width=\"{img.Width}\" ";
                                }
                            }
                        }

                        src = File.ReadAllBytes(TxtFile.Text);
                        if (!mimeTable.TryGetValue(ext, out format))
                        {
                            format = "application/octet-stream";
                        }
                        alt = Path.GetFileNameWithoutExtension(TxtFile.Text);
                    }
                    else
                    {
                        ShowErrorMessage("The selected file was not found or doesn't exist.");
                        return;
                    }
                }
                else if (RadClipboard.Checked && RadClipboard.Enabled)
                {
                    using (Image image = Clipboard.GetImage())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            src = ms.ToArray();
                            format = "image/png";
                            size = $" height=\"{image.Height}\" width=\"{image.Width}\" ";
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("No source is selected to process.");
                }

                string srcText = $"data:{format};base64,{Convert.ToBase64String(src)}";
                if (ChkFullTag.Checked)
                {
                    srcText = $"<img src=\"{srcText}\" alt=\"{alt}\" {size}/>";
                }
                TxtOutput.Text = srcText;
            }
            catch (Exception)
            {
                ShowErrorMessage("An error occurred while generating output.");
            }
        }

        private void PopulateMimeTypes()
        {
            mimeTable.Add(".jpeg", "image/jpeg");
            mimeTable.Add(".jpg", "image/jpeg");
            mimeTable.Add(".svg", "image/svg+xml");
            mimeTable.Add(".gif", "image/gif");
            mimeTable.Add(".bmp", "image/bmp");
            mimeTable.Add(".png", "image/png");

        }
        private void RadFile_CheckedChanged(object sender, EventArgs e)
        {
            TxtFile.Enabled = RadFile.Checked;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        #endregion Private Methods

        
    }
}
