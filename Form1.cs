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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const string ConnectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
           Signup b = new Signup();
            b.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            string email = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }
            string query = "SELECT  Role FROM SignUp WHERE Email=@Email AND Password=@Password";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            MessageBox.Show($"Login successful! Welcome, {role}.");
                            if (role == "Admin")
                            {
                                this.Hide();
                                Dashboard b = new Dashboard();
                                b.ShowDialog();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password. Please try again.");
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
                }
    }
}
