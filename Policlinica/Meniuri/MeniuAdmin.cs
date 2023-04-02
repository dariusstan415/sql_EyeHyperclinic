using MySql.Data.MySqlClient;
using Policlinica.Adaugare_FunctiiAngajati;
using Policlinica.FunctiiAngajati;
using Policlinica.Interfete;
using System;
using System.Data;
using System.Windows.Forms;

namespace Policlinica.Meniuri
{
    public partial class MeniuAdmin : Form, IDezautentificare
    {
        string numeAdmin;
        string prenumeAdmin;
        string emailLogin;
        string idUtilizatorAdmin;

        string idUtilizator;
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

        MySqlDataAdapter daAdapter = null;
        DataSet ds = null;
        private bool button3WasClicked = false;

        public MeniuAdmin(string nume, string prenume, string emailLogin, string idUtilizator)
        {
            InitializeComponent();

            numeAdmin = nume;
            prenumeAdmin = prenume;
            this.emailLogin = emailLogin;
            this.idUtilizatorAdmin = idUtilizator;

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
            textBox20.AppendText("Administrator");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Continuare_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Continuare_Click_1(object sender, EventArgs e)
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
                MessageBox.Show("Completati campul 'ID Utilizator'!");
            else if (button3WasClicked == false)
                MessageBox.Show("Apasati butonul 'Vezi informatii curente'!");
            else
            {
                idUtilizator = textBox13.Text;
                idPoliclinica = textBox21.Text;
                nume = textBox19.Text;
                prenume = textBox18.Text;
                adresa = textBox17.Text;
                nrTelefon = textBox16.Text;
                IBAN = textBox15.Text;
                email = textBox12.Text;

                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Modific_Utilizator('" + idUtilizator + "', '" + idPoliclinica + "', '" + nume + "', '" + prenume
                        + "', '" + adresa + "', '" + nrTelefon + "', '" + email + "', '" + IBAN + "');";
                int res = cmd.ExecuteNonQuery();

                if (res < 1)
                    MessageBox.Show("Modificare utilizator nereusita!");
                else
                {
                    MessageBox.Show("Modificare utilizator efectuata!");
                    conn.Close();
                }

                textBox13.Text = "";
                textBox21.Text = "";
                textBox19.Text = "";
                textBox18.Text = "";
                textBox17.Text = "";
                textBox16.Text = "";
                textBox15.Text = "";
                textBox12.Text = "";

                dataGridView1.DataSource = null;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || checkBox1.Checked == false)
                MessageBox.Show("Completati toate campurile!");
            else
            {
                idUtilizator = textBox11.Text;

                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Stergere_Utilizator('"  + idUtilizator + "');";
                int res = cmd.ExecuteNonQuery();

                if (res < 1)
                    MessageBox.Show("Stergere utilizator nereusita!");
                else
                {
                    MessageBox.Show("Stergere utilizator efectuata!");
                    conn.Close();
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
                MessageBox.Show("Completati campul 'ID Utilizator'!");
            else
            {
                button3WasClicked = true;

                idUtilizator = textBox13.Text;

                string cmdString;
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
                conn.Open();

                string Tabel = "Utilizatori";
                cmdString = "SELECT * FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                daAdapter = new MySqlDataAdapter(cmdString, conn);
                ds = new DataSet();
                daAdapter.Fill(ds, Tabel);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = Tabel;

                /*** idPoliclinica ***/
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                idPoliclinica = cmd.ExecuteScalar().ToString();
                textBox21.AppendText(idPoliclinica);

                /*** nume ***/
                cmd.CommandText = "SELECT Utilizatori.nume FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                nume = cmd.ExecuteScalar().ToString();
                textBox19.AppendText(nume);

                /*** prenume ***/
                cmd.CommandText = "SELECT Utilizatori.prenume FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                prenume = cmd.ExecuteScalar().ToString();
                textBox18.AppendText(prenume);

                /*** adresa ***/
                cmd.CommandText = "SELECT Utilizatori.adresa FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                adresa = cmd.ExecuteScalar().ToString();
                textBox17.AppendText(adresa);

                /*** nrTelefon ***/
                cmd.CommandText = "SELECT Utilizatori.nr_telefon FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                nrTelefon = cmd.ExecuteScalar().ToString();
                textBox16.AppendText(nrTelefon);

                /*** IBAN ***/
                cmd.CommandText = "SELECT Utilizatori.nr_telefon FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                IBAN = cmd.ExecuteScalar().ToString();
                textBox15.AppendText(IBAN);

                /*** email ***/
                cmd.CommandText = "SELECT Utilizatori.nr_telefon FROM Utilizatori WHERE Utilizatori.idUtilizator = '" + idUtilizator + "';";
                email = cmd.ExecuteScalar().ToString();
                textBox12.AppendText(email);

                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
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
