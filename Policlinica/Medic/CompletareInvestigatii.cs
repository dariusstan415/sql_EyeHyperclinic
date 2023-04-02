using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Policlinica.Medic
{
    public partial class CompletareInvestigatii : Form
    {
        MySqlConnection conn;
        string idInvestigatie1;
        string idInvestigatie2;
        string idInvestigatie3;
        public CompletareInvestigatii(MySqlConnection conn, string idInvestigatie1,
            string idInvestigatie2, string idInvestigatie3)
        {
            InitializeComponent();
            this.conn = conn;
            this.idInvestigatie1 = idInvestigatie1;
            this.idInvestigatie2 = idInvestigatie2;
            this.idInvestigatie3 = idInvestigatie3;
        }

        private void CompletareInvestigatii_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            string rezultat1 = textBox1.Text;
            string rezultat2 = textBox2.Text;
            string rezultat3 = textBox3.Text;
            string parafa = textBox4.Text;
            string diagnostic = textBox26.Text;
            string recomandari = textBox27.Text;
            bool salvare = true;

            if (idInvestigatie1 != "" && rezultat1 != "")
            {
                cmd.CommandText = "CALL P_Insert_AdaugareRezultat('" + idInvestigatie1 + "', '" + rezultat1 + "');";
                int res = cmd.ExecuteNonQuery();
                if (res < 1) { MessageBox.Show("Salvare rezultat investigatie 1 nereusita!"); salvare = false; }
            }

            if (idInvestigatie2 != "" && rezultat2 != "")
            {
                cmd.CommandText = "CALL P_Insert_AdaugareRezultat('" + idInvestigatie2 + "', '" + rezultat2 + "');";
                int res = cmd.ExecuteNonQuery();
                if (res < 1) { MessageBox.Show("Salvare rezultat investigatie 2 nereusita!"); salvare = false; }
            }

            if (idInvestigatie3 != "" && rezultat3 != "")
            {
                cmd.CommandText = "CALL P_Insert_AdaugareRezultat('" + idInvestigatie3 + "', '" + rezultat3 + "');";
                int res = cmd.ExecuteNonQuery();
                if (res < 1) { MessageBox.Show("Salvare rezultat investigatie 3 nereusita!"); salvare = false; }
            }

            cmd.CommandText = "CALL P_Insert_AdaugareDiagnosticRecomandari('" + diagnostic + "', '" + recomandari + "', '" + parafa + "');";
            int result = cmd.ExecuteNonQuery();
            if (result < 1) { MessageBox.Show("Salvare diagnostic, recomandari, parafa nereusita!"); salvare = false; }

            if (salvare == true)
                MessageBox.Show("Salvare reusita!");
            else
                MessageBox.Show("Salvare nereusita!");
        }
    }
}
