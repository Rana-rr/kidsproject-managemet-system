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

namespace kidsproject.Admin
{
    public partial class admincourses : Form
    {
        public admincourses()
        {
            InitializeComponent();
            DisplayCourse();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        int key = 0;
        private void panelcourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CourseName.Text = panelcourse.SelectedRows[0].Cells[1].Value.ToString();
            Duration.Text = panelcourse.SelectedRows[0].Cells[2].Value.ToString();
            Materialcb.Text = panelcourse.SelectedRows[0].Cells[3].Value.ToString();
            deptid.Text = panelcourse.SelectedRows[0].Cells[4].Value.ToString();


            if (CourseName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(panelcourse.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (CourseName.Text == "")
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

                        SqlCommand cmd = new SqlCommand("insert_into_course_table @CN,@CD,@CM,@CDEP", connection);

                        cmd.Parameters.AddWithValue("@CN", CourseName.Text);
                        cmd.Parameters.AddWithValue("@CD", Duration.Text);
                        cmd.Parameters.AddWithValue("@CM", Materialcb.Text);
                        cmd.Parameters.AddWithValue("@CDEP", deptid.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Course added", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayCourse();

                        connection.Close();
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }



            }
        }
        private void DisplayCourse()
        {
            con.Open();
            string Query = "Select * from Course";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            panelcourse.DataSource = ds.Tables[0];
            con.Close();

        }

        private void Editbt_Click(object sender, EventArgs e)
        {
            if (CourseName.Text == "" || Duration.Text == "" || /*Materialcb.Text == "" ||*/ deptid.Text == "")
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
                        SqlCommand cmd = new SqlCommand("Update Course set crs_name=@CN,crs_duration=@CD,crs_material=@CM,dept_id=@CDEP where crs_id = @crs_id"
                           , connection);

                        cmd.Parameters.AddWithValue("@CN", CourseName.Text);
                        cmd.Parameters.AddWithValue("@CD", Duration.Text);
                        cmd.Parameters.AddWithValue("@CM", Materialcb.Text);
                        cmd.Parameters.AddWithValue("@CDEP", deptid.Text);
                        cmd.Parameters.AddWithValue("@crs_id", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Course Updated", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayCourse();
                        connection.Close();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }

        private void Deletebt_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Course To Be Deleted!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Course Where crs_name = @CN ", connection);
                        cmd.Parameters.AddWithValue("@CN", CourseName.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Course Deleted", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayCourse();
                        connection.Close();
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           Instractors obj = new Instractors();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
           Admin.adminkids obj = new Admin.adminkids();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
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
