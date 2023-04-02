using MySql.Data.MySqlClient;
using Policlinica.Interfete;
using System;
using System.Data;
using System.Windows.Forms;

namespace Policlinica.Meniuri
{
    public partial class MeniuInspector : Form, IDezautentificare
    {
        string numeInspector;
        string prenumeInspector;
        string emailLogin;
        string idUtilizatorInspector;

        string idMedic;
        string specializare;
        string gradMedic;
        string serviciuMedical;
        string pretServiciu;
        string durataServiciu;

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
        MySqlCommand cmd = new MySqlCommand();

        public MeniuInspector(string nume, string prenume, string emailLogin, string idUtilizator)
        {
            InitializeComponent();

            numeInspector = nume;
            prenumeInspector = prenume;
            this.emailLogin = emailLogin;
            this.idUtilizatorInspector = idUtilizator;

            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
            conn.Open();

            /*** idPoliclinica ***/
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            idPoliclinica = cmd.ExecuteScalar().ToString();
            textBox18.AppendText(idPoliclinica);

            /*** CNP ***/
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            CNP = cmd.ExecuteScalar().ToString();
            textBox17.AppendText(CNP);

            /*** nume ***/
            cmd.CommandText = "SELECT Utilizatori.nume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            numeSql = cmd.ExecuteScalar().ToString();
            textBox16.AppendText(numeSql);

            /*** prenume ***/
            cmd.CommandText = "SELECT Utilizatori.prenume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            prenumeSql = cmd.ExecuteScalar().ToString();
            textBox15.AppendText(prenumeSql);

            /*** adresa ***/
            cmd.CommandText = "SELECT Utilizatori.adresa FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            adresa = cmd.ExecuteScalar().ToString();
            textBox14.AppendText(adresa);

            /*** nrTelefon ***/
            cmd.CommandText = "SELECT Utilizatori.nr_telefon FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrTelefon = cmd.ExecuteScalar().ToString();
            textBox13.AppendText(nrTelefon);

            /*** IBAN ***/
            cmd.CommandText = "SELECT Utilizatori.IBAN FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            IBAN = cmd.ExecuteScalar().ToString();
            textBox12.AppendText(IBAN);

            /*** email ***/
            cmd.CommandText = "SELECT Utilizatori.email FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            email = cmd.ExecuteScalar().ToString();
            textBox3.AppendText(email);

            /*** dataAngajarii ***/
            cmd.CommandText = "SELECT Utilizatori.data_angajarii FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            dataAngajarii = cmd.ExecuteScalar().ToString();
            textBox4.AppendText(dataAngajarii);

            /*** nrContract ***/
            cmd.CommandText = "SELECT Utilizatori.nr_contract FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrContract = cmd.ExecuteScalar().ToString();
            textBox5.AppendText(nrContract);

            /*** idFunctie ***/
            textBox11.AppendText("Inspector resurse umane");
        }

        private void Nume_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || listBox1.Text == "")
            {
                MessageBox.Show("Completati toate campurile!");
            }
            else
            {
                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
                conn.Open();

                string Tabel;

                if (listBox1.Text == "Medic")
                {
                    Tabel = "OrarMedici";
                    cmdString = "SELECT dataConsult, oraConsult, numePacient, prenumePacient" +
                        " FROM OrarMedici WHERE OrarMedici.numeMedic = '" + textBox1.Text +
                        "' AND OrarMedici.prenumeMedic = '" + textBox2.Text + "';";
                }
                else
                {
                    Tabel = "OrarAngajatiFaraMedici";
                    cmdString = "SELECT oraInceput, oraSfarsit FROM OrarAngajatiFaraMedici" +
                        " WHERE OrarAngajatiFaraMedici.numeAngajat = '" + textBox1.Text +
                        "' AND OrarAngajatiFaraMedici.prenumeAngajat = '" + textBox2.Text + "';";
                }
                daAdapter = new MySqlDataAdapter(cmdString, conn);
                ds = new DataSet();
                daAdapter.Fill(ds, Tabel);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = Tabel;
            } 
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "OrarAngajatiFaraMedici";
            cmdString = "SELECT oraInceput, oraSfarsit FROM OrarAngajatiFaraMedici" +
                " WHERE OrarAngajatiFaraMedici.numeAngajat = '" + numeInspector +
                "' AND OrarAngajatiFaraMedici.prenumeAngajat = '" + prenumeInspector + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = Tabel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "Concedii";
            cmdString = "SELECT dataInceput, dataSfarsit FROM Concedii" +
                " WHERE Concedii.numeAngajat = '" + numeInspector +
                "' AND Concedii.prenumeAngajat = '" + prenumeInspector + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = Tabel;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "" || textBox9.Text == "" || textBox10.Text == ""
                || textBox8.Text == "" || listBox3.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                idMedic = textBox6.Text;
                specializare = textBox7.Text;
                gradMedic = listBox3.Text;
                serviciuMedical = textBox9.Text;
                pretServiciu = textBox8.Text;
                durataServiciu = textBox10.Text;

                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Insert_Specializari_ServiciiMedicale_For_Medic('" + idMedic + "', '" + specializare
                    + "', '" + gradMedic + "', '" + serviciuMedical
                    + "', '" + pretServiciu + "', '" + durataServiciu + "');";
                int res = cmd.ExecuteNonQuery();

                if (res < 1)
                    MessageBox.Show("Inserare serviciu medical nereusita!");
                else
                {
                    MessageBox.Show("Inserare serviciu medical efectuata!");
                    conn.Close();
                }
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Dezautentificare();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dezautentificare(); ;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Angajati.idAngajat FROM Angajati WHERE Angajati.idUtilizator = '" + idUtilizatorInspector + "';";
            string idAngajat = cmd.ExecuteScalar().ToString();

            string Tabel = "SalariiAngajati";
            cmdString = "SELECT luna, salariu FROM SalariiAngajati" +
                " WHERE SalariiAngajati.idAngajat = '" + idAngajat + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView4.DataSource = ds;
            dataGridView4.DataMember = Tabel;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
