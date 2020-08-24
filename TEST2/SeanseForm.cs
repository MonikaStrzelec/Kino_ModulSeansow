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
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    public partial class SeanseForm : Form, deleteCallbakck
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        private List<Timetable> timetableFilterList = null;
        KinoEntities context = new KinoEntities();
        Timetable selectedElement;


        public SeanseForm()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}


        private void button2_Click(object sender, EventArgs e)
        {   //FILTROWANIE seansów po DACIE i PARAMETRZE

            if (monthCalendar1 == null && checkedListBox1.CheckedItems.Count == 0)
            {
                return;
            }

            SelectionRange sr = new SelectionRange();

            try
            {
                sr.Start = DateTime.Parse(this.textBox1.Text);
                sr.End = DateTime.Parse(this.textBox2.Text);
            }
            catch
            {
                sr.Start = DateTime.Now;
            }

            if (sr.Start != null)
            {
                if (!sr.Start.Date.Equals(sr.End.Date))
                {
                    if (sr.End != null)
                    {
                        timetableFilterList = context.Timetables.Local.Where(timetable => timetable.performanceDate >= sr.Start && sr.End >= timetable.performanceDate).ToList();
                    }
                    else
                    {
                        timetableFilterList = context.Timetables.Local.Where(timetable => timetable.performanceDate.Equals( sr.Start)).ToList();
                    }
                }
                else {
                    timetableFilterList = context.Timetables.Local.Where(timetable => timetable.performanceDate.Date.Equals( sr.Start)).ToList();
                }
            }
            else
            {
                timetableFilterList = context.Timetables.Local.ToList();
            }

            if (checkedListBox1.CheckedItems.Count > 0)
            {
                string dimParametersString = "";
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    dimParametersString += checkedListBox1.CheckedItems[x].ToString() + " ,";
                }
                timetableFilterList = timetableFilterList.Where(timetable => dimParametersString.Contains(timetable.Performance1.Hall1.Dim.name)).ToList();
            }
            bindingSource2.DataSource = new BindingList<Timetable>(timetableFilterList);
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {   //oprogramowanie KALENDARZA
            this.monthCalendar1.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.monthCalendar1.ScrollChange = 2; //jeden miesiąc na raz za pomoca strzałek
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 2);
            this.monthCalendar1.MaxSelectionCount = 150; //max 150 dni można wybrać
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
            this.textBox2.Text = monthCalendar1.SelectionRange.End.Date.ToShortDateString();
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.CheckOnClick = true; //zmiana by zaznaczało przy jednym kliknięciu
        }


        private void Form1_Load(object sender, EventArgs e)
        {   //wpisanie parametrów i danych do DATAGREADVIEW
            string[] parametry = { "2D", "3D", "VR" };
            checkedListBox1.Items.AddRange(parametry);

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //liknięcie w dowolnym miejscu w wierszu automatycznie zaznacza cały wiersz
            this.dataGridView1.MultiSelect = false;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //Cały wiersz zostanie wybrany przez kliknięcie nagłówka jego wiersza lub komórki zawartej w tym wierszu.
            this.dataGridView2.MultiSelect = false;

            try
            {
                context = new KinoEntities(); //tworzenie obiekyu bazy danych
                 //ładowanie tabeli
                uzupelnianieDataGridView();
            }
            catch (Exception eror)
            {
                MessageBox.Show("Sprawdź połączenie z bazą danych!");
            }
        }

        private void uzupelnianieDataGridView()
        {
            context.Timetables.Load();
            this.timetableFilterList = context.Timetables.Local.ToBindingList().Where(timetable => timetable.performanceDate >= DateTime.Now).ToList();
            this.bindingSource1.DataSource = new BindingList<Timetable>(this.timetableFilterList);  //wiązanie formatki z tabelą
        }

        private void doubleClickViewOnDataGridView1(object sender, EventArgs e)
        {   //oprogramowany doubleClic
            moveToDetailsMovie(dataGridView1);
        }


        private void doubleClickViewOnDataGridView2(object sender, EventArgs e)
        {
            moveToDetailsMovie(dataGridView2);
        }


        private void moveToDetailsMovie(DataGridView dataGridView)
        {   //pobranie danych klikniętych i wywołanie formatki
            int selectedRowCount = dataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                 selectedElement = timetableFilterList[dataGridView.SelectedRows[0].Index];
                FormularzSzczegolyFilmy formularzSeanse = new FormularzSzczegolyFilmy(selectedElement,this);
                formularzSeanse.Show();
                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void deleteElement()
        {
            if (selectedElement != null) {

                
                    context.Configuration.AutoDetectChangesEnabled = true;

                    context.Timetables.Attach(selectedElement);

                context.Entry(selectedElement).State = EntityState.Deleted;
                context.SaveChanges();


                uzupelnianieDataGridView();

            }
        }
    }
}
