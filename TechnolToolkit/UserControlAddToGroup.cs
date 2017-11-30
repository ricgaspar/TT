using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;

namespace TechnolToolkit
{
    public partial class UserControlAddToGroup : UserControl
    {
        UserControlAddToGroupChild_Add ucAdd = new UserControlAddToGroupChild_Add();
        UserControlAddToGroupChild_Remove ucRem = new UserControlAddToGroupChild_Remove();
        public UserControlAddToGroup()
        {
            InitializeComponent();

            //Defaultni nastaveni panelu
            panel1.Controls.Clear();
            panel1.Controls.Add(ucAdd);
            ucAdd.Size = panel1.Size;
        }

        private void radioButtonUCAdd_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonUCAdd.Checked == true)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(ucAdd);
                ucAdd.Size = panel1.Size;
            }
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(ucRem);
                ucRem.Size = panel1.Size;
            }
        }
    }
}
