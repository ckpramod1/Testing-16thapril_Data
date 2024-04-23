using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{

    public class FEEvents : DBObject
    {



        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FEEvents()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetBookingPending(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelBookingPending", objp);
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
        public DataTable UpdDateDtlsDtls(int bid, string shiprefno, DateTime cargoon, DateTime railoutdate, DateTime inspect, DateTime received, DateTime custom)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
                                                     new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@cargorecvon",SqlDbType.DateTime),
                    new SqlParameter("@railoutdate",SqlDbType.DateTime),
                    new SqlParameter("@inspect",SqlDbType.DateTime),
                    new SqlParameter("@received",SqlDbType.DateTime),
                    new SqlParameter("@custom",SqlDbType.DateTime)
                                                     };
            objp[0].Value = bid;
            objp[1].Value = shiprefno;
            objp[2].Value = cargoon;
            objp[3].Value = railoutdate;
            objp[4].Value = inspect;
            objp[5].Value = received;
            objp[6].Value = custom;

            return ExecuteTable("SPUPDBookingDateDtls", objp);

        }
        public DataTable GetBookingPendingWJobNo(string trantype, int jobno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@jobno",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = jobno;
            return ExecuteTable("SPSelBookingPendingWJobNo", objp);
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
        //bharathi
        public DataTable GETDAte4Booking(string blno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                      }
                                                       ;
            objp[0].Value = blno;
            objp[1].Value = bid;

            return ExecuteTable("SPGETDAte4Booking", objp);
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
        public DataTable GetMBLReleasedPending(int bid, string frmtyp)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@bid",SqlDbType .Int ,4),
                 new SqlParameter ("@ftyp",SqlDbType.VarChar  ,4)
            };
            objp[0].Value = bid;
            objp[1].Value = frmtyp;
            return ExecuteTable("SPMblReleasedON", objp);
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
        public void UpdateMblrelease(int branchid, DateTime mblreleasedon, int jobno, string frmtyp)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@mblreleasedon", SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
             new SqlParameter("@ftyp", SqlDbType.VarChar ,4)};
            objp[0].Value = branchid;
            objp[1].Value = mblreleasedon;
            objp[2].Value = jobno;
            objp[3].Value = frmtyp;
            ExecuteQuery("SPUPDMblreleasedon", objp);
        }
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


        //arun
        public DataTable GetdateTimeHBLCnfRcvDtls(int jobno, string blno, string frmtyp, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                                                               
                                                         new SqlParameter("@frmtyp",SqlDbType.Char,4),                                                          
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = blno;

            objp[2].Value = frmtyp;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPGetReceiveValue", objp);
        }

        public DataTable GetCustomerEDIMailId(int EmpId)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                  new SqlParameter("@EmpId",SqlDbType.Int),
            };

            objp[0].Value = EmpId;
            return ExecuteTable("GetCustomerEDIMailId", objp);
        }

        public string INSmastercustomersiscodeupdate(int CustomerId, string status, string errormsg, int updatedby)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@CustomerId", SqlDbType.Int) ,
            new SqlParameter("@status", SqlDbType.VarChar,500) ,
            new SqlParameter("@errormsg", SqlDbType.VarChar,500) ,
            new SqlParameter("@updatedby", SqlDbType.Int) ,
        

            };
            objp[0].Value = CustomerId;
            objp[1].Value = status;
            objp[2].Value = errormsg;
            objp[3].Value = updatedby;

            return ExecuteReader("SPINSmastercustomersiscodeupdate", objp);
        }

        public DataTable Getstatus4custxml(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int)
                                                         };
            objp[0].Value = customerid;

            return ExecuteTable("SPGetstatus4custxml", objp);
        }
        public DataTable get_Gridviewnewone(int Customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                  new SqlParameter("@Customerid",SqlDbType.Int),
             };
            objp[0].Value = Customerid;

            return ExecuteTable("get_Gridviewdatadisplaynewshownew", objp);
        }
        public void insertcustomerbankaccountnew(int Customerid, int Bankid, string Accountnumber, string Account, string IFSCCode)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@Customerid", SqlDbType.Int),  
                new SqlParameter("@Bankid", SqlDbType.Int),
                new SqlParameter("@Accountnumber", SqlDbType.VarChar, 30),
                 new SqlParameter("@Account", SqlDbType.VarChar, 30),
                 new SqlParameter("@IFSCCode", SqlDbType.VarChar, 30),
            };
            objp[0].Value = Customerid;
            objp[1].Value = Bankid;
            objp[2].Value = Accountnumber;
            objp[3].Value = Account;
            objp[4].Value = IFSCCode;

            ExecuteQuery("insertcustomerbankaccountdetnew", objp);
        }
        public DataTable SPSelGetCustomerDetails4pan(string customername, int customerid, string gst)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 200),
           new SqlParameter("@customerid", SqlDbType.Int ),
           new SqlParameter("@gst", SqlDbType.VarChar, 50)

           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };
            objp[0].Value = customername;
            objp[1].Value = customerid;
            objp[2].Value = gst;
            return ExecuteTable("SPSelGetCustomerDetails4pan", objp);

        }
        public void Inscustpandtls(string PANno, string customername, int legaltype, int category, int facategory)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar,50),  
                new SqlParameter("@customername", SqlDbType.VarChar, 200),
                new SqlParameter("@legaltype", SqlDbType.Int),
                new SqlParameter("@category", SqlDbType.Int),
                new SqlParameter("@facategory", SqlDbType.Int)
                                               
            };
            objlim[0].Value = PANno;
            objlim[1].Value = customername;
            objlim[2].Value = legaltype;
            objlim[3].Value = category;
            objlim[4].Value = facategory;

            ExecuteQuery("Inscustpandtls", objlim);
        }
        public void UPdEnvoice4custpan(int panid, string einvoice)
        {


            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@panid",SqlDbType.Int),        
                                                       new SqlParameter("@einvoice",SqlDbType.VarChar,1) };
            objp[0].Value = panid;
            objp[1].Value = einvoice;

            ExecuteQuery("SPUPdEnvoice4custpan", objp);

        }
        public string kycDeleteProof(int mode, int Customerid, string Filename, int proofid)
        {
            SqlParameter[] objgridp = new SqlParameter[]{new SqlParameter("@mode",SqlDbType.Int,5),
                                                        new SqlParameter("@CustomerId",SqlDbType.Int,5),
                                                        new SqlParameter("@FileName",SqlDbType.VarChar,45),
                                                        new SqlParameter("@Proofid",SqlDbType.Int,5),};
            objgridp[0].Value = mode;
            objgridp[1].Value = Customerid;
            objgridp[2].Value = Filename;
            objgridp[3].Value = proofid;
            return ExecuteReader("sp_masterKycCustomer", objgridp);
        }
        public DataTable KycUploadnew(int mode, int Customerid, int Empid, int Proofid, string proof, string FileName, int customerpanid)
        {
            SqlParameter[] objkyc = new SqlParameter[]{new SqlParameter("@mode",SqlDbType.Int,5),
                                                new SqlParameter("@CustomerId",SqlDbType.Int,5),
                                            new SqlParameter("@Empid",SqlDbType.Int,5),
                                            new SqlParameter("@Proofid",SqlDbType.Int,5),
                                            new SqlParameter("@Proof",SqlDbType.VarChar,15),
                                            new SqlParameter("@FileName",SqlDbType.VarChar,45),
                                                 new SqlParameter("@customerpanid",SqlDbType.Int)};
            objkyc[0].Value = mode;
            objkyc[1].Value = Customerid;
            objkyc[2].Value = Empid;
            objkyc[3].Value = Proofid;
            objkyc[4].Value = proof;
            objkyc[5].Value = FileName;
            objkyc[6].Value = customerpanid;
            return ExecuteTable("sp_masterKycCustomernew", objkyc);
        }
        public DataTable SPSelKYCProofCust(string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Char, 5) };
            objp[0].Value = type;
            return ExecuteTable("spselallproofCust", objp);
        }
        //public DataTable Getstatus4custxml(int customerid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int)
        //                                                 };
        //    objp[0].Value = customerid;

        //    return ExecuteTable("SPGetstatus4custxml", objp);
        //}

      


    }
}
