using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.payroll
{
    public class MedicalExcemption : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MedicalExcemption()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void UpdMedExcem(string excemption,char type,int year,double amount)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@excemption", SqlDbType.VarChar,50 ), 
                                                       new SqlParameter("@type", SqlDbType.Char, 2),
                new SqlParameter("@year", SqlDbType.Int, 4),
                new SqlParameter("@amount", SqlDbType.Money)
           };


            objp[0].Value = excemption;
            objp[1].Value = type;
            objp[2].Value = year;
            objp[3].Value = amount;

            //ExecuteQuery("SPUpdMedExm", objp);
            ExecuteQuery("SPUpdMedicalExmp", objp);
        }

        public void InsMasExcem(string excemption, char type, int year, double amount)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@excemption", SqlDbType.VarChar,50 ), 
                                                       new SqlParameter("@type", SqlDbType.Char, 2),
                new SqlParameter("@year", SqlDbType.Int, 4),
                new SqlParameter("@amount", SqlDbType.Money)
           };


            objp[0].Value = excemption;
            objp[1].Value = type;
            objp[2].Value = year;
            objp[3].Value = amount;

            ExecuteQuery("SPInsMasExm", objp);
        }

        public DataTable GetMasExcem(string excemption, char type, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@excemption", SqlDbType.VarChar,50 ), 
                                                       new SqlParameter("@type", SqlDbType.Char, 2),
                new SqlParameter("@year", SqlDbType.Int, 4)
           };


            objp[0].Value = excemption;
            objp[1].Value = type;
            objp[2].Value = year;
            return ExecuteTable("SpGetMasExm", objp);
        }

        public void DelMasExcem(string excemption, char type, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@excemption", SqlDbType.VarChar,50 ), 
                                                       new SqlParameter("@type", SqlDbType.Char, 2),
                new SqlParameter("@year", SqlDbType.Int, 4)
           };


            objp[0].Value = excemption;
            objp[1].Value = type;
            objp[2].Value = year;
            ExecuteQuery("SPDelMasExm", objp);
        }
    }

}
