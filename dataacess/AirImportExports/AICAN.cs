using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.AirImportExports
{
    public class AICAN : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public AICAN()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetDetails(int branchid,int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value =branchid;
            objp[1].Value = cid;
            return ExecuteTable("SPSelAICAN", objp);
        }
        public void UpdateCANDate(DateTime candate, int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@candate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = candate;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPUpdAICANDate", objp);
        }
        public DataTable GetBLDetails(int jobno, string trantype, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.Char,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return ExecuteTable("SPSelAIEBLJobno", objp);
        }
        public bool CheckBLDetails(string blno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            Dt = ExecuteTable("SPSelAICANBL", objp);
            if (Dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public DataTable Getcanpromachek(string blno, int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar, 50),
                                                      
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 10)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
          
            return ExecuteTable("spcanpromachek", objp);
        }
    }
}
