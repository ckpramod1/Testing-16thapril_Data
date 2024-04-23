using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Accounts
{
   public class TDS:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TDS()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsFATDS( int empid, int branchid,DateTime fromdate, DateTime todate,int cid)
       {
           SqlParameter[] objp = new SqlParameter[]{     new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@cid",SqlDbType.Int,4)};

           objp[0].Value = empid;
           objp[1].Value = branchid;
           objp[2].Value = fromdate;
           objp[3].Value = todate;
           objp[4].Value = cid;
           ExecuteQuery("SPInsFATDS", objp);
       }
       public void InsFAST(int empid, int branchid, DateTime fromdate, DateTime todate, int cid)
       {
           SqlParameter[] objp = new SqlParameter[]{     new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@cid",SqlDbType.Int,4)};

           objp[0].Value = empid;
           objp[1].Value = branchid;
           objp[2].Value = fromdate;
           objp[3].Value = todate;
           objp[4].Value = cid;
           ExecuteQuery("SPInsFAST", objp);
       }
       public DataTable GetTDSEXCEL(int empid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4) };

           objp[0].Value = empid;
           return ExecuteTable("SPGetTDSExcel", objp);
       }
       public DataTable GetSTExcel(int empid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4) };

           objp[0].Value = empid;
           return ExecuteTable("SPGetFASTExcel", objp);
       }

       public DataTable GetTDSEXCELALL(int empid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4) };

           objp[0].Value = empid;
           return ExecuteTable("SPGetTDSExcelALL", objp);
       }

       public void InsFATDSALL(int empid, int branchid, DateTime fromdate, DateTime todate, int cid)
       {
           SqlParameter[] objp = new SqlParameter[]{     new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@cid",SqlDbType.Int,4)};

           objp[0].Value = empid;
           objp[1].Value = branchid;
           objp[2].Value = fromdate;
           objp[3].Value = todate;
           objp[4].Value = cid;
           ExecuteQuery("SPInsFATDSALL", objp);
       }
    }
}
