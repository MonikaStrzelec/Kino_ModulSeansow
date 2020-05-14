using Kino.Domena;
using Kino.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    public partial class DodawanieSeansow : Form
    {
        KinoEntities context;

        private List<Movie> tytulyFilmow = null;
        private List<Hall> nazwySal = null;
        private int liczbaSeansow = 0;
        private int liczbaPerformansow = 0;

        private List<DomainSeans> seanse = new List<DomainSeans>();
        public DodawanieSeansow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { //DODWANIE SEANSU

            DateTime dataICzasRozpoczecia = pobierzDzienIGodzine();
            int idSali = comboBox1.SelectedIndex;
            int idFilmu = comboBox2.SelectedIndex;

            Performance performance = new Performance() { movie = idFilmu, hall = idSali, adsDuration = TimeSpan.FromMinutes((double)numericUpDown1.Value) };
            dodajPerformans(performance); //dodawanie seansu


            dodajSeans(new Timetable() { performance = performance.id, performanceDate = dataICzasRozpoczecia }); //dodawanie seansu do repertuaru

            try
            {
            //    Performance seansNowy = new Performance();
            //    if (comboBox1.SelectedIndex != -1)
            //    {
            //     //   seansNowy.movie = comboBox1.SelectedValue;

            //    }
            //     else
            //    {
            //        MessageBox.Show("Nie wybrałeś tytułu filmu!");
            //    }

            //    if (comboBox2.SelectedIndex != -1)
            //    {
            //        //if // jeślei parametr film == parametr movis
            //        //{
            //        //    seansNowy.hall = comboBox2.SelectedValue;
            //        //}
            //        //else
            //        //{
            //        //    MessageBox.Show("Musisz wybrać inną salę! ta nie wyświetli typ filmu jaki chcesz");
            //        //}

            //    }
            //    else
            //    {
            //        MessageBox.Show("Nie wybrałeś sali!");
            //    }

            //    SelectionRange sr = new SelectionRange();
            //    sr.Start = DateTime.Parse(this.textBox1.Text);
            //    if (sr.Start != null)
            //    {

            //    }
            //    else
            //    {
            //        MessageBox.Show("Nie wybrałeś daty seansu");
            //    }

            //    //NO I CZAS NA GODZINY...


            //    DodawanieSeansow dodawanie = new DodawanieSeansow();
            ////    seansNowy.adsDuration = dodawanie(sumTimeParameters());

            //    context.Performances.Add(seansNowy); //dodajemy obiekt do tabeli
            //    context.SaveChanges(); //zapisujemy zmiany
                }

            catch
            {

                MessageBox.Show("Czy na pewno nie chcesz dodać seansu?");
            }
            //// Definiujemy nowy obiekt do dodania
            //Department dp = new Department();
            //dp.GroupName = "Sample Group Name";
            //dp.ModifiedDate = DateTime.Now;
            //dp.Name = "Sample Name";
            //// Dodajemy obiekt do naszej tabeli
            //context.Department.Add(dp);
            //// Zapisujemy zmiany
            //context.SaveChanges();


        }

        private void DodawanieSeansow_Load(object sender, EventArgs e)
        {

            try
            {
                context = new KinoEntities(); //tworzenie obiekyu bazy danych


                context.Configuration.AutoDetectChangesEnabled = false; // point 1
                context.Configuration.ValidateOnSaveEnabled = false; // point 6
                context.Performances.Load();
                context.Movies.Load(); //ładowanie tabeli
                context.Halls.Load(); //ładowanie tabeli
                context.Timetables.Load(); //ładowanie tabeli

                this.liczbaSeansow = context.Timetables.Local.Count;
                this.liczbaPerformansow = context.Performances.Local.Count;


                dateTimePicker1.Format = DateTimePickerFormat.Time;
                dateTimePicker1.ShowUpDown = true;

                //context.Movies.Load();
                //this.timetableBindingSource1.DataSource = context.Movies.Local.ToBindingList();
            }
            catch
            {
                MessageBox.Show("Sprawdź połączenie z bazą danych!");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar1.ScrollChange = 1; //jeden miesiąc na raz za pomoca strzałek
            this.monthCalendar1.MaxSelectionCount = 1; //max 150 dni można wybrać
            //this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            //this.textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
        }

        private DateTime pobierzDzienIGodzine()
        {
            String dzien = monthCalendar1.SelectionRange.Start.Date.ToString().Split(' ')[0].Replace('.', '/');
            String godzina = dateTimePicker1.Value.ToString().Split(' ')[1];

            return DateTime.Parse(dzien + " " + godzina);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // filtrujFilmy();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // filtrujFilmy();
        }
        private void filtrujFilmy()
        {
            if (comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1)
            {

                string tytulFilmu = tytulyFilmow[comboBox1.SelectedIndex].title;
                string nazwaSali = nazwySal[comboBox2.SelectedIndex].name;


                //radScheduler1.DataSource = context.Timetables.Where(timetable => timetable.Performance1.Movie1.title.Equals(tytulFilmu) && timetable.Performance1.Hall1.name.Equals(nazwaSali)).ToList().ConvertAll(t => new DomainSeans(t));
                Timetable timetable = new Timetable();
            }
        }


        void dodajSeans(Timetable timetable)
        {
            context.Timetables.Local.Add(timetable);
            context.SaveChanges();
        }

        void dodajPerformans(Performance p)
        {
            try
            {
                liczbaPerformansow++;
                p.id = liczbaPerformansow;
                context.Performances.Local.Add(p);
                context.SaveChanges();
                MessageBox.Show("Dodano nowy seans");
            }
            catch
            {
                MessageBox.Show("Nie udało się dodać nowego seansu");
            }
        }
        private void none(object sender, EventArgs e) { }
            
        private void button1_Click_1(object sender, EventArgs e)
        {
            string info = "Nie dodałeś seansu, na pewno chcesz zamknąć?";
            string caption = "UWAGA!";
            MessageBoxButtons przycisk = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(info, caption, przycisk);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { //2D Movies.Dim
                string dimParametersString = "2D";

                this.tytulyFilmow = context.DimsMovies.Local
                    .Where(dimMovie => dimMovie.Dim1.name.Equals(dimParametersString))
                    .Select(dim => dim.Movie1)
                    .Where(movies => movies.movieState == 2 || movies.movieState == 3).ToList();
                this.movieBindingSource.DataSource = new BindingList<Movie>(this.tytulyFilmow);  //wiązanie formatki z tabelą


                this.nazwySal = context.Halls.Local.Where(hall => hall.Dim.name.Equals(dimParametersString)).ToList();
                this.hallBindingSource.DataSource = new BindingList<Hall>(this.nazwySal);
            }
            else if (radioButton2.Checked == true)
            { //3D Movies.Dim
                string dimParametersString = "3D";

                this.tytulyFilmow = context.DimsMovies
                    .Where(dims => dims.Dim1.name.Equals(dimParametersString))
                    .Select(dim => dim.Movie1)
                    .Where(movies => movies.movieState == 2 || movies.movieState == 3).ToList();
                this.movieBindingSource.DataSource = new BindingList<Movie>(this.tytulyFilmow);  //wiązanie formatki z tabelą


                this.nazwySal = context.Halls.Local.Where(hall => hall.Dim.name.Equals(dimParametersString)).ToList();
                this.hallBindingSource.DataSource = new BindingList<Hall>(this.nazwySal);
            }
            else if (radioButton3.Checked == true)
            { //VR Movies.Dim
                string dimParametersString = "VR";

                this.tytulyFilmow = context.DimsMovies
                    .Where(dims => dims.Dim1.name.Equals(dimParametersString))
                    .Select(dim => dim.Movie1)
                    .Where(movies => movies.movieState == 2 || movies.movieState == 3).ToList();
                this.movieBindingSource.DataSource = new BindingList<Movie>(this.tytulyFilmow);  //wiązanie formatki z tabelą


                this.nazwySal = context.Halls.Local.Where(hall => hall.Dim.name.Equals(dimParametersString)).ToList();
                this.hallBindingSource.DataSource = new BindingList<Hall>(this.nazwySal);
            }
            else
            {
                MessageBox.Show("Zaznacz parametr filmu! Bez niego nie utworzysz seansu!");
            }
        }
    }
}
