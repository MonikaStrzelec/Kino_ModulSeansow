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
    public partial class OrderDetailsForm : Form
    {
        int _index;
        public OrderDetailsForm(int index)
        {
            _index = index;
            InitializeComponent();
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            using (var context = new projektkinoEntities1())
            {
                dataGridView1.DataSource = context.SalePO.Where(x => x.SaleID == _index).ToList();
            }
            
        }
    }
}
