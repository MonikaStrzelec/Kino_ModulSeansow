using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reservation
{
    public class Validation
    {
        public static void ValidateMovieInfo(string tytul, int idTimetable)
        {
            if (tytul == null || idTimetable == 0) throw new Exception("Musisz wybrać jakieś wartości!");

        }

        public static void ValidateClientInfo(string imie, string nazwisko, string email, string status)
        {
            if (imie == null || nazwisko == null || email == null || status == null) throw new Exception("Musisz wpisać dane!");

            if (status != "aktywna") throw new Exception("Niepoprawnie złożona rezerwacja!");
        }

        public static void ValidateReservationData(string imie, string nazwisko, string email, string tytul, int idTimetable, string status)
        {
            ValidateMovieInfo(tytul, idTimetable);

            ValidateClientInfo(imie, nazwisko, email, status);

            Regex reg = new Regex("[^A-Za-z0-9]$");
            if (reg.IsMatch(imie)) throw new Exception("Możesz stosować tylko znaki od A-Z oraz 0-9");
            if (reg.IsMatch(nazwisko)) throw new Exception("Możesz stosować tylko znaki od A-Z oraz 0-9");
            

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!regex.IsMatch(email)) throw new Exception("Podaj poprawny mail!");
        }

        public static void ValidateTicketInfo(int id, string rodzaj, decimal cena, int idReservation, int idSeat)
        {
            if (id == 0 || rodzaj == null || cena == 0 || idReservation == 0 || idSeat == 0) throw new Exception("Brak wszystkich danych!");

            if (rodzaj != "ulgowy" & rodzaj != "normalny") throw new Exception("Zły rodzaj biletu!");

            if (rodzaj == "ulgowy" & cena != 12) throw new Exception("Niepoprawna cena!");

            if (rodzaj == "normalny" & cena != 18) throw new Exception("Niepoprawna cena!");

        }
    }
}
