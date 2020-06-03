using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modul_raportow;

namespace Modul_raportow_testy
{
    [TestClass]
    public class Validation
    {
        [TestMethod]
        public void TestValidateDatesIsNull()
        {
            DateTime? date1 = null;
            DateTime? date2 = null;

            try
            {
                Modul_raportow.Validation.ValidateDates(date1, date2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        [TestMethod]
        public void TestValidateDatesCorrect()
        {
            DateTime? date1 = new DateTime(2020, 06, 02);
            DateTime? date2 = new DateTime(2020, 06, 04);

            try
            {
                Modul_raportow.Validation.ValidateDates(date1, date2);


            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestValidateSameDay()
        {
            DateTime? date1 = new DateTime(2020, 06, 02);
            DateTime? date2 = new DateTime(2020, 06, 02);

            try
            {
                Modul_raportow.Validation.ValidateDates(date1, date2);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestValidateDatesWrongOrder()
        {
            DateTime? date1 = new DateTime(2020, 06, 6);
            DateTime? date2 = new DateTime(2020, 06, 5);

            try
            {
                Modul_raportow.Validation.ValidateDates(date1, date2);
                Assert.Fail();

            }
            catch (Exception e) when (!(e is AssertFailedException))
            {
                Console.Write(e.Message);
            }
        }

        [TestMethod]
        public void TestValidateDatesIndWrongNumber()
        {
            DateTime? date1 = new DateTime(2020, 06, 3);
            DateTime? date2 = new DateTime(2020, 06, 5);
            long nr = -3;
            string imie = "nazwa";

            try
            {
                Modul_raportow.Validation.ValidateDatesInd(date1, date2, nr, imie);
                Assert.Fail();
            }
            catch (Exception e) when (!(e is AssertFailedException))
            {
                Console.Write(e.Message);
            }



        }
        [TestMethod]
        public void TestValidateDatesIndEmptyString()
        {
            DateTime? date1 = new DateTime(2020, 06, 3);
            DateTime? date2 = new DateTime(2020, 06, 5);
            long nr = 3;
            string imie = "";

            try
            {
                Modul_raportow.Validation.ValidateDatesInd(date1, date2, nr, imie);
                Assert.Fail();
            }
            catch (Exception e) when (!(e is AssertFailedException))
            {
                Console.Write(e.Message);
            }


        }

        [TestMethod]
        public void TestValidateDatesIndTooLongString()
        {
            DateTime? date1 = new DateTime(2020, 06, 3);
            DateTime? date2 = new DateTime(2020, 06, 5);
            long nr = 3;
            string imie = new string('i', 70);

            try
            {
                Modul_raportow.Validation.ValidateDatesInd(date1, date2, nr, imie);
                Assert.Fail();
            }
            catch (Exception e) when (!(e is AssertFailedException))
            {
                Console.Write(e.Message);
            }

        }

        [TestMethod]
        public void TestValidateDatesIndCorrect()
        {
            DateTime? date1 = new DateTime(2020, 06, 3);
            DateTime? date2 = new DateTime(2020, 06, 5);
            long nr = 3;
            string imie = new string('i', 23);

            try
            {
                Modul_raportow.Validation.ValidateDatesInd(date1, date2, nr, imie);

            }
            catch (Exception e) when (!(e is AssertFailedException))
            {
                Assert.Fail();
                Console.Write(e.Message);
            }

        }


        [TestMethod]
        public void TestValidateDatesIndInvalidChar()
        {
            DateTime? date1 = new DateTime(2020, 06, 3);
            DateTime? date2 = new DateTime(2020, 06, 5);
            long nr = 3;
            string imie = "Anna_Nowak&";

            try
            {
                Modul_raportow.Validation.ValidateDatesInd(date1, date2, nr, imie);
                Assert.Fail();
            }
            catch (Exception e) when (!(e is AssertFailedException))
            {
                
                Console.Write(e.Message);
            }

        }
    }
}
