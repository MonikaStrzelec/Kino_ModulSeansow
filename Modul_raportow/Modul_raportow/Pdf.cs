using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace Modul_raportow
{
    class Pdf
    {
        static readonly PdfFont helvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, "CP1250");

        static string exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static Table ToTable(DataTable data)
        {
            Table res = new Table(data.Columns.Count);
            res.UseAllAvailableWidth();
            foreach (DataColumn column in data.Columns)
            {
                res.AddHeaderCell(new Paragraph(column.ColumnName).SetFontSize(11).SetBold().SetFont(helvetica));
            }
            foreach (DataRow row in data.Rows)
            {
                for(int i = 0; i < data.Columns.Count; i++)
                {
                    res.AddCell(new Paragraph(row[i].ToString()).SetFontSize(8).SetFont(helvetica));
                }


            }
            return res;
        }

        public static void Save(string name, DataTable data)
        {
            string genTime = DateTime.Today.ToShortDateString();
            string filename = name.Replace(" ","")+" "+genTime+" .pdf";
            

            string exportFile = System.IO.Path.Combine(exportFolder, filename);
            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf);
                    Paragraph title = new Paragraph(name).SetFont(helvetica);
                    title.SetFontSize(21);
                    doc.Add(new Paragraph(genTime).SetFont(helvetica));
                    doc.Add(title);
                    doc.Add(ToTable(data));
                    //NumberPages(pdf, doc);
                    doc.Close();
                    pdf.Close();
                }
            }
            
        }
        private static void NumberPages(PdfDocument pdfDoc, Document doc)
        {
            int numberOfPages = pdfDoc.GetNumberOfPages();
            for (int i = 1; i <= numberOfPages; i++)
            {

                // Write aligned text to the specified by parameters point
               try
                {
                    doc.ShowTextAligned(new Paragraph(String.Format("page %s of %s", i, numberOfPages)),
                        559, 806, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
   
}
