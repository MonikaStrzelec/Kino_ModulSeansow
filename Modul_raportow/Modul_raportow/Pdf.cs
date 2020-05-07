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

namespace Modul_raportow
{
    class Pdf
    {
        static string exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static Table ToTable(DataTable data)
        {
            Table res = new Table(data.Columns.Count);
            res.UseAllAvailableWidth();
            res.SetFontSize(14);
            foreach (DataColumn column in data.Columns)
            {
                res.AddHeaderCell(new Paragraph(column.ColumnName));
            }
            res.SetFontSize(10);
            foreach (DataRow row in data.Rows)
            {
                for(int i = 0; i < data.Columns.Count; i++)
                {
                    res.AddCell(new Paragraph(row[i].ToString()));
                }


            }
            return res;
        }

        public static void Save(string filename, Table tbl)
        {
            string exportFile = System.IO.Path.Combine(exportFolder, filename);
            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var doc = new Document(pdf);
                    doc.Add(new Paragraph(filename));
                    doc.Add(tbl);
                    doc.Close();
                }
            }
            
        }

    }
}
