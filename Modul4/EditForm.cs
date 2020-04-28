using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul4
{
    public partial class EditForm : Form
    {
        int indexik;
        public EditForm(int index)
        {
            InitializeComponent();
            using (var context = new projektkinoEntities1())
            {
                Product product = context.Product.Find(index);
                indexik = index;
                textBox1.Text = product.Name;
                numericUpDown1.Value = product.Price;
                numericUpDown2.Value = product.Amount;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product.edit(indexik, textBox1.Text, numericUpDown1.Value, (int)numericUpDown2.Value);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
