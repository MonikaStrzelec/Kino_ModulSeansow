using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Login
{
    public partial class MainMenu : Form
    {
        public MainMenu(int idd)
        {
            InitializeComponent();

            User logUser = new User();
            logUser.Id = idd;

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT id_permission FROM",con);

        }
      

        string connection = "Data Source=35.228.52.182,1433;Network Library = DBMSSOCN; Initial Catalog =Kino;User ID = sqlserver; Password=Pa$$w0rd";

        private void Button1_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            Form1 formlogin = new Form1();
            formlogin.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
