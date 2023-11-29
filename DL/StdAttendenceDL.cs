using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institution_System.DL
{
    public class StdAttendenceDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public StdAttendenceDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void InsertStdAttendence(int StdId , string StdName , int RegNo , string attendence)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO StdAtt (StdId, StdName, Attendence, [Created-On], [Editted-On], RegNo) VALUES (@StdId, @StdName, @Attendence, GETDATE(), GETDATE(), @RegNo)", con))
                {
                    cmd.Parameters.AddWithValue("@StdId", StdId);
                    cmd.Parameters.AddWithValue("@StdName", StdName); // Correct parameter name
                    cmd.Parameters.AddWithValue("@RegNo", RegNo);
                    cmd.Parameters.AddWithValue("@Attendence", attendence);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
