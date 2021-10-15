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
    public partial class LoginAsAdmin : Form
    {
        static string sql = "Data Source=LAPTOP-C0IG6J83\\FARAH;Initial Catalog=Project1;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        SqlCommand cmd = new SqlCommand();
        int result;
       
        //Procedure to find Expired Status
        public LoginAsAdmin()
        {
            InitializeComponent();
            con.Open();
            cmd = new SqlCommand("execute ExpStatus", con);
            cmd.ExecuteNonQuery();
            con.Close();

            loadDGVSettings(dataGridView1);
            loadDGVSettings(dataGridView3);
            loadDGVSettings(dataGridView4);
            loadDGVSettings(dataGridView5);
            loadDGVSettings(dataGridView6);
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

        //Display Donor grid1
        public DataTable Donor_Dis()
        {
            DataTable tbl_Donor = new DataTable();
            con.Open();
            cmd = new SqlCommand("execute Display_donor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl_Donor);
            con.Close();
            return tbl_Donor;
        }

        //Display Reciepent grid3
        public DataTable Rec_Dis() 
        {
            DataTable tbl_Recipient = new DataTable();
            con.Open();
            cmd = new SqlCommand("execute dis_admin_rec", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl_Recipient);
            con.Close();
            return tbl_Recipient;
        }

        //Display Blood grid4
        public DataTable Bld_Dis()
        {
            DataTable tbl_blood = new DataTable();
            con.Open();
            cmd = new SqlCommand("execute dis_bloodinven1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl_blood);
            con.Close();
            return tbl_blood;
        }

        //Display Blood Inventory grid5
        public DataTable bldInv()
        {
            DataTable tbl_bloodinv = new DataTable();
            con.Open();
            cmd = new SqlCommand("execute dis_bloodinven2", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl_bloodinv);
            con.Close();
            return tbl_bloodinv;
        }

        //Display Request grid6
        public DataTable Req_Dis()
        {
            DataTable tbl_req = new DataTable();
            con.Open();
            cmd = new SqlCommand("execute Req_Dis", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tbl_req);
            con.Close();
            return tbl_req;
        }

        private void BackA_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void login2admin_Click(object sender, EventArgs e)
        {
            
        }

        //login
        private void login2admin_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT dbo.login_Admin('" + UsernameAdmin.Text + "', '" + PasswordAdmin.Text + "')", con);

                result = (int)cmd.ExecuteScalar();
        
                con.Close();
                if (result >=1 && result <= 6)
                {
                    MessageBox.Show("Login Success");
                    HomeForAdmin.Visible = true;
                    BackgroundHome2.Visible = true;
                }
                else
                    MessageBox.Show("Incorrect login");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error:" + ex.Message);
            }
        }

        private void BackA_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LogOutA_Click(object sender, EventArgs e)
        {
            HomeForAdmin.Visible = false;
            BackgroundHome2.Visible = false;
        }

        //Donor Section
        private void DonorAdmin_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = true;
            BackgroundHome2.Visible = true;
            dataGridView1.DataSource = Donor_Dis();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        //Recipient Section
        private void RecipientAdmin_Click(object sender, EventArgs e)
        {

            AdmindonorAdd.Visible = true;
            Admindonor.Visible = true;
            AdminRecipient.Visible = true;
            dataGridView3.DataSource = Rec_Dis();
        }


        private void AddRecbAdmin_Click(object sender, EventArgs e)
        {
            //AddRecipientpanel2.Visible=true;
            //Admindonor.Visible = false;
            //AdmindonorAdd.Visible = false;
            //AdminRecipient.Visible = false;
            //BloodInventory.Visible = false;
            //RequestPanel.Visible = false;


            //msh shaghaal
            //MessageBox.Show("Done !");
        }

        //Search for Donor
        private void SearchDonorAdmin_TextChanged(object sender, EventArgs e)
        {
             
            DataTable dt = new DataTable();
            con.Open();
            string query = "select * from ser_adm_don ('" + SearchDonorAdmin.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            
        }

        //Button to open Register form
        private void AddDonorbyAdmin_Click_1(object sender, EventArgs e)
        {
            RegisterDonor r1 = new RegisterDonor();
            r1.Show();
            //AdmindonorAdd.Visible = true;
            //BackgroundHome2.Visible = true;
        }

        //Delete Donor
        private void DeleteDonor_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("execute del_don '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.DataSource = Donor_Dis();
            MessageBox.Show("Deleted Successfully");

        }

        private void ExitDonor2_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = false;
            BackgroundHome2.Visible = false;
        }

        private void ExitDonor_Click(object sender, EventArgs e)
        {
            AdmindonorAdd.Visible = false;
            Admindonor.Visible = false;
            BackgroundHome2.Visible = false;
        }

        private void AddDonorbyAdmin2_Click_1(object sender, EventArgs e)
        {
            //msh shaghala
            RegisterDonor r1 = new RegisterDonor();
            r1.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AddQuantityAdmin_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //msh shaghala
            //DataTable dt = new DataTable();
            //con.Open();
            //string query = "select * from Search_Don_Exist ('" + textBox1.Text + "')";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //con.Close();
            //dataGridView2.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Delete Recipient
        private void DeleteRec_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("execute del_rec '" + dataGridView3.CurrentRow.Cells[0].Value.ToString() + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView3.DataSource = Rec_Dis();
            MessageBox.Show("Deleted Successfully");
        }

        private void ExitAdminRec_Click(object sender, EventArgs e)
        {
            AdminRecipient.Visible = false;
            AdmindonorAdd.Visible = false;
            Admindonor.Visible = false;
        }

        private void BloodInventory_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Search Recipient
        private void SearchRcipientbyAdmin_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            con.Open();
            string query = "select * from ser_adm_rec ('" + SearchRcipientbyAdmin.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
           
            dataGridView3.DataSource = dt;
            
        }

        //button to open Register form
        private void AddRecAdmin_Click(object sender, EventArgs e)
        {
            //HomeForAdmin.Visible = true;
            //RequestPanel.Visible = true;
            //AddRecipientpanel2.Visible = true;
            //Admindonor.Visible = true;
            //AdmindonorAdd.Visible = true;
            //AdminRecipient.Visible = true;
            //BloodInventory.Visible = true;
            RegisterRecipient r1 = new RegisterRecipient();
            r1.Show();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExitBldInv_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = false;
            AdmindonorAdd.Visible = false;
            AdminRecipient.Visible = false;
            BloodInventory.Visible = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //search in blood inv by blood type or expired status
        private void SearchBloodInv_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            con.Open();
            string query = "select * from bloodtype_Exp_status ('"+SearchBloodInv.Text+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            dataGridView4.DataSource = dt;
        }

        //Delete blood
        private void DeleteBldinv_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("execute del_Blood '" + dataGridView4.CurrentRow.Cells[0].Value.ToString() + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView4.DataSource = Bld_Dis();
            MessageBox.Show("Deleted Successfully");

            dataGridView5.DataSource = bldInv();
        }

        //Blood Inventory section
        private void Bloodinv_Click(object sender, EventArgs e)
        {

            Admindonor.Visible = true;
            AdmindonorAdd.Visible = true;
            AdminRecipient.Visible = true;
            BloodInventory.Visible = true;
            dataGridView4.DataSource = Bld_Dis();
            dataGridView5.DataSource = bldInv();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
        private void dataGridView6_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //msh shaghala
            //RequestForm f2 = new RequestForm();
            //f2.ID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //f2.Date.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //f2.Qty.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //f2.BType.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //f2.Rname.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //f2.Hosp.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //f2.ShowDialog();

        }

        //Request section
        private void RequestAdmin_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = true;
            AdmindonorAdd.Visible = true;
            AdminRecipient.Visible = true;
            BloodInventory.Visible = true;
            RequestPanel.Visible = true;
            dataGridView6.DataSource = Req_Dis();
        }

        private void ExitRequest_Click(object sender, EventArgs e)
        {
            Admindonor.Visible = false;
            AdmindonorAdd.Visible = false;
            AdminRecipient.Visible = false;
            BloodInventory.Visible = false;
            RequestPanel.Visible = false;
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        //To open request form
        private void dataGridView6_DoubleClick(object sender, EventArgs e)
        {
            RequestForm f = new RequestForm();
            f.ID.Text = this.dataGridView6.CurrentRow.Cells[0].Value.ToString();
            f.Date.Text = this.dataGridView6.CurrentRow.Cells[2].Value.ToString();
            f.Rname.Text = this.dataGridView6.CurrentRow.Cells[3].Value.ToString();
            f.BType.Text = this.dataGridView6.CurrentRow.Cells[4].Value.ToString();
            f.Qty.Text = this.dataGridView6.CurrentRow.Cells[5].Value.ToString();
            f.Hosp.Text = this.dataGridView6.CurrentRow.Cells[6].Value.ToString();
            f.Addr.Text = this.dataGridView6.CurrentRow.Cells[7].Value.ToString();
            f.ShowDialog();

            dataGridView6.DataSource = Req_Dis();

        }

        private void ExiTTT_Click(object sender, EventArgs e)
        {
            HomeForAdmin.Visible = true;
            RequestPanel.Visible = false;
            //AddRecipientpanel2.Visible = false;
            Admindonor.Visible = false;
            AdmindonorAdd.Visible = false;
            AdminRecipient.Visible = false;
            BloodInventory.Visible = false;
        }

        //Delete Request
        private void DeleteReq_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("execute del_Req '" + dataGridView6.CurrentRow.Cells[0].Value.ToString() + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView6.DataSource = Req_Dis();
            MessageBox.Show("Deleted Successfully");
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //To open AddRec form
        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            AddRec f2 = new AddRec();
            f2.ID.Text = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            f2.username.Text = this.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            f2.pass.Text = this.dataGridView3.CurrentRow.Cells[2].Value.ToString();
            f2.name.Text = this.dataGridView3.CurrentRow.Cells[3].Value.ToString();
            f2.gender.Text = this.dataGridView3.CurrentRow.Cells[4].Value.ToString();    
            f2.age.Text = this.dataGridView3.CurrentRow.Cells[5].Value.ToString();
            f2.pnum.Text = this.dataGridView3.CurrentRow.Cells[6].Value.ToString();
            f2.num.Text = this.dataGridView3.CurrentRow.Cells[7].Value.ToString();
            f2.ShowDialog();
            
            dataGridView3.DataSource = Rec_Dis();
        }

        //To open AddDon form
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            AddDonor f2 = new AddDonor();
            f2.ID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f2.username.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f2.pass.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f2.name.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f2.BType.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f2.gender.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f2.age.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            f2.address.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            f2.pnum.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            f2.num.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            f2.ShowDialog();

            dataGridView1.DataSource = Donor_Dis();
        }
    }
}
