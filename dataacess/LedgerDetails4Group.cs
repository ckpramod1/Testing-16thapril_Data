using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class LedgerDetails4Group : DBObject 
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public LedgerDetails4Group()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable FAselLedgerDet4Group( DateTime fdate, DateTime tdate, string dbname, int divisionId,string dispname,int groupid,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      
                                                       
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4),
                                                    new SqlParameter("@dispname",SqlDbType.VarChar ,15),
                                                    new SqlParameter("@groupid",SqlDbType.Int ,4),
            new SqlParameter("@branchid",SqlDbType.Int ,4)};

            
            objp[0].Value = fdate;
            objp[1].Value = tdate;
            objp[2].Value = dbname;
            objp[3].Value = divisionId;
            objp[4].Value = dispname;
            objp[5].Value = groupid;
            objp[6].Value = branchid ;
            return ExecuteTable("SPFAselLedger4Group", objp);
        }
    }
}
