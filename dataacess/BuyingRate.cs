using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class BuyingRate : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public BuyingRate()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsBuyingHead(int intLiner, int intCargo, int intPOL, int intPOD, char freight, DateTime validtill, char shipment, char dgcargo, char bulkvolume, double brokerage, int intObtainby, int intPrepareby, string remarks, int intPor, int intFD)
        {
            SqlParameter[] array = new SqlParameter[16]
            {
            new SqlParameter("@liner", SqlDbType.Int, 4),
            new SqlParameter("@cargo", SqlDbType.SmallInt, 2),
            new SqlParameter("@pol", SqlDbType.Int, 4),
            new SqlParameter("@pod", SqlDbType.Int, 4),
            new SqlParameter("@freight", SqlDbType.Char, 1),
            new SqlParameter("@validity", SqlDbType.SmallDateTime, 4),
            new SqlParameter("@shipment", SqlDbType.Char, 1),
            new SqlParameter("@dgcargo", SqlDbType.Char, 1),
            new SqlParameter("@bulkvolume", SqlDbType.Char, 1),
            new SqlParameter("@brokerage", SqlDbType.Real, 4),
            new SqlParameter("@obtainedby", SqlDbType.Int, 4),
            new SqlParameter("@preparedby", SqlDbType.Int, 4),
            new SqlParameter("@remarks", SqlDbType.VarChar, 100),
            new SqlParameter("@por", SqlDbType.Int, 4),
            new SqlParameter("@fd", SqlDbType.Int, 4),
            new SqlParameter("@rateid", SqlDbType.Int, 4)
            };
            array[0].Value = intLiner;
            array[1].Value = intCargo;
            array[2].Value = intPOL;
            array[3].Value = intPOD;
            array[4].Value = freight;
            array[5].Value = validtill;
            array[6].Value = shipment;
            array[7].Value = dgcargo;
            array[8].Value = bulkvolume;
            array[9].Value = brokerage;
            array[10].Value = intObtainby;
            array[11].Value = intPrepareby;
            array[12].Value = remarks;
            array[13].Value = intPor;
            array[14].Value = intFD;
            array[15].Direction = ParameterDirection.Output;
            IDataParameter[] parameters = array;
            return ExecuteQuery("SPInsBuyingHead", parameters, "@rateid");
        }

        public void InsBuyingDetails(int intRateid, int intChargeid, string currency, double Rate, string Base)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int, 4),
                                                       new SqlParameter("@curr", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@rate", SqlDbType.Money, 8),
                                                       new SqlParameter("@base", SqlDbType.VarChar, 40) };
            objp[0].Value = intRateid;
            objp[1].Value = intChargeid;
            objp[2].Value = currency;
            objp[3].Value = Rate;
            objp[4].Value = Base;
            ExecuteQuery("SPInsBuyingDetails", objp);
        }

        public void UpdBuyingHead(int intRateid, int intLiner, int intCargo, int intPOL, int intPOD, char freight,char shipment, char dgcargo, char bulkvolume,DateTime validity, double Brokerage, int intObtainby, int intPrepareby, string Remarks,int intPor,int intFD)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4), 
                                                       new SqlParameter("@liner", SqlDbType.Int, 4),
                                                       new SqlParameter("@cargo", SqlDbType.Int),
                                                       new SqlParameter("@pol", SqlDbType.Int, 4),
                                                       new SqlParameter("@pod", SqlDbType.Int, 4),
                                                       new SqlParameter("@freight", SqlDbType.Char, 1),
                                                       new SqlParameter("@shipment", SqlDbType.Char, 1),
                                                       new SqlParameter("@dgcargo", SqlDbType.Char, 1),
                                                       new SqlParameter("@bulkvolume", SqlDbType.Char, 1),
                                                       new SqlParameter("@validity", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@brokerage", SqlDbType.Real, 4),
                                                       new SqlParameter("@obtainedby", SqlDbType.Int),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 100),
                                                         new SqlParameter("@por",SqlDbType.Int,4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4)};
            objp[0].Value = intRateid;
            objp[1].Value = intLiner;
            objp[2].Value = intCargo;
            objp[3].Value = intPOL;
            objp[4].Value = intPOD;
            objp[5].Value = freight;
            objp[6].Value = shipment;
            objp[7].Value = dgcargo;
            objp[8].Value = bulkvolume;
            objp[9].Value = validity;
            objp[10].Value = Brokerage;
            objp[11].Value = intObtainby;
            objp[12].Value = intPrepareby;
            objp[13].Value = Remarks;
            objp[14].Value = intPor;
            objp[15].Value = intFD;
            ExecuteQuery("SPUpdBuyingHead", objp);
        }

        public void UpdBuyingDetails(int intRateid, int intChargeid, string currency, double Rate, string Base)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int, 4),
                                                       new SqlParameter("@curr", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@rate", SqlDbType.Money, 8),
                                                       new SqlParameter("@base", SqlDbType.VarChar, 45) };
            objp[0].Value = intRateid;
            objp[1].Value = intChargeid;
            objp[2].Value = currency;
            objp[3].Value = Rate;
            objp[4].Value = Base;
            ExecuteQuery("SPUpdBuyingDetails", objp);
        }

        public DataTable SelBuyingHead(int intRateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = intRateid;
            return ExecuteTable("SPselBuyingHead", objp);
        }

        public DataTable SelBuyingDetails(int intRateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = intRateid;
            return ExecuteTable("SPselBuyingDetails", objp);
        }

        public int CheckDetailsExist(int intLiner, int intCargo, int intPOL, int intPOD, char freight, char shipment, char dgcargo, char bulkvolume)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@liner", SqlDbType.Int, 4),
                                                       new SqlParameter("@cargo", SqlDbType.Int),
                                                       new SqlParameter("@pol", SqlDbType.Int, 4),
                                                       new SqlParameter("@pod", SqlDbType.Int, 4),
                                                       new SqlParameter("@freight", SqlDbType.Char, 1),
                                                       new SqlParameter("@shipment", SqlDbType.Char, 1),
                                                       new SqlParameter("@dgcargo", SqlDbType.Char, 1),
                                                       new SqlParameter("@bulkvolume", SqlDbType.Char, 1) };
            objp[0].Value = intLiner;
            objp[1].Value = intCargo;
            objp[2].Value = intPOL;
            objp[3].Value = intPOD;
            objp[4].Value = freight;
            objp[5].Value = shipment;
            objp[6].Value = dgcargo;
            objp[7].Value = bulkvolume;
            return int.Parse(ExecuteReader("SPselBuying", objp));
        }

        public void DelBuyingDetail(int intrateid, int intchargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int) };
            objp[0].Value = intrateid;
            objp[1].Value = intchargeid;
            ExecuteQuery("SPDelBuyingDetails", objp);
        }

        public void DelBuyingDetailnew(int intrateid, int intchargeid,String bases)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@base", SqlDbType.VarChar, 10)
            };
            objp[0].Value = intrateid;
            objp[1].Value = intchargeid;
            objp[2].Value = bases;
            ExecuteQuery("SPDelBuyingDetailsnew", objp);

        }
        public void UpdBuyHeadDelYes(int intRateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = intRateid;
            ExecuteQuery("SPUpdBuyHeadDelYes", objp);
        }
          public DataTable  BuyingChargeExist(int intrateid, int intchargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int) };
            objp[0].Value = intrateid;
            objp[1].Value = intchargeid;
            return ExecuteTable("SPSelBuyingchargeexist", objp);
        }
           public DataTable  SelectBuyingHeadAll(int rateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = rateid;
            return ExecuteTable("SPselectBuyingHead", objp);
        }
        public DataTable BuyingChargebaseExist(int intrateid, int intchargeid, string bbase)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,6)};
            objp[0].Value = intrateid;
            objp[1].Value = intchargeid;
            objp[2].Value = bbase;
            return ExecuteTable("SPSelBuyingchargebaseexist", objp);
        }
            
        //Query
        public DataTable GetBuyingQry4Liner(int pol, int pod, string cbase, string ftype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pol", SqlDbType.Int, 4),
                                                        new SqlParameter("@pod", SqlDbType.Int, 4),
                                                        new SqlParameter("@base",SqlDbType.VarChar,4),
                                                        new SqlParameter("@type",SqlDbType.VarChar,4)};
            objp[0].Value = pol;
            objp[1].Value = pod;
            objp[2].Value = cbase;
            objp[3].Value = ftype;
            return ExecuteTable("SPGetBuyingQry4Liner", objp);
        }
        public DataTable GetBuyingQry(int pol, int pod, int liner, int rateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pol", SqlDbType.Int, 4),
                                                        new SqlParameter("@pod", SqlDbType.Int, 4),
                                                        new SqlParameter("@liner", SqlDbType.Int, 4),
                                                        new SqlParameter("@rateid", SqlDbType.Int, 4)};
            objp[0].Value = pol;
            objp[1].Value = pod;
            objp[2].Value = liner;
            objp[3].Value = rateid;
            return ExecuteTable("SPGetBuyingQry", objp);
        }


        public DataTable GetRate()
        {

            return ExecuteTable("SPRateID");
        }
        //muthu
        //public DataTable selpandbooking(int bid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] 
        //    { 
        //        new SqlParameter("@bid", SqlDbType.Int, 4)
        //    };
        //    objp[0].Value = bid;
        //    return ExecuteTable("Sp_GetpendingBook", objp);
        //}

        //sambavaraj(muthu)
        public DataTable selpandbooking(int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2)
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            return ExecuteTable("Sp_GetpendingBook", objp);
        }

        public DataTable selpendingBookcutomerwisecount(int bid, string trantype,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                 new SqlParameter("@empid", SqlDbType.Int, 4),
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = empid;
            return ExecuteTable("Sp_GetpendingBookcutomerwisecountnew", objp);
        }


        public DataTable selpendingBookcosigneecountfibl(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int)
              
            };
            objp[0].Value = bid;
         
            return ExecuteTable("Sp_GetpendingBookcosigneewisecount", objp);
        }

        public DataTable selpendingBookcustomeridwise(int bid, string trantype, int custid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                 new SqlParameter("@customerid", SqlDbType.Int, 4),
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = custid;
            return ExecuteTable("Sp_GetpendingBookcustomeridwise", objp);
        }


        public DataTable selpendingBookcustomeridwisebl(int bid, string trantype, int custid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                 new SqlParameter("@customerid", SqlDbType.Int, 4),
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = custid;
            return ExecuteTable("Sp_GetpendingBookcustomeridwisebl", objp);
        }


        public DataTable SpSalesCustName(int bid, int div, int custid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@branchid", SqlDbType.Int),
                 new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@empid", SqlDbType.Int),
                 new SqlParameter("@trantype", SqlDbType.VarChar, 5),
            };
            objp[0].Value = bid;
            objp[1].Value = div;
            objp[2].Value = custid;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetCussalesNew", objp);
        }

        public DataTable SpSalesBooking(int bid, int div, int custid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@branchid", SqlDbType.Int),
                 new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@cusuid", SqlDbType.Int),
                 new SqlParameter("@trantype", SqlDbType.VarChar,10)
               
            };
            objp[0].Value = bid;
            objp[1].Value = div;
            objp[2].Value = custid;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetNewBookingsales", objp);
        }

        //MUTHU

        public DataTable Getworkinprogess(int salesid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@salesid", SqlDbType.Int),
                new SqlParameter("@bid", SqlDbType.TinyInt),
                   
            };

            objp[0].Value = salesid;
            objp[1].Value = bid;


            return ExecuteTable("SPGetWIPDetail", objp);
        }





        public DataTable SalesCustNameForBooking(int bid, int div, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@empid", SqlDbType.Int),                 
            };
            objp[0].Value = bid;
            objp[1].Value = div;
            objp[2].Value = empid;

            return ExecuteTable("SP_SalesCustNameForBooking", objp);
        }

        public DataTable GetNewBookingDetailscust(int bid, int div, int custid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@cusuid", SqlDbType.Int), 
                 new SqlParameter("@empid", SqlDbType.Int),               
            };

            objp[0].Value = bid;
            objp[1].Value = div;
            objp[2].Value = custid;
            objp[3].Value = empid;

            return ExecuteTable("SP_GetNewBookingDetails4Cust", objp);
        }

        public DataTable Getworkinprogesscount(int salesid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@salesid", SqlDbType.Int),
                new SqlParameter("@bid", SqlDbType.TinyInt),

            };

            objp[0].Value = salesid;
            objp[1].Value = bid;


            return ExecuteTable("sp_workingprogesscount", objp);
        } 


        //ARUN

        public DataSet selpendingBookcutomerwisecountForNew(int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2)
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            return ExecuteDataSet("SpBlNumberCount", objp);
        }

        public DataTable selpendingBookcutomerwisecount_Chart(int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2)
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            return ExecuteTable("SPGetBookingCounts", objp);  //SPGetBookingCounts
        }
        public DataTable stuffingcount(string trantype, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
               
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                new SqlParameter("@bid", SqlDbType.TinyInt, 4),
                new SqlParameter("@cid", SqlDbType.TinyInt, 4),
               
            };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = cid;

            return ExecuteTable("sp_bookingstuffcount", objp);
        }
        //muthu
        public DataTable pendingcountOICS(string trantype, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
               
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                new SqlParameter("@bid", SqlDbType.TinyInt, 4),
                new SqlParameter("@cid", SqlDbType.TinyInt, 4),
               
            };
            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = cid;

            return ExecuteTable("SPGetFIPenEventOICS", objp);
        }

        //MUTHU


        public DataTable get_buyingreport(int rateid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@rateid", SqlDbType.Int),

            };
            objp[0].Value = rateid;

            return ExecuteTable("sp_buyingreport", objp);
        }
      
        // SPselBuyingDetailsall
        public DataTable Sellbuyingdeatils(int intRateid, int Quotid, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                     new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = intRateid;
            objp[1].Value = Quotid;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPselBuyingDetailsall", objp);
        }

        public DataTable SelBuyingDetailsnew(int intRateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = intRateid;
            return ExecuteTable("SPselBuyingDetailsnew", objp);
        }
        public void InsBuyingHeadversion(int intLiner, int intCargo, int intPOL, int intPOD, char freight, DateTime validtill, char shipment, char dgcargo, char bulkvolume, double brokerage, int intObtainby, int intPrepareby, string remarks, int intPor, int intFD, int rate, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@liner", SqlDbType.Int, 4),
                                                       new SqlParameter("@cargo", SqlDbType.Int),
                                                       new SqlParameter("@pol", SqlDbType.Int, 4),
                                                       new SqlParameter("@pod", SqlDbType.Int, 4),
                                                       new SqlParameter("@freight", SqlDbType.Char, 1),
                                                       new SqlParameter("@validity", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@shipment", SqlDbType.Char, 1),
                                                       new SqlParameter("@dgcargo", SqlDbType.Char, 1),
                                                       new SqlParameter("@bulkvolume", SqlDbType.Char, 1),
                                                       new SqlParameter("@brokerage", SqlDbType.Real, 4),
                                                       new SqlParameter("@obtainedby", SqlDbType.Int, 4),
                                                       new SqlParameter("@preparedby", SqlDbType.Int, 4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@por",SqlDbType.Int,4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4),
                                                       new SqlParameter("@rateid",SqlDbType.Int,4),
            new SqlParameter("@version",SqlDbType.Int,4)};
            objp[0].Value = intLiner;
            objp[1].Value = intCargo;
            objp[2].Value = intPOL;
            objp[3].Value = intPOD;
            objp[4].Value = freight;
            objp[5].Value = validtill;
            objp[6].Value = shipment;
            objp[7].Value = dgcargo;
            objp[8].Value = bulkvolume;
            objp[9].Value = brokerage;
            objp[10].Value = intObtainby;
            objp[11].Value = intPrepareby;
            objp[12].Value = remarks;
            objp[13].Value = intPor;
            objp[14].Value = intFD;
            objp[15].Value = rate;
            objp[16].Value = version;
            ExecuteQuery("SPInsBuyingHeadversion", objp);
        }
        public void InsBuyingDetailsversion(int intRateid, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                         new SqlParameter("@version",SqlDbType.Int,4)};
            objp[0].Value = intRateid;
            objp[1].Value = version;
            ExecuteQuery("SPInsBuyingDetailsversion", objp);
        }
        public DataTable Sellbuyingdeatilsversion(int intRateid, int Quotid, int intBranchID, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                     new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1), new SqlParameter("@version",SqlDbType.Int)};
            objp[0].Value = intRateid;
            objp[1].Value = Quotid;
            objp[2].Value = intBranchID;
            objp[2].Value = version;
            return ExecuteTable("SPselBuyingDetailsallversion", objp);
        }
        public DataTable GetEmpolyeeDetails4card(int empid, int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@EmployeeId",SqlDbType.Int, 4),
                                        new SqlParameter("@bid",SqlDbType.Int, 4),
                                        new SqlParameter("@trantype",SqlDbType.VarChar, 10)

                                        };
            objp[0].Value = empid;
            objp[1].Value = bid;
            objp[2].Value = trantype;

            return ExecuteTable("SP_GetEmpolyeeDetails4cardproduct", objp);
        }
        public DataTable selpendingBookcutomerwisecountforjob(int bid, string trantype, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                 new SqlParameter("@empid", SqlDbType.Int, 4),
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = empid;
            return ExecuteTable("Sp_GetpendingBookcutomerwisecountforjob", objp);
        }
        public DataTable selpendingBookcustomeridwiseForJob(int bid, string trantype, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                 new SqlParameter("@customerid", SqlDbType.Int, 4),
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = custid;
            return ExecuteTable("Sp_GetpendingBookcustomeridwiseforjobTask", objp);
        }
        //inquiry

        public void InsertBuyingNo(int inquiryid, int rateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inquiryid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rateid", SqlDbType.Int) };

            objp[0].Value = inquiryid;
            objp[1].Value = rateid;
            ExecuteQuery("SpInsertBuyingNo", objp);
        }

        public DataTable GetBaseValue(int inquiryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inquiryid", SqlDbType.Int, 4) };
            objp[0].Value = inquiryid;
            return ExecuteTable("SPGetBaseValue", objp);
        }


        public DataTable SelInquirybuyingdetails(int intRateid, int Inquiryid, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                     new SqlParameter("@inquiryid",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = intRateid;
            objp[1].Value = Inquiryid;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPselInquiryBuyingDetailsall", objp);
        }


        public DataTable GetSelPercent(int rateid, string product)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                        new SqlParameter("@product",SqlDbType.VarChar,4)};
            objp[0].Value = rateid;
            objp[1].Value = product;
            return ExecuteTable("SPGetPercent", objp);

        }

        public DataTable GetSelProduct(int buyingno)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@buyingno", SqlDbType.Int, 4) };
            objp[0].Value = buyingno;
            return ExecuteTable("SPGetTrantype", objp);

        }
        public DataTable GetSelProductForRateId(int buyingno)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@buyingno", SqlDbType.Int, 4) };
            objp[0].Value = buyingno;
            return ExecuteTable("SPGetTrantypeForRateId", objp);

        }

        public DataTable SelRateIdTable(int intRateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = intRateid;
            return ExecuteTable("SPSelRateIdTable", objp);
        }
        public DataTable selpendingBookcutomerwisecount_Chartempwise(int bid, string trantype,int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                new SqlParameter("@empid", SqlDbType.Int, 4)
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = empid;
            return ExecuteTable("SPGetBookingCountsloginempwise", objp);  //SPGetBookingCounts
        }
        public DataTable Card4TaskDetailDash(string customerid, int salesperson)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {new SqlParameter("@customerid",SqlDbType.VarChar, 500),
                                 new SqlParameter("@salesperson",SqlDbType.Int, 4),


                                        };
            objp[0].Value = customerid;
            objp[1].Value = salesperson;


            return ExecuteTable("Sp_Card4TaskDetailDash", objp);
        }

        public DataTable Card4TaskDetailDashsbid(string bid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                 new SqlParameter("@bid",SqlDbType.VarChar, 500),


                                        };
            objp[0].Value = bid;



            return ExecuteTable("Sp_Card4TaskDetailDashbranchid", objp);
        }


        public DataTable Card4TaskDetailDashsvoutype(int bid, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                 new SqlParameter("@bid",SqlDbType.Int, 4),
                                  new SqlParameter("@voutype",SqlDbType.VarChar, 50),


                                        };
            objp[0].Value = bid;
            objp[1].Value = voutype;



            return ExecuteTable("SP_GetCardDetail4TaskDashBordvoutype", objp);
        }


        public DataTable Card4TaskDetailDashsall(string bid, string voutype, int customerid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                 new SqlParameter("@bid",SqlDbType.VarChar, 500),
                                  new SqlParameter("@voutype",SqlDbType.VarChar, 500),
                                    new SqlParameter("@customerid",SqlDbType.Int, 4),
                                      new SqlParameter("@salesperson",SqlDbType.Int, 4),


                                        };
            objp[0].Value = bid;
            objp[1].Value = voutype;
            objp[2].Value = customerid;
            objp[3].Value = empid;



            return ExecuteTable("SP_GetCardDetail4TaskDashBorForall", objp);
        }
        public DataTable GetBranch4TaskDashbord()
        {




            return ExecuteTable("SP_GetBranch4TaskDashbord");
        }
        public DataTable Getvou4TaskDashbord()
        {




            return ExecuteTable("SP_GetVoutype4TaskDashBord");
        }

        public DataTable Card4TaskDetailDashsvou(string vou)
        {
            SqlParameter[] objp = new SqlParameter[]
                                        {
                                 new SqlParameter("@vouchar",SqlDbType.VarChar, 500),


                                        };
            objp[0].Value = vou;



            return ExecuteTable("Sp_Card4TaskDetailDashVouchertype", objp);
        }

    }
}

