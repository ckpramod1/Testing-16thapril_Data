using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class chequeApprovalAlert : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public chequeApprovalAlert()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable Fn_GetChequeAppRights(int int_bid, int int_Empid,string str_type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@type",SqlDbType.VarChar,2)};
            objp[0].Value = int_bid;
            objp[1].Value = int_Empid;
            objp[2].Value = str_type;
            Dt = ExecuteTable("Sp_GetChqAppRights", objp);
            return Dt;
        }

        public DataTable Fn_GetPendingChequeReq(int int_bid, int int_Vouyear, int int_divisionid, string Str_Type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.Int,4),
                                                    new SqlParameter("@Type",SqlDbType.VarChar,2)};
            objp[0].Value = int_bid;
            objp[1].Value = int_Vouyear;
            objp[2].Value = int_divisionid;
            objp[3].Value = Str_Type;
            Dt = ExecuteTable("SP_GetPendingChqReq", objp);
            return Dt;
        }
        public DataTable Fn_GetPendingChequeReqALL(int int_bid, int int_Vouyear, int int_divisionid, string Str_Type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.Int,4),
                                                    new SqlParameter("@Type",SqlDbType.VarChar,2)};
            objp[0].Value = int_bid;
            objp[1].Value = int_Vouyear;
            objp[2].Value = int_divisionid;
            objp[3].Value = Str_Type;
            Dt = ExecuteTable("SP_GetPendingChqReqALL", objp);
            return Dt;
        }
        public void Fn_UpdPendingChequeReq(int int_vouno, string strtype,int int_bid,int int_vouyear,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.Int),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                    new SqlParameter("@type",SqlDbType.VarChar,5),
                                                    new SqlParameter("@cid",SqlDbType.Int),};
            objp[0].Value = int_vouno;
            objp[1].Value = int_bid;
            objp[2].Value = int_vouyear;
            objp[3].Value = strtype;
            objp[4].Value = divisionid;
            ExecuteQuery("UpdatePendingChequeReq", objp);
        }
    }
}
