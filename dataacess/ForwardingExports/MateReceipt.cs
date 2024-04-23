using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
   public class MateReceipt:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MateReceipt()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetJobLists(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("spFErptMRJobnolist", objp);
       }

       public DataTable GetJobShippingLists(int intJobNo, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@jobno", SqlDbType.Int,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = intJobNo;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("spFErptMRshpngbillist", objp);
       }
       public DataTable GetSBno4Amend(int jobno, int bid)
       {

           SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
           objp[0].Value = jobno;
           objp[1].Value = bid;
           return ExecuteTable("SPGetSBNo4Amend", objp);
       }
       public void UpdAmendSBL(string stroldblno, string strnewblno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[]{ 
                                                      new SqlParameter("@oldblno",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@newblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
           objp[0].Value = stroldblno;
           objp[1].Value = strnewblno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           ExecuteQuery("SPAmendShippingBill", objp);
       }

    }
}
