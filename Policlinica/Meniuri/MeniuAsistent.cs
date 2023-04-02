using MySql.Data.MySqlClient;
using Policlinica.Interfete;
using System;
using System.Data;
using System.Windows.Forms;

namespace Policlinica.Meniuri
{
    public partial class MeniuAsistent : Form, IDezautentificare
    {
        string numeAsistent;
        string prenumeAsistent;
        string emailLogin;

        string idUtilizator;
        string idPoliclinica;
        string CNP;
        string numeSql;
        string prenumeSql;
        string adresa;
        string nrTelefon;
        string IBAN;
        string nrContract;
        string dataAngajarii;
        string email;
        string functie;

        string cmdString;
        MySqlDataAdapter daAdapter = null;
        DataSet ds = null;
        MySqlConnection conn = null;

        public MeniuAsistent(string nume, string prenume, string emailLogin, string idUtilizator)
        {
            InitializeComponent();

            numeAsistent = nume;
            prenumeAsistent = prenume;
            this.emailLogin = emailLogin;
            this.idUtilizator = idUtilizator;

            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = null;

            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
            conn.Open();

            /*** idPoliclinica ***/
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            idPoliclinica = cmd.ExecuteScalar().ToString();
            textBox1.AppendText(idPoliclinica);

            /*** CNP ***/
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            CNP = cmd.ExecuteScalar().ToString();
            textBox2.AppendText(CNP);

            /*** nume ***/
            cmd.CommandText = "SELECT Utilizatori.nume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            numeSql = cmd.ExecuteScalar().ToString();
            textBox3.AppendText(numeSql);

            /*** prenume ***/
            cmd.CommandText = "SELECT Utilizatori.prenume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            prenumeSql = cmd.ExecuteScalar().ToString();
            textBox4.AppendText(prenumeSql);

            /*** adresa ***/
            cmd.CommandText = "SELECT Utilizatori.adresa FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            adresa = cmd.ExecuteScalar().ToString();
            textBox5.AppendText(adresa);

            /*** nrTelefon ***/
            cmd.CommandText = "SELECT Utilizatori.nr_telefon FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrTelefon = cmd.ExecuteScalar().ToString();
            textBox6.AppendText(nrTelefon);

            /*** IBAN ***/
            cmd.CommandText = "SELECT Utilizatori.IBAN FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            IBAN = cmd.ExecuteScalar().ToString();
            textBox12.AppendText(IBAN);

            /*** email ***/
            cmd.CommandText = "SELECT Utilizatori.email FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            email = cmd.ExecuteScalar().ToString();
            textBox10.AppendText(email);

            /*** dataAngajarii ***/
            cmd.CommandText = "SELECT Utilizatori.data_angajarii FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            dataAngajarii = cmd.ExecuteScalar().ToString();
            textBox9.AppendText(dataAngajarii);

            /*** nrContract ***/
            cmd.CommandText = "SELECT Utilizatori.nr_contract FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrContract = cmd.ExecuteScalar().ToString();
            textBox8.AppendText(nrContract);

            /*** idFunctie ***/
            textBox11.AppendText("Asistent medical");

            conn.Close();
        }



        private void MeniuAsistent_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "OrarAngajatiFaraMedici";
            cmdString = "SELECT oraInceput, oraSfarsit FROM OrarAngajatiFaraMedici" +
                " WHERE OrarAngajatiFaraMedici.numeAngajat = '" + numeAsistent +
                "' AND OrarAngajatiFaraMedici.prenumeAngajat = '" + prenumeAsistent + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = Tabel;

            conn.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "Concedii";
            cmdString = "SELECT dataInceput, dataSfarsit FROM Concedii" +
                " WHERE Concedii.numeAngajat = '" + numeAsistent +
                "' AND Concedii.prenumeAngajat = '" + prenumeAsistent + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = Tabel;

            conn.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Continuare_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Dezautentificare();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dezautentificare();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Angajati.idAngajat FROM Angajati WHERE Angajati.idUtilizator = '" + idUtilizator + "';";
            string idAngajat = cmd.ExecuteScalar().ToString();

            string Tabel = "SalariiAngajati";
            cmdString = "SELECT luna, salariu FROM SalariiAngajati" +
                " WHERE SalariiAngajati.idAngajat = '" + idAngajat + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = Tabel;

            conn.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                string idPacient = textBox13.Text;
                string analiza = textBox14.Text;
                string rezultat = textBox15.Text;

                conn = new MySqlConnection("Server=localhost;Database=policlinica;Uid='root';Pwd='Sincopa2*';");
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Insert_AnalizePacienti('" + idPacient + "', '" + analiza + "', '" + rezultat + "');";
                int res = cmd.ExecuteNonQuery();

                if (res < 1) MessageBox.Show("Salvare nereusita!");
                else MessageBox.Show("Salvare reusita!");
            }
        }
    }
}
