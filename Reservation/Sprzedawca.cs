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

    public partial class Sprzedawca : Form
    {
        public Sprzedawca()
        {
            InitializeComponent();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wróćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RepertuarSprzedawca form = new RepertuarSprzedawca();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrzegladRez form = new FormPrzegladRez();
            form.ShowDialog();
        }

        //Ręczne uruchomienie automatu anulującego rezerwacje
        private void button3_Click(object sender, EventArgs e)
        {
            int lbZwolnMiejsc = 0;
            int lbAnulRezerw = 0;
            string connectionString = @"Data Source=35.228.52.182,1433;Initial Catalog=Kino; User ID=sqlserver; Password=Pa$$w0rd; MultipleActiveResultSets=True";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            string sql = "SELECT id, idTimetable FROM Kino.dbo.Reservation WHERE status = 'aktywna'";       //dataReader.GetString(0) -> id dataReader.GetString(1) -> idTimetable
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while(dataReader.Read())
            {
                string sql1 = "SELECT performanceDate FROM Kino.dbo.Timetable WHERE id = '" + dataReader.GetValue(1).ToString() + "'"; // dataReader1.GetValue(0) -> performanceDate
                SqlCommand cmd1 = new SqlCommand(sql1, cnn);
                SqlDataReader dataReader1 = cmd1.ExecuteReader();
                while(dataReader1.Read())
                {
                    double timeSpan = ((DateTime)dataReader1.GetValue(0) - DateTime.Now).TotalMinutes;
                    if (timeSpan < 30)
                    {
                        lbAnulRezerw++;
                        string sql2 = "UPDATE Kino.dbo.Reservation SET status = 'anulowana' WHERE id = '" + dataReader.GetValue(0).ToString() + "'";
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        SqlCommand cmd2 = new SqlCommand(sql2, cnn);

                        adapter.UpdateCommand = new SqlCommand(sql2, cnn);
                        adapter.UpdateCommand.ExecuteNonQuery();
                        cmd2.Dispose();

                        string sql3 = "SELECT id_Seat FROM Kino.dbo.Ticket WHERE id_Reservation = '" + dataReader.GetValue(0).ToString() + "'"; // dataReader3.GetString(0) -> id_Seat
                        SqlCommand cmd3 = new SqlCommand(sql3, cnn);
                        SqlDataReader dataReader3 = cmd3.ExecuteReader();
                        while (dataReader3.Read())
                        {
                            lbZwolnMiejsc++;
                            string sql4 = "UPDATE Kino.dbo.Seat SET status = 'wolne' WHERE id = '" + dataReader3.GetValue(0).ToString() + "'";
                            adapter = new SqlDataAdapter();
                            SqlCommand cmd4 = new SqlCommand(sql4, cnn);

                            adapter.UpdateCommand = new SqlCommand(sql4, cnn);
                            adapter.UpdateCommand.ExecuteNonQuery();
                            cmd4.Dispose();
                        }
                        dataReader3.Close();
                        cmd3.Dispose();
                    }
                }
                dataReader1.Close();
                cmd1.Dispose();
            }
            dataReader.Close();
            cmd.Dispose();
            if (lbAnulRezerw != 0)
                MessageBox.Show("Anulowanie rezerwacji zakończone. \nAnulowano " + lbAnulRezerw.ToString() + " rezerwacji. \nZwolniono" + lbZwolnMiejsc.ToString() + " miejsc.");
            else
                MessageBox.Show("Brak rezerwacji do anulowania");
        }
    }
}
