using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.Masters
{
    public class MasterDepartment:DBObject 
    {
        //Insert Department Name.

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterDepartment()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void Insertdepartment(string deptname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptname", SqlDbType.VarChar, 30) };
            objp[0].Value = deptname;
            ExecuteQuery("SPInsMasterDepartment", objp);
        }
        //Update  Department Name.

        public void Upddepartment(string deptname,int deptid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptname", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@deptid",SqlDbType.TinyInt,1)};
            objp[0].Value = deptname;
            objp[1].Value = deptid;
            ExecuteQuery("SPUpdMasterDepartment", objp);
        }
        public DataTable SelDeptname(string deptname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptname", SqlDbType.VarChar, 30) };
            objp[0].Value = deptname;
            return ExecuteTable("SPSelMasterDepartment", objp);
        }
        public DataTable GetLikeDeptname(string deptname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtdeptname", SqlDbType.VarChar, 30) };
            objp[0].Value =deptname;
            return ExecuteTable("SPLikeDepartment", objp);

        }
        //gridDept
        public DataTable GetGridview()
        {
            return ExecuteTable("SpgrideDept");
        }

        //Delete Depts
        public void DelDept(int deptid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptid", SqlDbType.Int) };
            objp[0].Value = deptid;
            ExecuteQuery("SpDeldept", objp);
        }

       

        public DataTable GetDetpNameView(int depid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptid", SqlDbType.Int) };

            objp[0].Value = depid;

            return ExecuteTable("SPSelectDepartment", objp);

        }

        public DataTable GetDeptTopGridRow()
        {
            return ExecuteTable("SPTopDepartmentVal");
        }
        public void DelTableDept(int deptid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptid", SqlDbType.Int)
            
        };
            objp[0].Value = deptid;
            ExecuteQuery("Sp_DelDept", objp);

        }

        public DataTable GetDepartmentview()
        {
            return ExecuteTable("spviewdepartmentdetails");
        }

    }
}
