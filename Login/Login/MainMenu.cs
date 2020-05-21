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
            
            try
            {
                #region select_id_permission
                string id_permission;
                DataTable dt = new DataTable();
                dt.Columns.Add("id_permission");
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("SELECT id_permission FROM dbo.g1_permission_list WHERE id_user=@user_id;", con);
                cmd.Parameters.AddWithValue("@user_id", logUser.Id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                
                
                foreach(DataRow row in dt.Rows)
                {
                    id_permission = row["id_permission"].ToString();
                    idPermissionList.Add(id_permission);
                }

                foreach (var id in idPermissionList)
                    listBox1.Items.Add(id);
                #endregion

                #region select_string_permission
                foreach (var id in idPermissionList)
                {
                    string name_permission;
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("permission_name");
                    SqlConnection con2 = new SqlConnection(connection);
                    SqlCommand cmd2 = new SqlCommand("SELECT permission_name FROM dbo.g1_permission WHERE id_permission=@id_permission;", con);
                    cmd2.Parameters.AddWithValue("@id_permission", id);
                    con2.Open();
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    dt2.Load(dr2);


                    foreach (DataRow row in dt2.Rows)
                    {
                        name_permission = row["permission_name"].ToString();
                        logUser.AddItemToPermissionList(name_permission);                     
                        listBox2.Items.Add(logUser.PrintListOfPermission());
                    }
                  
                }
                #endregion
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        
        List<string> idPermissionList = new List<string>();
    
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
