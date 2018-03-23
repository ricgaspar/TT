using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TechnolToolkit.CustomControls_and_Clases
{
    class ServiceManipulation
    {
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
                    using (ServiceController sc = new ServiceController(serviceName, computer))
                        if (sc.Status != ServiceControllerStatus.Running)
                        {
                            Console.WriteLine("Start sluzby {0}", sc.DisplayName);
                            sc.Start();
                            Console.WriteLine("Cekani na status: Running");
                            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(60));
                            if (sc.Status != ServiceControllerStatus.Running)
                                MessageBox.Show("Sluzbu " + sc.DisplayName + " se nepodarilo spustit", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else Console.WriteLine("Status sluzby {0}: {1}",sc.DisplayName,sc.Status);
                        }
                        else Console.WriteLine("Status sluzby {0}: {1}", sc.DisplayName, sc.Status);
                    break;

                case serviceAction.stop:
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
