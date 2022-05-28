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

            if (txtFName.Text.Trim() != ""  && txtMobile.Text.Trim() != "" && txtEmail.Text.Trim() != ""  && txtSubject.Text.Trim() != "" && txtExperience.Text.Trim() != "" && txtUniversity.Text.Trim() != "" && txtAddress.Text.Trim() != "")
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

                if(MessageBox.Show("Data Saved. Remember the Teacher ID.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)==DialogResult.OK)
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

                    SqlConnection con2 = new SqlConnection();
                    con2.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con2;

                    cmd2.CommandText = "select max(tID) from teacher";

                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);

                    Int64 abc = Convert.ToInt64(ds2.Tables[0].Rows[0][0]);
                    label12.Text = (abc + 1).ToString();

                }
            }
            else
            {
                MessageBox.Show("Please Fill All The Information and Submit ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void txtMobile_Validating(object sender, CancelEventArgs e)
        {
            if (((txtMobile.TextLength == 10) || (txtMobile.TextLength == 7)) && (txtMobile.Text.Any(char.IsNumber)))
            {
                errorProviderMobile.SetError(txtMobile, "");

            }
            else
            {
                txtMobile.Focus();
                errorProviderMobile.SetError(txtMobile, "Please Enter Valid Phone Number");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if ((txtEmail.Text != string.Empty) && (txtEmail.Text.Contains("@")) && (txtEmail.Text.Contains(".")))
            {
                errorProviderEmail.SetError(txtEmail, "");
            }
            else
            {
                txtEmail.Focus();
                errorProviderEmail.SetError(txtEmail, "Please enter valid Email");
            }
        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
