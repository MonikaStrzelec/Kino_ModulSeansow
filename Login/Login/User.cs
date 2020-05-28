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
        
        public void AddItemToPermissionList(string permission)
        { 
            PermissionList.Add(permission);
        }

       
        public string PrintListOfPermission()
        {
          

            if (PermissionList.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Permissions of logged user: \r\n \r\n");
                foreach (string permission in PermissionList)
                    sb.AppendLine(permission);
                return sb.ToString();
            }
            string x = "Błąd, użytkownik nie posiada uprawnień.";
            return x;


        }
    }
}
