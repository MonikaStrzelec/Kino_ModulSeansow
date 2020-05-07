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

        /* public static DataTable ConnectToData() {


             using (SqlConnection con = new SqlConnection("Data Source=35.228.52.182;Initial Catalog=Kino;User ID=sqlserver;Password=Pa$$w0rd"))
             {
                 DataTable data = new DataTable();



                 con.Open();
                 Console.WriteLine("Open");

                 SqlCommand command = new SqlCommand("SELECT * FROM dbo.Movie", con);

                 command.CommandType = CommandType.Text;

                 //adapter.SelectCommand = command;

                 SqlDataAdapter adapter = new SqlDataAdapter(command);

                 adapter.Fill(data);



                 Console.WriteLine(data);

                 con.Close();
                 Console.WriteLine("Connection closed");
                // foreach (DataRow row in data.Rows)
              //  {
                //     Console.WriteLine(row[1].ToString());
                // }

                 return data;
             }
         }*/





        static SqlConnection con = new SqlConnection("Data Source=35.228.52.182;Initial Catalog=Kino;User ID=sqlserver;Password=Pa$$w0rd");

        public static DataTable SendCommand(string query)
        {


            try
            {
                DataTable data = new DataTable();
                con.Open();
                MessageBox.Show("Połączono");

                SqlCommand command = new SqlCommand(query, con);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się połączyć");
                return null;
            }

        }
    }
}
 