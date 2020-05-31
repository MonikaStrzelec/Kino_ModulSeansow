using Kino.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    class TablicaWartosciOdDo
    {
        private int indexPoczatkowy;
        private int indexKoncowy;

        public int IndexPoczatkowy { get => indexPoczatkowy; set => indexPoczatkowy = value; }
        public int IndexKoncowy { get => indexKoncowy; set => indexKoncowy = value; }

        public TablicaWartosciOdDo(DateTime czasRozpoczecia, TimeSpan dlugosc) {

            TimeSpan czasWdniu = czasRozpoczecia.TimeOfDay;
            int tmp = czasWdniu.Hours * 60 + czasWdniu.Minutes;
            this.indexPoczatkowy = obliczIndex(tmp);

            TimeSpan czasKoncowy = czasWdniu.Add(dlugosc);
            this.indexKoncowy = obliczIndex(czasKoncowy.Hours * 60 + czasKoncowy.Minutes) - 1;
        }

        public TablicaWartosciOdDo(Timetable t) {

            DateTime czasRozpoczecia = t.performanceDate;
            TimeSpan dlugosc = t.Performance1.Movie1.movieTime.Add(t.Performance1.adsDuration);

            TimeSpan czasWdniu = czasRozpoczecia.TimeOfDay;
            int tmp = czasWdniu.Hours * 60 + czasWdniu.Minutes;
            this.indexPoczatkowy = obliczIndex(tmp);

            TimeSpan czasKoncowy = czasWdniu.Add(dlugosc);
            this.indexKoncowy = obliczIndex(czasKoncowy.Hours * 60 + czasKoncowy.Minutes) - 1;

        }

        private int obliczIndex(int minuty) {

            int tmpIndex = minuty / 5;

            if (minuty % 5 != 0) {
                tmpIndex++;
            }
            return tmpIndex; 
        }
    }
}
