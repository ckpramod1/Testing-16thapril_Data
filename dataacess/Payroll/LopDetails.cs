using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.payroll
{
    public class LopDetails : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public LopDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable SelLopDetails(int employeeid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@employeeid", SqlDbType.Int),
                new SqlParameter("@month", SqlDbType.Int, 4) ,
                new SqlParameter("@year", SqlDbType.Int, 4) 
            };
            objp[0].Value = employeeid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPSelLopDetails", objp);

        }


        public void InsLopDetails(int empid, DateTime lopdate, char lopsts, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@employeeid",SqlDbType.Int),
               new SqlParameter("@lopdate",SqlDbType.SmallDateTime,4),
               new SqlParameter("@lopstatus",SqlDbType.Char,1),
               new SqlParameter("@month",SqlDbType.TinyInt,1),
               new SqlParameter("@year",SqlDbType.Int)
           };
            objp[0].Value = empid;
            objp[1].Value = lopdate;
            objp[2].Value = lopsts;
            objp[3].Value = month;
            objp[4].Value = year;
            ExecuteQuery("SPInsLopDetails", objp);
        }


        //public float GetLopDates(int empid, int month, int year)
        //{
        //    SqlParameter[] objp = new SqlParameter[]
        //        {
        //           new SqlParameter("@employeeid",SqlDbType.Int),
        //           new SqlParameter("@month",SqlDbType.TinyInt,1),
        //           new SqlParameter("@year",SqlDbType.Int)
        //        };
        //    objp[0].Value = empid;
        //    objp[1].Value = month;
        //    objp[2].Value = year;
        //    return float.Parse(ExecuteReader("SPGetLopDays", objp));
        //}

        public DataTable SelLopDays(DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@from", SqlDbType.SmallDateTime,4) ,
                new SqlParameter("@to", SqlDbType.SmallDateTime, 4) 
            };
            objp[0].Value = from;
            objp[1].Value = to;
            return ExecuteTable("SPSelNoOfLopDays", objp);

        }
        public void InsLopDays(int empid, int month, int year, decimal days,decimal wdays)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@employeeid",SqlDbType.Int),
               new SqlParameter("@month",SqlDbType.TinyInt,1),
               new SqlParameter("@year",SqlDbType.Int),
               new SqlParameter("@days",SqlDbType.Decimal,18),
               new SqlParameter("@wdays",SqlDbType.Decimal,18)
           };
            objp[0].Value = empid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = days;
            objp[4].Value = wdays;
            ExecuteQuery("SPInsLopDays", objp);
        }

        public void DelLopDays(int empid,int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@employeeid",SqlDbType.Int),
               new SqlParameter("@month",SqlDbType.TinyInt,1),
               new SqlParameter("@year",SqlDbType.Int)
           };
            objp[0].Value = empid;
            objp[1].Value = month;
            objp[2].Value = year;

            ExecuteQuery("SPDelLopDays", objp);
        }

        public DataTable RegenlopDays4Emp(int empid, DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@from", SqlDbType.SmallDateTime,4) ,
                new SqlParameter("@to", SqlDbType.SmallDateTime, 4) ,
                new SqlParameter("@empid", SqlDbType.Int,4) 
            };
            objp[0].Value = from;
            objp[1].Value = to;
            objp[2].Value = empid;
            return ExecuteTable("ReGenLopdays4Emp", objp);

        }

    }
}
