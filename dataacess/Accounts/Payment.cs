using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class Payment : DBObject
    {
        //FIN

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Payment()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int GetCPBPNo(int branchid, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 5) };
            objp[0].Value = branchid;
            objp[1].Value = mode;
            return int.Parse(ExecuteReader("SPUpdCPBPno", objp));
        }
        
        //FIN
        public void InsPaymentCustomerDetail(int payid, int customer, double amount)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@customer",SqlDbType.Int ,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8)};
            objp[0].Value = payid;
            objp[1].Value = customer;
            objp[2].Value = amount;
            ExecuteQuery("SPInsPaymentcustomerDetails", objp);
        }
        
        //FIN
        public void InsPaymentChargeDetail(int payid, int chargeid, double amount)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@chargeid",SqlDbType.Int,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8)};
            objp[0].Value = payid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            ExecuteQuery("SPInsPaymentchargeDetails", objp);
        }
        
        //FIN
        public int GetPaymentid(int payno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int , 4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = payno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return int.Parse(ExecuteReader("SPSelPaymentid", objp));
        }
        
        //FIN
        public void InsPaymentHeadBank(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, char ACPayee, string fvrname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@status", SqlDbType.Char, 1),
                                                       new SqlParameter("@fvrname", SqlDbType.VarChar,100)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            objp[13].Value = ACPayee;
            objp[14].Value = fvrname;
            ExecuteQuery("SPInsPaymentHeadBank", objp);
        }
        //FIN
        public void InsPaymentHeadCash(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            ExecuteQuery("SPInsPaymentHeadcash", objp);
        }
        
        //FIN
        public DataTable GetPaymentHead(int payno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = payno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPaymentHead", objp);
        }
        //XML
        public DataTable GetPaymentHeadXML(int payno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = payno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPaymentHeadXML", objp);
        }

        //FIN
        public DataTable GetPaymentCust(int payid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = payid;
            return ExecuteTable("SPGetPaymentCust", objp);
        }

        //FIN
        public DataTable GetPaymentChrg(int payid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = payid;
            return ExecuteTable("SPGetPaymentChrg", objp);
        }

        //FIN
        public DataTable GetPaymentES(int payid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = payid;
            return ExecuteTable("SPGetPaymentESDtls", objp);
        }

        
        public DataTable GetPAPaymentDtls1(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetPAPaymentDtls1", objp);
        }


        //FIN
        //From CN
        public DataTable GetCN(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetCNforPayments", objp);
        }

        //FIN
        //From OSCN
        public DataTable GetOSCN(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSCNforPayment", objp);
        }

        //From Admin CN
        public DataTable GetAdminCN(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetAdmCNforPayments", objp);
        }

        
        public void UpdReceiptDeleted(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            ExecuteQuery("SPUpdReceDeleted", objp);
        }

        public void DelRecAgInv(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            ExecuteQuery("SPDelRecAgInv", objp);
        }

        public void UpdPaymentDeleted(int payid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = payid;
            ExecuteQuery("SPUpdPymtDeleted", objp);
        }

        public void DelCustChrgsPymt(int pymtid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid",SqlDbType.Int,4) };
            objp[0].Value = pymtid;
            ExecuteQuery("SPDelCustChargPymt", objp);
        }


        //------------PaymentClearance-----------------
        public DataTable GetPymtClearanceDetails(int branchid, DateTime clearedon)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            return ExecuteTable("SPGetPymtClearanceDtls", objp);
        }
        public DataTable GetPymtClearanceDetails4Bank(int branchid, DateTime clearedon, string Bankname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4), 
                                                        new SqlParameter("@bankname", SqlDbType.VarChar, 100)};
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = Bankname;
            return ExecuteTable("SPGetPymtClearanceDtls4Bank", objp);
        }

        public void UpdPymtClearanceDetails(char truefalse, DateTime clearedon, int paymentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@truefalse", SqlDbType.Char, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@paymentid", SqlDbType.Int, 4) };
            objp[0].Value = truefalse;
            objp[1].Value = clearedon;
            objp[2].Value = paymentid;
            ExecuteQuery("SPUpdPymtClearanceDtls1", objp);
        }

        //------Select Payment Head by Cheque #-----------
        public DataTable SelPymtHeadByChq(string chqno, string FormName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chqno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@form", SqlDbType.VarChar, 12) };
            objp[0].Value = chqno;
            objp[1].Value = FormName;
            return ExecuteTable("SPSelPymtHeadChq", objp);
        }

        public DataTable SelUnAppPymts(int DivisionID, string BranchName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@branchname", SqlDbType.VarChar, 15) };
            objp[0].Value = DivisionID;
            objp[1].Value = BranchName;
            return ExecuteTable("SPUnAppPymts", objp);
        }

        public void ApprovPymts(int Empid, int PaymentID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 2),
                                                       new SqlParameter("@paymentid", SqlDbType.Int, 4) };
            objp[0].Value = Empid;
            objp[1].Value = PaymentID;
            ExecuteQuery("SPApproPymts", objp);
        }

        //Reversel Entry procedure
        public void InsDNHeadforreversal(int pano, int vouyear, int branchid, int dnno, int empid, int appempid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@pano",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4)


            };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            ExecuteQuery("SPInsDNHeadforreversal", objp);
        }
        public void InsCNHeadforreversal(int invoiceno, int vouyear, int branchid, int cnno, int empid, int appempid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4)

                
            };
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            ExecuteQuery("SPInsCNHeadforreversal", objp);
        }
        public void InsCNHeadforreversalForbos(int invoiceno, int vouyear, int branchid, int cnno, int empid, int appempid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4)


            };
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            ExecuteQuery("SPInsCNHeadforreversalBos", objp);
        }


        public void InsDNTCNHeadforreversal(int dnno, int vouyear, int branchid, int cnno, int empid, int appempid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4)

                
            };
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            ExecuteQuery("SPInsCNheadcforreverse", objp);
        }
        public void InsCNTDNHeadforreversal(int cnno, int vouyear, int branchid, int dnno, int empid, int appempid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4)

                
            };
            objp[0].Value = cnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            ExecuteQuery("SPInsDNheadcforreverse", objp);
        }
        public void InsVouReversal(int branchid, string voutype, int vouno, int vouyear, string rvoutype, int rvouno, int rvouyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                new SqlParameter("@voutype",SqlDbType.VarChar,1),
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@rvoutype",SqlDbType.VarChar,1),
                new SqlParameter("@rvouno",SqlDbType.Int,4),
                new SqlParameter("@rvouyear",SqlDbType.Int),
                
            };
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            objp[2].Value = vouno;
            objp[3].Value = vouyear;
            objp[4].Value = rvoutype;
            objp[5].Value = rvouno;
            objp[6].Value = rvouyear;
            ExecuteQuery("SPInsVouReversal", objp);
        }
        public DataTable CheckVouReversal(int vouno, int branchid, string voutype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                new SqlParameter("@voutype",SqlDbType.VarChar,1),
                new SqlParameter("@vouyear",SqlDbType.Int)
               
            };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;
            return ExecuteTable("SPCheckVouReversal", objp);
        }

        public DataTable GetChqCOApprovedList(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.TinyInt,1)               
            };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetChqCOApprovedList", objp);
        }
        //nithya 1/02/2012

        /*OSPayment*/
        /////////////////ACOSPymt//////////////////////////////////////////



        public DataTable GetCN4OS(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetCNforPayments4OS", objp);
        }
        public DataTable GetOSCN4OS(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSCNforPayment4OS", objp);
        }


        public int GetOSPaymentid(int payno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int , 4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = payno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return int.Parse(ExecuteReader("SPOSSelPaymentid", objp));
        }
        public DataTable GetOSPaymentHead(int payno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = payno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetOSPaymentHead", objp);
        }
        public DataTable GetOSPaymentCust(int payid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = payid;
            return ExecuteTable("SPGetOSPaymentCust", objp);
        }
        public DataTable GetOSPaymentES(int payid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = payid;
            return ExecuteTable("SPGetOSPaymentESDtls", objp);
        }

        public void DelOSCustChrgsPymt(int pymtid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = pymtid;
            ExecuteQuery("SPDelOSCustChargPymt", objp);
        }

        public void InsOSPaymentHeadBank(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, char ACPayee, string fvrname, double payfamount, string payfcurr, double payfexrate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@status", SqlDbType.Char, 1),
                                                       new SqlParameter("@fvrname", SqlDbType.VarChar,100),
                                                       new SqlParameter("@payfamount",SqlDbType.Money,8),
                                                       new SqlParameter("@payfcurr",SqlDbType.VarChar,3),
                                                       new SqlParameter("@payfexrate",SqlDbType.Money,8)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            objp[13].Value = ACPayee;
            objp[14].Value = fvrname;
            objp[15].Value = payfamount;
            objp[16].Value = payfcurr;
            objp[17].Value = payfexrate;
            ExecuteQuery("SPInsOSPaymentHeadBank", objp);
        }
        public void InsOSPaymentCustomerDetail(int payid, int customer, double amount, double fcamt)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@customer",SqlDbType.Int ,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8),
             new SqlParameter("@fcamt",SqlDbType.Money,8)};
            objp[0].Value = payid;
            objp[1].Value = customer;
            objp[2].Value = amount;
            objp[3].Value = fcamt;
            ExecuteQuery("SPInsOSPaymentcustomerDetails", objp);
        }

        public void InsOSPaymentChargeDetail(int payid, int chargeid, double amount, double fcamt)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@chargeid",SqlDbType.Int,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8),
             new SqlParameter("@fcamt",SqlDbType.Money,8)};
            objp[0].Value = payid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            objp[3].Value = fcamt;
            ExecuteQuery("SPInsOSPaymentchargeDetails", objp);
        }



        //Manoj  OrgRefno START
        public DataTable GetHeadforOrgrefno(int branchid, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.TinyInt,1)  ,
                new SqlParameter("@voutype",SqlDbType.VarChar,10)
            };
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            return ExecuteTable("SPGetPaHeadforOrgrefno", objp);
        }


        public void UPDOrginPACN(int branchid, int vouyear, string voutype, int pano, string vendorrefno)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                        new SqlParameter("@voutype",SqlDbType.VarChar,10),
                                                        new SqlParameter("@pano",SqlDbType.Int,4),
                                                        new SqlParameter("@vendorrefno",SqlDbType.VarChar,50)};
            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = voutype;
            objp[3].Value = pano;
            objp[4].Value = vendorrefno;
            ExecuteQuery("SPUpdOrgrefforPACN", objp);
        }

        //Manoj OrgRefno END

        //nambi AC Paynemt Head add ref no

        public void InsPaymentHeadcash4RefNo(int payno, char Mode, int Branchid, int vouyr, string refno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.VarChar, 30)
                                                       };
            objp[0].Value = payno;
            objp[1].Value = Mode;
            objp[2].Value = Branchid;
            objp[3].Value = vouyr;
            objp[4].Value = refno;
            ExecuteQuery("SPInsPaymentHeadcash4RefNo", objp);
        }

        public DataTable GetCashRefNO(string refno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 1)
                                                        };
            objp[0].Value = refno;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetCashRefNO", objp);
        }
        public DataTable GetPymtClearance4Chq(int branchid, string chqno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@chqno", SqlDbType.VarChar ,30) };
            objp[0].Value = branchid;
            objp[1].Value = chqno;
            return ExecuteTable("SPGetPymtClearance4chq", objp);
        }


        //Cheque Max Amount in FA
        public bool CheckMedgerMaxMinAmt4Pmt(int ledgerid,int divid,double pmtamt,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                            new SqlParameter("@ledgerid", SqlDbType.Int ),
                                                            new SqlParameter("@divisionid", SqlDbType.Int ),
                                                            new SqlParameter("@Payamt", SqlDbType.Money ),
                                                            new SqlParameter("@dbname", SqlDbType.VarChar,15)};
            objp[0].Value = ledgerid ;
            objp[1].Value = divid ;
            objp[2].Value = pmtamt ;
            objp[3].Value = dbname ;
            string  retval = ExecuteReader("spFALedgerMaxMinAmtCheck", objp);
            if (retval =="True" )
                return true ;
            else
                return false ;
        }

        public DataTable Getcustamt(int custid, int branchid, string mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@custid", SqlDbType.Int, 4),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                    new SqlParameter("@mode", SqlDbType.NVarChar, 1),
                                                    new SqlParameter("@vouyear", SqlDbType.Int, 4)
                                                      };
            objp[0].Value = custid;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;

            return ExecuteTable("SPGetcustamt", objp);
        }

        public DataTable Getchargeamt(int charge, int branchid, string mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@charge", SqlDbType.Int, 4),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                    new SqlParameter("@mode", SqlDbType.NVarChar, 1),
                                                    new SqlParameter("@vouyear", SqlDbType.Int, 4)
                                                      };
            objp[0].Value = charge;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;

            return ExecuteTable("SPGetchargeamt", objp);
        }

        public DataTable GetOSPaymentChrg(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSPaymentChrg", objp);
        }

        public DataTable GetCN4OSLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetCNforPayments4OSLedger", objp);
        }

        public DataTable GetOSCN4OSLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSCNforPayment4OSLedger", objp);
        }

        public DataTable GetCNAdmin4OSLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetCNAdminforReceipts4OSLedger", objp);
        }


        //Fin
        public void InsOSPaymentHead4RefNo(int payno, char Mode, int Branchid, int vouyr, string refno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.VarChar, 30)
                                                       };
            objp[0].Value = payno;
            objp[1].Value = Mode;
            objp[2].Value = Branchid;
            objp[3].Value = vouyr;
            objp[4].Value = refno;
            ExecuteQuery("SPInsOSPaymentHead4RefNo", objp);
        }


        //Karthika_K

        public void upddirpay(int pid, string status)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@pid",SqlDbType.BigInt ,4),
                                                      new SqlParameter("@status",SqlDbType.Char,1)};
            objp[0].Value = pid;
            objp[1].Value = status;
            ExecuteQuery("upddirpay", objp);
        }

        //RAJA
        public DataTable CheckVouReversalfa(int vouno, int branchid, string voutype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                new SqlParameter("@voutype",SqlDbType.VarChar,1),
                new SqlParameter("@vouyear",SqlDbType.Int)

            };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;
            return ExecuteTable("SPCheckVouReversalfa", objp);
        }

        //Karthika
        public DataTable SelPymtHeadChqPymtno(string chqno, string FormName, int paymentno, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chqno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@form", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@paymentno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1)};
            objp[0].Value = chqno;
            objp[1].Value = FormName;
            objp[2].Value = paymentno;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;

            return ExecuteTable("SPSelPymtHeadChqPymtno", objp);
        }




        //GURU and MUTHURAJ

        // ***************guru******************//

        public DataSet GetCoutForAdminOtherCnDn(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@branchid", SqlDbType.Int)
            };
            objp[0].Value = bid;
            return ExecuteDataSet("SPAdminCnDnCouns", objp);
        }

        public DataTable getcreditnote_tds(int branchid, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),         
                                                                      new SqlParameter("@voutype",SqlDbType.VarChar,4),
            };
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            return ExecuteTable("SPGetPATDSCORCOUNT", objp);

        }

        public DataTable getcreditnote_opera(string type, string trantype, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@type",SqlDbType.VarChar,4),         
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                        new SqlParameter("@divid",SqlDbType.Int,4),
            };
            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;

            return ExecuteTable("SPGetChequeRequestCORCOUNT", objp);

        }

        public DataTable getbankbalance(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dbname",SqlDbType.VarChar,15),         
                                                      new SqlParameter("@branchid",SqlDbType.Int,4),
                                                   
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;


            return ExecuteTable("SPgetBankalances4home", objp);

        }

        // cashbalance

        public DataTable getcashbalance(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dbname",SqlDbType.VarChar,15),         
                                                      new SqlParameter("@branchid",SqlDbType.Int,4),
                                                   
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;


            return ExecuteTable("SPgetCashbalances4home", objp);

        }



        public DataTable getcreditnote_operation(string type, string trantype, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@type",SqlDbType.VarChar),         
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@bid",SqlDbType.Int,4),
                                                     new SqlParameter("@divid",SqlDbType.Int,4),
            };
            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;

            return ExecuteTable("SPGetChequeApprovalcount", objp);

        }

        public DataTable getDNApprovalcount(int branchid, string ftype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid ",SqlDbType.Int,4),
                                                      new SqlParameter("@ftype ",SqlDbType.VarChar),
                                                   
            };
            objp[0].Value = branchid;
            objp[1].Value = ftype;


            return ExecuteTable("SPApproveProAdmDCNCOUNT", objp);

        }

        public DataTable getpaymentrquest(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid ",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = branchid;


            return ExecuteTable("SPGetChqCOApprovedListcorpacount", objp);

        }


        //---------------------CreditControl------------------------------------------------------

        public DataTable getdsodays4creditcontrol(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid ",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = divisionid;


            return ExecuteTable("SPGetDsodays4CreditcontrolHome", objp);

        }

        //------------------------------------------------------
        public DataTable GetOutstanding4Home(int time, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@time",SqlDbType.Int),
                                                      new SqlParameter("@divisionid ",SqlDbType.Int),
                                                      
                                                   
            };
            objp[0].Value = time;
            objp[1].Value = divisionid;


            return ExecuteTable("SPGetSalesOutStaing4NewCORPORATEOUSTANDING", objp);

        }

        //---------------------------------------------------

        public DataTable GetCreditlimit4home(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid ",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = divisionid;


            return ExecuteTable("SpGetCreditlimit4home", objp);

        }

        //------------------------------------------------------


        public DataTable GetCreditRequest4home(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid ",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = divisionid;


            return ExecuteTable("SPGetCreditRequest4home", objp);

        }

        //----------------------------------------------


        public DataTable getExemptionList4Home(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid ",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = divisionid;


            return ExecuteTable("SpgetExemptionList4Home", objp);

        }

        //--------------------------------------Bank&Cash-------------------------------------//


        public DataTable GetBankBalancefordashboard(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            return ExecuteTable("SPgetBankalancesfordash", objp);
        }
        public DataTable GetCashBalancefordashboard(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            return ExecuteTable("SPgetCashbalancesfordash", objp);
        }

        //*************************************////

        public DataTable GetCreditApprovallimithome(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid ",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = divisionid;


            return ExecuteTable("sp_creditapprovallimit", objp);

        }


        public DataTable getCreditRequestHome(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = divisionid;


            return ExecuteTable("sp_creditrequest", objp);

        }


        public DataTable getExemptionlistHome(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                      
                                                   
            };
            objp[0].Value = divisionid;


            return ExecuteTable("sp_exemptionlisthome", objp);

        }



        public DataTable getoustandingcorporate(int divisionid, int time)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
              
                new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@time", SqlDbType.Int)  
            };


            objp[0].Value = divisionid;
            objp[1].Value = time;

            return ExecuteTable("SPGetSalesOutStaing4NewCORPORATE", objp);
        }



        public DataTable getOverduecorporate( int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
               
                new SqlParameter("@divisionid", SqlDbType.Int),
                
               
            };


            objp[0].Value = divisionid;






            return ExecuteTable("sp_overduehomecorcount", objp);
        }
        public DataTable getOverduecorporatebar(int empid, int branchid, int divisionid, int subgroupid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
                new SqlParameter("@empid", SqlDbType.Int),     
                new SqlParameter("@branchid", SqlDbType.Int) ,
                new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@subgroupid", SqlDbType.Int),  
                new SqlParameter("@trantype", SqlDbType.VarChar),   
               
            };


            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = trantype;


            return ExecuteTable("SP_CorpOverdue4HomeCountbar", objp);
        }
        public DataTable getOverduecorporatebaroverdue(int divisionid, int time)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
               
                new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@time", SqlDbType.Int),  
                
               
            };


            objp[0].Value = divisionid;
            objp[1].Value = time;



            return ExecuteTable("sp_overduehomecor", objp);
        }

        public DataTable getExemptionlistHomeline(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                      
                                                      
                                                   
            };
            objp[0].Value = divisionid;
           


            return ExecuteTable("sp_bankpaymentline", objp);

        }


        //Guru

        public DataSet GetBudetVsActual4Home(int did)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@division", SqlDbType.Int)
            };
            objp[0].Value = did;
            return ExecuteDataSet("SPgetBudetVsActual4Home", objp);
        }

        //karthika


        public DataTable SelPymtHeadPymtno(string FormName, int paymentno, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@form", SqlDbType.VarChar, 12),
                                                       new SqlParameter("@paymentno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1)};
            objp[0].Value = FormName;
            objp[1].Value = paymentno;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;

            return ExecuteTable("SPSelPymtHeadPymtno", objp);
        }

        //GST

        public DataTable sp_debitnoteadmin(int dnno, int vouyear, int branchid, string type, string formname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar,10)};
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            if (formname == "Profoma")
            {
                return ExecuteTable("sp_prodebitnoteadmin", objp);
            }
            else
            {
                return ExecuteTable("sp_debitnoteadmin", objp);
            }

        }

        //nambi //Dinesh

        public int InsProVou4Reversal(int branchid, string voutype, int vouno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                new SqlParameter("@voutype",SqlDbType.VarChar,1),
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@refno",SqlDbType.Int,4),
               
            };
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            objp[2].Value = vouno;
            objp[3].Value = vouyear;
            objp[4].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsProVou4Reversal", objp, "@refno");

        }
        //FA

        public DataTable Getchequedetails(string type, int branchid, DateTime voudate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@type",SqlDbType.VarChar,4),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@voudate",SqlDbType.SmallDateTime)
            };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = voudate;
            return ExecuteTable("SPGetChequeUnclear", objp);
        }


        public DataTable GetOSPymtClearanceDetails4BRS(int branchid, DateTime Voudate, string BankName, string curtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@voudate", SqlDbType.SmallDateTime, 4) ,
                                                       new SqlParameter("@BankName", SqlDbType.NVarChar, 100),
                                                        new SqlParameter("@curtype", SqlDbType.NVarChar, 10)};
            objp[0].Value = branchid;
            objp[1].Value = Voudate;
            objp[2].Value = BankName;
            objp[3].Value = curtype;
            return ExecuteTable("SPGetOSPymtClearanceDtls4BRS", objp);
        }


        public DataTable Getchequedetails(string type, int branchid, DateTime voudate, string BankName)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@type",SqlDbType.VarChar,4),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@voudate",SqlDbType.SmallDateTime),
                new SqlParameter("@BankName",SqlDbType.VarChar,150)
            };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = voudate;
            objp[3].Value = BankName;
            return ExecuteTable("SPGetChequeUnclear", objp);
        }

        public void DelTempBRS(int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                         new SqlParameter("@dbname", SqlDbType.VarChar ,15)};
            objp[0].Value = empid;
            objp[1].Value = dbname;
            ExecuteQuery("DelTempBRS", objp);
        }



        public void InsTempBRS(int empid, string dbname, string bankname, string paymenttype, string chequeno, DateTime chequedate, string bankbranch, double amount, string paytype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar ,15),
                                                      new SqlParameter("@bankname", SqlDbType.VarChar ,500),
                                                      new SqlParameter("@paymenttype", SqlDbType.VarChar,150),
                                                      new SqlParameter("@chequeno",SqlDbType.VarChar ,50),
                                                      new SqlParameter("@chequedate", SqlDbType.DateTime),
                                                      new SqlParameter("@bankbranch",SqlDbType.VarChar,350),
                                                      new SqlParameter("@amount", SqlDbType.Money),
                                                      new SqlParameter("@paytype",SqlDbType.Char),
                                                      new SqlParameter("@branchid",SqlDbType.Int)};
            objp[0].Value = empid;
            objp[1].Value = dbname;
            objp[2].Value = bankname;
            objp[3].Value = paymenttype;
            objp[4].Value = chequeno;
            objp[5].Value = chequedate;
            objp[6].Value = bankbranch;
            objp[7].Value = amount;
            objp[8].Value = paytype;
            objp[9].Value = branchid;
            ExecuteQuery("InsTempBRS", objp);
        }

        public void InsTempBRS(int empid, string dbname, string bankname, string paymenttype, string chequeno, DateTime chequedate, string bankbranch, double amount, string paytype, int branchid, string customername, string BranchName)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar ,15),
                                                      new SqlParameter("@bankname", SqlDbType.VarChar ,500),
                                                      new SqlParameter("@paymenttype", SqlDbType.VarChar,150),
                                                      new SqlParameter("@chequeno",SqlDbType.VarChar ,50),
                                                      new SqlParameter("@chequedate", SqlDbType.DateTime),
                                                      new SqlParameter("@bankbranch",SqlDbType.VarChar,350),
                                                      new SqlParameter("@amount", SqlDbType.Money),
                                                      new SqlParameter("@paytype",SqlDbType.Char),
                                                      new SqlParameter("@branchid",SqlDbType.Int)
                                                      ,new SqlParameter("@Customername",SqlDbType.VarChar,300)
                                                      ,new SqlParameter("@Branchname",SqlDbType.VarChar,30)};
            objp[0].Value = empid;
            objp[1].Value = dbname;
            objp[2].Value = bankname;
            objp[3].Value = paymenttype;
            objp[4].Value = chequeno;
            objp[5].Value = chequedate;
            objp[6].Value = bankbranch;
            objp[7].Value = amount;
            objp[8].Value = paytype;
            objp[9].Value = branchid;
            objp[10].Value = customername;
            objp[11].Value = BranchName;
            ExecuteQuery("InsTempBRS", objp);
        }

        //Cheque MIN/Max Amount in CONTRA
        public string CheckMedgerMaxMinAmtchk4Conta(int ledgerid, int divid, double pmtamt, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                            new SqlParameter("@ledgerid", SqlDbType.Int ),
                                                            new SqlParameter("@divisionid", SqlDbType.Int ),
                                                            new SqlParameter("@Payamt", SqlDbType.Money ),
                                                            new SqlParameter("@dbname", SqlDbType.VarChar,15)};
            objp[0].Value = ledgerid;
            objp[1].Value = divid;
            objp[2].Value = pmtamt;
            objp[3].Value = dbname;
            string retval = ExecuteReader("spFALedgerMaxMinAmtCheck4contra", objp);
            return retval;
        }

        public bool CheckMedgerMaxMinAmtchk4Contastep2(int ledgerid, int divid, double pmtamt, string dbname, string Ltype, string retult1)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                            new SqlParameter("@ledgerid", SqlDbType.Int ),
                                                            new SqlParameter("@divisionid", SqlDbType.Int ),
                                                            new SqlParameter("@Payamt", SqlDbType.Money ),
                                                            new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                            new SqlParameter("@ltype", SqlDbType.VarChar,2),
                                                            new SqlParameter("@result1", SqlDbType.VarChar,2)};
            objp[0].Value = ledgerid;
            objp[1].Value = divid;
            objp[2].Value = pmtamt;
            objp[3].Value = dbname;
            objp[4].Value = Ltype;
            objp[5].Value = retult1;
            string retval = ExecuteReader("spFALedgerMaxMinAmtCheck4contraStep2", objp);
            if (retval == "True")
                return true;
            else
                return false;
        }

        public void UpdOSPymtClearanceDetails(char truefalse, DateTime clearedon, int paymentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@truefalse", SqlDbType.Char, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@paymentid", SqlDbType.Int, 4) };
            objp[0].Value = truefalse;
            objp[1].Value = clearedon;
            objp[2].Value = paymentid;
            ExecuteQuery("SPUpdOSPymtClearanceDtls1", objp);
        }



        //--------New Payment Clearance Karthika_K

        public DataTable GetPymtClearanceDetails(int branchid, DateTime clearedon, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4)
                                                    ,new SqlParameter("@datetype", SqlDbType.NVarChar, 5)};
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = datetype;
            return ExecuteTable("SPGetPymtClearanceDtls", objp);
        }

        public DataTable GetOSPymtClearanceDetails(int branchid, DateTime clearedon, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4) ,
                                                       new SqlParameter("@datetype", SqlDbType.NVarChar, 5)};
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = datetype;
            return ExecuteTable("SPGetOSPymtClearanceDtls", objp);
        }



        public DataTable GetPymtClearanceDetails4Bank(int branchid, DateTime clearedon, string Bankname, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4), 
                                                        new SqlParameter("@bankname", SqlDbType.VarChar, 100)
                                                        ,new SqlParameter("@datetype", SqlDbType.NVarChar, 5)};
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = Bankname;
            objp[3].Value = datetype;
            return ExecuteTable("SPGetPymtClearanceDtls4Bank", objp);
        }

        public DataTable GetOSPymtClearanceDetails4Bank(int branchid, DateTime clearedon, string Bankname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4), 
                                                        new SqlParameter("@bankname", SqlDbType.VarChar, 100)};
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = Bankname;
            return ExecuteTable("SPGetOSPymtClearanceDtls4Bank", objp);
        }

        public DataTable GetTOTOSPymtClearanceDetails4BRS(int branchid, DateTime Voudate, string BankName, string curtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@voudate", SqlDbType.SmallDateTime, 4) ,
                                                       new SqlParameter("@BankName", SqlDbType.NVarChar, 100),
                                                        new SqlParameter("@curtype", SqlDbType.NVarChar, 10)};
            objp[0].Value = branchid;
            objp[1].Value = Voudate;
            objp[2].Value = BankName;
            objp[3].Value = curtype;
            return ExecuteTable("SPGetTOTOSPymtClearanceDtls4BRS", objp);
        }

        public DataTable sp_receipt(int divisionid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fromclearedon", SqlDbType .DateTime) ,
                                                       new SqlParameter("@toclearedon", SqlDbType.DateTime) 
                                        };
            objp[0].Value = divisionid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("sp_receipt", objp);
        }

        public DataTable sp_payments(int divisionid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fromclearedon", SqlDbType .DateTime) ,
                                                       new SqlParameter("@toclearedon", SqlDbType.DateTime) 
                                        };
            objp[0].Value = divisionid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("sp_payments", objp);
        }

        public DataTable sp_osreceipt(int divisionid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fromclearedon", SqlDbType .DateTime) ,
                                                       new SqlParameter("@toclearedon", SqlDbType.DateTime) 
                                        };
            objp[0].Value = divisionid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("sp_osreceipt", objp);
        }

        public DataTable sp_ospayments(int divisionid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fromclearedon", SqlDbType .DateTime) ,
                                                       new SqlParameter("@toclearedon", SqlDbType.DateTime) 
                                        };
            objp[0].Value = divisionid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("sp_ospayments", objp);
        }

        public DataTable spreceiptchecquebounce(int branchid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fromreceiptdate", SqlDbType .DateTime) ,
                                                       new SqlParameter("@toreceiptdate", SqlDbType.DateTime) 
                                        };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("spreceiptchecquebounce", objp);
        }


        public DataTable sp_contra(DateTime fromdate, DateTime todate, int divisionid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@from", SqlDbType.DateTime),
                                                       new SqlParameter("@to", SqlDbType .DateTime) ,
                                                       new SqlParameter("@divisionid", SqlDbType.Int,1),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar,50) 
                                        };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = divisionid;
            objp[3].Value = dbname;


            return ExecuteTable("sp_contra", objp);
        }


        public DataTable SP_PAYMENTCANCEL(int branchid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@frompaymentdate", SqlDbType .DateTime) ,
                                                       new SqlParameter("@topaymentdate", SqlDbType.DateTime) 
                                        };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SP_PAYMENTCANCEL", objp);
        }
        public void InsPaymentHeadBanknew(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, char ACPayee, string fvrname, string neft)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@status", SqlDbType.Char, 1),
                                                       new SqlParameter("@fvrname", SqlDbType.VarChar,100),
                                                       new SqlParameter("@neft", SqlDbType.VarChar,2)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            objp[13].Value = ACPayee;
            objp[14].Value = fvrname;
            objp[15].Value = neft;
            ExecuteQuery("SPInsPaymentHeadBanknew", objp);
        }

        //Lawrence
        public void InsVouReversalNew(int chargeid, string chargename, string curr, double rate, double exrate, string Base, double amount, double gst, 
            double net, double RevRate, double RevAmt, double RevGst, double RevNet, double DiffAmt, double DiffGst, double DiffNet, double percentage,
            char voutype, int vouno, int vouyear, int branchid, double fcamount, double unit, double DiffRevRate, double DiffFcamt, string blno, 
            int jobno, string trantype, char Rvoutype, int Rvouno, int Rvouyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@chargeid",SqlDbType.Int),
                new SqlParameter("@chargename",SqlDbType.VarChar,50),
                new SqlParameter("@curr",SqlDbType.VarChar,5),
                new SqlParameter("@rate",SqlDbType.Money,5),
                new SqlParameter("@exrate",SqlDbType.Money,4),
                new SqlParameter("@Base",SqlDbType.VarChar,10),
                new SqlParameter("@amount",SqlDbType.Money),
                new SqlParameter("@gst",SqlDbType.Money),
                new SqlParameter("@net",SqlDbType.Money),
                new SqlParameter("@RevRate",SqlDbType.Money),
                new SqlParameter("@RevAmt",SqlDbType.Money),
                new SqlParameter("@RevGst",SqlDbType.Money),
                new SqlParameter("@RevNet",SqlDbType.Money),
                new SqlParameter("@DiffAmt",SqlDbType.Money),
                new SqlParameter("@DiffGst",SqlDbType.Money),
                new SqlParameter("@DiffNet",SqlDbType.Money),
                new SqlParameter("@percentage",SqlDbType.Money),
                new SqlParameter("@voutype",SqlDbType.Char,1),
                new SqlParameter("@vouno",SqlDbType.Int,2),
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@fcamount",SqlDbType.Money),
                new SqlParameter("@unit",SqlDbType.Money),
                new SqlParameter("@DiffRevRate",SqlDbType.Money),
                new SqlParameter("@DiffFcamt",SqlDbType.Money),
                new SqlParameter("@blno",SqlDbType.VarChar,30),
                new SqlParameter("@jobno",SqlDbType.Int,4),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@rvoutype",SqlDbType.Char,1),
                new SqlParameter("@rvouno",SqlDbType.Int,2),
                new SqlParameter("@rvouyear",SqlDbType.Int)
            };
            objp[0].Value = chargeid;
            objp[1].Value = chargename;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = exrate;
            objp[5].Value = Base;
            objp[6].Value = amount;
            objp[7].Value = gst;
            objp[8].Value = net;
            objp[9].Value = RevRate;
            objp[10].Value = RevAmt;
            objp[11].Value = RevGst;
            objp[12].Value = RevNet;
            objp[13].Value = DiffAmt;
            objp[14].Value = DiffGst;
            objp[15].Value = DiffNet;
            objp[16].Value = percentage;
            objp[17].Value = voutype;
            objp[18].Value = vouno;
            objp[19].Value = vouyear;
            objp[20].Value = branchid;
            objp[21].Value = fcamount;
            objp[22].Value = unit;
            objp[23].Value = DiffRevRate;
            objp[24].Value = DiffFcamt;
            objp[25].Value = blno;
            objp[26].Value = jobno;
            objp[27].Value = trantype;
            objp[28].Value = Rvoutype;
            objp[29].Value = Rvouno;
            objp[30].Value = Rvouyear;
            ExecuteQuery("SPInsVouReversalNew1", objp);
        }

        public void InsDNHeadforreversalnew(int pano, int vouyear, int branchid, int dnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@pano",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),//,
                //new SqlParameter("@chargid",SqlDbType.Int,4),
                //new SqlParameter("@Base",SqlDbType.VarChar,4),
                //new SqlParameter("@Amount",SqlDbType.Money,8),
                //new SqlParameter("@Diff",SqlDbType.Money, 8)
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)


            };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            //objp[6].Value = chargid;
            //objp[7].Value = Base;
            //objp[8].Value = Amount;
            //objp[9].Value = Diff;
            ExecuteQuery("SPInsDNHeadforreversalrev", objp);
        }

        public void InsCNHeadforreversalnew(int invoiceno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsCNHeadforreversalrev", objp);
        }

        public void InsCNHeadforreversalnewBOS(int invoiceno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsCNHeadforreversalrevBOS", objp);
        }

        public void InsPaymentHeadCash(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby, string vis)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@vis", SqlDbType.VarChar,1)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            objp[9].Value = vis;
            ExecuteQuery("SPInsPaymentHeadcash", objp);
        } 
//FIN
        public DataTable GetPaymentCust4FA(int payid, string rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
              new SqlParameter("@rptype", SqlDbType.VarChar , 2) };
            objp[0].Value = payid;
          objp[1].Value = rptype;
            return ExecuteTable("SPGetRecptCust4FA", objp);
        }
        public DataTable GetPaymentCust4FANEW(int payid, string rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
              new SqlParameter("@rptype", SqlDbType.VarChar , 2) };
            objp[0].Value = payid;
            objp[1].Value = rptype;
            return ExecuteTable("SPGetRecptCust4FANEW", objp);
        }
        public DataTable SP_PAYMENTCANCEL(int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@frompaymentdate", SqlDbType .DateTime) ,
                                                       new SqlParameter("@topaymentdate", SqlDbType.DateTime) ,
                                                       new SqlParameter("@divsionid", SqlDbType.Int)
                                        };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = divisionid;
            return ExecuteTable("SP_PAYMENTCANCEL", objp);
        }




        public void InsCNHeadforreversalnewOSDN(int dnno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsCNHeadforreversalrevOSDN", objp);
        }

        public void InsCNHeadforreversalnewOSCN(int cnno, int vouyear, int branchid, int dnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = cnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsDNHeadforreversalrevOSCN", objp);
        }

        public void InsDNHeadforreversalnewCN(int cnno, int vouyear, int branchid, int dnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = cnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsDNHeadforreversalrevCN", objp);
        }

        public void InsCNHeadforreversalnewDN(int dnno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsCNHeadforreversalrevDN", objp);
        }

        public void InsDNHeadforreversalnewACN(int cnno, int vouyear, int branchid, int dnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = cnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsDNHeadforreversalrevACN", objp);
        }

        public void InsCNHeadforreversalnewADN(int dnno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsCNHeadforreversalrevADN", objp);
        }

        public void InsCNHeadforreversalnewADNlv(int dnno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed,string vtype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2),
                new SqlParameter("@vtype",SqlDbType.VarChar ,50)
                
            };
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            objp[8].Value = vtype;
            ExecuteQuery("SPInsCNHeadforreversalrevADN_lv", objp);
        }
        
        public void InsPaymentHeadBanknew(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, char ACPayee, string fvrname, string neft, string vis)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@status", SqlDbType.Char, 1),
                                                       new SqlParameter("@fvrname", SqlDbType.VarChar,100),
                                                       new SqlParameter("@neft", SqlDbType.VarChar,2),
                                                       new SqlParameter("@vis", SqlDbType.VarChar,1)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            objp[13].Value = ACPayee;
            objp[14].Value = fvrname;
            objp[15].Value = neft;
            objp[16].Value = vis;
            ExecuteQuery("SPInsPaymentHeadBanknew", objp);
        }
        //payment
        public DataTable SPTallyJournal(int vouno, int branchid, int month, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@month", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar,50)
                                        };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = month;
            objp[3].Value = dbname;
            return ExecuteTable("SPTallyJournal", objp);
        }

        //FIN
        public DataTable GetPaymentCustnew(int payid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = payid;
            return ExecuteTable("SPGetPaymentCustcorrraj", objp);
        }

        //New
        public void InsOSPaymentHeadBankBackdate(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, char ACPayee, string fvrname, double payfamount, string payfcurr, double payfexrate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@status", SqlDbType.Char, 1),
                                                       new SqlParameter("@fvrname", SqlDbType.VarChar,100),
                                                       new SqlParameter("@payfamount",SqlDbType.Money,8),
                                                       new SqlParameter("@payfcurr",SqlDbType.VarChar,3),
                                                       new SqlParameter("@payfexrate",SqlDbType.Money,8)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            objp[13].Value = ACPayee;
            objp[14].Value = fvrname;
            objp[15].Value = payfamount;
            objp[16].Value = payfcurr;
            objp[17].Value = payfexrate;
            ExecuteQuery("SPInsOSPaymentHeadBankBackdate", objp);
        }
        public DataTable CheckVouReversalExistorNot(int vouno, int branchid, string voutype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                new SqlParameter("@voutype",SqlDbType.VarChar,1),
                new SqlParameter("@vouyear",SqlDbType.Int)
               
            };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;
            return ExecuteTable("SPCheckVouReversalCHeck", objp);
        }

        //NewOne       //08/08/2022
        public DataTable GetPAPaymentDtls1NewOne(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetPAPaymentDtls1NewOne", objp);
        }

        //From CN       //NewOne       //08/08/2022
        public DataTable GetCNNewOne(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetCNforPaymentsNewOne", objp);
        }

        //From Admin CN     //NewOne       //08/08/2022
        public DataTable GetAdminCNNewOne(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetAdmCNforPaymentsNewOne", objp);
        }

        //From OSCN     //NewOne       //08/08/2022
        public DataTable GetOSCNNewOne(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSCNforPaymentNewOne", objp);
        }

        ////////////////////////////

        public void InsPaymentHeadCash_new(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            ExecuteQuery("SPInsPaymentHeadcash_new", objp);
        }
        public void InsPaymentHeadCash(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby, string fcurr, double fcamt, double exrate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@fcurr", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@fcamt", SqlDbType.Money),
                                                       new SqlParameter("@exrate", SqlDbType.Money) };
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            objp[9].Value = fcurr;
            objp[10].Value = fcamt;
            objp[11].Value = exrate;
            ExecuteQuery("SPInsPaymentHeadcashNewRP_new", objp);
        }
        public DataTable GetPAPaymentDtls1sing_newFC(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            //return ExecuteTable("SPGetPAPaymentDtls1sing", objp);
            return ExecuteTable("SPGetPAPaymentDtls1sing_testSKFC", objp);
        }
        public DataTable GetPAPaymentDtls1_newFC(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetPAPaymentDtls1", objp);
            return ExecuteTable("SPGetPAPaymentDtls1_testSKFC", objp);
        }

        public DataTable GetPAPaymentDtls1sing_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            //return ExecuteTable("SPGetPAPaymentDtls1sing", objp);
            return ExecuteTable("SPGetPAPaymentDtls1sing_testSK", objp);
        }

        public DataTable GetPAPaymentDtls1_new(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetPAPaymentDtls1", objp);
            return ExecuteTable("SPGetPAPaymentDtls1_testSK", objp);
        }
        public DataTable GetCNsing_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                         new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            //return ExecuteTable("SPGetCNforPaymentssing", objp);
            return ExecuteTable("SPGetCNforPaymentssing_testSK", objp);
        }

        public DataTable GetCN_new(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetCNforPayments", objp);
            return ExecuteTable("SPGetCNforPayments_testSK", objp);
        }
        public DataTable GetadminCNforPaymentssing_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;


            return ExecuteTable("SPGetadminCNforPaymentssing_testSK", objp);
        }

        public DataTable GetAdminCN_new(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetAdmCNforPayments", objp);
            return ExecuteTable("SPGetAdmCNforPayments_testSK", objp);
        }
        public void InsPaymentChargeDetail(int payid, int chargeid, double amount, string exchrge)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@rid",SqlDbType.Int ,4),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@faexgl",SqlDbType.VarChar,3)
                                                     };
            objp[0].Value = payid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            objp[3].Value = exchrge;

            ExecuteQuery("SPInsPaymentchargeDetails_new", objp);
        }
        public void InsPaymentHeadBank(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, char ACPayee, string fvrname, string fcurr, double fcamt, double exrate, string neft)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 350),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@status", SqlDbType.Char, 1),
                                                       new SqlParameter("@fvrname", SqlDbType.VarChar,100),
                                                       new SqlParameter("@fcurr", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@fcamt", SqlDbType.Money),
                                                       new SqlParameter("@exrate", SqlDbType.Money),
            new SqlParameter("@neft",SqlDbType.VarChar,2)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            objp[13].Value = ACPayee;
            objp[14].Value = fvrname;
            objp[15].Value = fcurr;
            objp[16].Value = fcamt;
            objp[17].Value = exrate;
            objp[18].Value = neft;
            ExecuteQuery("SPInsPaymentHeadBankNewRP_new1", objp);
        }

        ////////////////////////////
        //new


        public void InsCNHeadforreversalnewFC(int invoiceno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)
                
            };
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            ExecuteQuery("SPInsCNHeadforreversalrevFC", objp);
        }

        public void InsDNHeadforreversalnewFC(int pano, int vouyear, int branchid, int dnno, int empid, int appempid, string revise, string Afterjobclosed)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@pano",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@dnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),//,
                //new SqlParameter("@chargid",SqlDbType.Int,4),
                //new SqlParameter("@Base",SqlDbType.VarChar,4),
                //new SqlParameter("@Amount",SqlDbType.Money,8),
                //new SqlParameter("@Diff",SqlDbType.Money, 8)
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2)


            };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            //objp[6].Value = chargid;
            //objp[7].Value = Base;
            //objp[8].Value = Amount;
            //objp[9].Value = Diff;
            ExecuteQuery("SPInsDNHeadforreversalrevFC", objp);
        }

        public DataTable sp_debitnoteadminvouchers(int dnno, int vouyear, int branchid, int type, string formname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.Int)};
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            if (formname == "Profoma")
            {
                return ExecuteTable("sp_prodebitnoteadminvouchers", objp);
            }
            else
            {
                return ExecuteTable("sp_debitnoteadminCOM", objp);
            }

        }

        public void InsCNHeadforreversalnewlv(int invoiceno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed,string vtype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2),
                new SqlParameter("@vtype",SqlDbType.VarChar ,50)
                
            };
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            objp[8].Value = vtype;
            ExecuteQuery("SPInsCNHeadforreversalrevlv", objp);
        }
        public void InsCNHeadforreversalnewOSDNlv(int dnno, int vouyear, int branchid, int cnno, int empid, int appempid, string revise, string Afterjobclosed, string vtype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouno",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@cnno",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@appempid",SqlDbType.Int,4),
                new SqlParameter("@revise",SqlDbType.VarChar ,2),
                new SqlParameter("@Afterjobclosed",SqlDbType.VarChar ,2),
                new SqlParameter("@vtype",SqlDbType.VarChar ,50)
                
            };
            objp[0].Value = dnno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = cnno;
            objp[4].Value = empid;
            objp[5].Value = appempid;
            objp[6].Value = revise;
            objp[7].Value = Afterjobclosed;
            objp[8].Value = vtype;

            ExecuteQuery("SPInsCNHeadforreversalrevOSSIlv", objp);
        }
    }
}
