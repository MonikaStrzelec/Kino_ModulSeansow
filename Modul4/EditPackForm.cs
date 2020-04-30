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
    public partial class EditPackForm : Form
    {
        public EditPackForm(int index)
        {
            InitializeComponent();
            projektkinoEntities1 projektkinoEntities1 = new projektkinoEntities1();
            foreach (Product product in projektkinoEntities1.Product.ToList())
            {
                listBox1.Items.Add(product);
            }

        }

        private void EditPackForm_Load(object sender, EventArgs e)
        {

        }
    }
}
