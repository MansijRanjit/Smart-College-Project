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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        private void txtTeacherID_TextChanged(object sender, EventArgs e)
        {
            if(txtTeacherID.Text != "")
            {
                SqlConnection con = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True");

                string query = "select fname,mobile from teacher where tID = "+txtTeacherID.Text+" ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    fnameLabel.Text = ds.Tables[0].Rows[0][0].ToString();
                    mobnoLabel.Text = ds.Tables[0].Rows[0][1].ToString();
                   
                }
                else
                {
                    fnameLabel.Text = "____________________";
                    mobnoLabel.Text = "____________________";
                    
                }
            }
            else
            {
                txtTeacherID.Text = "";
                fnameLabel.Text = "____________________";
                mobnoLabel.Text = "____________________";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtTeacherID.Text.Trim() != "" && txtYear.Text.Trim() != "" && txtSalary.Text.Trim() != "" )
            {
                SqlConnection con = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True");

                string query = "select syear from Salary where syear=('" + txtYear.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if(ds.Tables[0].Rows.Count == 0 )
                {
                    SqlConnection con1 = new SqlConnection("data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True");

                    string query1 = "insert into Salary (tID,syear,salary) values (" + txtTeacherID.Text + ",'" + txtYear.Text + "'," + txtSalary.Text + ")";
                    SqlDataAdapter da1 = new SqlDataAdapter(query1, con1);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);

                    if (MessageBox.Show("Fees Submition Successful.", " Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        txtTeacherID.Text = "";
                        txtYear.Text = "";
                        txtSalary.Text = "";
                        fnameLabel.Text = "____________________";
                        mobnoLabel.Text = "____________________";

                    }
                }
                else
                {
                    MessageBox.Show("Entered Year Salary Already Paid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            else
            {
                MessageBox.Show("Please Check All The Informations and Submit.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void txtTeacherID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
