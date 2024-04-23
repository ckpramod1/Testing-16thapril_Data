using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DashBoard
{
    public class RightFrame:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public RightFrame()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetCountryList(string strPortName)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@portname", SqlDbType.VarChar, 30)};
            objp[0].Value =strPortName;
            return ExecuteTable("SPPortCountryName", objp);
        }
        public DataTable GetPortList(string strCountryName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@country", SqlDbType.VarChar, 30)};
            objp[0].Value =  strCountryName;
            return ExecuteTable("SPCountryPortNames", objp);
        }
        
        public void InsertUsageRates(int divisionid, int branchid, string trantype, double rating, double closedjob, double totaljob)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@rating",SqlDbType.Real,8),
                                                      new SqlParameter("@closedjobs",SqlDbType.Real,8),
                                                      new SqlParameter("@totaljobs",SqlDbType.Real,8)};
            objp[0].Value = divisionid;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = rating;
            objp[4].Value = closedjob;
            objp[5].Value = totaljob;
            ExecuteQuery("SPInsUsagerates", objp);
        }

        public void DeleteUsageRates()
        {

            ExecuteQuery("SPDelUsagerates");
        }
        public DataTable GetBranchid4usg(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = divisionid;
            return ExecuteTable("SPSelBranchid4usage", objp);
        }
        public double Getusagerating(int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                     };

            objp[0].Value = branchid;
            objp[1].Value = trantype;
            return double.Parse(ExecuteReader("SPSelUsagerates", objp));
        }
        public double GetusageratingForAC(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int)
                                                     };

            objp[0].Value = branchid;
            return double.Parse(ExecuteReader("SPSelUsageratesforAC", objp));
        }
    }

}
