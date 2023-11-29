using Institution_System.BL;
using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Institution_System
{
    public partial class Management : Form
    {
        private ManagementBL businessLogic;
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        string error;
        public Management()
        {
            InitializeComponent();
      
           ManagementDL dataAccess = new ManagementDL(connectionString);
            businessLogic = new ManagementBL(dataAccess);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetError(textBox5) == "" && errorProvider1.GetError(textBox7) == "")
                {
                    businessLogic.SaveManagement(textBox2.Text, textBox3.Text, textBox6.Text, textBox4.Text,textBox5.Text, int.Parse(textBox7.Text));
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
                    cmd1.Parameters.AddWithValue("@functionName", "InsertManagement");
                    cmd1.Parameters.AddWithValue("@exception", error);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show(error);
                }
            }
        }
        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text) || System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^![a-zA-Z ]"))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider1.SetError(textBox5, "Invalid");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox5, "");

            }
            if (!IsValid(textBox5.Text))
            {
                MessageBox.Show("Enter the Valid Email!!!!!!");
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text) || System.Text.RegularExpressions.Regex.IsMatch(textBox7.Text, "^![a-zA-Z ]"))
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider1.SetError(textBox7, "Invalid");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox7, "");

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
