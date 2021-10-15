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
    public partial class LoginAsDonor : Form
    {
        static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();

        int result;
        
        public LoginAsDonor()
        {
            InitializeComponent();

            dataGridViewDonor.BorderStyle = BorderStyle.None;
            dataGridViewDonor.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewDonor.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDonor.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewDonor.BackgroundColor = Color.Silver;

            dataGridViewDonor.EnableHeadersVisualStyles = false;
            dataGridViewDonor.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewDonor.ColumnHeadersDefaultCellStyle.BackColor = Color.Pink;
            dataGridViewDonor.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        public DataTable DisDon()
        {
            DataTable tblDon = new DataTable();
            con.Open();
            cmd = new SqlCommand("execute DisplayDonors '" + result + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tblDon);
            con.Close();
            return tblDon;
        }
        private void backD_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void registerforDonor_Click(object sender, EventArgs e)
        {
            RegisterDonor r1 = new RegisterDonor();

            r1.Show();
        }

        private void login2donor_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    result = 0;
                    con.Open();
                    cmd = new SqlCommand("SELECT dbo.login_Don('" + UsernameDonor.Text + "', '" + PasswordDonor.Text + "')", con);

                    result = (int)cmd.ExecuteScalar();

                    con.Close();
                    if (result >= 1)
                    {
                        MessageBox.Show("Login Success");
                        HomeForDonor.Visible = true;
                        backgroundhome1.Visible = true;
                    }
                    else
                        MessageBox.Show("Incorrect login");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error:" + ex.Message);
                }

            }

            
        }

        private void backgroundhome1_Paint(object sender, PaintEventArgs e)
        {

        }

          private void Donate_Click_1(object sender, EventArgs e)
        {
            DonateForm.Visible = true;
            dataGridViewDonor.DataSource = DisDon();
        }

        private void logoutD_Click_1(object sender, EventArgs e)
        {
            HomeForDonor.Visible = false;
            backgroundhome1.Visible = false;
        }

        private void add_Click_2(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT dbo.getBlood('" + result + "' )", con);
            string Bld_Type = cmd.ExecuteScalar().ToString();
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute insert_blood '" + Bld_Type + "', '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute NumofDonate '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Added Successfully");
            dataGridViewDonor.DataSource = DisDon();

            //DonateForm.Visible = false;
        }

        private void QuantityD_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridViewDonor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DonateForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuantityD_TextChanged(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
