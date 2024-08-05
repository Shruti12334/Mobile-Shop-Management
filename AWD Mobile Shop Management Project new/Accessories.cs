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
using System.Xml.Linq;
namespace AWD_Mobile_Shop_Management_Project_new
{
    public partial class Accessories : Form
    {
        int stk;
        String id;
        public Accessories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Users\ADMIN\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            String query = "select * from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessorieDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (AidTb.Text == "" || AbrandTb.Text == "" || ApriceTb.Text == "" || AmodelTb.Text == "" || AStock.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Close();
                    Con.Open();
                    String sql = "insert into AccessorieTbl values(" + AidTb.Text + ",'" + AbrandTb.Text + "', '" + AmodelTb.Text + "', " + AStock.Text + "," + ApriceTb.Text + ")";

                    SqlCommand cd = new SqlCommand(sql, Con);
                    cd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Added successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void Accessories_Load(object sender, EventArgs e)
        {
            populate();
            id = AidTb.Text.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AidTb.Text = "";
            AbrandTb.Text = "";
            AmodelTb.Text = "";
            ApriceTb.Text = "";
            AStock.Text = "";

        }

        private void AccessorieDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (AidTb.Text == "")
                {
                    MessageBox.Show("Enter the Accessorie to be Deleted");
                }
                else
                {
                    try
                    {
                        Con.Close();
                        Con.Open();
                        string query = "delete AccessorieTbl where AId = " + AidTb.Text + "";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Accessorie Deleted");
                        Con.Close();
                        populate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (AidTb.Text == "" || AbrandTb.Text == "" || AmodelTb.Text == "" || AStock.Text == "" || ApriceTb.Text == "")

                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    try
                    {
                        Con.Close();
                        Con.Open();
                        String sql = "update AccessorieTbl set Abrand = '" + AbrandTb.Text + "', AModel = '" + AmodelTb.Text + "', Astock=" + AStock.Text + ", Aprice = " + ApriceTb.Text + "where AId =" + AidTb.Text + ";";
                        SqlCommand cmd = new SqlCommand(sql, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Accessorie Updated successfully");
                        Con.Close();
                        populate();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void AccessorieDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AidTb.Text = AccessorieDGV.SelectedRows[0].Cells[0].Value.ToString();
            AbrandTb.Text = AccessorieDGV.SelectedRows[0].Cells[1].Value.ToString();
            AmodelTb.Text = AccessorieDGV.SelectedRows[0].Cells[2].Value.ToString();
            AStock.Text = AccessorieDGV.SelectedRows[0].Cells[3].Value.ToString();
            ApriceTb.Text = AccessorieDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Con.Close();
            Con.Open();
            string qu = "SELECT AStock From AccessorieTbl WHERE AId = @id;";
            SqlCommand cmd = new SqlCommand(qu, Con);
            cmd.Parameters.AddWithValue("id", id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    stk = reader.GetInt32(0);
                }
            }
            int qty = Convert.ToInt32(AStock.Text);
            if (stk > qty)
            {
                string query = "UPDATE AccessorieTbl SET AStock = AStock + @qty WHERE AId = @id;";
                SqlCommand sqlCommand = new SqlCommand(query, Con);
                sqlCommand.Parameters.AddWithValue("qty", qty);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.ExecuteNonQuery();
                Con.Close();
            }
        }
    }
}