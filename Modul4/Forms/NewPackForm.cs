using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul4
{
    public partial class NewPackForm : Form
    {
        decimal Price;
        Product product;
        public NewPackForm()
        {
            InitializeComponent();
            
        }

        private void NewPackForm_Load(object sender, EventArgs e)
        {
            projektkinoEntities1 projektkinoEntities1 = new projektkinoEntities1();
            foreach (Product product in projektkinoEntities1.Product.ToList())
            {
                listBox1.Items.Add(product);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            product = (Product)listBox1.SelectedItem;
            Price += product.Price;
            numericUpDown1.Value = Price;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count < 1 || String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("");
            }
            else
            {
                Pack pack = new Pack();
                int id = pack.add(textBox1.Text, numericUpDown1.Value);
                foreach (Product product in listBox2.Items)
                {
                    PackPO packPO = new PackPO();
                    packPO.add(id, product);
                }
                MessageBox.Show("");
                listBox2.Items.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            product = (Product)listBox2.SelectedItem;
            numericUpDown1.Value -= product.Price;
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
