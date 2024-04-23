using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.FAMaster
{
    public class ReportView:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ReportView()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable SelMasterVoutype(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
           
            objp[0].Value = dbname;
            return ExecuteTable("SPFAselMasterVouTypes", objp);
        }
        public DataTable FAselStatisticsReg(int voutypeid, int branchid,DateTime fdate,DateTime tdate,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@voutype", SqlDbType.Int, 4),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = voutypeid;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            return ExecuteTable("SPFAselStatisticsReg", objp);
        }
        public DataTable FAselStatisticsvoucher(int branchid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                     
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
          
            objp[1].Value = dbname;
            return ExecuteTable("SPFAselStatisticsvoucher", objp);
        }

        public DataTable FAselStatisticsvouchermonth(int branchid,int voutype, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@voutype",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            objp[2].Value = dbname;
            return ExecuteTable("SPFAselStatisticsvouchermonth", objp);
        }
        public DataTable FAselCstcatogry(int branchid, DateTime fdate, DateTime tdate,string columnname,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@columnname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = columnname;
            objp[4].Value = dbname;
            return ExecuteTable("SPFAselCstcatogry", objp);
        }
        public DataSet FAselCstcatogryJob(int branchid, DateTime fdate, DateTime tdate, string columnname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@columnname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = columnname;
            objp[4].Value = dbname;
            return ExecuteDataSet("SPFAselCstcatogryJob", objp);
        }
        public DataSet FASelopbal(int branchid,int ledgerid,DateTime fdate, DateTime tdate,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            return ExecuteDataSet("SPFASelopbal", objp);
        }
        public DataTable FAselLedgergrd(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            return ExecuteTable("SPFAselLedgergrd", objp);
        }

        public DataTable FAselLedgergrd(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname, string dispname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@dispname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            objp[5].Value = dispname;
            return ExecuteTable("SPFAselLedgergrdGST", objp);
        }

        public DataTable GetGroupSummary(string dbname, DateTime from, DateTime to, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = branchid;
            return ExecuteTable("SPFAGroupSummary", objp);
        }

        public DataTable GetSubGroupSummary(string dbname, DateTime from, DateTime to, int branchid, int grpid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@grpid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = branchid;
            objp[4].Value = grpid;
            return ExecuteTable("SPFASubGroupSummary", objp);
        }
        public DataTable SPFASubGroupSummaryforcorp(string dbname, DateTime from, DateTime to, int divisionid, int grpid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@grpid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = divisionid;
            objp[4].Value = grpid;
            return ExecuteTable("SPFASubGroupSummaryforcorp", objp);
        }

        public DataTable GetLedgerGroupSummary(string dbname, DateTime from, DateTime to, int branchid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@subgroupid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = branchid;
            objp[4].Value = subgroupid;
            return ExecuteTable("SPFALedgerGroupSummary", objp);
        }
        public DataTable FAselTempLedger(string dbname,int branchid,DateTime fdate, DateTime tdate ,int empid,int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      
                                                      new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                     new SqlParameter("empid",SqlDbType.Int,4),
                                                    new SqlParameter("ledgerid",SqlDbType.Int,4)
                                                       
                                                      };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = empid;
            objp[5].Value = ledgerid;
            return ExecuteTable("SPFAInsTempLedger", objp);
        }
        public DataSet FAselTrialBalance(int branchid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = dbname;
            
            return ExecuteDataSet("SPFAselTrialBalance", objp);
        }
        public DataSet FAselTrialBalance(int branchid,DateTime fdate,DateTime tdate,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;

            return ExecuteDataSet("SPFAselTrialBalanceFTdate", objp);
        }
        public DataSet FAselTBLedgerFTdate(int branchid, DateTime fdate, DateTime tdate,int sid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@sid",SqlDbType.Int,4),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = sid;
            objp[4].Value = dbname;

            return ExecuteDataSet("SPFAselTBLedgerFTdate", objp);
        }
        public DateTime MaxVouGetDate(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = dbname;
            return DateTime.Parse(ExecuteReader("SPSelFAmaxvoudate", objp));
        }
        public DataSet SelProfitLosswithdate(string dbname, int branchid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteDataSet("SPFAProfitLosswithdate", objp);
        }
        public DataSet SelBalanceSheet(string dbname, int branchid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteDataSet("SPFABalanceSheet", objp);
        }
        public int FASelGroupid(string groupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@groupname",SqlDbType.VarChar,100),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = groupname;
            objp[1].Value = dbname;
            return int.Parse(ExecuteReader("SPFASelGroupId", objp));
        }

        public DataTable FASelGroupall(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                    };

            objp[0].Value = dbname;
            return ExecuteTable("SPFASelGroupall", objp);
        }

        public DataTable FASelSubGroupall(string dbname,int groupid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@groupid",SqlDbType.Int,4)
                                                    };

            objp[0].Value = dbname;
            objp[1].Value = groupid;
            return ExecuteTable("SPFASelSubGroupall", objp);
        }
        public DataTable FASelLedgerall(string dbname, int groupid,int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@groupid",SqlDbType.Int,4),
                                                    new SqlParameter("@subgroupid",SqlDbType.Int,4)
                                                    };

            objp[0].Value = dbname;
            objp[1].Value = groupid;
            objp[2].Value = subgroupid;
            return ExecuteTable("SPFASelLedgerall", objp);
        }
        public DataSet FAselTrialBalanceFTdate4CO(int divisionid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;

            return ExecuteDataSet("SPFAselTrialBalanceFTdate4CO", objp);
        }
        public DataSet FAselTBLedgerFTdate4CO(int divisionid, DateTime fdate, DateTime tdate, int sid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@sid",SqlDbType.Int,4),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = sid;
            objp[4].Value = dbname;

            return ExecuteDataSet("SPFAselTBLedgerFTdate4CO", objp);
        }
        public DataSet FASelBankBalance4CO(int divisionid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;

            return ExecuteDataSet("SPFASelBankBalance4CO", objp);
        }
        public DataTable FASelOverseas4CO(int divisionid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;

            return ExecuteTable("SPFASelOverseas4CO", objp);
        }
        public DataTable FASelOverseasLeg4CO(int divisionid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;

            return ExecuteTable("SPFASelOverseasLeg4CO", objp);
        }
        public DataTable FASelOverseasVou4CO(int divisionid, DateTime fdate, DateTime tdate, int ledgerid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = ledgerid;
            objp[4].Value = dbname;

            return ExecuteTable("SPFASelOverseasVou4CO", objp);
        }
        public DataSet SelBalanceSheetforcorporate(string dbname, int divisionid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = divisionid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteDataSet("SPFABalanceSheet4corporate", objp);
        }

        public DataSet SelProfitLossforcorporate(string dbname, int divisionid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = divisionid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteDataSet("SPFAGetProfitLossforcorporate", objp);
        }

        public DataTable GetCorpPayment(int divisionid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};


            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;
            return ExecuteTable("SPFACorpGetPayment", objp);
        }
        public DataTable GetCorpCollection(int divisionid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)};


            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;
            return ExecuteTable("SPFACorpGetCollection", objp);
        }

        public DataTable GetCorpPRDtls(int divisionid, DateTime fdate, DateTime tdate, string dbname, string voutypename)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@voutypename",SqlDbType.VarChar,20)};


            objp[0].Value = divisionid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;
            objp[4].Value = voutypename;
            return ExecuteTable("SPFACorpGetPadtls", objp);
        }
        public void RunTempReports(int empid,string dbname,DateTime fdate,DateTime tdate,int branchid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15),   
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1)};
            objp[0].Value = empid;
            objp[1].Value = dbname;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = branchid;
            objp[5].Value = divisionid; 
            ExecuteQuery("SPInsTempreports", objp);
        }

         //public void GetInsPLReports (string partinc,double incamnt,string partiexp,double expamnt)
         //{
         //   SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@partinc",SqlDbType.VarChar,100),
         //                                            new SqlParameter("@incamnt",SqlDbType.Money),   
         //                                            new SqlParameter("@partiexp",SqlDbType.VarChar,100),
         //                                            new SqlParameter("@expamnt",SqlDbType.Money)};
         //   objp[0].Value = partinc;
         //   objp[1].Value = incamnt;
         //   objp[2].Value = partiexp;
         //   objp[3].Value = expamnt;
         //   ExecuteQuery("SPFAInsPLReport",objp);

         //}

        public DataTable FASelDayBook(string dbname, int branchid, DateTime fdate, DateTime tdate, char status)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@status",SqlDbType.Char,1),};

            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = status;
            return ExecuteTable("SPFASelDayBook", objp);
        }


        //Krishna 31/12/2011

        public void DelPLReports(int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
            new SqlParameter("@dbname", SqlDbType.VarChar , 15)};
            objp[0].Value = empid;
            objp[1].Value = dbname;
            ExecuteQuery("SPFADelPLReport", objp);
        }

        public void GetInsPLReports(int empid, string partinc, double incamnt, string partiexp, double expamnt, string dbname, int branchid, string AGType, string LGType, int rno)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                    new SqlParameter("@empid",SqlDbType.Int,4),
                                                     new SqlParameter("@partinc",SqlDbType.VarChar,100),
                                                     new SqlParameter("@incamnt",SqlDbType.Money),   
                                                     new SqlParameter("@partiexp",SqlDbType.VarChar,100),
                                                     new SqlParameter("@expamnt",SqlDbType.Money),
                             new SqlParameter("@dbname",SqlDbType.VarChar,15),
                             new SqlParameter("@branchid",SqlDbType.Int,4),
                            new SqlParameter("@AGType",SqlDbType.VarChar,10),
                             new SqlParameter("@LGType",SqlDbType.VarChar,10),
                            new SqlParameter("@RNO",SqlDbType.Int,2)};
            objp[0].Value = empid;
            objp[1].Value = partinc;
            objp[2].Value = incamnt;
            objp[3].Value = partiexp;
            objp[4].Value = expamnt;
            objp[5].Value = dbname;
            objp[6].Value = branchid;
            objp[7].Value = AGType;
            objp[8].Value = LGType;
            objp[9].Value = rno;
            ExecuteQuery("SPFAInsPLReport", objp);

        }

        public DataSet SelBalanceSheetLedgerwise(string dbname, int branchid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteDataSet("SPFABSLedgerwise", objp);
        }


        public DataSet SelProfitLossLedgerwise(string dbname, int branchid, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteDataSet("SPFAPLLedgerwise", objp);
        }
        public DataTable FAselLedgergrd4Month(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            return ExecuteTable("SPFAselLedgergrd4Month", objp);
        }

        public DataTable FAgetinvoice4Ledgergrd(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            return ExecuteTable("SPGetFAinvoice4ledger", objp);
        }

        public DataTable FAgetreceipt4invoice(string dbname, int branchid, int invoiceno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                    new SqlParameter("@invoiceno",SqlDbType.Int,4),};
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = invoiceno;
            return ExecuteTable("spgetreceipt4invoice", objp);
        }

        public void InsTempFATrailBalance(int empid, string dbname, string ledgername, double obcr, double obdr, double trdr, double trcr, double cldr, double clcr, string gtype, int rno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar ,15),
                                                         new SqlParameter("@ledgername", SqlDbType.VarChar ,100),
                                                        new SqlParameter("@obdr", SqlDbType.Money),
                                                         new SqlParameter("@obcr",SqlDbType.Money),
                                                        new SqlParameter("@trdr", SqlDbType.Money),
                                                         new SqlParameter("@trcr",SqlDbType.Money),
                                                        new SqlParameter("@cldr", SqlDbType.Money),
                                                         new SqlParameter("@clcr",SqlDbType.Money),
                                                        new SqlParameter("@gtype",SqlDbType .VarChar,20),
                                                        new SqlParameter("@rno",SqlDbType.Int,2)};
            objp[0].Value = empid;
            objp[1].Value = dbname;
            objp[2].Value = ledgername;
            objp[3].Value = obdr;
            objp[4].Value = obcr;
            objp[5].Value = trdr;
            objp[6].Value = trdr;
            objp[7].Value = cldr;
            objp[8].Value = clcr;
            objp[9].Value = gtype;
            objp[10].Value = rno;
            ExecuteQuery("InsTempFATrailBalance", objp);
        }
        public void DelTempFATrailBalance(int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                         new SqlParameter("@dbname", SqlDbType.VarChar ,15)};
            objp[0].Value = empid;
            objp[1].Value = dbname;
            ExecuteQuery("DelTempFATrailBalance", objp);
        }

        public DataSet FAselAllLedgerFTdate(int branchid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;

            return ExecuteDataSet("SPFAselAllLedgerFTdate", objp);
        }


        public DataSet FAselAllLedgerOB(int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),                                                        
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = dbname;

            return ExecuteDataSet("SPFAselAllLedgerOB", objp);
        }

        public DataSet FAselAllLedgerAsOnDate(int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),                                                        
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = dbname;

            return ExecuteDataSet("SPFAselAllLedgerAsOnDate", objp);
        }

        //End


        //KUMAR DayBook Cr Dr 03-02-2012
        public DataTable FASelDayBookNew(string dbname, int branchid, DateTime fdate, DateTime tdate, char status, int voutypeid, double amount, string qtype, string refno)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@status",SqlDbType.Char,1),
                                                    new SqlParameter("@voutypeid",SqlDbType.Int,4),
                                                    new SqlParameter("@amount",SqlDbType.Money),
                                                    new SqlParameter("@qtype",SqlDbType.VarChar,10),
                                                    new SqlParameter("@refno",SqlDbType.VarChar,500)
                                                    };

            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = status;
            objp[5].Value = voutypeid;
            objp[6].Value = amount;
            objp[7].Value = qtype;
            objp[8].Value = refno;
            return ExecuteTable("SPFASelDayBookNew", objp);
        }
        //KUMAR DayBook Cr Dr 03-02-2012

        public DataTable FAgetinvoice4Refno(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            return ExecuteTable("SPgetLdgrPenBills", objp);
        }
        public DataTable FAgetinvoice4Vouno(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname, string reffno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@ledgerid",SqlDbType.Int ),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),                                                       
                                                      new SqlParameter("@reffno",SqlDbType.VarChar,500)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            objp[5].Value = reffno;
            return ExecuteTable("SPgetLdgrPenBills4Refno", objp);
        }


        //KUMAR For Refno Type Ahead  10-02-2012  START
        public DataTable GetLikeRefno(string refno, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.VarChar, 500),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = refno;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAGetLikeRefno", objp);
        }
        //KUMAR For Refno Type Ahead  10-02-2012  END



          public DataSet SelBalanceSheet4AllBranch(string dbname, int divisionId, DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@divisionId",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
            objp[0].Value = dbname;
            objp[1].Value = divisionId;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteDataSet("SPFABalanceSheet4AllBranch", objp);
        }

          public DataSet SelProfitLosswithdate4AllBranch(string dbname, DateTime fdate, DateTime tdate, int divisionId)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),                                                    
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};
              objp[0].Value = dbname;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = divisionId;
              return ExecuteDataSet("SPFAProfitLosswithdate4AllBranch", objp);
          }


          public DataSet SelBalanceSheetLedgerwise4AllBranch(string dbname, int divisionid, DateTime fdate, DateTime tdate)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
              objp[0].Value = dbname;
              objp[1].Value = divisionid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              return ExecuteDataSet("SPFABSLedgerwise4AllBranch", objp);
          }

          public DataTable GetSubGroupSummary4BS4AllBranch(string dbname, DateTime from, DateTime to, int grpid, int divisionId)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),                                                     
                                                     new SqlParameter("@grpid",SqlDbType.Int),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};

              objp[0].Value = dbname;
              objp[1].Value = from;
              objp[2].Value = to;
              objp[3].Value = grpid;
              objp[4].Value = divisionId;
              return ExecuteTable("SPFASubGroupSummary4BS4AllBranch", objp);
          }
          public DataTable GetSubGroupSummary4BS(string dbname, DateTime from, DateTime to, int branchid, int grpid)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@grpid",SqlDbType.Int)};

              objp[0].Value = dbname;
              objp[1].Value = from;
              objp[2].Value = to;
              objp[3].Value = branchid;
              objp[4].Value = grpid;
              return ExecuteTable("SPFASubGroupSummary4BS", objp);
          }

          public DataTable GetSubGroupSummary4AllBranch(string dbname, DateTime from, DateTime to, int grpid, int divisionId)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),                                                     
                                                     new SqlParameter("@grpid",SqlDbType.Int),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};

              objp[0].Value = dbname;
              objp[1].Value = from;
              objp[2].Value = to;
              objp[3].Value = grpid;
              objp[4].Value = divisionId;
              return ExecuteTable("SPFASubGroupSummary4AllBranch", objp);
          }

          public DataTable GetLedgerGroupSummary4BS4AllBranch(string dbname, DateTime from, DateTime to, int divisionId, int subgroupid)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@divisionId",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@subgroupid",SqlDbType.Int)};

              objp[0].Value = dbname;
              objp[1].Value = from;
              objp[2].Value = to;
              objp[3].Value = divisionId;
              objp[4].Value = subgroupid;
              return ExecuteTable("SPFALedgerGroupSummary4BS4AllBranch", objp);
          }

          public DataTable GetLedgerGroupSummary4BS(string dbname, DateTime from, DateTime to, int branchid, int subgroupid)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@subgroupid",SqlDbType.Int)};

              objp[0].Value = dbname;
              objp[1].Value = from;
              objp[2].Value = to;
              objp[3].Value = branchid;
              objp[4].Value = subgroupid;
              return ExecuteTable("SPFALedgerGroupSummary4BS", objp);
          }

        //FA

          public DataTable FASelDayBookNew_web(string dbname, int branchid, DateTime fdate, DateTime tdate, char status, int voutypeid, double amount, string qtype, string refno)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@status",SqlDbType.Char,1),
                                                    new SqlParameter("@voutypeid",SqlDbType.Int,4),
                                                    new SqlParameter("@amount",SqlDbType.Money),
                                                    new SqlParameter("@qtype",SqlDbType.VarChar,10),
                                                    new SqlParameter("@refno",SqlDbType.VarChar,500)
                                                    };

              objp[0].Value = dbname;
              objp[1].Value = branchid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              objp[4].Value = status;
              objp[5].Value = voutypeid;
              objp[6].Value = amount;
              objp[7].Value = qtype;
              objp[8].Value = refno;
              return ExecuteTable("SPFASelDayBookNew_WEB", objp);
          }

          //-------Karthika_K Date Difference

          public int DateDiffernce(DateTime fdate, DateTime tdate)
          {
              SqlParameter[] objp = new SqlParameter[]{   new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                    };
              objp[0].Value = fdate;
              objp[1].Value = tdate;
              return int.Parse(ExecuteReader("DateDifference_DayBook", objp));
          }

          //prabha//

          public DataTable FAselLedgergrd4AllBranchwithDet(int ledgerid, DateTime fdate, DateTime tdate, string dbname, int divisionId)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};

              objp[0].Value = ledgerid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              objp[4].Value = divisionId;
              return ExecuteTable("SPFAselLedgergrd4AllBranchWithDetGST_New", objp); ////4-18-2022

              //return ExecuteTable("SPFAselLedgergrd4AllBranch4Bank", objp);
          }


          //--------------------Karthika_K

          public void DelTempFAChequeClearance(int empid, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                         new SqlParameter("@dbname", SqlDbType.VarChar ,15)};
              objp[0].Value = empid;
              objp[1].Value = dbname;
              ExecuteQuery("DelTempChequeClearance", objp);
          }
          public void InsTempchequeClearance(int empid, string dbname, int branchid, string date, string chequeno, string bankbranch, string Customer, string amount, string Cleared, string rid, string slipno, string clearedon, string branch, string cmbtype)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar ,15),
                                                         new SqlParameter("@branchid", SqlDbType.Int,2),
                                                        new SqlParameter("@date", SqlDbType.NVarChar ,50),
                                                         new SqlParameter("@chequeNo",SqlDbType.NVarChar ,50),
                                                        new SqlParameter("@bankBranch", SqlDbType.NVarChar ,50),
                                                        new SqlParameter("@customer", SqlDbType.NVarChar ,150),
                                                        new SqlParameter("@amount", SqlDbType.NVarChar ,50),
                                                         new SqlParameter("@cleared",SqlDbType.NVarChar,50),
                                                        new SqlParameter("@rid", SqlDbType.NVarChar,50),
                                                         new SqlParameter("@slipno",SqlDbType.NVarChar,50),
                                                        new SqlParameter("@clearedOn",SqlDbType .NVarChar,50),
                                                        new SqlParameter("@branch",SqlDbType.NVarChar,50),
                                                        new SqlParameter("@cmbtype",SqlDbType.NVarChar,50)};
              objp[0].Value = empid;
              objp[1].Value = dbname;
              objp[2].Value = branchid;
              objp[3].Value = date;
              objp[4].Value = chequeno;
              objp[5].Value = bankbranch;
              objp[6].Value = Customer;
              objp[7].Value = amount;
              objp[8].Value = Cleared;
              objp[9].Value = rid;
              objp[10].Value = slipno;
              objp[11].Value = clearedon;
              objp[12].Value = branch;
              objp[13].Value = cmbtype;

              ExecuteQuery("InsTempChequeClearance", objp);
          }
          public DataTable GPBrekup(int branchid, DateTime fdate, DateTime tdate, string dbname, string div)
          {
              SqlParameter[] objp = new SqlParameter[]{
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@div",SqlDbType.VarChar,1)};
              objp[0].Value = branchid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              objp[4].Value = div;

              return ExecuteTable("spGPBrekup", objp);
          }



          public DataTable FAselLedgergrd4Month4web(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
              objp[0].Value = branchid;
              objp[1].Value = ledgerid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              objp[4].Value = dbname;
              return ExecuteTable("SPFAselLedgergrd4Month4web", objp);
          }


          public DataTable FAselLedgergrd4Day(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
              objp[0].Value = branchid;
              objp[1].Value = ledgerid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              objp[4].Value = dbname;
              return ExecuteTable("SPFAselLedgergrd4Day", objp);
          }

          public DataTable FAselLedgergrd4Day4AllBranch(int divisionid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
              objp[0].Value = divisionid;
              objp[1].Value = ledgerid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              objp[4].Value = dbname;
              return ExecuteTable("SPFAselLedgergrd4Day4AllBranch", objp);
          }

          public void DelTempFALedgerView(int empid, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                         new SqlParameter("@dbname", SqlDbType.VarChar ,15)};
              objp[0].Value = empid;
              objp[1].Value = dbname;
              ExecuteQuery("DelTempFALedgerView", objp);
          }

          public void InsTempLedgerView(int empid, string dbname, int branchid, string date, string vouno, string voutype, string parti, double debit, double credit, string balance, string narration, string containerno, string vendorrefno, int jobno, string refno, string curr, double dramt, double cramt, double exrate, int rno)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar ,15),
                                                         new SqlParameter("@branchid", SqlDbType.Int,2),
                                                        new SqlParameter("@date", SqlDbType.VarChar ,15),
                                                         new SqlParameter("@vouno",SqlDbType.VarChar ,15),
                                                        new SqlParameter("@voutype", SqlDbType.VarChar ,100),
                                                        new SqlParameter("@parti", SqlDbType.VarChar ,150),
                                                         new SqlParameter("@Debit",SqlDbType.Money),
                                                        new SqlParameter("@Credit", SqlDbType.Money),
                                                         new SqlParameter("@Balance",SqlDbType.VarChar,50),
                                                        new SqlParameter("@narration",SqlDbType .VarChar,200),
                                                        new SqlParameter("@Container",SqlDbType.VarChar,100),
                                                        new SqlParameter("@VendorRefNo",SqlDbType.VarChar,50),
                                                        new SqlParameter("@jobno",SqlDbType.VarChar,100),
                                                        new SqlParameter("@refno",SqlDbType.VarChar,100),
                                                        new SqlParameter("@Cur",SqlDbType.VarChar,15),
                                                        new SqlParameter("@dramt",SqlDbType.Money),
                                                        new SqlParameter("@cramt",SqlDbType.Money),
                                                        new SqlParameter("@exrate",SqlDbType.Money),
                                                        new SqlParameter("@rno",SqlDbType.Int,2)};
              objp[0].Value = empid;
              objp[1].Value = dbname;
              objp[2].Value = branchid;
              objp[3].Value = date;
              objp[4].Value = vouno;
              objp[5].Value = voutype;
              objp[6].Value = parti;
              objp[7].Value = debit;
              objp[8].Value = credit;
              objp[9].Value = balance;
              objp[10].Value = narration;
              objp[11].Value = containerno;
              objp[12].Value = vendorrefno;
              objp[13].Value = jobno;
              objp[14].Value = refno;
              objp[15].Value = curr;
              objp[16].Value = dramt;
              objp[17].Value = cramt;
              objp[18].Value = exrate;
              objp[19].Value = rno;

              ExecuteQuery("InsTempLedgerView", objp);
          }

          public DataSet SelAgainstRefDet(string dbname, int ledgerid, DateTime fdate, DateTime tdate, int branchid, int divisionid)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@ledgerid", SqlDbType.Int),
                                                       new SqlParameter("@fdate", SqlDbType.DateTime ),
                                                         new SqlParameter("@tdate", SqlDbType.DateTime),
                                                        new SqlParameter("@bid", SqlDbType.Int),
                                                         new SqlParameter("@divid",SqlDbType.Int),
                                                        new SqlParameter("@dbname", SqlDbType.NVarChar )};
              objp[0].Value = ledgerid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = branchid;
              objp[4].Value = divisionid;
              objp[5].Value = dbname;

              return ExecuteDataSet("FALedgerAgainstRefDet", objp);
          }

          public DataSet FASelopbal4AllBranch(int ledgerid, DateTime fdate, DateTime tdate, string dbname, int divisionId)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                       new SqlParameter("@divisionId",SqlDbType.Int,4)};

              objp[0].Value = ledgerid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              objp[4].Value = divisionId;
              return ExecuteDataSet("SPFASelopbal4AllBranch", objp);
          }

          public DataTable FAselLedgergrd4AllBranch(int ledgerid, DateTime fdate, DateTime tdate, string dbname, int divisionId)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};

              objp[0].Value = ledgerid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              objp[4].Value = divisionId;
              return ExecuteTable("SPFAselLedgergrd4AllBranchGST", objp);
          }

          public DataTable FAselLedgergrdWithDet(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
              objp[0].Value = branchid;
              objp[1].Value = ledgerid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              objp[4].Value = dbname;
              return ExecuteTable("SPFAselLedgergrdWithDetGST", objp);
              //return ExecuteTable("SPFAselLedgergrd", objp);
          }

          public DataSet FASelopbal4web(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),
                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)};
              objp[0].Value = branchid;
              objp[1].Value = ledgerid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              objp[4].Value = dbname;
              return ExecuteDataSet("SPFASelopbal4web", objp);
          }

          public DataSet SelProfitLosswithdate4WEB(string dbname, int branchid, DateTime fdate, DateTime tdate)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
              objp[0].Value = dbname;
              objp[1].Value = branchid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              return ExecuteDataSet("SPFAProfitLosswithdate4WEB", objp);
          }

          public DataSet SelProfitLossLedgerwise4AllBranch(string dbname, int divisionid, DateTime fdate, DateTime tdate)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime)};
              objp[0].Value = dbname;
              objp[1].Value = divisionid;
              objp[2].Value = fdate;
              objp[3].Value = tdate;
              return ExecuteDataSet("SPFAPLLedgerwise4AllBranch", objp);
          }


          public DataTable GetLedgerGroupSummary4AllBranch(string dbname, DateTime from, DateTime to, int divisionId, int subgroupid)
          {
              SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@divisionId",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@subgroupid",SqlDbType.Int)};

              objp[0].Value = dbname;
              objp[1].Value = from;
              objp[2].Value = to;
              objp[3].Value = divisionId;
              objp[4].Value = subgroupid;
              return ExecuteTable("SPFALedgerGroupSummary4AllBranch", objp);
          }

          public void InsTempFATrailBalance(int empid, string dbname, string ledgername, double obcr, double obdr, double trdr, double trcr, double cldr, double clcr, string gtype, int rno, int branchid)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar ,15),
                                                         new SqlParameter("@ledgername", SqlDbType.VarChar ,100),
                                                        new SqlParameter("@obdr", SqlDbType.Money),
                                                         new SqlParameter("@obcr",SqlDbType.Money),
                                                        new SqlParameter("@trdr", SqlDbType.Money),
                                                         new SqlParameter("@trcr",SqlDbType.Money),
                                                        new SqlParameter("@cldr", SqlDbType.Money),
                                                         new SqlParameter("@clcr",SqlDbType.Money),
                                                        new SqlParameter("@gtype",SqlDbType .VarChar,20),
                                                        new SqlParameter("@rno",SqlDbType.Int,2),
                                                        new SqlParameter("@branchid",SqlDbType.Int,2)};
              objp[0].Value = empid;
              objp[1].Value = dbname;
              objp[2].Value = ledgername;
              objp[3].Value = obdr;
              objp[4].Value = obcr;
              objp[5].Value = trdr;
              objp[6].Value = trcr;
              objp[7].Value = cldr;
              objp[8].Value = clcr;
              objp[9].Value = gtype;
              objp[10].Value = rno;
              objp[11].Value = branchid;
              ExecuteQuery("InsTempFATrailBalance", objp);
          }

          public DataSet FAselTrailBalance4AllBranch(DateTime fdate, DateTime tdate, string dbname, int DivisionId)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@divisionId",SqlDbType.Int,4)};

              objp[0].Value = fdate;
              objp[1].Value = tdate;
              objp[2].Value = dbname;
              objp[3].Value = DivisionId;
              return ExecuteDataSet("SPFAselTrailBalance4AllBranch", objp);
          }


          //--------------- For All Branch changed by Priya

          public DataSet FAselTrailBalance4AllBranch(DateTime fdate, DateTime tdate, string dbname, int DivisionId, string dispname, int Emp_ID)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                    new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                    new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4),
                                                    new SqlParameter("@dispname",SqlDbType.VarChar,20),
                                                    new SqlParameter("@empid",SqlDbType.Int,4)};

              objp[0].Value = fdate;
              objp[1].Value = tdate;
              objp[2].Value = dbname;
              objp[3].Value = DivisionId;
              objp[4].Value = dispname;
              objp[5].Value = Emp_ID;
              return ExecuteDataSet("SPTB4allbranch", objp);
          }


          //-- Changing for Speed

          public DataSet FAselTrailBalance4AllBranch_New(DateTime fdate, DateTime tdate, string dbname, int DivisionId, int Empid)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@divisionId",SqlDbType.Int,4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4)};

              objp[0].Value = fdate;
              objp[1].Value = tdate;
              objp[2].Value = dbname;
              objp[3].Value = DivisionId;
              objp[4].Value = Empid;
              return ExecuteDataSet("SPFAselTrailBalance4AllBranch_New", objp);
          }

          public DataSet FAselAllLedgerFTdate(int branchid, DateTime fdate, DateTime tdate, string dbname, string dispname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                         new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@dispname",SqlDbType.VarChar,20)};
              objp[0].Value = branchid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              objp[4].Value = dispname;

              return ExecuteDataSet("SPFAselAllLedgerFTdate", objp);
          }

          public DataSet FAselAllLedgerFTdate(int branchid, DateTime fdate, DateTime tdate, string dbname, string dispname, int EmpID)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@fdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@tdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@dispname",SqlDbType.VarChar,20),
                                                        new SqlParameter("@empid",SqlDbType.Int)};
              objp[0].Value = branchid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              objp[4].Value = dispname;
              objp[5].Value = EmpID;
              return ExecuteDataSet("sptb1", objp);
          }

        //Ruban
          public DataTable FAselLedgergrd4AllBranchTransfer(int ledgerid, DateTime fdate, DateTime tdate, string dbname, int divisionId)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                      new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@tdate",SqlDbType.DateTime,8),                                                       
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};

              objp[0].Value = ledgerid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              objp[4].Value = divisionId;
              return ExecuteTable("SPFAselLedgergrd4AllBranchGSTTransferLedger", objp);
          }


          /**************************** For Auto Mail Vouchers ******************************/
          public DataSet Getapprovingvouchermail(int refno, string vtype, int branchid, int vyear, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@refno", SqlDbType.Int),
                                                        new SqlParameter("@vtype", SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid", SqlDbType.Int),
                                                        new SqlParameter("@vyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,20)
                                                    };
              objp[0].Value = refno;
              objp[1].Value = vtype;
              objp[2].Value = branchid;
              objp[3].Value = vyear;
              objp[4].Value = dbname;

              return ExecuteDataSet("sp_approvingvouchermail", objp);
          }

          public DataTable GetPortNameforBranch(int branchid)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.Int,4)
                                                     };
              objp[0].Value = branchid;
              return ExecuteTable("SPGetPortNameforBranch", objp);
          }

          public DataSet GetRecPymtVoucherMail(int vouno, string vtype, int branchid, int vyear, string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@vouno", SqlDbType.Int),
                                                        new SqlParameter("@vtype", SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid", SqlDbType.Int),
                                                        new SqlParameter("@vyear",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,20)
                                                    };
              objp[0].Value = vouno;
              objp[1].Value = vtype;
              objp[2].Value = branchid;
              objp[3].Value = vyear;
              objp[4].Value = dbname;

              return ExecuteDataSet("sp_RecPymtVoucherMail", objp);
          }

          public DataTable GetListOfAccinFA (string dbname)
          {
              SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname",SqlDbType.VarChar,20) };

              objp[0].Value = dbname;

              return ExecuteTable("SP_ListOfAccinFA", objp);
          }


          public DataTable PandLDetails(int branchid, DateTime fdate, DateTime tdate, string dbname)  //////haribalaji----13_02_2023
          {
              SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                       new SqlParameter("@to",SqlDbType.DateTime,8),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
              objp[0].Value = branchid;
              objp[1].Value = fdate;
              objp[2].Value = tdate;
              objp[3].Value = dbname;
              return ExecuteTable("sp_PandLDetails", objp);
          }
        

public DataTable FAselLedgergrdGST_panno12(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname, string dispname, string pano, string gst)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                              new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                               new SqlParameter("ledgerid",SqlDbType.Int,4),
                                              new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                               new SqlParameter("@tdate",SqlDbType.DateTime,8),

                                              new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                new SqlParameter("@dispname",SqlDbType.VarChar,15),
                                                new SqlParameter("@pano",SqlDbType.VarChar,40),
      new SqlParameter("@gstno",SqlDbType.VarChar,40)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            objp[5].Value = dispname;
            objp[6].Value = pano;
            objp[7].Value = gst;
            return ExecuteTable("SPFAselLedgergrdGST_panno12_new", objp);
        }
        public DataTable FAselLedgergrdGST_panno12almt(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname, string dispname, string pano, string gst)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                         new SqlParameter("ledgerid",SqlDbType.Int,4),
                                        new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                         new SqlParameter("@tdate",SqlDbType.DateTime,8),

                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                          new SqlParameter("@dispname",SqlDbType.VarChar,15),
                                          new SqlParameter("@pano",SqlDbType.VarChar,40),
new SqlParameter("@gstno",SqlDbType.VarChar,40)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            objp[5].Value = dispname;
            objp[6].Value = pano;
            objp[7].Value = gst;
            return ExecuteTable("SPFAselLedgergrdGST_panno12_newalmnt", objp);
        }

        // PAN - Ledger [19-02-2024] 
        public DataTable FAselLedgergrdGST_panno_ledg(int branchid, int ledgerid, DateTime fdate, DateTime tdate, string dbname, string dispname, string pano, string gst, int portid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                 new SqlParameter("ledgerid",SqlDbType.Int,4),
                                new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                 new SqlParameter("@tdate",SqlDbType.DateTime,8),

                                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                  new SqlParameter("@dispname",SqlDbType.VarChar,15),
                                  new SqlParameter("@pano",SqlDbType.VarChar,40),
                                new SqlParameter("@gstno",SqlDbType.VarChar,40),
                                new SqlParameter("@portid",SqlDbType.VarChar,40)};
            objp[0].Value = branchid;
            objp[1].Value = ledgerid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            objp[4].Value = dbname;
            objp[5].Value = dispname;
            objp[6].Value = pano;
            objp[7].Value = gst;
            objp[8].Value = portid;
            return ExecuteTable("SPFAselLedgergrdGST_panno_ledg", objp);
        }

        public DataTable mstbrnch(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                new SqlParameter("@bid",SqlDbType.Int,4)
                                             };
            objp[0].Value = branchid;
            return ExecuteTable("spmstbrnch", objp);
        }

        /////////////////////
        ///
        public DataTable GetLedgerGroupSummary4AllBranch_all(string dbname, DateTime from, DateTime to, int divisionId, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@divisionId",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@subgroupid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = divisionId;
            objp[4].Value = subgroupid;
            return ExecuteTable("SPFALedgerGroupSummary4AllBranch_all", objp);
        }

        public DataTable GetLedgerGroupSummary_all(string dbname, DateTime from, DateTime to, int branchid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@subgroupid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = branchid;
            objp[4].Value = subgroupid;
            return ExecuteTable("SPFALedgerGroupSummary_all", objp);
        }


        public DataTable GetLedgerGroupSummary4BS_new(string dbname, DateTime from, DateTime to, int branchid, int grpid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@grpid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = branchid;
            objp[4].Value = grpid;
            return ExecuteTable("SPFALedgerGroupSummary4BS_all_new", objp);
        }
        public DataTable GetLedgerGroupSummary4BS4AllBranch_new(string dbname, DateTime from, DateTime to, int divisionId, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@divisionId",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@subgroupid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = divisionId;
            objp[4].Value = subgroupid;
            return ExecuteTable("SPFALedgerGroupSummary4BS4AllBranch_all_new", objp);
        }


        public DataTable GetSubGroupSummary4BS_new(string dbname, DateTime from, DateTime to, int branchid, int grpid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@grpid",SqlDbType.Int)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = branchid;
            objp[4].Value = grpid;
            return ExecuteTable("SPFASubGroupSummary4BS_newall", objp);
        }




        public DataTable GetSubGroupSummary4AllBranch_new(string dbname, DateTime from, DateTime to, int grpid, int divisionId)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@grpid",SqlDbType.Int),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = grpid;
            objp[4].Value = divisionId;
            return ExecuteTable("SPFASubGroupSummary4AllBranch_all_new", objp);
        }
        public DataTable GetSubGroupSummary4BS4AllBranch_all_new(string dbname, DateTime from, DateTime to, int grpid, int divisionId)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@from",SqlDbType.DateTime,2),
                                                     new SqlParameter("@to",SqlDbType.DateTime,2),
                                                     new SqlParameter("@grpid",SqlDbType.Int),
                                                    new SqlParameter("@divisionId",SqlDbType.Int,4)};

            objp[0].Value = dbname;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = grpid;
            objp[4].Value = divisionId;
            return ExecuteTable("SPFASubGroupSummary4BS4AllBranch_all_new", objp);
        }
        public DataSet sptbpiv_allset2(int branch, DateTime fdate, DateTime tdate, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@branchid", SqlDbType.Int),
                                                    new SqlParameter("@fromdate", SqlDbType.DateTime, 8),
                                                    new SqlParameter("@todate",SqlDbType.DateTime, 8),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};

            objp[0].Value = branch;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = vouyear;
            return ExecuteDataSet("tbpiv_allset3", objp);
        }
        ///
        /////////////////////


    }
}
