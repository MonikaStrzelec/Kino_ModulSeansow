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

        string connection = "Server=tcp:kinosql.database.windows.net,1433;Initial Catalog=kino;Persist Security Info=False;User ID=student;Password=Pa$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
                if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    MessageBox.Show("Enter login and password");
                    textBoxLogin.Focus();
                    return;
                }
                else
                {

                    SqlConnection con = new SqlConnection(connection);

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.User WHERE login=@Login AND password=@password;", con);
                    cmd.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("@password", StringHash(textBoxPassword.Text));


                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();

                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1)
                    {
                        MessageBox.Show("Successful");        //przejście do menu głównego
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Check your login and password and try again");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }


        private void ButtonLogInWithCode_Click(object sender, EventArgs e)
        {
            #region DATABASE CODE CONNECTION
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Enter your code");
                    textBox3.Focus();
                    return;
                }
                else
                {

                    SqlConnection con = new SqlConnection(connection);

                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.User WHERE code=@Code;", con);
                    cmd.Parameters.AddWithValue("@Code", StringHash(textBox3.Text));

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();

                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1)
                    {
                        MessageBox.Show("Successful.");        //przejście do menu głównego
                    }
                    else
                    {
                        MessageBox.Show("Login failed. Check your code and try again.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            #endregion
        }

        #region NumericKeyboard
        private void Button1_Click_1(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "1";

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "9";
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text + "0";
        }
        #endregion

        private void ButtonClearCode_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
