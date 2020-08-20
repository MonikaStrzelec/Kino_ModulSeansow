using Kino.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    public class TimeCleanAndAd
    {
        private const int TWENTY_MINUTES = 20;
        private const int THIRTY_MINUTES = 30;
        private const int FOURTY_MINUTES = 40;
        private const int TWO_HOURS_MINUTES = 120;
        private const int ONE_AND_HALF_HOUR_MINUTES = 180;

        private int TimeAd; //podawane w minutach
        private int TimeClean; //podawane w minutach

        public int TimeAd1 { get => TimeAd; set => TimeAd = value; }
        public int TimeClean1 { get => TimeClean; set => TimeClean = value; }
        Movie movie = null;


        public TimeCleanAndAd(Movie film) 
        {
            this.movie = film;
        }

        public TimeCleanAndAd(int czasSprzatania, int czasReklam) {
            this.TimeAd = czasReklam;
            this.TimeClean = czasSprzatania;
        }


    public int timeClean()
        {
            double totalMinutes = movie.movieTime.TotalMinutes;

            if (totalMinutes < TWO_HOURS_MINUTES)
            {
                return TWENTY_MINUTES;
            }
            else if (totalMinutes < ONE_AND_HALF_HOUR_MINUTES)
            {
                return THIRTY_MINUTES;
            }
            else
            {
                return FOURTY_MINUTES;
            }
        }
    

        public int timeAd()
        {
            if (movie != null)
            {
                return movie.movieTime.TotalMinutes < TWO_HOURS_MINUTES ? TWENTY_MINUTES : THIRTY_MINUTES;
            }
            return (TimeAd + TimeClean) < TWO_HOURS_MINUTES ? TWENTY_MINUTES : THIRTY_MINUTES;
        }


        public int sumTimeParameters ()
        {
            return timeAd() + timeClean();
        }
    } 
}
