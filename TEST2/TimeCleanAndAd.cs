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


        public TimeCleanAndAd(int czasSprzatania, int czasReklam)
        {
            this.TimeAd1 = czasReklam;
            this.TimeClean1 = czasSprzatania;
           
        }


        public int timeClean()
        {
            int czasSprzatania = 0;

            if (movie != null)
            {
                double totalMinutes = movie.movieTime.TotalMinutes;

                if (totalMinutes < TWO_HOURS_MINUTES)
                {
                    czasSprzatania = TWENTY_MINUTES;
                }
                else if (totalMinutes < ONE_AND_HALF_HOUR_MINUTES)
                {
                     czasSprzatania = THIRTY_MINUTES;
                }
                else
                {
                     czasSprzatania = FOURTY_MINUTES;
                }

                return czasSprzatania;
            }


            

            if (czasSprzatania < 10) {
                czasSprzatania = 10;
            }

            if (czasSprzatania > TWO_HOURS_MINUTES)
            {
                czasSprzatania = TWO_HOURS_MINUTES;
            }

            else { czasSprzatania = TimeClean1; }

            return czasSprzatania;
        }


        public int timeAd()
        {
            int czas = 0;

            if (movie != null)
            {   czas = movie.movieTime.TotalMinutes < TWO_HOURS_MINUTES ? TWENTY_MINUTES : THIRTY_MINUTES;
                return czas;
            }

            if (TimeAd1 < 15) {
                czas = 15;
            }

            if (TimeAd1 > 45)
            {
                czas = 45;
            }
            else {
                czas = TimeAd1;
            }
            return czas;
        
        }


        public int sumTimeParameters()
        {
            return timeAd() + timeClean();
        }
    }

 
}
