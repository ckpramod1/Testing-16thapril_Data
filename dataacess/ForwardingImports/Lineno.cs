using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
    public class Lineno:DBObject
    {
        //Gets the details of all Job nos

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Lineno()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetJobDetails(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPFILineNo",objp);
        }



        //Get BL Details using jobno
        public DataTable GetBLDetails(int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@intjobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFILineDetails",objp);
        }


        //Update the line number using jobno and blno
        public void UpdateLineNumber(int jobno, string blno, string lineno, string sublineno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@lineno",SqlDbType.VarChar,5),
                                                         new SqlParameter("@sublineno",SqlDbType.VarChar,5),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = lineno;
            objp[3].Value = sublineno;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            ExecuteQuery("SPUpdFILineno",objp);
        }


        public void UpdateFILineNumber(int jobno, string blno, string lineno, string sublineno, string cargotype, string mmtype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@lineno",SqlDbType.VarChar,5),
                                                         new SqlParameter("@sublineno",SqlDbType.VarChar,5),
                                                         new SqlParameter("@cargotype",SqlDbType.VarChar,5),
                                                         new SqlParameter("@mmtype",SqlDbType.VarChar,5),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = lineno;
            objp[3].Value = sublineno;
            objp[4].Value = cargotype;
            objp[5].Value = mmtype;
            objp[6].Value = intBranchID;
            objp[7].Value = intDivisionID;
            ExecuteQuery("SPUpdLineno", objp);
        }

        public void UpdateFIBL(int jobno,int branchid,string blno,string Shippod)
        {
            SqlParameter[] objFbl = new SqlParameter[]{
                                             new SqlParameter("@jobno",SqlDbType.Int,4),
                                               new SqlParameter("@bid",SqlDbType.TinyInt),
                                             new SqlParameter("@blno",SqlDbType.VarChar,30),
                                             new SqlParameter("@Shippod",SqlDbType.VarChar,10)
                                             
            };
            objFbl[0].Value = jobno;
            objFbl[1].Value = branchid;
            objFbl[2].Value = blno;
            objFbl[3].Value = Shippod;
            ExecuteQuery("SpFblDetails", objFbl);
        }
    }
}
