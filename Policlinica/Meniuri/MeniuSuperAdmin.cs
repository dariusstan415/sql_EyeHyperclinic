using MySql.Data.MySqlClient;
using Policlinica.Adaugare_FunctiiAngajati;
using Policlinica.FunctiiAngajati;
using Policlinica.Interfete;
using System;
using System.Windows.Forms;

namespace Policlinica.Meniuri
{
    public partial class MeniuSuperAdmin : Form, IDezautentificare
    {
        string numeSuperAdmin;
        string prenumeSuperAdmin;
        string emailLogin;
        string idUtilizatorSuperAdmin;

        string idPoliclinica;
        string CNP;
        string nume;
        string prenume;
        string adresa;
        string nrTelefon;
        string IBAN;
        string nrContract;
        string dataAngajarii;
        string email;
        int functie;
        string numeSql;
        string prenumeSql;
        public MeniuSuperAdmin(string nume, string prenume, string emailLogin, string idUtilizator)
        {
            InitializeComponent();

            numeSuperAdmin = nume;
            prenumeSuperAdmin = prenume;
            this.emailLogin = emailLogin;
            this.idUtilizatorSuperAdmin = idUtilizator;

            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = null;

            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
            conn.Open();

            /*** idPoliclinica ***/
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            idPoliclinica = cmd.ExecuteScalar().ToString();
            textBox30.AppendText(idPoliclinica);

            /*** CNP ***/
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            CNP = cmd.ExecuteScalar().ToString();
            textBox29.AppendText(CNP);

            /*** nume ***/
            cmd.CommandText = "SELECT Utilizatori.nume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            numeSql = cmd.ExecuteScalar().ToString();
            textBox28.AppendText(numeSql);

            /*** prenume ***/
            cmd.CommandText = "SELECT Utilizatori.prenume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            prenumeSql = cmd.ExecuteScalar().ToString();
            textBox27.AppendText(prenumeSql);

            /*** adresa ***/
            cmd.CommandText = "SELECT Utilizatori.adresa FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            adresa = cmd.ExecuteScalar().ToString();
            textBox26.AppendText(adresa);

            /*** nrTelefon ***/
            cmd.CommandText = "SELECT Utilizatori.nr_telefon FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrTelefon = cmd.ExecuteScalar().ToString();
            textBox25.AppendText(nrTelefon);

            /*** IBAN ***/
            cmd.CommandText = "SELECT Utilizatori.IBAN FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            IBAN = cmd.ExecuteScalar().ToString();
            textBox14.AppendText(IBAN);

            /*** email ***/
            cmd.CommandText = "SELECT Utilizatori.email FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            email = cmd.ExecuteScalar().ToString();
            textBox22.AppendText(email);

            /*** dataAngajarii ***/
            cmd.CommandText = "SELECT Utilizatori.data_angajarii FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            dataAngajarii = cmd.ExecuteScalar().ToString();
            textBox23.AppendText(dataAngajarii);

            /*** nrContract ***/
            cmd.CommandText = "SELECT Utilizatori.nr_contract FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrContract = cmd.ExecuteScalar().ToString();
            textBox24.AppendText(nrContract);

            /*** idFunctie ***/
            textBox20.AppendText("Super-administrator");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Continuare_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""
            || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == ""
            || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == ""
            || textBox10.Text == "" || listBox1.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                if (listBox1.Text == "Inspector resurse umane")
                    functie = 1;
                if (listBox1.Text == "Expert financiar-contabil")
                    functie = 2;
                if (listBox1.Text == "Receptioner")
                    functie = 3;
                if (listBox1.Text == "Asistent medical")
                    functie = 4;
                if (listBox1.Text == "Medic")
                    functie = 5;
                if (listBox1.Text == "Adminsitrator")
                    functie = 6;

                idPoliclinica = textBox1.Text;
                CNP = textBox2.Text;
                nume = textBox3.Text;
                prenume = textBox4.Text;
                adresa = textBox5.Text;
                nrTelefon = textBox6.Text;
                IBAN = textBox7.Text;
                nrContract = textBox8.Text;
                dataAngajarii = textBox9.Text;
                email = textBox10.Text;


                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Insert_Utilizatori('" + idPoliclinica + "', '" + CNP + "', '" + nume + "', '" + prenume
                        + "', '" + adresa + "', '" + nrTelefon + "', '" + email + "', '" + IBAN + "', '" + nrContract + "', '" + dataAngajarii
                        + "', '" + functie + "');";
                int res = cmd.ExecuteNonQuery();

                if (res < 1)
                    MessageBox.Show("Inserare utilizator nereusita!");
                else
                {
                    MessageBox.Show("Inserare utilizator efectuata!");
                    conn.Close();
                }

                if (functie == 1)
                {
                    conn.Close();
                    AddInspector secondWindow = new AddInspector();
                    this.Hide();
                    secondWindow.ShowDialog();
                    this.Close();
                }

                if (functie == 2)
                {
                    conn.Close();
                    AddExpert secondWindow = new AddExpert();
                    this.Hide();
                    secondWindow.ShowDialog();
                    this.Close();
                }

                if (functie == 3)
                {
                    conn.Close();
                    AddReceptioner secondWindow = new AddReceptioner();
                    this.Hide();
                    secondWindow.ShowDialog();
                    this.Close();
                }

                if (functie == 4)
                {
                    conn.Close();
                    AddAsistent secondWindow = new AddAsistent();
                    this.Hide();
                    secondWindow.ShowDialog();
                    this.Close();
                }

                if (functie == 5)
                {
                    conn.Close();
                    AddMedic secondWindow = new AddMedic();
                    this.Hide();
                    secondWindow.ShowDialog();
                    this.Close();
                }

                if (functie == 5)
                {
                    conn.Close();
                    AddMedic secondWindow = new AddMedic();
                    this.Hide();
                    secondWindow.ShowDialog();
                    this.Close();
                }

                if (functie == 6)
                {
                    conn.Close();
                    AddAdmin secondWindow = new AddAdmin();
                    this.Hide();
                    secondWindow.ShowDialog();
                    this.Close();
                }
            }
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        public void Dezautentificare()
        {
            LoginMenu secondWindow = new LoginMenu();
            this.Hide();
            secondWindow.ShowDialog();
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Dezautentificare();
        }
    }
}
