using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit.Resources
{
    public partial class SHA512_Generator : Form
    {
        public SHA512_Generator()
        {
            InitializeComponent();
        }

        private string ToSHA512_HEX(string value, bool toHex)
        {
            SHA512 sha512 = SHA512.Create();
            byte[] hashData = sha512.ComputeHash(Encoding.UTF8.GetBytes(value));
            StringBuilder returnValue = new StringBuilder(hashData.Length * 2);
            if (toHex)
                foreach (byte b in hashData)
                    returnValue.AppendFormat("{0:x2}", b);
            else
                foreach (byte b in hashData)
                    returnValue.Append(b);
            return returnValue.ToString();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (checkBoxHEX.Checked)
                textBoxHash.Text = ToSHA512_HEX(textBoxText.Text, true);
            else textBoxHash.Text = ToSHA512_HEX(textBoxText.Text, false);
        }
        /*
        Deleted feature because licenses were removed from this project :)
        private void buttonTT_Click(object sender, EventArgs e)
        {
            checkBoxHEX.Checked = true;
            textBoxText.Text = Environment.UserName + ";" + Environment.MachineName;
            textBoxHash.Text = ToSHA512_HEX(textBoxText.Text, true);
            MessageBox.Show("Vložte vygenerovaný hash do souboru \"C:\\ProgramData\\TechnolToolkit\\License.dat\"\nNa každý řádek jeden klíč!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        */
        private void SHA512_Generator_Shown(object sender, EventArgs e)
        {
            textBoxHash.Text = "";
            textBoxText.Text = "";
            checkBoxHEX.Checked = false;
        }
    }
}
