namespace Html_Embedded_Image_Tag
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadClipboard = new System.Windows.Forms.RadioButton();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.TxtFile = new System.Windows.Forms.TextBox();
            this.RadFile = new System.Windows.Forms.RadioButton();
            this.ChkFullTag = new System.Windows.Forms.CheckBox();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.BtnClipboard = new System.Windows.Forms.Button();
            this.MainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ClipboardWatcher = new System.Windows.Forms.Timer(this.components);
            this.ChkSize = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.RadClipboard);
            this.groupBox1.Controls.Add(this.BtnBrowse);
            this.groupBox1.Controls.Add(this.TxtFile);
            this.groupBox1.Controls.Add(this.RadFile);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(791, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // RadClipboard
            // 
            this.RadClipboard.AutoSize = true;
            this.RadClipboard.Enabled = false;
            this.RadClipboard.Location = new System.Drawing.Point(8, 95);
            this.RadClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.RadClipboard.Name = "RadClipboard";
            this.RadClipboard.Size = new System.Drawing.Size(89, 21);
            this.RadClipboard.TabIndex = 3;
            this.RadClipboard.Text = "Clipboard";
            this.RadClipboard.UseVisualStyleBackColor = true;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBrowse.Location = new System.Drawing.Point(729, 49);
            this.BtnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(53, 28);
            this.BtnBrowse.TabIndex = 2;
            this.BtnBrowse.Text = "....";
            this.MainTooltip.SetToolTip(this.BtnBrowse, "Browse");
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // TxtFile
            // 
            this.TxtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFile.Location = new System.Drawing.Point(36, 52);
            this.TxtFile.Margin = new System.Windows.Forms.Padding(32, 4, 4, 4);
            this.TxtFile.Name = "TxtFile";
            this.TxtFile.Size = new System.Drawing.Size(684, 22);
            this.TxtFile.TabIndex = 1;
            // 
            // RadFile
            // 
            this.RadFile.AutoSize = true;
            this.RadFile.Checked = true;
            this.RadFile.Location = new System.Drawing.Point(8, 23);
            this.RadFile.Margin = new System.Windows.Forms.Padding(4);
            this.RadFile.Name = "RadFile";
            this.RadFile.Size = new System.Drawing.Size(51, 21);
            this.RadFile.TabIndex = 0;
            this.RadFile.TabStop = true;
            this.RadFile.Text = "File";
            this.RadFile.UseVisualStyleBackColor = true;
            this.RadFile.CheckedChanged += new System.EventHandler(this.RadFile_CheckedChanged);
            // 
            // ChkFullTag
            // 
            this.ChkFullTag.AutoSize = true;
            this.ChkFullTag.Checked = true;
            this.ChkFullTag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkFullTag.Location = new System.Drawing.Point(24, 165);
            this.ChkFullTag.Margin = new System.Windows.Forms.Padding(4);
            this.ChkFullTag.Name = "ChkFullTag";
            this.ChkFullTag.Size = new System.Drawing.Size(128, 21);
            this.ChkFullTag.TabIndex = 1;
            this.ChkFullTag.Text = "Output Full Tag";
            this.ChkFullTag.UseVisualStyleBackColor = true;
            this.ChkFullTag.CheckedChanged += new System.EventHandler(this.ChkFullTag_CheckedChanged);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BtnGenerate.Location = new System.Drawing.Point(24, 193);
            this.BtnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(132, 36);
            this.BtnGenerate.TabIndex = 3;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = false;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 246);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output";
            // 
            // TxtOutput
            // 
            this.TxtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtOutput.Location = new System.Drawing.Point(24, 266);
            this.TxtOutput.Margin = new System.Windows.Forms.Padding(4);
            this.TxtOutput.Multiline = true;
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.Size = new System.Drawing.Size(725, 138);
            this.TxtOutput.TabIndex = 4;
            this.TxtOutput.WordWrap = false;
            // 
            // BtnClipboard
            // 
            this.BtnClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClipboard.Image = ((System.Drawing.Image)(resources.GetObject("BtnClipboard.Image")));
            this.BtnClipboard.Location = new System.Drawing.Point(759, 266);
            this.BtnClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClipboard.Name = "BtnClipboard";
            this.BtnClipboard.Size = new System.Drawing.Size(48, 48);
            this.BtnClipboard.TabIndex = 5;
            this.MainTooltip.SetToolTip(this.BtnClipboard, "Copy to Clipboard");
            this.BtnClipboard.UseVisualStyleBackColor = true;
            this.BtnClipboard.Click += new System.EventHandler(this.BtnClipboard_Click);
            // 
            // ClipboardWatcher
            // 
            this.ClipboardWatcher.Enabled = true;
            this.ClipboardWatcher.Interval = 1000;
            this.ClipboardWatcher.Tick += new System.EventHandler(this.ClipboardWatcher_Tick);
            // 
            // ChkSize
            // 
            this.ChkSize.AutoSize = true;
            this.ChkSize.Location = new System.Drawing.Point(172, 165);
            this.ChkSize.Name = "ChkSize";
            this.ChkSize.Size = new System.Drawing.Size(170, 21);
            this.ChkSize.TabIndex = 2;
            this.ChkSize.Text = "Include Size Attributes";
            this.ChkSize.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 417);
            this.Controls.Add(this.ChkSize);
            this.Controls.Add(this.BtnClipboard);
            this.Controls.Add(this.TxtOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.ChkFullTag);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Html Embedded Image Tag Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadClipboard;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.TextBox TxtFile;
        private System.Windows.Forms.RadioButton RadFile;
        private System.Windows.Forms.CheckBox ChkFullTag;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtOutput;
        private System.Windows.Forms.Button BtnClipboard;
        private System.Windows.Forms.ToolTip MainTooltip;
        private System.Windows.Forms.Timer ClipboardWatcher;
        private System.Windows.Forms.CheckBox ChkSize;
    }
}

