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
    public partial class ins_answe : Form
    {
        public ins_answe()
        {
            InitializeComponent();
            Displayanswer();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        int key = 0;
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void studentpanel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            coursid.Text = studentpanel.SelectedRows[0].Cells[2].Value.ToString();
            op1.Text = studentpanel.SelectedRows[0].Cells[3].Value.ToString();
            op2.Text = studentpanel.SelectedRows[0].Cells[4].Value.ToString();
            op3.Text = studentpanel.SelectedRows[0].Cells[5].Value.ToString();
            op4.Text = studentpanel.SelectedRows[0].Cells[6].Value.ToString();



        }

        private void stsave_Click(object sender, EventArgs e)
        {
            if (coursid.Text == "" || op1.Text == "" || op2.Text == "")
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
                        SqlCommand cmd = new SqlCommand("insert into Exam.Model_Choice (crs_id,option1,option2,option3,option4) values (@ACID,@A1,@A2,@A3,@A4)", connection);

                        cmd.Parameters.AddWithValue("@ACID", coursid.Text);
                        cmd.Parameters.AddWithValue("@A1", op1.Text);
                        cmd.Parameters.AddWithValue("@A2", op2.Text);
                        cmd.Parameters.AddWithValue("@A3", op3.Text);
                        cmd.Parameters.AddWithValue("@A4", op4.Text);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Answers added", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                        Displayanswer();

                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }


            }
        }
        private void Displayanswer()
        {
            con.Open();
            string Query = "Select * from Exam.Model_Choice";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            studentpanel.DataSource = ds.Tables[0];
            con.Close();

        }

        private void stedit_Click(object sender, EventArgs e)
        {
            if (coursid.Text == "" || op1.Text == "" || op2.Text == "")
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
                        SqlCommand cmd = new SqlCommand("Update Exam.Model_Choice set crs_id=@ACID,option1=@A1,option2=@A2,option3=@A3,option4=@A4 where crs_id=@crs_id"
                           , connection);


                        cmd.Parameters.AddWithValue("@ACID", coursid.Text);
                        cmd.Parameters.AddWithValue("@A1", op1.Text);
                        cmd.Parameters.AddWithValue("@A2", op2.Text);
                        cmd.Parameters.AddWithValue("@A3", op3.Text);
                        cmd.Parameters.AddWithValue("@A4", op4.Text);
                        cmd.Parameters.AddWithValue("@crs_id", key);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Answers Update", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Displayanswer();
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
            ins_exam obj = new ins_exam();
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

        private void label5_Click(object sender, EventArgs e)
        {
          login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ins_exam obj = new ins_exam();
            obj.Show();
            this.Hide();
        }
    }
}
