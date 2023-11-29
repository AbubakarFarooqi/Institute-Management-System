using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.BL
{
    public class StdAttendenceBL
    {
        public StdAttendenceDL dataAccess;
        public StdAttendenceBL(StdAttendenceDL dataaccess)
        {
            this.dataAccess = dataaccess;
        }
        public void SaveStdAttendence(int StdId, string StdName, int RegNo , string attendence)
        {
            dataAccess.InsertStdAttendence(StdId , StdName , RegNo , attendence);

        }
    }
}
