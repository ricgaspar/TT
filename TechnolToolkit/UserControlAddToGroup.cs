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
using System.DirectoryServices.AccountManagement;
using System.IO;

namespace TechnolToolkit
{
    public partial class UserControlAddToGroup : UserControl
    {
        public UserControlAddToGroup()
        {
            InitializeComponent();
            radioButtonHierarchy.Checked = true;
        }
        private void enableUIElements()
        {
            textBoxUsername.Enabled = true;
            treeViewGroups.Enabled = true;
            radioButtonOdebraniLokalni.Enabled = true;
            radioButtonOdebraniSitove.Enabled = true;
            checkBoxNeomezene.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            labelConnectedTo.Text = "Připojeno k: " + textBoxComputername.Text;
            labelDateTimeConnected.Text = "Čas připojení: " + DateTime.Now.ToString();
        }
        private void searchGroupsAndMembers(string computername)
        {
            treeViewGroups.Nodes.Clear();
            comboBox1.Items.Clear();
            Ping ping = new Ping();
            try
            {
                //try if machine is online
                PingReply pingReply = ping.Send(computername);

                if (pingReply.Status == IPStatus.Success)
                {
                    int i = 0;

                    DirectoryEntry machine = new DirectoryEntry("WinNT://" + computername + ",Computer");

                    foreach (DirectoryEntry child in machine.Children)
                    {
                        if (child.SchemaClassName == "Group")
                        {
                            //adding groups to treeView
                            treeViewGroups.Nodes.Add(child.Name);
                            comboBox1.Items.Add(child.Name);
                            //Starting of code that adds members of groups above.
                            using (DirectoryEntry groupEntry = new DirectoryEntry("WinNT://" + computername + "/" + child.Name + ",group"))
                            {
                                foreach (object member in (IEnumerable)groupEntry.Invoke("Members"))
                                {
                                    using (DirectoryEntry memberEntry = new DirectoryEntry(member))
                                    {
                                        //Adding members of current group
                                        treeViewGroups.Nodes[i].Nodes.Add(memberEntry.Name);
                                    }
                                }
                            }
                            i++;
                        }
                    }
                    enableUIElements();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
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
            if (textBoxComputername.Text == "Název PC")
            {
                textBoxComputername.Text = "";
                textBoxComputername.ForeColor = Color.Black;
            }
            
        }

        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Uživatel (DZC)")
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxComputername_Leave(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "")
            {
                textBoxComputername.Text = "Název PC";
                textBoxComputername.ForeColor = Color.Gray;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                textBoxUsername.Text = "Uživatel (DZC)";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název PC")
            {
                searchGroupsAndMembers(textBoxComputername.Text.ToString());
            }
        }

        private void textBoxComputername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název PC")
                {
                    searchGroupsAndMembers(textBoxComputername.Text.ToString());
                }
            }
        }
        private bool activateLastButton()
        {
            if (textBoxComputername.Text != ""  && textBoxUsername.Text != "" && textBoxComputername.Text != "Název PC" && textBoxComputername.Text != "localhost" &&
                textBoxUsername.Text != "Uživatel (DZC)" && comboBox1.Text != "Výběr skupiny")
                if (checkBoxNeomezene.Checked)
                    return true;
                else
                    if (radioButtonOdebraniLokalni.Checked == true || radioButtonOdebraniSitove.Checked == true)
                        return true;
                    else
                        return false;
            else
                return false;
        }
        private void logData(string user, string computername, string group, DateTime dateTime)
        {

        }
        private void addMemberToGroup(string user, string computername, string group)
        {
            try {
                using (var pcLocal = new PrincipalContext(ContextType.Machine, computername))
                {
                    var grp = GroupPrincipal.FindByIdentity(pcLocal, group);

                    using (var pcDomain = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
                    {
                        grp.Members.Add(pcDomain, IdentityType.SamAccountName, user);
                        grp.Save();
                        searchGroupsAndMembers(textBoxComputername.Text);
                    }
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (activateLastButton() == true)
            {
                addMemberToGroup(textBoxUsername.Text, textBoxComputername.Text, comboBox1.Text);
                System.Media.SystemSounds.Beep.Play();

            } 
            else
            {
                MessageBox.Show("Něco jsi zapomněl vyplnit. :(");
            }
            
        }

        private void textBoxComputername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název PC" && textBoxComputername.Text != "localhost")
                buttonConnectToDevice.Enabled = true;
            else buttonConnectToDevice.Enabled = false;
        }

        private void radioButtonHierarchy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHierarchy.Checked)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
                buttonExportToCSV.Visible = false;
                buttonGraphicalVisualization.Visible = false;
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2Collapsed = false;
                buttonExportToCSV.Visible = true;
                buttonGraphicalVisualization.Visible = true;
            }
        }
    }
}
