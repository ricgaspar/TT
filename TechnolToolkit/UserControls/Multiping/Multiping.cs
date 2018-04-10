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
        private int pingWaitAfterCompletetion = 3000;
        public Multiping()
        {
            InitializeComponent();
            timer1.Interval = pingWaitAfterCompletetion;
            timer1.Tick += new System.EventHandler(timer1_Tick);
        }



        private void textBoxDevices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
                textBoxDevices.SelectAll();
            if (e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(textBoxDevices.SelectedText);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //check if we are not on higher index than our device count is
            if (indexDevice >= devices.Count)
            {
                indexDevice = 0;
                //Separate every group ping with new line, but do not write new line at the start of the program
                if(textBoxStatus.Text != "")
                    textBoxStatus.Text += Environment.NewLine;
            }
            //NOT A GOOD WAY TO CHECK FOR WHITESPACE OR INVALID DEVICE NAMES!!!
            if(devices[indexDevice] != null && devices[indexDevice] != "")
            { 
                IPStatus ips = multipingSend(devices[indexDevice]);
                if (ips == IPStatus.Success)
                {
                    //check if we should display text notification
                    if (checkBoxNotification.Checked)
                    {
                        //display notification here
#error nefunguje
                        notifyIcon1.ShowBalloonTip(1000,"MultiPing",devices[indexDevice] + "je vidět na síti",ToolTipIcon.Info);
                    }
                    //check if we should play sound notification
                    if (checkBoxSound.Checked)
                        System.Media.SystemSounds.Beep.Play();

                    //check if we should not longer ping on device
                    if (radioButtonradioButtonMarkAfterSuccesPing.Checked)
                    {
                        //remove device from list of devices that we ping on
                    }

                }
                //ping was not successful
                else
                {
                    textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] " + devices[indexDevice] + ": " + ips.ToString() + Environment.NewLine;
                }
            }
            indexDevice++; //move on to another device
            #region oldCode
            /*
            #warning neodebira zarizeni, na ktere probehl ping s uspechem
            if (devices.Count <= 0)
            {
                //Pokud promena devices neobsahuje zadna zarizeni, napln je z textboxu
                devices.AddRange(textBoxDevices.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>());

                for (int i = 0; i < devices.Count; i++)
                {
                    if (devices[i].StartsWith("[OK - "))
                        devices.RemoveAt(i);
                }
            }
            do
            {
                multipingStart(devices[i]);
            } while (devices.Count > 0);
            #warning vypise na konci 2x, kdyz dojdou zarizeni...
            textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] Nový pokus o PING na všechny zařízení za " + (pingWaitAfterCompletetion / 1000) + " sekund" + Environment.NewLine;
            */
            #endregion
        }

        private IPStatus multipingSend(string device)
        {
            Ping ping = new Ping();
            PingReply pingReply;
            //Ping probehne, pokud jsme obdrzeli korektni vstup
            if (device != null && device != "")
            {
                //Posli ping a nastav timeout - 5s
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
            else return IPStatus.DestinationUnreachable;
        }

        private void buttonStartMultiPing_Click(object sender, EventArgs e)
        {
            
            if (textBoxStatus.Text != "")
                textBoxStatus.Text += Environment.NewLine;
            #warning Chybi kontrola whitespace a jejich mazani!
            devices.AddRange(textBoxDevices.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>());

            buttonStartMultiPing.BackColor = Color.FromArgb(68, 68, 68);
            buttonStopMultiping.BackColor = Color.DarkOrange;
            buttonStopMultiping.Enabled = true;
            buttonStartMultiPing.Enabled = false;

            timer1.Start();
            
        }

        private void buttonStopMultiping_Click(object sender, EventArgs e)
        {
            
            buttonStartMultiPing.Enabled = true;
            buttonStartMultiPing.BackColor = Color.ForestGreen;
            buttonStopMultiping.BackColor = Color.FromArgb(68, 68, 68);
            buttonStopMultiping.Enabled = false;
            timer1.Stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pingWaitAfterCompletetion = (int)numericUpDown1.Value * 1000;
        }
    }
}
