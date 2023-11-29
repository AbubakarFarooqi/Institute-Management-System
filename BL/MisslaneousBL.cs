using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.BL
{
    public class MisslaneousBL
    {
        public MisslaneousDL dataAccess;


        public MisslaneousBL(MisslaneousDL dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void SaveMisslaneous(int electricity , int gas , int water , int manid)
        {
            dataAccess.InsertMisslaneous(electricity , gas , water , manid);

        }
    }
}
