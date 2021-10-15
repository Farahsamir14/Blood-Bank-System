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
    public partial class RegisterDonor : Form
    {
        static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();

        string gender;

        public RegisterDonor()
        {
            InitializeComponent();
        }
        
        private void nextD_Click(object sender, EventArgs e)
        {

            MessageBox.Show("welcome to our system ");
            this.Hide();
        }

        private void nextD_Click_1(object sender, EventArgs e)
        {
             
            con.Open();
            cmd = new SqlCommand("execute insert_donor '" + FullnameRD.Text + "', '" + PasswordRD.Text + "', '" + emailRD.Text + "', '" + BloodtypeRD.Text + "' ,'" + AgeRD.Text + "' , '" + gender + "', '" + AddressRD.Text + "', '" + ContactnumberRD.Text + "' ", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("SELECT dbo.login_Don('" + FullnameRD.Text + "', '" + PasswordRD.Text + "')", con);
            int result = (int)cmd.ExecuteScalar();
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute insert_blood '" + BloodtypeRD.Text + "' ,'" + result + "' ", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute NumofDonate '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            
            con.Close();
            if (PasswordRD.Text == ConPawwordRD.Text)
            {
                MessageBox.Show("Welcome to Our System");
                this.Hide();
            }
            else
                MessageBox.Show("Passwords don't match, Try Again");
            //LoginAsDonor k = new LoginAsDonor();
            //k.Show();
            //HomeForAdmin.Visible = true;
            //BackgroundHome2.Visible = true;
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void FullnameRD_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
