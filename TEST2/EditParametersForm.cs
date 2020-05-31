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

            if (result != null) 
            {
                if (numericUpDown1.Value > 60 && numericUpDown1.Value < 20)
                {
                    if (numericUpDown1.Value > 60)
                    {
                        MessageBox.Show("reklamy nie mogą trwać prócej niz 20 min");
                    }
                    else
                    {
                        MessageBox.Show("reklamy nie mogą trwać powyżej 60 min");
                    }
                }

                else if (numericUpDown2.Value > 180 && numericUpDown2.Value <= 5)
                {
                    if (numericUpDown2.Value > 180)
                    {
                        MessageBox.Show("sprzątanie nie może trwać więcej niż 2h!");
                    }
                    else
                    {
                        MessageBox.Show("sprzątanie nie może być krótsze niż 5 min!");
                    }
                }

                else
                {
                    try 
                    {
                        decimal sum = numericUpDown1.Value + numericUpDown2.Value;

                        result.adsDuration = new TimeSpan((int )sum/60, (int)sum%60, 0 );

                        context.SaveChanges();

                    } 
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.StackTrace);
                    }
                }
            }
        }
    }
}
