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

namespace AWD_Mobile_Shop_Management_Project_new
{
    public partial class Mobile : Form
    {
        public Mobile()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Users\ADMIN\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            String query = "select * from MobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();


        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Close();
                    Con.Open();
                    String sql = "insert into MobileTbl values(" + Mobidtb.Text + ",'" + brandtb.Text + "', '" + modeltb.Text + "', " + pricetb.Text + "," + stocktb.Text + ", " + ramcb.SelectedItem.ToString() + ", " + romcb.SelectedItem.ToString() + "," + cameratb.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile added successfully");
                    Con.Close();
                    populate();

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Mobile_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mobidtb.Text = "";
            brandtb.Text = "";
            modeltb.Text = "";
            pricetb.Text = "";
            stocktb.Text = "";
            cameratb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "")
            {
                MessageBox.Show("Enter the mobile to be Deleted");
            }
            else
            {
                try
                {
                    Con.Close();
                    Con.Open();
                    string query = "delete from MobileTbl where MobId = " + Mobidtb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
                    Con.Close();
                    populate();
                } catch (Exception ex)
                {

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Close();
                    Con.Open();
                    String sql = "update MobileTbl set Mbrand = '" + brandtb.Text.ToString() + "', MModel = '" + modeltb.Text.ToString() + "', Mstock='" + stocktb.Text.ToString() + "', MRam='" + ramcb.SelectedItem.ToString() + "',MRom='" + romcb.SelectedItem.ToString() + "',MCamera='" + cameratb.Text.ToString() + "'where MobId =" +Convert.ToInt32( Mobidtb.Text )+ ";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Updated successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void MobileDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           Mobidtb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brandtb.Text = MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modeltb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            pricetb.Text = MobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stocktb.Text = MobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ramcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            romcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            cameratb.Text = MobileDGV.SelectedRows[0].Cells[7].Value.ToString();
        }
    }

}