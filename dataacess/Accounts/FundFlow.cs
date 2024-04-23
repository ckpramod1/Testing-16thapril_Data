using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Accounts
{
    public class FundFlow : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FundFlow()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataSet fundsflow(DateTime fromdate, DateTime todate, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                     };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteDataSet("fundsflow", objp);
        }

        public DataSet fundsflowforAllBranches(DateTime fdate, DateTime tdate, string dbname, int DivisionId)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@divisionId",SqlDbType.Int,4)};

            objp[0].Value = fdate;
            objp[1].Value = tdate;
            objp[2].Value = dbname;
            objp[3].Value = DivisionId;
            return ExecuteDataSet("fundsflowforAllBranches", objp);
        }
    }
}
