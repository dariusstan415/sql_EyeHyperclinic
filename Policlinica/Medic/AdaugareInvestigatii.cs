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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Policlinica.Medic
{
    public partial class AdaugareInvestigatii : Form
    {
        MySqlConnection conn;
        public AdaugareInvestigatii(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idInvestigatie1 = textBox23.Text;
            string idInvestigatie2 = textBox24.Text;
            string idInvestigatie3 = textBox25.Text;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            if (idInvestigatie1 != "")
            {
                cmd.CommandText = "CALL P_Insert_ManyToManyInvestigatieServiciuRezultat('" + idInvestigatie1 + "');";
                cmd.ExecuteNonQuery();
            }
            if (idInvestigatie2 != "")
            {
                cmd.CommandText = "CALL P_Insert_ManyToManyInvestigatieServiciuRezultat('" + idInvestigatie2 + "');";
                cmd.ExecuteNonQuery();
            }
            if (idInvestigatie3 != "")
            {
                cmd.CommandText = "CALL P_Insert_ManyToManyInvestigatieServiciuRezultat('" + idInvestigatie3 + "');";
                cmd.ExecuteNonQuery();
            }

            CompletareInvestigatii secondWindow = new CompletareInvestigatii(conn, idInvestigatie1, idInvestigatie2, idInvestigatie3);
            secondWindow.ShowDialog();
        }
    }
}
