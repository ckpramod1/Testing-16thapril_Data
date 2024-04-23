using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public  class checkvouchercount:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public checkvouchercount()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetvochercountCredit(DateTime fromdate, DateTime todate,int branchid,int divisionid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,4)
                                                     };
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = branchid;
           objp[3].Value = divisionid;


           return ExecuteTable("Sp_chkvouchercount_credit", objp);
       }



       public DataTable GetvochercountCreditAdmin(DateTime fromdate, DateTime todate, int branchid,int divisionid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,4)
                                                     };
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = branchid;
           objp[3].Value = divisionid;
           return ExecuteTable("Sp_chkvouchercount_creditAdmin", objp);
       }

     

       public DataTable Getvochercount(DateTime fromdate, DateTime todate, int branchid, int divisionid,int vouyear,string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int ),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                     };
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = branchid;
           objp[3].Value = divisionid;
           objp[4].Value = vouyear;
           objp[5].Value = dbname;
           return ExecuteTable("Sp_chkvouchercount", objp);
       }

       public DataTable Getvocherdetail(string type, DateTime fromdate, DateTime todate, int branchid, int divisionid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@vtype",SqlDbType.VarChar,20),
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,4)
                                                     };
           objp[0].Value = type ;
           objp[1].Value = fromdate;
           objp[2].Value = todate;
           objp[3].Value = branchid;
           objp[4].Value = divisionid;


           return ExecuteTable("Spvoucherdetail", objp);
       }
       public DataTable Getvocherdiff(string type, DateTime fromdate, DateTime todate, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@vtype",SqlDbType.VarChar,20),
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4)
                                                     };
           objp[0].Value = type;
           objp[1].Value = fromdate;
           objp[2].Value = todate;
           objp[3].Value = branchid;



           return ExecuteTable("Spvoucherdiff", objp);
       }

       public DataTable GetTDSdetails(string type,int vouno, int vouyear, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@voutype",SqlDbType.VarChar,20),
                                                         new SqlParameter("@vouno",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,1)
                                                     };
           objp[0].Value = type;
           objp[1].Value = vouno;
           objp[2].Value = vouyear;
           objp[3].Value = branchid;



           return ExecuteTable("SPGetTDSDtls", objp);
       }
       public DataTable  GetAmountDiff(DateTime fromdate, DateTime todate, int vouyear, int branchid,int divisionid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@divisionid",SqlDbType.TinyInt,4)
                                                         
                                                     };
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = vouyear ;
           objp[3].Value = branchid;
           objp[4].Value = divisionid;
         

           return ExecuteTable ("SPGetAmountDiff", objp);
       }

       public DataSet  GetAmountDetails(string Vtype, DateTime fromdate, DateTime todate, int vouyear, int branchid, int divisionid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@vtype",SqlDbType.VarChar,20),
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,4)
                                                     };
           objp[0].Value = Vtype;
           objp[1].Value = fromdate;
           objp[2].Value = todate;
           objp[3].Value = vouyear;
           objp[4].Value = branchid;
           objp[5].Value = divisionid;


           return ExecuteDataSet("Spvoucheramountdetail", objp);
       }
       public DataTable GetRepostDetails(int vouno,int voutype,int branch,int pbid,int corid,string stype,string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@vouno",SqlDbType.Int,4),
                                                         new SqlParameter("@voutype",SqlDbType.Int,4),
                                                         new SqlParameter("@branch",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@pbid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@corpid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@seltype",SqlDbType.VarChar,100),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                     };
           objp[0].Value = vouno;
           objp[1].Value = voutype;
           objp[2].Value = branch;
           objp[3].Value = pbid;
           objp[4].Value = corid;
           objp[5].Value = stype;
           objp[6].Value = dbname;


           return ExecuteTable("SPMyUseSelAllinOne4FA", objp);
       }
       public void Delvoudetail(int vouid,string dbname,string dtype)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                         new SqlParameter("@delType",SqlDbType.VarChar,15)
                                                        
                                                     };
           objp[0].Value = vouid;
           objp[1].Value = dbname;
           objp[2].Value = dtype;
         

           ExecuteQuery("SPMyUseDelVoucherFA", objp);
       }

       public DataSet GetDiffDetails(string Vtype, DateTime fromdate, DateTime todate, int vouyear, int branchid, int divisionid,int vouno,string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@vtype",SqlDbType.VarChar,20),
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@vouno",SqlDbType.Int,4),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                     };
           objp[0].Value = Vtype;
           objp[1].Value = fromdate;
           objp[2].Value = todate;
           objp[3].Value = vouyear;
           objp[4].Value = branchid;
           objp[5].Value = divisionid;
           objp[6].Value = vouno;
           objp[7].Value = dbname;


           return ExecuteDataSet("Spdiffvoucheramount", objp);
       }
       public DataTable GetBankpayment(DateTime fromdate, DateTime todate, int vouyear, int branchid, int divisionid,int corid,string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@divisionid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@corid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                         
                                                     };
           objp[0].Value = fromdate;
           objp[1].Value = todate;
           objp[2].Value = vouyear;
           objp[3].Value = branchid;
           objp[4].Value = divisionid;
           objp[5].Value = corid;
           objp[6].Value = dbname ;


           return ExecuteTable("spgetbankpay", objp);
       }

    //Select OSDN OSCN
       public DataTable SelOSDCNJV(int VouType,int VouNo,int BranchID,int VouYear,string OsvType,int CorpID,string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@VouType",SqlDbType.Int),
                                                         new SqlParameter("@VouNo",SqlDbType.Int),
                                                         new SqlParameter("@BranchID",SqlDbType.TinyInt),
                                                         new SqlParameter("@VouYear",SqlDbType.Int),
                                                         new SqlParameter("@OsvType",SqlDbType.VarChar,2),
                                                         new SqlParameter("@CorpID",SqlDbType.TinyInt),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)                                                         
                                                     };
           objp[0].Value = VouType ;
           objp[1].Value = VouNo ;
           objp[2].Value = BranchID ;
           objp[3].Value = VouYear ;
           objp[4].Value = OsvType ;
           objp[5].Value = CorpID ;
           objp[6].Value = dbname;
           return ExecuteTable("SPMyUseSelOSDCNJV", objp);
       }


       //KUMAR  - Voucher Count New
       public DataTable GetvochercountNew(int branchid,int vouyear,DateTime fromdate, DateTime todate,  int divisionid,  string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int ),
                                                         new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@to",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@divisionid",SqlDbType.TinyInt,4),                                                        
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,30)
                                                     };
           objp[0].Value = branchid;
           objp[1].Value = vouyear;
           objp[2].Value = fromdate;
           objp[3].Value = todate;
           objp[4].Value = divisionid;
           objp[5].Value = dbname;
           //return ExecuteTable("SPCompareFAandFACount", objp);  ////haribalaji
           return ExecuteTable("SPCompareopsandFACount_allhd", objp);
       }

       public DataTable GetvocherdiffNew(string type, DateTime fromdate, DateTime todate, int branchid,int vouyear,string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@vtype",SqlDbType.VarChar,30),
                                                         new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4),
                                                          new SqlParameter("@vouyear",SqlDbType.Int),
                                                          new SqlParameter("@dbname",SqlDbType.VarChar,30)                       
                                                     };
           objp[0].Value = type;
           objp[1].Value = fromdate;
           objp[2].Value = todate;
           objp[3].Value = branchid;
           objp[4].Value = vouyear;
           objp[5].Value = dbname;
           //return ExecuteTable("Spvoucherdiffnew", objp); ///haribalaji
           return ExecuteTable("SpvoucherdiffNew_allhd", objp);
       }


       public String DelAutoJV4Fa(int TranId, int RecNo, int RecBid, string DoType, string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@TranId",SqlDbType.BigInt),
                                                         new SqlParameter("@RecNo",SqlDbType.Int),
                                                         new SqlParameter("@RecBid",SqlDbType.BigInt),
                                                         new SqlParameter("@DoType",SqlDbType.VarChar,20),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,30)
                                                        
                                                     };
           objp[0].Value = TranId;
           objp[1].Value = RecNo;
           objp[2].Value = RecBid;
           objp[3].Value = DoType;
           objp[4].Value = dbname;
           return ExecuteReader("SPDelAutoJV4Fa", objp);
       }

       //FA
       //prabha

       public String DelVouchersFromFAraja(int vouid, string dbname, string dtype)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                         new SqlParameter("@delType",SqlDbType.VarChar,15)
                                                        
                                                     };
           objp[0].Value = vouid;
           objp[1].Value = dbname;
           objp[2].Value = dtype;
           return ExecuteReader("SPDelVoucherFromFAraja", objp);
       }





       public String DelAutoJV4Fa(int TranId, int RecNo, int RecBid, string DoType, string dbname, string rptype)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@TranId",SqlDbType.BigInt),
                                                         new SqlParameter("@RecNo",SqlDbType.Int),
                                                         new SqlParameter("@RecBid",SqlDbType.BigInt),
                                                         new SqlParameter("@DoType",SqlDbType.VarChar,20),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,30),
                                                         new SqlParameter("@rptype",SqlDbType.VarChar,1)

                                                     };
           objp[0].Value = TranId;
           objp[1].Value = RecNo;
           objp[2].Value = RecBid;
           objp[3].Value = DoType;
           objp[4].Value = dbname;
           objp[5].Value = rptype;
           return ExecuteReader("SPDelAutoJV4Fa", objp);
           //ExecuteQuery("SPDelAutoJV4Fa", objp);
       }

       public void DelMyUseCompareDrCrinFA(string dbname)
       {
           SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@dbname",SqlDbType.VarChar,15)  };
           
           objp[0].Value = dbname;

           ExecuteQuery("SPMyUseCompareDrCrinFAautodelete", objp);
       }

       


    }
}
