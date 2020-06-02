using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelMenagement.Models
{
    public class User
    {
        public long id;
        public string firstName;
        public string lastName;
        public string login;
        public string passwordHash;
        public string codeHash;
        public decimal baseSalary;
        public decimal hourlyRate;
        List<Permissions> permissions;
    }
}
