using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
                buttonPing.Enabled = true;
            } else
            {
                buttonClearCache.Enabled = false;
                buttonPolicy.Enabled = false;
                buttonRepair.Enabled = false;
                buttonSetCache.Enabled = false;
                numericUpDown1.Enabled = false;
                buttonGetCacheSize.Enabled = false;
                buttonPing.Enabled = false;
            }
        }

        private void textBoxComputername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.Text.Contains("Název počítače"))
            {
                textBoxComputername.Text = textBoxComputername.Text.Replace("Název počítače", "");
                textBoxComputername.ForeColor = Color.White;
                textBoxComputername.SelectionStart = 0;
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

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        private void buttonGetCacheSize_Click(object sender, EventArgs e)
        {
            //Max velikost
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
            
            //Vyuzite misto
            string processOutput = String.Empty;
            Process p1 = new Process();
            p1.StartInfo.FileName = "cmd.exe";
            p1.StartInfo.Arguments = "/c wmic /node:" + textBoxComputername.Text + @" /namespace:\\ROOT\CCM\SoftMgmtAgent path CacheConfig get Location";
            p1.StartInfo.CreateNoWindow = true;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.UseShellExecute = false;
            p1.Start();
            p1.WaitForExit();

            processOutput = p1.StandardOutput.ReadToEnd().ToString();
            //Rozdeli vystup procesu p1 do pole "lines" po kazdem radku
            string[] lines = processOutput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //Prasacky napsane, ale funguje
            //Mozny vystup: \\pocitac1\C$\Windows\ccmcahce
            //                                                      smaze prvni pismeno(C:\cesta...)    smaze ":", ktera byla v ceste (C:\cesta...)
            string path = "\\\\" + textBoxComputername.Text + @"\" + lines[1].Trim()[0] + "$" + lines[1].TrimStart(lines[1].Trim()[0]).TrimStart(':');
            DirectoryInfo di = new DirectoryInfo(path);
            label5.Text = ((DirSize(di) / 1024)/1024).ToString() + " MB";

        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            buttonPing.BackColor = Color.Orange;
            buttonPing.Text = "PING Probíhá";
            new Thread(() =>
            {
                using (Ping ping = new Ping())
                {
                    try
                    {
                        PingReply pingReply = ping.Send(textBoxComputername.Text, 2000);
                        if (pingReply.Status == IPStatus.Success)
                        {
                            Invoke(new Action(() =>
                            {
                                buttonPing.BackColor = Color.ForestGreen;
                                buttonPing.Text = "PING";
                            }));
                        }
                    }
                    catch
                    {
                        Invoke(new Action(() =>
                        {
                            buttonPing.BackColor = Color.Firebrick;
                            buttonPing.Text = "PING";
                        }));
                        return;
                    }
                }
            }).Start();
        }

        private void buttonClearCache_Click(object sender, EventArgs e)
        {
            //Smaze z WMI polozky z cahce
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c wmic /node:" + textBoxComputername.Text + @" /namespace:\\ROOT\CCM\SoftMgmtAgent path CacheInfoEx delete";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
            //Ziska, kam se uklada cache
            string processOutput = String.Empty;
            Process p1 = new Process();
            p1.StartInfo.FileName = "cmd.exe";
            p1.StartInfo.Arguments = "/c wmic /node:" + textBoxComputername.Text + @" /namespace:\\ROOT\CCM\SoftMgmtAgent path CacheConfig get Location";
            p1.StartInfo.CreateNoWindow = true;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.UseShellExecute = false;
            p1.Start();
            p1.WaitForExit();

            processOutput = p1.StandardOutput.ReadToEnd().ToString();
            //Rozdeli vystup procesu p1 do pole "lines" po kazdem radku
            string[] lines = processOutput.Split(new[] { '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            //Prasacky napsane, ale funguje
            //Mozny vystup: \\pocitac1\C$\Windows\ccmcahce
            //                                                      smaze prvni pismeno(C:\cesta...)    smaze ":", ktera byla v ceste (C:\cesta...)
            string path = "\\\\" + textBoxComputername.Text + @"\" + lines[1].Trim()[0] + "$"  + lines[1].TrimStart(lines[1].Trim()[0]).TrimStart(':');
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                if (dir.Exists)
                    dir.Delete(true);
            }
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(174, 0, 0), 1), textBoxComputername.Location.X, textBoxComputername.Location.Y + textBoxComputername.Height + 2, textBoxComputername.Location.X + textBoxComputername.Width, textBoxComputername.Location.Y + textBoxComputername.Height + 2);
        }

        private void buttonPolicy_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c wmic /node:" + textBoxComputername.Text + " /namespace:\\\\ROOT\\CCM path sms_client CALL TriggerSchedule \"{00000000-0000-0000-0000-000000000021}\" /NOINTERACTIVE & timeout /t 3 >nul";
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.WaitForExit();
        }

        private void buttonRepair_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_maintenance_96, 50, 50), 10,3);
        }
    }
}
