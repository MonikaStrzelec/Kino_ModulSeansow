using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class FormPermissionAdd : Form
    {
        public FormPermissionAdd()
        {
            InitializeComponent();
            refreshDataGridView();
        }

        string connection = "Data Source=35.228.52.182,1433;Network Library = DBMSSOCN; Initial Catalog =Kino;User ID = sqlserver; Password=Pa$$w0rd";


        private void label1_Click(object sender, EventArgs e) { }


        private void refreshDataGridView()
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Select id_permission, permission_name FROM dbo.g1_permission;", con);
                con.Open();

                SqlDataReader dataReader = cmd.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataGridView1.DataSource = dataTable;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void buttonAddPermission_Click(object sender, EventArgs e)
        {
            bool check = User.CheckPermission("addPermission");
            try
            {
                if (check == true)
                {
                    SqlConnection con2 = new SqlConnection(connection);
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO dbo.g1_permission (permission_name) VALUES (@permissionName);", con2);
                    cmd2.Parameters.AddWithValue("@permissionName", textBox1.Text);
                    con2.Open();
                    int recordsAffected = cmd2.ExecuteNonQuery();
                    if (recordsAffected == 1)
                    {
                        MessageBox.Show("Permission has been added successfully.");
                        textBox1.Clear();
                        refreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Error, permission has not been stated.");
                    }

                    con2.Close();
                }
                else
                    MessageBox.Show("You have no permission to add new permission.");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());            }
        }


        private void buttonDeletePermission_Click(object sender, EventArgs e)
        {
            bool check = User.CheckPermission("deletePermission");
            try
            {
                if (check == true)
                {
                    var selectedItemId = dataGridView1.SelectedCells[0].Value;
                    var selectedItemName = dataGridView1.SelectedCells[1].Value;
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want delete permission: " + selectedItemName + "?", "Delete the permission", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (dataGridView1.SelectedRows.Count == 1)
                        {
                            SqlConnection con3 = new SqlConnection(connection);
                            SqlCommand cmd3 = new SqlCommand("DELETE FROM dbo.g1_permission WHERE id_permission=@idPermission;", con3);
                            cmd3.Parameters.AddWithValue("@idPermission", selectedItemId);
                            con3.Open();
                            cmd3.ExecuteNonQuery();
                            con3.Close();
                            MessageBox.Show("The permission with id: " + selectedItemId + ", has been deleted.");
                            refreshDataGridView();
                        }
                        else
                            MessageBox.Show("Error, the permission has not been deleted.");
                    }
                    else if (dialogResult == DialogResult.No)
                        return;
                }

                else
                    MessageBox.Show("You have no permission to delete a permission");
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
