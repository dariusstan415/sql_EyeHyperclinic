using MySql.Data.MySqlClient;
using Policlinica.Interfete;
using Policlinica.Medic;
using System;
using System.Data;
using System.Windows.Forms;

namespace Policlinica.Meniuri
{
    public partial class MeniuMedic : Form, IDezautentificare
    {
        string numeMedic;
        string prenumeMedic;
        string emailLogin;
        string idUtilizatorMedic;
        string idAngajatMedic;
        string idMedic;

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

        string cmdString;
        MySqlDataAdapter daAdapter = null;
        DataSet ds = null;
        MySqlConnection conn = null;
        public MeniuMedic(string nume, string prenume, string emailLogin, string idUtilizator)
        {
            InitializeComponent();

            numeMedic = nume;
            prenumeMedic = prenume;
            this.emailLogin = emailLogin;
            this.idUtilizatorMedic = idUtilizator;

            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = null;

            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
            conn.Open();

            /*** idPoliclinica ***/
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            idPoliclinica = cmd.ExecuteScalar().ToString();
            textBox13.AppendText(idPoliclinica);

            /*** CNP ***/
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            CNP = cmd.ExecuteScalar().ToString();
            textBox7.AppendText(CNP);

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
            textBox2.AppendText(adresa);

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
            textBox11.AppendText("Medic");
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "Concedii";
            cmdString = "SELECT dataInceput, dataSfarsit FROM Concedii" +
                " WHERE Concedii.numeAngajat = '" + numeMedic +
                "' AND Concedii.prenumeAngajat = '" + prenumeMedic + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = Tabel;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "OrarMedici";
            cmdString = "SELECT dataConsult, oraConsult, numePacient, prenumePacient" +
            " FROM OrarMedici WHERE OrarMedici.numeMedic = '" + numeMedic +
            "' AND OrarMedici.prenumeMedic = '" + prenumeMedic + "';";

            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = Tabel;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Angajati.idAngajat FROM Angajati WHERE Angajati.idUtilizator = '" + idUtilizatorMedic + "';";
            idAngajatMedic = cmd.ExecuteScalar().ToString();

            cmd.CommandText = "SELECT Medici.idMedic FROM Medici WHERE Medici.idAngajat = '" + idAngajatMedic + "';";
            idMedic = cmd.ExecuteScalar().ToString();

            string Tabel = "RaportMedici";
            cmdString = "SELECT luna, sumTotal FROM RaportMedici" +
                " WHERE RaportMedici.idMedic = '" + idMedic + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView4.DataSource = ds;
            dataGridView4.DataMember = Tabel;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Angajati.idAngajat FROM Angajati WHERE Angajati.idUtilizator = '" + idUtilizatorMedic + "';";
            idAngajatMedic = cmd.ExecuteScalar().ToString();

            cmd.CommandText = "SELECT Medici.idMedic FROM Medici WHERE Medici.idAngajat = '" + idAngajatMedic + "';";
            idMedic = cmd.ExecuteScalar().ToString();

            string Tabel = "RaportMedici";
            cmdString = "SELECT * FROM RaportMedici" +
                " WHERE RaportMedici.idMedic = '" + idMedic + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = Tabel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

            string Tabel = "OrarMedici";
            cmdString = "SELECT * FROM OrarMedici" +
                " WHERE OrarMedici.dataConsult = '" + todayDate + "' AND OrarMedici.numeMedic = '" + numeMedic +
            "' AND OrarMedici.prenumeMedic = '" + prenumeMedic + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView5.DataSource = ds;
            dataGridView5.DataMember = Tabel;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void MeniuMedic_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        public void Dezautentificare()
        {
            LoginMenu secondWindow = new LoginMenu();
            this.Hide();
            secondWindow.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dezautentificare();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Dezautentificare();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Dezautentificare();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e, MySqlConnection conn)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == ""
                    || textBox17.Text == "" || textBox18.Text == "" || textBox19.Text == ""
                    || textBox20.Text == "" || textBox21.Text == "")
            {
                MessageBox.Show("Completati toate campurile!");
            }
            else
            {
                string idPacient = textBox14.Text;
                string numePacient = textBox15.Text;
                string prenumePacient = textBox16.Text;
                string numeMedicRecomandare = textBox17.Text;
                string prenumeMedicRecomandare = textBox18.Text;
                string numeAsistent = textBox19.Text;
                string prenumeAsistent = textBox20.Text;
                string dataConsult = textBox21.Text;
                string simptome = textBox22.Text;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='root';Pwd='Sincopa2*';");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "CALL P_Creare_Raport_Medical('" + idPacient  + "', '" + numePacient + "', '" 
                    + prenumePacient + "', '" + numeMedic + "', '" + prenumeMedic + "', '" + numeMedicRecomandare + "', '"
                    + prenumeMedicRecomandare + "', '" + numeAsistent + "', '" + prenumeAsistent + "', '" + dataConsult + "', '"
                    + simptome + "');";
                cmd.ExecuteNonQuery();

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            AdaugareInvestigatii secondWindow = new AdaugareInvestigatii(conn);
            secondWindow.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "RapoarteMedicale";
            cmdString = "SELECT * FROM RapoarteMedicale" +
                " WHERE RapoarteMedicale.idPacient = '" + textBox1.Text + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView6.DataSource = ds;
            dataGridView6.DataMember = Tabel;
        }
    }
}
