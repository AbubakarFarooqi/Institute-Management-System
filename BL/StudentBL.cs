using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Institution_System.DL;

namespace Institution_System.BL
{
     public class StudentBL
    {
    
        public StudentDL dataAccess;


        public StudentBL(StudentDL dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void SaveStudent(string name, string gender, string address, int grade, string phone, string email)
        {
            dataAccess.InsertStudent(name, gender, address, grade, phone, email);

        }

    }
}
