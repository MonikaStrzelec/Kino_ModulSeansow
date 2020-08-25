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
        private deleteCallbakck callback;

        public FormularzSzczegolyFilmy(Timetable element, deleteCallbakck callbakck)
        {
            this.element = element;
            this.callback = callbakck;
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
            if (sprawdSprzedarz(element) && czyMoznaUsunacLubEdytowac())
            {
                string info = "Czy na pewno chcesz usunąć seans?";
                string caption = "UWAGA!";
                MessageBoxButtons przycisk = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(info, caption, przycisk);
                if (result == DialogResult.Yes)
                {
                    callback.deleteElement();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Przykro mi, jest zarezerwowany bilet na ten seans lub seans jest w trakcie projekcji. Nie możesz go usunąć/edytować.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        { //DODAWANIE SEANSU- wywolanie formatki
            DodawanieSeansow nowySeans = new DodawanieSeansow(); //WYWOŁYWANIE FORMATKI
            nowySeans.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        { //EDYCJA SEANSU- wywolanie formatki
            if (sprawdSprzedarz(element) && czyMoznaUsunacLubEdytowac())
            {
                int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    //Timetable selectedElement = timetableFilterList[dataGridView1.SelectedRows[0].Index];
                    DodawanieSeansow dodawanieSeansow = new DodawanieSeansow(element);
                    dodawanieSeansow.Show();
                }
            }
            else {
                MessageBox.Show("Przykro mi, jest zarezerwowany bilet na ten seans lub seans jest w trakcie projekcji. Nie możesz go usunąć/edytować.");
            }
        }


        private bool czyMoznaUsunacLubEdytowac()
        {
            bool status = true;

            DateTime zakonczenieSeansu = element.performanceDate.Add(element.Performance1.Movie1.movieTime).Add(element.Performance1.adsDuration);
            if (element.performanceDate <= DateTime.Now && DateTime.Now <= zakonczenieSeansu) {
                status = false;
            }
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
                        status = false;
                    }
                }
            }
            return status;
        }
    }

   public  interface  deleteCallbakck
    {
         void deleteElement();
    }
}
