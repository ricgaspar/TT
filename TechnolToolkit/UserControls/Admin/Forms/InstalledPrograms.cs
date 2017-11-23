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
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(46, 45, 48); }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(75, 74, 77); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(46, 45, 48); }
            }
            public override Color MenuItemBorder
            {
                get { return Color.Transparent; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.FromArgb(46, 45, 48); }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.FromArgb(75, 74, 77); }
            }

        }
        private ListViewColumnSorter lvwColumnSorter;
        public InstalledPrograms()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = lvwColumnSorter;
            obnovListView();
            //this.Icon = new Icon(Properties.Resources.)
            menuStrip1.Renderer = new MyRenderer();
            
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
            //Chceme lokalni pc?
            if (checkBoxLocalPC.Checked == true)
            {
                textBox1.Enabled = false;
                buttonVyhledat.Enabled = true;
            }
            //Nechceme
            else
            {
                textBox1.Enabled = true;
                textBox1.Text = "";
                buttonVyhledat.Enabled = false;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Lokální PC")
                textBox1.Text = "";
            else
                return;
        }
        private void obnovListView()
        {
            listView1.Clear();
            int sirkaListView1 = listView1.Width;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("PC/IP", (sirkaListView1 / 100) * 15);
            listView1.Columns.Add("Instalovaný Software", (sirkaListView1 / 100) * 65);
            listView1.Columns.Add("Verze", (sirkaListView1 / 100) * 20);
        }
        private void naplnListView(string pcName, string program, string verze)
        {
            
            ListViewItem lvi = new ListViewItem(pcName);
            lvi.SubItems.Add(program);
            lvi.SubItems.Add(verze);
            listView1.Items.Add(lvi);
        }

        private void InstalovaneProgramy(string output, bool isRemotePC)
        {
            string[] pole = output.Split(new[] { "HKEY_LOCAL_MACHINE" }, StringSplitOptions.RemoveEmptyEntries);
            obnovListView();
            foreach(string blok in pole)
            {
                Match m1 = Regex.Match(blok, @"DisplayName\s+REG_SZ(.*)",RegexOptions.Multiline);
                Match m2 = Regex.Match(blok, @"DisplayVersion\s+REG_SZ(.*)", RegexOptions.Multiline);
                if (m1.Success && m2.Success)
                {
                    string name = m1.Groups[1].ToString().Trim();
                    string version = m2.Groups[1].ToString().Trim();

                    if (checkBoxLocalPC.Checked)
                        naplnListView(Environment.MachineName, name, version);
                    else naplnListView(textBox1.Text, name, version);
                }
            }
            if (checkBoxLocalPC.Checked)
                otevrenoToolStripMenuItem.Text = "Otevřeno: " + Environment.MachineName;
            else otevrenoToolStripMenuItem.Text = "Otevřeno: " + textBox1.Text;
            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.listView1.Columns)
            {
                ch.Width = -2;
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            obnovListView();
            Process p = new Process();
            string format = DateTime.Now.ToString("yyy_mm_dd_hh_mm_ss");
            string pcName = Environment.MachineName;
            string slozkaLogy = @"C:\ProgramData\TechnolToolkit\InstalledPrograms\" + pcName + "\\";
            p.StartInfo.CreateNoWindow = true;
            if (checkBoxLocalPC.Checked)
            {
                p.StartInfo.FileName = @"C:\WINDOWS\system32\reg.exe";
                p.StartInfo.Arguments = @"query HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall /s /f Display";
            }
            else
            {
                p.StartInfo.FileName = @"C:\ProgramData\TechnolToolkit\PsExec.exe";
                p.StartInfo.Arguments =  @"\\" + textBox1.Text + @" reg query HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Uninstall /s /f Display";
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;

            statusBox sb = new statusBox();
            sb.Show();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (checkBoxLocalPC.Checked)
                {
                    //local pc, nebudeme provadet ping
                    p.Start();
                    string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();

                    Invoke(new Action(() =>
                    {
                        InstalovaneProgramy(output, false);
                        sb.Close();
                    }));
                }
                else
                {
                    //remote pc, provedeme ping
                    try {
                        Ping ping = new Ping();
                        PingReply pingReply = ping.Send(textBox1.Text);
                        if (pingReply.Status == IPStatus.Success)
                        {
                            //Machine is alive
                            p.Start();
                            string output = p.StandardOutput.ReadToEnd();
                            p.WaitForExit();

                            Invoke(new Action(() =>
                            {
                                InstalovaneProgramy(output, false);
                                sb.Close();
                            }));
                        }
                    }
                    catch
                    {
                        Invoke(new Action(() =>
                        {
                            sb.Close();
                        }));
                        MessageBox.Show(textBox1.Text + " není na síti. Zadali jste správný HostName?\nZkuste zadat IP adresu místo HostName.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                
            }).Start();            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
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
        private void otevrenoToolStripMenuItem_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(otevrenoToolStripMenuItem.Text, otevrenoToolStripMenuItem.Font);
            otevrenoToolStripMenuItem.Width = size.Width;
        }

        private void InstalledPrograms_FormClosing(object sender, FormClosingEventArgs e)
        {
            obnovListView();
            otevrenoToolStripMenuItem.Text = "";
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
                String text = "";
                foreach (ListViewItem item in selectedItems)
                {
                    if(checkBoxKopirujVerze.Checked)
                        text += item.SubItems[1].Text + " - " + item.SubItems[2].Text + "\n";
                    else
                        text += item.SubItems[1].Text + "\n";
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

        private void kopírovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            String text = "";
            foreach (ListViewItem item in selectedItems)
            {
                if (checkBoxKopirujVerze.Checked)
                    text += item.SubItems[1].Text + " - " + item.SubItems[2].Text + "\n";
                else
                    text += item.SubItems[1].Text + "\n";
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
    }
}
