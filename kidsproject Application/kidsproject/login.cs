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


    public partial class login : Form
    {
        public static string x;

        public login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=KidsCodingSchool;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit(); }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            passpt.BackColor = Color.White;
            //   panel4.BackColor = Color.White;
            panel2.BackColor = Color.FromArgb(255, 241, 191);
            username.BackColor = Color.IndianRed;
            aspt.BackColor = Color.FromArgb(255, 241, 191);
            panel5.BackColor = Color.FromArgb(255, 241, 191);
        }

        private void stfirsttb_TextChanged(object sender, EventArgs e)
        {
            //   username.BackColor = Color.;
            //   panel2.BackColor = Color.FromArgb(255, 241, 191);
            panel4.BackColor = Color.FromArgb(255, 241, 191);
            passpt.BackColor = Color.FromArgb(255, 241, 191);
            panel5.BackColor = Color.FromArgb(255, 241, 191);
            aspt.BackColor = Color.FromArgb(255, 241, 191);

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {


        }

        private void aspt_SelectedIndexChanged(object sender, EventArgs e)
        {
            aspt.BackColor = Color.IndianRed;
            passpt.BackColor = Color.IndianRed;
            /* panel4.BackColor = Color.IndianRed;
           panel2.BackColor = Color.IndianRed;*/
            username.BackColor = Color.IndianRed;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            passpt.UseSystemPasswordChar = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void loginbt_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            username.Text = "";
            passpt.Text = "";
            aspt.SelectedIndex = -1;
            aspt.Text = "Select Login";
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            x = username.Text;

            //login kid
            if (aspt.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (aspt.SelectedIndex == 0)
            {
                if (username.Text == "" || passpt.Text == "")
                {
                    MessageBox.Show("ENter User name And Password!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                   
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from login.Login_Kid where kid_id='" + username.Text + "' and kid_password='" + passpt.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                       homekids obj = new homekids();
                        obj.Show();
                        this.Hide();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Kid Name Or Password", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        username.Text = "";
                        passpt.Text = "";
                    }
                    con.Close();
                }
            }
            else if (aspt.SelectedIndex == 1)
            {
                if (username.Text == "" || passpt.Text == "")
                {
                    MessageBox.Show("ENter User name And Password!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from login.Login_ins where ins_email='" + username.Text + "' and ins_password='" + passpt.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                       Form1 obj = new Form1();
                        obj.Show();
                        this.Hide();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Instructor Name Or Password", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        username.Text = "";
                        passpt.Text = "";
                    }
                    con.Close();
                } 
                //admin login
            } else
            {
                if (username.Text == "" || passpt.Text == "")
                {
                    MessageBox.Show("ENter User name And Password!", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();

                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from login.Login_Admin where admin_mail='" + username.Text + "' and admin_password='" + passpt.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Admin.adminhome obj = new Admin.adminhome();
                        obj.Show();
                        this.Hide();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Instructor Name Or Password", "result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        username.Text = "";
                        passpt.Text = "";
                    }
                    con.Close();
                }
            }
            
            
            
        }

            

        

            private void login_Load(object sender, EventArgs e)
            {
                // TODO: This line of code loads data into the 'logindataset.login' table. You can move, or remove it, as needed.
                this.loginTableAdapter.Fill(this.logindataset.login);
                x = username.Text;

            }

            private void pictureBox3_Mouseup(object sender, MouseEventArgs e)
            {
                passpt.UseSystemPasswordChar = true;
            }
        }



    }     

