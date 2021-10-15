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
    public partial class AddRec : Form
    {
        static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();
        public AddRec()
        {
            InitializeComponent();
        }

        //Add Request
        private void Add_Click(object sender, EventArgs e)
        {
            int result = Convert.ToInt32(ID.Text);
            con.Open();
            cmd = new SqlCommand("execute insert_request '" + hosp.Text + "','" + address.Text + "' ,'" + Qty.Text + "' ,'" + BType.Text + "', '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute NumofRequest '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute insert_Inv_Rec '" + result + "', '" + BType.Text + "' ", con);
            cmd.ExecuteNonQuery();
            //string query = "execute Accepted '" + result + "'";
            //cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Added Successfully");

            this.Hide();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //msh shaghaal
        private void button1_Click(object sender, EventArgs e)
        {
            int result = Convert.ToInt32(ID.Text);
            con.Open();
            cmd = new SqlCommand("execute insert_request '" + hosp.Text + "','" + address.Text + "' ,'" + Qty.Text + "' , '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute NumofRequest '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            string query = "execute Rejected '" + result + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
