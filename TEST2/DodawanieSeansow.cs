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
        private int ostatniIDperformance;
        private int idWybranegoSeansu = 0;
        private int idWybranejSali = 0;

        private string dimParametersString = "";

        private const int iloscJednostek = 288;// dzielimy 24h na 288 jednostek 5 minutowych

        private bool[] zajetoscTablica = new bool[iloscJednostek];

        private List<DomainSeans> seanse = new List<DomainSeans>();


        public DodawanieSeansow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  //DODAWANIA seansu

            DateTime dataICzasRozpoczecia = pobierzDzienIGodzine();
            int ostatniIDperformance = context.Performances.OrderBy(p => p.id).ToList().Last().id;
            int ostatniIdTimetable = context.Timetables.OrderBy(p => p.id).ToList().Last().id;

            if (idWybranegoSeansu > 0 && idWybranejSali > 0)
            {
                Performance performance = new Performance() { id = ++ostatniIDperformance, movie = idWybranegoSeansu, hall = idWybranejSali, adsDuration = TimeSpan.FromMinutes((double)numericUpDown1.Value) };
                dodajPerformans(performance); //dodawanie seansu
                context.SaveChanges(); //zapisujemy zmiany

                dodajSeans(new Timetable() { id = ++ostatniIdTimetable, performance = ostatniIDperformance, performanceDate = dataICzasRozpoczecia }); //dodawanie seansu do repertuaru
                context.SaveChanges(); //zapisujemy zmiany       // context.SaveChanges(); //zapisujemy zmiany

                MessageBox.Show("SUKCES");
                this.Close();
            }
            else
            {
                if (monthCalendar1 == null)
                {
                    MessageBox.Show("Nie wybrałeś daty seansu");
                }

                else if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Nie wybrałeś tytułu filmu!");
                }

                else if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Nie wybrałeś sali");
                }

                else
                {
                    MessageBox.Show("Nie wybrano zadnej wartosci");
                }
            }
        }

        private void pobierzWszystkieSeanseZFiltrami( String parametr, int idFilmu, int idSali, DateTime data) {

          List<Timetable> przefiltrowaneSeanse =   context.Timetables.Where(t => 
          t.Performance1.Hall1.Dim.name.Equals(parametr) &&
          DbFunctions.TruncateTime(t.performanceDate) == data.Date &&
          t.Performance1.movie == idFilmu &&
          t.Performance1.hall == idSali)
                .ToList();

            this.domainSeansBindingSource.DataSource = new BindingList<DomainSeans>( przefiltrowaneSeanse.ConvertAll(s => new DomainSeans(s)) ) ;
          dodajListeSeansowDoTablicy(przefiltrowaneSeanse);
        }

        private void dodajListeSeansowDoTablicy(List<Timetable> seanse) {

            foreach (Timetable seans in seanse) {
                dodajSeansDoTablicy(seans);
            }
        
        }

        private void dodajSeansDoTablicy(Timetable timetable) {

            TablicaWartosciOdDo odIDo = new TablicaWartosciOdDo(timetable);

            for (int i = odIDo.IndexPoczatkowy; i <= odIDo.IndexKoncowy; i++) {
                zajetoscTablica[i] = true;
            }


        }

        private void czyscTabliceZajetosci() {

            for (int i =0; i < zajetoscTablica.Length; i++ ) {
                zajetoscTablica[i] = false;
            }
        }

        private bool czyMoznaDodacSeans(TablicaWartosciOdDo odIDo) {

            for (int i = odIDo.IndexPoczatkowy; i <= odIDo.IndexKoncowy; i++)
            {
                if (zajetoscTablica[i]) return false;
            }
            return true;
        }

        private void DodawanieSeansow_Load(object sender, EventArgs e)
        {   //oprogramowanie formatki

            try
            {
                context = new KinoEntities(); //tworzenie obiekyu bazy danych

                context.Configuration.AutoDetectChangesEnabled = false; // point 1
                context.Configuration.ValidateOnSaveEnabled = false; // point 6
                context.Performances.Load(); //ładowanie tabeli
                context.Movies.Load(); //ładowanie tabeli
                context.Halls.Load(); //ładowanie tabeli
                context.Timetables.Load(); //ładowanie tabeli

                this.liczbaSeansow = context.Timetables.Local.Count;
                this.liczbaPerformansow = context.Performances.Local.Count;
                this.ostatniIDperformance = context.Performances.OrderBy(p => p.id).ToList().Last().id;


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
            this.monthCalendar1.MaxSelectionCount = 1; //max 1 dzien można wybrać
        }


        private DateTime pobierzDzienIGodzine()
        {
            String dzien = monthCalendar1.SelectionRange.Start.Date.ToString().Split(' ')[0].Replace('.', '/');
            String godzina = dateTimePicker1.Value.ToString().Split(' ')[1];

            return DateTime.Parse(dzien + " " + godzina);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem;
            if (item != null)
            {
                idWybranegoSeansu = ((Movie)(item)).id;
            }
            filtrujFilmy();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = comboBox2.SelectedItem;
            if (item != null)
            {
                idWybranejSali = ((Hall)(item)).id;
                pobierzWszystkieSeanseZFiltrami(dimParametersString,idWybranegoSeansu,idWybranejSali, monthCalendar1.SelectionRange.Start.Date);
            }
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
            using (var context = new KinoEntities())
            {
                context.Configuration.AutoDetectChangesEnabled = true;
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Configuration.AutoDetectChangesEnabled = true;
                    try
                    {
                        context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Timetable] ON");

                        context.Timetables.Add(timetable);
                        context.Timetables.Attach(timetable);
                        //  context.Timetables.Local.Add(timetable);
                        context.Entry(timetable).State = EntityState.Added;

                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Dodano nowy seans do repertuaru \n stan contextu = " + context.Entry(timetable).State);
                        }
                        context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Timetable] OFF");
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Nie udało się dodać nowego seansu \n " + e.Message);
                    }
                }
            }
        }


        void dodajPerformans(Performance p)
        {
            try
            {
                using (var context = new KinoEntities())
                {
                    context.Configuration.AutoDetectChangesEnabled = true;
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Performance] ON");
                        context.Performances.Add(p);
                        //  context.Performances.Local.Add(p);
                        context.Performances.Attach(p);
                        context.Entry(p).State = EntityState.Added;


                        //context.Entry(p).State = EntityState.Added;

                        MessageBox.Show("Stan bazy danych przed \n " + context.Entry(p).State.ToString());
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Dodano performens \n Stan bazy danych po \n " + context.Entry(p).State);

                            this.ostatniIDperformance++;
                        }
                        context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Performance] OFF");

                        transaction.Commit();
                        MessageBox.Show("Stan bazy danych po \n " + context.ChangeTracker.HasChanges());
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Nie udało się dodać nowego seansu \n " + error.Message);
            }
        }


        private void none(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {   //ZAMKNIĘCIE formularza bez dodania seansu

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
                 dimParametersString = "2D";

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
                 dimParametersString = "3D";

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
                 dimParametersString = "VR";

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
