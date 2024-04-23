using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ForwardingExports
{
    public class BLRegister:DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BLRegister()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetBLTransactions(DateTime dtStDate, DateTime dtEndDate, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@stdate", SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@endDate", SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = dtStDate;
            objp[1].Value = dtEndDate;
            objp[2].Value =intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("spFErptBLRegister", objp);
        }
    }
}
