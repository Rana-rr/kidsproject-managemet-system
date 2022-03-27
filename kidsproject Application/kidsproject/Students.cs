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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
           // level();
            Displaykids();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
         
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panelcenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Mycourses obj = new Mycourses();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void stsave_Click(object sender, EventArgs e)
        {
            if (stfirsttb.Text == ""|| stlasttb.Text==""  ||stadresstb.Text=="" || stgendertb.SelectedIndex ==-1|| stphonetb.Text==""|| stleveltb.SelectedIndex == -1 || dept.Text == "")
            {
                MessageBox.Show("Missing Information!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("insert_into_kid_table  @SF,@SL,@SG,@SA,@SP,@SCN,@SDID,@SBD,@kcrs", connection);
                        cmd.Parameters.AddWithValue("@SF", stfirsttb.Text);
                        cmd.Parameters.AddWithValue("@SL", stlasttb.Text);
                        cmd.Parameters.AddWithValue("@SG", stgendertb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@SA", stadresstb.Text);
                        cmd.Parameters.AddWithValue("@SP", stphonetb.Text);
                        cmd.Parameters.AddWithValue("@SBD", StDOB.Value.Date);
                        cmd.Parameters.AddWithValue("@SDID", dept.Text);
                        cmd.Parameters.AddWithValue("@SCN", stleveltb.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Kcrs", crsid.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kid added", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        Displaykids();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }
        private void Displaykids()
        {
            con.Open();
            string Query = "Select * from Kid";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            
            var ds = new DataSet();
              sda.Fill(ds);
            studentpanel.DataSource = ds.Tables[0];
            con.Close();

        }

        private void Coursecb_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void StDOB_onValueChanged(object sender, EventArgs e)
        {

        }

        private void stleveltb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        int key = 0;
        private void studentpanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            stfirsttb.Text = studentpanel.SelectedRows[0].Cells[1].Value.ToString();
            stlasttb.Text = studentpanel.SelectedRows[0].Cells[2].Value.ToString();
            stgendertb.Text = studentpanel.SelectedRows[0].Cells[4].Value.ToString();
            stadresstb.Text = studentpanel.SelectedRows[0].Cells[5].Value.ToString();
            stphonetb.Text = studentpanel.SelectedRows[0].Cells[6].Value.ToString();
            stleveltb.Text = studentpanel.SelectedRows[0].Cells[7].Value.ToString();
            dept.Text = studentpanel.SelectedRows[0].Cells[8].Value.ToString();
            crsid.Text = studentpanel.SelectedRows[0].Cells[8].Value.ToString();
            StDOB.Value = Convert.ToDateTime(studentpanel.SelectedRows[0].Cells[9].Value.ToString());

            if (stfirsttb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(studentpanel.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void stdelete_Click(object sender, EventArgs e)
        { 
            
            if (key == 0)
            {
                MessageBox.Show("Select The Kid To Be Deleted!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("Delete_Kid_Data @SP  ", connection);
                        cmd.Parameters.AddWithValue("@SP", stphonetb.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Kid Deleted", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                        Displaykids();
                        connection.Close();
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void stedit_Click(object sender, EventArgs e)
        { 

           
        }

        private void pnHome_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            ins_exam obj = new ins_exam();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stgendertb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dept_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void stlasttb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void stphonetb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void stadresstb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void stfirsttb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void stedit_Click_1(object sender, EventArgs e)
        {
            if (stfirsttb.Text == "" || stlasttb.Text == "" || stadresstb.Text == "" || stgendertb.SelectedIndex == -1 || stphonetb.Text == "" || stleveltb.SelectedIndex == -1 || dept.Text == "")
            {
                MessageBox.Show("Missing Information!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("Update Kid set kid_fname=@SF,kid_lname=@SL,kid_gender=@SG,kid_address=@SA,kid_phone=@SP,kid_level=@SCN,kid_birthdate=@SBD,dept_id=@SDID where kid_id=@kid_id"
                           , connection);

                        cmd.Parameters.AddWithValue("@SF", stfirsttb.Text);
                        cmd.Parameters.AddWithValue("@SL", stlasttb.Text);
                        cmd.Parameters.AddWithValue("@SG", stgendertb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@SA", stadresstb.Text);
                        cmd.Parameters.AddWithValue("@SP", stphonetb.Text);
                        cmd.Parameters.AddWithValue("@SBD", StDOB.Value.Date);
                        cmd.Parameters.AddWithValue("@SDID", dept.Text);
                        cmd.Parameters.AddWithValue("@SCN", stleveltb.SelectedIndex);
                        cmd.Parameters.AddWithValue("@kid_id", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kid Update", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Displaykids();
                        connection.Close();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        
    }
    }
}
