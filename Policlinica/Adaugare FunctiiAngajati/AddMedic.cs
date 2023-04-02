using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Policlinica.Adaugare_FunctiiAngajati
{
    public partial class AddMedic : Form
    {
        string idPoliclinica;
        string nrOre;
        string salariu;
        string codParafa;
        string postDidactic;
        string titluStiintific;
        string comision;

        string idMedic;
        string specializare;
        string gradMedic;
        string serviciuMedical;
        string pretServiciu;
        string durataServiciu;
        public AddMedic()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""
                || textBox5.Text == "" || listBox1.Text == "" || listBox2.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                string idFunctie = "5";
                idPoliclinica = textBox1.Text;
                nrOre = textBox2.Text;
                salariu = textBox4.Text;
                codParafa = textBox3.Text;
                comision = textBox5.Text;

                if (listBox1.Text == "- niciun titlu -")
                    titluStiintific = "";
                else
                    titluStiintific = listBox1.Text;

                if (listBox2.Text == "- niciun titlu -")
                    postDidactic = "";
                else
                    postDidactic = listBox2.Text;



                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Insert_Medici('" + idPoliclinica + "', '" + nrOre + "', '" + idFunctie + "', '" + salariu + "', '"
                    + "" + "', '" + codParafa + "', '" + titluStiintific + "', '" + postDidactic + "', '" + comision + "');";
                int res = cmd.ExecuteNonQuery();

                if (res < 1)
                    MessageBox.Show("Inserare angajat nereusita!");
                else
                {
                    MessageBox.Show("Inserare angajat efectuata!");
                    conn.Close();
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }
    }
}
