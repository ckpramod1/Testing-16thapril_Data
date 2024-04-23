using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRMNew
{
    public class AppointmentCancel : DBObject
    {

        //public DataTable GetCRMCancelAppts()
        //{
        //    return ExecuteTable("SPGetCRMCancelAppints");
        //}


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public AppointmentCancel()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetCRMCancelAppts(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPGetCRMCancelAppints", objp);
        }

        public DataTable DeleteCRMApptsDetails(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = crmid;
            return ExecuteTable("SPDeleteAllCRMAppts", objp);
        }

        public DataTable GetCRMIDwithcust(int custs)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cusid", SqlDbType.Int) };
            objp[0].Value = custs;
            return ExecuteTable("SPGetCRMidWithCust ", objp);
        }







    }
}
