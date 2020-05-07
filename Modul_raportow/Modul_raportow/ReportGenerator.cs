using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Modul_raportow
{
    class ReportGenerator
    {
        public static void Raport_podsumowania_czasu_pracy_pracownikow()
        {

            string zapytanie = "SELECT CAST( dbo.'Schedule'.dateFrom AS DATE) AS 'Dzień Pracy',CAST(dbo.'Schedule'.dateFrom AS Time(0)) AS 'Czas rozpoczęcia',CAST(dbo.'Schedule'.dateTo AS Time(0)) AS 'Czas Zakończenia', CAST(dbo.'Schedule'.dateTo - dbo.'Schedule'.dateFrom AS Time(0)) AS 'Czas pracy' FROM dbo.'Schedule' WHERE dbo.'Schedule'.userId = 1";
            
            //while (wynik.Read() || wynik != null)
          //  {
          //      Console.WriteLine(wynik[0].ToString(), wynik[1].ToString(), wynik[2].ToString());
          //  }
          //  return;
        }

        
        


    }
}
