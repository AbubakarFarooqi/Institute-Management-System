using Institution_System.BL;
using Institution_System.DL;
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

namespace Institution_System
{
    public partial class TeacherAtten : Form
    {
        private TeaAttendenceBL businessLogic;
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        string error;
        public TeacherAtten()
        {
            InitializeComponent();
            TeaAttendenceDL dataAccess = new TeaAttendenceDL(connectionString);
            businessLogic = new TeaAttendenceBL(dataAccess);
        }

        private void TeacherAtten_Load(object sender, EventArgs e)
        {
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT ID , Name FROM Teacher", con1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string attendence = "Present";
            string attendence1 = "Absent";
            try
            {

                if (e.ColumnIndex == dataGridView1.Columns["Present"].Index)
                {
                    businessLogic.SaveTeaAttendence(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),  attendence);
                    MessageBox.Show("Successfully saved");


                }
                else if (e.ColumnIndex == dataGridView1.Columns["Absent"].Index)
                {
                    businessLogic.SaveTeaAttendence(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), attendence1);
                    MessageBox.Show("Successfully saved");


                }
            }
            catch (Exception ex)
            {
                //Hnadle exception
                error = "Error updating in database:" + ex.Message;
                using (SqlConnection con1 = new SqlConnection(connectionString))
                {
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("Insert into Logs(Exception , functionName , CreatedTime) values(@exception , @functionName , GETDATE())", con1);
                    cmd1.Parameters.AddWithValue("@functionName", "InsertTeacherAttendence");
                    cmd1.Parameters.AddWithValue("@exception", error);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show(error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
