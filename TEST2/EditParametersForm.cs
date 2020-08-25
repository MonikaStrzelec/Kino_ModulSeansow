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

        private KinoEntities context;
        private ExtraTimeCallback callback;


        public EditParametersForm(ExtraTimeCallback callback)
        {
            this.callback = callback;
            context = new KinoEntities();
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e){}

        private void label2_Click(object sender, EventArgs e){}


        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 60 && numericUpDown1.Value < 20)
            {
                if (numericUpDown1.Value > 60)
                {
                    MessageBox.Show("reklamy nie mogą trwać krócej niz 15 min");
                }
                else
                {
                    MessageBox.Show("reklamy nie mogą trwać powyżej 45 min");
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
                    callback.uaktualnijCzas(new TimeCleanAndAd((int)numericUpDown2.Value, (int)numericUpDown1.Value));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

                string info;
                info = "Na pewno chcesz zamknac formatkę edycji parametrów?";
                string caption = "UWAGA!";
                MessageBoxButtons przycisk = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(info, caption, przycisk);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }

    public interface ExtraTimeCallback
    {
        void uaktualnijCzas(TimeCleanAndAd timeClean);
    }
}
