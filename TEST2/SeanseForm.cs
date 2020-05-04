using Kino.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    public partial class SeanseForm : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        KinoEntities context;
        public SeanseForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //liknięcie w dowolnym miejscu w wierszu automatycznie zaznacza cały wiersz
            this.dataGridView1.MultiSelect = false;




            //    //uzyskanie wiersza wybranego z DataGridView1
            dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append(dataGridView1.SelectedRows[i].Index.ToString());
                }

                sb.Append("Zaznaczony: " + selectedRowCount.ToString());

            }




            //try
            //{ 
            //    BindingSource BindingSource1 = new BindingSource();
            //    SqlConnection conetionString = new SqlConnection (@"Server = tcp:kinosql.database.windows.net,1433; Initial Catalog = Kino; Persist Security Info = False; User ID = student; Password = Pa$$w0rd; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
            //    SqlDataAdapter seanseAdapter = new SqlDataAdapter("Select * FROM Timetable", conetionString);
            //    DataTable tabelaSeansow = new DataTable();

            //    seanseAdapter.Fill(tabelaSeansow);
            //    BindingSource1.DataSource = tabelaSeansow;
            //    BindingSource1.Filter = "";    //dane pobrane z listBox

            //    dataGridView2.DataSource = BindingSource1; //Ustaw źródło danych dla dataGridView2 na BindingSource1.

            //    dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;  //// Automatycznie zmienia rozmiar widocznych wierszy.
            //}
            //catch (SqlException)
            //{
            //    MessageBox.Show("Nie udało się połączyć z bazą");
            //    System.Threading.Thread.CurrentThread.Abort();
            //}

        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (monthCalendar1 == null && checkedListBox1.Items.Count == 0) {
                MessageBox.Show("nie wybrałeś żadnych filtrów ");
                return;
            }

            SelectionRange sr = new SelectionRange();
            sr.Start = DateTime.Parse (this.textBox1.Text);
            sr.End = DateTime.Parse(this.textBox2.Text);

            List<Timetable> timetableFilterList = null;

            this.monthCalendar1.SelectionRange = sr;

            if (monthCalendar1 != null)
            {
                if (sr.End != null)
                {
                    timetableFilterList = context.Timetables.Local.Where(timetable => timetable.performanceDate >= sr.Start && sr.End >= timetable.performanceDate).ToList();
                }
                else
                {
                    timetableFilterList = context.Timetables.Local.Where(timetable => timetable.performanceDate == sr.Start).ToList();
                }
            } 
            else 
            {

                timetableFilterList = context.Timetables.Local.ToList();
            }


            if (checkedListBox1.Items.Count > 0) {

                string dimParametersString = "";

                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {

                    dimParametersString += checkedListBox1.CheckedItems[x].ToString() + " ,";
                }

                timetableFilterList = timetableFilterList.Where(timetable => dimParametersString.Contains(timetable.Performance1.Hall1.Dim.name)).ToList();

            }

        bindingSource2.DataSource = new BindingList<Timetable>( timetableFilterList);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.monthCalendar1.ScrollChange = 1; //jeden miesiąc na raz za pomoca strzałek
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
            this.textBox2.Text = monthCalendar1.SelectionRange.End.Date.ToShortDateString();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.CheckOnClick = true; //zmiana by zaznaczało przy jednym kliknięciu

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {     
            //KinoEntities context = new KinoEntities();
            //var Timetable = from p in entities.Timetable
            //                select new
            //                {
            //                    TimetableId = p.TimetableID,
            //                    Name = p.Name,
            //                    PerformanceDate = p.PerformanceDate
            //                };
            //dataGridView1.DataSource = timetable.ToList();





            //uzyskanie wiersza wybranego z DataGridView2
            dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);

            int selectedRowCount = dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append(dataGridView2.SelectedRows[i].Index.ToString());
                }

                sb.Append("Zaznaczony: " + selectedRowCount.ToString());
            }
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dataGridView2.MultiSelect = false;



        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string[] parametry = { "2D", "3D", "VR" };
            checkedListBox1.Items.AddRange(parametry);

            try
            { 
                context = new KinoEntities(); //tworzenie obiekyu bazy danych


                context.Timetables.Load(); //ładowanie tabeli
                this.bindingSource1.DataSource = context.Timetables.Local.ToBindingList().Where(timetable => timetable.performanceDate >= DateTime.Now);  //wiązanie formatki z tabelą
            
                //context.DimsMovies.Load();
                //this.timetableBindingSource1.DataSource = context.DimsMovies.Local.ToBindingList();

                //context.Dims.Load();
                //this.timetableBindingSource1.DataSource = context.Dims.Local.ToBindingList();

                //context.Movies.Load();
                //this.timetableBindingSource1.DataSource = context.Movies.Local.ToBindingList();
            }
            catch
            {
                MessageBox.Show("Sprawdź połączenie z bazą danych!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //private void wywolanieFormatkiZSeansem(object sender, DataGridViewCellFormattingEventArgs e)
        //{

        //    if (sb.ToString != null)  //??

        //        if (e != null)
        //        {
        //            if (this.DataGridView.Columns[e.ColumnIndex].Name == "Release Date")
        //            {
        //                if (e.Value != null)
        //                {
        //                    try
        //                    {
        //                        e.Value = DateTime.Parse(e.Value.ToString()).ToLongDateString();
        //                        e.FormattingApplied = true;
        //                    }
        //                    catch (FormatException)
        //                    {
        //                        MessageBox.Show("{0} is not a valid date.", e.Value.ToString());
        //                    }
        //                }
        //            }
        //        }
        //}

    }
}
