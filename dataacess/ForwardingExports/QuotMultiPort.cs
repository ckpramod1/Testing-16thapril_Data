using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
   public class QuotMultiPort:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public QuotMultiPort()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetQuotCustLists(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                 {
                                                      new SqlParameter("@bid", SqlDbType.TinyInt),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt)
                                                 };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("spFEQuotCustNames", objp);
       }

       public DataTable GetCustQuotDetails(int intCustID, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                       new SqlParameter("@custid", SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = intCustID;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("spFECustQuotations", objp);
       }
       
       public DataTable GetLikeCustName(string CustomerName, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@customername", SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = CustomerName;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPLikeFEQuotCustNames", objp);
       }
    }
}
