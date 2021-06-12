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
    public partial class SalaryDetails : Form
    {
        public SalaryDetails()
        {
            InitializeComponent();
        }

        private void SalaryDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True");

            string query = "select  teacher.tID as TeacherID, teacher.fname as FullName, teacher.mobile as MobileNumber, teacher.dob as DateOfBirth, Salary.syear as SalaryYear, Salary.salary as Salary from teacher,Salary where  teacher.tID = Salary.tID ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True");

            string query = "select  teacher.tID as TeacherID, teacher.fname as FullName, teacher.mobile as MobileNumber,teacher.dob as DateOfBirth, Salary.syear as SalaryYear, Salary.salary as Salary from teacher,Salary where  teacher.tID = Salary.tID and (Salary.tID= " + textBoxTeacherID.Text+") ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
