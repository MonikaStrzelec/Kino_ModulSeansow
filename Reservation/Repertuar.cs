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
    public partial class Repertuar : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Kino"].ConnectionString;
        SqlConnection cnn;
        public Repertuar()
        {
            InitializeComponent();

            cnn = new SqlConnection(connectionString);

            cnn.Open();
            refresh();            
        }

        private void Repertuar_Load(object sender, EventArgs e)
        {
           
        }

        void refresh()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter sqlFilmy = new SqlDataAdapter("SELECT title as Title,CONVERT(time,performanceDate,106) as Time,CONVERT(date,performanceDate,106) as Date FROM Kino.dbo.Movie INNER JOIN Kino.dbo.Performance ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance WHERE CONVERT(date, performanceDate, 102) = CONVERT(date, GETDATE(), 102); ", cnn);
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

        private void wróćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Klient form = new Klient();
            form.ShowDialog();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            SqlDataAdapter sqlFilmy = new SqlDataAdapter("SELECT Kino.dbo.Movie.title as Title, CONVERT(time, performanceDate, 106) as Time, CONVERT(date, performanceDate, 106) as Date FROM Kino.dbo.Movie INNER JOIN Kino.dbo.Performance ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance  WHERE convert(date, performanceDate, 102) = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "'" + " ORDER BY performanceDate;", cnn);
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

        //Przejście do formatki tworzenia rezerwacji
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRezerwacja form = new FormRezerwacja();
            form.ShowDialog();
        }

      
    }
}
