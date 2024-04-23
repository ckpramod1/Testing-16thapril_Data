using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public class CloseJobs:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CloseJobs()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetJobDetails(string jobinfo, string trantype, int intBranchID)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobinfo", SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1)};
           objp[0].Value = jobinfo;
           objp[1].Value = trantype;
           objp[2].Value = intBranchID;
          return ExecuteTable("SPGetCloseJob", objp);                   
       }

       public DataTable GetJobDetailsOpen(string jobinfo, string trantype, int intBranchID)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobinfo", SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1)};
           objp[0].Value = jobinfo;
           objp[1].Value = trantype;
           objp[2].Value = intBranchID ;
           return ExecuteTable("SPGetJobOpen", objp);
       }

       public DataTable GetJobDetailsClose(string jobinfo, string trantype, int intBranchID)
       {
           SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@jobinfo", SqlDbType.VarChar,30),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
           objp[0].Value = jobinfo;
           objp[1].Value = trantype;
           objp[2].Value = intBranchID ;
           return ExecuteTable("SPGetJobClose", objp);
       }
       public DataTable CheckApprovedVoucher(int jobno, string trantype, int branchid, string voutype)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@voutype",SqlDbType.VarChar,1)};
           objp[0].Value = jobno;
           objp[1].Value = trantype;
           objp[2].Value = branchid;
           objp[3].Value = voutype;
           return ExecuteTable("SPCheckApprovedVoucher", objp);
       }

       public int CheckDCAdviseRaiseOS(int jobno, string trantype, int branchid, string voutype)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@voutype",SqlDbType.VarChar,1)};
           objp[0].Value = jobno;
           objp[1].Value = trantype;
           objp[2].Value = branchid;
           objp[3].Value = voutype;
           return int.Parse(ExecuteReader("SPCheckDCAdviseRaiseOS", objp));
       }

       public void UpdJobClsConfirm(int jobno, string trantype, string blno, int branchid, int cid, int volumeconf, int incomeconf, int expenseconf, int blreleaseconf, int destconf)
       {
           SqlParameter[] objp = { new SqlParameter("@jobno",SqlDbType.Int,4),
                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                    new SqlParameter("@blno",SqlDbType.VarChar,30),
                                    new SqlParameter("@branchid",SqlDbType.Int,4),
                                    new SqlParameter("@cid",SqlDbType.Int,4),
                                     new SqlParameter("@volumeconf",SqlDbType.Int,4),
                                      new SqlParameter("@incomeconf",SqlDbType.Int,4),
                                       new SqlParameter("@expenseconf",SqlDbType.Int,4),
                                        new SqlParameter("@blreleaseconf",SqlDbType.Int,4),
                                       new SqlParameter("@destconf",SqlDbType.Int,4)
                                    };
           objp[0].Value = jobno;
           objp[1].Value = trantype;
           objp[2].Value = blno;
           objp[3].Value = branchid;
           objp[4].Value = cid;
           objp[5].Value = volumeconf;
           objp[6].Value = incomeconf;
           objp[7].Value = expenseconf;
           objp[8].Value = blreleaseconf;
           objp[9].Value = destconf;

           ExecuteQuery("SP_UpdJobClsConfirm", objp);
       }

       public void UpdateCloseJob(string jobinfo, string trantype, int jobno, int branchid, DateTime cdate,int JobClosedBy)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobinfo", SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@jobno", SqlDbType.Int,4),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cdate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@jobclosedby",SqlDbType.Int)};
           objp[0].Value = jobinfo;
           objp[1].Value = trantype;
           objp[2].Value = jobno;
           objp[3].Value = branchid;
           objp[4].Value = cdate;
           objp[5].Value = JobClosedBy;
           ExecuteQuery("SPUpdCloseJob", objp);
       }

       public void UpdateCloseJobN(string jobinfo, string trantype, int jobno, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobinfo", SqlDbType.VarChar,30),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@jobno", SqlDbType.Int,4),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
           objp[0].Value = jobinfo;
           objp[1].Value = trantype;
           objp[2].Value = jobno;
           objp[3].Value = branchid;
           ExecuteQuery("SPUpdCloseJobN", objp);

        }
       public DataTable GetJobDetails4datechange(int branchid, int month, string strTrantype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@month", SqlDbType.Int,4)};
            objp[0].Value = strTrantype;
            objp[1].Value = branchid;
            objp[2].Value = month;
            return ExecuteTable("SPSeljobdetails", objp);
        }
        public void UpdateJobClosedate(int branchid, DateTime jobcloseddate, string trantype, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@closeddate", SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = jobcloseddate;
            objp[2].Value = trantype;
            objp[3].Value = jobno;
            ExecuteQuery("SPUpdjobCloseDate", objp);

        }

       public DataTable CheckJobClosedORNot(int jobno,string trantype,int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@jobno", SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1) };
           objp[0].Value = trantype;
           objp[1].Value = jobno;
           objp[2].Value = branchid;
           return ExecuteTable("SPCheckJobClosedORNot", objp);
       }

       public DataTable SelOtherBranchBL(int Jobno, int Branch, string TranType)
       {
           SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
           objp[0].Value = Jobno;
           objp[1].Value = Branch;
           objp[2].Value = TranType;
           return ExecuteTable("SPSelOtherBranchBL", objp);
       }

       public DataTable GetCustofPLGroup(int Branch)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
           objp[0].Value = Branch;
           return ExecuteTable("SPGetPLGroupCustID", objp);
       }
       public DataTable CheckShipmentTransferOrNot(int jobno, int branchid, string TranType)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,1),
                                                       new SqlParameter("@branchid",SqlDbType.VarChar,10),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2) };
           objp[0].Value = jobno;
           objp[1].Value = branchid;
           objp[2].Value = TranType;
           return ExecuteTable("SPCheckShipmentTransferOrNot", objp);
       }
       public void UpdateJobCloseNull(int bid, int cid, int jobno, int month, string year, string product)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@cid",SqlDbType.Int,4),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@month",SqlDbType.Int,4),
                                                       new SqlParameter("@year",SqlDbType.VarChar,4),
                                                       new SqlParameter("@product",SqlDbType.VarChar,6)};
           objp[0].Value = bid;
           objp[1].Value = cid;
           objp[2].Value = jobno;
           objp[3].Value = month;
           objp[4].Value = year;
           objp[5].Value = product;
           ExecuteQuery("SPUpdJobCloseddatenull", objp);
       }


       //------------------------   For JobCloseRemarks

       public void UpdJobCloseRemarks(int bid, string jobno, string trantype, string remarks)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobcloserks",SqlDbType.VarChar,3000)};
           objp[0].Value = bid;
           objp[1].Value = jobno;
           objp[2].Value = trantype;
           objp[3].Value = remarks;
           ExecuteQuery("SPUpdJobCloseRemarks", objp);
       }



       public void UpdJobCloseRemarks4rptJob(int bid, string jobno, string trantype, string remarks)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobcloserks",SqlDbType.VarChar,100)};
           objp[0].Value = bid;
           objp[1].Value = jobno;
           objp[2].Value = trantype;
           objp[3].Value = remarks;
           ExecuteQuery("SPUpdJobCloseRemarks4rptJob", objp);
       }


       //For InsAutoDCN From JobClose START   KUMAR
       public void InsAutoDCNFrmJobClose(int vouno,string voutype,int branchid,int jobno,string trantype,int vouyear)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@voutype",SqlDbType.Char,1),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt ),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear",SqlDbType.Int )};
           objp[0].Value = vouno ;
           objp[1].Value = voutype ;
           objp[2].Value = branchid ;
           objp[3].Value = jobno;
           objp[4].Value = trantype ;
           objp[5].Value = vouyear ;
           ExecuteQuery("SPInsAutoDCNFrmJobClose", objp);
       }
       //For InsAutoDCN From JobClose END   KUMAR


       //Manoj

       public DataTable CheckVoucherForJobClose(int jobno, string trantype, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@jobno", SqlDbType.Int,4),
           new SqlParameter("@branchid",SqlDbType.TinyInt,1) };
           objp[0].Value = trantype;
           objp[1].Value = jobno;
           objp[2].Value = branchid;
           return ExecuteTable("SPCheckVoucherForJobCloseLV", objp);
       }

       public void UpdateClosedateForJobinfo(int jobno, string trantype, int branchid, DateTime cdate, int closedby)
       {
           SqlParameter[] objp = { new SqlParameter("@jobno",SqlDbType.Int,4),
                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                    new SqlParameter("@bid",SqlDbType.Int,4),
                                    new SqlParameter("@cdate",SqlDbType.SmallDateTime,12),
                                    new SqlParameter("@jobclosedby",SqlDbType.Int,4)};
           objp[0].Value = jobno;
           objp[1].Value = trantype;
           objp[2].Value = branchid;
           objp[3].Value = cdate;
           objp[4].Value = closedby;
           ExecuteQuery("SpUpdCloseddateinJobInfo", objp);
       }
       public DataSet SelCostingTempRpt4JobBLwise(int jobno, string trantype, int bid, int empid)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@empid", SqlDbType.Int,4)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = trantype;
           objp[2].Value = bid;
           objp[3].Value = empid;

           return ExecuteDataSet("SPSelCostingTempRpt4JobBLwise", objp);
       }

       //Rajkumar

       public DataTable SelJobClsConfirm4JobCls(int jobno, string trantype, int bid, int cid)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        };
           objp[0].Value = jobno;
           objp[1].Value = trantype;
           objp[2].Value = bid;
           objp[3].Value = cid;

           return ExecuteTable("SPSelJobClsConfirm4JobCls", objp);
       }


       //ARUN

       public DataTable GetJobDetailsOpenForNew(string trantype, int intBranchID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1)};
           objp[0].Value = trantype;
           objp[1].Value = intBranchID;
           return ExecuteTable("SPGetJobOpenForNew", objp);
       }

       public DataTable GetJobDetailsOpenForNewFE(string trantype, int intBranchID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1)};
           objp[0].Value = trantype;
           objp[1].Value = intBranchID;
           return ExecuteTable("SPGetJobOpenOpsDocFe", objp);
       }


       //MUTHURAJ


       //public int GetJobclosedjobstatus(int jobno, int intBranchID, string trantype)
       //{
       //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
       //                                               new SqlParameter("@branchid", SqlDbType.Int),
       //                                               new SqlParameter("@trantype",SqlDbType.VarChar,2)
       //    };
       //    objp[0].Value = jobno;
       //    objp[1].Value = intBranchID;
       //    objp[2].Value = trantype;
       //    return int.Parse(ExecuteReader("sp_closedjob", objp));
       //}


       //QUOTATION
       public DataTable Updatesalespersonquotation(int quotno, int intBranchID, string trantype, int salesid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int),
                                                      new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@salesid", SqlDbType.Int)
           };
           objp[0].Value = quotno;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;
           objp[3].Value = salesid;
           return ExecuteTable("sp_salespersonquotationhead", objp);
       }
       //BL
       public DataTable Updatesalespersonbldetails(int jobno, int intBranchID, string trantype, string blno, int salesid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                      new SqlParameter("@salesid", SqlDbType.Int)
           };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;
           objp[3].Value = blno;
           objp[4].Value = salesid;
           return ExecuteTable("sp_salespersonupdatebl", objp);
       }
       //RPTVOSTINGDETAILS
       public DataTable UpdatesalespersonMISDetails(int jobno, int intBranchID, string trantype, string blno, int salesid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),                                                    
                                                      new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                      new SqlParameter("@salesid", SqlDbType.Int)
           };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;
           objp[3].Value = blno;
           objp[4].Value = salesid;
           return ExecuteTable("sp_salespersonMISDetails", objp);
       }
       //getquotno
       public DataTable getquotno(string blno, int intBranchID, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                      new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4)
                                                     
           };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;

           //return int.Parse(ExecuteReader("sp_getquotno", objp));

           return ExecuteTable("sp_getquotno", objp);
       }


       //MuthuRaj
       public int getoldsalespersonname(int quotno, int intBranchID, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@quotno",SqlDbType.Int),
                                                      new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4)
                                                     
           };
           objp[0].Value = quotno;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;

           //return int.Parse(ExecuteReader("sp_getquotno", objp));

           return int.Parse(ExecuteReader("sp_getsalesperson", objp));
       }

       public string getsalespersonnameold(int salesid)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                      
                                                      new SqlParameter("@salesid",SqlDbType.Int)
                                                     
           };
           objp[0].Value = salesid;


           //return int.Parse(ExecuteReader("sp_getquotno", objp));

           return ExecuteReader("sp_getsalesname", objp);
       }

       public DataTable GetJobclosedjobstatus(int jobno, int intBranchID, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2)
           };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;
           return ExecuteTable("sp_closedjob", objp);
           // return int.Parse(ExecuteReader("sp_closedjob", objp));
       }
       public int ediapprovedadd(int vouno, int BranchID, int vouyear, string voutype, string xmlfilename, string pdffilename, int approved)
       {
           SqlParameter[] objp = new SqlParameter[] 
           {
                                                      new SqlParameter("@vouno",SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.Int),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                      new SqlParameter("@voutype",SqlDbType.VarChar,10),
                                                      new SqlParameter("@xmlfilename",SqlDbType.VarChar,50),
                                                      new SqlParameter("@pdffilename",SqlDbType.VarChar,50),
                                                      new SqlParameter("@ediapproved",SqlDbType.Int),
                                                     
           };
           objp[0].Value = vouno;
           objp[1].Value = BranchID;
           objp[2].Value = vouyear;
           objp[3].Value = voutype;
           objp[4].Value = xmlfilename;
           objp[5].Value = pdffilename;
           objp[6].Value = approved;
           return int.Parse(ExecuteReader("sp_ediapprovedadd", objp));
       }




       public DataTable CheckApprovedVouchernew(int jobno, string trantype, int branchid, string voutype)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@voutype",SqlDbType.VarChar,1)};
           objp[0].Value = jobno;
           objp[1].Value = trantype;
           objp[2].Value = branchid;
           objp[3].Value = voutype;
           return ExecuteTable("SPCheckApprovedVouchernew", objp);
       }


       public DataTable getDetails4Salesperson(int JobNo, int intBranchID, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] 
           {
               new SqlParameter("@JobNo",SqlDbType.VarChar,50),
               new SqlParameter("@bid", SqlDbType.Int),
               new SqlParameter("@trantype",SqlDbType.VarChar,4)                                                    
           };
           objp[0].Value = JobNo;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;
           return ExecuteTable("sp_getSalesperson_ByJobNo", objp);
       }

       public string UpdateSalesperson(int JobNo, int intBranchID, string trantype, int OldSalesPersonId, int NewSalesPersonId, string Docno)
       {
           SqlParameter[] objp = new SqlParameter[] 
           {
               new SqlParameter("@JobNo",SqlDbType.Int),
               new SqlParameter("@bid", SqlDbType.Int),
               new SqlParameter("@trantype",SqlDbType.VarChar,4) ,
               new SqlParameter("@OldSalesPersonId", SqlDbType.Int),
               new SqlParameter("@NewSalesPersonId",SqlDbType.Int) ,
               new SqlParameter("@Docno",SqlDbType.VarChar,50) ,                             
           };
           objp[0].Value = JobNo;
           objp[1].Value = intBranchID;
           objp[2].Value = trantype;
           objp[3].Value = OldSalesPersonId;
           objp[4].Value = NewSalesPersonId;
           objp[5].Value = Docno;
           return ExecuteReader("sp_SalesPersonUpdate4CHA", objp);
       }


       public DataTable CheckShipmentTransferOrNotnewjobclosed(int jobno, int branchid, string TranType)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,1),
                                                       new SqlParameter("@branchid",SqlDbType.VarChar,10),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2) };
           objp[0].Value = jobno;
           objp[1].Value = branchid;
           objp[2].Value = TranType;
           return ExecuteTable("SPCheckShipmentTransferOrNotnewjobclosed", objp);
       }


       public DataTable Getunclosedjobnew(int divisionid, int branchid, int flag)
       {

           SqlParameter[] objp = new SqlParameter[]
             {
                 //new SqlParameter("@dbname",SqlDbType.VarChar,15),
                 new SqlParameter("@cid",SqlDbType.Int),
                 new SqlParameter("@bid1",SqlDbType.Int),
                 new SqlParameter("@flag",SqlDbType.Int)
                
             };
           objp[0].Value = divisionid;
           objp[1].Value = branchid;
           objp[2].Value = flag;

           // return ExecuteTable("SPGetUnclosedJobFAnew", objp);
           // return ExecuteTable("SPGetUnclosedJobFAnew1", objp);
           return ExecuteTable("SPGetUnclosedJobFAnew1ETAETDhome", objp);

       }
       //nivedha consolidate
       public DataTable GetunclosedjobnewWITHRET(int branchid, int empid, int flag)
       {

           SqlParameter[] objp = new SqlParameter[]
             {
                 //new SqlParameter("@dbname",SqlDbType.VarChar,15),
               
                 new SqlParameter("@bid1",SqlDbType.Int,1),
                 new SqlParameter("@empid",SqlDbType.Int,1),
                 new SqlParameter("@flag",SqlDbType.Int,1),
                 
               
             };
           objp[0].Value = branchid;
           objp[1].Value = empid;
           objp[2].Value = flag;

           // return ExecuteTable("SPGetUnclosedJobFAnew", objp);
           // return ExecuteTable("SPGetUnclosedJobFAnew1", objp);
           return ExecuteTable("SPGetUnclosedJobFAnew1ETAETDhomeproduct", objp);

       }
       public DataTable GetunclosedjobnewWITHRETnew(int branchid, int empid, int flag, DateTime fdate, DateTime tdate)
       {

           SqlParameter[] objp = new SqlParameter[]
             {
                 //new SqlParameter("@dbname",SqlDbType.VarChar,15),
               
                 new SqlParameter("@bid1",SqlDbType.Int,1),
                 new SqlParameter("@empid",SqlDbType.Int,1),
                 new SqlParameter("@flag",SqlDbType.Int,1),
                 new SqlParameter("@fromdate",SqlDbType.DateTime),
                 new SqlParameter("@todate",SqlDbType.DateTime)
               
             };
           objp[0].Value = branchid;
           objp[1].Value = empid;
           objp[2].Value = flag;
           objp[3].Value = fdate;
           objp[4].Value = tdate;
           // return ExecuteTable("SPGetUnclosedJobFAnew", objp);
           // return ExecuteTable("SPGetUnclosedJobFAnew1", objp);
           return ExecuteTable("SPGetUnclosedJobFAnew1ETAETDhomeproduct", objp);

       }
       public DataTable Getunclosedjobnewcorporate(int divisionid, int empid, int flag, DateTime fdate, DateTime tdate)
       {

           SqlParameter[] objp = new SqlParameter[]
             {
                 //new SqlParameter("@dbname",SqlDbType.VarChar,15),
               
                 new SqlParameter("@divisionid",SqlDbType.Int,1),
                 new SqlParameter("@empid",SqlDbType.Int,1),
                 new SqlParameter("@flag",SqlDbType.Int,1),
                 new SqlParameter("@fromdate",SqlDbType.DateTime),
                 new SqlParameter("@todate",SqlDbType.DateTime)
               
             };
           objp[0].Value = divisionid;
           objp[1].Value = empid;
           objp[2].Value = flag;
           objp[3].Value = fdate;
           objp[4].Value = tdate;
           // return ExecuteTable("SPGetUnclosedJobFAnew", objp);
           // return ExecuteTable("SPGetUnclosedJobFAnew1", objp);
           return ExecuteTable("SPGetUnclosedJobFAnew1ETAETDhomeproductcorp", objp);

       }

        // addeddd

        public int getopenjobcount(int branchid, string trantype, int empid)
        {

            SqlParameter[] objp = new SqlParameter[]
              {
          //new SqlParameter("@dbname",SqlDbType.VarChar,15),
        
          new SqlParameter("@bid",SqlDbType.Int,1),
          new SqlParameter("@trantype",SqlDbType.VarChar,2),
          new SqlParameter("@empid",SqlDbType.Int,1),
           new SqlParameter("@jobcount",SqlDbType.Int,4),
              };
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = empid;
            objp[3].Direction = ParameterDirection.Output;

            return ExecuteQuery("getopenjobcount", objp, "@jobcount");

        }
    }
 }

