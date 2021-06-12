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
    public partial class Student_Fees : Form
    {
        public Student_Fees()
        {
            InitializeComponent();
        }

        private void txtRegNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtRegNumber.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select fname,gname,semester from NewStudent where (NSID = " + txtRegNumber.Text + ")";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


                if (DS.Tables[0].Rows.Count != 0)
                {
                    fnameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    gnameLabel.Text = DS.Tables[0].Rows[0][1].ToString();
                    semesterLabel.Text = DS.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    fnameLabel.Text = "____________________";
                    gnameLabel.Text = "____________________";
                    semesterLabel.Text = "____________________";
                }
            }
            else
            {
                txtRegNumber.Text = "";
                fnameLabel.Text = "____________________";
                gnameLabel.Text = "____________________";
                semesterLabel.Text = "____________________";

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from StudentFees where (NSID = " + txtRegNumber.Text + ")";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            if(DS.Tables[0].Rows.Count == 0)
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security = True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;

                cmd1.CommandText = "insert into StudentFees (NSID,fees,sem) values (" + txtRegNumber.Text + "," + txtFees.Text + ",'"+semesterLabel.Text+"')";

                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);

                if (MessageBox.Show("Fees Submition Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtRegNumber.Text = "";
                    txtFees.Text = "";
                    fnameLabel.Text = "____________________";
                    gnameLabel.Text = "____________________";
                    semesterLabel.Text = "____________________";
                }
            }
            else
            {
                MessageBox.Show("Fees is Already Submitted.");
                txtRegNumber.Text = "";
                txtFees.Text = "";
                fnameLabel.Text = "____________________";
                gnameLabel.Text = "____________________";
                semesterLabel.Text = "____________________";
            }
        }
    }
};
