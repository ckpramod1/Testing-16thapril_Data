using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Accounts
{
    public class CostingDt:DBObject 
    {
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();
        DataAccess.HR.Employee empobj = new DataAccess.HR.Employee();
        DataAccess.Accounts.Invoice Invobj = new DataAccess.Accounts.Invoice();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CostingDt()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GridFillJobdtls(string strTranType,int branchid)
        {



            
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = strTranType;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetCostingdtls", objp);
        }
    
        public DataTable GetJobdtls(string strTranType, int jobno,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),      
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPCostJobdtls", objp);
        }
       
        public DataTable GetMBLCont(string mblno, string ftype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@mblno",SqlDbType.VarChar,30),        
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = mblno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            return ExecuteTable("SPMBLInvCont", objp);
        }
        public string GetInvAmount(int invoiceno, string charge, string strbase, string ftype,int vouyear,int branchid)
        {
            
            int intchargeid = 0;
            intchargeid = chrgobj.GetChargeid(charge);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),   
                                                        new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = intchargeid;
            objp[2].Value = strbase;
            objp[3].Value = ftype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            
            return ExecuteReader("SPGetInvAmountforInvno", objp);
        }
        public DataTable GetCBM2040fromJob(int jobno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetCBM2040fromJob", objp);
        }
        public int GetTotalPkgs(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),      
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return int.Parse(ExecuteReader("SPGetTotalPkgs", objp));
        }
        //raj
        public DataTable GetJobdtls4CostSheet(int jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetCostSheetdetails", objp);
        }

        public DataTable GetCountAgentOurBL4Job(int jobno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@JobNo",SqlDbType.Int,4),        
                                                      new SqlParameter("@TranType",SqlDbType.VarChar,2),
                                                      new SqlParameter("@BranchID", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetCountAgentOurBL4Job", objp);
        }
        //raj
       

        public DataTable GetLedgerWise4EDI(int vouno, int bid, int vouyear, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),        
                                                      new SqlParameter("@bid",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear", SqlDbType.Int,4),
                                                      new SqlParameter("@type", SqlDbType.VarChar,1)};
            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = type;
            return ExecuteTable("SPGetLedger4EDI", objp);
        }
        public DataTable GetLedgerWise4EDIRoundupoff(int vouno, int bid, int vouyear, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),        
                                                      new SqlParameter("@bid",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear", SqlDbType.Int,4),
                                                      new SqlParameter("@type", SqlDbType.VarChar,1)};
            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = type;
            return ExecuteTable("SPGetLedger4EDIRoundupoff", objp);
        }
    }
}
