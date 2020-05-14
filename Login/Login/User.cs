using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class User
    {
        List<string> PermissionList = new List<string>();

        int id;
      

        
        public int Id { get => id; set => id = value; }

       public string AddItemToPermissionList(string permission)
        {
            PermissionList.Add(permission);
            return permission;
        }
    
    }
}
