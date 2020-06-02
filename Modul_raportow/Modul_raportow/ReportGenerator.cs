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
        static string zapytanie = null;
        //static DateTime czas = DateTime.Now;

        public static void GenerateAllMoviesReport()
        {
            zapytanie = "DECLARE @RC int EXECUTE @RC = [dbo].[raport_podsumowania_filmow]";
            res = SQLObject.SendCommand(zapytanie);

            Pdf.Save("Raport Filmów", res);

        }
        public static void GenerateSalariesReport(DateTime dateFrom, DateTime dateTo) { }
        public static void GenerateWorkTimeReport(DateTime? dateFrom, DateTime? dateTo)
        {
            Validation.ValidateDates(dateFrom, dateTo);

            zapytanie = "SELECT dbo.\"Schedule\".userId AS \"Identryfikator\",dbo.g1_pearson.first_name AS \"Imie\", dbo.g1_pearson.last_name AS \"Nazwisko\",CONVERT(TIME, DATEADD(s, SUM((DATEPART(hh, CAST(dbo.\"Schedule\".dateTo - dbo.\"Schedule\".dateFrom AS Time(0))) * 3600) + (DATEPART(mi, CAST(dbo.\"Schedule\".dateTo - dbo.\"Schedule\".dateFrom AS Time(0))) * 60) + DATEPART(ss, CAST(dbo.\"Schedule\".dateTo - dbo.\"Schedule\".dateFrom AS Time(0)))), 0)) AS \"Czas pracy\" FROM dbo.\"Schedule\" INNER JOIN dbo.g1_user ON dbo.g1_user.id_user = dbo.\"Schedule\".userId INNER JOIN dbo.g1_pearson ON dbo.g1_pearson.id_Pearson = dbo.g1_user.id_Pearson GROUP BY dbo.\"Schedule\".userId, dbo.g1_pearson.first_name, dbo.g1_pearson.last_name;";
            
            res = SQLObject.SendCommand(zapytanie);
            Pdf.Save("Raport Czasu Pracowników", res);
        }
        public static void GenerateIndividualSalary(DateTime dateFrom, DateTime dateTo, long userId) { }
        public static void GenerateIndividualWorkTime(DateTime dateFrom, DateTime dateTo, long userId, string name)
        {

            zapytanie = "DECLARE @RC int DECLARE @id_pracownika bigint DECLARE @datefrom datetime DECLARE @dateto datetime EXECUTE @RC = [dbo].[raport_pensji_indywidualnego_pracownika] @id_pracownika ="+userId+", @datefrom='"+dateFrom.ToString("yyyy-MM-dd")+ "', @dateto='"+ dateTo.ToString("yyyy-MM-dd")+"'";

            res = SQLObject.SendCommand(zapytanie);

            Pdf.Save("Raport Czasu Pracownika Indywidualnego -  "+name, res);

        }
        public static void GenerateIncomeReport(DateTime dateFrom, DateTime dateTo) { }
        public static void GenerateFoodSaleReport(DateTime dateFrom, DateTime dateTo) { }

    }
}