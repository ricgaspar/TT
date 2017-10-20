using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace TechnolToolkit
{
    public partial class UserControl_InfoPCSystem : UserControl
    {
        public UserControl_InfoPCSystem()
        {
            InitializeComponent();
            wmiSystem(true);
        }
        public void wmiSystem(bool localhost)
        {
            richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.Text = "";
            if (localhost == true)
            {
                ManagementScope scope = new ManagementScope(@"\\localhost\root\cimv2");
                scope.Connect();

                ManagementObjectSearcher searcher7 = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj7 in searcher7.Get())
                {
                    richTextBox1.Rtf = @"{\rtf1\n \b Název: \b0" + queryObj7["Caption"] +
                        @"\n\bÚroveň šifrování: \b0" + queryObj7["EncryptionLevel"] +
                        @"\n\bDatum instalace: \b0" + queryObj7["InstallDate"] +
                        @"\n\bPoslední čas nabootování: \b0" + queryObj7["LastBootUpTime"] +
                        @"\n\bArchitektura OS: \b0" + queryObj7["OSArchitecture"] +
                        @"\n\bSystémová složka: \b0" + queryObj7["SystemDirectory"] +
                        @"\n\bSložka Windows: \b0" + queryObj7["WindowsDirectory"] +
                        @"\n\bSystémový disk: \b0" + queryObj7["SystemDrive"] +
                        @"\n\bVerze OS: \b0" + queryObj7["Version"] + "}";
                }
            } else
            {
                InfoPC ipc = new InfoPC();
                ManagementScope scope = new ManagementScope(@"\\" + ipc.textBoxPCName.Text + @"\root\cimv2");
                scope.Connect();

                ManagementObjectSearcher searcher7 = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj7 in searcher7.Get())
                {
                    //Console.WriteLine("-----------------------------------");
                    //Console.WriteLine("Win32_OperatingSystem instance");
                    //Console.WriteLine("-----------------------------------");
                    richTextBox1.Rtf = @"{\rtf1ansi \bNázev: " + queryObj7["Caption"] +
                        @"\n\bÚroveň šifrování: " + queryObj7["EncryptionLevel"] +
                        @"\n\bDatum instalace: " + queryObj7["InstallDate"] +
                        @"\n\bPoslední čas nabootování: " + queryObj7["LastBootUpTime"] +
                        @"\n\bArchitektura OS: " + queryObj7["OSArchitecture"] +
                        @"\n\bSystémová složka: " + queryObj7["SystemDirectory"] + 
                        @"\n\bSložka Windows: " + queryObj7["WindowsDirectory"] +
                        @"\n\bSystémový disk: " + queryObj7["SystemDrive"] +
                        @"\n\bVerze OS: " + queryObj7["Version"] + "}";
                    //Console.WriteLine("Caption: {0}", queryObj7["Caption"]);
                    //Console.WriteLine("EncryptionLevel: {0}", queryObj7["EncryptionLevel"]);
                    //Console.WriteLine("InstallDate: {0}", queryObj7["InstallDate"]);
                    //Console.WriteLine("LastBootUpTime: {0}", queryObj7["LastBootUpTime"]);
                    //Console.WriteLine("OSArchitecture: {0}", queryObj7["OSArchitecture"]);
                    //Console.WriteLine("SystemDirectory: {0}", queryObj7["SystemDirectory"]);
                    //Console.WriteLine("WindowsDirectory: {0}", queryObj7["WindowsDirectory"]);
                    //Console.WriteLine("SystemDrive: {0}", queryObj7["SystemDrive"]);
                    //Console.WriteLine("OS Version: {0}", queryObj7["Version"]);
                }
            }

        }
    }
}
