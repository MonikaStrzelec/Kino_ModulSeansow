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
            sprawdSprzedarz(element);

            string info = "Czy na pewno chcesz usunąć seans?";
            string caption = "UWAGA!";
            MessageBoxButtons przycisk = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(info, caption, przycisk);
            if (result == DialogResult.Yes)
            {
                using (var context = new KinoEntities())
                {
                    context.Configuration.AutoDetectChangesEnabled = true;
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Timetables.Remove(element);
                        context.Entry(element).State = EntityState.Deleted;
                        context.SaveChanges();
                        transaction.Commit();
                        this.Close();
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        { //DODAWANIE SEANSU- wywolanie formatki
            DodawanieSeansow nowySeans = new DodawanieSeansow(); //WYWOŁYWANIE FORMATKI
            nowySeans.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        { //EDYCJA SEANSU- wywolanie formatki
            sprawdSprzedarz(element);
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                //Timetable selectedElement = timetableFilterList[dataGridView1.SelectedRows[0].Index];
                DodawanieSeansow dodawanieSeansow = new DodawanieSeansow(element);
                dodawanieSeansow.Show();
            }
        }


        private bool czyMoznaUsunacLubEdytowac(Timetable t)
        {
            bool status = true;
            return status;
        }


        private bool sprawdSprzedarz(Timetable timetable)
        {  //WARUNEK edycji, usuwania

            bool status = true; ;
            context.Reservations.Load();
            List<Reservation> allReservations = context.Reservations.Where(r => r.idTimetable == timetable.id).ToList();
            if (allReservations.Count > 0)
            {
                foreach (Reservation r in allReservations)
                {
                    if (r.status == "aktywna" || r.status == "oplacona")
                    {
                        MessageBox.Show("Przykro mi, jest zarezerwowany bilet na ten seans. Nie możesz go usunąć/edytować.");
                        status = false;
                    }
                }
            }
            return status;
            //   if (timetable.Performance1.idReservation.status == "aktywna")
            //if(true)
            //   {
            //       
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
