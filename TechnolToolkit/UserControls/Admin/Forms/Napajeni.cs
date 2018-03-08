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
            if(textBoxComputername.Text.Contains("Název počítače"))
            {
                textBoxComputername.Text = textBoxComputername.Text.Replace("Název počítače", "");
                textBoxComputername.ForeColor = Color.White;
                textBoxComputername.SelectionStart = 1;
                textBoxComputername.SelectionLength = 0;
            }
            if (textBoxComputername.TextLength > 0)
                buttonActionValidation();
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
                textBoxComputername.Text = "Název počítače";
        }

        private void textBoxComputername_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxComputername.Text == "Název počítače")
            {
                textBoxComputername.Text = "";
                textBoxComputername.ForeColor = Color.White;
            }
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            if (radioButtonNoAction.Checked)
                return;

            if (radioButtonPowerOffAction.Checked)
            {
                if (radioButtonActionTimeNow.Checked)
                {
                    var psi = new ProcessStartInfo("shutdown");
                    psi.CreateNoWindow = true;
                    psi.Arguments = "/m \\\\" + textBoxComputername.Text + " /s /t 0 /f";
                    psi.UseShellExecute = false;
                    Process.Start(psi);
                }
                if (radioButtonActionTimeLater.Checked)
                {
                    var psi = new ProcessStartInfo("shutdown");
                    psi.CreateNoWindow = true;
                    if(textBoxComment.Text == "Komentář k prováděné akci (nepovinné)")
                        psi.Arguments = "/m \\\\" + textBoxComputername.Text + " /s /t " + (numericUpDown1.Value * 60) + " /f";
                    else psi.Arguments = "/m \\\\" + textBoxComputername.Text + " /s /t " + (numericUpDown1.Value * 60) + " /c \"" + textBoxComment.Text + "\" /f";
                    psi.UseShellExecute = false;
                    Process.Start(psi);
                }
            }
            if (radioButtonRestartAction.Checked)
            {
                if (radioButtonActionTimeNow.Checked)
                {
                    var psi = new ProcessStartInfo("shutdown");
                    psi.CreateNoWindow = true;
                    psi.Arguments = "/m \\\\" + textBoxComputername.Text + " /r /t 0 /f";
                    psi.UseShellExecute = false;
                    Process.Start(psi);
                }
                if (radioButtonActionTimeLater.Checked)
                {
                    var psi = new ProcessStartInfo("shutdown");
                    psi.CreateNoWindow = true;
                    if(textBoxComment.Text == "Komentář k prováděné akci (nepovinné)")
                        psi.Arguments = "/m \\\\" + textBoxComputername.Text + " /r /t " + (numericUpDown1.Value * 60) + " /f";
                    else psi.Arguments = "/m \\\\" + textBoxComputername.Text + " /r /t " + (numericUpDown1.Value * 60) + " /c \"" + textBoxComment.Text + "\" /f";
                    psi.UseShellExecute = false;
                    Process.Start(psi);
                }
            }
            if (radioButtonStopAction.Checked)
            {
                if (radioButtonActionTimeNow.Checked)
                {
                    var psi = new ProcessStartInfo("shutdown");
                    psi.CreateNoWindow = true;
                    psi.Arguments = "/m \\\\" + textBoxComputername.Text + " /a";
                    psi.UseShellExecute = false;
                    Process.Start(psi);
                }
            }
        }

        private void buttonMultiplePCs_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo("shutdown", "/i");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
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
            if (textBoxComment.Text.Contains("Komentář k prováděné akci (nepovinné)"))
            {
                textBoxComment.Text = textBoxComment.Text.Replace("Komentář k prováděné akci (nepovinné)", "");
                textBoxComment.ForeColor = Color.White;
                textBoxComment.SelectionStart = 1;
                textBoxComment.SelectionLength = 0;
            }
            if (textBoxComment.TextLength > 0)
                buttonActionValidation();
        }

        private void textBoxComment_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBoxComment.Text == "Komentář k prováděné akci (nepovinné)")
            {
                textBoxComment.Text = "";
                textBoxComment.ForeColor = Color.White;
            }
        }

        private void textBoxComment_Enter(object sender, EventArgs e)
        {
            if (textBoxComment.Text == "Komentář k prováděné akci (nepovinné)")
            {
                textBoxComment.SelectionStart = 0;
                textBoxComment.SelectionLength = 0;
            }
        }
        private void textBoxComment_Leave(object sender, EventArgs e)
        {
            if (textBoxComment.Text == "")
            {
                textBoxComment.Text = "Komentář k prováděné akci (nepovinné)";
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            SByte offset = 2;
            e.Graphics.DrawLine(new Pen(themeColor, 1), textBoxComment.Location.X, textBoxComment.Location.Y + textBoxComment.Height + offset, textBoxComment.Location.X + textBoxComment.Width, textBoxComment.Location.Y + textBoxComment.Height + offset);            
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            SByte offset = 2;
            e.Graphics.DrawLine(new Pen(themeColor, 1), textBoxComputername.Location.X, textBoxComputername.Location.Y + textBoxComputername.Height + offset, textBoxComputername.Location.X + textBoxComputername.Width, textBoxComputername.Location.Y + textBoxComputername.Height + offset);
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
