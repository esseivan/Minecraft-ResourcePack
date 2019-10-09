namespace MinecraftGoogleImages
{
    partial class frmMain
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
            this.btnExtractJar = new System.Windows.Forms.Button();
            this.btnOpenDataFolder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGetImages = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbTag = new System.Windows.Forms.CheckBox();
            this.txtTag = new EsseivaN.Controls.TextboxWatermark();
            this.cbResizeMode = new System.Windows.Forms.ComboBox();
            this.txtPixelsH = new EsseivaN.Controls.TextboxWatermark();
            this.txtPixelsW = new EsseivaN.Controls.TextboxWatermark();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateZip = new System.Windows.Forms.Button();
            this.chbRnd = new System.Windows.Forms.CheckBox();
            this.txtImgIndex = new EsseivaN.Controls.TextboxWatermark();
            this.btnSelJar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.cbBackground = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.visuBackground = new System.Windows.Forms.Panel();
            this.lblBackground = new System.Windows.Forms.Label();
            this.chbTrans = new System.Windows.Forms.CheckBox();
            this.txtTags = new EsseivaN.Controls.TextboxWatermark();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExtractJar
            // 
            this.btnExtractJar.Location = new System.Drawing.Point(12, 41);
            this.btnExtractJar.Name = "btnExtractJar";
            this.btnExtractJar.Size = new System.Drawing.Size(100, 46);
            this.btnExtractJar.TabIndex = 0;
            this.btnExtractJar.Text = "Extract jar";
            this.btnExtractJar.UseVisualStyleBackColor = true;
            this.btnExtractJar.Click += new System.EventHandler(this.btnExtractJar_Click);
            // 
            // btnOpenDataFolder
            // 
            this.btnOpenDataFolder.Location = new System.Drawing.Point(150, 12);
            this.btnOpenDataFolder.Name = "btnOpenDataFolder";
            this.btnOpenDataFolder.Size = new System.Drawing.Size(100, 46);
            this.btnOpenDataFolder.TabIndex = 1;
            this.btnOpenDataFolder.Text = "Open data folder";
            this.btnOpenDataFolder.UseVisualStyleBackColor = true;
            this.btnOpenDataFolder.Click += new System.EventHandler(this.btnOpenDataFolder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbStatus,
            this.toolStripStatusLabel1,
            this.lblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(699, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pbStatus
            // 
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel1.Text = "-";
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 17);
            this.lblCount.Text = "0";
            // 
            // btnGetImages
            // 
            this.btnGetImages.Location = new System.Drawing.Point(12, 93);
            this.btnGetImages.Name = "btnGetImages";
            this.btnGetImages.Size = new System.Drawing.Size(100, 46);
            this.btnGetImages.TabIndex = 0;
            this.btnGetImages.Text = "Get images\r\nfrom web";
            this.btnGetImages.UseVisualStyleBackColor = true;
            this.btnGetImages.Click += new System.EventHandler(this.btnGetImages_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtTags);
            this.groupBox1.Controls.Add(this.chbTrans);
            this.groupBox1.Controls.Add(this.lblBackground);
            this.groupBox1.Controls.Add(this.visuBackground);
            this.groupBox1.Controls.Add(this.cbBackground);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chbTag);
            this.groupBox1.Controls.Add(this.txtTag);
            this.groupBox1.Controls.Add(this.txtImgIndex);
            this.groupBox1.Controls.Add(this.chbRnd);
            this.groupBox1.Controls.Add(this.cbResizeMode);
            this.groupBox1.Controls.Add(this.txtPixelsH);
            this.groupBox1.Controls.Add(this.txtPixelsW);
            this.groupBox1.Location = new System.Drawing.Point(256, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 367);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // chbTag
            // 
            this.chbTag.AutoSize = true;
            this.chbTag.Location = new System.Drawing.Point(6, 110);
            this.chbTag.Name = "chbTag";
            this.chbTag.Size = new System.Drawing.Size(110, 17);
            this.chbTag.TabIndex = 10;
            this.chbTag.Text = "Add tag to search";
            this.chbTag.UseVisualStyleBackColor = true;
            this.chbTag.CheckedChanged += new System.EventHandler(this.chbTag_CheckedChanged);
            // 
            // txtTag
            // 
            this.txtTag.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTag.Location = new System.Drawing.Point(6, 133);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(147, 20);
            this.txtTag.TabIndex = 9;
            this.txtTag.TextColor = System.Drawing.SystemColors.ControlText;
            this.txtTag.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtTag.WatermarkText = "Search tag";
            // 
            // cbResizeMode
            // 
            this.cbResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResizeMode.FormattingEnabled = true;
            this.cbResizeMode.Items.AddRange(new object[] {
            "Resize",
            "Keep Ratio Width (X)",
            "Keep Ratio Height (Y)",
            "Keep Ratio Auto"});
            this.cbResizeMode.Location = new System.Drawing.Point(6, 71);
            this.cbResizeMode.Name = "cbResizeMode";
            this.cbResizeMode.Size = new System.Drawing.Size(147, 21);
            this.cbResizeMode.TabIndex = 8;
            // 
            // txtPixelsH
            // 
            this.txtPixelsH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPixelsH.Location = new System.Drawing.Point(6, 45);
            this.txtPixelsH.Name = "txtPixelsH";
            this.txtPixelsH.Size = new System.Drawing.Size(147, 20);
            this.txtPixelsH.TabIndex = 0;
            this.txtPixelsH.Text = "64";
            this.txtPixelsH.TextColor = System.Drawing.SystemColors.ControlText;
            this.txtPixelsH.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtPixelsH.WatermarkText = "Pixels Y";
            // 
            // txtPixelsW
            // 
            this.txtPixelsW.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPixelsW.Location = new System.Drawing.Point(6, 19);
            this.txtPixelsW.Name = "txtPixelsW";
            this.txtPixelsW.Size = new System.Drawing.Size(147, 20);
            this.txtPixelsW.TabIndex = 0;
            this.txtPixelsW.Text = "64";
            this.txtPixelsW.TextColor = System.Drawing.SystemColors.ControlText;
            this.txtPixelsW.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtPixelsW.WatermarkText = "Pixels X";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel task";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateZip
            // 
            this.btnCreateZip.Location = new System.Drawing.Point(150, 64);
            this.btnCreateZip.Name = "btnCreateZip";
            this.btnCreateZip.Size = new System.Drawing.Size(100, 46);
            this.btnCreateZip.TabIndex = 1;
            this.btnCreateZip.Text = "Create zip";
            this.btnCreateZip.UseVisualStyleBackColor = true;
            this.btnCreateZip.Click += new System.EventHandler(this.btnCreateZip_Click);
            // 
            // chbRnd
            // 
            this.chbRnd.AutoSize = true;
            this.chbRnd.Location = new System.Drawing.Point(6, 198);
            this.chbRnd.Name = "chbRnd";
            this.chbRnd.Size = new System.Drawing.Size(66, 17);
            this.chbRnd.TabIndex = 8;
            this.chbRnd.Text = "Random";
            this.chbRnd.UseVisualStyleBackColor = true;
            this.chbRnd.CheckedChanged += new System.EventHandler(this.chbRnd_CheckedChanged);
            // 
            // txtImgIndex
            // 
            this.txtImgIndex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtImgIndex.Location = new System.Drawing.Point(6, 172);
            this.txtImgIndex.Name = "txtImgIndex";
            this.txtImgIndex.Size = new System.Drawing.Size(101, 20);
            this.txtImgIndex.TabIndex = 9;
            this.txtImgIndex.Text = "1";
            this.txtImgIndex.TextColor = System.Drawing.SystemColors.ControlText;
            this.txtImgIndex.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtImgIndex.WatermarkText = "Default result index";
            // 
            // btnSelJar
            // 
            this.btnSelJar.Location = new System.Drawing.Point(12, 12);
            this.btnSelJar.Name = "btnSelJar";
            this.btnSelJar.Size = new System.Drawing.Size(100, 23);
            this.btnSelJar.TabIndex = 7;
            this.btnSelJar.Text = "Select jar";
            this.btnSelJar.UseVisualStyleBackColor = true;
            this.btnSelJar.Click += new System.EventHandler(this.btnSelJar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.jar";
            this.openFileDialog1.Filter = "Jar files (*.jar)|*.jar|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Select minecraft.jar";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(421, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(421, 41);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(266, 338);
            this.treeView1.TabIndex = 12;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Take result index : ";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(150, 116);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 46);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy to ressource pack folder";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbBackground
            // 
            this.cbBackground.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackground.FormattingEnabled = true;
            this.cbBackground.Items.AddRange(new object[] {
            "Transparent",
            "Fixed  color"});
            this.cbBackground.Location = new System.Drawing.Point(6, 234);
            this.cbBackground.Name = "cbBackground";
            this.cbBackground.Size = new System.Drawing.Size(120, 21);
            this.cbBackground.TabIndex = 12;
            // 
            // visuBackground
            // 
            this.visuBackground.Location = new System.Drawing.Point(132, 234);
            this.visuBackground.Name = "visuBackground";
            this.visuBackground.Size = new System.Drawing.Size(21, 21);
            this.visuBackground.TabIndex = 13;
            this.visuBackground.Click += new System.EventHandler(this.visuBackground_Click);
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Location = new System.Drawing.Point(6, 218);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(65, 13);
            this.lblBackground.TabIndex = 14;
            this.lblBackground.Text = "Background";
            // 
            // chbTrans
            // 
            this.chbTrans.AutoSize = true;
            this.chbTrans.Location = new System.Drawing.Point(6, 261);
            this.chbTrans.Name = "chbTrans";
            this.chbTrans.Size = new System.Drawing.Size(141, 17);
            this.chbTrans.TabIndex = 15;
            this.chbTrans.Text = "Transparent images only";
            this.chbTrans.UseVisualStyleBackColor = true;
            // 
            // txtTags
            // 
            this.txtTags.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTags.Location = new System.Drawing.Point(6, 284);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(147, 20);
            this.txtTags.TabIndex = 16;
            this.txtTags.TextColor = System.Drawing.SystemColors.ControlText;
            this.txtTags.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtTags.WatermarkText = "Additionnal query tags";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(6, 310);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(147, 51);
            this.textBox1.TabIndex = 17;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "e.g. \"&tbs=ic:specific,isc:red\"\r\nfor color red";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 404);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSelJar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCreateZip);
            this.Controls.Add(this.btnOpenDataFolder);
            this.Controls.Add(this.btnGetImages);
            this.Controls.Add(this.btnExtractJar);
            this.Name = "frmMain";
            this.Text = "MC Google Images";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExtractJar;
        private System.Windows.Forms.Button btnOpenDataFolder;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnGetImages;
        private System.Windows.Forms.GroupBox groupBox1;
        private EsseivaN.Controls.TextboxWatermark txtPixelsH;
        private EsseivaN.Controls.TextboxWatermark txtPixelsW;
        private System.Windows.Forms.ComboBox cbResizeMode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private EsseivaN.Controls.TextboxWatermark txtTag;
        private System.Windows.Forms.CheckBox chbTag;
        private System.Windows.Forms.Button btnCreateZip;
        private System.Windows.Forms.CheckBox chbRnd;
        private EsseivaN.Controls.TextboxWatermark txtImgIndex;
        private System.Windows.Forms.Button btnSelJar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cbBackground;
        private System.Windows.Forms.Panel visuBackground;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.CheckBox chbTrans;
        private EsseivaN.Controls.TextboxWatermark txtTags;
        private System.Windows.Forms.TextBox textBox1;
    }
}

