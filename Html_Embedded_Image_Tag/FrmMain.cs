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

namespace Html_Imbedded_Image_Tag
{
    public partial class FrmMain : Form
    {
        Dictionary<string, string> mimeTable = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public FrmMain()
        {
            InitializeComponent();
            TxtOutput.MaxLength = int.MaxValue;
            PopulateMimeTypes();
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

        private void ClipboardWatcher_Tick(object sender, EventArgs e)
        {
            RadClipboard.Enabled = Clipboard.ContainsImage();
        }

        private void RadFile_CheckedChanged(object sender, EventArgs e)
        {
            TxtFile.Enabled = RadFile.Checked;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog() {
                Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.svg;"
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TxtFile.Text = dlg.FileName;
                }
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
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
                        MessageBox.Show("The selected file was not found or doesn't exist.",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
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
                    MessageBox.Show("No source is selected to process.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
                MessageBox.Show("An error occurred while generating output.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

        private void ChkFullTag_CheckedChanged(object sender, EventArgs e)
        {
            ChkSize.Enabled = ChkFullTag.Checked;
            if (!ChkSize.Enabled)
            {
                ChkSize.Checked = false;
            }
        }
    }
}
