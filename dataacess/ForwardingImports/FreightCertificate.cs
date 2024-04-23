using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
    public class FreightCertificate:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FreightCertificate()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetBLDetails(string blno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,3), 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPFIFCBLDetails",objp);
        }


        public DataTable GetInvDetails(string blno, int vouyear, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]  { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@vouyear", SqlDbType.Int),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt)
                                                      };
            objp[0].Value = blno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = intBranchID;
            return ExecuteTable("SPFIFCInvDetails", objp);
        }
    }
}
