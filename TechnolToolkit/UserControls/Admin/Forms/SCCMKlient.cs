using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnolToolkit.CustomControls_and_Clases;

namespace TechnolToolkit.UserControls.Admin.Forms
{
    public partial class SCCMKlient : Form
    {
        public SCCMKlient()
        {
            InitializeComponent();
        }

        private void stuffActionValidation()
        {
            if(textBoxComputername.Text != "" && textBoxComputername.Text != "Název počítače")
            {
                buttonClearCache.Enabled = true;
                buttonPolicy.Enabled = true;
                buttonRepair.Enabled = true;
                buttonSetCache.Enabled = true;
                numericUpDown1.Enabled = true;
                buttonGetCacheSize.Enabled = true;
            } else
            {
                buttonClearCache.Enabled = false;
                buttonPolicy.Enabled = false;
                buttonRepair.Enabled = false;
                buttonSetCache.Enabled = false;
                numericUpDown1.Enabled = false;
                buttonGetCacheSize.Enabled = false;
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(174, 0, 0), 1), textBoxComputername.Location.X, textBoxComputername.Location.Y + textBoxComputername.Height + 2, textBoxComputername.Location.X + textBoxComputername.Width, textBoxComputername.Location.Y + textBoxComputername.Height + 2);
        }

        private void textBoxComputername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.Text.Contains("Název počítače"))
            {
                textBoxComputername.Text = textBoxComputername.Text.Replace("Název počítače", "");
                textBoxComputername.ForeColor = Color.White;
                textBoxComputername.SelectionStart = 1;
                textBoxComputername.SelectionLength = 0;
            }
            stuffActionValidation();
        }

        private void textBoxComputername_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxComputername.Text == "Název počítače")
            {
                textBoxComputername.Text = "";
                textBoxComputername.ForeColor = Color.White;
            }
        }

        private void textBoxComputername_Enter(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "Název počítače")
            {
                textBoxComputername.SelectionStart = 0;
                textBoxComputername.SelectionLength = 0;
            }
        }

        private void textBoxComputername_Leave(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "")
            {
                textBoxComputername.Text = "Název počítače";
            }
        }

        private void buttonRepair_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = @"/c WMIC /node:" + textBoxComputername.Text + @" /namespace:\\root\ccm path sms_client CALL RepairClient & pause";
            /*
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            */
            p.Start();
            p.WaitForExit();
            
        }
        private void buttonSetCache_Click(object sender, EventArgs e)
        {

            Process p = new Process();          
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c @echo off & wmic /node:" + textBoxComputername.Text + @" /namespace:\\ROOT\CCM\SoftMgmtAgent path CacheConfig set size = " + numericUpDown1.Value;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
            ServiceManipulation.runOrStopService("ccmexec", textBoxComputername.Text, ServiceManipulation.serviceAction.stop);
            ServiceManipulation.runOrStopService("ccmexec", textBoxComputername.Text, ServiceManipulation.serviceAction.run);
        }

        private void buttonGetCacheSize_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c wmic /node:" + textBoxComputername.Text + @" /namespace:\\ROOT\CCM\SoftMgmtAgent path CacheConfig get size";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();
            string output = new String(p.StandardOutput.ReadToEnd().Where(Char.IsDigit).ToArray());
            label6.Text = output + " MB";
        }
    }
}
