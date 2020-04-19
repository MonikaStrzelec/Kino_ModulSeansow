using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelMenagement
{
    public partial class Form1 : Form
    {
        Menagers.TaskMenagers taskMenagers;
        Form newUserForm;

        public Form1()
        {
            InitializeComponent();
            taskMenagers = new Menagers.TaskMenagers();
        }

        private void addUser_button_Click(object sender, EventArgs e)
        {
            newUserForm = new Form();

            Label firstName = new Label();
            Button addUser = new Button();
            addUser.Text = "sdsddfjhskjfskfsdkhfgsdkfsdkjf";
            addUser.Left = Left;
            addUser.Top = Top;
            addUser.Click += new EventHandler(this.addUser_Click);
            
            firstName.Text = "testujemy";


            newUserForm.Controls.Add(firstName);
            newUserForm.Controls.Add(addUser);

            newUserForm.Show();

            this.Hide();

            
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            newUserForm.Close();
            this.Show();
        }

        private void TaskSaveBtn_Click(object sender, EventArgs e)
        {
            taskMenagers.addTask(TaskName_textBox.Text,TaskDescription_textBox.Text);
        }
    }
}
