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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           try
            {
                if ( errorProvider1.GetError(textBox5) == "" && errorProvider1.GetError(textBox7) == "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Student (Name , Gender , Address , grade ,Phone ,  Status , Email , [Created-On] , [Editted-On]) values (@Name, @Gender , @Address , @grade , @Phone , @Status , @Email , GETDATE() , GETDATE())", con);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                    cmd.Parameters.AddWithValue("@grade", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditStu b = new EditStu();
            b.ShowDialog();
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
