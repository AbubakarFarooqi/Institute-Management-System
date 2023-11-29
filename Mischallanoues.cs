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
    public partial class Mischallanoues : Form
    {
        private MisslaneousBL businessLogic;
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        string error;
        public Mischallanoues()
        {
            InitializeComponent();
            MisslaneousDL dataAccess = new MisslaneousDL(connectionString);
            businessLogic = new MisslaneousBL(dataAccess);
        }

        private void Mischallanoues_Load(object sender, EventArgs e)
        {
            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Mischallanoues_Expenses", con1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetError(textBox4) == "")
                {
                    businessLogic.SaveMisslaneous(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
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
                    cmd1.Parameters.AddWithValue("@functionName", "InsertMischallaneous");
                    cmd1.Parameters.AddWithValue("@exception", error);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show(error);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
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
