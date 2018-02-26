using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class InstalledPrograms : Form
    {
       

        public Color themeColor = Color.FromArgb(174, 0, 0);

        private ListViewColumnSorter lvwColumnSorter;
        public InstalledPrograms()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = lvwColumnSorter;
            obnovListView();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

#warning Prepracovat funkce do co nejvice trid.. Napr vse pro kopirovani textu do jedne tridy, atd..

        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        public static string getEnding(string strSource, string strStart)
        {
            int Start, End;
            if (strSource.Contains(strStart))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.Length;
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        public static string getStarting(string strSource, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strEnd))
            {
                Start = 0;
                End = strSource.IndexOf(strEnd, 0);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        private void checkBoxLocalPC_CheckedChanged(object sender, EventArgs e)
        {
            textBoxComputername.Text = "";
            //Chceme lokalni pc?
            if (checkBoxLocalPC.Checked == true)
            {
                textBoxComputername.Enabled = false;
                buttonVyhledat.Enabled = true;

            }
            //Nechceme
            else
            {
                textBoxComputername.Enabled = true;
                textBoxComputername.Text = "";
                buttonVyhledat.Enabled = false;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "Lokální PC")
                textBoxComputername.Text = "";
            else
                return;
        }
        private void obnovListView()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Software", 100);
            listView1.Columns.Add("Verze", 100);
            listView1.Columns.Add("Datum instalace", 150);
            listView1.Columns.Add("Vydavatel", 100);
            listView1.Columns.Add("Umístění softwaru", 150);
            listView1.Columns.Add("Instalováno z", 120);
            listView1.Columns.Add("Odinstalační string", 150);
        }
        private void fillListView(string software, string verze, string datumInstalace, string vydavatel, string umisteniSoftwaru, string instalovanoZ, string odinstalacniString)
        {
            /*
            ListViewItem lvi = new ListViewItem(pcName);
            lvi.SubItems.Add(program);
            lvi.SubItems.Add(verze);
            listView1.Items.Add(lvi);
            */
            ListViewItem lvi = new ListViewItem(software);
            lvi.SubItems.Add(verze);
            lvi.SubItems.Add(datumInstalace);
            lvi.SubItems.Add(vydavatel);
            lvi.SubItems.Add(umisteniSoftwaru);
            lvi.SubItems.Add(instalovanoZ);
            lvi.SubItems.Add(odinstalacniString);

            listView1.Items.Add(lvi);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkBoxLocalPC.Checked)
            {
                obnovListView();
                searchInstalledSoftware(Environment.MachineName);
                labelSoftwareAt.Text = "Software na zařízení: " + Environment.MachineName;
                labelPocetSW.Text = "Počet: " + listView1.Items.Count;
            } else
            {
                obnovListView();
                searchInstalledSoftware(textBoxComputername.Text);
                labelSoftwareAt.Text = "Software na zařízení: " + textBoxComputername.Text;
                labelPocetSW.Text = "Počet: " + listView1.Items.Count;
            }

        }
        private void searchInstalledSoftware(string computername)
        {
            //Dictionary<String, List<List<>>> data = new
            List<string> displayNames = new List<string>();
            List<string> displayVersions = new List<string>();
            List<string> uninstallStrings = new List<string>();
            List<string> publishers = new List<string>();
            List<string> installSource = new List<string>();
            List<string> installDate = new List<string>();
            List<string> installLocation = new List<string>();
            RegistryKey key;
            
            //CurrentUser
            key = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, computername).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                //Otevri prave prochazeny klic
                RegistryKey subkey = key.OpenSubKey(keyName);
                //Do listu uloz jmeno softwaru
                if (keyName != null && keyName != "")
                { 
                    
                    displayNames.Add(subkey.GetValue("DisplayName") as string);
                    displayVersions.Add(subkey.GetValue("DisplayVersion") as string);
                    uninstallStrings.Add(subkey.GetValue("UninstallString") as string);
                    publishers.Add(subkey.GetValue("Publisher") as string);
                    installSource.Add(subkey.GetValue("InstallSource") as string);
                    installDate.Add(subkey.GetValue("InstallDate") as string);
                    installLocation.Add(subkey.GetValue("InstallLocation") as string);
                }
            }
            
            //Localmachine (on remote pc) 32-bit
            key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computername).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                //Otevri prave prochazeny klic
                RegistryKey subkey = key.OpenSubKey(keyName);
                //Do listu uloz jmeno softwaru
                if (keyName != null && keyName != "")
                {
                    displayNames.Add(subkey.GetValue("DisplayName") as string);
                    displayVersions.Add(subkey.GetValue("DisplayVersion") as string);
                    uninstallStrings.Add(subkey.GetValue("UninstallString") as string);
                    publishers.Add(subkey.GetValue("Publisher") as string);
                    installSource.Add(subkey.GetValue("InstallSource") as string);
                    installDate.Add(subkey.GetValue("InstallDate") as string);
                    installLocation.Add(subkey.GetValue("InstallLocation") as string);
                }
            }

            //Localmachine (on remote pc) 64-bit
            key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, computername).OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                //Otevri prave prochazeny klic
                RegistryKey subkey = key.OpenSubKey(keyName);
                //Do listu uloz jmeno softwaru
                if (keyName != null && keyName != "")
                {
                    displayNames.Add(subkey.GetValue("DisplayName") as string);
                    displayVersions.Add(subkey.GetValue("DisplayVersion") as string);
                    uninstallStrings.Add(subkey.GetValue("UninstallString") as string);
                    publishers.Add(subkey.GetValue("Publisher") as string);
                    installSource.Add(subkey.GetValue("InstallSource") as string);
                    installDate.Add(subkey.GetValue("InstallDate") as string);
                    installLocation.Add(subkey.GetValue("InstallLocation") as string);
                }
            }
            //Delete all whitespace, null or duplicates
            int pocetSW = displayNames.Count;
            for (int i = 0; i < pocetSW; ++i )
            {
                if (displayNames[i] == "" || displayNames[i] == null)
                {
                    displayNames.RemoveAt(i);
                    displayVersions.RemoveAt(i);
                    uninstallStrings.RemoveAt(i);
                    publishers.RemoveAt(i);
                    installSource.RemoveAt(i);
                    installDate.RemoveAt(i);
                    installLocation.RemoveAt(i);
                    pocetSW = displayNames.Count;
                    continue;
                }
                //if (i != 0)
                    //pokud najdes duplikat, proved toto v zavorkach
                    //musi nechat aleaspon jeden prvek! (nasel jsem 4 stejny stringy, 3 odstranim, 1 necham)
                    {
                        displayNames.RemoveAt(i);
                        displayVersions.RemoveAt(i);
                        uninstallStrings.RemoveAt(i);
                        publishers.RemoveAt(i);
                        installSource.RemoveAt(i);
                        installDate.RemoveAt(i);
                        installLocation.RemoveAt(i);
                        pocetSW = displayNames.Count;
                        continue;
                    }
                fillListView(displayNames[i], displayVersions[i], installDate[i], publishers[i], installLocation[i], installSource[i], uninstallStrings[i]);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "")
                if (!checkBoxLocalPC.Checked)
                {
                    buttonVyhledat.Enabled = false;
                }
                else
                {
                    buttonVyhledat.Enabled = true;
                }
            else
            {
                buttonVyhledat.Enabled = true;
            }

        }
        private void InstalledPrograms_FormClosing(object sender, FormClosingEventArgs e)
        {
            obnovListView();
            labelPocetSW.Text = "Počet: 0";
            labelSoftwareAt.Text = "Software na zařízení: ";
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            //CTRL + C = Kopirovat nazev SW
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
                    String text = "";
                    foreach (ListViewItem item in selectedItems)
                    {
                        text += item.SubItems[0].Text + "\n";
                    }
                    Clipboard.SetText(text);
                    listView1.SelectedItems.Clear();
                }
                else
                {
                    MessageBox.Show("Není označen žádný řádek!\nOznačte alespoň jeden řádek!");
                }
            }
            //CTRL + A = Oznac vse
            if (e.Control && e.KeyCode == Keys.A)
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Selected = true;
                }
        }

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            String text = "";
            foreach (ListViewItem item in selectedItems)
            {
                text += item.SubItems[0].Text + "\n";
            }
            Clipboard.SetText(text);
            listView1.SelectedItems.Clear();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void tableLayoutPanelHorniVnoreny_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(themeColor, 1), 157, 33, 330, 33);
        }

        private void kopírovatVseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            String text = "";
            foreach (ListViewItem item in selectedItems)
            {
                text += item.SubItems[0].Text + ";" + item.SubItems[1].Text + ";" + item.SubItems[2].Text + ";" + item.SubItems[3].Text + ";"
                    + item.SubItems[4].Text + ";" + item.SubItems[5].Text + ";" + item.SubItems[6].Text + ";\n";
            }
            Clipboard.SetText(text);
            listView1.SelectedItems.Clear();
        }

        private void textBoxComputername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                obnovListView();
                searchInstalledSoftware(textBoxComputername.Text);
                labelSoftwareAt.Text = "Software na zařízení: " + textBoxComputername.Text;
                labelPocetSW.Text = "Počet: " + listView1.Items.Count;
            }
        }
    }
}
