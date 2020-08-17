using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace Modul_raportow
{
    public sealed class SQLObject
    {
        




        static SqlConnection con = new SqlConnection("Data Source=35.228.52.182;Initial Catalog=Kino;User ID=sqlserver;Password=Pa$$w0rd");
       
        public static DataTable SendCommand(string query)
        {


            try
            {
                DataTable data = new DataTable();
                con.Open();
                SqlCommand command = new SqlCommand(query, con);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);
                con.Close();
                
                return data;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Niemożliwe połączenie z bazą danych. Nastąpi wyłączenie aplikacji");
                Console.WriteLine(ex);
                System.Windows.Forms.Application.Exit();
                return null;

            }

        }
    }
}
 