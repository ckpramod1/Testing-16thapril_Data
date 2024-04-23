using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace DataAccess.Payroll
{
    public class SatuatoryReport : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public SatuatoryReport()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetSalarySheet(int branchid, int divisionid, int payyear, int paymonth)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@payyear",SqlDbType.Int),
                new SqlParameter("paymonth",SqlDbType.Int)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = payyear;
            objp[3].Value = paymonth;
            return ExecuteTable("SPgetSalarySheet", objp);
        }

        public DataTable GetEsiStatement(int branchid, int divisionid, int payyear, int paymonth)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@payyear",SqlDbType.Int),
                new SqlParameter("paymonth",SqlDbType.Int)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = payyear;
            objp[3].Value = paymonth;
            return ExecuteTable("SpgetEsiStatement", objp);
        }

        public DataTable GetPfMonthlyStatement(int branchid, int divisionid, int payyear, int paymonth)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@payyear",SqlDbType.Int),
                new SqlParameter("paymonth",SqlDbType.Int)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = payyear;
            objp[3].Value = paymonth;
            return ExecuteTable("SPGetPFMonthlystmt", objp);
        }

        public DataTable GetPfNewMonthlyStatement(int branchid, int divisionid, int payyear, int paymonth)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@payyear",SqlDbType.Int),
                new SqlParameter("paymonth",SqlDbType.Int)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = payyear;
            objp[3].Value = paymonth;
            return ExecuteTable("SPGetPFNewMonthlystmt", objp);
        }

        public DataTable GetForm16(int divisionid, int payyear,int paymonth)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@payyear",SqlDbType.Int),
                new SqlParameter("@paymonth",SqlDbType.Int)
            };
            objp[0].Value = divisionid;
            objp[1].Value = payyear;
            objp[2].Value = paymonth;
            return ExecuteTable("spgenerateForm16", objp);
        }

        public DataTable GetSalaryslip()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPGetSalaryslipfor24Q", objp);
        }

        public DataTable GetAppraiseeTraining(int division, int kpiyear)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@division",SqlDbType.Int),
                        new SqlParameter("@kpiyear",SqlDbType.Int)
                    };
            objp[0].Value = division;
            objp[1].Value = kpiyear;

            return ExecuteTable("SPGetAppraiseeTrainingReport", objp);
        }
    }
}
