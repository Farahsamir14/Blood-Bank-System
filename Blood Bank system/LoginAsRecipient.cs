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
    public partial class LoginAsRecipient : Form
    {
        static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();
     
        public LoginAsRecipient()
        {
            InitializeComponent();

            loadDGVSettings(dataGridView1);
            loadDGVSettings(dataGridView2);
        }
        //properties of datagridview
        public static void loadDGVSettings(DataGridView s)
        {
            s.BorderStyle = BorderStyle.None;
            s.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            s.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            s.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            s.BackgroundColor = Color.Silver;
            s.EnableHeadersVisualStyles = false;
            s.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            s.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            s.ColumnHeadersDefaultCellStyle.BackColor = Color.Pink;
            s.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        }

        //Display Requests
        public DataTable DisReq()
        {
            DataTable tblReq = new DataTable();
            con.Open();
            cmd = new SqlCommand("execute DisplayRecReq '" + result + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tblReq);
            con.Close();
            return tblReq;
        }

        int result;

        private void backR_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void registerforRecipient_Click(object sender, EventArgs e)
        {
            RegisterRecipient r2 = new RegisterRecipient();
            r2.Show();
        }

        //Login
        private void login2recipient_Click(object sender, EventArgs e)
        {
            try
            {
                result = 0;
                con.Open();
                cmd = new SqlCommand("SELECT dbo.login_Rec('" + UsernameRecipient.Text + "', '" + PasswordRecipient.Text + "')", con);

                result = (int)cmd.ExecuteScalar();

                con.Close();
                if (result >= 1)
                {
                    MessageBox.Show("Login Success");
                    HomeForRecipient.Visible = true;
                    backgroundhome.Visible = true;
                }
                else
                    MessageBox.Show("Incorrect login");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:" + ex.Message);
            }
            
        }
        //private void Send_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("your request Successfully sent");
        //    sendRequestForm.Visible = false;
        //    searchForm.Visible = false;
        //    backgroundhome.Visible = true;
        //    HomeForRecipient.Visible = true;
        //}

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchR_Click_1(object sender, EventArgs e)
        {
            searchForm.Visible = true;
            backgroundhome.Visible = true;
        }

        private void logoutR_Click(object sender, EventArgs e)
        {
            HomeForRecipient.Visible = false;
            backgroundhome.Visible = false;
        }

        //Search in blood inventory
        private void Display_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from rec_blood_inv ('"+BloodtypeRecipient.Text+"')", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        //msh shaghaal
        private void sendR_Click(object sender, EventArgs e)
        {
            int count;
            con.Open();
            string query = "select dbo.check_req (" + result + ")";
            cmd = new SqlCommand(query, con);
            count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count == 0)
            {
                sendRequestForm.Visible = true;

                backgroundhome.Visible = true;
            }
            else
            {
  
                MessageBox.Show("You already sent request");
                sendRequestForm.Visible = false;
            }
            
         
        }
        //msh shaghaal
        private void finalSend_Click(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("execute insert_request '" + hospitalname.Text + "', '" + hospitaladd.Text+ "', '" + QuantityR.Text + "', '" + result.ToString() + "' ", con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //cmd = new SqlCommand("execute NumofRequest '" + result + "' ", con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //dataGridView2.DataSource = DisReq();
            //MessageBox.Show("Your Request has been sent");

            //sendRequestForm.Visible = false;
            //searchForm.Visible = false;
            //backgroundhome.Visible = true;
            //HomeForRecipient.Visible = true;

        }

        private void QuantityR_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void hospitalname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void hospitaladd_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundhome_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Display Requests
        private void Request_Click(object sender, EventArgs e)
        {
            Requestpanel2.Visible = true;
            Requestpanel2.BringToFront();
            backgroundhome.Visible = true;
            searchForm.Visible = true;
            

            dataGridView2.DataSource = DisReq();
        }
        //msh shaghala
        private void Delete_Click(object sender, EventArgs e)
        {
            //con.Open();
            //cmd = new SqlCommand("execute del_Req "+result, con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //dataGridView2.DataSource = DisReq();
            //MessageBox.Show("Deleted Successfully");
        }

        private void ex_Click(object sender, EventArgs e)
        {
            HomeForRecipient.Visible = true;
            backgroundhome.Visible = true;
            Requestpanel2.Visible = false;
            searchForm.Visible = false;
            sendRequestForm.Visible = false;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Requestpanel2.Visible = false;
          
            backgroundhome.Visible = false;
            searchForm.Visible = false;
       
        }

        //Delete Request
        private void Delete_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("execute del_Req '" + result + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            dataGridView2.DataSource = DisReq();
            MessageBox.Show("Deleted Successfully");
        }

        //To open details of request and check if he/she already sent request or not
        private void sendR_Click_2(object sender, EventArgs e)
        {
            int count;
            con.Open();
            cmd = new SqlCommand("select dbo.check_req ( " + result + ") ", con);
            count = (int)cmd.ExecuteScalar();
            con.Close();

            if (count == 0)
            {
                sendRequestForm.Visible = true;
                backgroundhome.Visible = true;
            }
            else
            {
                MessageBox.Show("You already sent request");
            }
            
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            Requestpanel2.Visible = false;

            backgroundhome.Visible = false;
            searchForm.Visible = false;
          
        }

        //Send request details
        private void finalSend_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("execute insert_request '" + hospitalname.Text + "', '" + hospitaladd.Text + "', '" + QuantityR.Text + "' , '" + BldType.Text + "','" + result.ToString() + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute NumofRequest '" +result+ "'", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("execute insert_Inv_Rec '" + result + "', '" + BldType.Text + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Your Request has been sent");
            dataGridView2.DataSource = DisReq();

            sendRequestForm.Visible = false;

            
        }

        private void exxit_Click(object sender, EventArgs e)
        {
          
            sendRequestForm.Visible = false;
        }

        
    }
}
