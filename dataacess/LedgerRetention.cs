using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace DataAccess
{
    public class LedgerRetention : DBObject 
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public LedgerRetention()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataSet  GetLedgerRet(int chargeid,DateTime fromdate,DateTime todate, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@chargeid",SqlDbType.Int,2),
                                                         new SqlParameter("@fromdate",SqlDbType.DateTime ,10),
                                                         new SqlParameter("@todate",SqlDbType.DateTime ,10 ),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1)                                              
                                                     };
            objp[0].Value = chargeid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = branchid;
            return ExecuteDataSet("SPSelLedgerwiseRetention", objp);
        }

        public DataTable  DTGetLedgerRet(int chargeid, DateTime fromdate, DateTime todate, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@chargeid",SqlDbType.Int,2),
                                                         new SqlParameter("@fromdate",SqlDbType.DateTime ,10),
                                                         new SqlParameter("@todate",SqlDbType.DateTime ,10 ),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1)                                              
                                                     };
            objp[0].Value = chargeid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelLedgerwiseRetention", objp);
        }
    }
}
