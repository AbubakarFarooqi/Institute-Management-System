using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.BL
{
    public class ManagementBL
    {
        public ManagementDL dataAccess;

        public ManagementBL(ManagementDL dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void SaveManagement(string name, string gender, string address, string phone, string email , int AccountNo)
        {
            dataAccess.Insertmanagement(name, gender, address,  phone, email , AccountNo);

        }
    }
}
