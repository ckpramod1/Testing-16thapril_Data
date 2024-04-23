using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
    public class StuffingConfirmation : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public StuffingConfirmation()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsShippingBill(string bookingno, string sbno, DateTime sbdate, int noofpkgs, int pkgid, double grosswt, string volume, int exporter, int agent, int destination, string remarks, char invpl, int jobno, int intBranchID, int PreparedBy, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar ,30),
                                                       new SqlParameter("@sbno",SqlDbType.VarChar,10),
                                                       new SqlParameter("@sbdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@noofpkg",SqlDbType.Int, 4),  
                                                       new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                       new SqlParameter("@grosswt",SqlDbType.Real, 4), 
                                                       new SqlParameter("@volume",SqlDbType.VarChar, 10),
                                                       new SqlParameter("@shipper",SqlDbType.Int,4), 
                                                       new SqlParameter("@agent",SqlDbType.Int,4), 
                                                       new SqlParameter("@pld",SqlDbType.Int), 
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,100), 
                                                       new SqlParameter("@invpl",SqlDbType.Char,1),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                       new SqlParameter("@preparedby",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)};

            objp[0].Value = bookingno;
            objp[1].Value = sbno;
            objp[2].Value = sbdate;
            objp[3].Value = noofpkgs;
            objp[4].Value = pkgid;
            objp[5].Value = grosswt;
            objp[6].Value = volume;
            objp[7].Value = exporter;
            objp[8].Value = agent;
            objp[9].Value = destination;
            objp[10].Value = remarks;
            objp[11].Value = invpl;
            objp[12].Value = jobno;
            objp[13].Value = PreparedBy;
            objp[14].Value = intBranchID;
            objp[15].Value = intDivisionID;
            ExecuteQuery("SPInsertShipBill", objp);
        }

        public DataTable GetLikeBooking(string trantype, string bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                       { 
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid",SqlDbType.TinyInt),
                                                           new SqlParameter("@cid",SqlDbType.TinyInt)
                                                       };
            objp[0].Value = trantype;
            objp[1].Value = bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPBookingStufflike", objp);
        }
        
        public DataTable GetLikeBookingWJobNo(string trantype, string bookingno, int jobno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                        new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = trantype;
            objp[1].Value = bookingno;
            objp[2].Value = jobno;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPBookingStufflikeWJobNo", objp);
        }
        
        public void InsFEStuffingDtls(int jobno, string shiprefno, int mvesselid, string mvoyage, int pol, DateTime etd, int pod, DateTime eta, string remarks, int intBranchID, int PreparedBy, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@vesselid",SqlDbType.Int),  
                                                           new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                           new SqlParameter("@pol",SqlDbType.Int),  
                                                           new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@pod",SqlDbType.Int),  
                                                           new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@remarks",SqlDbType.VarChar,100), 
                                                           new SqlParameter("@preparedby",SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                      };

            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = mvesselid;
            objp[3].Value = mvoyage;
            objp[4].Value = pol;
            objp[5].Value = etd;
            objp[6].Value = pod;
            objp[7].Value = eta;
            objp[8].Value = remarks;
            objp[9].Value = PreparedBy;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPInsertStuffingDetails", objp);
        }


        public void InsSBContainers(int jobno, string sbno, string containerno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = sbno;
            objp[2].Value = containerno;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPInsSBContainers", objp);
        }
        
        public void InsFEInlandMovement(string shiprefno, string InlandMovement, string ftype, string status,string subject,int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@stuffing",SqlDbType.VarChar,50),
                                                       new SqlParameter("@type",SqlDbType.VarChar,20),
                                                       new SqlParameter("@status", SqlDbType.VarChar, 240),
                                                       new SqlParameter("@subject", SqlDbType.VarChar, 160),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)};
            objp[0].Value = shiprefno;
            objp[1].Value = InlandMovement;
            objp[2].Value = ftype;
            objp[3].Value = status;
            objp[4].Value = subject;
            objp[5].Value = intBranchID;
            objp[6].Value = intDivisionID;
            ExecuteQuery("SPInsFEInlandMovement", objp);
        }

        public void UpdFEInlandMovement(string shiprefno, string InlandMovement, string ftype, int intBranchID, string status, string subject, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@stuffing",SqlDbType.VarChar,50),
                                                       new SqlParameter("@type",SqlDbType.VarChar,20),
                                                       new SqlParameter("@status", SqlDbType.VarChar, 240),
                                                       new SqlParameter("@subject", SqlDbType.VarChar, 160),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = shiprefno;
            objp[1].Value = InlandMovement;
            objp[2].Value = ftype;
            objp[3].Value = status;
            objp[4].Value = subject;
            objp[5].Value = intBranchID;
            objp[6].Value = intDivisionID;
            ExecuteQuery("SPUpdFEInlandMovement", objp);
        }


        public DataTable GetFEInlandMovement(string shiprefno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                         new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = shiprefno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelFEInlandMovement", objp);
        }

        public void DelShippingBill(string sbno, int jobno, int intBranchID, int intDivisionID)
        {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
          
            objp[0].Value = sbno;
            objp[1].Value = jobno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPDelShippingBill", objp);
        }
        //public void DelShippingBill(int jobno, string sbno, int intBranchID,int intDivisionID)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { 
        //                                               new SqlParameter("@jobno",SqlDbType.Int, 4),
        //                                               new SqlParameter("@sbno", SqlDbType.VarChar, 15),
        //                                               new SqlParameter("@bid", SqlDbType.TinyInt),
        //                                               new SqlParameter("@cid", SqlDbType.TinyInt) 
        //                                             };
        //    objp[0].Value = jobno;
        //    objp[1].Value = sbno;
        //    objp[2].Value = intBranchID;
        //    objp[3].Value = intDivisionID;
        //    ExecuteQuery("SPDelShippingBill", objp);
        //}
        

        public void UpdShippingBill(string sbno, DateTime sbdate, int noofpkgs, int pkgid, double grosswt, string volume, int exporter, int agent, int destination, string remarks, char invpl, int jobno, int intBranchID, int intDivisionID)
        {
                SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@sbno",SqlDbType.VarChar,10),
                                                           new SqlParameter("@sbdate", SqlDbType.SmallDateTime, 4),
                                                           new SqlParameter("@noofpkg",SqlDbType.Int, 4),  
                                                           new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                           new SqlParameter("@grosswt",SqlDbType.Real, 4), 
                                                           new SqlParameter("@volume",SqlDbType.VarChar, 10),
                                                           new SqlParameter("@shipper",SqlDbType.Int,4), 
                                                           new SqlParameter("@agent",SqlDbType.Int,4), 
                                                           new SqlParameter("@pld",SqlDbType.Int), 
                                                           new SqlParameter("@remarks",SqlDbType.VarChar,100), 
                                                           new SqlParameter("@invpl",SqlDbType.Char,1),
                                                           new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                        };

           
            objp[0].Value = sbno;
            objp[1].Value = sbdate;
            objp[2].Value = noofpkgs;
            objp[3].Value = pkgid;
            objp[4].Value = grosswt;
            objp[5].Value = volume;
            objp[6].Value = exporter;
            objp[7].Value = agent;
            objp[8].Value = destination;
            objp[9].Value = remarks;
            objp[10].Value = invpl;
            objp[11].Value = jobno;
            objp[12].Value = intBranchID;
            objp[13].Value = intDivisionID;
            ExecuteQuery("SPUpdateShipBill", objp);
        }

        public void UpdFEStuffingDtls(int jobno, string shiprefno, int mvesselid, string mvoyage, int pol, DateTime etd, int pod, DateTime eta, string remarks, int oldvslid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@vesselid",SqlDbType.Int),  
                                                       new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                       new SqlParameter("@pol",SqlDbType.Int),  
                                                       new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@pod",SqlDbType.Int),  
                                                       new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                       new SqlParameter("@oldvslid",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = mvesselid;
            objp[3].Value = mvoyage;
            objp[4].Value = pol;
            objp[5].Value = etd;
            objp[6].Value = pod;
            objp[7].Value = eta;
            objp[8].Value = remarks;
            objp[9].Value = oldvslid;
            objp[10].Value = intBranchID ;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPUpdateStuffingDetails", objp);
        }

        public DataTable GetSBDetails(int jobno, string Bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelSBDetails", objp);
        }


        public DataTable GetMVDetails(int jobno, string Bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelMVDetails", objp);
        }

        public DataTable GetStuffConfContainer(int jobno, string sbno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@sbno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)};
            objp[0].Value = jobno;
            objp[1].Value = sbno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetStuffConfContainer", objp);
        }


        //FELCBooking
        public void InsFELCBooking(int jobno, string shiprefno, int mvesselid, string mvoyage, int pol, DateTime etd, int pod, DateTime eta, string remarks, int intBranchID, int PreparedBy, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@vesselid",SqlDbType.Int),  
                                                           new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                           new SqlParameter("@pol",SqlDbType.Int),  
                                                           new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@pod",SqlDbType.Int),  
                                                           new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@remarks",SqlDbType.VarChar,100), 
                                                           new SqlParameter("@preparedby",SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = mvesselid;
            objp[3].Value = mvoyage;
            objp[4].Value = pol;
            objp[5].Value = etd;
            objp[6].Value = pod;
            objp[7].Value = eta;
            objp[8].Value = remarks;
            objp[9].Value = PreparedBy;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPInsertFELCBooking", objp);
        }


        public void InsFETCBooking(int jobno, string shiprefno, int mvesselid, string mvoyage, int pol, DateTime etd, int pod, DateTime eta, string remarks, int intBranchID, int PreparedBy, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@vesselid",SqlDbType.Int),  
                                                       new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                       new SqlParameter("@pol",SqlDbType.Int),  
                                                       new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@pod",SqlDbType.Int),  
                                                       new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,100), 
                                                       new SqlParameter("@preparedby",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = mvesselid;
            objp[3].Value = mvoyage;
            objp[4].Value = pol;
            objp[5].Value = etd;
            objp[6].Value = pod;
            objp[7].Value = eta;
            objp[8].Value = remarks;
            objp[9].Value = PreparedBy;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPInsertFETCBooking", objp);
        }

        public void UpdFELCBooking(int jobno, string shiprefno, int mvesselid, string mvoyage, int pol, DateTime etd, int pod, DateTime eta, string remarks, int oldvslid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@vesselid",SqlDbType.Int),  
                                                           new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                           new SqlParameter("@pol",SqlDbType.Int),  
                                                           new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@pod",SqlDbType.Int),  
                                                           new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                           new SqlParameter("@oldvslid",SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = mvesselid;
            objp[3].Value = mvoyage;
            objp[4].Value = pol;
            objp[5].Value = etd;
            objp[6].Value = pod;
            objp[7].Value = eta;
            objp[8].Value = remarks;
            objp[9].Value = oldvslid;
            objp[10].Value = intBranchID ;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPUpdateFELCBooking", objp);
        }

        public void UpdFETCBooking(int jobno, string shiprefno, int mvesselid, string mvoyage, int pol, DateTime etd, int pod, DateTime eta, string remarks, int oldvslid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@vesselid",SqlDbType.Int),  
                                                           new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                           new SqlParameter("@pol",SqlDbType.Int),  
                                                           new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@pod",SqlDbType.Int),  
                                                           new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                           new SqlParameter("@oldvslid",SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = mvesselid;
            objp[3].Value = mvoyage;
            objp[4].Value = pol;
            objp[5].Value = etd;
            objp[6].Value = pod;
            objp[7].Value = eta;
            objp[8].Value = remarks;
            objp[9].Value = oldvslid;
            objp[10].Value = intBranchID ;
            objp[11].Value = intDivisionID;
            ExecuteQuery("SPUpdateFETCBooking", objp);
        }
        
        public DataTable GetMVDetails4FELCBooking(int jobno, string Bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelMVDetails4LCBooking", objp);
        }

        public DataTable GetMVDetails4FETCBooking(int jobno, string Bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelMVDetails4TCBooking", objp);
        }

        public DataTable SelStuffStatus(string ftype, string shiprefno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@type", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = ftype;
            objp[1].Value = shiprefno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelStuffStatus", objp);
        }


       public DataTable ChkMVDetailsExist(int jobno, string Bookingno, int vesselid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@vesselid", SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = vesselid;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPChkMVDetails", objp);
        }

        public DataTable ChkLCMVDetailsExist(int jobno, string Bookingno, int vesselid, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@vesselid", SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = vesselid;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPChkLCMVDetails", objp);
        }


        public DataTable ChkTCMVDetailsExist(int jobno, string Bookingno, int vesselid, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@vesselid", SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)};
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = vesselid;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPChkTCMVDetails", objp);
        }


        public DataTable GetLikeCustExporMailID(string mailid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@mailid", SqlDbType.VarChar, 50) 
                                                    };
            objp[0].Value = mailid;
            return ExecuteTable("SPLikeCustExporMailID", objp);
        }


        public DataTable GetLikeEmpMailID(string mailid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mailid", SqlDbType.VarChar, 50) };
            objp[0].Value = mailid;
            return ExecuteTable("SPLikeEmpMailID", objp);
        }

        public bool CheckSBExistance(string SBno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@sbno", SqlDbType.VarChar, 10),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = SBno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            Dt = ExecuteTable("SPCheckSBExistance", objp);
            if (Dt.Rows.Count > 0)
                return true;
            else
                return false;
        }


        public string GetBLNofromBookNo(string bookingno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = bookingno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteReader("SPGetBLNofromBookNo", objp);
        }
        

        public void InsCRMMailids(int jobno, string bookingno, char mailtype, string mailid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@mailtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@mailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = mailtype;
            objp[3].Value = mailid;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            ExecuteQuery("SPInsFECRMMailids", objp);
        }



        public void DelCRMMailids(int jobno, string bookingno, char mailtype, string mailid, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@mailtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@mailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = mailtype;
            objp[3].Value = mailid;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            ExecuteQuery("SPDelFECRMMailids", objp);
        }


        public DataSet SelCRMMailids(int jobno, string Bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                          new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                          new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteDataSet("SPSelFECRMMailids", objp);
        }

        //FEShipment Status
        public void InsFEShipmentStatus(int jobno, string bookingno, DateTime statuson, string status, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@statuson",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@status", SqlDbType.VarChar, 500),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 20)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = statuson;
            objp[3].Value = status;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            objp[6].Value = trantype;
            ExecuteQuery("SPInsFEShipmentStatus", objp);
        }

        public void UpdFEShipmentStatus(int jobno, string bookingno, DateTime statuson, string status, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                           new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                           new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@statuson",SqlDbType.SmallDateTime,4),
                                                           new SqlParameter("@status", SqlDbType.VarChar, 500),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                            new SqlParameter("@trantype", SqlDbType.VarChar, 20)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = statuson;
            objp[3].Value = status;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            objp[6].Value = trantype;
            ExecuteQuery("SPUpdFEShipmentStatus", objp);
        }

        public DataTable SelCRMMailids4shipstatus(int jobno, string Bookingno, int intBranchID, string mailtype, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                      { 
                                                            new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                            new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                            new SqlParameter("@mailtype",SqlDbType.Char,1),
                                                            new SqlParameter("@bid", SqlDbType.TinyInt),
                                                            new SqlParameter("@cid", SqlDbType.TinyInt)
                                                      };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = mailtype;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPSelFECRMMailids4shipstatus", objp);
        }


        public DataTable GetlikeBookingPending4shipstatus(string trantype, string bookingno, int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = trantype;
            objp[1].Value = jobno;
            objp[2].Value = bookingno;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPlikeBookingPending4shipstatus", objp);
        }


        public DataTable SelFEshipstatus(string bookingno, int jobno, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter("@trantype", SqlDbType.VarChar, 20)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = trantype;
            return ExecuteTable("SPSelFEshipstatus", objp);
        }

        public DataTable SelBL4shipstatus(string bookingno, int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@shiprefno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelBL4shipstatus", objp);
        }

        public DataTable GetSBDetails4mail(int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                       { 
                                                            new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                            new SqlParameter("@bid", SqlDbType.TinyInt),
                                                            new SqlParameter("@cid", SqlDbType.TinyInt)
                                                       };
            objp[0].Value = jobno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelSBDetails4mail", objp);
        }

        public void InsCustMailids(string mailid, int custid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@mailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int,4)
                                                   };

            objp[0].Value = mailid;
            objp[1].Value = custid;

            ExecuteQuery("SPInSCustomerMailID", objp);
        }

        public DataTable GetLikeCustMailID(string mailid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@mailid", SqlDbType.VarChar, 50) 
                                                    };
            objp[0].Value = mailid;
            return ExecuteTable("SPLikeCustMailID", objp);
        }

        public DataTable GetLikeAccountantMailID(string mailid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mailid", SqlDbType.VarChar, 50) };
            objp[0].Value = mailid;
            return ExecuteTable("SPLikeAccountantMailID", objp);
        }


        public void InsMvesseldtlsinjob(string product, int jobno, string bookingno, int mvesselid, string mvoyage, DateTime etd, DateTime eta, int pol, int pod, int intBranchID, int intDivisionID, int PreparedBy, string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@Bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@mvessel",SqlDbType.Int),  
                                                           new SqlParameter("@mvoyage",SqlDbType.VarChar,15),
                                                           
                                                           new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                             new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                              new SqlParameter("@pol",SqlDbType.Int), 
                                                           new SqlParameter("@pod",SqlDbType.Int),  
                                                         
                                                          
                                                         
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                             new SqlParameter("@preparedby",SqlDbType.Int),
                                                            new SqlParameter("@remarks",SqlDbType.VarChar,500)
                                                      };

            objp[0].Value = product;
            objp[1].Value = jobno;
            objp[2].Value = bookingno;
            objp[3].Value = mvesselid;
            objp[4].Value = mvoyage;
            objp[5].Value = etd;
            objp[6].Value = eta;
            objp[7].Value = pol;
            objp[8].Value = pod;
            objp[9].Value = intBranchID ;
           
            objp[10].Value = intDivisionID;
            objp[11].Value = PreparedBy;
            objp[12].Value = remarks;
            ExecuteQuery("SPInsMvesseldtlsinjob", objp);
        }

        public DataTable  MVDetails4jobnew(int jobno, string Bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelMVDetails4jobnew", objp);
        }


        public void UpdateMvesseldtlsinjob(string product, int jobno, string bookingno, int mvesselid, string mvoyage, DateTime etd, DateTime eta, int pol, int pod, int intBranchID, int intDivisionID, int PreparedBy, string remarks, int oldvslid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@Bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@mvessel",SqlDbType.Int),  
                                                           new SqlParameter("@mvoyage",SqlDbType.VarChar,15),
                                                           
                                                           new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                             new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                              new SqlParameter("@pol",SqlDbType.Int), 
                                                           new SqlParameter("@pod",SqlDbType.Int),  
                                                         
                                                          
                                                         
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                             new SqlParameter("@preparedby",SqlDbType.Int),
                                                            new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                             new SqlParameter("@oldvslid",SqlDbType.Int)
                                                      };

            objp[0].Value = product;
            objp[1].Value = jobno;
            objp[2].Value = bookingno;
            objp[3].Value = mvesselid;
            objp[4].Value = mvoyage;
            objp[5].Value = etd;
            objp[6].Value = eta;
            objp[7].Value = pol;
            objp[8].Value = pod;
            objp[9].Value = intBranchID;

            objp[10].Value = intDivisionID;
            objp[11].Value = PreparedBy;
            objp[12].Value = remarks;
            objp[13].Value = oldvslid;
            ExecuteQuery("SPUpdateMvesseldtlsinjob", objp);
        }
        public DataTable ChkMVDetailsinjob(int jobno, string Bookingno, int vesselid, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@vesselid", SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = vesselid;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPChkMVDetailsinjob", objp);
        }
        public void InsertOEShipBillinbooking(string bookingno, string sbno, DateTime sbdate, int noofpkgs, int pkgid, double grosswt, string volume, int exporter, int agent, int destination, string remarks, char invpl, int jobno, int intBranchID, int PreparedBy, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar ,30),
                                                       new SqlParameter("@sbno",SqlDbType.VarChar,10),
                                                       new SqlParameter("@sbdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@noofpkg",SqlDbType.Int, 4),  
                                                       new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                       new SqlParameter("@grosswt",SqlDbType.Real, 4), 
                                                       new SqlParameter("@volume",SqlDbType.VarChar, 10),
                                                       new SqlParameter("@shipper",SqlDbType.Int,4), 
                                                       new SqlParameter("@agent",SqlDbType.Int,4), 
                                                       new SqlParameter("@pld",SqlDbType.Int), 
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,100), 
                                                       new SqlParameter("@invpl",SqlDbType.Char,1),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                       new SqlParameter("@preparedby",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)};

            objp[0].Value = bookingno;
            objp[1].Value = sbno;
            objp[2].Value = sbdate;
            objp[3].Value = noofpkgs;
            objp[4].Value = pkgid;
            objp[5].Value = grosswt;
            objp[6].Value = volume;
            objp[7].Value = exporter;
            objp[8].Value = agent;
            objp[9].Value = destination;
            objp[10].Value = remarks;
            objp[11].Value = invpl;
            objp[12].Value = jobno;
            objp[13].Value = PreparedBy;
            objp[14].Value = intBranchID;
            objp[15].Value = intDivisionID;
            ExecuteQuery("SPInsertOEShipBillinbooking", objp);
        }

        public void UpdateShipBillinbooking(string sbno, DateTime sbdate, int noofpkgs, int pkgid, double grosswt, string volume, int exporter, int agent, int destination, string remarks, char invpl, int jobno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@sbno",SqlDbType.VarChar,10),
                                                           new SqlParameter("@sbdate", SqlDbType.SmallDateTime, 4),
                                                           new SqlParameter("@noofpkg",SqlDbType.Int, 4),  
                                                           new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                           new SqlParameter("@grosswt",SqlDbType.Real, 4), 
                                                           new SqlParameter("@volume",SqlDbType.VarChar, 10),
                                                           new SqlParameter("@shipper",SqlDbType.Int,4), 
                                                           new SqlParameter("@agent",SqlDbType.Int,4), 
                                                           new SqlParameter("@pld",SqlDbType.Int), 
                                                           new SqlParameter("@remarks",SqlDbType.VarChar,100), 
                                                           new SqlParameter("@invpl",SqlDbType.Char,1),
                                                           new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                        };


            objp[0].Value = sbno;
            objp[1].Value = sbdate;
            objp[2].Value = noofpkgs;
            objp[3].Value = pkgid;
            objp[4].Value = grosswt;
            objp[5].Value = volume;
            objp[6].Value = exporter;
            objp[7].Value = agent;
            objp[8].Value = destination;
            objp[9].Value = remarks;
            objp[10].Value = invpl;
            objp[11].Value = jobno;
            objp[12].Value = intBranchID;
            objp[13].Value = intDivisionID;
            ExecuteQuery("SPUpdateShipBillinbooking", objp);
        }
        public void DeleteMvesseldtlsinjob(string product, int jobno, string bookingno, int mvesselid,   int intBranchID, int intDivisionID  )
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@Bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@mvessel",SqlDbType.Int),  
                                                            
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                             
                                                      };

            objp[0].Value = product;
            objp[1].Value = jobno;
            objp[2].Value = bookingno;
            objp[3].Value = mvesselid;
             
            objp[4].Value = intBranchID;

            objp[5].Value = intDivisionID;

            ExecuteQuery("SPdeleteMvesseldtlsinjob", objp);
        }
        public void DeleteShipBillinbooking(string sbno  , int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@sbno",SqlDbType.VarChar,10),                                                           
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                        };


            objp[0].Value = sbno;            
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            ExecuteQuery("SPdeleteShipBillinbooking", objp);
        }
        public DataTable GetSBDetailsinbooking(int jobno, string Bookingno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt) 
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = Bookingno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelSBDetailsinbooking", objp);
        }
        public DataTable GetMothervessaldts(int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                               new SqlParameter("@job", SqlDbType.Int, 4),

                                               new SqlParameter("@bid", SqlDbType.TinyInt)

                                             };
            objp[0].Value = jobno;
            objp[1].Value = bid;


            return ExecuteTable("GetMothervessaldts", objp);
        }
        public void DeletevessalDetail(int jobno, int bid, int vesselid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@job", SqlDbType.Int, 4),

                                               new SqlParameter("@bid", SqlDbType.TinyInt),
                                                new SqlParameter("@vesselid", SqlDbType.Int, 4),

                                                };

            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = vesselid;
            ExecuteQuery("SP_deleteMotherVessal", objp);
        }
        public void updateMotherveessel(int jobno, string shiprefno, int mvesselid, string mvoyage, int pol, DateTime etd, int pod, DateTime eta, string remarks, int intBranchID, int PreparedBy, int intDivisionID, int vesselid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                               new SqlParameter("@jobno",SqlDbType.Int,4),
                                               new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                               new SqlParameter("@vesselid",SqlDbType.Int),
                                               new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                               new SqlParameter("@pol",SqlDbType.Int),
                                               new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@pod",SqlDbType.Int),
                                               new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                               new SqlParameter("@preparedby",SqlDbType.Int),
                                               new SqlParameter("@bid", SqlDbType.TinyInt),
                                               new SqlParameter("@cid", SqlDbType.TinyInt),
                                                     new SqlParameter("@updvesselid", SqlDbType.Int, 4),
                                            };
            objp[0].Value = jobno;
            objp[1].Value = shiprefno;
            objp[2].Value = mvesselid;
            objp[3].Value = mvoyage;
            objp[4].Value = pol;
            objp[5].Value = etd;
            objp[6].Value = pod;
            objp[7].Value = eta;
            objp[8].Value = remarks;
            objp[9].Value = PreparedBy;
            objp[10].Value = intBranchID;
            objp[11].Value = intDivisionID;
            objp[12].Value = vesselid;
            ExecuteQuery("SPUpdMotherVessel", objp);
        }

    }
}
