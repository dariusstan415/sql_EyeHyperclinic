using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Policlinica.Interfete;

namespace Policlinica.Meniuri
{
    public partial class MeniuReceptioner : Form, IDezautentificare
    {
        string numeReceptioner;
        string prenumeReceptioner;
        string emailLogin;
        string idUtilizatorReceptioner;

        string numePacient;
        string prenumePacient;
        string adresaPacient;
        string telefonPacient;
        string CNPPacient;
        string CNPPacientSosit;
        string ora;
        string data;
        string todayDate;
        int idMedic;
        string specializare;
        string serviciu1;
        string serviciu2;
        string serviciu3;

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

        object numeMedic;
        object prenumeMedic;

        string cmdString;
        MySqlDataAdapter daAdapter = null;
        DataSet ds = null;
        MySqlCommand cmd = new MySqlCommand();
        MySqlConnection conn = null;

        public MeniuReceptioner(string nume, string prenume, string emailLogin, string idUtilizator)
        {
            InitializeComponent();

            numeReceptioner = nume;
            prenumeReceptioner = prenume;
            this.emailLogin = emailLogin;
            this.idUtilizatorReceptioner = idUtilizator;

            conn = new MySqlConnection("Server=localhost;Database=policlinica;Uid=root;Pwd=Sincopa2*");
            conn.Open();

            /*** idPoliclinica ***/
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            idPoliclinica = cmd.ExecuteScalar().ToString();
            textBox21.AppendText(idPoliclinica);

            /*** CNP ***/
            cmd.CommandText = "SELECT Utilizatori.idPoliclinica FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            CNP = cmd.ExecuteScalar().ToString();
            textBox20.AppendText(CNP);

            /*** nume ***/
            cmd.CommandText = "SELECT Utilizatori.nume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            numeSql = cmd.ExecuteScalar().ToString();
            textBox19.AppendText(numeSql);

            /*** prenume ***/
            cmd.CommandText = "SELECT Utilizatori.prenume FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            prenumeSql = cmd.ExecuteScalar().ToString();
            textBox18.AppendText(prenumeSql);

            /*** adresa ***/
            cmd.CommandText = "SELECT Utilizatori.adresa FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            adresa = cmd.ExecuteScalar().ToString();
            textBox17.AppendText(adresa);

            /*** nrTelefon ***/
            cmd.CommandText = "SELECT Utilizatori.nr_telefon FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrTelefon = cmd.ExecuteScalar().ToString();
            textBox16.AppendText(nrTelefon);

            /*** IBAN ***/
            cmd.CommandText = "SELECT Utilizatori.IBAN FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            IBAN = cmd.ExecuteScalar().ToString();
            textBox12.AppendText(IBAN);

            /*** email ***/
            cmd.CommandText = "SELECT Utilizatori.email FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            email = cmd.ExecuteScalar().ToString();
            textBox13.AppendText(email);

            /*** dataAngajarii ***/
            cmd.CommandText = "SELECT Utilizatori.data_angajarii FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            dataAngajarii = cmd.ExecuteScalar().ToString();
            textBox14.AppendText(dataAngajarii);

            /*** nrContract ***/
            cmd.CommandText = "SELECT Utilizatori.nr_contract FROM Utilizatori WHERE Utilizatori.email = '" + emailLogin + "';";
            nrContract = cmd.ExecuteScalar().ToString();
            textBox15.AppendText(nrContract);

            /*** idFunctie ***/
            textBox9.AppendText("Receptioner");
        }


        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "" || checkBox2.Checked == false || comboBox3.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                CNPPacientSosit = textBox23.Text;
                string oraSosirii = comboBox3.Text;
                todayDate = DateTime.Now.ToString("yyyy-MM-dd");

                if (CNPPacientSosit.Length < 13)
                    MessageBox.Show("CNP nevalid.");
                else
                {
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlConnection conn = null;

                    conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                    conn.Open();
                    cmd.Connection = conn;

                    string idPacient;
                    cmd.CommandText = "SELECT Pacienti.idPacient FROM Pacienti WHERE CNP = '" + CNPPacientSosit + "';";
                    idPacient = cmd.ExecuteScalar().ToString();

                    string idConsultatie;
                    cmd.CommandText = "SELECT Consultatie.idConsultatie FROM Consultatie WHERE idPacient = '" + idPacient +
                        "' AND dataConsult = '" + todayDate + "' AND oraConsult = '" + oraSosirii + "';";
                    idConsultatie = cmd.ExecuteScalar().ToString();

                    string idMedic;
                    cmd.CommandText = "SELECT Consultatie.idMedic FROM Consultatie WHERE idPacient = '" + idPacient +
                        "' AND dataConsult = '" + todayDate + "' AND oraConsult = '" + oraSosirii + "';";
                    idMedic = cmd.ExecuteScalar().ToString();

                    /*** Luam serviciile medicale ale pacientului ***/
                    string serviciu1 = null;
                    string serviciu2 = null;
                    string serviciu3 = null;

                    object serviciu1AUX;
                    object serviciu2AUX;
                    object serviciu3AUX;

                    cmd.CommandText = "SELECT ManyToManyConsultatieServicii.idServiciuMedical FROM ManyToManyConsultatieServicii " +
                        "WHERE ManyToManyConsultatieServicii.idConsultatie = '" + idConsultatie + "' AND ManyToManyConsultatieServicii.nrServiciu " +
                        "= '1';";
                    serviciu1AUX = cmd.ExecuteScalar();

                    if (serviciu1AUX != null)
                        serviciu1 = serviciu1AUX.ToString();

                    cmd.CommandText = "SELECT ManyToManyConsultatieServicii.idServiciuMedical FROM ManyToManyConsultatieServicii " +
                        "WHERE ManyToManyConsultatieServicii.idConsultatie = '" + idConsultatie + "' AND ManyToManyConsultatieServicii.nrServiciu " +
                        "= '2';";
                    serviciu2AUX = cmd.ExecuteScalar();

                    if (serviciu2AUX != null)
                        serviciu2 = serviciu2AUX.ToString();

                    cmd.CommandText = "SELECT ManyToManyConsultatieServicii.idServiciuMedical FROM ManyToManyConsultatieServicii " +
                        "WHERE ManyToManyConsultatieServicii.idConsultatie = '" + idConsultatie + "' AND ManyToManyConsultatieServicii.nrServiciu " +
                        "= '3';";
                    serviciu3AUX = cmd.ExecuteScalar();

                    if (serviciu3AUX != null)
                        serviciu3 = serviciu3AUX.ToString();

                    /* Verific daca serviciul de la medicul respectiv are alt pret. */
                    string Tabel = "ManyToManyMediciSpecializari";
                    cmdString = "SELECT denumireServiciu, pretServiciu FROM ManyToManyMediciSpecializari" +
                        " WHERE idMedic = '" + idMedic + "' AND (idServiciu = '" + serviciu1 
                        + "' OR idServiciu = '" + serviciu2 + "' OR idServiciu = '" + serviciu3 + "');";
                    daAdapter = new MySqlDataAdapter(cmdString, conn);
                    ds = new DataSet();
                    daAdapter.Fill(ds, Tabel);
                    dataGridView2.DataSource = ds;
                    dataGridView2.DataMember = Tabel;
                }
            }
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cmdString;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter daAdapter = null;
            DataSet ds = null;
            MySqlConnection conn = null;

            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "OrarAngajatiFaraMedici";
            cmdString = "SELECT oraInceput, oraSfarsit FROM OrarAngajatiFaraMedici" +
                " WHERE OrarAngajatiFaraMedici.numeAngajat = '" + numeReceptioner +
                "' AND OrarAngajatiFaraMedici.prenumeAngajat = '" + prenumeReceptioner + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = Tabel;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cmdString;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter daAdapter = null;
            DataSet ds = null;
            MySqlConnection conn = null;

            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "Concedii";
            cmdString = "SELECT dataInceput, dataSfarsit FROM Concedii" +
                " WHERE Concedii.numeAngajat = '" + numeReceptioner +
                "' AND Concedii.prenumeAngajat = '" + prenumeReceptioner + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = Tabel;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""
                || comboBox2.Text == "" || textBox5.Text == "" || textBox4.Text == "" 
                || textBox11.Text == "" || TableSelect.Text == "" || textBox8.Text == ""
                || textBox22.Text == "")
            {
                MessageBox.Show("Completati toate campurile!");
            }
            else
            {
                numePacient = textBox5.Text;
                prenumePacient = textBox1.Text;
                adresaPacient = textBox2.Text;
                telefonPacient = textBox3.Text;
                CNPPacient = textBox8.Text;

                string numePrenumeMedic = TableSelect.Text;
                ora = comboBox2.Text;
                todayDate = DateTime.Now.ToString("yyyy-MM-dd");
                data = textBox4.Text;
                specializare = textBox22.Text;

                serviciu1 = textBox11.Text;
                serviciu2 = textBox7.Text;
                serviciu3 = textBox6.Text;

                if (numePrenumeMedic == "Hurghis Alina")
                {
                    numeMedic = "Hurghis";
                    prenumeMedic = "Alina";
                    idMedic = 1;
                }
                if (numePrenumeMedic == "Galatan Ana")
                {
                    numeMedic = "Galatan";
                    prenumeMedic = "Ana";
                    idMedic = 2;
                }
                if (numePrenumeMedic == "Novac Adela")
                {
                    numeMedic = "Novac";
                    prenumeMedic = "Adela";
                    idMedic = 3;
                }

                if (data.CompareTo(todayDate) <= 0)
                    MessageBox.Show("Alegeti o data calendaristica ulterioara!");

                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();
                cmd.Connection = conn;

                object oraAuxiliar = null;
                string oraVerificare;


                object serviciu1Auxiliar;
                object serviciu2Auxiliar;
                object serviciu3Auxiliar;

                object sfaristConcediuAuxiliar = null;
                object inceputConcediuAuxiliar = null;
                DateTime inceputConcediu;
                DateTime sfarsitConcediu;
                string inceputConcediuSTRING;
                string sfarsitConcediuSTRING;

                object inceputOrarSpecificAuxiliar = null;
                object sfarsitOrarSpecificAuxiliar = null;
                DateTime inceputOrarSpecific;
                DateTime sfarsitOrarSpecific;
                string inceputOrarSpecificSTRING;
                string sfarsitOrarSpecificSTRING;

                bool Flag = true;

                /*** Verificare daca serviciile selectate pot fi efectuate de medic. ***/
                if (serviciu1 != "")
                {
                    cmd.CommandText = "SELECT manytomanymedicispecializari.denumireServiciu FROM manytomanymedicispecializari" +
                        " WHERE manytomanymedicispecializari.denumireServiciu = '" + serviciu1 +
                        "' AND manytomanymedicispecializari.idMedic ='" + idMedic +
                        "' AND manytomanymedicispecializari.specialzare ='" + specializare + "';";
                    serviciu1Auxiliar = cmd.ExecuteScalar();

                    if (serviciu1Auxiliar == null)
                    {
                        MessageBox.Show("Serviciul 1 nu este disponibil!");
                        Flag = false;
                    }
                }

                if (serviciu2 != "")
                {
                    cmd.CommandText = "SELECT manytomanymedicispecializari.denumireServiciu FROM manytomanymedicispecializari" +
                    " WHERE manytomanymedicispecializari.denumireServiciu = '" + serviciu2 +
                    "' AND manytomanymedicispecializari.idMedic ='" + idMedic +
                    "' AND manytomanymedicispecializari.specialzare ='" + specializare + "';";
                    serviciu2Auxiliar = cmd.ExecuteScalar();

                    if (serviciu2Auxiliar == null)
                    {
                        MessageBox.Show("Serviciul 2 nu este disponibil!");
                        Flag = false;
                    }
                }

                if (serviciu3 != "")
                {
                    cmd.CommandText = "SELECT manytomanymedicispecializari.denumireServiciu FROM manytomanymedicispecializari" +
                    " WHERE manytomanymedicispecializari.denumireServiciu = '" + serviciu3 +
                    "' AND manytomanymedicispecializari.idMedic ='" + idMedic +
                    "' AND manytomanymedicispecializari.specialzare ='" + specializare + "';";
                    serviciu3Auxiliar = cmd.ExecuteScalar();

                    if (serviciu3Auxiliar == null)
                    {
                        MessageBox.Show("Serviciul 3 nu este disponibil!");
                        Flag = false;
                    }
                }
   
                /*** Verificare daca medicul e in concediu. ***/
                cmd.CommandText = "SELECT Concedii.dataInceput FROM Concedii WHERE Concedii.numeAngajat = '" + numeMedic +
                    "' AND Concedii.prenumeAngajat = '" + prenumeMedic + "';";
                inceputConcediuAuxiliar = cmd.ExecuteScalar();

                if (inceputConcediuAuxiliar != null)
                {
                    inceputConcediu = (DateTime)inceputConcediuAuxiliar;
                    inceputConcediuSTRING = inceputConcediu.ToString("yyyy-MM-dd") ;
                    cmd.CommandText = "SELECT Concedii.dataSfarsit FROM Concedii WHERE Concedii.numeAngajat = '" + numeMedic +
                        "' AND Concedii.prenumeAngajat = '" + prenumeMedic + "';";
                    sfaristConcediuAuxiliar = cmd.ExecuteScalar();
                    sfarsitConcediu = (DateTime)sfaristConcediuAuxiliar;
                    sfarsitConcediuSTRING = sfarsitConcediu.ToString("yyyy-MM-dd");
                    if (data.CompareTo(inceputConcediuSTRING) >= 0 && data.CompareTo(sfarsitConcediuSTRING) <= 0)
                    {
                        MessageBox.Show("Medicul e in concediu!");
                        Flag = false;
                    }
                }

                /*** Verificare orar specific.***/
                cmd.CommandText = "SELECT OrarSpecific.oraInceput FROM OrarSpecific WHERE OrarSpecific.dataSpecifica = '" + data + "';";
                inceputOrarSpecificAuxiliar = cmd.ExecuteScalar();

                if (inceputOrarSpecificAuxiliar != null)
                {
                    inceputOrarSpecific = (DateTime)inceputOrarSpecificAuxiliar;
                    inceputOrarSpecificSTRING = inceputOrarSpecific.ToString("HH:mm:ss");

                    cmd.CommandText = "SELECT OrarSpecific.oraSfarsit FROM OrarSpecific WHERE OrarSpecific.dataSpecifica = '" + data + "';";
                    sfarsitOrarSpecificAuxiliar = cmd.ExecuteScalar();
                    sfarsitOrarSpecific = (DateTime)sfarsitOrarSpecificAuxiliar;
                    sfarsitOrarSpecificSTRING = sfarsitOrarSpecific.ToString("HH:mm:ss");

                    if (data.CompareTo(inceputOrarSpecificSTRING) >= 0 && data.CompareTo(sfarsitOrarSpecificSTRING) <= 0)
                    {
                        MessageBox.Show("Zi cu orar specific. Alegeti alti interval orar!");
                        Flag = false;
                    }
                }

                /*** Verificare daca medicul are alta programare. ***/
                cmd.CommandText = "SELECT OrarMedici.oraConsult FROM OrarMedici WHERE OrarMedici.idMedic = '" + idMedic +
                    "' AND OrarMedici.dataConsult = '" + data +
                    "' AND OrarMedici.oraConsult = '" + ora + "';";
                oraAuxiliar = cmd.ExecuteScalar();

                if (oraAuxiliar != null)
                {
                    MessageBox.Show("Interval orar indisponibil!");
                    Flag = false;
                }
                if (Flag == true)
                { 
                    cmd.CommandText = "CALL P_Insert_Pacienti('" + numePacient + "', '" + prenumePacient + "', '" + CNPPacient + "', '" + adresaPacient + "', '" + telefonPacient + "');";
                    cmd.ExecuteNonQuery();

                    string idPoliclinica = "1";
                    cmd.CommandText = "CALL P_Insert_Consultatie('" + idPoliclinica + "', '" + numePacient + "', '" + prenumePacient + "', '" + idMedic + "', '" + data + "', '" +
                        ora + "', '" + serviciu1 + "', '" + serviciu2 + "', '" + serviciu3 + "');";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Salvare efectuata!");
                }
            }  
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idCabinet = null;

            if (textBox10.Text == "" || checkBox1.Checked == false || comboBox1.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                CNPPacientSosit = textBox10.Text;
                string oraSosirii = comboBox1.Text;
                todayDate = DateTime.Now.ToString("yyyy-MM-dd");

                if (CNPPacientSosit.Length < 13)
                    MessageBox.Show("CNP nevalid.");
                else
                {
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlConnection conn = null;

                    conn = new MySqlConnection("Server=localhost;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                    conn.Open();
                    cmd.Connection = conn;

                    string idPacient;
                    cmd.CommandText = "SELECT Pacienti.idPacient FROM Pacienti WHERE CNP = '" + CNPPacientSosit + "';";
                    idPacient = cmd.ExecuteScalar().ToString();

                    string idConsultatie;
                    cmd.CommandText = "SELECT Consultatie.idConsultatie FROM Consultatie WHERE idPacient = '" + idPacient +
                        "' AND dataConsult = '" + todayDate + "' AND oraConsult = '" + oraSosirii + "';";
                    idConsultatie = cmd.ExecuteScalar().ToString();

                    /*** Luam serviciile medicale ale pacientului ***/
                    string serviciu1 = null;
                    string serviciu2 = null;
                    string serviciu3 = null;

                    string echipament1 = null;
                    string echipament2 = null;
                    string echipament3 = null;

                    object serviciu1AUX;
                    object serviciu2AUX;
                    object serviciu3AUX;

                    cmd.CommandText = "SELECT ManyToManyConsultatieServicii.idServiciuMedical FROM ManyToManyConsultatieServicii " +
                        "WHERE ManyToManyConsultatieServicii.idConsultatie = '" + idConsultatie + "' AND ManyToManyConsultatieServicii.nrServiciu " +
                        "= '1';";
                    serviciu1AUX = cmd.ExecuteScalar();

                    if (serviciu1AUX != null)
                    {
                        serviciu1 = serviciu1AUX.ToString();
                        cmd.CommandText = "SELECT ServiciiMedicale.echipament FROM ServiciiMedicale " +
                        "WHERE ServiciiMedicale.idServiciuMedical = '" + serviciu1 + "';";
                        echipament1 = cmd.ExecuteScalar().ToString();
                    }

                    cmd.CommandText = "SELECT ManyToManyConsultatieServicii.idServiciuMedical FROM ManyToManyConsultatieServicii " +
                        "WHERE ManyToManyConsultatieServicii.idConsultatie = '" + idConsultatie + "' AND ManyToManyConsultatieServicii.nrServiciu " +
                        "= '2';";
                    serviciu2AUX = cmd.ExecuteScalar();

                    if (serviciu2AUX != null)
                    {
                        serviciu2 = serviciu2AUX.ToString();
                        cmd.CommandText = "SELECT ServiciiMedicale.echipament FROM ServiciiMedicale " +
                        "WHERE ServiciiMedicale.idServiciuMedical = '" + serviciu2 + "';";
                        echipament2 = cmd.ExecuteScalar().ToString();
                    }

                    cmd.CommandText = "SELECT ManyToManyConsultatieServicii.idServiciuMedical FROM ManyToManyConsultatieServicii " +
                        "WHERE ManyToManyConsultatieServicii.idConsultatie = '" + idConsultatie + "' AND ManyToManyConsultatieServicii.nrServiciu " +
                        "= '3';";
                    serviciu3AUX = cmd.ExecuteScalar();

                    if (serviciu3AUX != null)
                    {
                        serviciu3 = serviciu3AUX.ToString();
                        cmd.CommandText = "SELECT ServiciiMedicale.echipament FROM ServiciiMedicale " +
                        "WHERE ServiciiMedicale.idServiciuMedical = '" + serviciu3 + "';";
                        echipament3 = cmd.ExecuteScalar().ToString();
                    }

                    object idCabinetAUX;
                    /*** Caut cabinete care indeplinesc serviciile si sunt libere. ***/
                    if (serviciu1 != null)
                    {
                        for (int i = 1; i <= 6; i++)
                        {
                            cmd.CommandText = "SELECT ManyToManyCabineteServiciiMedicale.idCabinet FROM ManyToManyCabineteServiciiMedicale" +
                                " WHERE idServiciuMedical = '" + serviciu1 + "' AND idCabinet = '" + i + "';";
                            idCabinetAUX = cmd.ExecuteScalar();

                            if (idCabinetAUX != null)
                            {
                                idCabinet = idCabinetAUX.ToString();
                                if (serviciu2 != null)
                                {
                                    cmd.CommandText = "SELECT ManyToManyCabineteServiciiMedicale.idCabinet FROM ManyToManyCabineteServiciiMedicale" +
                                    " WHERE idServiciuMedical = '" + serviciu2 + "' AND idCabinet = '" + idCabinet + "';";
                                    idCabinetAUX = cmd.ExecuteScalar();

                                    if (idCabinetAUX != null)
                                    {
                                        if (serviciu3 != null)
                                        {
                                            cmd.CommandText = "SELECT ManyToManyCabineteServiciiMedicale.idCabinet FROM ManyToManyCabineteServiciiMedicale" +
                                            " WHERE idServiciuMedical = '" + serviciu3 + "' AND idCabinet = '" + idCabinet + "';";
                                            idCabinetAUX = cmd.ExecuteScalar();

                                            if (idCabinetAUX != null)
                                            {
                                                cmd.CommandText = "SELECT ManyToManyCabinetLiber.idCabinet FROM ManyToManyCabinetLiber" +
                                                " WHERE dataConsult = '" + todayDate + "' AND oraConsult = '" + oraSosirii +
                                                "' AND idCabinet = '" + i + "';";
                                                object liber = cmd.ExecuteScalar();

                                                if (liber == null)
                                                {
                                                    cmd.CommandText = "CALL P_Insert_ManyToManyCabinetLiber(' " + i 
                                                    + "', '" + todayDate + "', '" + oraSosirii + "');";
                                                    int resultat = cmd.ExecuteNonQuery();
                                                    if (resultat < 1)
                                                        MessageBox.Show("Repartizare cabinet nereusita!");
                                                    else
                                                    {
                                                        MessageBox.Show("Repartizare cabinet reusita!");
                                                        break;
                                                    }
                                                }

                                            }

                                        }
                                        else
                                        {
                                            cmd.CommandText = "SELECT ManyToManyCabinetLiber.idCabinet FROM ManyToManyCabinetLiber" +
                                                " WHERE dataConsult = '" + todayDate + "' AND oraConsult = '" + oraSosirii +
                                                "' AND idCabinet = '" + i + "';";
                                            object liber = cmd.ExecuteScalar();

                                            if (liber == null)
                                            {
                                                cmd.CommandText = "CALL P_Insert_ManyToManyCabinetLiber(' " + i
                                                + "', '" + todayDate + "', '" + oraSosirii + "');";
                                                int resultat = cmd.ExecuteNonQuery();
                                                if (resultat < 1)
                                                    MessageBox.Show("Repartizare cabinet nereusita!");
                                                else
                                                {
                                                    MessageBox.Show("Repartizare cabinet reusita!");
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    cmd.CommandText = "SELECT ManyToManyCabinetLiber.idCabinet FROM ManyToManyCabinetLiber" +
                                                " WHERE dataConsult = '" + todayDate + "' AND oraConsult = '" + oraSosirii +
                                                "' AND idCabinet = '" + i + "';";
                                    object liber = cmd.ExecuteScalar();

                                    if (liber == null)
                                    {
                                        cmd.CommandText = "CALL P_Insert_ManyToManyCabinetLiber(' " + i
                                        + "', '" + todayDate + "', '" + oraSosirii + "');";
                                        int resultat = cmd.ExecuteNonQuery();
                                        if (resultat < 1)
                                            MessageBox.Show("Repartizare cabinet nereusita!");
                                        else
                                        {
                                            MessageBox.Show("Repartizare cabinet reusita!");
                                            break; 
                                        }
                                    }
                                }
                            }
                        }
                    }

                    cmd.Connection = conn;

                    string numeCabinet;
                    /*** Nume cabinet. ***/
                    cmd.CommandText = "SELECT Cabinete.numeCabinet FROM Cabinete" +
                                                " WHERE idCabinet = '" + idCabinet + "';";
                    numeCabinet = cmd.ExecuteScalar().ToString();

                    /*** Inregistrare pacient. ***/
                    cmd.CommandText = "CALL P_Pacient_Inregistrat('" + CNPPacientSosit 
                        + "', '" + oraSosirii + "', '" + todayDate +  "');";
                    int res = cmd.ExecuteNonQuery();

                    if (res < 1 )
                        MessageBox.Show("Pacient inexistent!");
                    else
                    {
                        MessageBox.Show("Salvare efectuata! Cabinetul " + numeCabinet + ".");
                        conn.Close();
                    }
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TableSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Dezautentificare()
        {
            LoginMenu secondWindow = new LoginMenu();
            this.Hide();
            secondWindow.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dezautentificare();
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
            conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid='angajat';Pwd='cristinadariusbd10*';");
            conn.Open();

            string Tabel = "SalariiAngajati";
            cmdString = "SELECT luna, salariu FROM SalariiAngajati" +
                " WHERE SalariiAngajati.idUtilizator = '" + idUtilizatorReceptioner + "';";
            daAdapter = new MySqlDataAdapter(cmdString, conn);
            ds = new DataSet();
            daAdapter.Fill(ds, Tabel);
            dataGridView4.DataSource = ds;
            dataGridView4.DataMember = Tabel;
        }

        private void MeniuReceptioner_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
    }
}
