﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Net;
using System.IO;

namespace TechnolToolkit
{
    public partial class DZCsearch : Form
    {
        private int minChars = 3; //minimal number of characters needed to search for user
        private ListViewColumnSorter lvwColumnSorter;
        public DZCsearch()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = lvwColumnSorter;
            this.ActiveControl = textBoxUser;
            textBoxUser.Focus();
        }
        private void searchUsers(string user)
        {
            obnovListView();
            if (textBoxUser.Text.StartsWith("*") == true)
            {
                MessageBox.Show("Řetězec nesmí začínat znakem hvězdy ( * )", "Nepovolený znak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int foundUsers = 0;
                using (var context = new PrincipalContext(ContextType.Domain))
                {
                    bool dzcFound;
                    using (UserPrincipal userp = new UserPrincipal(context))
                    {
                        //Vyhledame vsechny uzivatelske id (DZCxxxx, nikoliv Pepa Novak), ktera zacinaji tim, co jsme dostali v promene od uzivatele
                        userp.SamAccountName = user + "*";
                        using (var searcher = new PrincipalSearcher(userp))
                        {
                            //Aby prohledaval pouze podvetev a nezatezoval server hledanim v celym AD... snad to takhle funguje.. byl jsem linej se podivat
                            ((DirectorySearcher)searcher.GetUnderlyingSearcher()).SearchScope = SearchScope.Subtree;
                           
                            foreach (var result in searcher.FindAll())
                            {
                                DirectoryEntry direntry = result.GetUnderlyingObject() as DirectoryEntry;
                                string telefon = string.Empty; string mobil = string.Empty; string email = string.Empty; string kancelar = string.Empty; string oddeleni = string.Empty;
                                try { telefon = direntry.Properties["telephoneNumber"].Value.ToString(); } catch (Exception) { telefon = ""; }
                                try { mobil = direntry.Properties["mobile"].Value.ToString(); } catch (Exception) { mobil = ""; }
                                try { email = direntry.Properties["mail"].Value.ToString(); } catch (Exception) { email = ""; }
                                try { kancelar = direntry.Properties["physicalDeliveryOfficeName"].Value.ToString(); } catch (Exception) { kancelar = ""; }
                                try { oddeleni = direntry.Properties["department"].Value.ToString(); } catch (Exception) { oddeleni = ""; }
                                fillListView(result.SamAccountName.ToString(), result.DisplayName.ToString(), oddeleni, telefon, mobil, email, kancelar);
                                foundUsers++;
                            }
                            
                            if (foundUsers > 0) //Nasli jsme podle uzivateskeho id (DZCxxxx) nejake uzivatele, tak je vypiseme
                                dzcFound = true;
                            else dzcFound = false; //Nenasli jsme podle uzivatelskeho id (DZCxxxx), budeme hledat podle jmena uzivatele (Pepa Novak)
                        }
                    }
                    if (dzcFound == false)
                    {
                        //Vse jako nahore krome radku, kde je komentar (viz. nize komentar)
                        using (UserPrincipal userPrincipal = new UserPrincipal(context))
                        {
                            //Rozdil je .DisplayName, ktery vyhleda zobrazovane jmeno (Jan Novak) a nikoliv user id(DZCxxx)
                            userPrincipal.DisplayName = user + "*";
                            using (var searcher = new PrincipalSearcher(userPrincipal))
                            {
                                ((DirectorySearcher)searcher.GetUnderlyingSearcher()).SearchScope = SearchScope.Subtree;
                                foreach (var result in searcher.FindAll())
                                {
                                    DirectoryEntry direntry = result.GetUnderlyingObject() as DirectoryEntry;
                                    string telefon = string.Empty; string mobil = string.Empty; string email = string.Empty; string kancelar = string.Empty; string oddeleni = string.Empty;
                                    try { telefon = direntry.Properties["telephoneNumber"].Value.ToString(); } catch (Exception) { telefon = ""; }
                                    try { mobil = direntry.Properties["mobile"].Value.ToString(); } catch (Exception) { mobil = ""; }
                                    try { email = direntry.Properties["mail"].Value.ToString(); } catch(Exception) { email = ""; }
                                    try { kancelar = direntry.Properties["physicalDeliveryOfficeName"].Value.ToString(); } catch (Exception) { kancelar = ""; }
                                    try { oddeleni = direntry.Properties["department"].Value.ToString(); } catch (Exception) { oddeleni = ""; }

                                    fillListView(result.SamAccountName.ToString(), result.DisplayName.ToString(), oddeleni, telefon, mobil, email, kancelar);
                                    foundUsers++;
                                }
                            }
                        }
                    }
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            searchUsers(textBoxUser.Text);           
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUser.Text != "" && textBoxUser.TextLength > minChars)
                buttonSearch.Enabled = true;
            else buttonSearch.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && textBoxUser.TextLength > minChars)
                searchUsers(textBoxUser.Text);
        }

        private void buttonSearch_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonSearch.Enabled)
            {
                buttonSearch.ForeColor = Color.LimeGreen;
                buttonSearch.Font = new Font(buttonSearch.Font.FontFamily, buttonSearch.Font.Size, FontStyle.Bold);
            }
            else
            {
                buttonSearch.ForeColor = Color.White;
                buttonSearch.Font = new Font(buttonSearch.Font.FontFamily, buttonSearch.Font.Size, FontStyle.Regular);
            }
        }

        private void obnovListView()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("DZC", 50);
            listView1.Columns.Add("Jméno", 100);
            listView1.Columns.Add("Oddělení", 50);
            listView1.Columns.Add("Telefon",100);
            listView1.Columns.Add("Mobil", 100);
            listView1.Columns.Add("Email", 100);
            listView1.Columns.Add("Budova, kancelář", 100);
        }
        private void fillListView(string dzc, string jmeno, string oddeleni, string telefon, string mobil, string email, string kancelar)
        {
            ListViewItem lvi = new ListViewItem(dzc);
            lvi.SubItems.Add(jmeno);
            lvi.SubItems.Add(oddeleni);
            lvi.SubItems.Add(telefon);
            lvi.SubItems.Add(mobil);
            lvi.SubItems.Add(email);
            lvi.SubItems.Add(kancelar);

            listView1.Items.Add(lvi);
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
                if (selectedItems.Count > 0)
                {
                    string text = string.Empty;
                    foreach (ListViewItem item in selectedItems)
                    {
                        //6 protoze mame dohromady 6 udaju, ktere jsme nasli
                        for (int i = 0; i < 6; i++)
                        {
                            if (item != null)
                                text += item.SubItems[i].Text + ";";
                        }

                    }
                    if (text != null && text != "")
                        Clipboard.SetText(text);
                    listView1.SelectedItems.Clear();
                }
                else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem item in listView1.Items)
                    item.Selected = true;
            }
        }

        private void kopirovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    //6 protoze mame dohromady 6 udaju, ktere jsme nasli
                    for (int i = 0; i < 6; i++)
                    {
                        if (item != null)
                            text += item.SubItems[i].Text + ";";
                    }

                }
                if (text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void kopirovatDZCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.SubItems[0] != null)
                        if (selectedItems.Count > 1)
                            text += item.SubItems[0].Text + ";";
                        else
                            text += item.SubItems[0].Text;
                }
                if (text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void koprovatJmenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.SubItems[1] != null)
                        if (selectedItems.Count > 1)
                            text += item.SubItems[1].Text + ";";
                        else
                            text += item.SubItems[1].Text;
                }
                if (text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void kopirovatOddeleniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.SubItems[2] != null)
                        if (selectedItems.Count > 1)
                            text += item.SubItems[2].Text + ";";
                        else
                            text += item.SubItems[2].Text;
                }
                if (text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void kopirovatTelefonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    if(item.SubItems[3] != null)
                        if (selectedItems.Count > 1)
                            text += item.SubItems[3].Text + ";";
                        else
                            text += item.SubItems[3].Text;
                }
                if (text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void kopirovatMobilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.SubItems[4] != null)
                        if (selectedItems.Count > 1)
                            text += item.SubItems[4].Text + ";";
                        else
                            text += item.SubItems[4].Text;
                    
                }
                if(text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void kopirovatEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.SubItems[5] != null)
                        if (selectedItems.Count > 1)
                            text += item.SubItems[5].Text + ";";
                        else
                            text += item.SubItems[5].Text;
                }
                if (text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void kopirovatUmisteniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                string text = string.Empty;
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.SubItems[6] != null)
                        if (selectedItems.Count > 1)
                            text += item.SubItems[6].Text + ";";
                        else
                            text += item.SubItems[6].Text;
                }
                if (text != null && text != "")
                    Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
