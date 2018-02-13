using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnolToolkit
{
    class GroupsAndMember
    {
        public Dictionary<String, List<String>> getGroupsAndMembers(string computername)
        {
            Dictionary<String, List<String>> result = new Dictionary<string, List<string>>();

            Ping ping = new Ping();
            try
            {
                //try if machine is online
                PingReply pingReply = ping.Send(computername,2000);
                if (pingReply.Status == IPStatus.Success)
                {
                    DirectoryEntry machine = new DirectoryEntry("WinNT://" + computername + ",Computer");

                    foreach (DirectoryEntry child in machine.Children)
                        if (child.SchemaClassName == "Group")
                        {
                            String groupName = child.Name;
                            List<String> groupMembers = new List<string>();

                            //Starting code that adds members of groups above.
                            using (DirectoryEntry groupEntry = new DirectoryEntry("WinNT://" + computername + "/" + child.Name + ",group"))
                                foreach (object member in (IEnumerable)groupEntry.Invoke("Members"))
                                    using (DirectoryEntry memberEntry = new DirectoryEntry(member))
                                    {
                                        //Adding members of current group
                                        groupMembers.Add(memberEntry.Name);
                                    }
                            result.Add(groupName, groupMembers);
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

    }
}
