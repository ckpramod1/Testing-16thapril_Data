using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Payroll
{
    public class salaryRevison:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public salaryRevison()
        {
            Conn = new SqlConnection(DBCS);
        }

        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();

        public DataTable GetEmpdetails4SalRev(DateTime sdate,string div,string branch,string grade)
        {
            SqlParameter[] getemp = new SqlParameter[] {
                                    new SqlParameter("@sdate",SqlDbType.SmallDateTime),
                  new SqlParameter("@div",SqlDbType.VarChar,50),
                 new SqlParameter("@branch",SqlDbType.VarChar,50),
                 new SqlParameter("@grade",SqlDbType.VarChar,10)
                        };
                        getemp[0].Value = sdate;
                        getemp[1].Value =div;
                         getemp[2].Value =branch;
                         getemp[3].Value =grade;
                    
            return ExecuteTable("SPGetEmpdetails4SalRev", getemp);
        }

        public DataTable GetGradeList()
        {
            SqlParameter[] objp = new SqlParameter[] { 
               
                        };
            return ExecuteTable("SPGetGradeList", objp);
        }
        public void InsSalRevDtls(int empid, DateTime sfrom, DateTime sto, string pgrade, decimal incentive)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@employeeid",SqlDbType.Int),
                new SqlParameter("@sfrom",SqlDbType.DateTime),
                 new SqlParameter("@sto",SqlDbType.DateTime),
                    new SqlParameter("@pgrade",SqlDbType.VarChar,15),
               new SqlParameter("@incentive",SqlDbType.Decimal,18)
           };
            objp[0].Value = empid;
            objp[1].Value = sfrom;
            objp[2].Value = sto;
            objp[3].Value = pgrade;
            objp[4].Value = incentive;
            ExecuteQuery("SPInsSalRevDtls", objp);
        }

        public void DelSalRevDtls(int empid,DateTime sfrom, DateTime sto)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@sfrom",SqlDbType.DateTime),
                 new SqlParameter("@sto",SqlDbType.DateTime)
           };
            objp[0].Value = empid;
            objp[1].Value = sfrom;
            objp[2].Value = sto;

            ExecuteQuery("SPDelSalRevDtls", objp);
        }


        //public double GetIncentiveAmt(int empid, DateTime sfrom, DateTime sto)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //        new SqlParameter("@empid",SqlDbType.Int,6),
        //        new SqlParameter("@sfrom",SqlDbType.DateTime),
        //         new SqlParameter("@sto",SqlDbType.DateTime)};
        //    objp[0].Value = empid;
        //    objp[1].Value = sfrom;
        //    objp[2].Value = sto;
        //    return double.Parse(ExecuteReader("SPgetIncentiveAmt", objp));
        //}

        public DataTable GetIncentiveAmt(int empid, DateTime sfrom, DateTime sto)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid",SqlDbType.Int,6),
                new SqlParameter("@sfrom",SqlDbType.DateTime),
                 new SqlParameter("@sto",SqlDbType.DateTime)};
            objp[0].Value = empid;
            objp[1].Value = sfrom;
            objp[2].Value = sto;
            return ExecuteTable("SPgetIncentiveAmt", objp);
        }
        public DataTable SelSalrev4chk()
        {
               SqlParameter[] objp = new SqlParameter[] 
            {                                       
               };
           
            return ExecuteTable("SPSelSalrev4chk", objp);
        }

        public DataTable SelSal4gross(DateTime sfrom,DateTime sto)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {                                       
                new SqlParameter("@sfrom",SqlDbType.DateTime),
                 new SqlParameter("@sto",SqlDbType.DateTime)
               };
            objp[0].Value = sfrom;
            objp[1].Value = sto;
            return ExecuteTable("SPSelSal4gross", objp);
        }
        public void UpdEmpSalary4Inc(string strEmpCode, double dblBasic, double dblHRA, double dblSAllowence, double dblLAllowence, double dblConveyance, double dblOthers, DateTime datSfrom, DateTime datSto, double loyalty, double entertainallow, double driverallow, double dblsalmed)
        {
            int intEmpID;
            intEmpID = empObj.GetEmpid(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@basic",SqlDbType.Money,8),
                        new SqlParameter("@hra",SqlDbType.Money,8),
                        new SqlParameter("@sallowence",SqlDbType.Money,8),
                        new SqlParameter("@lallowence",SqlDbType.Money,8),
                        new SqlParameter("@conveyance",SqlDbType.Money,8),
                        new SqlParameter("@others",SqlDbType.Money,8),
                        new SqlParameter("@sfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@sto",SqlDbType.DateTime,8),
                        new SqlParameter("@loyalty",SqlDbType.Money,8),
                        new SqlParameter("@entertainallow",SqlDbType.Money,8),
                        new SqlParameter("@driverallow",SqlDbType.Money,8),
                         new SqlParameter("@medical",SqlDbType.Money,8)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = dblBasic;
            objp[2].Value = dblHRA;
            objp[3].Value = dblSAllowence;
            objp[4].Value = dblLAllowence;
            objp[5].Value = dblConveyance;
            objp[6].Value = dblOthers;
            objp[7].Value = datSfrom;
            objp[8].Value = datSto;
            objp[9].Value = loyalty;
            objp[10].Value = entertainallow;
            objp[11].Value = driverallow;
            objp[12].Value = dblsalmed ;
            ExecuteQuery("SPUpdEmpSalaryDetails4Inc", objp);
        }
    }
}
