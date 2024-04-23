using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
    public class ReminderNotice : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ReminderNotice()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetBLJobNo(int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFIReminderJobNo",objp);
        }

        public DataTable GetBLNo(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFIReminderBLNo",objp);
        }
    }
}
