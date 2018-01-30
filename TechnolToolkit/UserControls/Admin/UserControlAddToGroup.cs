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
using Microsoft.Win32.TaskScheduler;


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
            textBoxComputername.BackColor = Color.FromArgb(255,102,102);
        }

        GroupsAndMember groups_and_members = new GroupsAndMember();
        public string selectedUserToRemove;
        public string selectedGroupToRemove;

        private void enableUIElements()
        {
            buttonSetCurrentUser.Enabled = true;
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
            try {
                using (var pcLocal = new PrincipalContext(ContextType.Machine, computername))
                {
                    var grp = GroupPrincipal.FindByIdentity(pcLocal, group);

                    using (var pcDomain = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
                    {
                        grp.Members.Add(pcDomain, IdentityType.SamAccountName, user);
                        grp.Save();

                        //Automaticke lokalni/sitove odebrani
                        if (radioButtonOdebraniLokalni.Checked)
                            try {
                                automatickaUloha(dateTimePicker1.Value, user, group, computername);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        else
                            if(radioButtonOdebraniSitove.Checked)
                                try
                                {
                                    //Funkce na automaticke sitove odebrani
                                    //          - zapis do databaze, ktera se da otevrit (vymyslet na to tlacitko nebo neco)
                                    //          - upozorneni na nemoznost odebrani
                                    //          - automaticke odebrani, jakmile je pc na siti
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }      

        private void textBoxComputername_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název PC" && textBoxComputername.Text != "localhost")
            {
                buttonConnectToDevice.Enabled = true;
                textBoxComputername.BackColor = Color.FromName("Window");
            }
            else
            {
                buttonConnectToDevice.Enabled = false;
                textBoxComputername.BackColor = Color.FromArgb(255, 102, 102);
            }
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
            addMemberToGroup(textBoxUsername.Text, textBoxComputername.Text, comboBox1.Text);
            saveDataToFile();
            updateGroupsAndMembers();
            checkBoxNeomezene.Checked = false;
            radioButtonOdebraniLokalni.Checked = false;
            radioButtonOdebraniSitove.Checked = false;
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
        private void automatickaUloha(DateTime datum_a_cas, string username, string skupina, string jmeno_pocitace)
        {
            // JESTE DODELAT TO, ZE SE SMAZE ULOHA ("UKLIZENI") PO TOM, KDY PROBEHNE

            // Get the service on the local machine
            using (TaskService ts = new TaskService(jmeno_pocitace))
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                //td.RegistrationInfo.Description = "Automatické odebrání uživatele ze skupiny";

                // Create a trigger that will fire the task at this time every other day
                td.Triggers.Add(new TimeTrigger(datum_a_cas));
                //spusteni co nejdriv po prekroceni casu, ktery jsme definovali, kdy bude task spusten.
                td.Settings.StartWhenAvailable = true;
                td.Settings.Hidden = true;
                //nastaveni maximalni doby behu - 10 minut
                td.Settings.ExecutionTimeLimit = TimeSpan.FromMinutes(10);
                td.Settings.DeleteExpiredTaskAfter = TimeSpan.FromSeconds(10);
                td.Settings.DisallowStartIfOnBatteries = false;

                // Create an action that will launch cmd.exe to remove user from group
                string parametr = "/c net localgroup " + skupina + " /delete " + username;
                td.Actions.Add(new ExecAction("cmd.exe",parametr, null));

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
                textBoxUsername.Text != "Uživatel (DZC)" && comboBox1.Text != "Výběr skupiny")
                if (checkBoxNeomezene.Checked)
                    buttonAddMemberToGroup.Enabled = true;
                else
                    if (radioButtonOdebraniLokalni.Checked == true && dateTimePicker1.Value.Date >= DateTime.Today || 
                    radioButtonOdebraniSitove.Checked == true && dateTimePicker1.Value.Date >= DateTime.Today)
                        buttonAddMemberToGroup.Enabled = true;
                    else
                        buttonAddMemberToGroup.Enabled = false;
            else
                buttonAddMemberToGroup.Enabled = false;

        }
    }
}
