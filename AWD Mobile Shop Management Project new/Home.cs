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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mobile mob  = new Mobile();
            mob.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          Accessories acc = new Accessories();
            acc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Selling Sell  = new Selling();
            Sell.Show();
            this.Hide();
        }
    }
}
