using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ForwardingExports
{
    public class BLDetails:DBObject
    {
        int intPkgID;
        Masters.MasterCustomer CustObj = new Masters.MasterCustomer();
        Masters.MasterPort PortObj = new Masters.MasterPort();
        Masters.MasterVessel VesselObj = new Masters.MasterVessel();
        Masters.MasterPackages PkgObj = new Masters.MasterPackages();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BLDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsBLDetails(int intJobNo, string strBLNo, DateTime datIssuedOn, int intIssudAtid, int intSprID, string strSprName, string strSprAdReader, int intCneeID, string strCneeName, string strCneeAdReader, int intNPtyID, string strNPtyName, string strNPtyAdReader, int intAgentID, int intCnfID, string strMN, string strDesc, double dblGrWt, double dblNtWt, double dblCBM, int intPackages, string strUnits, int intPORID, int intPOLID, int intPODID, int intFDID, string strFreight, int intSpmt, string strNomination, string strOurBL, string strSurd, int fe20, int fe40, int intBranchID, int originalbl, string division, string branch, string strRemarks, short shrtSign, char chrDGCargo, int salesid, int PreparedBy, int cargoid, int intDivisionID)
        {
            intPkgID = PkgObj.GetNPackageid(strUnits);
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@jobno",SqlDbType.Int),
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
                                                         new SqlParameter("@marks",SqlDbType.VarChar,5000), 
                                                         new SqlParameter("@descn",SqlDbType.VarChar,1500),                                                                                     
                                                         new SqlParameter("@grweight",SqlDbType.Decimal ,18),
                                                         new SqlParameter("@ntweight",SqlDbType.Real,4),
                                                         new SqlParameter("@cbm",SqlDbType.Real,4),
                                                         new SqlParameter("@npkg",SqlDbType.Int,4),
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
                                                         new SqlParameter("@fe20",SqlDbType.Int),
                                                         new SqlParameter("@fe40",SqlDbType.Int),
                                                         new SqlParameter("@originalbl",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                         new SqlParameter("@sign",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@dgcargo",SqlDbType.VarChar,1),
                                                         new SqlParameter("@salesid",SqlDbType.Int),
                                                         new SqlParameter("@preparedby",SqlDbType.Int),
                                                         new SqlParameter("@cargoid",SqlDbType.Int),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };

            objp[0].Value = intJobNo;
            objp[1].Value = strBLNo;
            objp[2].Value = datIssuedOn;
            objp[3].Value = intIssudAtid;
            objp[4].Value = intSprID;
            objp[5].Value = strSprName;
            objp[6].Value = strSprAdReader;
            objp[7].Value = intCneeID;
            objp[8].Value = strCneeName;
            objp[9].Value = strCneeAdReader;
            objp[10].Value = intNPtyID;
            objp[11].Value = strNPtyName;
            objp[12].Value = strNPtyAdReader;
            objp[13].Value = intAgentID;
            objp[14].Value = intCnfID;
            objp[15].Value = strMN;
            objp[16].Value = strDesc;
            objp[17].Value = dblGrWt;
            objp[18].Value = dblNtWt;
            objp[19].Value = dblCBM;
            objp[20].Value = intPackages;
            objp[21].Value = intPkgID;
            objp[22].Value = intPORID;
            objp[23].Value = intPOLID;
            objp[24].Value = intPODID;
            objp[25].Value = intFDID;
            objp[26].Value = strFreight;
            objp[27].Value = intSpmt;
            objp[28].Value = strNomination;
            objp[29].Value = strOurBL;
            objp[30].Value = strSurd;
            objp[31].Value = fe20;
            objp[32].Value = fe40;
            objp[33].Value = originalbl;
            objp[34].Value = strRemarks;
            objp[35].Value = shrtSign;
            objp[36].Value = chrDGCargo;
            objp[37].Value = salesid;
            objp[38].Value = PreparedBy;
            objp[39].Value = cargoid;
            objp[40].Value = intBranchID;
            objp[41].Value = intDivisionID;
            ExecuteQuery("SPInsFEBL", objp);
        }

        public void UpdateBLDetails(string strBLNo, DateTime datIssuedOn, int intIssudAtid, int intSprID, string strSprName, string strSprAdReader, int intCneeID, string strCneeName, string strCneeAdReader, int intNPtyID, string strNPtyName, string strNPtyAdReader, int intAgentID, int intCnfID, string strMN, string strDesc, decimal  dblGrWt, double dblNtWt, double dblCBM, int intPackages, string strUnits, int intPORID, int intPOLID, int intPODID, int intFDID, string strFreight, int intSpmt, string strNomination, string strOurBL, string strSurd, int fe20, int fe40, int jobno, double oldcbm, int originalbl, string strRemarks, short shrtSign, char chrDGCargo, int salesid, int cargoid, int intBranchID, int intDivisionID)
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
                                                         new SqlParameter("@marks",SqlDbType.VarChar,5000), 
                                                         new SqlParameter("@descn",SqlDbType.VarChar,1500),                                                                                     
                                                         new SqlParameter("@grweight",SqlDbType.Decimal ,18),
                                                         new SqlParameter("@ntweight",SqlDbType.Real,4),
                                                         new SqlParameter("@cbm",SqlDbType.Real,4),
                                                         new SqlParameter("@npkg",SqlDbType.Int,4),
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
                                                         new SqlParameter("@fe20",SqlDbType.Int),
                                                         new SqlParameter("@fe40",SqlDbType.Int),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@oldcbm",SqlDbType.Real,4),
                                                         new SqlParameter("@originalbl",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                         new SqlParameter("@sign",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@dgcargo",SqlDbType.VarChar,1),
                                                         new SqlParameter("@salesid",SqlDbType.Int),
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
            objp[30].Value = fe20;
            objp[31].Value = fe40;
            objp[32].Value = jobno;
            objp[33].Value = oldcbm;
            objp[34].Value = originalbl;
            objp[35].Value = strRemarks;
            objp[36].Value = shrtSign;
            objp[37].Value = chrDGCargo;
            objp[38].Value = salesid;
            objp[39].Value = cargoid;
            objp[40].Value = intBranchID;
            objp[41].Value = intDivisionID;
            ExecuteQuery("SPUpdFEBL", objp);
        }


        public DataTable GetBLDetails(string strBlno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFEBLDetail", objp);
         }


        public DataTable GetLikeBLDetails(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFEBL", objp);
        }


        public DataTable GetLikeOTHERBLDetails(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {     
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeOTHERFEBL", objp);
        }


        public void DelContDetails(int intJbNo, string strBLNo, string containerno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                       new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = containerno;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPDelFEContainerDetls", objp);
          }


        public void DelContainerDetails(int intJbNo, string strBLNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPDelFEContainerDetails", objp);
        }


        public void DelBLdt(string blno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            ExecuteQuery("SPDelFEBLDt", objp);
         }


        public DataTable GetBookingDt(string bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                      { 
                                                        new SqlParameter("@bookingno", SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                      };
             objp[0].Value = bookingno;
             objp[1].Value = intBranchID;
             objp[2].Value = intDivisionID;
             return ExecuteTable("SPBookingId", objp);
        }


        public string GetBookinkNo(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteReader("SPGetBookingno", objp);
        }


        public int GetCont2040(string strBLNo, int intconttype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@size", SqlDbType.VarChar,6),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBLNo;
            objp[1].Value = intconttype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return int.Parse(ExecuteReader("SPFEGetContainerType", objp));
        }


        public void UpdContSize(string strBLNo, string strType, int intBranchID,int intDivisionID)
        {
            int intcont20, intcont40;

            if (strType == "FCL")
            {
                intcont20 = GetCont2040(strBLNo, 20, intBranchID, intDivisionID);
                intcont40 = GetCont2040(strBLNo, 40, intBranchID, intDivisionID) * 2;
            }
            else
            {
                intcont40 = 0;
                intcont20 = 0;
            }
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@cont20", SqlDbType.Int,4),
                                                       new SqlParameter("@cont40", SqlDbType.Int,4) ,
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBLNo;
            objp[1].Value = intcont20;
            objp[2].Value = intcont40;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPUpdFEBLConSize", objp);
        }

        public DataTable GetPOnoFromBookingno(string bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bookingno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = bookingno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPGETPOnoFromBookingno", objp);
        }















        public DataTable ShowFEInfo(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
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
            objp[4].Value = intBranchID ;
            objp[5].Value = intDivisionID;
            return ExecuteTable("SPSelFEInfo", objp);
        }

        public DataTable ShowFEInfonew(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
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
            return ExecuteTable("SPSelFEInfonew", objp);
        }













        //BL Print Details
        public void InsBLPrintDetails(int divisionid, int branchid, string blno, DateTime printdate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@printdate", SqlDbType.DateTime,8)
                                                     };
            objp[0].Value = divisionid;
            objp[1].Value = branchid;
            objp[2].Value = blno;
            objp[3].Value = printdate;
            ExecuteQuery("SPInsBLPrintDetails", objp);
        }

        public void UpdateBLDetails4BLPrint(string strBLNo, string pordetails, string poldetails, string poddetails, string fddetails, string pkgdetails, string cntrdetails, string blgrwt, string blntwt, string blcbm, int intBranchID, int intDivisionID)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@pordetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@poldetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@poddetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@fddetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@pkgdetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@cntrdetails",SqlDbType.VarChar,5000),
                                                         new SqlParameter("@blgrweight",SqlDbType.VarChar,15),
                                                         new SqlParameter("@blntweight",SqlDbType.VarChar,15),
                                                         new SqlParameter("@blcbm",SqlDbType.VarChar,15),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
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
            objp[10].Value = intBranchID ;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPUpdFEBLPrint", objp);
        }
        public DataTable selFEBLPrint(string StrBlno,int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = StrBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFEBLPrint", objp);
        }





        public DataTable GETFEIBLTransfer(int intBranchid, string TranType, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2) 
                                                     };
            objp[0].Value = intBranchid;
            objp[1].Value = intDivisionID;
            objp[2].Value = TranType;
            return ExecuteTable("SPSelFEIBLforTransfer", objp);
        }

        public void InsFEIBLTransfer(string blno, string Trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = blno;
            objp[1].Value = Trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPInsFEIBLTransfer", objp);
        }
        
        public void InsBidInFEBLTransfer(int branchid, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30)
                                                     };

            objp[0].Value = branchid;
            objp[1].Value = blno;
            ExecuteQuery("SPInsbidinFEBLTransfer", objp);
        }

        public DataTable GETFEIBLTransICDPort(int intBranchid, string Trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2) 
                                                     };
            objp[0].Value = intBranchid;
            objp[1].Value = Trantype;
            return ExecuteTable("SPSelFEIBLTransfer", objp);
        }

        public DataTable GetBLDetails1(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFEBLDetail4web", objp);
        }
        public void InsFEIBLFromFEIBLTransfer(string blno, int branchid, string TranType,int fbranchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@fbranchid",SqlDbType.TinyInt,1) 
                                                     };

            objp[0].Value = blno;
            objp[1].Value = branchid;
            objp[2].Value = TranType;
            objp[3].Value = fbranchid;
            ExecuteQuery("SPInsFEIBLfromFEIBLTransferNew", objp);
        }

        
        public void UpdFEBLTransfer(string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30)
                                                        };

            objp[0].Value = blno;
            ExecuteQuery("SPUpdFEBLTransfer", objp);
        }

        public void UpdJobnoinFEIBL(string blno, int jobno,string strTranType, int fbranchid, int rbranchid)
        {
            SqlParameter[] objp = new SqlParameter[] {  
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@jobno",SqlDbType.Int,1),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@fbranchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@rbranchid",SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = strTranType;
            objp[3].Value = fbranchid;
            objp[4].Value = rbranchid;
            ExecuteQuery("SPUpdJobnoinFEIBL", objp);
        }


        public DataTable CheckFEIJobno(int jobno,string TranType, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = TranType;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPCheckFEIJobno", objp);
        }
        

        public string GetFEBLTransferStatus(string blno)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30) };
            objp[0].Value = blno;
            return ExecuteReader("SPSelFEBLTransferstatus", objp);
        }


        public DataTable SelBLDetailsByJob(int JobNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = JobNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelBLDtlsByJob", objp);
        }




        public DataTable SelFIBLDetailsByJob(int JobNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = JobNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFIBLDtlsByJob", objp);
        }


        public void UpdCBMRateByJob(int JobNo, double CBMRate, int BranchID,int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@cbmrate", SqlDbType.SmallMoney, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = JobNo;
            objp[1].Value = CBMRate;
            objp[2].Value = BranchID;
            objp[3].Value = DivisionID;
            ExecuteQuery("SPUpdCBMRate4Job", objp);
        }
        public string DelBlDetails(string blno, int bid, string trantype, string lastst)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@lastst",SqlDbType.VarChar,50),
                                                     new SqlParameter("@comm",SqlDbType.VarChar,50)};


            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            objp[3].Value = lastst;
            objp[4].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPDelBlDetails", "@comm", objp).ToString();

        }
        //salquery
        public DataTable SalesShowFEInfo(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@ftype",SqlDbType.VarChar,4),
                                                           new SqlParameter("@cbm",SqlDbType.Real,8),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter ("@salesid",SqlDbType .Int ,4)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = ftype;
            objp[3].Value = cbm;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            objp[6].Value = salesid;
            return ExecuteTable("SPSalesSelFEInfo", objp);
        }
       


        public DataTable GetLikeSalesOTHERBLDetails(string strBlno, int intBranchID, int intDivisionID, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {     
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt,1),
                                                           new SqlParameter ("@salesid",SqlDbType .Int ,4) 

                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = salesid;
            return ExecuteTable("SPLikeSalesOTHERFEBL", objp);
        }
        //EBL
        public void UpdBLApprove(int approvedby, DateTime approvedon, string blno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@approvedby",SqlDbType .Int),
                new SqlParameter ("@approvedon",SqlDbType.SmallDateTime ,8),
               new SqlParameter ("@blno",SqlDbType.VarChar,30),
                new SqlParameter ("@bid",SqlDbType.TinyInt)
            };
            objp[0].Value = approvedby;
            objp[1].Value = approvedon;
            objp[2].Value = blno;
            objp[3].Value = bid;
            ExecuteQuery("SPUpdapprovedOn", objp);

        }

        public DataTable CheckBLApprove(string blno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar ,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1 ) 
                                                     };
            objp[0].Value = blno;
            objp[1].Value = bid;
            return ExecuteTable("SPCheckblapprove", objp);
        }
        public void SPUpdFEhblreleasedon(string strBLNo, int intBranchID, int intDivisionID)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = strBLNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            ExecuteQuery("SPUpdFEhblreleasedon", objp);
        }

        public DataTable GetHBLReleased(int intBranchID, int intDivisionID,string TranType)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                      
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) ,
                new SqlParameter("@trantype", SqlDbType.VarChar,5) 
                                                     };

            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            objp[2].Value = TranType;
            return ExecuteTable("SPHBLReleased", objp);
        }
        //cost sheet
        public DataTable GetBLDetails4CostSheet(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFEBLDetail4CostSheet", objp);
        }
        public DataTable GetQuotchgs4Inv(int quotno, int bid,string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            objp[2].Value = bookingno;
            return ExecuteTable("SPGetQuotChgs4Inv", objp);
        }

        public DataTable GetCBMLimt4cont()
        {

            return ExecuteTable("SPSelCBMLimt");
        }
        //Dinesh

        public DataTable Getshipmentdetailscargodate(string blno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt)
                                                      
                                                     };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;

            return ExecuteTable("sp_getshipmentdetailscargodate", objp);
        }

        //MUTHURAJ

        public DataTable GetLikeALLBL(string strBlno, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {     
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype",SqlDbType.VarChar,4)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("SPLikeBLNOALL", objp);
        }


        //Dinesh
        public DataTable GetLikeBLDetailsnew(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFEBLnew", objp);
        }

        //Dinesh
        public DataTable GetQuotchgs4debitcreditFE(int quotno, int bid, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            objp[2].Value = bookingno;
            return ExecuteTable("sp_autodebitcreditfe", objp);
        }


        public DataTable GetBuyingchgs4debitcredit(int buyingno, int bid, string bookingno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@buyingno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = buyingno;
            objp[1].Value = bid;
            objp[2].Value = bookingno;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetBuyingchgs4debitcredit", objp);
        }

        public DataTable GetQuotchgs4InvFI(int quotno, int bid, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            objp[2].Value = bookingno;
            return ExecuteTable("SPGetQuotChgs4InvFI", objp);
        }

        public DataTable GetBuyingchgs4debitcredit1(int buyingno, int bid, string bookingno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@buyingno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = buyingno;
            objp[1].Value = bid;
            objp[2].Value = bookingno;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetBuyingchgs4debitcredit1", objp);
        }

        //Dinesh
        public DataTable GetQuotchgs4debitcreditFI(int quotno, int bid, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            objp[2].Value = bookingno;
            return ExecuteTable("sp_autodebitcreditfi", objp);
        }


        public DataTable getsp_getbookingno(string mbl, string trantype, int div)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@mbl", SqlDbType.VarChar ,100),   // new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                     };
            objp[0].Value = mbl;
            objp[1].Value = trantype;
            objp[2].Value = div;
            return ExecuteTable("sp_getbookingno", objp);
        }

        public DataTable GetCreditApprovalFromCustomer(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                      { 
                                                        new SqlParameter("@customerid", SqlDbType.Int),
                                                        
                                                      };
            objp[0].Value = customerid;
           
          
            return ExecuteTable("SPGetCreditApprovalFromCustomer", objp);
        }


        public DataTable Gettdsforcustomer(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                      { 
                                                        new SqlParameter("@customerid", SqlDbType.Int),
                                                        
                                                      };
            objp[0].Value = customerid;


            return ExecuteTable("spgettdsforcustomer", objp);
        }


        //NEW
        public DataTable GETAEIBLTransfer(int intBranchid, string TranType, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2) 
                                                     };
            objp[0].Value = intBranchid;
            objp[1].Value = intDivisionID;
            objp[2].Value = TranType;
            return ExecuteTable("SPSelAEIBLforTransfer", objp);
        }

        public void InsAEIBLTransfer(string blno, string Trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = blno;
            objp[1].Value = Trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPInsAEIBLTransfer", objp);
        }

        //Dinesh

        public DataTable GetLikeOTHERCHBLDetails(string strBlno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {     
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeOTHERchBL", objp);
        }

        //Elengo
        public string ContSizeverifyquataionandjob(string Shiprefno, int Jobno, int Bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@Shiprefno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@Jobno", SqlDbType.Int,4),
                                                           new SqlParameter("@Bid", SqlDbType.TinyInt)
                                                      };
            objp[0].Value = Shiprefno;
            objp[1].Value = Jobno;
            objp[2].Value = Bid;
            return ExecuteReader("SPContSizeverifyquataionandjob", objp);
        }
        public void UpdateAgentaddress(string strBLNo, string agentaddress, int intBranchID, int intDivisionID)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                         new SqlParameter("@agentaddress",SqlDbType.VarChar,250),      
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = strBLNo;
            objp[1].Value = agentaddress;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPUpdFEBLPrint4Agentadd", objp);
        }
       public void   updmovetypeinbl(string strBLNo,  int intBranchID, int movetype)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                         new SqlParameter("@bid",SqlDbType.Int),      
                                                         new SqlParameter("@movetype", SqlDbType.Int)
                                                        
                                                     };

            objp[0].Value = strBLNo;
            objp[1].Value = intBranchID;
            objp[2].Value = movetype;

            ExecuteQuery("updmovetypeinbl", objp);

        }
        public void InsSOBdate(string strBLNo, int intBranchID, DateTime sobdate)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid",SqlDbType.Int),
                                                         new SqlParameter("@sobdate", SqlDbType.DateTime)

                                                     };

            objp[0].Value = strBLNo;
            objp[1].Value = intBranchID;
            objp[2].Value = sobdate;

            ExecuteQuery("SpInsSOBdate", objp);

        }
        public void UpddescannexinFEBLdetails(string strBLNo, int intBranchID, string descannex)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid",SqlDbType.Int),
                                                         new SqlParameter("@descannex", SqlDbType.VarChar,5000)

                                                     };

            objp[0].Value = strBLNo;
            objp[1].Value = intBranchID;
            objp[2].Value = descannex;

            ExecuteQuery("SPUpddescannexinFEBLdetails", objp);

        }
        public void UpdateBLDetails4BLPrint4blrealse(string strBLNo, string pordetails, string poldetails, string poddetails, string fddetails, string pkgdetails, string cntrdetails, string blgrwt, string blntwt, string blcbm, int intBranchID, int intDivisionID)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@pordetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@poldetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@poddetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@fddetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@pkgdetails",SqlDbType.VarChar,30),
                                                         new SqlParameter("@cntrdetails",SqlDbType.VarChar,5000),
                                                         new SqlParameter("@blgrweight",SqlDbType.VarChar,15),
                                                         new SqlParameter("@blntweight",SqlDbType.VarChar,15),
                                                         new SqlParameter("@blcbm",SqlDbType.VarChar,15),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
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
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPUpdFEBLPrint4blrelease", objp);
        }
        public DataTable GETFEIBLTransferTask(int intBranchid, string TranType, int intDivisionID,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@empid", SqlDbType.Int)
                                                     };
            objp[0].Value = intBranchid;
            objp[1].Value = intDivisionID;
            objp[2].Value = TranType;
            objp[3].Value = empid;
            return ExecuteTable("SPSelFEIBLforTransferTask", objp);
        }

        public DataTable get_containeronly(int job, int intBranchID, int intDivisionID)
        {
            SqlParameter[] array = new SqlParameter[3]
            {
            new SqlParameter("@job", SqlDbType.VarChar, 30),
            new SqlParameter("@bid", SqlDbType.TinyInt),
            new SqlParameter("@did", SqlDbType.TinyInt)
            };
            array[0].Value = job;
            array[1].Value = intBranchID;
            array[2].Value = intDivisionID;
            return ExecuteTable("SP_getcontaineronly", array);
        }
    }
}
