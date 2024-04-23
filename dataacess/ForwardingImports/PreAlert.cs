using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
   public  class PreAlert:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public PreAlert()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetFIPreAlertBLDetails(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPFIPreAlert", objp);
       }



       public void UpdPreAlert(int intBranchID, int intJobno, string strTrantype, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = intJobno;
           objp[1].Value = strTrantype;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           ExecuteQuery("SPUpdPrealert", objp);
       }
    }
}
