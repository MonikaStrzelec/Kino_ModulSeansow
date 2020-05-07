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

        public static DataTable ConnectToData() {


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

                return data;
            }
        }
        
        

        

        /* static SqlConnection con = new SqlConnection("Data Source=35.228.52.182;Initial Catalog=Kino;User ID=sqlserver;Password=Pa$$w0rd");

         public static SqlDataAdapter SendCommand(SqlConnection connection)
         {


             try
             {
                 con.Open();
                 MessageBox.Show("Połączono");

                 SqlDataAdapter adapter = new SqlDataAdapter();

                 SqlCommand command = new SqlCommand("SELECT CAST(dbo.'Schedule'.dateFrom AS DATE) AS 'Dzień Pracy', CAST(dbo.'Schedule'.dateFrom AS Time(0)) AS 'Czas rozpoczęcia', CAST(dbo.'Schedule'.dateTo AS Time(0)) AS 'Czas Zakończenia', CAST(dbo.'Schedule'.dateTo - dbo.'Schedule'.dateFrom AS Time(0)) AS 'Czas pracy' FROM dbo.'Schedule' WHERE dbo.'Schedule'.userId = 1", con);

                 Console.WriteLine(command);

                 return adapter;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Nie udało się połączyć");
                 return null;
             }


              using (SqlCommand query = new SqlCommand(zapytanie, con))
                 {
                     query.Connection.Open();
                     SqlDataReader temp = query.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                     con.Close();
                     return temp;
                 }
          */

    
    }
}
 