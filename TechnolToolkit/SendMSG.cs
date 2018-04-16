using System;
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
    public partial class SendMSG : Form
    {
        public SendMSG()
        {
            InitializeComponent();
        }

        private void check_IF_MSG_sendable()
        {
            if (check_Input_Content() == true)
            {
                buttonSend.Enabled = true;
            }
            else buttonSend.Enabled = false;
        }

        //Check if all the inputs are not empty
        private bool check_Input_Content()
        {
            if (textBoxComputername.Text != "" && textBoxMSG.Text != "")
                return true;
            else return false;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            int cas = (int)numericUpDown1.Value;
            string zprava = textBoxMSG.Text;
            string pocitac = textBoxComputername.Text;
            string pwscmd = "\"Invoke-wmiMethod -Path Win32_Process -Name Create -ArgumentList 'msg * /time:" + cas + " \"" + zprava + "\"' -ComputerName " + pocitac + "\"";
            Process p = new Process();
            p.StartInfo.FileName = "powershell.exe";
            p.StartInfo.Arguments = "-Command " + pwscmd;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.WaitForExit();
        }

        private void textBoxComputername_TextChanged(object sender, EventArgs e)
        {
            check_IF_MSG_sendable();
        }

        private void textBoxMSG_TextChanged(object sender, EventArgs e)
        {
            check_IF_MSG_sendable();
        }
    }
}
