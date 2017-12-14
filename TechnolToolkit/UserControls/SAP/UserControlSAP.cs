using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace TechnolToolkit
{
    public partial class UserControlSAP : UserControl
    {
        public UserControlSAP()
        {
            InitializeComponent();
            obnovListView(listView1);
            listView1.FullRowSelect = true;
        }
        string ReadTextFromUrl(string url)
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead(url))
            using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
            {
                return textReader.ReadToEnd();
            }
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
        private void naplnListView()
        {
            string pc = textBoxPCname.Text;
            string url = "http://skdambsaimod01.mb.skoda.vwg/AISAPWEB/ai_sap.aspx?computername="+pc;

            WebClient client = new WebClient();

            //Vezme web a hodi ho do jednoho stringu
            string obsahWebu = String.Empty;
            try
            {
                 obsahWebu = ReadTextFromUrl(url);
            }
            catch(Exception ex)
            {
                obsahWebu = String.Empty;
                MessageBox.Show("Pravděpodobně nejste připojeni do sítě Škoda!\n--------------------------------------\n"+ ex.Message.ToString(),"Chyba!");
            }
            
            //Vyberem si pouze cast, ktera zacina <Software> a konci </Software>
            string obsahWebuSoftware = getBetween(obsahWebu, "<Software>", "</Software>");
            Console.WriteLine(obsahWebuSoftware);
            List<string> software = obsahWebuSoftware.Split(new string[] {"</Item>"}, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string swRadek in software)
              {
                ListViewItem lvi = new ListViewItem(getEnding(swRadek,">"));
                lvi.SubItems.Add(getBetween(obsahWebu, "<Computername>", "</Computername>"));
                lvi.SubItems.Add(getBetween(obsahWebu, "<SapId>", "</SapId>"));
                listView1.Items.Add(lvi);
            }
        }
        private void obnovListView(ListView listView)
        {
            listView.Clear();
            listView.Columns.Add("Software", 100);
            listView.Columns.Add("Jméno PC", 100);
            listView.Columns.Add("SAP ID zařízení", 100);
        }
        private void buttonVyhledat_Click(object sender, EventArgs e)
        {
            obnovListView(listView1);
            naplnListView();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.Columns[0].Width = listView1.Columns[0].Width < 100 ? 100 : listView1.Columns[0].Width;
            listView1.Columns[1].Width = listView1.Columns[1].Width < 100 ? 100 : listView1.Columns[1].Width;
            listView1.Columns[2].Width = listView1.Columns[2].Width < 100 ? 100 : listView1.Columns[2].Width;
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

        private void textBoxPCname_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPCname.Text == "")
                buttonVyhledat.Enabled = false;
            else
                buttonVyhledat.Enabled = true;
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {

                ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
                String text = "";
                foreach (ListViewItem item in selectedItems)
                {
                    if (checkBoxZarizeni.Checked)
                        text += item.SubItems[1].Text + " - " + item.SubItems[0].Text + "\n";
                    else
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

        private void textBoxPCname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                obnovListView(listView1);
                naplnListView();
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns[0].Width = listView1.Columns[0].Width < 100 ? 100 : listView1.Columns[0].Width;
                listView1.Columns[1].Width = listView1.Columns[1].Width < 100 ? 100 : listView1.Columns[1].Width;
                listView1.Columns[2].Width = listView1.Columns[2].Width < 100 ? 100 : listView1.Columns[2].Width;
            }
        }

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            String text = "";
            foreach (ListViewItem item in selectedItems)
            {
                if (checkBoxZarizeni.Checked)
                    text += item.SubItems[1].Text + " - " + item.SubItems[0].Text + "\n";
                else
                    text += item.SubItems[0].Text + "\n";
            }
            Clipboard.SetText(text);
            listView1.SelectedItems.Clear();
        }
    }
}
