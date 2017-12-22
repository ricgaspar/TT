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

namespace TechnolToolkit
{
    public partial class UserControlAddToGroup : UserControl
    {
        string connectedToComputerName = "";
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
            labelConnectedTo.Text = "Připojeno k: " + connectedToComputerName;
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
                    connectedToComputerName = textBoxComputername.Text;
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
            
                Lepsim zpusobem vyresit zapisovani do souboru...
                    Ted to vzdy zapise pouze jeden zaznam a vse ostatni smaze
                    Zapisuje blbe skupiny z combobox
                Udelat overovani toho, ze button na nastaveni bude enabled, misto toho, ze to bude vyhazovat hlasku... PRoste kdyz vse bude spravne vyplnene, tak to "enabluje" button
                Dodelat funkcnost contextMenuStripu v hierarchii zobrazeni skupin
                Predelat texboxy.. at to je uppercase a pripadne lowercase.. jak to bylo puvodne...
                Pri kliknuti na pripojit, vyskoci okno s nacitanim jako je to u "installed programs"
                Zlepsit GUI - lepe rozvrhnout prvky (status, jestli jsme pripojeni nejak zakomponovat do texboxu nebo to nejak hezky indikovat) pripadne zmenit celkove GUI
                Pridat moznost nastavit do texboxUsername prihlaseneho uzivatele...
                Kontrola, zda-li nebylo zadano minule datum, pri casove omezenem pridavani opravneni
                Pridat moznost zobrazeni zpravy na remote pc, ze admin byl pridany a ze se maji odlasit a prihlasit.. (viz. message v ucA) Casove omezena zprava bych to dal... Zadna moznost permanentniho zobrazeni
                Zmensit/premistit/zlepsit "Pripojit" button
                Po kliknuti na button "nastavit opravneni" se prepne splitContainer na databazi nastavenych opravneni, misto hierarchie.
                Po kliknuti na button "pripojit" nebo po pripojeni k pc se prepne splitContainer na hierarchii lokalnich skupin, misto databaze
            */


            string path = @"C:\ProgramData\TechnolToolkit\Data\Admins.txt";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(@"C:\ProgramData\TechnolToolkit\Data");

            try
            {
                using (FileStream adminsLogFile = new FileStream(path, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(adminsLogFile))
                {
                    //cas neomezeny
                    if (checkBoxNeomezene.Checked)
                        //lokalni odebrani
                        if (radioButtonOdebraniLokalni.Checked)
                            sw.WriteLine(textBoxUsername.Text + ";" + textBoxComputername.Text + ";" + "neomezene;" + comboBox1.SelectedText.ToString() + ";neodebira se");
                        //remote odebrani
                        if (radioButtonOdebraniSitove.Checked)
                            sw.WriteLine(textBoxUsername.Text + ";" + textBoxComputername.Text + ";" + "neomezene;" + comboBox1.SelectedText.ToString() + ";neodebira se");
                    //cas omezeny
                    else
                        //lokalni odebrani
                        if (radioButtonOdebraniLokalni.Checked)
                            sw.WriteLine(textBoxUsername.Text + ";" + textBoxComputername.Text + ";" + dateTimePicker1.Value.ToString() + ";" + comboBox1.SelectedText.ToString() + ";local");
                        //remote odebrani
                        if (radioButtonOdebraniSitove.Checked)
                            sw.WriteLine(textBoxUsername.Text + ";" + textBoxComputername.Text + ";" + dateTimePicker1.Value.ToString() + ";" + comboBox1.SelectedText.ToString() + ";remote");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        private void smazatClenaZeSkupinyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Check if any node is selected
            if (treeViewGroups.SelectedNode != null)
            {
                //Fill List skupiny with all groups on remote machine for later use
                List<string> skupiny = new List<string>();
                for (int i = 0; i < comboBox1.Items.Count; i++)
                    skupiny.Add(comboBox1.GetItemText(comboBox1.Items[i]));

                //If selected note is group, we do not do anything, because we do not want to delete group. We want to delete member
                if (skupiny.Contains(treeViewGroups.SelectedNode.Text))
                    return;
                //Selected note is member, so we delete him
                else
                {
                    try
                    {
                        using (var pcLocal = new PrincipalContext(ContextType.Machine, textBoxComputername.Text))
                        {
                            var grp = GroupPrincipal.FindByIdentity(pcLocal, comboBox1.Text.ToString());

                            using (var pcDomain = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
                            {
                                string username = treeViewGroups.SelectedNode.Text;
                                DialogResult res = MessageBox.Show("Opravdu chcete smazat " + username + " ze skupiny " + treeViewGroups.SelectedNode.Parent.Text + "?", "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                                if (res == DialogResult.Yes)
                                {
                                    //Zprovoznit odebirani clenu
                                    //grp.Members.Remove(pcDomain, IdentityType.SamAccountName, username);
                                    //grp.Members.Remove();
                                    grp.Save();

                                    searchGroupsAndMembers(textBoxComputername.Text);
                                } else
                                {
                                    MessageBox.Show("Operace přerušena!");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
                return;
        }

        private void buttonConnectToDevice_Click(object sender, EventArgs e)
        {
            if (textBoxComputername.Text != "" && textBoxComputername.Text != "Název PC")
            {
                searchGroupsAndMembers(textBoxComputername.Text.ToString());
            }
        }

        private void buttonAddMemberToGroup_Click(object sender, EventArgs e)
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
            saveDataToFile();
        }
    }
}
