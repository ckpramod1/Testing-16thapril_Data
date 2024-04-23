using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
    public class BLDetailsWOJob : DBObject
    {
        int intPkgID;   //Package id

        Masters.MasterCustomer CustObj = new Masters.MasterCustomer();
        Masters.MasterPort PortObj = new Masters.MasterPort();
        Masters.MasterVessel VesselObj = new Masters.MasterVessel();
        Masters.MasterPackages PkgObj = new Masters.MasterPackages();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BLDetailsWOJob()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsBLWOJobDet(string strBLNo, DateTime datIssuedOn, int intIssudAtid, int intSprID, string strSprName, string strSprAdReader, int intCneeID, string strCneeName, string strCneeAdReader, int intNPtyID, string strNPtyName, string strNPtyAdReader, int intAgentID, int intCnfID, string strMN, string strDesc, double dblGrWt, double dblNtWt, double dblCBM, int intPackages, string strUnits, int intPORID, int intPOLID, int intPODID, int intFDID, string strFreight, int intSpmt, string strNomination, string strOurBL, string strSurd, string vessvoy, string container, string strRemarks, short shrtSign, char chrDGCargo, int intBranchID,int intDivisionID,int cargoid)
        {
            intPkgID = PkgObj.GetNPackageid(strUnits);
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@bldate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@blissuedt",SqlDbType.Int),
                                                         new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                         new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                         new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                         new SqlParameter("@consigneeid",SqlDbType.Int,4), 
                                                         new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                         new SqlParameter("@caddress",SqlDbType.VarChar,250),        
                                                         new SqlParameter("@notifypartyid",SqlDbType.Int,4), 
                                                         new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                         new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                         new SqlParameter("@deliveryagent",SqlDbType.Int,4),
                                                         new SqlParameter("@cnf",SqlDbType.Int,4),
                                                         new SqlParameter("@marks",SqlDbType.VarChar,1000), 
                                                         new SqlParameter("@descn",SqlDbType.VarChar,1000),                                                                                     
                                                         new SqlParameter("@grweight",SqlDbType.Real,4),
                                                         new SqlParameter("@ntweight",SqlDbType.Real,4),
                                                         new SqlParameter("@cbm",SqlDbType.Real,4),
                                                         new SqlParameter("@npkg",SqlDbType.Int),
                                                         new SqlParameter("@pkgid",SqlDbType.Int), 
                                                         new SqlParameter("@por",SqlDbType.Int),
                                                         new SqlParameter("@pol",SqlDbType.Int),        
                                                         new SqlParameter("@pod",SqlDbType.Int), 
                                                         new SqlParameter("@fd",SqlDbType.Int),
                                                         new SqlParameter("@freight",SqlDbType.VarChar,10),
                                                         new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                         new SqlParameter("@ourbl",SqlDbType.VarChar,1), 
                                                         new SqlParameter("@surrendered",SqlDbType.VarChar,1),
                                                         new SqlParameter("@vessvoy",SqlDbType.VarChar,40),
                                                         new SqlParameter("@container",SqlDbType.VarChar,44),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                         new SqlParameter("@sign",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@dgcargo",SqlDbType.VarChar,1), 
                                                         new SqlParameter("@cargoid",SqlDbType.Int),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                   };

            objp[0].Value = strBLNo;
            objp[1].Value = datIssuedOn;
            objp[2].Value = intIssudAtid;
            objp[3].Value = intSprID;
            objp[4].Value = strSprName;
            objp[5].Value = strSprAdReader;
            objp[6].Value = intCneeID;
            objp[7].Value = strCneeName;
            objp[8].Value = strCneeAdReader;
            objp[9].Value = intNPtyID;
            objp[10].Value = strNPtyName;
            objp[11].Value = strNPtyAdReader;
            objp[12].Value = intAgentID;
            objp[13].Value = intCnfID;
            objp[14].Value = strMN;
            objp[15].Value = strDesc;
            objp[16].Value = dblGrWt;
            objp[17].Value = dblNtWt;
            objp[18].Value = dblCBM;
            objp[19].Value = intPackages;
            objp[20].Value = intPkgID;
            objp[21].Value = intPORID;
            objp[22].Value = intPOLID;
            objp[23].Value = intPODID;
            objp[24].Value = intFDID;
            objp[25].Value = strFreight;
            objp[26].Value = intSpmt;
            objp[27].Value = strNomination;
            objp[28].Value = strOurBL;
            objp[29].Value = strSurd;
            objp[30].Value = vessvoy;
            objp[31].Value = container;
            objp[32].Value = strRemarks;
            objp[33].Value = shrtSign;
            objp[34].Value = chrDGCargo;
            objp[35].Value = cargoid;
            objp[36].Value = intBranchID;
            objp[37].Value = intDivisionID;
            ExecuteQuery("SPInsFEBLWOJob", objp);
        }

        public void UpdBLWOJobDet(string strBLNo, DateTime datIssuedOn, int intIssudAtid, int intSprID, string strSprName, string strSprAdReader, int intCneeID, string strCneeName, string strCneeAdReader, int intNPtyID, string strNPtyName, string strNPtyAdReader, int intAgentID, int intCnfID, string strMN, string strDesc, double dblGrWt, double dblNtWt, double dblCBM, int intPackages, string strUnits, int intPORID, int intPOLID, int intPODID, int intFDID, string strFreight, int intSpmt, string strNomination, string strOurBL, string strSurd, string vessvoy, string container, string strRemarks, short shrtSign, char chrDGCargo, int intBranchID, int cargoid, int intDivisionID)
        {
            intPkgID = PkgObj.GetNPackageid(strUnits);
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@bldate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@blissuedt",SqlDbType.Int),
                                                         new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                         new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                         new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                         new SqlParameter("@consigneeid",SqlDbType.Int,4), 
                                                         new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                         new SqlParameter("@caddress",SqlDbType.VarChar,250),        
                                                         new SqlParameter("@notifypartyid",SqlDbType.Int,4), 
                                                         new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                         new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                         new SqlParameter("@deliveryagent",SqlDbType.Int,4),
                                                         new SqlParameter("@cnf",SqlDbType.Int,4),
                                                         new SqlParameter("@marks",SqlDbType.VarChar,1000), 
                                                         new SqlParameter("@descn",SqlDbType.VarChar,1000),                                                                                     
                                                         new SqlParameter("@grweight",SqlDbType.Real,4),
                                                         new SqlParameter("@ntweight",SqlDbType.Real,4),
                                                         new SqlParameter("@cbm",SqlDbType.Real,4),
                                                         new SqlParameter("@npkg",SqlDbType.Int),
                                                         new SqlParameter("@pkgid",SqlDbType.Int), 
                                                         new SqlParameter("@por",SqlDbType.Int),
                                                         new SqlParameter("@pol",SqlDbType.Int),        
                                                         new SqlParameter("@pod",SqlDbType.Int), 
                                                         new SqlParameter("@fd",SqlDbType.Int),
                                                         new SqlParameter("@freight",SqlDbType.VarChar,10),
                                                         new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@nomination",SqlDbType.VarChar,5),
                                                         new SqlParameter("@ourbl",SqlDbType.VarChar,5), 
                                                         new SqlParameter("@surrendered",SqlDbType.VarChar,5),
                                                         new SqlParameter("@vessvoy",SqlDbType.VarChar,40),
                                                         new SqlParameter("@container",SqlDbType.VarChar,44),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                         new SqlParameter("@sign",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@dgcargo",SqlDbType.VarChar,1), 
                                                         new SqlParameter("@cargoid",SqlDbType.Int),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                   };

            objp[0].Value  = strBLNo;
            objp[1].Value  = datIssuedOn;
            objp[2].Value  = intIssudAtid;
            objp[3].Value  = intSprID;
            objp[4].Value  = strSprName;
            objp[5].Value  = strSprAdReader;
            objp[6].Value  = intCneeID;
            objp[7].Value  = strCneeName;
            objp[8].Value  = strCneeAdReader;
            objp[9].Value  = intNPtyID;
            objp[10].Value = strNPtyName;
            objp[11].Value = strNPtyAdReader;
            objp[12].Value = intAgentID;
            objp[13].Value = intCnfID;
            objp[14].Value = strMN;
            objp[15].Value = strDesc;
            objp[16].Value = dblGrWt;
            objp[17].Value = dblNtWt;
            objp[18].Value = dblCBM;
            objp[19].Value = intPackages;
            objp[20].Value = intPkgID;
            objp[21].Value = intPORID;
            objp[22].Value = intPOLID;
            objp[23].Value = intPODID;
            objp[24].Value = intFDID;
            objp[25].Value = strFreight;
            objp[26].Value = intSpmt;
            objp[27].Value = strNomination;
            objp[28].Value = strOurBL;
            objp[29].Value = strSurd;
            objp[30].Value = vessvoy;
            objp[31].Value = container;

            objp[32].Value = strRemarks;
            objp[33].Value = shrtSign;
            objp[34].Value = chrDGCargo;
            objp[35].Value = cargoid;

            objp[36].Value = intBranchID;
            objp[37].Value = intDivisionID;
            ExecuteQuery("SPUpdFEBLWOJob", objp);
        }


        public DataTable GetBLDetWOJob(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFEBLDetailWOJob", objp);
        }


        public DataTable GetLikeBLDetailsWOJ(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFEBLWOJ", objp);
        }


        public DataTable GeBLDetailsWOJ(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPSelFEBLDtsWoJ", objp);
        }



        public DataTable DelBLDetailsWOJ(string strBlno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPDelFEBLDtsWoJ", objp);
        }




        public DataTable UpdBLDetailsInvCostWOJ(string strBlno, int jobno, int agent, int jobtype, int cont20, int cont40, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                           new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                           new SqlParameter("@agent", SqlDbType.Int, 4),
                                                           new SqlParameter("@jobtype", SqlDbType.Int, 4),
                                                           new SqlParameter("@cont20", SqlDbType.Int, 30),
                                                           new SqlParameter("@cont40", SqlDbType.Int, 4)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = jobno;
            objp[3].Value = agent;
            objp[4].Value = jobtype;
            objp[5].Value = cont20;
            objp[6].Value = cont40;
            return ExecuteTable("SPUpdInvCostWoJ", objp);
        }
    }
}
