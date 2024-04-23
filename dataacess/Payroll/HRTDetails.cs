using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.PAYROLL
{



    public class HRTDetails:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public HRTDetails()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetHRTDetails(int paymonth, int payyear,int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                     new SqlParameter("@paymonth", SqlDbType.Int) ,
                    new SqlParameter("@payyear", SqlDbType.Int),
                    new SqlParameter("@empid", SqlDbType.Int)

                };
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            objp[2].Value = empid;
            return ExecuteTable("GetHRDTDetails", objp);

        }

        public void HRInsHRTDDetails(int empid,int paymonth,int payyear,DateTime depdate,int tds,int surcharge,int educess,string  cheque,string  bsrcode,string  chellan,string datafrom)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
               new SqlParameter("@empid",SqlDbType.Int ,4),
               new SqlParameter("@paymonth",SqlDbType.Int),
               new SqlParameter("@payyear",SqlDbType.Int),
               new SqlParameter("@depdate",SqlDbType.DateTime  ,2),
                new SqlParameter("@tds",SqlDbType.Money ,2),
               new SqlParameter("@surcharge",SqlDbType.Money ,2),
                new SqlParameter("@educess",SqlDbType.Money ,2),
                  new SqlParameter("@cheque",SqlDbType.VarChar ,15),
                 new SqlParameter("@bsrcode",SqlDbType.VarChar ,15),
                new SqlParameter("@chellan ",SqlDbType.VarChar  ,15),
               new SqlParameter("@datafrom",SqlDbType.VarChar,2)
              

           };
            objp[0].Value = empid;
            objp[1].Value = paymonth ;
            objp[2].Value = payyear ;
            objp[3].Value = depdate ;
            objp[4].Value = tds ;
            objp[5].Value = surcharge ;
            objp[6].Value = educess ;
            objp[7].Value = cheque ;
            objp[8].Value = bsrcode ;
            objp[9].Value = chellan ;
            objp[10].Value = datafrom;

            ExecuteQuery("SPInsHRTDS", objp);
        }


        public double GetTDStaxAmt(int empid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@empid", SqlDbType.Int,4),
                new SqlParameter("@month", SqlDbType.TinyInt,2),
                new SqlParameter("@year", SqlDbType.Int,4)
                                                       
               };
            objp[0].Value = empid;
            objp[1].Value = month;
            objp[2].Value = year;
            return double.Parse(ExecuteReader("SPGetHRTDStaxAmt", objp));
        }



        public DataTable GetHRTdsDetailsforgrd(int paymonth, int payyear, int empid, string func)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                     new SqlParameter("@paymonth", SqlDbType.Int) ,
                    new SqlParameter("@payyear", SqlDbType.Int),
                    new SqlParameter("@empid", SqlDbType.Int),
                    new SqlParameter("@func",SqlDbType.VarChar,1)
                };
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            objp[2].Value = empid;
            objp[3].Value = func;
            return ExecuteTable("SPGetTdsDetailsForEmp", objp);

        }

        public DataTable GetHrtdscodeDetails(int paymonth, int payyear)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                     new SqlParameter("@paymonth", SqlDbType.Int) ,
                    new SqlParameter("@payyear", SqlDbType.Int)
                };
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            return ExecuteTable("SpGettdsdtlsfrommonth", objp);
        }

        public void InsGetHrTdsfromPayroll(int paymonth, int payyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@paymonth",SqlDbType.Int,4),
                new SqlParameter("@payyear",SqlDbType.Int,4)
            };
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            ExecuteQuery("SpGetDtlsfromPayroll", objp);
        }
        /*Dinesh*/
        public void HRInsHRTDDetailsWeb(int empid, int paymonth, int payyear, DateTime depdate, Double tds, Double surcharge, Double educess, string cheque, string bsrcode, string chellan, string datafrom)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
               new SqlParameter("@empid",SqlDbType.Int ,4),
               new SqlParameter("@paymonth",SqlDbType.Int),
               new SqlParameter("@payyear",SqlDbType.Int),
               new SqlParameter("@depdate",SqlDbType.DateTime  ,2),
                new SqlParameter("@tds",SqlDbType.Money ,2),
               new SqlParameter("@surcharge",SqlDbType.Money ,2),
                new SqlParameter("@educess",SqlDbType.Money ,2),
                  new SqlParameter("@cheque",SqlDbType.VarChar ,15),
                 new SqlParameter("@bsrcode",SqlDbType.VarChar ,15),
                new SqlParameter("@chellan ",SqlDbType.VarChar  ,15),
               new SqlParameter("@datafrom",SqlDbType.VarChar,2)
              

           };
            objp[0].Value = empid;
            objp[1].Value = paymonth;
            objp[2].Value = payyear;
            objp[3].Value = depdate;
            objp[4].Value = tds;
            objp[5].Value = surcharge;
            objp[6].Value = educess;
            objp[7].Value = cheque;
            objp[8].Value = bsrcode;
            objp[9].Value = chellan;
            objp[10].Value = datafrom;

            ExecuteQuery("SPInsHRTDS", objp);
        }
    


    }
}
