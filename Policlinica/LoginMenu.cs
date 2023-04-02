using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Policlinica.Adaugare_FunctiiAngajati;
using Policlinica.FunctiiAngajati;
using Policlinica.Meniuri;

namespace Policlinica
{
    public partial class LoginMenu : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        string cmdString = null;
        MySqlDataAdapter daAdapter = null;
        DataSet ds = null;

        AddAdmin admin;

        AddMedic medic;
        AddAsistent asistent;
        AddExpert expert;
        AddInspector inspector;
        AddReceptioner receptioner;

        int IdS;
        DataGridViewRow row;

        string email;
        public LoginMenu()
        {
            InitializeComponent();

            cmd = new MySqlCommand();
            conn = null;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (listBox1.Text == "Administrator")
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='administrator';Pwd='cristinadariusbd10*';");
                conn.Open();

                MeniuAdmin secondWindow = new MeniuAdmin();
                secondWindow.Show();
            }

            if (listBox1.Text == "Super-Administrator")
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='super-administrator';Pwd='cristinadariusbd10*';");
                conn.Open();

                MeniuSuperAdmin secondWindow = new MeniuSuperAdmin();
                secondWindow.Show();
            }

            if (listBox1.Text == "Inspector Resurse Umane")
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
                conn.Open();

                MeniuInspector secondWindow = new MeniuInspector();
                this.Hide();
                secondWindow.Show();
                this.Close();
            }

            if (listBox1.Text == "Expert Financiar-Contabil")
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
                conn.Open();

                MeniuExpert secondWindow = new MeniuExpert();
                secondWindow.Show();
            }

            if (listBox1.Text == "Receptioner")
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
                conn.Open();

                MeniuReceptioner secondWindow = new MeniuReceptioner();
                secondWindow.Show();
            }

            if (listBox1.Text == "Asistent Medical")
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
                conn.Open();

                MeniuAsistent secondWindow = new MeniuAsistent();
                secondWindow.Show();
            }

            if (listBox1.Text == "Medic")
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
                conn.Open();

                MeniuMedic secondWindow = new MeniuMedic();
                secondWindow.Show();
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else if (textBox1.Text.Contains("medic") != true && textBox1.Text.Contains("administrator") != true && textBox1.Text.Contains("super-administrator") != true
                && textBox1.Text.Contains("asistent") != true && textBox1.Text.Contains("expert") != true && textBox1.Text.Contains("inspector") != true
                && textBox1.Text.Contains("receptioner") != true)
                    MessageBox.Show("Utilizator nevalid!");
            else if (textBox2.Text != "cristinadariusbd10*")
                MessageBox.Show("Parola nevalida!");
            else
            {
                email = textBox1.Text;
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Utilizatori.idUtilizator FROM Utilizatori WHERE Utilizatori.email = '" + email + "';";
                object idVerificare = cmd.ExecuteScalar();

                if (idVerificare == null)
                    MessageBox.Show("E-mail incorect!");
                else
                {
                    cmd.CommandText = "SELECT Utilizatori.nume FROM Utilizatori WHERE Utilizatori.email = '" + email + "';";
                    string numeLogin = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "SELECT Utilizatori.prenume FROM Utilizatori WHERE Utilizatori.email = '" + email + "';";
                    string prenumeLogin = cmd.ExecuteScalar().ToString();

                    cmd.CommandText = "SELECT Utilizatori.idUtilizator FROM Utilizatori WHERE Utilizatori.email = '" + email + "';";
                    string idUtilizator = cmd.ExecuteScalar().ToString();

                    if (textBox1.Text.Contains("administrator") == true)
                    {
                        MeniuAdmin secondWindow = new MeniuAdmin(numeLogin, prenumeLogin, email, idUtilizator);
                        this.Hide();
                        secondWindow.ShowDialog();
                        this.Close();
                    }

                    if (textBox1.Text.Contains("super-administrator") == true)
                    {
                        MeniuSuperAdmin secondWindow = new MeniuSuperAdmin(numeLogin, prenumeLogin, email, idUtilizator);
                        this.Hide();
                        secondWindow.ShowDialog();
                        this.Close();
                    }

                    if (textBox1.Text.Contains("inspector") == true)
                    {
                        MeniuInspector secondWindow = new MeniuInspector(numeLogin, prenumeLogin, email, idUtilizator);
                        this.Hide();
                        secondWindow.ShowDialog();
                        this.Close();
                    }

                    if (textBox1.Text.Contains("expert") == true)
                    {
                        MeniuExpert secondWindow = new MeniuExpert(numeLogin, prenumeLogin, email, idUtilizator);
                        this.Hide();
                        secondWindow.ShowDialog();
                        this.Close();
                    }

                    if (textBox1.Text.Contains("receptioner") == true)
                    {
                        MeniuReceptioner secondWindow = new MeniuReceptioner(numeLogin, prenumeLogin, email, idUtilizator);
                        this.Hide();
                        secondWindow.ShowDialog();
                        this.Close();
                    }

                    if (textBox1.Text.Contains("asistent") == true)
                    {
                        MeniuAsistent secondWindow = new MeniuAsistent(numeLogin, prenumeLogin, email, idUtilizator);
                        this.Hide();
                        secondWindow.ShowDialog();
                        this.Close();
                    }

                    if (textBox1.Text.Contains("medic") == true)
                    {
                        MeniuMedic secondWindow = new MeniuMedic(numeLogin, prenumeLogin, email, idUtilizator);
                        this.Hide();
                        secondWindow.ShowDialog();
                        this.Close();
                    }
                }
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
