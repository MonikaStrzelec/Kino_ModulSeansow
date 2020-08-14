using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using Kino.Properties;

namespace Kino
{
    class DatabaseUtil
    {
        KinoEntities context;

        private void wyswietlanieSzczegolowSeansu()
        {
            string conetionString;
            SqlConnection sc;
            SqlDataReader dr;
            conetionString = (@"Server = tcp:kinosql.database.windows.net,1433; Initial Catalog = Kino; Persist Security Info = False; User ID = student; Password = Pa$$w0rd; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
            sc = new SqlConnection(conetionString);
            sc.Open();



            String sql, odczyt = "";
            sql = "Select * FROM Performance WHERE Parametrs = " ;
            SqlCommand komenda = new SqlCommand(sql, sc);  //przekazany obiekt połączenia i ciąg SQ
            dr = komenda.ExecuteReader();                  // polecenie czytnika danych, które pobierze wszystkie wiersze z tabeli

            while (dr.Read())
            {
                odczyt = odczyt + dr.GetValue(1) + "\n";
            }

            MessageBox.Show(odczyt);
            sc.Close();
        }


        private void filtrNaDataGreadView()
        {
            //DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.Rows(counter).Index;       spr jak to dziala
            //DataGridView1.Refresh();
            //DataGridView1.CurrentCell = DataGridView1.Rows(counter).Cells(1);
            //DataGridView1.Rows(counter).Selected = True;


        }
    }
}
