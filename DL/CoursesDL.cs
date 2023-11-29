using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.DL
{
    public class CoursesDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public CoursesDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void InsertCourses(string name, int CreditHrs, int semester, string Department)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("Insert into Course (Name , CreditHrs , Status , [Created-On] , [Editted-On] , Semester , Department) values (@Name, @CreditHrs , @Status ,  GETDATE() , GETDATE() , @Semester , @Department)", con))
                {

                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@CreditHrs", CreditHrs);
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@Semester", semester);
                    cmd.Parameters.AddWithValue("@Department", Department);
         
                    //cmd.Parameters.AddWithValue("@Editted-On", DateTime.Now);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
