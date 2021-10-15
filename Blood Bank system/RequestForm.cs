using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Blood_Bank_system
{
    public partial class RequestForm : Form
    {
        static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();

        public RequestForm()
        {
            InitializeComponent();

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Acc_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(ID.Text);
            con.Open();
            string query = "execute Accepted '" + i + "', '" + Qty.Text + "' ";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();

            this.Hide();
        }
        private void Rej_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(ID.Text);
            con.Open();
            string query = "execute Rejected '" + i + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
