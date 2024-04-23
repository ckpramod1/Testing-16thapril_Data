using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class Recipts : DBObject
    {
        //----------To Add Vouc directly into RecAgnVouch------------------------------------------------


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Recipts()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetUnRecVouch(int branch, int month)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@month", SqlDbType.TinyInt, 1) };
            objp[0].Value = branch;
            objp[1].Value = month;
            return ExecuteTable("SPTempToAddRecepAgnVouc", objp);
        }

        public void InsPendingVoucher(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1) };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            ExecuteQuery("SPTempInsPendingVouch", objp);
        }
        //---------------------------------------------------------------------------------------------------

        public DataTable GetLikeBankName(string bankname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bname", SqlDbType.VarChar, 50) };
            objp[0].Value = bankname;
            return ExecuteTable("SPBanknamelike", objp);
        }
        public DataTable GetLikeBankName(string bankname,string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bname", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@type", SqlDbType.VarChar, 2) };
            objp[0].Value = bankname;
            objp[1].Value = type;
            return ExecuteTable("SPBanknamelike", objp);
        }

        public DataTable GetLikeReceiptCustomer(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeReceiptCustomer", objp);
        }

        public int GetCRBRNo(int branchid, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 5) };
            objp[0].Value = branchid;
            objp[1].Value = mode;
            return int.Parse(ExecuteReader("SPUpdCRBRno", objp));
        }
        public void InsReciptCustomerDetail(int rid,int customer,double amount)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@customer",SqlDbType.Int ,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8)};
            objp[0].Value =rid ;
            objp[1].Value =customer ;
            objp[2].Value =amount ;
            ExecuteQuery("SPInsReciptCustomerDetails", objp);
        }
        public void InsReciptChargeDetail(int rid, int chargeid, double amount)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@chargeid",SqlDbType.Int,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8)};
            objp[0].Value = rid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            ExecuteQuery("SPInsReciptChargeDetails", objp);
        }
        public int GetRecrid(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int , 4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return int.Parse(ExecuteReader("SPSelReciptrid", objp));
        }

        public int GetBankid(string bname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bname", SqlDbType.VarChar, 100) };
            objp[0].Value =bname;
            return int.Parse(ExecuteReader("SPSelBankid", objp));
        }

        public void InsRecptHeadBank(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby)
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
                                                       new SqlParameter("@preparedby", SqlDbType.Int) };
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
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
            ExecuteQuery("SPInsReciptHeadBank", objp);
        }

        public void InsRecptHeadCash(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby)
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
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            ExecuteQuery("SPInsReciptHeadcash", objp);
        }
       
        public string GetBankName(int bankid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankid", SqlDbType.Int) };
            objp[0].Value = bankid;
            return ExecuteReader("SPSelBankname", objp);
        }

        public DataTable GetRecptHead(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetRecptHead", objp);
        }

        public DataTable GetRecptCust(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetRecptCust", objp);
        }

        public DataTable GetRecptChrg(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetRecptChrg", objp);
        }

        public DataTable GetRecptChrgNEW(int rid, int branchid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@custid", SqlDbType.Int, 4)};
            objp[0].Value = rid;
            objp[1].Value = branchid;
            objp[2].Value = customerid;
            return ExecuteTable("SPGetRecptChrgNEW1", objp);
        }

        public DataTable GetES(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetESDtls", objp);
        }


        public void InsRecptAginstInv(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int) };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            ExecuteQuery("SPInsReciptAgInv", objp);
        }

        public void UpdRecptToCreditAmt(int tranid,int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4)};
            objp[0].Value = tranid;
            objp[1].Value = customerid;
            ExecuteQuery("SPUpdReceiptToCreditAmt", objp);
        }

        //From 'From ReceiptAgainstInvoice(If the Receipt amount is not setteled)
        public DataTable GetInvRecptDtls(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPRecPaymCalc", objp);//SPGetInvRecptDtls  SPRecPaymCalc4adj
        }

        //From Invoice
        public DataTable GetInvRecptDtls1(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetInvRecptDtls1", objp);
        }

        //From DN
        public DataTable GetDN(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetDNforReceipts", objp);
        }

        //From OSDN
        public DataTable GetOSDN(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSDNforReceipt", objp);
        }

        //From Admin DN
        public DataTable GetAdminDN(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetAdmDNforReceipts", objp);
        }

        public bool CheckChequeNo(string chqno, int bankid, char rptype)
        {
            bool existance;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chqno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@bank", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1) };
            objp[0].Value = chqno;
            objp[1].Value = bankid;
            objp[2].Value = rptype;
            Dt = ExecuteTable("SPCheckChequeNo", objp);
            if (Dt.Rows.Count > 0)
                existance = true;
            else
                existance = false;

            return existance;
        }
        
        public DataTable GetRAInvoiceToShow(int tranid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            return ExecuteTable("SPGetRecpAgnsInv", objp);
        }

        public DataTable GetRAInvoiceToShowWithCustomer(int tranid, char rptype, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = customerid;
            return ExecuteTable("SPGetRecpAgnsInvWithCustomer", objp);
        }

        public DataTable GetRAInvoiceToShowWithCustomerNEW(int tranid, char rptype, int customerid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = customerid;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetRecpAgnsInvWithCustomerNEW", objp);
        }

        public void DelCustChrgs(int rid, int ccid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid",SqlDbType.Int,4),
                                                       new SqlParameter("@ccid",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2) };
            objp[0].Value = rid;
            objp[1].Value = ccid;
            objp[2].Value = type;
            ExecuteQuery("SPDelCustCharg", objp);
        }

        public void UpdReceiptDeleted(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            ExecuteQuery("SPUpdReceDeleted", objp);
        }

        public void UpdRecptCustAmt(int rid, int custid, double amount)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@customer", SqlDbType.Int, 4),
                                                       new SqlParameter("@amount", SqlDbType.Money, 8) };
            objp[0].Value = rid;
            objp[1].Value = custid;
            objp[2].Value = amount;
            ExecuteQuery("SPUpdReciptcustomerAmt", objp);
        }

        public void DelRecAgInv(int rid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1) };
            objp[0].Value = rid;
            objp[1].Value = rptype;
            ExecuteQuery("SPDelRecAgInv", objp);
        }

        public void UpdateRecptHeadCash(int Recptno, int Branchid, char Mode, double rfAmount, string Naration)
       
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@naration",SqlDbType.VarChar,50)};
            objp[0].Value = Recptno;
            objp[1].Value = Branchid;
            objp[2].Value = Mode;
            objp[3].Value = rfAmount;
            objp[4].Value = Naration;
            ExecuteQuery("SPUpdRecptHeadCash", objp);
        }

        public void UpdateRecptHeadBank(int Recptno, int Branchid, char Mode, double rfAmount, int bank, string bbranch, string checkno, DateTime checkdate, string Naration)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int, 4),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@naration",SqlDbType.VarChar,50) };
            objp[0].Value = Recptno;
            objp[1].Value = Branchid;
            objp[2].Value = Mode;
            objp[3].Value = rfAmount;
            objp[4].Value = bank;
            objp[5].Value = bbranch;
            objp[6].Value = checkno;
            objp[7].Value = checkdate;
            objp[8].Value = Naration;
            ExecuteQuery("SPUpdRecptHeadBank", objp);
        }

        //----------------Cheque Query by Amount--------------------------------
        public DataTable SelRecHeadByAmt(double RAmt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ramt", SqlDbType.Money, 8) };
            objp[0].Value = RAmt;
            return ExecuteTable("SPSelRecHeadAmt", objp);
        }

        //----------------Cheque Bounce---------------------------------------
        public DataTable SelRecHeadByChq(string chqno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chqno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = chqno;
            objp[1].Value = branchid;
            return ExecuteTable("SPSelRecHeadChq", objp);
        }

        public void InsChqBounce(int rid,char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("rptype", SqlDbType.Char, 1)};
            objp[0].Value = rid;
            objp[1].Value = rptype;
            ExecuteQuery("SPInsChqBounce", objp);
        }

        ///OutStanding-------------
        public void InsertOutstanding(int branchid, int empid, string salesYesNo,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@sales",SqlDbType.VarChar,2)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = salesYesNo;
            ExecuteQuery("SPOutStdInv", objp);

        }

        public void DeleteOutstanding4Empid(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4)};
            objp[0].Value = empid;
            ExecuteQuery("SPDelOutStdInv", objp);

        }

        public void InsertOutstanding4Customer(int branchid, int empid,int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = customerid;
            ExecuteQuery("SPOutStdInv4Customer", objp);

        }

        public DataTable InsertOutstd4Cust(int customerid,int divisionid,string qtype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@division",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@qtype", SqlDbType.VarChar, 1)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = qtype;
            return ExecuteTable("SPTempOutStdCust", objp);

        }

        public DataTable InsertOutstd4CustExpense(int customerid, int divisionid, string qtype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@division",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@qtype", SqlDbType.VarChar, 1)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = qtype;
            return ExecuteTable("SPTempOutStdCustExpense", objp);

        }

        public double GetOnAcc4Cust(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return double.Parse(ExecuteReader("SPGetOnAcc4Cust", objp));

        }

        public void InsertOutstandingPayment(int branchid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            ExecuteQuery("SPOutStdExp", objp);

        }
        //-------------Deposit Slip-----------------------------
        public DataTable GetLikeSlipno(string slipno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@slipno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = slipno;
            objp[1].Value = branchid;
            return ExecuteTable("SPLikeSlipno", objp);
        }

        public string SlipNoExist(string slipno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@slipno", SqlDbType.VarChar, 15) };
            objp[0].Value = slipno;
            return ExecuteReader("SPSlipnoExist", objp);
        }

        public DataTable GetSlipDetails(string slipno, int branchid, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@slipno", SqlDbType.VarChar, 15),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@mode", SqlDbType.VarChar, 1) };
            objp[0].Value = slipno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            return ExecuteTable("SPGetSlipDtls", objp);
        }


        public DataTable GetSlipDetailsFA(string slipno, int branchid, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@slipno", SqlDbType.VarChar, 15),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@mode", SqlDbType.VarChar, 1) };
            objp[0].Value = slipno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            return ExecuteTable("SPGetSlipDtls_Karthika", objp);
        }
        public int InsDepositSlip(string Slipno, DateTime Slipdate, int Bankid, string Remarks, int Branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@slipno", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@slipdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@bankid", SqlDbType.Int),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@slipid", SqlDbType.Int, 4) };
            objp[0].Value = Slipno;
            objp[1].Value = Slipdate;
            objp[2].Value = Bankid;
            objp[3].Value = Remarks;
            objp[4].Value = Branchid;
            objp[5].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsDepositSlip", objp, "@slipid");
        }

        public void UpdSlipDetails(int Slipid, int receiptid, int branchid, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@slipid", SqlDbType.Int, 4),
                                                      new SqlParameter("@receiptid", SqlDbType.Int, 4),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@mode", SqlDbType.VarChar, 1) };
            objp[0].Value = Slipid;
            objp[1].Value = receiptid;
            objp[2].Value = branchid;
            objp[3].Value = mode;
            ExecuteQuery("SPUpdSlipDtls", objp);
        }
        //------------ChequeClearance--------------------------
        public DataTable GetRecptClearanceDetails(int branchid, DateTime clearedon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            return ExecuteTable("SPGetRecptClearanceDtls", objp);
        }
        public DataTable GetRecptClearanceDetails4Bank(int branchid, DateTime clearedon, string bankname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4), 
                                                    new SqlParameter("@bankname", SqlDbType.VarChar , 100)};

            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = bankname;
            return ExecuteTable("SPGetRecptClearanceDtls4Bank", objp);
        }
        public void UpdRecptClearanceDetails(char truefalse, DateTime clearedon, int receiptid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@truefalse", SqlDbType.Char, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@receiptid", SqlDbType.Int, 4) };
            objp[0].Value = truefalse;
            objp[1].Value = clearedon;
            objp[2].Value = receiptid;
            ExecuteQuery("SPUpdRecptClearanceDtls1", objp);
        }
        //TALLY
        public DataTable GetSlipDetails4tally(string slipno, int branchid, char mode)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@slipno", SqlDbType.VarChar, 15),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1)};
            objp[0].Value = slipno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            return ExecuteTable("SPGetSlipDtls4tally", objp);
        }

        public DataTable GetSlipDetails4CORtally(string slipno, int branchid, char mode)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@slipno", SqlDbType.VarChar, 15),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1)};
            objp[0].Value = slipno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            return ExecuteTable("SPGetSlipDtls4CORtally", objp);
        }

        public DataTable GetCNDetails4Adjus(int CNno, int vouyear, int Branchid, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@cnno", SqlDbType.Int, 4),
                                                      new SqlParameter("@vouyear", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@voutype",SqlDbType.Char,1) };
            objp[0].Value = CNno;
            objp[1].Value = vouyear;
            objp[2].Value = Branchid;
            objp[3].Value = voutype;
            return ExecuteTable("SPGetCNDtls4Adjus", objp);
        }
        public DataTable Getdeposit4branch(DateTime sdate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@sdate",SqlDbType.SmallDateTime),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = sdate;
            objp[1].Value = divisionid;
            return ExecuteTable("SPgetDepositamount4branch", objp);
        }


        public DataTable Getdetails4branchfromDeposit(int branchid, DateTime sdate, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@sdate",SqlDbType.SmallDateTime),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = branchid;
            objp[1].Value = sdate;
            objp[2].Value = division;
            return ExecuteTable("SPGetDetailsfrombranch4deposit", objp);
        }

        //KRishna 1/10/2011
        public DataTable Getnotovercheque4payment(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int)
                
            };
            objp[0].Value = branchid;

            return ExecuteTable("spselnotovercheque4payment", objp);
        }




        //////////////////////Guru????????????????????????????????????////////////////

        public DataTable Getdeposit4branchGriddash()
        {
            
            return ExecuteTable("SPgetDepositamount4branch");
        }




        /* public DataTable Getdetails4branchfromDeposit4Newdash(int branchid, DateTime sdate, int division)
         {
             SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@sdate",SqlDbType.SmallDateTime),
                 new SqlParameter("@divisionid",SqlDbType.Int)
             };
             objp[0].Value = branchid;
             objp[1].Value = sdate;
             objp[2].Value = division;
             return ExecuteTable("SPGetDetailsfrombranch4deposit4NewDash", objp);
         }

         */
        ///////////////////////////////////////////////////////////////////////////////////
        //Krishna 1/10/2011

        //nithya 1/02/2012

        /////////////////ACOSReceiptHead//////////////////////////////////////////



        public void InsOSRecptHeadBank(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, string firc, int preparedby, double recfamt, string recfcurr, double recexrate)
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
                                                       new SqlParameter("@firc", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@recfamount",SqlDbType.Money,8),
                                                       new SqlParameter("@recfcurr",SqlDbType.VarChar,3),
                                                       new SqlParameter("@recexrate",SqlDbType.Money,8)};
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
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
            objp[12].Value = firc;
            objp[13].Value = preparedby;
            objp[14].Value = recfamt;
            objp[15].Value = recfcurr;
            objp[16].Value = recexrate;
            ExecuteQuery("SPInsOSReciptHeadBank", objp);
        }
        //to generate the OSRPno number
        public int GetOSRPNo(int branchid, char rptype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1), 
           new SqlParameter("@rptype", SqlDbType.Char, 1) };
            objp[0].Value = branchid;
            objp[1].Value = rptype;
            return int.Parse(ExecuteReader("SPUpdMCOSrpno", objp));
        }
        // to get OSRecpid
        public int GetOSRecrid(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int , 4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return int.Parse(ExecuteReader("SPSelOSReciptrid", objp));
        }
        //to get OSRECPTHEAD

        public DataTable GetOSRecptHead(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetOSRecptHead", objp);
        }
        // TO GET osrecT cUST
        public DataTable GetOSRecptCust(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSRecptCust", objp);
        }


        public void InsRecptAginstInv4OS(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string receiptfcurr, double receiptfamount, double receiptexrate, double receiptvamount, double recptfcamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
             new SqlParameter("@receiptfcurr", SqlDbType.VarChar, 3),
                 new SqlParameter("@receiptfamount", SqlDbType.Money , 8),
                  new SqlParameter("@receiptexrate", SqlDbType.Money , 8),
                new SqlParameter("@receiptvamount", SqlDbType.Money , 8),
                new SqlParameter("@recptfcamt",SqlDbType.Money,8)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = receiptfcurr;
            objp[10].Value = receiptfamount;
            objp[11].Value = receiptexrate;
            objp[12].Value = receiptvamount;
            objp[13].Value = recptfcamt;
            ExecuteQuery("SPInsReciptAgInv4OS", objp);
        }
        ///OSCUSTOMERDETAILS
        public void InsOSReciptCustomerDetail(int rid, int customer, double amount, double fcamt)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@customer",SqlDbType.Int ,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8),
             new SqlParameter("@fcamt",SqlDbType.Money,8)};
            objp[0].Value = rid;
            objp[1].Value = customer;
            objp[2].Value = amount;
            objp[3].Value = fcamt;
            ExecuteQuery("SPInsOSReciptCustomerDetails", objp);

        }


        //IS OS CHARGEDETAILS
        public void InsOSReciptChargeDetail(int rid, int chargeid, double amount, double fcamt)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@chargeid",SqlDbType.Int,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8),
                new SqlParameter("@fcamt",SqlDbType.Money,8)};
            objp[0].Value = rid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            objp[3].Value = fcamt;
            ExecuteQuery("SPInsOSReciptChargeDetails", objp);
        }
        //GETCHRG DETAILS
        public DataTable GetOSRecptChrg(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSRecptChrg", objp);
        }

        public DataTable GetOSES(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSESDtls", objp);
        }
        public DataTable GetRAInvoiceToShow4OS(int tranid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            return ExecuteTable("SPGetRecpAgnsInv4OS", objp);
        }

        public DataTable GetOSInvRecptDtls(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPOSRecPaymCalc", objp);//SPGetInvRecptDtls
        }
        public DataTable GetDN4OS(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetDNforReceipts4OS", objp);
        }
        public DataTable GetOSDN4OS(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSDNforReceipt4OS", objp);
        }



        public void DelOSCustChrgs(int rid, int ccid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid",SqlDbType.Int,4),
                                                       new SqlParameter("@ccid",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2) };
            objp[0].Value = rid;
            objp[1].Value = ccid;
            objp[2].Value = type;
            ExecuteQuery("SPOSDelCustCharg", objp);
        }
        public bool CheckOSChequeNo(string chqno, int bankid, char rptype)
        {
            bool existance;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chqno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@bank", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1) };
            objp[0].Value = chqno;
            objp[1].Value = bankid;
            objp[2].Value = rptype;
            Dt = ExecuteTable("SPOSCheckChequeNo", objp);
            if (Dt.Rows.Count > 0)
                existance = true;
            else
                existance = false;

            return existance;
        }

        //For Tally

        public DataTable GetOSRecptHeadForTally(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetOSRecptHead4Tally", objp);
        }

        public DataTable GetOSRecptCustForTally(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSRecptCustForTallyNew", objp);
        }


        public DataTable GetOSRAInvoiceToShowWithCustomerForTally(int tranid, char rptype, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = customerid;
            return ExecuteTable("SPGetOSRecpAgnsInvWithCustomer4Tally", objp);
        }

        public DataTable GetOSRecptChrg4Tally(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPOSGetRecptChrg", objp);
        }

        public DataTable GetESOS4Tally(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSESDtls4Tally", objp);
        }


        public DataTable GetOSPaymentHeadForTally(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetOSPaymentHead4Tally", objp);
        }

        public DataTable GetOSPaymentCustForTally(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSPaymentCustForTally", objp);
        }

        public DataTable GetOSPaymentChrg4Tally(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPOSGetPaymentChrg", objp);
        }

        public DataTable GetESOSPayment4Tally(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetOSESDtlsPay4Tally", objp);
        }

        public DataTable GetonAccDetails(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@custid",SqlDbType.Int)
                
            };
            objp[0].Value = custid;

            return ExecuteTable("SpGetOnAccdtls", objp);
        }

        public DataTable GetLikeBankNamefromBranch(string bankname, int branch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bname", SqlDbType.VarChar, 50),
            new SqlParameter("@branchid",SqlDbType.Int,4)};
            objp[0].Value = bankname;
            objp[1].Value = branch;
            return ExecuteTable("SPGetBankfromBranch", objp);
        }


        public void InsertOutstanding4CustomerRpt(int branchid, int empid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = customerid;
            ExecuteQuery("SPOutStd4Customerpt", objp);

        }
        //KUMAR For Cheque Bounce
        public int InsRcptPymt4ChkBounce(int receiptid, int empid, int branchid, char type)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                     new SqlParameter("@receiptid",SqlDbType.Int),
                                                     new SqlParameter("@empid",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@type",SqlDbType.Char,1),
                                                     new SqlParameter("@pyno",SqlDbType.Int,4)};


            objp[0].Value = receiptid;
            objp[1].Value = empid;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Direction = ParameterDirection.Output;
            return ExecuteQuery("Spindpayfromreceipt", objp, "@pyno");
        }



        //raja 4 FA

        //FA
        public DataTable GetRecptHeadFA(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetRecptHeadFA", objp);
        }

        //KUMAR 4 FA
        public DataTable GetRecptCust4FA(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetRecptCust4FA", objp);
        }


        public DataTable GetRecptChrg4FA(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetTDSAmtBranchwise", objp);
        }
        //For Journal
        public DataTable GetRecPaymCalcjnrl(int customerid, int divisionid, string rpttype, string fadbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@rpttype", SqlDbType.VarChar, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = rpttype;
            objp[3].Value = fadbname;
            return ExecuteTable("SPRecPaymCalcjnrl", objp);//SPGetInvRecptDtls
        }
        //from Journal
        public DataTable GetjnrlRecptDtls(int customerid, int divisionid, string fadbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = fadbname;
            return ExecuteTable("SPGetjnrlRecptDtls", objp);
        }

        public void InsRecptAginstInvj(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string jrefno, string jltype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@jrefno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@jltype",SqlDbType.VarChar,2)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = jrefno;
            objp[10].Value = jltype;
            ExecuteQuery("SPInsReciptAgInvj", objp);
        }

        public DataTable GetRecptPymtContraLikeChqno(int branchid, string chqno, char type, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@chqno", SqlDbType.VarChar ,30),
                                                      new SqlParameter("@type", SqlDbType.Char,1),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,30) };
            objp[0].Value = branchid;
            objp[1].Value = chqno;
            objp[2].Value = type;
            objp[3].Value = dbname;
            return ExecuteTable("SPGetRecptPymtContraLikeChqno", objp);
        }

        //public DataTable GetRecptClearance4chq(int branchid, string chqno)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
        //                                              new SqlParameter("@chqno", SqlDbType.VarChar ,30) };
        //    objp[0].Value = branchid;
        //    objp[1].Value = chqno;
        //    return ExecuteTable("SPGetRecptClearance4Chq", objp);
        //}
        //nambi

        public void DelRectPmt(int rid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1) };
            objp[0].Value = rid;
            objp[1].Value = rptype;
            ExecuteQuery("SPDelRectPmt", objp);
        }
        public DataTable GetOSRecptClearanceDetails(int branchid, DateTime clearedon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            return ExecuteTable("SPGetOSRecptClearanceDtls1", objp);
        }

        public DataTable GetRecptClearance4chq(int branchid, string chqno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@chqno", SqlDbType.VarChar ,30), 
                                                      new SqlParameter("@type", SqlDbType.Char)};
            objp[0].Value = branchid;
            objp[1].Value = chqno;
            objp[2].Value = type;
            return ExecuteTable("SPGetRecptClearance4Chq", objp);
        }
        ////Newly Added
        //public void InsRecptAginstVou(string voutype, int vouno, int vouyear, double amount, int branchid, string avoutype, int avouno, int avouyear, double avouamt, double aamount, int abranchid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { 
        //                                               new SqlParameter("@voutype", SqlDbType.VarChar , 1),
        //                                               new SqlParameter("@vouno", SqlDbType.Int, 4),
        //                                               new SqlParameter("@vouyear", SqlDbType.Int),
        //                                               new SqlParameter("@amount", SqlDbType.Money , 8),
        //                                               new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
        //                                               new SqlParameter("@avoutype", SqlDbType.VarChar , 1),
        //                                               new SqlParameter("@avouno", SqlDbType.Int, 4),
        //                                               new SqlParameter("@avouyear", SqlDbType.Int),
        //                                               new SqlParameter("@avouamount", SqlDbType.Money , 8),
        //                                               new SqlParameter("@aamount", SqlDbType.Money , 8),
        //                                               new SqlParameter("@abranchid", SqlDbType.TinyInt, 1)
        //                                              };
        //    objp[0].Value = voutype;
        //    objp[1].Value = vouno;
        //    objp[2].Value = vouyear;
        //    objp[3].Value = amount;
        //    objp[4].Value = branchid;
        //    objp[5].Value = avoutype;
        //    objp[6].Value = avouno;
        //    objp[7].Value = avouyear;
        //    objp[8].Value = avouamt;
        //    objp[9].Value = aamount;
        //    objp[10].Value = abranchid;
        //    ExecuteQuery("SPInsReciptAgVou", objp);
        //}

        //Newly Added
        public void InsRecptAginstVou(string voutype, int vouno, int vouyear, double amount, int branchid, string avoutype, int avouno, int avouyear, double avouamt, double aamount, int abranchid, string settype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@voutype", SqlDbType.VarChar , 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int,4),
                                                       new SqlParameter("@amount", SqlDbType.Money , 8),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@avoutype", SqlDbType.VarChar , 1),
                                                       new SqlParameter("@avouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@avouyear", SqlDbType.Int,1),
                                                       new SqlParameter("@avouamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@aamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@abranchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@setdate", SqlDbType.VarChar , 3)
                                                      };
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = vouyear;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = avoutype;
            objp[6].Value = avouno;
            objp[7].Value = avouyear;
            objp[8].Value = avouamt;
            objp[9].Value = aamount;
            objp[10].Value = abranchid;
            objp[11].Value = settype;
            ExecuteQuery("SPInsReciptAgVou", objp);
        }

        public DataTable GetSlipDetails4ReversalBr(int recid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@recID", SqlDbType.BigInt) };
            objp[0].Value = recid;
            return ExecuteTable("SPGetSlipDtls4ReversalBr", objp);
        }
        public DataTable GetSlipDetails4ReversalCo(int recid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@recID", SqlDbType.BigInt) };
            objp[0].Value = recid;
            return ExecuteTable("SPGetSlipDtls4ReversalCo", objp);
        }
        public void updSlipIDforBounce(int recno, string mode, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@recno", SqlDbType.BigInt),
                                                       new SqlParameter("@mode", SqlDbType.Char,1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt ),
                                                       new SqlParameter("@vouyear", SqlDbType.Int)};
            objp[0].Value = recno;
            objp[1].Value = mode;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            ExecuteQuery("SPUpdSlipIDforBounce", objp);
        }

        public void InsSinsAudit(DateTime fromdate, DateTime todate, int bid, int empid, string rptype, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime),
                                                       new SqlParameter("@todate",SqlDbType.DateTime),
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@empid",SqlDbType.Int,4),
                                                       new SqlParameter("@rptype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@cid",SqlDbType.Int,4)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = bid;
            objp[3].Value = empid;
            objp[4].Value = rptype;
            objp[5].Value = cid;
            ExecuteQuery("SPInsTempSinceAudit", objp);
        }

        public void InsSinsAudit4OS(DateTime fromdate, DateTime todate, int bid, int empid, string rptype, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime),
                                                       new SqlParameter("@todate",SqlDbType.DateTime),
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@empid",SqlDbType.Int,4),
                                                       new SqlParameter("@rptype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@cid",SqlDbType.Int,4)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = bid;
            objp[3].Value = empid;
            objp[4].Value = rptype;
            objp[5].Value = cid;
            ExecuteQuery("SPInsTempSinceAuditOS", objp);
        }
        //From 'From ReceiptAgainstInvoice(If the Receipt amount is not setteled)
        public DataTable GetInvRecptDtlsAdj(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPRecPaymCalc4adj", objp);//SPGetInvRecptDtls
        }

        public DataTable GetOSInvRecptDtlsLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPOSRecPaymCalcLedger", objp);//SPGetInvRecptDtls
        }

        public DataTable RecPaymCalcAdjDNLedger(int ledgerid, int divisionid, string rpttype, string fadbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@rpttype", SqlDbType.VarChar, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            objp[2].Value = rpttype;
            objp[3].Value = fadbname;
            return ExecuteTable("SPRecPaymCalcAdjDNLedger", objp);//SPGetInvRecptDtls
        }

        public DataTable GetDN4OSLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetDNforReceipts4OSLedger", objp);
        }

        public DataTable GetOSDN4OSLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSDNforReceipt4OSLedger", objp);
        }

        public DataTable GetAdjDCNRecptDtlsLedger(int ledgerid, int divisionid, string rpttype, string fadbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@rpttype", SqlDbType.VarChar, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            objp[2].Value = rpttype;
            objp[3].Value = fadbname;
            return ExecuteTable("SPGetAdjDCNRecptDtlsLedger", objp);//SPGetInvRecptDtls
        }

        public DataTable GetDNAdmin4OSLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetDNAdminforReceipts4OSLedger", objp);
        }


        //Arun

        public DataTable GetCreditApprovalBy(int divisionid, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@divisinid", SqlDbType.Int),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = divisionid;
            objp[1].Value = brnachid;

            return ExecuteTable("SpGetApproval", objp);
        }


        public DataTable GetCreditApprovalGet(int divisionid, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@divisinid", SqlDbType.Int),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = divisionid;
            objp[1].Value = brnachid;

            return ExecuteTable("SpGetApprovalReg", objp);
        }


        public DataTable GetLikeReceiptCustomer4Corp(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeReceiptCustomer4Corp", objp);
        }


        public DataTable GetLikeReceiptCustomer4Mum(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeReceiptCustomer4Mum", objp);
        }

        //Karthika

        public DataTable SelRecHeadChqRecno(string chqno, int branchid, int receiptno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chqno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@receiptno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4)};
            objp[0].Value = chqno;
            objp[1].Value = branchid;
            objp[2].Value = receiptno;
            objp[3].Value = vouyear;

            return ExecuteTable("SPSelRecHeadChqRecno", objp);
        }

        public DataTable SelRecHeadRecno(int branchid, int receiptno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@receiptno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = receiptno;
            objp[2].Value = vouyear;
            return ExecuteTable("SPSelRecHeadRecno", objp);
        }


        //ARUN

        public DataTable GetOverallRecAmt(int branchid, int vouyear, DateTime receptdate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@voucheryear", SqlDbType.Int),
                                                       new SqlParameter("@receiptDate", SqlDbType.SmallDateTime)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = receptdate;
            return ExecuteTable("SPOverAllRecptAmt", objp);
        }
        public DataTable GetOverallAmtForBarChart(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@branchid", SqlDbType.Int)
                                                      
                                                     };
            objp[0].Value = branchid;

            return ExecuteTable("sp_GetBarCharRecCount", objp);
        }

        public DataTable GetPartiCulRecpt(int branchid, int vouyear, DateTime receptdate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@voucheryear", SqlDbType.Int),
                                                       new SqlParameter("@receiptDate", SqlDbType.SmallDateTime)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = receptdate;
            return ExecuteTable("SPGetRecptNo", objp);
        }


        //FA
        public DataTable GetOSRecptClearanceDetails4BRS(int branchid, DateTime voudate, string bankname, string curtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                      new SqlParameter("@voudate", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@bankname", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@curtype", SqlDbType.VarChar, 10)};
            objp[0].Value = branchid;
            objp[1].Value = voudate;
            objp[2].Value = bankname;
            objp[3].Value = curtype;
            return ExecuteTable("SPGetOSRecptClearanceDtls4BRS", objp);
        }

        //Newly Added
        public void InsRecptAginstVou(string voutype, int vouno, int vouyear, double amount, int branchid, string avoutype, int avouno, int avouyear, double avouamt, double aamount, int abranchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@voutype", SqlDbType.VarChar , 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int,4),
                                                       new SqlParameter("@amount", SqlDbType.Money , 8),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@avoutype", SqlDbType.VarChar , 1),
                                                       new SqlParameter("@avouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@avouyear", SqlDbType.Int,1),
                                                       new SqlParameter("@avouamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@aamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@abranchid", SqlDbType.TinyInt, 1)
                                                      };
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = vouyear;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = avoutype;
            objp[6].Value = avouno;
            objp[7].Value = avouyear;
            objp[8].Value = avouamt;
            objp[9].Value = aamount;
            objp[10].Value = abranchid;
            ExecuteQuery("SPInsReciptAgVou", objp);
        }

        public void DelRecAgInv4OS(int rid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1) };
            objp[0].Value = rid;
            objp[1].Value = rptype;
            ExecuteQuery("SPDelRecAgInv4OS", objp);
        }
        public void InsRecptAginstVouOS(string voutype, int vouno, int vouyear, double amount, int branchid, string avoutype, int avouno, int avouyear, double avouamt, double aamount, int abranchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@voutype", SqlDbType.VarChar , 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int,4),
                                                       new SqlParameter("@amount", SqlDbType.Money , 8),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@avoutype", SqlDbType.VarChar , 1),
                                                       new SqlParameter("@avouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@avouyear", SqlDbType.Int,1),
                                                       new SqlParameter("@avouamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@aamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@abranchid", SqlDbType.TinyInt, 1)
                                                      };
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = vouyear;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = avoutype;
            objp[6].Value = avouno;
            objp[7].Value = avouyear;
            objp[8].Value = avouamt;
            objp[9].Value = aamount;
            objp[10].Value = abranchid;
            ExecuteQuery("SPInsReciptAgVouOS", objp);
        }



    


        public void InsReciptAgVou4jnl(string voutype, int vouno, int vouyear, double amount, int branchid, int avouyear, double avouamt, double aamount, int abranchid, string jrefno, string jltype, int custid, int ledgid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@voutype", SqlDbType.VarChar , 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money , 8),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@avouyear", SqlDbType.Int , 1),
                                                       new SqlParameter("@avouamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@aamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@abranchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@jrefno", SqlDbType.VarChar , 60),
                                                       new SqlParameter("@jltype", SqlDbType.VarChar , 2),
                                                       new SqlParameter("@custid", SqlDbType.Int , 1),
                                                       new SqlParameter("@ledgid", SqlDbType.Int , 1),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar , 15),
                                                      };
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = vouyear;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = avouyear;
            objp[6].Value = avouamt;
            objp[7].Value = aamount;
            objp[8].Value = abranchid;
            objp[9].Value = jrefno;
            objp[10].Value = jltype;
            objp[11].Value = custid;
            objp[12].Value = ledgid;
            objp[13].Value = dbname;
            ExecuteQuery("SPInsReciptAgVou4jnl", objp);
        }

        public void InsRecptAginstInv4OSAdjDCN(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string receiptfcurr, double receiptfamount, double receiptexrate, double receiptvamount, double recptfcamt, string jltype, int jlid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@receiptfcurr", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@receiptfamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@receiptexrate", SqlDbType.Money , 8),
                                                       new SqlParameter("@receiptvamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@recptfcamt",SqlDbType.Money,8),
                                                       new SqlParameter("@jltype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@jlid", SqlDbType.Int, 4)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = receiptfcurr;
            objp[10].Value = receiptfamount;
            objp[11].Value = receiptexrate;
            objp[12].Value = receiptvamount;
            objp[13].Value = recptfcamt;
            objp[14].Value = jltype;
            objp[15].Value = jlid;
            ExecuteQuery("SPInsReciptAgInv4OSAdjDCN", objp);
        }


        public void DelCustChrgsOS(int rid, int ccid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid",SqlDbType.Int,4),
                                                       new SqlParameter("@ccid",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2) };
            objp[0].Value = rid;
            objp[1].Value = ccid;
            objp[2].Value = type;
            ExecuteQuery("SPDelCustChargOS", objp);
        }

        public void UpdRecptCustAmtOS(int rid, int custid, double amount, double fcamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@customer", SqlDbType.Int, 4),
                                                       new SqlParameter("@amount", SqlDbType.Money, 8),
                                                       new SqlParameter("@fcamt", SqlDbType.Money, 8)};
            objp[0].Value = rid;
            objp[1].Value = custid;
            objp[2].Value = amount;
            objp[3].Value = fcamt;

            ExecuteQuery("SPUpdReciptcustomerAmtOS", objp);
        }

        public DataTable GetRecptChrgOS(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPGetRecptChrgOS", objp);
        }

        public DataTable OSGetCustomerVoutype(string vtype, int vouno, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vtype", SqlDbType.VarChar, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int) };
            objp[0].Value = vtype;
            objp[1].Value = vouno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;

            return ExecuteTable("OSGetCustomerVoutype", objp);
        }



        public DataTable Getdetails4branchfromDeposit4Newdash(int branchid, DateTime sdate, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@sdate",SqlDbType.SmallDateTime),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = branchid;
            objp[1].Value = sdate;
            objp[2].Value = division;
            return ExecuteTable("SPGetDetailsfrombranch4deposit4NewDash", objp);
        }


        public double Get_excessinreceipt(int receiptid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@receiptid", SqlDbType.Int, 4) };
            objp[0].Value = receiptid;
            return double.Parse(ExecuteReader("SPGet_excessinreceiptt", objp));
        }

        public double Getcollectionamt(int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) ,
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4) };
            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            return double.Parse(ExecuteReader("SP_GetCollectionAmount", objp));

        }

        public double GetdepositTot(int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) ,
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4) };
            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            return double.Parse(ExecuteReader("Sp_getdepositslipTot", objp));
        }

        public DataTable GetCNDetails4AdjusOS(int CNno, int vouyear, int Branchid, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@cnno", SqlDbType.Int, 4),
                                                      new SqlParameter("@vouyear", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@voutype",SqlDbType.Char,1) };
            objp[0].Value = CNno;
            objp[1].Value = vouyear;
            objp[2].Value = Branchid;
            objp[3].Value = voutype;
            return ExecuteTable("SPGetCNDtls4AdjusOS", objp);
        }

        public DataTable GetOSInvRecptDtls4Adjust(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPOSRecPaymCalcAdjust", objp);
        }


        public DataTable GetRecptClearanceDetails(int branchid, DateTime clearedon, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4)
                                    ,new SqlParameter("@datetype", SqlDbType.NVarChar, 5)};
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = datetype;
            return ExecuteTable("SPGetRecptClearanceDtls", objp);
        }


        public void UpdOSRecptClearanceDetails(char truefalse, DateTime clearedon, int receiptid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@truefalse", SqlDbType.Char, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@receiptid", SqlDbType.Int, 4) };
            objp[0].Value = truefalse;
            objp[1].Value = clearedon;
            objp[2].Value = receiptid;
            ExecuteQuery("SPUpdOSRecptClearanceDtls", objp);
        }


        public DataTable GetOSRecptClearanceDetails4Bank(int branchid, DateTime clearedon, string bankname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4), 
                                                    new SqlParameter("@bankname", SqlDbType.VarChar , 100)};

            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = bankname;
            return ExecuteTable("SPGetOSRecptClearanceDtls4Bank", objp);
        }




        public DataTable GetOSRecptClearanceDetails(int branchid, DateTime clearedon, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@datetype", SqlDbType.NVarChar, 5)};
            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = datetype;
            return ExecuteTable("SPGetOSRecptClearanceDtls", objp);
        }




        public DataTable GetRecptClearanceDetails4Bank(int branchid, DateTime clearedon, string bankname, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4), 
                                                    new SqlParameter("@bankname", SqlDbType.VarChar , 100)
                            ,new SqlParameter("@datetype", SqlDbType.NVarChar, 5)};

            objp[0].Value = branchid;
            objp[1].Value = clearedon;
            objp[2].Value = bankname;
            objp[3].Value = datetype;
            return ExecuteTable("SPGetRecptClearanceDtls4Bank", objp);
        }


        public DataTable GetTOTOSRecptClearanceDetails4BRS(int branchid, DateTime voudate, string bankname, string curtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                      new SqlParameter("@voudate", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@bankname", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@curtype", SqlDbType.VarChar, 10)};
            objp[0].Value = branchid;
            objp[1].Value = voudate;
            objp[2].Value = bankname;
            objp[3].Value = curtype;
            return ExecuteTable("SPGetTOTOSRecptClearanceDtls4BRS", objp);
        }


        //KUMAR
        //For BDJV
        public int GetRecridBD(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int , 4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return int.Parse(ExecuteReader("SPSelReciptridBD", objp));
        }
        //For BR-BDJV
        public DataTable GetRecptHeadBD(int rno, int branchid, char mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetRecptHeadBD", objp);
        }

    

        //RUBAN



        public DataTable CollectionPending(int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@divisionid",SqlDbType.Int,4)
            };
            objp[0].Value = divisionid;
            return ExecuteTable("spcollectionpending", objp);
        }
        public DataTable BRSUncleared(int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@divisionid",SqlDbType.Int,4)
            };
            objp[0].Value = divisionid;
            return ExecuteTable("SPClearedon", objp);
        }

        //Ruban

        public DataTable GetdepositTot(int branchid, int vouyear, DateTime sdate, int divisionid)
        {
            SqlParameter[] obj_p = new SqlParameter[]{
                new SqlParameter("@branchid",SqlDbType.Int,2),
                new SqlParameter("@vouyear",SqlDbType.Int,2),
                new SqlParameter("@sdate",SqlDbType.SmallDateTime),
                new SqlParameter("@divisionid",SqlDbType.Int,2)

               
            };
            obj_p[0].Value = branchid;
            obj_p[1].Value = vouyear;

            obj_p[2].Value = sdate;
            obj_p[3].Value = divisionid;
             return ExecuteTable("Sp_getdepositslipTot", obj_p);
        }

        //Ruban Add for BOS
        //From BOS
        public DataTable GetInvRecptDtls1BOS(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetInvRecptDtls1BOS", objp);
        }


        public void InsRecptAginstInvwithvendor(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string vendorrefno, DateTime vendordate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@vendorrefno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@vendordate", SqlDbType.SmallDateTime, 4)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = vendorrefno;
            objp[10].Value = vendordate;
            ExecuteQuery("SPInsReciptAgInvwithvendor", objp);
        }


        public void InsRecptAginstInv4OSwithvendor(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string receiptfcurr, double receiptfamount, double receiptexrate, double receiptvamount, double recptfcamt, string vendorrefno, DateTime vendordate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
             new SqlParameter("@receiptfcurr", SqlDbType.VarChar, 3),
                 new SqlParameter("@receiptfamount", SqlDbType.Money , 8),
                  new SqlParameter("@receiptexrate", SqlDbType.Money , 8),
                new SqlParameter("@receiptvamount", SqlDbType.Money , 8),
                new SqlParameter("@recptfcamt",SqlDbType.Money,8),
                                                       new SqlParameter("@vendorrefno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@vendordate", SqlDbType.SmallDateTime, 4)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = receiptfcurr;
            objp[10].Value = receiptfamount;
            objp[11].Value = receiptexrate;
            objp[12].Value = receiptvamount;
            objp[13].Value = recptfcamt;
            objp[14].Value = vendorrefno;
            objp[15].Value = vendordate;
            ExecuteQuery("SPInsReciptAgInv4OSwithvendor", objp);
        }

        public DataTable GetRecptHeadFA(int rno, int branchid, char mode, int vouyear, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            objp[4].Value = rptype;
            return ExecuteTable("SPGetRecptHeadFANew", objp);
        }
        public double Get_excessinreceiptnew(int receiptid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@receiptid", SqlDbType.Int, 4),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = receiptid;
            objp[1].Value = rptype;
            return double.Parse(ExecuteReader("SPGet_excessinreceipttNEw", objp));
        }

        public void UpdRecptCustAmt(int rid, int custid, double amount, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@customer", SqlDbType.Int, 4),
                                                       new SqlParameter("@amount", SqlDbType.Money, 8),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rid;
            objp[1].Value = custid;
            objp[2].Value = amount;
            objp[3].Value = rptype;
            ExecuteQuery("SPUpdReciptcustomerAmtNew", objp);
        }

        public void InsReciptChargeDetail(int rid, int chargeid, double amount, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
new SqlParameter ("@chargeid",SqlDbType.Int,4),
new SqlParameter("@amount",SqlDbType.Money,8),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            objp[3].Value = rptype;
            ExecuteQuery("SPInsReciptChargeDetailsNew", objp);
        }


        public void DelCustChrgs(int rid, int ccid, string type, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid",SqlDbType.Int,4),
                                                       new SqlParameter("@ccid",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rid;
            objp[1].Value = ccid;
            objp[2].Value = type;
            objp[3].Value = rptype;
            ExecuteQuery("SPDelCustChargNew", objp);
        }
        //rajsir added on 22 nov2021
        public void DelCustChrgsonacc(int rid, int ccid, string type, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid",SqlDbType.Int,4),
                                                       new SqlParameter("@ccid",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rid;
            objp[1].Value = ccid;
            objp[2].Value = type;
            objp[3].Value = rptype;
            ExecuteQuery("SPDelCustChargNewdel4onacc", objp);
        }


        public DataTable GetInvRecptDtls(int customerid, int divisionid, string rpttype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@rpttype", SqlDbType.VarChar, 1)  };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = rpttype;
            return ExecuteTable("SPRecPaymCalcnewforonaccount", objp);//SPGetInvRecptDtls  SPRecPaymCalc4adj
        }

        public int sp_receiptheadneft(int branchid, string mode, string neft)
        {
            SqlParameter[] objp = new SqlParameter[]
            { new SqlParameter("@branchid", SqlDbType.Int),
              new SqlParameter("@mode", SqlDbType.VarChar,2),
              new SqlParameter("@NEFT", SqlDbType.VarChar,2)
            };
            objp[0].Value = branchid;
            objp[1].Value = mode;
            objp[2].Value = neft;
            return int.Parse(ExecuteReader("sp_receiptheadneft", objp));
        }
        public int sp_paymentheadneft(int branchid, string mode, string neft)
        {
            SqlParameter[] objp = new SqlParameter[]
            { new SqlParameter("@branchid", SqlDbType.Int),
              new SqlParameter("@mode", SqlDbType.VarChar,2),
              new SqlParameter("@NEFT", SqlDbType.VarChar,2)
            };
            objp[0].Value = branchid;
            objp[1].Value = mode;
            objp[2].Value = neft;
            return int.Parse(ExecuteReader("sp_paymentheadneft", objp));
        }



        public void InsRecptHeadBanknew(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, string neft)
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
                                                       new SqlParameter("@neft", SqlDbType.VarChar, 2)};
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
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
            objp[13].Value = neft;
            ExecuteQuery("SPInsReciptHeadBanknew", objp);
        }



        public void DelFARectPmt(int ledgerid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                                    };
            objp[0].Value = ledgerid;
            objp[1].Value = branchid;
            ExecuteQuery("SpDelFARectPmt", objp);
        }

        public int ChkVouNoExistsinFARectPmt(int vouno, int vouyear, int bid, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid", SqlDbType.TinyInt),
                                                     new SqlParameter("@voutype",SqlDbType.VarChar,5),};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = bid;
            objp[3].Value = voutype;
            return int.Parse(ExecuteReader("SPChkVouNoExistsinFARectPmt", objp));
        }

        //Dinesh
        public void InsFARectPmttempvendor(int ledgerid, int vouno, DateTime voudate, string voutype, int vouyear, int branchid, double vouamonut, string fcurr, double famount, int tranyear, double tranamount, string tranfcurr, double tranfamount, string settled, int customerid, double exrate, string vendorrefno, DateTime vendorrefdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voudate", SqlDbType.DateTime , 8),
                                                       new SqlParameter("@voutype", SqlDbType.Char,2),
                                                        new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@fcurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@famount", SqlDbType.Money , 8),
                                                        new SqlParameter("@tranyear", SqlDbType.Int , 4),
                                                       new SqlParameter("@tranamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@tranfcurr", SqlDbType.VarChar , 3),
                                                         new SqlParameter("@tranfamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@settled",SqlDbType.VarChar,1),
                                                        new SqlParameter("@customerid",SqlDbType.Int ),
                                                        new SqlParameter("@exrate",SqlDbType.SmallMoney ),
                                                         new SqlParameter("@vendorrefno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8)
                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vouamonut;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = tranyear;
            objp[10].Value = tranamount;
            objp[11].Value = tranfcurr;
            objp[12].Value = tranfamount;
            objp[13].Value = settled;
            objp[14].Value = customerid;
            objp[15].Value = exrate;
            objp[16].Value = vendorrefno;
            objp[17].Value = vendorrefdate;
            ExecuteQuery("SPinsFARectPmttempvendor", objp);
        }




        //dinesh

        public void InsFARectPmtnewvendor(int ledgerid, int vouno, DateTime voudate, string voutype, int vouyear, int branchid, double vouamonut, string fcurr, double famount,
               int tranyear, double tranamount, string tranfcurr, double tranfamount, string settled, int customerid, double exrate, string vendorrefno, DateTime vendorrefdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voudate", SqlDbType.DateTime , 8),
                                                       new SqlParameter("@voutype", SqlDbType.Char,2),
                                                        new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@fcurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@famount", SqlDbType.Money , 8),
                                                        new SqlParameter("@tranyear", SqlDbType.Int , 4),
                                                       new SqlParameter("@tranamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@tranfcurr", SqlDbType.VarChar , 3),
                                                         new SqlParameter("@tranfamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@settled",SqlDbType.VarChar,1),
                                                        new SqlParameter("@customerid",SqlDbType.Int ),
                                                        new SqlParameter("@exrate",SqlDbType.SmallMoney ),
                                                         new SqlParameter("@vendorrefno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8)


                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vouamonut;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = tranyear;
            objp[10].Value = tranamount;
            objp[11].Value = tranfcurr;
            objp[12].Value = tranfamount;
            objp[13].Value = settled;
            objp[14].Value = customerid;
            objp[15].Value = exrate;
            objp[16].Value = vendorrefno;
            objp[17].Value = vendorrefdate;
            ExecuteQuery("SPinsFARectPmtvendor", objp);
        }


        //Muthuraj

        public void InsFARectPmttemp(int ledgerid, int vouno, DateTime voudate, string voutype, int vouyear, int branchid, double vouamonut, string fcurr, double famount, int tranyear, double tranamount, string tranfcurr, double tranfamount, string settled, int customerid, double exrate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voudate", SqlDbType.DateTime , 8),
                                                       new SqlParameter("@voutype", SqlDbType.Char,2),
                                                        new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@fcurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@famount", SqlDbType.Money , 8),
                                                        new SqlParameter("@tranyear", SqlDbType.Int , 4),
                                                       new SqlParameter("@tranamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@tranfcurr", SqlDbType.VarChar , 3),
                                                         new SqlParameter("@tranfamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@settled",SqlDbType.VarChar,1),
                                                        new SqlParameter("@customerid",SqlDbType.Int ),
                                                        new SqlParameter("@exrate",SqlDbType.SmallMoney )


                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vouamonut;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = tranyear;
            objp[10].Value = tranamount;
            objp[11].Value = tranfcurr;
            objp[12].Value = tranfamount;
            objp[13].Value = settled;
            objp[14].Value = customerid;
            objp[15].Value = exrate;
            ExecuteQuery("SPinsFARectPmttemp", objp);
        }




        public void InsFARectPmtnew(int ledgerid, int vouno, DateTime voudate, string voutype, int vouyear, int branchid, double vouamonut, string fcurr, double famount,
                  int tranyear, double tranamount, string tranfcurr, double tranfamount, string settled, int customerid, double exrate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voudate", SqlDbType.DateTime , 8),
                                                       new SqlParameter("@voutype", SqlDbType.Char,2),
                                                        new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@fcurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@famount", SqlDbType.Money , 8),
                                                        new SqlParameter("@tranyear", SqlDbType.Int , 4),
                                                       new SqlParameter("@tranamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@tranfcurr", SqlDbType.VarChar , 3),
                                                         new SqlParameter("@tranfamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@settled",SqlDbType.VarChar,1),
                                                        new SqlParameter("@customerid",SqlDbType.Int ),
                                                        new SqlParameter("@exrate",SqlDbType.SmallMoney )


                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vouamonut;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = tranyear;
            objp[10].Value = tranamount;
            objp[11].Value = tranfcurr;
            objp[12].Value = tranfamount;
            objp[13].Value = settled;
            objp[14].Value = customerid;
            objp[15].Value = exrate;
            ExecuteQuery("SPinsFARectPmt", objp);
        }

        public DataTable SelOPBal4Ledger(string dbname, int ledgerid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@dbname", SqlDbType.VarChar,15 ),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int ),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt )};
            objp[0].Value = dbname;
            objp[1].Value = ledgerid;
            objp[2].Value = bid;
            return ExecuteTable("spselopbal4ledger", objp);
        }

        public DataTable ChkLedgIDInFARcptPmt(int ledgerid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                        new SqlParameter("@ledgerid", SqlDbType.Int ),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt )};
            objp[0].Value = ledgerid;
            objp[1].Value = bid;
            return ExecuteTable("SPChkLedgIDInFARcptPmt", objp);

        } 
        




  //Raj

        public DataTable GetRecptCust4FA(int rid, string rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.VarChar , 2) };
            objp[0].Value = rid;
            objp[1].Value = rptype;
            return ExecuteTable("SPGetRecptCust4FA", objp);
        }
        //From OB Breakup
        public DataTable GetOBRecptDtls(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOBRecptDtls", objp);
        }

        public DataTable RecPaymCalc4OBBreakup(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                      };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPRecPaymCalc4OBBreakup", objp);//SPGetInvRecptDtls
        }
        //Sindhu
        public DataTable GetOBRecptDtlsOS(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOBRecptDtlsOS", objp);
        }
        public DataTable RecPaymCalc4OBBreakupOS(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                      };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPRecPaymCalc4OBBreakupOS", objp);//SPGetInvRecptDtls
        }

        //Receipt.cs
        //Tally
        public DataTable GetRAInvoiceToShowWithCustomerforremittance(int tranid, char rptype, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = customerid;
            return ExecuteTable("SPGetRecpAgnsInvWithCustomerforremittance", objp);
        }

        public void InsRecptAginstInvnew(int tranid, char rptype, int vouno, string voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int) };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            ExecuteQuery("SPInsReciptAgInv", objp);
        }
        public String SpDelRecPay(int vouno, int voutype, int branch, string seltype, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@vouno",SqlDbType.Int),
                                                         new SqlParameter("@voutype",SqlDbType.Int),
                                                         new SqlParameter("@branch",SqlDbType.Int),
                                                         new SqlParameter("@seltype",SqlDbType.VarChar,100),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,30)

                                                     };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = branch;
            objp[3].Value = seltype;
            objp[4].Value = dbname;
            return ExecuteReader("SpDelPayrecforOnAccount", objp);
        }   

        //Changes into On-Account
        public String AcReceiptPaymentOnAccount(int tranid, int divisionid, string rptype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@tranid",SqlDbType.Int),
                                                         new SqlParameter("@divisionid",SqlDbType.Int),
                                                        
                                                         new SqlParameter("@rptype",SqlDbType.VarChar,100)

                                                     };
            objp[0].Value = tranid;
            objp[1].Value = divisionid;
            objp[2].Value = rptype;

            return ExecuteReader("AcReceiptPaymentOnAccount", objp);
        }

        public DateTime GetRPMaxDate(int bid, string type, string mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.Int,4),
                                                        new SqlParameter("@rptype", SqlDbType.VarChar,1),
                                                        new SqlParameter("@mode", SqlDbType.VarChar, 1),
                                                        new SqlParameter("@vouyear", SqlDbType.Int,4)};
            objp[0].Value = bid;
            objp[1].Value = type;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return DateTime.Parse(ExecuteReader("SPGetRPMaxDate", objp));
        }


        public int ReversalPayment(int receiptid, int empid, int branchid, char type)
        {

            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@receiptid",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
              new SqlParameter("@branchid",SqlDbType.TinyInt,1),
              new SqlParameter("@type",SqlDbType.Char,1),
               new SqlParameter("@pyno",SqlDbType.Int,4)

            };
            objp[0].Value = receiptid;
            objp[1].Value = empid;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Direction = ParameterDirection.Output;
            return ExecuteQuery("Cashrecpaycancel", objp, "@pyno");
        }




        public DataTable getcustloginchart4home(int webgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@webgroupid", SqlDbType.Int)
                                                      
                                                     };
            objp[0].Value = webgroupid;

            return ExecuteTable("spgetcustloginchart4home", objp);
        }

        public DataTable getcustlogin4homedetails(int webgroupid, string trantype,string type)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@webgroupid", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,30),
                                                        new SqlParameter("@type", SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = webgroupid;
            objp[1].Value = trantype;
            objp[2].Value = type;
            return ExecuteTable("spgetcustlogin4homedetails", objp);
          //  return ExecuteTable("spgetcustlogin4homedetailsnew", objp);
            
        }

        public DataTable getcustloginchart4homenew(int webgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@webgroupid", SqlDbType.Int)
                                                      
                                                     };
            objp[0].Value = webgroupid;

            return ExecuteTable("spgetcustloginchart4homenew", objp);
        }


        public DataTable GetRecpAgnsInvForTally(int tranid, char rptype,int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@custid", SqlDbType.Int, 4)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = custid;
            return ExecuteTable("SPGetRecpAgnsInvForTally", objp);
        }

        //New
        public int GetOSRPNoBackdated(int branchid, char rptype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1), 
           new SqlParameter("@rptype", SqlDbType.Char, 1) };
            objp[0].Value = branchid;
            objp[1].Value = rptype;
            return int.Parse(ExecuteReader("SPUpdMCOSrpnoBackdated", objp));
        }

        public void InsOSRecptHeadBankBackdate(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, double recfamt, string recfcurr, double recexrate)
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
                                                       new SqlParameter("@recfamount",SqlDbType.Money,8),
                                                       new SqlParameter("@recfcurr",SqlDbType.VarChar,3),
                                                       new SqlParameter("@recexrate",SqlDbType.Money,8)};
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
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
            objp[13].Value = recfamt;
            objp[14].Value = recfcurr;
            objp[15].Value = recexrate;
            ExecuteQuery("SPInsOSReciptHeadBankBackdate", objp);
        }

        public void InsRecptAginstInv4OSNew(int tranid, char rptype, int vouno, string voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string receiptfcurr, double receiptfamount, double receiptexrate, double receiptvamount, double recptfcamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
             new SqlParameter("@receiptfcurr", SqlDbType.VarChar, 3),
                 new SqlParameter("@receiptfamount", SqlDbType.Money , 8),
                  new SqlParameter("@receiptexrate", SqlDbType.Money , 8),
                new SqlParameter("@receiptvamount", SqlDbType.Money , 8),
                new SqlParameter("@recptfcamt",SqlDbType.Money,8)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = receiptfcurr;
            objp[10].Value = receiptfamount;
            objp[11].Value = receiptexrate;
            objp[12].Value = receiptvamount;
            objp[13].Value = recptfcamt;
            ExecuteQuery("SPInsReciptAgInv4OSNew", objp);
        }

        //Remittance Payment Cancel
        public void RemitncreciptPayCancl(int receiptno, int receiptid, char rptype, int vouyear, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@recno", SqlDbType.Int ),
                new SqlParameter("@receiptid", SqlDbType.Int ),
               new SqlParameter("@rptype", SqlDbType.Char,1),
               new SqlParameter("@vouyear", SqlDbType.Int  ),
                new SqlParameter("@branchid", SqlDbType.Int ),
               new SqlParameter("@dbname", SqlDbType.VarChar,20)};
            objp[0].Value = receiptno;
            objp[1].Value = receiptid;
            objp[2].Value = rptype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = dbname;
            ExecuteQuery("sp_remitncreciptPayCancl", objp);
        }
        
        public DataTable GetRecptPymtGrid(int tranid, string rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                        new SqlParameter("@rptype", SqlDbType.VarChar, 2)
                                                     };
            objp[0].Value = tranid;
            objp[1].Value = rptype;

            return ExecuteTable("SPGetRecptPymtGrid", objp);
        }

        // New For Trigger

        public void UpdRecptPymt4trigger(int rno, int bid, int vouyear, int empid, string rptype, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 2)
                                                     };
            objp[0].Value = rno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = empid;
            objp[4].Value = rptype;
            objp[5].Value = mode;

            ExecuteQuery("SPUpdRecptPymt4trigger", objp);
        }

        public void UpdOSRecptPymt4trigger(int rno, int bid, int vouyear, int empid, string rptype, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 2)
                                                     };
            objp[0].Value = rno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = empid;
            objp[4].Value = rptype;
            objp[5].Value = mode;

            ExecuteQuery("SPOSUpdRecptPymt4trigger", objp);
        }

        public DataTable GetRecptChrg(int rid,int tally)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
            new SqlParameter("@tally", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            objp[1].Value = tally;

            return ExecuteTable("SPGetRecptChrg", objp);
        }

        //from Journal jiid
        public DataTable GetjnrlRecptDtls(int customerid, int divisionid, string fadbname, string curr)          //NewOne //24/05/2022
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                       new SqlParameter("@Curr",SqlDbType.VarChar,20)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = fadbname;
            objp[3].Value = curr;
            return ExecuteTable("SPGetjnrlRecptDtlsNew", objp);
        }


        //NewOne //24/05/2022
        public void InsRecptAginstInvjid(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string jrefno, string jltype, int jlid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@jrefno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@jltype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@lid",SqlDbType.Int,4)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = jrefno;
            objp[10].Value = jltype;
            objp[11].Value = jlid;
            ExecuteQuery("SPInsReciptAgInvj", objp);
        }

        //NewOne    //24/06/2022
        public DataTable GetRecPaymCalcjnrl_Journal(int divisionid, string rpttype, string fadbname, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@rpttype", SqlDbType.VarChar, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                        new SqlParameter("@customer",SqlDbType.Int)};

            objp[0].Value = divisionid;
            objp[1].Value = rpttype;
            objp[2].Value = fadbname;
            objp[3].Value = customerid;
            return ExecuteTable("SPRecPaymCalcjnrl_journal", objp);
        }


        // New set for journal vino
        public void InsOSRecptAginstInvj(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string jrefno, string jltype,
            int lid, string fcur, double famt, double exrate, double fvamt, double fcamt)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                        new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                        new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                        new SqlParameter("@ravouyear", SqlDbType.Int),
                                                        new SqlParameter("@jrefno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@jltype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@lid", SqlDbType.Int, 4),
                                                        new SqlParameter("@fcur", SqlDbType.VarChar, 3),
                                                        new SqlParameter("@famt", SqlDbType.Money , 8),
                                                        new SqlParameter("@exrate", SqlDbType.Money , 8),
                                                        new SqlParameter("@fvamt", SqlDbType.Money , 8),
                                                        new SqlParameter("@fcamt", SqlDbType.Money , 8)
                                                    };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = jrefno;
            objp[10].Value = jltype;
            objp[11].Value = lid;
            objp[12].Value = fcur;
            objp[13].Value = famt;
            objp[14].Value = exrate;
            objp[15].Value = fvamt;
            objp[16].Value = fcamt;
            ExecuteQuery("SPInsOSReciptAgInvj", objp);
        }


        public DataTable GetOSjnrlRecptDtls(int customerid, int divisionid, string fadbname)          //NewOne //24/05/2022
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = fadbname;
            return ExecuteTable("SPGetOSjnrlRecptDtls", objp);
        }


        public void InsRecptAginstInv4OS1(int tranid, char rptype, int vouno, string voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string receiptfcurr, double receiptfamount, double receiptexrate, double receiptvamount, double recptfcamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
             new SqlParameter("@receiptfcurr", SqlDbType.VarChar, 3),
                 new SqlParameter("@receiptfamount", SqlDbType.Money , 8),
                  new SqlParameter("@receiptexrate", SqlDbType.Money , 8),
                new SqlParameter("@receiptvamount", SqlDbType.Money , 8),
                new SqlParameter("@recptfcamt",SqlDbType.Money,8)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = receiptfcurr;
            objp[10].Value = receiptfamount;
            objp[11].Value = receiptexrate;
            objp[12].Value = receiptvamount;
            objp[13].Value = recptfcamt;
            ExecuteQuery("SPInsReciptAgInv4OS1", objp);
        }

        ///// 07-12-2022 hari

        public DataTable GetOSRecptHead(int rno, int branchid, char mode, int vouyear, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) ,
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rno;
            objp[1].Value = branchid;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            objp[4].Value = rptype;
            return ExecuteTable("SPGetOSRecptHead_new_07", objp);
        }

        public void InsRecptAginstInv4OS_new(int tranid, char rptype, int vouno, string voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string receiptfcurr, double receiptfamount, double receiptexrate, double receiptvamount, double recptfcamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
             new SqlParameter("@receiptfcurr", SqlDbType.VarChar, 3),
                 new SqlParameter("@receiptfamount", SqlDbType.Money , 8),
                  new SqlParameter("@receiptexrate", SqlDbType.Money , 8),
                new SqlParameter("@receiptvamount", SqlDbType.Money , 8),
                new SqlParameter("@recptfcamt",SqlDbType.Money,8)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = receiptfcurr;
            objp[10].Value = receiptfamount;
            objp[11].Value = receiptexrate;
            objp[12].Value = receiptvamount;
            objp[13].Value = recptfcamt;
            ExecuteQuery("SPInsReciptAgInv4OS", objp);
        }

        public void InsOSReciptChargeDetail(int rid, int chargeid, double amount, double fcamt, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@rid",SqlDbType.Int ,4),
                                                                             new SqlParameter ("@chargeid",SqlDbType.Int,4),
                                                                             new SqlParameter("@amount",SqlDbType.Money,8),
                new SqlParameter("@fcamt",SqlDbType.Money,8),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            objp[3].Value = fcamt;
            objp[4].Value = rptype;
            ExecuteQuery("SPInsOSReciptchargeDetails_new_07", objp);
        }

        public DataTable GetOSRecptCust(int rid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
            new SqlParameter("@rptype",SqlDbType.Char,1) };
            objp[0].Value = rid;
            objp[1].Value = rptype;

            return ExecuteTable("SPGetOSRecptCust_new_07", objp);
        }

        //public DataTable GetRAInvoiceToShow4OS(int tranid, char rptype)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
        //                                               new SqlParameter("@rptype", SqlDbType.Char, 1)};
        //    objp[0].Value = tranid;
        //    objp[1].Value = rptype;
        //    return ExecuteTable("SPGetRecpAgnsInv4OS", objp);
        //}

        public DataTable GetRAInvoiceToShow4OS_new_07(int tranid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            return ExecuteTable("SPGetRecpAgnsInv4OS_new_07", objp);
        }

        public void DelCustChrgsOS(int rid, int ccid, string type, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid",SqlDbType.Int,4),
                                                       new SqlParameter("@ccid",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2),
            new SqlParameter("@rptype",SqlDbType.Char,1) };
            objp[0].Value = rid;
            objp[1].Value = ccid;
            objp[2].Value = type;
            objp[3].Value = rptype;
            ExecuteQuery("SPDelCustChargOS_new_07", objp);
        }

        public void UpdRecptCustAmtOS(int rid, int custid, double amount, double fcamt, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
                                                       new SqlParameter("@customer", SqlDbType.Int, 4),
                                                       new SqlParameter("@amount", SqlDbType.Money, 8),
                                                       new SqlParameter("@fcamt", SqlDbType.Money, 8),
            new SqlParameter("@rptype",SqlDbType.Char,1)};
            objp[0].Value = rid;
            objp[1].Value = custid;
            objp[2].Value = amount;
            objp[3].Value = fcamt;
            objp[4].Value = rptype;
            ExecuteQuery("SPUpdReciptcustomerAmtOS_new_07", objp);
        }

        public DataTable GetRecptChrgOS(int rid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4),
            new SqlParameter("@rptype",SqlDbType.Char,1) };
            objp[0].Value = rid;
            objp[1].Value = rptype;
            return ExecuteTable("SPGetRecptChrgOS_new_07", objp);
        }

        public void InsRecptAginstInv4OSAdjDCN(int tranid, char rptype, int vouno, string voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string receiptfcurr, double receiptfamount, double receiptexrate, double receiptvamount, double recptfcamt, string jltype, int jlid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@receiptfcurr", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@receiptfamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@receiptexrate", SqlDbType.Money , 8),
                                                       new SqlParameter("@receiptvamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@recptfcamt",SqlDbType.Money,8),
                                                       new SqlParameter("@jltype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@jlid", SqlDbType.Int, 4)
            };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = receiptfcurr;
            objp[10].Value = receiptfamount;
            objp[11].Value = receiptexrate;
            objp[12].Value = receiptvamount;
            objp[13].Value = recptfcamt;
            objp[14].Value = jltype;
            objp[15].Value = jlid;
            ExecuteQuery("SPInsReciptAgInv4OSAdjDCN", objp);
        }

        //From Invoice       //NewOne       //08/08/2022
        public DataTable GetInvRecptDtls1NewOne(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetInvRecptDtls1newone", objp);
        }

        //From DN           //NewOne       //08/08/2022
        public DataTable GetDNNewOne(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetDNforReceiptsNewone", objp);
        }

        //From Admin DN     //NewOne       //08/08/2022
        public DataTable GetAdminDNNewone(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetAdmDNforReceiptsNewOne", objp);
        }

        //From OSDN      //NewOne       //08/08/2022
        public DataTable GetOSDNnewone(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetOSDNforReceiptnewone", objp);
        }

        //from Journal      //NewOne       //08/08/2022
        public DataTable GetjnrlRecptDtlsNewOne(int customerid, int divisionid, string fadbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = fadbname;
            return ExecuteTable("SPGetjnrlRecptDtlsNewOne", objp);
        }

        //From BOS      //NewOne       //08/08/2022
        public DataTable GetInvRecptDtls1BOSNewOne(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetInvRecptDtls1BOSNewOne", objp);
        }


        //////////////////////////////////

        public void InsRecptHeadCash_new(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby)
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
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            ExecuteQuery("SPInsReciptHeadcash_new", objp);
        }
        public void InsRecptHeadCash(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby, string fcurr, double fcamt, double exrate)
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
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
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
            ExecuteQuery("SPInsReciptHeadcashNewRP_new", objp);
        }
        public void InsRecptHeadBank(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, string fcurr, double fcamt, double exrate, string neft)
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
                                                       new SqlParameter("@fcurr", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@fcamt", SqlDbType.Money),
                                                       new SqlParameter("@exrate", SqlDbType.Money),
            new SqlParameter("@neft",SqlDbType.VarChar,2)};
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
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
            objp[13].Value = fcurr;
            objp[14].Value = fcamt;
            objp[15].Value = exrate;
            objp[16].Value = neft;
            ExecuteQuery("SPInsReciptHeadBankNewRP_new", objp);
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
            ExecuteQuery("SPInsPaymentHeadBankNewRP_new", objp);
        }
        public DataTable GetRAInvoiceToShowNew(int tranid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            return ExecuteTable("SPGetRecpAgnsInvNew_new", objp);
        }


        public DataTable GetInvRecptDtls_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@curr", SqlDbType.VarChar, 3) ,
                                                     new SqlParameter("@ledgerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            //return ExecuteTable("SPRecPaymCalc", objp);//SPGetInvRecptDtls
            return ExecuteTable("SPRecPaymCalc_testSK", objp);//SPGetInvRecptDtls
        }
        public DataTable GetInvRecptDtlssingabdul_new(int customerid, int divisionid, string rpttype, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@rpttype", SqlDbType.VarChar, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)   };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = rpttype;
            objp[3].Value = curr;
            objp[4].Value = ledgerid;

            //return ExecuteTable("SPRecPaymCalcSingabdul", objp);//SPGetInvRecptDtls
            return ExecuteTable("SPRecPaymCalcSingabdul_testSK", objp);//SPGetInvRecptDtls
        }
        public DataTable GetRecPaymCalcjnrl_new(int customerid, int divisionid, string rpttype, string fadbname, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@rpttype", SqlDbType.VarChar, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                       new SqlParameter("@curr",SqlDbType.VarChar,20),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = rpttype;
            objp[3].Value = fadbname;
            objp[4].Value = curr;
            objp[5].Value = ledgerid;
            //return ExecuteTable("SPRecPaymCalcjnrl", objp);//SPGetInvRecptDtls
            return ExecuteTable("SPRecPaymCalcjnrl_testSK", objp);//SPGetInvRecptDtls
        }
        public DataTable GetInvRecptDtls1sing_newFC(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)   };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            return ExecuteTable("SPGetInvRecptDtls1sing_testSKFC", objp);
        }
        public DataTable GetInvRecptDtls1_newFC(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetInvRecptDtls1", objp);
            return ExecuteTable("SPGetInvRecptDtls1_testSKFC", objp);
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
        public DataTable GetBOSRecptDtls1sing_newFC(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)   };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            return ExecuteTable("SPGetBOSRecptDtls1sing_testSKFC", objp);
        }

        public DataTable GetBOSRecptDtls1_newFC(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetInvRecptDtls1", objp);
            return ExecuteTable("SPGetBOSRecptDtls1_testSKFC", objp);
        }
        public DataTable GetInvRecptDtls1sing_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)   };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            return ExecuteTable("SPGetInvRecptDtls1sing_testSK", objp);
        }

        public DataTable GetInvRecptDtls1_new(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetInvRecptDtls1", objp);
            return ExecuteTable("SPGetInvRecptDtls1_testSK", objp);
        }
        public DataTable GetDNsing_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;

            return ExecuteTable("SPGetDNforReceiptssing_testSK", objp);
        }

        public DataTable GetDN_new(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                    new SqlParameter("@ledgerid", SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            return ExecuteTable("SPGetDNforReceipts_testSK", objp);
        }
        public DataTable GetadminDNsing_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;

            //return ExecuteTable("SPGetadminDNforReceiptssing", objp);

            return ExecuteTable("SPGetadminDNforReceiptssing_testSK", objp);
        }

        public DataTable GetAdminDN_new(int customerid, int divisionid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = ledgerid;
            //return ExecuteTable("SPGetAdmDNforReceipts", objp);
            return ExecuteTable("SPGetAdmDNforReceipts_testSK", objp);
        }
        public DataTable GetjnrlRecptDtlsnew_new(int customerid, int divisionid, string fadbname, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                       new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = fadbname;
            objp[3].Value = curr;
            objp[4].Value = ledgerid;
            //return ExecuteTable("SPGetjnrlRecptDtlsnew", objp);
            return ExecuteTable("SPGetjnrlRecptDtlsnew_testSK", objp);
        }
        public void InsRecptAginstInvj(int tranid, char rptype, int vouno, string voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string jrefno, string jltype, int custid, int ledgid, string curr, double exrate, double famount, double rfamount)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                        new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                        new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                        new SqlParameter("@ravouyear", SqlDbType.Int),
                                                        new SqlParameter("@jrefno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@jltype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@cid",SqlDbType.Int),
                                                        new SqlParameter("@lid",SqlDbType.Int),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@exrate",SqlDbType.Money, 8),
                                                        new SqlParameter("@famount",SqlDbType.Money, 8),
                                                        new SqlParameter("@rfamount",SqlDbType.Money, 8)
                                                     };

            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = jrefno;
            objp[10].Value = jltype;
            objp[11].Value = custid;
            objp[12].Value = ledgid;
            objp[13].Value = curr;
            objp[14].Value = exrate;
            objp[15].Value = famount;
            objp[16].Value = rfamount;
            ExecuteQuery("SPInsReciptAgInvjNewRP_new", objp);
        }

        public void InsRecptAginstInv(int tranid, char rptype, int vouno, string voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string fcurr, double famount, double exrate, double rfamount)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@fcurr", SqlDbType.VarChar,5),
                                                       new SqlParameter("@famount", SqlDbType.Money, 8),
                                                       new SqlParameter("@exrate", SqlDbType.Money, 8),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8)  };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = fcurr;
            objp[10].Value = famount;
            objp[11].Value = exrate;
            objp[12].Value = rfamount;

            ExecuteQuery("SPInsReciptAgInvNEWRP_new", objp);
        }
        public void InsReciptChargeDetail(int rid, int chargeid, double amount, string exchrge)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@rid",SqlDbType.Int ,4),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@faexgl",SqlDbType.VarChar,3)
                                                     };
            objp[0].Value = rid;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            objp[3].Value = exchrge;

            ExecuteQuery("SPInsReciptchargeDetails_new", objp);
        }
        public DataTable RecPaymCalc4OBBreakup_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@curr", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@ledgerid", SqlDbType.Int)
                                                      };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;

            //return ExecuteTable("SPRecPaymCalc4OBBreakup", objp);//SPGetInvRecptDtls
            return ExecuteTable("SPRecPaymCalc4OBBreakup_testSK", objp);//SPGetInvRecptDtls
        }
        public DataTable GetOBRecptDtls_new(int customerid, int divisionid, string curr, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@curr", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@ledgerid", SqlDbType.Int)
                                                     };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            objp[2].Value = curr;
            objp[3].Value = ledgerid;
            //return ExecuteTable("SPGetOBRecptDtls", objp);
            return ExecuteTable("SPGetOBRecptDtls_testSK", objp);
        }

        public DataTable FAYEAR(int div, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@did",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = div;
            objp[1].Value = bid;
            //return ExecuteTable("SPGetOBRecptDtls", objp);
            return ExecuteTable("sp_FAYEAR", objp);
        }
        public DateTime GetOSRPMaxDate(int bid, string type, string mode, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.Int,4),
                                                        new SqlParameter("@rptype", SqlDbType.VarChar,1),
                                                        new SqlParameter("@mode", SqlDbType.VarChar, 1),
                                                        new SqlParameter("@vouyear", SqlDbType.Int,4)};
            objp[0].Value = bid;
            objp[1].Value = type;
            objp[2].Value = mode;
            objp[3].Value = vouyear;
            return DateTime.Parse(ExecuteReader("SPGetRPMaxDateos", objp));
        }
        //////////////////////////////////
        public DataTable GetInvRecptDtlslv(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPRecPaymCalclv", objp);//SPGetInvRecptDtls  SPRecPaymCalc4adj
        }

        public DataTable GetlvRecptDtls1(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetlvRecptDtls", objp);
        }
        public DataTable GetOSlvRecptDtlsLedger(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPOSRecPaymCalcLedgerlv", objp);//SPGetInvRecptDtls
        }
        public DataTable Getall4OSLedgerlv(int ledgerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetlvforReceipt4OSLedger", objp);
        }
        public DataTable GetlvRecptDtls1new(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPGetlvRecptDtls1", objp);
        }
        // Vino New for OPBal Breakup St [09-04-2024]
        public void InsFARectPmtNew(int ledgerid, int vouno, DateTime voudate, string voutype, int vouyear, int branchid, double vouamonut, string fcurr, double famount,
           int tranyear, double tranamount, string tranfcurr, double tranfamount, string settled, int customerid, double exrate, string vendorrefno, DateTime vendorrefdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voudate", SqlDbType.DateTime , 8),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar,3),
                                                        new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@fcurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@famount", SqlDbType.Money , 8),
                                                        new SqlParameter("@tranyear", SqlDbType.Int , 4),
                                                       new SqlParameter("@tranamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@tranfcurr", SqlDbType.VarChar , 3),
                                                         new SqlParameter("@tranfamount", SqlDbType.Money, 8),
                                                        new SqlParameter("@settled",SqlDbType.VarChar,1),
                                                        new SqlParameter("@customerid",SqlDbType.Int ),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@vendorrefno", SqlDbType.VarChar , 30),
                                                        new SqlParameter("@vendorrefdate", SqlDbType.DateTime , 8)

                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vouamonut;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = tranyear;
            objp[10].Value = tranamount;
            objp[11].Value = tranfcurr;
            objp[12].Value = tranfamount;
            objp[13].Value = settled;
            objp[14].Value = customerid;
            objp[15].Value = exrate;
            objp[16].Value = vendorrefno;
            objp[17].Value = vendorrefdate;

            ExecuteQuery("insFARectPmtNew4OPBal", objp);
        }

        // Vino New for OPBal Breakup End [09-04-2024]


    }
}




    
