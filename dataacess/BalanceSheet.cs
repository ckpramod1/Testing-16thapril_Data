using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class BalanceSheet : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BalanceSheet()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataSet SelBalanceSheet4Branchwise(string dbname, int divisionid, int branchid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),   
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),                                 
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),                                                     
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;          
            objp[3].Value = fdate;
            objp[4].Value = tdate;
            return ExecuteDataSet("SPFASelBalanceSheet4Branchwise", objp);
        }
    }
}
