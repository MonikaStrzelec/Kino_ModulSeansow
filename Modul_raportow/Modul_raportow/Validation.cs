using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_raportow
{
    public class Validation
    {
        public static void ValidateDates(DateTime? date1, DateTime? date2) 
        {  
            if (date1 == null || date2 == null) throw new Exception("Musisz podać daty");

            if (DateTime.Compare((DateTime)date1, (DateTime)date2) > 1) throw new Exception("Data pierwsza nie może być wieksza");
        }
        public static void ValidateDatesInd(DateTime? date1, DateTime? date2)
        {

        }
    }
        
}
