using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelMenagement.Menagers
{
    public class TaskMenagers
    {
        List<Task> tasks;

        public void addTask (string name, string description)
        {

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:kinosql.database.windows.net,1433";   // update me
                builder.UserID = "student";              // update me
                builder.Password = "Pa$$w0rd";      // update me
                builder.InitialCatalog = "Kino";



                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    // INSERT demo
                    sb.Append("INSERT Task (name, description) ");
                    sb.Append("VALUES (@name, @description);");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@description", description);

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }


        }

        public void updateTask (Models.Task task)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:kinosql.database.windows.net,1433";   // update me
                builder.UserID = "student";              // update me
                builder.Password = "Pa$$w0rd";      // update me
                builder.InitialCatalog = "Kino";



                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    // Update demo
                    sb.Append("UPDATE Task SET name=@name, description=@description WHERE id=@id");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", task.id);
                        command.Parameters.AddWithValue("@name", task.name);
                        command.Parameters.AddWithValue("@description", task.description);

                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void deleteTask (Models.Task task)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:kinosql.database.windows.net,1433";   // update me
                builder.UserID = "student";              // update me
                builder.Password = "Pa$$w0rd";      // update me
                builder.InitialCatalog = "Kino";



                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    // Delete demo
                    sb.Append("DELETE FROM Task WHERE id=@id");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", task.id);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        



    }
}
