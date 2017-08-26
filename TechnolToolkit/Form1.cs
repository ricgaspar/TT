using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class Form1 : Form
    {
        bool menuVisible = true;
        string aktivniPanel = "ucA";
        #region Barvy...
        //Definovani barev pro themes
        //Blue Nadpis - 96,162,232
        /*
                Color panelDark = Color.FromArgb(53, 53, 55);
                Color menuButtonDark = Color.FromArgb(53, 53, 55); //pozadi normalni
                Color menuButtonDarkHover = Color.FromArgb(63, 63, 66); //pri hover
                Color menuButtonDarkClick = Color.FromArgb(105, 105, 107); //pri drzeni mysi
                Color menuMenuDark = Color.FromArgb(0, 120, 215); //barva se nemeni ani pri hover ci stisknuti
                Color formBkgDark = Color.FromArgb(36, 35, 38);
                //----
                Color panelBlue = Color.FromArgb(1, 73, 141);
                Color menuButtonBlue = Color.FromArgb(1, 73, 141);
                Color menuButtonBlueHover = Color.FromArgb(103, 181, 255);
                Color menuButtonBlueClick = Color.FromArgb(179, 218, 255);
                Color menuMenuBlue = Color.FromArgb(0, 120, 215);
                Color formBkgBlue = Color.FromArgb(36, 35, 38);
        */
        #endregion
        //Admin Tools
        UserControl ucA = new UserControlAdmin();
        //Other Tools
        UserControlOther ucO = new UserControlOther();
        //SCCM Tools
        UserControl ucSCCM = new UserControlSCCM();
        //Nastaveni
        UserControl ucN = new UserControlNastaveni();
        //Nahled do SAPu
        UserControl ucS = new UserControlSAP();
        //Login
        Login loginScreen = new Login();

        public Form1()
        {
            InitializeComponent();
            kopirujSoubory();
            //Vyhozi obrazovka
            flowLayoutPanel1.Controls.Add(ucA);
            ucA.Size = flowLayoutPanel1.Size;
            ucO.Size = flowLayoutPanel1.Size;
            ucSCCM.Size = flowLayoutPanel1.Size;
            ucN.Size = flowLayoutPanel1.Size;
            ucS.Size = flowLayoutPanel1.Size;
            pozadiAktivnihoButtonu(aktivniPanel);

        }

        //Funkce, která se stará o vysoko kvalitní resize obrázků
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            //Graphics g = e.Graphics;
            //g.DrawImage(ResizeImage(Properties.Resources.Admin, 45, 45), 5, -5);
            //https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
            //Nemazat
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        //Aktualizace velikosti UserControlů
        private void Form1_Resize(object sender, EventArgs e)
        {
            switch (aktivniPanel)
            {
                case "ucA":
                    ucA.Size = flowLayoutPanel1.Size;
                    break;
                case "ucO":
                    ucO.Size = flowLayoutPanel1.Size;
                    break;
                case "ucSCCM":
                    ucSCCM.Size = flowLayoutPanel1.Size;
                    break;
                case "ucN":
                    ucN.Size = flowLayoutPanel1.Size;
                    break;
                case "ucS":
                    ucS.Size = flowLayoutPanel1.Size;
                    break;
                default:
                    MessageBox.Show("Chyba při pokusu o resize! Není definovaný aktivní panel!\nKontaktujte prosím vyvojáře softwaru!", "RESIZE ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
        }

        //Skryvani menu
        private void timerMenu_Tick(object sender, EventArgs e)
        {
            ucA.Size = flowLayoutPanel1.Size;
            ucO.Size = flowLayoutPanel1.Size;
            ucSCCM.Size = flowLayoutPanel1.Size;
            ucN.Size = flowLayoutPanel1.Size;
            ucS.Size = flowLayoutPanel1.Size;
            
            if (menuVisible == true)
            {
                tableLayoutPanelVnejsi.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanelVnejsi.ColumnStyles[0].Width = tableLayoutPanelVnejsi.ColumnStyles[0].Width - 10;
                if (tableLayoutPanelVnejsi.ColumnStyles[0].Width <= 70)
                {
                    timerMenu.Stop();
                    menuVisible = false;
                }
            }
            else
            {
                
                tableLayoutPanelVnejsi.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanelVnejsi.ColumnStyles[0].Width = tableLayoutPanelVnejsi.ColumnStyles[0].Width + 10;
                if(tableLayoutPanelVnejsi.ColumnStyles[0].Width >= 250)
                {
                    timerMenu.Stop();
                    menuVisible = true;
                }
                
            }
        }
        
        //Nastavuje pozadi pro aktivni buttony
        private void pozadiAktivnihoButtonu(string activePanel)
        {
            Color barvaButtonu = Color.FromArgb(163, 163, 163);
            if (activePanel == "ucA")
            {
                
                //aktivni
                buttonAdminTools.BackColor = barvaButtonu;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                //buttonOtherTools.BackColor = Color.Transparent;
                //buttonOtherTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonSCCM.BackColor = Color.Transparent;
                //buttonSCCM.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonNastaveni.BackColor = Color.Transparent;
                //buttonNastaveni.FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttonSAP.BackColor = Color.Transparent;
                buttonSAP.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }
            if (activePanel == "ucO")
            {
                //aktivni
                //buttonOtherTools.BackColor = barvaButtonu;
                //buttonOtherTools.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                buttonAdminTools.BackColor = Color.Transparent;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonSCCM.BackColor = Color.Transparent; ;
                //buttonSCCM.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonNastaveni.BackColor = Color.Transparent;
                //buttonNastaveni.FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttonSAP.BackColor = Color.Transparent;
                buttonSAP.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }
            if (activePanel == "ucSCCM")
            {
                //aktivni
                //buttonSCCM.BackColor = barvaButtonu;
                //buttonSCCM.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                buttonAdminTools.BackColor = Color.Transparent;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonOtherTools.BackColor = Color.Transparent;
                //buttonOtherTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonNastaveni.BackColor = Color.Transparent;
                //buttonNastaveni.FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttonSAP.BackColor = Color.Transparent;
                buttonSAP.FlatAppearance.MouseOverBackColor = Color.Transparent;

            }
            if (activePanel == "ucN")
            {
                //aktivni
                //buttonNastaveni.BackColor = barvaButtonu;
                //buttonNastaveni.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                buttonAdminTools.BackColor = Color.Transparent;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonOtherTools.BackColor = Color.Transparent;
                //buttonOtherTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonSCCM.BackColor = Color.Transparent;
                //buttonSCCM.FlatAppearance.MouseOverBackColor = Color.Transparent;
                buttonSAP.BackColor = Color.Transparent;
                buttonSAP.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }
            if (activePanel == "ucS")
            {
                //aktivni
                buttonSAP.BackColor = barvaButtonu;
                buttonSAP.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
                buttonAdminTools.BackColor = Color.Transparent;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonOtherTools.BackColor = Color.Transparent;
                //buttonOtherTools.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonSCCM.BackColor = Color.Transparent;
                //buttonSCCM.FlatAppearance.MouseOverBackColor = Color.Transparent;
                //buttonNastaveni.BackColor = Color.Transparent;
                //buttonNastaveni.FlatAppearance.MouseOverBackColor = Color.Transparent;
            }
        }
        
        #region Button Click funkce
        private void buttonSCCM_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucSCCM");
        }
        private void buttonNastaveni_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucN");
        }
        private void buttonOtherTools_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucO");
        }
        private void buttonAdminTools_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucA");
        }
        private void buttonSAP_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucS");
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            timerMenu.Start();
        }
        #endregion

        #region Button Paint funkce
        //Admin nastroje button
        private void buttonAdminTools_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ResizeImage(Properties.Resources.icons8_Crown_96, 50, 50), 10, 2);

        }
        //Menu button (skryvani menu)
        private void buttonMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ResizeImage(Properties.Resources.Menu_96px, 35, 35), 21, 7);
        }
        //SAP button
        private void buttonSAP_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ResizeImage(Properties.Resources.icons8_SAP_96, 50, 50), 14, 2);
        }
        #endregion

        //Funkce která se stará o změnu zobrazovaného UserControl a volá funkci na změnu pozadí buttonu
        private void activePanelFuntion(string activePanel, string buttonClicked)
        {
            switch(buttonClicked)
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
                        switch (activePanel)
                        {
                            case "ucA":
                                flowLayoutPanel1.Controls.Remove(ucA);
                                break;
                            case "ucO":
                                flowLayoutPanel1.Controls.Remove(ucO);
                                break;
                            case "ucSCCM":
                                flowLayoutPanel1.Controls.Remove(ucSCCM);
                                break;
                            case "ucN":
                                flowLayoutPanel1.Controls.Remove(ucN);
                                break;
                            case "ucS":
                                flowLayoutPanel1.Controls.Remove(ucS);
                                break;
                        }
                        flowLayoutPanel1.Controls.Add(ucA);
                        ucA.Size = flowLayoutPanel1.Size;
                        aktivniPanel = "ucA";
                    }
                    #endregion
                    break;
                case "ucO":
                    #region ucO code...
                    //Kliknuli jsme na jiz zobrazovany button(user control)?
                    if(activePanel == "ucO")
                        return;
                    //Neni zobrazovany!
                    else
                    {
                        //Klikli jsme na Ostatni nastroje. Ostatni nastroje nejsou zobrazovany(je zobrazovana jina sekce). Smazeme soucasny user control a nahradime ho ucO
                        switch (activePanel)
                        {
                            case "ucA":
                                flowLayoutPanel1.Controls.Remove(ucA);
                                break;
                            case "ucO":
                                flowLayoutPanel1.Controls.Remove(ucO);
                                break;
                            case "ucSCCM":
                                flowLayoutPanel1.Controls.Remove(ucSCCM);
                                break;
                            case "ucN":
                                flowLayoutPanel1.Controls.Remove(ucN);
                                break;
                            case "ucS":
                                flowLayoutPanel1.Controls.Remove(ucS);
                                break;
                        }
                        flowLayoutPanel1.Controls.Add(ucO);
                        ucO.Size = flowLayoutPanel1.Size;
                        aktivniPanel = "ucO";
                    }
                    #endregion
                    break;
                case "ucSCCM":
                    #region ucSCCM code...
                    //Kliknuli jsme na jiz zobrazovany button(user control)?
                    if (activePanel == "ucSCCM")
                        return;
                    //Neni zobrazovany!
                    else
                    {
                        //Klikli jsme na SCCM nastroje. Ostatni nastroje nejsou zobrazovany(je zobrazovana jina sekce). Smazeme soucasny user control a nahradime ho ucSCCM
                        switch (activePanel)
                        {
                            case "ucA":
                                flowLayoutPanel1.Controls.Remove(ucA);
                                break;
                            case "ucO":
                                flowLayoutPanel1.Controls.Remove(ucO);
                                break;
                            case "ucSCCM":
                                flowLayoutPanel1.Controls.Remove(ucSCCM);
                                break;
                            case "ucN":
                                flowLayoutPanel1.Controls.Remove(ucN);
                                break;
                            case "ucS":
                                flowLayoutPanel1.Controls.Remove(ucS);
                                break;
                        }
                        flowLayoutPanel1.Controls.Add(ucSCCM);
                        ucSCCM.Size = flowLayoutPanel1.Size;
                        aktivniPanel = "ucSCCM";
                    }
                    #endregion
                    break;
                case "ucN":
                    #region ucN code...
                    //Kliknuli jsme na jiz zobrazovany button(user control)?
                    if (activePanel == "ucN")
                        return;
                    //Neni zobrazovany!
                    else
                    {
                        //Klikli jsme na Nastaveni. Nastaveni neni zobrazovany(je zobrazovana jina sekce). Smazeme soucasny user control a nahradime ho ucN
                        switch (activePanel)
                        {
                            case "ucA":
                                flowLayoutPanel1.Controls.Remove(ucA);
                                break;
                            case "ucO":
                                flowLayoutPanel1.Controls.Remove(ucO);
                                break;
                            case "ucSCCM":
                                flowLayoutPanel1.Controls.Remove(ucSCCM);
                                break;
                            case "ucN":
                                flowLayoutPanel1.Controls.Remove(ucN);
                                break;
                            case "ucS":
                                flowLayoutPanel1.Controls.Remove(ucS);
                                break;
                        }
                        flowLayoutPanel1.Controls.Add(ucN);
                        ucN.Size = flowLayoutPanel1.Size;
                        aktivniPanel = "ucN";
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
                        //Klikli jsme na Nahled do SAPu. Nahled do SAPu neni zobrazovany(je zobrazovana jina sekce). Smazeme soucasny user control a nahradime ho ucS
                        switch (activePanel)
                        {
                            case "ucA":
                                flowLayoutPanel1.Controls.Remove(ucA);
                                break;
                            case "ucO":
                                flowLayoutPanel1.Controls.Remove(ucO);
                                break;
                            case "ucSCCM":
                                flowLayoutPanel1.Controls.Remove(ucSCCM);
                                break;
                            case "ucN":
                                flowLayoutPanel1.Controls.Remove(ucN);
                                break;
                            case "ucS":
                                flowLayoutPanel1.Controls.Remove(ucS);
                                break;
                        }
                        flowLayoutPanel1.Controls.Add(ucS);
                        ucS.Size = flowLayoutPanel1.Size;
                        aktivniPanel = "ucS";
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
                System.Diagnostics.Trace.WriteLine("Kopiruji: "+ resourceName);
                if (resourceName.StartsWith("TechnolToolkit.Resources."))
                {
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
}
