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
    public partial class Instractors : Form
    {
        public Instractors()
        {
            InitializeComponent();
            Displayins();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
       
        private void Instractors_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        int key = 0;
        private void studentpanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            stfirsttb.Text = studentpanel.SelectedRows[0].Cells[1].Value.ToString();
            stlasttb.Text = studentpanel.SelectedRows[0].Cells[2].Value.ToString();
            insdegree.Text = studentpanel.SelectedRows[0].Cells[3].Value.ToString();
            inssalary.Text = studentpanel.SelectedRows[0].Cells[4].Value.ToString();
            insaddress.Text = studentpanel.SelectedRows[0].Cells[5].Value.ToString();
             dept.Text = studentpanel.SelectedRows[0].Cells[6].Value.ToString();
            

            if (stfirsttb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(studentpanel.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void stsave_Click(object sender, EventArgs e)
        {
            if (stfirsttb.Text == "" || stlasttb.Text == "" || insaddress.Text == "" || inssalary.Text == "" || dept.Text == "")
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
                        SqlCommand cmd = new SqlCommand("insert_into_Instructor_table  @IF,@IL,@IG,@IS,@IAD,@IDID", connection);
                        cmd.Parameters.AddWithValue("@IF", stfirsttb.Text);
                        cmd.Parameters.AddWithValue("@IL", stlasttb.Text);
                        cmd.Parameters.AddWithValue("@IG", insdegree.Text);
                        cmd.Parameters.AddWithValue("@IS", inssalary.Text);
                        cmd.Parameters.AddWithValue("@IAD", insaddress.Text);
                        cmd.Parameters.AddWithValue("@IDID", dept.Text);
               
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Instructor added", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                      Displayins();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }
        private void Displayins()
        {
            con.Open();
            string Query = "Select * from Instructor";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            studentpanel.DataSource = ds.Tables[0];
            con.Close();

        }

        private void stdelete_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Select The Instructor To Be Deleted!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Instructor Where ins_fname = @IF ", connection);
                        cmd.Parameters.AddWithValue("@IF", stfirsttb.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Instructor Deleted", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Displayins();
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
            if (stfirsttb.Text == "" || stlasttb.Text == "" || insaddress.Text == "" || inssalary.Text == "" || dept.Text == "")
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
                        SqlCommand cmd = new SqlCommand("Update Instructor set ins_fname=@IF,ins_lname=@IL,ins_degree=@IG,ins_salary=@IS,ins_address=@iAD,dept_id=@IDID where ins_id=@ins_id"
                           , connection);

                        cmd.Parameters.AddWithValue("@IF", stfirsttb.Text);
                        cmd.Parameters.AddWithValue("@IL", stlasttb.Text);
                        cmd.Parameters.AddWithValue("@IG", insdegree.Text);
                        cmd.Parameters.AddWithValue("@IS", inssalary.Text);
                        cmd.Parameters.AddWithValue("@IAD", insaddress.Text);
                        cmd.Parameters.AddWithValue("@IDID", dept.Text);
                        cmd.Parameters.AddWithValue("@ins_id", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Instructor Update", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Displayins();
                        connection.Close();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Admin.adminkids obj = new Admin.adminkids();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin.admincourses obj = new Admin.admincourses();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Admin.adminhome obj = new Admin.adminhome();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Admin.adminexam obj = new Admin.adminexam();
            obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Admin.admin_result obj = new Admin.admin_result();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}
