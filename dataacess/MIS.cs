using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MIS : DBObject
    {
        DataAccess.HR.Employee Empobj = new DataAccess.HR.Employee();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MIS()
        {
            Conn = new SqlConnection(DBCS);
        }

        public string DataBaseName(string division, string branch)
        {
            int branchid = 0;
            int divisionid = Empobj.GetDivisionId(division);
            branchid = Empobj.GetBranchId(divisionid, branch);
            return "FA" + branchid;
        }

        public string GetQuotPendingApproval(string division, string branch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
            objp[0].Value = "FA40";
            objp[1].Value = "MD";
            return ExecuteReader("SPPngAprovalCount", objp);
        }

        public DataTable GetBooking(string databasename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
            objp[0].Value = databasename;
            objp[1].Value = "MD";
            return ExecuteTable("SPSelShiprefno", objp);
        }
        
        public string GetIncome(int division, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@division", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = division;
            objp[1].Value = empid;
            return ExecuteReader("SPMISCostingIncome", objp);
        }
        public string GetExpense(int division, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@division", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = division;
            objp[1].Value = empid;
            return ExecuteReader("SPMISCostingExpense", objp);
        }        

        public string MISBudgetActual(int division, string category, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@division", SqlDbType.TinyInt,1 ),
                                                      new SqlParameter("@category", SqlDbType.VarChar, 20),
                                                      new SqlParameter("@month", SqlDbType.Int),
                                                      new SqlParameter("@year", SqlDbType.Int) };
            objp[0].Value = division;
            objp[1].Value = category;
            objp[2].Value = month;
            objp[3].Value = year;
            return ExecuteReader("SPMISBudgetActuals", objp);
        }

        public DataTable MISBudgActByBranch(int branch, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branch", SqlDbType.Int),
                                                      new SqlParameter("@month", SqlDbType.Int),
                                                      new SqlParameter("@year", SqlDbType.Int) };
            objp[0].Value = branch;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPMISBudgActByBranch", objp);
        }

        public int GetBranchCount()
        {
            int count;
            return count = int.Parse(ExecuteReader("SPGetBranchCount"));
        }
        //regionwise revenue
        public DataTable GetBranchnameforregion(int regionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@regionid", SqlDbType.TinyInt, 1)
                                                      };
            objp[0].Value = regionid;
            return ExecuteTable("SPSelBranchname4region", objp);
        }
        public DataTable GetBranchnameListregion(int regionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@regionid", SqlDbType.TinyInt, 1)
                                                      };
            objp[0].Value = regionid;
            return ExecuteTable("SPSelBranchnameListregion", objp);
        }
        public DataTable GetRegionname()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPGetRegionname", objp);
        }

        public int GetRegionid(string regionname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@regionname",SqlDbType.VarChar,25)       
                                                                           };
            objp[0].Value = regionname;
            return int.Parse(ExecuteReader("SPGetregionid", objp));
        }
        public double GetRegionInvCost(int revmonth, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@revmonth",SqlDbType.TinyInt,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = revmonth;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;            
            //objp[3].Value = DBaseName(division, branchid); 
            return double.Parse(ExecuteReader("SPRegionInvCost", objp));

        }
        public double GetRegionPACost(int revmonth, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@revmonth",SqlDbType.TinyInt,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = revmonth;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            return double.Parse(ExecuteReader("SPRegionPACost", objp));
        }
        public double GetRegionDNCost(int revmonth, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@revmonth",SqlDbType.TinyInt,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = revmonth;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            return double.Parse(ExecuteReader("SPRegionDNCost", objp));

        }
        public double GetRegionCNCost(int revmonth, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@revmonth",SqlDbType.TinyInt,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = revmonth;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            return double.Parse(ExecuteReader("SPRegionCNCost", objp));

        }
        public double GetRegionOSCNCost(int revmonth, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@revmonth",SqlDbType.TinyInt,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = revmonth;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            return double.Parse(ExecuteReader("SPRegionOSCNCost", objp));

        }
        public double GetRegionOSDNCost(int revmonth, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@revmonth",SqlDbType.TinyInt,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = revmonth;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            return double.Parse(ExecuteReader("SPRegionOSDNCost", objp));
        }
        public DataTable GetSelbranchidForport(int portid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int, 4),
                                                        new SqlParameter("@divisionid",SqlDbType.TinyInt,1)};

            objp[0].Value = portid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPSelBranchid", objp);

        }
        public void InsRegionRevenue(int portid, double month04, double month05, double month06, double month07, double month08, double month09, double month10, double month11, double month12, double month01, double month02, double month03, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@portid",SqlDbType.Int),
                                                    new SqlParameter("@month04",SqlDbType.Money,8),
                                                    new SqlParameter("@month05",SqlDbType.Money,8),
                                                    new SqlParameter("@month06",SqlDbType.Money,8),
                                                    new SqlParameter("@month07",SqlDbType.Money,8),
                                                    new SqlParameter("@month08",SqlDbType.Money,8),
                                                    new SqlParameter("@month09",SqlDbType.Money,8),
                                                    new SqlParameter("@month10",SqlDbType.Money,8),
                                                    new SqlParameter("@month11",SqlDbType.Money,8),
                                                    new SqlParameter("@month12",SqlDbType.Money,8),
                                                    new SqlParameter("@month01",SqlDbType.Money,8),
                                                    new SqlParameter("@month02",SqlDbType.Money,8),
                                                    new SqlParameter("@month03",SqlDbType.Money,8),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = portid;
            objp[1].Value = month04;
            objp[2].Value = month05;
            objp[3].Value = month06;
            objp[4].Value = month07;
            objp[5].Value = month08;
            objp[6].Value = month09;
            objp[7].Value = month10;
            objp[8].Value = month11;
            objp[9].Value = month12;
            objp[10].Value = month01;
            objp[11].Value = month02;
            objp[12].Value = month03;
            objp[13].Value = vouyear;
            ExecuteQuery("SPInsRegionrevenue", objp);
        }
        public double GetBudgetedAmnt(int revmonth, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@revmonth",SqlDbType.TinyInt,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};

            objp[0].Value = revmonth;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            return double.Parse(ExecuteReader("SPSELBudgetedRev", objp));
        }
        public void InsRevenuebudget(int portid, double actual04, double budget04, double actual05, double budget05, double actual06, double budget06, double actual07, double budget07, double actual08, double budget08, double actual09, double budget09, double actual10, double budget10, double actual11, double budget11, double actual12, double budget12, double actual01, double budget01, double actual02, double budget02, double actual03, double budget03, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@portid",SqlDbType.Int),
                                                      
                                                      new SqlParameter("@actual04",SqlDbType.Money,8),
                                                      new SqlParameter("@budget04",SqlDbType.Money,8),
                                                      new SqlParameter("@actual05",SqlDbType.Money,8),
                                                      new SqlParameter("@budget05",SqlDbType.Money,8),
                                                      new SqlParameter("@actual06",SqlDbType.Money,8),
                                                      new SqlParameter("@budget06",SqlDbType.Money,8),
                                                      new SqlParameter("@actual07",SqlDbType.Money,8),
                                                      new SqlParameter("@budget07",SqlDbType.Money,8),
                                                      new SqlParameter("@actual08",SqlDbType.Money,8),
                                                      new SqlParameter("@budget08",SqlDbType.Money,8),
                                                      new SqlParameter("@actual09",SqlDbType.Money,8),
                                                      new SqlParameter("@budget09",SqlDbType.Money,8),
                                                      new SqlParameter("@actual10",SqlDbType.Money,8),
                                                      new SqlParameter("@budget10",SqlDbType.Money,8),
                                                      new SqlParameter("@actual11",SqlDbType.Money,8),
                                                      new SqlParameter("@budget11",SqlDbType.Money,8),
                                                      new SqlParameter("@actual12",SqlDbType.Money,8),
                                                      new SqlParameter("@budget12",SqlDbType.Money,8),
                                                      new SqlParameter("@actual01",SqlDbType.Money,8),
                                                      new SqlParameter("@budget01",SqlDbType.Money,8),
                                                      new SqlParameter("@actual02",SqlDbType.Money,8),
                                                      new SqlParameter("@budget02",SqlDbType.Money,8),
                                                      new SqlParameter("@actual03",SqlDbType.Money,8),
                                                      new SqlParameter("@budget03",SqlDbType.Money,8),
                                                      new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = portid;
            objp[1].Value = actual04;
            objp[2].Value = budget04;
            objp[3].Value = actual05;
            objp[4].Value = budget05;
            objp[5].Value = actual06;
            objp[6].Value = budget06;
            objp[7].Value = actual07;
            objp[8].Value = budget07;
            objp[9].Value = actual08;
            objp[10].Value = budget08;
            objp[11].Value = actual09;
            objp[12].Value = budget09;
            objp[13].Value = actual10;
            objp[14].Value = budget10;
            objp[15].Value = actual11;
            objp[16].Value = budget11;
            objp[17].Value = actual12;
            objp[18].Value = budget12;
            objp[19].Value = actual01;
            objp[20].Value = budget01;
            objp[21].Value = actual02;
            objp[22].Value = budget02;
            objp[23].Value = actual03;
            objp[24].Value = budget03;
            objp[25].Value = vouyear;
            ExecuteQuery("SPInsRevenueBudget", objp);
        }

        public DataTable GetSelbranchidForRegion(int regionid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@divisionid",SqlDbType.TinyInt,1)};

            objp[0].Value = regionid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPSelBranchid4region", objp);

        }
        public DataTable GetBranchnameforregionForWeb(int regionid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@regionid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = regionid;
            objp[1].Value = divisionid;
            return ExecuteTable("SPSelBranchname4regionForWeb", objp);
        }
        public DataSet SelClosedJob(DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime , 8),
                                                       new SqlParameter("@todate", SqlDbType.SmallDateTime , 8)};

            //objp[0].Value = bid;
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            return ExecuteDataSet("SPTotalClosedJob", objp);

        }
        public void InsTempY2D(string trantype, DateTime fromdate, DateTime todate, int empid, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@fromdate",SqlDbType.SmallDateTime,8),
                                                    new SqlParameter("todate",SqlDbType.SmallDateTime,8),
                                                    new SqlParameter("@empid",SqlDbType.Int),
                                                   new SqlParameter("@bid",SqlDbType.Int),
            new SqlParameter("@cid",SqlDbType.Int)};
            objp[0].Value = trantype;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = empid;
            objp[4].Value = bid;
            objp[5].Value = cid;

            ExecuteQuery("SPInsTempY2D", objp);
        }


        public void SelIncomeNotBkd(int bid, int cid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt ),
                                                        new SqlParameter("@empid", SqlDbType.Int )};

            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = empid;
            ExecuteQuery("SPSelIncomeNotBooked", objp);

        }

        public void SelExpenseNotBkd(int bid, int cid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt ),
                                                        new SqlParameter("@empid", SqlDbType.Int )};

            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = empid;
            ExecuteQuery("SPSelExpenseNotBooked", objp);

        }



        //----------------GUru_______________________//

        public DataTable SelIncomeNotBkdnew()
        {

            return ExecuteTable("Sp_IncomeNotBkdnew");

        }

        public void SelExpenNotBkd(int bid, int cid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt ),
                                                        new SqlParameter("@empid", SqlDbType.Int )};

            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = empid;
            ExecuteQuery("SPSelExpenNotBooked", objp);

        }

        public DataTable SelExpenceNotBkdnew()
        {

            return ExecuteTable("Sp_ExpenseNotBkdnew");

        }



        public DataTable GetTues4PL(int fromyear, int frommonth, int toyear, int tomonth, int branchid, string strtrantype, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@fromyear",SqlDbType.Int),
                new SqlParameter("@frommonth",SqlDbType.Int),
                new SqlParameter("@toyear",SqlDbType.Int),
                new SqlParameter("@tomonth",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@strtrantype",SqlDbType.VarChar,2),
            new SqlParameter("@type",SqlDbType.VarChar,10)};

            objp[0].Value = fromyear;
            objp[1].Value = frommonth;
            objp[2].Value = toyear;
            objp[3].Value = tomonth;
            objp[4].Value = branchid;
            objp[5].Value = strtrantype;
            objp[6].Value = type;
            return ExecuteTable("SPGetTeusReport4PL", objp);
        }

        //MIS Monthwise



        public DataTable getmismonth(int fmonth, int tmonth, int fyear, int tyear, string trantype, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{
            new SqlParameter("@fmonth",SqlDbType.Int),
            new SqlParameter("@tmonth",SqlDbType.Int),
            new SqlParameter("@fyear",SqlDbType.Int),
            new SqlParameter("@tyear",SqlDbType.Int),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@bid",SqlDbType.Int),
        new SqlParameter("@cid",SqlDbType.Int)};
            objp[0].Value = fmonth;
            objp[1].Value = tmonth;
            objp[2].Value = fyear;
            objp[3].Value = tyear;
            objp[4].Value = trantype;
            objp[5].Value = bid;
            objp[6].Value = cid;
            return ExecuteTable("spgetmismon", objp);
        }



        public DataTable getmismonthdtls(int month, int year, int cmonth, int cyear, string trantype, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{
            new SqlParameter("@month",SqlDbType.Int),
           
            new SqlParameter("@year",SqlDbType.Int),
                 new SqlParameter("@cmonth",SqlDbType.Int),
           
            new SqlParameter("@cyear",SqlDbType.Int),
            
            new SqlParameter("@trantype",SqlDbType.VarChar,4),
            new SqlParameter("@bid",SqlDbType.Int),
        new SqlParameter("@cid",SqlDbType.Int)};
            objp[0].Value = month;

            objp[1].Value = year;
            objp[2].Value = cmonth;

            objp[3].Value = cyear;

            objp[4].Value = trantype;
            objp[5].Value = bid;
            objp[6].Value = cid;
            return ExecuteTable("SPGetdtls4MisMon", objp);
        }
        //Elakkiya
        public DataTable GetLinerWiseLike(string liner)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = liner;

            return ExecuteTable("SPLikeLinerCustomerElaa", objp);
        }

        //FA

        public DataTable Getunclosedjob4date(int divisionid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
             {
                 new SqlParameter("@cid",SqlDbType.TinyInt,1),
                 new SqlParameter("@bidd",SqlDbType.TinyInt,1)
            
             };
            objp[0].Value = divisionid;
            objp[1].Value = branchid;

            return ExecuteTable("SPGetUnclosedJobsNew", objp);
        }


        public DataTable GridFillJobdtls(DateTime fromdate, DateTime todate, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate", SqlDbType.DateTime,4),
                                                       new SqlParameter("@todate", SqlDbType.DateTime,4),
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@cid",SqlDbType.Int,4)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return ExecuteTable("SPGetExemptionList", objp);
        }

        //Dinesh

        public void SelIncomeNotBkdnew(int bid, int cid, int empid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt ),
                                                        new SqlParameter("@empid", SqlDbType.Int ),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar)};

            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = empid;
            objp[3].Value = trantype;
            //ExecuteQuery("SPSelIncomeNotBookednew", objp);

            ExecuteQuery("SPSelIncomeNotBookedNewone", objp);

        }

        public void SelIncomeNotBkdnewfa2023(int bid, int cid, int empid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@bid",SqlDbType.TinyInt ),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt ),
                                                        new SqlParameter("@empid", SqlDbType.SmallInt,2 ),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar)};

            objp[0].Value = bid;
            objp[1].Value = cid;
            objp[2].Value = empid;
            objp[3].Value = trantype;
            //ExecuteQuery("SPSelIncomeNotBookednew", objp);

            ExecuteQuery("SPSelIncomeNotBookedNewone4FA030423", objp);

        }
    }
}
