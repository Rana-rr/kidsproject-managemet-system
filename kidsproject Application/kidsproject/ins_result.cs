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
    public partial class ins_result : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        public ins_result()
        {
            InitializeComponent();
            DisplayGrades();
        }
        int key = 0;
        private void panelcourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  examid.Text = panelcourse.SelectedRows[0].Cells[1].Value.ToString();
            StDOB.Value = Convert.ToDateTime(panelcourse.SelectedRows[0].Cells[1].Value.ToString());
            insid.Text = panelcourse.SelectedRows[0].Cells[2].Value.ToString();
            crsid.Text = panelcourse.SelectedRows[0].Cells[3].Value.ToString();
            kidid.Text = panelcourse.SelectedRows[0].Cells[4].Value.ToString();
            grade.Text = panelcourse.SelectedRows[0].Cells[5].Value.ToString();
        

            if (grade.Text == "")
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
           
        }
        private void DisplayGrades()
        {
            con.Open();
            string Query = "Select * from Exam.Exam";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            panelcourse.DataSource = ds.Tables[0];
            con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Editbt_Click(object sender, EventArgs e)
        {
          if  (insid.Text == "" || crsid.Text == "" || grade.Text == "" || kidid.Text == "")            {
                MessageBox.Show("Missing Information!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("Update Exam.Exam set exam_date=@EBD,ins_id=@IID,crs_id=@CID,kid_id=@KID,Grade=@EG where exam_id=@kid_id"
                           , connection); 

                        cmd.Parameters.AddWithValue("@EBD", StDOB.Value.Date);
                        cmd.Parameters.AddWithValue("@IID", insid.Text);
                        cmd.Parameters.AddWithValue("@CID", crsid.Text);
                        cmd.Parameters.AddWithValue("@KID", kidid.Text);
                        cmd.Parameters.AddWithValue("@EG", grade.Text);
                        cmd.Parameters.AddWithValue("@kid_id", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kid Update", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayGrades();
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
            Students obj = new Students();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           Mycourses obj = new Mycourses();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ins_exam obj = new ins_exam();
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    

