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

namespace Institution_System
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetError(textBox5) == "" && errorProvider1.GetError(textBox7) == "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Teacher (Name , Gender , Address , Email , AccountNo , Phone ,Salary ,  Status  , Created , Editted) values (@Name, @Gender , @Address , @Email , @AccountNo , @Phone ,@Salary ,  @Status ,  GETDATE() , GETDATE())", con);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Salary", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                    //cmd.Parameters.AddWithValue("@Editted-On", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                }
                else
                {
                    MessageBox.Show("Please enter valid data");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

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
    }
}
