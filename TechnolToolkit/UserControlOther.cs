using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TechnolToolkit
{
    public partial class UserControlOther : UserControl
    {
        int picSize = 90;
        public UserControlOther()
        {
            InitializeComponent();
        }

        private void buttonInfoPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Laptop_96, picSize, picSize), (buttonInfoPC.Width / 2) - (picSize / 2), 5);
        }

        private void buttonIPConfig_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Network_Card_96, picSize, picSize), (buttonIPConfig.Width / 2) - (picSize / 2), 5);
        }

        private void buttonRegSearch_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Registry_Editor_96, picSize, picSize), (buttonRegSearch.Width / 2) - (picSize / 2), 5);
        }

        private void buttonVAS_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Support_96, picSize, picSize), (buttonVAS.Width / 2) - (picSize / 2), 5);
        }

        private void buttonASCII_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Name_Tag_96, picSize, picSize), (buttonASCII.Width / 2) - (picSize / 2), 5);
        }

        private void buttonInfoPC_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\PC_INFO.hta";
            p.Start();
        }

        private void buttonUserPCname_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Name_Tag_96, picSize, picSize), (buttonUserPCname.Width / 2) - (picSize / 2), 5);
        }
    }
}
