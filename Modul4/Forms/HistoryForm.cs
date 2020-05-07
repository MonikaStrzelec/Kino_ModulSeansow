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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            using (var context = new projektkinoEntities1())
            {
                dataGridView1.DataSource = context.Sale.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helpers.GetIndex(dataGridView1);
        }
    }
}
