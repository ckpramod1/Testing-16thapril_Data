using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
   public class MISRegion : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MISRegion()
       {
           Conn = new SqlConnection(DBCS);
       }
       public double SPMISRegionIncome(int branchid, int vouyear, DateTime dtfrom, DateTime dtto)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to",SqlDbType.SmallDateTime,4)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = dtfrom;
           objp[3].Value = dtto;          
           return double.Parse(ExecuteReader("SPMISRegionIncome", objp));
       }
       public double SPMISRegionInDN(int branchid, int vouyear, DateTime dtfrom, DateTime dtto)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to",SqlDbType.SmallDateTime,4)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = dtfrom;
           objp[3].Value = dtto;
           return double.Parse(ExecuteReader("SPMISRegionInDN", objp));
       }
       public double SPMISRegionExp(int branchid, int vouyear, DateTime dtfrom, DateTime dtto)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to",SqlDbType.SmallDateTime,4)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = dtfrom;
           objp[3].Value = dtto;
           return double.Parse(ExecuteReader("SPMISRegionExp", objp));
       }
       public double SPMISRegionExpCN(int branchid, int vouyear, DateTime dtfrom, DateTime dtto)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to",SqlDbType.SmallDateTime,4)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = dtfrom;
           objp[3].Value = dtto;
           return double.Parse(ExecuteReader("SPMISRegionExpCN", objp));
       }
       public double SPMISRegionActIncome(int branchid, int vouyear, int month)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = month;
           
           return double.Parse(ExecuteReader("SPMISRegionActIncome", objp));
       }
       public double SPMISRegionActInDN(int branchid, int vouyear, int month)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = month;
           return double.Parse(ExecuteReader("SPMISRegionActInDN", objp));
       }
       public double SPMISRegionActExp(int branchid, int vouyear, int month)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = month;
           return double.Parse(ExecuteReader("SPMISRegionActExp", objp));
       }
       public double SPMISRegionActExpCN(int branchid, int vouyear, int month)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = month;
           return double.Parse(ExecuteReader("SPMISRegionActExpCN", objp));
       }
       public double SPMISRegionBudget(int branchid, int vouyear, int month)
       {
           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int)};
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = month;
           return double.Parse(ExecuteReader("SPMISRegionBudget", objp));
       }
    }
}
