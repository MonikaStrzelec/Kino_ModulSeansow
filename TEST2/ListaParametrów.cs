using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kino
{
    class DatabaseUtil
    {
        private void pobierzListaParametrow()
        {
            string conetionString;
            SqlConnection sc;
            SqlDataReader dr;
            conetionString = (@"Server = tcp:kinosql.database.windows.net,1433; Initial Catalog = Kino; Persist Security Info = False; User ID = student; Password = Pa$$w0rd; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
            sc = new SqlConnection(conetionString);
            sc.Open();

            String sql, odczyt = "";
            sql = "Select * FROM Dim";
            SqlCommand komenda = new SqlCommand(sql, sc);  //przekazany obiekt połączenia i ciąg SQ
            dr = komenda.ExecuteReader();                  // polecenie czytnika danych, które pobierze wszystkie wiersze z tabeli

            while(dr.Read())
            {
                odczyt = odczyt + dr.GetValue(1) + "\n";
            }
         //   return(odczyt);
        }

        private void wyswietlanieFilmow()
        {
            string conetionString;
            SqlConnection sc;
            SqlDataReader dr;
            conetionString = (@"Server = tcp:kinosql.database.windows.net,1433; Initial Catalog = Kino; Persist Security Info = False; User ID = student; Password = Pa$$w0rd; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
            sc = new SqlConnection(conetionString);
            sc.Open();

            String sql, odczyt = "";
            sql = "Select * FROM Movie";
            SqlCommand komenda = new SqlCommand(sql, sc);  //przekazany obiekt połączenia i ciąg SQ
            dr = komenda.ExecuteReader();                  // polecenie czytnika danych, które pobierze wszystkie wiersze z tabeli

            while (dr.Read())
            {
                odczyt = odczyt + dr.GetValue(1) + "\n";
            }

            MessageBox.Show(odczyt);
        }
    }
}
