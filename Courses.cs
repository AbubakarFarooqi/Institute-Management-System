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
        public Courses()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetError(textBox2) == "" && errorProvider1.GetError(textBox3) == "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Course (Name , CreditHrs , Status , [Created-On] , [Editted-On] , Semester , Department) values (@Name, @CreditHrs , @Status ,  GETDATE() , GETDATE() , @Semester , @Department)", con);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CreditHrs", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Semester", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Department", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Status", 1);
             
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
    }
}
