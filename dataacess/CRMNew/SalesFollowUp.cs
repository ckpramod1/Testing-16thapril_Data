using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.CRMNew
{
    public class SalesFollowUp:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public SalesFollowUp()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetFollowupCustomer(string customername,int sc)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customer", SqlDbType.VarChar, 100),
            new SqlParameter("@empid", SqlDbType.Int )};

            objp[0].Value = customername ;
            objp[1].Value = sc;

            return ExecuteTable("SPGetFollowupCustomer", objp);
        }
        public DataTable GetCustomerDetails4SalesFollowup(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@customerid", SqlDbType.Int )};

            objp[0].Value = customerid;
           
            return ExecuteTable("SPGetCustomerDetails4SalesFollowup", objp);
        }
        public int InsertTeleCallerVal(int pcusid, DateTime FlupDate, int callby,  string spokenwith, DateTime spokenon, char status, string remarks, string Spdept, string Spdesgn, DateTime callon, string Spmobile, string Splandline,string salesby)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                        new SqlParameter("@followupdatetime",SqlDbType.DateTime),
                                                        new SqlParameter("@calledby",SqlDbType.Int),
                                                       new SqlParameter("@spokenwith",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@spokenon",SqlDbType.DateTime),
                                                       new SqlParameter("@status",SqlDbType.Char,1),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar, 100),
                                                       new SqlParameter("@spdept",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@spdesg",SqlDbType.VarChar,50),
                                                       new SqlParameter("@calledon",SqlDbType.DateTime),   
                                                       new SqlParameter("@spmobile",SqlDbType.VarChar,30),
                                                       new SqlParameter("@splandline",SqlDbType.VarChar,30),
                                                         new SqlParameter("@salesby",SqlDbType.VarChar,5),
                                        new SqlParameter("@crmid",SqlDbType.Int)  };

            objp[0].Value = pcusid;
            objp[1].Value = FlupDate;
            objp[2].Value = callby;
            objp[3].Value = spokenwith;
            objp[4].Value = spokenon;
            objp[5].Value = status;
            objp[6].Value = remarks;
            objp[7].Value = Spdept;
            objp[8].Value = Spdesgn;
            objp[9].Value = callon;
             objp[10].Value = Spmobile;
             objp[11].Value = Splandline;
            objp[12].Value = salesby;
            objp[13].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsCrmDetailsFromSales", objp, "@crmid");

        }

        public DataTable GetCustomerNameForSalesDetailsfollowup(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.Int) };

            objp[0].Value = customerid;

            return ExecuteTable("SPSelCustomerNameForSalesDetailsfollowup", objp);
        }
        public int SPInsMasterCustomerFromProspective(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@customername", SqlDbType.VarChar ,100),
             new SqlParameter("@customerid",SqlDbType.Int) 
            };

            objp[0].Value = customername ;
            objp[1].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsMasterCustomerFromProspective", objp, "@customerid");
        }

        public DataTable GEtFollowupfromcrmdetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@customerid", SqlDbType.Int )};


            objp[0].Value = customerid;

            return ExecuteTable("SPSElGEtFollowupfromcrmdetails", objp);
        }
        public DataTable SPGETQuotno4NewBooking(int customerid, int marketedby, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@customerid", SqlDbType.Int ),
            new SqlParameter("@marketedby", SqlDbType.Int ),
            new SqlParameter("@bid", SqlDbType.Int ),
        new SqlParameter("@cid", SqlDbType.Int )};


            objp[0].Value = customerid;
            objp[1].Value = marketedby;
            objp[2].Value = bid;
            objp[3].Value = cid;


            return ExecuteTable("SPGETQuotno4NewBooking", objp);
        }
        //Branch Region Employee

        public DataTable SPGetRegion()
        {
            return ExecuteTable("SPGetRegion");
        }
        public DataTable SPGetBranchfromRegion(int regionid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@region", SqlDbType.Int )};


            objp[0].Value = regionid;

            return ExecuteTable("SPGetBranchfromRegion", objp);
        }
        public DataTable SPGetEmployeefromBranchAndRegion(int regionid, int branch,int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@region", SqlDbType.Int ),
             new SqlParameter("@branch", SqlDbType.Int ),
            new SqlParameter("@divid", SqlDbType.Int )};


            objp[0].Value = regionid;
            objp[1].Value = branch;
            objp[2].Value = divid;

            return ExecuteTable("SPGetEmployeefromBranchAndRegion", objp);
        }

        public DataTable SpGetCRMRegionNew(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@empid", SqlDbType.Int )};


            objp[0].Value = empid;

            return ExecuteTable("SPCRMRegionname", objp);
        }
        





    }
}
