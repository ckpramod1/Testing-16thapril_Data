using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Marketing
{
    public class Booking : DBObject
    {
        DataAccess.Masters.MasterCharges ChargeObj = new DataAccess.Masters.MasterCharges();
        DataAccess.LogDetails logobj = new DataAccess.LogDetails();

        //public int GetShipRefno(int intBranchID)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt,1)};
        //    objp[0].Value = intBranchID;
        //    return int.Parse(ExecuteReader("SPUpdMCShipRef",objp));
        //}
        //Methods.
        //Insert Booking Details.   

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Booking()
        {
            Conn = new SqlConnection(DBCS);
        }
        public string InsertBookingDetails(int quotno, double volume, DateTime bookingdate, string trantype, string division, string branch, int branchid, int PreparedBy, int incoid, int intDivID)
        {
            string shiprefno = null;
            string monthyear = "";
            string m, y;
            m = logobj.GetDate().Month.ToString();
            //m = DateTime.Today.Month.ToString();
            if (m.Length < 2)
                m = "0" + m;
            y = DateTime.Today.Year.ToString();
            y = y.Substring(2, 2);
            monthyear = m + y;

            shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString();
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@quotno", SqlDbType.Int,4),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@bookingdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@srefno",SqlDbType.VarChar,30),                        
                                                    new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = quotno;
            objp[1].Value = volume;
            objp[2].Value = bookingdate;
            objp[3].Value = trantype;
            objp[4].Value = shiprefno;
            objp[5].Value = branchid;
            objp[6].Direction = ParameterDirection.Output;
            objp[7].Value = PreparedBy;
            objp[8].Value = incoid;
            objp[9].Value = intDivID;
            return ExecuteQuery("SPInsBooking", "@srefno", objp).ToString();
        }
        public string GetBookingCharges(string bookno, string charge, string strbase, int intBranchID)
        {
            int chargeid = ChargeObj.GetChargeid(charge);
            string prc = "";
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                      new SqlParameter("@base",SqlDbType.VarChar,45),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookno;
            objp[1].Value = chargeid;
            objp[2].Value = strbase;
            objp[3].Value = intBranchID;
            Dt = ExecuteTable("SPSelBookingCharges", objp);
            if (Dt.Rows.Count > 0)
            {
                prc = Dt.Rows[0].ItemArray[0].ToString();
            }
            return prc;
        }

        public string GetBookingBuyingCharges(string bookno, string charge, string strbase, int intBranchID)
        {
            int chargeid = ChargeObj.GetChargeid(charge);
            string prc = "";
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                      new SqlParameter("@base",SqlDbType.VarChar,45),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookno;
            objp[1].Value = chargeid;
            objp[2].Value = strbase;
            objp[3].Value = intBranchID;
            Dt = ExecuteTable("SPSelBookingBuyingCharges", objp);
            if (Dt.Rows.Count > 0)
            {
                prc = Dt.Rows[0].ItemArray[0].ToString();
            }
            return prc;
        }
        public void InsertChargeDetails(int quotationid, string chargename, string curr, double rate, string Base, string bookingno, string prc, int intBranchID, int intDivID)
        {
            int chargeid = ChargeObj.GetChargeid(chargename);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                         new SqlParameter("@chargeid",SqlDbType.Int),
                                                         new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                         new SqlParameter("@rate",SqlDbType.Money,4),
                                                         new SqlParameter("@base",SqlDbType.VarChar,45),
                                                         new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@prc",SqlDbType.VarChar,1),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = quotationid;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = Base;
            objp[5].Value = bookingno;
            objp[6].Value = prc;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivID;
            ExecuteQuery("SPInsBookingDetails", objp);
        }
        public void InsertbuyingChargeDetails(int buyingno, string chargename, string curr, double rate, string Base, string bookingno, string prc, int intBranchID, int intDivID)
        {
            int chargeid = ChargeObj.GetChargeid(chargename);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                         new SqlParameter("@chargeid",SqlDbType.Int),
                                                         new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                         new SqlParameter("@rate",SqlDbType.Money,4),
                                                         new SqlParameter("@base",SqlDbType.VarChar,45),
                                                         new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@prc",SqlDbType.VarChar,1),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = buyingno;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = Base;
            objp[5].Value = bookingno;
            objp[6].Value = prc;
            objp[7].Value = intBranchID;
            objp[8].Value = intDivID;
            ExecuteQuery("SPInsBuyingBookingDetails", objp);
        }

        //Get Customerid Based on Customername.  
        public int Getinconame(string incocode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inco", SqlDbType.VarChar, 100) };
            objp[0].Value = incocode;
            return int.Parse(ExecuteReader("SPInconame", objp));

        }

        public void InsertBuyingNo(string shiprefno, int buyingno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = shiprefno;
            objp[1].Value = buyingno;
            objp[2].Value = intBranchID;
            ExecuteQuery("SPInsBuyingnoToBooking", objp);
        }

        //Update Booking Details.  int,
        public void UpdateBookingDetails(double volume, string bookingno, int branchid, int incoid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@volume", SqlDbType.Real,4), 
                                                        new SqlParameter("@bookingno", SqlDbType.VarChar,30), 
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@inco",SqlDbType.TinyInt,1)};
            objp[0].Value = volume;
            objp[1].Value = bookingno;
            objp[2].Value = branchid;
            objp[3].Value = incoid;
            ExecuteQuery("SPUpdBooking", objp);
        }

        public void DelBookingCharges(string bookingno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@bookingno", SqlDbType.VarChar,30), 
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = intBranchID;
            ExecuteQuery("SPDelBookingDetails", objp);
        }
        public void DelBookingBuyingCharges(string bookingno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@bookingno", SqlDbType.VarChar,30), 
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = intBranchID;
            ExecuteQuery("SPDelBookingBuyingDetails", objp);
        }
        //Get Booking Details.
        public DataTable GetBookingDetails(string Bookingno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Bookingno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelBookingdtls", objp);
        }

        public DataTable GetBookingDetailsFromShiprefNo(string shiprefno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = shiprefno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPGetBookingDetailsFromShiprefNo", objp);
        }


        public int GetBookingNo(string blno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30),                                                       
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            return int.Parse(ExecuteReader("SPSelBookingNo", objp));
        }

        //Get Booking Pending.
        public DataTable GetBookingPending(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelBookingPending", objp);
        }
        public DataTable GetBookingPending4Cancel(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelBookingPending4Cancel", objp);
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

        //Booking Calcel.  
        public void Bookingcancel(string Bookingno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Bookingno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            ExecuteQuery("SPUpdBookingCancel", objp);
        }

        //*********Quotation Grid *******
        //public DataTable QuotGrdDetails(string trantype, int intBranchID)
        // {
        //     SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
        //                                                new SqlParameter("@bid",SqlDbType.TinyInt,1)};
        //     objp[0].Value = trantype;
        //     objp[1].Value = intBranchID;
        //     return ExecuteTable("SPSelQuotApproved", objp);            
        // }


        public DataTable QuotGrdDetails(string trantype, int intBranchID, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@empid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = empid;
            //return ExecuteTable("SPSelQuotApproved", objp);

            return ExecuteTable("SPSelQuotApprovednew", objp);
        }

        public DataTable BuyingGrdDetails(string shipment, int pol, int pod, int por, int fd)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@shipment",SqlDbType.VarChar,1),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int)};
            objp[0].Value = shipment;
            objp[1].Value = pol;
            objp[2].Value = pod;
            objp[3].Value = por;
            objp[4].Value = fd;
            return ExecuteTable("SPSelBuyingGrd", objp);

        }
        public int Customerid(string blno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return int.Parse(ExecuteReader("SPGetCustidBookingno", objp));
        }
        public DataTable GetLikeBooking(string trantype, string bookingno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = bookingno;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPLikeBookingNo", objp);
        }
        //Shipment Status
        public DataTable GetBookingPending4Shipstatus(string trantype, int jobno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@jobno",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = jobno;
            return ExecuteTable("SPSelBookingPending4shipstatus", objp);
        }
        //inco
        public DataTable GetLikeIncocode(string inccode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inco", SqlDbType.VarChar, 5)
                                                        };
            objp[0].Value = inccode;
            return ExecuteTable("SPIncoLike", objp);
        }
        public DataTable SelMasterInco(int incoid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@incoid", SqlDbType.TinyInt,1)
                                                        };
            objp[0].Value = incoid;
            return ExecuteTable("SPselMasterInco", objp);
        }
        public void InsBookingBack(string bookingno, DateTime BookingDate, double tues, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@bookingdate",SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@tues",SqlDbType.Real,4),
                                                      new SqlParameter("@bid",SqlDbType.Int,4),
                                                      new SqlParameter("@cid",SqlDbType.Int,4)
                                                      };
            objp[0].Value = bookingno;
            objp[1].Value = BookingDate;
            objp[2].Value = tues;
            objp[3].Value = bid;
            objp[4].Value = cid;
            ExecuteQuery("SPBookingBackEnd", objp);
        }
        public void UPDBookingBack(string bookingno, DateTime BookingDate, double tues, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@bookingdate",SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@tues",SqlDbType.Real,4),
                                                      new SqlParameter("@bid",SqlDbType.Int,4),
                                                      new SqlParameter("@cid",SqlDbType.Int,4)
                                                      };
            objp[0].Value = bookingno;
            objp[1].Value = BookingDate;
            objp[2].Value = tues;
            objp[3].Value = bid;
            objp[4].Value = cid;
            ExecuteQuery("SPUPDBookingBackEnd", objp);
        }
        //booking reg

        public DataTable seldetails(int bid, string strtrantype, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       
                                                       new SqlParameter("@bid", SqlDbType.Int ,4),
                                                         new SqlParameter("@strtrantype", SqlDbType.VarChar ,3),
                                                          new SqlParameter("@fromdate", SqlDbType.DateTime ,10),
                                                      new SqlParameter("@todate", SqlDbType.DateTime ,10)



                                                       
                                                       };

            objp[0].Value = bid;
            objp[1].Value = strtrantype;
            objp[2].Value = fromdate;
            objp[3].Value = todate;


            return ExecuteTable("SPSalesPerson", objp);
        }
        //Raj
        public DataTable seldetails(int bid, string strtrantype, DateTime fromdate, DateTime todate, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       
                                                       new SqlParameter("@bid", SqlDbType.Int ,4),
                                                         new SqlParameter("@strtrantype", SqlDbType.VarChar ,3),
                                                          new SqlParameter("@fromdate", SqlDbType.DateTime ,10),
                                                      new SqlParameter("@todate", SqlDbType.DateTime ,10),
                 new SqlParameter("@type", SqlDbType.VarChar ),



                                                       
                                                       };

            objp[0].Value = bid;
            objp[1].Value = strtrantype;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = type;


            return ExecuteTable("SPSalesPerson", objp);
        }
        //salquery
        public DataTable GetLikeSalesBooking(string bookingno, int intBranchID, int marketedby)
        {

            SqlParameter[] objp = new SqlParameter[] 
       { 
                                                      new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter ("@marketedby",SqlDbType.Int ,4) 
                                                     
       };

            objp[0].Value = bookingno;
            objp[1].Value = intBranchID;
            objp[2].Value = marketedby;
            return ExecuteTable("SPLikeSalesBookingNo", objp);

        }
        //getbusiness

        public DataTable SPGETCustid4factory(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@customerid",SqlDbType.Int,4)
                                                       //new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       };
            objp[0].Value = customerid;
            //  objp[1].Value = bid;
            return ExecuteTable("SPGETCustid4factory", objp);
        }


        public DataTable Getbusinessfromquot(int Quotationno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int,2), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("spgetbusinessfromquot", objp);
        }

        public DataTable GetbusinessfromBooking(string shiprefno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shiprefno",SqlDbType.VarChar,30), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = shiprefno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("spgetbusinessfrombook", objp);
        }

        //Get our booking or agnet booking

        public DataTable GETBusiness4Booking(int bookingno, int Bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1)
 };
            objp[0].Value = bookingno;
            objp[1].Value = Bid;
            return ExecuteTable("SPGetBusinessfrombooking", objp);
        }
        public void UPDBusinessinbooking(int Quotationno, string trantype, int intBranchID, string shiprefno, string bus)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@quotationno",SqlDbType.Int,2), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bus",SqlDbType.VarChar,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = shiprefno;
            objp[4].Value = bus;
            ExecuteQuery("SPUPDBusinessinbooking", objp);
        }
        public DataTable selSalesdetails(int bid, string strtrantype, DateTime fromdate, DateTime todate, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       
                                                       new SqlParameter("@bid", SqlDbType.Int ,4),
                                                         new SqlParameter("@strtrantype", SqlDbType.VarChar ,3),
                                                          new SqlParameter("@fromdate", SqlDbType.DateTime ,10),
                                                      new SqlParameter("@todate", SqlDbType.DateTime ,10),
               new SqlParameter("@salesid",SqlDbType.Int,4)



                                                       
                                                       };

            objp[0].Value = bid;
            objp[1].Value = strtrantype;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = salesid;
            return ExecuteTable("SPSalesPersonDetails", objp);
        }
        public int GetCustID4mBookingno(string shiprefno, string trantype, int intBranchID, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = shiprefno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = cid;
            return int.Parse(ExecuteReader("SPGetCustID4mBooking", objp));
        }





        //Booking New 
        public string InsertBookingDetailsNew(int quotno, double volume, DateTime bookingdate, string trantype, string division, string branch, int branchid, int PreparedBy, int incoid, int intDivID, int shipid, int congid, string remarks)
        {
            string shiprefno = null;
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

            shiprefno = branch + monthyear.ToString();
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@quotno", SqlDbType.Int,4),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@bookingdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@srefno",SqlDbType.VarChar,30),                        
                                                    new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
               new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000)
           };
            objp[0].Value = quotno;
            objp[1].Value = volume;
            objp[2].Value = bookingdate;
            objp[3].Value = trantype;
            objp[4].Value = shiprefno;
            objp[5].Value = branchid;
            objp[6].Direction = ParameterDirection.Output;
            objp[7].Value = PreparedBy;
            objp[8].Value = incoid;
            objp[9].Value = intDivID;
            objp[10].Value = shipid;
            objp[11].Value = congid;
            objp[12].Value = remarks;
            return ExecuteQuery("SPInsBookingNew", "@srefno", objp).ToString();
        }



        //Booking New 
        public string InsertBookingDetailsNewebooking(int quotno, double volume, DateTime bookingdate, string trantype, string division, string branch, int branchid, int PreparedBy, int incoid, int intDivID, int shipid, int congid, string remarks, string shiprefno, int bookno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@quotno", SqlDbType.Int,4),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@bookingdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@srefno",SqlDbType.VarChar,30),                        
                                                    new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
               new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000),
                new SqlParameter("@bookno", SqlDbType.Int,4)
           };
            objp[0].Value = quotno;
            objp[1].Value = volume;
            objp[2].Value = bookingdate;
            objp[3].Value = trantype;
            objp[4].Value = shiprefno;
            objp[5].Value = branchid;
            objp[6].Direction = ParameterDirection.Output;
            objp[7].Value = PreparedBy;
            objp[8].Value = incoid;
            objp[9].Value = intDivID;
            objp[10].Value = shipid;
            objp[11].Value = congid;
            objp[12].Value = remarks;
            objp[13].Value = bookno;
            return ExecuteQuery("SPInsBookingNewebooking", "@srefno", objp).ToString();
        }





        public void UpdateBookingDetailsNew(double volume, string bookingno, int branchid, int incoid, int shipid, int congid, string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@volume", SqlDbType.Real,4), 
                                                        new SqlParameter("@bookingno", SqlDbType.VarChar,30), 
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@inco",SqlDbType.TinyInt,1),
            new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000)
            };
            objp[0].Value = volume;
            objp[1].Value = bookingno;
            objp[2].Value = branchid;
            objp[3].Value = incoid;
            objp[4].Value = shipid;
            objp[5].Value = congid;
            objp[6].Value = remarks;
            ExecuteQuery("SPUpdBookingNew", objp);
        }


        public void InsBookingMailID(string bookingno, string mailid, string type, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@mailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@type",SqlDbType.VarChar,1),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      
                                                      };
            objp[0].Value = bookingno;
            objp[1].Value = mailid;
            objp[2].Value = type;
            objp[3].Value = bid;

            ExecuteQuery("SPInsCOMBookingMailid", objp);
        }

        public void DelBookingMailID(string bookingno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      
                                                      };
            objp[0].Value = bookingno;
            objp[1].Value = bid;

            ExecuteQuery("SPDelBookingMailIDs", objp);
        }


        public DataTable SelCOMBookingMailid(string bookingno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bookno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.Int ,4),
                                                        
                                                                     
                                                       };
            objp[0].Value = bookingno;
            objp[1].Value = bid;


            return ExecuteTable("SPSelCOMBookingMailid", objp);
        }
        public DataTable GetBookingdtlsNew(string Bookingno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Bookingno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelBookingdtlsNew", objp);
        }

        public string InsertFIBookingDetailsNewBook(int quotno, double volume, DateTime bookingdate, string trantype, string division, string branch, int branchid, int PreparedBy, int incoid, int intDivID, int shipid, int congid, string remarks, int agentid, int factory)
        {
            string shiprefno = null;
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
            shiprefno = branch + monthyear.ToString();
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@quotno", SqlDbType.Int,4),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@bookingdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@srefno",SqlDbType.VarChar,30),                        
                                                    new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
               new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000),
               new SqlParameter("@agentid", SqlDbType.Int,4),
               new SqlParameter("@factory", SqlDbType.Int,4),
           };
            objp[0].Value = quotno;
            objp[1].Value = volume;
            objp[2].Value = bookingdate;
            objp[3].Value = trantype;
            objp[4].Value = shiprefno;
            objp[5].Value = branchid;
            objp[6].Direction = ParameterDirection.Output;
            objp[7].Value = PreparedBy;
            objp[8].Value = incoid;
            objp[9].Value = intDivID;
            objp[10].Value = shipid;
            objp[11].Value = congid;
            objp[12].Value = remarks;
            objp[13].Value = agentid;
            objp[14].Value = factory;
            return ExecuteQuery("SPInsFIBookingNew", "@srefno", objp).ToString();
        }


        public string InsertFIBookingDetailsNewBookebbookingno(int quotno, double volume, DateTime bookingdate, string trantype, string division, string branch, int branchid, int PreparedBy, int incoid, int intDivID, int shipid, int congid, string remarks, int agentid, int factory, string shiprefno, int bookno)
        {
            //string shiprefno = null;
            //string monthyear = "";
            //string m, y;
            //m = logobj.GetDate().Month.ToString();
            ////m = DateTime.Today.Month.ToString();
            //if (m.Length < 2)
            //    m = "0" + m;
            //y = DateTime.Today.Year.ToString();
            //y = y.Substring(2, 2);
            ////monthyear = m + y;

            //monthyear = y;

            ////shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString();
            //shiprefno = branch + monthyear.ToString();
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@quotno", SqlDbType.Int,4),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@bookingdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@srefno",SqlDbType.VarChar,30),                        
                                                    new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
               new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000),
               new SqlParameter("@agentid", SqlDbType.Int,4),
               new SqlParameter("@factory", SqlDbType.Int,4),
                 new SqlParameter("@bookno", SqlDbType.Int,4)
           };
            objp[0].Value = quotno;
            objp[1].Value = volume;
            objp[2].Value = bookingdate;
            objp[3].Value = trantype;
            objp[4].Value = shiprefno;
            objp[5].Value = branchid;
            objp[6].Direction = ParameterDirection.Output;
            objp[7].Value = PreparedBy;
            objp[8].Value = incoid;
            objp[9].Value = intDivID;
            objp[10].Value = shipid;
            objp[11].Value = congid;
            objp[12].Value = remarks;
            objp[13].Value = agentid;
            objp[14].Value = factory;
            objp[15].Value = bookno;
            return ExecuteQuery("SPInsFIBookingNewebooking", "@srefno", objp).ToString();
        }


        //FIBOOKINGAGENTINCLUDED
        public string InsertFIBookingDetailsNew(int quotno, double volume, DateTime bookingdate, string trantype, string division, string branch, int branchid, int PreparedBy, int incoid, int intDivID, int shipid, int congid, string remarks, int agentid)
        {
            string shiprefno = null;
            string monthyear = "";
            string m, y;
            m = logobj.GetDate().Month.ToString();
            //m = DateTime.Today.Month.ToString();
            if (m.Length < 2)
                m = "0" + m;
            y = DateTime.Today.Year.ToString();
            y = y.Substring(2, 2);
            monthyear = m + y;

            shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString();
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@quotno", SqlDbType.Int,4),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@bookingdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@srefno",SqlDbType.VarChar,30),                        
                                                    new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
               new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000),
               new SqlParameter("@agentid", SqlDbType.Int,4)
           };
            objp[0].Value = quotno;
            objp[1].Value = volume;
            objp[2].Value = bookingdate;
            objp[3].Value = trantype;
            objp[4].Value = shiprefno;
            objp[5].Value = branchid;
            objp[6].Direction = ParameterDirection.Output;
            objp[7].Value = PreparedBy;
            objp[8].Value = incoid;
            objp[9].Value = intDivID;
            objp[10].Value = shipid;
            objp[11].Value = congid;
            objp[12].Value = remarks;
            objp[13].Value = agentid;
            return ExecuteQuery("SPInsFIBookingNew", "@srefno", objp).ToString();
        }

        public void UpdateFIBookingDetailsNewBook(double volume, string bookingno, int branchid, int incoid, int shipid, int congid, string remarks, int agentid, int factory)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@volume", SqlDbType.Real,4), 
                                                        new SqlParameter("@bookingno", SqlDbType.VarChar,30), 
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@inco",SqlDbType.TinyInt,1),
            new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000),
                  new SqlParameter("@agentid", SqlDbType.Int),
               new SqlParameter("@factory", SqlDbType.Int,4),
            };
            objp[0].Value = volume;
            objp[1].Value = bookingno;
            objp[2].Value = branchid;
            objp[3].Value = incoid;
            objp[4].Value = shipid;
            objp[5].Value = congid;
            objp[6].Value = remarks;
            objp[7].Value = agentid;
            objp[8].Value = factory;
            ExecuteQuery("SPUpdFIBookingNew", objp);
        }
        public void UpdateFIBookingDetailsNew(double volume, string bookingno, int branchid, int incoid, int shipid, int congid, string remarks, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@volume", SqlDbType.Real,4), 
                                                        new SqlParameter("@bookingno", SqlDbType.VarChar,30), 
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@inco",SqlDbType.TinyInt,1),
            new SqlParameter("@shipid", SqlDbType.Int,4),
               new SqlParameter("@congid", SqlDbType.Int,4),
               new SqlParameter("@remarks", SqlDbType.VarChar,4000),
                  new SqlParameter("@agentid", SqlDbType.Int)
            };
            objp[0].Value = volume;
            objp[1].Value = bookingno;
            objp[2].Value = branchid;
            objp[3].Value = incoid;
            objp[4].Value = shipid;
            objp[5].Value = congid;
            objp[6].Value = remarks;
            objp[7].Value = agentid;
            ExecuteQuery("SPUpdFIBookingNew", objp);
        }
        //Booking-Quotation grid

        public DataTable QuotGrdDetails4booking(string trantype, int intBranchID, string bookno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
           new SqlParameter("@bookno",SqlDbType.VarChar)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = bookno;
            return ExecuteTable("SPSelQuotApp4booking", objp);
        }

        public DataTable GetBookingPending(string trantype, int intBranchID, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
            new SqlParameter("@bookingno",SqlDbType.VarChar)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = bookingno;
            return ExecuteTable("SPSelBookPend4typad", objp);
        }


        public DataTable GetBookingPendingnew(string trantype, int intBranchID, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
            new SqlParameter("@bookingno",SqlDbType.VarChar)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = bookingno;
            return ExecuteTable("SPSelBookPend4typadsalesperson", objp);
        }
        //buying grid for booking
        public DataTable BuyingGrdDetails(string shipment, int pol, int pod, int por, int fd, int quotno)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@shipment",SqlDbType.VarChar,1),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
           new SqlParameter("@quotno",SqlDbType.Int)};
            objp[0].Value = shipment;
            objp[1].Value = pol;
            objp[2].Value = pod;
            objp[3].Value = por;
            objp[4].Value = fd;
            objp[5].Value = quotno;

            return ExecuteTable("SPSelBuyingGrd4book", objp);

        }
        public DataTable QuotGrdDetailsCust(string trantype, int intBranchID, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@custid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = customerid;
            return ExecuteTable("SPSelQuotApprovedCust", objp);
        }
        public DataTable GetEvenDTLS(int bid, string shiprefno)
        {
            SqlParameter[] objp = new SqlParameter[] {                                                      
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@shiprefno",SqlDbType.VarChar,50)
           };
            objp[0].Value = bid;
            objp[1].Value = shiprefno;
            return ExecuteTable("SPSelctFEEvet", objp);
        }


        public DataTable UpdcargoRailDtls(int bid, string shiprefno, DateTime fdate, string ftype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
                                                     new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,50),
                                                     };
            objp[0].Value = bid;
            objp[1].Value = shiprefno;
            objp[2].Value = fdate;
            objp[3].Value = ftype;
            return ExecuteTable("SPUPDBookingCargoRailDtls", objp);

        }

        //public DataTable UpdDateDtlsDtls(int bid, string shiprefno, DateTime cargoon, DateTime railoutdate, DateTime inspect, DateTime received, DateTime custom)
        //{
        //    SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
        //                                              new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
        //                                              new SqlParameter("@cargorecvon",SqlDbType.DateTime),
        //             new SqlParameter("@railoutdate",SqlDbType.DateTime),
        //             new SqlParameter("@inspect",SqlDbType.DateTime),
        //             new SqlParameter("@received",SqlDbType.DateTime),
        //             new SqlParameter("@custom",SqlDbType.DateTime)
        //                                              };
        //    objp[0].Value = bid;
        //    objp[1].Value = shiprefno;
        //    objp[2].Value = cargoon;
        //    objp[3].Value = railoutdate;
        //    objp[4].Value = inspect;
        //    objp[5].Value = received;
        //    objp[6].Value = custom;

        //    return ExecuteTable("SPUPDBookingDateDtls", objp);

        //}

        public DataTable UpdDateDtlsDtls(int bid, string shiprefno, DateTime cargoon, DateTime railoutdate, DateTime inspect, DateTime received, DateTime custom, DateTime cargoreadyon)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
                                                     new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@cargorecvon",SqlDbType.DateTime),
                    new SqlParameter("@railoutdate",SqlDbType.DateTime),
                    new SqlParameter("@inspect",SqlDbType.DateTime),
                    new SqlParameter("@received",SqlDbType.DateTime),
                    new SqlParameter("@custom",SqlDbType.DateTime),
               new SqlParameter("@cargoreadyon",SqlDbType.DateTime)
                                                     };
            objp[0].Value = bid;
            objp[1].Value = shiprefno;
            objp[2].Value = cargoon;
            objp[3].Value = railoutdate;
            objp[4].Value = inspect;
            objp[5].Value = received;
            objp[6].Value = custom;
            objp[7].Value = cargoreadyon;

            return ExecuteTable("SPUPDBookingDateDtls", objp);

        }

        public DataTable GETMAilis4BookigCRM(int cusid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = cusid;

            return ExecuteTable("SPGetMailids4Booking", objp);
        }
        public DataTable QuotGrdDetailsCust4CRM(string trantype, int intBranchID, int customerid, string stype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@custid",SqlDbType.Int,4),
                                                         new SqlParameter("@stype",SqlDbType.VarChar,5)
           };
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = customerid;
            objp[3].Value = stype;
            return ExecuteTable("SPSelQuotApprovedCust4CRM", objp);
        }
        public DataTable QuotGrdDetails4crm(string trantype, int intBranchID, string stype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@stype",SqlDbType.VarChar,5)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = stype;
            return ExecuteTable("SPSelQuotApproved4CRM", objp);
        }




        //guru
        //public DataTable GETBookingNoJobInfo(int intBranchID, string trantype)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { 
        //                                                new SqlParameter("@bid",SqlDbType.TinyInt,1),
        //                                                new SqlParameter("@trantype",SqlDbType.VarChar,3)
        //                                               //  new SqlParameter("@stype",SqlDbType.VarChar,5)
        //    };
        //    objp[0].Value = intBranchID;
        //    objp[1].Value = trantype;

        //    return ExecuteTable("SPGETBookingNoJobInfo", objp);
        //}

        public DataTable GETBookingNoJobInfo(int intBranchID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,3)
                                                      //  new SqlParameter("@stype",SqlDbType.VarChar,5)
           };
            objp[0].Value = intBranchID;
            objp[1].Value = trantype;
            return ExecuteTable("SPSelShiprefnoForJobnewadd", objp);
            // return ExecuteTable("SPSelShiprefnoForJob", objp);
            //return ExecuteTable("SPGETBookingNoJobInfo", objp);
        }
        //raj
        public void Insbookvessel(int book, string vessel, string voyage, string pol, string pod, DateTime etd, DateTime eta)
        {
            //int pkgid = 0;
            //pkgid = PkgObj.GetNPackageid(pkgs);
            SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                          new SqlParameter("@book",SqlDbType.Int,4),
                                                          new SqlParameter("@vessel",SqlDbType.VarChar,50),        
                                                          new SqlParameter("@voyage",SqlDbType.VarChar,50), 
                                                          new SqlParameter("@pol",SqlDbType.VarChar,50),
                                                          new SqlParameter("@pod",SqlDbType.VarChar,500),
                                                          new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@eta",SqlDbType.SmallDateTime,4)
                                                     };
            objp[0].Value = book;
            objp[1].Value = vessel;
            objp[2].Value = voyage;
            objp[3].Value = pol;
            objp[4].Value = pod;
            objp[5].Value = etd;
            objp[6].Value = eta;

            ExecuteQuery("SPInsbookvsl", objp);
        }
        public void Updbookvsl(int book, string vessel, string voyage, string pol, string pod, DateTime etd, DateTime eta)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                          new SqlParameter("@book",SqlDbType.Int,4),
                                                          new SqlParameter("@vessel",SqlDbType.VarChar,50),        
                                                          new SqlParameter("@voyage",SqlDbType.VarChar,50), 
                                                          new SqlParameter("@pol",SqlDbType.VarChar,50),
                                                          new SqlParameter("@pod",SqlDbType.VarChar,50),
                                                          new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@eta",SqlDbType.SmallDateTime,4)
                                                     };
            objp[0].Value = book;
            objp[1].Value = vessel;
            objp[2].Value = voyage;
            objp[3].Value = pol;
            objp[4].Value = pod;
            objp[5].Value = etd;
            objp[6].Value = eta;
            ExecuteQuery("SPUpdbookvsl", objp);
        }
        public DataTable SelectBookvsl(int book)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     {new SqlParameter("@book",SqlDbType.Int,4)
                                                     };
            objp[0].Value = book;
            return ExecuteTable("SPSelectBookvsl", objp);

        }
        public void DeleteBookvessel(int vesselid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     {new SqlParameter("@vessel",SqlDbType.Int,4)
                                                     };
            objp[0].Value = vesselid;
            ExecuteQuery("SPDeleteBookvsl", objp);
        }
        //GURU BOOKING NEW
        public void UpdJobInComBooking(int bookingno, int jobno, string strTrantype, int bid, int flag)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                         new SqlParameter("@bookingno", SqlDbType.Int,4),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                         new SqlParameter("@bid", SqlDbType.Int,4),
                                                         new SqlParameter("@flag", SqlDbType.Int,4)
                                                     };
            objp[0].Value = bookingno;
            objp[1].Value = jobno;
            objp[2].Value = strTrantype;
            objp[3].Value = bid;
            objp[4].Value = flag;
            ExecuteQuery("SPUpdJobInComBookingNew", objp);
        }

        public DataTable SELBookingDtlsByJob(string strTrantype, int bid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                    };
            objp[0].Value = strTrantype;
            objp[1].Value = bid;
            objp[2].Value = jobno;
            return ExecuteTable("SPSELCOMBookingDtlsByJob", objp);
        }
        public DataTable SELBookingDtlsByJobnew(string strTrantype, int bid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                    };
            objp[0].Value = strTrantype;
            objp[1].Value = bid;
            objp[2].Value = jobno;
            //return ExecuteTable("SPSelShiprefnoForJobnew", objp);
            //return ExecuteTable("SPSelShiprefnoForJobnewaddjob", objp);

            return ExecuteTable("SPSelShiprefnoForJobnewaddjobone", objp);
        }

        //public void InsBookingVesselDetails(string bookingno, string vsltype, int vessel, string voyage, DateTime eta, int pol, DateTime etd, int pod, DateTime cutoffdt, int bid,int did)
        //{



        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno", SqlDbType.NVarChar,20),
        //                                                new SqlParameter("@vsltype",SqlDbType.Char,1),
        //                                                new SqlParameter("@vessel",SqlDbType.Int),
        //                                                new SqlParameter("@voyage",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@eta",SqlDbType.DateTime,8),
        //                                                new SqlParameter("@pol",SqlDbType.Int),
        //                                                new SqlParameter("@etd",SqlDbType.DateTime,8),
        //                                                new SqlParameter("@pod",SqlDbType.Int),
        //                                                new SqlParameter("@cutoffdt",SqlDbType.DateTime),
        //                                                new SqlParameter("@bid",SqlDbType.TinyInt,1),
        //                                                new SqlParameter("@did",SqlDbType.TinyInt,1)
        //                                               };
        //    objp[0].Value = bookingno;
        //    objp[1].Value = vsltype;
        //    objp[2].Value = vessel;
        //    objp[3].Value = voyage;
        //    objp[4].Value = eta;
        //    objp[5].Value = pol;
        //    objp[6].Value = etd;
        //    objp[7].Value = pod;
        //    objp[8].Value = cutoffdt;
        //    objp[9].Value = bid;
        //    objp[10].Value = did;

        //    ExecuteQuery("SpInsBookingVesselDetails", objp);
        //}



        //public void UpdBookingVesselDetails(string bookingno, string vsltype, int vessel, string voyage, DateTime eta, int pol, DateTime etd, int pod, DateTime cutoffdt,int bid,int did)
        //{



        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno", SqlDbType.NVarChar,20),
        //                                                new SqlParameter("@vsltype",SqlDbType.Char,1),
        //                                                new SqlParameter("@vessel",SqlDbType.Int),
        //                                                new SqlParameter("@voyage",SqlDbType.VarChar,15),
        //                                                new SqlParameter("@eta",SqlDbType.DateTime,8),
        //                                                new SqlParameter("@pol",SqlDbType.Int),
        //                                                new SqlParameter("@etd",SqlDbType.DateTime,8),                                                        
        //                                                new SqlParameter("@pod",SqlDbType.Int),
        //                                                new SqlParameter("@cutoffdt",SqlDbType.DateTime),
        //                                                new SqlParameter("@bid",SqlDbType.TinyInt,1),
        //                                                new SqlParameter("@did",SqlDbType.TinyInt,1)
        //                                               };
        //    objp[0].Value = bookingno;
        //    objp[1].Value = vsltype;
        //    objp[2].Value = vessel;
        //    objp[3].Value = voyage;
        //    objp[4].Value = eta;
        //    objp[5].Value = pol;
        //    objp[6].Value = etd;
        //    objp[7].Value = pod;
        //    objp[8].Value = cutoffdt;
        //    objp[9].Value = bid;
        //    objp[10].Value = did;
        //    ExecuteQuery("SPUpdBookingVesselDetails", objp);
        //}


        public void InsBookingVesselDetails(int bookingno, string vsltype, int vessel, string voyage, DateTime eta, int pol, DateTime etd, int pod, DateTime cutoffdt, int bid)
        {



            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno", SqlDbType.Int,4),
                                                       new SqlParameter("@vsltype",SqlDbType.Char,1),
                                                       new SqlParameter("@vessel",SqlDbType.Int,4),
                                                       new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                       new SqlParameter("@eta",SqlDbType.DateTime,8),
                                                       new SqlParameter("@pol",SqlDbType.Int,4),
                                                       new SqlParameter("@etd",SqlDbType.DateTime,8),
                                                       new SqlParameter("@pod",SqlDbType.Int,4),
                                                       new SqlParameter("@cutoffdt",SqlDbType.DateTime),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                      };
            objp[0].Value = bookingno;
            objp[1].Value = vsltype;
            objp[2].Value = vessel;
            objp[3].Value = voyage;
            objp[4].Value = eta;
            objp[5].Value = pol;
            objp[6].Value = etd;
            objp[7].Value = pod;
            objp[8].Value = cutoffdt;
            objp[9].Value = bid;


            ExecuteQuery("SpInsBookingVesselDetails", objp);
        }



        public void UpdBookingVesselDetails(int bookingno, string vsltype, int vessel, string voyage, DateTime eta, int pol, DateTime etd, int pod, DateTime cutoffdt, int bid)
        {



            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno", SqlDbType.Int,4),
                                                       new SqlParameter("@vsltype",SqlDbType.Char,1),
                                                       new SqlParameter("@vessel",SqlDbType.Int,4),
                                                       new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                       new SqlParameter("@eta",SqlDbType.DateTime,8),
                                                       new SqlParameter("@pol",SqlDbType.Int,4),
                                                       new SqlParameter("@etd",SqlDbType.DateTime,8),                                                        
                                                       new SqlParameter("@pod",SqlDbType.Int,4),
                                                       new SqlParameter("@cutoffdt",SqlDbType.DateTime),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                      };
            objp[0].Value = bookingno;
            objp[1].Value = vsltype;
            objp[2].Value = vessel;
            objp[3].Value = voyage;
            objp[4].Value = eta;
            objp[5].Value = pol;
            objp[6].Value = etd;
            objp[7].Value = pod;
            objp[8].Value = cutoffdt;
            objp[9].Value = bid;

            ExecuteQuery("SPUpdBookingVesselDetails", objp);
        }

        public DataTable GetBookingVesselDetails(int bookingno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bookingno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       };
            objp[0].Value = bookingno;
            objp[1].Value = bid;
            return ExecuteTable("SPSelBookingVesselDetails", objp);
        }

        public void DelBookingVesselDetails(int bookingno, int vessel, string voyage, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {  
                                                        new SqlParameter("@bookingno", SqlDbType.Int,4), 
                                                        new SqlParameter("@vesselid", SqlDbType.Int,4),
                                                        new SqlParameter("@voyage", SqlDbType.VarChar,15),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = vessel;
            objp[2].Value = voyage;
            objp[3].Value = bid;

            ExecuteQuery("SPDelBookingVesselDetails", objp);
        }

        //Raj-------------------------------------------------------//

        public DataTable GetBookingnosearch(string shiprefno, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@shiprefno", SqlDbType.NVarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                               new SqlParameter("@trantype", SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = shiprefno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("SPLikebookingnosearch", objp);
        }

        public DataTable GetBookingnosearchjob(string shiprefno, int intBranchID, int intDivisionID, string trantype, int job)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@shiprefno", SqlDbType.NVarChar,30),
                                                           new SqlParameter("@branchid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                               new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                               new SqlParameter("@jobno",SqlDbType.Int,4)
                                                     };
            objp[0].Value = shiprefno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            objp[4].Value = job;
            return ExecuteTable("SPLikebookingnosearchjob", objp);
        }

        //Raj

        public DataTable GETBookingNofordock(int intBranchID, string trantype, int customerid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                       new SqlParameter("@custid",SqlDbType.Int),
                                                       new SqlParameter("@jobno",SqlDbType.Int)
           };
            objp[0].Value = intBranchID;
            objp[1].Value = trantype;
            objp[2].Value = customerid;
            objp[3].Value = jobno;
            return ExecuteTable("SPSelShiprefnofromdock", objp);
        }

        //Nambi

        public DataSet GetBookingDtls4ETSXML(string bookno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookno;
            objp[1].Value = intBranchID;
            return ExecuteDataSet("SPSelBookingDtls4ETSXML", objp);
        }
        public DataTable SPGETCustid4ETS(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@customerid",SqlDbType.Int,4)
                                                       //new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       };
            objp[0].Value = customerid;
            //  objp[1].Value = bid;
            return ExecuteTable("SPGETCustid4ETS", objp);
        }


        //MUTHU

        public DataTable Sp_bookingslip(int intBranchID, string shiprefno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@shiprefno",SqlDbType.VarChar,50),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)
                                                      
           };
            objp[0].Value = intBranchID;
            objp[1].Value = shiprefno;
            objp[2].Value = trantype;
            return ExecuteTable("Sp_bookingslip", objp);
        }

        // yuvaraj 23-09-2022
        public DataTable SPSelBookingPendingWjobdetails(int bid, string trantype, int cid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt),
                                                        new SqlParameter("@jobno", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = cid;
            objp[3].Value = jobno;
            return ExecuteTable("SPSelBookingPendingWjob", objp);
        }



        public DataTable GetWithOutAmount4CORPandBR(DateTime From, DateTime To, string trantype, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@FromDate",SqlDbType.SmallDateTime),
                new SqlParameter("@ToDate",SqlDbType.SmallDateTime),
                new SqlParameter("@frmtyp",SqlDbType.VarChar,4),
                new SqlParameter("@Bid",SqlDbType.Int),
                new SqlParameter("@Cid",SqlDbType.Int),
            };
            objp[0].Value = From;
            objp[1].Value = To;
            objp[2].Value = trantype;
            objp[3].Value = Bid;
            objp[4].Value = Cid;
            return ExecuteTable("SpSelBookingPerformance4CORPandBR", objp);
        }

        public DataTable seldetails4mis1(int bid, string strtrantype, DateTime fromdate, DateTime todate, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       
                                                       new SqlParameter("@bid", SqlDbType.Int ,4),
                                                         new SqlParameter("@strtrantype", SqlDbType.VarChar ,3),
                                                          new SqlParameter("@fromdate", SqlDbType.DateTime ,10),
                                                      new SqlParameter("@todate", SqlDbType.DateTime ,10),
                 new SqlParameter("@type", SqlDbType.VarChar ),



                                                       
                                                       };

            objp[0].Value = bid;
            objp[1].Value = strtrantype;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = type;


            return ExecuteTable("SPSalesPersonWithETA", objp);

        }
        public DataTable Instaskbooking(int intBranchID, string shiprefno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,50),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)

           };
            objp[0].Value = intBranchID;
            objp[1].Value = shiprefno;
            objp[2].Value = trantype;
            return ExecuteTable("SPInstaskbooking", objp);
        }
        public DataTable GETBookingNoJobInfo4task(int intBranchID, string trantype,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@empid",SqlDbType.Int)
           };
            objp[0].Value = intBranchID;
            objp[1].Value = trantype;
            objp[2].Value = empid;
            return ExecuteTable("SPSelShiprefnoForJobnewadd4TASK", objp);
             
        }
    }
}
