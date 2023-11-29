using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.DL
{
    public class MisslaneousDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public MisslaneousDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void InsertMisslaneous(int electricity , int gas , int water , int ManId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Mischallanoues_Expenses (Electricity , Gas , Water , ManId , [Created-On], [Editted-On]) " +
                                                       "VALUES (@Electricity, @Gas, @Water, @ManId , GETDATE(), GETDATE())", con))
                {
                    cmd.Parameters.AddWithValue("@Electricity", electricity);
                    cmd.Parameters.AddWithValue("@Gas", gas);
                    cmd.Parameters.AddWithValue("@Water", water);
                    cmd.Parameters.AddWithValue("@ManId", ManId);
                  

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
