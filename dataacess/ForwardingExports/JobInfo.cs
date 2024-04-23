using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using DataAccess.Marketing;

namespace DataAccess.ForwardingExports
{
    public class JobInfo : DBObject
    {
        Masters.MasterCustomer CustObj = new Masters.MasterCustomer();
        Masters.MasterPort PortObj = new Masters.MasterPort();
        Masters.MasterVessel VesselObj = new Masters.MasterVessel();
        Masters.MasterPackages PkgObj = new Masters.MasterPackages();



        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public JobInfo()
        {
            Conn = new SqlConnection(DBCS);
        }

        //public int InsertJoboinfo(int intVslid, int intLoadPort, int intDestPort, string strEMNo, string strVoyage, DateTime datETD, DateTime datETA, DateTime datEMdate, int intSpmtDest, int intMLO, int intAgent, string strMBLNo, int intJobType, DateTime jobdate, char chrContract, int intBranchID, DateTime stuffedon, string mblstatus, int PreparedBy, string remarks, int intDivisionID)
        //{
        //    char seawaybl = 'Y';
        //    int closedjob = 0;
        //    SqlParameter[] objp = new SqlParameter[] {
        //                                                 new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
        //                                                 new SqlParameter("@vesselid",SqlDbType.Int),        
        //                                                 new SqlParameter("@voyage",SqlDbType.VarChar,15), 
        //                                                 new SqlParameter("@agent",SqlDbType.Int,4),
        //                                                 new SqlParameter("@mlo",SqlDbType.Int,4),
        //                                                 new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@pol",SqlDbType.Int), 
        //                                                 new SqlParameter("@pod",SqlDbType.Int),
        //                                                 new SqlParameter("@fd",SqlDbType.Int),        
        //                                                 new SqlParameter("@mblno",SqlDbType.VarChar,30), 
        //                                                 new SqlParameter("@emno",SqlDbType.VarChar,25),
        //                                                 new SqlParameter("@emdate",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@seawaybl",SqlDbType.Char,2),
        //                                                 new SqlParameter("@closedjob",SqlDbType.Char,2),
        //                                                 new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@contract",SqlDbType.Char,1),
        //                                                 new SqlParameter("@stuffedon",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@mblstatus",SqlDbType.Char,1),
        //                                                 new SqlParameter("@preparedby",SqlDbType.Int), 
        //                                                 new SqlParameter("@remarks",SqlDbType.VarChar,250),
        //                                                 new SqlParameter("@bid", SqlDbType.TinyInt),
        //                                                 new SqlParameter("@cid", SqlDbType.TinyInt),
        //                                                 new SqlParameter("@jobno",SqlDbType.Int,4)
        //                                             };
        //    objp[0].Value = intJobType;
        //    objp[1].Value = intVslid;
        //    objp[2].Value = strVoyage;
        //    objp[3].Value = intAgent;
        //    objp[4].Value = intMLO;
        //    objp[5].Value = datETD;
        //    objp[6].Value = datETA;
        //    objp[7].Value = intLoadPort;
        //    objp[8].Value = intDestPort;
        //    objp[9].Value = intSpmtDest;
        //    objp[10].Value = strMBLNo;
        //    objp[11].Value = strEMNo;
        //    objp[12].Value = datEMdate;
        //    objp[13].Value = seawaybl;
        //    objp[14].Value = closedjob;
        //    objp[15].Value = jobdate;
        //    objp[16].Value = chrContract;
        //    objp[17].Value = stuffedon;
        //    objp[18].Value = mblstatus;
        //    objp[19].Value = PreparedBy;
        //    objp[20].Value = remarks;
        //    objp[21].Value = intBranchID;
        //    objp[22].Value = intDivisionID;
        //    objp[23].Direction = ParameterDirection.Output;
        //    //ExecuteQuery("SPInsFEJob", objp);
        //    //return GetJobNo(strMBLNo, intBranchID, intDivisionID);
        //    return ExecuteQuery("SPInsFEJob", objp, "@jobno");
        //}

      

        public int InsertJoboinfo(int intVslid, int intLoadPort, int intDestPort, string strEMNo, string strVoyage, DateTime datETD, DateTime datETA, DateTime datEMdate, int intSpmtDest, int intMLO, int intAgent, string strMBLNo, int intJobType, DateTime jobdate, char chrContract, int intBranchID, DateTime stuffedon, string mblstatus, int PreparedBy, string remarks, int intDivisionID, DateTime lbdate)
        {
            char seawaybl = 'Y';
            int closedjob = 0;
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@vesselid",SqlDbType.Int),
                                                         new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                         new SqlParameter("@agent",SqlDbType.Int,4),
                                                         new SqlParameter("@mlo",SqlDbType.Int,4),
                                                         new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@pol",SqlDbType.Int),
                                                         new SqlParameter("@pod",SqlDbType.Int),
                                                         new SqlParameter("@fd",SqlDbType.Int),
                                                         new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@emno",SqlDbType.VarChar,25),
                                                         new SqlParameter("@emdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@seawaybl",SqlDbType.Char,2),
                                                         new SqlParameter("@closedjob",SqlDbType.Char,2),
                                                         new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@contract",SqlDbType.Char,1),
                                                         new SqlParameter("@stuffedon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@mblstatus",SqlDbType.Char,1),
                                                         new SqlParameter("@preparedby",SqlDbType.Int),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,250),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                   new SqlParameter("@lbdate",SqlDbType.SmallDateTime,4)
                                                     };
            objp[0].Value = intJobType;
            objp[1].Value = intVslid;
            objp[2].Value = strVoyage;
            objp[3].Value = intAgent;
            objp[4].Value = intMLO;
            objp[5].Value = datETD;
            objp[6].Value = datETA;
            objp[7].Value = intLoadPort;
            objp[8].Value = intDestPort;
            objp[9].Value = intSpmtDest;
            objp[10].Value = strMBLNo;
            objp[11].Value = strEMNo;
            objp[12].Value = datEMdate;
            objp[13].Value = seawaybl;
            objp[14].Value = closedjob;
            objp[15].Value = jobdate;
            objp[16].Value = chrContract;
            objp[17].Value = stuffedon;
            objp[18].Value = mblstatus;
            objp[19].Value = PreparedBy;
            objp[20].Value = remarks;
            objp[21].Value = intBranchID;
            objp[22].Value = intDivisionID;
            objp[23].Direction = ParameterDirection.Output;
            objp[24].Value = lbdate;
            //ExecuteQuery("SPInsFEJob", objp);
            //return GetJobNo(strMBLNo, intBranchID, intDivisionID);
            return ExecuteQuery("SPInsFEJob", objp, "@jobno");
        }
        public void InsContDetails(int intJbNo, string strContNo, string strSizeType, string strSealNo, string strBLNo, int pkgs, double wt, int intBranchID, int intDivisionID)
        {
            //int pkgid = 0;
            //pkgid = PkgObj.GetNPackageid(pkgs);
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                          new SqlParameter("@jobno",SqlDbType.Int),
                                                          new SqlParameter("@containerno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                          new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@pkg",SqlDbType.Int,4),
                                                          new SqlParameter("@wt",SqlDbType.Real,4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intJbNo;
            objp[1].Value = strContNo;
            objp[2].Value = strSizeType;
            objp[3].Value = strSealNo;
            objp[4].Value = strBLNo;
            objp[5].Value = pkgs;
            objp[6].Value = wt;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivisionID;
            ExecuteQuery("SPInsFEContainer", objp);
        }

        public void InsContDetail(int intJbNo, string strContNo, string strSizeType, string strSealNo, string strBLNo, int pkgs, double wt, int intBranchID, int intDivisionID, DateTime datCRO)
        {
            //int pkgid = 0;
            //pkgid = PkgObj.GetNPackageid(pkgs);
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                          new SqlParameter("@jobno",SqlDbType.Int),
                                                          new SqlParameter("@containerno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                          new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@pkg",SqlDbType.Int,4),
                                                          new SqlParameter("@wt",SqlDbType.Real,4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@crodate",SqlDbType.SmallDateTime,4)
                                                     };
            objp[0].Value = intJbNo;
            objp[1].Value = strContNo;
            objp[2].Value = strSizeType;
            objp[3].Value = strSealNo;
            objp[4].Value = strBLNo;
            objp[5].Value = pkgs;
            objp[6].Value = wt;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivisionID;
            objp[9].Value = datCRO;
            ExecuteQuery("SPInsFEContainer", objp);
        }

        //public void UpdateFEJobInfo(int intVslid, int intLoadPort, int intDestPort, string strEMNo, string strVoyage, DateTime datETD, DateTime datETA, DateTime datEMdate, int intSpmtDest, int intMLO, int intAgent, string strMBLNo, int intJobType, int intjbNo, DateTime jobdate, char chrContract, int intBranchID, DateTime stuffedon, string mblstatus, string remarks, int intDivisionID)
        //{
        //    char seawaybl = 'Y';
        //    int closedjob = 0;
        //    SqlParameter[] objp = new SqlParameter[] {
        //                                                 new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
        //                                                 new SqlParameter("@vesselid",SqlDbType.Int),        
        //                                                 new SqlParameter("@voyage",SqlDbType.VarChar,15), 
        //                                                 new SqlParameter("@agent",SqlDbType.Int,4),
        //                                                 new SqlParameter("@mlo",SqlDbType.Int,4),
        //                                                 new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@pol",SqlDbType.Int), 
        //                                                 new SqlParameter("@pod",SqlDbType.Int),
        //                                                 new SqlParameter("@fd",SqlDbType.Int),        
        //                                                 new SqlParameter("@mblno",SqlDbType.VarChar,30), 
        //                                                 new SqlParameter("@emno",SqlDbType.VarChar,25),
        //                                                 new SqlParameter("@emdate",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@seawaybl",SqlDbType.Char,2),
        //                                                 new SqlParameter("@closedjob",SqlDbType.Char,2),
        //                                                 new SqlParameter("@jobno",SqlDbType.Int,4),
        //                                                 new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@contract",SqlDbType.Char,1),
        //                                                 new SqlParameter("@stuffedon",SqlDbType.SmallDateTime,4),
        //                                                 new SqlParameter("@mblstatus",SqlDbType.Char,1), 
        //                                                 new SqlParameter("@remarks",SqlDbType.VarChar,250),
        //                                                 new SqlParameter("@bid", SqlDbType.TinyInt),
        //                                                 new SqlParameter("@cid", SqlDbType.TinyInt)
        //                                            };

        //    objp[0].Value = intJobType;
        //    objp[1].Value = intVslid;
        //    objp[2].Value = strVoyage;
        //    objp[3].Value = intAgent;
        //    objp[4].Value = intMLO;
        //    objp[5].Value = datETD;
        //    objp[6].Value = datETA;
        //    objp[7].Value = intLoadPort;
        //    objp[8].Value = intDestPort;
        //    objp[9].Value = intSpmtDest;
        //    objp[10].Value = strMBLNo;
        //    objp[11].Value = strEMNo;
        //    objp[12].Value = datEMdate;
        //    objp[13].Value = seawaybl;
        //    objp[14].Value = closedjob;
        //    objp[15].Value = intjbNo;
        //    objp[16].Value = jobdate;
        //    objp[17].Value = chrContract;
        //    objp[18].Value = stuffedon;
        //    objp[19].Value = mblstatus;
        //    objp[20].Value = remarks;
        //    objp[21].Value = intBranchID;
        //    objp[22].Value = intDivisionID;
        //    ExecuteQuery("SPUpdFEJob", objp);
        //}
        public void UpdateFEJobInfo(int intVslid, int intLoadPort, int intDestPort, string strEMNo, string strVoyage, DateTime datETD, DateTime datETA, DateTime datEMdate, int intSpmtDest, int intMLO, int intAgent, string strMBLNo, int intJobType, int intjbNo, DateTime jobdate, char chrContract, int intBranchID, DateTime stuffedon, string mblstatus, string remarks, int intDivisionID, DateTime lbdate)
        {
            char seawaybl = 'Y';
            int closedjob = 0;
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@jobtype",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@vesselid",SqlDbType.Int),
                                                         new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                         new SqlParameter("@agent",SqlDbType.Int,4),
                                                         new SqlParameter("@mlo",SqlDbType.Int,4),
                                                         new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@pol",SqlDbType.Int),
                                                         new SqlParameter("@pod",SqlDbType.Int),
                                                         new SqlParameter("@fd",SqlDbType.Int),
                                                         new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@emno",SqlDbType.VarChar,25),
                                                         new SqlParameter("@emdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@seawaybl",SqlDbType.Char,2),
                                                         new SqlParameter("@closedjob",SqlDbType.Char,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@contract",SqlDbType.Char,1),
                                                         new SqlParameter("@stuffedon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@mblstatus",SqlDbType.Char,1),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,250),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                     new SqlParameter("@lbdate",SqlDbType.SmallDateTime,4)
                                                    };

            objp[0].Value = intJobType;
            objp[1].Value = intVslid;
            objp[2].Value = strVoyage;
            objp[3].Value = intAgent;
            objp[4].Value = intMLO;
            objp[5].Value = datETD;
            objp[6].Value = datETA;
            objp[7].Value = intLoadPort;
            objp[8].Value = intDestPort;
            objp[9].Value = intSpmtDest;
            objp[10].Value = strMBLNo;
            objp[11].Value = strEMNo;
            objp[12].Value = datEMdate;
            objp[13].Value = seawaybl;
            objp[14].Value = closedjob;
            objp[15].Value = intjbNo;
            objp[16].Value = jobdate;
            objp[17].Value = chrContract;
            objp[18].Value = stuffedon;
            objp[19].Value = mblstatus;
            objp[20].Value = remarks;
            objp[21].Value = intBranchID;
            objp[22].Value = intDivisionID;
            objp[23].Value = lbdate;
            ExecuteQuery("SPUpdFEJob", objp);
        }
        public void UpdateFEEventShiprefno(string shiprefno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = shiprefno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventjobblno(int jobno, string shiprefno, string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = blno;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvent", objp);
        }

        public void UpdateFEEventjobno(int jobno, string shiprefno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventStuff(string shiprefno, DateTime stuffsenton, int intBranchID, int sentby, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                   {
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@stuffsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt),
                                                         new SqlParameter("@sentby",SqlDbType.Int)
                                                   };

            objp[0].Value = shiprefno;
            objp[1].Value = stuffsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = sentby;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventlcsenton(string shiprefno, DateTime lcsenton, int intBranchID, int sentby, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                   {
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@lcsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt),
                                                         new SqlParameter("@sentby",SqlDbType.Int)
                                                   };

            objp[0].Value = shiprefno;
            objp[1].Value = lcsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = sentby;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventinvplrecon(string shiprefno, DateTime invplrecon, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@invplrecon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = shiprefno;
            objp[1].Value = invplrecon;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventprealertsenton(string shiprefno, DateTime prealertsenton, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@prealertsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = shiprefno;
            objp[1].Value = prealertsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventdocssenton(string shiprefno, DateTime docssenton, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@docssenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = shiprefno;
            objp[1].Value = docssenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventtssenton(string blno, DateTime tssenton, int intBranchID, int sentby, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@tssenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt),
                                                         new SqlParameter("@sentby",SqlDbType.Int)
                                                     };

            objp[0].Value = blno;
            objp[1].Value = tssenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = sentby;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventdrsenton(string blno, DateTime drsenton, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@drsenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = blno;
            objp[1].Value = drsenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvent", objp);
        }
        public void UpdateFEEventdssenton(string blno, DateTime dssenton, int intBranchID, int sentby, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@dssenton",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt),
                                                         new SqlParameter("@sentby",SqlDbType.Int)
                                                     };

            objp[0].Value = blno;
            objp[1].Value = dssenton;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = sentby;
            ExecuteQuery("SPUpdFEEvent", objp);
        }

        public void updateContDetails(int intJbNo, string strBLNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid",SqlDbType.TinyInt),
                                                          new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPDelFEContDetails", objp);
        }

        public void DeleteContDetails(int intJbNo, string containerno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                          new SqlParameter("@bid",SqlDbType.TinyInt),
                                                          new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };

            objp[0].Value = intJbNo;
            objp[1].Value = containerno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPDelFEContDts", objp);
        }

        //public void UpdContDetails(int intJbNo, string strBLNo, string strContNo, string strSztype, string strSlNo, string strContNo1, int pkgs, double wt, int intBranchID, int intDivisionID)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //                                                 new SqlParameter("@jobno",SqlDbType.Int,4),
        //                                                 new SqlParameter("@blno",SqlDbType.VarChar,30),        
        //                                                 new SqlParameter("@containerno",SqlDbType.VarChar,12), 
        //                                                 new SqlParameter("@sizetype",SqlDbType.VarChar,6),
        //                                                 new SqlParameter("@sealno",SqlDbType.VarChar,12),
        //                                                 new SqlParameter("@containerno1",SqlDbType.VarChar,12),
        //                                                 new SqlParameter("@pkg",SqlDbType.Int),
        //                                                 new SqlParameter("@wt",SqlDbType.Real,4),
        //                                                 new SqlParameter("@bid", SqlDbType.TinyInt),
        //                                                 new SqlParameter("@cid", SqlDbType.TinyInt)
        //                                              };
        //    objp[0].Value = intJbNo;
        //    objp[1].Value = strBLNo;
        //    objp[2].Value = strContNo;
        //    objp[3].Value = strSztype;
        //    objp[4].Value = strSlNo;
        //    objp[5].Value = strContNo1;
        //    objp[6].Value = pkgs;
        //    objp[7].Value = wt;
        //    objp[8].Value = intBranchID;
        //    objp[9].Value = intDivisionID;
        //    ExecuteQuery("SPUpdFEContDetails", objp);
        //}

        public void UpdContDetails(int intJbNo, string strBLNo, string strContNo, string strSztype, string strSlNo, string strContNo1, int pkgs, double wt, int intBranchID, int intDivisionID, DateTime datCRO)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                         new SqlParameter("@sealno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@containerno1",SqlDbType.VarChar,12),
                                                         new SqlParameter("@pkg",SqlDbType.Int,4),
                                                         new SqlParameter("@wt",SqlDbType.Real,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                  new SqlParameter("@crodate",SqlDbType.SmallDateTime,4)
                                                      };
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = strContNo;
            objp[3].Value = strSztype;
            objp[4].Value = strSlNo;
            objp[5].Value = strContNo1;
            objp[6].Value = pkgs;
            objp[7].Value = wt;
            objp[8].Value = intBranchID;
            objp[9].Value = intDivisionID;
            objp[10].Value = datCRO;
            ExecuteQuery("SPUpdFEContDetails", objp);
        }



        public void UpdateContDetails(int intJbNo, string strBLNo, string strContNo, string strSztype, string strSlNo, int pkgs, double wt, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                         new SqlParameter("@sealno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@pkg",SqlDbType.Int),
                                                         new SqlParameter("@wt",SqlDbType.Real,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = strContNo;
            objp[3].Value = strSztype;
            objp[4].Value = strSlNo;
            objp[5].Value = pkgs;
            objp[6].Value = wt;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivisionID;
            ExecuteQuery("SPUpdateFEContDetails", objp);
        }

        public int GetJobNo(string strMBLNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                            new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                            new SqlParameter("@bid", SqlDbType.TinyInt),
                                                            new SqlParameter("@cid", SqlDbType.TinyInt)
                                                      };
            objp[0].Value = strMBLNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return int.Parse(ExecuteReader("SPFEJobno", objp));
        }

        public DataTable GetJobNoList(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPFEQery", objp);
        }

        public DataTable GetFEJobInfo(int intjbno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno", SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intjbno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFEQryJobinfo", objp);
        }

        public DataTable GetFIJobInfo(int intjbno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno", SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intjbno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFIQryJobinfo", objp);
        }


        public DataTable GetINVPLDocsDts(string datetype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@datetype",SqlDbType.VarChar,5),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = datetype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPGetINVPLDocsDts", objp);
        }

        public DataTable GetContainerDetails(int intJbNo, string strBLNo, int intBranchid, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = intBranchid;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPFEContainers", objp);
        }


        public DataTable GetContainerDetailsFI(int intJbNo, string strBLNo, int intBranchid, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = intBranchid;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPFIContainers", objp);
        }

        //Convert shipment type from numeric to string
        public string setSpmtType(int intSpmtType)
        {
            string strTemp = "";
            switch (intSpmtType)
            {
                case 1:
                    strTemp = "Consol";
                    break;
                case 2:
                    strTemp = "Co-Load";
                    break;
                case 3:
                    strTemp = "FCL";
                    break;
                case 4:
                    strTemp = "Buyer Consol";
                    break;
                case 5:
                    strTemp = "MCC";
                    break;
            }
            return strTemp;
        }


        //Converting shipment type from string to numeric
        public int getSpmtType(string strSpmtType)
        {
            int intTemp = 0;
            switch (strSpmtType)
            {
                case "Consol":
                    intTemp = 1;
                    break;
                case "Co-Load":
                    intTemp = 2;
                    break;
                case "FCL":
                    intTemp = 3;
                    break;
                case "Buyer Consol":
                    intTemp = 4;
                    break;
                case "MCC":
                    intTemp = 5;
                    break;
            }
            return intTemp;
        }

        public DataTable GetOTHERFEJobInfoMBL(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeOTHERJobMBL", objp);
        }


        public DataTable GetFEJobInfoMBL(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@mblno", SqlDbType.VarChar,150),
                                                           new SqlParameter("@bid", SqlDbType.Int),
                                                           new SqlParameter("@cid", SqlDbType.Int)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeJobMBL", objp);
        }


        public DataTable GetFEJobInfoMBLWOClosedJob(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeJobMBLWOClosedJob", objp);
        }


        public DataTable GetContDetails(int jobno, string ContainerNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno", SqlDbType.Int,4),
                                                           new SqlParameter("@contno", SqlDbType.VarChar,12),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = ContainerNo;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelContDetails", objp);
        }


        public DataTable GetEventBtwJobdates(int intBranchID, string trantype, DateTime fromdate, DateTime todate, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPSelEventbtwdates", objp);
        }
        public DataTable GetFEBookStuff(int intBranchID, int intDivisionID, DateTime FromDate, DateTime ToDate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            objp[2].Value = FromDate;
            objp[3].Value = ToDate;
            return ExecuteTable("SpSelBooking4grd", objp);
        }


        public DataTable GetFEEventTracking(int intBranchID, string fvalue, string svalue, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@fvalue",SqlDbType.VarChar,30),
                                                       new SqlParameter("@svalue",SqlDbType.Char,1),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = fvalue;
            objp[1].Value = svalue;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelFEEventTracking1", objp);
        }

        public void UpdEventdtls(int intBranchID, DateTime eventdate, string type, char ack, string remarks, string bkgno, int sentby, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                         new SqlParameter("@eventdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@type",SqlDbType.VarChar,50),
                                                         new SqlParameter("@ack",SqlDbType.Char,1),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,200),
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@sentby",SqlDbType.Int),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = eventdate;
            objp[1].Value = type;
            objp[2].Value = ack;
            objp[3].Value = remarks;
            objp[4].Value = bkgno;
            objp[5].Value = sentby;
            objp[6].Value = intBranchID;
            objp[7].Value = intDivisionID;
            ExecuteQuery("SPUpdFEEvents2", objp);
        }


        public DataTable FillFollowup(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPSelEventsforfollowdate", objp);
        }


        public DataTable Geteventsforfollowupdates(int intBranchID, DateTime eventdate, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                           new SqlParameter("@nextfollowup",SqlDbType.DateTime),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = eventdate;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFEEventforFollowup", objp);
        }

        //FEDocmail
        public void Upddocsentby(int intbranchid, int jobno, string bkgno, int empid, int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[]{
                                                      new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = bkgno;
            objp[2].Value = empid;
            objp[3].Value = intbranchid;
            objp[4].Value = divisionid;
            ExecuteQuery("SPUpddocsentby", objp);
        }

        public DataTable GridFillJobdtlsForEvnttrack(string strTranType, int branchid, int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strTranType;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPJobDtlsforEvntTrk", objp);
        }
        //salquery
        public DataTable GetSalesFEJobInfoMBL(string mblno, int salesid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                           new SqlParameter ("@salesid",SqlDbType.Int ,4),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = salesid;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPLikeSalesJobMBL", objp);
        }
        public DataTable GridFillContainerDtls(int bid, int flag)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       //new SqlParameter("@pickedon", SqlDbType.DateTime ,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@flag", SqlDbType.TinyInt,1)

                                                     };
            // objp[0].Value = pickedon;
            objp[0].Value = bid;
            objp[1].Value = flag;

            return ExecuteTable("SPContainerDtls", objp);
        }
        public DataTable SelContainerDtls(string containerno, int bid, int flag, string vesselname, string mblno)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@containerno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                 new SqlParameter("@flag", SqlDbType.TinyInt,1),
                new SqlParameter("@vesselname", SqlDbType.VarChar,30),
                new SqlParameter("@mblno", SqlDbType.VarChar,30)

                                                     };
            objp[0].Value = containerno;
            objp[1].Value = bid;
            objp[2].Value = flag;
            objp[3].Value = vesselname;
            objp[4].Value = mblno;

            return ExecuteTable("SPSelContainerDtls", objp);
        }

        public DataTable UpdContPickerOn(int jobno, string containerno, string sizetype, DateTime pickedon, int bid, int flag)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@containerno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@sizetype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@pickedon", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@flag", SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = containerno;
            objp[2].Value = sizetype;
            objp[3].Value = pickedon;
            objp[4].Value = bid;
            objp[5].Value = flag;
            return ExecuteTable("SPUpdContPickedOn", objp);
        }
        public DataTable GetLikeContainerno(string containerno, int bid, int flag)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@containerno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@flag", SqlDbType.TinyInt,1)

                                                     };
            objp[0].Value = containerno;
            objp[1].Value = bid;
            objp[2].Value = flag;
            return ExecuteTable("SPLikeContainerno", objp);
        }
        public DataTable GetLikemblno(string mblno, int bid, int flag)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                         new SqlParameter("@flag", SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = bid;
            objp[2].Value = flag;
            return ExecuteTable("SPLikeMblno", objp);
        }
        public DataTable GetLikeVessel(string vesselname, int bid, int flag)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@txtVessel", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                         new SqlParameter("@flag", SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = vesselname;
            objp[1].Value = bid;
            objp[2].Value = flag;
            return ExecuteTable("SPGetLikeVessel", objp);
        }
        public DataTable GetLikembl(string mblno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                     // new SqlParameter("@flag", SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = bid;
            // objp[2].Value = flag;
            return ExecuteTable("SPLikeMBL", objp);
        }

        public DataTable GetLikemlo(string mlo, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@customername", SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      //new SqlParameter("@flag", SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = mlo;
            objp[1].Value = bid;
            // objp[2].Value = flag;
            return ExecuteTable("SPLikemlo", objp);
        }


        public DataTable GetMBlDrafsSentOnPending(int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@bid",SqlDbType .Int ,4)
            };
            objp[0].Value = bid;
            return ExecuteTable("SPMblDraftSentOn", objp);
        }


        public void UpdateMblDraftsSent(int branchid, DateTime mbldraftssenton, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@mbldraftssenton", SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = mbldraftssenton;
            objp[2].Value = jobno;
            ExecuteQuery("SPUPDMbldraftssenton", objp);
        }




        public void UpdateMblrelease(int branchid, DateTime mblreleasedon, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@mblreleasedon", SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = mblreleasedon;
            objp[2].Value = jobno;
            ExecuteQuery("SPUPDMblreleasedon", objp);
        }

        //Elakkiya
        public void UpdateMblreleaseNew(int branchid, DateTime mblreleasedon, int jobno, string frmtyp)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@mblreleasedon", SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
             new SqlParameter("@ftyp", SqlDbType.VarChar ,4)};
            objp[0].Value = branchid;
            objp[1].Value = mblreleasedon;
            objp[2].Value = jobno;
            objp[3].Value = frmtyp;
            ExecuteQuery("SPUPDMblreleasedonNew", objp);
        }

        public DataTable GetLikeJobMBLNotReleased(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeJobMBLNotReleased", objp);
        }
        public DataTable GetMBLReleasedPending(int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@bid",SqlDbType .Int ,4)
            };
            objp[0].Value = bid;
            return ExecuteTable("SPMblReleasedON", objp);
        }

        //Elakkiya
        public DataTable GetMBLReleasedPendingNew(int bid, string frmtyp)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@bid",SqlDbType .Int ,4),
                 new SqlParameter ("@ftyp",SqlDbType.VarChar  ,4)
            };
            objp[0].Value = bid;
            objp[1].Value = frmtyp;
            return ExecuteTable("SPMblReleasedONNew", objp);
        }

        public DataSet SelClosedJob(DateTime fromdate, DateTime todate, int empid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid",SqlDbType.Int,4),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime , 8),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime , 8),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4)};

            objp[0].Value = empid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = cid;
            return ExecuteDataSet("SPTotalClosedJob", objp);

        }

        public DataTable selgetjobbl(int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@jobno",SqlDbType.Int)};

            objp[0].Value = jobno;
            return ExecuteTable("sp_getjobnobl", objp);

        }

        public DataTable GetVoyfromSS(int vesselid, string voyage)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselid", SqlDbType.Int, 4) ,
               new SqlParameter("@voyage", SqlDbType.VarChar, 15)};


            objp[0].Value = vesselid;
            objp[1].Value = voyage;
            return ExecuteTable("SPGetVoyfromSS", objp);

        }
        public DataTable GetVslfromSS()
        {
            SqlParameter[] objp = new SqlParameter[] { };


            return ExecuteTable("SPGetVslfromSS", objp);

        }


        public DataTable getCheckCNDNForaJOb(int branchid, int jobno, string Trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {    new SqlParameter("@branchid",SqlDbType.Int,4),
            new SqlParameter("@jobno",SqlDbType.Int,4),
                new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = branchid;
            objp[1].Value = jobno;
            objp[2].Value = Trantype;
            return ExecuteTable("SPCheckOSDNCNRaiseForaJob", objp);
        }
        public DataTable GetConttpye(int bid, int jobno, string containerno)
        {
            SqlParameter[] objp = new SqlParameter[]
            {                                   new SqlParameter("@bid",SqlDbType.Int,4),
                                                new SqlParameter("@jobno",SqlDbType.Int,4),
                                                new SqlParameter("@containerno",SqlDbType.VarChar,20)};
            objp[0].Value = bid;
            objp[1].Value = jobno;
            objp[2].Value = containerno;
            return ExecuteTable("SPGetConttype4Teus", objp);
        }

        //maniG
        public DataTable GetHBLJobDtls(int jobno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@jobno", SqlDbType.Int,4),
                 new SqlParameter("@bid", SqlDbType.Int,4),
                 new SqlParameter("@cid", SqlDbType.Int,4)

                                                     };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetHBLJobDtls", objp);
        }




        public DataTable GetHBLDtls(int jobno, char frmtyp, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@jobno", SqlDbType.Int,4),
                  new SqlParameter("@frmtyp", SqlDbType.Char ,4),
                 new SqlParameter("@bid", SqlDbType.Int,4),
                 new SqlParameter("@cid", SqlDbType.Int,4)

                                                     };
            objp[0].Value = jobno;
            objp[1].Value = frmtyp;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;
            return ExecuteTable("SPGetHBLDtls", objp);
        }

        public void UpdHBLCnfRcvDtls(int jobno, string blno, string frmtyp, DateTime hblon, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@hblon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@frmtyp",SqlDbType.Char,4),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = hblon;
            objp[3].Value = frmtyp;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            ExecuteQuery("SPUpdHBLCnfRcvDtls", objp);
        }

        public DataTable GetFEBookPerformanceTrack(int intBranchID, int intDivisionID, string frmtyp, DateTime FromDate, DateTime ToDate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@frmtyp",SqlDbType.Char,4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            objp[2].Value = frmtyp;
            objp[3].Value = FromDate;
            objp[4].Value = ToDate;
            return ExecuteTable("SpSelBookingPerformance", objp);
        }

        //----------------------------------Rajkumar--------------------------------------------

        public DataTable GetfeventDates(int intjbno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno", SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intjbno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SpGetfeventDates", objp);
        }

        //RajaGuru
        public void updjobinfoprofit(string trantype, int jobno, int bid, string jobprofit, int carrierid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobno",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.Int),
                                                     new SqlParameter("@jobprofit",SqlDbType.Char,1),
                                                     new SqlParameter("@carrierid",SqlDbType.Int)};
            objp[0].Value = trantype;
            objp[1].Value = jobno;
            objp[2].Value = bid;
            objp[3].Value = jobprofit;
            objp[4].Value = carrierid;
            ExecuteQuery("spupdjobinfoprofit", objp);
        }


        //Arun

        public DataTable GetPerformanceRevenusales(DateTime fromdate, DateTime todate, int empid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@fromdate", SqlDbType.DateTime),
                                                           new SqlParameter("@todate", SqlDbType.DateTime),
                                                            new SqlParameter("@empid", SqlDbType.Int),
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int)


                                                     };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;
            return ExecuteTable("SPPerforRevenue4Sales", objp);
        }

        public DataTable GetQuationIdForNew(int branchid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int),
                                                           new SqlParameter("@empid", SqlDbType.Int)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;
            return ExecuteTable("GetQuatotionidForNew", objp);
        }
        public DataTable GetTrantypeForNewsales(int branchid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                            new SqlParameter("@divisionid", SqlDbType.Int),
                                                           new SqlParameter("@empid", SqlDbType.Int)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;
            return ExecuteTable("GetTrantypeNewinsales", objp);
        }

        public DataTable GetSalesBookingNew(int branchid, int divisionid, int salesid, string Booking, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                            new SqlParameter("@divisionid", SqlDbType.Int),
                                                           new SqlParameter("@empid", SqlDbType.Int),
                                                             new SqlParameter("@shipno", SqlDbType.VarChar,100),
                                                              new SqlParameter("@trantype", SqlDbType.VarChar,5)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;
            objp[3].Value = Booking;
            objp[4].Value = trantype;
            return ExecuteTable("SPGetBookingNewSales", objp);
        }

        public DataTable GetRevenuePersonCurr(DateTime fromdate, DateTime todate, int empid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@fromdate", SqlDbType.DateTime),
                                                           new SqlParameter("@todate", SqlDbType.DateTime),
                                                            new SqlParameter("@empid", SqlDbType.Int),
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int)


                                                     };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;
            return ExecuteTable("SpGetCurrencyPerson", objp);
        }

        public DataTable get_getdetailsforemptyjobbooking(int bid, string booking)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@booking", SqlDbType.VarChar,20)
                                                     };
            objp[0].Value = bid;
            objp[1].Value = booking;
            return ExecuteTable("sp_getdetailsforemptyjobbooking", objp);
        }


        //MUTHU

        public DataTable getbookingbar(int salesid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                           new SqlParameter("@empid", SqlDbType.Int),
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int),

                                                     };



            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;


            return ExecuteTable("sp_bookingbarcount", objp);
        }




        public DataTable getperfomanceyear(int salesid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                           new SqlParameter("@empid", SqlDbType.Int),
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int),

                                                     };



            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;


            return ExecuteTable("SPPerforRevenue4Salesmonth", objp);
        }


        public DataTable GetSalesBookingCount_Karthika(int branchid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int),
                                                           new SqlParameter("@empid", SqlDbType.Int)

                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;

            return ExecuteTable("sp_salesBookingCount", objp);
        }

        //ARUN
        public DataTable GetOPsDocHomeCount(int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2)
            };

            objp[0].Value = branchid;
            objp[1].Value = trantype;

            return ExecuteTable("sp_GetOPsDocHomeCount", objp);

        }
        //muthu

        public DataTable GetSalesBookingCount_MUTHU(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int)


                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;


            return ExecuteTable("sp_salesBookingCountOECS", objp);
        }
        public DataTable GetSalesBookingCount_new(int branchid, int divisionid, string strantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,4),


                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = strantype;


            return ExecuteTable("sp_salesBookingCountOECSnew", objp);
        }


        public DataTable GetSalesBookingCountHome(int branchid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int),
                                                           new SqlParameter("@empid", SqlDbType.Int)

                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;

            return ExecuteTable("SP_SalesCustNameForBookingCOUNTING", objp);
        }


        //Dinesh

        public DataTable Getjobinforpt(int branchid, string jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.VarChar, 10),
             new SqlParameter("@jobno", SqlDbType.VarChar, 20)};
            objp[0].Value = branchid;
            objp[1].Value = jobno;
            return ExecuteTable("spjobinforpt", objp);
        }


        //Dinesh
        public DataTable GetFEJobInfoMBLWOClosedJobnew(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeJobMBLWOClosedJobnew", objp);
        }

        //Dinesh

        public DataTable GetLikeMBLNoWOClosedJobnew(string mblno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@mblno", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = mblno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFIMBLNoWOClosedJobnew", objp);
        }

        public DataTable get_getdetailsforemptyjobbookingAE(int bid, string booking, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@booking", SqlDbType.VarChar,20),
                                                             new SqlParameter("@trantype", SqlDbType.VarChar,20)
                                                     };
            objp[0].Value = bid;
            objp[1].Value = booking;
            objp[2].Value = trantype;
            return ExecuteTable("sp_getdetailsforemptyjobbookingAE", objp);
        }


        //Nambi
        public DataTable GetContainerDetails4job(int intJbNo, int intBranchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),

                                                     };

            objp[0].Value = intJbNo;
            objp[1].Value = intBranchid;

            return ExecuteTable("SPFEContainers4job", objp);
        }

        public void updjobindirectnotify(int jobno, int bid, string directbl, string notify)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@jobno",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.Int),
                                                     new SqlParameter("@directbl",SqlDbType.VarChar,2),
                                                     new SqlParameter("@notify",SqlDbType.VarChar,2)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = directbl;
            objp[3].Value = notify;

            ExecuteQuery("sp_directblnotify", objp);
        }

        //Manoj Change Job Checking

        public DataSet CheckChangeJobforOSDNCN(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno", SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.Int),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,2)

                                                     };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            return ExecuteDataSet("SPCheckOSVouforJob", objp);
        }

        public DataSet CheckChangeJobforOSDNCNjobclosing(int jobno, int branchid, string trantype, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno", SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.Int),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                            new SqlParameter("@year", SqlDbType.Int),

                                                     };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = year;
            return ExecuteDataSet("SPCheckOSVouforJobclosing", objp);
        }
        //Forwarding Exports. Jobinfo
        //Tally

        public DataTable GetFEJobInfonew(int intjbno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno", SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intjbno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFEQryJobinfofornewtally", objp);
        }
        public DataTable ShowJobDetailsnew(int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFIJobDtlsfornewtally", objp);
        }
        public DataTable AEAIJobInfo(int jobno, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt),
                                                          new SqlParameter("@trantype", SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("AEAIJobinfo", objp);
        }





        public DataTable GetSalesBookingCountHomenewly(int branchid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@branchid", SqlDbType.Int),
                                                           new SqlParameter("@divisionid", SqlDbType.Int),
                                                           new SqlParameter("@empid", SqlDbType.Int)

                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;

            return ExecuteTable("SP_SalesCustNameFore-BookingCOUNTING", objp);
        }

        public DataTable GetJobNoListFI(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPFIQery", objp);
        }





        public DataTable GetFEQrywithoutJobinfonew(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPFEQrywithoutJobinfonew", objp);
        }




        public DataTable GetFIQrywithoutJobinfonew(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPFIQrywithoutJobinfonew", objp);
        }


        public DataTable SPLikeJobBLno(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@blno", SqlDbType.VarChar,150),
                                                           new SqlParameter("@bid", SqlDbType.Int),
                                                           new SqlParameter("@cid", SqlDbType.Int)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeJobBLno", objp);
        }


        public DataTable sp_getdetailsforemptyjobbookingFI(int bid, string booking, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@booking", SqlDbType.VarChar,20),
                                                             new SqlParameter("@trantype", SqlDbType.VarChar,20)
                                                     };
            objp[0].Value = bid;
            objp[1].Value = booking;
            objp[2].Value = trantype;
            return ExecuteTable("sp_getdetailsforemptyjobbookingFI", objp);
        }

        public void InsContDetail4job(int intJbNo, string strContNo, string strSizeType, string strSealNo, string strBLNo, int pkgs, double wt, int intBranchID, int intDivisionID, DateTime datCRO,
           double ntwt, char GrwtType, char NtWtType)
        {
            //int pkgid = 0;
            //pkgid = PkgObj.GetNPackageid(pkgs);
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                          new SqlParameter("@jobno",SqlDbType.Int),
                                                          new SqlParameter("@containerno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                          new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@pkg",SqlDbType.Int,4),
                                                          new SqlParameter("@wt",SqlDbType.Real,4),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@crodate",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@ntwt",SqlDbType.Decimal,18),
                                                            new SqlParameter("@grwttype",SqlDbType.Char,1),
                                                     new SqlParameter("@ntwttype",SqlDbType.Char,1),
                                                     };
            objp[0].Value = intJbNo;
            objp[1].Value = strContNo;
            objp[2].Value = strSizeType;
            objp[3].Value = strSealNo;
            objp[4].Value = strBLNo;
            objp[5].Value = pkgs;
            objp[6].Value = wt;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivisionID;
            objp[9].Value = datCRO;
            objp[10].Value = ntwt;
            objp[11].Value = GrwtType;
            objp[12].Value = NtWtType;
            ExecuteQuery("SPInsFEContainer4job", objp);
        }

        public void UpdContDetails4job(int intJbNo, string strBLNo, string strContNo, string strSztype, string strSlNo, string strContNo1, int pkgs, double wt, int intBranchID, int intDivisionID, DateTime datCRO, double ntwt, char GrwtType, char NtWtType)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                         new SqlParameter("@sealno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@containerno1",SqlDbType.VarChar,12),
                                                         new SqlParameter("@pkg",SqlDbType.Int,4),
                                                         new SqlParameter("@wt",SqlDbType.Real,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                  new SqlParameter("@crodate",SqlDbType.SmallDateTime,4),
                   new SqlParameter("@ntwt",SqlDbType.Decimal,18),
                                                            new SqlParameter("@grwttype",SqlDbType.Char,1),
                                                     new SqlParameter("@ntwttype",SqlDbType.Char,1)
                                                      };
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = strContNo;
            objp[3].Value = strSztype;
            objp[4].Value = strSlNo;
            objp[5].Value = strContNo1;
            objp[6].Value = pkgs;
            objp[7].Value = wt;
            objp[8].Value = intBranchID;
            objp[9].Value = intDivisionID;
            objp[10].Value = datCRO;
            objp[11].Value = ntwt;
            objp[12].Value = GrwtType;
            objp[13].Value = NtWtType;
            ExecuteQuery("SPUpdFEContDetails4job", objp);
        }
        public void UpdateTaskEvent(string bookingNo, string trantype, int bid, int empid, int taskid)
        {
            //int pkgid = 0;
            //pkgid = PkgObj.GetNPackageid(pkgs);
            SqlParameter[] objp = new SqlParameter[]
                                                     {

                                                          new SqlParameter("@booking",SqlDbType.VarChar,100),
                                                          new SqlParameter("@product",SqlDbType.VarChar,10),


                                                          new SqlParameter("@bid",SqlDbType.Int,4),
                                                           new SqlParameter("empid",SqlDbType.Int,4),
                                                            new SqlParameter("@taskid",SqlDbType.Int,4),




                                                     };
            objp[0].Value = bookingNo;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = empid;
            objp[4].Value = taskid;

            ExecuteQuery("SP_UpdateTaskBookingEvent", objp);
        }


        public DataTable GetGridHeader(string OE)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@OE", SqlDbType.VarChar,150)
            };

            objp[0].Value = OE;
            return ExecuteTable("SPGetGridRow", objp);
        }

        public DataTable GetEvent(DateTime FromDate, DateTime ToDate)
        {
            SqlParameter[] array = new SqlParameter[2] {
            new SqlParameter("@fromdate", SqlDbType.SmallDateTime, 4),
            new SqlParameter("@todate", SqlDbType.SmallDateTime, 4)
            };
            array[0].Value = FromDate;
            array[1].Value = ToDate;
            return ExecuteTable("SPGetEvents", array);
        }


        public DataTable GetFEBookPerformanceTrackEvents(int intBranchID, int intDivisionID, string frmtyp, DateTime FromDate, DateTime ToDate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@frmtyp",SqlDbType.Char,4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            objp[2].Value = frmtyp;
            objp[3].Value = FromDate;
            objp[4].Value = ToDate;
            return ExecuteTable("SPGETEventAllDetails", objp);
        }

    }
}

