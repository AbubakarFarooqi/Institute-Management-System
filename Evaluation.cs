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
        public Evaluation()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                if (errorProvider1.GetError(textBox3) == "" && errorProvider1.GetError(textBox4) == "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert into Evaluation ( Department , TotalWg , Subject , Semster ,   Status  , [Created-On] , [Editted-On]) values ( @Department , @TotalWg , @Subject , @Semster ,  @Status ,  GETDATE() , GETDATE())", con);
                    cmd.Parameters.AddWithValue("@Department", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@TotalWg", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Subject", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Semster", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Status", 1);
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
    }
}
