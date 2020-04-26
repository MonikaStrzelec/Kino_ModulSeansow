using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST2
{
    public partial class Form1 : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        KinoEntities context;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  SqlConnection polaczeniezBaza = new SqlConnection(@"Server = tcp:kinosql.database.windows.net,1433; Initial Catalog = Kino; Persist Security Info = False; User ID = student; Password = Pa$$w0rd; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30", polaczeniezBaza);  
          //  //Zmienna typu SqlConnection służy do ustanowienia połączenia z bazą danych.

          //  polaczeniezBaza.Open();
          //  SqlCommand komenda = new SqlCommand("Select * FROM Timetable", polaczeniezBaza);  //zbudowanie naszej instrukcji „select”, która będzie używana do odczytu danych z bazy danych.


          //  SqlDataAdapter sda = new SqlDataAdapter();
          //  DataTable dt = new DataTable();
          //  sda.Fill(dt);
          //  BindingSource wiazanie = new BindingSource();

          //  wiazanie.DataSource = dt;
          //  dataGridView1.DataSource = dt;

          //  sda.Update(dt);

          ////  SqlDataReader czytnikDanych;
          // // czytnikDanych = komenda.ExecuteReader();

          ////  czytnikDanych.Close();



          //  komenda.Dispose();
          //  polaczeniezBaza.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e == null)
            {
                //MessageBox.Show("Brak seansów do wczytania", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //liknięcie w dowolnym miejscu w wierszu automatycznie zaznacza cały wiersz
            this.dataGridView1.MultiSelect = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //while (monthCalendar1 != null)
            //{
            //    SqlConnection polaczeniezBaza = new SqlConnection(@"Server = tcp:kinosql.database.windows.net,1433; Initial Catalog = Kino; Persist Security Info = False; User ID = student; Password = Pa$$w0rd; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30", polaczeniezBaza);
            //    polaczeniezBaza.Open();
            //    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Timetable WHERE perfotmanceDate BETWEEN projektStart AND projektStop " , polaczeniezBaza);
                
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    dataGridView2.DataSource = dt;
            //}

            //while (checkedListBox1.CheckedItems != null)
            ////for (int i=0; i< checkedListBox1.CheckedItems.Count; i++)
            //{
            //    SqlConnection polaczeniezBaza = new SqlConnection(@"Server = tcp:kinosql.database.windows.net,1433; Initial Catalog = Kino; Persist Security Info = False; User ID = student; Password = Pa$$w0rd; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30", polaczeniezBaza);
            //    polaczeniezBaza.Open();
            //    SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Dim WHERE nazwa = listaWarunkow ", polaczeniezBaza);
                
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    dataGridView2.DataSource = dt;
            //}

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //DateTime projektStart = new DateTime();
            //DateTime projektStop = new DateTime();
            //monthCalendar1.CalendarDimensions = new System.Drawing.Size(3,2);
            //monthCalendar1.SelectionStart = projektStart;
            //monthCalendar1.SelectionEnd = projektStop;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (this.checkedListBox1.Items.Contains(this.checkedListBox1.Text)) //czy coś zawiera
            {
                InitializeComponent();
                List<string> listaWarunkow = new List<string>();
                checkedListBox1.Items.AddRange(listaWarunkow.ToArray());
                checkedListBox1.CheckOnClick = true; //zmiana by zaznaczało przy jednym kliknięciu
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.MultiSelect = false;
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context = new KinoEntities();
            context.Timetables.Load();
            this.timetableBindingSource1.DataSource = context.Timetables.Local.ToBindingList();
            this.timetableBindingSource1.DataSource = context.Timetables.Local.ToBindingList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
