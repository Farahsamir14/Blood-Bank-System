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
        
    public partial class RegisterRecipient : Form
    {
         static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();

        public RegisterRecipient()
        {
            InitializeComponent();
        }

        string gender;
        
        private void nextR_Click(object sender, EventArgs e)
        {
            MessageBox.Show("welcome to our system ");
            this.Hide();
        }

        private void nextR_Click_1(object sender, EventArgs e)
        {
            
            cmd = new SqlCommand("execute insert_recipient '"+FullnameRr.Text+"', '"+PasswordRr.Text+"', '"+emailRr.Text+"' , '"+AgeRr.Text+"', '"+gender+"', '"+ContactnumberRr.Text+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            if (PasswordRr.Text == ConPawwordRr.Text)
            {
                MessageBox.Show("Welcome to Our System");
                this.Hide();
            }
            else
                MessageBox.Show("Passwords don't match, Try Again");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BloodtypeRr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
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

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
