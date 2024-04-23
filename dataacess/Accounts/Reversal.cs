using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Accounts
{
  public  class Reversal:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Reversal()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsReversalVouchers(int bid, int vouyear, int vouno, int revno, int empid, int voutype,int revvoutype, string dbname)
      {
          SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@bid",SqlDbType.Int,4),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                    new SqlParameter("@vouno",SqlDbType.VarChar,50),
                                                    new SqlParameter("@revno",SqlDbType.Int,4),
                                                    new SqlParameter("@empid",SqlDbType.Int,4),
                                                    new SqlParameter("@voutype",SqlDbType.Int,4),
                                                    new SqlParameter("@revvoutype",SqlDbType.Int,4),
                                                    new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@voucherid",SqlDbType.Int)};
          objp[0].Value = bid;
          objp[1].Value = vouyear;
          objp[2].Value = vouno;
          objp[3].Value = revno;
          objp[4].Value = empid;
          objp[5].Value = voutype;
          objp[6].Value = revvoutype;
          objp[7].Value = dbname;
          objp[8].Direction = ParameterDirection.Output;
          return ExecuteQuery("SPInsReversalVouchers", objp, "@voucherid");
      }
      public void InsReversalFAVouDetails(string dbname, int voucherid, int vouno, int voutype, int vouyear, int branchid)
      {
          SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@voucherid",SqlDbType.Int),
                                                     new SqlParameter("@vouno",SqlDbType.Int),
                                                     new SqlParameter("@voutype",SqlDbType.Char,2),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};


          objp[0].Value = dbname;
          objp[1].Value = voucherid;
          objp[2].Value = vouno;
          objp[3].Value = voutype;
          objp[4].Value = vouyear;
          objp[5].Value = branchid;
          ExecuteQuery("SPInsReversalVoucherDetails", objp);

      }
      public DataTable GetReversalVoucherDtls(int voucherid,string dbname)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@voucherid", SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                        };

          objp[0].Value = voucherid;
          objp[1].Value = dbname;
          return ExecuteTable("SPGetRevrsalVoucherDtls", objp);
      }
      public void UpdReversalLedgerDtls(int ledgerid, int branchid, int divisionid, double ledgeramount, string dbname, string ledgertype, int vouyear)
      {
          SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@ledgerid",SqlDbType.Int),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@divisionid",SqlDbType.Int),
                                                     new SqlParameter("@ledgeramount",SqlDbType.Money,4),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@ledgertype",SqlDbType.VarChar,3),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};


          objp[0].Value = ledgerid;
          objp[1].Value = branchid;
          objp[2].Value = divisionid;
          objp[3].Value = ledgeramount;
          objp[4].Value = dbname;
          objp[5].Value = ledgertype;
          objp[6].Value = vouyear;
          ExecuteQuery("SPUpdReversalLedgerDtls", objp);

      }

      public DataTable GetReciptPaymentDet4VouNo(int vouno, int branchid, int divisionid, int vouyear, string voutype)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@vouno", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@vouyear", SqlDbType.Int),
                                                      new SqlParameter("@voutype", SqlDbType.Char)                                                        
                                                    };

          objp[0].Value = vouno;
          objp[1].Value = branchid;
          objp[2].Value = divisionid;
          objp[3].Value = vouyear;
          objp[4].Value = voutype;
          return ExecuteTable("GetReceiptPaymentDet4vouno", objp);
      }

      public DataTable GetRevAmount(int vouno, int branchid, int divisionid, int vouyear, string voutype)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@vouno", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@vouyear", SqlDbType.Int),
                                                      new SqlParameter("@voutype", SqlDbType.Char)                                                        
                                                    };

          objp[0].Value = vouno;
          objp[1].Value = branchid;
          objp[2].Value = divisionid;
          objp[3].Value = vouyear;
          objp[4].Value = voutype;
          return ExecuteTable("GetRevAmount", objp);
      }

      public DataTable GetCutoffBreakUpDetails(int divisionid, string cases, DateTime cutoffdate, int empid)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@case", SqlDbType.VarChar,1),
                                                      new SqlParameter("@cutoffdate", SqlDbType.SmallDateTime,12),
                                                      new SqlParameter("@empid", SqlDbType.Int)                                                    
                                                    };

          objp[0].Value = divisionid;
          objp[1].Value = cases;
          objp[2].Value = cutoffdate;
          objp[3].Value = empid;
          return ExecuteTable("SPJGV", objp);
      }

      //Lawrence

      public DataTable GetRevisedCharges(int receiptno, int branchid, int vouyear, char voutype)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@receiptno", SqlDbType.Int,5),
                                                      new SqlParameter("@branchid", SqlDbType.Int,3),
                                                      new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                      new SqlParameter("@voutype", SqlDbType.Char, 1)                                                    
                                                    };

          objp[0].Value = receiptno;
          objp[1].Value = branchid;
          objp[2].Value = vouyear;
          objp[3].Value = voutype;
          return ExecuteTable("SPGetRevisedCharges", objp);
      }

      //Select the Reviesed charges to make enabled FALSE
      public DataTable GetRevisedChargesEnabled(int vouno, int chargeid, string chargename, string Base, int branchid, int vouyear, char voutype)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@vouno", SqlDbType.Int),
                                                      new SqlParameter("@chargeid", SqlDbType.Int),
                                                      new SqlParameter("@chargename", SqlDbType.VarChar, 100),
                                                      new SqlParameter("@Base", SqlDbType.VarChar, 10),
                                                      new SqlParameter("@branchid", SqlDbType.Int),
                                                      new SqlParameter("@vouyear", SqlDbType.Int),
                                                      new SqlParameter("@voutype", SqlDbType.Char)                                                    
                                                    };

          objp[0].Value = vouno;
          objp[1].Value = chargeid;
          objp[2].Value = chargename;
          objp[3].Value = Base;
          objp[4].Value = branchid;
          objp[5].Value = vouyear;
          objp[6].Value = voutype;
          return ExecuteTable("SPEnableRevisedCharges", objp);
      }

      //Journal Reversal New
      public int JournalReversal(int branchid, int vouid, int empid, string dbname, int divisionid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vouid1", SqlDbType.Int, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int, 1),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar, 20),
                                                     new SqlParameter("@divisionid",SqlDbType.Int)};
          objp[0].Value = branchid;
          objp[1].Value = vouid;
          objp[2].Value = empid;
          objp[3].Value = dbname;
          objp[4].Value = divisionid;
          return int.Parse(ExecuteReader("JournalReversal", objp));
      }

      //Check Journal Reversal 
      public int CheckJournalRevised(int branchid, int vouyear, int vouno, string dbname, int month, int year)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 1),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar, 20),
                                                       new SqlParameter("@month", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@year", SqlDbType.Int, 4)};
          objp[0].Value = branchid;
          objp[1].Value = vouyear;
          objp[2].Value = vouno;
          objp[3].Value = dbname;
          objp[4].Value = month;
          objp[5].Value = year;
          return int.Parse(ExecuteReader("CheckRevisedJournal", objp));
      }

      //Check Book Closure Status
      public int CheckBookClosureStatus(int branchid, int divisionid, string dbname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@divisionid", SqlDbType.Int),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar, 20)
                                                        };
          objp[0].Value = branchid;
          objp[1].Value = divisionid;
          objp[2].Value = dbname;
          return int.Parse(ExecuteReader("CheckBookClosure", objp));
      }

    }
}
