using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domena
{
    class DomainFilm
    {
        int id;
        string nameMovie, nameHall, parametr;
        DateTime dateShow;


        public DomainFilm(int id, string nameMovie, string nameHall, string parametr, DateTime dateShow)
        {
            this.id = id;
            this.nameMovie = nameMovie;
            this.nameHall = nameHall;
            this.parametr = parametr;
            this.dateShow = dateShow;
        }
    }
}
