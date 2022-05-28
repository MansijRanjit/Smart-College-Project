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
    public partial class FeesDetails : Form
    {
        public FeesDetails()
        {
            InitializeComponent();
        }

        private void FeesDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select StudentFees.fid as FeeID,NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, StudentFees.sem as Semester,StudentFees.fees as Fees, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent, StudentFees where NewStudent.NSID=StudentFees.NSID ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim()!="" && (textBox1.Text.Any(char.IsNumber)))
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select sf.fid as FeeID, ns.NSID as Student_ID, ns.fname as Full_Name, ns.gender as Gender, ns.dob as Date_Of_Birth, ns.mobile as Mobile, ns.email as Email_ID, sf.sem as Semester, ns.prog as Program, ns.batch as Batch, ns.addres as Address,sf.fees as Fees from StudentFees sf, NewStudent ns" + " where sf.NSID = " + textBox1.Text + "" + " and ns.NSID=sf.NSID ";
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
}
