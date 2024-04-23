using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class unclosedjob : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public unclosedjob()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable Getunclosedjob(int divisionid, int branchid,int flag,DateTime fdate, DateTime tdate)
        {
            
            SqlParameter[] objp = new SqlParameter[]
             {
                 //new SqlParameter("@dbname",SqlDbType.VarChar,15),
                 new SqlParameter("@cid",SqlDbType.TinyInt,1),
                 new SqlParameter("@bid1",SqlDbType.TinyInt,1),
                 new SqlParameter("@flag",SqlDbType.TinyInt,1),
                 new SqlParameter("@fromdate",SqlDbType.DateTime),
                 new SqlParameter("@todate",SqlDbType.DateTime)
             };
            objp[0].Value = divisionid;
            objp[1].Value = branchid;
            objp[2].Value = flag;
            objp[3].Value = fdate;
            objp[4].Value = tdate;
           // return ExecuteTable("SPGetUnclosedJobFAnew", objp);
           // return ExecuteTable("SPGetUnclosedJobFAnew1", objp);
            return ExecuteTable("SPGetUnclosedJobFAnew1ETAETD", objp);
            
        }

        //public DataTable Getunclosedjobnew(int divisionid, int branchid, int flag)
        //{

        //    SqlParameter[] objp = new SqlParameter[]
        //     {
        //         //new SqlParameter("@dbname",SqlDbType.VarChar,15),
        //         new SqlParameter("@cid",SqlDbType.Int,1),
        //         new SqlParameter("@bid1",SqlDbType.Int,1),
        //         new SqlParameter("@flag",SqlDbType.Int,1)
                
        //     };
        //    objp[0].Value = divisionid;
        //    objp[1].Value = branchid;
        //    objp[2].Value = flag;
          
        //    // return ExecuteTable("SPGetUnclosedJobFAnew", objp);
        //    // return ExecuteTable("SPGetUnclosedJobFAnew1", objp);
        //    return ExecuteTable("SPGetUnclosedJobFAnew1ETAETD", objp);

        //}


    }
}
