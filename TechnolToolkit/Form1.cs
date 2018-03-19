using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices;
using TechnolToolkit.CustomControls_and_Clases;
using System.Security.Cryptography;
using System.Text;
using TechnolToolkit.Resources;
using TechnolToolkit.UserControls.Multiping;

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
            ucAG.Size = flowLayoutPanel1.Size;
            pozadiAktivnihoButtonu(aktivniPanel);
            this.MaximizeBox = false;
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
        Multiping mp = new Multiping();
        private void buttonMultiping_Click(object sender, EventArgs e)
        {
            mp.Show();
        }
        private void buttonAdminTools_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucA");
            /*if (aktivniPanel == "ucA")
            {
              */
            /*
              Graphics dc = this.CreateGraphics();
              Pen pen = new Pen(Color.Blue, 3);
              dc.DrawRectangle(pen, 0, 0, 50, 50);
              Refresh();
              */
            //}
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
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_Menu_96_color, 35, 35), 21, 9);
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
            g.DrawImage(ImageManipulation.ResizeImage(Properties.Resources.icons8_broadcasting_96, 100,100), 12, 0);
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
        }
        DeleteFiles df = new DeleteFiles();
        private void linkLabelDeleteAllFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            df.ShowDialog();
        }

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
                    MessageBox.Show("Licence není platná!\n\nUkončuji program...");
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
                MessageBox.Show("Nebyla nalezena licence!\n\nUkončuji program...");
                Application.Exit();
            }
        }
        SHA512_Generator sh = new SHA512_Generator();
        private void buttonSHA512Generator_Click(object sender, EventArgs e)
        {
            sh.ShowDialog();
        }

       
    }
}
