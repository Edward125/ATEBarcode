namespace SBBarcode
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.timerDelay = new System.Windows.Forms.Timer(this.components);
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReadBarcode = new System.Windows.Forms.Button();
            this.btnCapturePic = new System.Windows.Forms.Button();
            this.txtImg = new System.Windows.Forms.TextBox();
            this.btnOpenCam = new System.Windows.Forms.Button();
            this.btnCloseCam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboCam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshCam = new System.Windows.Forms.Button();
            this.txtHWID = new System.Windows.Forms.TextBox();
            this.txtSNFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLeftASN = new System.Windows.Forms.TextBox();
            this.txtLeftBSN = new System.Windows.Forms.TextBox();
            this.txtRightASN = new System.Windows.Forms.TextBox();
            this.txtRightBSN = new System.Windows.Forms.TextBox();
            this.txtLeftAHWID = new System.Windows.Forms.TextBox();
            this.txtLeftBHWID = new System.Windows.Forms.TextBox();
            this.txtRightAHWID = new System.Windows.Forms.TextBox();
            this.txtRightBHWID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstMsg = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSourcePlayer1.BackColor = System.Drawing.Color.Black;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(3, 3);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(510, 355);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // timerDelay
            // 
            this.timerDelay.Interval = 10;
            this.timerDelay.Tick += new System.EventHandler(this.timerDelay_Tick);
            // 
            // picCapture
            // 
            this.picCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picCapture.Location = new System.Drawing.Point(519, 3);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(511, 355);
            this.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCapture.TabIndex = 4;
            this.picCapture.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.videoSourcePlayer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picCapture, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstMsg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1033, 602);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btnReadBarcode
            // 
            this.btnReadBarcode.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReadBarcode.FlatAppearance.BorderSize = 0;
            this.btnReadBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadBarcode.Location = new System.Drawing.Point(321, 43);
            this.btnReadBarcode.Name = "btnReadBarcode";
            this.btnReadBarcode.Size = new System.Drawing.Size(102, 26);
            this.btnReadBarcode.TabIndex = 13;
            this.btnReadBarcode.Text = "Read Barcode";
            this.btnReadBarcode.UseVisualStyleBackColor = false;
            this.btnReadBarcode.Click += new System.EventHandler(this.btnReadBarcode_Click);
            // 
            // btnCapturePic
            // 
            this.btnCapturePic.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCapturePic.FlatAppearance.BorderSize = 0;
            this.btnCapturePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturePic.Location = new System.Drawing.Point(188, 43);
            this.btnCapturePic.Name = "btnCapturePic";
            this.btnCapturePic.Size = new System.Drawing.Size(121, 26);
            this.btnCapturePic.TabIndex = 11;
            this.btnCapturePic.Text = "Capture Picture";
            this.btnCapturePic.UseVisualStyleBackColor = false;
            this.btnCapturePic.EnabledChanged += new System.EventHandler(this.btnCapturePic_EnabledChanged);
            this.btnCapturePic.Click += new System.EventHandler(this.btnCapturePic_Click);
            // 
            // txtImg
            // 
            this.txtImg.Location = new System.Drawing.Point(74, 211);
            this.txtImg.Name = "txtImg";
            this.txtImg.Size = new System.Drawing.Size(405, 21);
            this.txtImg.TabIndex = 12;
            this.txtImg.DoubleClick += new System.EventHandler(this.txtImg_DoubleClick);
            // 
            // btnOpenCam
            // 
            this.btnOpenCam.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOpenCam.FlatAppearance.BorderSize = 0;
            this.btnOpenCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenCam.Location = new System.Drawing.Point(16, 43);
            this.btnOpenCam.Name = "btnOpenCam";
            this.btnOpenCam.Size = new System.Drawing.Size(79, 26);
            this.btnOpenCam.TabIndex = 9;
            this.btnOpenCam.Text = "Open Cam ";
            this.btnOpenCam.UseVisualStyleBackColor = false;
            this.btnOpenCam.EnabledChanged += new System.EventHandler(this.btnOpenCam_EnabledChanged);
            this.btnOpenCam.Click += new System.EventHandler(this.btnOpenCam_Click);
            // 
            // btnCloseCam
            // 
            this.btnCloseCam.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCloseCam.FlatAppearance.BorderSize = 0;
            this.btnCloseCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseCam.Location = new System.Drawing.Point(107, 43);
            this.btnCloseCam.Name = "btnCloseCam";
            this.btnCloseCam.Size = new System.Drawing.Size(69, 26);
            this.btnCloseCam.TabIndex = 10;
            this.btnCloseCam.Text = "Close Cam";
            this.btnCloseCam.UseVisualStyleBackColor = false;
            this.btnCloseCam.EnabledChanged += new System.EventHandler(this.btnCloseCam_EnabledChanged);
            this.btnCloseCam.Click += new System.EventHandler(this.btnCloseCam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Img Path:";
            // 
            // comboCam
            // 
            this.comboCam.FormattingEnabled = true;
            this.comboCam.Location = new System.Drawing.Point(46, 12);
            this.comboCam.Name = "comboCam";
            this.comboCam.Size = new System.Drawing.Size(119, 20);
            this.comboCam.TabIndex = 15;
            this.comboCam.SelectedIndexChanged += new System.EventHandler(this.comboCam_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "CAM:";
            // 
            // btnRefreshCam
            // 
            this.btnRefreshCam.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRefreshCam.FlatAppearance.BorderSize = 0;
            this.btnRefreshCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshCam.Location = new System.Drawing.Point(436, 43);
            this.btnRefreshCam.Name = "btnRefreshCam";
            this.btnRefreshCam.Size = new System.Drawing.Size(59, 26);
            this.btnRefreshCam.TabIndex = 17;
            this.btnRefreshCam.Text = "Get CAM";
            this.btnRefreshCam.UseVisualStyleBackColor = false;
            this.btnRefreshCam.Click += new System.EventHandler(this.btnRefreshCam_Click);
            // 
            // txtHWID
            // 
            this.txtHWID.Location = new System.Drawing.Point(171, 12);
            this.txtHWID.Name = "txtHWID";
            this.txtHWID.ReadOnly = true;
            this.txtHWID.Size = new System.Drawing.Size(324, 21);
            this.txtHWID.TabIndex = 18;
            // 
            // txtSNFolder
            // 
            this.txtSNFolder.Location = new System.Drawing.Point(114, 184);
            this.txtSNFolder.Name = "txtSNFolder";
            this.txtSNFolder.Size = new System.Drawing.Size(365, 21);
            this.txtSNFolder.TabIndex = 19;
            this.txtSNFolder.TextChanged += new System.EventHandler(this.txtSNFolder_TextChanged);
            this.txtSNFolder.DoubleClick += new System.EventHandler(this.txtSNFolder_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "Save SN Folder:";
            // 
            // txtLeftASN
            // 
            this.txtLeftASN.Location = new System.Drawing.Point(63, 75);
            this.txtLeftASN.Name = "txtLeftASN";
            this.txtLeftASN.Size = new System.Drawing.Size(102, 21);
            this.txtLeftASN.TabIndex = 22;
            this.txtLeftASN.TextChanged += new System.EventHandler(this.txtLeftASN_TextChanged);
            // 
            // txtLeftBSN
            // 
            this.txtLeftBSN.Location = new System.Drawing.Point(63, 102);
            this.txtLeftBSN.Name = "txtLeftBSN";
            this.txtLeftBSN.Size = new System.Drawing.Size(102, 21);
            this.txtLeftBSN.TabIndex = 23;
            this.txtLeftBSN.TextChanged += new System.EventHandler(this.txtLeftBSN_TextChanged);
            // 
            // txtRightASN
            // 
            this.txtRightASN.Location = new System.Drawing.Point(63, 129);
            this.txtRightASN.Name = "txtRightASN";
            this.txtRightASN.Size = new System.Drawing.Size(102, 21);
            this.txtRightASN.TabIndex = 24;
            this.txtRightASN.TextChanged += new System.EventHandler(this.txtRightASN_TextChanged);
            // 
            // txtRightBSN
            // 
            this.txtRightBSN.Location = new System.Drawing.Point(63, 156);
            this.txtRightBSN.Name = "txtRightBSN";
            this.txtRightBSN.Size = new System.Drawing.Size(102, 21);
            this.txtRightBSN.TabIndex = 25;
            this.txtRightBSN.TextChanged += new System.EventHandler(this.txtRightBSN_TextChanged);
            // 
            // txtLeftAHWID
            // 
            this.txtLeftAHWID.Location = new System.Drawing.Point(171, 75);
            this.txtLeftAHWID.Name = "txtLeftAHWID";
            this.txtLeftAHWID.Size = new System.Drawing.Size(308, 21);
            this.txtLeftAHWID.TabIndex = 26;
            this.txtLeftAHWID.TextChanged += new System.EventHandler(this.txtLeftAHWID_TextChanged);
            // 
            // txtLeftBHWID
            // 
            this.txtLeftBHWID.Location = new System.Drawing.Point(171, 102);
            this.txtLeftBHWID.Name = "txtLeftBHWID";
            this.txtLeftBHWID.Size = new System.Drawing.Size(308, 21);
            this.txtLeftBHWID.TabIndex = 27;
            this.txtLeftBHWID.TextChanged += new System.EventHandler(this.txtLeftBHWID_TextChanged);
            // 
            // txtRightAHWID
            // 
            this.txtRightAHWID.Location = new System.Drawing.Point(171, 129);
            this.txtRightAHWID.Name = "txtRightAHWID";
            this.txtRightAHWID.Size = new System.Drawing.Size(308, 21);
            this.txtRightAHWID.TabIndex = 28;
            this.txtRightAHWID.TextChanged += new System.EventHandler(this.txtRightAHWID_TextChanged);
            // 
            // txtRightBHWID
            // 
            this.txtRightBHWID.Location = new System.Drawing.Point(171, 156);
            this.txtRightBHWID.Name = "txtRightBHWID";
            this.txtRightBHWID.Size = new System.Drawing.Size(308, 21);
            this.txtRightBHWID.TabIndex = 29;
            this.txtRightBHWID.TextChanged += new System.EventHandler(this.txtRightBHWID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "Left A:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "Left B:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "Rigth A:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "Rigth B:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRightBHWID);
            this.panel1.Controls.Add(this.txtRightAHWID);
            this.panel1.Controls.Add(this.txtLeftBHWID);
            this.panel1.Controls.Add(this.txtLeftAHWID);
            this.panel1.Controls.Add(this.txtRightBSN);
            this.panel1.Controls.Add(this.txtRightASN);
            this.panel1.Controls.Add(this.txtLeftBSN);
            this.panel1.Controls.Add(this.txtLeftASN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSNFolder);
            this.panel1.Controls.Add(this.txtHWID);
            this.panel1.Controls.Add(this.btnRefreshCam);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboCam);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCloseCam);
            this.panel1.Controls.Add(this.btnOpenCam);
            this.panel1.Controls.Add(this.txtImg);
            this.panel1.Controls.Add(this.btnCapturePic);
            this.panel1.Controls.Add(this.btnReadBarcode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(519, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 235);
            this.panel1.TabIndex = 14;
            // 
            // lstMsg
            // 
            this.lstMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.ItemHeight = 12;
            this.lstMsg.Location = new System.Drawing.Point(3, 364);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(510, 232);
            this.lstMsg.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 622);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Timer timerDelay;
        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRightBHWID;
        private System.Windows.Forms.TextBox txtRightAHWID;
        private System.Windows.Forms.TextBox txtLeftBHWID;
        private System.Windows.Forms.TextBox txtLeftAHWID;
        private System.Windows.Forms.TextBox txtRightBSN;
        private System.Windows.Forms.TextBox txtRightASN;
        private System.Windows.Forms.TextBox txtLeftBSN;
        private System.Windows.Forms.TextBox txtLeftASN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSNFolder;
        private System.Windows.Forms.TextBox txtHWID;
        private System.Windows.Forms.Button btnRefreshCam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloseCam;
        private System.Windows.Forms.Button btnOpenCam;
        private System.Windows.Forms.TextBox txtImg;
        private System.Windows.Forms.Button btnCapturePic;
        private System.Windows.Forms.Button btnReadBarcode;
    }
}

