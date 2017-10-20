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
    public partial class MSIUninstall : Form
    {
        public MSIUninstall()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxTentoPC.CheckState == CheckState.Unchecked)
            {
                textBoxComputerName.Enabled = true;
            } else
            {
                textBoxComputerName.Enabled = false;
            }
        }
        public void restartMsiUninstall()
        {
            textBoxMSIstring.Text = "";
            textBoxComputerName.Text = "";
            buttonOK.Enabled = false;
            checkBoxTentoPC.Checked = false;
        }
        private void kliknutiNeboEnter()
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\msi_vyhledavac.vbs";
            if (checkBoxTentoPC.CheckState == CheckState.Unchecked)
            {
                p.StartInfo.Arguments = textBoxComputerName.Text + " \"" + textBoxMSIstring.Text + "\"";
            }
            else
            {
                p.StartInfo.Arguments = "\".\"" + " \"" + textBoxMSIstring.Text + "\"";
            }
            p.Start();
            this.Close();

            checkBoxTentoPC.Checked = true;
            textBoxComputerName.Enabled = false;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            kliknutiNeboEnter();
        }

        private void textBoxComputerName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputerName.Text == "" && checkBoxTentoPC.Checked == false)
            {
                buttonOK.Enabled = false;
            }
            else
            {
                buttonOK.Enabled = true;
            }
        }

        private void textBoxMSIstring_TextChanged(object sender, EventArgs e)
        {
            if(textBoxMSIstring.Text == "")
            {
                buttonOK.Enabled = false;
            }
            else
            {
                buttonOK.Enabled = true;
            }
        }

        private void textBoxComputerName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                if(textBoxMSIstring.Text != "")
                {
                    kliknutiNeboEnter();
                }
        }

        private void textBoxMSIstring_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (textBoxMSIstring.Text != "")
                {
                    kliknutiNeboEnter();
                }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics line = e.Graphics;
            line.DrawLine(new Pen(Brushes.Gray),0,0,pictureBox1.Width,0);
        }
    }
}
