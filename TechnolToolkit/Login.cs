using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBoxUSER_Click(object sender, EventArgs e)
        {
            textBoxUSER.Text = "";
            if(textBoxMD5.Text == "")
            {
                textBoxMD5.Text = "MD5 Hash";
            }
        }

        private void textBoxMD5_Click(object sender, EventArgs e)
        {
            textBoxMD5.Text = "";
            if(textBoxUSER.Text == "")
            {
                textBoxUSER.Text = "Uživatel";
            }
        }

    }
}
