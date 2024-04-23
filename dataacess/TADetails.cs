using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class TADetails : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TADetails()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetDivisionProduct(int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = DivisionID;
            return ExecuteTable("SPTADivProduct", objp);
        }

        public DataTable GetDivisionCustomer(int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = DivisionID;
            return ExecuteTable("SPTADivCustomer", objp);
        }

        public DataTable GetDivisionEmployee(int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = DivisionID;
            return ExecuteTable("SPTADivEmployee", objp);
        }

        public DataTable GetBranchProduct(int BranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int) };
            objp[0].Value = BranchID;
            return ExecuteTable("SPTABranchProduct", objp);
        }

        public DataTable GetBranchCustomer(int BranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int) };
            objp[0].Value = BranchID;
            return ExecuteTable("SPTABranchCustomer", objp);
        }

        public DataTable GetBranchEmployee(int BranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int) };
            objp[0].Value = BranchID;
            return ExecuteTable("SPTABranchEmployee", objp);
        }

        public DataTable GetBranches4BP()
        {
            return ExecuteTable("SPSelBranches4BP");
        }

        public DataTable GetBranchDivision(int DivisionID, string IA)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@IA", SqlDbType.VarChar, 3) };
            objp[0].Value = DivisionID;
            objp[1].Value = IA;
            return ExecuteTable("SPBranchDivisionMD", objp);
        }

        public DataTable GetBranchDivisionOther(int DivisionID, string IA)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@IA", SqlDbType.VarChar, 3) };
            objp[0].Value = DivisionID;
            objp[1].Value = IA;
            return ExecuteTable("SPBranchDivisionOthMD", objp);
        }
    }
}
