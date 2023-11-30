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
    public partial class EditStu : Form
    {
        private int RegNO;
        private string name;
        private string Gender;
        private string Address;
        private string Email;
        private string Phone;
        private string Status;
        private int ID;
        
        public EditStu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
               
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Update Student Set     Name = @Name ,  Gender = @Gender , Address = @Address , RegNo = @RegNo , Phone = @Phone , Status = @Status , Email = @Email , [Editted-On] = GETDATE() where @ID = Id", con);
                    cmd.Parameters.AddWithValue("@Id", int.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Gender", textBox3.Text);
                    cmd.Parameters.AddWithValue("@RegNo", textBox7.Text);
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@Status", textBox8.Text);
                cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Update");
                    this.Hide();
                    EditStudent a = new EditStudent();
                    a.Show();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Enter complete data or your data is not in correct format");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditStu_Load(object sender, EventArgs e)
        {
            textBox1.Text = name;
            textBox3.Text = Gender;
            textBox7.Text = RegNO.ToString();
            textBox6.Text = Address;
            textBox5.Text = Email;
            textBox4.Text = Phone;
            textBox2.Text = ID.ToString();
            textBox8.Text = Status;
           
        }
        public EditStu(  int ID , string name , string Gender , string Address , int RegNo ,string Phone, string Status,string Email)
        {
            this.Phone = Phone;
           this.name = name;
            this.Gender= Gender;
            this.Address = Address;
            this.Email= Email;
            this.Phone = Phone;
            this.ID= ID;
            this.RegNO= RegNo;
            this.Status= Status;

            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
