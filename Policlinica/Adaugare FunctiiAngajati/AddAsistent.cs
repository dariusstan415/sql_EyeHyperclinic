using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Policlinica.FunctiiAngajati
{
    public partial class AddAsistent : Form
    {
        string idTipAsistent;
        string idGradAsistent;

        public AddAsistent()
        {
            InitializeComponent();
        }

        private void AddAsistent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == ""
                || listBox1.Text == "" || listBox2.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                if (listBox1.Text == "Generalist")
                    idTipAsistent = "1";
                if (listBox1.Text == "Laborator")
                    idTipAsistent = "2";
                if (listBox1.Text == "Radiologie")
                    idTipAsistent = "3";

                if (listBox2.Text == "Principal")
                    idGradAsistent = "1";
                if (listBox2.Text == "Secundar")
                    idGradAsistent = "2";

                string idFunctie = "4";
                string idPoliclinica = textBox1.Text;
                string nrOre = textBox2.Text;
                string salariu = textBox4.Text;

                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Insert_Asistenti('" + idPoliclinica + "', '" + nrOre + "', '" + idFunctie + "', '" + salariu + "', '"
                    + idTipAsistent + "', '" + idGradAsistent + "');";
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
