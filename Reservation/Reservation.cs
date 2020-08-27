using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Reservation:Ticket
    {
        string imie, nazwisko, status, data, email;
        int idData, idTimetable;
        

        public string Imie
        {
            get
            {
                return imie;
            }

            set
            {
                imie = value;
            }
        }
        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }

            set
            {
                nazwisko = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }


        public int IdData
        {
            get
            {
                return idData;
            }

            set
            {
                idData = value;
            }
        }

        public int IdTimetable
        {
            get
            {
                return idTimetable;
            }

            set
            {
                idTimetable = value;
            }
        }
    }
}
