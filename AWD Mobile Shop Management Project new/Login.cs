using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWD_Mobile_Shop_Management_Project_new
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UidTb.Text = "";
            PassTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UidTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter User Name and Password");
            }
            else if (UidTb.Text == "Admin" && PassTb.Text == "Admin")
            {
              Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password");
            }
        }

        private void UidTb_TextChanged(object sender, EventArgs e)
        {
        }
    }
}