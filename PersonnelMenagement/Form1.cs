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
        Menagers.UserMenager userMenegers;
        Form newUserForm;

        TextBox firstName_textBox;
        TextBox lastName_textBox;
        TextBox login_textBox;
        TextBox password_textBox;
        



        public Form1()
        {
            InitializeComponent();
            taskMenagers = new Menagers.TaskMenagers();
            userMenegers = new Menagers.UserMenager();


            

        }

        private void addUser_button_Click(object sender, EventArgs e)
        {
            newUserForm = new Form();
            newUserForm.FormClosed += new FormClosedEventHandler(Inicio_FormClosed_1);
            newUserForm.Size = new Size(280, 200);
            newUserForm.FormBorderStyle = FormBorderStyle.FixedSingle;

            Button addUser = new Button();
            addUser.Text = "Dodaj użytkownika";
            addUser.Location = new Point(100 , 115);
            addUser.Click += new EventHandler(this.addUser_Click);

            Label firstName_label = new Label();
            firstName_label.Text = "Imię: ";
            firstName_label.Location = new Point(12,15);
            firstName_label.Size = new Size(70, 20);

            firstName_textBox = new TextBox();
            firstName_textBox.Location = new Point(83, 15);
            firstName_textBox.Size = new Size(150, 20);

            Label lastName_label = new Label();
            lastName_label.Text = "Nazwisko: ";
            lastName_label.Location = new Point(12, 40);
            lastName_label.Size = new Size(70, 20);

            lastName_textBox = new TextBox();
            lastName_textBox.Location = new Point(83, 40);
            lastName_textBox.Size = new Size(150, 20);

            Label login_label = new Label();
            login_label.Text = "Login: ";
            login_label.Location = new Point(12, 65);
            login_label.Size = new Size(70, 20);

            login_textBox = new TextBox();
            login_textBox.Location = new Point(83, 65);
            login_textBox.Size = new Size(150, 20);

            Label password_label = new Label();
            password_label.Text = "Hasło: ";
            password_label.Location = new Point(12, 90);
            password_label.Size = new Size(70, 20);

            password_textBox = new TextBox();
            password_textBox.Location = new Point(83, 90);
            password_textBox.Size = new Size(150, 20);
            password_textBox.PasswordChar = '*';




            newUserForm.Controls.Add(addUser);
            newUserForm.Controls.Add(firstName_label);
            newUserForm.Controls.Add(firstName_textBox);
            newUserForm.Controls.Add(lastName_label);
            newUserForm.Controls.Add(lastName_textBox);
            newUserForm.Controls.Add(login_label);
            newUserForm.Controls.Add(login_textBox);
            newUserForm.Controls.Add(password_label);
            newUserForm.Controls.Add(password_textBox);

            newUserForm.Show();
            this.Hide();



        }




        private void addUser_Click(object sender, EventArgs e)
        {
            this.Show();

            Models.User user = new Models.User();
            user.firstName = password_textBox.Text;
            user.lastName = lastName_textBox.Text;
            user.login = login_textBox.Text;
            user.passwordHash = password_textBox.Text;
            user.baseSalary = 0;
            user.codeHash = "";
            user.hourlyRate = 0;

            userMenegers.addUser(user);

            newUserForm.Close();
        }

        private void TaskSaveBtn_Click(object sender, EventArgs e)
        {
            taskMenagers.addTask(TaskName_textBox.Text,TaskDescription_textBox.Text);
        }

        private void Inicio_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}