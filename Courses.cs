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
    public partial class Courses : Form
    {
        private CoursesBL businessLogic;
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        string error;
        public Courses()
        {
            InitializeComponent();
            CoursesDL dataAccess = new CoursesDL(connectionString);
            businessLogic = new CoursesBL(dataAccess);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetError(textBox2) == "" && errorProvider1.GetError(textBox3) == "")
                {
                    businessLogic.SaveCourses(textBox2.Text, int.Parse(textBox3.Text), int.Parse(comboBox2.Text), comboBox1.Text);
                    MessageBox.Show("Successfully saved");
                   
                }
                else
                {
                    MessageBox.Show("Please enter valid data");
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
                    cmd1.Parameters.AddWithValue("@functionName", "InsertCourses");
                    cmd1.Parameters.AddWithValue("@exception", error);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show(error);
                }
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox2.Text) || System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^![a-zA-Z ]"))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "Invalid");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");

            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox3.Text) || System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^![a-zA-Z ]"))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, "Invalid");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, "");

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Courses_Load(object sender, EventArgs e)
        {

        }
    }
}
