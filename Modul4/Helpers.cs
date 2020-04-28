using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul4
{
    class Helpers
    {
        public static int getIndex(DataGridView dataGridView)
        {
            int rowindex = dataGridView.CurrentCell.RowIndex;
            int index = Int32.Parse(dataGridView.Rows[rowindex].Cells[0].Value.ToString());
            return index;
        }
    }
}
