using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Accounts
{
    public class DCAdvise : DBObject
    {
        DataAccess.Accounts.Invoice Invoice = new DataAccess.Accounts.Invoice();
        DataAccess.Masters .MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        DataAccess.HR.Employee HREmpobj = new DataAccess.HR.Employee();

        //int intchargeid;


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public DCAdvise()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GridFillJob(string strtrantype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = strtrantype;
            objp[1].Value =branchid;
            return ExecuteTable("SPDCJobno", objp);
        }

        public DataTable FillBLNo(int jobno, string strtrantype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPDCBLno", objp);
        }
        public DataTable FillIPBLNo(int jobno, string strtrantype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPCheckIPBLno", objp);
        }
        public void InsDCAdvise(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase, double amount, string ftype, int branchid, string remarks,int fd,double cbm)
        {  
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            ExecuteQuery("SPInsDCAdvise", objp);
        }

        public void UpdDCAdvise(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm)
        {   
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            ExecuteQuery("SPUpdDCAdvise", objp);
        }

        public DataTable GetDCCharge(string blno, string trantype, string ftype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelDCAdviseCharge", objp);
        }
        //------------------------------------------------------------------
        public DataTable GetDCAdvise(int jobno, string strTranType, string ftype)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            return ExecuteTable("SPSelDCAdvise", objp);
        }

        public DataTable GetDCAdvise(int jobno, string strTranType, string ftype, int BranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                       new SqlParameter("@branchid", SqlDbType.VarChar,10) };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = BranchID;
            return ExecuteTable("SPSelDCAdv4Job", objp);
        }

        //public DataTable GetDCAdviseWBranch(int jobno, string strTranType, string ftype,int branchid)
        //{
            
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
        //                                                new SqlParameter("@trantype",SqlDbType.VarChar,4),
        //                                                new SqlParameter("@ftype",SqlDbType.VarChar,20),
        //                                                new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
        //    objp[0].Value = jobno;
        //    objp[1].Value = strTranType;
        //    objp[2].Value = ftype;
        //    objp[3].Value = branchid;
        //    return ExecuteTable("SPSelDCAdviseWBranch", objp);
        //}

        public DataTable GetDCAdviseWBranch(int jobno, string strTranType, string ftype, int branchid, int vouno, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                         new SqlParameter("@vouno", SqlDbType.Int,1),
                                                         new SqlParameter("@vouyear", SqlDbType.Int,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = vouno;
            objp[5].Value = vouyear;
            //return ExecuteTable("SPSelDCAdviseWBranch", objp);
            return ExecuteTable("SPSelDCAdviseWBranch_allhd", objp); ////haribalaji
        } 
        //--------------------------------------------------------------------

        public int GetDCChargescount(string blno, int intchargeid, string ftype,int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = intchargeid;
            objp[2].Value = ftype;
            objp[3].Value = intBranchID;
            return int.Parse(ExecuteReader("SPDCCountchrgs", objp));
        }
        //---------------------------------------------------------------------

        public int GetDCBasecount(string blno, string strbase, int intchargeid, string ftype,int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strbase;
            objp[2].Value = intchargeid;
            objp[3].Value = ftype;
            objp[4].Value =intBranchID;
            return int.Parse(ExecuteReader("SPDCCountbase", objp));
        }

        //---------------------------------------------------------------------

        public string GetDCAdviseRemarks(string blno, string ftype, string trantype,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),        
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = ftype;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            return ExecuteReader("SPGetDCAdviseRemarks", objp).ToString();
        }
        public string CheckOSDCNFATrans(int jobno, string ftype, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,1),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),        
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = ftype;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            return ExecuteReader("SPCheckOSDCNFATrans", objp).ToString();
        }
        //-----------------------------------------------------------------------
        public void DelDebitCredit(string blno, int intcharge, string strbase, string ftype, int branchid, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                       new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = blno;
            objp[1].Value = intcharge;
            objp[2].Value = strbase;
            objp[3].Value = ftype;
            objp[4].Value = branchid;
            objp[5].Value = jobno;
            objp[6].Value = trantype;
            ExecuteQuery("SPDelDebitCredit", objp);
        }
        public void DelDebitCreditnew(string blno, int intcharge, string strbase, string ftype, int branchid, int jobno, string trantype, int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                       new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@refno",SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = intcharge;
            objp[2].Value = strbase;
            objp[3].Value = ftype;
            objp[4].Value = branchid;
            objp[5].Value = jobno;
            objp[6].Value = trantype;
            objp[7].Value = refno;
            ExecuteQuery("SPDelDebitCredit", objp);
        }

    //-------------------------------------------------------------------
        public DataTable RptDebit(string strtrantype, string strvtype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@strtrantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = strtrantype;
            objp[1].Value = branchid;
            return ExecuteTable("SPRptDebitCredit", objp);
        }

        public DataTable CheckCurr4DCAdvise(int jobno, string strtrantype, int branchid,string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),        
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = branchid;
            objp[3].Value = ftype;
            return ExecuteTable("SPCheckCurr4DCAdvise", objp);
        }
        public string GetFDFromBLNO(string blno, string trantype, int branchid,string bltype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),        
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@bltype",SqlDbType.VarChar,1)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = bltype;
            return ExecuteReader("SPGetFDFromBLNO", objp).ToString();
        }

        //Nambi
        public DataTable SelDepCre4OSCN(int jobno, string strtrantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelDepCre4OSCN", objp);
        }
        public DataTable SelDepCre4OSDN(int jobno, string strtrantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelDepCre4OSDN", objp);
        }

        //Dinesh
        public string getproosdenjobtype(string blno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {        
                                                      new SqlParameter("@blno",SqlDbType.VarChar,20),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1)};

            objp[0].Value = blno;
            objp[1].Value = branchid;
            return ExecuteReader("spproosdenjobtype", objp).ToString();
        }

        //Arun
        public DataTable getCheckosdncnrpr(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
new SqlParameter("@trantype",SqlDbType.VarChar,4),
new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteTable("SpCheckosdncnrpr", objp);
        }


        //new 20july2022
        public DataTable getCheckosdncnrpr4refno(string strTranType, int jobno, int branchid,int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
new SqlParameter("@trantype",SqlDbType.VarChar,4),
new SqlParameter("@branchid",SqlDbType.Int,4),
new SqlParameter("@refno",SqlDbType.Int)

           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = refno;
            //objp[2].Value = ftype;
            return ExecuteTable("SpCheckosdncnrpr4refno", objp);
        }


        public DataSet GetCheckosdncndelete(string strTranType, int jobno,
int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new 
SqlParameter("@jobno",SqlDbType.Int,4),
new SqlParameter("@trantype",SqlDbType.VarChar,4),
new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SpCheckosdncndelete", objp);
        }
       //public void UpdDCAdviseForGst(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto)
       // {
       //     SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
       //                                                 new SqlParameter("@rate",SqlDbType.Money,8), 
       //                                                 new SqlParameter("@exrate",SqlDbType.Money,8),
       //                                                 new SqlParameter("@base",SqlDbType.VarChar,6),
       //                                                 new SqlParameter("@amount",SqlDbType.Money,8),
       //                                                 new SqlParameter("@blno",SqlDbType.VarChar,30),
       //                                                 new SqlParameter("@chargeid",SqlDbType.Int,4), 
       //                                                 new SqlParameter("@oldbase",SqlDbType.VarChar,6),
       //                                                 new SqlParameter("@ftype",SqlDbType.VarChar,20),
       //                                                 new SqlParameter("@branchid",SqlDbType.Int,4),
       //                                                 new SqlParameter("@remarks",SqlDbType.VarChar,25),
       //                                                 new SqlParameter("@jobno", SqlDbType.Int,4),
       //                                                 new SqlParameter("@trantype", SqlDbType.VarChar,2),
       //                                                 new SqlParameter("@fd", SqlDbType.Int),
       //                                                 new SqlParameter("@cbm", SqlDbType.Real,10),
       //                                                   new SqlParameter("@supplyto", SqlDbType.Int)};
       //     objp[0].Value = curr;
       //     objp[1].Value = rate;
       //     objp[2].Value = exrate;
       //     objp[3].Value = strbase;
       //     objp[4].Value = amount;
       //     objp[5].Value = blno;
       //     objp[6].Value = intchargeid;
       //     objp[7].Value = oldbase;
       //     objp[8].Value = ftype;
       //     objp[9].Value = branchid;
       //     objp[10].Value = remarks;   
       //     objp[11].Value = jobno;
       //     objp[12].Value = trantype;
       //     objp[13].Value = fd;
       //     objp[14].Value = cbm;
       //     objp[15].Value = supplyto;
       //     ExecuteQuery("SPUpdDCAdviseForGst", objp);
       // }


       // public void InsDCAdviseForGst(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase, double amount, string ftype, int branchid, string remarks, int fd, double cbm, int supplyto)
       // {
       //     SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
       //                                                 new SqlParameter("@trantype",SqlDbType.VarChar,4), 
       //                                                 new SqlParameter("@blno",SqlDbType.VarChar,30),
       //                                                 new SqlParameter("@charges",SqlDbType.Int,4),
       //                                                 new SqlParameter("@curr",SqlDbType.VarChar,6),
       //                                                 new SqlParameter("@rate",SqlDbType.Money,8),
       //                                                 new SqlParameter("@exrate",SqlDbType.Money,8), 
       //                                                 new SqlParameter("@base",SqlDbType.VarChar,6),
       //                                                 new SqlParameter("@amount",SqlDbType.Money,8),
       //                                                 new SqlParameter("@ftype",SqlDbType.VarChar,20),
       //                                                 new SqlParameter("@branchid",SqlDbType.Int,4),
       //                                                 new SqlParameter("@remarks",SqlDbType.VarChar,25),
       //                                                 new SqlParameter("@fd", SqlDbType.Int),
       //                                                 new SqlParameter("@cbm", SqlDbType.Real,10),
       //      new SqlParameter("@supplyto", SqlDbType.Int)};
       //     objp[0].Value = jobno;
       //     objp[1].Value = trantype;
       //     objp[2].Value = blno;
       //     objp[3].Value = intchargeid;
       //     objp[4].Value = curr;
       //     objp[5].Value = rate;
       //     objp[6].Value = exrate;
       //     objp[7].Value = cmbbase;
       //     objp[8].Value = amount;
       //     objp[9].Value = ftype;
       //     objp[10].Value = branchid;
       //     objp[11].Value = remarks;
       //     objp[12].Value = fd;
       //     objp[13].Value = cbm;
       //     objp[14].Value = supplyto;

       //     ExecuteQuery("SPInsDCAdviseGstNew", objp);
       // }

        public void UpdDCAdviseForGst(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            ExecuteQuery("SPUpdDCAdviseForGst", objp);
        }
        public void InsDCAdviseForGst(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase, double amount, string ftype, int branchid, string remarks, int fd, double cbm, int supplyto, string chk)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
             new SqlParameter("@supplyto", SqlDbType.Int),
            new SqlParameter("@GSTCHK", SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = supplyto;
            objp[15].Value = chk;
            ExecuteQuery("SPInsDCAdviseGstNew", objp);
        }



        public DataTable getRetriveCnDnNum(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
            new SqlParameter("@trantype",SqlDbType.VarChar,4),
            new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteTable("SpCheckOSSIcnrprRetCnDnNo", objp);
        }
        //new


        public DataTable getRetriveCnDnNum_new(string strTranType, int jobno, int branchid,int dnno,int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
            new SqlParameter("@trantype",SqlDbType.VarChar,4),
            new SqlParameter("@branchid",SqlDbType.Int,4),
             new SqlParameter("@dnno",SqlDbType.Int,4),
              new SqlParameter("@vouyear",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = dnno;
            objp[4].Value = vouyear;
            return ExecuteTable("SpCheckOSSIcnrprRetCnDnNo_newOSV", objp);
        }




        //ARUN

        //GST

        public void UpdDCAdviseNew(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10)
        };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;

            ExecuteQuery("SPUpdateDCAdviseNew", objp);
        }





        public void UpdDCAdviseForGstForNew(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
                                                            new SqlParameter("@refno", SqlDbType.Int)
            };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = refno;
            ExecuteQuery("SPUpdDCAdviseForGstForRefNotnull", objp);
        }



        public void UpdDCAdviseForNew(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
            new SqlParameter("@refno", SqlDbType.Real,10)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = refno;
            ExecuteQuery("SPUpdDCAdviseForNew", objp);
        }



        public void InsForAcdebiteadviseDtls(int prodn, int vouyear, int branchid, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prodn",SqlDbType.BigInt),
                      new SqlParameter("@vouyear",SqlDbType.Int),
               new SqlParameter("@branchid",SqlDbType.Int),
            new SqlParameter("@jobno",SqlDbType.Int),
              new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = prodn;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            ExecuteQuery("SpUpdDnVouyearFordebitadvise", objp);

        }

        public void InsForAcCrediteadviseDtls(int procn, int vouyear, int branchid, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@procn",SqlDbType.BigInt),
                      new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
            new SqlParameter("@jobno",SqlDbType.Int),
              new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = procn;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            ExecuteQuery("SpUpdDnVouyearForcreditadvise", objp);

        }


        public void InsDCAdviseForGst(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase, double amount, string ftype, int branchid, string remarks, int fd, double cbm, int supplyto, string chk, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,4),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
             new SqlParameter("@supplyto", SqlDbType.Int),
            new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
             new SqlParameter("@agentid",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = supplyto;
            objp[15].Value = chk;
            objp[16].Value = agentid;

            ExecuteQuery("SPInsDCAdviseGstNewAGENT", objp);
        }

    //Dinesh

        public DataSet SPGetDtls4osdcnForAgent(int bid, int jobno, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int),        
                                                      new SqlParameter("@jobno",SqlDbType.Int),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar,10)};
            objp[0].Value = bid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SPGetDtls4osdcn", objp);
        }



        public void InsDCAdviseForAgent(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase, double amount, string ftype, int branchid, string remarks, int fd, double cbm, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
              new SqlParameter("@agentid",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = agentid;
            ExecuteQuery("SPInsDCAdviseForAgentNEW", objp);
        }


        public void InsForAcdebiteadviseDtls(int prodn, int vouyear, int branchid, int jobno, string trantype, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prodn",SqlDbType.BigInt),
                      new SqlParameter("@vouyear",SqlDbType.Int),
               new SqlParameter("@branchid",SqlDbType.Int),
            new SqlParameter("@jobno",SqlDbType.Int),
              new SqlParameter("@trantype",SqlDbType.VarChar,2),
             new SqlParameter("@customerid",SqlDbType.Int)};
            objp[0].Value = prodn;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = customerid;
            ExecuteQuery("SpUpdDnVouyearFordebitadvisenew", objp);

        }


        public void InsForAcCrediteadviseDtls(int procn, int vouyear, int branchid, int jobno, string trantype, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@procn",SqlDbType.BigInt),
                      new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
            new SqlParameter("@jobno",SqlDbType.Int),
              new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@customerid",SqlDbType.Int)};
            objp[0].Value = procn;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = customerid;
            ExecuteQuery("SpUpdDnVouyearForcreditadvisenew", objp);

        }


        public void UpdDCAdviseForNew(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int refno, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
            new SqlParameter("@refno", SqlDbType.Real,10),
             new SqlParameter("@agentid", SqlDbType.Int),};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = refno;
            objp[16].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForNewww", objp);
        }




        public void UpdDCAdviseNew(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                        new SqlParameter("@agentid", SqlDbType.Int)
        };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = agentid;
            ExecuteQuery("SPUpdateDCAdviseNewwww", objp);
        }



        public void UpdDCAdviseForGstForagent(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForagent", objp);
        }


        public int GetDCChargescountAgent(string blno, int intchargeid, string ftype, int intBranchID, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt,1),
             new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = intchargeid;
            objp[2].Value = ftype;
            objp[3].Value = intBranchID;
            objp[4].Value = agentid;
            return int.Parse(ExecuteReader("SPDCCountchrgsForagent", objp));
        }

        public int GetDCBasecountAgent(string blno, string strbase, int intchargeid, string ftype, int intBranchID, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt,1),
             new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = strbase;
            objp[2].Value = intchargeid;
            objp[3].Value = ftype;
            objp[4].Value = intBranchID;
            objp[5].Value = agentid;
            return int.Parse(ExecuteReader("SPDCCountbaseAgent", objp));
        }


        public void DelDebitCredit(string blno, int intcharge, string strbase, string ftype, int branchid, int jobno, string trantype, int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                       new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@refno",SqlDbType.Int,7)};
            objp[0].Value = blno;
            objp[1].Value = intcharge;
            objp[2].Value = strbase;
            objp[3].Value = ftype;
            objp[4].Value = branchid;
            objp[5].Value = jobno;
            objp[6].Value = trantype;
            objp[7].Value = refno;
            ExecuteQuery("SPDelDebitCreditnew", objp);
        }

        public void UpdDCAdviseForGstForNew(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int refno, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
                                                            new SqlParameter("@refno", SqlDbType.Int),
                                                            new SqlParameter("@agentid", SqlDbType.Int)
            };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = refno;
            objp[18].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForRefNotnullnew", objp);
        }


        public void UpdDCAdviseForGst(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstnew", objp);
        }

        public void InsDCAdviseForGstservisetax(int jobno, string trantype, string blno, int intchargeid, string curr, double rate,
            double exrate, string cmbbase, double amount, string ftype, int branchid, string remarks, int fd, double cbm, int supplyto,
            string chk, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,4),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
             new SqlParameter("@supplyto", SqlDbType.Int),
            new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
             new SqlParameter("@agentid",SqlDbType.Int),
             new SqlParameter("@gstyesno",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = supplyto;
            objp[15].Value = chk;
            objp[16].Value = agentid;
            objp[17].Value = gstyesno;
            ExecuteQuery("SPInsDCAdviseGstNewAGENT", objp);
        }
        public void UpdDCAdviseForGstForNewservisetax(string curr, double rate, double exrate, string strbase, double amount,
            string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype,
            int fd, double cbm, int supplyto, string chk, int refno, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
                                                            new SqlParameter("@refno", SqlDbType.Int),
                                                            new SqlParameter("@agentid", SqlDbType.Int),
                                                              new SqlParameter("@gstyesno", SqlDbType.VarChar,1)
            };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = refno;
            objp[18].Value = agentid;
            objp[19].Value = gstyesno;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForRefNotnullnew", objp);
        }


        public void InsDCAdviseForAgentservisetax(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase,
            double amount, string ftype, int branchid, string remarks, int fd, double cbm, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
              new SqlParameter("@agentid",SqlDbType.Int),
            new SqlParameter("@gstyesno",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = agentid;
            objp[15].Value = gstyesno;
            ExecuteQuery("SPInsDCAdviseForAgentNEW", objp);
        }


        public void UpdDCAdviseForGstservisetax(string curr, double rate, double exrate, string strbase, double amount, string blno,
            int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd,
            double cbm, int supplyto, string chk, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int),
            new SqlParameter("@gstyesno", SqlDbType.VarChar,1)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            objp[18].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstnew]", objp);
        }

        public void UpdDCAdviseForGstForagentservisetax(string curr, double rate, double exrate, string strbase, double amount,
            string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno,
            string trantype, int fd, double cbm, int supplyto, string chk, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int),
            new SqlParameter("@gstyesno", SqlDbType.VarChar,1)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            objp[18].Value = gstyesno;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForagent", objp);
        }
        //DCAdvise.cs
        //Tally
        public DataTable GetDCAdviseWBranch(int jobno, string
strTranType, string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new 
SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new 
SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new 
SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new 
SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelDCAdviseWBranch", objp);
        }



        
  //Dhivya
        public void InsDCAdviseForGstservisetaxAfterJobClosed(int jobno, string trantype, string blno, int intchargeid, string curr, double rate,
            double exrate, string cmbbase, double amount, string ftype, int branchid, string remarks, int fd, double cbm, int supplyto,
            string chk, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,4),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
             new SqlParameter("@supplyto", SqlDbType.Int),
            new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
             new SqlParameter("@agentid",SqlDbType.Int),
             new SqlParameter("@gstyesno",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = supplyto;
            objp[15].Value = chk;
            objp[16].Value = agentid;
            objp[17].Value = gstyesno;
            ExecuteQuery("SPInsDCAdviseGstNewAGENTAfterJobClosed", objp);
        }

        public void InsDCAdviseForAgentservisetaxAfterJobClosed(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase,
           double amount, string ftype, int branchid, string remarks, int fd, double cbm, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
              new SqlParameter("@agentid",SqlDbType.Int),
            new SqlParameter("@gstyesno",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = agentid;
            objp[15].Value = gstyesno;
            ExecuteQuery("SPInsDCAdviseForAgentNEWAfterJobClosed", objp);
        }

        // Yuvaraj [05-01-2023]
        public void DelDebitCreditnewly(int branchid, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)     };


            objp[0].Value = branchid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;

            ExecuteQuery("SPDelDebitCreditnew1", objp);
        }
        //


        




     
        public void UpdDCAdviseForGstOSV(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstnewOSV", objp);
        }

        

        //public void UpdDCAdviseForNewOSV(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int refno)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
        //                                                new SqlParameter("@rate",SqlDbType.Money,8), 
        //                                                new SqlParameter("@exrate",SqlDbType.Money,8),
        //                                                new SqlParameter("@base",SqlDbType.VarChar,45),
        //                                                new SqlParameter("@amount",SqlDbType.Money,8),
        //                                                new SqlParameter("@blno",SqlDbType.VarChar,30),
        //                                                new SqlParameter("@chargeid",SqlDbType.Int,4), 
        //                                                new SqlParameter("@oldbase",SqlDbType.VarChar,45),
        //                                                new SqlParameter("@ftype",SqlDbType.Int),
        //                                                new SqlParameter("@branchid",SqlDbType.Int,4),
        //                                                new SqlParameter("@remarks",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@jobno", SqlDbType.Int,4),
        //                                                new SqlParameter("@trantype", SqlDbType.VarChar,2),
        //                                                new SqlParameter("@fd", SqlDbType.Int),
        //                                                new SqlParameter("@cbm", SqlDbType.Real,10),
        //    new SqlParameter("@refno", SqlDbType.Real,10)};
        //    objp[0].Value = curr;
        //    objp[1].Value = rate;
        //    objp[2].Value = exrate;
        //    objp[3].Value = strbase;
        //    objp[4].Value = amount;
        //    objp[5].Value = blno;
        //    objp[6].Value = intchargeid;
        //    objp[7].Value = oldbase;
        //    objp[8].Value = ftype;
        //    objp[9].Value = branchid;
        //    objp[10].Value = remarks;
        //    objp[11].Value = jobno;
        //    objp[12].Value = trantype;
        //    objp[13].Value = fd;
        //    objp[14].Value = cbm;
        //    objp[15].Value = refno;
        //    ExecuteQuery("SPUpdDCAdviseForNewOSV", objp);
        //}


        public void UpdDCAdviseForNewOSV(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int refno, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
            new SqlParameter("@refno", SqlDbType.Real,10),
             new SqlParameter("@agentid", SqlDbType.Int),};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = refno;
            objp[16].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForNewwwOSV", objp);
        }

        public void UpdDCAdviseNewOSV(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                        new SqlParameter("@agentid", SqlDbType.Int)
        };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = agentid;
            ExecuteQuery("SPUpdateDCAdviseNewwwwOSV", objp);
        }
        public void InsDCAdviseForGstOSV(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase, double amount, int ftype, int branchid, string remarks, int fd, double cbm, int supplyto, string chk, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,4),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
             new SqlParameter("@supplyto", SqlDbType.Int),
            new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
             new SqlParameter("@agentid",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = supplyto;
            objp[15].Value = chk;
            objp[16].Value = agentid;

            ExecuteQuery("SPInsDCAdviseGstNewAGENTOSV", objp);
        }

        public void InsDCAdviseForAgentOSV(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase, double amount, int ftype, int branchid, string remarks, int fd, double cbm, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
              new SqlParameter("@agentid",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = agentid;
            ExecuteQuery("SPInsDCAdviseForAgentNEWOSV", objp);
        }

        public void InsForAcdebitcrediteadviseDtlsOSV(int prodn, int vouyear, int branchid, int jobno, string trantype, int customerid,int type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prodn",SqlDbType.BigInt),
                      new SqlParameter("@vouyear",SqlDbType.Int),
               new SqlParameter("@branchid",SqlDbType.Int),
            new SqlParameter("@jobno",SqlDbType.Int),
              new SqlParameter("@trantype",SqlDbType.VarChar,2),
             new SqlParameter("@customerid",SqlDbType.Int),
            new SqlParameter("@type",SqlDbType.Int)};
            objp[0].Value = prodn;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = customerid;
            objp[6].Value = type;
            ExecuteQuery("SpUpdDnCNVouyearFordebitadvisenewOSV", objp);

        }
        public void UpdDCAdviseForGstForagentOSV(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForagentOSV", objp);
        }

        public DataTable GetDCAdviseOSV(int jobno, string strTranType, int ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            return ExecuteTable("SPSelDCAdviseOSV", objp);
        }
        public DataSet GetCheckosdncndeleteOSV(string strTranType, int jobno,int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new 
SqlParameter("@jobno",SqlDbType.Int,4),
new SqlParameter("@trantype",SqlDbType.VarChar,4),
new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SpCheckosdncndeleteOSV", objp);
        }
        public DataTable getCheckosdncnrprOSV(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
new SqlParameter("@trantype",SqlDbType.VarChar,4),
new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteTable("SpCheckosdncnrprOSV", objp);
        }





        public void InsDCAdviseForGstservisetaxOSV(int jobno, string trantype, string blno, int intchargeid, string curr, double rate,
           double exrate, string cmbbase, double amount, int ftype, int branchid, string remarks, int fd, double cbm, int supplyto,
           string chk, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,4),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
             new SqlParameter("@supplyto", SqlDbType.Int),
            new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
             new SqlParameter("@agentid",SqlDbType.Int),
             new SqlParameter("@gstyesno",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = supplyto;
            objp[15].Value = chk;
            objp[16].Value = agentid;
            objp[17].Value = gstyesno;
            ExecuteQuery("SPInsDCAdviseGstNewAGENT1OSV", objp);
        }
        public void UpdDCAdviseForGstForNewservisetaxOSV(string curr, double rate, double exrate, string strbase, double amount,
            string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype,
            int fd, double cbm, int supplyto, string chk, int refno, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
                                                            new SqlParameter("@refno", SqlDbType.Int),
                                                            new SqlParameter("@agentid", SqlDbType.Int),
                                                              new SqlParameter("@gstyesno", SqlDbType.VarChar,1)
            };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = refno;
            objp[18].Value = agentid;
            objp[19].Value = gstyesno;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForRefNotnullnewOSV", objp);
        }


        public void InsDCAdviseForAgentservisetaxOSV(int jobno, string trantype, string blno, int intchargeid, string curr, double rate, double exrate, string cmbbase,
            double amount, int ftype, int branchid, string remarks, int fd, double cbm, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@charges",SqlDbType.Int,4),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
              new SqlParameter("@agentid",SqlDbType.Int),
            new SqlParameter("@gstyesno",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = agentid;
            objp[15].Value = gstyesno;
            ExecuteQuery("SPInsDCAdviseForAgentNEWOSV", objp);
        }


        public void UpdDCAdviseForGstservisetax(string curr, double rate, double exrate, string strbase, double amount, string blno,
            int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd,
            double cbm, int supplyto, string chk, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int),
            new SqlParameter("@gstyesno", SqlDbType.VarChar,1)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            objp[18].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstnewOSV", objp);
        }

        public void UpdDCAdviseForGstservisetaxOSV(string curr, double rate, double exrate, string strbase, double amount, string blno,
            int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd,
            double cbm, int supplyto, string chk, int agentid, string gstyesno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                        new SqlParameter("@rate",SqlDbType.Money,8),
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
            new SqlParameter("@agentid", SqlDbType.Int),
            new SqlParameter("@gstyesno", SqlDbType.VarChar,1)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = agentid;
            objp[18].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstnewOSV", objp);
        }
        public DataTable getCheckosdncnrpr4refnoOSV(string strTranType, int jobno, int branchid, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
new SqlParameter("@trantype",SqlDbType.VarChar,4),
new SqlParameter("@branchid",SqlDbType.Int,4),
new SqlParameter("@refno",SqlDbType.Int)

           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = refno;
            //objp[2].Value = ftype;
            return ExecuteTable("SpCheckOSSIcnrpr4refnoOSV", objp);
        }


        public DataTable SelDepCre4OSDCNOSV(int jobno, string strtrantype, int branchid,int Type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
            new SqlParameter("@type", SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = branchid;
            objp[3].Value = Type;
            return ExecuteTable("SPSelDepCre4OSDNOSV", objp);
        }
        public string GetDCAdviseRemarksOSV(string blno, string ftype, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),        
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = ftype;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            return ExecuteReader("SPGetDCAdviseRemarksOSV", objp).ToString();
        }


        public void UpdDCAdviseForGstForNewOSV(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int refno, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
                                                            new SqlParameter("@refno", SqlDbType.Int),
                                                            new SqlParameter("@agentid", SqlDbType.Int)
            };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = refno;
            objp[18].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForRefNotnullnewOSV", objp);
        }
        //public void UpdDCAdviseForGstForNewosv(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, int ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int refno)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
        //                                                new SqlParameter("@rate",SqlDbType.Money,8), 
        //                                                new SqlParameter("@exrate",SqlDbType.Money,8),
        //                                                new SqlParameter("@base",SqlDbType.VarChar,45),
        //                                                new SqlParameter("@amount",SqlDbType.Money,8),
        //                                                new SqlParameter("@blno",SqlDbType.VarChar,30),
        //                                                new SqlParameter("@chargeid",SqlDbType.Int,4), 
        //                                                new SqlParameter("@oldbase",SqlDbType.VarChar,45),
        //                                                new SqlParameter("@ftype",SqlDbType.Int),
        //                                                new SqlParameter("@branchid",SqlDbType.Int,4),
        //                                                new SqlParameter("@remarks",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@jobno", SqlDbType.Int,4),
        //                                                new SqlParameter("@trantype", SqlDbType.VarChar,2),
        //                                                new SqlParameter("@fd", SqlDbType.Int),
        //                                                new SqlParameter("@cbm", SqlDbType.Real,10),
        //                                                  new SqlParameter("@supplyto", SqlDbType.Int),
        //                                                   new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
        //                                                    new SqlParameter("@refno", SqlDbType.Int)
        //    };
        //    objp[0].Value = curr;
        //    objp[1].Value = rate;
        //    objp[2].Value = exrate;
        //    objp[3].Value = strbase;
        //    objp[4].Value = amount;
        //    objp[5].Value = blno;
        //    objp[6].Value = intchargeid;
        //    objp[7].Value = oldbase;
        //    objp[8].Value = ftype;
        //    objp[9].Value = branchid;
        //    objp[10].Value = remarks;
        //    objp[11].Value = jobno;
        //    objp[12].Value = trantype;
        //    objp[13].Value = fd;
        //    objp[14].Value = cbm;
        //    objp[15].Value = supplyto;
        //    objp[16].Value = chk;
        //    objp[17].Value = refno;
        //    ExecuteQuery("SPUpdDCAdviseForGstForRefNotnullOSV", objp);
        //}

        public int GetDCChargescountAgentOSV(string blno, int intchargeid, int ftype, int intBranchID, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt,1),
             new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = intchargeid;
            objp[2].Value = ftype;
            objp[3].Value = intBranchID;
            objp[4].Value = agentid;
            return int.Parse(ExecuteReader("SPDCCountchrgsForagentOSV", objp));
        }
        public int GetDCBasecountAgentOSV(string blno, string strbase, int intchargeid, int ftype, int intBranchID, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt,1),
             new SqlParameter("@agentid", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = strbase;
            objp[2].Value = intchargeid;
            objp[3].Value = ftype;
            objp[4].Value = intBranchID;
            objp[5].Value = agentid;
            return int.Parse(ExecuteReader("SPDCCountbaseAgentOSV", objp));
        }
        public DataSet SPGetDtls4osdcnForAgentOSV(int bid, int jobno, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int),        
                                                      new SqlParameter("@jobno",SqlDbType.Int),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar,10)};
            objp[0].Value = bid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SPGetDtls4osdcnOSV", objp);
        }
        public void DelDebitCreditnewlyOSV(int branchid, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)     };


            objp[0].Value = branchid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;

            ExecuteQuery("SPDelDebitCreditnew1OSV", objp);
        }
        public void DelDebitCreditOSV(string blno, int intcharge, string strbase, int ftype, int branchid, int jobno, string trantype, int refno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                       new SqlParameter("@charge",SqlDbType.Int,4),
                                                        new SqlParameter("@base",SqlDbType.VarChar,45),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@refno",SqlDbType.Int,7)};
            objp[0].Value = blno;
            objp[1].Value = intcharge;
            objp[2].Value = strbase;
            objp[3].Value = ftype;
            objp[4].Value = branchid;
            objp[5].Value = jobno;
            objp[6].Value = trantype;
            objp[7].Value = refno;
            ExecuteQuery("SPDelDebitCreditnewOSV", objp);
        }
        public void InsOSVdetails(int jobno, string trantype, string blno, int intchargeid, string curr, double rate,
  double exrate, string cmbbase, double amount, int ftype, int branchid, string remarks, int fd, double cbm, int supplyto,
  string chk, int agentid, string gstyesno, int refno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                  new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                  new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                  new SqlParameter("@charges",SqlDbType.Int,4),
                                                  new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                  new SqlParameter("@rate",SqlDbType.Money,4),
                                                  new SqlParameter("@exrate",SqlDbType.Money,8),
                                                  new SqlParameter("@base",SqlDbType.VarChar,45),
                                                  new SqlParameter("@amount",SqlDbType.Money,8),
                                                  new SqlParameter("@ftype",SqlDbType.Int),
                                                  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                  new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                  new SqlParameter("@fd", SqlDbType.Int),
                                                  new SqlParameter("@cbm", SqlDbType.Real,10),
       new SqlParameter("@supplyto", SqlDbType.Int),
      new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
       new SqlParameter("@agentid",SqlDbType.Int),
       new SqlParameter("@gstyesno",SqlDbType.VarChar,1),
       new SqlParameter("@refno",SqlDbType.Int),
       new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = amount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = fd;
            objp[13].Value = cbm;
            objp[14].Value = supplyto;
            objp[15].Value = chk;
            objp[16].Value = agentid;
            objp[17].Value = gstyesno;
            objp[18].Value = refno;
            objp[19].Value = vouyear;
            ExecuteQuery("SPInsOSVdetails", objp);
        }
        public DataTable CheckgstforOSV(int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                        new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                         };


            objp[0].Value = chargeid;


            return ExecuteTable("SPcheckgstforOSV", objp);
        }
    }
}