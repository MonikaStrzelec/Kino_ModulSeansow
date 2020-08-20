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

        public string tytul { get; set; }

        public DateTime godzinaRozpoczecia { get; set; }

        public DateTime godzinaZakonczenia { get; set; }

        public int dlugoscReklamMin { get; set; }

        public TimeSpan dlugoscFilmu { get; set; }


        public DomainSeans(Timetable p)
        {
            this.tytul = p.Performance1.Movie1.title;
            this.godzinaRozpoczecia = p.performanceDate;
            this.godzinaZakonczenia = godzinaRozpoczecia.Add(p.Performance1.Movie1.movieTime).Add(p.Performance1.adsDuration);
            this.dlugoscFilmu = p.Performance1.Movie1.movieTime;
            this.dlugoscReklamMin = p.Performance1.adsDuration.Minutes;
        }

    }
}
