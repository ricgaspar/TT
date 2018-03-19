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
        private int pingTimeout = 5000;
        private int pingWaitAfterCompletetion = 10000;
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
#warning neodebira zarizeni, na ktere probehl ping s uspechem
            if (devices.Count <= 0)
            {
                devices.AddRange(textBoxDevices.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>());

                for (int i = 0; i < devices.Count; i++)
                {
                    if (devices[i].StartsWith("[OK - "))
                        devices.RemoveAt(i);
                }
            }
            do
            {
                multipingStart();
            } while (devices.Count > 0);
#warning vypise na konci 2x, kdyz dojdou zarizeni...
            textBoxStatus.Text += "[" + DateTime.Now.ToString("dd.MM.yy HH:mm:ss") + "] Nový pokus o PING na všechny zařízení za " + (pingWaitAfterCompletetion / 1000) + " sekund" + Environment.NewLine;
        }
        
        private void multipingStart()
        {
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
        }

        private void buttonStartMultiPing_Click(object sender, EventArgs e)
        {
            buttonStartMultiPing.BackColor = Color.DarkOrange;
            buttonStartMultiPing.Text = "Probíhá... Klikni znovu pro zastavení";

            timer1.Start();

            buttonStopMultiping.Enabled = true;
            buttonStartMultiPing.Enabled = false;
        }

        private void buttonStopMultiping_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            buttonStartMultiPing.Enabled = true;
            buttonStopMultiping.Enabled = false;
        }
    }
}
