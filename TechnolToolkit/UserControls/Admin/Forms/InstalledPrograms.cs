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
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnolToolkit.CustomControls_and_Clases;

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
            if (checkBoxLocalPC.Checked == true)
            {
                textBoxComputername.Enabled = false;
                buttonVyhledat.Enabled = true;

            }
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
            listView1.Columns.Add("Vydavatel", 100);
            listView1.Columns.Add("Datum instalace", 150);
            listView1.Columns.Add("Umístění softwaru", 150);
            listView1.Columns.Add("Instalováno z", 120);
            listView1.Columns.Add("Odinstalační string", 150);
        }
        private void fillListView(string software, string verze, string vydavatel, string datumInstalace, string umisteniSoftwaru, string instalovanoZ, string odinstalacniString)
        {
            ListViewItem lvi = new ListViewItem(software);
            lvi.SubItems.Add(verze);
            lvi.SubItems.Add(vydavatel);
            lvi.SubItems.Add(datumInstalace);
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
                    
            }
            else
            {
                obnovListView();
                searchInstalledSoftware(textBoxComputername.Text);
                labelSoftwareAt.Text = "Software na zařízení: " + textBoxComputername.Text;
                labelPocetSW.Text = "Počet: " + listView1.Items.Count;
            }
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = SortOrder.Ascending;
            // Perform the sort with these new sort options.
            this.listView1.Sort();
    }

    private void searchInstalledSoftware(string computername)
        {
            if(!checkBoxLocalPC.Checked)
                runOrStopService("RemoteRegistry", textBoxComputername.Text, serviceAction.run);
            //ServiceManipulation.runOrStopService("RemoteRegistry", computername, ServiceManipulation.serviceAction.run);
            List<string> displayNames = new List<string>();
            List<string> displayVersions = new List<string>();
            List<string> uninstallStrings = new List<string>();
            List<string> publishers = new List<string>();
            List<string> installSource = new List<string>();
            List<string> installDate = new List<string>();
            List<string> installLocation = new List<string>();
            RegistryKey key;

            #region currentUser
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
            #endregion
            #region localmachine 64-bit
            //Localmachine (on remote pc) 64-bit
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
            #endregion
            #region localmachine 32-bit
            
            //Localmachine (on remote pc) 32-bit
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

            #endregion

            #region Delete duplicates
            //ulozi do listu vsechny polozky, az na jednu, ktere se opakuji     
            List<string> duplicates = displayNames.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).ToList();
            
            //Smazani duplikatu
            for (int i = 0; i < duplicates.Count; i++)
            {
                for (int y = 0; y < displayNames.Count; y++)
                {
                    if (duplicates[i] == displayNames[y])
                    {    
                        displayNames.RemoveAt(y);
                        displayVersions.RemoveAt(y);
                        uninstallStrings.RemoveAt(y);
                        publishers.RemoveAt(y);
                        installSource.RemoveAt(y);
                        installDate.RemoveAt(y);
                        installLocation.RemoveAt(y);
                        continue;
                    }
                }
            }
            #endregion

            #region Filters
            //Hide Updates
            if (checkBoxHideUpdates.Checked)
            {
                for (int i = 0; i < displayNames.Count; i++)
                {
                    if (displayNames[i].Contains("Update") && publishers[i].Contains("Microsoft"))
                    {
                        displayNames.RemoveAt(i);
                        displayVersions.RemoveAt(i);
                        uninstallStrings.RemoveAt(i);
                        publishers.RemoveAt(i);
                        installSource.RemoveAt(i);
                        installDate.RemoveAt(i);
                        installLocation.RemoveAt(i);
                        continue;
                    }
                }
            }
            //Hide MUIs
            if (checkBoxHideMUI.Checked)
            {
                for (int i = 0; i < displayNames.Count; i++)
                {
                    if (displayNames[i].Contains("MUI"))
                    {
                        displayNames.RemoveAt(i);
                        displayVersions.RemoveAt(i);
                        uninstallStrings.RemoveAt(i);
                        publishers.RemoveAt(i);
                        installSource.RemoveAt(i);
                        installDate.RemoveAt(i);
                        installLocation.RemoveAt(i);
                        continue;
                    }
                }
            }
            //Hide Microsoft
            if (checkBoxHideMicrosoft.Checked)
            {
                for (int i = 0; i < publishers.Count; i++)
                {
                    if (publishers[i] != null)
                        if (publishers[i] == ("Microsoft") || publishers[i] == ("Microsoft Corporation"))
                        {
                            displayNames.RemoveAt(i);
                            displayVersions.RemoveAt(i);
                            uninstallStrings.RemoveAt(i);
                            publishers.RemoveAt(i);
                            installSource.RemoveAt(i);
                            installDate.RemoveAt(i);
                            installLocation.RemoveAt(i);
                            continue;                            
                        }
                }
            }

            #endregion

            #region Delete Null items and fill listView
            for (int i = 0; i < displayNames.Count; ++i )
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
                    continue;
                }
                fillListView(displayNames[i], displayVersions[i], publishers[i], installDate[i], installLocation[i], installSource[i], uninstallStrings[i]);
            }
            #endregion
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            if (!checkBoxLocalPC.Checked)
                runOrStopService("RemoteRegistry", computername, serviceAction.stop);
                    //ServiceManipulation.runOrStopService("RemoteRegistry", computername, ServiceManipulation.serviceAction.stop);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxComputername.Text == "")
                if (!checkBoxLocalPC.Checked)
                    buttonVyhledat.Enabled = false;
                else
                    buttonVyhledat.Enabled = true;
            else
                buttonVyhledat.Enabled = true;
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
                    MessageBox.Show("Není označen žádný řádek!\nOznačte alespoň jeden řádek!","Není co kopírovat",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void kopirovatVseToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void pictureBoxInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tento nástroj prohledává registry na zvoleném PC.\n\nJe možné, že nalezne již odinstalovaný software, který ale zůstal v registrech zapsaný.\n\nNapříklad se může stát: \nPokud se zobrazí 2 softwary stejného jména, ale jiné verze, je možné, že starší verze již neexistuje, ale záznam v registru zůstal.\nAtp...\n\n\nProhledávané větve registrů:\nHKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\nHKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\nHKLM\\SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", "Jak to vlastně funguje? :)",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        float imageOpacity = 0.4f;
        float imageMinimalOpacity = 0.4f;

        private void pictureBoxInfo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(ImageManipulation.ResizeImage(ImageManipulation.SetOpacity(Properties.Resources.icons8_information_96,imageOpacity),25,25),0,0);
        }

        public enum opacityAction { increase, decrease };

        private void mouseVisitOpacity(opacityAction increseOrDecreseOpacity)
        {
            switch(increseOrDecreseOpacity)
            {
                case opacityAction.increase:
                    timer1.Start();
                    timer1.Interval = 5;
                    while (imageOpacity < 1)
                    {
                        imageOpacity += 0.001f;
                        if (imageOpacity > 1)
                            imageOpacity = 1;
                        pictureBoxInfo.Refresh();
                    }
                    timer1.Stop();
                    break;
                case opacityAction.decrease:
                    timer1.Start();
                    timer1.Interval = 5;
                    while (imageOpacity > imageMinimalOpacity)
                    {
                        imageOpacity -= 0.001f;
                        if (imageOpacity < imageMinimalOpacity)
                            imageOpacity = imageMinimalOpacity;
                        pictureBoxInfo.Refresh();
                    }
                    timer1.Stop();
                    break;
            }
        }
        private void pictureBoxInfo_MouseEnter(object sender, EventArgs e)
        {
            mouseVisitOpacity(opacityAction.increase);
        }

        private void pictureBoxInfo_MouseLeave(object sender, EventArgs e)
        {
            mouseVisitOpacity(opacityAction.decrease);
        }

        public static void EnableTheService(string serviceName, string computername, serviceAction serAction)
        {
            switch (serAction)
            {
                case serviceAction.run:
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = @"/c sc \\" + computername + " config " + serviceName + " start= demand";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();
                    p.WaitForExit(10000);
                    break;
                case serviceAction.stop:
                    Process p1 = new Process();
                    p1.StartInfo.FileName = "cmd.exe";
                    p1.StartInfo.Arguments = @"/c sc \\" + computername + " config " + serviceName + " start= disabled";
                    p1.StartInfo.CreateNoWindow = true;
                    p1.StartInfo.UseShellExecute = false;
                    p1.Start();
                    p1.WaitForExit(10000);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Invalid parameter in serviceAction enum");
            }

        }

        public enum serviceAction
        {
            run,
            stop,
        }
        public static void runOrStopService(string serviceName, string computer, serviceAction action)
        {
            Console.WriteLine("==========Service Manipulation==========");
            switch (action)
            {
                case serviceAction.run:
                    EnableTheService(serviceName, computer, action);
                    using (ServiceController sc = new ServiceController(serviceName, computer))
                        if (sc.Status != ServiceControllerStatus.Running)
                        {
                            Console.WriteLine("Start sluzby {0}", sc.DisplayName);
                            sc.Start();
                            Console.WriteLine("Cekani na status: Running");
                            sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(60));
                            if (sc.Status != ServiceControllerStatus.Running)
                                MessageBox.Show("Sluzbu " + sc.DisplayName + " se nepodarilo spustit", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else Console.WriteLine("Status sluzby {0}: {1}", sc.DisplayName, sc.Status);
                        }
                        else Console.WriteLine("Status sluzby {0}: {1}", sc.DisplayName, sc.Status);
                    break;

                case serviceAction.stop:
                    EnableTheService(serviceName, computer, action);
                    using (ServiceController sc = new ServiceController(serviceName, computer))
                        if (sc.Status != ServiceControllerStatus.Stopped)
                        {
                            Console.WriteLine("Zastavovani sluzby {0}", sc.DisplayName);
                            sc.Stop();
                            Console.WriteLine("Cekani na status: Stopped");
                            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(60));
                            if (sc.Status != ServiceControllerStatus.Stopped)
                                MessageBox.Show("Sluzbu " + sc.DisplayName + " se nepodarilo zastavit", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else Console.WriteLine("Status sluzby {0}: {1}", sc.DisplayName, sc.Status);
                        }
                    break;
                default:
                    throw new InvalidEnumArgumentException("Invalid parameter in serviceAction enum");
            }
            Console.WriteLine("========================================");
        }
    }
}
