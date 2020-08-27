using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reservation;

namespace ReservationUnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestValidateCorrectReservationInfo()
        {
            string imie = "Elon";
            string nazwisko = "Musk";
            string email = "elonm@gmail.com";
            string tytul = "Grave Decisions";
            int idTimetable = 10;
            string status = "aktywna";

            try
            {
                Reservation.Validation.ValidateReservationData(imie, nazwisko, email, tytul, idTimetable, status);
            }
            catch (Exception)
            {
                Assert.Fail();
            }


        }

        [TestMethod]
        public void TestValidateWrongSurname()
        {
            string imie = "Elon";
            string nazwisko = "Mu$$k";
            string email = "elonm@gmail.com";
            string tytul = "Grave Decisions";
            int idTimetable = 10;
            string status = "aktywna";

            try
            {
                Reservation.Validation.ValidateReservationData(imie, nazwisko, email, tytul, idTimetable, status);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }

        [TestMethod]
        public void TestValidateWrongName()
        {
            string imie = "E%$on_";
            string nazwisko = "Musk";
            string email = "elonm@gmail.com";
            string tytul = "Grave Decisions";
            int idTimetable = 10;
            string status = "aktywna";

            try
            {
                Reservation.Validation.ValidateReservationData(imie, nazwisko, email, tytul, idTimetable, status);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }

        [TestMethod]
        public void TestValidateWrongMail()
        {
            string imie = "Elon";
            string nazwisko = "Musk";
            string email = "elonmgmail";
            string tytul = "Grave Decisions";
            int idTimetable = 10;
            string status = "aktywna";

            try
            {
                Reservation.Validation.ValidateReservationData(imie, nazwisko, email, tytul, idTimetable, status);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }

        [TestMethod]
        public void TestValidateWrongTimetable()
        {
            string imie = "Elon";
            string nazwisko = "Musk";
            string email = "elonm@gmail.com";
            string tytul = "Grave Decisions";
            int idTimetable = 0;
            string status = "aktywna";

            try
            {
                Reservation.Validation.ValidateReservationData(imie, nazwisko, email, tytul, idTimetable, status);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }

        [TestMethod]
        public void TestValidateWrongReservation()
        {
            string imie = "Elon";
            string nazwisko = "Musk";
            string email = "elonm@gmail.com";
            string tytul = "Grave Decisions";
            int idTimetable = 10;
            string status = "niedostępna";

            try
            {
                Reservation.Validation.ValidateReservationData(imie, nazwisko, email, tytul, idTimetable, status);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }

        [TestMethod]
        public void TestValidateCorrectTicketInfo()
        {
            int id = 21;
            string rodzaj = "normalny";
            decimal cena = 18;
            int idReservation = 150;
            int idSeat = 9;

            try
            {
                Reservation.Validation.ValidateTicketInfo(id, rodzaj, cena, idReservation, idSeat);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void TestValidateTicketWrongPrice()
        {
            int id = 21;
            string rodzaj = "normalny";
            decimal cena = 12;
            int idReservation = 150;
            int idSeat = 9;

            try
            {
                Reservation.Validation.ValidateTicketInfo(id, rodzaj, cena, idReservation, idSeat);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }

        [TestMethod]
        public void TestValidateTicketWrongType()
        {
            int id = 21;
            string rodzaj = "wakacyjny";
            decimal cena = 18;
            int idReservation = 150;
            int idSeat = 9;

            try
            {
                Reservation.Validation.ValidateTicketInfo(id, rodzaj, cena, idReservation, idSeat);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }

        [TestMethod]
        public void TestValidateTicketWrongId()
        {
            int id = 0;
            string rodzaj = "normalny";
            decimal cena = 18;
            int idReservation = 150;
            int idSeat = 9;

            try
            {
                Reservation.Validation.ValidateTicketInfo(id, rodzaj, cena, idReservation, idSeat);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
            }

        }
    }
}
