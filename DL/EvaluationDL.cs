using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.DL
{
    public class EvaluationDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public EvaluationDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void InsertEvaluation(string department, int TotalWg, string Subject , int semster)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("Insert into Evaluation (Department , TotalWg , Subject , Semster ,   Status  , [Created-On] , [Editted-On]) values (@Department, @TotalWg , @Subject , @Semster ,   @Status ,  GETDATE() , GETDATE() )", con))
                {

                    cmd.Parameters.AddWithValue("@Department", department);
                    cmd.Parameters.AddWithValue("@TotalWg", TotalWg);
                    cmd.Parameters.AddWithValue("@Subject", Subject);
                    cmd.Parameters.AddWithValue("@Semster", semster);
                    cmd.Parameters.AddWithValue("@Status", 1);
                    //cmd.Parameters.AddWithValue("@Editted-On", DateTime.Now);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
