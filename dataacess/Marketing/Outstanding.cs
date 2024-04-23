using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Marketing
{
    public   class Outstanding:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Outstanding()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsSalesOutstandindivwise(int empid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@cid",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = cid;
            ExecuteQuery("SPInsSalesOutstanding4Alldiv", objp);
        }
        public DataTable GetAlldivDetatails( int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@cid",SqlDbType.Int,4)};
            objp[0].Value = cid;
            return ExecuteTable("SpGetDiviIdAll", objp);
        }
        public DataTable GetSalesOutstandindivwise(int empid,string cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@cid",SqlDbType.VarChar,3)};
            objp[0].Value = empid;
            objp[1].Value = cid;
            return ExecuteTable("SPGetSalesOutstnading4All", objp);
        }
        public DataTable GetUnclosedJobWise(int branchid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   
                                                    new SqlParameter("@bidd",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = branchid;
            objp[1].Value = division;
            return ExecuteTable("SPGetUnclosedJobsNew", objp);
        }

        public DataTable OutStandingNewLedgerTillDateNew(int empid, int divisionid, int subgroupid, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                               new SqlParameter("@divisionid",SqlDbType.Int),
                                               new SqlParameter("@subgroupid",SqlDbType.Int),
                                               new SqlParameter("@to",SqlDbType.DateTime)
                                           };

            objp[0].Value = empid;
            objp[1].Value = divisionid;  
            objp[2].Value = subgroupid;
            objp[3].Value = to;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDtilldaterajosvouchers", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinetilldaterajlvnew", objp);
            }

        }


       
    }

}
