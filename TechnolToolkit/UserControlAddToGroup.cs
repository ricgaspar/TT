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
using System.Collections;
using System.Net.NetworkInformation;

namespace TechnolToolkit
{
    public partial class UserControlAddToGroup : UserControl
    {
        public UserControlAddToGroup()
        {
            InitializeComponent();
        }
        private void vyhledaniSkupin_a_Uzivatelu(string computername)
        {
            int i = 0;
            treeViewGroups.Nodes.Clear();
            DirectoryEntry machine = new DirectoryEntry("WinNT://" + computername + ",Computer");
            
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(computername);
            if (pingReply.Status == IPStatus.Success)
            {
                foreach (DirectoryEntry child in machine.Children)
                {
                    if (child.SchemaClassName == "Group")
                    {
                        
                        treeViewGroups.Nodes.Add(child.Name);
                        using (DirectoryEntry groupEntry = new DirectoryEntry("WinNT://" + computername + "/"+child.Name+",group"))
                        {
                            foreach (object member in (IEnumerable)groupEntry.Invoke("Members"))
                            {
                                using (DirectoryEntry memberEntry = new DirectoryEntry(member))
                                {
                                    Console.WriteLine(child.Name +"["+i+"]: " + memberEntry.Name);
                                    treeViewGroups.Nodes[i].Nodes.Add(memberEntry.Name);
                                }
                            }
                        }
                        i++;
                    }
                }
            }     
        }
        private void checkBoxNeomezene_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNeomezene.Checked)
            {
                dateTimePicker1.Enabled = false;
                radioButtonOdebraniSitove.Enabled = false;
                radioButtonOdebraniSitove.Checked = false;
                radioButtonOdebraniLokalni.Enabled = false;
                radioButtonOdebraniLokalni.Checked = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                radioButtonOdebraniSitove.Enabled = true;
                radioButtonOdebraniLokalni.Enabled = true;
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

        private void textBoxComputername_Leave(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "")
            {
                textBoxComputername.Text = "NÁZEV PC";
                textBoxComputername.ForeColor = Color.Gray;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                textBoxUsername.Text = "UŽIVATELSKÉ JMÉNO";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBoxComputername.Text != "" && textBoxComputername.Text != "NÁZEV PC")
            {
                vyhledaniSkupin_a_Uzivatelu(textBoxComputername.Text.ToString());
                textBoxUsername.Enabled = true;
                treeViewGroups.Enabled = true;
                radioButtonOdebraniLokalni.Enabled = true;
                radioButtonOdebraniSitove.Enabled = true;
                checkBoxNeomezene.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
        }
    }
}
