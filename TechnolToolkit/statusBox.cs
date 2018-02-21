using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class statusBox : Form
    {
        //int remaningTime = 20;
        public statusBox()
        {
            InitializeComponent();
            //timer1.Interval = 1000;
            //timer1.Start();
            //timer1.Tick += new System.EventHandler(timer1_Tick);
        }
        

        private void statusBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Timeout: " + remaningTime + " sekund";
            if (remaningTime <= 0)
            {
                timer1.Stop();
                this.Close();
            } else remaningTime -= 1;            
        }
        */
    }
}
