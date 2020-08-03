using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using iText.Kernel.Geom;

namespace Modul_raportow
{
     public class ReportGenerator
    {
        static DataTable res;
        static string query = null;
        //static DateTime czas = DateTime.Now;

        public static void GenerateAllMoviesReport()
        {
            query = "DECLARE @RC int EXECUTE @RC = [dbo].[raport_podsumowania_filmow]";
            res = SQLObject.SendCommand(query);

            Pdf.Save("Raport Filmów", res);

        }
        public static void GenerateSalariesReport(DateTime dateFrom, DateTime dateTo) {

            Validation.ValidateDates(dateFrom, dateTo);

            query = "DECLARE @RC int DECLARE @datefrom datetime DECLARE @dateto datetime EXECUTE @RC = [dbo].[raport_pensji_pracownikow] @dateFrom='" + dateFrom.ToString("yyyy-MM-dd") + "', @dateTo='" + dateTo.ToString("yyyy-MM-dd") + "'";
            res = SQLObject.SendCommand(query);
            Pdf.Save("Raport Pensji Pracowników", res);

        }
        public static void GenerateWorkTimeReport(DateTime dateFrom, DateTime dateTo)
        {
            Validation.ValidateDates(dateFrom, dateTo);

            query = "DECLARE @RC int DECLARE @dateFrom datetime DECLARE @dateTo datetime EXECUTE @RC = [dbo].[raport_podsumowania_czasu_pracy_pracownikow] @dateFrom='" + dateFrom.ToString("yyyy-MM-dd") + "', @dateTo='" + dateTo.ToString("yyyy-MM-dd") + "'";

            res = SQLObject.SendCommand(query);
            Pdf.Save("Raport Czasu Pracy Pracowników", res);
        }
        public static void GenerateIndividualSalary(DateTime dateFrom, DateTime dateTo, long userId, string name)
        {
            Validation.ValidateDatesInd(dateFrom, dateTo, userId, name);

            query = "DECLARE @RC int DECLARE @id_pracownika bigint DECLARE @datefrom datetime DECLARE @dateto datetime EXECUTE @RC = [dbo].[raport_pensji_indywidualnego_pracownika] @id_pracownika='"+userId+"' ,@dateFrom='" + dateFrom.ToString("yyyy-MM-dd") + "', @dateTo='" + dateTo.ToString("yyyy-MM-dd") + "'";

            res = SQLObject.SendCommand(query);

            Pdf.Save("Raport indywidualnego czasu pracy pracownika", res);
        }

        public static void GenerateIndividualWorkTime(DateTime dateFrom, DateTime dateTo, long userId, string name)
        {
            Validation.ValidateDatesInd(dateFrom, dateTo, userId, name);

            query = "DECLARE @RC int DECLARE @userid bigint DECLARE @dateFrom datetime DECLARE @dateTo datetime EXECUTE @RC = [dbo].[raport_podsumowania_czasu_pracy_indywidualngo_pracownika] @userid =" + userId+", @datefrom='"+dateFrom.ToString("yyyy-MM-dd")+ "', @dateto='"+ dateTo.ToString("yyyy-MM-dd")+"'";

            res = SQLObject.SendCommand(query);

            Pdf.Save("Raport Czasu Pracownika Indywidualnego -  "+name, res);

        }
        public static void GenerateIncomeReport(DateTime dateFrom, DateTime dateTo) { }
        public static void GenerateFoodSaleReport(DateTime dateFrom, DateTime dateTo)
        {

            Validation.ValidateDates(dateFrom, dateTo);

            query = "DECLARE @RC int DECLARE @data1 datetime DECLARE @data2 datetime EXECUTE @RC = [dbo].[raport_sprzedanego_jedzenia] @datefrom='" + dateFrom.ToString("yyyy-MM-dd") + "', @dateto='" + dateTo.ToString("yyyy-MM-dd") + "';";

            res = SQLObject.SendCommand(query);

            Pdf.Save("Raport zestawienia sprzedanego jedzenia", res);

        }
    }
}