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
    public partial class RemoveTeacher : Form
    {
        public RemoveTeacher()
        {
            InitializeComponent();
        }

        private void RemoveTeacher_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select tID as Teacher_Id,fname as Full_Name,gender as Gender,dob as Date_Of_Birth,mobile as Mobile_Number,email as Email,sub as Teaching_Subject,experience as Experience,uni as Graduated_University,adr as Address from teacher";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && (textBox1.Text.Any(char.IsNumber)))
            {
                if (MessageBox.Show("This will delete data permanently.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = MANSIJ\\SQLEXPRESS; database = college; integrated security =True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "delete from teacher where tID = " + textBox1.Text + "";


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
