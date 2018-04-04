using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class Bitlocker : Form
    {
        public Bitlocker()
        {
            InitializeComponent();
            resetListView();
        }
        public void resetTextBox()
        {
            textBoxDevice.Text = "";
        }
        public void resetListView()
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = false;
            listView1.MultiSelect = true;
            listView1.Columns.Add("BitLocker obnovovací klíč");
            listView1.Columns.Add("Vygenerováno dne");
            listView1.Columns.Add("Recovery GUID");
            listView1.Columns[0].Width = 400;
            listView1.Columns[1].Width = 150;
            listView1.Columns[2].Width = 300;
        }
        private void fillListViewBetter(string data)
        {
            Match bitlocker = Regex.Match(data, @"name: ([^{]*).*[\r\n]+msFVE-RecoveryGuid: \{(\S*)\}[\r\n]+msFVE-RecoveryPassword: (\S*)");
            while (bitlocker.Success)
            {
                string datumCas = bitlocker.Groups[1].ToString().Trim();
                string guID = bitlocker.Groups[2].ToString().Trim();
                string bKey = bitlocker.Groups[3].ToString().Trim();
                //bitlocker key
                ListViewItem lvi = new ListViewItem(bKey);
                //datum a cas
                lvi.SubItems.Add(datumCas);
                //recovery guid
                lvi.SubItems.Add(guID);
                listView1.Items.Add(lvi);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                bitlocker = bitlocker.NextMatch();
            }
        }
 
        private void runIt()
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Windows\System32\cscript.exe";
            p.StartInfo.Arguments = @"//NoLogo C:\ProgramData\TechnolToolkit\bitlocker.vbs " + textBoxDevice.Text;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            fillListViewBetter(output);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            runIt();
        }

        private void textBoxDevice_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDevice.Text == "")
            {
                buttonSearch.Enabled = false;
                buttonSearch.ForeColor = Color.DimGray;
            }
            else
            {
                buttonSearch.Enabled = true;
                buttonSearch.ForeColor = Color.White;
            }
        }

        private void textBoxDevice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                runIt();
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
                if (selectedItems.Count > 0)
                {
                    String text = "";
                    foreach (ListViewItem item in selectedItems)
                    {
                        text += item.SubItems[0].Text + "\n";
                    }
                    Clipboard.SetText(text);
                    listView1.SelectedItems.Clear();
                }
                else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.Control && e.KeyCode == Keys.A)
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Selected = true;
                }
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

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                String text = "";
                foreach (ListViewItem item in selectedItems)
                {
                    text += item.SubItems[0].Text + "\n";
                }
                Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
