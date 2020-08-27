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

namespace Reservation
{
    public partial class FormRezerwacja : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Kino"].ConnectionString;
        SqlConnection cnn;
        Reservation rezerwacja = new Reservation();

        public FormRezerwacja()
        {
            InitializeComponent();            

            cnn = new SqlConnection(connectionString);

            cnn.Open();
            refresh();
        }

        private void FormRezerwacja_Load(object sender, EventArgs e)
        {

        }

        void refresh()
        {
            SqlDataAdapter sqlTytuły = new SqlDataAdapter("SELECT DISTINCT  title FROM Kino.dbo.Performance INNER JOIN Kino.dbo.Movie ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance WHERE CONVERT(date, performanceDate, 102) >= CONVERT(date, GETDATE(), 102) ORDER BY title;", cnn);
            DataTable tytuly = new DataTable();
            sqlTytuły.Fill(tytuly);
            foreach (DataRow dr in tytuly.Rows)
            {
                comboBox1.Items.Add(dr["title"].ToString());
            }

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            button1.Enabled = false;
            comboBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

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

        //Imię wprowadzone
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox3.Enabled = true;
            }
        }

        //Nazwisko wprowadzone
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox2.Enabled = true;
                button1.Enabled = true;
            }
        }

        //Email wprowadzony
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {                
                comboBox1.Enabled = true;
            }
        }

        //Wybrano film
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null)
            {
                comboBox2.Items.Clear();
                comboBox2.Enabled = true;
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT CONVERT(date, performanceDate, 106) AS date FROM Kino.dbo.Performance INNER JOIN Kino.dbo.Movie ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance WHERE CONVERT(date, performanceDate, 102) >= CONVERT(date, GETDATE(), 102) AND title = '" + comboBox1.SelectedItem.ToString() + "'" + " ORDER BY performanceDate", cnn);
                DataTable dni = new DataTable();
                sqlData.Fill(dni);

                foreach (DataRow dr in dni.Rows)
                {
                    comboBox2.Items.Add(dr["date"].ToString());
                }
            }
        }

        //Wybrano dzień
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                comboBox3.Items.Clear();
                comboBox3.Enabled = true;

                SqlDataAdapter sqlGodz = new SqlDataAdapter("SELECT CONVERT(time, performanceDate, 106) AS godz FROM Kino.dbo.Performance INNER JOIN Kino.dbo.Movie ON Kino.dbo.Movie.id = Kino.dbo.Performance.movie INNER JOIN Kino.dbo.Timetable ON Kino.dbo.Performance.id = Kino.dbo.Timetable.performance WHERE CONVERT(date, performanceDate, 102) >= CONVERT(date, GETDATE(), 102) AND title = '" + comboBox1.SelectedItem.ToString() + "'" + "AND CONVERT(date, performanceDate, 102) = '" + comboBox2.SelectedItem.ToString() + "'", cnn);
                DataTable godz = new DataTable();

                sqlGodz.Fill(godz);

                foreach (DataRow dr in godz.Rows)
                {
                    comboBox3.Items.Add(dr["godz"].ToString());
                }
            }

        }

        //Wybrano godzinę
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        //Zakończenie podawania danych i przejście do wyboru sali
        private void button1_Click(object sender, EventArgs e)
        {
            //Obsługa wyjątków we wprowadzanych danych
            //Przypisanie danych do klasy Reservation w celu użycia ich w kolejnych formatkach (Sala, ZatwierdzRezerwacje)
            var hasNumber = new Regex(@"[0-9]+"); //Imię i Nazwisko nie mogą mieć liczb
            var hasSpecialChar = new Regex(@"[\| !#$%&/()=?»«@£§€{}.-;'<>_,]+"); //Imię i Nazwisko nie mogą mieć dziwnych znaków

            if (!this.textBox2.Text.Contains('@') || !this.textBox2.Text.Contains('.'))
            {
                MessageBox.Show("Wprowadź poprawny adres email", "Niepoprawny adres email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (hasNumber.IsMatch(textBox1.Text) || hasSpecialChar.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Wpisz poprawne imię!", "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (hasNumber.IsMatch(textBox3.Text) || hasSpecialChar.IsMatch(textBox3.Text))
            {
                MessageBox.Show("Wpisz poprawne nazwisko!", "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Podaj wszystkie dane!", "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime dzien, dzisiaj, time, godzina = DateTime.Now;
                dzisiaj = DateTime.Today;
                time = DateTime.Now;

                rezerwacja.Imie = textBox1.Text;
                rezerwacja.Nazwisko = textBox3.Text;
                rezerwacja.Email = textBox2.Text;
                rezerwacja.Tytuł = comboBox1.SelectedIndex.ToString();
                rezerwacja.Dzien = comboBox2.SelectedIndex.ToString();
                godzina = DateTime.Parse(comboBox3.SelectedItem.ToString());
                dzien = DateTime.Parse(comboBox2.SelectedItem.ToString());
                int result = DateTime.Compare(dzien, dzisiaj);
                if (result == 0)
                {
                    int resultgodz = DateTime.Compare(godzina, time);
                    if (resultgodz < 0)
                    {
                        MessageBox.Show("Seans już się odbył!");
                    }
                }
                else
                rezerwacja.GodzinaRozp = double.Parse(comboBox3.SelectedIndex.ToString());
                rezerwacja.Status = "aktywna";

                string sql, output = "";
                int intoutput = 0;
                SqlCommand command;
                SqlDataReader dataReader;

                sql = "SELECT id FROM kino.dbo.Movie WHERE title = '" + comboBox1.Text + "'";
                command = new SqlCommand(sql, cnn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    output = dataReader.GetValue(0).ToString();
                }

                dataReader.Close();
                command.Dispose();

                sql = "SELECT id FROM kino.dbo.Performance WHERE movie = '" + output + "'";
                command = new SqlCommand(sql, cnn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    output = dataReader.GetValue(0).ToString();
                }


                dataReader.Close();
                command.Dispose();
                string czasSeansu = dzien.Date.ToString().Remove(11, 8) + godzina.TimeOfDay.ToString();

                sql = "SELECT id FROM kino.dbo.Timetable WHERE performance = '" + output + "' AND performanceDate = '" + czasSeansu + "'";
                command = new SqlCommand(sql, cnn);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    intoutput = (int)dataReader.GetValue(0);
                }
                rezerwacja.IdTimetable = intoutput;

                dataReader.Close();
                command.Dispose();

                
                SqlDataAdapter sqlAda = new SqlDataAdapter("SELECT id FROM Kino.dbo.Timetable WHERE CONVERT(date, performanceDate, 102) = '" + comboBox2.SelectedItem.ToString() + "'" + "AND CONVERT(time, performanceDate, 102) = '" + comboBox3.SelectedItem.ToString() + "'", cnn);
                DataTable seans = new DataTable();
                sqlAda.Fill(seans);
                foreach (DataRow dr in seans.Rows)
                {
                    if (seans.Rows.Count > 0)
                    {
                        DataRow row = seans.Rows[0];
                        rezerwacja.IdData = row.Field<int>("id");

                    }
                }
                rezerwacja.Data = czasSeansu;
                rezerwacja.Tytuł = comboBox1.SelectedItem.ToString();
                this.Hide();
                Sala form = new Sala(rezerwacja);
                form.ShowDialog();
            }
        }
    }
}
