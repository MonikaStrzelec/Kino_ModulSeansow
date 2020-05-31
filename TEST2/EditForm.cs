using Kino.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    public partial class EditForm : Form
    {
        EditParametersForm edycjaParametrow = null;
        KinoEntities context;


        public EditForm(Timetable timetable)
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {// EDYCJA PARAMETRÓW

            if (edycjaParametrow == null)
            {
                edycjaParametrow.Show();
                edycjaParametrow.BringToFront();
            }
            else
                edycjaParametrow.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        { //ZAMKNIĘCIE FORMULARZA
     
            string info = "Nie edytowałeś seansu, na pewno chcesz zamknąć?";
            string caption = "UWAGA!";
            MessageBoxButtons przycisk = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(info, caption, przycisk);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        { //EDYCJA SEANSU- zapis

            DateTime dataICzasRozpoczecia = pobierzDzienIGodzine();
            
            try
            {
                context = new KinoEntities();

                do
                {
                    Performance editPerformance = new Performance();
                    editPerformance.movie = 1;
                    editPerformance.hall = 2;
                   //editPerformance.adsDuration = '00:00:12';
                    context.Performances.Add(editPerformance);
                    context.SaveChanges();
                }

                while (monthCalendar1 != null);
                {
                    

                    if (dataICzasRozpoczecia > DateTime.Now)
                    { 
                        Timetable editTimetable = new Timetable();
                        editTimetable.performanceDate = dataICzasRozpoczecia;
                        context.Timetables.Add(editTimetable);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Musisz wybrać przyszłą datę!");
                    }
                }
                MessageBox.Show("EDYCJA powiodła się");
            }
            catch
            {
                MessageBox.Show("edycja nie powiodła się");

                if (dataICzasRozpoczecia <= DateTime.Now)
                {
                    MessageBox.Show("Musisz wybrać przyszłą datę!");
                }


                    //if else zły format daty
                    //if else nieistniejące id
                    //else nie wprowadziłeś żadnych zmian
            }
            
        }

        private DateTime pobierzDzienIGodzine()
        {   //pobieranie daty i godziny

            String dzien = monthCalendar1.SelectionRange.Start.Date.ToString().Split(' ')[0].Replace('.', '/');
            String godzina = dateTimePicker1.Value.ToString().Split(' ')[1];

            return DateTime.Parse(dzien + " " + godzina);
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

            try
            {
                dateTimePicker1.Format = DateTimePickerFormat.Time;
                dateTimePicker1.ShowUpDown = true;
            }
            catch
            {
                MessageBox.Show("Sprawdź połączenie z bazą danych!");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.ScrollChange = 1;
        }
    }
}
