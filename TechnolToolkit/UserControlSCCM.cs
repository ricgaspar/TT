using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class UserControlSCCM : UserControl
    {
        public UserControlSCCM()
        {
            InitializeComponent();
        }

        private void buttonKolekce_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Monitor_96,90,90), (buttonKolekce.Width / 2) - (90 / 2), 0);
        }

        private void buttonZasadyPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Monitor_Refresh_96, 90,90), (buttonZasadyPC.Width / 2) - (90 / 2), 0);
        }

        private void buttonAkceVsechny_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Monitor_Star_96, 90, 90), (buttonAkceVsechny.Width / 2) - (90 / 2), 0);
        }
    }
}
