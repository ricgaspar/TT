using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit.UserControls.Multiping
{
    public partial class Multiping : Form
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        List<string> devices = new List<string>();
        int indexDevice = 0;

        private int pingTimeout = 5000;
        private int pingWaitAfterCompletetion = 6000;
        public Multiping()
        {
            InitializeComponent();
            timer1.Interval = pingWaitAfterCompletetion;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            numericUpDown1.Value = pingWaitAfterCompletetion / 1000;
        }

        private void textBoxDevices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                textBoxDevices.SelectAll();
            if (e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(textBoxDevices.SelectedText);
        }

        private void fillDevicesList()
        {
            devices.Clear();
            devices.AddRange(textBoxDevices.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Where(s => !s.StartsWith("[OK - ")).ToList<string>());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //protection - fill list with new devices if 
            if (devices.Count > 0)
            {
                /*
                if (indexDevice > devices.Count)
                {
                    //fillDevicesList();
                    //Separate every group ping with new line, but do not write new line at the start of the program
                    if(textBoxStatus.Text != "")
                        textBoxStatus.Text += Environment.NewLine;
                }*/
                //NOT A GOOD WAY TO CHECK FOR WHITESPACE OR INVALID DEVICE NAMES!!!
                //if (devices[indexDevice] != null && devices[indexDevice] != "" && !devices[indexDevice].StartsWith("[OK - "))
                if (devices[0] != null && devices[0] != "" && !devices[0].StartsWith("[OK - "))
                {
                    IPStatus ips = multipingSend(devices[0]);
                    //IPStatus ips = multipingSend(devices[indexDevice]);
                    if (ips == IPStatus.Success)
                    {
                        //check if we should display text notification
                        if (checkBoxNotification.Checked)
                        {
                            //display notification here
                            //#error nefunguje
                            notifyIcon1.Icon = SystemIcons.Information;
                            //notifyIcon1.ShowBalloonTip(1000,"MultiPing",devices[indexDevice].ToUpper() + " je na síti", ToolTipIcon.Info);
                            notifyIcon1.ShowBalloonTip(1000, "MultiPing", devices[0].ToUpper() + " je na síti", ToolTipIcon.Info);
                        }
                        //check if we should play sound notification
                        if (checkBoxSound.Checked)
                            System.Media.SystemSounds.Beep.Play();

                        //check if we should not longer ping on device
                        if (radioButtonradioButtonMarkAfterSuccesPing.Checked)
                        {
                            //remove device from list of devices that we ping on and edit textboxdevices accordingly
                            List<string> lines = textBoxDevices.Lines.ToList<string>();
                            for (int i = 0; i < lines.Count; i++)
                            {
                                if (lines[i] == devices[0])
                                { 
                                    lines[i] = "[OK - " + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + lines[i];
                                    textBoxDevices.Lines = lines.ToArray();
                                }
                            }
                            //lines[0] = "[OK - " + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + lines[0];
                            //lines[indexDevice] = "[OK - " + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + lines[indexDevice];
                            //textBoxDevices.Lines = lines.ToArray();
                        }

                    }
                    //ping was not successful
                    else
                    {
                        textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + devices[indexDevice] + ": " + ips.ToString() + Environment.NewLine;
                    }
                }
                devices.RemoveAt(0);
            }
            else
            {
                fillDevicesList();
                if (devices.Count == 0)
                {
                    stopMultiping();
                    textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] Všechna zařízení online. Zastavuji MultiPing!";
                }
            }

        }

        private IPStatus multipingSend(string device)
        {
            Ping ping = new Ping();
            PingReply pingReply;
            //Ping probehne, pokud jsme obdrzeli korektni vstup
            if (device != null && device != "")
            {
                //Posli ping a nastav timeout - 5s
                try
                {
                    pingReply = ping.Send(device, pingTimeout);
                    textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + device + ": " + pingReply.Status.ToString() + Environment.NewLine;
                    #region OldCode
                    /*
                    Ping ping = new Ping();
                    PingReply pingReply;
                    if (devices.Count > 0)
                    {
                        try
                        {
                            pingReply = ping.Send(devices[0], pingTimeout);
                            textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + devices[0] + ": " + pingReply.Status.ToString() + Environment.NewLine;
                            if (pingReply.Status == IPStatus.Success)
                            {
                                System.Media.SystemSounds.Beep.Play();
                    #warning nefunguje - nemeni text textboxu
                                textBoxDevices.Text.Replace(devices[0], "[OK - " + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + devices[0]);
                            }
                        }
                        catch (Exception ex)
                        {
                            textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + devices[0] + ": " + ex.Message.ToString() + Environment.NewLine;
                        }
                        devices.RemoveAt(0);
                    }
                    else
                    {
                        timer1.Stop();
                        buttonStartMultiPing.Enabled = true;
                        buttonStopMultiping.Enabled = false;
                        buttonStartMultiPing.BackColor = Color.FromArgb(68, 68, 68);
                        buttonStartMultiPing.Text = "Spustit";
                        MessageBox.Show("Konec!");
                    }
                            */
                    #endregion
                    return pingReply.Status;
                }
                catch
                {
                    return IPStatus.DestinationHostUnreachable;
                }
            }
            else
                return IPStatus.Unknown;
        }

        private void buttonStartMultiPing_Click(object sender, EventArgs e)
        {
            if (textBoxStatus.Text != "")
                textBoxStatus.Text += Environment.NewLine;

#warning Chybi kontrola whitespace a jejich mazani!
            fillDevicesList();

            buttonStartMultiPing.BackColor = Color.FromArgb(68, 68, 68);
            buttonStopMultiping.BackColor = Color.DarkOrange;
            buttonStopMultiping.Enabled = true;
            buttonStartMultiPing.Enabled = false;

            timer1.Start();
        }

        private void stopMultiping()
        {
            buttonStartMultiPing.Enabled = true;
            buttonStartMultiPing.BackColor = Color.ForestGreen;
            buttonStopMultiping.BackColor = Color.FromArgb(68, 68, 68);
            buttonStopMultiping.Enabled = false;
            timer1.Stop();
        }

        private void buttonStopMultiping_Click(object sender, EventArgs e)
        {
            stopMultiping();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pingWaitAfterCompletetion = (int)numericUpDown1.Value * 1000;
        }
    }
}
