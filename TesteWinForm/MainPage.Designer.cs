namespace MiniFCUServer
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.PanelSideBar = new System.Windows.Forms.Panel();
            this.PanelLogoContainer = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.PanelVolumeMixer = new System.Windows.Forms.Panel();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.LBLHeader = new System.Windows.Forms.Label();
            this.textSeverStatus = new System.Windows.Forms.Label();
            this.PanelShortcuts = new System.Windows.Forms.Panel();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.ListContainerVolumeMixer = new System.Windows.Forms.FlowLayoutPanel();
            this.Header = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.LBLSavedPrograms = new System.Windows.Forms.Label();
            this.HeaderBarR = new System.Windows.Forms.Panel();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.HeaderBarL = new System.Windows.Forms.Panel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerToRefresh = new System.Windows.Forms.Timer(this.components);
            this.ServerStatusRefresh = new System.Windows.Forms.Timer(this.components);
            this.PanelSideBar.SuspendLayout();
            this.PanelLogoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.PanelVolumeMixer.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.PanelMain.SuspendLayout();
            this.Header.SuspendLayout();
            this.HeaderBarR.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSideBar
            // 
            this.PanelSideBar.BackColor = System.Drawing.Color.White;
            this.PanelSideBar.Controls.Add(this.PanelLogoContainer);
            this.PanelSideBar.Controls.Add(this.HeaderBarL);
            this.PanelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelSideBar.Location = new System.Drawing.Point(0, 0);
            this.PanelSideBar.Name = "PanelSideBar";
            this.PanelSideBar.Size = new System.Drawing.Size(180, 700);
            this.PanelSideBar.TabIndex = 0;
            // 
            // PanelLogoContainer
            // 
            this.PanelLogoContainer.Controls.Add(this.Logo);
            this.PanelLogoContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLogoContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelLogoContainer.Name = "PanelLogoContainer";
            this.PanelLogoContainer.Size = new System.Drawing.Size(180, 118);
            this.PanelLogoContainer.TabIndex = 0;
            this.PanelLogoContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseDown);
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(42, 49);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(96, 21);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // PanelVolumeMixer
            // 
            this.PanelVolumeMixer.AutoSize = true;
            this.PanelVolumeMixer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.PanelVolumeMixer.Controls.Add(this.PanelHeader);
            this.PanelVolumeMixer.Controls.Add(this.PanelShortcuts);
            this.PanelVolumeMixer.Controls.Add(this.PanelMain);
            this.PanelVolumeMixer.Controls.Add(this.HeaderBarR);
            this.PanelVolumeMixer.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelVolumeMixer.Location = new System.Drawing.Point(181, 0);
            this.PanelVolumeMixer.Margin = new System.Windows.Forms.Padding(0);
            this.PanelVolumeMixer.Name = "PanelVolumeMixer";
            this.PanelVolumeMixer.Padding = new System.Windows.Forms.Padding(32, 48, 32, 16);
            this.PanelVolumeMixer.Size = new System.Drawing.Size(419, 700);
            this.PanelVolumeMixer.TabIndex = 1;
            // 
            // PanelHeader
            // 
            this.PanelHeader.Controls.Add(this.LBLHeader);
            this.PanelHeader.Controls.Add(this.textSeverStatus);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(32, 48);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(355, 31);
            this.PanelHeader.TabIndex = 4;
            // 
            // LBLHeader
            // 
            this.LBLHeader.BackColor = System.Drawing.Color.Transparent;
            this.LBLHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.LBLHeader.Font = new System.Drawing.Font("Manrope ExtraBold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.LBLHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LBLHeader.Location = new System.Drawing.Point(0, 0);
            this.LBLHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 32);
            this.LBLHeader.Name = "LBLHeader";
            this.LBLHeader.Size = new System.Drawing.Size(117, 31);
            this.LBLHeader.TabIndex = 0;
            this.LBLHeader.Text = "Volume Mixer";
            this.LBLHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textSeverStatus
            // 
            this.textSeverStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.textSeverStatus.Enabled = false;
            this.textSeverStatus.Font = new System.Drawing.Font("Manrope Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSeverStatus.Location = new System.Drawing.Point(106, 0);
            this.textSeverStatus.Name = "textSeverStatus";
            this.textSeverStatus.Size = new System.Drawing.Size(249, 31);
            this.textSeverStatus.TabIndex = 3;
            this.textSeverStatus.Text = "Iniciando servidor";
            this.textSeverStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PanelShortcuts
            // 
            this.PanelShortcuts.BackColor = System.Drawing.Color.White;
            this.PanelShortcuts.Location = new System.Drawing.Point(36, 488);
            this.PanelShortcuts.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.PanelShortcuts.Name = "PanelShortcuts";
            this.PanelShortcuts.Size = new System.Drawing.Size(351, 193);
            this.PanelShortcuts.TabIndex = 2;
            // 
            // PanelMain
            // 
            this.PanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMain.BackColor = System.Drawing.Color.Transparent;
            this.PanelMain.Controls.Add(this.ListContainerVolumeMixer);
            this.PanelMain.Controls.Add(this.Header);
            this.PanelMain.Location = new System.Drawing.Point(36, 105);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(368, 357);
            this.PanelMain.TabIndex = 1;
            // 
            // ListContainerVolumeMixer
            // 
            this.ListContainerVolumeMixer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListContainerVolumeMixer.AutoScroll = true;
            this.ListContainerVolumeMixer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListContainerVolumeMixer.CausesValidation = false;
            this.ListContainerVolumeMixer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ListContainerVolumeMixer.Location = new System.Drawing.Point(0, 51);
            this.ListContainerVolumeMixer.Margin = new System.Windows.Forms.Padding(0);
            this.ListContainerVolumeMixer.Name = "ListContainerVolumeMixer";
            this.ListContainerVolumeMixer.Size = new System.Drawing.Size(371, 305);
            this.ListContainerVolumeMixer.TabIndex = 1;
            this.ListContainerVolumeMixer.WrapContents = false;
            // 
            // Header
            // 
            this.Header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Header.AutoSize = true;
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.Header.Controls.Add(this.AddButton);
            this.Header.Controls.Add(this.LBLSavedPrograms);
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Margin = new System.Windows.Forms.Padding(3, 3, 3, 18);
            this.Header.Name = "Header";
            this.Header.Padding = new System.Windows.Forms.Padding(0, 0, 18, 0);
            this.Header.Size = new System.Drawing.Size(371, 32);
            this.Header.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddButton.BackgroundImage")));
            this.AddButton.CausesValidation = false;
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(321, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 32);
            this.AddButton.TabIndex = 0;
            this.AddButton.TabStop = false;
            this.AddButton.UseMnemonic = false;
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddAppButton_Click);
            // 
            // LBLSavedPrograms
            // 
            this.LBLSavedPrograms.Dock = System.Windows.Forms.DockStyle.Left;
            this.LBLSavedPrograms.Font = new System.Drawing.Font("Manrope SemiBold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.LBLSavedPrograms.Location = new System.Drawing.Point(0, 0);
            this.LBLSavedPrograms.Margin = new System.Windows.Forms.Padding(0);
            this.LBLSavedPrograms.Name = "LBLSavedPrograms";
            this.LBLSavedPrograms.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.LBLSavedPrograms.Size = new System.Drawing.Size(131, 32);
            this.LBLSavedPrograms.TabIndex = 0;
            this.LBLSavedPrograms.Text = "Programas Salvos";
            this.LBLSavedPrograms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HeaderBarR
            // 
            this.HeaderBarR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeaderBarR.Controls.Add(this.BtnMinimize);
            this.HeaderBarR.Controls.Add(this.BtnClose);
            this.HeaderBarR.Location = new System.Drawing.Point(0, 0);
            this.HeaderBarR.Name = "HeaderBarR";
            this.HeaderBarR.Size = new System.Drawing.Size(419, 32);
            this.HeaderBarR.TabIndex = 1;
            this.HeaderBarR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseDown);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.BtnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMinimize.BackgroundImage")));
            this.BtnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMinimize.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMinimize.FlatAppearance.BorderSize = 0;
            this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimize.Location = new System.Drawing.Point(323, 0);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(48, 32);
            this.BtnMinimize.TabIndex = 1;
            this.BtnMinimize.TabStop = false;
            this.BtnMinimize.UseVisualStyleBackColor = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.BtnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClose.BackgroundImage")));
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Location = new System.Drawing.Point(371, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(48, 32);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.TabStop = false;
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnClose.UseMnemonic = false;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.BtnClose.MouseEnter += new System.EventHandler(this.BtnClose_MouseEnter);
            this.BtnClose.MouseLeave += new System.EventHandler(this.BtnClose_MouseLeave);
            // 
            // HeaderBarL
            // 
            this.HeaderBarL.BackColor = System.Drawing.Color.White;
            this.HeaderBarL.Location = new System.Drawing.Point(0, 0);
            this.HeaderBarL.Name = "HeaderBarL";
            this.HeaderBarL.Size = new System.Drawing.Size(180, 32);
            this.HeaderBarL.TabIndex = 2;
            this.HeaderBarL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderBar_MouseDown);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "O miniFCU server ainda está rodando!";
            this.notifyIcon.BalloonTipTitle = "miniFCU Server";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIcon_Click);
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // timerToRefresh
            // 
            this.timerToRefresh.Enabled = true;
            this.timerToRefresh.Interval = 1000;
            this.timerToRefresh.Tick += new System.EventHandler(this.RefreshItemsMixerList_Tick);
            // 
            // ServerStatusRefresh
            // 
            this.ServerStatusRefresh.Enabled = true;
            this.ServerStatusRefresh.Interval = 1000;
            this.ServerStatusRefresh.Tick += new System.EventHandler(this.ServerStatusRefresh_Tick);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.PanelVolumeMixer);
            this.Controls.Add(this.PanelSideBar);
            this.Font = new System.Drawing.Font("Manrope", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1200, 200);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "miniFCU - Server";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.PanelSideBar.ResumeLayout(false);
            this.PanelLogoContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.PanelVolumeMixer.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.Header.ResumeLayout(false);
            this.HeaderBarR.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelSideBar;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel PanelLogoContainer;
        private System.Windows.Forms.Panel PanelVolumeMixer;
        private System.Windows.Forms.Label LBLHeader;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label LBLSavedPrograms;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Panel PanelShortcuts;
        private System.Windows.Forms.Panel HeaderBarR;
        private System.Windows.Forms.Panel HeaderBarL;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.FlowLayoutPanel ListContainerVolumeMixer;
        private System.Windows.Forms.Timer timerToRefresh;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Label textSeverStatus;
        private System.Windows.Forms.Timer ServerStatusRefresh;
    }
}