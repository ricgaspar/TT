using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Threading;
using Microsoft.Win32.TaskScheduler;
using Microsoft.Win32;
using TechnolToolkit.CustomControls_and_Clases;

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
        public Color themeColor = Color.FromArgb(174, 0, 0);

        private void enableUIElements()
        {
            buttonSetCurrentUser.Enabled = true;
            textBoxUsername.Enabled = true;
            treeViewGroups.Enabled = true;
            radioButtonAutomatickeOdebrani.Enabled = true;
            radioButtonNeomezenaPlatnost.Enabled = true;
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
                    Invoke(new System.Action(() =>
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

        private void textBoxComputername_Click(object sender, EventArgs e)
        {            
            if (textBoxComputername.Text == "Název PC")
                textBoxComputername.Text = "";
        }

        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Uživatel (DZC)")
                textBoxUsername.Text = "";
        }

        private void textBoxComputername_Leave(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "")
                textBoxComputername.Text = "Název PC";
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
                textBoxUsername.Text = "Uživatel (DZC)";
        }

        private void textBoxComputername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateGroupsAndMembers();
            }
        }

        private void addMemberToGroup(string user, string computername, string group)
        {

            try
            {
                using (var pcRemote = new PrincipalContext(ContextType.Machine, computername))
                {
                    var grp = GroupPrincipal.FindByIdentity(pcRemote, group);

                    using (var pcDomain = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
                    {
                        try
                        {
                            //Automaticke odebrani
                            if (radioButtonAutomatickeOdebrani.Checked)
                            {
                                grp.Members.Add(pcDomain, IdentityType.SamAccountName, user);
                                automatickaUloha(dateTimePicker1.Value, user, group, computername);
                                saveDataToFile();
                                grp.Save();
                            }
                            else
                            {
                                grp.Members.Add(pcDomain, IdentityType.SamAccountName, user);
                                saveDataToFile();
                                grp.Save();
                            }
                            updateGroupsAndMembers();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message.ToString() + "\nOprávnění nebylo přidáno!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }      

        private void textBoxComputername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název PC" && textBoxComputername.Text != "localhost")
            {
                buttonConnectToDevice.Enabled = true;
                buttonPing.Enabled = true;
                checkInputDataCompletion();
            }
            else
            {
                buttonConnectToDevice.Enabled = false;
                buttonPing.Enabled = false;
            }
        }

        private void radioButtonHierarchy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHierarchy.Checked)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel2Collapsed = false;
                fillLoggedDatatoListView();
                listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void saveDataToFile()
        {
            string addToGroupLog = @"C:\ProgramData\TechnolToolkit\Logs\addToGroup.txt";
            string logDir = @"C:\ProgramData\TechnolToolkit\Logs";
                if (!Directory.Exists(logDir))
                    Directory.CreateDirectory(logDir);

            using (StreamWriter sw = new StreamWriter(addToGroupLog, true))
            {

                if (radioButtonNeomezenaPlatnost.Checked)
                {
                    sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + ";" + textBoxUsername.Text.ToString() + ";" + textBoxComputername.Text.ToString() + ";neomezene;" + comboBox1.Text.ToString() + ";neodebira se");
                }
                else
                {
                    if (radioButtonAutomatickeOdebrani.Checked)
                    {
                        sw.WriteLine(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + ";" + textBoxUsername.Text.ToString() + ";" + textBoxComputername.Text.ToString() + ";" + dateTimePicker1.Value.ToString("dd.MM.yyyy HH:mm") + ";" + comboBox1.Text.ToString() + ";ano");
                    }
                    else
                    {
                        MessageBox.Show("Chyba v ukládaní dat do logu! Není vybrán ani jeden radio button a oprávnění není trvalé!");
                    }
                }
            }
        }
        private void smazatClenaZeSkupinyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceManipulation.runOrStopService("RemoteRegistry", textBoxComputername.Text, ServiceManipulation.serviceAction.run);
            registryFix(textBoxComputername.Text);

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
                    selectedGroupToRemove = treeViewGroups.SelectedNode.Parent.Text;
                    selectedUserToRemove = treeViewGroups.SelectedNode.Text;
                    DialogResult confirmation = MessageBox.Show("Opravdu chcete odebrat " + selectedUserToRemove + " ze skupiny " + selectedGroupToRemove + "?", "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                            MessageBox.Show(E.Message.ToString(), "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
            else return;

            ServiceManipulation.runOrStopService("RemoteRegistry", textBoxComputername.Text, ServiceManipulation.serviceAction.stop);
        }

        private void buttonConnectToDevice_Click(object sender, EventArgs e)
        {
            updateGroupsAndMembers();
        }

        private void buttonAddMemberToGroup_Click(object sender, EventArgs e)
        {
            ServiceManipulation.runOrStopService("RemoteRegistry", textBoxComputername.Text, ServiceManipulation.serviceAction.run);
            registryFix(textBoxComputername.Text);
            addMemberToGroup(textBoxUsername.Text, textBoxComputername.Text, comboBox1.Text);
            ServiceManipulation.runOrStopService("RemoteRegistry", textBoxComputername.Text, ServiceManipulation.serviceAction.stop);
            radioButtonAutomatickeOdebrani.Checked = false;
            radioButtonNeomezenaPlatnost.Checked = false;
        }

        private void treeViewGroups_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                treeViewGroups.SelectedNode = e.Node;
        }

        private void automatickaUloha(DateTime datum_a_cas, string username, string skupina, string jmeno_pocitace)
        {
            // Get the service on the local machine
            using (TaskService ts = new TaskService(jmeno_pocitace))
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                //td.RegistrationInfo.Description = "Automatické odebrání uživatele ze skupiny";
                TimeTrigger tt = new TimeTrigger(datum_a_cas);
                tt.EndBoundary = datum_a_cas + TimeSpan.FromMinutes(3);
                td.Settings.StartWhenAvailable = true;
                td.Settings.Hidden = true;
                td.Settings.AllowDemandStart = false;
                td.Settings.DisallowStartOnRemoteAppSession = false;
                td.Settings.Priority = System.Diagnostics.ProcessPriorityClass.AboveNormal;
                td.Settings.ExecutionTimeLimit = TimeSpan.FromMinutes(2);
                td.Settings.DeleteExpiredTaskAfter = TimeSpan.FromMinutes(0);
                td.Settings.DisallowStartIfOnBatteries = false;

                // Create an action that will launch cmd.exe to remove user from group
                string parametr = "/c net localgroup " + skupina + " /delete " + username;
                td.Actions.Add(new ExecAction("cmd.exe",parametr, null));

                td.Triggers.Add(tt);
                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"Automatic Membership Validation", td,TaskCreation.CreateOrUpdate,"SYSTEM",null,TaskLogonType.ServiceAccount);

                // Remove the task we just created
                //ts.RootFolder.DeleteTask("Test");
            }
        }

        private void buttonSetCurrentUser_Click(object sender, EventArgs e)
        {
            textBoxUsername.Text = Environment.UserName;
        }
        private void checkInputDataCompletion()
        {
            if (textBoxComputername.Text != "" && textBoxUsername.Text != "" && textBoxComputername.Text != "Název PC" && textBoxComputername.Text != "localhost" &&
                textBoxUsername.Text != "Uživatel (DZC)" && comboBox1.SelectedText != null)
                if (radioButtonNeomezenaPlatnost.Checked)
                    buttonAddMemberToGroup.Enabled = true;
                else
                    if (radioButtonAutomatickeOdebrani.Checked == true && dateTimePicker1.Value.Date >= DateTime.Today)
                        buttonAddMemberToGroup.Enabled = true;
                    else
                        buttonAddMemberToGroup.Enabled = false;
            else
                buttonAddMemberToGroup.Enabled = false;

        }

        private void radioButtonAutomatickeOdebrani_CheckedChanged(object sender, EventArgs e)
        {
            checkInputDataCompletion();
        }

        private void radioButtonNeomezenaPlatnost_CheckedChanged(object sender, EventArgs e)
        {
            checkInputDataCompletion();
        }

        private void zobrazitUzivatelskeJmenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceManipulation.runOrStopService("RemoteRegistry", textBoxComputername.Text, ServiceManipulation.serviceAction.run);
            registryFix(textBoxComputername.Text);

            if (treeViewGroups.SelectedNode.Parent != null)
            {
                string selectedUser = treeViewGroups.SelectedNode.Text;
                string selectedGroup = treeViewGroups.SelectedNode.Parent.Text;
                try
                {
                    //Removing selected user from opened group
                    using (PrincipalContext pc = new PrincipalContext(ContextType.Machine, textBoxComputername.Text))
                    using (GroupPrincipal localGroup = GroupPrincipal.FindByIdentity(pc, IdentityType.Name, selectedGroup))
                        foreach (Principal groupUser in localGroup.GetMembers())
                            if (groupUser.SamAccountName == selectedUser)
                            {
                                MessageBox.Show(groupUser.Name, groupUser.SamAccountName, MessageBoxButtons.OK);
                            }
                }
                catch (System.DirectoryServices.DirectoryServicesCOMException E)
                {
                    MessageBox.Show(E.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ServiceManipulation.runOrStopService("RemoteRegistry", textBoxComputername.Text, ServiceManipulation.serviceAction.stop);
        }
        private void fillLoggedDatatoListView()
        {
            try {
                string addToGroupLog = @"C:\ProgramData\TechnolToolkit\Logs\addToGroup.txt";
                List<string> lines = new List<string>();
                using (StreamReader sr = new StreamReader(addToGroupLog, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                obnoveniListView();
                foreach (string s in lines)
                {
                    string[] t;
                    t = s.Split(';');
                    ListViewItem lvi = new ListViewItem(t[0]);
                    lvi.SubItems.Add(t[1]);
                    lvi.SubItems.Add(t[2]);
                    lvi.SubItems.Add(t[4]);
                    lvi.SubItems.Add(t[3]);
                    lvi.SubItems.Add(t[5]);
                    listView1.Items.Add(lvi);

                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            

        }
        private void obnoveniListView()
        {
            listView1.Clear();
            listView1.Columns.Add("Datum přidání");
            listView1.Columns.Add("Uživatel");
            listView1.Columns.Add("Počítač");
            listView1.Columns.Add("Skupina");
            listView1.Columns.Add("Platnost do");
            listView1.Columns.Add("Automatické odebrání",120);
            listView1.FullRowSelect = true;
        }
        
        private void tableLayoutPanelNazevPC_Paint(object sender, PaintEventArgs e)
        {            
            e.Graphics.DrawLine(new Pen(themeColor, 1), 3, 28, 235, 28);
        }

        private void tableLayoutPanelDZC_Paint(object sender, PaintEventArgs e)
        { 
            e.Graphics.DrawLine(new Pen(themeColor, 1), 3, 28, 235, 28);
        }

        private void buttonPing_Click(object sender, EventArgs e)
        {
            labelPingStatus.Text = "Ping na " + textBoxComputername.Text + " status: navazuji komunikaci";
            buttonPing.BackColor = Color.Orange;
            labelPingStatus.ForeColor = Color.Orange;
            using (Ping ping = new Ping())
            {
                try
                {
                    PingReply pingReply = ping.Send(textBoxComputername.Text, 2000);
                    if (pingReply.Status == IPStatus.Success)
                    {
                        labelPingStatus.Text = "Ping na "+ textBoxComputername.Text + " status: úspěch";
                        labelPingStatus.ForeColor = Color.ForestGreen;
                        buttonPing.BackColor = Color.ForestGreen;
                    } else
                    {
                        labelPingStatus.Text = "Ping na " + textBoxComputername.Text + " status: " + pingReply.Status.ToString();
                        buttonPing.BackColor = Color.Firebrick;
                        labelPingStatus.ForeColor = Color.Firebrick;
                    }
                } catch(Exception x)
                {
                    labelPingStatus.Text = "Ping na " + textBoxComputername.Text + " status: " + x.Message;
                    buttonPing.BackColor = Color.Firebrick;
                    labelPingStatus.ForeColor = Color.Firebrick;
                    return;
                }
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            checkInputDataCompletion();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkInputDataCompletion();
        }
        private void registryFix(string computer)
        {
            //RegisteredOwner
            var regOwn = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion").GetValue("RegisteredOwner");
            if (regOwn != null)
            {
                if (regOwn.ToString() != "SKODA AUTO a.s.")
                    RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", true).SetValue("RegisteredOwner", "SKODA AUTO a.s.", RegistryValueKind.String);
            }
            else
            {
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", true).CreateSubKey("RegisteredOwner");
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", true).SetValue("RegisteredOwner", "SKODA AUTO a.s.", RegistryValueKind.String);
            }

            //RegisteredOrganization
            var regOrg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion").GetValue("RegisteredOrganization");
            if (regOrg != null)
            {
                if (regOrg.ToString() != "SKODA AUTO a.s.")
                    RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", true).SetValue("RegisteredOrganization", "SKODA AUTO a.s.", RegistryValueKind.String);
            }
            else
            {
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", true).CreateSubKey("RegisteredOrganization");
                RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computer).OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", true).SetValue("RegisteredOrganization", "SKODA AUTO a.s.", RegistryValueKind.String);
            }
        }
    }
}
