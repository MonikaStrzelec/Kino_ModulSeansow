using SprzedazBiletow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservation
{
    public partial class Sala : Form
    {        
        string connectionString;
        SqlConnection cnn;
        private Reservation rezerwacjaSala;
        Color wolne = Color.FromArgb(50, 200, 50);
        Color zajete = Color.FromArgb(175, 175, 175);
        Color rezerw = Color.FromArgb(50, 100, 250);
        HallView[,] saleMiejscas = new HallView[10, 5];

        public Sala(Reservation rezerwacja)
        {
            InitializeComponent();
            rezerwacjaSala = rezerwacja;
            connectionString = @"Data Source=35.228.52.182,1433;Initial Catalog=Kino; User ID=sqlserver; Password=Pa$$w0rd";
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, output1 = "";
            int row, nr, output2 = 0;

            cnn = new SqlConnection(connectionString);

            cnn.Open();

            Bitmap bmp = null;
            bmp = new Bitmap(System.Environment.CurrentDirectory + "\\jpg\\Miejsca.jpg");
            pictureBox1.Image = bmp;
            pictureBox1.Size = bmp.Size;

            //Pobranie informacji o dostępności miejsc na dany seans
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    row = j + 1;
                    nr = i + 1;
                    sql = "SELECT status, id FROM kino.dbo.Seat WHERE row = '"+ row +"' AND number = '" + nr + "' AND id_Timetable = '" + rezerwacja.IdTimetable + "'";
                    command = new SqlCommand(sql, cnn);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        output1 = dataReader.GetValue(0).ToString();
                        output2 = (int)dataReader.GetValue(1);
                    }

                    saleMiejscas[i, j] = new HallView();
                    saleMiejscas[i, j].setId(output2);
                    if (output1 == "wolne     ")
                    { 
                        saleMiejscas[i, j].setDost(1);
                    }
                    else if (output1 == "zajete    ")
                    { 
                        saleMiejscas[i, j].setDost(0);
                    }

                    saleMiejscas[i, j].setX(60 * (i + 1));
                    saleMiejscas[i, j].setY(60 + (74 * j));

                    dataReader.Close();
                    command.Dispose();
                }
            }
            cnn.Close();

            //Ustalenie dostępności miejsc
            //Wygenerowanie podglądu sali
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (saleMiejscas[i, j].getDost() == 1)
                    {
                        for (int n = 0; n < 40; n++)
                        {
                            for (int m = 0; m < 50; m++)
                            {
                                bmp.SetPixel(saleMiejscas[i, j].getX() + n, saleMiejscas[i, j].getY() + m, wolne);
                            }
                        }
                    }
                    else if (saleMiejscas[i, j].getDost() == 0)
                    {
                        for (int n = 0; n < 40; n++)
                        {
                            for (int m = 0; m < 50; m++)
                            {
                                bmp.SetPixel(saleMiejscas[i, j].getX() + n, saleMiejscas[i, j].getY() + m, zajete);
                            }
                        }
                    }
                    else
                    {
                        for (int n = 0; n < 40; n++)
                        {
                            for (int m = 0; m < 50; m++)
                            {
                                bmp.SetPixel(saleMiejscas[i, j].getX() + n, saleMiejscas[i, j].getY() + m, Color.FromArgb(0,0,0));
                            }
                        }
                    }
                }
            }
            pictureBox1.Refresh();
            label2.Text = rezerwacja.Tytuł;
        }

        private void Sala_Load(object sender, EventArgs e)
        {

        }

        private void wsteczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRezerwacja form = new FormRezerwacja();
            form.ShowDialog();
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Interakcje podglądu sali
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = null;
            bmp = (Bitmap)pictureBox1.Image;

            //Sprawdzanie lokaliacji "kliknięcia"
            Form form2 = new Form();
            form2.Left = Form1.ActiveForm.Left;
            form2.Top = Form1.ActiveForm.Top;
            int lokX, lokY;
            lokX = (Cursor.Position.X - form2.Left - pictureBox1.Location.X);
            lokY = (Cursor.Position.Y - form2.Top - pictureBox1.Location.Y - 30);

            //Zmiana koloru miejsca na podglądzie
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (lokX > saleMiejscas[i, j].getX() && lokX < saleMiejscas[i, j].getX() + 40 && lokY > saleMiejscas[i, j].getY() && lokY < saleMiejscas[i, j].getY() + 50)
                    {
                        if (saleMiejscas[i, j].getDost() == 1 && bmp.GetPixel(saleMiejscas[i, j].getX(), saleMiejscas[i, j].getY()) == wolne)
                        {
                            for (int n = 0; n < 40; n++)
                            {
                                for (int m = 0; m < 50; m++)
                                {
                                    bmp.SetPixel(saleMiejscas[i, j].getX() + n, saleMiejscas[i, j].getY() + m, rezerw);
                                    saleMiejscas[i, j].setDost(2);
                                    
                                }
                            }
                        }
                        else if (saleMiejscas[i, j].getDost() == 2 && bmp.GetPixel(saleMiejscas[i, j].getX(), saleMiejscas[i, j].getY()) == rezerw)
                        {
                            for (int n = 0; n < 40; n++)
                            {
                                for (int m = 0; m < 50; m++)
                                {
                                    bmp.SetPixel(saleMiejscas[i, j].getX() + n, saleMiejscas[i, j].getY() + m, wolne);
                                    saleMiejscas[i, j].setDost(1);
                                }
                            }
                        }
                    }
                }
            }
            pictureBox1.Refresh();
        }

        //Zapis danych o wybranych miejscach i rodzajach biletów
        private void button1_Click(object sender, EventArgs e)
        {
            List<Ticket> ticketList = new List<Ticket>();
            int biletyUlgowe = (int)numericUpDown1.Value;
            int lbbiletow = 0;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (saleMiejscas[i, j].getDost() == 2)
                    {
                        Ticket ticket = new Ticket();
                        ticket.IdReservation = rezerwacjaSala.IdReservation;
                        ticket.IdSeat = saleMiejscas[i, j].getId();
                        if (biletyUlgowe > 0)
                        {
                            ticket.Cena = 12;
                            ticket.Rodzaj = "Ulgowy";
                            lbbiletow++;
                            biletyUlgowe--;
                        }
                        else
                        {
                            ticket.Cena = 18;
                            ticket.Rodzaj = "Normalny";
                            lbbiletow++;
                        }
                        ticketList.Add(ticket);
                    }
                }
            }
            if(lbbiletow == 0)
            {
                MessageBox.Show("Nie wybrano żadnych miejsc.");
            }
            else if (lbbiletow < (int)numericUpDown1.Value || lbbiletow < 0)
            {
                MessageBox.Show("Podano nieprawidłową liczbę biletów ulgowych.");
            }
            else
            {
                this.Hide();
                ZatwierdzRezerwacje form = new ZatwierdzRezerwacje(rezerwacjaSala, ticketList);
                form.ShowDialog();
            }        

          
        }
    }
}
