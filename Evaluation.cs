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
    public partial class Evaluation : Form
    {
        private EvaluationBL businessLogic;
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        string error;
        public Evaluation()
        {
            InitializeComponent();
            EvaluationDL dataAccess = new EvaluationDL(connectionString);
            businessLogic = new EvaluationBL(dataAccess);

        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                if (errorProvider1.GetError(textBox3) == "" && errorProvider1.GetError(textBox4) == "")
                {
                    businessLogic.SaveEvaluation(comboBox1.Text, int.Parse(textBox3.Text), textBox4.Text,int.Parse( comboBox2.Text));
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
                    cmd1.Parameters.AddWithValue("@functionName", "InsertEvaluation");
                    cmd1.Parameters.AddWithValue("@exception", error);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show(error);
                }
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

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^![a-zA-Z ]"))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "Invalid");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, "");

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
