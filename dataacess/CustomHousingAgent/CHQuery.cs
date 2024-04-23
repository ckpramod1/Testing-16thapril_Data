using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CustomHousingAgent
{
    public class CHQuery : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CHQuery()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetQueryforJobno(int bid, int cid, int intjobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4)};

            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = intjobno;
            return ExecuteTable("SPGetCHQuerydtls", objp);
        }

        public DataTable GetQueryfordocno(string docno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{  new SqlParameter("@docno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)};

            objp[0].Value = docno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPCHQUeryfordocno", objp);
        }

        public DataTable GetQueryforEventdtls(int intjobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)};

            objp[0].Value = intjobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPCHQryEventdtls", objp);

        }

        public DataTable GetQueryforCustomers(int customerid, char customertype, int bid, int cid)
        {
            if (customertype == 'P')
            {
                customertype = 'P';
            }
            else
            {
                customertype = 'C';
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@customertype",SqlDbType.Char,1),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = customerid;
            objp[1].Value = customertype;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return ExecuteTable("SPCHQueryforCustomers", objp);

        }
    }
}

