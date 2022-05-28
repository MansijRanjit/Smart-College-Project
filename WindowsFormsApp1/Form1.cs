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
            panel2.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database=college; integrated security=True");

            con.Open();

            string sql = "select * from admin where username = '" + textBox1.Text + "' and password= '" + textBox2.Text + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                menuStrip1.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();

            }

            con.Close();
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

        private void feeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary sy = new Salary();
            sy.Show();
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryDetails sad = new SalaryDetails();
            sad.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void btnExitRegister_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBoxUsername.Text.Trim() != "" && txtBoxPass.Text.Trim() != "" && txtBoxLiscence.Text.Trim() == "admin" && txtBoxUsername.Text.Length >= 4 && txtBoxPass.Text.Length >= 4)
            {
                SqlConnection con = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database=college; integrated security=True");

                con.Open();

                string sql = "Insert into admin(username,password) values ('" + txtBoxUsername.Text + "','" + txtBoxPass.Text + "')";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                con.Close();

                MessageBox.Show("Register Successful");

                panel1.Visible = true;
                panel2.Visible = false;


            }
            else
            {
                MessageBox.Show("Please Check All The Information and Submit ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void feeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeesDetails fd = new FeesDetails();
            fd.Show();
        }

        private void txtBoxUsername_Validating(object sender, CancelEventArgs e)
        {
            if ((txtBoxUsername.TextLength >= 4) )
            {
                errorProviderUsername.SetError(txtBoxUsername, "");

            }
            else
            {
                errorProviderUsername.SetError(txtBoxUsername, "Please Enter Username Greater than or equal to 4 characters");
            }
        }

        private void txtBoxPass_Validating(object sender, CancelEventArgs e)
        {
            if ((txtBoxPass.TextLength >= 4))
            {
                errorProviderPassword.SetError(txtBoxPass, "");

            }
            else
            {
                errorProviderPassword.SetError(txtBoxPass, "Please Enter Stronger Password ");
            }
        }

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
