using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    public partial class RemoteControl : Form
    {
        public RemoteControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(File.Exists(@"C:\Program Files (x86)\ConfigMgr\bin\i386\CmRcViewer.exe") == true)
            {
                Process p = new Process();
                p.StartInfo.FileName = @"C:\Program Files (x86)\ConfigMgr\bin\i386\CmRcViewer.exe";
                p.StartInfo.Arguments = textBoxCilPC.Text;
                p.Start();
            }
            else
            {
                MessageBox.Show("Pravděpodobně nemáte nainstalovanou Configuration Manager Konzoli\nOtevření soboru selhalo...\n\"C:\\Program Files(x86)\\ConfigMgr\\bin\\i386\\CmRcViewer.exe\"", "Chyba", MessageBoxButtons.OK);
            }
        }
    }
}
