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
    public partial class SplashScreen : Form
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

        public SplashScreen()
        {
            InitializeComponent();
            (new MiniFCUServer.DropShadow()).ApplyShadows(this);
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width, Height, 12, 12));
        }

        int splashTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            splashTime++;

            //Debug.WriteLine(splashTime.ToString());

            if (splashTime > 20)
            {
                timer1.Enabled = false;
                MainPage main = new MainPage();
                main.Show();
                this.Hide();
            }
        }
    }
}
