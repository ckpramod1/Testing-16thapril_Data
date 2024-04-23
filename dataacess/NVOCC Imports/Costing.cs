using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.NVOCC_Imports
{
    public class Costing : DBObject
    {
        protected int count;
        protected DataTable tempDt;
        protected double amount;
        protected double income;
        protected double expense;
        protected double invoice;
        protected double oscn;
        protected double dn;
        protected double cn;
        protected double pa;
        protected double osdn;
        protected double osinv;
        protected double ospa;


        public int exprowcount = 0;


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Costing()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable CostingDetail(int jobno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPNICostingofJob", objp);
        }

        public DataTable GetChargewiseCosting(int jobno, string trantype, int branchid,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@empid",SqlDbType.Int) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = empid;
            return ExecuteTable("SPNIGetCosting", objp);
        }

        public void InsertCostingCloseJobs(int empid, int branchid, int jobno, string trantype, DateTime closedate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                                new SqlParameter("@bid",SqlDbType.Int),
                                                                 new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                 new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                 new SqlParameter("@closedate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = trantype;
            objp[4].Value = closedate;
            ExecuteQuery("SPNIInsJobClose", objp);

        }


        public DataTable CheckSOA(int jobno, string trantype, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            return ExecuteTable("SPNICheckSOA", objp);
        }
    }
}
