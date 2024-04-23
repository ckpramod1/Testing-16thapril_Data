using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class TotalShipmentDtls : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TotalShipmentDtls()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataSet GetTotalNoOfJobs(int bid, int divid, DateTime from, DateTime to,string trantype,string strBy)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@divid",SqlDbType.TinyInt),
                                                        new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                        new SqlParameter("@strBy",SqlDbType.VarChar ,5)};

            objp[0].Value = bid ;
            objp[1].Value = divid ;
            objp[2].Value = from ;
            objp[3].Value = to ;
            objp[4].Value = trantype ;
            objp[5].Value = strBy ;
            return ExecuteDataSet("SPGetTotalNoOfJobs", objp);
        }

        public DataTable SPGetTotalNoOfJobDtls(int bid, int divid, DateTime from, DateTime to, string trantype,string strBy)
        {
            DataTable dt = new DataTable();
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@divid",SqlDbType.TinyInt),
                                                        new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                        new SqlParameter("@strBy",SqlDbType.VarChar ,5)};

            objp[0].Value = bid;
            objp[1].Value = divid;
            objp[2].Value = from;
            objp[3].Value = to;
            objp[4].Value = trantype;
            objp[5].Value = strBy;
            return ExecuteTable("SPGetTotalNoOfJobDetails", objp);
        }
        public DataTable SPGetTotalNoOfBLDetails(int bid, int divid, DateTime from, DateTime to, string trantype,string strBy)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@divid",SqlDbType.TinyInt),
                                                        new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                        new SqlParameter("@strBy",SqlDbType.VarChar ,5)};

            objp[0].Value = bid;
            objp[1].Value = divid;
            objp[2].Value = from;
            objp[3].Value = to;
            objp[4].Value = trantype;
            objp[5].Value = strBy;
            return ExecuteTable("SPGetTotalNoOfBLDetails", objp);
        }


        public DataTable SPGetTotalNoOfBLDetails4Job(int bid, int divid,int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@divid",SqlDbType.TinyInt),
                                                        new SqlParameter("@jobno",SqlDbType.Int ),                                                        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                        };

            objp[0].Value = bid;
            objp[1].Value = divid;
            objp[2].Value = jobno ;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetTotalNoOfBLDetails4Job", objp);
        }


        public DataSet GetTotalContDtls(int bid, int divid, DateTime from, DateTime to, string trantype,string strBy)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@divid",SqlDbType.TinyInt),
                                                        new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                        new SqlParameter("@strBy",SqlDbType.VarChar ,5)
                                                          };

            objp[0].Value = bid;
            objp[1].Value = divid;
            objp[2].Value = from;
            objp[3].Value = to;
            objp[4].Value = trantype;
            objp[5].Value = strBy;
            return ExecuteDataSet("SPGetContDtls", objp);
        }

    }
}
