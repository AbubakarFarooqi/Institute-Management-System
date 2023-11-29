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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (errorProvider1.GetError(textBox3) == "" && errorProvider1.GetError(textBox5) == "" && errorProvider1.GetError(textBox4) == "")
                {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into SignUp values ( @Name, @Phone, @Password ,@Email, @ID)", con);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox4.Text);
                cmd.Parameters.AddWithValue("@ID", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
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
        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_Validated(object sender, EventArgs e)
        {

        }

        private void textBox3_Validating_1(object sender, CancelEventArgs e)
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
            if (!IsValid(textBox3.Text))
            {
                MessageBox.Show("Enter the Valid Email!!!!!!");
            }
        }
        private bool IsValidPassword(string password)
        {
            // Check if the password is at least 8 characters long and contains at least one letter
            return password.Length >= 8 && password.Any(char.IsLetter);
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string password = textBox4.Text;
            if (!IsValidPassword(password))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox4, "Invalid password! Password must be at least 8 characters long and contain at least one letter.");
                MessageBox.Show("Invalid password! Password must be at least 8 characters long and contain at least one letter.");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            string userId = textBox5.Text;

            if (string.IsNullOrEmpty(userId))
            {
                // ID is required, display an error message
                errorProvider1.SetError(textBox5, "ID is required");
                e.Cancel = true;
            }
            else
            {
                // ID is not empty, perform the existence check
                if (CheckIdExistsInTable("Student", userId) ||
                    CheckIdExistsInTable("Teacher", userId) ||
                    CheckIdExistsInTable("Management", userId))
                {
                    // ID exists, clear error message
                    errorProvider1.SetError(textBox5, "");
                }
                else
                {
                    // ID does not exist, display an error message
                    errorProvider1.SetError(textBox5, "ID does not exist in data");
                    MessageBox.Show("ID does not exist in data");
                    e.Cancel = true;
                }
            }
        }
        private const string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        private bool CheckIdExistsInTable(string tableName, string userId)
        {
          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", userId);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 b = new Form1();
            b.ShowDialog();
        }
    } 
}
