﻿using System;
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
using System.Drawing.Printing;

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
            string pc = textBoxPC.Text;
            
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

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
                if (selectedItems.Count > 0)
                {
                    String text = "";
                    foreach (ListViewItem item in selectedItems)
                        text += item.SubItems[0].Text + Environment.NewLine;

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

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                String text = "";
                foreach (ListViewItem item in selectedItems)
                        text += item.SubItems[0].Text + Environment.NewLine;

                Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CopyWithNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems.Count > 0)
            {
                String text = "";
                foreach (ListViewItem item in selectedItems)
                        text += item.SubItems[0].Text + ";" + item.SubItems[1].Text + Environment.NewLine; 

                Clipboard.SetText(text);
                listView1.SelectedItems.Clear();
            }
            else MessageBox.Show("Není co kopírovat! Vyber položky ke kopírování.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxPC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                obnovListView(listView1);
                naplnListView();
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.Columns[0].Width = listView1.Columns[0].Width < 100 ? 100 : listView1.Columns[0].Width;
                listView1.Columns[1].Width = listView1.Columns[1].Width < 100 ? 100 : listView1.Columns[1].Width;
                listView1.Columns[2].Width = listView1.Columns[2].Width < 100 ? 100 : listView1.Columns[2].Width;
            }
        }

        private void buttonPrintPage_Click(object sender, EventArgs e)
        {
            string content = String.Empty;
            int i = 0;
            foreach (var item in listView1.Items)
            {
                i++;
                content += i + ". " + getBetween(item.ToString(), "{", "}") + Environment.NewLine;
            }
            printDocument1.DocumentName = "Evidovany_software_" + textBoxPC.Text.ToUpper();
            printDocument1.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString("Datum vygenerování: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), new Font("Arial", 8, FontStyle.Regular), new SolidBrush(Color.Black), new RectangleF(5, 5, printDocument1.DefaultPageSettings.PrintableArea.Width - 5, 15));
                e1.Graphics.DrawString("Seznam evidovaného softwaru na zařízení: " + textBoxPC.Text.ToUpper(), new Font("Arial", 14, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(5, 25, printDocument1.DefaultPageSettings.PrintableArea.Width - 5, 20));
                e1.Graphics.DrawString(content, new Font("Arial", 12), new SolidBrush(Color.Black), new RectangleF(5, 50, printDocument1.DefaultPageSettings.PrintableArea.Width-5, printDocument1.DefaultPageSettings.PrintableArea.Height-5));
            };
            printDialog1.Document = printDocument1;
            printPreviewDialog1.Document = printDocument1;
            try
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        
    }
}
