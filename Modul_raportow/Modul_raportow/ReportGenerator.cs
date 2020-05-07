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
        static string exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string exportFile = System.IO.Path.Combine(exportFolder, "test1.pdf");

        public static void generateAllMoviesReport()
        {
            string zapytanie = " SELECT  dbo.Movie.id, dbo.Movie.title, dbo.Movie.description, dbo.MovieState.name, dbo.MovieType.name, dbo.Movie.movietime  FROM dbo.Movie INNER JOIN dbo.MovieState ON  dbo.Movie.movieState=dbo.MovieState.id INNER JOIN dbo.MovieType ON dbo.Movie.movieType = dbo.MovieType.id";

            res = SQLObject.SendCommand(zapytanie);

            Pdf.save("RaportFilmów.pdf", Pdf.toTable(res));

        }
        public static void generateSalariesReport(DateTime dateFrom, DateTime dateTo) { }
        public static void generateWorkTimeReport(DateTime dateFrom, DateTime dateTo) { }
        public static void generateIndividualSalary(DateTime dateFrom, DateTime dateTo, long userId) { }
        public static void generateIndividualWorkTime(DateTime dateFrom, DateTime dateTo, long userId) { }
        public static void generateIncomeReport(DateTime dateFrom, DateTime dateTo) { }
        public static void generateFoodSaleReport(DateTime dateFrom, DateTime dateTo) { }




        public static void Raport_podsumowania_czasu_pracy_pracownikow()
        {
            //string zapytanie = "SELECT dbo.Schedule.\"User\"Id AS Identryfikator,dbo.\"User\".firstname AS Imie, dbo.\"User\".lastname AS Nazwisko,CONVERT(TIME, DATEADD(s, SUM(( DATEPART(hh, CAST(dbo.Schedule.dateTo - dbo.Schedule.dateFrom AS Time(0))) * 3600 ) + ( DATEPART(mi, CAST(dbo.Schedule.dateTo - dbo.Schedule.dateFrom AS Time(0))) * 60 ) + DATEPART(ss, CAST(dbo.Schedule.dateTo - dbo.Schedule.dateFrom AS Time(0)))), 0)) AS \"Czas pracy\" FROM dbo.Schedule INNER JOIN dbo.\"User\" ON dbo.\"User\".id=dbo.Schedule.\"User\"Id GROUP BY dbo.Schedule.\"User\"Id, dbo.\"User\".firstname, dbo.\"User\".lastname;";

            res = null;

            string zapytanie = "SELECT dbo.Movie.id, dbo.Movie.title, dbo.Movie.description, dbo.MovieState.name, dbo.MovieType.name, dbo.Movie.movietime  FROM dbo.Movie INNER JOIN dbo.MovieState ON  dbo.Movie.movieState=dbo.MovieState.id INNER JOIN dbo.MovieType ON dbo.Movie.movieType = dbo.MovieType.id";
            res = SQLObject.SendCommand(zapytanie);

            

            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf = new PdfDocument(writer))
                {

                    
                    var doc = new Document(pdf);
                    doc.Add(Pdf.toTable(res));
                    
                }
            }

        }





    }
}
