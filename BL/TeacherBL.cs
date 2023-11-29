using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Institution_System.DL;

namespace Institution_System.BL
{
    public class TeacherBL
    {
        private TeacherDL teacherDL;
        public TeacherBL(TeacherDL teacherDL)
        {
            // Initialize the DAL in the constructor
            this.teacherDL = teacherDL;
        }
        public void SaveTeacher(string name, string gender, string address, string email, int accountNo, string phone, int salary)
        {
            teacherDL.InsertTeacher(name, gender, address, email, accountNo, phone, salary);
        }
    }
}
