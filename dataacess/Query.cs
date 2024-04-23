using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Query : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Query()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable FEJobno(int Jobno, int intBranchID)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Jobno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = Jobno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPQryFEJobNo", objp);
        }

        public DataTable FEMBLno(string MBLno, int intBranchID)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mblno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = MBLno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPQryFEMBLNo", objp);
        }

        public DataTable FEcontainerno(string containerno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@containerno", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = containerno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPQryFEContainerNo", objp);
        }

        public DataTable FIJobno(int Jobno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Jobno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = Jobno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPQryFIJobNo", objp);
        }

        public DataTable FILineno(string Lineno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@linenumber", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = Lineno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPQryFILineNo", objp);
        }

        public DataTable FIMBLno(string MBLno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mblno", SqlDbType.VarChar, 15), 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = MBLno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPQryFIMBLNo", objp);
        }

        public DataTable FIcontainerno(string containerno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@containerno", SqlDbType.VarChar, 12), 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = containerno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPQryFIContainerNo", objp);
        }

    }
}
