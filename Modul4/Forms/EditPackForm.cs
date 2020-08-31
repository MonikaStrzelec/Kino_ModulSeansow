using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul4
{
    public partial class EditPackForm : Form
    {
        int _index;
        public EditPackForm(int index)
        {
            InitializeComponent();
          
            using (var context = new projektkinoEntities1())
            {
                 foreach (Product product in context.Product.ToList())
                 {
                         listBox1.Items.Add(product);
                 }
                var query = from st in context.PackPO
                            where st.PackID == index
                            from sy in context.Product
                            where st.ProductID == sy.IDProduct
                            select sy;

                foreach (Product product in query.ToList())
                {
                    listBox2.Items.Add(product);
                }

                Pack pack = context.Pack.Find(index);
                _index = index;
                label2.Text = pack.Name;
                textBox1.Text = pack.Name;
                numericUpDown1.Value = pack.Price;
            }

        }

        private void EditPackForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox2.Items.Count < 1 || String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("");
            }
            else
            {
                Pack.Delete(_index);
                Pack pack = new Pack();
                int id = pack.add(textBox1.Text, numericUpDown1.Value);
                for (int i = 0; i < listBox2.Items.Count;)
                {
                    bool xyz = false;
                    int counter = 0;
                    Product product = (Product)listBox2.Items[i];
                    for (int x = 0; x < listBox2.Items.Count; x++)
                    {
                        Product product1 = (Product)listBox2.Items[x];
                        if (product == product1)
                        {
                            xyz = true;
                            counter++;
                            listBox2.Items.Remove(product1);
                            x = -1;
                        }

                    }
                    if (!xyz)
                    {
                        i++;
                    }
                    PackPO packPO = new PackPO();
                    packPO.add(id, product, counter);
                }
                MessageBox.Show("");
                listBox2.Items.Clear();
            }
        }
    }
}
