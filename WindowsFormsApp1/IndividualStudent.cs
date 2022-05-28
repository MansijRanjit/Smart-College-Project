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
    public partial class IndividualStudent : Form
    {
        public IndividualStudent()
        {
            InitializeComponent();
        }

        private void textBoxRegistrationID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRegistrationID.Text.Trim() != "" && (textBoxRegistrationID.Text.Any(char.IsNumber)))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database =college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where NSID = " + textBoxRegistrationID.Text + "";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtFullName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtGuardianName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtGender.Text = ds.Tables[0].Rows[0][3].ToString();
                    dateTimePickerDOB.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][7].ToString();
                    txtProgram.Text = ds.Tables[0].Rows[0][8].ToString();
                    txtSchoolName.Text = ds.Tables[0].Rows[0][9].ToString();
                    txtBatch.Text = ds.Tables[0].Rows[0][10].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0][11].ToString();

                }

            }
            else
            {
                txtFullName.Clear();
                txtGuardianName.Clear();
                txtAddress.Clear();
                txtGender.Clear();
                txtMobile.Clear();
                txtEmail.Clear();
                txtSemester.Clear();
                txtProgram.Clear();
                txtSchoolName.Clear();
                txtBatch.Clear();
                textBoxRegistrationID.Clear();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim() != "" && txtGuardianName.Text.Trim() != "" && txtGender.Text.Trim() != "" && txtMobile.Text.Trim() != "" && txtEmail.Text.Trim() != "" && txtSemester.Text.Trim() != "" && txtProgram.Text.Trim() != "" && txtSchoolName.Text.Trim() != "" && txtBatch.Text.Trim() != "" && txtAddress.Text.Trim() != "")
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set fname ='" + txtFullName.Text + "' ,gname ='"+txtGuardianName.Text+"', gender = '" + txtGender.Text + "', dob = '" + dateTimePickerDOB.Text + "' , mobile= '" + txtMobile.Text + "' , email = '" + txtEmail.Text + "' , semester = '" + txtSemester.Text + "' , prog = '" + txtProgram.Text + "' , sname = '" + txtSchoolName.Text + "' ,batch= '"+txtBatch.Text+"' ,addres = '" + txtAddress.Text + "' where NSID ='" + textBoxRegistrationID.Text + "'  ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (MessageBox.Show("Data Modified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    txtFullName.Clear();
                    txtGuardianName.Clear();
                    txtAddress.Clear();
                    txtGender.Clear();
                    txtMobile.Clear();
                    txtEmail.Clear();
                    txtSemester.Clear();
                    txtProgram.Clear();
                    txtSchoolName.Clear();
                    txtBatch.Clear();
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
