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
    public partial class examkids : Form
    {
        public examkids()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panelcenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dbToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // IQquiz iq = new IQquiz();
            //iq.ShowDialog();
        }

        private void iQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            homekids obj = new homekids();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           resultkids obj = new resultkids();
            obj.Show();
            this.Hide(); 
        }

        private void stsave_Click(object sender, EventArgs e)
        {
           IQquiz obj = new IQquiz();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select concat(kid_fname,' ',kid_lname) from Kid where kid_id =" + login.x, con);
         //   label4.Text = (string)cmd.ExecuteScalar();
            con.Close();
          //  label6.Text = login.x;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* int test = int.Parse(login.x);
            con.Open();
            SqlCommand cmd = new SqlCommand(" execute generate_exam " + test + "", con);
            con.Close();
            MessageBox.Show("exam added", "result", MessageBoxButtons.OK, MessageBoxIcon.Information); */
          
        }

        private void examkids_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
