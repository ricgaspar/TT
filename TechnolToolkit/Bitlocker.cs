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

        private void fillListView(string data)
        {
            resetListView();

            //Rozdeli data do listu tmp vzdy, kdyz narazi na novy radek
            List<string> tmp = data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            try
            {
                //Ostraneni prvniho radku
                tmp.RemoveAt(0);
                //Ostraneni vsech prazdnych radku
                tmp.RemoveAll(string.IsNullOrWhiteSpace);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Pravděpodobně nejste připojeni do sítě Škoda nebo jste nezadali správně název počítače" +
                                "\n-------------------------------------------------------------------------------\n"+ex.ToString(),"Chyba");
            }
            //Deklarace promenych
            List<string> threeLine = new List<string>();
            string temp = string.Empty;
            int i = 0;

            foreach (var line in tmp)
            {
                if (i == 3)
                {
                    threeLine.Add(temp);
                    temp = "";
                    i = 0;
                }
                temp += line + "\n";
                i++;
            }    
            foreach (var line in threeLine)
            {
                //datum a cas
                Match dc = Regex.Match(line, @"^name: ([^{]*)", RegexOptions.Singleline);
                Match guid = Regex.Match(line, @"msFVE-RecoveryGuid: \{(.*)\}");
                Match key = Regex.Match(line, "(?<=msFVE-RecoveryPassword: )(.*)(?=\n)", RegexOptions.Singleline);
                if (dc.Success && guid.Success && key.Success)
                {
                    string datumCas = dc.Groups[1].ToString().Trim();
                    string guID = guid.Groups[1].ToString().Trim();
                    string bKey = key.Groups[1].ToString().Trim();
                    //bitlocker key
                    ListViewItem lvi = new ListViewItem(bKey);
                    //datum a cas
                    lvi.SubItems.Add(datumCas);
                    //recovery guid
                    lvi.SubItems.Add(guID);
                    listView1.Items.Add(lvi);
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                
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
            fillListView(output);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            runIt();
        }

        private void textBoxDevice_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDevice.Text == "")
                buttonSearch.Enabled = false;
            else buttonSearch.Enabled = true;
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
                String text = "";
                foreach (ListViewItem item in selectedItems)
                {
                    text += item.SubItems[0].Text + "\n";
                }
                Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
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
                ListView.SelectedListViewItemCollection selectedItems =
                listView1.SelectedItems;
                String text = "";
                foreach (ListViewItem item in selectedItems)
                {
                    text += item.SubItems[0].Text + "\n";
                }
                Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
        }
    }
}
