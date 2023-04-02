using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinica.Adaugare_FunctiiAngajati
{
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
                MessageBox.Show("Completati toate campurile!");
            else
            {
                string idPoliclinica = textBox1.Text;
                string nrOre = textBox2.Text;
                string salariu = textBox4.Text;

                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = null;

                conn = new MySqlConnection("Server=127.0.0.1;Database=policlinica;Uid=root;Pwd=Sincopa2*");
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = "CALL P_Insert_Angajati('" + idPoliclinica + "', '" + nrOre + "', '" + "6" + "', '" + salariu + "');";
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
    }
}
