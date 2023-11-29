using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institution_System.DL
{
    public class ManagementDL
    {
        private string connectionString = @"Data Source=(local);Initial Catalog=Institution;Integrated Security=True";

        public ManagementDL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Insertmanagement(string name, string gender, string address, string phone, string email , int AccountNo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("Insert into Management (Name , Gender , Address , Email ,  Phone ,  Status  , [Created-On] , [Editted-On] , AccountNo) values (@Name, @Gender , @Address , @Email ,  @Phone ,  @Status ,  GETDATE() , GETDATE() , @AccountNo)", con))
                {
                 
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@AccountNo", AccountNo);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@Email", email);
                    //cmd.Parameters.AddWithValue("@Editted-On", DateTime.Now);
                    cmd.ExecuteNonQuery();
                 
                }
            }
        }
    }
}
