using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.HR
{
    public class Attendance : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Attendance()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetEmpForAttendance(string division, string branch, string dept, DateTime attdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@branch", SqlDbType.VarChar, 20),
                                                       new SqlParameter("@dept", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@attdate", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = division;
            objp[1].Value = branch;
            objp[2].Value = dept;
            objp[3].Value = attdate;
            return ExecuteTable("SPSelEmpForAtten", objp);
        }

        public DataTable GetEmpForAttendanceEmpid(int empid, DateTime attdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@attdate", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = empid;
            objp[1].Value = attdate;
            return ExecuteTable("SPSelEmpForAttenEmpid", objp);
        }

        public DataTable GetEmpForWOAttendance(string division, string branch, string dept)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@branch", SqlDbType.VarChar, 20),
                                                       new SqlParameter("@dept", SqlDbType.VarChar, 15) };
            objp[0].Value = division;
            objp[1].Value = branch;
            objp[2].Value = dept;
            return ExecuteTable("SPSelEmpForWOAtten", objp);
        }

        public void UpdEmpAttendance(int empid, DateTime attdate,char FN,char AN)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@attdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@fn", SqlDbType.Char, 1),
                                                       new SqlParameter("@an", SqlDbType.Char, 1) };
            objp[0].Value = empid;
            objp[1].Value = attdate;
            objp[2].Value = FN;
            objp[3].Value = AN;
            ExecuteQuery("SPUpdEmpAttendance", objp);
        }
        public void UpdEmpAttendanceExist(int empid, DateTime attdate, char FN, char AN)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@attdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@fn", SqlDbType.Char, 1),
                                                       new SqlParameter("@an", SqlDbType.Char, 1) };
            objp[0].Value = empid;
            objp[1].Value = attdate;
            objp[2].Value = FN;
            objp[3].Value = AN;
            ExecuteQuery("SPUpdEmpAttendanceExist", objp);
        }
        public void DailyEmpAttendance()
        {
            ExecuteQuery("SPInsDailyAttend");
        }

        public void InsEmpLevBalance(int empid, double clb, double slb, double elb)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@clb", SqlDbType.Real, 1),
                                                       new SqlParameter("@slb", SqlDbType.Real, 1),
                                                       new SqlParameter("@elb", SqlDbType.Real, 1) };
            objp[0].Value = empid;
            objp[1].Value = clb;
            objp[2].Value = slb;
            objp[3].Value = elb;
            ExecuteQuery("SPInsEmpLevBalance", objp);
        }

        public void UpdEmpLevBalance(int empid, double clb, double slb, double elb)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@clb", SqlDbType.Real, 1),
                                                       new SqlParameter("@slb", SqlDbType.Real, 1),
                                                       new SqlParameter("@elb", SqlDbType.Real, 1) };
            objp[0].Value = empid;
            objp[1].Value = clb;
            objp[2].Value = slb;
            objp[3].Value = elb;
            ExecuteQuery("SPUpdEmpLevBalance", objp);
        }
        public void UpdEmpEL(int empid, double elclaimed, DateTime elclaimedon)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@elclaimed", SqlDbType.Real , 4),
                                                       new SqlParameter("@elclaimedon", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int)};
            objp[0].Value = elclaimed;
            objp[1].Value = elclaimedon;
            objp[2].Value = empid;
            ExecuteQuery("SPUpdEmpEL", objp);
        }

        public DataTable SelEmpLevBalance(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPSelEmpLevBalDtls", objp);
        }
        public DataTable GetFNAttendence(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@intempid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPFNAttendance", objp);
        }

        public DataTable GetANAttendence(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@intempid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPANAttendance", objp);
        }

        public DataTable SelAllEmpAttendance(DateTime attdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@attdate", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = attdate;
            return ExecuteTable("SPSelAllEmpAttendance", objp);
        }
        public void InsAllEmpAttendance(DateTime attdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@attdate", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = attdate;
            ExecuteQuery("SPInsAllEmpAttendance", objp);
        }
        //Newly Added
        public DataTable SelEmpClaimDtls(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPSelEmpElClaimDtls", objp);
            //SPGet4EaDtls
        }
        public DataTable GetEmp4EADtls(string division, string branch, int fy)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@branch", SqlDbType.VarChar, 20),                                                      
                                                       new SqlParameter("@fy", SqlDbType.Int) };
            objp[0].Value = division;
            objp[1].Value = branch;
            objp[2].Value = fy;
            return ExecuteTable("SPGetEmp4Ea", objp);
        }
        public void InsHR4EADtls(int empid, DateTime fy, double amt)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid", SqlDbType.Int),
                new SqlParameter("@fy", SqlDbType.SmallDateTime, 4),
                new SqlParameter("@amount", SqlDbType.Money   , 4)
         };
            objp[0].Value = empid;
            objp[1].Value = fy;
            objp[2].Value = amt;
            ExecuteQuery("SPEaclaimDtls", objp);
        }

       


    }
}
