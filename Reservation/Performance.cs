using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Performance:Film
    {
        double godzinaRozp,czasTrwania;
        string dzien;

        public double GodzinaRozp
        {
            get
            {
                return godzinaRozp;
            }

            set
            {
                godzinaRozp = value;
            }
        }

        public double CzasTrwania
        {
            get
            {
                return czasTrwania;
            }

            set
            {
                czasTrwania = value;
            }
        }
        public string Dzien
        {
            get
            {
                return dzien;
            }

            set
            {
                dzien = value;
            }
        }
    }
}
