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

        KinoEntities context;
        private Timetable element;

        public FormularzSzczegolyFilmy(Timetable element)
        {
            InitializeComponent();
            this.element = element;
        }

        private void FormularzSzczegolyFilmy_Load(object sender, EventArgs e)
        {
                try
                {
                dataGridView1.AutoGenerateColumns = true;

                context = new KinoEntities(); //tworzenie obiekyu bazy danych
                    context.Timetables.Load(); //ładowanie tabeli

                TimetableDomainClass domain = new TimetableDomainClass(this.element);// warstwa domenowa 

                timetableDomainClassBindingSource.DataSource = new BindingList<TimetableDomainClass>() { domain };

            }
                catch
                {
                    MessageBox.Show("Sprawdź połączenie z bazą danych!");
                }
            
        }
    }

    class TimetableDomainClass {
        public string title { get; set; }
        public string description { get; set; }
        public string movieType { get; set; }

        public DateTime dataTime { get; set; }
        public string hallName { get; set; }
        public string hallType { get; set; }

        public TimeSpan movieTime { get; set; }

        public TimetableDomainClass(Timetable t) {
            this.title = t.Performance1.Movie1.title;
            this.description = t.Performance1.Movie1.description;
            this.movieType = t.Performance1.Movie1.MovieType1.name;
            this.dataTime = t.performanceDate;
            this.hallName = t.Performance1.Hall1.name;
            this.hallType = t.Performance1.Hall1.Dim.name;
            this.movieTime = t.Performance1.Movie1.movieTime;

        }
        

    }
}
