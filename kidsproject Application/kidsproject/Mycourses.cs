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
    public partial class Mycourses : Form
    {
        public Mycourses()
        {
            InitializeComponent();
        
            DisplayCourse();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
    
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Coursecb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Coursecb_SelectionChangeCommitted(object sender, EventArgs e)
        {
          //  FetchCname();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void seveCourses(object sender, EventArgs e)
        {
            if ( CourseName.Text == ""   )
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Coursetb_TextChanged(object sender, EventArgs e)
        {




        }

        private void button3_Click(object sender, EventArgs e)
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

        private void Mycourses_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            ins_exam obj = new ins_exam();
            obj.Show();
            this.Hide();
        }
    }
}
