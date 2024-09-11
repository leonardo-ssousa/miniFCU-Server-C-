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
    public partial class ModalAddApp : Form
    {
        Main main = new Main();

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
        public ModalAddApp()
        {
            InitializeComponent();
        }

        private void ModalAddApp_Load(object sender, EventArgs e)
        {
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 12, 12));
            SaveButton.Region = Region.FromHrgn(CreateRoundRectRgn(0,0, SaveButton.Width, SaveButton.Height, 6, 6));

            ProcessDropDown.Items.Clear();
            foreach (var process in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(WinMixerAPI.GetApplicationVolume(process.Id).ToString()) && process.ProcessName != "Idle")
                {
                    ProcessDropDown.Items.Add(process.ProcessName);
                }
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            main.lastItensCont = 0;
            this.Close();
        }


        string appConfig = Application.StartupPath + @"\appConfig.ini";
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var cfg = new ConfigParser(appConfig);

            cfg.SetValue("FRIENDLY NAMES", ProcessDropDown.Text, friendlyNameInput.Text);
            Console.WriteLine(ProcessDropDown.Text + " salvo como: " + friendlyNameInput.Text);
            cfg.Save();
            this.Close();
        }

        private void ProcessDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cfg = new ConfigParser(appConfig);

            foreach (var key in cfg["FRIENDLY NAMES"].Keys)
            {
                if(key.Name.ToString() == ProcessDropDown.Text)
                {
                    friendlyNameInput.Text = cfg["FRIENDLY NAMES"][key.Name];
                    Console.WriteLine(cfg["FRIENDLY NAMES"][key.Name]);
                }
            }
        }
    }
}
