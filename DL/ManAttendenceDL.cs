using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.DL
{
    public class ManAttendenceDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public ManAttendenceDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void InsertManAttendence(int ManId, string ManName, string Attendence)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO ManAtt (ManId, ManName, Attendence, [Created-On], [Editted-On]) VALUES (@ManId, @ManName, @Attendence, GETDATE(), GETDATE())", con))
                {
                    cmd.Parameters.AddWithValue("@ManId", ManId);
                    cmd.Parameters.AddWithValue("@ManName", ManName);
                    cmd.Parameters.AddWithValue("@Attendence", Attendence);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
