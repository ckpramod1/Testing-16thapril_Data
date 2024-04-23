using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class FAVoucher : DBObject
    {
        public int voucherid;


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FAVoucher()
        {
            Conn = new SqlConnection(DBCS);
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
           /// return ExecuteQuery("SPFAInsFAVouHead", objp, "@voucherid");haribalaji
            return ExecuteQuery("SPFAInsVouHead_allhd", objp, "@voucherid");
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
            //ExecuteQuery("SPFAInsFAVouDtls", objp); haribalaji
            ExecuteQuery("SPFAInsVouDtls_allhd", objp);

        }
        public int Selledgerid(string dbname, int opsid, char opstype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@opsid",SqlDbType.Int,4),
                                                     new SqlParameter("@opstype",SqlDbType.Char,1)};
            objp[0].Value = dbname;
            objp[1].Value = opsid;
            objp[2].Value = opstype;
            return int.Parse(ExecuteReader("SPFASellegerid", objp));
        }

        public int Selledgeridforops(string dbname, string ledgername, char opstype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@ledgername",SqlDbType.VarChar,150),
                                                     new SqlParameter("@opstype",SqlDbType.Char,1)};
            objp[0].Value = dbname;
            objp[1].Value = ledgername;
            objp[2].Value = opstype;
            return int.Parse(ExecuteReader("SPFASellegeridforOps", objp));
        }
        public double GetFATDSAmount(int branchid, char voutype, int vouno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            objp[2].Value = vouno;
            objp[3].Value = vouyear;
            return double.Parse(ExecuteReader("SPFAGetPTDSAmnt", objp));
        }

        public string GetFAPortcode(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) };
            objp[0].Value = branchid;
            return ExecuteReader("SPFAGetPortcode", objp);
        }
        public int Selvoutypeid(string vouname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouname", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouname;
            objp[1].Value = dbname;
            return int.Parse(ExecuteReader("SPFASelvoutypeid", objp));
        }
        public DataTable SelFAVoucher(int vouno, int branchid, int divisionid, int voutypeid, int vouyear, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = voutypeid;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;
            return ExecuteTable("SPSelFAVoucher", objp);
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
        public int GetJournalNo(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCJournal", objp));
        }

        //in query dbname has to be removed.. month number pass shl

        //krishna command due to
        //public DataTable SelFAvoucherHead(int branchid, int vouyear, int vouno, int voutypeid, string dbname)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
        //                                                new SqlParameter("@vouyear",SqlDbType.Int),
        //                                                new SqlParameter("@vouno", SqlDbType.Int, 4),
        //                                                new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
        //                                                new SqlParameter("@dbname",SqlDbType.VarChar,15)};

        //    objp[0].Value = branchid;
        //    objp[1].Value = vouyear;
        //    objp[2].Value = vouno;
        //    objp[3].Value = voutypeid;
        //    objp[4].Value = dbname;
        //    return ExecuteTable("SPFASelVouHead", objp);
        //}
        //in query dbname has to be removed..
        //public DataTable SelFAvoucherDetails(int branchid, int vouyear, int vouno, int voutypeid, string dbname)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
        //                                                new SqlParameter("@vouyear",SqlDbType.Int),
        //                                                new SqlParameter("@vouno", SqlDbType.Int, 4),
        //                                                new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
        //                                                new SqlParameter("@dbname",SqlDbType.VarChar,15)};

        //    objp[0].Value = branchid;
        //    objp[1].Value = vouyear;
        //    objp[2].Value = vouno;
        //    objp[3].Value = voutypeid;
        //    objp[4].Value = dbname;
        //    return ExecuteTable("SPFASelVouDetails", objp);
        //}
        ////end krishna

        public DataTable SelFAvoucherHead(int branchid, int vouyear, int vouno, int voutypeid, string dbname, int voumonth)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),            
                                                        new SqlParameter("@voumonth",SqlDbType.Int) };

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = vouno;
            objp[3].Value = voutypeid;
            objp[4].Value = dbname;
            objp[5].Value = voumonth;
            return ExecuteTable("SPFASelVouHead", objp);
        }

        public DataTable SelFAvoucherDetails(int branchid, int vouyear, int vouno, int voutypeid, string dbname, int voumonth)
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
            return ExecuteTable("SPFASelVouDetails", objp);
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


        public void UpdJournalDetails(int vouno, int branchid, int voutype, int vouyear, int ledgerid, string ledgertype, double ledgeramnt, int vousubid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                     new SqlParameter("@ledgertype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@ledgeramnt",SqlDbType.Money,8),
                                                     new SqlParameter("@vousubid",SqlDbType.Int,4),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;
            objp[4].Value = ledgerid;
            objp[5].Value = ledgertype;
            objp[6].Value = ledgeramnt;
            objp[7].Value = vousubid;
            objp[8].Value = dbname;
            ExecuteQuery("SPFAUpdJouVouDetails", objp);
        }

        public int SelJouSubId(int vouno, int branchid, int voutype, int vouyear, int ledgerid, string ledgertype, double ledgeramnt, string @dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                     new SqlParameter("@ledgertype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@ledgeramnt",SqlDbType.Real,8),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;
            objp[4].Value = ledgerid;
            objp[5].Value = ledgertype;
            objp[6].Value = ledgeramnt;
            objp[7].Value = dbname;
            return int.Parse(ExecuteReader("SPFASelJouVSubid", objp));
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
        public DataTable GetFAES(int rid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rid", SqlDbType.Int, 4) };
            objp[0].Value = rid;
            return ExecuteTable("SPFAGetESDtls", objp);
        }
        public int CheckFAExists4VoucherES(int vouno, int vouyear, int branchid, int voutype, int ledgerid, string ltype, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.Int),
                                                     new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@ltype",SqlDbType.VarChar,3),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            objp[4].Value = ledgerid;
            objp[5].Value = ltype;
            objp[6].Value = dbname;
            return int.Parse(ExecuteReader("SPFACheckExists4VoucherES", objp));
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
        public DataTable GetFAquery(string Qtype, double Amount, string Remarks, int BranchID, string DBname)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@qtype",SqlDbType.VarChar,10),
                                                      new SqlParameter("@amount",SqlDbType.Money,8),
                                                      new SqlParameter("@rmks",SqlDbType.VarChar,100),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = Qtype;
            objp[1].Value = Amount;
            objp[2].Value = Remarks;
            objp[3].Value = BranchID;
            objp[4].Value = DBname;
            return ExecuteTable("SPGetFAQuery", objp);
        }

        //rr
        public int UpdateFAVouHeadDetails(string dbname, string DataFrom, int vouid, string chqrefno, int jobno, string fvrname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@DataFrom",SqlDbType.VarChar ,25),
                                                       new SqlParameter("@vouid",SqlDbType.Int ,4),
                                                     new SqlParameter("@chqrefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno",SqlDbType.Int ,4),
                                                        new SqlParameter("@fvrname",SqlDbType.VarChar,150)};
            objp[0].Value = dbname;
            objp[1].Value = DataFrom;
            objp[2].Value = vouid;
            objp[3].Value = chqrefno;
            objp[4].Value = jobno;
            objp[5].Value = fvrname;
            return int.Parse(ExecuteReader("SPFAUpdateVouHeadDetails", objp));
        }


        //Krishna 31/12/2011

        public DataTable SelFAvoucherHeadWOMonth(int branchid, int vouyear, int vouno, int voutypeid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = vouno;
            objp[3].Value = voutypeid;
            objp[4].Value = dbname;
            return ExecuteTable("SPFASelVouHeadWOmonth", objp);
        }

        public DataTable SelFAvoucherDetailsWOMonth(int branchid, int vouyear, int vouno, int voutypeid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.TinyInt, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = vouno;
            objp[3].Value = voutypeid;
            objp[4].Value = dbname;
            return ExecuteTable("SPFASelVouDetailsWOMonth", objp);
        }

        public DataTable GetContraClearanceDetails4BRS(int Branchid, string dbname, DateTime clearedon)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;

            return ExecuteTable("SPGetContraClearanceDtls4BRS", objp);

        }

        public DataTable GetContraClearanceDetails4BRS(int Branchid, string dbname, DateTime clearedon, int ledgerid, string str_Type, string curtype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.VarChar ,20),
                                                        new SqlParameter("@curtype",SqlDbType.VarChar,5)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            objp[4].Value = str_Type;
            objp[5].Value = curtype;
            return ExecuteTable("SPGetContraClearanceDtls4BRS", objp);

        }

        public DataTable GetContraClearanceDetails4BRS(int Branchid, string dbname, DateTime clearedon, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int,4)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            return ExecuteTable("SPGetContraClearanceDtls4BRS", objp);

        }

        public void UpdContraClearanceDetails(char truefalse, DateTime clearedon, int vouid, string Dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@truefalse", SqlDbType.Char, 1),
                                                      new SqlParameter("@clearedon", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@vouid", SqlDbType.Int, 4),
                                                      new SqlParameter("@Dbname",SqlDbType.VarChar,20)};
            objp[0].Value = truefalse;
            objp[1].Value = clearedon;
            objp[2].Value = vouid;
            objp[3].Value = Dbname;
            ExecuteQuery("SPUpdContraClearanceDtls1", objp);
        }

        public DataTable GetContraClearanceDetails(int Branchid, string dbname, DateTime clearedon)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;

            return ExecuteTable("SPGetContraClearanceDtls", objp);

        }

        public DataTable GetContraClearance4Chq(int Branchid, string dbname, string chqno)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@chqno",SqlDbType.VarChar ,30)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = chqno;

            return ExecuteTable("SPGetContraClearance4Chq", objp);

        }

        public DataTable GetFAquery(string Qtype, double Amount, string Remarks, int BranchID, string DBname, string Chqno, string ledgername, int voutypeid, DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@qtype",SqlDbType.VarChar,10),
                                                      new SqlParameter("@amount",SqlDbType.Money,8),
                                                      new SqlParameter("@rmks",SqlDbType.VarChar,100),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@chequeno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@ledgername",SqlDbType.VarChar ,100),
                                                      new SqlParameter("@voutypeid",SqlDbType.Int ,4),
                                                      new SqlParameter("@from",SqlDbType.DateTime),
                                                      new SqlParameter("@to",SqlDbType.DateTime )};
            objp[0].Value = Qtype;
            objp[1].Value = Amount;
            objp[2].Value = Remarks;
            objp[3].Value = BranchID;
            objp[4].Value = DBname;
            objp[5].Value = Chqno;
            objp[6].Value = ledgername;
            objp[7].Value = voutypeid;
            objp[8].Value = from;
            objp[9].Value = to;
            return ExecuteTable("SPGetFAQuery", objp);
        }

        public DataSet GetAllVoucherTypes(string DbName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname", SqlDbType.VarChar, 20) };
            objp[0].Value = DbName;
            return ExecuteDataSet("SPGetAllVouTypes", objp);
        }
        //End
        //Update Reference No       KUMAR
        public void UpdRefno4VouHead(int vouid, string refno, string Dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@vouid", SqlDbType.Int, 4),
                                                      new SqlParameter("@comrefno",SqlDbType.VarChar,500),
                                                      new SqlParameter("@Dbname",SqlDbType.VarChar,20)};
            objp[0].Value = vouid;
            objp[1].Value = refno;
            objp[2].Value = Dbname;
            ExecuteQuery("SPFAUpdRefno4VouHead", objp);
        }
        //Update NEW  Field       RAJA
        public void UpdNEW4VouHead(int vouid, string vref, string cont, string Dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@vouid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vendrefno",SqlDbType.VarChar,50),
                                                      new SqlParameter("@contno",SqlDbType.VarChar,500),
                                                      new SqlParameter("@Dbname",SqlDbType.VarChar,20)};
            objp[0].Value = vouid;
            objp[1].Value = vref;
            objp[2].Value = cont;
            objp[3].Value = Dbname;
            ExecuteQuery("SPFAUpdnewfield4VouHead", objp);
        }

        //nambi 4 OSDN and OSCN

        public void UpdFAVouDtls4OS(string dbname, int vouid, string fcur, double famt, double exrate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                    new SqlParameter("@fcur",SqlDbType.VarChar,3),
                                                    new SqlParameter("@famt",SqlDbType.Money,8),
                                                    new SqlParameter("@exrate",SqlDbType.Money,8),
            
            
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = fcur;
            objp[3].Value = famt;
            objp[4].Value = exrate;
            ExecuteQuery("SPFAUpdVouDtls4OS", objp);

        }
        public void UpdPBid4VouHead(string dbname, int vouid, int PBid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@PBid",SqlDbType.TinyInt)
            
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = PBid;
            ExecuteQuery("SPUpdPBid4VouHead", objp);

        }

        public int CheckFAExists4Voucher4Corp(int vouno, int vouyear, int branchid, int voutype, string dbname)
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
            return int.Parse(ExecuteReader("SPFACheckExists4Voucher4Corp", objp));
        }

        //to generate the BDJV number
        public int GetBDJVNONo(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdBDJVNO", objp));
        }

        public int CheckFAExists4Voucher4CorpJV(int vouno, int vouyear, int branchid, int voutype, int corrpid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.Int),
                                                      new SqlParameter("@corpid",SqlDbType.Int),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            objp[4].Value = corrpid;
            objp[5].Value = dbname;
            return int.Parse(ExecuteReader("SPFACheckExists4Voucher4CorpJV", objp));
        }


        public void UpdFAVouDtls4OSRP(string dbname, int vouid, string fcur, double famt, double exrate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                    new SqlParameter("@fcur",SqlDbType.VarChar,3),
                                                    new SqlParameter("@famt",SqlDbType.Money,8),
                                                    new SqlParameter("@exrate",SqlDbType.Money,8),
            
            
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = fcur;
            objp[3].Value = famt;
            objp[4].Value = exrate;
            ExecuteQuery("SPFAUpdVouDtls4OSRP", objp);

        }
        public int Getvousubid4OS(string dbname, int vouid, int ledgerid, string ledgertype, double ledgeramount, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.Int),
                                                     new SqlParameter("@ledgerid",SqlDbType.Int),
                                                     new SqlParameter("@ledgertype",SqlDbType.Char,2),
                                                     new SqlParameter("@ledgeramount",SqlDbType.Money,8),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                   };


            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = ledgerid;
            objp[3].Value = ledgertype;
            objp[4].Value = ledgeramount;
            objp[5].Value = vouyear;

            return int.Parse(ExecuteReader("SPFAGetvousubid4OS", objp));

        }


        //For OverSeas Vouchers
        public void Updosvtype4VouHead(string dbname, int vouid, string osvtype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                     new SqlParameter("@osvtype",SqlDbType.Char,1)
            
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = osvtype;
            ExecuteQuery("SPUpdosvtype4VouHead", objp);

        }
        public DataTable SelFAVoucher4OSVou(int vouno, int branchid, int divisionid, int voutypeid, int vouyear, string dbname, int PBid, string osvtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@PBid", SqlDbType.TinyInt),
                                                        new SqlParameter("@osvtype",SqlDbType.Char )};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = voutypeid;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;
            objp[6].Value = PBid;
            objp[7].Value = osvtype;
            return ExecuteTable("SPSelFAVoucher4OSVou", objp);
        }

        //Payment Reversal

        public void ReversalPmtinFA(int bid, int vouno, int voutype, int corpid, string narration, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt),
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.Int,4),
                                                     new SqlParameter("@corpid",SqlDbType.TinyInt ),
                                                     new SqlParameter("@narration",SqlDbType.VarChar,500),
                                                     new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = bid;
            objp[1].Value = vouno;
            objp[2].Value = voutype;
            objp[3].Value = corpid;
            objp[4].Value = narration;
            objp[5].Value = empid;
            objp[6].Value = dbname;
            ExecuteQuery("SPReversalPmtinFA", objp);

        }

        //Select Voucher From Finance
        public DataTable GetRepostDetails(int vouno, int voutype, int branch, int pbid, int corid, string stype, string dbname)
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

        //Delete Voucher From Finance
        public void Delvoudetail(int vouid, string dbname, string dtype)
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

        //to generate the BRRJV & BPRJV number
        public int GetBPRRJVNO(int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt),
                                                       new SqlParameter("@type", SqlDbType.Char,1)};
            objp[0].Value = branchid;
            objp[1].Value = type;
            return int.Parse(ExecuteReader("SPUpdRJV", objp));
        }

        //Update RPNarration       KUMAR
        public void UpdRPNarr4VouHead(int vouid, string rpnarr, string Dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@vouid", SqlDbType.Int, 4),
                                                      new SqlParameter("@RPNarr",SqlDbType.VarChar,2000),
                                                      new SqlParameter("@Dbname",SqlDbType.VarChar,20)};
            objp[0].Value = vouid;
            objp[1].Value = rpnarr;
            objp[2].Value = Dbname;
            ExecuteQuery("SPFAUpdRPNarr4VouHead", objp);
        }


        //
        public int Sellegerid4IntrBr(string ledgername, char opstype, int bid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                     new SqlParameter("@ledgername",SqlDbType.VarChar,150),
                                                     new SqlParameter("@opstype",SqlDbType.Char,1),
                                                     new SqlParameter("@BrId",SqlDbType.TinyInt),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,30)};
            objp[0].Value = ledgername;
            objp[1].Value = opstype;
            objp[2].Value = bid;
            objp[3].Value = dbname;
            return int.Parse(ExecuteReader("SPFASellegerid4IntrBr", objp));
        }


        //Dinesh
        public string getfinalize(int branchid, int divisionid, int empid, string FADbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar,15)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = empid;
            objp[3].Value = FADbname;

            return ExecuteReader("sp_getfinalize", objp);
        }


        //Karthika

        public DataTable SPReversalRcptCorpinFA(int branchid, int vouno, int voutype, int corpid, string narration, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]
            {

                new SqlParameter("@bid",SqlDbType.TinyInt),
                new SqlParameter("@vouno",SqlDbType.Int ,4),
                new SqlParameter("@voutype",SqlDbType.TinyInt),
                 new SqlParameter("@corpid",SqlDbType.TinyInt),
                 new SqlParameter("@narration",SqlDbType.VarChar,500),
                 new SqlParameter("@empid",SqlDbType.Int ,4),
                new SqlParameter("@dbname",SqlDbType.VarChar,30)
            };
            objp[0].Value = branchid;
            objp[1].Value = vouno;
            objp[2].Value = voutype;
            objp[3].Value = corpid;
            objp[4].Value = narration;
            objp[5].Value = empid;
            objp[6].Value = dbname;
            return ExecuteTable("SPReversalRcptCorpinFA", objp);

        }


        public DataTable SPReversalRcptCorpinFA4OldChq(int branchid, int vouno, int voutype, int corpid, string narration, int empid, string dbname, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            {

                new SqlParameter("@bid",SqlDbType.TinyInt),
                new SqlParameter("@vouno",SqlDbType.Int ,4),
                new SqlParameter("@voutype",SqlDbType.TinyInt),
                 new SqlParameter("@corpid",SqlDbType.TinyInt),
                 new SqlParameter("@narration",SqlDbType.VarChar,500),
                 new SqlParameter("@empid",SqlDbType.Int ,4),
                new SqlParameter("@dbname",SqlDbType.VarChar,30),
                new SqlParameter("@vouyr",SqlDbType.Int)
            };
            objp[0].Value = branchid;
            objp[1].Value = vouno;
            objp[2].Value = voutype;
            objp[3].Value = corpid;
            objp[4].Value = narration;
            objp[5].Value = empid;
            objp[6].Value = dbname;
            objp[7].Value = vouyear;
            return ExecuteTable("SPReversalRcptCorpinFA4OldChq", objp);

        }

        public void ReversalPmtinFA4OldChq(int bid, int vouno, int voutype, int corpid, string narration, int empid, string dbname, int vouyr)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt),
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.Int,4),
                                                     new SqlParameter("@corpid",SqlDbType.TinyInt ),
                                                     new SqlParameter("@narration",SqlDbType.VarChar,500),
                                                     new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouyr",SqlDbType.Int)};
            objp[0].Value = bid;
            objp[1].Value = vouno;
            objp[2].Value = voutype;
            objp[3].Value = corpid;
            objp[4].Value = narration;
            objp[5].Value = empid;
            objp[6].Value = dbname;
            objp[7].Value = vouyr;
            ExecuteQuery("SPReversalPmtinFA4OldChq", objp);

        }

        //RAJA
        public void GetSTAmt4STTypeGSTOS(string dbname, int vouid, int ledgerid, string ledgertype, double ledgeramount, int vouyear, int branchid, int divisionid, int vouno, int voutype, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.Int),
                                                     new SqlParameter("@ledgerid",SqlDbType.Int),
                                                     new SqlParameter("@ledgertype",SqlDbType.Char,2),
                                                     new SqlParameter("@ledgeramount",SqlDbType.Money,8),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouno",SqlDbType.Int,1),
                                                     new SqlParameter("@voutype",SqlDbType.Int,1),
                                                     new SqlParameter("@jobno",SqlDbType.Int,1),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),};


            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = ledgerid;
            objp[3].Value = ledgertype;
            objp[4].Value = ledgeramount;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = divisionid;
            objp[8].Value = vouno;
            objp[9].Value = voutype;
            objp[10].Value = jobno;
            objp[11].Value = trantype;
            //ExecuteQuery("SPFAInsFAVouDtls", objp);
            ExecuteQuery("SPGetSTAmt4STTypeGSTOS", objp);

        }

        public double GetSTAmt4STTypeGSTOSagent(string dbname, int vouid, int ledgerid, string ledgertype, double ledgeramount, int vouyear, int branchid, int divisionid, int vouno, int voutype, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.Int),
                                                     new SqlParameter("@ledgerid",SqlDbType.Int),
                                                     new SqlParameter("@ledgertype",SqlDbType.Char,2),
                                                     new SqlParameter("@ledgeramount",SqlDbType.Money,8),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouno",SqlDbType.Int,1),
                                                     new SqlParameter("@voutype",SqlDbType.Int,1),
                                                     new SqlParameter("@jobno",SqlDbType.Int,1),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@igstamt",SqlDbType.Money,8)   };


            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = ledgerid;
            objp[3].Value = ledgertype;
            objp[4].Value = ledgeramount;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = divisionid;
            objp[8].Value = vouno;
            objp[9].Value = voutype;
            objp[10].Value = jobno;
            objp[11].Value = trantype;
            objp[12].Direction = ParameterDirection.Output;
            //ExecuteQuery("SPFAInsFAVouDtls", objp);
            return ExecuteQuerydouble("SPGetSTAmt4STTypeGSTOSagent", objp, "@igstamt");

        }



        //nambi 4 Adj AN/CN

        public int GetMCAdjDNCN(string type, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@type",SqlDbType.VarChar,2),
                                    new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = type;
            objp[1].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCAdjDNCN", objp));
        }
        public void UpdFAVouDtls4AdjDNCN(string dbname, int vouid, string refno, string fcur, double famt, double exrate, int ledgerid, string ledgertype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                    new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@fcur",SqlDbType.VarChar,3),
                                                    new SqlParameter("@famt",SqlDbType.Money,8),
                                                    new SqlParameter("@exrate",SqlDbType.Money,8),
                                                    new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                    new SqlParameter("@ledgertype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),
            
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = refno;
            objp[3].Value = fcur;
            objp[4].Value = famt;
            objp[5].Value = exrate;
            objp[6].Value = ledgerid;
            objp[7].Value = ledgertype;
            objp[8].Value = vouyear;
            ExecuteQuery("SPFAUpdVouDtls4AdjDNCN", objp);

        }

        public void updfinalize(int branchid, int divisionid, int empid, string FADbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),    
                                                      new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                      };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = empid;
            objp[3].Value = FADbname;

            ExecuteQuery("sp_updfinalize", objp);
        }




        public DataTable GetManRPClearanceDetails4BRS(int Branchid, string dbname, DateTime clearedon, int ledgerid, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.Char,1)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            objp[4].Value = type;
            return ExecuteTable("SPGetManRPClearanceDtls4BRS", objp);

        }

        public DataTable GetManRPClearanceDetails4BRS(int Branchid, string dbname, DateTime clearedon, int ledgerid, string type, string curtype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.Char,1),
                                                        new SqlParameter("@cutype",SqlDbType.VarChar,5)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            objp[4].Value = type;
            objp[5].Value = curtype;
            return ExecuteTable("SPGetManRPClearanceDtls4BRS", objp);

        }

        public DataTable getCollectVouAging(DateTime fdate, DateTime tdate, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@from",SqlDbType.DateTime,8),
                                                       new SqlParameter("@to",SqlDbType.DateTime,8),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@divisionid",SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = fdate;
            objp[1].Value = tdate;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;

            // return ExecuteTable("spgetCollectVouAging", objp);
            return ExecuteTable("spgetCollectVouAgingnew1", objp);
        }

        public DataTable More60Rec(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@divisionid",SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("spmore60rec", objp);
        }

        //prabha
        public DataTable GetTBDrCrDiffinFA(int DivId, int Bid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@divID", SqlDbType.Int, 4),
                                                        new SqlParameter("@Bid", SqlDbType.Int, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,30)};
            objp[0].Value = DivId;
            objp[1].Value = Bid;
            objp[2].Value = dbname;
            return ExecuteTable("SPGetTBDrCrDiffinFA", objp);
        }


        //---------Karthika_K

        public int GetVouId(int Vouno, int BranchID, int voutype, string @dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {                                                                                                              
                                                        new SqlParameter("@Vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@BranchID",SqlDbType.TinyInt,1),                                                        
                                                        new SqlParameter("@voutype",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),};
            objp[0].Value = Vouno;
            objp[1].Value = BranchID;
            objp[2].Value = voutype;
            objp[3].Value = dbname;
            return int.Parse(ExecuteReader("SP_GetVouID", objp));
        }

        //-------- For Jouranl 

        public int GetVouIdJou(int Vouno, int BranchID, int voutype, string @dbname, int month)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@Vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@BranchID",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@voutype",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@month",SqlDbType.Int,4)};
            objp[0].Value = Vouno;
            objp[1].Value = BranchID;
            objp[2].Value = voutype;
            objp[3].Value = dbname;
            objp[4].Value = month;

            return int.Parse(ExecuteReader("SP_GetVouIDJOU", objp));
        }

        public void SPFAUpdFAVouDtls4Fcur(string dbname, int vouid, string fcur, double famt, double exrate, int ledgerid, string ledgertype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                    new SqlParameter("@fcur",SqlDbType.VarChar,3),
                                                    new SqlParameter("@famt",SqlDbType.Money,8),
                                                    new SqlParameter("@exrate",SqlDbType.Money,8),
                                                    new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                    new SqlParameter("@ledgertype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),
            
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = fcur;
            objp[3].Value = famt;
            objp[4].Value = exrate;
            objp[5].Value = ledgerid;
            objp[6].Value = ledgertype;
            objp[7].Value = vouyear;
            ExecuteQuery("SPFAUpdVouDtls4Fcur", objp);

        }

        //---------Karthika_K

        public DataTable SelFAAllVoucher(int voutypeid, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {                                                                                                              
                                                        new SqlParameter("@vouid", SqlDbType.Int, 4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = voutypeid;
            objp[1].Value = empid;
            objp[2].Value = dbname;
            return ExecuteTable("SPInsTempvoucherRPT", objp);
        }

        public DataTable GetContraClearanceDetails(int Branchid, string dbname, DateTime clearedon, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@datetype",SqlDbType.NVarChar,5)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = datetype;
            return ExecuteTable("SPGetContraClearanceDtls", objp);

        }


        public DataTable GetManRPClearanceDtls(int Branchid, string dbname, DateTime clearedon, string vtype, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@type",SqlDbType.Char ,1),
                                                        new SqlParameter("@datetype",SqlDbType.NVarChar ,5)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = vtype;
            objp[4].Value = datetype;
            return ExecuteTable("SPGetManRPClearanceDtls", objp);
        }

        public DataTable GetRecRevClearanceDetails(int Branchid, string dbname, DateTime clearedon, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@datetype",SqlDbType.NVarChar,5)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = datetype;
            return ExecuteTable("SPGetRecRevClearanceDtls", objp);

        }


        public DataTable GetPayRevClearanceDetails(int Branchid, string dbname, DateTime clearedon, string datetype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@datetype",SqlDbType.NVarChar,5)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = datetype;
            return ExecuteTable("SPGetPayRevClearanceDtls", objp);

        }

        public DataTable GetManRPClearanceDBTtoal(int Branchid, string dbname, DateTime clearedon, int ledgerid, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),    
                                                        new SqlParameter("@ledgerid",SqlDbType.Int),
                                                        new SqlParameter("@type",SqlDbType.Char,1)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            objp[4].Value = type;
            return ExecuteTable("SPGetManRPClearanceDBTotal", objp);

        }

        public DataTable GetContraClearanceDBTtoal(int Branchid, string dbname, DateTime clearedon, int ledgerid, string str_Type)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),    
                                                        new SqlParameter("@ledgerid",SqlDbType.Int),
                                                        new SqlParameter("@type",SqlDbType.VarChar,10)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            objp[4].Value = str_Type;
            return ExecuteTable("SPGetcontraClearanceDBTotal", objp);

        }

        public DataTable GetContraClearanceTtoal(int Branchid, string dbname, DateTime clearedon, int ledgerid, string str_type)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.VarChar,10)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            objp[4].Value = str_type;
            return ExecuteTable("SPGetcontraClearanceTotal", objp);

        }

        public DataTable GetContraClearanceTtoal(int Branchid, string dbname, DateTime clearedon, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@Branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar ,15),
                                                       new SqlParameter("@clearedon",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@ledgerid",SqlDbType.Int,4)};
            objp[0].Value = Branchid;
            objp[1].Value = dbname;
            objp[2].Value = clearedon;
            objp[3].Value = ledgerid;
            return ExecuteTable("SPGetcontraClearanceTotal", objp);

        }

        public DataTable GetApproveProJou(string dbname, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            return ExecuteTable("SPApproveProJou", objp);
        }

        public DataTable SelFAVoucher4Corp(int vouno, int branchid, int divisionid, int voutypeid, int vouyear, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = voutypeid;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;
            return ExecuteTable("SPSelFAVoucher4Corp", objp);
        }

        public DataTable SelFAVoucher4BP(int vouno, int branchid, int divisionid, int voutypeid, int vouyear, string dbname, int PBid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@PBid", SqlDbType.TinyInt) };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = voutypeid;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;
            objp[6].Value = PBid;
            return ExecuteTable("SPSelFAVoucher4BP", objp);
        }

        public void UpdApprovalProJou(int jouno, int approvedby, int @vouid, string dbname, DateTime joudate)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jouno",SqlDbType.Int,4),    
                                                      new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                      new SqlParameter("@vouid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                      new SqlParameter("@voudate",SqlDbType.DateTime,8) };
            objp[0].Value = jouno;
            objp[1].Value = approvedby;
            objp[2].Value = vouid;
            objp[3].Value = dbname;
            objp[4].Value = joudate;
            ExecuteQuery("SPUpdApprovalProJou", objp);
        }

        public int UpdateFAVouHeadDetailsProVou(string dbname, string DataFrom, int vouid, string chqrefno, int jobno, string fvrname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@DataFrom",SqlDbType.VarChar ,25),
                                                       new SqlParameter("@vouid",SqlDbType.Int ,4),
                                                     new SqlParameter("@chqrefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno",SqlDbType.Int ,4),
                                                        new SqlParameter("@fvrname",SqlDbType.VarChar,150)};
            objp[0].Value = dbname;
            objp[1].Value = DataFrom;
            objp[2].Value = vouid;
            objp[3].Value = chqrefno;
            objp[4].Value = jobno;
            objp[5].Value = fvrname;
            return int.Parse(ExecuteReader("SPFAUpdateVouHeadDetailsProvou", objp));
        }

        //GetRevVoucherDet
        public DataTable GetRevVoucherDet(int branchid, int RVouNo, string RVouType, int RVouYear)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@BID",SqlDbType.TinyInt ),
                new SqlParameter("@RVouNo",SqlDbType.Int),
                new SqlParameter("@RVouType",SqlDbType.Char,1),
                new SqlParameter("@RVouYear",SqlDbType.Int)
            };
            objp[0].Value = branchid;
            objp[1].Value = RVouNo;
            objp[2].Value = RVouType;
            objp[3].Value = RVouYear;
            return ExecuteTable("SPGetRevVoucherDet", objp);
        }

        public DataTable SelFAVouHead4All(int vouno, int vouyear, int voutypeid, int branchid, int corpid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@vouno", SqlDbType.Int, 4),                                          
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@voutype", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@corpid", SqlDbType.Int, 4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = voutypeid;
            objp[3].Value = branchid;
            objp[4].Value = corpid;
            objp[5].Value = dbname;
            return ExecuteTable("SPSelFAVouHead4All", objp);
        }

        //RAJ
        public string GetUiidfromFormname(string Formname, string module)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@formname", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@module", SqlDbType.VarChar, 3)};
            objp[0].Value = Formname;
            objp[1].Value = module;
            return ExecuteReader("Sp_getuiifromuiname", objp);
        }


        ////Ruban Ledger Transfer New Process
        public void InsertAdustmentVoucher(int fromledgerid, int toledgerid, int vouid, int vouno, int voutype, int vouyear, int corpid, int branchid, double ledgeramount, int empid, string customertype, string dbname, DateTime voutypedate, string fcurr, double famount, int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromledgerid", SqlDbType.BigInt, 12),
                                                       new SqlParameter("@toledgerid", SqlDbType.BigInt, 12),
                                                        new SqlParameter("@vouid", SqlDbType.BigInt, 12),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 6),
                                                     new SqlParameter("@voutype", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                         new SqlParameter("@corpid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                         new SqlParameter("@ledgeramount", SqlDbType.Money),
                                                          new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@customertype", SqlDbType.VarChar,10),
                                           new SqlParameter("@dbname", SqlDbType.VarChar,15)   ,
                                           new SqlParameter("@voutypedate",SqlDbType.SmallDateTime,4),
                                              new SqlParameter("@fcurr", SqlDbType.VarChar,4)   ,
                                           new SqlParameter("@famt",SqlDbType.Money),
                                             new SqlParameter("@customerid",SqlDbType.BigInt)
            };

            objp[0].Value = fromledgerid;
            objp[1].Value = toledgerid;

            objp[2].Value = vouid;
            objp[3].Value = vouno;

            objp[4].Value = voutype;
            objp[5].Value = vouyear;

            objp[6].Value = corpid;
            objp[7].Value = branchid;

            objp[8].Value = ledgeramount;
            objp[9].Value = empid;

            objp[10].Value = customertype;
            objp[11].Value = dbname;
            objp[12].Value = voutypedate;

            objp[13].Value = fcurr;
            objp[14].Value = famount;
            objp[15].Value = custid;

            ExecuteQuery("SPINSADJDCNFORLEDGERTRANSFERRuban", objp);

        }


        //FAFaVoucher

        //SpGetChargeid4Pa
        public DataTable SpGetChargeid4Pa(int vouno, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.BigInt, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.BigInt, 4),
                                                        new SqlParameter("@branchid", SqlDbType.BigInt, 4)
                    };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            return ExecuteTable("SpGetChargeid4Pa", objp);

        }

        public int GetContraNo4BackDated(int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int) };
            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            return int.Parse(ExecuteReader("SPUpdMCContra4BackDated", objp));
        }

        //Check Voucher Revised or not
        public string CheckVocherReversal(int vouno, int bid, int Vouyear, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt, 1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1)};
            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = Vouyear;
            objp[3].Value = voutype;
            return ExecuteReader("CheckVouReversal", objp);
        }

        //Check Admin Voucher Revised or Not.
        public DataTable CheckReversalCNAdmin(int vouno, int vouyear, int branchid, int voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.BigInt, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.BigInt, 4),
                                                        new SqlParameter("@branchid", SqlDbType.BigInt, 4),
                                                        new SqlParameter("@voutype",SqlDbType.BigInt,4)
                    };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            return ExecuteTable("CheckReversalCNAdmin", objp);

        }

        //Reversal Admin
        public DataTable ReversalCNAdmin(int vouno, int vouyear, int branchid, int voutype, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.BigInt, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.BigInt, 4),
                                                        new SqlParameter("@branchid", SqlDbType.BigInt, 4),
                                                        new SqlParameter("@voutype",SqlDbType.BigInt,4),
                                                        new SqlParameter("@vouid",SqlDbType.BigInt,4)
                    };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            objp[4].Value = vouid;
            return ExecuteTable("spreversalcnadmin", objp);

        }
        //Get Reversal TDS Amount
        public double GetFARevTDSAmount(int branchid, char voutype, int vouno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            objp[2].Value = vouno;
            objp[3].Value = vouyear;
            return double.Parse(ExecuteReader("FAGetRevTDSAmnt", objp));
        }
        //Reversal Of GST 
        public void InsFAVouDetailsRev(string dbname, int vouid, int ledgerid, string ledgertype, double ledgeramount, int vouyear, int branchid, int divisionid)
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
            ExecuteQuery("SPFAInsVouDtlsRev", objp);

        }

        public string GetBankfromReceiptandBank(int vouno, string voutype, int branchid, int vouyear, string mode)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                        new SqlParameter("@voutype",SqlDbType.Char,1),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@mode",SqlDbType.VarChar,1)};

            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = mode;
            return ExecuteReader("SPGetBankfromReceiptandBank", objp);
        }


        public string ChkDepositSlipinFA(string slipno, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                                                        new SqlParameter("@slipno",SqlDbType.VarChar,20),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,20)
                                                    };
            objp[0].Value = slipno;
            objp[1].Value = dbname;

            return ExecuteReader("ChkDepositSlip", objp);

        }



        public DataTable GetPaymentCorpCust(int vouno, int branchid, int divisionid, int voutypeid, int vouyear, string dbname, int PBid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@PBid", SqlDbType.TinyInt) };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = voutypeid;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;
            objp[6].Value = PBid;
            return ExecuteTable("SPGetPaymentCorpCust", objp);
        }

        public DataTable GetFAJournalDtls(int vouno, int bid, string rptype, int vouyear, string mode, int rbid, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@vouno",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                        new SqlParameter("@rptype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@mode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@rbid",SqlDbType.Int),                                                       
                                                        new SqlParameter("@custid",SqlDbType.Int)
                                                    };

            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = rptype;
            objp[3].Value = vouyear;
            objp[4].Value = mode;
            objp[5].Value = rbid;
            objp[6].Value = custid;

            return ExecuteTable("SPGetFAJournalDtls", objp);
        }

        public DataTable InsFAJournalDtls(int vouno, int bid, string rptype, int vouyear, string mode, int rbid, string deleted, int jvno, int jvmonth, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@vouno",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                        new SqlParameter("@rptype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@mode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@rbid",SqlDbType.Int),
                                                        new SqlParameter("@deleted",SqlDbType.VarChar,2),
                                                        new SqlParameter("@jvno",SqlDbType.Int),
                                                        new SqlParameter("@jvmonth",SqlDbType.Int),                                                       
                                                        new SqlParameter("@custid",SqlDbType.Int)                                                        
                                                    };

            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = rptype;
            objp[3].Value = vouyear;
            objp[4].Value = mode;
            objp[5].Value = rbid;
            objp[6].Value = deleted;
            objp[7].Value = jvno;
            objp[8].Value = jvmonth;
            objp[9].Value = custid;

            return ExecuteTable("SPInsFAJournalDtls", objp);
        }

        public DataTable InsFAJournalDtls(int vouno, int bid, string rptype, int vouyear, string mode, int rbid, string deleted, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@vouno",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                        new SqlParameter("@rptype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@mode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@rbid",SqlDbType.Int),
                                                        new SqlParameter("@deleted",SqlDbType.VarChar,2),                                                       
                                                        new SqlParameter("@custid",SqlDbType.Int)                                                  
                                                    };

            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = rptype;
            objp[3].Value = vouyear;
            objp[4].Value = mode;
            objp[5].Value = rbid;
            objp[6].Value = deleted;
            objp[7].Value = custid;

            return ExecuteTable("SPInsFAJournalDtls", objp);
        }

        public DataTable DelFAJournalDtls(int bid, int vouyear, int jvmonth, string dbname, string narration, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@jvmonth",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                        new SqlParameter("@narration",SqlDbType.VarChar,500),                                                       
                                                        new SqlParameter("@custid",SqlDbType.Int)
                                                    };

            objp[0].Value = bid;
            objp[1].Value = vouyear;
            objp[2].Value = jvmonth;
            objp[3].Value = dbname;
            objp[4].Value = narration;
            objp[5].Value = custid;

            return ExecuteTable("SPDelFAJournalDtls", objp);
        }

        public DataTable UpdFAJournalDtls(int vouno, int bid, string rptype, int vouyear, string mode, int rbid, int jvno, int jvmonth, int custid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@vouno",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                        new SqlParameter("@rptype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@mode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@rbid",SqlDbType.Int),
                                                        new SqlParameter("@jvno",SqlDbType.Int),
                                                        new SqlParameter("@jvmonth",SqlDbType.Int),                                                       
                                                        new SqlParameter("@custid",SqlDbType.Int)
                                                    };

            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = rptype;
            objp[3].Value = vouyear;
            objp[4].Value = mode;
            objp[5].Value = rbid;
            objp[6].Value = jvno;
            objp[7].Value = jvmonth;
            objp[8].Value = custid;


            return ExecuteTable("SPUpdFAJournalDtls", objp);
        }

        /******************** Get Vouyear Fro Re-Transfer *******************/

        public int Getvouyearforautotransfer(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int) };

            objp[0].Value = branchid;

            return int.Parse(ExecuteReader("SPGetvouyearforautotransfer", objp));
        }

        /********************************************************************/


        public DataTable SelFAVoucherNew(int vouno, int branchid, int divisionid, int voutypeid, int vouyear, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {  
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@voutypeid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                     };

            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = voutypeid;
            objp[4].Value = vouyear;
            objp[5].Value = dbname;

            return ExecuteTable("SPSelFAVoucherNew", objp);
        }


        public void SPFAUpdFAVouDtls4Fcurprovou(string dbname, int vouid, string fcur, double famt, double exrate, int ledgerid, string ledgertype, int vouyear, string refno)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@vouid",SqlDbType.BigInt,8),
                                                    new SqlParameter("@fcur",SqlDbType.VarChar,3),
                                                    new SqlParameter("@famt",SqlDbType.Money,8),
                                                    new SqlParameter("@exrate",SqlDbType.Money,8),
                                                    new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                    new SqlParameter("@ledgertype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),

                                                    new SqlParameter("@refno",SqlDbType.VarChar,50)

            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = fcur;
            objp[3].Value = famt;
            objp[4].Value = exrate;
            objp[5].Value = ledgerid;
            objp[6].Value = ledgertype;
            objp[7].Value = vouyear;
            objp[8].Value = refno;
            ExecuteQuery("SPFAUpdVouDtls4Fcurprojour", objp);

        }

        //added on 20/07/2022  --bhuvi
        public DataTable SelFAAllVoucherNew(int voutypeid, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {                                                                                                              
                                                        new SqlParameter("@vouid", SqlDbType.Int, 4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = voutypeid;
            objp[1].Value = empid;
            objp[2].Value = dbname;
            return ExecuteTable("SPInsTempvoucherRPTprojournal", objp);
        }

        //Vino For Sales/Purchase Report [22-02-2024]
        public DataTable GetFinanceBranchDashBoard(int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("branchid",SqlDbType.Int)
            };

            objp[0].Value = vouyear;
            objp[1].Value = branchid;
            return ExecuteTable("GetFinanceBranchDashBoard", objp);
        }
        public DataTable GetFinanceBranchDashBoardDetails(string type, int vouyear, int branchid, int voumonth)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@type",SqlDbType.VarChar,20),
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("branchid",SqlDbType.Int),
                new SqlParameter("@voumonth",SqlDbType.Int)
            };

            objp[0].Value = type;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voumonth;

            return ExecuteTable("GetFinanceBranchDashBoardDetails", objp);
        }



        // Vino New for MISvsGP [01-03-2024]
        public DataSet MyUseMISvsDirectIncomeDetails(DateTime frmdate, DateTime todate, string dbname, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
        new SqlParameter("@from",SqlDbType.DateTime),
        new SqlParameter("@to",SqlDbType.DateTime),
        new SqlParameter("@dbname",SqlDbType.VarChar,20),
        new SqlParameter("@branchid",SqlDbType.Int),
        new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = frmdate;
            objp[1].Value = todate;
            objp[2].Value = dbname;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;

            return ExecuteDataSet("MyUseMISvsDirectIncomeDetails", objp);
        }

        public DataSet MyUseMISvsDirectIncomeDetailsBreakUp(DateTime frmdate, DateTime todate, string dbname, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
        new SqlParameter("@from",SqlDbType.DateTime),
        new SqlParameter("@to",SqlDbType.DateTime),
        new SqlParameter("@dbname",SqlDbType.VarChar,20),
        new SqlParameter("@branchid",SqlDbType.Int),
        new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = frmdate;
            objp[1].Value = todate;
            objp[2].Value = dbname;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;

            return ExecuteDataSet("MyUseMISvsDirectIncomeDetailsBreakUp", objp);
        }

        // Vino New for MISvsGP [01-03-2024]
        public DataSet MyUseMISvsDirectExpenseDetails(DateTime frmdate, DateTime todate, string dbname, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
        new SqlParameter("@from",SqlDbType.DateTime),
        new SqlParameter("@to",SqlDbType.DateTime),
        new SqlParameter("@dbname",SqlDbType.VarChar,20),
        new SqlParameter("@branchid",SqlDbType.Int),
        new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = frmdate;
            objp[1].Value = todate;
            objp[2].Value = dbname;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;

            return ExecuteDataSet("MyUseMISvsDirectExpenseDetails", objp);
        }
        public DataSet MyUseMISvsDirectExpenseDetailsBreakup(DateTime frmdate, DateTime todate, string dbname, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
        new SqlParameter("@from",SqlDbType.DateTime),
        new SqlParameter("@to",SqlDbType.DateTime),
        new SqlParameter("@dbname",SqlDbType.VarChar,20),
        new SqlParameter("@branchid",SqlDbType.Int),
        new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = frmdate;
            objp[1].Value = todate;
            objp[2].Value = dbname;
            objp[3].Value = branchid;
            objp[4].Value = divisionid;

            return ExecuteDataSet("MyUseMISvsDirectExpenseDetailsBreakup", objp);
        }
    }
}