using Kino.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domena
{
    class TimetableDomain
    {
        public string title { get; set; }
        public string description { get; set; }
        public string movieType { get; set; }
        public DateTime dataTime { get; set; }
        public string hallName { get; set; }
        public string hallType { get; set; }
        public TimeSpan movieTime { get; set; }


        public TimetableDomain(Timetable t)
        {
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
