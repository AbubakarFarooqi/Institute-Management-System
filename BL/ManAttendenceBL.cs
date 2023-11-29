using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.BL
{
    public class ManAttendenceBL
    {
        public ManAttendenceDL dataAccess;
        public ManAttendenceBL(ManAttendenceDL dataaccess)
        {
            this.dataAccess = dataaccess;
        }
        public void SaveManAttendence(int TecId, string TecName, string attendence)
        {
            dataAccess.InsertManAttendence(TecId, TecName, attendence);

        }
    }
}
