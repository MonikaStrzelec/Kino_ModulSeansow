﻿using System;
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
            Init();
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
//test
        private void generate_report_button_Click(object sender, EventArgs e)
        {

            DateTime dateFrom, dateTo;

            int n = comboBox1.SelectedIndex;

            long id_pr;
            
            switch (n)
            {
                case 0:
                    ReportGenerator.GenerateAllMoviesReport();
                    comboBox2.Enabled = false;
                    break;

                case 1:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    comboBox2.Enabled = false;
                    ReportGenerator.GenerateWorkTimeReport(dateFrom, dateTo);
                    break;
                
                case 2:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    id_pr = long.Parse( comboBox2.GetItemText(comboBox2.SelectedItem));

                    ReportGenerator.GenerateIndividualWorkTime(dateFrom, dateTo, id_pr);
                    break;

                case 3:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    comboBox2.Enabled = false;
                    ReportGenerator.GenerateIncomeReport(dateFrom, dateTo);
                    break;

                case 4:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    comboBox2.Enabled = false;
                    ReportGenerator.GenerateSalariesReport(dateFrom, dateTo);
                    break;

                case 5:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    id_pr = comboBox2.SelectedIndex + 1;

                    ReportGenerator.GenerateIndividualSalary(dateFrom, dateTo, id_pr);
                    break;
                
                case 6:
                    dateFrom = dateTimePicker1.Value;
                    dateTo = dateTimePicker2.Value;
                    comboBox2.Enabled = false;
                    ReportGenerator.GenerateFoodSaleReport(dateFrom, dateTo);
                    break;
                default:
                    comboBox1.SelectedIndex = 0;
                    MessageBox.Show("Ej wybierz jakiś raport");
                    break;
            }

            MessageBox.Show("Raport został stworzony");

            Init();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void Init()
        {
            
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = comboBox1.SelectedIndex;

            switch (n)
            {
                case 0:
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    comboBox2.Enabled = false;
                    break;

                case 1:
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    comboBox2.Enabled = false;
                    
                    break;

                case 2:
                    DataTable id;
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    comboBox2.Enabled = true;
                    id = SQLObject.SendCommand("SELECT dbo.g1_user.id_user AS Identyfikator, dbo.g1_pearson.first_name + ' '+dbo.g1_pearson.last_name FROM dbo.g1_user INNER JOIN dbo.g1_pearson ON dbo.g1_pearson.id_pearson=dbo.g1_user.id_pearson");
                    foreach (DataRow row in id.Rows)
                    {
                        comboBox2.Items.Add(row[0].ToString());
                    }
                    
                    break;

                case 3:
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    comboBox2.Enabled = false;
                    
                    break;

                case 4:
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    comboBox2.Enabled = false;
                    
                    break;

                case 5:
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    comboBox2.Enabled = true;
                    break;

                case 6:
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    comboBox2.Enabled = false;
                    
                    break;
                
            }
        }

        

        
    }
}
