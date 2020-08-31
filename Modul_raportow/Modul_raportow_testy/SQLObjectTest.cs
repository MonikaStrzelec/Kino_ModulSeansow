using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;


namespace Modul_raportow_testy
{
    [TestClass]
    public class SQLObjectTest
    {
        [TestMethod]
        public void SQLConnectionCorrect()
        {
            SqlConnection con = new SqlConnection("Data Source=35.228.52.182;Initial Catalog=Kino;User ID=sqlserver;Password=Pa$$w0rd");

            con.Open();
            Assert.AreEqual(con.State.ToString(), "Open");

        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void SQLConnectionFail()
        {
            SqlConnection con = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=Whatever;User ID=user;Password=pass");
            con.Open();
        }

        [TestMethod]
        public void SQLObjectSendCommandCorrect()
        {
            //SqlConnection con = new SqlConnection("Data Source=35.228.52.182;Initial Catalog=Kino;User ID=sqlserver;Password=Pa$$w0rd");

            DataTable result = Modul_raportow.SQLObject.SendCommand("SELECT 1");

            Assert.AreEqual(1, result.Rows[0][0]); 

        }

        //[testmethod]
        //public void sqlobjectsendcommandfail()
        //{
        //    sqlconnection con = new sqlconnection("data source=35.228.52.182;initial catalog=kino;user id=sqlserver;password=pa$$w0rd");

        //    datatable result = modul_raportow.sqlobject.sendcommand("select 1");
        //    assert.areequal(1, result.rows[0][0]);
        //}
    }
}
