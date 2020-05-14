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
    class ReportGenerator
    {
        static DataTable res;
        static string zapytanie = null;
        //static DateTime czas = DateTime.Now;

        public static void GenerateAllMoviesReport()
        {
            zapytanie = "DECLARE @RC int EXECUTE @RC = [dbo].[raport_podsumowania_filmow]";
            DateTime czas = DateTime.Now;
            res = SQLObject.SendCommand(zapytanie);

            Pdf.Save("RaportFilmów.pdf", Pdf.ToTable(res));

        }
        public static void GenerateSalariesReport(DateTime dateFrom, DateTime dateTo) { }
        public static void GenerateWorkTimeReport(DateTime dateFrom, DateTime dateTo)
        {
            zapytanie = "SELECT dbo.\"Schedule\".userId AS \"Identryfikator\",dbo.g1_pearson.first_name AS \"Imie\", dbo.g1_pearson.last_name AS \"Nazwisko\",CONVERT(TIME, DATEADD(s, SUM((DATEPART(hh, CAST(dbo.\"Schedule\".dateTo - dbo.\"Schedule\".dateFrom AS Time(0))) * 3600) + (DATEPART(mi, CAST(dbo.\"Schedule\".dateTo - dbo.\"Schedule\".dateFrom AS Time(0))) * 60) + DATEPART(ss, CAST(dbo.\"Schedule\".dateTo - dbo.\"Schedule\".dateFrom AS Time(0)))), 0)) AS \"Czas pracy\" FROM dbo.\"Schedule\" INNER JOIN dbo.g1_user ON dbo.g1_user.id_user = dbo.\"Schedule\".userId INNER JOIN dbo.g1_pearson ON dbo.g1_pearson.id_Pearson = dbo.g1_user.id_Pearson GROUP BY dbo.\"Schedule\".userId, dbo.g1_pearson.first_name, dbo.g1_pearson.last_name;";
            res = SQLObject.SendCommand(zapytanie);
            Pdf.Save("RaportCzasuPracowników.pdf", Pdf.ToTable(res));
        }
        public static void GenerateIndividualSalary(DateTime dateFrom, DateTime dateTo, long userId) { }
        public static void GenerateIndividualWorkTime(DateTime dateFrom, DateTime dateTo, long userId)
        {
            zapytanie = "DECLARE @RC int DECLARE @id_pracownika bigint DECLARE @datefrom datetime DECLARE @dateto datetime EXECUTE @RC = [dbo].[raport_pensji_indywidualnego_pracownika] @id_pracownika ="+userId+", @datefrom="+dateFrom+", @dateto="+dateTo;

            res = SQLObject.SendCommand(zapytanie);

            Pdf.Save("RaportCzasuPracownikaIndywidualnegoID__"+userId+"__"+DateTime.Now+".pdf", Pdf.ToTable(res));
        }
        public static void GenerateIncomeReport(DateTime dateFrom, DateTime dateTo) { }
        public static void GenerateFoodSaleReport(DateTime dateFrom, DateTime dateTo) { }

    }
}