using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAccess.Masters;

namespace DataAccess.Marketing
{
    public class Quotation : DBObject
    {
        MasterCustomer CustObj = new MasterCustomer();
        MasterEmployee EmpObj = new MasterEmployee();
        HR.Employee Employee = new DataAccess.HR.Employee();
        MasterPort PortObj = new MasterPort();
        MasterCargo CargoObj = new MasterCargo();
        MasterCharges ChargeObj = new MasterCharges();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Quotation()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetQuotationDetails(int Quotationno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelQuotHead", objp);
        }

        public DataTable CheckQuotForBookingFromQno(int quotno, string trantype, int intBranchID, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@quotno",SqlDbType.Int), 
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1), 
                                                        new SqlParameter("@type",SqlDbType.VarChar,2)};
            objp[0].Value = quotno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = type;
            return ExecuteTable("SPCheckQuotForBookingFromQNo", objp);
        }

        public string GetBranchmgrmailid(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int) };
            objp[0].Value = bid;
            return ExecuteReader("SPGetBranchmgrmailid", objp);
        }

        public string GetQuotationShipType(int Quotationno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteReader("SPSelQuotShipType", objp);
        }

        //Insert Quotation Details.
        public int InsertQuotationDetails(DateTime Quotationdate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby, int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country)
        {

            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@quotdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@quotno",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1)};
            objp[0].Value = Quotationdate;
            objp[1].Value = Trantype;
            objp[2].Value = custid;
            objp[3].Value = intPOR;
            objp[4].Value = intPOL;
            objp[5].Value = intPOD;
            objp[6].Value = intFD;
            objp[7].Value = stype;
            objp[8].Value = ftype;
            objp[9].Value = intCargo;
            objp[10].Value = Description;
            objp[11].Value = Validtill;
            objp[12].Value = intMarketedby;
            objp[13].Value = intPreparedby;
            objp[14].Value = hazardous;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = intBranchID;
            objp[17].Value = strRemarks;
            objp[18].Value = strBrokerage;
            objp[19].Value = buyingno;
            objp[20].Value = intDivID;
            objp[21].Value = bus; objp[22].Value = country;
            return ExecuteQuery("SPInsQHead", objp, "@quotno");
        }

        //Update Quotation Details.
        public void UpdateQuotationDetails(int Qid, DateTime validtill, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby, int hazardous, string Trantype, string strRemarks, string strBrokerage, int intBranchID, int buyingno, string bus, string country)
        {
            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),   
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1)};
            objp[0].Value = Qid;
            objp[1].Value = custid;
            objp[2].Value = intPOR;
            objp[3].Value = intPOL;
            objp[4].Value = intPOD;
            objp[5].Value = intFD;
            objp[6].Value = stype;
            objp[7].Value = ftype;
            objp[8].Value = intCargo;
            objp[9].Value = validtill;
            objp[10].Value = intMarketedby;
            objp[11].Value = intPreparedby;
            objp[12].Value = Description;
            objp[13].Value = hazardous;
            objp[14].Value = intBranchID;
            objp[15].Value = strRemarks;
            objp[16].Value = strBrokerage;
            objp[17].Value = buyingno;
            objp[18].Value = bus;
            objp[19].Value = country;
            ExecuteQuery("SPUpdQHead", objp);
        }

        //Update Quotation Details with Approval. 
        public void UpdateQuotationDetailsWApp(int Qid, DateTime validtill, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby, int intApprovedby, int hazardous, DateTime approvedon, int intBranchID)
        {
            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),   
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                     new SqlParameter("@approvedon",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Qid;
            objp[1].Value = custid;
            objp[2].Value = intPOR;
            objp[3].Value = intPOL;
            objp[4].Value = intPOD;
            objp[5].Value = intFD;
            objp[6].Value = stype;
            objp[7].Value = ftype;
            objp[8].Value = intCargo;
            objp[9].Value = validtill;
            objp[10].Value = intMarketedby;
            objp[11].Value = intPreparedby;
            objp[12].Value = intApprovedby;
            objp[13].Value = Description;
            objp[14].Value = hazardous;
            objp[15].Value = approvedon;
            objp[16].Value = intBranchID;
            ExecuteQuery("SPUpdQHeadApp", objp);
        }

        ////Get Quotation no.
        //public int GetQuotationno(int intBranchID)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
        //    return int.Parse(ExecuteReader("SPUpdMCQuot",objp));
        //}

        //Get Shipmenttype.
        public char GetShipmenttype(string stype)
        {
            if (stype == "LCL")
                return 'L';

            else if (stype == "AIR")
                return 'A';
            else if (stype == "FCL")

                return 'F';
            else
                return ' ';
        }

        public string GetShipment(char shiptype)
        {
            if (shiptype == 'L')
                return "LCL";
            else if (shiptype == 'A')
                return "AIR";
            else if (shiptype == 'F')
                return "FCL";
            else
                return " ";
        }

        //Get Frighttype
        public char GetFrighttype(string Fright)
        {
            if (Fright == "PrePaid")
                return 'P';
            else
                return 'C';
        }

        //Get Fright
        public string GetFright(char frighttype)
        {
            if (frighttype == 'P')
                return "PrePaid";
            else
                return "Collect";
        }

        //public string GetFright(char frighttype)
        //{
        //    if (frighttype == 'P')
        //        return "PrePaid";
        //    else
        //        return "To Collect";
        //}


        //**** Charge Grid ********

        //Bind GrdCharges
        public DataTable ChargeDetails(int Quotid, int intBranchID, string shiprefno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30)};
            objp[0].Value = Quotid;
            objp[1].Value = intBranchID;
            objp[2].Value = shiprefno;
            return ExecuteTable("SPSelQCharges", objp);
        }
        public DataTable ChargeDetailsGT0(int Quotid, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotid;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelQChargesGT0", objp);
        }

        //Bind GrdBuyingCharges
        public DataTable ChargeBuyingDetails(int buyingid, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = buyingid;
            return ExecuteTable("SPSelBCharges", objp);
        }

        //Update Grdcharges 
        public void UpdateGrdChargeDetails(int quotationno, string chargename, string curr, double rate, int intBranchID, string strbase, string oldbase)
        {
            int chargeid = ChargeObj.GetChargeid(chargename);
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@qno",SqlDbType.Int,4),
                                                         new SqlParameter("@chargeid",SqlDbType.Int),
                                                         new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                         new SqlParameter("@rate",SqlDbType.Money,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@base",SqlDbType.VarChar,45),
                                                         new SqlParameter("@oldbase",SqlDbType.VarChar,45)};
            objp[0].Value = quotationno;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = intBranchID;
            objp[5].Value = strbase;
            objp[6].Value = oldbase;
            ExecuteQuery("SPUpdGrdCharge", objp);
        }

        //insert charge Details.
        public bool InsertChargeDetails(int quotationid, string chargename, string curr, double rate, string Base, int intBranchID, int intDivID)
        {
            bool exist;
            int chargeid = ChargeObj.GetChargeid(chargename);
            exist = CheckChargeExist(chargeid, quotationid, Base, intBranchID);
            if (!exist)
            {
                SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                           new SqlParameter("@chargeid",SqlDbType.Int),
                                                           new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                           new SqlParameter("@rate",SqlDbType.Money,8),
                                                           new SqlParameter("@base",SqlDbType.VarChar,45),
                                                           new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                           new SqlParameter("@cid",SqlDbType.TinyInt,1)};
                objp[0].Value = quotationid;
                objp[1].Value = chargeid;
                objp[2].Value = curr;
                objp[3].Value = rate;
                objp[4].Value = Base;
                objp[5].Value = intBranchID;
                objp[6].Value = intDivID;
                ExecuteQuery("SPInsQDtls", objp);
                return true;
            }
            return false;
        }

        public bool CheckChargeExist(int chargeid, int Qno, string cbase, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid",SqlDbType.Int),
                                                       new SqlParameter("@base",SqlDbType.VarChar,6),
                                                       new SqlParameter("@bid",SqlDbType.Char,10)};
            objp[0].Value = Qno;
            objp[1].Value = chargeid;
            objp[2].Value = cbase;
            objp[3].Value = intBranchID;
            if (ExecuteTable("SPSelChgidQnoBase", objp).Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        //Delete ChargeDetails.
        public void DeleteGrdcharges(string chargename, int qno, string strbase, int intBranchID)
        {
            int cid = ChargeObj.GetChargeid(chargename);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int, 4), 
                                                       new SqlParameter("@chargeid",SqlDbType.Int),
                                                       new SqlParameter("@base",SqlDbType.VarChar,6),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = qno;
            objp[1].Value = cid;
            objp[2].Value = strbase;
            objp[3].Value = intBranchID;
            ExecuteQuery("SPDelGrdCharge", objp);
        }

        //****** Quotation Grid *******

        //Bind Quotation Details.

        public DataTable QuotationDetails(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelGrdQuotDtls", objp);
        }

        //***** Approval Pending Grid *****
        public DataTable ApprovalPendingDetails(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelQuotApproval ", objp);
        }

        public DataTable QuotDetails(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelQuotDt", objp);
        }

        //   public void QuotationApproval(int Quotationid)
        //{

        //}

        public void DeleteQuotation(int qno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int, 4), 
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = qno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            ExecuteQuery("SPDelQuotation", objp);
        }
        public DataTable CheckQuotationApproved(int Quotationno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int), 
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelApprovdQuotHead", objp);
        }
        public void UpdQuotationValidTill(int Quotationno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int), 
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            ExecuteQuery("SPUpdQuotvalidtill", objp);
        }

        //quotation for fiquery
        public DataTable GetQuotationDetails4qry(int Quotationno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelQuotHead4qry", objp);
        }
        public DataTable QuotationDetailsCust(string trantype, int intBranchID, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@custid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = custid;
            return ExecuteTable("SPSelGrdQuotDtlscust", objp);
        }
        //BHARATHI
        public DataTable GetLikeCustomerForSales(string customername, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = empid;
            return ExecuteTable("SPLikeCustomerforSales", objp);

        }
        public DataTable GetLikeCurrency(string currency)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@Curr",SqlDbType.VarChar,3)
                                                                                     };
            objp[0].Value = currency;
            //objp[1].Value = empid;
            return ExecuteTable("SPLikeCurr", objp);

        }
        public DataTable GetLikeCurrencyName(string Currency)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@Currency",SqlDbType.VarChar,10)
                                                                                     };
            objp[0].Value = Currency;
            //objp[1].Value = empid;
            return ExecuteTable("SPSelCurr", objp);

        }
        public DataTable GetLikeEmployeeName(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empname",SqlDbType.VarChar,50)
                                                                                     };
            objp[0].Value = empname;
            //objp[1].Value = empid;
            return ExecuteTable("SPSelEmployee", objp);

        }
        public DataTable RetrieveCustomerDetails4Pin(int intCustID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = intCustID;
            return ExecuteTable("SPSelCustomerDetails4webPin", objp);
        }

        //Guru
        public DataTable GetFEUnclosdjobs(int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@salesid", SqlDbType.Int, 4) };
            objp[0].Value = salesid;

            return ExecuteTable("SPFEUnclosedJobs", objp);

        }
        public DataTable GetFiWIP()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                                                     };

            return ExecuteTable("SPSelWIP ");

        }
        public DataTable GetFEUnclosdjobsNew()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                                                     };

            return ExecuteTable("SPFEUnclosedJobsNew");

        }
        public DataTable GetFIUnclosdjobs(int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@salesid", SqlDbType.Int, 4) };
            objp[0].Value = salesid;

            return ExecuteTable("SpFiUnclosedJob", objp);

        }
        public DataTable GetAIUnclosdjobs(int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@salesid", SqlDbType.Int, 4) };
            objp[0].Value = salesid;

            return ExecuteTable("SpAiUnClosedJoibs", objp);

        }
        public DataTable GetAEUnclosdjobs(int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@salesid", SqlDbType.Int, 4) };
            objp[0].Value = salesid;

            return ExecuteTable("SpAeUnclosedJob", objp);

        }


        //Arun

        public DataTable GetQuation4salesnew(int salesid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@divisionid",SqlDbType.Int)
                                                  };

            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;

            return ExecuteTable("SPGetQuaotationDetails4New", objp);
        }
        public DataTable WSQuotHeadDetails(int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branch", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 5)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            return ExecuteTable("SPGetQuotApprovalDet4CS", objp);
        }
        public void UpdateQuotationDetailsWAppWS(int Qid, int intApprovedby, DateTime approvedon, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),                                                     
                                                     new SqlParameter("@approvedby",SqlDbType.Int),                                                   
                                                     new SqlParameter("@approvedon",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Qid;
            objp[1].Value = intApprovedby;
            objp[2].Value = approvedon;
            objp[3].Value = intBranchID;
            ExecuteQuery("SPUpdQHeadAppWS", objp);
        }

        public DataTable GetquationCount(int salesid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@divisionid",SqlDbType.Int)
                                                  };

            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;

            return ExecuteTable("SpGetQuotationCount", objp);
        }

        //Dinesh
        public string quotbuyingget(int buyingno)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@buyno",SqlDbType.Int)
                                                      };
            objp[0].Value = buyingno;
            return ExecuteReader("quotbuyingget", objp);
        }

        //MUTHU

        public DataTable GetQuation4salesnew1(int salesid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@divisionid",SqlDbType.Int)
                                                  };

            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;

            return ExecuteTable("SPGetQuaotationDetails4New1", objp);
        }
        //muthu

        public DataTable GetQuation4salesnewOECS(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@divisionid",SqlDbType.Int)
                                                  };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;


            return ExecuteTable("SPGetQuaotationDetails4NewOECS", objp);
        }

        public DataTable SPGetQuaotationDetails4NewOECSnew(int branchid, int divisionid, string strantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                                                  new SqlParameter("@trantype",SqlDbType.VarChar,4)
                                                  };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = strantype;


            return ExecuteTable("SPGetQuaotationDetails4NewOECSnew", objp);
        }
        //raj
        public DataTable GetQuatForprocuiNew(int quatno, int branchid, int customerid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int),
                                                     new SqlParameter("@branch",SqlDbType.Int),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,5)
            };

            objp[0].Value = quatno;
            objp[1].Value = branchid;
            objp[2].Value = customerid;
            objp[3].Value = trantype;

            return ExecuteTable("GetProcessui4Sales", objp);

        }

        //Insert Quotation Details.
        public int InsertQuotationDetails(DateTime Quotationdate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby, int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int bid, int cid)
        {

            char stype = GetShipmenttype(Shipmenttype);
            //int cargotype = CargoObj.GetCargoid(Cargo);
            char ftype = GetFrighttype(fright);
            //int pid =EmpObj.GetNEmpid(Preparedby);
            //int mid = EmpObj.GetNEmpid(Marketedby);

            SqlParameter[] objp = new SqlParameter[] { //new SqlParameter("@quotno",SqlDbType.Int,4),
                                                     new SqlParameter("@quotdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@quotno",SqlDbType.Int,4),
                                                    new SqlParameter("@dbname",SqlDbType.Char,10),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            //objp[0].Value = Quotationno;
            objp[0].Value = Quotationdate;
            objp[1].Value = Trantype;
            objp[2].Value = custid;
            objp[3].Value = intPOR;
            objp[4].Value = intPOL;
            objp[5].Value = intPOD;
            objp[6].Value = intFD;
            objp[7].Value = stype;
            objp[8].Value = ftype;
            objp[9].Value = intCargo;
            objp[10].Value = Description;
            objp[11].Value = Validtill;
            objp[12].Value = intMarketedby;
            objp[13].Value = intPreparedby;
            objp[14].Value = hazardous;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = "FA" + intBranchID;
            objp[17].Value = strRemarks;
            objp[18].Value = strBrokerage;
            objp[19].Value = buyingno;
            objp[20].Value = bid;
            objp[21].Value = cid;
            return ExecuteQuery("SPInsQHead", objp, "@quotno");
            //ExecuteQuery("SPInsQHead",objp);
            //return Quotationno;
        }

        public DataTable RetrieveCustGroupDetails(int Groupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupid", SqlDbType.Int) };

            objp[0].Value = Groupid;

            return ExecuteTable("SPGetMasterCustGroupDts", objp);

        }


        //Get Fright
        public string GetFrightAEAI(char frighttype)
        {
            if (frighttype == 'P')
                return "PrePaid";
            else
                return "Collect";
        }



        public DataTable getebookingdetails(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                  new SqlParameter("@branchid",SqlDbType.Int)
                                                 
                                                  };


            objp[0].Value = branchid;


            return ExecuteTable("spebookingdetails ", objp);
        }
        // yuvaraj 08/09/2022
        public DataTable ChargeBuyingDetailsnew(int buyingid, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = buyingid;
            return ExecuteTable("SPSelBChargesnew", objp);
        }
        public bool InsertcombinedChargeDetailsnew(int quotationid, string chargename, string curr, double rate, string Base, int intBranchID, int intDivID, double expqty, double exrate, double amount)
        {
            bool exist;
            int chargeid = ChargeObj.GetChargeid(chargename);
            exist = CheckChargeExist(chargeid, quotationid, Base, intBranchID);
            if (!exist)
            {
                SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                           new SqlParameter("@chargeid",SqlDbType.Int),
                                                           new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                           new SqlParameter("@rate",SqlDbType.Money,8),
                                                           new SqlParameter("@base",SqlDbType.VarChar,45),
                                                          new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                           new SqlParameter("@cid",SqlDbType.TinyInt,1),
                new SqlParameter("@expqty",SqlDbType.Real),
             new SqlParameter("@exrate",SqlDbType.Money),
             new SqlParameter("@amount",SqlDbType.Money)};

                objp[0].Value = quotationid;
                objp[1].Value = chargeid;
                objp[2].Value = curr;
                objp[3].Value = rate;
                objp[4].Value = Base;
                objp[5].Value = intBranchID;
                objp[6].Value = intDivID;
                objp[7].Value = expqty;
                objp[8].Value = exrate;
                objp[9].Value = amount;
                ExecuteQuery("SPInscombinedQDtlsnew", objp);
                return true;
            }
            return false;
        }

        public void Updquotmarginper(int quotationno, string chargename, int intBranchID, decimal margin, decimal retention)
        {
            int chargeid = ChargeObj.GetChargeid(chargename);
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@qno",SqlDbType.Int,4),
                                                         new SqlParameter("@chargeid",SqlDbType.Int),                                                      
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@margin",SqlDbType.Decimal),
                                                          new SqlParameter("@retention",SqlDbType.Decimal)
                                                        
             };
            objp[0].Value = quotationno;
            objp[1].Value = chargeid;
            objp[2].Value = intBranchID;
            objp[3].Value = margin;
            objp[4].Value = retention;

            ExecuteQuery("SPUpdquotmarginper", objp);
        }
        public DataTable ChargeDetailsnew(int Quotid, int intBranchID, string shiprefno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30)};
            objp[0].Value = Quotid;
            objp[1].Value = intBranchID;
            objp[2].Value = shiprefno;
            return ExecuteTable("SPSelQChargesnew", objp);
        }
        public void UpdateGrdChargeDetailsnew(int quotationno, string chargename, string curr, double rate, int intBranchID, string strbase, string oldbase, double expqty, double exrate, double amount)
        {
            int chargeid = ChargeObj.GetChargeid(chargename);
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@qno",SqlDbType.Int,4),
                                                         new SqlParameter("@chargeid",SqlDbType.Int),
                                                         new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                         new SqlParameter("@rate",SqlDbType.Money,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@base",SqlDbType.VarChar,45),
                                                         new SqlParameter("@oldbase",SqlDbType.VarChar,45),
             new SqlParameter("@expqty",SqlDbType.Real),
             new SqlParameter("@exrate",SqlDbType.Money),
             new SqlParameter("@amount",SqlDbType.Money)};
            objp[0].Value = quotationno;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = intBranchID;
            objp[5].Value = strbase;
            objp[6].Value = oldbase;
            objp[7].Value = expqty;
            objp[8].Value = exrate;
            objp[9].Value = amount;
            ExecuteQuery("SPUpdGrdChargenew", objp);
        }


        public DataTable QuotationDetailsnew(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelGrdQuotDtlsnew", objp);
        }
        public DataTable GetcombbinedQuotationDetails(int Quotationno, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelCombinedQuotHead", objp); // ok yuvaraj
        }
        public DataTable SpGetversion(int quotationno, int intBranchID)
        {

            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@qno",SqlDbType.Int,4),                                                        
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                         };
            objp[0].Value = quotationno;
            objp[1].Value = intBranchID;

            return ExecuteTable("SpGetversion", objp);
        }
        public DataTable Getbuyingdtls(int chargeid, int rateid, string basetype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int),
                 new SqlParameter("@rateid", SqlDbType.Int),
                  new SqlParameter("@base", SqlDbType.VarChar,6)
            };
            objp[0].Value = chargeid;
            objp[1].Value = rateid;
            objp[2].Value = basetype;
            return ExecuteTable("SPGetbuyingdtls", objp);
        }
        public void UpdateCombinedQuotationDetail(int Qid, DateTime validtill, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo,
         string Description, int intMarketedby, int intPreparedby, int hazardous, string Trantype, string strRemarks, string strBrokerage, int intBranchID, int buyingno, string bus,
         string country, string Terms, int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope
       , string pieces, string noofcont, decimal grwt, string noofunits, double volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, DateTime enqno)
        {
            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1),
             new SqlParameter("@Terms",SqlDbType.VarChar,5000),
            new SqlParameter("@inco",SqlDbType.Int),
                  new SqlParameter("@shipperid",SqlDbType.Int),
                     new SqlParameter("@consigneeid",SqlDbType.Int),
                     new SqlParameter("@cuspono",SqlDbType.VarChar,50),
                     new SqlParameter("@routing",SqlDbType.VarChar,50 ),
                     new SqlParameter("@transittime",SqlDbType.VarChar,50 ),
                     new SqlParameter("@scope",SqlDbType.Int),
                     new SqlParameter("@pieces",SqlDbType.VarChar,50 ),
                        new SqlParameter("@noofcont",SqlDbType.VarChar,50 ),
              new SqlParameter("@grwt",SqlDbType.Decimal ),
                new SqlParameter("@noofunits",SqlDbType.VarChar,50 ),
                  new SqlParameter("@volume",SqlDbType.Real ),
                    new SqlParameter("@dimension",SqlDbType.VarChar,30 ),
                 new SqlParameter("@value",SqlDbType.VarChar,50 ),
                      new SqlParameter("@chrageblewt",SqlDbType.Decimal),
                       new SqlParameter("@totaldays",SqlDbType.Int),
                         new SqlParameter("@feasibility",SqlDbType.VarChar,1),
             new SqlParameter("@enqno",SqlDbType.DateTime),
            };
            objp[0].Value = Qid;
            objp[1].Value = custid;
            objp[2].Value = intPOR;
            objp[3].Value = intPOL;
            objp[4].Value = intPOD;
            objp[5].Value = intFD;
            objp[6].Value = stype;
            objp[7].Value = ftype;
            objp[8].Value = intCargo;
            objp[9].Value = validtill;
            objp[10].Value = intMarketedby;
            objp[11].Value = intPreparedby;
            objp[12].Value = Description;
            objp[13].Value = hazardous;
            objp[14].Value = intBranchID;
            objp[15].Value = strRemarks;
            objp[16].Value = strBrokerage;
            objp[17].Value = buyingno;
            objp[18].Value = bus;
            objp[19].Value = country;
            objp[20].Value = Terms;

            objp[21].Value = inco;
            objp[22].Value = shipperid;
            objp[23].Value = consigneeid;
            objp[24].Value = cuspono;
            objp[25].Value = routing;
            objp[26].Value = transittime;
            objp[27].Value = scope;
            objp[28].Value = pieces;
            objp[29].Value = noofcont;
            objp[30].Value = grwt;
            objp[31].Value = noofunits;
            objp[32].Value = volume;
            objp[33].Value = dimension;
            objp[34].Value = value;
            objp[35].Value = chrageblewt;
            objp[36].Value = totaldays;
            objp[37].Value = feasibility;
            objp[38].Value = enqno;
            ExecuteQuery("SPUpdcombinedQHead", objp);
        }
        public int InsertcombinedQuotationDetails(DateTime Quotationdate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL,
          int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby,
          int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country, string Terms,
int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope
, string pieces, string noofcont, decimal grwt, string noofunits, double volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, DateTime enqno)
        {

            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@quotdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@quotno",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1),
             new SqlParameter("@Terms",SqlDbType.VarChar,5000),
               new SqlParameter("@inco",SqlDbType.Int),
                  new SqlParameter("@shipperid",SqlDbType.Int),
                     new SqlParameter("@consigneeid",SqlDbType.Int),
                     new SqlParameter("@cuspono",SqlDbType.VarChar,50),
                     new SqlParameter("@routing",SqlDbType.VarChar,50 ),
                     new SqlParameter("@transittime",SqlDbType.VarChar,50 ),
                     new SqlParameter("@scope",SqlDbType.Int),
                     new SqlParameter("@pieces",SqlDbType.VarChar,50 ),
                       new SqlParameter("@noofcont",SqlDbType.VarChar,50 ),
              new SqlParameter("@grwt",SqlDbType.Decimal ),
                new SqlParameter("@noofunits",SqlDbType.VarChar,50 ),
                  new SqlParameter("@volume",SqlDbType.Real ),
                    new SqlParameter("@dimension",SqlDbType.VarChar,30 ),
                    new SqlParameter("@value",SqlDbType.VarChar,50 ),
                      new SqlParameter("@chrageblewt",SqlDbType.Decimal),
                       new SqlParameter("@totaldays",SqlDbType.Int),
                         new SqlParameter("@feasibility",SqlDbType.VarChar,1),
                             new SqlParameter("@enqno",SqlDbType.DateTime),
            };
            objp[0].Value = Quotationdate;
            objp[1].Value = Trantype;
            objp[2].Value = custid;
            objp[3].Value = intPOR;
            objp[4].Value = intPOL;
            objp[5].Value = intPOD;
            objp[6].Value = intFD;
            objp[7].Value = stype;
            objp[8].Value = ftype;
            objp[9].Value = intCargo;
            objp[10].Value = Description;
            objp[11].Value = Validtill;
            objp[12].Value = intMarketedby;
            objp[13].Value = intPreparedby;
            objp[14].Value = hazardous;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = intBranchID;
            objp[17].Value = strRemarks;
            objp[18].Value = strBrokerage;
            objp[19].Value = buyingno;
            objp[20].Value = intDivID;
            objp[21].Value = bus;
            objp[22].Value = country;
            objp[23].Value = Terms;

            objp[24].Value = inco;
            objp[25].Value = shipperid;
            objp[26].Value = consigneeid;
            objp[27].Value = cuspono;
            objp[28].Value = routing;
            objp[29].Value = transittime;
            objp[30].Value = scope;
            objp[31].Value = pieces;
            objp[32].Value = noofcont;
            objp[33].Value = grwt;
            objp[34].Value = noofunits;
            objp[35].Value = volume;
            objp[36].Value = dimension;
            objp[37].Value = value;
            objp[38].Value = chrageblewt;
            objp[39].Value = totaldays;
            objp[40].Value = feasibility;
            objp[41].Value = enqno;
            return ExecuteQuery("SPInsCombinedQHead", objp, "@quotno");
        }
        public DataTable GetcombbinedQuotationDetailsversion(int Quotationno, string trantype, int intBranchID, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),  new SqlParameter("@version",SqlDbType.Int)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = version;
            return ExecuteTable("SPSelCombinedQuotHeadversion", objp);
        }
        public int InsertQuotationDetailsnew(DateTime Quotationdate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby, int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country, string Terms)
        {

            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@quotdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@quotno",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1),
             new SqlParameter("@Terms",SqlDbType.VarChar,500)};
            objp[0].Value = Quotationdate;
            objp[1].Value = Trantype;
            objp[2].Value = custid;
            objp[3].Value = intPOR;
            objp[4].Value = intPOL;
            objp[5].Value = intPOD;
            objp[6].Value = intFD;
            objp[7].Value = stype;
            objp[8].Value = ftype;
            objp[9].Value = intCargo;
            objp[10].Value = Description;
            objp[11].Value = Validtill;
            objp[12].Value = intMarketedby;
            objp[13].Value = intPreparedby;
            objp[14].Value = hazardous;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = intBranchID;
            objp[17].Value = strRemarks;
            objp[18].Value = strBrokerage;
            objp[19].Value = buyingno;
            objp[20].Value = intDivID;
            objp[21].Value = bus; objp[22].Value = country;
            objp[23].Value = Terms;
            return ExecuteQuery("SPInsQHeadnew", objp, "@quotno");
        }
        public void Updversion(int quotationno, int intBranchID, int version)
        {

            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@qno",SqlDbType.Int,4),                                                        
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                          new SqlParameter("@version",SqlDbType.Int,4)};
            objp[0].Value = quotationno;
            objp[1].Value = intBranchID;
            objp[2].Value = version;
            ExecuteQuery("SPUpdversion", objp);
        }
        public int InsertcombinedQuotationDetailsversion(DateTime Quotationdate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL,
         int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby,
         int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country, string Terms,
int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope
, string pieces, string noofcont, decimal grwt, string noofunits, decimal volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, int version, int qno, DateTime enqno)
        {

            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@quotdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@quotno",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1),
             new SqlParameter("@Terms",SqlDbType.VarChar,5000),
               new SqlParameter("@inco",SqlDbType.Int),
                  new SqlParameter("@shipperid",SqlDbType.Int),
                     new SqlParameter("@consigneeid",SqlDbType.Int),
                     new SqlParameter("@cuspono",SqlDbType.VarChar,50),
                     new SqlParameter("@routing",SqlDbType.VarChar,50 ),
                     new SqlParameter("@transittime",SqlDbType.VarChar,50 ),
                     new SqlParameter("@scope",SqlDbType.Int),
                     new SqlParameter("@pieces",SqlDbType.VarChar,50 ),
                       new SqlParameter("@noofcont",SqlDbType.VarChar,50 ),
              new SqlParameter("@grwt",SqlDbType.Decimal ),
                new SqlParameter("@noofunits",SqlDbType.VarChar,50 ),
                  new SqlParameter("@volume",SqlDbType.Decimal ),
                    new SqlParameter("@dimension",SqlDbType.VarChar,30 ),
                    new SqlParameter("@value",SqlDbType.VarChar,50 ),
                      new SqlParameter("@chrageblewt",SqlDbType.Decimal),
                       new SqlParameter("@totaldays",SqlDbType.Int),
                         new SqlParameter("@feasibility",SqlDbType.VarChar,1),
                          new SqlParameter("@version",SqlDbType.Int,4),
                            new SqlParameter("@qno",SqlDbType.Int,4),new SqlParameter("@enqno",SqlDbType.DateTime )
            };
            objp[0].Value = Quotationdate;
            objp[1].Value = Trantype;
            objp[2].Value = custid;
            objp[3].Value = intPOR;
            objp[4].Value = intPOL;
            objp[5].Value = intPOD;
            objp[6].Value = intFD;
            objp[7].Value = stype;
            objp[8].Value = ftype;
            objp[9].Value = intCargo;
            objp[10].Value = Description;
            objp[11].Value = Validtill;
            objp[12].Value = intMarketedby;
            objp[13].Value = intPreparedby;
            objp[14].Value = hazardous;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = intBranchID;
            objp[17].Value = strRemarks;
            objp[18].Value = strBrokerage;
            objp[19].Value = buyingno;
            objp[20].Value = intDivID;
            objp[21].Value = bus;
            objp[22].Value = country;
            objp[23].Value = Terms;

            objp[24].Value = inco;
            objp[25].Value = shipperid;
            objp[26].Value = consigneeid;
            objp[27].Value = cuspono;
            objp[28].Value = routing;
            objp[29].Value = transittime;
            objp[30].Value = scope;
            objp[31].Value = pieces;
            objp[32].Value = noofcont;
            objp[33].Value = grwt;
            objp[34].Value = noofunits;
            objp[35].Value = volume;
            objp[36].Value = dimension;
            objp[37].Value = value;
            objp[38].Value = chrageblewt;
            objp[39].Value = totaldays;
            objp[40].Value = feasibility;
            objp[41].Value = version;
            objp[42].Value = qno;
            objp[43].Value = enqno;
            return ExecuteQuery("SPInsCombinedQHeadversion", objp, "@quotno");
        }
        public void InsertChargeDetailsnewversion(int quotationid, int intBranchID, int intDivID, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),                                                           
                                                          new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                           new SqlParameter("@cid",SqlDbType.TinyInt,1),               
                 new SqlParameter("@version",SqlDbType.Int)};
            objp[0].Value = quotationid;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivID;
            objp[3].Value = version;
            ExecuteQuery("SPInsQDtlsnewversion", objp);
        }
        public DataTable Getterms(string type, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.VarChar, 5),
                 new SqlParameter("@trantype", SqlDbType.VarChar, 2)
            };
            objp[0].Value = type;
            objp[1].Value = trantype;
            return ExecuteTable("SPGetterms", objp);
        }

        public DataTable CheckMax(int Quotationno, int intBranchID, int intDivID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotationno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivID;
            return ExecuteTable("SPCheckMax", objp);
        }
        public void DeleteGrdchargesnew(string chargename, int qno, string strbase, int intBranchID)
        {
            int cid = ChargeObj.GetChargeid(chargename);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int, 4), 
                                                       new SqlParameter("@chargeid",SqlDbType.Int),
                                                       new SqlParameter("@base",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = qno;
            objp[1].Value = cid;
            objp[2].Value = strbase;
            objp[3].Value = intBranchID;
            ExecuteQuery("SPDelGrdChargenew", objp);
        }
        public DataTable Checkquotform(int quotno, int intBranchID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@quotno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.TinyInt,1),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      };
            objp[0].Value = quotno;
            objp[1].Value = intBranchID;
            objp[2].Value = trantype;
            return ExecuteTable("SPCheckquotform", objp);
        }

        public DataTable ChargeDetailsnewversion(int Quotid, int intBranchID, string shiprefno, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),new SqlParameter("@version",SqlDbType.Int)};
            objp[0].Value = Quotid;
            objp[1].Value = intBranchID;
            objp[2].Value = shiprefno;
            objp[3].Value = version;
            return ExecuteTable("SPSelQChargesnewversion", objp);
        }
        public DataTable ChargeBuyingDetailsnewversion(int buyingid, int intBranchID, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4), new SqlParameter("@version", SqlDbType.Int) };
            objp[0].Value = buyingid;
            objp[1].Value = version;
            return ExecuteTable("SPSelBChargesnewversion", objp);
        }
        public DataSet GetcombbinedQuotationrpt(int Quotationno, string trantype, int intBranchID, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),  new SqlParameter("@version",SqlDbType.Int,4)};
            objp[0].Value = Quotationno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = version;
            return ExecuteDataSet("SpGetCombinedQuotrpt", objp);
        }
        public DataTable QuotationDetailsCustqnew(string trantype, int intBranchID, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@custid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = custid;
            return ExecuteTable("SPSelGrdQuotDtlscustqnew", objp);
        }
        // yuvaraj 27/12/2022

        public DataTable GETTUESCBMVALUE(int quotno, int bid, string trantype, string stype)
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                new SqlParameter("@quotno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.TinyInt,1),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@stype",SqlDbType.VarChar,3)
                                                      };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            objp[3].Value = stype;
            return ExecuteTable("SPGETTUESCBMVALUE", objp);
        }

        public void qreuseNewdetails(int qutno, int bid, int qnew)
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                new SqlParameter("@qutno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.TinyInt,1),
                new SqlParameter("@qnew",SqlDbType.Int),
           
                                                      };
            objp[0].Value = qutno;
            objp[1].Value = bid;
            objp[2].Value = qnew;

            ExecuteQuery("qreuse", objp);
        }

        public DataSet GetQuation4salesappunapp(int salesid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@divisionid",SqlDbType.Int)
                                                  };

            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;

            return ExecuteDataSet("SPGetQuaotationDetails4appunapp", objp);
        }


        public DataTable Getquotsizetypegrid(int quotno, int bid, string trantype )
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                new SqlParameter("@quotno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.TinyInt,1),
                new SqlParameter("@trantype",SqlDbType.VarChar,2 
                 )
                                                      };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
           
            return ExecuteTable("SPGetquotsizetypegrid", objp);
        }


        public DataSet SelBChargesnew4booking(int quotno, int bid, string trantype ,string basetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                new SqlParameter("@quotno",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.TinyInt,1),
                new SqlParameter("@trantype",SqlDbType.VarChar,2 ),
                  
                    new SqlParameter("@base",SqlDbType.VarChar,10 ),
                 
                                                      };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            
            objp[3].Value = basetype;
            return ExecuteDataSet("SPSelBChargesnew4booking", objp);
        }


        public DataTable GetCustomerDetailFromTask(int customerid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{
         new SqlParameter("@customerid",SqlDbType.Int),

         new SqlParameter("@trantpe",SqlDbType.VarChar,30
          )
                                               };
            objp[0].Value = customerid;

            objp[1].Value = trantype;

            return ExecuteTable("SP_GetTaskCustomerCheck", objp);
        }

        //imquiry...

        //09/02/2024

        public int InsertInquiryHeadDetails(DateTime inquirydate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL,
         int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby,
         int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country, string Terms,
int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope
, string pieces, string noofcont, decimal grwt, string noofunits, double volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, DateTime enqno)
        {

            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@inquirydate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@Inquiryid",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1),
             new SqlParameter("@Terms",SqlDbType.VarChar,5000),
               new SqlParameter("@inco",SqlDbType.Int),
                  new SqlParameter("@shipperid",SqlDbType.Int),
                     new SqlParameter("@consigneeid",SqlDbType.Int),
                     new SqlParameter("@cuspono",SqlDbType.VarChar,50),
                     new SqlParameter("@routing",SqlDbType.VarChar,50 ),
                     new SqlParameter("@transittime",SqlDbType.VarChar,50 ),
                     new SqlParameter("@scope",SqlDbType.Int),
                     new SqlParameter("@pieces",SqlDbType.VarChar,50 ),
                       new SqlParameter("@noofcont",SqlDbType.VarChar,50 ),
              new SqlParameter("@grwt",SqlDbType.Decimal ),
                new SqlParameter("@noofunits",SqlDbType.VarChar,50 ),
                  new SqlParameter("@volume",SqlDbType.Real ),
                    new SqlParameter("@dimension",SqlDbType.VarChar,30 ),
                    new SqlParameter("@value",SqlDbType.VarChar,50 ),
                      new SqlParameter("@chrageblewt",SqlDbType.Decimal),
                       new SqlParameter("@totaldays",SqlDbType.Int),
                         new SqlParameter("@feasibility",SqlDbType.VarChar,1),
                             new SqlParameter("@enqno",SqlDbType.DateTime),
            };
            objp[0].Value = inquirydate;
            objp[1].Value = Trantype;
            objp[2].Value = custid;
            objp[3].Value = intPOR;
            objp[4].Value = intPOL;
            objp[5].Value = intPOD;
            objp[6].Value = intFD;
            objp[7].Value = stype;
            objp[8].Value = ftype;
            objp[9].Value = intCargo;
            objp[10].Value = Description;
            objp[11].Value = Validtill;
            objp[12].Value = intMarketedby;
            objp[13].Value = intPreparedby;
            objp[14].Value = hazardous;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = intBranchID;
            objp[17].Value = strRemarks;
            objp[18].Value = strBrokerage;
            objp[19].Value = buyingno;
            objp[20].Value = intDivID;
            objp[21].Value = bus;
            objp[22].Value = country;
            objp[23].Value = Terms;

            objp[24].Value = inco;
            objp[25].Value = shipperid;
            objp[26].Value = consigneeid;
            objp[27].Value = cuspono;
            objp[28].Value = routing;
            objp[29].Value = transittime;
            objp[30].Value = scope;
            objp[31].Value = pieces;
            objp[32].Value = noofcont;
            objp[33].Value = grwt;
            objp[34].Value = noofunits;    //SPInsInquiryQHead
            objp[35].Value = volume;       //SPInsGenQuotHead
            objp[36].Value = dimension;
            objp[37].Value = value;
            objp[38].Value = chrageblewt;
            objp[39].Value = totaldays;
            objp[40].Value = feasibility;
            objp[41].Value = enqno;
            return ExecuteQuery("SPInsInquiryQHead", objp, "@Inquiryid");
        }




        public void UpdateInquiryheadDetail(int quotid, DateTime validtill, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo,
          string Description, int intMarketedby, int intPreparedby, int hazardous, string Trantype, string strRemarks, string strBrokerage, int intBranchID, int buyingno, string bus,
          string country, string Terms, int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope
        , string pieces, string noofcont, decimal grwt, string noofunits, double volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, DateTime enqno)
        {
            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inquiryid",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1),
             new SqlParameter("@Terms",SqlDbType.VarChar,5000),
            new SqlParameter("@inco",SqlDbType.Int),
                  new SqlParameter("@shipperid",SqlDbType.Int),
                     new SqlParameter("@consigneeid",SqlDbType.Int),
                     new SqlParameter("@cuspono",SqlDbType.VarChar,50),
                     new SqlParameter("@routing",SqlDbType.VarChar,50 ),
                     new SqlParameter("@transittime",SqlDbType.VarChar,50 ),
                     new SqlParameter("@scope",SqlDbType.Int),
                     new SqlParameter("@pieces",SqlDbType.VarChar,50 ),
                        new SqlParameter("@noofcont",SqlDbType.VarChar,50 ),
              new SqlParameter("@grwt",SqlDbType.Decimal ),
                new SqlParameter("@noofunits",SqlDbType.VarChar,50 ),
                  new SqlParameter("@volume",SqlDbType.Real ),
                    new SqlParameter("@dimension",SqlDbType.VarChar,30 ),
                 new SqlParameter("@value",SqlDbType.VarChar,50 ),
                      new SqlParameter("@chrageblewt",SqlDbType.Decimal),
                       new SqlParameter("@totaldays",SqlDbType.Int),
                         new SqlParameter("@feasibility",SqlDbType.VarChar,10),
             new SqlParameter("@enqno",SqlDbType.DateTime),
            };
            objp[0].Value = quotid;
            objp[1].Value = custid;
            objp[2].Value = intPOR;
            objp[3].Value = intPOL;
            objp[4].Value = intPOD;
            objp[5].Value = intFD;
            objp[6].Value = stype;
            objp[7].Value = ftype;
            objp[8].Value = intCargo;
            objp[9].Value = validtill;
            objp[10].Value = intMarketedby;
            objp[11].Value = intPreparedby;
            objp[12].Value = Description;
            objp[13].Value = hazardous;
            objp[14].Value = intBranchID;
            objp[15].Value = strRemarks;
            objp[16].Value = strBrokerage;
            objp[17].Value = buyingno;
            objp[18].Value = bus;
            objp[19].Value = country;
            objp[20].Value = Terms;

            objp[21].Value = inco;
            objp[22].Value = shipperid;
            objp[23].Value = consigneeid;
            objp[24].Value = cuspono;
            objp[25].Value = routing;
            objp[26].Value = transittime;
            objp[27].Value = scope;
            objp[28].Value = pieces;
            objp[29].Value = noofcont;
            objp[30].Value = grwt;
            objp[31].Value = noofunits;
            objp[32].Value = volume;
            objp[33].Value = dimension;
            objp[34].Value = value;
            objp[35].Value = chrageblewt;
            objp[36].Value = totaldays;
            objp[37].Value = feasibility;
            objp[38].Value = enqno;
            ExecuteQuery("SPUpdQHead", objp);
        }



        public DataTable GetInquiryHeadDetails(int Inquiryid, string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inquiryid",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = Inquiryid;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPSelInquiryHead", objp); // ok yuvaraj
        }



        public DataTable ApprovalPendingDetails1(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelectInquiryApproval ", objp);
        }


        public DataTable InquiryDetailsCustqnew(string trantype, int intBranchID, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@custid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = custid;
            return ExecuteTable("SPSelGrdInquiryDtlscustqnew", objp);
        }


        public DataTable InquiryDetailsnew(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelGrdInquiryDtlsnew", objp);
        }


        public DataTable CheckInquiryForBookingFromQno(int inquiryid, string trantype, int intBranchID, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@inquiryid",SqlDbType.Int),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@type",SqlDbType.VarChar,2)};
            objp[0].Value = inquiryid;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = type;
            return ExecuteTable("SPCheckInquiryForBookingFromQNo", objp);
        }


        public DataTable GetInquiry4salesnew1(int salesid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int),
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                                                    new SqlParameter("@divisionid",SqlDbType.Int)
                                                  };

            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;

            return ExecuteTable("SPGetInquiryDetails4New1", objp);
        }


        public DataTable CheckMax2(int inquiryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inquiryid", SqlDbType.Int) };

            objp[0].Value = inquiryid;
            return ExecuteTable("SPCheckMax2", objp);

        }


        public int InsertInquiryHeadDetailsversion(DateTime Inquirydate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL,
        int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby,
        int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country, string Terms,
int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope
, string pieces, string noofcont, decimal grwt, string noofunits, decimal volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, int version, int qno, DateTime enqno)
        {

            char stype = GetShipmenttype(Shipmenttype);
            char ftype = GetFrighttype(fright);
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@inquirydate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
                                                    new SqlParameter("@inquiryid",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@business",SqlDbType.Char,1),
             new SqlParameter("@country",SqlDbType.VarChar,1),
             new SqlParameter("@Terms",SqlDbType.VarChar,5000),
               new SqlParameter("@inco",SqlDbType.Int),
                  new SqlParameter("@shipperid",SqlDbType.Int),
                     new SqlParameter("@consigneeid",SqlDbType.Int),
                     new SqlParameter("@cuspono",SqlDbType.VarChar,50),
                     new SqlParameter("@routing",SqlDbType.VarChar,50 ),
                     new SqlParameter("@transittime",SqlDbType.VarChar,50 ),
                     new SqlParameter("@scope",SqlDbType.Int),
                     new SqlParameter("@pieces",SqlDbType.VarChar,50 ),
                       new SqlParameter("@noofcont",SqlDbType.VarChar,50 ),
              new SqlParameter("@grwt",SqlDbType.Decimal ),
                new SqlParameter("@noofunits",SqlDbType.VarChar,50 ),
                  new SqlParameter("@volume",SqlDbType.Decimal ),
                    new SqlParameter("@dimension",SqlDbType.VarChar,30 ),
                    new SqlParameter("@value",SqlDbType.VarChar,50 ),
                      new SqlParameter("@chrageblewt",SqlDbType.Decimal),
                       new SqlParameter("@totaldays",SqlDbType.Int),
                         new SqlParameter("@feasibility",SqlDbType.VarChar,1),
                          new SqlParameter("@version",SqlDbType.Int,4),
                            new SqlParameter("@qno",SqlDbType.Int,4),new SqlParameter("@enqno",SqlDbType.DateTime )
            };
            objp[0].Value = Inquirydate;
            objp[1].Value = Trantype;
            objp[2].Value = custid;
            objp[3].Value = intPOR;
            objp[4].Value = intPOL;
            objp[5].Value = intPOD;
            objp[6].Value = intFD;
            objp[7].Value = stype;
            objp[8].Value = ftype;
            objp[9].Value = intCargo;
            objp[10].Value = Description;
            objp[11].Value = Validtill;
            objp[12].Value = intMarketedby;
            objp[13].Value = intPreparedby;
            objp[14].Value = hazardous;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = intBranchID;
            objp[17].Value = strRemarks;
            objp[18].Value = strBrokerage;
            objp[19].Value = buyingno;
            objp[20].Value = intDivID;
            objp[21].Value = bus;
            objp[22].Value = country;
            objp[23].Value = Terms;

            objp[24].Value = inco;
            objp[25].Value = shipperid;
            objp[26].Value = consigneeid;
            objp[27].Value = cuspono;
            objp[28].Value = routing;
            objp[29].Value = transittime;
            objp[30].Value = scope;
            objp[31].Value = pieces;
            objp[32].Value = noofcont;
            objp[33].Value = grwt;
            objp[34].Value = noofunits;
            objp[35].Value = volume;
            objp[36].Value = dimension;
            objp[37].Value = value;
            objp[38].Value = chrageblewt;
            objp[39].Value = totaldays;
            objp[40].Value = feasibility;
            objp[41].Value = version;
            objp[42].Value = qno;
            objp[43].Value = enqno;
            return ExecuteQuery("SPInsInquiryHeadversion", objp, "@inquiryid");
        }

        public void InsertChargeDetailsnewversion2(int inquiryid, int intBranchID, int intDivID, int version)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inquiryid",SqlDbType.Int,4),
                                                          new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                           new SqlParameter("@cid",SqlDbType.TinyInt,1),
                 new SqlParameter("@version",SqlDbType.Int)};
            objp[0].Value = inquiryid;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivID;
            objp[3].Value = version;
            ExecuteQuery("SPInsQDtlsnewversion", objp);
        }


        public void UpdateGrdQtyDetailsnew(int inquiryid, string strbase, string qty)
        {
            SqlParameter[] objp = new SqlParameter[] {    new SqlParameter("@inquiryid",SqlDbType.Int,4),
                                                          new SqlParameter("@base",SqlDbType.VarChar,45),
                                                          new SqlParameter("@Qty",SqlDbType.VarChar,4) };

            objp[0].Value = inquiryid;
            objp[5].Value = strbase;
            objp[7].Value = qty;
            ExecuteQuery("SPUpdQtynew", objp);
        }



        public void InsertInquiryDetailsTable(int inquiryid, string Base, string Qty)
        {

            SqlParameter[] array = new SqlParameter[3] {

    new SqlParameter("@inquiryid", SqlDbType.Int, 4),
    new SqlParameter("@base", SqlDbType.VarChar, 10),
    new SqlParameter("@Qty", SqlDbType.VarChar,10)};


            array[0].Value = inquiryid;
            array[1].Value = Base;
            array[2].Value = Qty;

            ExecuteQuery("SPInquiryDetails", array);
        }




        public void UpdateInquiryDetailsTable(int inquiryid, string Base, int Qty)
        {
            SqlParameter[] array = new SqlParameter[3]
            {
            new SqlParameter("@inquiryid", SqlDbType.Int, 4),
            new SqlParameter("@base", SqlDbType.VarChar, 10),
            new SqlParameter("@Qty", SqlDbType.Int, 4)
            };
            array[0].Value = inquiryid;
            array[1].Value = Base;
            array[2].Value = Qty;
            IDataParameter[] parameters = array;
            ExecuteQuery("SPInquiryUpdateDetails", parameters);
        }
        public DataTable GetRateId(int inquiryid)
        {
            SqlParameter[] objp = new SqlParameter[1]
               {
            new SqlParameter("@inquiryid", SqlDbType.Int, 4)};

            objp[0].Value = inquiryid;


            return ExecuteTable("SPGetRateId", objp);


        }


        //        public int InsertGenQuotDetails(DateTime inquirydate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL,
        //        int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby,
        //        int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country, string Terms,
        //int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope
        //, string pieces, string noofcont, decimal grwt, string noofunits, double volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, DateTime enqno)
        //        {

        //            char stype = GetShipmenttype(Shipmenttype);
        //            char ftype = GetFrighttype(fright);
        //            SqlParameter[] objp = new SqlParameter[] {
        //                                                     new SqlParameter("@inquirydate",SqlDbType.SmallDateTime,4),
        //                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
        //                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
        //                                                     new SqlParameter("@por",SqlDbType.Int),
        //                                                     new SqlParameter("@pol",SqlDbType.Int),
        //                                                     new SqlParameter("@pod",SqlDbType.Int),
        //                                                     new SqlParameter("@fd",SqlDbType.Int),
        //                                                     new SqlParameter("@stype",SqlDbType.VarChar,4),
        //                                                     new SqlParameter("@fstatus",SqlDbType.VarChar,1),
        //                                                     new SqlParameter("@cargoid",SqlDbType.Int),
        //                                                     new SqlParameter("@descn",SqlDbType.VarChar,50),
        //                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
        //                                                     new SqlParameter("@marketedby",SqlDbType.Int),
        //                                                     new SqlParameter("@preparedby",SqlDbType.Int),
        //                                                     new SqlParameter("@hazardous",SqlDbType.VarChar,1),
        //                                                    new SqlParameter("@quot",SqlDbType.Int,4),
        //                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
        //                                                    new SqlParameter("@remarks",SqlDbType.VarChar,4000),
        //                                                    new SqlParameter("@brokerage",SqlDbType.VarChar,25),
        //                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
        //                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
        //                                                    new SqlParameter("@business",SqlDbType.Char,1),
        //             new SqlParameter("@country",SqlDbType.VarChar,1),
        //             new SqlParameter("@Terms",SqlDbType.VarChar,5000),
        //               new SqlParameter("@inco",SqlDbType.Int),
        //                  new SqlParameter("@shipperid",SqlDbType.Int),
        //                     new SqlParameter("@consigneeid",SqlDbType.Int),
        //                     new SqlParameter("@cuspono",SqlDbType.VarChar,50),
        //                     new SqlParameter("@routing",SqlDbType.VarChar,50 ),
        //                     new SqlParameter("@transittime",SqlDbType.VarChar,50 ),
        //                     new SqlParameter("@scope",SqlDbType.Int),
        //                     new SqlParameter("@pieces",SqlDbType.VarChar,50 ),
        //                       new SqlParameter("@noofcont",SqlDbType.VarChar,50 ),
        //              new SqlParameter("@grwt",SqlDbType.Decimal ),
        //                new SqlParameter("@noofunits",SqlDbType.VarChar,50 ),
        //                  new SqlParameter("@volume",SqlDbType.Real ),
        //                    new SqlParameter("@dimension",SqlDbType.VarChar,30 ),
        //                    new SqlParameter("@value",SqlDbType.VarChar,50 ),
        //                      new SqlParameter("@chrageblewt",SqlDbType.Decimal),
        //                       new SqlParameter("@totaldays",SqlDbType.Int),
        //                         new SqlParameter("@feasibility",SqlDbType.VarChar,1),
        //                             new SqlParameter("@enqno",SqlDbType.DateTime),
        //            };
        //            objp[0].Value = inquirydate;
        //            objp[1].Value = Trantype;
        //            objp[2].Value = custid;
        //            objp[3].Value = intPOR;
        //            objp[4].Value = intPOL;
        //            objp[5].Value = intPOD;
        //            objp[6].Value = intFD;
        //            objp[7].Value = stype;
        //            objp[8].Value = ftype;
        //            objp[9].Value = intCargo;
        //            objp[10].Value = Description;
        //            objp[11].Value = Validtill;
        //            objp[12].Value = intMarketedby;
        //            objp[13].Value = intPreparedby;
        //            objp[14].Value = hazardous;
        //            objp[15].Direction = ParameterDirection.Output;
        //            objp[16].Value = intBranchID;
        //            objp[17].Value = strRemarks;
        //            objp[18].Value = strBrokerage;
        //            objp[19].Value = buyingno;
        //            objp[20].Value = intDivID;
        //            objp[21].Value = bus;
        //            objp[22].Value = country;
        //            objp[23].Value = Terms;

        //            objp[24].Value = inco;
        //            objp[25].Value = shipperid;
        //            objp[26].Value = consigneeid;
        //            objp[27].Value = cuspono;
        //            objp[28].Value = routing;
        //            objp[29].Value = transittime;
        //            objp[30].Value = scope;
        //            objp[31].Value = pieces;
        //            objp[32].Value = noofcont;
        //            objp[33].Value = grwt;
        //            objp[34].Value = noofunits;
        //            objp[35].Value = volume;
        //            objp[36].Value = dimension;
        //            objp[37].Value = value;
        //            objp[38].Value = chrageblewt;
        //            objp[39].Value = totaldays;
        //            objp[40].Value = feasibility;
        //            objp[41].Value = enqno;
        //            return ExecuteQuery("SPInsGenQuotHead", objp, "@Inquiryid");
        //        }


        public int InsertGenQuotDetails(DateTime Quotationdate, DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL, int intPOD, int intFD, string Shipmenttype, string fright, int intCargo, string Description, int intMarketedby, int intPreparedby, int hazardous, string strRemarks, string strBrokerage, int intBranchID, int buyingno, int intDivID, string bus, string country, string Terms, int inco, int shipperid, int consigneeid, string cuspono, string routing, string transittime, int scope, string pieces, string noofcont, decimal grwt, string noofunits, double volume, string dimension, string value, decimal chrageblewt, int totaldays, string feasibility, DateTime enqno)
        {
            char shipmenttype = GetShipmenttype(Shipmenttype);
            char frighttype = GetFrighttype(fright);
            SqlParameter[] array = new SqlParameter[42]
            {
            new SqlParameter("@quotdate", SqlDbType.SmallDateTime, 4),
            new SqlParameter("@trantype", SqlDbType.VarChar, 2),
            new SqlParameter("@customerid", SqlDbType.Int, 4),
            new SqlParameter("@por", SqlDbType.Int),
            new SqlParameter("@pol", SqlDbType.Int),
            new SqlParameter("@pod", SqlDbType.Int),
            new SqlParameter("@fd", SqlDbType.Int),
            new SqlParameter("@stype", SqlDbType.VarChar, 1),
            new SqlParameter("@fstatus", SqlDbType.VarChar, 1),
            new SqlParameter("@cargoid", SqlDbType.Int),
            new SqlParameter("@descn", SqlDbType.VarChar, 50),
            new SqlParameter("@validtill", SqlDbType.SmallDateTime, 4),
            new SqlParameter("@marketedby", SqlDbType.Int),
            new SqlParameter("@preparedby", SqlDbType.Int),
            new SqlParameter("@hazardous", SqlDbType.VarChar, 1),
            new SqlParameter("@quotno", SqlDbType.Int, 4),
            new SqlParameter("@bid", SqlDbType.TinyInt, 1),
            new SqlParameter("@remarks", SqlDbType.VarChar, 4000),
            new SqlParameter("@brokerage", SqlDbType.VarChar, 25),
            new SqlParameter("@buyingno", SqlDbType.Int, 4),
            new SqlParameter("@cid", SqlDbType.TinyInt, 1),
            new SqlParameter("@business", SqlDbType.Char, 1),
            new SqlParameter("@country", SqlDbType.VarChar, 1),
            new SqlParameter("@Terms", SqlDbType.VarChar, 5000),
            new SqlParameter("@inco", SqlDbType.Int),
            new SqlParameter("@shipperid", SqlDbType.Int),
            new SqlParameter("@consigneeid", SqlDbType.Int),
            new SqlParameter("@cuspono", SqlDbType.VarChar, 50),
            new SqlParameter("@routing", SqlDbType.VarChar, 50),
            new SqlParameter("@transittime", SqlDbType.VarChar, 50),
            new SqlParameter("@scope", SqlDbType.Int),
            new SqlParameter("@pieces", SqlDbType.VarChar, 50),
            new SqlParameter("@noofcont", SqlDbType.VarChar, 50),
            new SqlParameter("@grwt", SqlDbType.Decimal),
            new SqlParameter("@noofunits", SqlDbType.VarChar, 50),
            new SqlParameter("@volume", SqlDbType.Real),
            new SqlParameter("@dimension", SqlDbType.VarChar, 30),
            new SqlParameter("@value", SqlDbType.VarChar, 50),
            new SqlParameter("@chrageblewt", SqlDbType.Decimal),
            new SqlParameter("@totaldays", SqlDbType.Int),
            new SqlParameter("@feasibility", SqlDbType.VarChar, 1),
            new SqlParameter("@enqno", SqlDbType.DateTime)
            };
            array[0].Value = Quotationdate;
            array[1].Value = Trantype;
            array[2].Value = custid;
            array[3].Value = intPOR;
            array[4].Value = intPOL;
            array[5].Value = intPOD;
            array[6].Value = intFD;
            array[7].Value = shipmenttype;
            array[8].Value = frighttype;
            array[9].Value = intCargo;
            array[10].Value = Description;
            array[11].Value = Validtill;
            array[12].Value = intMarketedby;
            array[13].Value = intPreparedby;
            array[14].Value = hazardous;
            array[15].Direction = ParameterDirection.Output;
            array[16].Value = intBranchID;
            array[17].Value = strRemarks;
            array[18].Value = strBrokerage;
            array[19].Value = buyingno;
            array[20].Value = intDivID;
            array[21].Value = bus;
            array[22].Value = country;
            array[23].Value = Terms;
            array[24].Value = inco;
            array[25].Value = shipperid;
            array[26].Value = consigneeid;
            array[27].Value = cuspono;
            array[28].Value = routing;
            array[29].Value = transittime;
            array[30].Value = scope;
            array[31].Value = pieces;
            array[32].Value = noofcont;
            array[33].Value = grwt;
            array[34].Value = noofunits;
            array[35].Value = volume;
            array[36].Value = dimension;
            array[37].Value = value;
            array[38].Value = chrageblewt;
            array[39].Value = totaldays;
            array[40].Value = feasibility;
            array[41].Value = enqno;
            IDataParameter[] parameters = array;
            return ExecuteQuery("SPGenerateQuotHead", parameters, "@quotno");
        }


        public DataTable GetQuotId(int buyingno)
        {
            SqlParameter[] array = new SqlParameter[1]
            {
            new SqlParameter("@buyingno", SqlDbType.Int, 4)
            };
            array[0].Value = buyingno;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPGetQuotNo", parameters);
        }


        public DataTable ChargeInquiryDetailsnew(int Quotid, string shiprefno)
        {
            SqlParameter[] array = new SqlParameter[2]
            {
            new SqlParameter("@inquiryid", SqlDbType.Int, 4),
            new SqlParameter("@bookingno", SqlDbType.VarChar, 30)
            };
            array[0].Value = Quotid;
            array[1].Value = shiprefno;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPSelInquiryChargesnew", parameters);

        }

        public bool InsertQuotChargeDetails(int quotationid, string chargename, string curr, double rate, string Base, int intBranchID, int intDivID, double expqty, double exrate, double amount, double marginpercent, double retention, int version)
        {
            bool exist;
            int chargeid = ChargeObj.GetChargeid(chargename);
            exist = CheckChargeExist(chargeid, quotationid, Base, intBranchID);
            if (!exist)
            {
                SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                           new SqlParameter("@chargeid",SqlDbType.Int),
                                                           new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                           new SqlParameter("@rate",SqlDbType.Money,8),
                                                           new SqlParameter("@base",SqlDbType.VarChar,45),
                                                          new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                           new SqlParameter("@cid",SqlDbType.TinyInt,1),
                new SqlParameter("@expqty",SqlDbType.Real),
             new SqlParameter("@exrate",SqlDbType.Real),
             new SqlParameter("@amount",SqlDbType.Real),
             new SqlParameter("@marginpercent",SqlDbType.Real),
             new SqlParameter("@retention",SqlDbType.Real),
             new SqlParameter("@version",SqlDbType.Int,4)  };

                objp[0].Value = quotationid;
                objp[1].Value = chargeid;
                objp[2].Value = curr;
                objp[3].Value = rate;
                objp[4].Value = Base;
                objp[5].Value = intBranchID;
                objp[6].Value = intDivID;
                objp[7].Value = expqty;
                objp[8].Value = exrate;
                objp[9].Value = amount;
                objp[10].Value = marginpercent;
                objp[11].Value = retention;
                objp[12].Value = version;
                ExecuteQuery("SPInsQuotChargeDetails", objp);
                return true;
            }
            return false;
        }


        public DataTable GetQty(int Quotid)
        {
            SqlParameter[] array = new SqlParameter[]
            {
            new SqlParameter("@inquiryid", SqlDbType.Int, 4),

            };
            array[0].Value = Quotid;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPGetQty", parameters);
        }


        public DataTable CheckBuyrateForBookingFromRateId(int rateid, string trantype, int intBranchID, string type)
        {
            SqlParameter[] array = new SqlParameter[4]
            {
            new SqlParameter("@rateid", SqlDbType.Int),
            new SqlParameter("@trantype", SqlDbType.VarChar, 2),
            new SqlParameter("@bid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type", SqlDbType.VarChar, 2)
            };
            array[0].Value = rateid;
            array[1].Value = trantype;
            array[2].Value = intBranchID;
            array[3].Value = type;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPCheckBuyRateForBookingFromRateid", parameters);
        }

    }
}

