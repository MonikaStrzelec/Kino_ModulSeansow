using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connection = "Server=tcp:kinosql.database.windows.net,1433;Initial Catalog=Kino;Persist Security Info=False;User ID=student;Password=Pa$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public static byte[] StringHash(string str)
        {
            HashAlgorithm algorithm = SHA1.Create();
            return algorithm.ComputeHash(Encoding.Unicode.GetBytes(str));
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region DATABASE LOGIN CONNECTION
            try
            {
                if (textBoxLogin.Text == "" && textBoxPassword.Text == "")
                {
                    MessageBox.Show("Enter any Login or Password");
                }
                else
                {

                    SqlConnection con = new SqlConnection(connection);

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.User WHERE login=@Login AND passwordHash=@PasswordHash;", con);
                    cmd.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("@PasswordHash", StringHash(textBoxPassword.Text));

                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();

                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1 )
                         {
                        MessageBox.Show("Poprawnie zalogowano użytkownika.");
                        }
                     else
                         {
                        MessageBox.Show("Błąd logowania, wprowadź ponownie dane.");
                        }
                    
                }

                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
