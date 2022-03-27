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
    public partial class IQquiz : Form
    {
        int Q;
        public IQquiz()
        {
            InitializeComponent();
           
        }
       public static SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        public static int correction(int k_id,int ex_id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Correct_Exam", con);
            cmd.Parameters.AddWithValue("kid_ID", k_id);
            cmd.Parameters.AddWithValue("Exam_ID",ex_id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public static int JustForTest(int _KID, int _Eid, int Qid, string ansr)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertInto ", con);
            cmd.Parameters.AddWithValue("kid", _KID);
            cmd.Parameters.AddWithValue("Eid", _Eid);
            cmd.Parameters.AddWithValue("QID", Qid);
            cmd.Parameters.AddWithValue("answer", ansr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            int resultt = cmd.ExecuteNonQuery();
            con.Close();
            return resultt;
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IQquiz_Load(object sender, EventArgs e)
        {
            timer1.Start();
            con.Open();
            int test = int.Parse(login.x);

           // SqlCommand cmd = new SqlCommand("select * from Exam.Questions where Kid_id = " + test,con);
            SqlCommand cmd2 = new SqlCommand("declare @examid int set @examid = (select exam_id from Exam.Exam where kid_id = " + test + "); select * from Exam.Questions where exam_id = @examid", con);
            // cmd.Parameters.AddWithValue("kid_id", login.x);
            cmd2.ExecuteNonQuery();

          
           

            con.Close();

            con.Open();

             List<string> newex = new List<string>();
            SqlCommand _cmd3 = new SqlCommand("declare @Eid int Select @Eid = (select exam_id from Exam.Exam where kid_id = " + test + ");select q.ques_id ,q.ques_answer from Exam.Question q inner join Exam.Exam_Questions eq on q.ques_id = eq.Question_id and eq.exam_id = @Eid ", con);
             _cmd3.Parameters.AddWithValue("Eid", test);
             _cmd3.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
             int go = 0;
              foreach (var item in dt.Rows)
              {
                  string x = dt.Rows[0][1].ToString(); 
                  newex.Add(x);
              }
           
            con.Close();

         

            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
           groupBox10.Visible = false;
            submitbtn.Visible = false;
         
            
          

            Q = 1;
           // btnNext.Text = dt.Rows[Q].ToString();
          //  foreach (DataRow item1 in dt.Rows)
          //  {
                Q0.Text = dt.Rows[0]["ques_head"].ToString();
                radioButton1.Text = dt.Rows[0]["option1"].ToString();
                radioButton4.Text = dt.Rows[0]["option2"].ToString();
                radioButton3.Text = dt.Rows[0]["option3"].ToString();
                radioButton2.Text = dt.Rows[0]["option4"].ToString();
               

                Q1.Text = dt.Rows[1]["ques_head"].ToString();
                radioButton8.Text = dt.Rows[1]["option1"].ToString();
                radioButton5.Text = dt.Rows[1]["option2"].ToString();
                radioButton6.Text = dt.Rows[1]["option3"].ToString();
                radioButton7.Text = dt.Rows[1]["option4"].ToString();
               
                
                Q2.Text = dt.Rows[2]["ques_head"].ToString();
                radioButton12.Text = dt.Rows[2]["option1"].ToString();
                radioButton9.Text = dt.Rows[2]["option2"].ToString();
                radioButton10.Text = dt.Rows[2]["option3"].ToString();
                radioButton11.Text = dt.Rows[2]["option4"].ToString();
              

                Q3.Text = dt.Rows[3]["ques_head"].ToString();
                radioButton16.Text = dt.Rows[3]["option1"].ToString();
                radioButton13.Text = dt.Rows[3]["option2"].ToString();
                radioButton14.Text = dt.Rows[3]["option3"].ToString();
                radioButton15.Text = dt.Rows[3]["option4"].ToString();
               
                Q4.Text = dt.Rows[4]["ques_head"].ToString();
                radioButton20.Text = dt.Rows[4]["option1"].ToString();
                radioButton17.Text = dt.Rows[4]["option2"].ToString();
                radioButton18.Text = dt.Rows[4]["option3"].ToString();
                radioButton19.Text = dt.Rows[4]["option4"].ToString();
               
                Q5.Text = dt.Rows[5]["ques_head"].ToString();
                radioButton24.Text = dt.Rows[5]["option1"].ToString();
                radioButton21.Text = dt.Rows[5]["option2"].ToString();
                radioButton22.Text = dt.Rows[5]["option3"].ToString();
                radioButton23.Text = dt.Rows[5]["option4"].ToString();
               
                Q6.Text = dt.Rows[6]["ques_head"].ToString();
                radioButton28.Text = dt.Rows[6]["option1"].ToString();
                radioButton25.Text = dt.Rows[6]["option2"].ToString();
                radioButton26.Text = dt.Rows[6]["option3"].ToString();
                radioButton27.Text = dt.Rows[6]["option4"].ToString();
                Q7.Text = dt.Rows[7]["ques_head"].ToString();
                radioButton32.Text = dt.Rows[7]["option1"].ToString();
                radioButton29.Text = dt.Rows[7]["option2"].ToString();
                radioButton30.Text = dt.Rows[7]["option3"].ToString();
                radioButton31.Text = dt.Rows[7]["option4"].ToString();
               
                Q8.Text = dt.Rows[7]["ques_head"].ToString();
                radioButton36.Text = dt.Rows[8]["option1"].ToString();
                radioButton33.Text = dt.Rows[8]["option2"].ToString();
                radioButton34.Text = dt.Rows[8]["option3"].ToString();
                radioButton35.Text = dt.Rows[8]["option4"].ToString();
                Q9.Text = dt.Rows[9]["ques_head"].ToString();
                radioButton40.Text = dt.Rows[9]["option1"].ToString();
                radioButton37.Text = dt.Rows[9]["option2"].ToString();
                radioButton38.Text = dt.Rows[9]["option3"].ToString();
                radioButton39.Text = dt.Rows[9]["option4"].ToString();


         //   }
            con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stsave_Click(object sender, EventArgs e)
        {
            Q += 1;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
            groupBox10.Visible = false;
            switch (Q)
            {
               
                case 2:
                    Q = 2;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox2.Visible = true;
                    break;
                case 3:
                    Q= 3;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox3.Visible = true;
                    break;
                case 4:
                   Q = 4;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox4.Visible = true;
                    break;
                case 5:
                    Q = 5;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox5.Visible = true;
                    break;
                case 6:
                    Q = 6;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox6.Visible = true;
                    break;
                case 7:
                   Q = 7;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox7.Visible = true;
                    break;
                case 8:
                    Q = 8;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox8.Visible = true;
                    break;
                case 9:
                 Q =9;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox9.Visible = true;
                    break;
                case 10:
                    Q = 10;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox10.Visible = true;
                    btnNext.Visible = false;
                    submitbtn.Visible = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Q -= 1;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
              groupBox10.Visible = false;
            switch (Q)
            {
                 case 1:
                    Q = 1;
                     btnNext.Text = Convert.ToString(Q);
                     groupBox1.Visible = true;
                     break;
                case 2:
                    Q = 2;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox2.Visible = true;
                    break;
                case 3:
                    Q = 3;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox3.Visible = true;
                    break;
                case 4:
                    Q = 4;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox4.Visible = true;
                    break;
                case 5:
                    Q = 5;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox5.Visible = true;
                    break;
                case 6:
                    Q = 6;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox6.Visible = true;
                    break;
                case 7:
                    Q = 7;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox7.Visible = true;
                    break;
                case 8:
                    Q = 8;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox8.Visible = true;
                    break;
                case 9:
                    Q = 9;
                    btnNext.Text = Convert.ToString(Q);
                    groupBox9.Visible = true;
                    submitbtn.Visible = false;
                    btnNext.Visible = true;
                    break;
                case 10:
                    Q = 10;
                    
                    groupBox10.Visible = true;
                    
                   
                    break;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True")) ;
            con.Open();
            int test =int.Parse(login.x);
            DataTable dtt = new DataTable();
            
            SqlCommand cmdd = new SqlCommand("declare @examid int set @examid = (select exam_id from Exam.Exam where kid_id = " + test + " ); select exam_id, Question_id from Exam.Questions where exam_id = @examid", con);
            cmdd.Parameters.AddWithValue("kid_id", test);
            cmdd.ExecuteNonQuery();
            SqlDataAdapter daa = new SqlDataAdapter(cmdd);
            daa.Fill(dtt);
            con.Close();
            string z = " ";
            int result = 0;
            if (radioButton1.Checked)
            {
                z = "A";
                int test2 = JustForTest(test , int.Parse(dtt.Rows[0]["exam_id"].ToString()),int.Parse( dtt.Rows[0]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton2.Checked)
            {
                z = "B";
                
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[0]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton3.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[0]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton4.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[0]["Question_id"].ToString()), z);
                result += test2;
            }


            if (radioButton5.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[1]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton6.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[1]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton7.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[1]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton8.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[1]["Question_id"].ToString()), z);
                result += test2;
            }


            if (radioButton9.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[2]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton10.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[2]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton11.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[2]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton12.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[2]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton13.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[3]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton14.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[3]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton15.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[3]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton16.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[3]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton17.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[4]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton18.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[4]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton19.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[4]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton20.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[4]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton21.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[5]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton22.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[5]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton23.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[5]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton24.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[5]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton25.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[6]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton26.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[6]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton27.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[6]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton28.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[6]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton29.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[7]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton30.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[7]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton31.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[7]["Question_id"].ToString()), z);
                result += test2;

            }
            if (radioButton32.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[7]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton33.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[8]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton34.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[8]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton35.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[8]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton36.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[8]["Question_id"].ToString()), z);
                result += test2;
            }

            if (radioButton37.Checked)
            {
                z = "A";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[9]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton38.Checked)
            {
                z = "B";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[9]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton39.Checked)
            {
                z = "C";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[9]["Question_id"].ToString()), z);
                result += test2;
            }
            if (radioButton40.Checked)
            {
                z = "D";
                int test2 = JustForTest(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()), int.Parse(dtt.Rows[9]["Question_id"].ToString()), z);
                result += test2;
            }
            correction(test, int.Parse(dtt.Rows[0]["exam_id"].ToString()));
            


        }
       
        int k = 300;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            timingbar.Value = k;
            k -= 1;
            if (timingbar.Value==0)
            {
              
                timingbar.Value = 200;
                timer1.Stop();
                MessageBox.Show("Time Over", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                resultkids log = new resultkids();
                log.Show();
                this.Close();

            }
        }

        private void timingbar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panelcenter_Paint(object sender, PaintEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select concat(kid_fname,' ',kid_lname) from Kid where kid_id =" + login.x, con);
            label3.Text = (string)cmd.ExecuteScalar();
            con.Close();
            label2.Text = login.x;
        }
    }
}
