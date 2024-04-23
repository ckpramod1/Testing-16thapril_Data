using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data.SqlClient;

namespace DataAccess.FAMaster
{
    public class IncomeExpensesDet : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public IncomeExpensesDet()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataSet  GetIncomeExpenseDet(DateTime fdate, DateTime tdate, string dbname, int divisionId, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      
                                                       
                                                       new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                       new SqlParameter("@divisionId",SqlDbType.TinyInt,4),  
                                                       new SqlParameter("@branchid",SqlDbType.Int ,4)
                                                    };

            objp[0].Value = fdate;
            objp[1].Value = tdate;
            objp[2].Value = dbname;
            objp[3].Value = divisionId;           
            objp[4].Value = branchid;
            return ExecuteDataSet("SP_GetIncomeExpenseDet", objp);
        }

        public DataTable GetVouwisecost4job(int divisionid, int branchid, DateTime fdate, DateTime tdate)
        {

            SqlParameter[] objp = new SqlParameter[]
             {
                 new SqlParameter("@cid",SqlDbType.TinyInt,1),
                 new SqlParameter("@bid",SqlDbType.TinyInt,1),
                 new SqlParameter("@fromdate",SqlDbType.DateTime),
                 new SqlParameter("@todate",SqlDbType.DateTime)
             };
            objp[0].Value = divisionid;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteTable("SPGetVouwisecost4job", objp);
        }


        public DataTable GetMISReconsOP(DateTime from, DateTime to, int vouyear, int branchid, string dbname, string div)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                 new SqlParameter("@from",SqlDbType.DateTime),
                 new SqlParameter("@to",SqlDbType.DateTime),
                 new SqlParameter("@vouyear",SqlDbType.Int),
                 new SqlParameter("@bid",SqlDbType.TinyInt,1),
                 new SqlParameter("@dbname",SqlDbType.VarChar,15),
                  new SqlParameter("@div",SqlDbType.Char ,1)
             };
            objp[0].Value = from;
            objp[1].Value = to;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = dbname;
            objp[5].Value = div;
            return ExecuteTable("SPGetMISReconsOP", objp);


        }


    }
}
