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

namespace TechnolToolkit
{
    public partial class Napajeni : Form
    {
        public Color themeColor = Color.FromArgb(174, 0, 0);
        public Napajeni()
        {
            InitializeComponent();
        }

        private void buttonActionValidation()
        {
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawLine(new Pen(themeColor, 1), textBoxComputername.Location.X, textBoxComputername.Location.Y + textBoxComputername.Height, textBoxComputername.Location.X + textBoxComputername.Width, textBoxComputername.Location.Y + textBoxComputername.Height);
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
                textBoxComputername.SelectionStart = 0;
                textBoxComputername.SelectionLength = 0;
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
                if(radioButtonVisibilityHidden.Checked)
                {
                    
                }
                if(radioButtonVisibilityVisible.Checked)
                {
                    if (radioButtonActionTimeNow.Checked)
                    {
                        var psi = new ProcessStartInfo("shutdown");
                        psi.CreateNoWindow = true;
                        psi.Arguments = "/m \\" + textBoxComputername.Text + " /s /t 0 /f";
                        psi.UseShellExecute = false;
                        Process.Start(psi);
                    }
                    if (radioButtonActionTimeLater.Checked)
                    {
                        var psi = new ProcessStartInfo("shutdown");
                        psi.CreateNoWindow = true;
                        psi.Arguments = "/m \\" + textBoxComputername.Text + " /s /t " + (numericUpDown1.Value * 60) +" /f";
                        psi.UseShellExecute = false;
                        Process.Start(psi);
                    }
                }
            }
            if (radioButtonRestartAction.Checked)
            {
                //Restart code
            }
            if (radioButtonSleepAction.Checked)
            {
                //sleep code
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
                numericUpDown1.Enabled = true;
            else
                numericUpDown1.Enabled = false;
            if (radioButtonVisibilityHidden.Checked)
                MessageBox.Show("Vypnutí(například) PC za dobu větší než 0 sekund bez jakéhokoliv upozornění na vypínaném PC není standartně možné.\n\nTím pádem tento program vytvoří proces na okamžité vypnutí vzáleného PC a zároveň jej uspí na Vámi zvolenou dobu. Tím se vyřeší tento problém. Bohužel pokud vyprší doba uspání a vzdálený PC již nebude na síti, není možné jej vypnout.\n\nJsou způsoby jak tento problém vyřešit elegantněji, ale vzhledem k místu užívaní programu je toto nejsnažší cesta.");
        }
    }
}
