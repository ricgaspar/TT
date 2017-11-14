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

namespace TechnolToolkit
{
    public partial class Napajeni : Form
    {
        public Napajeni()
        {
            InitializeComponent();
        }
        void Shutdown()
        {
            try
            {
                const string computerName = "COMPUTER"; // computer name or IP address

                ConnectionOptions options = new ConnectionOptions();
                options.EnablePrivileges = true;
                // To connect to the remote computer using a different account, specify these values:
                // options.Username = "USERNAME";
                // options.Password = "PASSWORD";
                // options.Authority = "ntlmdomain:DOMAIN";

                ManagementScope scope = new ManagementScope(
                  "\\\\" + computerName + "\\root\\CIMV2", options);
                scope.Connect();

                SelectQuery query = new SelectQuery("Win32_OperatingSystem");
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject os in searcher.Get())
                {
                    // Obtain in-parameters for the method
                    ManagementBaseObject inParams =
                        os.GetMethodParameters("Win32Shutdown");

                    // Add the input parameters.
                    inParams["Flags"] = 2;

                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams =
                        os.InvokeMethod("Win32Shutdown", inParams, null);
                }
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
            catch (System.UnauthorizedAccessException unauthorizedErr)
            {
                MessageBox.Show("Connection error (user name or password might be incorrect): " + unauthorizedErr.Message);
            }
        }
    }
}
