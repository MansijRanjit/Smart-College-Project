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
    public partial class NewTeacher : Form
    {
        public NewTeacher()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String gender = "";
            bool isChecked = radioMale.Checked;

            if (isChecked)
            {
                gender = radioMale.Text;
            }
            else
            {
                gender = radioFemale.Text;
            }


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into teacher (fname,gender,dob,mobile,email,sub,experience,uni,adr) values ('" + txtFName.Text + "','" + gender + "','" + dateTimePickerDOB.Text + "'," + txtMobile.Text + ",'" + txtEmail.Text + "','" + txtSubject.Text + "','" + txtExperience.Text + "','" + txtUniversity.Text + "','" + txtAddress.Text + "')";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Data Saved. Remember the Teacher ID.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFName.Clear();
            txtAddress.Clear();
            radioFemale.Checked = false;
            radioMale.Checked = false;
            txtMobile.Clear();
            txtEmail.Clear();
            txtSubject.Clear();
            txtExperience.Clear();
            txtUniversity.Clear();

        }

        private void NewTeacher_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select max(tID) from teacher";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Int64 abc = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
            label12.Text = (abc + 1).ToString();
        }
    }
}
