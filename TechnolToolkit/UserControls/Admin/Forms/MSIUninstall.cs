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
        public Color themeColor = Color.FromArgb(174, 0, 0);
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
            buttonSearch.Enabled = false;
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
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            kliknutiNeboEnter();
        }

        private void textBoxComputerName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputerName.Text == "" && checkBoxTentoPC.Checked == false)
            {
                buttonSearch.Enabled = false;
            }
            else
            {
                buttonSearch.Enabled = true;
            }
        }

        private void textBoxMSIstring_TextChanged(object sender, EventArgs e)
        {
            if(textBoxMSIstring.Text == "")
            {
                buttonSearch.Enabled = false;
            }
            else
            {
                buttonSearch.Enabled = true;
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

        private void MSIUninstall_Paint(object sender, PaintEventArgs e)
        {
            PointF computerTxt = new PointF(textBoxComputerName.FindForm().PointToClient(textBoxComputerName.Parent.PointToScreen(textBoxComputerName.Location)).X,
                textBoxComputerName.FindForm().PointToClient(textBoxComputerName.Parent.PointToScreen(textBoxComputerName.Location)).Y);
            e.Graphics.DrawLine(new Pen(themeColor, 1), computerTxt.X, computerTxt.Y + textBoxComputerName.Height + 2, computerTxt.X + textBoxComputerName.Width, computerTxt.Y + textBoxComputerName.Height + 2);

            PointF msiTxt = new PointF(textBoxMSIstring.FindForm().PointToClient(textBoxMSIstring.Parent.PointToScreen(textBoxMSIstring.Location)).X,
                textBoxMSIstring.FindForm().PointToClient(textBoxMSIstring.Parent.PointToScreen(textBoxMSIstring.Location)).Y);
            
            e.Graphics.DrawLine(new Pen(themeColor, 1),msiTxt.X,msiTxt.Y + textBoxMSIstring.Height + 2, msiTxt.X + textBoxMSIstring.Width, msiTxt.Y + textBoxMSIstring.Height + 2);
        }
    }
}
