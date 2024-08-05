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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int startpoint = 15;


        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint   += 1;
            VProgressBar.Value = startpoint;
            LProgressBar.Value = startpoint;
            if (LProgressBar.Value == 100) 
            {
                VProgressBar.Value = 0;
                LProgressBar.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
