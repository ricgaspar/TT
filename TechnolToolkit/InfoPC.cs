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

                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");

                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Win32_ComputerSystem instance");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Computer Name: {0}", queryObj["name"]);
                        Console.WriteLine("SystemType: {0}", queryObj["SystemType"]);
                        Console.WriteLine("Model: {0}", queryObj["model"]);
                        Console.WriteLine("Manufacturer: {0}", queryObj["Manufacturer"]);
                        Console.WriteLine("Domain: {0}", queryObj["domain"]);
                        Console.WriteLine("DNSHostName: {0}", queryObj["DNSHostName"]);
                        Console.WriteLine("BootupState: {0}", queryObj["BootupState"]);
                        Console.WriteLine("UserName: {0}", queryObj["UserName"]);
                        Console.WriteLine("NumberOfProcessors: {0}", queryObj["NumberOfProcessors"]);
                        Console.WriteLine("NumberOfLogicalProcessors: {0}", queryObj["NumberOfLogicalProcessors"]);
                        //####################################################
                        ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Desktop");

                        foreach (ManagementObject queryObj1 in searcher1.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_Desktop instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Wallpaper: {0}", queryObj1["Wallpaper"]);
                        }
                        //####################################################
                        ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");

                        foreach (ManagementObject queryObj2 in searcher2.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_DesktopMonitor instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("ScreenHeight: {0}", queryObj2["ScreenHeight"]);
                            Console.WriteLine("ScreenWidth: {0}", queryObj2["ScreenWidth"]);
                        }
                        //####################################################
                        /*
                        Nize LogicalDisk instance to vyhodi v lepsim vzhledu.. asi zbytecny
                        ManagementObjectSearcher searcher3 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");

                        foreach (ManagementObject queryObj3 in searcher3.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_DiskDrive instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Caption: {0}", queryObj3["Caption"]);
                            Console.WriteLine("InterfaceType: {0}", queryObj3["InterfaceType"]);
                            Console.WriteLine("MediaType: {0}", queryObj3["MediaType"]);
                            Console.WriteLine("Model: {0}", queryObj3["Model"]);
                            Console.WriteLine("Partitions: {0}", queryObj3["Partitions"]);
                            Console.WriteLine("SerialNumber: {0}", queryObj3["SerialNumber"]);
                            Console.WriteLine("Size: {0}", queryObj3["Size"]);

                        }
                        */
                        //####################################################
                        ManagementObjectSearcher searcher5 = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_LogicalDisk");

                        foreach (ManagementObject queryObj5 in searcher5.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_LogicalDisk instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Name: {0}", queryObj5["Name"]);
                            Console.WriteLine("VolumeName: {0}", queryObj5["VolumeName"]);
                            Console.WriteLine("Description: {0}", queryObj5["Description"]);
                            Console.WriteLine("FileSystem: {0}", queryObj5["FileSystem"]);
                            Console.WriteLine("FreeSpace: {0}", queryObj5["FreeSpace"]);
                            Console.WriteLine("ProviderName: {0}", queryObj5["ProviderName"]);

                        }
                        //####################################################
                        //Vsude, kde jsem pripojeny
                        ManagementObjectSearcher searcher6 = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_NetworkConnection");

                        foreach (ManagementObject queryObj6 in searcher6.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_NetworkConnection instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Name: {0}", queryObj6["Name"]);
                            Console.WriteLine("LocalName: {0}", queryObj6["LocalName"]);
                            Console.WriteLine("ConnectionState: {0}", queryObj6["ConnectionState"]);
                            Console.WriteLine("RemoteName: {0}", queryObj6["RemoteName"]);
                            Console.WriteLine("RemotePath: {0}", queryObj6["RemotePath"]);
                            Console.WriteLine("Status: {0}", queryObj6["Status"]);
                            Console.WriteLine("UserName: {0}", queryObj6["UserName"]);
                        }
                        ManagementObjectSearcher searcher7 = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_OperatingSystem");

                        foreach (ManagementObject queryObj7 in searcher7.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_OperatingSystem instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Caption: {0}", queryObj7["Caption"]);
                            Console.WriteLine("EncryptionLevel: {0}", queryObj7["EncryptionLevel"]);
                            Console.WriteLine("InstallDate: {0}", queryObj7["InstallDate"]);
                            Console.WriteLine("LastBootUpTime: {0}", queryObj7["LastBootUpTime"]);
                            Console.WriteLine("OSArchitecture: {0}", queryObj7["OSArchitecture"]);
                            Console.WriteLine("SystemDirectory: {0}", queryObj7["SystemDirectory"]);
                            Console.WriteLine("WindowsDirectory: {0}", queryObj7["WindowsDirectory"]);
                            Console.WriteLine("SystemDrive: {0}", queryObj7["SystemDrive"]);
                            Console.WriteLine("OS Version: {0}", queryObj7["Version"]);
                        }

                        ManagementObjectSearcher searcher8 = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_Processor");

                            foreach (ManagementObject queryObj8 in searcher8.Get())
                            {
                                Console.WriteLine("-----------------------------------");
                                Console.WriteLine("Win32_Processor instance");
                                Console.WriteLine("-----------------------------------");
                                Console.WriteLine("Name: {0}", queryObj8["Name"]);
                                Console.WriteLine("CurrentClockSpeed: {0}", queryObj8["CurrentClockSpeed"]);
                                Console.WriteLine("NumberOfCores: {0}", queryObj8["NumberOfCores"]);
                                Console.WriteLine("ThreadCount: {0}", queryObj8["ThreadCount"]);
                                Console.WriteLine("NumberOfEnabledCore: {0}", queryObj8["NumberOfEnabledCore"]);
                            }

                        /*
                        //VYPISE VSECHNY NAINSTALOVANY PROGRAMY A INFO O NICH
                        ManagementObjectSearcher searcher9 = new ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_Product");

                        foreach (ManagementObject queryObj9 in searcher9.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_Product instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Name: {0}", queryObj9["Name"]);
                            Console.WriteLine("InstallDate: {0}", queryObj9["InstallDate"]);
                            Console.WriteLine("InstallLocation: {0}", queryObj9["InstallLocation"]);
                            Console.WriteLine("InstallSource: {0}", queryObj9["InstallSource"]);
                            Console.WriteLine("LocalPackage: {0}", queryObj9["LocalPackage"]);
                            Console.WriteLine("ProductID: {0}", queryObj9["ProductID"]);
                            Console.WriteLine("Vendor: {0}", queryObj9["Vendor"]);
                            Console.WriteLine("Version: {0}", queryObj9["Version"]);
                        }
                        */
                        ManagementObjectSearcher searcher10 = new ManagementObjectSearcher("root\\cimv2","SELECT * FROM Win32_VideoController");
                        
                        foreach (ManagementObject queryObj10 in searcher10.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Win32_VideoController instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Caption: {0}", queryObj10["Caption"]);
                            Console.WriteLine("CurrentBitsPerPixel: {0}", queryObj10["CurrentBitsPerPixel"]);
                            Console.WriteLine("CurrentHorizontalResolution: {0}", queryObj10["CurrentHorizontalResolution"]);
                            Console.WriteLine("CurrentVerticalResolution: {0}", queryObj10["CurrentVerticalResolution"]);
                            Console.WriteLine("CurrentRefreshRate: {0}", queryObj10["CurrentRefreshRate"]);
                            Console.WriteLine("DriverDate: {0}", queryObj10["DriverDate"]);
                            Console.WriteLine("DriverVersion: {0}", queryObj10["DriverVersion"]);
                            Console.WriteLine("MaxRefreshRate: {0}", queryObj10["MaxRefreshRate"]);
                            Console.WriteLine("MinRefreshRate: {0}", queryObj10["MinRefreshRate"]);
                            Console.WriteLine("Name: {0}", queryObj10["Name"]);                           
                            Console.WriteLine("VideoModeDescription: {0}", queryObj10["VideoModeDescription"]);
                        }
                        

                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

            }
            else
            {
                ManagementScope scope = new ManagementScope(@"\\" + textBoxPCName.Text + @"\root\cimv2");
                scope.Connect();

                //Query system for Operating System information
                /*
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    // Display the remote computer information
                    Console.WriteLine("Computer Name : {0}", m["csname"]);
                    Console.WriteLine("Windows Directory : {0}", m["WindowsDirectory"]);
                    Console.WriteLine("Operating System: {0}", m["Caption"]);
                    Console.WriteLine("Version: {0}", m["Version"]);
                    Console.WriteLine("Manufacturer: {0}", m["Manufacturer"]);                    
                }
                */
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("SystemType: {0}", queryObj["SystemType"]);
                    Console.WriteLine("Computer Name: {0}", queryObj["csname"]);
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
        private void naplListView()
        {
            listView1.View = View.LargeIcon;
            ListViewItem lvi = new ListViewItem("test");
            lvi.SubItems.Add("poditem");
            lvi.SubItems.Add("poditem2");
            listView1.LargeImageList = imageList1;
            lvi.ImageIndex = 0;
            listView1.Items.Add(lvi);
            
            
        }

        private void InfoPC_Load(object sender, EventArgs e)
        {
            naplListView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.Text)
            {
                case "LargeIcon":
                    listView1.View = View.LargeIcon;
                    break;
                case "SmallIcon":
                    listView1.View = View.SmallIcon;
                    break;
                case "Title":
                    listView1.View = View.Tile;
                    break;
                case "List":
                    listView1.View = View.List;
                    break;
                case "Details":
                    listView1.View = View.Details;
                    break;
            }
            
        }
    }
}
