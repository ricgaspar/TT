using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using TechnolToolkit.CustomControls_and_Clases;
using TechnolToolkit.UserControls.Admin.Forms;

namespace TechnolToolkit
{

    public partial class UserControlAdmin : UserControl
    {
        int picSize = 110;
        int heightOffset = 10;
        public UserControlAdmin()
        {
            InitializeComponent();
        }

        private void buttonZprava_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_telegram_app_528, picSize, picSize), (buttonZprava.Width / 2) - (picSize / 2), (buttonZprava.Height / 2) - (picSize / 2 ) - heightOffset);
        }

        private void buttonZmenaSkupin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_user_group_528, picSize*2, picSize*2), (buttonZmenaSkupin.Width / 2) - (picSize / 2), (buttonZmenaSkupin.Height / 2) - (picSize / 2) - heightOffset);
        }

        private void buttonInstalovanyProgramy_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_Software_96_color, picSize, picSize), (buttonInstalovanyProgramy.Width / 2) - (picSize / 2), (buttonInstalovanyProgramy.Height / 2) - (picSize / 2) - heightOffset);
        }

        private void buttonNajdiPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_system_information_528, picSize*2+20,picSize*2+20), (buttonNajdiPC.Width / 2) - (picSize/ 2)-7, (buttonNajdiPC.Height / 2) - (picSize / 2) - heightOffset-5);
        }

        private void buttonMSI_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_remove_book_528, picSize, picSize), (buttonMSI.Width / 2) - (picSize / 2), (buttonMSI.Height / 2) - (picSize / 2) - heightOffset);
        }

        private void buttonNapajeniPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_Electrical_96_color, picSize, picSize), (buttonNapajeniPC.Width / 2) - (picSize / 2), (buttonNapajeniPC.Height / 2) - (picSize / 2) - heightOffset);
        }
       
        private void buttonVAS_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_F1_Car_96_color, picSize, picSize), (buttonVAS.Width / 2) - (picSize / 2), (buttonVAS.Height / 2) - (picSize / 2) - heightOffset);
        }

        private void buttonBitlocker_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_data_encryption_528, picSize,picSize), (buttonBitlocker.Width / 2) - (picSize / 2), (buttonBitlocker.Height / 2) - (picSize / 2) - heightOffset);
        }
        
        private void buttonZprava_Click(object sender, EventArgs e)
        {
#warning Fix me I am shit!
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\runpwshell_parameter.bat";
            p.StartInfo.Arguments = "/RemoteDialog.ps1";
            p.Start();
        }

        private void buttonNajdiPC_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\Najdi_PC.hta";
            p.Start();
        }
        MSIUninstall msi = new MSIUninstall();
        private void buttonMSI_Click(object sender, EventArgs e)
        {
            msi.restartMsiUninstall();
            msi.ShowDialog();
        }

        private void buttonZmenaSkupin_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\Change_Groups.hta";
            p.Start();
        }
        
        InstalledPrograms instalP = new InstalledPrograms();
        private void buttonInstalovanyProgramy_Click(object sender, EventArgs e)
        {
            instalP.ShowDialog();
            instalP.WindowState = FormWindowState.Normal;
            instalP.Width = 966;
            instalP.Height = 635;
        }

        private void buttonASCII_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\ASCII_znaky.vbs";
            p.Start();
        }

        private void buttonRegSearch_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\RegSearch.exe";
            p.Start();
        }

        private void buttonIPConfig_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\Zjistit_IPconfig.vbs";
            p.Start();
        }
        public void extractVAS()
        {
            if (!Directory.Exists(@"C:\ProgramData\TechnolToolkit\VAS6154_Configurator"))
            {
                string zipPath = @"C:\ProgramData\TechnolToolkit\VAS6154_Configurator.zip";
                string extractPath = @"C:\ProgramData\TechnolToolkit\VAS6154_Configurator";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
        //VASConfig vc = new VASConfig();
        private void buttonVAS_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"C:\ProgramData\TechnolToolkit\VAS6154_Configurator"))
                extractVAS();
            if (File.Exists(@"C:\ProgramData\TechnolToolkit\VAS6154_Configurator\start.bat"))
            {
                //Po rucnim spusteni funguje...
                Process p = new Process();
                p.StartInfo.FileName = "start.bat";
                p.StartInfo.WorkingDirectory = @"C:\ProgramData\TechnolToolkit\VAS6154_Configurator";
                p.Start();
            }
            else
            {
                Directory.Delete(@"C:\ProgramData\TechnolToolkit\VAS6154_Configurator",true);
                extractVAS();
                MessageBox.Show("Soubor \"C:\\ProgramData\\TechnolToolkit\\VAS6154_Configurator\\start.bat\" nenalezen!\n\nNo tak já to po tobě teda opravím :)", "I ty brute, že ty jsi ten soubor smazal?!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process p = new Process();
                p.StartInfo.FileName = "start.bat";
                p.StartInfo.WorkingDirectory = @"C:\ProgramData\TechnolToolkit\VAS6154_Configurator";
                p.Start();
            }
        }

        Bitlocker bit = new Bitlocker();
        private void buttonBitlocker_Click(object sender, EventArgs e)
        {
            bit.resetListView();
            bit.resetTextBox();
            bit.ShowDialog();
        }

        private void buttonSCCM_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_individual_server_96, 180, 180), (buttonSCCM.Width / 2) - (100 / 2), (buttonSCCM.Height / 2) - (picSize / 2) - heightOffset);
        }

        Napajeni np = new Napajeni();
        private void buttonNapajeniPC_Click(object sender, EventArgs e)
        {
            np.ShowDialog();
        }

        SCCMKlient sk = new SCCMKlient();
        private void buttonSCCM_Click(object sender, EventArgs e)
        {
            sk.ShowDialog();
        }
    }
}
