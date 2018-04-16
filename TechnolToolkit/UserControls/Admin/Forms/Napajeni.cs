using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Threading;

namespace TechnolToolkit
{
    public partial class Napajeni : Form
    {
        public Color themeColor = Color.FromArgb(174, 0, 0);
        public Napajeni()
        {
            InitializeComponent();
            radioButtonNoAction.Focus();
        }

        private void buttonActionValidation()
        {
            if (radioButtonNoAction.Checked)
                buttonAction.Enabled = false;
            else
            {
                if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název počítače")
                {
                    buttonAction.Enabled = true;
                }
            }
        }

        private void textBoxComputername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.TextLength > 0)
                buttonActionValidation();
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            if (radioButtonNoAction.Checked)
                return;

            if (radioButtonPowerOffAction.Checked)
            {
                if (radioButtonActionTimeNow.Checked)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "/c shutdown /m \\\\" + textBoxComputername.Text + " /s /t 0 /f";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    MessageBox.Show("Vypnutí systému spuštěno",textBoxComputername.Text);

                }
                if (radioButtonActionTimeLater.Checked)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    if (textBoxComment.Text == "")
                        p.StartInfo.Arguments = "/c shutdown /m \\\\" + textBoxComputername.Text + " /s /t " + (numericUpDown1.Value * 60) + " /f";
                    else p.StartInfo.Arguments = "/c shutdown /m \\\\" + textBoxComputername.Text + " /s /t " + (numericUpDown1.Value * 60) + " /c \"" + textBoxComment.Text + "\" /f";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    MessageBox.Show("Vypnutí systému bude spuštěno za " + numericUpDown1.Value + " minut", textBoxComputername.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (radioButtonRestartAction.Checked)
            {
                if (radioButtonActionTimeNow.Checked)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";        
                    p.StartInfo.Arguments = "/c shutdown /m \\\\" + textBoxComputername.Text + " /r /t 0 /f";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    MessageBox.Show("Restart byl spuštěn", textBoxComputername.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (radioButtonActionTimeLater.Checked)
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    if (textBoxComment.Text == "")
                        p.StartInfo.Arguments = "/c shutdown /m \\\\" + textBoxComputername.Text + " /r /t " + (numericUpDown1.Value * 60) + " /f";
                    else p.StartInfo.Arguments = "/c shutdown /m \\\\" + textBoxComputername.Text + " /r /t " + (numericUpDown1.Value * 60) + " /c \"" + textBoxComment.Text + "\" /f";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    MessageBox.Show("Restart bude spuštěn za" + numericUpDown1.Value + " minut", textBoxComputername.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (radioButtonStopAction.Checked)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Arguments = "/c shutdown /m \\\\" + textBoxComputername.Text + " /a & timeout /t 3 > nul";
                p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                MessageBox.Show("Vypínání/restart přerušen(o)", textBoxComputername.Text, MessageBoxButtons.OK,MessageBoxIcon.Information);
                //MessageBox.Show(p.StandardOutput.ReadToEnd(),"Výstup");
            }
        }

        private void buttonMultiplePCs_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = "/c shutdown /i";
            p.Start();
        }

        private void radioButtonActionTimeLater_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonActionTimeLater.Checked)
            {
                numericUpDown1.Enabled = true;
                labelUpozorneni.Visible = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
                labelUpozorneni.Visible = false;
            }
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {          
            if (textBoxComment.TextLength > 0)
                buttonActionValidation();
        }

        private void radioButtonSleepAction_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStopAction.Checked)
            {
                textBoxComment.Enabled = false;
                radioButtonActionTimeLater.Enabled = false;
                buttonActionValidation();
            }
            else
            {
                textBoxComment.Enabled = true;
                radioButtonActionTimeLater.Enabled = true;
            }
        }

        private void radioButtonRestartAction_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRestartAction.Checked)
                buttonActionValidation();
           
        }

        private void radioButtonPowerOffAction_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPowerOffAction.Checked)
                buttonActionValidation();
            
        }

        private void radioButtonNoAction_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNoAction.Checked)
                buttonActionValidation();
        }
    }
}
