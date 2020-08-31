using Modul4.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Modul4
{
    public partial class ManagementForm : Form
    { 
        public ManagementForm()
        {
            InitializeComponent();


        }

        private void ManagementForm_Load(object sender, EventArgs e)
        {
            Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Type name of the product");
            }
            else
            { 
                Product.add(textBox1.Text, numericUpDown2.Value, (int)numericUpDown1.Value);
                MessageBox.Show("Product added");
                Refresh();
            }
                

        }

        new private void Refresh()
        {
            projektkinoEntities1 projektkinoEntities1 = new projektkinoEntities1();
            dataGridView2.DataSource = projektkinoEntities1.Product.ToList<Product>();
            dataGridView1.DataSource = projektkinoEntities1.Pack.ToList<Pack>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(Helpers.GetIndex(dataGridView2));
            editForm.ShowDialog();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product.Delete(Helpers.GetIndex(dataGridView2));
            MessageBox.Show("Product deleted");
            Refresh();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewPackForm newPackForm = new NewPackForm();
            newPackForm.ShowDialog();
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                EditPackForm editPackForm = new EditPackForm(Helpers.GetIndex(dataGridView1));
                editPackForm.ShowDialog();
                Refresh();
            }
            else
            {
                MessageBox.Show("Empty grid view");
            }    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pack.Delete(Helpers.GetIndex(dataGridView1));
            MessageBox.Show("Pack deleted");
            Refresh();
        }
    }
}
