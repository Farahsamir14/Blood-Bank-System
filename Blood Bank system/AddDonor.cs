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
    public partial class AddDonor : Form
    {
        static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();

        public AddDonor()
        {
            InitializeComponent();
        }

        private void Acc_Click(object sender, EventArgs e)
        {
            int result = Convert.ToInt32(ID.Text);
            con.Open();
            cmd = new SqlCommand("SELECT dbo.getBlood('" + result + "' )", con);
            var Bld_Type = cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute insert_blood '" + Bld_Type + "' , '" + result + "'  ", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute NumofDonate '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Added Successfully");
            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDonor_Load(object sender, EventArgs e)
        {

        }

        private void Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
