using Kino.Domena;
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
    public partial class FormularzSzczegolyFilmy : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        private List<Timetable> timetableFilterList = null;

        KinoEntities context;
        private Timetable element;

        public FormularzSzczegolyFilmy(Timetable element)
        {
            this.element = element;
            InitializeComponent();
        }

        


        private void FormularzSzczegolyFilmy_Load(object sender, EventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //liknięcie w dowolnym miejscu w wierszu automatycznie zaznacza cały wiersz
            this.dataGridView1.MultiSelect = false;

            try
            {
                dataGridView1.AutoGenerateColumns = true;

                context = new KinoEntities(); //tworzenie obiekyu bazy danych
                context.Timetables.Load(); //ładowanie tabeli

                TimetableDomain domain = new TimetableDomain(this.element);// warstwa domenowa przygotująca wynik
                timetableDomainClassBindingSource.DataSource = new BindingList<TimetableDomain>() { domain };
            }
            catch
            {
                 MessageBox.Show("Sprawdź połączenie z bazą danych!");
            } 
        }


        private void button2_Click(object sender, EventArgs e)
        { //USUWANIE SEANSU

            string info = "Czy na pewno chcesz usunąć seans?";
            string caption = "UWAGA!";
            MessageBoxButtons przycisk = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(info, caption, przycisk);
            if (result == DialogResult.Yes)
            {
                context.Timetables.Remove(element);
                context.SaveChanges();
                this.Close();
            }
            //??? Refresh();
        }


        private void button1_Click(object sender, EventArgs e)
        { //DODAWANIE SEANSU

            DodawanieSeansow nowySeans = new DodawanieSeansow(); //WYWOŁYWANIE FORMATKI
            nowySeans.Parent = this;
            nowySeans.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        { //EDYCJA SEANSU

            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                //Timetable selectedElement = timetableFilterList[dataGridView1.SelectedRows[0].Index];
                DodawanieSeansow dodawanieSeansow = new DodawanieSeansow(element);
                dodawanieSeansow.Parent = this;
                dodawanieSeansow.Show();
            }
        }


        private void sprawdSprzedarz(Timetable timetable)
        {  //WARUNEK edycji, usuwania

         //   if (timetable.Performance1.idReservation.status == "aktywna")
         //if(true)
         //   {
         //       MessageBox.Show("Przykro mi, jest zarezerwowany bilet na ten seans");
         //   }

         //   else if (Timetable.performanceDate + Performance.Movie.movieTime + Performance.adsDuration = DateTime.Now)
         //   {
         //       MessageBox.Show("nie ma mozliwości edycji/usunięcia filmu. Własnie trwa");
         //   }

         //   else if (Timetable.performanceDate + Performance.Movie.movieTime + Performance.adsDuration < DateTime.Now)
         //   {
         //       MessageBox.Show("nie ma mozliwości edycji filmu bo już się odbył");
         //   }

         //   else (Timetable.performanceDate + Performance.Movie.movieTime + Performance.adsDuration > DateTime.Now)
         //   {
         //       //idź dalej
         //   }
        }
    }
}
