using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
    public class LoadingConfirmation:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public LoadingConfirmation()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetLoadingConfirmationDet(string strBLno, string strType, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@strType", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = strBLno;
            objp[1].Value = strType;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPFERptLoadConfirm", objp);
        }



        public void UpdFEBLDODate(string blno, DateTime dodate, int intBranchID, int DOComfirmBy, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar,30), 
                                                       new SqlParameter("@dodate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@doconfirmby",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)};
            objp[0].Value = blno;
            objp[1].Value = dodate;
            objp[2].Value = DOComfirmBy;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPUpdFEBLDODate", objp);
        }


    }
}
