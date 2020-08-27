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
    public partial class FormPrzegladRez : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Kino"].ConnectionString;
        SqlConnection cnn;
        

        public FormPrzegladRez()
        {
            InitializeComponent();

            cnn = new SqlConnection(connectionString);
            refresh();
        }

        private void wsteczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sprzedawca form = new Sprzedawca();
            form.ShowDialog();
        }

        void refresh()
        {
            dataGridView1.Rows.Clear();
            SqlDataAdapter sqlRez = new SqlDataAdapter("SELECT [Kino].[dbo].[Reservation].[id],[status],[lastName] FROM [Kino].[dbo].[Reservation] INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Reservation.idTimetable = Kino.dbo.Timetable.id WHERE convert(date, performanceDate, 102) = CONVERT(date, GETDATE(), 102);", cnn);
            DataTable rezerw = new DataTable();
            sqlRez.Fill(rezerw);
            dataGridView1.DataSource = rezerw;
            if (dataGridView1.Rows.Count == 0 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Nie znaleziono rezerwacji na dzisiaj!");
            }
        }

        private void FormPrzegladRez_Load(object sender, EventArgs e)
        {

        }
        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Wyświetlanie rezerwacji na wybrany dzień
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sqlRez = new SqlDataAdapter("SELECT [Kino].[dbo].[Reservation].[id],[status],[lastName] FROM [Kino].[dbo].[Reservation] INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Reservation.idTimetable = Kino.dbo.Timetable.id WHERE convert(date, performanceDate, 102) = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "'" + " ORDER BY performanceDate;", cnn);
            DataTable rezerwacje = new DataTable();
            sqlRez.Fill(rezerwacje);
            dataGridView1.DataSource = rezerwacje;

            DateTime dzien, dzisiaj;
            dzien = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy/MM/dd"));
            dzisiaj = DateTime.Today;
            int result = DateTime.Compare(dzien, dzisiaj);
            if (result < 0 && dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Wybrano stare rezerwacje!");
            }
            else if (result < 0 && dataGridView1.Rows.Count == 0 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Nie znaleziono starych rezerwacji!");
            }
            else if (dataGridView1.Rows.Count == 0 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Nie znaleziono rezerwacji na dany dzień!");
            }


        }

        //Otwarcie formatki zatwierdzania płatności
        private void button2_Click_1(object sender, EventArgs e)
        {
            int idReserv;            
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
                {
                    idReserv = (int)dataGridView1.SelectedCells[0].Value;                                   
                    this.Hide();
                    ZatwierdzPlatnosc form = new ZatwierdzPlatnosc(idReserv);
                    form.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("Wybierz rezerwację!");
            }

        }

        //Wyświetlenie szczegółów rezerwacji
        private void button3_Click(object sender, EventArgs e)
        {
            int idReserv;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
                {
                   
                    idReserv = (int)dataGridView1.SelectedCells[0].Value;
                    SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM Reservation WHERE id = '" + idReserv.ToString() + "'", cnn);
                    DataTable rezerwacje = new DataTable();
                    sql.Fill(rezerwacje);
                    dataGridView1.DataSource = rezerwacje;

                }
                 
            }
            else
            {
                MessageBox.Show("Wybierz rezerwację!");
            }

        }
    }
}
