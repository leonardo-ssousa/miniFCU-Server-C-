namespace MiniFCUServer
{
    partial class ItemListVolumeMixer
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListVolumeMixer));
            this.Main = new System.Windows.Forms.Panel();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.lblFriendlyName = new System.Windows.Forms.Label();
            this.DeletePanel1 = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.VolumePanel = new System.Windows.Forms.Panel();
            this.lblVolume = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.GetVolumeValueHate = new System.Windows.Forms.Timer(this.components);
            this.itemIcon = new System.Windows.Forms.PictureBox();
            this.ItIndex = new System.Windows.Forms.Label();
            this.VolumeBar = new System.Windows.Forms.Panel();
            this.Main.SuspendLayout();
            this.DeletePanel1.SuspendLayout();
            this.VolumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.BackColor = System.Drawing.Color.Transparent;
            this.Main.Controls.Add(this.lblProcessName);
            this.Main.Controls.Add(this.lblFriendlyName);
            this.Main.Dock = System.Windows.Forms.DockStyle.Left;
            this.Main.Location = new System.Drawing.Point(84, 8);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.Main.Size = new System.Drawing.Size(167, 42);
            this.Main.TabIndex = 1;
            // 
            // lblProcessName
            // 
            this.lblProcessName.BackColor = System.Drawing.Color.Transparent;
            this.lblProcessName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcessName.Font = new System.Drawing.Font("Manrope SemiBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblProcessName.ForeColor = System.Drawing.Color.Gray;
            this.lblProcessName.Location = new System.Drawing.Point(6, 0);
            this.lblProcessName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblProcessName.Size = new System.Drawing.Size(161, 19);
            this.lblProcessName.TabIndex = 0;
            this.lblProcessName.Text = "Processo: discord";
            this.lblProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFriendlyName
            // 
            this.lblFriendlyName.BackColor = System.Drawing.Color.Transparent;
            this.lblFriendlyName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFriendlyName.Font = new System.Drawing.Font("Manrope", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblFriendlyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblFriendlyName.Location = new System.Drawing.Point(6, 11);
            this.lblFriendlyName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.lblFriendlyName.Name = "lblFriendlyName";
            this.lblFriendlyName.Size = new System.Drawing.Size(161, 31);
            this.lblFriendlyName.TabIndex = 1;
            this.lblFriendlyName.Text = "Discord";
            this.lblFriendlyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DeletePanel1
            // 
            this.DeletePanel1.Controls.Add(this.DeleteButton);
            this.DeletePanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeletePanel1.Location = new System.Drawing.Point(304, 8);
            this.DeletePanel1.Name = "DeletePanel1";
            this.DeletePanel1.Size = new System.Drawing.Size(35, 42);
            this.DeletePanel1.TabIndex = 2;
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteButton.BackgroundImage")));
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Location = new System.Drawing.Point(9, 11);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(18, 18);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // VolumePanel
            // 
            this.VolumePanel.Controls.Add(this.lblVolume);
            this.VolumePanel.Controls.Add(this.pictureBox2);
            this.VolumePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.VolumePanel.Location = new System.Drawing.Point(229, 8);
            this.VolumePanel.Name = "VolumePanel";
            this.VolumePanel.Size = new System.Drawing.Size(75, 42);
            this.VolumePanel.TabIndex = 3;
            // 
            // lblVolume
            // 
            this.lblVolume.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVolume.Font = new System.Drawing.Font("Manrope SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.Location = new System.Drawing.Point(21, 0);
            this.lblVolume.Margin = new System.Windows.Forms.Padding(0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(54, 42);
            this.lblVolume.TabIndex = 1;
            this.lblVolume.Text = "100 %";
            this.lblVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // GetVolumeValueHate
            // 
            this.GetVolumeValueHate.Enabled = true;
            this.GetVolumeValueHate.Tick += new System.EventHandler(this.GetVolumeValueHate_Tick);
            // 
            // itemIcon
            // 
            this.itemIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.itemIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemIcon.Image = ((System.Drawing.Image)(resources.GetObject("itemIcon.Image")));
            this.itemIcon.Location = new System.Drawing.Point(42, 8);
            this.itemIcon.Name = "itemIcon";
            this.itemIcon.Size = new System.Drawing.Size(42, 42);
            this.itemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.itemIcon.TabIndex = 5;
            this.itemIcon.TabStop = false;
            // 
            // ItIndex
            // 
            this.ItIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.ItIndex.Font = new System.Drawing.Font("Manrope", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ItIndex.Location = new System.Drawing.Point(8, 8);
            this.ItIndex.Margin = new System.Windows.Forms.Padding(0);
            this.ItIndex.Name = "ItIndex";
            this.ItIndex.Padding = new System.Windows.Forms.Padding(6);
            this.ItIndex.Size = new System.Drawing.Size(34, 42);
            this.ItIndex.TabIndex = 6;
            this.ItIndex.Text = "10";
            this.ItIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VolumeBar
            // 
            this.VolumeBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.VolumeBar.Location = new System.Drawing.Point(0, 55);
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(347, 3);
            this.VolumeBar.TabIndex = 2;
            // 
            // ItemListVolumeMixer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.VolumePanel);
            this.Controls.Add(this.DeletePanel1);
            this.Controls.Add(this.Main);
            this.Controls.Add(this.itemIcon);
            this.Controls.Add(this.ItIndex);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
            this.Name = "ItemListVolumeMixer";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(347, 58);
            this.Load += new System.EventHandler(this.ItemListVolumeMixer_Load);
            this.Main.ResumeLayout(false);
            this.DeletePanel1.ResumeLayout(false);
            this.VolumePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Main;
        private System.Windows.Forms.Label lblFriendlyName;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Panel DeletePanel1;
        private System.Windows.Forms.Panel VolumePanel;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Timer GetVolumeValueHate;
        private System.Windows.Forms.PictureBox itemIcon;
        private System.Windows.Forms.Label ItIndex;
        private System.Windows.Forms.Panel VolumeBar;
    }
}
