using PersonnelMenagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelMenagement.Menagers
{
    public class UserMenager
    {
        List<User> users;

        public void addUser (User user)
        {

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:kinosql.database.windows.net,1433";   // update me
                builder.UserID = "student";              // update me
                builder.Password = "Pa$$w0rd";      // update me
                builder.InitialCatalog = "PersonnelMenagement";



                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    // INSERT demo
                    sb.Append("INSERT User (firstName, lastName, login, passwordHash, codeHash, baseSalar, hourlyRate) ");
                    sb.Append("VALUES (@firstName, @lastName, @login, @passwordHash, @codeHash, @baseSalar, @hourlyRate);");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", user.firstName);
                        command.Parameters.AddWithValue("@lastName", user.lastName);
                        command.Parameters.AddWithValue("@login", user.login);
                        command.Parameters.AddWithValue("@passwordHash", user.passwordHash);
                        command.Parameters.AddWithValue("@codeHash", user.codeHash);
                        command.Parameters.AddWithValue("@baseSalar", user.baseSalar);
                        command.Parameters.AddWithValue("@hourlyRate", user.hourlyRate);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void modifyUser (User user)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:kinosql.database.windows.net,1433";   // update me
                builder.UserID = "student";              // update me
                builder.Password = "Pa$$w0rd";      // update me
                builder.InitialCatalog = "PersonnelMenagement";



                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    // Update demo
                    sb.Append("UPDATE User SET firstName=@firstName, lastName=@lastName, login=@login, passwordHash=@passwordHash, codeHash=@codeHash, baseSolar=@baseSolar, hourlyRate=@hourlyRate WHERE id=@id");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", user.id);
                        command.Parameters.AddWithValue("@firstName", user.firstName);
                        command.Parameters.AddWithValue("@lastName", user.lastName);
                        command.Parameters.AddWithValue("@login", user.login);
                        command.Parameters.AddWithValue("@passwordHash", user.passwordHash);
                        command.Parameters.AddWithValue("@codeHash", user.codeHash);
                        command.Parameters.AddWithValue("@baseSalar", user.baseSalar);
                        command.Parameters.AddWithValue("@hourlyRate", user.hourlyRate);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void deleteUser (User user)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "tcp:kinosql.database.windows.net,1433";   // update me
                builder.UserID = "student";              // update me
                builder.Password = "Pa$$w0rd";      // update me
                builder.InitialCatalog = "PersonnelMenagement";



                // Connect to SQL
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();

                    // Delete demo
                    sb.Append("DELETE FROM User WHERE id=@id");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", user.id);
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
