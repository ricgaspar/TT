using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class statusBox : Form
    {
        public int runningSeconds = 0;
        public statusBox()
        {
            InitializeComponent();
            Timer timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Start();
            timer1.Tick += new System.EventHandler(timer1_Tick);
        }
        

        private void statusBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Opravdu chcete restartovat aplikaci?", "Potvrzení restartu aplikace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                string cesta = Application.ExecutablePath;
                Process p = new Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c timeout /t 1 > nul &" + cesta;
                p.Start();
                Application.Exit();
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            runningSeconds++;
            labelRunningForAmmountOfTime.Text = "Běží již " + runningSeconds.ToString() + " sekund";
        }
    }
}
