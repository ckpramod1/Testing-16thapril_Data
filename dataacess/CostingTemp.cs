using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CostingTemp : DBObject
    {
        DataAccess.CostingDetails costtemp = new CostingDetails();
        protected double dbinvoice, dblDn, dblosdn, dblPA, dblCn, dbloscn;
        protected DataTable dttemp1, dttemp2, dttemp3, dt;
        protected double totincome, totexpense;
        protected int i, intjobno;

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CostingTemp()
        {
            Conn = new SqlConnection(DBCS);
        }


        public double GetAllIncAmount(int intjobno, string trantype, int branchid, int intvouyear)
        {
            dbinvoice = InvoiceDetails(intjobno, trantype, branchid, intvouyear);
            dblDn = DNDetails(intjobno, trantype, branchid, intvouyear);
            dblosdn = OSDNDetails(intjobno, trantype, branchid, intvouyear);
            totincome = dbinvoice + dblDn + dblosdn;
            return totincome;
        }

        public double GetAllExpAmount(int intjobno, string trantype, int branchid, int intvouyear)
        {
            dblPA = PADetails(intjobno, trantype, branchid, intvouyear);
            dblCn = CNDetails(intjobno, trantype, branchid, intvouyear);
            dbloscn = OSCNDetails(intjobno, trantype, branchid, intvouyear);
            totexpense = dblPA + dblCn + dbloscn;
            return totexpense;
        }


        public void InsertFIFCTemp(int empid, int branch, int chargeid, int jobno, string trantype, string blno, int invno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                                new SqlParameter("@branch",SqlDbType.Int),
                                                                new SqlParameter("@chargeid",SqlDbType.Int),
                                                                 new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                 new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                 new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                                 new SqlParameter("@invno",SqlDbType.Int,4),
                                                                 new SqlParameter("@vouyear",SqlDbType.Int)};

            objp[0].Value = empid;
            objp[1].Value = branch;
            objp[2].Value = chargeid;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = blno;
            objp[6].Value = invno;
            objp[7].Value = vouyear;
            ExecuteQuery("SPFIFCTemp", objp);

        }
        public void DelFIFCTemp(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };

            objp[0].Value = empid;
            ExecuteQuery("SPFIFCTempDel", objp);

        }


        public void InsertOP(int jobno, string trantype, int branchid, double income, double expense, int empid,DateTime jobdate,DateTime jobclosedate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int),
                                                         new SqlParameter("@income",SqlDbType.Money,4),
                                                         new SqlParameter("@expense",SqlDbType.Money,4),
                                                         new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter ("@jobdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@jobclosedate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = income;
            objp[4].Value = expense;
            objp[5].Value = empid;
            objp[6].Value = jobdate;
            objp[7].Value = jobclosedate;
            ExecuteQuery("SPITempInsOProfit", objp);

        }
        public double InvoiceDetails(int jobno, string trantype, int branchid, int vouyear)
        {
            
            Cmd = new SqlCommand("SPCostingInv", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "Invoice");
            dbinvoice = TotalAmount(Ds.Tables["Invoice"]);
            return dbinvoice;
        }
        public double DNDetails(int jobno, string trantype, int branchid, int vouyear)
        {
            
            Cmd = new SqlCommand("SPCostingDN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "DN");
            dblDn = TotalAmount(Ds.Tables["DN"]);
            return dblDn;
        }

        public double CNDetails(int jobno, string trantype, int branchid, int vouyear)
        {
            
            Cmd = new SqlCommand("SPCostingCN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "CN");
            dblCn = TotalAmount(Ds.Tables["CN"]);
            return dblCn;
        }

        public double PADetails(int jobno, string trantype, int branchid, int vouyear)
        {
            
            Cmd = new SqlCommand("SPCostingPA", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "PA");
            dblPA = TotalAmount(Ds.Tables["PA"]);
            return dblPA;



        }

        public double OSDNDetails(int jobno, string trantype, int branchid, int vouyear)
        {
            
            Cmd = new SqlCommand("SPCostingOSDN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            

            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "OSDN");
            dblosdn = TotalAmount(Ds.Tables["OSDN"]);
            return dblosdn;
        }

        public double OSCNDetails(int jobno, string trantype, int branchid, int vouyear)
        {
            
            Cmd = new SqlCommand("SPCostingOSCN", Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@jobno", SqlDbType.Int));
            Cmd.Parameters["@jobno"].Value = jobno;
            Cmd.Parameters.Add(new SqlParameter("@trantype", SqlDbType.VarChar, 2));
            Cmd.Parameters["@trantype"].Value = trantype;
            Cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int));
            Cmd.Parameters["@branchid"].Value = branchid;
            Cmd.Parameters.Add(new SqlParameter("@vouyear", SqlDbType.Int));
            Cmd.Parameters["@vouyear"].Value = vouyear;
            
            
            Adp = new SqlDataAdapter(Cmd);
            Ds = new DataSet();
            Adp.Fill(Ds, "OSCN");
            dbloscn = TotalAmount(Ds.Tables["OSCN"]);
            return dbloscn;
        }

        public double TotalAmount(DataTable dt1)
        {
            double amt = 0;
            if (dt1.TableName == "Invoice" || dt1.TableName == "PA" || dt1.TableName == "DN" || dt1.TableName == "CN")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i].ItemArray[3].ToString() != "")
                    {
                        amt += double.Parse(dt1.Rows[i].ItemArray[3].ToString());
                    }
                }
            }
            else if (dt1.TableName == "OSCN" || dt1.TableName == "OSDN")
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i].ItemArray[2].ToString() != "")
                    {
                        amt += double.Parse(dt1.Rows[i]["amount"].ToString());
                    }
                }
            }
            return amt;
        }

        public void DeleteOperatingprofit(int branchid, string trantype, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2) ,
                                                       new SqlParameter("@empid", SqlDbType.Int)};

            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = empid;
            ExecuteQuery("SPDelTOperatProfit", objp);
        }

        //BL Costing--------------------------------------------------------------------------------------------



        public DataTable GetAllJobs(DateTime fromdate, DateTime todate, string trantype, int intBranchID)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = trantype;
            objp[3].Value = intBranchID;// DataAccess."FA" + intBranchID;
            return ExecuteTable("SPGetAllClosedJobs", objp);
        }

        public DataTable GetClosedJobDts(int jobno, string trantype, int intBranchID)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;// DataAccess."FA" + intBranchID;
            return ExecuteTable("SPGetClosedJobDts", objp);
        }


        public DataTable GetDNCN4MIS(DateTime fromdate, DateTime todate, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetDNCNForMIS", objp);
        }

        public DataTable GetDNCN4MISFromJobNo(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPGetDNCNForMISFromJobno", objp);
        }

        public double GetcostInv(string blno, string trantype, int branch)
        {
            double invincome = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            return invincome = double.Parse(ExecuteReader("SPCostInvTemp", objp));
        }

        public double GetcostInvBOS(string blno, string trantype, int branch)
        {
            double invincome = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            return invincome = double.Parse(ExecuteReader("SPCostInvTempBOS", objp));
        }


        public double GetcostInvBT(string blno, string trantype, int branch,int customerid)
        {
            double invincome = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4)  };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            objp[3].Value = customerid;
            return invincome = double.Parse(ExecuteReader("SPCostInvTempBT", objp));
        }

        public double GetcostPABT(string blno, string trantype, int branch, int customerid)
        {
            double PAexpns = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            objp[3].Value = customerid;
            return PAexpns = double.Parse(ExecuteReader("SPCostPATempBT", objp));
        }  

        public double GetcostPA(string blno, string trantype, int branch)
        {
            double PAexpns = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            return PAexpns = double.Parse(ExecuteReader("SPCostPATemp", objp));
        }        

        public double GetCreditDebit(string blno, string trantype, int branch, string mode)
        {
            double CADA = 0, sum = 0;//, CADA1 = 0
            CADA = GetCADA(blno, trantype, branch, mode);
            //CADA1 = GetCADA1(blno, trantype, branch, mode);
            return sum = CADA; //+ CADA1;
        }

        public double GetCADA(string blno, string trantype, int branch, string mode)
        {
            double CADA = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 10) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            objp[3].Value = mode;
            return CADA = double.Parse(ExecuteReader("SPGetDebitCreditTemp", objp));
        }

        public double GetCADA1(string blno, string trantype, int branch, string mode)
        {
            double CADA1 = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 10) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            objp[3].Value = mode;
            return CADA1 = double.Parse(ExecuteReader("SPGetDebitCreditTemp1", objp));
        }

        public DataTable GetBLRow(int jobno, string trantype,int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = intBranch;
            return ExecuteTable("SPGetBLRow", objp);
        }

        public DataTable GetBLRowBL(string BLno, string trantype, int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = BLno;
            objp[1].Value = trantype;
            objp[2].Value = intBranch;
            return ExecuteTable("SPGetBLRowBL", objp);
        }

        public DataTable GetCBMTues(int jobno, string trantype, int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = intBranch;
            return ExecuteTable("SPGetCBMTues", objp);
        }

        public int GetSalesPerson(string blno, string trantype, int intBranch)
        {
            int sales;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = intBranch;
            return sales = int.Parse(ExecuteReader("SPGetSalesPerson", objp));
        }
  

        public void DelCostingTemp(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            ExecuteQuery("SPDelCostingTemp", objp);
        }
        public void DelCostingTemp4Sales(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            ExecuteQuery("SPDelCostingTemp4sales", objp);
        }

        public void DelCostingTempCharges(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            ExecuteQuery("SPDelCostingChargeTemp", objp);
        }
        //***End of BL Costing***--------------------------------------------------------------------------------------------

        // for CostingWithCharges

        public DataTable GetInvoiceCharges(int branchid, int jobno, string trantype, int vouyear, int ftype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@jobno",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@vouyear",SqlDbType.Int),
                                                new SqlParameter("@ftype",SqlDbType.TinyInt,1)};

            objp[0].Value = branchid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = vouyear;
            objp[4].Value = ftype;
            return ExecuteTable("SPTempSelIChargesLV", objp);
        }

        public DataTable InsJobChargesTemp(int branchid, int jobno, string trantype, int ftype, int empid, double income, double expenses, int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int,4),
                                                new SqlParameter("@empid",SqlDbType.Int),
                                                new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@chargeid",SqlDbType.Int),
                                                new SqlParameter("@income",SqlDbType.Money,8),
                                                new SqlParameter("@expenses",SqlDbType.Money,8),
                                                new SqlParameter("@ftype",SqlDbType.Money,8)};

            objp[0].Value = jobno;
            objp[1].Value = empid;
            objp[2].Value = branchid;
            objp[3].Value = chargeid;
            objp[4].Value = income;
            objp[5].Value = expenses;
            objp[6].Value = ftype;
            return ExecuteTable("SPInsJobChargeTemp", objp);
        }

        public DataTable GetDACharges(int branchid, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@jobno",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2)};

            objp[0].Value = branchid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            return ExecuteTable("SPTempSelDACharges", objp);
        }
        public DataTable GetDNCharges(int branchid, int jobno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@jobno",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2)};

            objp[0].Value = branchid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            return ExecuteTable("SPTempSelDNCharges", objp);
        }

        public void InsSTChargewise(int branchid, int vouyear, int empid, DateTime from, DateTime to, string ftype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) ,
                                                       new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@from", SqlDbType.SmallDateTime, 4) ,
                                                       new SqlParameter("@to", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@ftype", SqlDbType.VarChar, 3)};

            objp[0].Value = branchid;
            objp[1].Value = vouyear;
            objp[2].Value = empid;
            objp[3].Value = from;
            objp[4].Value = to;
            objp[5].Value = ftype;
            ExecuteQuery("SPSTChargeWiseIE", objp);
        }
        //For mail to mgt
        public DataTable GetAllClosedJobs(DateTime fromdate, DateTime todate, string trantype, int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = trantype;
            objp[3].Value = intBranch;
            return ExecuteTable("SPGetAllClosedJobs", objp);
        }

        public DataTable GetAllUnClosedJobs(string trantype, int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranch;
            return ExecuteTable("SPGetAllUnClosedJobs", objp);
        }
        
        public void DeleteOperatingprofitMgt()
        {
            ExecuteQuery("SPDelTOperatProfitMgt");
        }
        //For mail to mgt

        public void DeleteOperatingprofit1(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4) };

            objp[0].Value = empid;
            ExecuteQuery("SPDelOperatProfit1", objp);
        }
        public DataTable SelExcelOperatingProfit(int branchid, string trantype, DateTime fromdate, DateTime todate,int division)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@division",SqlDbType.TinyInt,1)};

            objp[0].Value = fromdate;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = todate;
            objp[4].Value = division;
            return ExecuteTable("SPSelExcelOperatingProfit", objp);
        }
        public DataTable SelExcelJobWise(int branchid, string trantype,DateTime fromdate,DateTime todate,int division)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@division",SqlDbType.TinyInt,1)};

            objp[0].Value = fromdate;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = todate;
            objp[4].Value = division;
            return ExecuteTable("SPSelExcelJobWise", objp);
        }

        public DataTable SelExcelShipment(int branchid, int empid, string trantype, string reportname, string reportid, string sector)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@report",SqlDbType.VarChar,15),
                                                new SqlParameter("@reportid",SqlDbType.VarChar,6),
                                                new SqlParameter("@sector",SqlDbType.VarChar,1)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = reportname;
            objp[4].Value = reportid;
            objp[5].Value = sector;
            return ExecuteTable("SPSelExcelShipmentDt", objp);
        }

        public DataTable SelExcelShipmentFCostingDts(int branchid, string trantype, string reportname, string reportid,DateTime fromdate,DateTime todate,int division)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@reportid",SqlDbType.VarChar,6),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@division",SqlDbType.TinyInt,1)};

            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = reportid;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            objp[5].Value = division;

            return ExecuteTable("SPSelExcelShipmentDtsFBranch"+reportname, objp);
        }
        public void InsChargeWSTInc(DateTime fromdt, DateTime todt, int branchid, int chargeid, int userid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@todt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@chargeid", SqlDbType.Int),
                                                      new SqlParameter("@userid", SqlDbType.Int) };
            objp[0].Value = fromdt;
            objp[1].Value = todt;
            objp[2].Value = branchid;
            objp[3].Value = chargeid;
            objp[4].Value = userid;
            ExecuteQuery("SPTempChargesWSTInc", objp);
        }

        public void InsChargeWSTExp(DateTime fromdt, DateTime todt, int branchid, int chargeid, int userid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@todt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@chargeid", SqlDbType.Int),
                                                      new SqlParameter("@userid", SqlDbType.Int) };
            objp[0].Value = fromdt;
            objp[1].Value = todt;
            objp[2].Value = branchid;
            objp[3].Value = chargeid;
            objp[4].Value = userid;
            ExecuteQuery("SPTempChargesWSTExp", objp);
        }

        public void DelChargeWST(int userid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@userid", SqlDbType.Int) };
            objp[0].Value = userid;
            ExecuteQuery("SPDelTempChargeWST", objp);
        }
        public DataTable SelExcelVoucherReg(int branchid, string ftype, DateTime from, DateTime to, string reporttype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                new SqlParameter("@type",SqlDbType.VarChar,20),
                                                new SqlParameter("@from",SqlDbType.SmallDateTime,8),
                                                new SqlParameter("@to",SqlDbType.SmallDateTime,8),
                                                new SqlParameter("@Rtype",SqlDbType.VarChar,1)};

            objp[0].Value = branchid;
            objp[1].Value = ftype;
            objp[2].Value = from;
            objp[3].Value = to;
            objp[4].Value = reporttype;
            return ExecuteTable("SPSelExcelVouchersReg", objp);
        }
        public DataTable SelExcelVoucherCharSt(int branchid, int empid, string ST)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                new SqlParameter("@empid",SqlDbType.Int),
                                                new SqlParameter("@st",SqlDbType.VarChar,1)};

            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = ST;
            return ExecuteTable("SPSelExcelVouchersST", objp);
        }
        public DataTable SelExcelVoucherRegSt(int branchid, int empid, string ftype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                new SqlParameter("@empid",SqlDbType.Int),
                                                new SqlParameter("@type",SqlDbType.VarChar,1)};

            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = ftype;
            return ExecuteTable("SPSelExcelVouchersRegST", objp);
        }
        public DataTable SelGrdNVF(int empid, int branchid, string ttype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),   
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = ttype;
            return ExecuteTable("SPSelGrdNVF", objp);
        }
        public DataTable SelLedgerAccount(int empid, int branchid, int customerid, DateTime fromdate, DateTime todate)
        {
            double totdr = 0;
            double totcr = 0;
            double debit = 0;
            double credit = 0;
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),   
                                                        new SqlParameter("@customerid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,8),   
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,8)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = customerid;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            dt = ExecuteTable("SPLedgerAccount", objp);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[3].ToString() != "")
                {
                    totdr = totdr + double.Parse(dt.Rows[i].ItemArray[3].ToString());

                    if (dt.Rows[i].ItemArray[4].ToString() != "")
                    {
                        totcr = totcr + double.Parse(dt.Rows[i].ItemArray[4].ToString());
                    }
                }
                //return ExecuteTable("SPLedgerAccount", objp);
            }
            Dr = dt.NewRow();
            Dr[0] = "";
            Dr[1] = "";
            Dr[2] = "";
            Dr[3] = totdr.ToString("#,##0.00");
            Dr[4] = totcr.ToString("#,##0.00");
            dt.Rows.Add(Dr);
            Dr = dt.NewRow();
            Dr[0] = "";
            Dr[1] = "";
            Dr[2] = "Closing Balance";
            if (totdr > totcr)
            {
                Dr[3] = "";
            }
            else
            {
                Dr[3] = (totcr - totdr).ToString("#,##0.00");
            }
            if (totcr > totdr)
            {
                Dr[4] = "";
            }
            else
            {
                Dr[4] = (totdr - totcr).ToString("#,##0.00");
            }
            dt.Rows.Add(Dr);

            if (totdr > totcr)
            {
                debit = totdr;
            }
            else
            {
                debit = totdr + (totcr - totdr);
            }
            if (totcr > totdr)
            {
                credit = totcr;
            }
            else
            {
                credit = totcr + (totdr - totcr);
            }
            Dr = dt.NewRow();
            Dr[0] = "";
            Dr[1] = "";
            Dr[2] = "";
            Dr[3] = debit.ToString("#,##0.00");
            Dr[4] = credit.ToString("#,##0.00");
            dt.Rows.Add(Dr);
            return dt;
        }

        public DataTable SelFromCostDtls(int empid, int branchid, string ttype, DateTime frmmonth, DateTime tomonth,int salesid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),   
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@frmmonth",SqlDbType.DateTime,8),
                                                        new SqlParameter("@tomonth",SqlDbType.DateTime,8),
                                                        new SqlParameter("@salesid",SqlDbType.Int)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = ttype;
            objp[3].Value = frmmonth;
            objp[4].Value = tomonth;
            objp[5].Value = salesid;
            return ExecuteTable("SPSelCostTempDtls", objp);
        }

        public DataTable SelSalesFromCostDtls(int empid, int branchid, string ttype, DateTime frmmonth, DateTime tomonth)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),   
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@frmmonth",SqlDbType.DateTime,8),
                                                        new SqlParameter("@tomonth",SqlDbType.DateTime,8)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = ttype;
            objp[3].Value = frmmonth;
            objp[4].Value = tomonth;
            return ExecuteTable("SPSelSalesCtTemp", objp);
        }

        public string GetRetentionforTrend(int shipper,int salesid ,int branchid, int empid, string trantype, int dtmonth,int dtyear,string nominamtion)
        {
            //double retention = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@dtmonth", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid", SqlDbType.Int,4),
                                                       new SqlParameter("@dtyear", SqlDbType.Int,4),
                                                       new SqlParameter("@nomination", SqlDbType.VarChar,20) };
            objp[0].Value = shipper;
            objp[1].Value = branchid;
            objp[2].Value = empid;
            objp[3].Value = trantype;
            objp[4].Value = dtmonth;
            objp[5].Value = salesid;
            objp[6].Value = dtyear;
            objp[7].Value = nominamtion;
           // return ExecuteReader("SPGetRetenfromCost", objp);

            return ExecuteReader("SPGetRetenfromCostnew", objp);
        }

        

        public string GetCBMforTrend(int shipper, int salesid, int branchid, int empid, string trantype, int dtmonth,int dtyear)
        {
            //double retention = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@dtmonth", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid", SqlDbType.Int,4),
                                                       new SqlParameter("@dtyear", SqlDbType.Int,4) };
            objp[0].Value = shipper;
            objp[1].Value = branchid;
            objp[2].Value = empid;
            objp[3].Value = trantype;
            objp[4].Value = dtmonth;
            objp[5].Value = salesid;
            objp[6].Value = dtyear;
            return ExecuteReader("SPGetCBMfromCost", objp);
        }

        public string GetTuesforTrend(int shipper, int salesid, int branchid, int empid, string trantype, int dtmonth,int dtyear)
        {
            //double retention = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@dtmonth", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid", SqlDbType.Int,4),
                                                       new SqlParameter("@dtyear", SqlDbType.Int,4) };
            objp[0].Value = shipper;
            objp[1].Value = branchid;
            objp[2].Value = empid;
            objp[3].Value = trantype;
            objp[4].Value = dtmonth;
            objp[5].Value = salesid;
            objp[6].Value = dtyear;
            return ExecuteReader("SPGetTuesfromCost", objp);
        }

        public string GetRetentionforSales(int salid, int branchid, int empid, string trantype, int dtmonth,int dtyear)
        {
            //double retention = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@salid", SqlDbType.Int),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@dtmonth", SqlDbType.Int,4),
                                                       new SqlParameter("@dtyear", SqlDbType.Int,4) };
            objp[0].Value = salid;
            objp[1].Value = branchid;
            objp[2].Value = empid;
            objp[3].Value = trantype;
            objp[4].Value = dtmonth;
            objp[5].Value = dtyear;
            return ExecuteReader("SPGetRetenforSales", objp);
        }

        public DataTable SelProductFromCostDtls(int empid, int branchid, string ttype, int month,int dtyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),   
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                       new SqlParameter("@dtyear", SqlDbType.Int,4)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = ttype;
            objp[3].Value = month;
            objp[4].Value = dtyear;
            return ExecuteTable("SPSelRetenforproducts", objp);
        }
        
        public string CheckBLNoFromShipDts(string docno)
        {
            //double retention = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30) };
            objp[0].Value = docno;
            return ExecuteReader("SPCheckBLNoFromShipDts", objp);
        }
        public string CheckBLNoFromShipDetails(string docno,int division)
        {
            //double retention = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@division", SqlDbType.TinyInt, 1)};
            objp[0].Value = docno;
            objp[1].Value = division;
            return ExecuteReader("SPCheckBLNoFromShipDetails", objp);
        }
        public DataTable GetDivisionProfit(int division, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = division;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPGetDivisionProfit",objp);
        }
        public DataTable GetBranchProfit(int division, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@division",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime, 4)};

            objp[0].Value = division;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPGetBranchProfit", objp);
        }
        public DataTable GetTrantypeProfit(int branch, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime, 4) };

            objp[0].Value = branch;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPGetTrantypeProfit", objp);
        }
        public DataTable GetTrantypeJobProfit(int branch, string trantype, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime, 4)};

            objp[0].Value = branch;
            objp[1].Value = trantype;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            return ExecuteTable("SPGetTrantypeJobnoProfit", objp);
        }

        public DataTable GetJobProfit(int branch, string trantype,int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4)};

            objp[0].Value = branch;
            objp[1].Value = trantype;
            objp[2].Value = jobno;
            return ExecuteTable("SPGetJobProfit", objp);
        }

        public int GetDivision4Branch(int branch)
        {
            int sales;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branch", SqlDbType.TinyInt, 1)};
            objp[0].Value = branch;
            return sales = int.Parse(ExecuteReader("SPGetDivisionID4Branchid", objp));
        }

        public DataTable GetCustomerRetention(int empid,double retention,int division,DateTime fromdate,DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@retention", SqlDbType.Money, 8),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime, 4)};

            objp[0].Value = empid;
            objp[1].Value = retention;
            objp[2].Value = division;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            return ExecuteTable("SPGetCustomerRetention", objp);
        }
        public void InsCostingTemp(int empid, int jobno, string trantype, int branchid, string blno, double volume, int cont20, int cont40, double income, double expense, char nomination, int salesperson, int shipper, int consignee, int notify, int agent, int pol, int pod, int jobtype, DateTime closedate, int mlo)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.Int, 1),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@volume", SqlDbType.Real, 4),
                                                       new SqlParameter("@cont20", SqlDbType.Int),
                                                       new SqlParameter("@cont40", SqlDbType.Int),
                                                       new SqlParameter("@income", SqlDbType.Money, 4),
                                                       new SqlParameter("@expense", SqlDbType.Money, 4),
                                                       new SqlParameter("@nomination", SqlDbType.Char, 1),
                                                       new SqlParameter("@salesperson", SqlDbType.Int),
                                                       new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@consignee", SqlDbType.Int,4),
                                                       new SqlParameter("@notify", SqlDbType.Int,4),
                                                       new SqlParameter("@agent", SqlDbType.Int,4),
                                                       new SqlParameter("@pol", SqlDbType.Int),
                                                       new SqlParameter("@pod", SqlDbType.Int),
                                                       new SqlParameter("@jobtype", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@closedate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@mlo",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            objp[4].Value = blno;
            objp[5].Value = volume;
            objp[6].Value = cont20;
            objp[7].Value = cont40;
            objp[8].Value = income;
            objp[9].Value = expense;
            objp[10].Value = nomination;
            objp[11].Value = salesperson;
            objp[12].Value = shipper;
            objp[13].Value = consignee;
            objp[14].Value = notify;
            objp[15].Value = agent;
            objp[16].Value = pol;
            objp[17].Value = pod;
            objp[18].Value = jobtype;
            objp[19].Value = closedate;
            objp[20].Value = mlo;
            ExecuteQuery("SPInsCostingTemp", objp);
        }

        public void InsCostingTempRpt(int empid, int jobno, string trantype, int branchid, string blno, double volume, int cont20, int cont40, double income, double expense, char nomination, int salesperson, int shipper, int consignee, int notify, int agent, int pol, int pod, int jobtype, DateTime closedate, int mlo, int vouno, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@volume", SqlDbType.Real, 4),
                                                       new SqlParameter("@cont20", SqlDbType.Int),
                                                       new SqlParameter("@cont40", SqlDbType.Int),
                                                       new SqlParameter("@income", SqlDbType.Money, 4),
                                                       new SqlParameter("@expense", SqlDbType.Money, 4),
                                                       new SqlParameter("@nomination", SqlDbType.Char, 1),
                                                       new SqlParameter("@salesperson", SqlDbType.Int),
                                                       new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@consignee", SqlDbType.Int,4),
                                                       new SqlParameter("@notify", SqlDbType.Int,4),
                                                       new SqlParameter("@agent", SqlDbType.Int,4),
                                                       new SqlParameter("@pol", SqlDbType.Int),
                                                       new SqlParameter("@pod", SqlDbType.Int),
                                                       new SqlParameter("@jobtype", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@closedate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@mlo",SqlDbType.Int,4),
                                                        new SqlParameter("@vouno",SqlDbType.Int,4),
                                                        new SqlParameter("@voutype",SqlDbType.Char,1)};
            objp[0].Value = empid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            objp[4].Value = blno;
            objp[5].Value = volume;
            objp[6].Value = cont20;
            objp[7].Value = cont40;
            objp[8].Value = income;
            objp[9].Value = expense;
            objp[10].Value = nomination;
            objp[11].Value = salesperson;
            objp[12].Value = shipper;
            objp[13].Value = consignee;
            objp[14].Value = notify;
            objp[15].Value = agent;
            objp[16].Value = pol;
            objp[17].Value = pod;
            objp[18].Value = jobtype;
            objp[19].Value = closedate;
            objp[20].Value = mlo;
            objp[21].Value = vouno;
            objp[22].Value = voutype;
            ExecuteQuery("SPInsCostingTempRpt", objp);
        }

        public void InsCostingTempRptnew(int empid, int jobno, string trantype, int branchid, string blno, double volume, int cont20, int cont40, double income, double expense, char nomination, int salesperson, int shipper, int consignee, int notify, int agent, int pol, int pod, int jobtype, DateTime closedate, int mlo, int vouno, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@volume", SqlDbType.Real, 4),
                                                       new SqlParameter("@cont20", SqlDbType.Int),
                                                       new SqlParameter("@cont40", SqlDbType.Int),
                                                       new SqlParameter("@income", SqlDbType.Money, 4),
                                                       new SqlParameter("@expense", SqlDbType.Money, 4),
                                                       new SqlParameter("@nomination", SqlDbType.Char, 1),
                                                       new SqlParameter("@salesperson", SqlDbType.Int),
                                                       new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@consignee", SqlDbType.Int,4),
                                                       new SqlParameter("@notify", SqlDbType.Int,4),
                                                       new SqlParameter("@agent", SqlDbType.Int,4),
                                                       new SqlParameter("@pol", SqlDbType.Int),
                                                       new SqlParameter("@pod", SqlDbType.Int),
                                                       new SqlParameter("@jobtype", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@closedate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@mlo",SqlDbType.Int,4),
                                                        new SqlParameter("@vouno",SqlDbType.Int,4),
                                                        new SqlParameter("@voutype",SqlDbType.Char,1)};
            objp[0].Value = empid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            objp[4].Value = blno;
            objp[5].Value = volume;
            objp[6].Value = cont20;
            objp[7].Value = cont40;
            objp[8].Value = income;
            objp[9].Value = expense;
            objp[10].Value = nomination;
            objp[11].Value = salesperson;
            objp[12].Value = shipper;
            objp[13].Value = consignee;
            objp[14].Value = notify;
            objp[15].Value = agent;
            objp[16].Value = pol;
            objp[17].Value = pod;
            objp[18].Value = jobtype;
            objp[19].Value = closedate;
            objp[20].Value = mlo;
            objp[21].Value = vouno;
            objp[22].Value = voutype;
            ExecuteQuery("SPInsCostingTempRptnew", objp);
        }





        public void InsCostingTempRptreclose(int empid, int jobno, string trantype, int branchid, string blno, double volume, int cont20, int cont40, double income, double expense, char nomination, int salesperson, int shipper, int consignee, int notify, int agent, int pol, int pod, int jobtype, DateTime closedate, int mlo, int vouno, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@volume", SqlDbType.Real, 4),
                                                       new SqlParameter("@cont20", SqlDbType.Int),
                                                       new SqlParameter("@cont40", SqlDbType.Int),
                                                       new SqlParameter("@income", SqlDbType.Money, 4),
                                                       new SqlParameter("@expense", SqlDbType.Money, 4),
                                                       new SqlParameter("@nomination", SqlDbType.Char, 1),
                                                       new SqlParameter("@salesperson", SqlDbType.Int),
                                                       new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@consignee", SqlDbType.Int,4),
                                                       new SqlParameter("@notify", SqlDbType.Int,4),
                                                       new SqlParameter("@agent", SqlDbType.Int,4),
                                                       new SqlParameter("@pol", SqlDbType.Int),
                                                       new SqlParameter("@pod", SqlDbType.Int),
                                                       new SqlParameter("@jobtype", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@closedate",SqlDbType.DateTime,8),
                                                        new SqlParameter("@mlo",SqlDbType.Int,4),
                                                        new SqlParameter("@vouno",SqlDbType.Int,4),
                                                        new SqlParameter("@voutype",SqlDbType.Char,1)};
            objp[0].Value = empid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            objp[4].Value = blno;
            objp[5].Value = volume;
            objp[6].Value = cont20;
            objp[7].Value = cont40;
            objp[8].Value = income;
            objp[9].Value = expense;
            objp[10].Value = nomination;
            objp[11].Value = salesperson;
            objp[12].Value = shipper;
            objp[13].Value = consignee;
            objp[14].Value = notify;
            objp[15].Value = agent;
            objp[16].Value = pol;
            objp[17].Value = pod;
            objp[18].Value = jobtype;
            objp[19].Value = closedate;
            objp[20].Value = mlo;
            objp[21].Value = vouno;
            objp[22].Value = voutype;
            ExecuteQuery("SPInsCostingTempRptreclose", objp);
        }


        //public void InsCostingTempRpt(int empid, int jobno, string trantype, int branchid, string blno, double volume, int cont20, int cont40, double income, double expense, char nomination, int salesperson, int shipper, int consignee, int notify, int agent, int pol, int pod, int jobtype, DateTime closedate, int mlo)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
        //                                               new SqlParameter("@jobno", SqlDbType.Int),
        //                                               new SqlParameter("@trantype", SqlDbType.VarChar, 2),
        //                                               new SqlParameter("@branch", SqlDbType.TinyInt, 1),
        //                                               new SqlParameter("@blno", SqlDbType.VarChar, 30),
        //                                               new SqlParameter("@volume", SqlDbType.Real, 4),
        //                                               new SqlParameter("@cont20", SqlDbType.Int),
        //                                               new SqlParameter("@cont40", SqlDbType.Int),
        //                                               new SqlParameter("@income", SqlDbType.Money, 4),
        //                                               new SqlParameter("@expense", SqlDbType.Money, 4),
        //                                               new SqlParameter("@nomination", SqlDbType.Char, 1),
        //                                               new SqlParameter("@salesperson", SqlDbType.Int),
        //                                               new SqlParameter("@shipper", SqlDbType.Int,4),
        //                                               new SqlParameter("@consignee", SqlDbType.Int,4),
        //                                               new SqlParameter("@notify", SqlDbType.Int,4),
        //                                               new SqlParameter("@agent", SqlDbType.Int,4),
        //                                               new SqlParameter("@pol", SqlDbType.Int),
        //                                               new SqlParameter("@pod", SqlDbType.Int),
        //                                               new SqlParameter("@jobtype", SqlDbType.TinyInt, 1),
        //                                               new SqlParameter("@closedate",SqlDbType.DateTime,8),
        //                                                new SqlParameter("@mlo",SqlDbType.Int,4)};
        //    objp[0].Value = empid;
        //    objp[1].Value = jobno;
        //    objp[2].Value = trantype;
        //    objp[3].Value = branchid;
        //    objp[4].Value = blno;
        //    objp[5].Value = volume;
        //    objp[6].Value = cont20;
        //    objp[7].Value = cont40;
        //    objp[8].Value = income;
        //    objp[9].Value = expense;
        //    objp[10].Value = nomination;
        //    objp[11].Value = salesperson;
        //    objp[12].Value = shipper;
        //    objp[13].Value = consignee;
        //    objp[14].Value = notify;
        //    objp[15].Value = agent;
        //    objp[16].Value = pol;
        //    objp[17].Value = pod;
        //    objp[18].Value = jobtype;
        //    objp[19].Value = closedate;
        //    objp[20].Value = mlo;

        //    ExecuteQuery("SPInsCostingTempRpt", objp);
        //}

        public DataSet SelTop50ShipperConsignee(int empid, int division,DateTime fromdate,DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@division",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = empid;
            objp[1].Value = division;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            return ExecuteDataSet("SPSelTop50ShipperandConsignee", objp);
        }
        public DataSet SelTop50ShipperConsignee4Branch(int empid, int branchid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            return ExecuteDataSet("SPSelTop50ShipperandConsignee4Branch", objp);
        }
        public DataTable SelTop50ShipperConsignee4BranchTantype(int empid, int branchid, string trantype, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            return ExecuteTable("SPSelTop50ShipperandConsignee4BranchTrantype", objp);
        }
        
        public DataTable SelLossJobs(DateTime fromdate, DateTime todate,string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelLossJobs", objp);
        }
        public void InsTempInternalBillingBranch(DateTime fromdate, DateTime todate,int empid,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            ExecuteQuery("SPInsTempInternalBillingBranch", objp);
        }

        public void InsTempReversalBillingBranch(DateTime fromdate, DateTime todate, int empid, int branchid,string Type)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@Type",SqlDbType.Char,1)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            objp[4].Value = Type;
            ExecuteQuery("SPInsTempReversalBillingBranch", objp);
        }

        public void DelCostingDetailsRpt(int jobno, string trantype, string type, int branchid, int vouno, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@type",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@vouno",SqlDbType.Int,4),
                                                        new SqlParameter("@voutype",SqlDbType.VarChar,1)};

            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = type;
            objp[3].Value = branchid;
            objp[4].Value = vouno;
            objp[5].Value = voutype;
            ExecuteQuery("SPDelCostingDetailsRpt", objp);
        }
        public void InsTempInternalBillingCompany(DateTime fromdate, DateTime todate, int empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            ExecuteQuery("SPInsTempInternalBillingCompany", objp);
        }
        public DataTable SelTempInternalBillingBranch(int empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};

           objp[0].Value = empid;
           objp[1].Value = branchid;
           return ExecuteTable("SPSelExcelInternalBillingBranch", objp);
        }

        public void InsCostingTemp(DateTime fromdate, DateTime todate, int empid, int branchid,string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            objp[4].Value = trantype;
            ExecuteQuery("SPSDProcess", objp);
        }
        public DataSet SelAgentwiseVolume(DateTime fromdate, DateTime todate, string jobtype, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = jobtype;
            objp[3].Value = branchid;
            objp[4].Value = trantype;
            return ExecuteDataSet("SPSelAgentwiseVolume", objp);
        }


public DataTable GetRetentionperunitforbranch(int branch, int division, DateTime fromdate, DateTime todate,string Trantype)
        {
            SqlParameter[] objp=new SqlParameter[]{ new SqlParameter("@branchid",SqlDbType.Int,4),
                                                    new SqlParameter("@division",SqlDbType.Int,4),
                                                    new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = branch;
            objp[1].Value = division;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = Trantype;
            return ExecuteTable("SPRetentionperUnit",objp);
        }
        public DataTable SelOSLedgerAccount(int empid, int branchid, int customerid, DateTime fromdate, DateTime todate)
        {
            double totdr = 0;
            double totcr = 0;
            double debit = 0;
            double credit = 0;
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),   
                                                        new SqlParameter("@customerid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromdate",SqlDbType.SmallDateTime,8),   
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,8)};

            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = customerid;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            dt = ExecuteTable("SPOSLedgerAccount", objp);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[3].ToString() != "")
                {
                    totdr = totdr + double.Parse(dt.Rows[i].ItemArray[3].ToString());

                    if (dt.Rows[i].ItemArray[4].ToString() != "")
                    {
                        totcr = totcr + double.Parse(dt.Rows[i].ItemArray[4].ToString());
                    }
                }
                //return ExecuteTable("SPLedgerAccount", objp);
            }
            Dr = dt.NewRow();
            Dr[0] = "";
            Dr[1] = "";
            Dr[2] = "";
            Dr[3] = totdr.ToString("#,##0.00");
            Dr[4] = totcr.ToString("#,##0.00");
            dt.Rows.Add(Dr);
            Dr = dt.NewRow();
            Dr[0] = "";
            Dr[1] = "";
            Dr[2] = "Closing Balance";
            if (totdr > totcr)
            {
                Dr[3] = "";
            }
            else
            {
                Dr[3] = (totcr - totdr).ToString("#,##0.00");
            }
            if (totcr > totdr)
            {
                Dr[4] = "";
            }
            else
            {
                Dr[4] = (totdr - totcr).ToString("#,##0.00");
            }
            dt.Rows.Add(Dr);

            if (totdr > totcr)
            {
                debit = totdr;
            }
            else
            {
                debit = totdr + (totcr - totdr);
            }
            if (totcr > totdr)
            {
                credit = totcr;
            }
            else
            {
                credit = totcr + (totdr - totcr);
            }
            Dr = dt.NewRow();
            Dr[0] = "";
            Dr[1] = "";
            Dr[2] = "";
            Dr[3] = debit.ToString("#,##0.00");
            Dr[4] = credit.ToString("#,##0.00");
            dt.Rows.Add(Dr);
            return dt;
        }

        //del vouchers
        public void Delvounoinrptcosdtls(int vouno,char voutype, int branchid, string trantype,int jobno)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                         new SqlParameter("@vouno",SqlDbType.Int,4),
                                                          new SqlParameter("@voutype",SqlDbType.Char,1),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4)};

            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = jobno;
            ExecuteQuery("SPDelvounoinrptcosdtls", objp);
        }
        public DataTable Checkrowexistsforothdncn(int jobno,string blno,double  amount,char vtype,int branchid, string Trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                                                      new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@amount",SqlDbType.Money,8),
                                                       new SqlParameter("@vtype",SqlDbType.Char,1),
                                                       new SqlParameter("branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("trantype",SqlDbType.VarChar,2)

                                                        };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = amount;
            objp[3].Value = vtype;
            objp[4].Value = branchid;
            objp[5].Value = Trantype;
            return ExecuteTable("SPCheckrowexistsforothdncn", objp);
        }
        public DataTable GetDNCN4MISFromVouno(int jobno, int branchid, string trantype, int vouno, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      
                                                       new SqlParameter("@vouno", SqlDbType.Int,4),
                                                       new SqlParameter("@voutype",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
          
            objp[3].Value = vouno;
            objp[4].Value = voutype;
            return ExecuteTable("SPGetDNCNForMISFromVouno", objp);
        }
          
        public DataTable GetBLfromDatel(DateTime fromdate, DateTime todate, int custid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@todate", SqlDbType.DateTime,8),
                                                       new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.Int,4)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = custid;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetBLafterJobclosel", objp);
        }
        //Chart 

        public DataTable SelOperatingProfit4chart(int branchid, string trantype, DateTime fromdate, DateTime todate, int division)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@division",SqlDbType.TinyInt,1)};

            objp[0].Value = fromdate;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = todate;
            objp[4].Value = division;
            return ExecuteTable("SPSelOperatingProfit4chart", objp);
        }
        public DataSet SelAgentwiseVolumeCor(DateTime fromdate, DateTime todate, string jobtype, int divisionid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                        new SqlParameter("@divisionid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = jobtype;
            objp[3].Value = divisionid;
            objp[4].Value = trantype;
            return ExecuteDataSet("SPSelAgentwiseVolumeCO", objp);
        }
        //blcount
        public DataSet SPSelCostTempDtls4blcount(int branchid, string ttype, DateTime frmmonth, DateTime tomonth, char type)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),   
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@frmmonth",SqlDbType.DateTime,8),
                                                        new SqlParameter("@tomonth",SqlDbType.DateTime,8),
                                                        new SqlParameter("@type",SqlDbType.Char,1),
                                                       };


            objp[0].Value = branchid;
            objp[1].Value = ttype;
            objp[2].Value = frmmonth;
            objp[3].Value = tomonth;
            objp[4].Value = type;
            return ExecuteDataSet("SPSelCostTempDtls4blcount", objp);
        }
        public DataTable GetRevenueRpt(int bid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = bid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPExcelRevenueRpt", objp);
        }
        public DataTable GetCanRegister4AuditAI(int bid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = bid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPCANRegister4AuditAI", objp);

        }
        public DataTable GetCanRegister4Audit(int bid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = bid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPCANRegister4Audit", objp);

        }
        public DataTable GetDoRegister4Audit(int bid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.Int),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4)};

            objp[0].Value = bid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPDORegister4Audit", objp);

        }

        public DataTable GetIncentivedtls(DateTime fromdate, DateTime todate, int cid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = cid;
            objp[3].Value = salesid;
            return ExecuteTable("SPRptSalesIncentives", objp);
        }

        //CostingTemp
        //Manoj
        public void DelChargeWSTNewManoj(int userid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@userid", SqlDbType.Int) };
            objp[0].Value = userid;
            ExecuteQuery("SPDelTempChargeWSTNewManoj", objp);
        }

        public void InsChargeWSTIncNewManoj(DateTime fromdt, DateTime todt, int branchid, int chargeid, int userid, string divtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@todt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@chargeid", SqlDbType.Int),
                                                      new SqlParameter("@userid", SqlDbType.Int),
                                                      new SqlParameter("@divtype",SqlDbType.Char,1)};
            objp[0].Value = fromdt;
            objp[1].Value = todt;
            objp[2].Value = branchid;
            objp[3].Value = chargeid;
            objp[4].Value = userid;
            objp[5].Value = divtype;
            ExecuteQuery("SPTempChargesWSTIncNewManoj", objp);
        }

        public void InsChargeWSTExpNewManoj(DateTime fromdt, DateTime todt, int branchid, int chargeid, int userid, string divtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@todt", SqlDbType.SmallDateTime, 4),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@chargeid", SqlDbType.Int),
                                                      new SqlParameter("@userid", SqlDbType.Int),
                                                      new SqlParameter("@divtype",SqlDbType.Char,1)};
            objp[0].Value = fromdt;
            objp[1].Value = todt;
            objp[2].Value = branchid;
            objp[3].Value = chargeid;
            objp[4].Value = userid;
            objp[5].Value = divtype;
            ExecuteQuery("SPTempChargesWSTExpNewManoj", objp);
        }
        //RajaGuru
        public DataTable GetIncentivedtables(DateTime fromdate, DateTime todate, int cid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = cid;
            objp[3].Value = salesid;
            return ExecuteTable("SPRptSalesIncentivesNew", objp);
        }


        //Arun

        public void DelCostingDetailsRpt4JobBLwise(int jobno, string trantype, string type, int branchid, int vouno, string voutype, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@type",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@vouno",SqlDbType.Int,4),
                                                        new SqlParameter("@voutype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@empid", SqlDbType.Int),};

            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = type;
            objp[3].Value = branchid;
            objp[4].Value = vouno;
            objp[5].Value = voutype;
            objp[6].Value = empid;
            ExecuteQuery("SPDelCostingDetailsRpt4JobBLwise", objp);
        }

        public DataTable GetClosedJobDts4JobBLwise(int jobno, string trantype, int intBranchID)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;// DataAccess."FA" + intBranchID;
            return ExecuteTable("SPGetClosedJobDts4JobBLwise", objp);
        }

        public void InsCostingTempRpt4JobBLwise(int empid, int jobno, string trantype, int branchid, string blno, double income, double expense)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@income", SqlDbType.Money, 4),
                                                       new SqlParameter("@expense", SqlDbType.Money, 4),
                                                    };
            objp[0].Value = empid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = branchid;
            objp[4].Value = blno;
            objp[5].Value = income;
            objp[6].Value = expense;
            ExecuteQuery("SPInsCostingTempRpt4JobBLwise", objp);
        }

        public DataTable GetDNCN4MISFromJobNo4JobBLwise(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPGetDNCNForMISFromJobno4JobBLwise", objp);
        }

        //Elakkiya
        public DataTable SelExcelShipmentFCostingDtsLiner(int branchid, string trantype, string reportname, string reportid, DateTime fromdate, DateTime todate, int division, int liner)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@reportid",SqlDbType.VarChar,6),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@division",SqlDbType.TinyInt,1),
             new SqlParameter("@liner",SqlDbType.Int ,4 )};

            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = reportid;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            objp[5].Value = division;
            objp[5].Value = liner;

            return ExecuteTable("SPSelExcelShipmentDtsFBranchliner", objp);
        }

        //MUthuRaj
        public DataTable SelExcelShipmentFCostingDtsLinerTemp(int branchid, string trantype, DateTime fromdate, DateTime todate, string reportid, int division)
        {
            SqlParameter[] objp = new SqlParameter[]
                                               {new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                               
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@reportid",SqlDbType.VarChar,6),
                                                new SqlParameter("@division",SqlDbType.TinyInt,1)};


            objp[0].Value = branchid;
            objp[1].Value = trantype;

            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = reportid;
            objp[5].Value = division;


            return ExecuteTable("SPSelExcelShipmentDtsFBranchliner", objp);

        }


        //Guru

        public DataTable GetSP_CostingRPT(int job, int bid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@job",SqlDbType.Int,5),
                                                       new SqlParameter("@bid", SqlDbType.Int, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int, 4)};

            objp[0].Value = job;
            objp[1].Value = bid;
            objp[2].Value = empid;
            return ExecuteTable("SP_CostingRPT", objp);
        }


        //FA

        public DataTable GetAuditRpt(DateTime fromdate, DateTime todate, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@bid",SqlDbType.Int),
                                                new SqlParameter("@cid",SqlDbType.Int)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return ExecuteTable("Sp_GetChargewiseBreakup4Audit", objp);
        }


        //Dinesh

        public DataTable GetDNCN4MISFromVounonew(int jobno, int branchid, string trantype, int vouno, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      
                                                       new SqlParameter("@vouno", SqlDbType.Int,4),
                                                       new SqlParameter("@voutype",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            objp[3].Value = vouno;
            objp[4].Value = voutype;
            return ExecuteTable("SPGetDNCNForMISFromVounonewLV", objp);
        }

        public DataSet GetTDSSum(int empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       
                                                         new SqlParameter("@empid",SqlDbType.Int,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,4)
                                                     };
            objp[0].Value = empid;
            objp[1].Value = branchid;

            return ExecuteDataSet("SpTDSSum", objp);
        }

        //-----------Arun

        public DataTable RetriveDtlsServiceTax(int Empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@branch", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = branchid;
            return ExecuteTable("SPRetriveDtlsServiceTax", objp);
        }

        public DataTable RetiveDtlsTdsVoucherVise(int Empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@branch", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetVouWise", objp);
        }

        public DataTable RetiveDtlsTdsVoucherViseDivision(int Empid, int Divisonid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = Divisonid;
            return ExecuteTable("SPGetVouWiseAlldivisin", objp);
        }


        public DataTable RetriveTdsSummary(int Empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@branch", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = branchid;
            return ExecuteTable("SPretriveTdsSummary", objp);
        }

        public DataTable RetriveTdsAllSummary(int Empid, int div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = div;
            return ExecuteTable("SPretriveTdsAllSummary", objp);
        }

        public DataTable RetriveTdsVouchwiseAll(int Empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@branch", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = branchid;
            return ExecuteTable("SPRetriveTdsVouchwiseAll", objp);
        }

        public DataTable RetriveTdsVouchwiseAllDiv(int Empid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = cid;
            return ExecuteTable("SPRetriveTdsVouchwiseAllDiv", objp);
        }

        public DataTable GetInternalBillDtls(int Empid, int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@divid", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = divid;
            return ExecuteTable("SPGetInternalBillDtls", objp);
        }


        public DataTable GetInternalBillDtlsall(int Empid, int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int),
                                                       new SqlParameter("@divid", SqlDbType.Int)
                                                      };
            objp[0].Value = Empid;
            objp[1].Value = divid;
            return ExecuteTable("SPGetInternalBillDtlsall", objp);
        }

        public DataTable GetRetriveDnJobClosing(int bid, int year, DateTime date, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                        new SqlParameter("@date", SqlDbType.SmallDateTime),
                                                        new SqlParameter("@todate", SqlDbType.SmallDateTime)
                                                      };
            objp[0].Value = bid;
            objp[1].Value = year;
            objp[2].Value = date;
            objp[3].Value = todate;
            return ExecuteTable("SpGetRetriveDnJobClosing", objp);
        }

        public DataTable GetRetriveCNJobClosing(int bid, int year, DateTime date, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                        new SqlParameter("@date", SqlDbType.SmallDateTime),
                                                        new SqlParameter("@todate", SqlDbType.SmallDateTime)
                                                      };
            objp[0].Value = bid;
            objp[1].Value = year;
            objp[2].Value = date;
            objp[3].Value = todate;
            return ExecuteTable("SpGetRetriveCNJobClosing", objp);
        }


        public DataTable TempChargesWSTInc4NewReport(DateTime fromdate, DateTime todate, int bid, int chargeid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdt",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@todt",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                     new SqlParameter("@userid",SqlDbType.Int,4)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = bid;
            objp[3].Value = chargeid;
            objp[4].Value = empid;

            return ExecuteTable("SPTempChargesWSTInc4NewReport", objp);
        }
        public DataTable GetCustomerRetention(int empid, double retention, int division, DateTime fromdate, DateTime todate,char type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@retention", SqlDbType.Money, 8),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime, 4),
                                                         new SqlParameter("@type",SqlDbType.VarChar,1)};
             
            objp[0].Value = empid;
            objp[1].Value = retention;
            objp[2].Value = division;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            objp[5].Value = type;
            return ExecuteTable("SPGetCustomerRetentionnew", objp);
        }

        public DataTable AEBLSHIPPERINVOICEGET(string blno, int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {  
                                                        new SqlParameter("@blno", SqlDbType.VarChar,50),
                                                       new SqlParameter("@bid",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2)
                                                       
                                                      };
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            // objp[3].Value = todate;
            return ExecuteTable("sp_AEBLSHIPPERINVOICEGET", objp);
        }

        public double SPCostPATemp4new(int bid, string trantype, string blno, double totalcbm, double tottues, double totweight, int jobno, string type)
        {
            double PAexpns1 = 0;
            SqlParameter[] objp = new SqlParameter[] {

                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@totalcbm",SqlDbType.Real),
                                                       new SqlParameter("@tottues",SqlDbType.Real),
                                                       new SqlParameter("@totweight",SqlDbType.Real),
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2)};

            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = totalcbm;
            objp[4].Value = tottues;
            objp[5].Value = totweight;
            objp[6].Value = jobno;
            objp[7].Value = type;

            return PAexpns1 = double.Parse(ExecuteReader("SPCostPATemp4newraj", objp));
        }
        //Ruban costingtemp.cs
        public DataTable GetTDS(string type, DateTime from, DateTime to, int bid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                       new SqlParameter("@empid",SqlDbType.Int ,4),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@type",SqlDbType.Char,1),
                                                         new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@to",SqlDbType.SmallDateTime,1)
                                                       
                                                        };


            objp[0].Value = empid;
            objp[1].Value = bid;
            objp[2].Value = type;
            objp[3].Value = from;
            objp[4].Value = to;
            return ExecuteTable("SPACGetTDS", objp);
        }
        public void InsTempInternalBillingBranch(DateTime fromdate, DateTime todate, int empid, int branchid, int countryid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@countryid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = empid;
            objp[3].Value = branchid;
            objp[4].Value = countryid;
            ExecuteQuery("SPInsTempInternalBillingBranch", objp);
        }

        public double GetCreditDebitReversal(string blno, string trantype, int branch, string mode, int vouno)
        {
            double CADA = 0, sum = 0;
            CADA = GetCADAReversal(blno, trantype, branch, mode, vouno);
            return sum = CADA;
        }

        public double GetCADAReversal(string blno, string trantype, int branch, string mode, int vouno)
        {
            double CADA = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.Int),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 10),
                                                        new SqlParameter("@vouno", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            objp[3].Value = mode;
            objp[4].Value = vouno;
            return CADA = double.Parse(ExecuteReader("SPGetDebitCreditTempReversal", objp));
        }



        //Nambi
        public double GetcostPA4Reclose(string blno, string trantype, int branch)
        {
            double PAexpns = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            return PAexpns = double.Parse(ExecuteReader("SPCostPATemp4Reclose", objp));
        }


        public double GetcostInv4Reclose(string blno, string trantype, int branch)
        {
            double invincome = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            return invincome = double.Parse(ExecuteReader("SPCostInvTemp4Reclose", objp));
        }

        public DataTable GetDNCN4MISFromVounonew4Reclose(int jobno, int branchid, string trantype, int vouno, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      
                                                       new SqlParameter("@vouno", SqlDbType.Int,4),
                                                       new SqlParameter("@voutype",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            objp[3].Value = vouno;
            objp[4].Value = voutype;
            return ExecuteTable("SPGetDNCNForMISFromVounonew4Reclose", objp);
        }







        //dHIVYA
        public double GetDebitCreditTempAfterJobCosed(string blno, string trantype, int branch, string mode, int vouno)
        {
            double CADA = 0, sum = 0;
            CADA = GetCADAAfterJobCosed(blno, trantype, branch, mode, vouno);
            return sum = CADA;
        }

        public double GetCADAAfterJobCosed(string blno, string trantype, int branch, string mode, int vouno)
        {
            double CADA = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.Int),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 10),
                                                        new SqlParameter("@vouno", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            objp[3].Value = mode;
            objp[4].Value = vouno;
            return CADA = double.Parse(ExecuteReader("SPGetDebitCreditTempAfterJobCosed", objp));
        }

        public DataTable GetDNCN4MISFromJobNoReversal(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPGetDNCNForMISFromJobnoReversalLV", objp);
        }
        //colidated radar da on 14mar2022
        public void InsertFICustomJobs(int jobno, string challanno, DateTime challandate, double duty, double bond, int empid, string func, int customid, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                                new SqlParameter("@challanno",SqlDbType.VarChar,10),
                                                                new SqlParameter("@challandate",SqlDbType.SmallDateTime),
                                                                 new SqlParameter("@duty",SqlDbType.Money),
                                                                 new SqlParameter("@bond",SqlDbType.Money),
                                                                 new SqlParameter("@empid",SqlDbType.Int,4),
                                                                 new SqlParameter("@func",SqlDbType.Char,1),
                                                                 new SqlParameter("@custom",SqlDbType.Int),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@branchid",SqlDbType.Int,2)};

            objp[0].Value = jobno;
            objp[1].Value = challanno;
            objp[2].Value = challandate;
            objp[3].Value = duty;
            objp[4].Value = bond;
            objp[5].Value = empid;
            objp[6].Value = func;
            objp[7].Value = customid;
            objp[8].Value = trantype;
            objp[9].Value = branchid;
            ExecuteQuery("SPinsFICustomsReport", objp);

        }
        public DataTable GetFICustomReport(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPGetFICustomReport", objp);
        }
        //end

        //new

        public double Costing4unclosedjobs(string blno, string trantype, int branch, string mode)
        {
            double CADA1 = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@type", SqlDbType.VarChar, 20) };
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = branch;
            objp[3].Value = mode;
            return CADA1 = double.Parse(ExecuteReader("SPCosting4unclosedjobs", objp));
        }

        public double CostPATemplv(int bid, string trantype, string blno, double totalcbm, double tottues, double totweight, int jobno, string type)
        {
            double PAexpns1 = 0;
            SqlParameter[] objp = new SqlParameter[] {

                                                        new SqlParameter("@bid",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@totalcbm",SqlDbType.Real),
                                                       new SqlParameter("@tottues",SqlDbType.Real),
                                                       new SqlParameter("@totweight",SqlDbType.Real),
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,2)};

            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = totalcbm;
            objp[4].Value = tottues;
            objp[5].Value = totweight;
            objp[6].Value = jobno;
            objp[7].Value = type;

            return PAexpns1 = double.Parse(ExecuteReader("SPCostPATemplv", objp));
        }
        public DataTable GetDNCN4MISFromJobNo4JobBLwiseLV(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPGetDNCNForMISFromJobno4JobBLwiseLV", objp);
        }
        public DataTable GetDNCN4MISFromVounoLV(int jobno, int branchid, string trantype, int vouno, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      
                                                       new SqlParameter("@vouno", SqlDbType.Int,4),
                                                       new SqlParameter("@voutype",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            objp[3].Value = vouno;
            objp[4].Value = voutype;
            return ExecuteTable("SPGetDNCNForMISFromVounoLV", objp);
        }
        public DataTable GetDNCN4MISFromJobNoLV(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPGetDNCNForMISFromJobnolV", objp);
        }
        public string CheckcostinginsertAfterjobclose(int jobno, int branchid, string trantype, int vouno, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      
                                                       new SqlParameter("@vouno", SqlDbType.Int,4),
                                                       new SqlParameter("@voutype",SqlDbType.VarChar,1)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            objp[3].Value = vouno;
            objp[4].Value = voutype;
            return ExecuteReader("SPCheckcostinginsertAfterjobclose", objp);
        }
    }
}