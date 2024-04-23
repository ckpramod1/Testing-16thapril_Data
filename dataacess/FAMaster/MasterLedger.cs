using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.FAMaster
{
    public class MasterLedger:DBObject 
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterLedger()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsLedgerHead(string ledgername, int sgroupid, int groupid,char acctype,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@subgroupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@groupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@acctype", SqlDbType.Char, 1),
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = sgroupid;
            objp[2].Value = groupid;
            objp[3].Value = acctype;
            objp[4].Direction = ParameterDirection.Output;
            objp[5].Value = dbname;
            return ExecuteQuery("SPInsFALedgerHead", objp, "@ledgerid");

        }
        public void InsLedgerDetails(int ledgerid, int divisionid, int branchid, char  pbtype,char opbtype, double pbamt, double opbamt,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@pbtype", SqlDbType.Char, 1),
                                                        new SqlParameter("@opbtype", SqlDbType.Char, 1),
                                                         new SqlParameter("@pbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@opbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = pbtype;
            objp[4].Value = opbtype;
            objp[5].Value = pbamt;
            objp[6].Value = opbamt;
            objp[7].Value = dbname;
            ExecuteQuery("SPInsFALedgerDetails", objp);
        }
        
        
        public void  UpdLedgerHead(string ledgername, int sgroupid, int groupid, char acctype,int ledgerid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@subgroupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@groupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@acctype", SqlDbType.Char, 1),
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = sgroupid;
            objp[2].Value = groupid;
            objp[3].Value = acctype;
            objp[4].Value = ledgerid;
            objp[5].Value = dbname;
            ExecuteQuery("SPUpdFALedgerHead", objp);

        }
        public void UpdLedgerDetails(int ledgerid, int divisionid, int branchid, char amttype, double pbamt, double opbamt,string columnname,string dbname,double minamt,double maxamt,char costapp)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@amttype", SqlDbType.Char, 1),
                                                       
                                                         new SqlParameter("@pbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@opbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@columnname",SqlDbType.NVarChar,30),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@minamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@maxamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@costapp", SqlDbType.Char,1)
                                                                    

                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = amttype;
            objp[4].Value = pbamt;
            objp[5].Value = opbamt;
            objp[6].Value = columnname;
            objp[7].Value = dbname;
            objp[8].Value = minamt ;
            objp[9].Value = maxamt ;
            objp[10].Value = costapp ;
            ExecuteQuery("SPUpdFALedgerDetails", objp);
        }
        public DataTable GetLikeLedgername(string ledgername,int divisionid,int branchid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAMasterledgernamelike", objp);
        }
        public DataTable SelMasterLedger(int ledgerid,string dbname,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),};
            objp[0].Value = ledgerid;
            objp[1].Value = dbname;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelFALedger", objp);
        }
        public void UpdLedgerid(string dbname,int branchid,int ledgerid, int opsid, char opstype)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@opsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@opstype", SqlDbType.Char, 1)
                                                                                                               };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = ledgerid;
            objp[3].Value = opsid;
            objp[4].Value = opstype;
            ExecuteQuery("SPFAUpdledgerid", objp);
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

        public DataTable GetLikeLedgernameforcontra(string ledgername, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAMasterledgernamecolike", objp);
        }

        public DataTable GetCustname(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@customerid",SqlDbType.Int,4)
                                                        };
            objp[0].Value = custid;
            return ExecuteTable("SPFAselCustgrd", objp);
        }
        public DataTable GetChargename(int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@chrgid",SqlDbType.Int,4)
                                                        };
            objp[0].Value = chargeid;
            return ExecuteTable("SPFAselChrggrd", objp);
        }

        public int ChkLedgeridfrmLedHead(int cid, string opstype,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cid", SqlDbType.Int, 4),
                                                       new SqlParameter("@opstype", SqlDbType.VarChar, 2),
                                                         new SqlParameter("@dbname",SqlDbType.VarChar,15)};
                                                                                                            
            objp[0].Value = cid;
            objp[1].Value = opstype;
            objp[2].Value = dbname;
            return int.Parse(ExecuteReader("SPChkledgeridinHead", objp));
        }
        public DataTable Getdtls4ledgrd(int opsid,string opstype)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@opsid",SqlDbType.Int,4),
                                                        new SqlParameter("@opstype", SqlDbType.Char , 1) };
            objp[0].Value = opsid;
            objp[1].Value = opstype;
            return ExecuteTable("SPgetdtls4ledgrd", objp);
        }


        public DataTable GetCrandDBfromLedger(int branchid, int divisionid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
            };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = dbname;
            return ExecuteTable("SPGetCd&DbfromLedger", objp);


        }

        //public DataTable GetreceiptamountfromHead(int branchid, int year)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //        new SqlParameter("@branchid",SqlDbType.Int),
        //        new SqlParameter("@year",SqlDbType.Int,4)
        //    };
        //    objp[0].Value = branchid;
        //    objp[1].Value = year;
        //    return ExecuteTable("SPGetReceiptfromACRhead", objp);
        //}
        public DataTable GetreceiptamountfromHead(int branchid, int year, DateTime voudate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@year",SqlDbType.Int,4),
                new SqlParameter ("@voudate",SqlDbType.SmallDateTime)
            };
            objp[0].Value = branchid;
            objp[1].Value = year;
            objp[2].Value = voudate;
            return ExecuteTable("SPGetReceiptfromACRhead", objp);
        }

        //public DataTable GetPaymentamountfromHead(int branchid, int year)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //        new SqlParameter("@branchid",SqlDbType.Int),
        //        new SqlParameter("@year",SqlDbType.Int,4)
        //    };
        //    objp[0].Value = branchid;
        //    objp[1].Value = year;
        //    return ExecuteTable("SPGetPaymentfromACPhead", objp);
        //}

        public DataTable GetPaymentamountfromHead(int branchid, int year, DateTime voudate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@year",SqlDbType.Int,4),
                new SqlParameter("@voudate",SqlDbType.SmallDateTime)
            };
            objp[0].Value = branchid;
            objp[1].Value = year;
            objp[2].Value = voudate;
            return ExecuteTable("SPGetPaymentfromACPhead", objp);
        }

        public int InsLedgerHeadfromTally(string ledgername, int sgroupid, int groupid, char acctype,  int opsid, char opstype,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@subgroupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@groupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@acctype", SqlDbType.Char, 1),
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@opsid",SqlDbType.Int,4),
                                                        new SqlParameter("@opsType",SqlDbType.Char,1),};
            objp[0].Value = ledgername;
            objp[1].Value = sgroupid;
            objp[2].Value = groupid;
                objp[3].Value = acctype;
            objp[4].Direction = ParameterDirection.Output;
            objp[5].Value = dbname;
            objp[6].Value = opsid;
            objp[7].Value = opstype;
            return ExecuteQuery("SPInsFALedgerHeadfrmTally", objp, "@ledgerid");

        }


        public DataSet GetCrandDBfromLedger(int branchid, int divisionid, string dbname, DateTime voudate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@voudate",SqlDbType.SmallDateTime)
            };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = dbname;
            objp[3].Value = voudate;
            return ExecuteDataSet("SPGetCd&DbfromLedger", objp);


        }

        //KUMAR Upd SerTax & PAN # START    06-02-2012


        public DataTable GetLikeLedgernameLedger(string ledgername, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;

            return ExecuteTable("SPFAMasterledgernamelikeledger", objp);
        }

        public DataSet SelFALedgerPreviousFA(int ledgerid, string dbname, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@divisionid",SqlDbType.Int,4),};
            objp[0].Value = ledgerid;
            objp[1].Value = dbname;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;
            return ExecuteDataSet("SPSelFALedgerPreviousFA", objp);
        }




        public void UpdSerTaxandPan4Ldgr(int ledgerid, string sertax, string pan, string dbname,int bid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@ledgerid",SqlDbType.Int,4),
                new SqlParameter("@servicetax",SqlDbType.VarChar,15),
                new SqlParameter("@panno",SqlDbType.VarChar,15),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@branchid",SqlDbType.TinyInt )
            };
            objp[0].Value = ledgerid;
            objp[1].Value = sertax;
            objp[2].Value = pan;
            objp[3].Value = dbname;
            objp[4].Value = bid ;
            ExecuteQuery("SPUpdSerTaxandPan4Ldgr", objp);
        }
        //KUMAR Upd SerTax & PAN # END      06-02-2012

     
        public DataTable GetBankLedger(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
            };
            objp[0].Value = dbname;
            return ExecuteTable("spFAGetBankLedger", objp);
        }

          //Ruban



        public int GetLedgerId(string ledgername, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar,100),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
                                                    
            objp[0].Value = ledgername;
            objp[1].Value = dbname;
           // objp[2].Value = branchid;
            return int.Parse(ExecuteReader("SP_ledgerid", objp));
        }


        public void UpdateLedgerDetails4USD(int ledgerid, int branchid, double opbamtusd, char opbtypeusd, string dbname, string opbalcurr)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@opbamtusd", SqlDbType.Money),
                                                       new SqlParameter("@opbtypeusd", SqlDbType.Char, 1),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                       new SqlParameter("@opbalcurr",SqlDbType.VarChar,3)
                                                       };
            objp[0].Value = ledgerid;
            objp[1].Value = branchid;
            objp[2].Value = opbamtusd;
            objp[3].Value = opbtypeusd;
            objp[4].Value = dbname;
            objp[5].Value = opbalcurr;

            ExecuteQuery("SPUpdateLedgerDetails4USD", objp);
        }


        //Fa
        //nambi 

        public DataTable GetLikeLedgername4NonBlock(string ledgername, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAMasterledgernamelike4NonBlock", objp);
        }


        //Block Ledger
        public DataTable UpdBlockLedgerID(int DLedgerId, char block, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@DLedgerId", SqlDbType.Int,4),
                                                        new SqlParameter("@block",SqlDbType.Char,1),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = DLedgerId;
            objp[1].Value = block;
            objp[2].Value = dbname;
            return ExecuteTable("SPFABlockLedgerID", objp);
        }

        //--------------Karthika_K

        public DataSet GetCrandDBfromLedger(int branchid, int divisionid, string dbname, DateTime voudate, int ledgerid, string curtype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@voudate",SqlDbType.SmallDateTime),
                new SqlParameter("@Ledgerid",SqlDbType.Int),
                new SqlParameter("@curtype",SqlDbType.VarChar)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = dbname;
            objp[3].Value = voudate;
            objp[4].Value = ledgerid;
            objp[5].Value = curtype;
            return ExecuteDataSet("SPGetCd&DbfromLedger", objp);


        }

        public DataTable GetBank4Contra(int ledgerid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@ledgerid",SqlDbType.BigInt),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
            };
            objp[0].Value = ledgerid;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAbank4contra", objp);
        }

        //Manoj For Dash Board
        public DataTable GetBankBalancefordashboard(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            return ExecuteTable("SPgetBankalancesfordash", objp);
        }

        public DataTable GetCashBalancefordashboard(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            return ExecuteTable("SPgetCashbalancesfordash", objp);
        }



        public DataTable GetPaymentfromvoucherdetailsfordash(string dbname, int branchid, DateTime fdate, DateTime tdate, char status, int voutypeid, double amount, string qtype, string refno)
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
            return ExecuteTable("SPGetPaymentDetailsFromVoucherforDash", objp);
        }

        public DataTable GetReceiptsfromvoucherdetailsfordash(string dbname, int branchid, DateTime fdate, DateTime tdate, char status, int voutypeid, double amount, string qtype, string refno)
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
            return ExecuteTable("SPGetRecieptDetailsFromVoucherforDash", objp);
        }

        public DataTable GetOVCBalancefordashboard(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            return ExecuteTable("SPgetOVCbalancesfordash", objp);
        }

        public DataTable GetCTCBalancefordashboard(string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            return ExecuteTable("SPgetCTCbalancesfordash", objp);
        }

        public DataSet GetOVCLEDBalancefordashboard(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
            };
            objp[0].Value = dbname;
            return ExecuteDataSet("SPGetOVCBalancefromLedgerDetails", objp);
        }

        public DataSet GetCTCLEDBalancefordashboard(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
            };
            objp[0].Value = dbname;
            return ExecuteDataSet("SPGetCTCBalancefromLedgerDetails", objp);
        }


        //Karthika_K

        public DataTable FACkhopsid(string dbname, int opsid, string opstype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                       new SqlParameter("@opsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@opstype", SqlDbType.Char, 1),
                                                        };

            objp[0].Value = dbname;
            objp[1].Value = opsid;
            objp[2].Value = opstype;
            return ExecuteTable("SPFACkhopsid", objp);
        }


        public void UpdAliasName4Ledger(string dbname, int ledgerid, string alias)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                       new SqlParameter("@ledgerid",SqlDbType.Int,4),
                                                       new SqlParameter("@alias",SqlDbType.VarChar,100)
                                                       };
            objp[0].Value = dbname;
            objp[1].Value = ledgerid;
            objp[2].Value = alias;
            ExecuteQuery("spupdalias", objp);

        }

        public DataTable GetexactLedgernameLedger(string ledgername, int divisionid, int branchid, string dbname, int opsid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@opsid",SqlDbType.Int,4)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            objp[4].Value = opsid;
            return ExecuteTable("SPFAMasterledgernameexactledger", objp);
        }

        //------------Karthika_K

        public DataTable GetLedgerDetails(int Ledgerid, int branchid, int Empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Ledgerid",  SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@empid ",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = Ledgerid;
            objp[1].Value = branchid;
            objp[2].Value = Empid;
            objp[3].Value = dbname;

            return ExecuteTable("sp_InsLedgerDetails", objp);
        }

        public DataTable GetLikeLedgernameExact(string ledgername, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAMasterledgernameExact", objp);
        }



        public DataTable GetreceiptamountfromHead(int branchid, int year, DateTime voudate, string BankName)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@year",SqlDbType.Int,4),
                new SqlParameter ("@voudate",SqlDbType.SmallDateTime),
                new SqlParameter("@bankName",SqlDbType.VarChar,150)
            };
            objp[0].Value = branchid;
            objp[1].Value = year;
            objp[2].Value = voudate;
            objp[3].Value = BankName;
            return ExecuteTable("SPGetReceiptfromACRhead", objp);
        }

        public DataTable GetPaymentamountfromHead(int branchid, int year, DateTime voudate, string BankName)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@year",SqlDbType.Int,4),
                new SqlParameter("@voudate",SqlDbType.SmallDateTime),
                new SqlParameter("@BankName",SqlDbType.VarChar,150)
            };
            objp[0].Value = branchid;
            objp[1].Value = year;
            objp[2].Value = voudate;
            objp[3].Value = BankName;
            return ExecuteTable("SPGetPaymentfromACPhead", objp);
        }


        //merger Ledger
        public DataTable UpdChangeLedgerID(int DLedgerId, int CLedgerId, int branchid, int divisionid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@DLedgerId", SqlDbType.Int,4),
                                                        new SqlParameter("@CLedgerId",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = DLedgerId;
            objp[1].Value = CLedgerId;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;
            objp[4].Value = dbname;
            return ExecuteTable("SPFAChangeLedgerID", objp);
        }


        public void UpdLedgerDetails(int ledgerid, int divisionid, int branchid, char amttype, double pbamt, double opbamt, string columnname, string dbname, double minamtdr, double maxamtdr, double minamtcr, double maxamtcr, char costapp)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@amttype", SqlDbType.Char, 1),
                                                       
                                                         new SqlParameter("@pbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@opbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@columnname",SqlDbType.NVarChar,30),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@minamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@maxamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@minamtcr", SqlDbType.Money, 8),
                                                        new SqlParameter("@maxamtcr", SqlDbType.Money, 8),
                                                        new SqlParameter("@costapp", SqlDbType.Char,1)
                                                                    

                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = amttype;
            objp[4].Value = pbamt;
            objp[5].Value = opbamt;
            objp[6].Value = columnname;
            objp[7].Value = dbname;
            objp[8].Value = minamtdr;
            objp[9].Value = maxamtdr;
            objp[10].Value = minamtcr;
            objp[11].Value = maxamtcr;
            objp[12].Value = costapp;
            ExecuteQuery("SPUpdFALedgerDetails", objp);
        }

        public DataTable GetLedgername4NonBlock(int ledgerid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgerid;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAMasterledgername4NonBlock", objp);
        }

        //RAJ
        public string GetLedgernamewithID(int ledgerID, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgerID;
            objp[1].Value = dbname;
            return ExecuteReader("SPFAMasterledgernamewithID", objp);
        }

        public DataTable GetLedgernamebyID(int ledgerID, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgerID;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAMasterledgernamebyID", objp);
        }
        //Dinesh



        public DataTable Getbookclosure(int bid,int div, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = bid;
            objp[1].Value = div;
            objp[2].Value = dbname;
            return ExecuteTable("spbookclosure", objp);
        } 



    

        public DataTable Getledgerviewcheck(int bid, int div, int ledgerid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                         new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = bid;
            objp[1].Value = div;
            objp[2].Value = ledgerid;
            objp[3].Value = dbname;
            return ExecuteTable("spledgerviewcheck", objp);
        }
        //Dinesh

        public DataTable GetLikeLedgernamenew(string ledgername, int divisionid, int branchid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = ledgername;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = dbname;
            return ExecuteTable("SPFAMasterledgernamelikeblocked", objp);
        }

        public DataTable Getledgerblocked( string dbname, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15),    new SqlParameter("@ledgerid", SqlDbType.Int, 4),};
         
            objp[0].Value = dbname;
            objp[1].Value = ledgerid;
            return ExecuteTable("spledgerblocked", objp);
        }


        public void insledgerdetailsnew(int Dlederid, string Dledername, int dsubgroupid, int dgroupid, int cledgerid, string cledgername, int csubgroupid, int cgroupid, int bid, DateTime updateon, int updatedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Dlederid", SqlDbType.Int, 4),
                                                        new SqlParameter("@Dledername", SqlDbType.VarChar, 250),
                                                        new SqlParameter("@dsubgroupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dgroupid", SqlDbType.Int, 4),
                                                       
                                                         new SqlParameter("@cledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@cledgername", SqlDbType.VarChar, 250),
                                                        new SqlParameter("@csubgroupid",SqlDbType.Int, 4),
                                                        new SqlParameter("@cgroupid",SqlDbType.Int, 4),
                                                        new SqlParameter("@bid", SqlDbType.Int, 4),
                                                        new SqlParameter("@updateon", SqlDbType.DateTime, 4),
                                                        new SqlParameter("@updatedby", SqlDbType.Int, 4)
                                                      
                                                                    

                                                        };
                  objp[0].Value = Dlederid;
                  objp[1].Value = Dledername;
                  objp[2].Value = dsubgroupid;
                  objp[3].Value = dgroupid;
                  objp[4].Value = cledgerid;
                  objp[5].Value = cledgername;
                  objp[6].Value = csubgroupid;
                  objp[7].Value = cgroupid;
                  objp[8].Value = bid;
                  objp[9].Value = updateon;
                  objp[10].Value = updatedby;
            ExecuteQuery("sp_mergerledgerdetails", objp);
        }

        //masterledger.cs
        //Tally
        public DataTable SPTallyAllVouchersOnlyApprovedbyZero(DateTime frdate, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@date", SqlDbType.DateTime,10),
                                                        new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = frdate;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;

            return ExecuteTable("SPTallyAllVouchersOnlyApprovedbyZero", objp);
        }
        public DataTable GetAllVouchersCount(int vouyear, int branchid, DateTime fromdate, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouyear", SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromdate",SqlDbType.DateTime,10),new SqlParameter("@empid",SqlDbType.Int,4)
            };
            objp[0].Value = vouyear;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = empid;
            return ExecuteTable("sp_getallvouchersno", objp);
        }

        /*----- For BRS -----*/

        public DataTable ConfirmedBRS(string bankname, int bid, int divid, DateTime cBRS, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                     new SqlParameter("@bankname", SqlDbType.VarChar, 50),
                                     new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                     new SqlParameter("@divid", SqlDbType.TinyInt, 1),
                                     new SqlParameter("@cBRS", SqlDbType.SmallDateTime),
                                      new SqlParameter("@ledgerid", SqlDbType.Int)
                                     };
            objp[0].Value = bankname;
            objp[1].Value = bid;
            objp[2].Value = divid;
            objp[3].Value = cBRS;
            objp[4].Value = ledgerid;
            return ExecuteTable("SPinsconfirmBRS", objp);
        }

        public DataTable CheckBRSDate(string bankname, DateTime clearedon)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                     new SqlParameter("@bankname", SqlDbType.VarChar, 50),
                                     new SqlParameter("@clearedon", SqlDbType.SmallDateTime)
                                     };
            objp[0].Value = bankname;
            objp[1].Value = clearedon;

            return ExecuteTable("CheckCleareanceDate", objp);

        }

        public DataTable ChkBRSDet()
        {
            return ExecuteTable("CheckBRS");
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

        // Vino New for OPBal Breakup St [09-04-2024]
        public void InsLedgerDetailsNew(int ledgerid, int divisionid, int branchid, char pbtype, char opbtype, double pbamt, double opbamt, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@pbtype", SqlDbType.Char, 1),
                                                        new SqlParameter("@opbtype", SqlDbType.Char, 1),
                                                         new SqlParameter("@pbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@opbamt", SqlDbType.Money, 8),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                        };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            objp[3].Value = pbtype;
            objp[4].Value = opbtype;
            objp[5].Value = pbamt;
            objp[6].Value = opbamt;
            objp[7].Value = dbname;

            ExecuteQuery("SPInsFALedgerDetailsNew", objp);
        }

        public int GetVouNo4OPBal(string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.VarChar, 100) };

            objp[0].Value = voutype;
            return int.Parse(ExecuteReader("SPGetVouNo4OPBal", objp));
        }


        // Vino New for OPBal Breakup End [09-04-2024]


    }







}
