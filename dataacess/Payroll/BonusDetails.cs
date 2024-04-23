using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DataAccess.Payroll
{
    public class BonusDetails : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BonusDetails()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetHRBasic4Bonus(int year, int divisionid, char param)
        {
            SqlParameter[] getdet = new SqlParameter[]{
                               new SqlParameter("@year", SqlDbType.Int, 6),
                new SqlParameter("@divisionid",SqlDbType.Int,6),
                 new SqlParameter("@param",SqlDbType.Char,1)
                            };
            getdet[0].Value = year;
            getdet[1].Value = divisionid;
            getdet[2].Value = param;
            return ExecuteTable("SPGetHRBasic4Bonus", getdet);
        }

        public DataTable GetHRBonusDtls(int year, int divisionid, char param)
        {
            SqlParameter[] getdet = new SqlParameter[]{
                               new SqlParameter("@year", SqlDbType.Int, 6),
                new SqlParameter("@divisionid",SqlDbType.Int,6),
                 new SqlParameter("@param",SqlDbType.Char,1)
                            };
            getdet[0].Value = year;
            getdet[1].Value = divisionid;
            getdet[2].Value = param;
            return ExecuteTable("SPGetHRBonusDtls", getdet);
        }

        public void InsBnsDtls(int empid, int year, decimal amt, double percen)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@employeeid",SqlDbType.Int),
                new SqlParameter("@year",SqlDbType.Int,4),
               new SqlParameter("@amt",SqlDbType.Money),
               new SqlParameter("@percen",SqlDbType.Float)
           };
            objp[0].Value = empid;
            objp[1].Value = year;
            objp[2].Value = amt;
            objp[3].Value = percen;
            ExecuteQuery("SPInsBnsDtls", objp);
        }
        public void UpdBnsDtls(int empid, int year, decimal amt, double percen)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@employeeid",SqlDbType.Int),
                new SqlParameter("@year",SqlDbType.Int,4),
               new SqlParameter("@amt",SqlDbType.Money),
               new SqlParameter("@percen",SqlDbType.Float)
           };
            objp[0].Value = empid;
            objp[1].Value = year;
            objp[2].Value = amt;
            objp[3].Value = percen;
            ExecuteQuery("SPUpdBnsDtls", objp);
        }
        public void DelBnsDtls(int empid,int year)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@year",SqlDbType.Int,4)
           };
            objp[0].Value = empid;
            objp[1].Value = year;
            ExecuteQuery("SPDelBnsDtls", objp);
        }
    }


}
