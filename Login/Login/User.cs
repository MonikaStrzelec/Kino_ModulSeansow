using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    class User
    {
        private List<string> PermissionList = new List<string>();

        int id;
      

        
        public int Id { get => id; set => id = value; }
       

        public string AddItemToPermissionList(string permission)
        {
            PermissionList.Add(permission);
            return permission;
        }
        public string PrintListOfPermission()
        {
            string x = "nic";
            if (PermissionList.Count != 0)
            {
                foreach (string permission in PermissionList)
                    return permission;
            }
            return x;

        }
    }
}
