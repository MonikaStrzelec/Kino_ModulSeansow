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
    public partial class ZatwierdzPlatnosc : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Kino"].ConnectionString;
        SqlConnection cnn;
        int idReservZatwPlat;
        public ZatwierdzPlatnosc(int idReserv)
        {
            idReservZatwPlat = idReserv;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            InitializeComponent();

            string sql = "SELECT firstName, lastName FROM Kino.dbo.Reservation WHERE id = '" + idReserv.ToString() + "'";
            SqlCommand cmd1 = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = cmd1.ExecuteReader();
            while(dataReader.Read())
            {
                if (dataReader.GetString(0) == "Klient")
                    label3.Text = "Klient";
                else
                    label3.Text = dataReader.GetString(0) + " " + dataReader.GetString(1);
            }
            cmd1.Cancel();
            dataReader.Close();

            decimal oplata = -1;
            sql = "SELECT price FROM Kino.dbo.Ticket WHERE id_Reservation = '" + idReserv.ToString() + "'";
            cmd1 = new SqlCommand(sql, cnn);
            dataReader = cmd1.ExecuteReader();
            while (dataReader.Read())
            {
                oplata = oplata + (decimal)dataReader.GetValue(0);
            }
            cmd1.Cancel();
            dataReader.Close();

            label4.Text = oplata.ToString() + "zł";
        }

        //Zatwierdzenie płatności
        private void button1_Click(object sender, EventArgs e)
        {
            string sql3 = "UPDATE Kino.dbo.Reservation SET status = 'oplacona' WHERE id = '" + idReservZatwPlat + "'";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd3 = new SqlCommand(sql3, cnn);

            adapter.UpdateCommand = new SqlCommand(sql3, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            cmd3.Dispose();

            MessageBox.Show("Płatność zatwierdzona.");
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        //Anulowanie płatności
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz anulować?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Płatność anulowana.");
                this.Hide();
                FormPrzegladRez form = new FormPrzegladRez();
                form.ShowDialog();

            }            
        }

        private void ZatwierdzPlatnosc_Load(object sender, EventArgs e)
        {

        }
    }
}
