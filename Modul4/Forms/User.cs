using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4.Forms
{
    public class User
    {
        private int iDUser;
        private string name, surname;
        private bool privileges;

        public int IDUser { get => iDUser; set => iDUser = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public bool Privileges { get => privileges; set => privileges = value; }
    }
}
