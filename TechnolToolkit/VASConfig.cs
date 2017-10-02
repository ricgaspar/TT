using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class VASConfig : Form
    {
        public VASConfig()
        {
            InitializeComponent();
            Size = new Size(380, 240);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPinRemove.Checked)
                buttonClearDatabase.Enabled = true;
            else buttonClearDatabase.Enabled = false;
        }
        public void restore()
        {
            checkBoxRestore.Checked = false;
            checkBoxRucni.Checked = false;
            checkBoxPinRemove.Checked = false;
        }
        private void checkBoxRucni_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRucni.Checked)
            {
                #region checkBoxRucni checked
                Size = new Size(580, 609); //zmena velikosti, aby bylo vse videt
                /*
                ***********************
                *     RADIO BUTTON    *
                ***********************
                ----ENABLE----*/
                radioButtonHZ.Enabled = false;
                radioButtonTV.Enabled = false;
                radioButtonKV.Enabled = false;
                radioButtonVR.Enabled = false;
                //----CHECK----
                radioButtonHZ.Checked = false;
                radioButtonTV.Checked = false;
                radioButtonKV.Checked = false;
                radioButtonVR.Checked = false;
                /*
                *************************
                *   RADIO BUTTON LABEL  *
                *************************/
                labelHZ.ForeColor = Color.Gray;
                labelKV.ForeColor = Color.Gray;
                labelTV.ForeColor = Color.Gray;
                labelVR.ForeColor = Color.Gray;
                /*
                ***********************
                *       TEXT BOX      *
                ***********************/
                //Schovani text boxu
                textBoxCert.Visible = true;
                textBoxConf.Visible = true;
                textBoxFirm.Visible = true;
                textBoxTab.Visible = true;
                textBoxFirmwareVersion.Visible = true;
                /*
                ***********************
                *        BUTTON       *
                ***********************/
                buttonSaveConfig.Visible = true;
                buttonHelp.Visible = true;
                buttonRestore.Visible = true;
                /*
                ***********************
                *   LABEL TEXT BOX    *
                ***********************/
                labelCer.Visible = true;
                labelTab.Visible = true;
                labelFirm.Visible = true;
                labelConf.Visible = true;
                labelFirmVer.Visible = true;
                labelRestore.Visible = true;
                labelRestore2.Visible = true;
                /*
                *************************
                *       CHECK BOX       *
                *************************/
                checkBoxRestore.Visible = true;
                //Nastaveni aktualich cest, ktere vycteme ze souboru ▼ ▼
                try
                {
                    using (StreamReader sr = new StreamReader(@"C:\ProgramData\TechnolToolkit\VAS6154\vas.properties", Encoding.GetEncoding(28592)))
                    {
                        String obsahSouboru = sr.ReadToEnd();
                        Match ff = Regex.Match(obsahSouboru, @"(?<=firmware.file = ).*?(?=\s)");
                        Match fv = Regex.Match(obsahSouboru, @"(?<=firmware.version = ).*?(?=\s)");
                        Match cer = Regex.Match(obsahSouboru, @"(?<=certifikaty.path = ).*?(?=\s)");
                        Match tab = Regex.Match(obsahSouboru, @"(?<=tabulky.path = ).*?(?=\s)");
                        Match conf = Regex.Match(obsahSouboru, @"(?<=konfigurace.path = ).*?(?=\s)");
                        if (ff.Success)
                        {
                            string firmFile = ff.Groups[0].ToString().Trim();
                            textBoxFirm.Text = firmFile;
                        }
                        if (fv.Success)
                        {
                            string firmVer = fv.Groups[0].ToString().Trim();
                            textBoxFirmwareVersion.Text = firmVer;
                        }
                        if (cer.Success)
                        {
                            string cert = cer.Groups[0].ToString().Trim();
                            textBoxCert.Text = cert;
                        }
                        if (tab.Success)
                        {
                            string tabulka = tab.Groups[0].ToString().Trim();
                            textBoxTab.Text = tabulka;
                        }
                        if (conf.Success)
                        {
                            string config = conf.Groups[0].ToString().Trim();
                            textBoxConf.Text = config;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Není možné číst ze souboru", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (canSave())
                    buttonRun.Enabled = true;
                else
                    buttonRun.Enabled = false;
                #endregion
            }
            else
            {
                #region checkBoxRucni !checked
                Size = new Size(380, 240);
                /*
                ***********************
                *     RADIO BUTTON    *
                ***********************
                ----ENABLE----*/
                radioButtonHZ.Enabled = true;
                radioButtonTV.Enabled = true;
                radioButtonKV.Enabled = true;
                radioButtonVR.Enabled = true;
                /*
                *************************
                *   RADIO BUTTON LABEL  *
                *************************/
                labelHZ.ForeColor = Color.Black;
                labelKV.ForeColor = Color.Black;
                labelTV.ForeColor = Color.Black;
                labelVR.ForeColor = Color.Black;
                /*
                *************************
                *        TEXT BOX       *
                *************************/
                textBoxCert.Visible = false;
                textBoxConf.Visible = false;
                textBoxFirm.Visible = false;
                textBoxTab.Visible = false;            
                textBoxFirmwareVersion.Visible = false;
                /*
                *************************
                *         BUTTON        *
                *************************/
                buttonSaveConfig.Visible = false;
                buttonHelp.Visible = false;
                buttonRestore.Visible = false;

                /*
                *************************
                *         LABEL         *
                *************************/
                labelCer.Visible = false;
                labelTab.Visible = false;
                labelFirm.Visible = false;
                labelConf.Visible = false;
                labelFirmVer.Visible = false;
                labelRestore.Visible = false;
                labelRestore2.Visible = false;
                /*
                *************************
                *       CHECK BOX       *
                *************************/
                checkBoxRestore.Visible = false;
                buttonRun.Enabled = false;
                #endregion
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (checkBoxRucni.Checked)
                checkBoxRucni.Checked = false;
            else checkBoxRucni.Checked = true;
        }
        string umisteni = string.Empty;
        private void editConfig()
        {
            if(checkBoxRucni.Checked)
            {
                string cer = textBoxCert.Text;
                string firm = textBoxFirm.Text;
                string firmV = textBoxFirmwareVersion.Text;
                string tab = textBoxTab.Text;
                string conf = textBoxConf.Text;
                // Write the string to a file.
                try
                {
                    File.Delete(@"C:\ProgramData\TechnolToolkit\VAS6154\vas.properties");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FileStream fs = new FileStream(@"C:\ProgramData\TechnolToolkit\VAS6154\vas.properties", FileMode.CreateNew);
                System.IO.StreamWriter file = new System.IO.StreamWriter(fs, Encoding.GetEncoding(28592));
                file.WriteLine("firmware.file = " + firm);
                file.WriteLine("firmware.version = " + firmV);
                file.WriteLine("");
                file.WriteLine("certifikaty.path = " + cer);
                file.WriteLine("tabulky.path = " + tab);
                file.WriteLine("konfigurace.path = " + conf);
                file.Close();
                fs.Close();
            } else
            {
                try
                {
                    File.Delete(@"C:\ProgramData\TechnolToolkit\VAS6154\vas.properties");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FileStream fs = new FileStream(@"C:\ProgramData\TechnolToolkit\VAS6154\vas.properties", FileMode.CreateNew);
                System.IO.StreamWriter file = new System.IO.StreamWriter(fs, Encoding.GetEncoding(28592));
                switch (umisteni)
                {
                    case "tv":
                        file.WriteLine("firmware.file = G:/F/FI/@FIO/FIO.1/VAS_6154/Firmware6154/VAS6154_6.1r00-6843-664-20151127");
                        file.WriteLine("firmware.version = 6.1r00-6843-664");
                        file.WriteLine("");
                        file.WriteLine("certifikaty.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Technický_vývoj");
                        file.WriteLine("tabulky.path = G:/F/FI/@FIO/FIO.1/Tech_PC/VAS6154");
                        file.WriteLine("konfigurace.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Technický_vývoj/ZALOHA");
                        break;
                    case "hz":
                        file.WriteLine("firmware.file = G:/F/FI/@FIO/FIO.1/VAS_6154/Firmware6154/VAS6154_6.1r00-6843-664-20151127");
                        file.WriteLine("firmware.version = 6.1r00-6843-664");
                        file.WriteLine("");
                        file.WriteLine("certifikaty.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Hlavní_závod");
                        file.WriteLine("tabulky.path = G:/F/FI/@FIO/FIO.1/Tech_PC/VAS6154");
                        file.WriteLine("konfigurace.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Hlavní_závod/ZALOHA");
                        break;
                    case "vr":
                        file.WriteLine("firmware.file = G:/F/FI/@FIO/FIO.1/VAS_6154/Firmware6154/VAS6154_6.1r00-6843-664-20151127");
                        file.WriteLine("firmware.version = 6.1r00-6843-664");
                        file.WriteLine("");
                        file.WriteLine("certifikaty.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Vrchlabí");
                        file.WriteLine("tabulky.path = G:/F/FI/@FIO/FIO.1/Tech_PC/VAS6154");
                        file.WriteLine("konfigurace.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Vrchlabí/ZALOHA");
                        break;
                    case "kv":
                        file.WriteLine("firmware.file = G:/F/FI/@FIO/FIO.1/VAS_6154/Firmware6154/VAS6154_6.1r00-6843-664-20151127");
                        file.WriteLine("firmware.version = 6.1r00-6843-664");
                        file.WriteLine("");
                        file.WriteLine("certifikaty.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Kvasiny");
                        file.WriteLine("tabulky.path = G:/F/FI/@FIO/FIO.1/Tech_PC/VAS6154");
                        file.WriteLine("konfigurace.path = G:/F/FI/@FIO/FIO.1/VAS_6154/Kvasiny/ZALOHA");
                        break;
                    default:
                        MessageBox.Show("Chyba při konfiguraci, zkuste ruční nastavení!", "Chyba",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                }
                file.Close();
                fs.Close();
            }
        }
        
        private bool canSave()
        {
            if (textBoxCert.Text == "" || textBoxConf.Text == "" || textBoxFirm.Text == "" || textBoxFirmwareVersion.Text == "" || textBoxTab.Text == "")
                return false;
            else
                return true;
        }

        private void checkBoxRestore_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRestore.Checked)
                buttonRestore.Enabled = true;
            else buttonRestore.Enabled = false;
        }
        private void buttonRestore_Click(object sender, EventArgs e)
        {
            var slozka = @"C:\ProgramData\TechnolToolkit\VAS6154";
            try
            {
                if (Directory.Exists(slozka))
                    Directory.Delete(slozka, true);
                else MessageBox.Show("Složka byla již odstraněna! Zpusťte VAS konfigurátor znovu pro obnovení!", "Chyba", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            UserControlAdmin uAc = new UserControlAdmin();
            uAc.extractVAS();
            checkBoxRestore.Checked = false;
            checkBoxRucni.Checked = false;
            checkBoxRucni.Checked = true;
            
        }

        private void buttonClearDatabase_Click(object sender, EventArgs e)
        {
            foreach (string directories in Directory.GetDirectories(@"C:\ProgramData\TechnolToolkit\VAS6154\ocr"))
            {
                foreach (var file in Directory.GetFiles(directories))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Chyba při mazání databáze... Zkuste obnovit program",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
            MessageBox.Show("Hotovo!");
            checkBoxPinRemove.Checked = false;
        }

        private void textBoxTab_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTab.Text == "")
                labelTab.ForeColor = Color.Red;
            else labelTab.ForeColor = Color.Black;
            if (canSave() == true)
            {
                buttonSaveConfig.Enabled = true;
                buttonRun.Enabled = true;
            }
            else
            {
                buttonSaveConfig.Enabled = false;
                buttonRun.Enabled = false;
            }
        }

        private void textBoxConf_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConf.Text == "")
                labelConf.ForeColor = Color.Red;
            else labelConf.ForeColor = Color.Black;
            if (canSave() == true)
            {
                buttonSaveConfig.Enabled = true;
                buttonRun.Enabled = true;
            }
            else
            {
                buttonSaveConfig.Enabled = false;
                buttonRun.Enabled = false;
            }
        }

        private void textBoxFirm_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFirm.Text == "")
                labelFirm.ForeColor = Color.Red;
            else labelFirm.ForeColor = Color.Black;
            if (canSave() == true)
            {
                buttonSaveConfig.Enabled = true;
                buttonRun.Enabled = true;
            }
            else
            {
                buttonSaveConfig.Enabled = false;
                buttonRun.Enabled = false;
            }
        }
        private void textBoxCert_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCert.Text == "")
                labelCer.ForeColor = Color.Red;
            else labelCer.ForeColor = Color.Black;
            if (canSave() == true)
            {
                buttonSaveConfig.Enabled = true;
                buttonRun.Enabled = true;
            }
            else
            {
                buttonSaveConfig.Enabled = false;
                buttonRun.Enabled = false;
            }
        }

        private void textBoxFirmwareVersion_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFirmwareVersion.Text == "")
                labelFirmVer.ForeColor = Color.Red;
            else labelFirmVer.ForeColor = Color.Black;
            if (canSave() == true)
            {
                buttonSaveConfig.Enabled = true;
                buttonRun.Enabled = true;
            }
            else
            {
                buttonSaveConfig.Enabled = false;
                buttonRun.Enabled = false;
            }
        }
        
        private void radioButtonKV_Paint(object sender, PaintEventArgs e)
        {
            if(radioButtonKV.Enabled)
            {
                base.OnPaint(e);
                return;
            }
            using (Brush aBrush = new SolidBrush(Color.DarkGray))
            {
                e.Graphics.DrawString(radioButtonKV.Text, Font, aBrush, ClientRectangle);
            }
        }

        private void labelTV_Click(object sender, EventArgs e)
        {
            if (checkBoxRucni.Checked)
                return;
            else radioButtonTV.Checked = true;
        }

        private void labelHZ_Click(object sender, EventArgs e)
        {
            if (checkBoxRucni.Checked)
                return;
            else radioButtonHZ.Checked = true;
        }

        private void labelKV_Click(object sender, EventArgs e)
        {
            if (checkBoxRucni.Checked)
                return;
            else radioButtonKV.Checked = true;
        }

        private void labelVR_Click(object sender, EventArgs e)
        {
            if (checkBoxRucni.Checked)
                return;
            else radioButtonVR.Checked = true;
        }
        
        private void buttonRun_Click(object sender, EventArgs e)
        {
            buttonRun.Enabled = false;
            editConfig();
            Process p = new Process();
            p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\VAS6154\start.bat";
            p.Start();
            p.WaitForExit();
            if (p.HasExited)
                buttonRun.Enabled = true;
        }

        private void radioButtonTV_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTV.Checked)
            {
                umisteni = "tv";
                editConfig();
                buttonRun.Enabled = true;
            }
            else
            {
                buttonRun.Enabled = false;
            }
        }

        private void radioButtonHZ_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHZ.Checked)
            {
                umisteni = "hz";
                editConfig();
                buttonRun.Enabled = true;
            }
            else
            {
                buttonRun.Enabled = false;
            }
        }

        private void radioButtonKV_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKV.Checked)
            {
                umisteni = "kv";
                editConfig();
                buttonRun.Enabled = true;
            }
            else
            {
                buttonRun.Enabled = false;
            }
        }

        private void radioButtonVR_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonVR.Checked)
            {
                umisteni = "vr";
                editConfig();
                buttonRun.Enabled = true;
            }
            else
            {
                buttonRun.Enabled = false;
            }
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            if (canSave())
            {
                editConfig();
                MessageBox.Show("Konfigurace uložena!", "Uloženo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Nebylo možné uložit konfiguraci.\nMáte vyplněné všechny kolonky v sekci Ruční nastavení?", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void buttonClearDatabase_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonClearDatabase.Enabled)
                buttonClearDatabase.ForeColor = Color.Red;
            else buttonClearDatabase.ForeColor = Color.DimGray;
        }

        private void buttonRestore_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonRestore.Enabled)
                buttonRestore.ForeColor = Color.Red;
            else buttonRestore.ForeColor = Color.DimGray;
        }
    }
}
