using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Statistics : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Statistics()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetStatisticsDts(DateTime fromdate,DateTime todate , string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = trantype;
            objp[3].Value = intBranchID;
            return ExecuteTable("SPGetStatistics", objp);
        }
        public DataSet GetReceiptPaymentDts(DateTime fromdate, DateTime todate, int intBranchID,int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@division",SqlDbType.TinyInt,1)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = intBranchID;
            objp[3].Value = division;
            return ExecuteDataSet("SPSelReceiptPayment", objp);
        }
    }
}
