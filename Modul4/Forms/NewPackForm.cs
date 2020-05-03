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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pack pack = new Pack();
            int id = pack.add(textBox1.Text, numericUpDown1.Value);
            foreach (Product product in listBox2.Items)
            {
                PackPO packPO = new PackPO();
                packPO.add(id, product);
            }
            MessageBox.Show("Dodano zestaw");
            listBox2.Items.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
