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
    public partial class resultkids : Form
    {
        public resultkids()
        {
            InitializeComponent();
            DisplayResult();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void resultkids_Load(object sender, EventArgs e)
        {
         /*   con.Open();
            SqlCommand _cmd = new SqlCommand("Select * From dbo.ResultData where Kid_id = @kidid" ,con);
            _cmd.Parameters.AddWithValue("@kidid", int.Parse(login.x));
            _cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(_cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DGV.DataSource = dt; */
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
           homekids obj = new homekids();
            obj.Show();
            this.Hide();
        }

        private void examkid_Click(object sender, EventArgs e)
        {
            examkids obj = new examkids();
            obj.Show();
            this.Hide();
        }

        private void Studentpanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DisplayResult()
        {
            con.Open();
            SqlCommand _cmd = new SqlCommand("Select * From dbo.ResultData where Kid_id = @kidid", con);
            _cmd.Parameters.AddWithValue("@kidid", int.Parse(login.x));
            _cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(_cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
           Studentpanel.DataSource = dt;

             /*con.Open();
            string Query = "Select * From dbo.ResultData where Kid_id = @kidid";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Studentpanel.DataSource = ds.Tables[0];
            con.Close();*/

        }

        private void panelcenter_Paint(object sender, PaintEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select concat(kid_fname,' ',kid_lname) from Kid where kid_id =" + login.x, con);
            label4.Text = (string)cmd.ExecuteScalar();
            con.Close();
            label1.Text = login.x;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
