using PersonnelMenagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelMenagement.Menagers
{
    public class ScheduleMenager
    {
        List<ScheduleStatus> statuses;

        public List<Schedule>  GetSchedulesForDay (DateTime date)
        {
            DateTime dateEndDay = date.AddHours(23).AddMinutes(59);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "tcp:kinosql.database.windows.net,1433";   // update me
            builder.UserID = "student";              // update me
            builder.Password = "Pa$$w0rd";      // update me
            builder.InitialCatalog = "PersonnelMenagement";


            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();

                // INSERT demo
                sb.Append("SELECT * FROM Schedule WHERE @dateEndDay > dateFrom > @date;");
                sb.Append("VALUES @date, @dateEndDay");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@dateEndDay", dateEndDay);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }
                    }
                }
            }

            return null;
        }

        public void addScheduleTask(User user, Models.Task task, DateTime dateFrom, DateTime dateTo)
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
                    sb.Append("INSERT Schedule (userId, taskId, dateFrom, dateTo, statusId) ");
                    sb.Append("VALUES (@userId, @taskId, @dateFrom, @dateTo, @statusId);");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userId", user.id);
                        command.Parameters.AddWithValue("@taskId", task.id);
                        command.Parameters.AddWithValue("@dateFrom", dateFrom);
                        command.Parameters.AddWithValue("@dateTo", dateTo);
                        command.Parameters.AddWithValue("@statusId", 1);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void updateSchedule (Schedule schedule)
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
                    sb.Append("UPDATE Schedule SET userId=@userId, taskId=@taskId, dateFrom=@dateFrom, dateTo=@dateTo, statusId=@statusId WHERE id=@id");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", schedule.id);
                        command.Parameters.AddWithValue("@userId", schedule.userId);
                        command.Parameters.AddWithValue("@taskId", schedule.taskId);
                        command.Parameters.AddWithValue("@dateFrom", schedule.dateFrom);
                        command.Parameters.AddWithValue("@dateTo", schedule.dateTo);
                        command.Parameters.AddWithValue("@statusId", schedule.statusId);


                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public void deleteSchedule (Schedule schedule)
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
                    sb.Append("DELETE FROM Schedule WHERE id=@id");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", schedule.id);
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
