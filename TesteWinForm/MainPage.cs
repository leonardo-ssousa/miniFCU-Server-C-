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
    public partial class MainPage : Form
    {
        Server server = new Server();

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
        public MainPage()
        {
            InitializeComponent();
            (new MiniFCUServer.DropShadow()).ApplyShadows(this);
            server.Start();
        }

        // Ativa o arrastar da janela 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void HeaderBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            GetListeningApps();

            //Abrir na gaveta de apps
            if (true)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipText = $"Servidor rodando! {server.HostIp} ";

                notifyIcon.ShowBalloonTip(250);
            }
            

            #region Shortcuts Config
            PanelShortcuts.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PanelShortcuts.Width, PanelShortcuts.Height, 8, 8));

            int borderSize = 1;
            Panel ShortcutsBorder = new Panel();
            ShortcutsBorder.Location = new Point(PanelShortcuts.Location.X - borderSize, PanelShortcuts.Location.Y - borderSize);
            ShortcutsBorder.Size = new Size(PanelShortcuts.Width + borderSize * 2, PanelShortcuts.Height + borderSize * 2);
            ShortcutsBorder.BackColor = Color.FromArgb(235, 235, 235);
            ShortcutsBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ShortcutsBorder.Width, ShortcutsBorder.Height, 8, 8));
            PanelVolumeMixer.Controls.Add(ShortcutsBorder);
            #endregion


        }


        #region ApplicationStatesConfig
        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            BtnClose.BackColor = Color.Red;
            BtnClose.BackgroundImage = MiniFCUServer.Properties.Resources.close_icon_white;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.BackColor = Color.Transparent;
            BtnClose.BackgroundImage = MiniFCUServer.Properties.Resources.close_icon;
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool isFirstMinimize = true;
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            notifyIcon.Visible = true;
            if (isFirstMinimize)
            {
                notifyIcon.BalloonTipTitle = "miniFCU Server";
                notifyIcon.BalloonTipText = "O miniFCU server ainda está rodando!";
                notifyIcon.ShowBalloonTip(100);
                isFirstMinimize=false;
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            /*
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            (new MiniFCUServer.DropShadow()).ApplyShadows(this);
            notifyIcon.Visible = false; */
        }

        #endregion

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
                modalBackground.Width = this.Size.Width - 1;
                modalBackground.Height = this.Size.Height - 1;
                modalBackground.Location = new Point(this.Location.X + 1, this.Location.Y + 1);
                modalBackground.ShowInTaskbar = false;
                modalBackground.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, modalBackground.Width, modalBackground.Height, 9, 9));
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
            //Console.WriteLine("listening apps");


            foreach (var process in Process.GetProcesses())
            {
                foreach (var key in cfg["FRIENDLY NAMES"].Keys)
                {
                    if (process.ProcessName == key.Name.ToString() && key.ValueRaw.ToString() != "")
                    {
                        if (!string.IsNullOrEmpty(WinMixerAPI.GetApplicationVolume(process.Id).ToString()))
                        {
                            ItemListVolumeMixer item = new ItemListVolumeMixer();
                            item.ItemIndex = listOfVolumeItems.Count;
                            item.ProcessId = process.Id;
                            item.FriendlyName = key.ValueRaw.ToString();
                            item.ProcessName = process.ProcessName.ToString();
                            try
                            {
                                item.ItemIcon = Icon.ExtractAssociatedIcon(process.MainModule.FileName);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                            }
                            item.Width = ListContainerVolumeMixer.Width - 18;

                            listOfVolumeItems.Add(item);
                            //ListContainerVolumeMixer.Controls.Add(item);
                        }
                    }
                }
            }

            if (listOfVolumeItems.Count != lastItensCont) 
            {
                lastItensCont = listOfVolumeItems.Count;
                RefreshMixerList();
            }
        }
        public void RefreshMixerList()
        {
            Console.WriteLine("Refresh apps");
            ListContainerVolumeMixer.Controls.Clear();
            foreach (var item in listOfVolumeItems)
            {
                ListContainerVolumeMixer.Controls.Add(item);
            }
        }
        private void RefreshItemsMixerList_Tick(object sender, EventArgs e)
        {
            GetListeningApps();
        }


        //Refresh server status
        private void ServerStatusRefresh_Tick(object sender, EventArgs e)
        {
            if (server.isRunning == "OK")
            {
                textSeverStatus.Text = "Servidor iniciado: \n" + server.HostIp + "  ";
            }
            else
            {
                textSeverStatus.Text = server.isRunning;
                notifyIcon.BalloonTipText = server.isRunning;
                notifyIcon.ShowBalloonTip(1000);
                ServerStatusRefresh.Enabled = false;

                Debug.WriteLine("Tick error: ");
                Debug.WriteLine(server.isRunning);
            }
        }


    }
}
