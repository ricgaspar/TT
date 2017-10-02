using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class InfoPC : Form
    {
        public InfoPC()
        {
            InitializeComponent();
            /*
            ManagementScope scope = 
            new ManagementScope(
            "\\\\FullComputerName\\root\\cimv2");
        scope.Connect();

        // Use this code if you are connecting with a 
        // different user name and password:
        //
        // ManagementScope scope = 
        //    new ManagementScope(
        //        "\\\\FullComputerName\\root\\cimv2", options);
        // scope.Connect();

        //Query system for Operating System information
        ObjectQuery query = new ObjectQuery(
            "SELECT * FROM Win32_OperatingSystem");
        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(scope,query);

        ManagementObjectCollection queryCollection = searcher.Get();
        foreach ( ManagementObject m in queryCollection)
        {
            // Display the remote computer information
            Console.WriteLine("Computer Name : {0}", 
                m["csname"]);
            Console.WriteLine("Windows Directory : {0}", 
                m["WindowsDirectory"]);
            Console.WriteLine("Operating System: {0}",  
                m["Caption"]);
            Console.WriteLine("Version: {0}", m["Version"]);
            Console.WriteLine("Manufacturer : {0}", 
                m["Manufacturer"]);
        }

            */
        }
        private void wmiSearch(bool localhostOrNot)
        {
            // Use this code if you are connecting with a 
            // different user name and password:
            //
            // ManagementScope scope = 
            //    new ManagementScope(
            //        "\\\\FullComputerName\\root\\cimv2", options);
            // scope.Connect();
            if (localhostOrNot == true)
            {
                ManagementScope scope = new ManagementScope(@"\\localhost\root\cimv2");
                scope.Connect();

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    Console.WriteLine("Computer Name : {0}",
                        m["csname"]);
                    Console.WriteLine("Windows Directory : {0}",
                        m["WindowsDirectory"]);
                    Console.WriteLine("Operating System: {0}",
                        m["Caption"]);
                    Console.WriteLine("Version: {0}", m["Version"]);
                    Console.WriteLine("Manufacturer : {0}",
                        m["Manufacturer"]);
                }
            }
            else
            {
                ManagementScope scope = new ManagementScope(@"\\" + textBoxPCName.Text + @"\root\cimv2");
                scope.Connect();

                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    Console.WriteLine("Computer Name : {0}",
                        m["csname"]);
                    Console.WriteLine("Windows Directory : {0}",
                        m["WindowsDirectory"]);
                    Console.WriteLine("Operating System: {0}",
                        m["Caption"]);
                    Console.WriteLine("Version: {0}", m["Version"]);
                    Console.WriteLine("Manufacturer : {0}",
                        m["Manufacturer"]);
                }
            }
        }
        private void buttonVyhledat_Click(object sender, EventArgs e)
        {
            if (checkBoxLocalPC.Checked)
                wmiSearch(true);
            else wmiSearch(false);
        }

        private void checkBoxLocalPC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLocalPC.Checked)
                textBoxPCName.Enabled = false;
            else textBoxPCName.Enabled = true;
        }

        private void textBoxPCName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPCName.Text == "" || textBoxPCName.Text == "localhost")
                buttonVyhledat.Enabled = false;
            else buttonVyhledat.Enabled = true;
        }
    }
}
