using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Accounts
{
    public class Approval : DBObject
    {

        DataAccess.Masters.MasterEmployee Empobj = new DataAccess.Masters.MasterEmployee();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Approval()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable FillDt(string ftype, string strTrantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar,50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int)};
            objp[0].Value = ftype;
            objp[1].Value = strTrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPApprove", objp);
        }

        public DataTable FillDtPenTransferFA(string ftype, string strTrantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar,20),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int)};
            objp[0].Value = ftype;
            objp[1].Value = strTrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPApprovedAndPenTransferFA", objp);
        }

        public int GetPenFATrans(string ftype, string strTrantype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar,20),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int)};
            objp[0].Value = ftype;
            objp[1].Value = strTrantype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            //return ExecuteTable("SPApprove", objp);
            return int.Parse(ExecuteReader("SPPenFATrans", objp));
        }

        public DataTable view_invoicecnops(int pano, int jobno, int branchid, int vouyear, string type)
        {
            SqlParameter[] array = new SqlParameter[5]
            {
            new SqlParameter("@pano", SqlDbType.Int),
            new SqlParameter("@jobno", SqlDbType.Int),
            new SqlParameter("@branchid", SqlDbType.Int),
            new SqlParameter("@vouyear", SqlDbType.Int),
            new SqlParameter("@type", SqlDbType.VarChar, 30)
            };
            array[0].Value = pano;
            array[1].Value = jobno;
            array[2].Value = branchid;
            array[3].Value = vouyear;
            array[4].Value = type;
            IDataParameter[] array2 = array;
            IDataParameter[] parameters = array2;
            return ExecuteTable("sp_view_invoicecnops", parameters);
        }

        public void UpdApproval(int invoiceno, string strblno, int approveid, string trantype, string ftype, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,50),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = strblno;
            objp[2].Value = approveid;
            objp[3].Value = trantype;
            objp[4].Value = ftype;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            ExecuteQuery("SPUpdApproval", objp);
        }

        public void UpdCosting(int invno, string blno, string trantype, string ftype, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30)};
            objp[0].Value = invno;
            objp[1].Value = trantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = blno;
            ExecuteQuery("SPInvWNo", objp);
        }
        //Pro Invoice
        //public DataTable FillDt4Pro(string strTrantype, int branchid)
        //{

        //    SqlParameter[] objp = new SqlParameter[] { 
        //                                               new SqlParameter("@trantype", SqlDbType.VarChar,4),
        //                                               new SqlParameter("@branchid", SqlDbType.Int),
        //                                               };

        //    objp[0].Value = strTrantype;
        //    objp[1].Value = branchid;
        //    return ExecuteTable("SPProApprove", objp);
        //}
        //Manoj
        public DataTable FillDt4Pro(string strTrantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,35)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            return ExecuteTable("SPProApprove", objp);
        }
        //public void UpdProApproval(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
        //                                             new SqlParameter("@blno",SqlDbType.VarChar,30), 
        //                                             new SqlParameter("@approvedby",SqlDbType.Int,4),
        //                                             new SqlParameter("@trantype",SqlDbType.VarChar,4),
        //                                             new SqlParameter("@vouyear",SqlDbType.Int),
        //                                             new SqlParameter("@branchid",SqlDbType.TinyInt,1),
        //                                             new SqlParameter("@invoiceno",SqlDbType.Int,4)
        //                                             };
        //    objp[0].Value = refno;
        //    objp[1].Value = strblno;
        //    objp[2].Value = approvedby;
        //    objp[3].Value = trantype;
        //    objp[4].Value = vouyear;
        //    objp[5].Value = branchid;
        //    objp[6].Value = invoiceno;
        //    ExecuteQuery("SPUpdProApproval", objp);
        //}

        //mANOJ
        public void UpdProApproval(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = invoiceno;
            objp[7].Value = type;
            ExecuteQuery("SPUpdProApproval", objp);

        }




        public DataTable FillDtforProDCNApprove(string type, string strTrantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.VarChar,50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int)};
            objp[0].Value = type;
            objp[1].Value = strTrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetProDCNdetails", objp);
        }
        public int GetNoforAcForApproval(int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type",SqlDbType.VarChar,50)};
            objp[0].Value = branchid;
            objp[1].Value = type;
            return int.Parse(ExecuteReader("SPUpdMCForProApproval", objp));
        }
        //Nambi
        public int UpdProApprovalOSDCN(int refno, int strblno, int approvedby, string trantype, int vouyear, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.Int,4), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     //new SqlParameter("@dcno",SqlDbType.Int,4),
                 new SqlParameter("@type",SqlDbType.VarChar,50),
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            // objp[6].Value = dcno;
            objp[6].Value = type;
            //ExecuteQuery("SPUpdProApprovalOSDCN", objp);
            //return int.Parse(ExecuteReader("SPUpdProApprovalOSDCN", objp));

            return int.Parse(ExecuteReader("SPUpdProApprovalOSDCNnew", objp));
        }


        //GetAgentCustomerOrNot
        public DataTable GetAgentCustomerOrNot(int vouno, int vouyear, int branchid, string voutype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar,2)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            return ExecuteTable("SPGetAgentCustomerOrNot", objp);
        }


        //Ledger Breakup insert FARectPet Nambi

        public void InsLedgerOPBreakup(int ledgerid, int vouno, DateTime voudate, char voutype, int vouyear, int bid, double vouamount, string fcurr, double famount, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ledgerid",SqlDbType.Int,4),        
                                                     new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                     new SqlParameter("@voudate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@vouamount",SqlDbType.Money,8),
                                                     new SqlParameter("@fcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@famount",SqlDbType.Money,8),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = bid;
            objp[6].Value = vouamount;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = customerid;
            ExecuteQuery("SPInsLedgerOPBreakup", objp);
        }



        public void UpdLedgerOPBreakup(int vouno, char voutype, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, string tranfcurr, double tranfamount, string jnlrefno, string jnltype)
        {
            SqlParameter[] objp = new SqlParameter[] {   
                                                     new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranfcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,15),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,15),
                                                                                                         
                                                     };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = tranid;
            objp[5].Value = trantype;
            objp[6].Value = tranyear;
            objp[7].Value = tranamount;
            objp[8].Value = tranfcurr;
            objp[9].Value = tranfamount;
            objp[10].Value = jnlrefno;
            objp[11].Value = jnltype;
            ExecuteQuery("SPUpdLedgerOPBreakup", objp);
        }

        public DataTable SelRECTPMT(int vouno, string voutype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelRECTPMT", objp);
        }

        public void InsLedgerOPBreakup4OAC(int ledgerid, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ledgerid",SqlDbType.Int,4),        
                                                      new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     };
            objp[0].Value = ledgerid;
            objp[1].Value = vouyear;
            objp[2].Value = bid;
            objp[3].Value = tranid;
            objp[4].Value = trantype;
            objp[5].Value = tranyear;
            objp[6].Value = tranamount;
            objp[7].Value = customerid;

            ExecuteQuery("SPInsLedgerOPBreakup4OAC", objp);
        }


        public void UpdProApprovalBackD(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno, string type, DateTime approvedon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@approvedon",SqlDbType.DateTime)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = invoiceno;
            objp[7].Value = type;
            objp[8].Value = approvedon;
            ExecuteQuery("SPUpdProApprovalBackD", objp);
        }

        public void UpdProApprovalBack(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno, string type, DateTime approvedon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                     new SqlParameter ("@approvedon",SqlDbType.DateTime)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = invoiceno;
            objp[7].Value = type;
            objp[8].Value = approvedon;
            ExecuteQuery("SPUpdProApprovalBack", objp);
        }

        public DataTable FillDtforProDCNApproveBack(string type, string strTrantype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.VarChar,50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int )
            };
            objp[0].Value = type;
            objp[1].Value = strTrantype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetProDCNBackdetails", objp);
        }
        public int GetNoforAcForApprovalBackD(int branchid, string type, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type",SqlDbType.VarChar,30),
                 new SqlParameter("@vouyear",SqlDbType.Int )
            };
            objp[0].Value = branchid;
            objp[1].Value = type;
            objp[2].Value = vouyear;
            return int.Parse(ExecuteReader("SPUpdMCForProApprovalBackD", objp));
        }
        public int GetNoforAcForApprovalBack(int branchid, string type, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type",SqlDbType.VarChar,30),
                 new SqlParameter("@vouyear",SqlDbType.Int) };
            objp[0].Value = branchid;
            objp[1].Value = type;
            objp[2].Value = vouyear;
            return int.Parse(ExecuteReader("SPUpdMCForProApprovalBack", objp));
        }
        public int UpdProApprovalOSDCNBackD(int refno, int strblno, int approvedby, string trantype, int vouyear, int branchid, string type, DateTime approvedon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.Int,4), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     //new SqlParameter("@dcno",SqlDbType.Int,4),
                 new SqlParameter("@type",SqlDbType.VarChar,50),
                 new SqlParameter("@approvedon",SqlDbType.DateTime )
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            // objp[6].Value = dcno;
            objp[6].Value = type;
            objp[7].Value = approvedon;
            //ExecuteQuery("SPUpdProApprovalOSDCN", objp);
            return int.Parse(ExecuteReader("SPUpdProApprovalOSDCNBackD", objp));
        }

        public DataTable FillDt4ProBackdated(string strTrantype, int branchid, string type, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@vouyear",SqlDbType.VarChar,30)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            objp[3].Value = vouyear;
            return ExecuteTable("SPProApproveBackdated", objp);
        }
        public DataTable GetAccountantMailID(int branchid, int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int)
                                                       };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("SP_GetAccountantMail", objp);
        }
        public DataTable UpdateAccountantMailID(int branchid, int divisionid, string str_Mail)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                 new SqlParameter("@mail",SqlDbType.VarChar,100)
                                                       };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = str_Mail;
            return ExecuteTable("SP_UpdateAccountantMail", objp);
        }

        public void insprosharevou(int bid, string voutype, int vouno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar,5),
                  new SqlParameter("@vouno", SqlDbType.Int),
                  new SqlParameter("@vouyear", SqlDbType.Int),
                                                       };
            objp[0].Value = bid;
            objp[1].Value = voutype;
            objp[2].Value = vouno;
            objp[3].Value = vouyear;
            ExecuteQuery("SPinsprofitsharevou", objp);

        }
        //By ManiG

        public DataTable GetPenUnClose(string strTrantype, int branchid, int divid, int empid)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),                                                                                                            
                                                          new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1),
             new SqlParameter("@empid", SqlDbType.Int ,4)};
            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = divid;
            objp[3].Value = empid;

            return ExecuteTable("SPGETUncloseJobs", objp);

        }

        //Elakkiya

        public DataTable GetDebitSTCheckAmt(int refno, int bid, int vyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                          new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int) };

            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vyear;

            return ExecuteTable("SPCheckDebitSTNew", objp);
        }
        public DataTable GetInvoiceAppSTCheckAmt(int refno, int bid, int vyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                          new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int) };

            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vyear;

            return ExecuteTable("SPGetSTChagersInv", objp);
        }

        //Karthika_K

        public void InsLedgerOPBreakup4DirPay(int ledgerid, DateTime voudate, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ledgerid",SqlDbType.Int,4), 
                                                     new SqlParameter("@voudate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     };
            objp[0].Value = ledgerid;
            objp[1].Value = voudate;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = tranid;
            objp[5].Value = trantype;
            objp[6].Value = tranyear;
            objp[7].Value = tranamount;
            objp[8].Value = customerid;

            ExecuteQuery("SPInsLedgerOPBreakup4DirPay", objp);
        }



        public void UpdJnlDtls2FARP(int custid, char voutype, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, string tranfcurr, double tranfamount, string jnlrefno, string jnltype)
        {
            SqlParameter[] objp = new SqlParameter[] {   
                                                     new SqlParameter("@custid",SqlDbType.Int,4), 
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranfcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,15),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,15),
                                                                                                         
                                                     };
            objp[0].Value = custid;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = tranid;
            objp[5].Value = trantype;
            objp[6].Value = tranyear;
            objp[7].Value = tranamount;
            objp[8].Value = tranfcurr;
            objp[9].Value = tranfamount;
            objp[10].Value = jnlrefno;
            objp[11].Value = jnltype;
            ExecuteQuery("spupdfarcjnrl", objp);
        }




        public void UpdLedgerOPBreakup4oldvou(int ledgerid, int vouno, char voutype, int vouyear, int bid, double vouamount, string fcurr, double famount, int tranid, char trantype, int tranyear, double tranamount, string tranfcurr, double tranfamount, string jnlrefno, string jnltype, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ledgerid",SqlDbType.Int,4),        
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),    
                                                     //new SqlParameter("@voudate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@vouamount",SqlDbType.Money,8),
                                                     new SqlParameter("@fcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@famount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranfcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,15),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,15),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),                                                     
                                                     };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            //objp[2].Value = voudate;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;
            objp[4].Value = bid;
            objp[5].Value = vouamount;
            objp[6].Value = fcurr;
            objp[7].Value = famount;
            objp[8].Value = tranid;
            objp[9].Value = trantype;
            objp[10].Value = tranyear;
            objp[11].Value = tranamount;
            objp[12].Value = tranfcurr;
            objp[13].Value = tranfamount;
            objp[14].Value = jnlrefno;
            objp[15].Value = jnltype;
            objp[16].Value = customerid;
            ExecuteQuery("SPUpdLedgerOPBreakup4oldvou", objp);
        }

        //ARUN

        public DataTable GetPendingUnclose_Job(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@bid",SqlDbType.Int)};
            objp[0].Value = branchid;


            return ExecuteTable("SpGetUnclosed_Counts", objp);

        }

        public DataTable GetPenUnCloseForNew(string strTrantype, int branchid, int divid, int empid)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),                                                                                                            
                                                          new SqlParameter("@bid",SqlDbType.Int),
                                                        new SqlParameter("@cid",SqlDbType.Int),
             new SqlParameter("@empid", SqlDbType.Int)};
            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = divid;
            objp[3].Value = empid;

            return ExecuteTable("SPGETUncloseJobsForNew", objp);
        }

        //GST

        //RAJ

        public void UpdProApproval4Cnops(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = invoiceno;
            objp[7].Value = type;
            ExecuteQuery("SPUpdProApproval4cnopsnew", objp); //SPUpdProApproval4cnopsnew
        }

        public int GetNoforAcForApproval4cnops(int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type",SqlDbType.VarChar,30)};
            objp[0].Value = branchid;
            objp[1].Value = type;
            return int.Parse(ExecuteReader("SPUpdMCForProApprovalback4cnops", objp));
        }

        //GST 
        //ARUN
        public void insForOSDNCNDNCNNumber(int refno, string type, int branchid, int jobno, string trantype, int refno2)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dncnnum", SqlDbType.Int),
            new SqlParameter("@type",SqlDbType.VarChar,30),
            new SqlParameter("@branchid",SqlDbType.Int),
            new SqlParameter("@jobno",SqlDbType.Int),
              new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@refno", SqlDbType.Int),};
            objp[0].Value = refno;
            objp[1].Value = type;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = refno2;
            ExecuteReader("SPUpdOSDNCNNumerForNew", objp);
        }
        //RUBAN
        //public String CHKVoucher(int vouid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouid", SqlDbType.BigInt) };
        //    objp[0].Value = vouid;
        //    return ExecuteReader("SPChkLedgerAmount", objp);
        //}

        public String CHKVoucher(int vouid, string DBname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouid", SqlDbType.BigInt) ,
                                                       new SqlParameter("@DBname", SqlDbType.VarChar,20) };
            objp[0].Value = vouid;
            objp[1].Value = DBname;
            return ExecuteReader("SPChkLedgerAmount", objp);
        }


        //MUTHU RAJ
        public int UpdProApprovalnew(string type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedinvoiceautomatic", objp, "@invno");
        }
        public String CHKVoucher(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECk", objp);
        }
        public String CHKVoucherinvgen(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkinvgen", objp);
        }

        //Dinesh
        public DataTable FillDt4Pronew(string strTrantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            //return ExecuteTable("SPProApprovenew", objp);
            //  return ExecuteTable("SPProApprovenewnew", objp);
            return ExecuteTable("SPProApprovenewnew1", objp);
        }


        //dINESH
        public void UpdProApprovalNEW(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = invoiceno;
            objp[7].Value = type;
            ExecuteQuery("SPUpdProApprovalnew", objp);
        }

        public DataTable SPFAJouRefChkng(string dbname, string refno, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@refno",SqlDbType.VarChar,500),
                                                        new SqlParameter("@vouid",SqlDbType.BigInt)};

            objp[0].Value = dbname;
            objp[1].Value = refno;
            objp[2].Value = vouid;

            return ExecuteTable("SPFAJouRefChkng", objp);
        }


        public void InsLedgerOPBreakup4OACOS(int ledgerid, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, int customerid, string tranfcurr, double tranfamount)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ledgerid",SqlDbType.Int,4),        
                                                      new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@tranfcurr",SqlDbType.VarChar,3),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8)
                                                     };
            objp[0].Value = ledgerid;
            objp[1].Value = vouyear;
            objp[2].Value = bid;
            objp[3].Value = tranid;
            objp[4].Value = trantype;
            objp[5].Value = tranyear;
            objp[6].Value = tranamount;
            objp[7].Value = customerid;
            objp[8].Value = tranfcurr;
            objp[9].Value = tranfamount;

            ExecuteQuery("SPInsLedgerOPBreakup4OACOS", objp);
        }


        //Manual DCN Dtls 2 FARECTPMT
        public void SPInsLedgerOPBreakup4MDCN(int ledgerid, int vouno, DateTime voudate, string voutype, int vouyear, int bid, double vouamount, string fcurr, double famount, string jnlrefno, string jnltype, int customerid, char opstype, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ledgerid",SqlDbType.Int,4),        
                                                     new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                     new SqlParameter("@voudate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@voutype",SqlDbType.Char,3),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@vouamount",SqlDbType.Money,8),
                                                     new SqlParameter("@fcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@famount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,15),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,2),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@opstype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouid",SqlDbType.Int,4),
                                                     };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = bid;
            objp[6].Value = vouamount;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = jnlrefno;
            objp[10].Value = jnltype;
            objp[11].Value = customerid;
            objp[12].Value = opstype;
            objp[13].Value = vouid;
            ExecuteQuery("SPInsLedgerOPBreakup4MDCN", objp);
        }

        public void DelMDCNDtls2FARP(int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@vouid",SqlDbType.Int),
                                                    };


            objp[0].Value = vouid;
            ExecuteQuery("spdelfarcmdcn", objp);

        }

        public void InsJnlDtls2FARPProVou(int vouid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@vouid",SqlDbType.Int),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    };


            objp[0].Value = vouid;
            objp[1].Value = dbname;
            ExecuteQuery("spinsfarcjnrlProvou", objp);

        }

        public DataTable getinterbranchvoucher(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {  new SqlParameter("@div",SqlDbType.Int),
                                                       
            };
            objp[0].Value = divisionid;
            return ExecuteTable("sp_interbranchvoutransfer", objp);
        }
        public void getediupdatevoucher(int vouno, string voutype, int bid, int vouyear, int cutstid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {  
                new SqlParameter("@vouno",SqlDbType.Int),
                new SqlParameter("@vouchertype",SqlDbType.VarChar,10),
                new SqlParameter("@bid",SqlDbType.Int),
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@agecuts",SqlDbType.Int),
                                                       
            };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = bid;
            objp[3].Value = vouyear;
            objp[4].Value = cutstid;

            ExecuteQuery("sp_updateapprovededi", objp);
        }



        //Sinosh

        public string chkrcm(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteReader("SPChkRCM", objp);
        }


        //Dinesh
        public DataTable FillDt4ProTDS(string strTrantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            //return ExecuteTable("SPProApproveTDS", objp);
            //return ExecuteTable("SPProApproveTDSnew", objp);

            return ExecuteTable("SPProApproveTDSnewnewlawrence", objp);
        }
        public String CHKVoucherbos(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkbos", objp);
        }

        public int UpdProApprovalnewbos(string type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedinvoiceautomaticbos", objp, "@invno");
        }



        //DINESH
        public DataTable FillDtforProDCNApproveTDS(string type, string strTrantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.VarChar,50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int,4)};
            objp[0].Value = type;
            objp[1].Value = strTrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetProDCNdetailsTDS", objp);
        }




        public void updbosafterjobclse(int invoiceno, int year, int branchid, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[]                                 {
                                                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vyear",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,10)
                                                                                   
                                                                             
                                                                                  
                                                                                     };
            objp[0].Value = invoiceno;
            objp[1].Value = year;
            objp[2].Value = branchid;
            objp[3].Value = trantype;



            ExecuteQuery("sp_bosafterjobclse", objp);

        }

        //Get Voucher Amount For TDS Calculation
        public double GetVoucherAmount4TDS(int vouno, int branchid, int vouyear, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@type",SqlDbType.Char,1)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = type;

            return double.Parse(ExecuteReader("GetVouAmt4TDSnew", objp));
        }
        public void UpdLedgerOPBreakupnew(int vouno, string voutype, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, string tranfcurr, double tranfamount, string jnlrefno, string jnltype)
        {
            SqlParameter[] objp = new SqlParameter[] {   
                                                     new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                     new SqlParameter("@voutype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranfcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,15),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,15),
                                                                                                         
                                                     };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = tranid;
            objp[5].Value = trantype;
            objp[6].Value = tranyear;
            objp[7].Value = tranamount;
            objp[8].Value = tranfcurr;
            objp[9].Value = tranfamount;
            objp[10].Value = jnlrefno;
            objp[11].Value = jnltype;
            ExecuteQuery("SPUpdLedgerOPBreakup", objp);
        }

        public int getacosdncnamoutcheck(string trantype, int branchid, int prodn, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@trantype",SqlDbType.VarChar,35),        
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@prodn",SqlDbType.Int,4),
                                                        new SqlParameter("@type", SqlDbType.VarChar,75)
              };
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = prodn;
            objp[3].Value = type;

            return int.Parse(ExecuteReader("spacosdncnamoutcheck", objp));
        }

        //Get Customer Total Amount & Limit
        public DataTable GetCustAmtLimt(int customerid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid",SqlDbType.Int,4)};

            objp[0].Value = customerid;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetTdslimitpercentfromCustomer", objp);
        }

        public DataTable getdebitadviseactamtcheck(int vouyear, int refno, int branchid, int jobno, string trantype, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {       
                                                        new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                        new SqlParameter("@refno",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,35), 
                                                         new SqlParameter("@voutype",SqlDbType.VarChar,35)
              };
            objp[0].Value = vouyear;
            objp[1].Value = refno;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = voutype;

            return ExecuteTable("spdebitadviseactamtcheck", objp);
        }

        public DataTable getdncnstateid(int refno, int branchid, int year, string trantype, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno",SqlDbType.Int,4),
                
                  
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                           new SqlParameter("@year",SqlDbType.Int,4),
                                                          new SqlParameter("@trantype",SqlDbType.VarChar,35),    


                                                        new SqlParameter("@voutype", SqlDbType.VarChar,75)
              };
            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = type;

            return ExecuteTable("spstateidcheck", objp);

        }

        public int getprodncnamoutcheck(int branchid, int prodn, string type, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@prodn",SqlDbType.Int,4),
                                                        new SqlParameter("@type", SqlDbType.VarChar,75),
                                                         new SqlParameter("@vouyear",SqlDbType.Int,4)
              };

            objp[0].Value = branchid;
            objp[1].Value = prodn;
            objp[2].Value = type;
            objp[3].Value = vouyear;
            return int.Parse(ExecuteReader("spprodncnamoutcheck", objp));
        }


        //Dhivya
        public int UpdProApprovalOSDCNAfterJobClosed(int refno, int strblno, int approvedby, string trantype, int vouyear, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.Int,4), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     //new SqlParameter("@dcno",SqlDbType.Int,4),
                 new SqlParameter("@type",SqlDbType.VarChar,50),
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            // objp[6].Value = dcno;
            objp[6].Value = type;
            //ExecuteQuery("SPUpdProApprovalOSDCN", objp);
            //return int.Parse(ExecuteReader("SPUpdProApprovalOSDCN", objp));///4MAR21

            //  return int.Parse(ExecuteReader("SPUpdProApprovalOSDCNnew", objp));
            //CHANGE4MAR21
            return int.Parse(ExecuteReader("SPUpdProApprovalOSDCNAfterJobClosed", objp));

        }


        //Dinesh -Einvoice

        public DataTable Getchksaccodeforvoucher(int bid, int refno, int vyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@type",SqlDbType.VarChar,75)
            };

            objp[0].Value = bid;
            objp[1].Value = refno;
            objp[2].Value = vyear;
            objp[3].Value = voutype;
            return ExecuteTable("SPchksaccodeforvoucher", objp);
        }

        public void UpdLedgerOPBreakupNew(int vouno, string voutype, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, string tranfcurr, double tranfamount, string jnlrefno, string jnltype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.VarChar,3),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranfcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,15),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,15),

                                                     };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = tranid;
            objp[5].Value = trantype;
            objp[6].Value = tranyear;
            objp[7].Value = tranamount;
            objp[8].Value = tranfcurr;
            objp[9].Value = tranfamount;
            objp[10].Value = jnlrefno;
            objp[11].Value = jnltype;
            ExecuteQuery("SPUpdLedgerOPBreakupNew", objp);
        }

        public void UpdProApproval_backdated(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = invoiceno;
            objp[7].Value = type;
            ExecuteQuery("SPUpdProApproval_backdated", objp);
        }
        //chart
        public DataTable getunclosejobcount(int branchid, int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@divid", SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("sp_getunclosejobcount", objp);
        }
        public DataTable getunclosejobcountcorp(int branchid, int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@divid", SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("sp_getunclosejobcountcorp", objp);
        }


        public void Updproapp(int refno, int approvedby, int branchid, int invoiceno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                    
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                               
                                                   
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = approvedby;
            objp[2].Value = branchid;
            objp[3].Value = invoiceno;
            objp[4].Value = type;

            ExecuteQuery("proapplv", objp);
        }

        public int UpdproappOSDNCN(int refno, int approvedby, int branchid, int invoiceno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@refno",SqlDbType.Int,4),        
                                                        new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.VarChar,30),
                                                        new SqlParameter("@vouno",SqlDbType.Int),
                                                     };
            objp[0].Value = refno;
            objp[1].Value = approvedby;
            objp[2].Value = branchid;
            objp[3].Value = invoiceno;
            objp[4].Value = type;
            objp[5].Direction = ParameterDirection.Output;

            return int.Parse(ExecuteReader("proappOSDNCN", objp));
        }


        ///nambi
        ///
        public int UpdproappOSDNCNBD(int refno, int approvedby, int branchid, int invoiceno, string type, char bd, int bdyear)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@refno",SqlDbType.Int,4),        
                                                        new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.VarChar,30),
                                                        new SqlParameter("@vouno",SqlDbType.Int),
                                                        new SqlParameter ("@bd",SqlDbType.Char),
                                                        new SqlParameter("@bdyear",SqlDbType.Int)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = approvedby;
            objp[2].Value = branchid;
            objp[3].Value = invoiceno;
            objp[4].Value = type;
            objp[5].Direction = ParameterDirection.Output;
            objp[6].Value = bd;
            objp[7].Value = bdyear;

            return int.Parse(ExecuteReader("proappOSDNCNBD", objp));
        }
        public int GetNoforAcForApprovalbacknew(int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type",SqlDbType.VarChar,30),
              new SqlParameter("@ino",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = type;
            objp[2].Direction = ParameterDirection.Output;
            return int.Parse(ExecuteReader("SPUpdMCForProApprovalBackdat", objp));
        }

        public void UpdproappBD(int refno, int approvedby, int branchid, int invoiceno, string type, char bd, int bdyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),                                                            
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                     new SqlParameter ("@bd",SqlDbType.Char),
                                                     new SqlParameter("@bdyear",SqlDbType.Int)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = approvedby;
            objp[2].Value = branchid;
            objp[3].Value = invoiceno;
            objp[4].Value = type;
            objp[5].Value = bd;
            objp[6].Value = bdyear;
            ExecuteQuery("proappBD", objp);
        }
        public String CHKVoucherexists(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("spCHKVoucherexists", objp);
        }
        public int UpdProApprovalnewback(string type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedinvoiceautomaticback", objp, "@invno");
        }
        public DataTable getosdncncussup(int int_intdcno, int int_bid, int int_Vouyear, string Str_Trantype, string voutype, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),        
                                                     new SqlParameter("@bid",SqlDbType.Int,4), 
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@voutype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     };
            objp[0].Value = int_intdcno;
            objp[1].Value = int_bid;
            objp[2].Value = int_Vouyear;
            objp[3].Value = Str_Trantype;
            objp[4].Value = voutype;
            objp[5].Value = jobno;
            return ExecuteTable("sp_getosdncncussup", objp);
        }

        public void UpdLedgerOPBreakup_new(int vouno, string voutype, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, string tranfcurr, double tranfamount, string jnlrefno, string jnltype)
        {
            SqlParameter[] objp = new SqlParameter[] {   
                                                     new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                     new SqlParameter("@voutype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranfcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,15),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,15),
                                                                                                         
                                                     };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = tranid;
            objp[5].Value = trantype;
            objp[6].Value = tranyear;
            objp[7].Value = tranamount;
            objp[8].Value = tranfcurr;
            objp[9].Value = tranfamount;
            objp[10].Value = jnlrefno;
            objp[11].Value = jnltype;
            ExecuteQuery("SPUpdLedgerOPBreakup", objp);
        }

        //NewOne    //21/07/2022
        public DataTable FillDt4ProTDSNew(string strTrantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,35)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            //return ExecuteTable("SPProApproveTDS", objp);
            //return ExecuteTable("SPProApproveTDSnew", objp);

            return ExecuteTable("SPProApproveTDSnewnewlawrencenewone", objp);
        }
        // bhuvi Add 06/10/2022
        public String SPCHECkfright(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkfright", objp);
        }
        //bhuvi newly added for fright added 06/10/2022

        public int UpdProApprovalnefrieght(string type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedinvoiceautomaticnewinvoicefright", objp, "@invno");
        }
        //end

        //end
        public DataTable GetInvoiceAppSTCheckAmt4PA(int refno, int bid, int vyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                          new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int) };

            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vyear;

            return ExecuteTable("SPGetSTChagers4PA", objp);
        }
        // add yuvaraj 30/12/2022-----------------------------------------------------------------------------
        public DataTable jobsplit_automail(string blno, int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@bid",SqlDbType.Int)
                                                       };



            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = bid;

            return ExecuteTable("sp_jobsplit_automail", objp);

        }
        public DataTable mail_hblno(string blno, int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                       };

            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = bid;


            return ExecuteTable("sp_mail_hblno", objp);
        }
        public DataTable mail_hblno1(string blno, int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                       };

            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = bid;


            return ExecuteTable("sp_mail_hblno1", objp);
        }
        public DataTable automailids_update(string trantype, int jobno, string blno, int bid, string tomailids)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid",SqlDbType.Int),
                                                          new SqlParameter("@tomailids",SqlDbType.VarChar,500)
                                                       };

            objp[0].Value = trantype;
            objp[1].Value = jobno;
            objp[2].Value = blno;
            objp[3].Value = bid;
            objp[4].Value = tomailids;

            return ExecuteTable("sp_automailids_update", objp);
        }
        public DataTable get_splitbl_jobinfo_grid(string blno, int jobno, int bid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno", SqlDbType.Int),                                                                                                            
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@type",SqlDbType.VarChar,1)};

            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = bid;
            objp[3].Value = type;


            return ExecuteTable("sp_get_splitbl_jobinfo_grid", objp);
        }

        public DataTable profomainvoice_report(string blno, int jobno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)
                                                       };

            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = branchid;


            return ExecuteTable("sp_profomainvoice_report", objp);
        }
        public DataTable automailid_retrieved(string blno, int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@bid",SqlDbType.Int)
                                                       };

            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = bid;


            return ExecuteTable("sp_automailid_retrieved", objp);
        }

        public DataTable Checkcountry(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.Int),                                                                                                            
                                                          };

            objp[0].Value = bid;


            return ExecuteTable("SPcheckcountry", objp);
        }

        //////////////////
        public DataTable approve_transfer(string refno, int branchid, string trantype, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@type",SqlDbType.VarChar,100)};

            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = type;
            return ExecuteTable("sp_approve_transfer", objp);
        }
        //////////////////
        // new

        public DataTable usd_invoice(int customerid, string USDInvoice, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                       new SqlParameter("@USDInvoice",SqlDbType.Char,1),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                      };

            objp[0].Value = customerid;
            objp[1].Value = USDInvoice;
            objp[2].Value = branchid;
            return ExecuteTable("sp_ddl_usdinvoice", objp);
        }

        public DataTable usd_invoicedata(int customerid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                      };

            objp[0].Value = customerid;
            objp[1].Value = branchid;
            return ExecuteTable("sp_USD_Invoice", objp);
        }



        public int UpdProApprovalnewbosFC(string type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.VarChar,100),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedinvoiceautomaticbosFC", objp, "@invno");
        }

        public int UpdProApprovalnewFC(string type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.VarChar,100),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedinvoiceautomaticFC", objp, "@invno");
        }

        public String CHKVoucherbosFC(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkbosFC", objp);
        }

        public String CHKVoucherFC(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkFC", objp);
        }

        public String CHKVoucherinvgenFC(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkinvgenFC", objp);
        }

        public DataTable GetchksaccodeforvoucherFC(int bid, int refno, int vyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@type",SqlDbType.VarChar,75)
            };

            objp[0].Value = bid;
            objp[1].Value = refno;
            objp[2].Value = vyear;
            objp[3].Value = voutype;
            return ExecuteTable("SPchksaccodeforvoucherFC", objp);
        }

        public DataTable GetInvoiceAppSTCheckAmt4PAFC(int refno, int bid, int vyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                          new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int) };

            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vyear;

            return ExecuteTable("SPGetSTChagers4PAFC", objp);
        }
        public DataTable GetInvoiceAppSTCheckAmtFC(int refno, int bid, int vyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                          new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int) };

            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vyear;

            return ExecuteTable("SPGetSTChagersInvFC", objp);
        }

        public void UpdProApprovalFC(int refno, string strblno, int approvedby, string trantype, int vouyear, int branchid, int invoiceno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@invoiceno",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.VarChar,50)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = strblno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = invoiceno;
            objp[7].Value = type;
            ExecuteQuery("SPUpdProApprovalFC", objp);
        }

        //public void Getbranch4cn(int dnno, int branchid, int vouyear)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),                                                            
        //                                             new SqlParameter("@bid",SqlDbType.Int,4),                                                                                                                                                     
        //                                             new SqlParameter("@vouyear",SqlDbType.Int,4)                
        //                                             };
        //    objp[0].Value = dnno;
        //    objp[1].Value = branchid;
        //    objp[2].Value = vouyear;           
        //    ExecuteQuery("SPgetbranch4cn", objp);
        //}

        public void InsDNCNagainstDNCN(int dnno, int branchid, int vouyear, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),                                                            
                                                     new SqlParameter("@bid",SqlDbType.Int,4),                                                                                                                                                     
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4)  ,
               new SqlParameter("@type",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = dnno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = type;
            ExecuteQuery("SPInsDNCNagainstDNCN", objp);
        }
        //

        public DataTable creditnote_refno1(int pano, int jobno, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pano",SqlDbType.Int),

                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int)
            };

            objp[0].Value = pano;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("sp_creditnote_refno1", objp);
        }
        public DataTable creditnote_refno_new(int pano, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pano",SqlDbType.Int),

                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                       
            };

            objp[0].Value = pano;
            objp[1].Value = jobno;
            objp[2].Value = branchid;

            return ExecuteTable("sp_creditnote_refno_new", objp);
        }

        public DataTable creditnote_refno_newFC(int pano, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pano",SqlDbType.Int),

                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                       
            };

            objp[0].Value = pano;
            objp[1].Value = jobno;
            objp[2].Value = branchid;

            return ExecuteTable("sp_creditnote_refno_newFC", objp);
        }
        public DataTable creditnote_refno_addnewFC(int pano, int jobno, int branchid, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pano",SqlDbType.Int),

                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
            };

            objp[0].Value = pano;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            return ExecuteTable("sp_creditnote_refno_addnewFC", objp);
        }

        public DataTable creditnote_refno(int pano, int jobno, int branchid, string trantype, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pano",SqlDbType.Int),

                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@vouyear",SqlDbType.Int)
            };

            objp[0].Value = pano;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            return ExecuteTable("sp_creditnote_refno", objp);
        }

        public String Checkdate4BOS(int div)
        {
            SqlParameter[] objp = new SqlParameter[] {
             new SqlParameter("@div",SqlDbType.Int,4)};

            objp[0].Value = div;
            return ExecuteReader("Checkdate4BOS", objp);
        }

        public DataTable FillDt4ProLV(string strTrantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,35)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            return ExecuteTable("SPProApproveLV", objp);
        }

        public DataTable GetProApprovependingLV(string strTrantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,35)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            //return ExecuteTable("SPProApproveTDS", objp);
            //return ExecuteTable("SPProApproveTDSnew", objp);

            return ExecuteTable("SPProApprovependingLV", objp);
        }
        public DataTable GetInvoiceAppSTCheckAmtLV(int refno, int bid, int vyear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                          new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int) };

            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vyear;

            return ExecuteTable("SPGetSTChagersLV", objp);
        }
        public DataTable GetchksaccodeforvoucherLV(int bid, int refno, int vyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.Int),                                                                                                            
                                                        
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@type",SqlDbType.VarChar,75)
            };

            objp[0].Value = bid;
            objp[1].Value = refno;
            objp[2].Value = vyear;
            objp[3].Value = voutype;
            return ExecuteTable("SPchksaccodeforvoucherLV", objp);
        }
        public int GetNoforAcForApprovalLV(int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type",SqlDbType.VarChar,50)};
            objp[0].Value = branchid;
            objp[1].Value = type;
            return int.Parse(ExecuteReader("SPUpdMCForProApprovalLV", objp));
        }

        //
        public DataTable getdebitadviseactamtcheckLV(int vouyear, int refno, int branchid, int jobno, string trantype, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {       
                                                        new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                        new SqlParameter("@refno",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,35), 
                                                         new SqlParameter("@voutype",SqlDbType.VarChar,35)
              };
            objp[0].Value = vouyear;
            objp[1].Value = refno;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = voutype;

            return ExecuteTable("spdebitadviseactamtcheckLV", objp);
        }
        public int getacosdncnamoutcheckLV(string trantype, int branchid, int prodn, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@trantype",SqlDbType.VarChar,35),        
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@prodn",SqlDbType.Int,4),
                                                        new SqlParameter("@type", SqlDbType.VarChar,75)
              };
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = prodn;
            objp[3].Value = type;

            return int.Parse(ExecuteReader("spacosdncnamoutcheckLV", objp));
        }
        public void insForOSDNCNDNCNNumberLV(int refno, string type, int branchid, int jobno, string trantype, int refno2)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dncnnum", SqlDbType.Int),
            new SqlParameter("@type",SqlDbType.VarChar,30),
            new SqlParameter("@branchid",SqlDbType.Int),
            new SqlParameter("@jobno",SqlDbType.Int),
              new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@refno", SqlDbType.Int),};
            objp[0].Value = refno;
            objp[1].Value = type;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = refno2;
            ExecuteReader("SPUpdOSDNCNNumerForNewLV", objp);
        }
        public String CHKVoucherbosLV(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkbosLV", objp);
        }
        public String SPCHECkfrightLV(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkfrightLV", objp);
        }
        public String CHKVoucherinvgenLV(int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int) };
            objp[0].Value = refno;

            return ExecuteReader("SPCHECkinvgenLV", objp);
        }
        public int UpdProApprovalnewLV(string type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedautomaticLV", objp, "@invno");
        }
        public int UpdProApprovalnewBOSLV(int type, int branchid, int refno, int vouyear, string strblno, int approvedby, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@type",SqlDbType.Int),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@approvedby",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@invno",SqlDbType.Int)

                                                     };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = refno;
            objp[3].Value = vouyear;
            objp[4].Value = strblno;
            objp[5].Value = approvedby;
            objp[6].Value = trantype;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("inszeroratedautomaticBOSLV", objp, "@invno");
        }
        public int UpdproappOSDNCNOSV(int refno,string blno, int approvedby,string trantype,int vouyear ,int branchid , int type)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@refno",SqlDbType.Int,4), 
       new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                        new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                           new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                           new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        
                                                        new SqlParameter("@voutype",SqlDbType.Int) 
                                                        
                                                     };
            objp[0].Value = refno;
            objp[1].Value = blno;
            objp[2].Value = approvedby;
            objp[3].Value = trantype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            
            objp[6].Value = type;
            return int.Parse(ExecuteReader("SPUpdProApprovalOSVtrigger", objp));
        }
        public DataTable GetAgentCustomerOrNotradmincom(int vouno, int vouyear, int branchid, string voutype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar,2)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            return ExecuteTable("SPGetAgentCustomerOrNotradmincom", objp);
        }
        public void InsLedgerOPBreakuplv(int ledgerid, int vouno, DateTime voudate, char voutype, int vouyear, int bid, double vouamount, string fcurr, double famount, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ledgerid",SqlDbType.Int,4),        
                                                     new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                     new SqlParameter("@voudate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@vouamount",SqlDbType.Money,8),
                                                     new SqlParameter("@fcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@famount",SqlDbType.Money,8),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     };
            objp[0].Value = ledgerid;
            objp[1].Value = vouno;
            objp[2].Value = voudate;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = bid;
            objp[6].Value = vouamount;
            objp[7].Value = fcurr;
            objp[8].Value = famount;
            objp[9].Value = customerid;
            ExecuteQuery("SPInsLedgerOPBreakuplv", objp);
        }
        public DataTable GetProApprovependingLV_AJclose(string strTrantype, int branchid, int type)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type1",SqlDbType.Int)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
           
            return ExecuteTable("SPProApprovependingLVAfterjobclosed", objp);
        }
        public DataTable GetProApprovependingLVTask(string strTrantype, int branchid, string type,int empid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,35),
                 new SqlParameter("@empid", SqlDbType.Int)
                                                       };

            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = type;
            objp[3].Value = empid;
            //return ExecuteTable("SPProApproveTDS", objp);
            //return ExecuteTable("SPProApproveTDSnew", objp);

            return ExecuteTable("SPProApprovependingLVTask", objp);
        }


        // Vino New for Outstd Adjustment Table [19-02-2024] 
        public void UpdLedgerOPBreakup4adjustment(int vouno, string voutype, int vouyear, int bid, int tranid, char trantype, int tranyear, double tranamount, string tranfcurr, double tranfamount, string jnlrefno, string jnltype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.VarChar),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,2),
                                                     new SqlParameter("@tranid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@trantype",SqlDbType.Char,1),
                                                     new SqlParameter("@tranyear",SqlDbType.Int,4),
                                                     new SqlParameter("@tranamount",SqlDbType.Money,8),
                                                     new SqlParameter("@tranfcurr", SqlDbType.VarChar,10),
                                                     new SqlParameter("@tranfamount",SqlDbType.Money,8),
                                                     new SqlParameter("@jnlrefno", SqlDbType.VarChar,100),
                                                     new SqlParameter("@jnltype", SqlDbType.VarChar,15),

                                                     };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = tranid;
            objp[5].Value = trantype;
            objp[6].Value = tranyear;
            objp[7].Value = tranamount;
            objp[8].Value = tranfcurr;
            objp[9].Value = tranfamount;
            objp[10].Value = jnlrefno;
            objp[11].Value = jnltype;
            ExecuteQuery("SPUpdLedgerOPBreakupforadjustment", objp);
        }

        public int CheckCBMzero4osv(int refno, int branchid, int type)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@refno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@voutype",SqlDbType.Int)
                                                       };

            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = type;
            return int.Parse(ExecuteReader("SPcheckCBMzero4osv", objp));
            
        }
    }
}
