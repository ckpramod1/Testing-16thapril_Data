using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.FAMaster
{
    public  class TBCurwiseLedger : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TBCurwiseLedger()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataSet FAgetTB4FcurLedger(int branchid,int divisionid,DateTime fdate, DateTime tdate, int subgroupid,string dbname, string dispname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                      new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                      new SqlParameter("@subgroupid", SqlDbType.Int, 4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                      new SqlParameter("@dispname",SqlDbType.VarChar,20)};
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = subgroupid ;
            objp[5].Value = dbname;
            objp[6].Value = dispname;

            return ExecuteDataSet("spgetTB4Fcurgroup", objp);
        }
    }
}
