using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class ProJournal:DBObject 
    {
        //For Journal No Exists
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ProJournal()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int ChkRefnoExists4JournalProvou(string refno, int voutype, int branchid, string @dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@refno",SqlDbType.VarChar,150),
                                                     new SqlParameter("@voutype",SqlDbType.TinyInt),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = refno;
            objp[1].Value = voutype;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return int.Parse(ExecuteReader("SPChkRefnoExists4JournalProvou", objp));
        }

        public int InsFAVouHeadProVou(string dbname, int voutypeid, string vouno, DateTime voudate, string narration, string trantype, int deptid, int jobno, int branchid, int divisionid, int updatedby, DateTime updatedon, char cancelled, int vouyear)
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
            return ExecuteQuery("SPFAInsVouHeadProVou", objp, "@voucherid");
        }

        public void InsFAVouDetailsProVou(string dbname, int vouid, int ledgerid, string ledgertype, double ledgeramount, int vouyear, int branchid, int divisionid)
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
            ExecuteQuery("SPFAInsFAVouDtlsProVou", objp);

        }

        public DataTable SelFAvoucherHeadProVou(int branchid, int vouyear, int vouno, int voutypeid, string dbname, int voumonth)
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
            return ExecuteTable("SPFASelVouHeadProVou", objp);
        }

        public DataTable SelFAvoucherDetailsProVou(int branchid, int vouyear, int vouno, int voutypeid, string dbname, int voumonth)
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
            return ExecuteTable("SPFASelVouDetailsProVou", objp);
        }

        public void DelJouDetailsProVou(int branchid, int vouyear, int voutype, int vouno, int vousubid, string dbname)
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
            ExecuteQuery("SPFADelJouDetailsProVou", objp);
        }

        public void InsFAVouHeadDeletedProVou(string dbname, int updatedby, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@vouid",SqlDbType.BigInt),
                                                    new SqlParameter("@updatedby",SqlDbType.Int)
                                                  
                                                    };
            objp[0].Value = dbname;
            objp[1].Value = vouid;
            objp[2].Value = updatedby;

            ExecuteQuery("SPFAInsVouHeadDeletedProVou", objp);
        }

        public void UpdJouHeadProVou(string dbname, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt),
                                                     
            };
            objp[0].Value = dbname;
            objp[1].Value = vouid;

            ExecuteQuery("SPFAUpdJouHeadProVou", objp);
        }

        public void InsFAVouDtlsDeletedProVou(string dbname, int vouid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@vouid",SqlDbType.BigInt)};
            objp[0].Value = dbname;
            objp[1].Value = vouid;

            ExecuteQuery("SPFAInsVouDtlsDeletedProVou", objp);
        }

        public void DelVouDetailsProVou(int vouid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                     new SqlParameter("@vouid",SqlDbType.BigInt),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};

            objp[0].Value = vouid;
            objp[1].Value = dbname;
            ExecuteQuery("SPFADelVouDetailsProVou", objp);
        }

        public int GetJournalNoMONTHProVou(int branchid, DateTime joudate)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@joudate", SqlDbType.DateTime,8 )};
            objp[0].Value = branchid;
            objp[1].Value = joudate;
            return int.Parse(ExecuteReader("SPUpdMCJournal4monthProVou", objp));
        }
    }
}
