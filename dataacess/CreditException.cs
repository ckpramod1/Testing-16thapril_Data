using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class CreditException:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public CreditException()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetBookingCust4CE(string trantype, string blno,int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter ("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = intBranch;
            return ExecuteTable("SPSelBookingCust", objp);

        }
        public DataTable GetCustCreditAmt(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCustCreditlimit", objp);
        }
        public DataTable GetCustGroupOutStand(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCustGroupOutStand", objp);
        }
        public DataTable GetDetails4CE(string trantype, string blno, int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter ("@blno",SqlDbType.VarChar,30),
                                                      
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt, 1)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = intBranch;
            return ExecuteTable("SPGetDetails4CE", objp);
        }

        public void InsertCreditExec(int branchid, string trantype, string docno, int reqby,string reqremarks,int customerid,double osamt,int osdays)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.TinyInt,1), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@docno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@reqby",SqlDbType.Int),
                                                       new SqlParameter("@reqremarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@osamt",SqlDbType.Money,8),
                                                       new SqlParameter("@osdays",SqlDbType.Int)
                                                       };

            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = docno;
            objp[3].Value = reqby;
            objp[4].Value = reqremarks;
            objp[5].Value = customerid;
            objp[6].Value = osamt;
            objp[7].Value = osdays;
            ExecuteQuery("SPInsCreExce", objp);
            //ExecuteQuery("SPInsertMasterCustGroup", objp);

        }
        public DataTable GetDetails4Grd(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = divisionid;
            return ExecuteTable("SPSelGRD4CE", objp);
        }
        public DataTable GetCustIndOutStand(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCustIndOutStand", objp);
        }
        public int Getdes(int empid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid",SqlDbType.Int)
                                                                                     };
            objp[0].Value = empid;
            return int.Parse(ExecuteReader("SPSeldesigid", objp));
        }
        public void UpdateCreditExec(int branchid, string trantype, string docno,int employeeid,string appremarks,string appby)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.TinyInt,1), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@docno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@employeeid",SqlDbType.Int,4),
                                                        new SqlParameter("@appremarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@appby",SqlDbType.VarChar,3)
                                                       };

            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = docno;
            objp[3].Value = employeeid;
            objp[4].Value = appremarks;
            objp[5].Value = appby;
            ExecuteQuery("SPUpdCreExce", objp);
            //ExecuteQuery("SPInsertMasterCustGroup", objp);

        }
        public DataTable GetALLDetailsCreExec(string docno,string trantype,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar,30),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                        };
            objp[0].Value = docno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPSelALLCreExce", objp);
        }
        public DataTable GetCustGroupOutStandsum(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCustGroupOutStandsum", objp);
        }
        //public DataTable GetCustInvOut(int customerid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4)
        //                                                };
        //    objp[0].Value = customerid;
        //    return ExecuteTable("SPGetCreditExceptionout", objp);
        //}
        public DataTable GetCustInvOut(int customerid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)
                                                        };
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetCreditExceptionout", objp);
        }
        public DataTable GetCustInvOutAmt(int branchid, int vouno, string trantype, string blno, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@voutype", SqlDbType.VarChar, 3)
                                                        };
            objp[0].Value = branchid;
            objp[1].Value = vouno;
            objp[2].Value = trantype;
            objp[3].Value = blno;
            objp[4].Value = voutype;
            return ExecuteTable("SPGetCreditExcus", objp);
        }
        public DataTable GetCustCE(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCEBL", objp);
        }

        public DataSet GetExcemLimit(int empid, int branchid, int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[] {     new SqlParameter("@empid",SqlDbType.Int), 
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1), 
                                                          new SqlParameter("@DivID",SqlDbType.TinyInt,1), 
                                                        };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteDataSet("SPGetExcemLimit", objp);
        }

        //Manoj For CustomerRating

        public DataTable GetCustomerRate4Billing(int branchid,DateTime fromdate , DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime)
                                                        };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPBilling4CustRate", objp);
        }

        public DataTable GetCustomerRate4PaymentPat(int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                        };
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            return ExecuteTable("SPPaymentPattern4CustRate", objp);
        }

        public DataTable GetProfit4Credit(int branchid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime)
                                                        };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPGetProfit4Credit", objp);
        }

        public void InsCustomerRating(int custid, Double bamt,Double pamt, int ppdays, string brating, string prating, string pprating,DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@custid",SqlDbType.Int,4),
                new SqlParameter("@bamt",SqlDbType.Money),
                new SqlParameter("@pamt",SqlDbType.Money),
                new SqlParameter("@ppdays",SqlDbType.Int,4),
                new SqlParameter("@brating",SqlDbType.Char,1),
                new SqlParameter("@prating",SqlDbType.Char,1),
                new SqlParameter("@pprating",SqlDbType.Char,1),
                new SqlParameter("@tranfrom",SqlDbType.SmallDateTime),
                new SqlParameter("@tranto",SqlDbType.SmallDateTime)
            };

            objp[0].Value = custid;
            objp[1].Value = bamt;
            objp[2].Value = pamt;
            objp[3].Value = ppdays;
            objp[4].Value = brating;
            objp[5].Value = prating;
            objp[6].Value = pprating;
            objp[7].Value = from;
            objp[8].Value = to;
            ExecuteQuery("SPInsCustomerRating", objp);
        }

        public DataTable GetDetailsRatingFromDaterange(DateTime fromdate , DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                new SqlParameter("@todate",SqlDbType.SmallDateTime)
                                                     };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            return ExecuteTable("SPGetDetailsofDaterangeinRatingCustomer", objp);
        }

        public DataTable GetDetailsRatingFromPreviousDaterange(DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                new SqlParameter("@todate",SqlDbType.SmallDateTime)
                                                     };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            return ExecuteTable("SPGetPreviousCustomerRating", objp);
        }

        public void UpdCustomerRateexemption(int rateid, double exem)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@rateid",SqlDbType.Int,4),
                new SqlParameter("@exem",SqlDbType.Money)
            };

            objp[0].Value = rateid;
            objp[1].Value = exem;
            ExecuteQuery("SPUpdCredExeRating", objp);
        }

        public DataTable GetCreditRateExemption()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     };
            return ExecuteTable("SPGetCreditrateExemption", objp);
        }

        public void DelCustomerRateexemption(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            ExecuteQuery("SPDelCreditExemption", objp);
        }

        public DataTable GetColorCode(string brate , string prate, string nrate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@brate",SqlDbType.Char,1),
                new SqlParameter("@prate",SqlDbType.Char,1),
                new SqlParameter("@nrate",SqlDbType.Char,1)
                                                     };
            objp[0].Value = brate;
            objp[1].Value = prate;
            objp[2].Value = nrate;
            return ExecuteTable("SpgetColorcode4Rating", objp);
        }


        public DataTable GetsummaryforCreditBilling(DateTime fromdate, DateTime todate,int custid,int divisionid,string type)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                new SqlParameter("@todate",SqlDbType.SmallDateTime),
                new SqlParameter("@custid",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.Char,1)
                                                     };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = custid;
            objp[3].Value = divisionid;
            objp[4].Value = type;
            return ExecuteTable("SPGetSummaryForCrdtExemp", objp);
        }

        public DataTable GetsummaryforPreviousdetails(DateTime fromdate, DateTime todate, int custid, int divisionid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                new SqlParameter("@todate",SqlDbType.SmallDateTime),
                new SqlParameter("@custid",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@type",SqlDbType.Char,1)
                                                     };
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = custid;
            objp[3].Value = divisionid;
            objp[4].Value = type;
            return ExecuteTable("SPGetPrevDetails4Cust", objp);
        }

        public DataTable Getdtlsforlinechart(int month, int year, int custid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@month",SqlDbType.Int,4),
                new SqlParameter("@year",SqlDbType.Int,4),
                new SqlParameter("@custid",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4)  
                                                     };
            objp[0].Value = month;
            objp[1].Value = year;
            objp[2].Value = custid;
            objp[3].Value = divisionid;
            return ExecuteTable("SPGetbillforlinechart", objp);
        }

        public DataSet GetExcemLimitbycust(int customerid, int branchid, int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[] {     new SqlParameter("@custid",SqlDbType.Int,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                          new SqlParameter("@DivID",SqlDbType.TinyInt,1),
                                                        };
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteDataSet("SPGetExcemLimitByCust", objp);
        }
        public DataTable GetCustCreditAmtcust(int customerid, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                
            new SqlParameter("@branchid", SqlDbType.Int, 4),
                new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                        };
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetCustCreditlimitcust", objp);
        }

        public DataTable GetBookingCust4CEbooking(string trantype, string blno, int intBranch)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter ("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = intBranch;
            return ExecuteTable("SPSelBookingCustforbooking", objp);

        }

        public DataTable getapprovedname(int customerid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@customerid",SqlDbType.Int,4),
                  new SqlParameter("@divisionid",SqlDbType.Int,4)
                  };
            objp[0].Value = customerid;
            objp[1].Value = divisionid;
            return ExecuteTable("spapprovedname", objp);//, "@empid");
        }

        public int Getcustomergroupid(int groupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cusgroupid", SqlDbType.Int, 4) };
            objp[0].Value = groupid;
            return int.Parse(ExecuteReader("spcustomergroupid", objp));
        }

    }
}
