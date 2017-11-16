﻿using System;
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

namespace TechnolToolkit
{

    public partial class UserControlAdmin : UserControl
    {
        int picSize = 90;
        public UserControlAdmin()
        {
            InitializeComponent();
        }

        private void buttonZprava_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Post_96_color, picSize, picSize), (buttonZprava.Width / 2) - (picSize / 2), 5);
        }

        private void buttonZmenaSkupin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_User_Groups_96_color, picSize, picSize), (buttonZmenaSkupin.Width / 2) - (picSize / 2), 5);
        }

        private void buttonInstalovanyProgramy_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Software_Installer_96, picSize,picSize), (buttonInstalovanyProgramy.Width / 2) - (picSize / 2), 10);
        }

        private void buttonNajdiPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_LaptopSearch_96_color, picSize, picSize), (buttonNajdiPC.Width / 2) - (picSize / 2), 5);
        }

        private void buttonProcesy_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Processor_96_color, picSize, picSize), (buttonProcesy.Width / 2) - (picSize / 2), 5);
        }

        private void buttonMSI_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_SoftwareUninstall_96_color, picSize, picSize), (buttonMSI.Width / 2) - (picSize / 2), 5);
        }

        private void buttonRemoteControl_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Remote_Working_96_color, picSize, picSize), (buttonRemoteControl.Width / 2) - (picSize / 2), 5);
        }

        private void buttonNapajeniPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Electrical_96_color, picSize, picSize), (buttonNapajeniPC.Width / 2) - (picSize / 2), 5);
        }
        private void buttonRegSearch_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Registry_Editor_96_color, picSize, picSize), (buttonRegSearch.Width / 2) - (picSize / 2), 5);
        }
        private void buttonInfoPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Workstation_96, picSize, picSize), (buttonInfoPC.Width / 2) - (picSize / 2), 5);
        }

        private void buttonIPConfig_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Network_Card_96_color, picSize, picSize), (buttonIPConfig.Width / 2) - (picSize / 2), 5);
        }

        private void buttonUserPCname_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Under_Computer_96_color, picSize, picSize), (buttonUserPCname.Width / 2) - (picSize / 2), 5);
        }

        private void buttonVAS_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Car_96_color, picSize, picSize), (buttonVAS.Width / 2) - (picSize / 2), 5);
        }

        private void buttonASCII_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Sublime_Text_96_color, picSize, picSize), (buttonASCII.Width / 2) - (picSize / 2), 5);
        }

        private void buttonZasadyPC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Heart_Monitor_96_color, picSize, picSize), (buttonZasadyPC.Width / 2) - (picSize / 2), 0);
        }

        private void buttonAkceVsechny_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Heart_MonitorAll_96_color, picSize, picSize), (buttonAkceVsechny.Width / 2) - (picSize / 2), 0);
        }

        private void buttonBitlocker_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Encrypt_96_color, picSize, picSize), (buttonBitlocker.Width / 2) - (picSize / 2), 5);
        }

        private void buttonZprava_Click(object sender, EventArgs e)
        {
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
        RemoteControl rmc = new RemoteControl();
        private void buttonRemoteControl_Click(object sender, EventArgs e)
        {
            rmc.ShowDialog();
        }
        InstalledPrograms instalP = new InstalledPrograms();
        private void buttonInstalovanyProgramy_Click(object sender, EventArgs e)
        {
            instalP.ShowDialog();
            instalP.WindowState = FormWindowState.Normal;
            instalP.Width = 966;
            instalP.Height = 635;
        }

        private void buttonProcesy_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxLine_Paint(object sender, PaintEventArgs e)
        {
            Graphics line = e.Graphics;
            line.DrawLine(new Pen(Brushes.Gray, 3), 0, 0, pictureBoxLine.Width, 0);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics line = e.Graphics;
            line.DrawLine(new Pen(Brushes.Gray, 3), 0, 0, pictureBoxLine.Width, 0);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics line = e.Graphics;
            line.DrawLine(new Pen(Brushes.Gray, 3), 0, 0, pictureBoxLine.Width, 0);
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
            if (!Directory.Exists(@"C:\ProgramData\TechnolToolkit\VAS6154"))
            {
                string zipPath = @"C:\ProgramData\TechnolToolkit\VAS6154.zip";
                string extractPath = @"C:\ProgramData\TechnolToolkit";

                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
        VASConfig vc = new VASConfig();
        private void buttonVAS_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(@"C:\ProgramData\TechnolToolkit\VAS6154"))
                extractVAS();
            vc.restore();
            vc.ShowDialog();
        }

        Bitlocker bit = new Bitlocker();
        private void buttonBitlocker_Click(object sender, EventArgs e)
        {
            bit.resetListView();
            bit.resetTextBox();
            bit.ShowDialog();
        }

        private void buttonUserPCname_Click(object sender, EventArgs e)
        {

        }
        InfoPC ipc = new InfoPC();
        private void buttonInfoPC_Click(object sender, EventArgs e)
        {
            ipc.ShowDialog();
        }

        private void buttonOpravaKlienta_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Form1.ResizeImage(Properties.Resources.icons8_Computer_Repair96, picSize, picSize), (buttonOpravaKlienta.Width / 2) - (picSize / 2), 0);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}