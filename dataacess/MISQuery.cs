using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MISQuery : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MISQuery()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable MISQShowJobInfo(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@ftype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@cbm",SqlDbType.Real,8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = ftype;
            objp[3].Value = cbm;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            return ExecuteTable("SPSelMISQJobInfo", objp);
        }

        public DataTable MISQGetLikeFEFILikeBL(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {     
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelMISQFEFILikeBL", objp);
        }

        public DataTable MISQGetLikeBookingNo(string bookingno, int intDivID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = intDivID;
            return ExecuteTable("SPSelMISQLikeBookNo", objp);
        }

        public DataTable MISQGetLikeFBLWOCJob(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelMISQLikeFIFBLWOCJob", objp);
        }


        public DataTable MISQGetLikeCusblon(string invoiceno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@invoiceno",SqlDbType.VarChar,10),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)

                                                    };
            objp[0].Value = invoiceno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelMISQLikeCusInvno", objp);
        }

        public DataTable MISQGetLikeFEFIMBLNo(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mblno", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelMISQLikeFEFIMBLNo", objp);
        }

        public DataTable MISQGetLikeContno(string strContno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@containerno", SqlDbType.VarChar, 10),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strContno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelMISQFEFILikeContno", objp);
        }


        public DataTable MISQGetLikeShipBill(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelMISQLikeShipBill", objp);
        }

    }
}
