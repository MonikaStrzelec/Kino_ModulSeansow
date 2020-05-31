using Kino.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domena
{
    class DomainSeans 
    {

        private string tytul;

        private DateTime godzinaRozpoczecia;

        private TimeSpan godzinaZakonczenia;

        private int dlugoscReklamMin;


        public DomainSeans(Timetable p)
        {

            this.tytul = p.Performance1.Movie1.title;
            this.godzinaRozpoczecia = p.performanceDate;
            this.godzinaZakonczenia = p.Performance1.Movie1.movieTime.Add(TimeSpan.FromMinutes((double)p.Performance1.adsDuration.Minutes));
            this.dlugoscReklamMin = p.Performance1.adsDuration.Minutes;

        }

    }
}
