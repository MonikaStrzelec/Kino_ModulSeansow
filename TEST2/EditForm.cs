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
    public partial class EditForm : Form
    {
        EditParametersForm edycjaParametrow = null;

        public EditForm(Timetable timetable)
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {// EDYCJA PARAMETRÓW

            if (edycjaParametrow == null)
            {
                edycjaParametrow.Show();
                edycjaParametrow.BringToFront();
            }
            else
                edycjaParametrow.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        { //ZAMKNIĘCIE FORMULARZA
     
            string info = "Nie edytowałeś seansu, na pewno chcesz zamknąć?";
            string caption = "UWAGA!";
            MessageBoxButtons przycisk = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(info, caption, przycisk);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //EDYCJA SEANSU

        }
    }
}
