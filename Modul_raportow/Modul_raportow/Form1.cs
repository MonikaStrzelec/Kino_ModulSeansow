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
            Init();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void generate_report_button_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateFrom, dateTo;

                int n = comboBox1.SelectedIndex;
                long id_pr;
                string name;

                dateFrom = dateTimePicker1.Value;
                dateTo = dateTimePicker2.Value;

                switch (n)
                {
                    case 1:
                        ReportGenerator.GenerateAllMoviesReport();
                        break;

                    case 2:
                        ReportGenerator.GenerateWorkTimeReport(dateFrom, dateTo);
                        break;

                    case 3:
                        id_pr =(int)comboBox2.SelectedValue;
                        name = comboBox2.Text;
                        ReportGenerator.GenerateIndividualWorkTime(dateFrom, dateTo, id_pr, name);
                        break;

                    case 4:
                        ReportGenerator.GenerateIncomeReport(dateFrom, dateTo);
                        break;

                    case 5:
                        ReportGenerator.GenerateSalariesReport(dateFrom, dateTo);
                        break;

                    case 6:
                        id_pr = (int)comboBox2.SelectedValue;
                        ReportGenerator.GenerateIndividualSalary(dateFrom, dateTo, id_pr);
                        break;

                    case 7:
                        ReportGenerator.GenerateFoodSaleReport(dateFrom, dateTo);
                        break;

                    default:
                        comboBox1.SelectedIndex = 0;
                        MessageBox.Show("Wybierz jakiś raport");
                        break;
                }

                                
                if (comboBox1.SelectedIndex != 0) MessageBox.Show("Raport został stworzony");

            }

            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd związany z tworzeniem raportu.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void Init()
        {

            try
            {
                 

            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.Items.Clear();

            comboBox1.Items.Add("---- Wybierz raport ----");
            comboBox1.Items.Add("Raport podsumowania filmów");
            comboBox1.Items.Add("Raport podsumowania czasu pracy pracowników");
            comboBox1.Items.Add("Raport podsumowania czasu pracy indywidualnego pracownika");
            comboBox1.Items.Add("Raport podsumowania przychodów kina");
            comboBox1.Items.Add("Raport pensji pracowników");
            comboBox1.Items.Add("Raport pensji indywidualnego pracownika");
            comboBox1.Items.Add("Raport zestawienia sprzedanego jedzenia");
            
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Clear();

            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd w zainicjowaniem listy raportów");
            }

            try
            {

                DataTable workers= SQLObject.SendCommand("SELECT dbo.g1_user.id_user AS id, dbo.g1_pearson.first_name + ' '+dbo.g1_pearson.last_name AS name FROM dbo.g1_user INNER JOIN dbo.g1_pearson ON dbo.g1_pearson.id_pearson=dbo.g1_user.id_pearson");
                // comboBox2.Items.Add(row[0].ToString());
                comboBox2.DisplayMember = workers.Columns[1].ColumnName;
                    comboBox2.ValueMember = workers.Columns[0].ColumnName; ;
                    comboBox2.DataSource = workers;

                comboBox2.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd w zainicjowaniem listy użytkowników");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = comboBox1.SelectedIndex;

            if (n == 0 || n == 1)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }

            if (n == 3 || n == 6) comboBox2.Enabled = true;
            else comboBox2.Enabled = false;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void close_button_Click(object sender, EventArgs e)
        {

        }

        private void form1_closing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy chcesz wyjść?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
            {
              e.Cancel = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value) MessageBox.Show("Data początkowa nie może być większa od daty końcowej", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value) MessageBox.Show("Data początkowa nie może być większa od daty końcowej", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
