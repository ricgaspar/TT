using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class DeleteFiles : Form
    {
        public DeleteFiles()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            { 
                Process.Start(@"c:\ProgramData\TechnolToolkit\Logs");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(100, 100, 100), 1),0,0,pictureBox1.Width,0);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            { 
                Process.Start(@"c:\ProgramData\TechnolToolkit\VAS6154_Configurator\");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
}

        private void linkLabelRootTT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(@"c:\ProgramData\TechnolToolkit\");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
}

        private void buttonVASconfigDel_Click(object sender, EventArgs e)
        {
            try { 
                if (Directory.Exists(@"c:\ProgramData\TechnolToolkit\VAS6154_Configurator"))
                    Directory.Delete(@"c:\ProgramData\TechnolToolkit\VAS6154_Configurator",true);
                if (!Directory.Exists(@"c:\ProgramData\TechnolToolkit\VAS6154_Configurator"))
                    MessageBox.Show("Složka VAS6154_Configurator úspěšně smazána", "Úspěch");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
}

        private void buttonLogsDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(@"c:\ProgramData\TechnolToolkit\Logs"))
                    Directory.Delete(@"c:\ProgramData\TechnolToolkit\Logs",true);
                if (!Directory.Exists(@"c:\ProgramData\TechnolToolkit\Logs"))
                    MessageBox.Show("Složka Logs úspěšně smazána", "Úspěch");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
}

        private void buttonRootTTDel_Click(object sender, EventArgs e)
        {
            try {
                if (Directory.Exists(@"c:\ProgramData\TechnolToolkit"))
                    Directory.Delete(@"c:\ProgramData\TechnolToolkit",true);
                if (!Directory.Exists(@"c:\ProgramData\TechnolToolkit"))
                    MessageBox.Show("Složka TechnolToolkit úspěšně smazána", "Úspěch");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
