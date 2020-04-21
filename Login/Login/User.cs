using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class User
    {
        int id;
        string firstName, lastName, login, password, code;
        double baseSalary, hourlyRate;

        
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Code { get => code; set => code = value; }
        public double BaseSalary { get => baseSalary; set => baseSalary = value; }
        public double HourlyRate { get => hourlyRate; set => hourlyRate = value; }
    }
}
