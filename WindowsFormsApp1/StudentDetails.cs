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
    public partial class StudentDetails : Form
    {
        public StudentDetails()
        {
            InitializeComponent();
        }

        private void StudentDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            if (textBox1.Text.Trim() != "" && (textBox1.Text.Any(char.IsNumber)))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent where NSID = " + textBox1.Text + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    textBoxStudentsName.Clear();
                    comboBoxProgram.ResetText();

                }
                else
                {
                    MessageBox.Show("Registration Number data not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
              MessageBox.Show("Enter Valid Registration Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }

        private void textBoxStudentsName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStudentsName.Text.Trim() != "" && comboBoxProgram.Text.Trim() == "---SELECT---" || comboBoxProgram.Text.Trim() =="" )
            {
                SqlConnection con2 = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True");

                string query = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent where fname like '%" + textBoxStudentsName.Text +  "%' ";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con2);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];

                if (ds2.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = ds2.Tables[0];
                }
            }
            else if(textBoxStudentsName.Text.Trim() != "" && comboBoxProgram.Text.Trim() != "---SELECT---" || comboBoxProgram.Text.Trim() != "")
            {

                SqlConnection con2 = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True");

                string query = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent where prog = '" + comboBoxProgram.Text + "' and fname like '%" + textBoxStudentsName.Text + "%' ";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con2);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];

            }
            if(textBoxStudentsName.Text.Trim() == "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void comboBoxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProgram.Text.Trim() != "" && comboBoxProgram.Text.Trim() != "---SELECT---" && textBoxStudentsName.Text.Trim() == "")
            {
                SqlConnection con2 = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True");

                string query = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent where prog = '" + comboBoxProgram.Text + "' ";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con2);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];

                if (ds2.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = ds2.Tables[0];
                }
            }
            else if(comboBoxProgram.Text.Trim() != "" && comboBoxProgram.Text.Trim() != "---SELECT---" && textBoxStudentsName.Text != "")
            {
                SqlConnection con2 = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True");

                string query = "select * from NewStudent where prog = '" + comboBoxProgram.Text + "' and fname like '%" + textBoxStudentsName.Text + "%'";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con2);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];
            }
            if(comboBoxProgram.Text == "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void comboBoxProgram_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxProgram.DroppedDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IndividualStudent ids = new IndividualStudent();
            ids.Show();
        }
    }
}
