using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class VASConfig : Form
    {
        public VASConfig()
        {
            InitializeComponent();
            Size = new Size(380, 305);
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
                Size = new Size(580, 524);
                radioButtonHZ.Enabled = false;
                radioButtonHZ.Checked = false;
                radioButtonKV.Enabled = false;
                radioButtonKV.Checked = false;
                radioButtonTV.Enabled = false;
                radioButtonTV.Checked = false;
                radioButtonVR.Enabled = false;
                radioButtonVR.Checked = false;
                //-----------
                textBoxCert.Visible = true;
                textBoxConf.Visible = true;
                textBoxFirm.Visible = true;
                textBoxTab.Visible = true;
                textBoxFirmwareVersion.Visible = true;
                buttonUlozit.Visible = true;
                buttonHelp.Visible = true;
                labelCer.Visible = true;
                labelTab.Visible = true;
                labelFirm.Visible = true;
                labelConf.Visible = true;
                labelFirmVer.Visible = true;
                labelRestore.Visible = true;
                labelRestore2.Visible = true;
                buttonRestore.Visible = true;
                checkBoxRestore.Visible = true;
            }
            else
            {
                Size = new Size(380, 305);
                radioButtonHZ.Enabled = true;
                radioButtonKV.Enabled = true;
                radioButtonTV.Enabled = true;
                radioButtonVR.Enabled = true;
                //----------
                textBoxCert.Visible = false;
                textBoxConf.Visible = false;
                textBoxFirm.Visible = false;
                textBoxTab.Visible = false;
                textBoxFirmwareVersion.Visible = false;
                buttonUlozit.Visible = false;
                textBoxFirmwareVersion.Text = "Firmware verze";
                buttonHelp.Visible = false;
                labelCer.Visible = false;
                labelTab.Visible = false;
                labelFirm.Visible = false;
                labelConf.Visible = false;
                labelFirmVer.Visible = false;
                labelRestore.Visible = false;
                labelRestore2.Visible = false;
                buttonRestore.Visible = false;
                checkBoxRestore.Visible = false;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (checkBoxRucni.Checked)
                checkBoxRucni.Checked = false;
            else checkBoxRucni.Checked = true;
        }

        private void textBoxCert_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCert.Text == "Certifikáty cesta")
                textBoxCert.Text = "";
        }

        private void buttonUlozit_Click(object sender, EventArgs e)
        {

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
        }
    }
}
