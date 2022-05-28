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
    public partial class RemoveStudent : Form
    {
        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RemoveStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select NewStudent.NSID as Student_ID, NewStudent.fname as Full_Name, NewStudent.gname as Guardians_Name, NewStudent.gender as Gender, NewStudent.dob as Date_Of_Birth, NewStudent.mobile as Mobile, NewStudent.email as Email_ID, NewStudent.semester as Semester, NewStudent.prog as Program, NewStudent.sname as School_Name, NewStudent.batch as Batch, NewStudent.addres as Address from NewStudent";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            dataGridViewRemStudent.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRegID.Text.Trim() != "" && (txtRegID.Text.Any(char.IsNumber)))
            {
                if (MessageBox.Show("This will delete data permanently.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "delete from NewStudent where NSID = " + txtRegID.Text + "";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    MessageBox.Show("Delete Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Enter Valid Registration Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
