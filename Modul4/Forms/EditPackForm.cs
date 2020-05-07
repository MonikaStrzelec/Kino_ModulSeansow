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
    }
}
