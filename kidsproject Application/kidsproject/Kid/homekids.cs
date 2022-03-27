using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kidsproject
{
    public partial class homekids : Form
    {
        public homekids()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            examkids obj = new examkids();
            obj.Show();
            this.Hide();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           resultkids obj = new resultkids();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
             
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

           
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {
           

            con.Open();
            SqlCommand cmd = new SqlCommand("select concat(kid_fname,' ',kid_lname) from Kid where kid_id =" + login.x, con);
            label8.Text = (string) cmd.ExecuteScalar();
            con.Close();


            con.Open();
            SqlCommand cmd2 = new SqlCommand("select concat(kid_fname,' ',kid_lname) from Kid where kid_id =" + login.x, con);
            name.Text = (string)cmd2.ExecuteScalar();
            con.Close();
            id.Text = login.x;

            con.Open();
            SqlCommand cmd1 = new SqlCommand("select kid_address from Kid where kid_id =" + login.x, con);
            adress.Text = (string)cmd1.ExecuteScalar();
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("select kid_phone from Kid where kid_id =" + login.x, con);
          phone.Text = (string)cmd3.ExecuteScalar().ToString();
            con.Close();

            con.Open();
            SqlCommand cmd4 = new SqlCommand("select kid_age from Kid where kid_id =" + login.x, con);
            age.Text = (string)cmd4.ExecuteScalar().ToString();
            con.Close();

           con.Open();
            SqlCommand cmd5 = new SqlCommand("select kid_level from Kid where kid_id =" + login.x, con);
            level.Text = (string)cmd5.ExecuteScalar().ToString();
            con.Close(); 

            con.Open();
            SqlCommand cmd6 = new SqlCommand("select dept_id from Kid where kid_id =" + login.x, con);
             dept.Text = (string)cmd6.ExecuteScalar().ToString();
            con.Close();

            con.Open();
            SqlCommand cmd7 = new SqlCommand("select kid_gender from Kid where kid_id =" + login.x, con);
            gender.Text = (string)cmd7.ExecuteScalar().ToString();
            con.Close();
        }

        private void examkid_Click(object sender, EventArgs e)
        {
            examkids obj = new examkids();
            obj.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            resultkids obj = new resultkids();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void studentpanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
