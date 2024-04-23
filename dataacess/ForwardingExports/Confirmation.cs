using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
    public class Confirmation : DBObject
    {
        Masters.MasterCustomer CustObj = new Masters.MasterCustomer();
        Masters.MasterPort PortObj = new Masters.MasterPort();
        Masters.MasterVessel VesselObj = new Masters.MasterVessel();
        int intVslid;
        int intPODid;
        int intPOTid;


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Confirmation()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsConfirmDetails(string strBLNo, string strPOT, string strPOD, DateTime datETA, DateTime datETD, string strVslName, string strVoyage, char chrType, int intBranchID, int intDivisionID)
        {
            intPODid = PortObj.GetNPortid(strPOD);
            intPOTid = PortObj.GetNPortid(strPOT);
            intVslid = VesselObj.GetVesselid(strVslName);
            SqlParameter[] objp = new SqlParameter[] {    
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@pot",SqlDbType.Int), 
                                                         new SqlParameter("@pod",SqlDbType.Int),
                                                         new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@vessel",SqlDbType.Int),
                                                         new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                         new SqlParameter("@ftype",SqlDbType.Char,2),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBLNo;
            objp[1].Value = intPOTid;
            objp[2].Value = intPODid;
            objp[3].Value = datETA;
            objp[4].Value = datETD;
            objp[5].Value = intVslid;
            objp[6].Value = strVoyage;
            objp[7].Value = chrType;
            objp[8].Value = intBranchID;
            objp[9].Value = intDivisionID;
            ExecuteQuery("SPInsFEConfirmTS", objp);
        }

        public void UpdConfirmDetails(string strBLNo, string strPOT, string strPOD, DateTime datETA, DateTime datETD, string strVslName, string strVoyage, char chrType, int intBranchID, int intDivisionID)
        {
            intPODid = PortObj.GetNPortid(strPOD);
            intPOTid = PortObj.GetNPortid(strPOT);
            intVslid = VesselObj.GetVesselid(strVslName);
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@pot",SqlDbType.Int), 
                                                         new SqlParameter("@pod",SqlDbType.Int),
                                                         new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@vessel",SqlDbType.Int),
                                                         new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                         new SqlParameter("@ftype",SqlDbType.Char,2),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBLNo;
            objp[1].Value = intPOTid;
            objp[2].Value = intPODid;
            objp[3].Value = datETA;
            objp[4].Value = datETD;
            objp[5].Value = intVslid;
            objp[6].Value = strVoyage;
            objp[7].Value = chrType;
            objp[8].Value = intBranchID;
            objp[9].Value = intDivisionID;
            ExecuteQuery("SPUpdFEConfirmTS", objp);
        }




        public DataTable GetConfirmDetails(string strBLNo, string chrType, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@ftype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBLNo;
            objp[1].Value = chrType;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelFEConfirmTS", objp);
        }


    }
}
