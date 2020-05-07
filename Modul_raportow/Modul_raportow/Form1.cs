using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using System.Security.AccessControl;
using System.Security.Permissions;



namespace Modul_raportow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void generate_report_button_Click(object sender, EventArgs e)
        {

            DateTime dateFrom, dateTo;

            int n = comboBox1.SelectedIndex;

            long id_pr;
            
            switch (n)
            {
                case 0:
                    ReportGenerator.generateAllMoviesReport();
                    break;

                case 1:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;

                    ReportGenerator.generateWorkTimeReport(dateFrom, dateTo);
                    break;

                case 2:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    id_pr = comboBox2.SelectedIndex + 1;

                    ReportGenerator.generateIndividualWorkTime(dateFrom, dateTo, id_pr);
                    break;

                case 3:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;

                    ReportGenerator.generateIncomeReport(dateFrom, dateTo);
                    break;

                case 4:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;

                    ReportGenerator.generateSalariesReport(dateFrom, dateTo);
                    break;

                case 5:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    id_pr = comboBox2.SelectedIndex + 1;

                    ReportGenerator.generateIndividualSalary(dateFrom, dateTo, id_pr);
                    break;
                
                case 6:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;

                    ReportGenerator.generateFoodSaleReport(dateFrom, dateTo);
                    break;
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ExportToPdf()
        {

            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var exportFile = System.IO.Path.Combine(exportFolder, "test.pdf");
            

            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var doc = new Document(pdf);
                    doc.Add(new Paragraph("Hello World"));
                }
            }


        }
    }
}
