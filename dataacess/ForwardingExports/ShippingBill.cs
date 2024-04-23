using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
    public class ShippingBill:DBObject
    {
        Masters.MasterCustomer CustObj = new Masters.MasterCustomer();
        Masters.MasterPort PortObj = new Masters.MasterPort();
        Masters.MasterPackages PkgObj = new Masters.MasterPackages();

        int intPkgID; // Package id


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ShippingBill()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsShipBill(string intBkgNo, string strSbNo, DateTime datSbDate, int intSprID, int intCneeID, int intNptyID, int intCnfID, string strMarks, string strDescn, int intPOR, int intPOL, int intPOD, int intPLD, int intNoofPkg, string strPkg, double dblGrWt, double dblNtWt, string strGrNo, DateTime datGrDate, string strCsNo, string strHtsCode, int intJobno, string dblVolume, int intBranchID, int PreparedBy, int intDivisionID, int billid)
        {

            intPkgID = PkgObj.GetNPackageid(strPkg);

            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@sbno",SqlDbType.VarChar,10),        
                                                     new SqlParameter("@sbdate",SqlDbType.SmallDateTime,4), 
                                                     new SqlParameter("@shipper",SqlDbType.Int,4),
                                                     new SqlParameter("@consignee",SqlDbType.Int,4),
                                                     new SqlParameter("@notifyparty",SqlDbType.Int,4),
                                                     new SqlParameter("@cnf",SqlDbType.Int,4),
                                                     new SqlParameter("@marks",SqlDbType.VarChar,200), 
                                                     new SqlParameter("@descn",SqlDbType.VarChar,500),
                                                     new SqlParameter("@por",SqlDbType.Int,4),        
                                                     new SqlParameter("@pol",SqlDbType.Int,4), 
                                                     new SqlParameter("@pod",SqlDbType.Int,4),
                                                     new SqlParameter("@pld",SqlDbType.Int,4),
                                                     new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                     new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                     new SqlParameter("@grosswt",SqlDbType.Real,4), 
                                                     new SqlParameter("@netwt",SqlDbType.Real,4),                                                                                     
                                                     new SqlParameter("@grno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@grdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@csno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@htscode",SqlDbType.VarChar,15),
                                                     new SqlParameter("@job",SqlDbType.Int,4),
                                                     new SqlParameter("@volume",SqlDbType.VarChar,10),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@bid", SqlDbType.TinyInt),
                                                     new SqlParameter("@cid", SqlDbType.TinyInt),
                                                     new SqlParameter("@billid",SqlDbType.Int,4)
                                                   };

            objp[0].Value = intBkgNo;
            objp[1].Value = strSbNo;
            objp[2].Value = datSbDate;
            objp[3].Value = intSprID;
            objp[4].Value = intCneeID;
            objp[5].Value = intNptyID;
            objp[6].Value = intCnfID;
            objp[7].Value = strMarks;
            objp[8].Value = strDescn;
            objp[9].Value = intPOR;
            objp[10].Value = intPOL;
            objp[11].Value = intPOD;
            objp[12].Value = intPLD;
            objp[13].Value = intNoofPkg;
            objp[14].Value = intPkgID;
            objp[15].Value = dblGrWt;
            objp[16].Value = dblNtWt;
            objp[17].Value = strGrNo;
            objp[18].Value = datGrDate;
            objp[19].Value = strCsNo;
            objp[20].Value = strHtsCode;
            objp[21].Value = intJobno;
            objp[22].Value = dblVolume;
            objp[23].Value = PreparedBy;
            objp[24].Value = intBranchID;
            objp[25].Value = intDivisionID;
            objp[26].Value = billid;
            ExecuteQuery("SPInsShipBill", objp);
        }

        public void UpdShipBill(int intBkgNo, string strSbNo, DateTime datSbDate, int intSprID, int intCneeID, int intNptyID, int intCnfID, string strMarks, string strDescn, int intPOR, int intPOL, int intPOD, int intPLD, int intNoofPkg, string strPkg, double dblGrWt, double dblNtWt, string strGrNo, DateTime datGrDate, string strCsNo, string strHtsCode, int intJobno, string dblVolume, int intBranchID, int intDivisionID, int billid)
        {
            intPkgID = PkgObj.GetNPackageid(strPkg);
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@bookingno",SqlDbType.Int,4),
                                                         new SqlParameter("@sbno",SqlDbType.VarChar,10),        
                                                         new SqlParameter("@sbdate",SqlDbType.SmallDateTime), 
                                                         new SqlParameter("@shipper",SqlDbType.Int,4),
                                                         new SqlParameter("@consignee",SqlDbType.Int,4),
                                                         new SqlParameter("@notifyparty",SqlDbType.Int,4),
                                                         new SqlParameter("@cnf",SqlDbType.Int,4),
                                                         new SqlParameter("@marks",SqlDbType.VarChar,200), 
                                                         new SqlParameter("@descn",SqlDbType.VarChar,500),
                                                         new SqlParameter("@por",SqlDbType.Int,4),        
                                                         new SqlParameter("@pol",SqlDbType.Int,4), 
                                                         new SqlParameter("@pod",SqlDbType.Int,4),
                                                         new SqlParameter("@pld",SqlDbType.Int,4),
                                                         new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                         new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                         new SqlParameter("@grosswt",SqlDbType.Real,4), 
                                                         new SqlParameter("@netwt",SqlDbType.Real,4),                                                                                     
                                                         new SqlParameter("@grno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@grdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@csno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@htscode",SqlDbType.VarChar,15),
                                                         new SqlParameter("@job",SqlDbType.Int,4),
                                                         new SqlParameter("@volume",SqlDbType.VarChar,10),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                     new SqlParameter("@billid",SqlDbType.Int,4)
                                                    };
            objp[0].Value = intBkgNo;
            objp[1].Value = strSbNo;
            objp[2].Value = datSbDate;
            objp[3].Value = intSprID;
            objp[4].Value = intCneeID;
            objp[5].Value = intNptyID;
            objp[6].Value = intCnfID;
            objp[7].Value = strMarks;
            objp[8].Value = strDescn;
            objp[9].Value = intPOR;
            objp[10].Value = intPOL;
            objp[11].Value = intPOD;
            objp[12].Value = intPLD;
            objp[13].Value = intNoofPkg;
            objp[14].Value = intPkgID;
            objp[15].Value = dblGrWt;
            objp[16].Value = dblNtWt;
            objp[17].Value = strGrNo;
            objp[18].Value = datGrDate;
            objp[19].Value = strCsNo;
            objp[20].Value = strHtsCode;
            objp[21].Value = intJobno;
            objp[22].Value = dblVolume;
            objp[23].Value = intBranchID;
            objp[24].Value = intDivisionID;
            objp[25].Value = billid;
            ExecuteQuery("SPUpdShipBill", objp);
        }



        public DataTable GetShipBill(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelShipBill", objp);
        }

        public DataTable GetShippingBill(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID ;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelShippingBill", objp);
        }

        public DataTable GetLikeShipBill(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeSBill", objp);
        }

        public string GetShipRefNo(int bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@bookingno", SqlDbType.Int, 4),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = bookingno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteReader("SPGetShipRefNo", objp);
        }
        
        public int CheckShipBillNo(string sbno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = sbno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return int.Parse(ExecuteReader("SPCheckShipBillNo", objp));
        }


        public void InsContDetail(int intJbNo, string strContNo, string strSizeType, string strSealNo, string strBLNo, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno",SqlDbType.Int),
                                                          new SqlParameter("@containerno",SqlDbType.VarChar,30),        
                                                          new SqlParameter("@sizetype",SqlDbType.VarChar,6), 
                                                          new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intJbNo;
            objp[1].Value = strContNo;
            objp[2].Value = strSizeType;
            objp[3].Value = strSealNo;
            objp[4].Value = strBLNo;
            objp[5].Value = intBranchID ;
            objp[6].Value = intDivisionID;
            ExecuteQuery("SPInsShippingContainer", objp);
        }

        public void DelContDetails(int intJbNo, string strBLNo, string containerno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                       new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)};
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = containerno;
            objp[3].Value =  intBranchID ;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPDelShippingContainerDetls", objp);
        }

        public DataTable GetContainerDetails(int intJbNo, string strBLNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                      {
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                      };
            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPShippingContainers", objp);
        }

        public void DelContainerDetails(int intJbNo, string strBLNo, int intBranchID,int intDivisionID)
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
            ExecuteQuery("SPDelShippingContainerDetails", objp);
        }
        
        public DataTable GetShipBill4web(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelShipBill4web", objp);
        }
        //salquery
        public DataTable GetLikeSalesShipBill(string strSbNo, int intBranchID, int intDivisionID, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                       new SqlParameter ("@salesid",SqlDbType .Int ,4) 
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = salesid;
            return ExecuteTable("SPLikeSalesSBill", objp);
        }
        public string GetBillName(int billid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billid", SqlDbType.Int, 4) };
            objp[0].Value = billid;
            return ExecuteReader("SPGetBillName", objp);
        }
        public DataTable GetLikeBillTypes(string billname, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billname", SqlDbType.VarChar, 25),
                                                       new SqlParameter("@billtype",SqlDbType.VarChar,2)};
            objp[0].Value = billname;
            objp[1].Value = type;
            return ExecuteTable("SpLikeBillTypes", objp);
        }
        //..............guru............//
        public DataTable Getsbno()
        {
            return ExecuteTable("SP_WithoutBooking");
        }


        public DataTable GetSearchsbno(string sbno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sbno", SqlDbType.VarChar, 30) };
            objp[0].Value = sbno;
            return ExecuteTable("SP_WithoutBookingSearch", objp);
        }


        public void GetUpdShipRefNo(int bookingno, string sbno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@bookingno", SqlDbType.Int, 4),
                                                           new SqlParameter("@sbno", SqlDbType.VarChar,30)                                                         
                                                     };
            objp[0].Value = bookingno;
            objp[1].Value = sbno;

            ExecuteQuery("SP_UpdateWithoutBooking", objp);
        }

        public DataTable GetviewShipRefNo(string shiprefno)
        {
            SqlParameter[] objp = new SqlParameter[] {                                                         
                                                           new SqlParameter("@shiprefno", SqlDbType.VarChar,30)                                                         
                                                     };
            objp[0].Value = shiprefno;
            return ExecuteTable("SP_GetShiprefno", objp);
        }

        //..........................guru.............//
        public DataTable GetLikeShipBillNew(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeSBillNew", objp);
        }

        public int Getjobcombooking(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@ship", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return int.Parse(ExecuteReader("sp_selectjob", objp));
        }



        public DataTable Getshippingbill(int branchid, string sbno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.VarChar, 10),
             new SqlParameter("@sbno", SqlDbType.VarChar, 20)};
            objp[0].Value = branchid;
            objp[1].Value = sbno;
            return ExecuteTable("spshippingbill", objp);
        }
        public DataTable GetShippingBillinbooking(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelShippingBillinbooking", objp);
        }
        public DataTable GetLikeShipBillinbooking(string strSbNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strSbNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeSBillinbooking", objp);
        }
    }
}
