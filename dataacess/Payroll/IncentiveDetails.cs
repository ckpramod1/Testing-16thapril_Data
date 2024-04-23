using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.PAYROLL
{
    public class IncentiveDetails : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public IncentiveDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable Getempdtls(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empcode",SqlDbType.VarChar ,10)};
            objp[0].Value = empcode;
            return ExecuteTable("SPgetEmpdtls", objp);
        }

        public void InsHRIncentiveDtls(int empid,decimal tdsp,double tdsa,double amount,DateTime date)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@empid" ,SqlDbType.Int,4),
                                                      new SqlParameter( "@tdsp",SqlDbType.Decimal,6),
                                                      new SqlParameter( "@tdsa",SqlDbType.Money,8),
                                                      new SqlParameter( "@amount",SqlDbType.Decimal,6),
                                                      new SqlParameter( "@date",SqlDbType.DateTime,10),
                                                      new SqlParameter( "@incid",SqlDbType.Int,4)};

            objp[0].Value = empid;
            objp[1].Value = tdsp;
            objp[2].Value = tdsa;
            objp[3].Value = amount;
            objp[4].Value = date;
            objp[5].Direction = ParameterDirection.Output;
            ExecuteQuery("SPInsHRIncentivedtls", objp);

        }

        public DataTable GetHRincentivedtls(int empid, DateTime date)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@date",SqlDbType.DateTime,8)
            };

            objp[0].Value = empid;
            objp[1].Value = date;
            return ExecuteTable("SPGetHRIncentivedtls", objp);
        }

        public void UpdHRIncentivedtls(int empid, int incid,DateTime date,decimal tdsp,double tdsa,double amount)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@date",SqlDbType.DateTime,8),
                new SqlParameter("@tdsp",SqlDbType.Decimal,8),
                new SqlParameter("@tdsa",SqlDbType.Money,8),
                new SqlParameter("@amount",SqlDbType.Money,8),
                new SqlParameter("@incid",SqlDbType.Int,4)};

            objp[0].Value = empid;
            objp[1].Value = date;
            objp[2].Value = tdsp;
            objp[3].Value = tdsa;
            objp[4].Value = amount;
            objp[5].Value = incid;
            ExecuteQuery("SPupdHRIncentiveDetails", objp);
        }

        public void DElHRIncentivedtls(int incid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@incid",SqlDbType.Int,4)};

            objp[0].Value = incid;
            ExecuteQuery("SPdelHrincentivedtls",objp);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////HRProfessional Tax ?//////////////////////////////////////////////////////////////////


        public void InsHRProfTax(int empid, int paymonth, int payyear, decimal amount)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@empid" ,SqlDbType.Int,4),
                                                      new SqlParameter( "@paymonth",SqlDbType.Int,4),
                                                      new SqlParameter( "@payyear",SqlDbType.Int,4),
                                                      new SqlParameter( "@amount",SqlDbType.Decimal,6),
                                                      new SqlParameter( "@proid",SqlDbType.Int,4)};

            objp[0].Value = empid;
            objp[1].Value = paymonth;
            objp[2].Value = payyear;
            objp[3].Value = amount;
            objp[4].Direction = ParameterDirection.Output;
            ExecuteQuery("SpInsHrProfTax", objp);

        }

        public void UpdHRProftax(int empid, int proid, int paymonth, int payyear, double amount)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@proid",SqlDbType.Int,8),
                new SqlParameter("@paymonth",SqlDbType.Int,4),
                new SqlParameter("@payyear",SqlDbType.Int,4),
                new SqlParameter("@amount",SqlDbType.Money,8)
            };
            objp[0].Value = empid;
            objp[1].Value = proid;
            objp[2].Value = paymonth;
            objp[3].Value = payyear;
            objp[4].Value = amount;
            ExecuteQuery("SPupdHRProftax", objp);
        }


        public DataTable GetHRProftaxdtls(int empid, int paymonth, int payyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@empid",SqlDbType.Int,4),
            new SqlParameter("@paymonth",SqlDbType.Int,4),
            new SqlParameter("@payyear",SqlDbType.Int,4)
            };

            objp[0].Value = empid;
            objp[1].Value = paymonth;
            objp[2].Value = payyear;
            return ExecuteTable("SPGetprodtls", objp);
        }

        public DataTable GetHRProftaxdtlsfrommonth(int paymonth, int payyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
            new SqlParameter("@paymonth",SqlDbType.Int,4),
            new SqlParameter("@payyear",SqlDbType.Int,4)
            };

            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            return ExecuteTable("SPGetprodtlsfrommonth", objp);
        }

        public void DElHRProftax(int proid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@proid", SqlDbType.Int, 4) };

            objp[0].Value = proid;
            ExecuteQuery("SPdelHrproftax", objp);
        }
    }
}
