using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.DashBoard
{
    public class Bottom : DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }


        public Bottom()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable BLDetails(string strBlno, string strTrantype,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30), 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
            objp[0].Value = branchid;
            objp[1].Value = strBlno;
            objp[2].Value = strTrantype;

            if ((strTrantype == "AE") || (strTrantype == "AI"))
            {
                Dt = ExecuteTable("SPAIEBLDetails", objp);
            }
            else if ((strTrantype == "FE") || (strTrantype == "FI"))
            {
                Dt = ExecuteTable("SPFIEBLDt", objp);
            }
            else
            {
                Dt = ExecuteTable("SPCHADt", objp);
            }
            return Dt;
        }

        public DataTable CHEventDt(string strDocno,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@docno", SqlDbType.VarChar, 30)};
            objp[0].Value = branchid;
            objp[1].Value = strDocno;
            return ExecuteTable("SPCHAEventDt", objp); ;
        }
        public DataTable GetBotInvPACust(string custname, int vouyear, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custname",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@vouyear",SqlDbType.Int), 
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1), 
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = custname;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetBotInvPACust", objp);
        }
        public DataTable GetInvPACustDetails(int customerid, int vouyear, int branchid, string trantype, string ftype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@vouyear",SqlDbType.Int), 
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1), 
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,2)};
            objp[0].Value = customerid;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = ftype;
            return ExecuteTable("SPGetInvPACustDetails", objp);
        }       
    }
}
