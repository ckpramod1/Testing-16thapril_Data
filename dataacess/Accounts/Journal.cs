using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class Journal:DBObject 
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Journal()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetLikeLedgernameforjournal(string ledgername, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAMasterledgernamejolike", objp);
        }
        public int Selvoutypeid(string vouname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouname", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouname;
            objp[1].Value = dbname;
            return int.Parse(ExecuteReader("SPFASelvoutypeid", objp));
        }
        //public int GetJournalNo(int branchid)
        //{

        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
        //    objp[0].Value = branchid;
        //    return int.Parse(ExecuteReader("SPUpdMCJournal", objp));
        //}
        ////public int GetJournalNoMONTH(int branchid)
        ////{

        ////    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
        ////    objp[0].Value = branchid;
        ////    return int.Parse(ExecuteReader("SPUpdMCJournal4month", objp)); 
        ////}

        public int GetJournalNoMONTH(int branchid, DateTime joudate)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@joudate", SqlDbType.DateTime,8 )};
            objp[0].Value = branchid;
            objp[1].Value = joudate;
            return int.Parse(ExecuteReader("SPUpdMCJournal4month", objp));
        }

        public int CheckFAExists4Voucher(int vouno, int vouyear, int branchid, int voutype, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.Int),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            objp[4].Value = dbname;
            return int.Parse(ExecuteReader("SPFACheckExists4Voucher", objp));
        }
        public int InsFAVouHead(string dbname, int voutypeid, string vouno, DateTime voudate, string narration, string trantype, int deptid, int jobno, int branchid, int divisionid, int updatedby, DateTime updatedon, char cancelled, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@voutypeid",SqlDbType.TinyInt),
                                                    new SqlParameter("@vouno",SqlDbType.VarChar,50),
                                                    new SqlParameter("@voudate",SqlDbType.DateTime),
                                                    new SqlParameter("@narration",SqlDbType.VarChar,250),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@deptid",SqlDbType.Int),
                                                    new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt),
                                                    new SqlParameter("@divisionid",SqlDbType.TinyInt),
                                                    new SqlParameter("@updatedby",SqlDbType.Int),
                                                    new SqlParameter("@updatedon",SqlDbType.DateTime),
                                                    new SqlParameter("@cancelled",SqlDbType.Char,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int),
                                                    new SqlParameter("@voucherid",SqlDbType.Int)};
            objp[0].Value = dbname;
            objp[1].Value = voutypeid;
            objp[2].Value = vouno;
            objp[3].Value = voudate;
            objp[4].Value = narration;
            objp[5].Value = trantype;
            objp[6].Value = deptid;
            objp[7].Value = jobno;
            objp[8].Value = branchid;
            objp[9].Value = divisionid;
            objp[10].Value = updatedby;
            objp[11].Value = updatedon;
            objp[12].Value = cancelled;
            objp[13].Value = vouyear;
            objp[14].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPFAInsVouHead", objp, "@voucherid");
        }

        public void InsFAVouDetails(string dbname, int vouid, int ledgerid, string ledgertype, double ledgeramount, int vouyear, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.Int),
                                                     new SqlParameter("@ledgerid",SqlDbType.Int),
                                                     new SqlParameter("@ledgertype",SqlDbType.Char,2),
                                                     new SqlParameter("@ledgeramount",SqlDbType.Money,8),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1)};


            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = ledgerid;
            objp[3].Value = ledgertype;
            objp[4].Value = ledgeramount;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = divisionid;
            //ExecuteQuery("SPFAInsFAVouDtls", objp);
            ExecuteQuery("SPMyUseChkCountinopsandFA", objp);

        }
        public void UpdJournalHead(string narration, int vouno, int branchid, int voutype, int vouyear, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@narration",SqlDbType.VarChar,250),
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = narration;
            objp[1].Value = vouno;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;
            ExecuteQuery("SPFAUpdJouVouHead", objp);
        }
        public int SelJouVouid(int vouno, int branchid, int voutype, int vouyear, string @dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;
            objp[4].Value = dbname;
            return int.Parse(ExecuteReader("SPFASelJouVouid", objp));
        }
        public void UpdJouledgerdetails(string dbname, int branchid, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouid",SqlDbType.Int,4)};
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = vouid;
            ExecuteQuery("SPFAUpdjouledamnt", objp);

        }
        //databse name to be removed
        public DataTable SelFAvoucherHead(int branchid, int vouyear, int vouno, int voutypeid, string dbname,int voumonth)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@voumonth",SqlDbType.Int)};

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = vouno;
            objp[3].Value = voutypeid;
            objp[4].Value = dbname;
            objp[5].Value = voumonth;
            return ExecuteTable("SPFASelVouHead", objp);
        }

        public DataTable SelFAvoucherDetails(int branchid, int vouyear, int vouno, int voutypeid, string dbname,int voumonth)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@voumonth",SqlDbType.Int)};

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = vouno;
            objp[3].Value = voutypeid;
            objp[4].Value = dbname;
            objp[5].Value = @voumonth;
            return ExecuteTable("SPFASelVouDetails", objp);
        }
        //databse name to be removed
        public void DelJouDetails(int branchid, int vouyear, int voutype, int vouno, int vousubid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@voutypeid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@vousubid",SqlDbType.Int,4),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = voutype;
            objp[3].Value = vouno;
            objp[4].Value = vousubid;
            objp[5].Value = dbname;
            ExecuteQuery("SPFADelJouDetails", objp);
        }


        //VouHead 4 ManualVouchers

        public DataTable SelVouHead4ManualVou(int branchid, int vouyear, int vouno, int voutypeid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                       };

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = vouno;
            objp[3].Value = voutypeid;
            objp[4].Value = dbname;
           
            return ExecuteTable("SPFASelVouHead4ManualVou", objp);
        }

        public DataTable SelFAvoucherDetails4ManualVou(int branchid, int vouyear, int vouno, int voutypeid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        };

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = vouno;
            objp[3].Value = voutypeid;
            objp[4].Value = dbname;
            
            return ExecuteTable("SPFASelVouDetails4ManualVou", objp);
        }

        //get COde from ManualACCode
        public int UpdMasterManualACCode(string type, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@type",SqlDbType.VarChar,10),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@vouyear",SqlDbType.Int)
                                                        };
            objp[0].Value = type;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            return int.Parse(ExecuteReader("SPUpdMasterManualACCode", objp));
        }

        

        //FA

        public void UpdJouVouHead4AdjDCN(string narration, int vouno, int branchid, int voutype, int vouyear, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@narration",SqlDbType.VarChar,250),
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = narration;
            objp[1].Value = vouno;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;
            ExecuteQuery("SPFAUpdJouVouHead4AdjDCN", objp);
        }

        public void InsFAVouHeadDeleted(string dbname, int updatedby, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@vouid",SqlDbType.BigInt),
                                                    new SqlParameter("@updatedby",SqlDbType.Int)
                                                  
                                                    };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = updatedby;


            ExecuteQuery("SPFAInsVouHeadDeleted", objp);
        }

        
        public void UpdJouHead(string dbname, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt),
                                                     
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;

            ExecuteQuery("SPFAUpdJouHead", objp);
        }

        public void InsFAVouDtlsDeleted(string dbname, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt)};
            objp[0].Value = dbname;
            objp[1].Value = vouid;

            ExecuteQuery("SPFAInsVouDtlsDeleted", objp);
        }

        public void DelVouDetails(int vouid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                     new SqlParameter("@vouid",SqlDbType.BigInt),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};

            objp[0].Value = vouid;
            objp[1].Value = dbname;
            ExecuteQuery("SPFADelVouDetails", objp);
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

        public string GetJouApprovedBy(int VouId, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                            new SqlParameter("@VouId", SqlDbType.Int ),
                                                            new SqlParameter("@dbname", SqlDbType.VarChar,15)};
            objp[0].Value = VouId;
            objp[1].Value = dbname;
            string retval = ExecuteReader("SPGetJouApprovedBy", objp);
            return retval;
        }


        public DataTable SelMaxJouamt(int tranid, char rptype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1)
                                                       };
            objp[0].Value = tranid;
            objp[1].Value = rptype;

            return ExecuteTable("SPSelMaxJouamt", objp);
        }

        public DataTable GetLikeLedgernameforADCN(string ledgername, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAMasterledgernameADCNlike", objp);
        }
    }
}
