using Kino.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    class TimeCleanAndAd
    {
        private int TimeAd; //podawane w minutach
        private int TimeClean; //podawane w minutach

        public int TimeAd1 { get => TimeAd; set => TimeAd = value; }
        public int TimeClean1 { get => TimeClean; set => TimeClean = value; }

        Movie movie = null;


        public TimeCleanAndAd(Movie film) 
        {
            this.movie = film;
        }

    public int timeClean()
        {
            if (movie.movieTime.TotalMinutes < 120)
            {
                return 20;
            }
            else if (movie.movieTime.TotalMinutes < 180)
            {
                return 30;
            }
            else
            {
                return 40;
            }
        }
    
        public int timeAd()
        {
            if (movie.movieTime.TotalMinutes < 120)
            {
                return 20;
            }
            else
            {
                return 30;
            }
        }

        public int sumTimeParameters ()
        {
            return timeAd() + timeClean();
        }
    } 
}
