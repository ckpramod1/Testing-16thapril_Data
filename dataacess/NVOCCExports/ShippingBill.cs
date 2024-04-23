using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.NvoccExports
{
    public class ShippingBill : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ShippingBill()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable BookingdetailsShipping(string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPBookingBLPENDingsShipping", objp);
        }

        public DataTable Bookingdetails(string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPBookingBLPendings", objp);
        }

        public DataTable GetLikeShipBill(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPNELikeSBill", objp);
        }

        public void InsShipBill(int JobNo, string BkgNo, string SbNo, DateTime SbDate, int intSprID, string SprDtls, int intCneeID, string CneeDtls, int intNptyID, string NptyDtls, int intChaID, int intPOR, int intPOL, int intPOD, int intFD, string strMarks, string strDescn, double GrWt, char GrWtType, double NtWt, char NtWtType,double Volume,int NoofPkg,int PkgID, string strGrNo, DateTime GrDate, string strCsNo, string strHtsCode, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@sbno",SqlDbType.VarChar,30),        
                                                       new SqlParameter("@sbdate",SqlDbType.SmallDateTime,4), 
                                                       new SqlParameter("@shipper",SqlDbType.Int,4),
                                                       new SqlParameter("@sdetails",SqlDbType.VarChar,250),
                                                       new SqlParameter("@consignee",SqlDbType.Int,4),
                                                       new SqlParameter("@cdetails",SqlDbType.VarChar,250),
                                                       new SqlParameter("@notify",SqlDbType.Int,4),
                                                       new SqlParameter("@ndetails",SqlDbType.VarChar,250),
                                                       new SqlParameter("@cha",SqlDbType.Int,4),
                                                       new SqlParameter("@por",SqlDbType.Int,4),        
                                                       new SqlParameter("@pol",SqlDbType.Int,4), 
                                                       new SqlParameter("@pod",SqlDbType.Int,4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4),
                                                       new SqlParameter("@marks",SqlDbType.VarChar,200), 
                                                       new SqlParameter("@descn",SqlDbType.VarChar,500),
                                                       new SqlParameter("@grwt",SqlDbType.Real,4),
                                                       new SqlParameter("@grwttype",SqlDbType.Char,1),
                                                       new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                       new SqlParameter("@ntwttype",SqlDbType.Char,1),
                                                       new SqlParameter("@volume",SqlDbType.VarChar,10),
                                                       new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                       new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                       new SqlParameter("@grno",SqlDbType.VarChar,15),
                                                       new SqlParameter("@grdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@csno",SqlDbType.VarChar,15),
                                                       new SqlParameter("@htscode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = JobNo;
            objp[1].Value = BkgNo;
            objp[2].Value = SbNo;
            objp[3].Value = SbDate;
            objp[4].Value = intSprID;
            objp[5].Value = SprDtls;
            objp[6].Value = intCneeID;
            objp[7].Value = CneeDtls;
            objp[8].Value = intNptyID;
            objp[9].Value = NptyDtls;
            objp[10].Value = intChaID;
            objp[11].Value = intPOR;
            objp[12].Value = intPOL;
            objp[13].Value = intPOD;
            objp[14].Value = intFD;
            objp[15].Value = strMarks;
            objp[16].Value = strDescn;
            objp[17].Value = GrWt;
            objp[18].Value = GrWtType;
            objp[19].Value = NtWt;
            objp[20].Value = NtWtType;
            objp[21].Value = Volume;
            objp[22].Value = NoofPkg;
            objp[23].Value = PkgID;
            objp[24].Value = strGrNo;
            objp[25].Value = GrDate;
            objp[26].Value = strCsNo;
            objp[27].Value = strHtsCode;
            objp[28].Value = intBranchID;
            objp[29].Value = intDivisionID;
            ExecuteQuery("SPNEInsShipBill", objp);
        }

        public void UpdShipBill(int JobNo, string BkgNo, string SbNo, DateTime SbDate, int intSprID, string SprDtls, int intCneeID, string CneeDtls, int intNptyID, string NptyDtls, int intChaID, int intPOR, int intPOL, int intPOD, int intFD, string strMarks, string strDescn, double GrWt, char GrWtType, double NtWt, char NtWtType, double Volume, int NoofPkg, int PkgID, string strGrNo, DateTime GrDate, string strCsNo, string strHtsCode, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@sbno",SqlDbType.VarChar,30),        
                                                       new SqlParameter("@sbdate",SqlDbType.SmallDateTime,4), 
                                                       new SqlParameter("@shipper",SqlDbType.Int,4),
                                                       new SqlParameter("@sdetails",SqlDbType.VarChar,250),
                                                       new SqlParameter("@consignee",SqlDbType.Int,4),
                                                       new SqlParameter("@cdetails",SqlDbType.VarChar,250),
                                                       new SqlParameter("@notify",SqlDbType.Int,4),
                                                       new SqlParameter("@ndetails",SqlDbType.VarChar,250),
                                                       new SqlParameter("@cha",SqlDbType.Int,4),
                                                       new SqlParameter("@por",SqlDbType.Int,4),        
                                                       new SqlParameter("@pol",SqlDbType.Int,4), 
                                                       new SqlParameter("@pod",SqlDbType.Int,4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4),
                                                       new SqlParameter("@marks",SqlDbType.VarChar,200), 
                                                       new SqlParameter("@descn",SqlDbType.VarChar,500),
                                                       new SqlParameter("@grwt",SqlDbType.Real,4),
                                                       new SqlParameter("@grwttype",SqlDbType.Char,1),
                                                       new SqlParameter("@netwt",SqlDbType.Real,4),
                                                       new SqlParameter("@ntwttype",SqlDbType.Char,1),
                                                       new SqlParameter("@volume",SqlDbType.VarChar,10),
                                                       new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                       new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                       new SqlParameter("@grno",SqlDbType.VarChar,15),
                                                       new SqlParameter("@grdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@csno",SqlDbType.VarChar,15),
                                                       new SqlParameter("@htscode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = JobNo;
            objp[1].Value = BkgNo;
            objp[2].Value = SbNo;
            objp[3].Value = SbDate;
            objp[4].Value = intSprID;
            objp[5].Value = SprDtls;
            objp[6].Value = intCneeID;
            objp[7].Value = CneeDtls;
            objp[8].Value = intNptyID;
            objp[9].Value = NptyDtls;
            objp[10].Value = intChaID;
            objp[11].Value = intPOR;
            objp[12].Value = intPOL;
            objp[13].Value = intPOD;
            objp[14].Value = intFD;
            objp[15].Value = strMarks;
            objp[16].Value = strDescn;
            objp[17].Value = GrWt;
            objp[18].Value = GrWtType;
            objp[19].Value = NtWt;
            objp[20].Value = NtWtType;
            objp[21].Value = Volume;
            objp[22].Value = NoofPkg;
            objp[23].Value = PkgID;
            objp[24].Value = strGrNo;
            objp[25].Value = GrDate;
            objp[26].Value = strCsNo;
            objp[27].Value = strHtsCode;
            objp[28].Value = intBranchID;
            objp[29].Value = intDivisionID;
            ExecuteQuery("SPNEUpdShipBill", objp);
        }

        public DataTable GetShipBill(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPNESelShipBill", objp);
        }
        
        public DataTable GetPPCont4SB(string BkngNo, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = BkngNo;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            return ExecuteTable("SPGetPPCont4SB", objp);
        }

        public void InsSBContainers(int JobNo, string SBno, string ContainerNo, string SizeType, string SealNo, int NoofPkg, double weight, char wttype, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@sbno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                       new SqlParameter("@sizetype",SqlDbType.VarChar,3),
                                                       new SqlParameter("@sealno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                       new SqlParameter("@weight",SqlDbType.Real,4),
                                                       new SqlParameter("@wttype",SqlDbType.Char,1),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = JobNo;
            objp[1].Value = SBno;
            objp[2].Value = ContainerNo;
            objp[3].Value = SizeType;
            objp[4].Value = SealNo;
            objp[5].Value = NoofPkg;
            objp[6].Value = weight;
            objp[7].Value = wttype;
            objp[8].Value = Bid;
            objp[9].Value = Cid;
            ExecuteQuery("SPInsSBContainer",objp);
        }

        public void UpdSBContainers(int JobNo, string SBno, string ContainerNo, string SizeType, string SealNo, int NoofPkg, double weight, char wttype, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@sbno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                       new SqlParameter("@sizetype",SqlDbType.VarChar,3),
                                                       new SqlParameter("@sealno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                       new SqlParameter("@weight",SqlDbType.Real,4),
                                                       new SqlParameter("@wttype",SqlDbType.Char,1),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = JobNo;
            objp[1].Value = SBno;
            objp[2].Value = ContainerNo;
            objp[3].Value = SizeType;
            objp[4].Value = SealNo;
            objp[5].Value = NoofPkg;
            objp[6].Value = weight;
            objp[7].Value = wttype;
            objp[8].Value = Bid;
            objp[9].Value = Cid;
            ExecuteQuery("SPUpdSBContainer", objp);
        }

        public DataTable GetPPContBySB(string SBno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sbno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = SBno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            return ExecuteTable("SPGetPPContBySB", objp);
        }
    }
}
