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
using System.IO;
using System.Windows.Forms;

namespace Modul_raportow
{
    class Pdf
    {
        private static PdfFont helvetica = null;

        static string exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static Table ToTable(DataTable data)
        {
            resetFont();
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
            resetFont();
            string genTime = DateTime.Today.ToShortDateString();
            string filename = name.Replace(" ","")+" "+genTime+" .pdf";

            string filepath = exportFolder +"\\"+ filename;
            try
            {
                if (File.Exists(filepath))
                {
                    MessageBox.Show("Raport "+name+" już istnieje. Proszę usunąć poprzednio wygenerowany raport i spróbować ponownie");
                    return;
                }
                else
                {
                    string exportFile = System.IO.Path.Combine(exportFolder, filename);

                    PdfWriter writer = new PdfWriter(exportFile);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document doc = new Document(pdf);
                    Paragraph title = new Paragraph(name).SetFont(helvetica);
                    title.SetFontSize(21);
                    doc.Add(new Paragraph(genTime).SetFont(helvetica));
                    doc.Add(title);
                    doc.Add(ToTable(data));
                    doc.Close();
                    pdf.Close();
                    writer.Close();
                    
                    MessageBox.Show("Wygenerowano raport: " + name);
                }
                

                    
                
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
            
        }

        private static void resetFont() // funkcja tworzy nową czcionke ponieważ pdffont przypisuje się do dokumentu pdf co uniemożliwia użycia jej w innym pdf'ie
        {
            helvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, "CP1250"); 
        }

        //private static void NumberPages(PdfDocument pdfDoc, Document doc)
        //{
        //    int numberOfPages = pdfDoc.GetNumberOfPages();
        //    for (int i = 1; i <= numberOfPages; i++)
        //    {

        //        // Write aligned text to the specified by parameters point
        //       try
        //        {
        //            doc.ShowTextAligned(new Paragraph(String.Format("page %s of %s", i, numberOfPages)),
        //                559, 806, i, TextAlignment.RIGHT, VerticalAlignment.TOP, 0);
        //        }
        //        catch(Exception e)
        //        {
        //            Console.WriteLine(e);
        //        }
        //    }
        //}
    }
   
}
