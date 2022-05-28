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
    public partial class TeacherDetails : Form
    {
        public TeacherDetails()
        {
            InitializeComponent();
        }

        private void TeacherDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select tID as Teacher_Id,fname as Full_Name,gender as Gender,dob as Date_Of_Birth,mobile as Mobile_Number,email as Email,sub as Teaching_Subject,experience as Experience,uni as Graduated_University,adr as Address from teacher";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

         

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (textBoxTeacherName.Text.Trim() == "")
            {
                if (textBox1.Text.Trim() != "" && (textBox1.Text.Any(char.IsNumber)))
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select tID as Teacher_Id,fname as Full_Name,gender as Gender,dob as Date_Of_Birth,mobile as Mobile_Number,email as Email,sub as Teaching_Subject,experience as Experience,uni as Graduated_University,adr as Address from teacher where tID = " + textBox1.Text + "";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Registration Number data not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Registration Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (textBox1.Text.Trim() != "" && (textBox1.Text.Any(char.IsNumber)))
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select tID as Teacher_Id,fname as Full_Name,gender as Gender,dob as Date_Of_Birth,mobile as Mobile_Number,email as Email,sub as Teaching_Subject,experience as Experience,uni as Graduated_University,adr as Address from teacher where tID = " + textBox1.Text + " and fname = '" + textBoxTeacherName.Text + "' ";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Registration Number data not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Registration Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

         


        }

        private void textBoxTeacherName_TextChanged(object sender, EventArgs e)
        {

            if(textBoxTeacherName.Text.Trim() != "")
            {
                SqlConnection con2 = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True");

                string query = "select tID as Teacher_Id,fname as Full_Name,gender as Gender,dob as Date_Of_Birth,mobile as Mobile_Number,email as Email,sub as Teaching_Subject,experience as Experience,uni as Graduated_University,adr as Address from teacher where fname like '%" + textBoxTeacherName.Text + "%' ";
                SqlDataAdapter da2 = new SqlDataAdapter(query, con2);

                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];

                if (ds2.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = ds2.Tables[0];
                }
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select tID as Teacher_Id,fname as Full_Name,gender as Gender,dob as Date_Of_Birth,mobile as Mobile_Number,email as Email,sub as Teaching_Subject,experience as Experience,uni as Graduated_University,adr as Address from teacher";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IndividualTeacher idt = new IndividualTeacher();
            idt.Show();
        }
    }
}
