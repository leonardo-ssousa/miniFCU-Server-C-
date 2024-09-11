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
    public partial class Main : Form
    {
        readonly Server server = new Server();

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

        public Main()
        {
            InitializeComponent();
            (new MiniFCUServer.DropShadow()).ApplyShadows(this);
        }


        // Ativa o arrastar da janela 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }


        private void Main_Load(object sender, EventArgs e)
        {
            //VolumeMixerCard.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, VolumeMixerCard.Width, VolumeMixerCard.Height, 12, 12));
            //ShortCutCard.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, ShortCutCard.Width, ShortCutCard.Height, 12, 12));
            //AddAppButton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, AddAppButton.Width, AddAppButton.Height, 7, 7));

            //Inicia na gaveta de apps

            /*
            if (true)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                //notifyIcon.Visible = true;
                //notifyIcon.BalloonTipText = "Servidor rodando!";

                //notifyIcon.ShowBalloonTip(250);
            }
            */

            server.Start();
            GetListeningApps();
        }




        #region TopBarFunctions

        
        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            //closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            //closeButton.BackColor = Color.White;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_MouseEnter(object sender, EventArgs e)
        {
            //minimizeButton.BackColor = Color.Gainsboro;
        }

        private void minimizeButton_MouseLeave(object sender, EventArgs e)
        {
           // minimizeButton.BackColor = Color.Transparent;
        }

        private bool showModalTip = true;
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            //notifyIcon.Visible = true;
            //minimizeButton.BackColor = Color.Transparent;

            if (showModalTip)
            {
                //notifyIcon.BalloonTipText = "O miniFCU Server ainda está aberto.";
                //notifyIcon.ShowBalloonTip(1000);
                showModalTip = false;
            }

        }
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            (new MiniFCUServer.DropShadow()).ApplyShadows(this);
            //notifyIcon.Visible = false;
        }

        #endregion


        //Refresh 1s
        private void RefreshHate_Tick(object sender, EventArgs e)
        {
            if(server.isRunning == "OK")
            {
                //textSeverStatus.Text = "Servidor iniciado: \n" + server.HostIp + "  ";
            } else 
            {
                //textSeverStatus.Text = server.isRunning;
            }
        }


        //Show Modal
        public static int parentX, parentY; 
        private void AddAppButton_Click(object sender, EventArgs e)
        {
            Form modalBackground = new Form();
            using (ModalAddApp modal = new ModalAddApp()) 
            {
                modalBackground.StartPosition = FormStartPosition.Manual;
                modalBackground.FormBorderStyle = FormBorderStyle.None;
                modalBackground.Opacity = 0.50d;
                modalBackground.BackColor = Color.Black;
                modalBackground.Size = this.Size;
                modalBackground.Location = this.Location;
                modalBackground.ShowInTaskbar = false;
                modalBackground.Show();

                modal.Owner = modalBackground;

                parentX = this.Location.X;
                parentY = this.Location.Y;

                modal.ShowDialog();
                modalBackground.Dispose();
            }
        }

        
        //Refresh items volume mixer
        string appConfig = Application.StartupPath + @"\appConfig.ini";
        List<ItemListVolumeMixer> listOfVolumeItems = new List<ItemListVolumeMixer>();
        public int lastItensCont = 0;

        public void GetListeningApps()
        {
            var cfg = new ConfigParser(appConfig);
            listOfVolumeItems.Clear();
            Console.WriteLine("listening apps");


            foreach (var process in Process.GetProcesses())
            {
                foreach (var key in cfg["FRIENDLY NAMES"].Keys)
                {
                    if (process.ProcessName == key.Name.ToString() && key.ValueRaw.ToString() != "")
                    {
                        if (!string.IsNullOrEmpty(WinMixerAPI.GetApplicationVolume(process.Id).ToString()))
                        {
                            ItemListVolumeMixer item = new ItemListVolumeMixer();
                            item.ProcessId = process.Id;
                            item.FriendlyName = key.ValueRaw.ToString();
                            item.ProcessName = process.ProcessName.ToString();
                            //item.ProcessName = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
                            item.VolumeValue = WinMixerAPI.GetApplicationVolume(process.Id).ToString();

                            listOfVolumeItems.Add(item);
                            //ILVolumeMixer.Controls.Add(item);
                        }
                    }
                }
            }

            if(listOfVolumeItems.Count != lastItensCont)
            {
                lastItensCont = listOfVolumeItems.Count;    
                RefreshMixerList();
            }
        }
        public void RefreshMixerList()
        {
            Console.WriteLine("Refresh apps");
            //ILVolumeMixer.Controls.Clear();
            foreach (var item in listOfVolumeItems)
            {
                //ILVolumeMixer.Controls.Add(item);
            }
        }

        private void InitializeComponent()
        {
            /*
            this.itemListVolumeMixer1 = new MiniFCUServer.ItemListVolumeMixer();
            this.SuspendLayout();
            // 
            // itemListVolumeMixer1
            // 
            this.itemListVolumeMixer1.BackColor = System.Drawing.Color.White;
            this.itemListVolumeMixer1.FriendlyName = null;
            this.itemListVolumeMixer1.Location = new System.Drawing.Point(43, 60);
            this.itemListVolumeMixer1.Margin = new System.Windows.Forms.Padding(0);
            this.itemListVolumeMixer1.Name = "itemListVolumeMixer1";
            this.itemListVolumeMixer1.Padding = new System.Windows.Forms.Padding(8);
            this.itemListVolumeMixer1.ProcessId = 0;
            this.itemListVolumeMixer1.ProcessName = null;
            this.itemListVolumeMixer1.Size = new System.Drawing.Size(313, 58);
            this.itemListVolumeMixer1.TabIndex = 0;
            this.itemListVolumeMixer1.VolumeValue = null;
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.itemListVolumeMixer1);
            this.Name = "Main";
            this.ResumeLayout(false); */

        }

        private void RefreshItemsMixerList_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(listOfVolumeItems.Count.ToString());
            Console.WriteLine(lastItensCont);
            GetListeningApps();
        }

        

    }
}
