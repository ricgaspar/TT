using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
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
            stuffActionValidation();
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
            MessageBox.Show("Pro aplikování nové velikosti cache paměti je nutné pc restarovat, nebo restartovat službu \"ccmexec\"!","Aplikace nového nastavení",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            /*
            For some reason this function sometimes fucks up remote sccm clinet.
            runOrStopService("ccmexec", textBoxComputername.Text, serviceAction.stop);
            runOrStopService("ccmexec", textBoxComputername.Text, serviceAction.run);
            */
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

        public static void EnableTheService(string serviceName, string computername, serviceAction serAction)
        {
            switch (serAction)
            {
                case serviceAction.run:
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = @"/c sc \\" + computername + " config " + serviceName + " start= demand";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    p.WaitForExit(10000);
                    break;
                case serviceAction.stop:
                    Process p1 = new Process();
                    p1.StartInfo.FileName = "cmd.exe";
                    p1.StartInfo.Arguments = @"/c sc \\" + computername + " config " + serviceName + " start= disabled";
                    p1.StartInfo.CreateNoWindow = true;
                    p1.StartInfo.UseShellExecute = false;
                    p1.Start();
                    p1.WaitForExit(10000);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Invalid parameter in serviceAction enum");
            }
        }

        public enum serviceAction
        {
            run,
            stop,
        }
        public static void runOrStopService(string serviceName, string computer, serviceAction action)
        {
            Console.WriteLine("==========Service Manipulation==========");
            switch (action)
            {
                case serviceAction.run:
                    EnableTheService(serviceName, computer, action);
                    using (ServiceController sc = new ServiceController(serviceName, computer))
                        if (sc.Status != ServiceControllerStatus.Running)
                        {
                            Console.WriteLine("Start sluzby {0}", sc.DisplayName);
                            sc.Start();
                            Console.WriteLine("Cekani na status: Running");
                            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(60));
                            if (sc.Status != ServiceControllerStatus.Running)
                                MessageBox.Show("Sluzbu " + sc.DisplayName + " se nepodarilo spustit", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else Console.WriteLine("Status sluzby {0}: {1}", sc.DisplayName, sc.Status);
                        }
                        else Console.WriteLine("Status sluzby {0}: {1}", sc.DisplayName, sc.Status);
                    break;

                case serviceAction.stop:
                    EnableTheService(serviceName, computer, action);
                    using (ServiceController sc = new ServiceController(serviceName, computer))
                        if (sc.Status != ServiceControllerStatus.Stopped)
                        {
                            Console.WriteLine("Zastavovani sluzby {0}", sc.DisplayName);
                            sc.Stop();
                            Console.WriteLine("Cekani na status: Stopped");
                            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(60));
                            if (sc.Status != ServiceControllerStatus.Stopped)
                                MessageBox.Show("Sluzbu " + sc.DisplayName + " se nepodarilo zastavit", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else Console.WriteLine("Status sluzby {0}: {1}", sc.DisplayName, sc.Status);
                        }
                    break;
                default:
                    throw new InvalidEnumArgumentException("Invalid parameter in serviceAction enum");
            }
            Console.WriteLine("========================================");
        }
    }

}
