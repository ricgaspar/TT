using System;
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

namespace TechnolToolkit
{
    public partial class DZCsearch : Form
    {
        public Color themeColor = Color.FromArgb(174, 0, 0);
        public DZCsearch()
        {
            InitializeComponent();
            this.ActiveControl = textBoxUser;
            textBoxUser.Focus();
        }
        private void searchUsers(string user)
        {
            if (textBoxUser.Text.StartsWith("*") == true)
            {
                MessageBox.Show("Řetězec nesmí začínat znakem hvězdy ( * )", "Nepovolený znak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (var context = new PrincipalContext(ContextType.Domain))
                {
                    bool dzcFound;
                    using (UserPrincipal userp = new UserPrincipal(context))
                    {
                        //Vyhledame vsechny uzivatelske id (DZCxxxx, nikoliv Pepa Novak), ktera zacinaji tim, co jsme dostali v promene od uzivatele
                        userp.SamAccountName = user + "*";
                        using (var searcher = new PrincipalSearcher(userp))
                        {
                            //Aby prohledaval pouze podvetev a nezatezoval server hledanim v celym AD...
                            ((DirectorySearcher)searcher.GetUnderlyingSearcher()).SearchScope = SearchScope.Subtree;
                            //List pro vsechny nalezeny usery
                            List<string> foundUsers = new List<string>();
                            foreach (var result in searcher.FindAll())
                            {
                                //Nalezene uzivatele pridame do listu
                                foundUsers.Add(result.SamAccountName.ToString() + " = " + result.DisplayName.ToString());
                            }
                            foundUsers.Sort();
                            //Nasli jsme podle uzivateskeho id (DZCxxxx) nejake uzivatele, tak je vypiseme
                            if (foundUsers.Count() > 0)
                            {
                                dzcFound = true;
                                string toDisplay = string.Join(Environment.NewLine, foundUsers);
                                MessageBox.Show(toDisplay, "Výsledek");
                            }
                            //Nenasli jsme podle uzivatelskeho id (DZCxxxx), budeme hledat podle jmena uzivatele (Pepa Novak)
                            else dzcFound = false;
                        }
                    }
                    if (dzcFound == false)
                    {
                        //Vse jako nahore krome radku, kde je komentar (viz. nize komentar)
                        using (UserPrincipal userp = new UserPrincipal(context))
                        {
                            //Rozdil je .DisplayName, ktery vyhleda zobrazovane jmeno (Jan Novak) a nikoliv user id(DZCxxx)
                            userp.DisplayName = user + "*";
                            using (var searcher = new PrincipalSearcher(userp))
                            {
                                ((DirectorySearcher)searcher.GetUnderlyingSearcher()).SearchScope = SearchScope.Subtree;
                                List<string> allUsers = new List<string>();
                                foreach (var result in searcher.FindAll())
                                {
                                    allUsers.Add(result.SamAccountName.ToString() + " = " + result.DisplayName.ToString());
                                }
                                allUsers.Sort();
                                string toDisplay = string.Join(Environment.NewLine, allUsers);
                                MessageBox.Show(toDisplay, "Výsledek");
                            }
                        }
                    }
                }

            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {            
            searchUsers(textBoxUser.Text);           
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUser.Text != "" && textBoxUser.TextLength > 4)
                buttonSearch.Enabled = true;
            else buttonSearch.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && textBoxUser.TextLength > 4)
                searchUsers(textBoxUser.Text);
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(themeColor, 1), 52, 37,52+textBoxUser.Width,37);
        }

        private void buttonSearch_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonSearch.Enabled)
            {
                buttonSearch.ForeColor = Color.FromArgb(142, 166, 4);
                buttonSearch.Font = new Font(buttonSearch.Font.FontFamily, buttonSearch.Font.Size, FontStyle.Bold);
            }
            else
            {
                buttonSearch.ForeColor = Color.White;
                buttonSearch.Font = new Font(buttonSearch.Font.FontFamily, buttonSearch.Font.Size, FontStyle.Regular);
            }
        }
    }
}
