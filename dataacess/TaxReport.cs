using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
   public  class TaxReport : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TaxReport()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable StatisticsTaxReport(string dbname,int divisionid, int branchid, int empid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@empid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = empid;
            objp[4].Value = fdate;
            objp[5].Value = tdate;
            return ExecuteTable("SPFAStatisticRep", objp);
        }

       public DataTable StatisticsTaxReport4AllBranch(string dbname, int divisionid, int branchid, int empid, DateTime fdate, DateTime tdate)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@empid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
           objp[0].Value = dbname;
           objp[1].Value = divisionid;
           objp[2].Value = branchid;
           objp[3].Value = empid;
           objp[4].Value = fdate;
           objp[5].Value = tdate;
           return ExecuteTable("SPFAStatisticRep4AllBranch", objp);
       }
    }
}
