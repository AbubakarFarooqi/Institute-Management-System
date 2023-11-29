using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Institution_System.BL;

namespace Institution_System.DL
{
    public class StudentDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public StudentDL(string connectionString) 
        {
            this.connectionString = connectionString;
        }
        public void InsertStudent(string name, string gender, string address, int grade, string phone, string email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Student (Name, Gender, Address, RegNo, Phone, Status, Email, [Created-On], [Editted-On]) " +
                                                       "VALUES (@Name, @Gender, @Address, @grade, @Phone, @Status, @Email, GETDATE(), GETDATE())", con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@grade", grade);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
    
}
