using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ChangeJob
{
    public class ChangeJob : DBObject
    {
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public ChangeJob()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetJobDetails(string strTranType, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = intBranchID;
            if (strTranType == "FE")
                Dt = ExecuteTable("SPSelOEJob",objp);
            else if (strTranType == "FI")
                Dt = ExecuteTable("SPSelOIJob", objp);
            else if (strTranType == "AE")
                Dt = ExecuteTable("SPSelAEJob", objp);
            else
                Dt = ExecuteTable("SPSelAIJob", objp);
            return Dt;
        }

        public DataTable GetBLDetails(int jobno, string strTranType, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = intBranchID;
            objp[1].Value = jobno;
            objp[2].Value = strTranType;
            if ((strTranType == "FE") || (strTranType == "FI"))
                Dt = ExecuteTable("SPFIEBLJobno", objp);
            else
                Dt= ExecuteTable("SPAIEBLJobno",objp);
            return Dt;
        }

        public void UpdChangeJob(int disjobno, string strblno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@disjobno",SqlDbType.Int,4),
                                                    new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = intBranchID;
            objp[1].Value = disjobno;
            objp[2].Value = strblno;
            objp[3].Value = trantype;
            ExecuteQuery("SPChangeJob", objp);            
        }
      

    }
}
