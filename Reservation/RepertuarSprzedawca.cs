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

namespace Reservation
{
    public partial class RepertuarSprzedawca : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Kino"].ConnectionString;
        SqlConnection cnn;
        public RepertuarSprzedawca()
        {
            InitializeComponent();
                       
            cnn = new SqlConnection(connectionString);

            cnn.Open();
            refresh();
        }

        private void RepertuarSprzedawca_Load(object sender, EventArgs e)
        {

        }

        void refresh()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter sqlFilmy = new SqlDataAdapter("SELECT title as Title,CONVERT(time,performanceDate,106) as Time,CONVERT(date,performanceDate,106) as Date, Kino.dbo.Timetable.id FROM Kino.dbo.Movie INNER JOIN Kino.dbo.Performance ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance WHERE CONVERT(date, performanceDate, 102) = CONVERT(date, GETDATE(), 102); ", cnn);
            DataTable filmy = new DataTable();
            sqlFilmy.Fill(filmy);
            dataGridView1.DataSource = filmy;
            if (dataGridView1.Rows.Count == 0 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Nie znaleziono seansów na dzisiaj!");
            }

            SqlDataAdapter sqlTytuły = new SqlDataAdapter("SELECT DISTINCT  title FROM Kino.dbo.Performance INNER JOIN Kino.dbo.Movie ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance WHERE CONVERT(date, performanceDate, 102) >= CONVERT(date, GETDATE(), 102) ORDER BY title;", cnn);
            DataTable tytuly = new DataTable();
            sqlTytuły.Fill(tytuly);
            foreach (DataRow dr in tytuly.Rows)
            {
                comboBox1.Items.Add(dr["title"].ToString());
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wróćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sprzedawca form = new Sprzedawca();
            form.ShowDialog();
        }

        //Zmiana wyświetlanych filmów po tytule
        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlFilmy = new SqlDataAdapter("SELECT Kino.dbo.Movie.title as Title, CONVERT(time,performanceDate,106) as Time, CONVERT(date,performanceDate,106) as Date FROM Kino.dbo.Movie INNER JOIN Kino.dbo.Performance ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance WHERE CONVERT(date, performanceDate, 102) >= CONVERT(date, GETDATE(), 102) AND title = '" + comboBox1.SelectedItem.ToString() + "'" + " ORDER BY performanceDate;", cnn);
            DataTable filmy = new DataTable();
            sqlFilmy.Fill(filmy);
            dataGridView1.DataSource = filmy;
        }

        //Zmiana wyświetlanych filmów po dacie
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlFilmy = new SqlDataAdapter("SELECT Kino.dbo.Movie.title as Title, CONVERT(time, performanceDate, 106) as Time, CONVERT(date, performanceDate, 106) as Date, Kino.dbo.Timetable.id FROM Kino.dbo.Movie INNER JOIN Kino.dbo.Performance ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance  WHERE convert(date, performanceDate, 102) = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "'" + " ORDER BY performanceDate;", cnn);
            DataTable filmy = new DataTable();
            sqlFilmy.Fill(filmy);
            dataGridView1.DataSource = filmy;
                       

            DateTime dzien, dzisiaj;
            dzien = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            dzisiaj = DateTime.Today;
            int result = DateTime.Compare(dzien, dzisiaj);
            if (result < 0 && dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Wybrano stary seans!");
            }
            else if (result < 0 && dataGridView1.Rows.Count == 0 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Nie znaleziono starych seansów!");
            }
            else if (dataGridView1.Rows.Count == 0 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Nie znaleziono seansów na dany dzień!");
            }
        }

        //Przejście do przeglądania rezerwacji
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrzegladRez form = new FormPrzegladRez();
            form.ShowDialog();
        }

        //Przejście do formatki sprzedaży biletu
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
                {
                    Reservation rezerwacja = new Reservation();
                    rezerwacja.Imie = "Klient";
                    rezerwacja.Nazwisko = "Klient";
                    rezerwacja.Status = "aktywna";
                    rezerwacja.Tytuł = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    rezerwacja.Data = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    rezerwacja.Email = "brak";
                    rezerwacja.IdTimetable = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
                    this.Hide();
                    Sala form = new Sala(rezerwacja);
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano filmu.");
            }
        }
    }
}
