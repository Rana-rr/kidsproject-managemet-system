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
    public partial class ins_exam : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        int key = 0;
        public ins_exam()
        {
            InitializeComponent();
            Displayexam();
        }

        private void stsave_Click(object sender, EventArgs e)
        {

            if (qhead.Text == "" || qanswer.SelectedIndex == -1 || qtype.SelectedIndex == -1 || diff.SelectedIndex == -1 || courseid.Text == "")
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
                        SqlCommand cmd = new SqlCommand("insert into Exam.Question (ques_head,ques_answer,ques_type,crs_id,Difficulty) values (@EH,@EA,@ET,@EID,@ED)", connection);
                        cmd.Parameters.AddWithValue("@EH", qhead.Text);
                        cmd.Parameters.AddWithValue("@EA", qanswer.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ET", qtype.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@EID", courseid.Text);
                        cmd.Parameters.AddWithValue("@ED", diff.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Question added", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        Displayexam();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }

        private void studentpanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            qhead.Text = studentpanel.SelectedRows[0].Cells[1].Value.ToString();
            qanswer.Text = studentpanel.SelectedRows[0].Cells[2].Value.ToString();
            qtype.Text = studentpanel.SelectedRows[0].Cells[3].Value.ToString();
            courseid.Text = studentpanel.SelectedRows[0].Cells[4].Value.ToString();
            diff.Text = studentpanel.SelectedRows[0].Cells[5].Value.ToString();



            if (qhead.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(studentpanel.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Displayexam()
        {
            con.Open();
            string Query = "Select * from Exam.Question";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            studentpanel.DataSource = ds.Tables[0];
            con.Close();

        }

        private void stedit_Click(object sender, EventArgs e)
        {
            if (qhead.Text == "" || qanswer.SelectedIndex == -1 || qtype.SelectedIndex == -1 || diff.SelectedIndex == -1 || courseid.Text == "")
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
                        SqlCommand cmd = new SqlCommand("Update Exam.Question set ques_head=@EH,ques_answer=@EA,ques_type=@ET,crs_id=@EID,Difficulty=@ED where ques_id=@ques_id"
                           , connection);

                        cmd.Parameters.AddWithValue("@EH", qhead.Text);
                        cmd.Parameters.AddWithValue("@EA", qanswer.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ET", qtype.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@EID", courseid.Text);
                        cmd.Parameters.AddWithValue("@ED", diff.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ques_id", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Question Update", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Displayexam();
                        connection.Close();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }

        private void stdelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Question To Be Deleted!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Exam.Question Where ques_head = @EH ", connection);
                        cmd.Parameters.AddWithValue("@EH", qhead.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Question Deleted", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Displayexam();
                        connection.Close();
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void answer_Click(object sender, EventArgs e)
        {
            ins_answe obj = new ins_answe();
            obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
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

        private void label2_Click(object sender, EventArgs e)
        {
            ins_result obj = new ins_result();
            obj.Show();
            this.Hide();
        }
    }
}
