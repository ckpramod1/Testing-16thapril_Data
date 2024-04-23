using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.NvoccExports
{
    public class BLDetails : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BLDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsBLDetails(int intJobNo, string strBLNo, DateTime datIssuedOn, int intIssudAtid, int intSprID, string strSprAdReader, int intCneeID, string strCneeAdReader, int intNPtyID, string strNPtyAdReader, int intAgentID, string strMN, string strDesc, double dblGrWt, char GrwtType, double dblNtWt, char NtWtType, double dblVolume, int intnoofpkgs, string intPkgID, int intPORID, int intPOLID, int intPODID, int intFDID, char strFreight, int intSpmt, char strNomination, char HBLStatus, int originalbl, string strRemarks, int BLSign, int cargoid, int intBranchID, int intDivisionID, string BookingNo, int cont20, int cont40, int salesID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                     new SqlParameter("@bldate",SqlDbType.SmallDateTime,4), 
                                                     new SqlParameter("@blissuedt",SqlDbType.Int),
                                                     new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                     new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@consigneeid",SqlDbType.Int,4), 
                                                     new SqlParameter("@caddress",SqlDbType.VarChar,250),        
                                                     new SqlParameter("@notify",SqlDbType.Int,4), 
                                                     new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@agent",SqlDbType.Int,4),
                                                     new SqlParameter("@marks",SqlDbType.VarChar,500), 
                                                     new SqlParameter("@descn",SqlDbType.VarChar,500),                                                                                     
                                                     new SqlParameter("@grweight",SqlDbType.Real,4),
                                                     new SqlParameter("@grwttype",SqlDbType.Char,1),
                                                     new SqlParameter("@ntweight",SqlDbType.Real,4),
                                                     new SqlParameter("@ntwttype",SqlDbType.Char,1),
                                                     new SqlParameter("@volume",SqlDbType.Real,4),
                                                     new SqlParameter("@npkg",SqlDbType.Int),
                                                     new SqlParameter("@pkgid",SqlDbType.Int), 
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),        
                                                     new SqlParameter("@pod",SqlDbType.Int), 
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@freight",SqlDbType.Char,1),
                                                     new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                     new SqlParameter("@hblstatus",SqlDbType.Char,1),
                                                     new SqlParameter("@originalbl",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                     new SqlParameter("@sign",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                     new SqlParameter("@cont20",SqlDbType.Int),
                                                     new SqlParameter("@cont40",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int) };
            objp[0].Value = intJobNo;
            objp[1].Value = strBLNo;
            objp[2].Value = datIssuedOn;
            objp[3].Value = intIssudAtid;
            objp[4].Value = intSprID;
            objp[5].Value = strSprAdReader; ;
            objp[6].Value = intCneeID;
            objp[7].Value = strCneeAdReader;
            objp[8].Value = intNPtyID;
            objp[9].Value = strNPtyAdReader;
            objp[10].Value = intAgentID;
            objp[11].Value = strMN;
            objp[12].Value = strDesc;
            objp[13].Value = dblGrWt;
            objp[14].Value = GrwtType;
            objp[15].Value = dblNtWt;
            objp[16].Value = NtWtType;
            objp[17].Value = dblVolume;
            objp[18].Value = intnoofpkgs;
            objp[19].Value = intPkgID;
            objp[20].Value = intPORID;
            objp[21].Value = intPOLID;
            objp[22].Value = intPODID;
            objp[23].Value = intFDID;
            objp[24].Value = strFreight;
            objp[25].Value = intSpmt;
            objp[26].Value = strNomination;
            objp[27].Value = HBLStatus;
            objp[28].Value = originalbl;
            objp[29].Value = strRemarks;
            objp[30].Value = BLSign;
            objp[31].Value = cargoid;
            objp[32].Value = intBranchID;
            objp[33].Value = intDivisionID;
            objp[34].Value = BookingNo;
            objp[35].Value = cont20;
            objp[36].Value = cont40;
            objp[37].Value = salesID;
            ExecuteQuery("SPNEInsBL", objp);
        }

        public void UpdBLDetails(int intJobNo, string strBLNo, DateTime datIssuedOn, int intIssudAtid, int intSprID, string strSprAdReader, int intCneeID, string strCneeAdReader, int intNPtyID, string strNPtyAdReader, int intAgentID, string strMN, string strDesc, double dblGrWt, char GrwtType, double dblNtWt, char NtWtType, double dblVolume, int intnoofpkgs, string intPkgID, int intPORID, int intPOLID, int intPODID, int intFDID, char strFreight, int intSpmt, char strNomination, char HBLStatus, int originalbl, string strRemarks, int BLSign, int cargoid, int intBranchID, int intDivisionID, int cont20, int cont40,int salesID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                     new SqlParameter("@bldate",SqlDbType.SmallDateTime,4), 
                                                     new SqlParameter("@blissuedt",SqlDbType.Int),
                                                     new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                     new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@consigneeid",SqlDbType.Int,4), 
                                                     new SqlParameter("@caddress",SqlDbType.VarChar,250),        
                                                     new SqlParameter("@notify",SqlDbType.Int,4), 
                                                     new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@agent",SqlDbType.Int,4),
                                                     new SqlParameter("@marks",SqlDbType.VarChar,500), 
                                                     new SqlParameter("@descn",SqlDbType.VarChar,500),                                                                                     
                                                     new SqlParameter("@grweight",SqlDbType.Real,4),
                                                     new SqlParameter("@grwttype",SqlDbType.Char,1),
                                                     new SqlParameter("@ntweight",SqlDbType.Real,4),
                                                     new SqlParameter("@ntwttype",SqlDbType.Char,1),
                                                     new SqlParameter("@volume",SqlDbType.Real,4),
                                                     new SqlParameter("@npkg",SqlDbType.Int),
                                                     new SqlParameter("@pkgid",SqlDbType.Int), 
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),        
                                                     new SqlParameter("@pod",SqlDbType.Int), 
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@freight",SqlDbType.Char,1),
                                                     new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                     new SqlParameter("@hblstatus",SqlDbType.Char,1),
                                                     new SqlParameter("@originalbl",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                     new SqlParameter("@sign",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cont20",SqlDbType.Int),
                                                     new SqlParameter("@cont40",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int) };
            objp[0].Value = intJobNo;
            objp[1].Value = strBLNo;
            objp[2].Value = datIssuedOn;
            objp[3].Value = intIssudAtid;
            objp[4].Value = intSprID;
            objp[5].Value = strSprAdReader; ;
            objp[6].Value = intCneeID;
            objp[7].Value = strCneeAdReader;
            objp[8].Value = intNPtyID;
            objp[9].Value = strNPtyAdReader;
            objp[10].Value = intAgentID;
            objp[11].Value = strMN;
            objp[12].Value = strDesc;
            objp[13].Value = dblGrWt;
            objp[14].Value = GrwtType;
            objp[15].Value = dblNtWt;
            objp[16].Value = NtWtType;
            objp[17].Value = dblVolume;
            objp[18].Value = intnoofpkgs;
            objp[19].Value = intPkgID;
            objp[20].Value = intPORID;
            objp[21].Value = intPOLID;
            objp[22].Value = intPODID;
            objp[23].Value = intFDID;
            objp[24].Value = strFreight;
            objp[25].Value = intSpmt;
            objp[26].Value = strNomination;
            objp[27].Value = HBLStatus;
            objp[28].Value = originalbl;
            objp[29].Value = strRemarks;
            objp[30].Value = BLSign;
            objp[31].Value = cargoid;
            objp[32].Value = intBranchID;
            objp[33].Value = intDivisionID;
            objp[34].Value = cont20;
            objp[35].Value = cont40;
            objp[36].Value = salesID;
            ExecuteQuery("SPNEUpdBL", objp);
        }

        public DataTable GetBLDetails(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30) ,
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt, 1) };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPNEBLDetail", objp);
        }

        public DataTable GetLikeBLDetails(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt, 1) };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeNEBL", objp);
        }

        public DataTable GetBookingDt(string bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt, 1) };
            objp[0].Value = bookingno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPBookingId", objp);
        }

        public void UpdBLContainers(int JobNo, string BLno, int FreeDays, string ContainerNo, string SealNo, int NoofPkgs, int PkgID, double Weight, char WtType, int nTrackID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                      new SqlParameter("@freedays",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                      new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                      new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                      new SqlParameter("@pkgtype",SqlDbType.Int),
                                                      new SqlParameter("@weight",SqlDbType.Real,4),
                                                      new SqlParameter("@wttype",SqlDbType.Char,1),
                                                      new SqlParameter("@ntrackid",SqlDbType.Int,4) };
            objp[0].Value = JobNo;
            objp[1].Value = BLno;
            objp[2].Value = FreeDays;
            objp[3].Value = ContainerNo;
            objp[4].Value = SealNo;
            objp[5].Value = NoofPkgs;
            objp[6].Value = PkgID;
            objp[7].Value = Weight;
            objp[8].Value = WtType;
            objp[9].Value = nTrackID;
            ExecuteQuery("SPNEUpdBLContainers", objp);
        }

        public DataTable GetNEContDtlsByBLno(int JobNo, string BLno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt, 1) };
            objp[0].Value = JobNo;
            objp[1].Value = BLno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetNEContDtlsByBLno", objp);
        }

        //BL Print Details

        public void UpdateBLDetails4BLPrint(string strBLNo, string pordetails, string poldetails, string poddetails, string fddetails, string pkgdetails, string cntrdetails, string blgrwt, string blntwt, string blcbm, int intBranchID, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                     new SqlParameter("@pordetails",SqlDbType.VarChar,30),
                                                     new SqlParameter("@poldetails",SqlDbType.VarChar,30),
                                                     new SqlParameter("@poddetails",SqlDbType.VarChar,30),
                                                     new SqlParameter("@fddetails",SqlDbType.VarChar,30),
                                                     new SqlParameter("@pkgdetails",SqlDbType.VarChar,30),
                                                     new SqlParameter("@cntrdetails",SqlDbType.VarChar,500),
                                                     new SqlParameter("@blgrweight",SqlDbType.VarChar,15),
                                                     new SqlParameter("@blntweight",SqlDbType.VarChar,15),
                                                     new SqlParameter("@blcbm",SqlDbType.VarChar,15),
                                                     new SqlParameter("@dbname", SqlDbType.VarChar, 10),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)
                                                     };

            objp[0].Value = strBLNo;
            objp[1].Value = pordetails;
            objp[2].Value = poldetails;
            objp[3].Value = poddetails;
            objp[4].Value = fddetails;
            objp[5].Value = pkgdetails;
            objp[6].Value = cntrdetails;
            objp[7].Value = blgrwt;
            objp[8].Value = blntwt;
            objp[9].Value = blcbm;
            objp[10].Value = "FA" + intBranchID;
            objp[11].Value = bid;
            objp[12].Value = cid;
            ExecuteQuery("SPUpdNEBLPrint", objp);
        }

        public DataTable selNEBLPrint(string StrBlno, int intBranchID, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@dbname",SqlDbType.Char,10),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = StrBlno;
            objp[1].Value = "FA" + intBranchID;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return ExecuteTable("SPSelNEBLPrint", objp);
        }
    }
}
