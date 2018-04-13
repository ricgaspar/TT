﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TechnolToolkit.CustomControls_and_Clases;
using System.Security.Cryptography;
using System.Text;
using TechnolToolkit.Resources;
using TechnolToolkit.UserControls.Multiping;
using System.Diagnostics;

namespace TechnolToolkit
{
    public partial class Form1 : Form
    {
        public Color themeColor = Color.FromArgb(174, 0, 0);
        string aktivniPanel = "ucA";
        Color activeButtonLineColor = Color.FromArgb(174, 0, 0);
        //Admin Tools
        UserControl ucA = new UserControlAdmin();
        //Nahled do SAPu
        UserControl ucS = new UserControlSAP();
        //Pridani do skupin
        UserControlAddToGroup ucAG = new UserControlAddToGroup();
        public Form1()
        {
            InitializeComponent();
            kopirujSoubory();
            //Vyhozi obrazovka
            flowLayoutPanel1.Controls.Add(ucA);
            pozadiAktivnihoButtonu(aktivniPanel);
            this.MaximizeBox = false;
            ucAG.Size = flowLayoutPanel1.Size;
        }

        //Aktualizace velikosti UserControlů
        private void Form1_Resize(object sender, EventArgs e)
        {
            switch (aktivniPanel)
            {
                case "ucA":
                    ucA.Size = flowLayoutPanel1.Size;
                    break;
                case "ucS":
                    ucS.Size = flowLayoutPanel1.Size;
                    break;
                case "ucAG":
                    ucAG.Size = flowLayoutPanel1.Size;
                    break;
                default:
                    MessageBox.Show("Chyba při pokusu o resize! Není definovaný aktivní panel!", "RESIZE ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        //Nastavuje pozadi pro aktivni buttony
        private void pozadiAktivnihoButtonu(string activePanel)
        {
            Color barvaButtonu = Color.FromArgb(48, 48, 48);
            //Black - Color barvaButtonu = Color.FromArgb(37, 51, 79);
            if (activePanel == "ucA")
            {

                //aktivni
                buttonAdminTools.BackColor = barvaButtonu;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                buttonSAP.BackColor = Color.Transparent;
                buttonSAP.FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttonAddToGroup.BackColor = Color.Transparent;
                buttonAddToGroup.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }
            if (activePanel == "ucS")
            {
                //aktivni
                buttonSAP.BackColor = barvaButtonu;
                buttonSAP.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                buttonAdminTools.BackColor = Color.Transparent;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttonAddToGroup.BackColor = Color.Transparent;
                buttonAddToGroup.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }
            if (activePanel == "ucAG")
            {
                //aktivni
                buttonAddToGroup.BackColor = barvaButtonu;
                buttonAddToGroup.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                buttonAdminTools.BackColor = Color.Transparent;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttonSAP.BackColor = Color.Transparent;
                buttonSAP.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }            
        }

        #region Button Click funkce
        private void buttonMultiping_Click(object sender, EventArgs e)
        {
            Multiping mp = new Multiping();
            mp.Show();
        }
        private void buttonAdminTools_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucA");
        }
        private void ButtonSAP_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucS");
        }
        private void buttonAddToGroup_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucAG");
        }
        private void buttonDZC_Click(object sender, EventArgs e)
        {
            Form dzcSearch = new DZCsearch();
            dzcSearch.ShowDialog();
        }

        #endregion

        #region Button Paint funkce
        //Admin nastroje button
        private void buttonAdminTools_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_Moderator_96_color, 50, 50), 10, 2);
            if (aktivniPanel == "ucA")
            {
                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(0, 0, 5, buttonAdminTools.Height);
                Brush br = new SolidBrush(activeButtonLineColor);
                g.FillRectangle(br, rect);
            }
        }
        //Menu button (skryvani menu)
        private void buttonMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_menu_528, 80, 80), 13, 6);
        }
        //SAP button
        private void buttonSAP_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_SAP_96_color, 50, 50), 14, (buttonSAP.Height / 2) - 25);
            if (aktivniPanel == "ucS")
            {
                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(0, 0, 5, buttonSAP.Height);
                Brush br = new SolidBrush(activeButtonLineColor);
                g.FillRectangle(br, rect);
            }
        }

        private void buttonAddToGroup_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_add_user_group_man_man_96, 100, 100), 8, 0);
            if (aktivniPanel == "ucAG")
            {
                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(0, 0, 5, buttonAddToGroup.Height);
                Brush br = new SolidBrush(activeButtonLineColor);
                g.FillRectangle(br, rect);
            }
        }

        private void buttonMultiping_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_broadcasting_96, 100,100), 8, 3);
        }

        private void buttonDZC_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_UserSearcg_96_color, 50, 50), 8, 0);
        }
        #endregion

        //Funkce která se stará o změnu zobrazovaného UserControl a volá funkci na změnu pozadí buttonu
        private void activePanelFuntion(string activePanel, string buttonClicked)
        {
            switch (buttonClicked)
            {
                case "ucA":
                    #region ucA code...
                    //Kliknuli jsme na jiz zobrazovany button(user control)?
                    if (activePanel == "ucA")
                        return;
                    //Neni zobrazovany!
                    else
                    {
                        //Klikli jsme na Admin nastroje. Admin nastroje nejsou zobrazovany(je zobrazovana jina sekce). Smazeme soucasny user control a nahradime ho ucA
                        flowLayoutPanel1.Controls.Clear();
                        flowLayoutPanel1.Controls.Add(ucA);
                        ucA.Size = flowLayoutPanel1.Size;
                        aktivniPanel = "ucA";
                        this.WindowState = FormWindowState.Normal;
                        this.MaximizeBox = false;
                    }
                    #endregion
                    break;
                case "ucS":
                    #region ucS code...
                    //Kliknuli jsme na jiz zobrazovany button(user control)?
                    if (activePanel == "ucS")
                        return;
                    //Neni zobrazovany!
                    else
                    {
                        flowLayoutPanel1.Controls.Clear();
                        flowLayoutPanel1.Controls.Add(ucS);
                        ucS.Size = flowLayoutPanel1.Size;
                        aktivniPanel = "ucS";
                        this.MaximizeBox = true;
                    }
                    #endregion
                    break;
                case "ucAG":
                    #region ucAG code...
                    if (activePanel == "ucAG")
                        return;
                    else
                    {
                        //Vycisteni predeslych user controlu
                        flowLayoutPanel1.Controls.Clear();
                        //pridani noveho user controlu
                        flowLayoutPanel1.Controls.Add(ucAG);
                        //nastaveni velikosti user controlu na velikost flowlayoutpanel1
                        ucAG.Size = flowLayoutPanel1.Size;
                        //nastaveni aktivniho panelu
                        aktivniPanel = "ucAG";
                        this.MaximizeBox = true;
                    }
                    #endregion
                    break;                
            }
            pozadiAktivnihoButtonu(buttonClicked);
        }

        public static void kopirujSoubory()
        {
            if (!Directory.Exists(@"C:\ProgramData\TechnolToolkit"))
                Directory.CreateDirectory(@"C:\ProgramData\TechnolToolkit");
            //nakopirovani souboru
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                if (resourceName.StartsWith("TechnolToolkit.Resources."))
                {
                    string soubor = resourceName.Replace("TechnolToolkit.Resources.", "");
                    if (!File.Exists(@"C:\ProgramData\TechnolToolkit\" + soubor))
                    {
                        System.Diagnostics.Trace.WriteLine("Kopiruji: " + resourceName);
                        using (var fs = File.Create(@"C:\ProgramData\TechnolToolkit\" + resourceName.Replace("TechnolToolkit.Resources.", "")))
                        {
                            var rs = assembly.GetManifestResourceStream(resourceName);
                            rs.CopyTo(fs);
                            rs.Close();
                        }
                    }
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(48, 48, 48), 1);
            e.Graphics.DrawLine(pen, tableLayoutPanelMenu.Width - 1, 0, tableLayoutPanelMenu.Width - 1, tableLayoutPanelMenu.Height - 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(60, 60, 60), 1), 0, buttonMenu.Location.Y+55, tableLayoutPanelMenu.Width, buttonMenu.Location.Y + 55);
        }
        DeleteFiles df = new DeleteFiles();
        private void linkLabelDeleteAllFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            df.ShowDialog();
        }
        #region old_Lincense_check
        /*
        This featrue is no longer in use! All license checks are now commented and do not work.
        That means anyone can use this program.
        private string ToSHA512_HEX(string value)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] hashData = sha512.ComputeHash(Encoding.UTF8.GetBytes(value));
            StringBuilder hex = new StringBuilder(hashData.Length * 2);
            StringBuilder returnValue = new StringBuilder();
            foreach (byte b in hashData)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private string fromHexatoString(string value)
        {
            int NumberChars = value.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(value.ToString().Substring(i, 2), 16);

            StringBuilder str = new StringBuilder();
            foreach (byte b in bytes)
                str.Append(b);
            return str.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\ProgramData\TechnolToolkit\License.dat"))
            {
                this.Enabled = false;
                this.Visible = false;
                bool accessGranted = false;

                string[] fileContent = File.ReadAllLines(@"C:\ProgramData\TechnolToolkit\License.dat");

                foreach (string line in fileContent)
                {
                    //kontrola, zda-li alespon jeden radek v licencnim souboru ma spravny hash
                    if (line == ToSHA512_HEX(Environment.UserName + ";" + Environment.MachineName))
                    {
                        accessGranted = true;
                        break;
                    }
                    else accessGranted = false;
                }
                if (accessGranted != true)
                {
                    MessageBox.Show("Licence není platná!\n\nVložte licenční kód do následujícího souboru C:\\ProgramData\\TechnolToolkit\\License.dat\n\n---------------------------------\n\nLicense is not valid!\n\nInsert the license code into the following file C:\\ProgramData\\TechnolToolkit\\License.dat", "Neplatná licence \\ Invalid license", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                else
                {
                    this.Enabled = true;
                    this.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Licence není platná!\n\nVložte licenční kód do následujícího souboru C:\\ProgramData\\TechnolToolkit\\License.dat\n\n---------------------------------\n\nLicense is not valid!\n\nInsert the license code into the following file C:\\ProgramData\\TechnolToolkit\\License.dat", "Neplatná licence \\ Invalid license", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }
        */
        #endregion

        private void buttonSHA512Generator_Click(object sender, EventArgs e)
        {
            SHA512_Generator sh = new SHA512_Generator();
            sh.ShowDialog();
        }

        private void buttonSHA512Generator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_password_528, 50,50), 12, 1);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.FromArgb(60,60,60), 1), 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void buttonAbout_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_about_528, 500,500), 12, 5);
        }
    }
}
