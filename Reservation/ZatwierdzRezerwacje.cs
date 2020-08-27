using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml;

namespace Reservation
{
    public partial class ZatwierdzRezerwacje : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Kino"].ConnectionString;
        SqlConnection cnn;


        Reservation rezerwacja;
        List<Ticket> ticketListZatw;
        public ZatwierdzRezerwacje(Reservation reservation, List<Ticket> ticketList)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            rezerwacja = reservation;
            ticketListZatw = ticketList;
            int miejsca = 0;
            float koszt = 0;
            foreach(Ticket nr in ticketList)
            {
                
                koszt = (koszt + (float)nr.Cena);
                miejsca++;
            }
            InitializeComponent();
            label3.Text = reservation.Imie;
            label4.Text = reservation.Nazwisko;
            label5.Text = reservation.Email;
            label6.Text = reservation.Data;
            label7.Text = reservation.Tytuł;
            label8.Text = miejsca.ToString();
            label16.Text = koszt.ToString() + "zł";
        }

        //Zatwierdzenie złożenia rezerwacji
        private void button1_Click(object sender, EventArgs e)
        {
                        
            string sql = "INSERT INTO Kino.dbo.Reservation (id, status, firstName, lastName, email, idTimetable) values (@id, @status, @name, @lastname, @email, @timetable)";
            string sql2 = "SELECT COUNT(*), MAX([id]) FROM [Kino].[dbo].[Reservation]";
            SqlCommand cmd1 = new SqlCommand(sql2, cnn);
            SqlDataReader dataReader = cmd1.ExecuteReader();
            int output1 = 0;
            while (dataReader.Read())
            {
                if ((int)dataReader.GetValue(0) != 0)
                {
                    output1 = Convert.ToInt32(dataReader.GetValue(1)) + 1;
                }
            }
            cmd1.Cancel();
            dataReader.Close();

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = output1;
            cmd.Parameters.Add("@status", SqlDbType.VarChar);
            cmd.Parameters["@status"].Value = rezerwacja.Status;
            cmd.Parameters.Add("@name", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = rezerwacja.Imie;
            cmd.Parameters.Add("@lastname", SqlDbType.VarChar);
            cmd.Parameters["@lastname"].Value = rezerwacja.Nazwisko;
            cmd.Parameters.Add("@email", SqlDbType.VarChar);
            cmd.Parameters["@email"].Value = rezerwacja.Email;
            cmd.Parameters.Add("@timetable", SqlDbType.Int);
            cmd.Parameters["@timetable"].Value = rezerwacja.IdTimetable;
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            foreach (Ticket ticket in ticketListZatw)
            {
                sql2 = "INSERT INTO Kino.dbo.Ticket (id, type, price, id_Reservation, id_Seat) values (@id, @type, @price, @id_Reservation, @id_Seat)";
                sql = "SELECT COUNT(*), MAX([id]) FROM [Kino].[dbo].[Ticket]";
                
                cmd1 = new SqlCommand(sql, cnn);
                dataReader = cmd1.ExecuteReader();
                int output2 = 0;
                while (dataReader.Read())
                {
                    if ((int)dataReader.GetValue(0) != 0)
                    {
                        output2 = Convert.ToInt32(dataReader.GetValue(1)) + 1;
                    }
                }
                cmd1.Cancel();
                dataReader.Close();

                SqlCommand cmd2 = new SqlCommand(sql2, cnn);
                cmd2.Parameters.Add("@id", SqlDbType.Int);
                cmd2.Parameters["@id"].Value = output2;
                cmd2.Parameters.Add("@type", SqlDbType.VarChar);
                cmd2.Parameters["@type"].Value = ticket.Rodzaj;
                cmd2.Parameters.Add("@price", SqlDbType.Decimal);
                cmd2.Parameters["@price"].Value = ticket.Cena;
                cmd2.Parameters.Add("@id_Reservation", SqlDbType.Int);
                cmd2.Parameters["@id_Reservation"].Value = output1;
                cmd2.Parameters.Add("@id_Seat", SqlDbType.Int);
                cmd2.Parameters["@id_Seat"].Value = ticket.IdSeat;
                cmd2.ExecuteNonQuery();
                cmd2.Dispose();

                string sql3 = "UPDATE Kino.dbo.Seat SET status = 'zajete    ' WHERE id = '" + ticket.IdSeat.ToString() + "'";
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd3 = new SqlCommand(sql3, cnn);

                adapter.UpdateCommand = new SqlCommand(sql3, cnn);
                adapter.UpdateCommand.ExecuteNonQuery();
                cmd3.Dispose();
            }
            cnn.Close();
            if (rezerwacja.Imie == "Klient")
            {
                ZatwierdzPlatnosc form = new ZatwierdzPlatnosc(output1);
                form.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Rezerwacja została złożona.");
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
        }

        //Wycofanie się ze składania rezerwacji
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz anulować?","Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)                
            {                
                this.Close();
                Klient form = new Klient();
                form.ShowDialog();
            }         


        }
    }
}
