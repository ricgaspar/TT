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
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;

namespace TechnolToolkit
{
    public partial class UserControlAddToGroup : UserControl
    {
        public UserControlAddToGroup()
        {
            InitializeComponent();
            radioButtonHierarchy.Checked = true;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd'.'MM.yyyy - HH':'mm";
        }

        GroupsAndMember groups_and_members = new GroupsAndMember();
        public string selectedUserToRemove;
        public string selectedGroupToRemove;

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
        
        private void updateGroupsAndMembers()
        {
            if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název PC")
            {
                statusBox sb = new statusBox();
                sb.Show();

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    var groupsAndMembersData = groups_and_members.getGroupsAndMembers(textBoxComputername.Text);
                    Invoke(new Action(() =>
                    {
                        showGroupsAndMembers(groupsAndMembersData);
                        sb.Close();
                    }));
                }).Start();
            }
        }

        private void showGroupsAndMembers(Dictionary<String, List<String>> data )
        {
            treeViewGroups.Nodes.Clear();
            comboBox1.Items.Clear();

            foreach (KeyValuePair<String, List<String>> entry in data)
            {
                            
                comboBox1.Items.Add(entry.Key);
                TreeNode groupNode = treeViewGroups.Nodes.Add(entry.Key);

                foreach (String member in entry.Value) {
                    groupNode.Nodes.Add(member);
                }
            }
            enableUIElements();
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

        private void textBoxComputername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateGroupsAndMembers();
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
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            checkBoxNeomezene.Checked = false;
            radioButtonOdebraniLokalni.Checked = false;
            radioButtonOdebraniSitove.Checked = false;
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
                buttonGraphicalVisualization.Visible = false;
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2Collapsed = false;
                buttonGraphicalVisualization.Visible = true;
            }
        }

        private void saveDataToFile()
        {
            /*
                TODO LIST:
                Naplnovat databazi nastavenych opravneni obsahem z logu
                Udelat overovani toho, ze button na nastaveni bude enabled, misto toho, ze to bude vyhazovat hlasku... PRoste kdyz vse bude spravne vyplnene, tak to "enabluje" button
                Dodelat funkcnost contextMenuStripu v hierarchii zobrazeni skupin
                Pri kliknuti na pripojit, vyskoci okno s nacitanim jako je to u "installed programs"
                Zlepsit GUI - lepe rozvrhnout prvky (status, jestli jsme pripojeni nejak zakomponovat do texboxu nebo to nejak hezky indikovat) pripadne zmenit celkove GUI
                Pridat moznost nastavit do texboxUsername prihlaseneho uzivatele...
                Kontrola, zda-li nebylo zadano minule datum, pri casove omezenem pridavani opravneni
                Pridat moznost zobrazeni zpravy na remote pc, ze admin byl pridany a ze se maji odlasit a prihlasit.. (viz. message v ucA) Casove omezena zprava bych to dal... Zadna moznost permanentniho zobrazeni, max treba hodina..
                Zmensit/premistit/zlepsit "Pripojit" button
                Po kliknuti na button "nastavit opravneni" se prepne splitContainer na databazi nastavenych opravneni, misto hierarchie.
                Po kliknuti na button "pripojit" nebo po pripojeni k pc se prepne splitContainer na hierarchii lokalnich skupin, misto databaze
            */
            string addToGroupLog = @"C:\ProgramData\TechnolToolkit\Logs\addToGroup.txt";
            string logDir = @"C:\ProgramData\TechnolToolkit\Logs";
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
            else
                if (!File.Exists(addToGroupLog))
                    File.Create(addToGroupLog);
            using (StreamWriter sw = new StreamWriter(addToGroupLog, true))
            {

                if (checkBoxNeomezene.Checked)
                {
                    sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy - HH:mm") + ";" + textBoxUsername.Text.ToString() + ";" + textBoxComputername.Text.ToString() + ";neomezene;" + comboBox1.Text.ToString() + ";neodebira se");
                }
                else
                {
                    if (radioButtonOdebraniLokalni.Checked)
                    {
                        sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy - HH:mm") + ";" + textBoxUsername.Text.ToString() + ";" + textBoxComputername.Text.ToString() + ";" + dateTimePicker1.Value.ToString() + ";" + comboBox1.Text.ToString() + ";lokalni");
                    }
                    else
                    {
                        if (radioButtonOdebraniSitove.Checked)
                        {
                            sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy - HH:mm") + ";" + textBoxUsername.Text.ToString() + ";" + textBoxComputername.Text.ToString() + ";" + dateTimePicker1.Value.ToString() + ";" + comboBox1.Text.ToString() + ";sitove");
                        }
                        else
                        {
                            MessageBox.Show("Chyba v ukládaní dat do logu! Není vybrán ani jeden radio button a oprávnění není trvalé!");
                        }
                    }
                }
            }
        }
        private void smazatClenaZeSkupinyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedGroupToRemove = treeViewGroups.SelectedNode.Parent.Text;
            selectedUserToRemove = treeViewGroups.SelectedNode.Text;
            //Check if any node is selected
            if (treeViewGroups.SelectedNode != null)
            {
                //Fill List skupiny with all groups on remote machine for later use
                List<string> skupiny = new List<string>();
                for (int i = 0; i < comboBox1.Items.Count; i++)
                    skupiny.Add(comboBox1.GetItemText(comboBox1.Items[i]));

                //If selected node is group, we do not do anything, because we do not want to delete group. We want to delete member
                if (skupiny.Contains(treeViewGroups.SelectedNode.Text))
                    return;
                //Selected node is member, so we delete him
                else
                {
                    DialogResult confirmation = MessageBox.Show("Opravdu chcete odebrat " + selectedUserToRemove + " ze skupiny " + selectedGroupToRemove + "?","Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (confirmation == DialogResult.Yes)
                        try
                        {
                            //Removing selected user from opened group
                            using (PrincipalContext pc = new PrincipalContext(ContextType.Machine, textBoxComputername.Text))
                                using (GroupPrincipal localGroup = GroupPrincipal.FindByIdentity(pc, IdentityType.Name, selectedGroupToRemove))
                                    foreach (Principal groupUser in localGroup.GetMembers())
                                        if (groupUser.SamAccountName == selectedUserToRemove)
                                        {
                                            localGroup.Members.Remove(groupUser);
                                            localGroup.Save();
                                            updateGroupsAndMembers();
                                        }
                        }
                        catch (System.DirectoryServices.DirectoryServicesCOMException E)
                        {
                            MessageBox.Show(E.Message.ToString(),"Chyba!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                }
            }
            else return;
        
        }

        private void buttonConnectToDevice_Click(object sender, EventArgs e)
        {
            updateGroupsAndMembers();
        }

        private void buttonAddMemberToGroup_Click(object sender, EventArgs e)
        {
            if (activateLastButton() == true)
                addMemberToGroup(textBoxUsername.Text, textBoxComputername.Text, comboBox1.Text);
            else
                MessageBox.Show("Něco jsi zapomněl vyplnit. :(");
            saveDataToFile();
            updateGroupsAndMembers();
            
        }

        private void treeViewGroups_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                treeViewGroups.SelectedNode = e.Node;
        }

        private void radioButtonOdebraniSitove_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNeomezene.Checked)
            { 
                radioButtonOdebraniLokalni.Checked = false;
                radioButtonOdebraniSitove.Checked = false;
            }
        }

        private void radioButtonOdebraniLokalni_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNeomezene.Checked)
            {
                radioButtonOdebraniLokalni.Checked = false;
                radioButtonOdebraniSitove.Checked = false;
            }
        }
    }
}
