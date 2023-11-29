using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.BL
{
    public class CoursesBL
    {
        public CoursesDL dataAccess;

        public CoursesBL(CoursesDL dataaccess) 
        { 
          this.dataAccess= dataaccess;
        }
        public void SaveCourses(string name, int CreditHrs, int semester, string department)
        {
            dataAccess.InsertCourses(name, CreditHrs, semester, department);

        }
    }
}
