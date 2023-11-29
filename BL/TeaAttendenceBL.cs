using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.BL
{
    public class TeaAttendenceBL
    {
        public TeaAttendenceDL dataAccess;
        public TeaAttendenceBL(TeaAttendenceDL dataaccess)
        {
            this.dataAccess = dataaccess;
        }
        public void SaveTeaAttendence(int TecId, string TecName, string attendence)
        {
            dataAccess.InsertTeaAttendence(TecId , TecName , attendence);

        }
    }
}
