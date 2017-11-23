using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class UserControlAddToGroup : UserControl
    {
        UserControlAddToGroupChild_Add ucAdd = new UserControlAddToGroupChild_Add();
        UserControlAddToGroupChild_Remove ucRem = new UserControlAddToGroupChild_Remove();
        public UserControlAddToGroup()
        {
            InitializeComponent();
            panel1.Controls.Add(ucAdd);
            ucAdd.Size = panel1.Size;
        }
    }
}
