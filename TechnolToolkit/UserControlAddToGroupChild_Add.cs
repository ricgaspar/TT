using System;
using System.Drawing;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Collections.Generic;

namespace TechnolToolkit
{
    public partial class UserControlAddToGroupChild_Add : UserControl
    {
        public UserControlAddToGroupChild_Add()
        {
            InitializeComponent();
        }
        private void vyhledaniSkupin(string computername)
        {
            comboBoxGroups.Items.Clear();
            DirectoryEntry machine = new DirectoryEntry("WinNT://" + computername + ",Computer");
            foreach (DirectoryEntry child in machine.Children)
            {
                if (child.SchemaClassName == "Group")
                {

                    comboBoxGroups.Items.Add(child.Name);
                }
            }
        }
        private void checkBoxNeomezene_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxNeomezene.Checked)
            {
                dateTimePicker1.Enabled = false;
                radioButtonOdebraniAutomat.Enabled = false;
                radioButtonOdebraniAutomat.Checked = false;
                radioButtonOdebraniForce.Enabled = false;
                radioButtonOdebraniForce.Checked = false;
            } else
            {
                dateTimePicker1.Enabled = true;
                radioButtonOdebraniAutomat.Enabled = true;
                radioButtonOdebraniForce.Enabled = true;
            }
        }

        private void textBoxComputername_Click(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "NÁZEV PC")
            {
                textBoxComputername.Text = "";
                textBoxComputername.ForeColor = Color.Black;
            }
            
        }

        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "UŽIVATELSKÉ JMÉNO")
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        
        }

        private void textBoxComputername_Leave(object sender, EventArgs e)
        {
            if(textBoxComputername.Text == "")
            {
                textBoxComputername.Text = "NÁZEV PC";
                textBoxComputername.ForeColor = Color.Gray;
            }
            if(textBoxComputername.Text != "" && textBoxComputername.Text != "NÁZEV PC")
            {
                vyhledaniSkupin(textBoxComputername.Text.ToString());
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if(textBoxUsername.Text == "")
            {
                textBoxUsername.Text = "UŽIVATELSKÉ JMÉNO";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

    }
}
