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
        //Admin Tools
        UserControl ucA = new UserControlAdmin();
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
                case "ucS":
                    ucS.Size = flowLayoutPanel1.Size;
                    break;
                default:
                    MessageBox.Show("Chyba při pokusu o resize! Není definovaný aktivní panel!\nKontaktujte prosím vyvojáře softwaru!", "RESIZE ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
        }
        
        //Nastavuje pozadi pro aktivni buttony
        private void pozadiAktivnihoButtonu(string activePanel)
        {
            Color barvaButtonu = Color.FromArgb(212, 223, 237); 
            //Black - Color barvaButtonu = Color.FromArgb(37, 51, 79);
            if (activePanel == "ucA")
            {

                //aktivni
                buttonAdminTools.BackColor = barvaButtonu;
                buttonAdminTools.FlatAppearance.MouseOverBackColor = barvaButtonu;
                //neaktivni
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
            }
        }
        
        #region Button Click funkce
        private void buttonAdminTools_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucA");
            /*if (aktivniPanel == "ucA")
            {
              */  Graphics dc = this.CreateGraphics();
                Pen pen = new Pen(Color.Blue, 3);
                dc.DrawRectangle(pen, 0, 0, 50, 50);
                Refresh();
            //}
        }
        private void buttonSAP_Click(object sender, EventArgs e)
        {
            activePanelFuntion(aktivniPanel, "ucS");
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {          
            if (menuVisible == true)
            {
                tableLayoutPanelVnejsi.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanelVnejsi.ColumnStyles[0].Width = 70;
                menuVisible = false;
            }
            else
            {

                tableLayoutPanelVnejsi.ColumnStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanelVnejsi.ColumnStyles[0].Width = 250;
                menuVisible = true;
            }
            ucA.Size = flowLayoutPanel1.Size;
            ucS.Size = flowLayoutPanel1.Size;
        }
        #endregion

        #region Button Paint funkce
        //Admin nastroje button
        private void buttonAdminTools_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ResizeImage(Properties.Resources.icons8_Moderator_96_color, 50, 50), 10, 2);;
            if (aktivniPanel == "ucA")
            {
                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(0, 0, 5, buttonAdminTools.Height);
                Brush br = new SolidBrush(Color.FromArgb(140, 164, 196));
                g.FillRectangle(br, rect);
            }


        }
        //Menu button (skryvani menu)
        private void buttonMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ResizeImage(Properties.Resources.icons8_Menu_96_color, 35, 35), 21, 9);
        }
        //SAP button
        private void buttonSAP_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(ResizeImage(Properties.Resources.icons8_SAP_96_color, 50, 50), 14, 2);
            if (aktivniPanel == "ucS")
            {
                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(0, 0, 5, buttonSAP.Height);
                Brush br = new SolidBrush(Color.FromArgb(140, 164, 196));
                g.FillRectangle(br, rect);
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1);
            e.Graphics.DrawLine(pen,panel1.Width-1,0,panel1.Width-1,panel1.Height-1);
        }
    }
}
