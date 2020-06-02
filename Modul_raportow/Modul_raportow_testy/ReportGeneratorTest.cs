using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modul_raportow;

namespace Modul_raportow_testy
{
    [TestClass]
    public class ReportGeneratorTest
    {
        [TestMethod]
        public void TestValidateDatesIsNull()
        {
            DateTime? date1 = null;
            DateTime? date2 = null;

            try
            {
                Validation.ValidateDates(date1, date2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        [TestMethod]
        public void TestValidateDatesCorrect()
        {
            DateTime? date1 = new DateTime(2020,06,02);
            DateTime? date2 = new DateTime(2020,06, 04);

            try
            {
                Validation.ValidateDates(date1, date2);


            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void TestValidateDatesWrongOrder()
        {
            DateTime? date1 = new DateTime(2020, 06, 04);
            DateTime? date2 = new DateTime(2020, 06, 02);

            try
            {
                Validation.ValidateDates(date1, date2);
                Assert.Fail();

            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }
}
