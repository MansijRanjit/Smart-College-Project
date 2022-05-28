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
    public partial class IndividualTeacher : Form
    {
        public IndividualTeacher()
        {
            InitializeComponent();
        }

        private void textBoxRegistraionID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRegistrationID.Text.Trim() != "" && (textBoxRegistrationID.Text.Any(char.IsNumber)))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from teacher where tID = " + textBoxRegistrationID.Text + "";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtFName.Text = ds.Tables[0].Rows[0][1].ToString();
                    textBoxGender.Text = ds.Tables[0].Rows[0][2].ToString();
                    dateTimePickerDOB.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtSubject.Text= ds.Tables[0].Rows[0][6].ToString();
                    txtExperience.Text= ds.Tables[0].Rows[0][7].ToString();
                    txtUniversity.Text= ds.Tables[0].Rows[0][8].ToString();
                    txtAddress.Text= ds.Tables[0].Rows[0][9].ToString();

                }
                
            }
            else
            {
                txtFName.Clear();
                txtAddress.Clear();
                textBoxGender.Clear();
                txtMobile.Clear();
                txtEmail.Clear();
                txtSubject.Clear();
                txtExperience.Clear();
                txtUniversity.Clear();
                textBoxRegistrationID.Clear();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtFName.Text.Trim() != "" && textBoxGender.Text.Trim() != "" && txtMobile.Text.Trim() != "" && txtEmail.Text.Trim() != "" && txtSubject.Text.Trim() != "" && txtExperience.Text.Trim() != "" && txtUniversity.Text.Trim() != "" && txtAddress.Text.Trim() != "")
            {
             
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update teacher set fname ='" + txtFName.Text + "' , gender = '" + textBoxGender.Text + "', dob = '" + dateTimePickerDOB.Text + "' , mobile= '" + txtMobile.Text + "' , email = '" + txtEmail.Text + "' , sub = '" + txtSubject.Text + "' , experience = '" + txtExperience.Text + "' , uni = '" + txtUniversity.Text + "' ,adr = '" + txtAddress.Text + "' where tID ='" + textBoxRegistrationID.Text + "'  ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (MessageBox.Show("Data Modified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    txtFName.Clear();
                    txtAddress.Clear();
                    textBoxGender.Clear();
                    txtMobile.Clear();
                    txtEmail.Clear();
                    txtSubject.Clear();
                    txtExperience.Clear();
                    txtUniversity.Clear();
                    textBoxRegistrationID.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Information and Submit ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
