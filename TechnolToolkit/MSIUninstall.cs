﻿using System;
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

        private void buttonOK_Click(object sender, EventArgs e)
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
            textBoxComputerName.Text = "Jméno pc";
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
    }
}
