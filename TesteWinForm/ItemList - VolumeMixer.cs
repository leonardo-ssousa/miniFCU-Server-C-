using Salaros.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniFCUServer
{
    public partial class ItemListVolumeMixer : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public ItemListVolumeMixer()
        {
            InitializeComponent();
        }

        #region Properties
        
        private int _itemIndex;
        private string _processName;
        private string _friendlyName;
        private string _volumeValue;
        private int _processId;
        private Icon _icon;



        public int ItemIndex
        {
            get { return _itemIndex; }
            set { _itemIndex = value; ItIndex.Text = value.ToString(); }
        }


        public Icon ItemIcon
        {
            get { return _icon; }
            set { 
                _icon = value;
                if (_icon != null) { 
                    itemIcon.Image = value.ToBitmap(); 
                    }                
                }
        }



        [Category("Custom Properties")]
        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; lblProcessName.Text = value; }
        }

        [Category("Custom Properties")]
        public string FriendlyName
        {
            get { return _friendlyName; }
            set { _friendlyName = value; lblFriendlyName.Text = value; }
        }


        [Category("Custom Properties")]
        public string VolumeValue
        {
            get { return _volumeValue; }
            set { _volumeValue = value; /* lblVolume.Text = value + "%"; */}
        }

        [Category("Custom Properties")]
        public int ProcessId
        {
            get { return _processId; }
            set { _processId = value;}
        }

        #endregion

       
        private void ItemListVolumeMixer_Load(object sender, EventArgs e)
        {
            lblVolume.Text = $"{WinMixerAPI.GetApplicationVolume(_processId)} %";

            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 8, 8));

        }




        private void GetVolumeValueHate_Tick(object sender, EventArgs e)
        {
            try
            {
                int volumeValue = (int)WinMixerAPI.GetApplicationVolume(_processId);
                lblVolume.Text = volumeValue.ToString() + "%";
                VolumeBar.Width = (volumeValue * this.Width) / 100;
            } catch {
                GetVolumeValueHate.Enabled = false;
            }
        }

        string appConfig = Application.StartupPath + @"\appConfig.ini";
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var cfg = new ConfigParser(appConfig);
            cfg.SetValue("FRIENDLY NAMES", _processName, "");
            Debug.WriteLine($"Delete: {_processName}");
            cfg.Save();
        }
    }
}
