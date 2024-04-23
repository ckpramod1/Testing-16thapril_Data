using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Accounts
{
   public class Exemption:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Exemption()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GridFillJobdtls(DateTime fromdate, DateTime todate,int bid,int cid)
       {

           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate", SqlDbType.DateTime,4),
                                                       new SqlParameter("@todate", SqlDbType.DateTime,4),
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@cid",SqlDbType.Int,4)};
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = bid;
           objp[3].Value = cid;
           return ExecuteTable("SPGetExemptionRpt", objp);
       }
       public DataTable Getbillrpt(DateTime fromdate, DateTime todate, int bid, int cid, string trantype, string strby)
       {

           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate", SqlDbType.DateTime,4),
                                                       new SqlParameter("@todate", SqlDbType.DateTime,4),
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@cid",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@strby",SqlDbType.VarChar,4)};
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = bid;
           objp[3].Value = cid;
           objp[4].Value = trantype;
           objp[5].Value = strby;
           return ExecuteTable("SPBillingReportagnsETA", objp);
       }
    }
}
