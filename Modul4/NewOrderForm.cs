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
    public partial class NewOrderForm : Form
    {
        public NewOrderForm()
        {
            InitializeComponent();
        }

        new private void Refresh()
        {
            projektkinoEntities1 projektkinoEntities1 = new projektkinoEntities1();
            packGrid.DataSource = projektkinoEntities1.Pack.ToList<Pack>();
        }

        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
