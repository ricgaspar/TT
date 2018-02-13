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
        public DZCsearch()
        {
            InitializeComponent();
            this.ActiveControl = textBoxUser;
            textBoxUser.Focus();
        }
        private void searchUsers(string user)
        {

            using (var context = new PrincipalContext(ContextType.Domain))
            {
                bool dzcFound;
                using (UserPrincipal userp = new UserPrincipal(context))
                {
                    userp.SamAccountName = user + "*";
                    using (var searcher = new PrincipalSearcher(userp))
                    {
                        ((DirectorySearcher)searcher.GetUnderlyingSearcher()).SearchScope = SearchScope.Subtree;
                        List<string> allUsers = new List<string>();
                        foreach (var result in searcher.FindAll())
                        {
                            allUsers.Add(result.DisplayName.ToString());
                            Console.WriteLine(result.DisplayName.ToString());
                        }
                        allUsers.Sort();
                        if (allUsers.Count() > 0)
                        {
                            dzcFound = true;
                            string toDisplay = string.Join(Environment.NewLine, allUsers);
                            MessageBox.Show(toDisplay, "Výsledek");
                        }
                        else dzcFound = false;
                    }
                }
                if (dzcFound == false)
                {
                    using (UserPrincipal userp = new UserPrincipal(context))
                    {
                        userp.DisplayName = user + "*";
                        using (var searcher = new PrincipalSearcher(userp))
                        {
                            ((DirectorySearcher)searcher.GetUnderlyingSearcher()).SearchScope = SearchScope.Subtree;
                            List<string> allUsers = new List<string>();
                            foreach (var result in searcher.FindAll())
                            {
                                allUsers.Add(result.DisplayName.ToString());
                                Console.WriteLine(result.DisplayName.ToString());
                            }
                            allUsers.Sort();
                            string toDisplay = string.Join(Environment.NewLine, allUsers);
                            MessageBox.Show(toDisplay, "Výsledek");
                        }
                    }
                }
            }
            
            
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            
            if (textBoxUser.TextLength <= 4)
            {
                DialogResult result = MessageBox.Show("Vyhledání takto širokého spektra uživatelů se nedoporučuje!\n\nToto vyhledání může zatížit server a potrvá déle!",
                    "Pokračování na vlastní riziko",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                    searchUsers(textBoxUser.Text);
            } else
                searchUsers(textBoxUser.Text);


        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUser.Text != "")
                buttonSearch.Enabled = true;
            else buttonSearch.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                searchUsers(textBoxUser.Text);
        }
    }
}
