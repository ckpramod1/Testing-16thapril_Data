using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ForwardingExports
{
    public class FETentativeTS:DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FETentativeTS()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetDetailsFromJob(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelDetailsFETenTSJob", objp);
        }


        public void InsFETenTS(string strblno, int pot, int pod, DateTime eta, DateTime etb, int vesselid, string voyage, int intBranchID, int intDivisionID)       
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@pot",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@vesselid",SqlDbType.Int),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strblno;
            objp[1].Value = pot;
            objp[2].Value = pod;
            objp[3].Value = eta;
            objp[4].Value = etb;
            objp[5].Value = vesselid;
            objp[6].Value = voyage;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivisionID;
            ExecuteQuery("SPInsFETenTS", objp);
        } 
        public void InsFEConTS(string strblno, int pot, int pod, DateTime eta, DateTime etb, int vesselid, string voyage, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@pot",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@vesselid",SqlDbType.Int),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strblno;
            objp[1].Value = pot;
            objp[2].Value = pod;
            objp[3].Value = eta;
            objp[4].Value = etb;
            objp[5].Value = vesselid;
            objp[6].Value = voyage;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivisionID;
            ExecuteQuery("SPInsFEConTS", objp);
        }



        public void UpdFETenTS(string strblno, int pot, int pod, DateTime eta, DateTime etb, int vesselid, string voyage, int oldpotid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@pot",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@vesselid",SqlDbType.Int),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@oldpotid",SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = strblno;
            objp[1].Value = pot;
            objp[2].Value = pod;
            objp[3].Value = eta;
            objp[4].Value = etb;
            objp[5].Value = vesselid;
            objp[6].Value = voyage;
            objp[7].Value = oldpotid;
            objp[8].Value = intBranchID;
            objp[9].Value = intDivisionID;
            ExecuteQuery("SPUpdFETenTS", objp);
        }






        public void UpdFEConTS(string strblno, int pot, int pod, DateTime eta, DateTime etb, int vesselid, string voyage, int oldpotid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@pot",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@etb",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@vesselid",SqlDbType.Int),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@oldpotid",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strblno;
            objp[1].Value = pot;
            objp[2].Value = pod;
            objp[3].Value = eta;
            objp[4].Value = etb;
            objp[5].Value = vesselid;
            objp[6].Value = voyage;
            objp[7].Value = oldpotid;
            objp[8].Value = intBranchID;
            objp[9].Value = intDivisionID;
            ExecuteQuery("SPUpdFEConTS", objp);
        }




        public DataTable GetDetailsFromFETents(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFETenTS", objp);
        }




        public DataTable GetDetailsFromFEConTS(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]  
                                                    {
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFEConTS", objp);
        }




        public DataTable CheckFETenTSPOT(string strBlno, int potid, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@oldpotid",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = potid;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPCheckFETenTS", objp);
        }



        public DataTable CheckFEConTSPOT(string strBlno, int potid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@oldpotid",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = potid;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPCheckFEConTS", objp);
        }


        public void insFEConTSfromFETenTS(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID ;
            objp[2].Value = intDivisionID;
            ExecuteQuery("SPInsFEConTSfromFETenTS", objp);
        }


    }
}
