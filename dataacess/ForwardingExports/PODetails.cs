using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
    public class PODetails : DBObject
    {
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public PODetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsPODetails(int intBookNo, string strPONo, string strStyle, int intPieces, int intCartons, float fltWeight, string strDimsn, string strTrtype, string strInvNo, DateTime datInvDate, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@bookno",SqlDbType.Int,4),        
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@style",SqlDbType.VarChar,25),
                                                         new SqlParameter("@pieces",SqlDbType.Int,4),
                                                         new SqlParameter("@cartons",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Float,4),
                                                         new SqlParameter("@dimension",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@invno",SqlDbType.VarChar,10),
                                                         new SqlParameter("@invdate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = intBookNo;
            objp[1].Value = strPONo;
            objp[2].Value = strStyle;
            objp[3].Value = intPieces;
            objp[4].Value = intCartons;
            objp[5].Value = fltWeight;
            objp[6].Value = strDimsn;
            objp[7].Value = strTrtype;
            objp[8].Value = strInvNo;
            objp[9].Value = datInvDate;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPInsPODetails", objp);
        }

        public void UpdPODetails(string strPONo, string strStyle, int intPieces, int intCartons, float fltWeight, string strDimsn, string strTrtype, string strInvNo, DateTime datInvDate, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@style",SqlDbType.VarChar,25),
                                                         new SqlParameter("@pieces",SqlDbType.Int,4),
                                                         new SqlParameter("@cartons",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Float,4),
                                                         new SqlParameter("@dimension",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@invno",SqlDbType.VarChar,10),
                                                         new SqlParameter("@invdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strStyle;
            objp[2].Value = intPieces;
            objp[3].Value = intCartons;
            objp[4].Value = fltWeight;
            objp[5].Value = strDimsn;
            objp[6].Value = strTrtype;
            objp[7].Value = strInvNo;
            objp[8].Value = datInvDate;
            objp[9].Value = intBranchID;
            objp[10].Value = intDivisionID;
            ExecuteQuery("SPUpdPODetails", objp);
        }
        //public void InsPODetails1(string intBookNo, string strPONo, string strStyle, int intPieces, int intCartons, float fltWeight, string strDimsn, string strTrtype, string strInvNo, DateTime datInvDate, int intBranchID, int intDivisionID, string agentrefno, string unittype, string remarks, string dvrypnt, DateTime dvrydt,int agentid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //                                                 new SqlParameter("@bookno",SqlDbType.VarChar,15),        
        //                                                 new SqlParameter("@pono",SqlDbType.VarChar,15), 
        //                                                 new SqlParameter("@style",SqlDbType.VarChar,25),
        //                                                 new SqlParameter("@pieces",SqlDbType.Int,4),
        //                                                 new SqlParameter("@cartons",SqlDbType.Int,4),
        //                                                 new SqlParameter("@weight",SqlDbType.Float,4),
        //                                                 new SqlParameter("@dimension",SqlDbType.VarChar,15), 
        //                                                 new SqlParameter("@trantype",SqlDbType.VarChar,2),
        //                                                 new SqlParameter("@invno",SqlDbType.VarChar,15),
        //                                                 new SqlParameter("@invdate",SqlDbType.SmallDateTime,4), 
        //                                                 new SqlParameter("@bid", SqlDbType.TinyInt),
        //                                                 new SqlParameter("@cid", SqlDbType.TinyInt),
        //                                                 new SqlParameter ("@agentrefno",SqlDbType .VarChar ,30),
        //                                                 new SqlParameter ("@unittype",SqlDbType .VarChar ,15),
        //                                                 new SqlParameter ("@remarks",SqlDbType .VarChar ,50),
        //                                                 new SqlParameter ("@dvrypint",SqlDbType .VarChar ,50),
        //                                                 new SqlParameter ("@dvrydt",SqlDbType.SmallDateTime  ,50),
        //                                                 new SqlParameter("@agentid",SqlDbType.Int)

        //                                            };
        //    objp[0].Value = intBookNo;
        //    objp[1].Value = strPONo;
        //    objp[2].Value = strStyle;
        //    objp[3].Value = intPieces;
        //    objp[4].Value = intCartons;
        //    objp[5].Value = fltWeight;
        //    objp[6].Value = strDimsn;
        //    objp[7].Value = strTrtype;
        //    objp[8].Value = strInvNo;
        //    objp[9].Value = datInvDate;
        //    objp[10].Value = intBranchID;
        //    objp[11].Value = intDivisionID;
        //    objp[12].Value = agentrefno;
        //    objp[13].Value = unittype;
        //    objp[14].Value = remarks;
        //    objp[15].Value = dvrypnt;
        //    objp[16].Value = dvrydt;
        //    objp[17].Value = agentid;
        //    ExecuteQuery("SPInsPODetails1", objp);
        //}
        public void InsPODetails1(string intBookNo, string strPONo, string strStyle, int intPieces, int intCartons, float fltWeight, string strDimsn, string strTrtype, string strInvNo, DateTime datInvDate, int intBranchID, int intDivisionID, string agentrefno, string unittype, string remarks, string dvrypnt, DateTime dvrydt, int agentid, string squsize, string squcolor)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@bookno",SqlDbType.VarChar,15),        
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@style",SqlDbType.VarChar,25),
                                                         new SqlParameter("@pieces",SqlDbType.Int,4),
                                                         new SqlParameter("@cartons",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Float,4),
                                                         new SqlParameter("@dimension",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@invno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@invdate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter ("@agentrefno",SqlDbType .VarChar ,30),
                                                         new SqlParameter ("@unittype",SqlDbType .VarChar ,15),
                                                         new SqlParameter ("@remarks",SqlDbType .VarChar ,50),
                                                         new SqlParameter ("@dvrypint",SqlDbType .VarChar ,50),
                                                         new SqlParameter ("@dvrydt",SqlDbType.SmallDateTime  ,50),
                                                         new SqlParameter("@agentid",SqlDbType.Int),
                                                         new SqlParameter ("@SQUsize",SqlDbType .VarChar ,25),
                                                         new SqlParameter ("@SQUcolor",SqlDbType .VarChar ,25)
                                                    };
            objp[0].Value = intBookNo;
            objp[1].Value = strPONo;
            objp[2].Value = strStyle;
            objp[3].Value = intPieces;
            objp[4].Value = intCartons;
            objp[5].Value = fltWeight;
            objp[6].Value = strDimsn;
            objp[7].Value = strTrtype;
            objp[8].Value = strInvNo;
            objp[9].Value = datInvDate;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            objp[12].Value = agentrefno;
            objp[13].Value = unittype;
            objp[14].Value = remarks;
            objp[15].Value = dvrypnt;
            objp[16].Value = dvrydt;
            objp[17].Value = agentid;
            objp[18].Value = squsize;
            objp[19].Value = squcolor;
            ExecuteQuery("SPInsPODetails1", objp);
        }


        public void UpdPODetails1(string strPONo, string strStyle, int intPieces, int intCartons, float fltWeight, string strDimsn, string strTrtype, string strInvNo, DateTime datInvDate, int intBranchID, int intDivisionID, string agentrefno, string unittype, string remarks,int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@style",SqlDbType.VarChar,25),
                                                         new SqlParameter("@pieces",SqlDbType.Int,4),
                                                         new SqlParameter("@cartons",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Float,4),
                                                         new SqlParameter("@dimension",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@invno",SqlDbType.VarChar,10),
                                                         new SqlParameter("@invdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter ("@agentrefno",SqlDbType .VarChar ,30),
                                                         new SqlParameter ("@unittype",SqlDbType .VarChar ,15),
                                                         new SqlParameter ("@remarks",SqlDbType .VarChar ,50),
                                                         new SqlParameter("@agentid",SqlDbType.Int)

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strStyle;
            objp[2].Value = intPieces;
            objp[3].Value = intCartons;
            objp[4].Value = fltWeight;
            objp[5].Value = strDimsn;
            objp[6].Value = strTrtype;
            objp[7].Value = strInvNo;
            objp[8].Value = datInvDate;
            objp[9].Value = intBranchID;
            objp[10].Value = intDivisionID;
            objp[11].Value = agentrefno;
            objp[12].Value = unittype;
            objp[13].Value = remarks;
            objp[14].Value = agentid;
            ExecuteQuery("SPUpdPODetails1", objp);
        }
        public DataTable GetBookingDet(string strBookNo, string strTrantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@bookingno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = strBookNo;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPBookingCname", objp);
        }

        public DataTable GetPODetails(string strPONo, string strTrantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                            new SqlParameter("@pono", SqlDbType.VarChar, 15),
                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                            new SqlParameter("@bid",SqlDbType.TinyInt),
                                                            new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPPOnodetails", objp);
        }

        public void DelPoDetails(string strPONo, string strbookno)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,15)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;

            ExecuteQuery("SPDelPodtls", objp);
        }



        public DataTable getbookdt(string bookno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@bookingno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)      

                                                     };
            objp[0].Value = bookno;
            objp[1].Value = bid;
            objp[2].Value = cid;

            return ExecuteTable("SpGetBook", objp);
        }

        public DataTable GetBkgNoList(string strTrantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                   };
            objp[0].Value = strTrantype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPBkgNoList", objp);
        }

        public DataTable GetLikePODetails(string pono, string strTrantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@pono", SqlDbType.VarChar, 15),
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = pono;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPLikePOno", objp);
        }
        public DataTable GetPo4XML(string bookingno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int)
        };
            objp[0].Value = bookingno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetPo4XML", objp);
        }

        public DataTable GetShiprefno4XML(int booking, string shiprefno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.Int),
                new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int)
        };
            objp[0].Value = booking;
            objp[1].Value = shiprefno;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;
            return ExecuteTable("SPGetShiprefno4Xml", objp);
        }

        public DataTable GetContr4XML(string bookingno, string pono, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                new SqlParameter("@pono",SqlDbType.VarChar,30),
                 new SqlParameter("@bid",SqlDbType.TinyInt),
                 new SqlParameter("@cid",SqlDbType.TinyInt)
        };
            objp[0].Value = bookingno;
            objp[1].Value = pono;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetContr4XML", objp);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////POSTUFFDETAILS///////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////


        public DataTable GetContainer4postuff(string blno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@blno",SqlDbType.VarChar,30),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@divisionid",SqlDbType.Int,4)
            };
            objp[0].Value = blno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetContainerno4mbooking", objp);
        }

        public void InsPostuff(string bookingno, string containerno, string pono, string invoiceno, string styleno, string pieces, string cartons, double weight, string squsize, string squcolor)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookno",SqlDbType.VarChar,30),
                new SqlParameter("@contno",SqlDbType.VarChar,30),
                new SqlParameter("@pono",SqlDbType.VarChar,30),
                new SqlParameter("@invoiceno",SqlDbType.VarChar,30),
                new SqlParameter("@styleno",SqlDbType.VarChar,30),
                new SqlParameter("@pieces",SqlDbType.VarChar,30),
                new SqlParameter("@cartons",SqlDbType.VarChar,30),
                new SqlParameter("@weight",SqlDbType.Decimal),
                new SqlParameter("@SQUsize",SqlDbType.VarChar,25),
                new SqlParameter("@SQUcolor",SqlDbType.VarChar,25)
            };

            objp[0].Value = bookingno;
            objp[1].Value = containerno;
            objp[2].Value = pono;
            objp[3].Value = invoiceno;
            objp[4].Value = styleno;
            objp[5].Value = pieces;
            objp[6].Value = cartons;
            objp[7].Value = weight;
            objp[8].Value = squsize;
            objp[9].Value = squcolor;
            ExecuteQuery("SPInsCompostuffdtls", objp);
        }



        public void Updpostuff(string bookingno, string containerno, string pono, string invoiceno, string styleno, string pieces, string cartons, int weight)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookno",SqlDbType.VarChar,30),
                new SqlParameter("@contno",SqlDbType.VarChar,30),
                new SqlParameter("@pono",SqlDbType.VarChar,30),
                new SqlParameter("@invoiceno",SqlDbType.VarChar,30),
                new SqlParameter("@styleno",SqlDbType.VarChar,30),
                new SqlParameter("@pieces",SqlDbType.VarChar,30),
                new SqlParameter("@cartons",SqlDbType.VarChar,30),
                new SqlParameter("@weight",SqlDbType.Int)
            };

            objp[0].Value = bookingno;
            objp[1].Value = containerno;
            objp[2].Value = pono;
            objp[3].Value = invoiceno;
            objp[4].Value = styleno;
            objp[5].Value = pieces;
            objp[6].Value = cartons;
            objp[7].Value = weight;

            ExecuteQuery("SPUpdCompostuffdtls", objp);
        }


        public DataTable GetCont4mBooking(string bookingno, string contno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                new SqlParameter("@contno",SqlDbType.VarChar,30)
          };
            objp[0].Value = bookingno;
            objp[1].Value = contno;
            return ExecuteTable("SPGetCont4Booking", objp);
        }



        public void DelPostuffDetails(string strPONo, string strbookno)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,15)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;

            ExecuteQuery("SPDelPostffdtls", objp);
        }

        public DataTable Get4mStuffDtls(string bookingno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int)
          };
            objp[0].Value = bookingno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetDtls4mcomstuff", objp);
        }


        public DataTable Getbook4mCont(string contno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@contno",SqlDbType.VarChar,30),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int)
          };
            objp[0].Value = contno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPGetBook4mCont", objp);
        }
        public DataTable GetPoCont4Mail(int bookno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int)
          };
            objp[0].Value = bookno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPGetPOcont4Mail", objp);
        }
        public void DelPoRowDetails(string strPONo, string strbookno, string strstyle)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                new SqlParameter("@style",SqlDbType.VarChar,30)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;
            objp[2].Value = strstyle;

            ExecuteQuery("SPDelPoRowdtls", objp);
        }
        public void DelPostuffRowDetails(string strPONo, string strbookno, string strstyle)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                new SqlParameter("@style",SqlDbType.VarChar,30)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;
            objp[2].Value = strstyle;

            ExecuteQuery("SPDelPostuffRowdtls", objp);
        }

        public DataTable GetPostuff4XML(string bookingno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int)
        };
            objp[0].Value = bookingno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetPostuff4XML", objp);
        }

        public DataTable Getlikebookingno(int bid, int cid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int),
                new SqlParameter("@trantype",SqlDbType.VarChar,4)
          };
            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = trantype;
            return ExecuteTable("SPgetlikebookingforpo", objp);
        }

        public DataTable Getlikebookfromtmp(string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.VarChar,30)
          };
            objp[0].Value = bookingno;
            return ExecuteTable("SPGetbookingfromtmp", objp);
        }
        public DataTable CHKPOAgentDtls(int bookno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.Int)
          };
            objp[0].Value = bookno;
            objp[1].Value = bid;
            return ExecuteTable("SPCHKPOAgentDtls", objp);
        }

        public DataTable CHKPOCustomerDtls(int bookno, int bid)  
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.Int)
          };
            objp[0].Value = bookno;
            objp[1].Value = bid;
            return ExecuteTable("SPCHKPOCustomerDtls", objp);
        }

        //eBooking
        public int InsertBookingDetails_web(DateTime bookingdate, string trantype, double volume, int incoid, string remark)
        {

            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@bookingdate",SqlDbType.DateTime,10),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remark",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@bookno",SqlDbType.Int,5)};
            objp[0].Value = bookingdate;
            objp[1].Value = trantype;
            objp[2].Value = volume;
            objp[3].Value = incoid;
            objp[4].Value = remark;
            objp[5].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsBookingWeb", objp, "@bookno");
        }

        public void InsEBookingdetails(int bookingno, int por, int pol, int pod, int fd, string shipper, string consignee, string notify)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bookno",SqlDbType.Int,5),
                                                        new SqlParameter("@por",SqlDbType.Int,5),
                                                        new SqlParameter("@pol",SqlDbType.Int,5),
                                                        new SqlParameter("@pod",SqlDbType.Int,5),
                                                        new SqlParameter("@fd",SqlDbType.Int,5),
                                                        new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                        new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                        new SqlParameter("@notify",SqlDbType.VarChar,100)};
            objp[0].Value = bookingno;
            objp[1].Value = por;
            objp[2].Value = pol;
            objp[3].Value = pod;
            objp[4].Value = fd;
            objp[5].Value = shipper;
            objp[6].Value = consignee;
            objp[7].Value = notify;
            ExecuteQuery("SPInseBookingdetails", objp);
        }
        public void InsPODetailsweb(string intBookNo, string strPONo, string strStyle, int intPieces, int intCartons, float fltWeight, string strDimsn, string strTrtype, string strInvNo, DateTime datInvDate, int intBranchID, int intDivisionID, string unittype, string remarks, DateTime cargodate, DateTime despatchdate, DateTime pickupdate, string str_marksno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@bookno",SqlDbType.VarChar,15),        
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@style",SqlDbType.VarChar,25),
                                                         new SqlParameter("@pieces",SqlDbType.Int,4),
                                                         new SqlParameter("@cartons",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Float,4),
                                                         new SqlParameter("@dimension",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@invno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@invdate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter ("@unittype",SqlDbType .VarChar ,15),
                                                         new SqlParameter ("@remarks",SqlDbType .VarChar ,50),
                                                         new SqlParameter ("@cargodate",SqlDbType .SmallDateTime ,50),
                                                         new SqlParameter ("@despatchdate",SqlDbType.SmallDateTime  ,50),
                                                         new SqlParameter("@pickupdate",SqlDbType.SmallDateTime,50),
                                                         new SqlParameter("@marksno",SqlDbType.VarChar,200)

                                                    };
            objp[0].Value = intBookNo;
            objp[1].Value = strPONo;
            objp[2].Value = strStyle;
            objp[3].Value = intPieces;
            objp[4].Value = intCartons;
            objp[5].Value = fltWeight;
            objp[6].Value = strDimsn;
            objp[7].Value = strTrtype;
            objp[8].Value = strInvNo;
            objp[9].Value = datInvDate;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            objp[12].Value = unittype;
            objp[13].Value = remarks;
            objp[14].Value = cargodate;
            objp[15].Value = despatchdate;
            objp[16].Value = pickupdate;
            objp[17].Value = str_marksno;
            ExecuteQuery("SPInsPODetailsweb", objp);
        }
        public void DelPoDetailsweb(int strbookno)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                        new SqlParameter("@bookingno",SqlDbType.Int,5)};

            objp[0].Value = strbookno;
            ExecuteQuery("SPDelPodtlsweb", objp);
        }




        //dinesh

        public string InsEBookingdetailsnew(string bookingno, string customername, int customerid, int branchid, string branch,
            string branchname, string stype, int pol, int por, int pod, int fd, string portname, int shipperid,
            string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty,
            string naddress, string marksno, int noofpks, string packageid, double grweight, double ntweight, int inco, int uno, string approved,
            string cargodet, string confirmed,string portcode)
        {

            string bookno = null;
            string monthyear = "";
            string m, y;
            m = logobj.GetDate().Month.ToString();
            //m = DateTime.Today.Month.ToString();
            if (m.Length < 2)
                m = "0" + m;
            y = DateTime.Today.Year.ToString();
            y = y.Substring(2, 2);
            //monthyear = m + y;

            monthyear = y;

            //shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString();
            bookno = portcode + monthyear.ToString();


            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bookno",SqlDbType.VarChar,100),
                                                        new SqlParameter("customername",SqlDbType.VarChar,1000),
                                                        new SqlParameter("@customerid",SqlDbType.Int,10),
                                                        new SqlParameter("@branchid",SqlDbType.Int,10),
                                                        new SqlParameter("@branch",SqlDbType.VarChar,100),
                                                        new SqlParameter("@branchname",SqlDbType.VarChar,1000),
                                                           new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@pol",SqlDbType.Int,4),
                                                          new SqlParameter("@por",SqlDbType.Int,4),
                                                           new SqlParameter("@pod",SqlDbType.Int,4),
                                                             new SqlParameter("@fd",SqlDbType.Int,4),
                                                          new SqlParameter("@portname",SqlDbType.VarChar,100),
                                                           new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                             new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                                new SqlParameter("@saddress",SqlDbType.VarChar,1000),

                                                                       new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                             new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                                new SqlParameter("@caddress",SqlDbType.VarChar,1000),

                                                                      new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                             new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                                new SqlParameter("@naddress",SqlDbType.VarChar,1000),

                                                                  new SqlParameter("@marksno",SqlDbType.VarChar,1000),

                                                                     new SqlParameter("@noofpks",SqlDbType.Int,4),
                                                                         new SqlParameter("@packageid",SqlDbType.VarChar,50),

                                                                               new SqlParameter("@grweight",SqlDbType.Decimal,18),
                                                                                 new SqlParameter("@ntweight",SqlDbType.Decimal,18),
                                                                                    new SqlParameter("@inco",SqlDbType.Int,4),
                                                                                      new SqlParameter("@uno",SqlDbType.Int,4),

                                                                                         new SqlParameter("@approved",SqlDbType.VarChar,1),
                                                                                          new SqlParameter("@cargodet",SqlDbType.VarChar,1000),

                                                                                               new SqlParameter("@confirmed",SqlDbType.VarChar,1),
                                                                                           new SqlParameter("@srefno",SqlDbType.VarChar,100),
            };
            objp[0].Value = bookno;
            objp[1].Value = customername;
            objp[2].Value = customerid;
            objp[3].Value = branchid;
            objp[4].Value = branch;
            objp[5].Value = branchname;
            objp[6].Value = stype;
            objp[7].Value = pol;
            objp[8].Value = por;
            objp[9].Value = pod;
            objp[10].Value = fd;
            objp[11].Value = portname;
            objp[12].Value = shipperid;
            objp[13].Value = shipper;
            objp[14].Value = saddress;
            objp[15].Value = consigneeid;
            objp[16].Value = consignee;
            objp[17].Value = caddress;
            objp[18].Value = notifypartyid;
            objp[19].Value = notifyparty;
            objp[20].Value = naddress;

            objp[21].Value = marksno;
            objp[22].Value = noofpks;
            objp[23].Value = packageid;
            objp[24].Value = grweight;
            objp[25].Value = ntweight;
            objp[26].Value = inco;
            objp[27].Value = uno;
            objp[28].Value = approved;
            objp[29].Value = cargodet;
            objp[30].Value = confirmed;
            objp[31].Direction = ParameterDirection.Output;

           // ExecuteQuery("SPInseBookingdetailsnew", objp);

            return ExecuteQuery("SPInseBookingdetailsnew", "@srefno", objp).ToString();
        }





        public void updEBookingdetailsnew(string bookingno, string customername, int customerid, int branchid, string branch,
           string branchname, string stype, int pol, int por, int pod, int fd, string portname, int shipperid,
           string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty,
           string naddress, string marksno, int noofpks, string packageid, double grweight, double ntweight, int inco, int uno, string approved,
           string cargodet, string confirmed)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bookno",SqlDbType.VarChar,100),
                                                        new SqlParameter("customername",SqlDbType.VarChar,1000),
                                                        new SqlParameter("@customerid",SqlDbType.Int,10),
                                                        new SqlParameter("@branchid",SqlDbType.Int,10),
                                                        new SqlParameter("@branch",SqlDbType.VarChar,100),
                                                        new SqlParameter("@branchname",SqlDbType.VarChar,1000),
                                                           new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@pol",SqlDbType.Int,4),
                                                          new SqlParameter("@por",SqlDbType.Int,4),
                                                           new SqlParameter("@pod",SqlDbType.Int,4),
                                                             new SqlParameter("@fd",SqlDbType.Int,4),
                                                          new SqlParameter("@portname",SqlDbType.VarChar,100),
                                                           new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                             new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                                new SqlParameter("@saddress",SqlDbType.VarChar,1000),

                                                                       new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                             new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                                new SqlParameter("@caddress",SqlDbType.VarChar,1000),

                                                                      new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                             new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                                new SqlParameter("@naddress",SqlDbType.VarChar,1000),

                                                                  new SqlParameter("@marksno",SqlDbType.VarChar,1000),

                                                                     new SqlParameter("@noofpks",SqlDbType.Int,4),
                                                                         new SqlParameter("@packageid",SqlDbType.VarChar,100),

                                                                               new SqlParameter("@grweight",SqlDbType.Decimal,18),
                                                                                 new SqlParameter("@ntweight",SqlDbType.Decimal,18),
                                                                                    new SqlParameter("@inco",SqlDbType.Int,4),
                                                                                      new SqlParameter("@uno",SqlDbType.Int,4),

                                                                                         new SqlParameter("@approved",SqlDbType.VarChar,1),
                                                                                          new SqlParameter("@cargodet",SqlDbType.VarChar,1000),

                                                                                               new SqlParameter("@confirmed",SqlDbType.VarChar,1)
            };
            objp[0].Value = bookingno;
            objp[1].Value = customername;
            objp[2].Value = customerid;
            objp[3].Value = branchid;
            objp[4].Value = branch;
            objp[5].Value = branchname;
            objp[6].Value = stype;
            objp[7].Value = pol;
            objp[8].Value = por;
            objp[9].Value = pod;
            objp[10].Value = fd;
            objp[11].Value = portname;
            objp[12].Value = shipperid;
            objp[13].Value = shipper;
            objp[14].Value = saddress;
            objp[15].Value = consigneeid;
            objp[16].Value = consignee;
            objp[17].Value = caddress;
            objp[18].Value = notifypartyid;
            objp[19].Value = notifyparty;
            objp[20].Value = naddress;

            objp[21].Value = marksno;
            objp[22].Value = noofpks;
            objp[23].Value = packageid;
            objp[24].Value = grweight;
            objp[25].Value = ntweight;
            objp[26].Value = inco;
            objp[27].Value = uno;
            objp[28].Value = approved;
            objp[29].Value = cargodet;
            objp[30].Value = confirmed;

            ExecuteQuery("SPupdeBookingdetailsnew", objp);
        }



        public void updatedateBookingdetailsnew(string ebookingno,int bid, DateTime bookingdate)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                        new SqlParameter("@bookno",SqlDbType.VarChar,100),
                                                        new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@bookingdate",SqlDbType.DateTime,8)};

            objp[0].Value = ebookingno;
            objp[1].Value = bid;
            objp[2].Value = bookingdate;
            ExecuteQuery("SPupdeBookingdetailsdatenew", objp);
        }


        public DataTable getbookingdetails(string bookno)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@bookingno",SqlDbType.VarChar,50)
                                                        

                                                     };
            objp[0].Value = bookno;


            return ExecuteTable("speboodetails", objp);
        }




        //Dinesh

        public void InsPostuffnewly(string bookingno, string containerno, string pono, string invoiceno, string styleno, string pieces, string cartons, double weight, string squsize, string squcolor)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookno",SqlDbType.VarChar,100),
                new SqlParameter("@contno",SqlDbType.VarChar,30),
                new SqlParameter("@pono",SqlDbType.VarChar,30),
                new SqlParameter("@invoiceno",SqlDbType.VarChar,30),
                new SqlParameter("@styleno",SqlDbType.VarChar,30),
                new SqlParameter("@pieces",SqlDbType.VarChar,30),
                new SqlParameter("@cartons",SqlDbType.VarChar,30),
                new SqlParameter("@weight",SqlDbType.Decimal),
                new SqlParameter("@SQUsize",SqlDbType.VarChar,25),
                new SqlParameter("@SQUcolor",SqlDbType.VarChar,25)
            };

            objp[0].Value = bookingno;
            objp[1].Value = containerno;
            objp[2].Value = pono;
            objp[3].Value = invoiceno;
            objp[4].Value = styleno;
            objp[5].Value = pieces;
            objp[6].Value = cartons;
            objp[7].Value = weight;
            objp[8].Value = squsize;
            objp[9].Value = squcolor;
            ExecuteQuery("SPInsCompostuffdtlsnewly", objp);
        }
        public DataTable GetBookingDetnewly(string strBookNo, string strTrantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@bookingno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = strBookNo;
            objp[1].Value = strTrantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPBookingCnamenewly", objp);
        }


        public DataTable Get4mStuffDtlsnewly(string bookingno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@cid",SqlDbType.Int)
          };
            objp[0].Value = bookingno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetDtls4mcomstuffnewly", objp);
        }



        public DataTable getbookdtnewly(string bookno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@bookingno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)      

                                                     };
            objp[0].Value = bookno;
            objp[1].Value = bid;
            objp[2].Value = cid;

            return ExecuteTable("SpGetBooknewly", objp);
        }


        public DataTable Getlikebookfromtmpnewly(string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@bookingno",SqlDbType.VarChar,30)
          };
            objp[0].Value = bookingno;
            return ExecuteTable("SPGetbookingfromtmpnewly", objp);
        }



        public void DelPostuffDetailsnewly(string strPONo, string strbookno)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,100),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,15)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;

            ExecuteQuery("SPDelPostffdtlsnewly", objp);
        }

        public void DelPoDetailsnewly(string strPONo, string strbookno)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,100)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;

            ExecuteQuery("SPDelPodtlsnewly", objp);
        }



        public void InsPODetails1newly(string intBookNo, string strPONo, string strStyle, int intPieces, int intCartons, float fltWeight, string strDimsn, string strTrtype, string strInvNo, DateTime datInvDate, int intBranchID, int intDivisionID, string agentrefno, string unittype, string remarks, string dvrypnt, DateTime dvrydt, int agentid, string squsize, string squcolor)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@bookno",SqlDbType.VarChar,100),        
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@style",SqlDbType.VarChar,25),
                                                         new SqlParameter("@pieces",SqlDbType.Int,4),
                                                         new SqlParameter("@cartons",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Float,4),
                                                         new SqlParameter("@dimension",SqlDbType.VarChar,15), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@invno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@invdate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter ("@agentrefno",SqlDbType .VarChar ,30),
                                                         new SqlParameter ("@unittype",SqlDbType .VarChar ,15),
                                                         new SqlParameter ("@remarks",SqlDbType .VarChar ,50),
                                                         new SqlParameter ("@dvrypint",SqlDbType .VarChar ,50),
                                                         new SqlParameter ("@dvrydt",SqlDbType.SmallDateTime  ,50),
                                                         new SqlParameter("@agentid",SqlDbType.Int),
                                                         new SqlParameter ("@SQUsize",SqlDbType .VarChar ,25),
                                                         new SqlParameter ("@SQUcolor",SqlDbType .VarChar ,25)
                                                    };
            objp[0].Value = intBookNo;
            objp[1].Value = strPONo;
            objp[2].Value = strStyle;
            objp[3].Value = intPieces;
            objp[4].Value = intCartons;
            objp[5].Value = fltWeight;
            objp[6].Value = strDimsn;
            objp[7].Value = strTrtype;
            objp[8].Value = strInvNo;
            objp[9].Value = datInvDate;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            objp[12].Value = agentrefno;
            objp[13].Value = unittype;
            objp[14].Value = remarks;
            objp[15].Value = dvrypnt;
            objp[16].Value = dvrydt;
            objp[17].Value = agentid;
            objp[18].Value = squsize;
            objp[19].Value = squcolor;
            ExecuteQuery("SPInsPODetails1newly", objp);
        }


        public void DelPostuffRowDetailsnewly(string strPONo, string strbookno, string strstyle)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,100),
                new SqlParameter("@style",SqlDbType.VarChar,30)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;
            objp[2].Value = strstyle;

            ExecuteQuery("SPDelPostuffRowdtlsnewly", objp);
        }



        public void DelPoRowDetailsnewly(string strPONo, string strbookno, string strstyle)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@pono",SqlDbType.VarChar,15),
                 new SqlParameter("@bookingno",SqlDbType.VarChar,100),
                new SqlParameter("@style",SqlDbType.VarChar,30)
                                                              

                                                     };
            objp[0].Value = strPONo;
            objp[1].Value = strbookno;
            objp[2].Value = strstyle;

            ExecuteQuery("SPDelPoRowdtlsnewly", objp);
        }


        public void spinscustomsdetails(int BOEno, DateTime BOEDate, string InvCurr, double Invamt, double DUTYamt, DateTime DUTYpiaddatetimeamt, DateTime CustomesReleaseDate, DateTime DeliveryDate, string CLMCLRNote, string product, int bid, int cid, string blno,string producttype)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@BOEno",SqlDbType.Int,4),
                                                  new SqlParameter("@BOEDate",SqlDbType.SmallDateTime,4),       
                                                   new SqlParameter("@InvCurr",SqlDbType.VarChar, 10),
                                                     new SqlParameter("@Invamt",SqlDbType.Money,8),
                                                      new SqlParameter("@DUTYamt",SqlDbType.Money,8),
                                                       new SqlParameter("@DUTYpiaddatetimeamt",SqlDbType.SmallDateTime,4), 
                                                       new SqlParameter("@CustomesReleaseDate",SqlDbType.SmallDateTime,4),  
                                                            new SqlParameter("@DeliveryDate",SqlDbType.SmallDateTime,4),  
                                               new SqlParameter("@CLMCLRNote",SqlDbType.VarChar, 500),
                                               new SqlParameter("@product",SqlDbType.VarChar, 10),
                                                new SqlParameter("@bid",SqlDbType.Int,4),
                                                  new SqlParameter("@cid",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar, 50),
                                                      new SqlParameter("@producttype",SqlDbType.VarChar, 10)
                                     };


            objp[0].Value = BOEno;
            objp[1].Value = BOEDate;
            objp[2].Value = InvCurr;
            objp[3].Value = Invamt;
            objp[4].Value = DUTYamt;
            objp[5].Value = DUTYpiaddatetimeamt;
            objp[6].Value = CustomesReleaseDate;
            objp[7].Value = DeliveryDate;
            objp[8].Value = CLMCLRNote;
            objp[9].Value = product;
            objp[10].Value = bid;
            objp[11].Value = cid;
            objp[12].Value = blno;
            objp[13].Value = producttype;
            ExecuteQuery("spinscustomsdetails", objp);
        }


        public void spupdcustomsdetails(int BOEno, DateTime BOEDate, string InvCurr, double Invamt, double DUTYamt, DateTime DUTYpiaddatetimeamt, DateTime CustomesReleaseDate, DateTime DeliveryDate, string CLMCLRNote, string product, int bid, int cid, string blno, string producttype)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@BOEno",SqlDbType.Int,4),
                                                  new SqlParameter("@BOEDate",SqlDbType.SmallDateTime,4),       
                                                   new SqlParameter("@InvCurr",SqlDbType.VarChar, 10),
                                                     new SqlParameter("@Invamt",SqlDbType.Money,8),
                                                      new SqlParameter("@DUTYamt",SqlDbType.Money,8),
                                                       new SqlParameter("@DUTYpiaddatetimeamt",SqlDbType.SmallDateTime,4), 
                                                       new SqlParameter("@CustomesReleaseDate",SqlDbType.SmallDateTime,4),  
                                                            new SqlParameter("@DeliveryDate",SqlDbType.SmallDateTime,4),  
                                               new SqlParameter("@CLMCLRNote",SqlDbType.VarChar, 500),
                                               new SqlParameter("@product",SqlDbType.VarChar, 10),
                                                new SqlParameter("@bid",SqlDbType.Int,4),
                                                  new SqlParameter("@cid",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar, 50),
                                                     new SqlParameter("@producttype",SqlDbType.VarChar, 10)
                                     };


            objp[0].Value = BOEno;
            objp[1].Value = BOEDate;
            objp[2].Value = InvCurr;
            objp[3].Value = Invamt;
            objp[4].Value = DUTYamt;
            objp[5].Value = DUTYpiaddatetimeamt;
            objp[6].Value = CustomesReleaseDate;
            objp[7].Value = DeliveryDate;
            objp[8].Value = CLMCLRNote;
            objp[9].Value = product;
            objp[10].Value = bid;
            objp[11].Value = cid;
            objp[12].Value = blno;
            objp[13].Value = producttype;
            ExecuteQuery("spupdcustomsdetails", objp);
        }

        public DataTable spgetcustdetails( string product, int bid, int cid, string blno)
        {

            SqlParameter[] objp = new SqlParameter[]{
                                               new SqlParameter("@product",SqlDbType.VarChar, 10),
                                                new SqlParameter("@bid",SqlDbType.Int,4),
                                                  new SqlParameter("@cid",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar, 50)
                                     };


   
            objp[0].Value = product;
            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = blno;
            return ExecuteTable("spgetcustomsdetails", objp);
        }




        public DataTable getebookingbranch(string strBookNo)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@bookingno", SqlDbType.VarChar,50)
                                                       
                                                    };
            objp[0].Value = strBookNo;
           
            return ExecuteTable("spgetebookingbranch", objp);
        }

       /* public string getbookingdetails(string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                            new SqlParameter("@bookingno", SqlDbType.VarChar, 50)
                                                            
                                                     };
            objp[0].Value = bookingno;

            return ExecuteQuery("sp_bookingdetails", objp);
        }*/

        public string getbookingdetailsnew(string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                            new SqlParameter("@bookingno", SqlDbType.VarChar, 50)
                                                            
                                                     };
            objp[0].Value = bookingno;

            return ExecuteReader("sp_bookingdetails", objp);
        }




        public void spupdatebookingstatus(string strbookno, string status,int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {          
                                                         new SqlParameter("@strbookno",SqlDbType.VarChar,500),
                 new SqlParameter("@status",SqlDbType.VarChar,15),
                 new SqlParameter("@bid",SqlDbType.Int,4)
                                                              

                                                     };
            objp[0].Value = strbookno;
            objp[1].Value = status;
            objp[2].Value = bid;
            ExecuteQuery("spupdatebookingstatus", objp);
        }




     

        public DataTable getbookingdetailsjobtrantype(string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                            new SqlParameter("@bookingno", SqlDbType.VarChar, 50)
                                                            
                                                     };
            objp[0].Value = bookingno;

            return ExecuteTable("sp_bookingdetailsjobtrantype", objp);
        }
    }
}
