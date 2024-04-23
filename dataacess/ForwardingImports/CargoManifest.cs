using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
    public class CargoManifest:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CargoManifest()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetCargoJobDts(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]   { 
                                                            new SqlParameter("@bid",SqlDbType.TinyInt),
                                                            new SqlParameter("@cid",SqlDbType.TinyInt)
                                                       };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPCargoManiFestJobDt", objp);
        }

        public DataTable GetCargoBLDts(int jobno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]   { 
                                                            new SqlParameter("@jobno", SqlDbType.Int,4),
                                                            new SqlParameter("@bid",SqlDbType.TinyInt),
                                                            new SqlParameter("@cid",SqlDbType.TinyInt)
                                                       };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPCargoManifestBLDts", objp);
        }


        public DataTable Getpanno4igm(int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]   { 
                                                            
                                                            new SqlParameter("@branchid",SqlDbType.TinyInt)
                                                       };
            objp[0].Value = intBranchID;

            return ExecuteTable("spGetpanno4igm", objp);
        }
        public DataTable Getportcode4igm(int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]   { 
                                                            
                                                            new SqlParameter("@branchid",SqlDbType.TinyInt)
                                                       };
            objp[0].Value = intBranchID;

            return ExecuteTable("spGetportcode4igm", objp);
        }
    }
}
