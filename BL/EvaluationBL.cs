using Institution_System.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution_System.BL
{
    public class EvaluationBL
    {
        public EvaluationDL dataAccess;

        public EvaluationBL(EvaluationDL dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public void SaveEvaluation(string department , int TotalWg , string subject , int semster)
        {
            dataAccess.InsertEvaluation(department , TotalWg , subject , semster);

        }
    }
}
