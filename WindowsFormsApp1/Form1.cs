using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String Username = textBox1.Text;
            String Password = textBox2.Text;

            if(Username == "eec" && Password == "eec")
            {
                menuStrip1.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Student ns = new New_Student();
            ns.Show();
        }

        private void studentFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Fees sfs = new Student_Fees();
            sfs.Show();
        }

        private void upgradeSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpgradeSemester us = new UpgradeSemester();
            us.Show();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StudentDetails sd = new StudentDetails();
            sd.Show();
        }

        private void newTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTeacher nt = new NewTeacher();
            nt.Show();
        }

        private void teacherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TeacherDetails td = new TeacherDetails();
            td.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveStudent rs = new RemoveStudent();
            rs.Show();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveTeacher rt = new RemoveTeacher();
            rt.Show();
        }
    }
}
