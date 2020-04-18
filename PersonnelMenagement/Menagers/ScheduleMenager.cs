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
            return null;
        }

        public void scheduleTask(User user, Models.Task task, DateTime date)
        {

        }

        public void updateSchedule (Schedule schedule)
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
                builder.InitialCatalog = "Kino";



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
