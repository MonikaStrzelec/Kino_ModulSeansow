using Kino.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino
{
    public partial class EditParametersForm : Form
    {
        private Performance performance;
        private KinoEntities context;
        public EditParametersForm(Performance performance)
        {
            this.performance = performance ;
            context = new KinoEntities();

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = context.Performances.SingleOrDefault(p => p.id == performance.id);

            if (result != null) {

                try {
                    decimal sum = numericUpDown1.Value + numericUpDown2.Value;

                    result.adsDuration = new TimeSpan((int )sum/60, (int)sum%60, 0 );

                    context.SaveChanges();

                } catch (Exception ex) {
                    MessageBox.Show(ex.StackTrace);
                }
            
            }
        }
    }
}
