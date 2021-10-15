using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_Bank_system
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login1admin_Click(object sender, EventArgs e)
        {
            LoginAsAdmin L3 = new LoginAsAdmin();
            L3.Show();
        }

        private void Login1Donor_Click(object sender, EventArgs e)
        {
            LoginAsDonor l2 = new LoginAsDonor();
            l2.Show();
        }

        private void Login1Recipient_Click(object sender, EventArgs e)
        {
            LoginAsRecipient l1 = new LoginAsRecipient();
            l1.Show();
   
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
