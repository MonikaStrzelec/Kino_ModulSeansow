using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Film
    {
        string tytuł;
        double długość;

        public string Tytuł
        {
            get
            {
                return tytuł;
            }

            set
            {
                tytuł = value;
            }
        }

        public double Długość
        {
            get
            {
                return długość;
            }

            set
            {
                długość = value;
            }
        }
    }
}
