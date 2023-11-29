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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Institution_System
{
    public partial class Attendence : Form
    {
        private StdAttendenceBL businessLogic;
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        string error;
        public Attendence()
        {
            InitializeComponent();
            StdAttendenceDL dataAccess = new StdAttendenceDL(connectionString);
            businessLogic = new StdAttendenceBL(dataAccess);
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT ID , Name , RegNo FROM Student", con1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string attendence = "Present";
            string attendence1 = "Absent";
            try
            {

                if (e.ColumnIndex == dataGridView1.Columns["Present"].Index)
                {
                    businessLogic.SaveStdAttendence(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) , attendence);
                    MessageBox.Show("Successfully saved");


                }
                else if (e.ColumnIndex == dataGridView1.Columns["Absent"].Index)
                {
                    businessLogic.SaveStdAttendence(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()), dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()), attendence1);
                    MessageBox.Show("Successfully saved");


                }
            }
            catch(Exception ex)
            {
                //Hnadle exception
                error = "Error updating in database:" + ex.Message;
                using (SqlConnection con1 = new SqlConnection(connectionString))
                {
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("Insert into Logs(Exception , functionName , CreatedTime) values(@exception , @functionName , GETDATE())", con1);
                    cmd1.Parameters.AddWithValue("@functionName", "InsertStudentAttendence");
                    cmd1.Parameters.AddWithValue("@exception", error);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show(error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // if (e.ColumnIndex == dataGridView1.Columns["Present"].Index)
           if(dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO StdAtt (StdId, StdName, Attendence, [Created-On], [Editted-On], RegNo) VALUES (@StdId, @StdName, @Attendence, GETDATE(), GETDATE(), @RegNo)", con);
                cmd.Parameters.AddWithValue("@StdId",int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                cmd.Parameters.AddWithValue("@StdName", dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()); // Correct parameter name
                cmd.Parameters.AddWithValue("@RegNo",  int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));
                cmd.Parameters.AddWithValue("@Attendence", "Present");
                cmd.ExecuteNonQuery();
            }
        }
    }
}
