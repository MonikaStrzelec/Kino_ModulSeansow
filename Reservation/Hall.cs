using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public class Hall:Performance
    {
        string nazwa;
        int iloscMiejsc;

        public string Nazwa
        {
            get
            {
                return nazwa;
            }

            set
            {
                nazwa = value;
            }
        }

        public int IloscMiejsc
        {
            get
            {
                return iloscMiejsc;
            }

            set
            {
                iloscMiejsc = value;
            }
        }
    }
}
