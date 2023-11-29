using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.DL
{
    public class TeaAttendenceDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public TeaAttendenceDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void InsertTeaAttendence(int TecId, string TecName, string Attendence)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO TecAtt (TecId, TecName, Attendence, [Created-On], [Editted-On]) VALUES (@TecId, @TecName, @Attendence, GETDATE(), GETDATE())", con))
                {
                    cmd.Parameters.AddWithValue("@TecId", TecId);
                    cmd.Parameters.AddWithValue("@TecName", TecName); 
                    cmd.Parameters.AddWithValue("@Attendence", Attendence);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
