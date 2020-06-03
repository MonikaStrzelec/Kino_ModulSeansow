using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Modul_raportow
{
    public class Validation
    {
        public static void ValidateDates(DateTime? date1, DateTime? date2) 
        {  
            if (date1 == null || date2 == null) throw new Exception("Musisz podać daty");

            if (DateTime.Compare((DateTime)date1.Value.Date, (DateTime)date2.Value.Date) > 0) throw new Exception("Data pierwsza nie może być wieksza");

    
        }
        public static void ValidateDatesInd(DateTime? date1, DateTime? date2, long userId, string name)
        {
            ValidateDates(date1, date2);

            if (userId < 0) throw new Exception("Podany numer jest mniejszy od zera");

            if (name.Length == 0) throw new Exception("Nie podano Nazwiska");

            if (name.Length >= 46) throw new Exception("Zbyt długi parametr");

            Regex r = new Regex("[^A-Za-z0-9]$");
            if (r.IsMatch(name)) throw new Exception("Możesz stosować tylko znaki od A-Z oraz 0-9 ");

        }
    }
        
}
