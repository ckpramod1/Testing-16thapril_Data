using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CRMNew
{
    public class Budget : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Budget()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void UpdBudget(int branchid, int bgtmonth, int bgtyear, string trantype, string subprod, int jobtype, double bgtamt, double vol)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int), 
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@prod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.Int),
                                                     new SqlParameter("@bgtamt",SqlDbType.Money),
                                                     new SqlParameter("@vol",SqlDbType.Money)};
            objp[0].Value = branchid;
            objp[1].Value = bgtmonth;
            objp[2].Value = bgtyear;
            objp[3].Value = trantype;
            objp[4].Value = subprod;
            objp[5].Value = jobtype;
            objp[6].Value = bgtamt;
            objp[7].Value = vol;
            ExecuteQuery("SPUpdMasterBudget", objp);
        }

        public void InsBudget(int branchid, int bgtmonth, int bgtyear, string trantype, string subprod, int jobtype, double bgtamt, double vol, string voltype, double actamt, double actvol)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int),        
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int), 
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@prod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.Int),
                                                     new SqlParameter("@bgtamt",SqlDbType.Money),
                                                     new SqlParameter("@vol",SqlDbType.Money),
                                                     new SqlParameter("@voltype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                     new SqlParameter("@actvol",SqlDbType.Money)};
            objp[0].Value = branchid;
            objp[1].Value = bgtmonth;
            objp[2].Value = bgtyear;
            objp[3].Value = trantype;
            objp[4].Value = subprod;
            objp[5].Value = jobtype;
            objp[6].Value = bgtamt;
            objp[7].Value = vol;
            objp[8].Value = voltype;
            objp[9].Value = actamt;
            objp[10].Value = actvol;
            ExecuteQuery("SPinsMasterBudget", objp);
        }



        public DataTable GetBudgetBranchFortran(int branchid, int month, int year, string trantype, int jobtype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@bgtmonth", SqlDbType.Int),
                                                       new SqlParameter("@bgtyear", SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobtype",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = jobtype;
            return ExecuteTable("SPGetMasterBudgetfortran", objp);
        }


        public void DelBudgetbranch(int branchid, int bgtmonth, int bgtyear, string trantype, string subprod, int jobtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int),        
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int), 
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@prod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = bgtmonth;
            objp[2].Value = bgtyear;
            objp[3].Value = trantype;
            objp[4].Value = subprod;
            objp[5].Value = jobtype;
            ExecuteQuery("SPDelBudgetBranchDetails", objp);
        }

        public void UpdBudgetsales(int branchid, int bgtmonth, int bgtyear, string trantype, string subprod, int jobtype, double bgtamt, double vol, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int), 
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@prod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.Int),
                                                     new SqlParameter("@bgtamt",SqlDbType.Money),
                                                     new SqlParameter("@vol",SqlDbType.Money),
                                                     new SqlParameter("@salesid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = bgtmonth;
            objp[2].Value = bgtyear;
            objp[3].Value = trantype;
            objp[4].Value = subprod;
            objp[5].Value = jobtype;
            objp[6].Value = bgtamt;
            objp[7].Value = vol;
            objp[8].Value = salesid;
            ExecuteQuery("SPUpdMasterBudgetsales", objp);
        }

        //public void InsBudgetsales(int branchid, int bgtmonth, int bgtyear, string trantype, string subprod, int jobtype, double bgtamt, double vol, string voltype, double actamt, int salesid, double actvol)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int),        
        //                                              new SqlParameter("@bgtmonth",SqlDbType.Int), 
        //                                              new SqlParameter("@bgtyear",SqlDbType.Int),
        //                                              new SqlParameter("@prod",SqlDbType.VarChar,2),
        //                                              new SqlParameter("@subprod",SqlDbType.VarChar,2),
        //                                              new SqlParameter("@jobtype",SqlDbType.Int),
        //                                              new SqlParameter("@bgtamt",SqlDbType.Money),
        //                                              new SqlParameter("@vol",SqlDbType.Money),
        //                                              new SqlParameter("@voltype",SqlDbType.VarChar,10),
        //                                              new SqlParameter("@actamt",SqlDbType.Money),
        //                                              new SqlParameter("@salesid",SqlDbType.Int),
        //                                              new SqlParameter("@actvol",SqlDbType.Int)};
        //    objp[0].Value = branchid;
        //    objp[1].Value = bgtmonth;
        //    objp[2].Value = bgtyear;
        //    objp[3].Value = trantype;
        //    objp[4].Value = subprod;
        //    objp[5].Value = jobtype;
        //    objp[6].Value = bgtamt;
        //    objp[7].Value = vol;
        //    objp[8].Value = voltype;
        //    objp[9].Value = actamt;
        //    objp[10].Value = salesid;
        //    objp[11].Value = actvol;
        //    ExecuteQuery("SPinsMasterBudgetsales", objp);
        //}

        public DataTable GetBudgetSales(int branchid, int month, int year, int salesid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@bgtmonth", SqlDbType.Int),
                                                       new SqlParameter("@bgtyear", SqlDbType.Int),
                                                       new SqlParameter("@salesid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = salesid;
            return ExecuteTable("SPGetMasterBudgetsales", objp);
        }

        public void DelBudgetsales(int branchid, int bgtmonth, int bgtyear, string trantype, string subprod, int jobtype, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int),        
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int), 
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@prod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = bgtmonth;
            objp[2].Value = bgtyear;
            objp[3].Value = trantype;
            objp[4].Value = subprod;
            objp[5].Value = jobtype;
            objp[6].Value = salesid;
            ExecuteQuery("SPDelBudgetsalesDetails", objp);
        }

        public DataSet GetBgtdtlstoCompare(int branchid, int bgtmonth, int bgtyear, string trantype, string subprod, int jobtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int),
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int), 
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@product",SqlDbType.VarChar,2),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = bgtmonth;
            objp[2].Value = bgtyear;
            objp[3].Value = trantype;
            objp[4].Value = subprod;
            objp[5].Value = jobtype;
            return ExecuteDataSet("SPGEtBgtdtlsCompare", objp);
        }

        public DataTable GetBudgetSalesall(int branchid, int month, int year, string trantype, string subprod, int jobtype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@bgtmonth", SqlDbType.Int),
                                                       new SqlParameter("@bgtyear", SqlDbType.Int),
                                                       new SqlParameter("@product",SqlDbType.VarChar,2),
                                                       new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobtype",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = subprod;
            objp[5].Value = jobtype;
            return ExecuteTable("SPGetMasterBudgetsalesall", objp);
        }

        public DataTable GetActualamtbranch(int branchid, int month, int year, string trantype, int jobtype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@bgtmonth", SqlDbType.Int),
                                                       new SqlParameter("@bgtyear", SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobtype",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = jobtype;
            return ExecuteTable("SPGEtActualAmtforBudget", objp);
        }

        public DataTable GetActualamtbranch4sales(int branchid, int month, int year, string trantype, int jobtype, int salesid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@bgtmonth", SqlDbType.Int),
                                                       new SqlParameter("@bgtyear", SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobtype",SqlDbType.Int),
                                                       new SqlParameter("@salesid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = jobtype;
            objp[5].Value = salesid;
            return ExecuteTable("SPGEtActualAmtforBudget4Sales", objp);
        }


        public void InsBudgetBranch(int branchid, string trantype, string jobtype, double volume, string voltype, double billamt, double actualamt, DateTime preparedon, int preparedby, int month, int year, string subprod, double actualvol)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@voltype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@preparedon",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@actvol",SqlDbType.Money)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = voltype;
            objp[5].Value = billamt;
            objp[6].Value = actualamt;
            objp[7].Value = preparedon;
            objp[8].Value = preparedby;
            objp[9].Value = month;
            objp[10].Value = year;
            objp[11].Value = subprod;
            objp[12].Value = actualvol;
            ExecuteQuery("SPInsBudgetbranch", objp);
        }

        public void InsBudgetSales(int branchid, string trantype, string jobtype, double volume, string voltype, double billamt, double actualamt, DateTime preparedon, int preparedby, int salesid, int month, int year, string subprod, double actualvol)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@voltype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@preparedon",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,2),
                                                     new SqlParameter("@actvol",SqlDbType.Money)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = voltype;
            objp[5].Value = billamt;
            objp[6].Value = actualamt;
            objp[7].Value = preparedon;
            objp[8].Value = preparedby;
            objp[9].Value = salesid;
            objp[10].Value = month;
            objp[11].Value = year;
            objp[12].Value = subprod;
            objp[13].Value = actualvol;
            ExecuteQuery("SPInsBudgetsales", objp);
        }

        public void InsBudgetcustomer(int branchid, string trantype, string jobtype, double volume, string voltype, double billamt, double actualamt, DateTime preparedon, int preparedby, int salesid, int customerid, int month, int year, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@voltype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@preparedon",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@mccid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = voltype;
            objp[5].Value = billamt;
            objp[6].Value = actualamt;
            objp[7].Value = preparedon;
            objp[8].Value = preparedby;
            objp[9].Value = salesid;
            objp[10].Value = customerid;
            objp[11].Value = month;
            objp[12].Value = year;
            objp[13].Value = mccid;
            ExecuteQuery("SPInsBudgetCustomer", objp);
        }


        public DataTable GetBudgetBranch(int branchid, int month, int year)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetBudgetBranchwise", objp);
        }

        public DataTable GetBudgetSales(int branchid, int month, int year)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetBudgetSaleswise", objp);
        }

        public DataTable GetBudgetCustomer(int branchid, int salesid, int month, int year, string trantype, string jobtype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@jobtype",SqlDbType.VarChar,10)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            return ExecuteTable("SPGetBudgetCustomerwise", objp);
        }

        public DataTable GetSalesPerson(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.Int,4)
                                                     };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetSalesPersonForBudget", objp);
        }

        public DataTable GetSalesPersontoFilter(int branchid, int dept)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@dept",SqlDbType.Int,4)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = dept;
            return ExecuteTable("SPGetSalesPersonForBudgetFilter", objp);
        }

        public void DelBudgetBranch(int branchid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                      new SqlParameter("@month",SqlDbType.Int),
                                                      new SqlParameter("@year",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            ExecuteQuery("SPDelBudgetbranch", objp);
        }

        public void DelBudgetcustomer(int branchid, int month, int year, int salesid, int customerid, string trantype, string jobtype, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                      new SqlParameter("@month",SqlDbType.Int),
                                                      new SqlParameter("@year",SqlDbType.Int),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4),
                                                      new SqlParameter("@customerid",SqlDbType.Int,4),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                      new SqlParameter("@mccid",SqlDbType.Int) };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = salesid;
            objp[4].Value = customerid;
            objp[5].Value = trantype;
            objp[6].Value = jobtype;
            objp[7].Value = mccid;

            ExecuteQuery("SPDelBudgetCustomer", objp);
        }

        public void DelBudgetsales(int branchid, int month, int year, int salesid, string trantype, string jobtype, string subprod)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                      new SqlParameter("@month",SqlDbType.Int),
                                                      new SqlParameter("@year",SqlDbType.Int),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                      new SqlParameter("@subprod",SqlDbType.VarChar,2)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = salesid;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            objp[6].Value = subprod;
            ExecuteQuery("SPDelBudgetSales", objp);
        }

        public void UpdBudgetcustomer(int branchid, string trantype, string jobtype, double volume, double billamt, double actualamt, int salesid, int customerid, int month, int year, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@mccid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = billamt;
            objp[5].Value = actualamt;
            objp[6].Value = salesid;
            objp[7].Value = customerid;
            objp[8].Value = month;
            objp[9].Value = year;
            objp[10].Value = mccid;
            ExecuteQuery("SPUPDBudgetCustomer", objp);
        }

        public DataTable GetActualbillamount(int branchid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetActualBillbranch", objp);
        }

        public DataTable GetInvoiceamount(int branchid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetInvoiceamount", objp);
        }

        public DataTable GetRetntion4Lastyear(int branchid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetRetention4ActualLastYear", objp);
        }


        public DataTable GetOSDNamount(int branchid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetOSDNAmount", objp);
        }

        public DataTable GetSalespersonamount(int branchid, int month, int year, string trantype, int jobtype, string subprod)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@jobt",SqlDbType.Int),
                                                        new SqlParameter("@subprod",SqlDbType.VarChar,2)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = jobtype;
            objp[5].Value = subprod;
            return ExecuteTable("SPGetSalesPersonInvoiceamount", objp);
        }

        public DataTable GetSalespersonretention(int branchid, int month, int year, string trantype, int jobtype, string subprod)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@jobt",SqlDbType.Int),
                                                        new SqlParameter("@subprod",SqlDbType.VarChar,2)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = jobtype;
            objp[5].Value = subprod;
            return ExecuteTable("SPGetSalesPersonretention", objp);
        }

        public DataTable GetCustomeracbillamount(int branchid, int month, int year, string trantype, string jobtype, int salesid, int custid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                        new SqlParameter("@salesid",SqlDbType.Int,4),
                                                        new SqlParameter("@custid",SqlDbType.Int,4)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = jobtype;
            objp[5].Value = salesid;
            objp[6].Value = custid;
            return ExecuteTable("SPGetCustomerInvoiceamount", objp);
        }

        public DataTable GetDeptname()
        {
            return ExecuteTable("SPGEtDeptForBudget");
        }

        public void InsBudgetCurractual(int salesid, int jobno, double retention, double volume, string trantype, int jobtype, DateTime closeddate, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid",SqlDbType.Int),        
                                                     new SqlParameter("@jobno",SqlDbType.Int), 
                                                     new SqlParameter("@retention",SqlDbType.Money),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.Int),
                                                     new SqlParameter("@closeddate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@branchid",SqlDbType.Int)};
            objp[0].Value = salesid;
            objp[1].Value = jobno;
            objp[2].Value = retention;
            objp[3].Value = volume;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            objp[6].Value = closeddate;
            objp[7].Value = branchid;
            ExecuteQuery("SPInsBudgetinJobClose", objp);
        }


        //Bhuvana

        public DataTable GetSalespersonamount(int branchid, int month, int year, string trantype, string jobtype)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@jobtype",SqlDbType.VarChar,10)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = trantype;
            objp[4].Value = jobtype;
            return ExecuteTable("SPGetSalesPersonInvoiceamount", objp);
        }
        public void DelBudgetsales(int branchid, int month, int year, int salesid, string trantype, string jobtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                      new SqlParameter("@month",SqlDbType.Int),
                                                      new SqlParameter("@year",SqlDbType.Int),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@jobtype",SqlDbType.VarChar,10)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = salesid;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            ExecuteQuery("SPDelBudgetSales", objp);
        }


        public void InsBudgetSales(int branchid, string trantype, string jobtype, double volume, string voltype, double billamt, double actualamt, DateTime preparedon, int preparedby, int salesid, int month, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@voltype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@preparedon",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = voltype;
            objp[5].Value = billamt;
            objp[6].Value = actualamt;
            objp[7].Value = preparedon;
            objp[8].Value = preparedby;
            objp[9].Value = salesid;
            objp[10].Value = month;
            objp[11].Value = year;
            ExecuteQuery("SPInsBudgetsales", objp);
        }

        // Bhuvana


        public DataTable GetRetntion4LastyearWithSalesperid(int branchid, int month, int year, int Salespesrid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@month",SqlDbType.Int,4),
                                                        new SqlParameter("@year",SqlDbType.Int,4),
                                                        new SqlParameter("@salesper",SqlDbType.Int,4)
            };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = Salespesrid;
            return ExecuteTable("SPGetRetention4ActualSalPers", objp);
        }

        public DataTable GetBudgetBranch4Salesperson(int branchid, int month, int year, int Salespesrid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                      new SqlParameter("@salesper",SqlDbType.Int)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = Salespesrid;
            return ExecuteTable("SPGetBudgetBranchwise4Salespers", objp);
        }

        //Bhuvana



        public void DelBudgetcustomernew(int branchid, int month, int year, int salesid, int customerid, string trantype, string jobtype, int mccid,int portid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                      new SqlParameter("@month",SqlDbType.Int),
                                                      new SqlParameter("@year",SqlDbType.Int),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4),
                                                      new SqlParameter("@customerid",SqlDbType.Int,4),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                      new SqlParameter("@mccid",SqlDbType.Int,4),
                                                      new SqlParameter("@portid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            objp[3].Value = salesid;
            objp[4].Value = customerid;
            objp[5].Value = trantype;
            objp[6].Value = jobtype;
            objp[7].Value = mccid;
            objp[8].Value = portid;

            ExecuteQuery("SPDelBudgetCustomer4crm", objp);
        }


        public void InsBudgetcustomer4crm(int branchid, string trantype, string jobtype, double volume, string voltype, double billamt, double actualamt, DateTime preparedon, int preparedby, int salesid, int customerid, int month, int year, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@voltype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@preparedon",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@mccid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = voltype;
            objp[5].Value = billamt;
            objp[6].Value = actualamt;
            objp[7].Value = preparedon;
            objp[8].Value = preparedby;
            objp[9].Value = salesid;
            objp[10].Value = customerid;
            objp[11].Value = month;
            objp[12].Value = year;
            objp[13].Value = mccid;
            ExecuteQuery("SPInsBudgetCustomer4crm", objp);
        }

        public void UpdBudgetcustomer4crm(int branchid, string trantype, string jobtype, double volume, double billamt, double actualamt, int salesid, int customerid, int month, int year, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@mccid",SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = billamt;
            objp[5].Value = actualamt;
            objp[6].Value = salesid;
            objp[7].Value = customerid;
            objp[8].Value = month;
            objp[9].Value = year;
            objp[10].Value = mccid;
            ExecuteQuery("SPUPDBudgetCustomer4crm", objp);

        }


        public DataTable GetBudgetCustomernew(int branchid, int salesid, int month, int year, string trantype, string jobtype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@jobtype",SqlDbType.VarChar,10)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            return ExecuteTable("SPGetBudgetCustomerwise4crm", objp);
        }

        //Elakkiya
        public DataTable GetBudgetCustomerNew(int branchid, int salesid, int month, int year, string trantype, string jobtype, string subproduct)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                 new SqlParameter("@subproduct",SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            objp[6].Value = subproduct;
            return ExecuteTable("SPGetBudgetCustomerwiseNewBud", objp);
        }

        public DataTable GetALLBudgetCustomer(int branchid, int salesid, int month, int year, string trantype, string jobtype, string subproduct)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@subproduct",SqlDbType.VarChar,2)
                                                    
                                                     
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            objp[6].Value = subproduct;

            return ExecuteTable("SPGetALLBudgetCustomerwisenew", objp);
        }



        public DataTable GetLikeCustomerForSalesNew(string customername, int portid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                    new SqlParameter("@portid",SqlDbType.Int )
                                                                                   };
            objp[0].Value = customername;
            objp[1].Value = portid;

            return ExecuteTable("SPLikeCustomerforSalesNew4Bud", objp);
        }

        public DataTable GetLikePort4Budget(string portname, int portid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@PortName", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@portid",SqlDbType.Int )};
            objp[0].Value = portname;
            objp[1].Value = portid;
            return ExecuteTable("SPLikePort4Budget", objp);

        }
        public void InsCustomerBudget(int branchid, string trantype, string jobtype, double volume, string voltype, double billamt, double actualamt, DateTime preparedon, int preparedby, int salesid, string subprod, int month, int year, double actualvol, int customerid, int portid, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@volumetype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@actualbill",SqlDbType.Money),
                                                     new SqlParameter("@preparedon",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,5),
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int),
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@actualvol",SqlDbType.Money),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                     new SqlParameter("@portid",SqlDbType.Int),
                                                     new SqlParameter("@mccid",SqlDbType.Int)
            };
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = voltype;
            objp[5].Value = billamt;
            objp[6].Value = actualamt;
            objp[7].Value = preparedon;
            objp[8].Value = preparedby;
            objp[9].Value = salesid;
            objp[10].Value = subprod;
            objp[11].Value = month;
            objp[12].Value = year;
            objp[13].Value = actualvol;
            objp[14].Value = customerid;
            objp[15].Value = portid;
            objp[16].Value = mccid;
            ExecuteQuery("SPInsCustomerBudget", objp);
        }

        public void UpdCustomerBudget(int branchid, string trantype, string jobtype, double volume, string voltype, double billamt, int preparedby, int salesid, string subprod, int month, int year, int customerid, int portid, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@volume",SqlDbType.Money),
                                                     new SqlParameter("@volumetype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@billamt",SqlDbType.Money),
                                                     new SqlParameter("@preparedby",SqlDbType.Int),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@subprod",SqlDbType.VarChar,5),
                                                     new SqlParameter("@bgtmonth",SqlDbType.Int),
                                                     new SqlParameter("@bgtyear",SqlDbType.Int),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                     new SqlParameter("@portid",SqlDbType.Int),
                                                       new SqlParameter("@mccid",SqlDbType.Int)
                                                    
                                                    
            };
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = jobtype;
            objp[3].Value = volume;
            objp[4].Value = voltype;
            objp[5].Value = billamt;
            objp[6].Value = preparedby;
            objp[7].Value = salesid;
            objp[8].Value = subprod;
            objp[9].Value = month;
            objp[10].Value = year;
            objp[11].Value = customerid;
            objp[12].Value = portid;
            objp[13].Value = mccid;
            ExecuteQuery("SPUpdCustomerBudget", objp);
        }

        //priya
        public DataTable GetBudgetBranchpriya(int branchid, int month, int year)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetBudgetBranchwisepriya", objp);
        }

        public DataTable GetBudgetSalespriya(int branchid, int month, int year)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = month;
            objp[2].Value = year;
            return ExecuteTable("SPGetBudgetSaleswisepriya", objp);
        }


        public DataTable GetBudgetCustomerpriya(int branchid, int salesid, int month, int year, string trantype, string jobtype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@jobtype",SqlDbType.VarChar,10)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            return ExecuteTable("SPGetBudgetCustomerwisepriya", objp);
        }

        //prabha


        public DataTable getunittot(int branchid, int salesid, int month, int year, string trantype, string jobtype, string subproduct)
        {
            // @branchid int,@salesid int,@bgtmonth int,@bgtyear int,@trantype varchar(2),@jobtype varchar(2),@subprod varchar(2)
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@subproduct",SqlDbType.VarChar,2)
                                                    
                                                     
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            objp[6].Value = subproduct;

            return ExecuteTable("spgetunittot", objp);
        }

        public DataTable chkuniqbudgetcust(int branchid, int salesid, int month, int year, string trantype, string jobtype, string subproduct,int custid,int portid)
        {
            // @branchid int,@salesid int,@bgtmonth int,@bgtyear int,@trantype varchar(2),@jobtype varchar(2),@subprod varchar(2)
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@subproduct",SqlDbType.VarChar,2),
                                                     new SqlParameter("@custid",SqlDbType.Int,4),
                                                     new SqlParameter("@portid",SqlDbType.Int,4)
                                                    
                                                     
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            objp[6].Value = subproduct;
            objp[7].Value = custid;
            objp[8].Value = portid;

            return ExecuteTable("spchkuniqbudgetcust", objp);
        }

        //prabha

        public DataTable GetBudgetCustomerPrabha(int branchid, int salesid, int month, int year, string trantype, string jobtype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@jobtype",SqlDbType.VarChar,10)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;

            return ExecuteTable("SPGetBudgetCustomerwisePrabha", objp);
        }

        public DataTable GetALLBudgetCustomerPrabha(int branchid, int salesid, int month, int year, string trantype, string jobtype, string subproduct)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                     new SqlParameter("@month",SqlDbType.Int),
                                                     new SqlParameter("@year",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobtype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@subproduct",SqlDbType.VarChar,2)
                                                    
                                                     
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = salesid;
            objp[2].Value = month;
            objp[3].Value = year;
            objp[4].Value = trantype;
            objp[5].Value = jobtype;
            objp[6].Value = subproduct;

            return ExecuteTable("SPGetALLBudgetCustomerwisenewPrabha", objp);
        }
        //Raj
        public DataTable GetexactCustomerForSalesNew(string customername, int portid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                    new SqlParameter("@portid",SqlDbType.Int )
                            };
            objp[0].Value = customername;
            objp[1].Value = portid;

            return ExecuteTable("SPexactCustomerforSalesNew4Bud", objp);
        } 
    }
}
