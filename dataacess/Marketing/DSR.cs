using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Marketing
{
    public class DSR:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public DSR()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsDSRHead(DateTime dsrdate, int empid, int branchid, int customerid, string product, char services, string purpose, string outcome,int intDivID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@dsrid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dsrdate", SqlDbType.SmallDateTime, 2),
                                                       new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@product", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@services", SqlDbType.Char, 1),
                                                       new SqlParameter("@purpose", SqlDbType.VarChar, 200),
                                                       new SqlParameter("@outcome", SqlDbType.VarChar, 200),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt, 1)};
            objp[0].Direction = ParameterDirection.Output;
            objp[1].Value = dsrdate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            objp[4].Value = customerid;
            objp[5].Value = product;
            objp[6].Value = services;
            objp[7].Value = purpose;
            objp[8].Value = outcome;
            objp[9].Value = intDivID;
            return ExecuteQuery("SPInsDSRHead", objp, "@dsrid");
        }

        public void UpdDSRHead(int dsrid, DateTime dsrdate, int empid, int customerid, string product, char services, string purpose, string outcome, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@dsrid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dsrdate", SqlDbType.SmallDateTime, 2),
                                                       new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@product", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@services", SqlDbType.Char, 1),
                                                       new SqlParameter("@purpose", SqlDbType.VarChar, 200),
                                                       new SqlParameter("@outcome", SqlDbType.VarChar, 200),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = dsrid;
            objp[1].Value = dsrdate;
            objp[2].Value = empid;
            objp[3].Value = customerid;
            objp[4].Value = product;
            objp[5].Value = services;
            objp[6].Value = purpose;
            objp[7].Value = outcome;
            objp[8].Value = bid;
            objp[9].Value = cid;
            ExecuteQuery("SPUpdDSRHead", objp);
        }
        public void InsDSRDetails(int dsrid, char status, DateTime followupdate, string review, DateTime meton, string mettime, int bid, int cid, string nexttime)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@dsrid",SqlDbType.Int,4),
                                                      new SqlParameter("@status",SqlDbType.Char,1),
                                                      new SqlParameter("@followupdate",SqlDbType.SmallDateTime,2),
                                                      new SqlParameter("@review",SqlDbType.VarChar,200),
                                                      new SqlParameter("@meton",SqlDbType.DateTime,8),
                                                      new SqlParameter("@mettime",SqlDbType.VarChar,15),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@nexttime",SqlDbType.VarChar,15)};

            objp[0].Value = dsrid;
            objp[1].Value = status;
            objp[2].Value = followupdate;
            objp[3].Value = review;
            objp[4].Value = meton;
            objp[5].Value = mettime;
            objp[6].Value = bid;
            objp[7].Value = cid;
            objp[8].Value = nexttime;
            ExecuteQuery("SPInsDSRDetails", objp);
        }

        public void UpdDSRDetails(int branchid, int dsrid, char status, DateTime followupdate,DateTime Oldfollowupdate, string review)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@dsrid",SqlDbType.Int,4),
                                                      new SqlParameter("@status",SqlDbType.Char,1),
                                                      new SqlParameter("@followupdate",SqlDbType.SmallDateTime,2),
                                                      new SqlParameter("@Oldfollowupdate",SqlDbType.SmallDateTime,2),
                                                      new SqlParameter("@review",SqlDbType.VarChar,200)};
            objp[0].Value = branchid;
            objp[1].Value = dsrid;
            objp[2].Value = status;
            objp[3].Value = followupdate;
            objp[4].Value = Oldfollowupdate;
            objp[5].Value = review;
            ExecuteQuery("SPUpdDSRDetails", objp);
        }

        public DataTable SelDSRDetails(int dsrid, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@dsrid",SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = dsrid;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelDSRDetails", objp);
        }

        public DataTable DelDSRDetails(int dsrid, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dsrid",SqlDbType.Int,4),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = dsrid;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPDelDSRDetails", objp);
        }

        public DataTable SelDSRHead(int dsrid, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dsrid",SqlDbType.Int,4),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = dsrid;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelDSRHead", objp);
        }

        public DataTable SelAllDSRId(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return ExecuteTable("SPSelAllDSRNumber", objp);
        }
        public DataTable GetSalesforfollowupdates(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPSelfollowdateforsales", objp);
        }

        public DataTable SelSalesFollowdtls(int bid, int cid, int employeeid, DateTime followupdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@employeeid",SqlDbType.Int,4),
                                                        new SqlParameter("@followupdate",SqlDbType.DateTime,8)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = employeeid;
            objp[3].Value = followupdate;
            return ExecuteTable("SPSelSalesfollowup", objp);
        }

        public DataTable SelDSRhead4Schedule(int bid, int cid, int employeeid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@employeeid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@todate",SqlDbType.DateTime,8)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = employeeid;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            return ExecuteTable("SPSelDSRHeadforSchedule", objp);
        }

        public DataTable SelDSRPreVisitDtls(int bid, int cid, int employeeid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@employeeid",SqlDbType.Int,4),
                                                        new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = employeeid;
            objp[3].Value = customerid;
            return ExecuteTable("SPSelDSRForPrevisitcust", objp);
        }
        public DataTable GetDailySalesReport(int bid, DateTime fromdate, DateTime todate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,8),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,8),
                                                        new SqlParameter("@empid",SqlDbType.Int,4)};
            objp[0].Value = bid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = empid;
            return ExecuteTable("SPGetDailysalesRpt", objp);
        }
    }
}
