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
        public static Table toTable(DataTable data)
        {
            Table res = new Table(data.Columns.Count);
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
    }
}
