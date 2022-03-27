using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kidsproject.Admin
{
    public partial class adminhome : Form
    {
        public adminhome()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Admin.adminkids obj = new Admin.adminkids();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Instractors obj = new Instractors();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin.admincourses obj = new Admin.admincourses();
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

        private void panelcenter_Paint(object sender, PaintEventArgs e)
        {
            label8.Text = login.x;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
