using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
   public class ChangeJob:DBObject
    {
        Masters.MasterCharges chrgobj = new Masters.MasterCharges();
        public String SPName;


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ChangeJob()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetJobDetails(string strTranType, int intBranchID, int intDivisionID)
       {
           if (strTranType == "FE")
               SPName = "SPFEJob";
           else if (strTranType == "FI")
               SPName = "SPFIJob";
           else if (strTranType == "AE")
               SPName = "SPAEJob";
           else
               SPName = "SPAIJob";

           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable(SPName, objp);
       }

       public DataTable GetBLDetails(int jobno, string strTranType, int intBranchID, int intDivisionId)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
           objp[0].Value = jobno;
           objp[1].Value = strTranType;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionId;
           if ((strTranType == "FE") || (strTranType == "FI"))
               Dt = ExecuteTable("SPFIEBLJobno", objp);
           else
               Dt = ExecuteTable("SPAIEBLJobno", objp);
           return Dt;
       }

       public void UpdChangeJob(int disjobno, string strblno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                        new SqlParameter("@disjobno",SqlDbType.Int,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = disjobno;
            objp[1].Value = strblno;
            objp[2].Value = trantype;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPChangeJob",objp);
        }
    }
}
