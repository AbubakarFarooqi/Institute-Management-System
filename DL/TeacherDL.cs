using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institution_System.DL
{
    public class TeacherDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";
        string error;
        public TeacherDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void InsertTeacher(string name, string gender, string address, string email, int accountNo, string phone, int salary)
        {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Teacher (Name, Gender, Address, Email, AccountNo, Phone, Salary, Status, Created, Editted) " +
                        "VALUES (@Name, @Gender, @Address, @Email, @AccountNo, @Phone, @Salary, @Status, GETDATE(), GETDATE())", con);

                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@AccountNo", accountNo);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.ExecuteNonQuery();
                }
            
            

           
            
        }
    }
}
