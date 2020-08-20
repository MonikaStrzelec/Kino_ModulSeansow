using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domena
{
    class DomainHoursOfPause
    {
       public TimeSpan czasRozpoczecia { get; set; }
       public TimeSpan czasZakonczenia { get; set; }

        public DomainHoursOfPause(int indexPoczatkowy, int indexKoncowy) {

            this.czasRozpoczecia = TimeSpan.FromMinutes(indexPoczatkowy * 5);
            this.czasZakonczenia = TimeSpan.FromMinutes(indexKoncowy * 5);
        }
    }
}
