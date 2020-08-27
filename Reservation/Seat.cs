using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Seat:Hall
    {
        int id, row, number, idReservation;
        bool dostepnosc;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Row
        {
            get
            {
                return row;
            }

            set
            {
                row = value;
            }
        }
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public bool Dostepnosc
        {
            get
            {
                return dostepnosc;
            }

            set
            {
                dostepnosc = value;
            }
        }

        public int IdReservation
        {
            get
            {
                return idReservation;
            }

            set
            {
                idReservation = value;
            }
        }
    }
}
