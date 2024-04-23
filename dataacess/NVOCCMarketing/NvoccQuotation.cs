using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.nvoccmarketing
{
    public class NvoccQuotation : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public NvoccQuotation()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsertQuotationDetails(DateTime Validtill, string Trantype, int custid, int intPOR, int intPOL, int intPOD, int intFD, int intCargo, int intMarketedby, int intPreparedby, string strRemarks, int buyingno, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@quotno",SqlDbType.Int,4),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                    new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                    new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = Trantype;
            objp[1].Value = custid;
            objp[2].Value = intPOR;
            objp[3].Value = intPOL;
            objp[4].Value = intPOD;
            objp[5].Value = intFD;
            objp[6].Value = intCargo;
            objp[7].Value = Validtill;
            objp[8].Value = intMarketedby;
            objp[9].Value = intPreparedby;
            objp[10].Direction = ParameterDirection.Output;
            objp[11].Value = strRemarks;
            objp[12].Value = buyingno;
            objp[13].Value = branchid;
            objp[14].Value = divisionid;
            return ExecuteQuery("SPNVInsQHead", objp, "@quotno");
        }

        public void UpdateQuotationDetails(int Qid, DateTime validtill, int custid, int intPOR, int intPOL, int intPOD, int intFD, int intCargo, int intMarketedby, int intPreparedby, string strRemarks, int buyingno, int intBranchID, int intdivisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),   
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),
                                                     new SqlParameter("@cargoid",SqlDbType.Int),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@marketedby",SqlDbType.Int),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                     new SqlParameter("@buyingno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                     new SqlParameter("@divisionid", SqlDbType.TinyInt,1) };
            objp[0].Value = Qid;
            objp[1].Value = custid;
            objp[2].Value = intPOR;
            objp[3].Value = intPOL;
            objp[4].Value = intPOD;
            objp[5].Value = intFD;
            objp[6].Value = intCargo;
            objp[7].Value = validtill;
            objp[8].Value = intMarketedby;
            objp[9].Value = intPreparedby;
            objp[10].Value = strRemarks;
            objp[11].Value = buyingno;
            objp[12].Value = intBranchID;
            objp[13].Value = intdivisionid;
            ExecuteQuery("SPNVUpdQHead", objp);
        }

        public DataTable GetQuotationDetails(int QuotationNo,string TranType,int intBid,int intCid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1) };
            objp[0].Value = QuotationNo;
            objp[1].Value = TranType;
            objp[2].Value = intBid;
            objp[3].Value = intCid;
            return ExecuteTable("SPNVSelQuotHead", objp);
        }

        public bool CheckChargeExist(int Qno, int chargeid, string cbase, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid",SqlDbType.Int),
                                                       new SqlParameter("@base",SqlDbType.VarChar,6),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = Qno;
            objp[1].Value = chargeid;
            objp[2].Value = cbase;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;
            if (ExecuteTable("SPNVSelChgidQnoBase", objp).Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public bool InsertChargeDetails(int quotationid, int chargeid, string curr, double rate, string Base, int BranchID, int DivisionID)
        {
            bool exist;
            exist = CheckChargeExist(chargeid, quotationid, Base,BranchID,DivisionID);
            if (!exist)
            {
                SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                           new SqlParameter("@chargeid",SqlDbType.Int),
                                                           new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                           new SqlParameter("@rate",SqlDbType.Money,8),
                                                           new SqlParameter("@base",SqlDbType.VarChar,4),
                                                           new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                           new SqlParameter("@divisionid",SqlDbType.TinyInt,1) };
                objp[0].Value = quotationid;
                objp[1].Value = chargeid;
                objp[2].Value = curr;
                objp[3].Value = rate;
                objp[4].Value = Base;
                objp[5].Value = BranchID;
                objp[6].Value = DivisionID;
                ExecuteQuery("SPNVInsQDtls", objp);
                return true;
            }
            return false;
        }

        public void UpdateGrdChargeDetails(int quotationno, int chargeid, string curr, double rate, string strbase, string oldbase, int BranchID, int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qno",SqlDbType.Int,4),
                                                       new SqlParameter("@chargeid",SqlDbType.Int),
                                                       new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                       new SqlParameter("@rate",SqlDbType.SmallMoney,4),
                                                       new SqlParameter("@base",SqlDbType.VarChar,4),
                                                       new SqlParameter("@oldbase",SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@divisionid",SqlDbType.TinyInt,1) };
            objp[0].Value = quotationno;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = strbase;
            objp[5].Value = oldbase;
            objp[6].Value = BranchID;
            objp[7].Value = DivisionID;
            ExecuteQuery("SPNVUpdGrdCharge", objp);
        }

        //Bind GrdCharges
        public DataTable ChargeDetails(int Quotid, string shiprefno,int branchid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotationno",SqlDbType.Int,4),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = Quotid;
            objp[1].Value = shiprefno;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;
            return ExecuteTable("SPNVSelQCharges", objp);
        }

        public DataTable CheckQuotForBookingFromQno(int quotno, string trantype, string type,int branchid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = quotno;
            objp[1].Value = trantype;
            objp[2].Value = type;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;
            return ExecuteTable("SPNVCheckQuotForBookingFromQNo", objp);
        }

        public DataTable QuotationDetails(string trantype,int branchid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPNVSelGrdQuotDtls", objp);
        }

        public DataTable ApprovalPendingDetails(string trantype, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPNVSelNonAppQuotations", objp);
        }

        public void UpdateQuotationDetailsWApp(int Qid, int intApprovedby, int BranchID, int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int,4),
                                                       new SqlParameter("@approvedby",SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = Qid;
            objp[1].Value = intApprovedby;
            objp[2].Value = BranchID;
            objp[3].Value = DivisionID;
            ExecuteQuery("SPNVUpdQHeadApp", objp);
        }

        public DataTable GetMRGDtsForQuot(int por, int pol, int pod, int fd)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@por",SqlDbType.Int),
                                                       new SqlParameter("@pol",SqlDbType.Int),
                                                       new SqlParameter("@pod",SqlDbType.Int),
                                                       new SqlParameter("@fd",SqlDbType.Int) };
            objp[0].Value = por;
            objp[1].Value = pol;
            objp[2].Value = pod;
            objp[3].Value = fd;
            return ExecuteTable("SPNIGetMRGDtsForQuot", objp);
        }
    }
}
