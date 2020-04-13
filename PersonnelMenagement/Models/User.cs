using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelMenagement.Models
{
    public class User
    {
        long id;
        string firstName;
        string lastName;
        string login;
        string passwordHash;
        string codeHash;
        decimal baseSalar;
        decimal hourlyRate;
        List<Permissions> permissions;
    }
}
