using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Ticket:Hall
    {
        int  idReservation, idSeat;
        double cena;
        string rodzaj;

        public string Rodzaj
        {
            get
            {
                return rodzaj;
            }

            set
            {
                rodzaj = value;
            }
        }

        public double Cena
        {
            get
            {
                return cena;
            }

            set
            {
                cena = value;
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
                idReservation= value;
            }
        }

        public int IdSeat
        {
            get
            {
                return idSeat;
            }

            set
            {
                idSeat = value;
            }
        }
    }
}
