﻿using Modul4.Properties;
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
            projektkinoEntities1 projektkinoEntities1 = new projektkinoEntities1();
            dataGridView2.DataSource = projektkinoEntities1.Product.ToList<Product>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product.add(textBox1.Text, numericUpDown2.Value, (int)numericUpDown1.Value);
            Refresh();

        }

        private void Refresh()
        {
            projektkinoEntities1 projektkinoEntities1 = new projektkinoEntities1();
            dataGridView2.DataSource = projektkinoEntities1.Product.ToList<Product>();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int index = Helpers.getIndex(dataGridView2);
            EditForm editForm = new EditForm(index);
            editForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = Helpers.getIndex(dataGridView2);
            Product.Delete(index);
            Refresh();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
