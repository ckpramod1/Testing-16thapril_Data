using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRM
{
    public class CRMSalesDetails:DBObject 
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CRMSalesDetails()
        {
            Conn = new SqlConnection(DBCS);
        }



        public DataTable GetIncoDesc(string incodesc)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inco", SqlDbType.VarChar, 50) };

            objp[0].Value = incodesc;

            return ExecuteTable("SPSelIncoDesc", objp);
        }

        public DataTable GetCustomerNameForSales(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 50) };

            objp[0].Value = customername;

            return ExecuteTable("SPSelCustomerNameForSales", objp);
        }

        public DataTable GetCustomerDetailsForSales(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };

            objp[0].Value = customerid;

            return ExecuteTable("SPSelCustomerDetailsForSales", objp);
        }

        public void InsPCustomerContactDetails(int pcustomerid, string title, string ptc, string desig, string dept, string phone, string mobile, string email, int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pcustomerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@title", SqlDbType.VarChar,50),
                                                        new SqlParameter("@ptc", SqlDbType.VarChar,50),
                                                        new SqlParameter("@desig", SqlDbType.VarChar,50),
                                                        new SqlParameter("@dept", SqlDbType.VarChar,50),
                                                        new SqlParameter("@phone", SqlDbType.VarChar,50),
                                                        new SqlParameter("@mobile", SqlDbType.VarChar,50),
                                                        new SqlParameter("@email", SqlDbType.VarChar,50),
                                                        new SqlParameter("@crmid", SqlDbType.Int, 4)
                        };

            objp[0].Value = pcustomerid;
            objp[1].Value = title;
            objp[2].Value = ptc;
            objp[3].Value = desig;
            objp[4].Value = dept;
            objp[5].Value = phone;
            objp[6].Value = mobile;
            objp[7].Value = email;
            objp[8].Value = crmid;

            ExecuteQuery("SPInsPCustomerContactDetails", objp);
        }
        public void UpdPCustomerContactDetails(string title, string ptc, string desig, string dept, string phone, string mobile, string email, int crmid, int pcustomerid, int crmkeyid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@title", SqlDbType.VarChar,50),
                                                        new SqlParameter("@ptc", SqlDbType.VarChar,50),
                                                        new SqlParameter("@desig", SqlDbType.VarChar,50),
                                                        new SqlParameter("@dept", SqlDbType.VarChar,50),
                                                        new SqlParameter("@phone", SqlDbType.VarChar,50),
                                                        new SqlParameter("@mobile", SqlDbType.VarChar,50),
                                                        new SqlParameter("@email", SqlDbType.VarChar,50),
                                                        new SqlParameter("@crmid", SqlDbType.Int, 4),
                                                        new SqlParameter("@pcustomerid", SqlDbType.Int, 4),
                                                        new SqlParameter("@crmkeyid", SqlDbType.Int, 4)
                        };
            objp[0].Value = title;
            objp[1].Value = ptc;
            objp[2].Value = desig;
            objp[3].Value = dept;
            objp[4].Value = phone;
            objp[5].Value = mobile;
            objp[6].Value = email;
            objp[7].Value = crmid;
            objp[8].Value = pcustomerid;
            objp[9].Value = crmkeyid;

            ExecuteQuery("SPUpdPCustomerContactDetails", objp);
        }
        public DataTable GetKeyPersonDetails(int crmid, int pcustomerid, string ptc)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@crmid", SqlDbType.Int, 4),
                                                    new SqlParameter("@pcustomerid", SqlDbType.Int, 4),
                                                    new SqlParameter("@ptc", SqlDbType.VarChar,50)};

            objp[0].Value = crmid;
            objp[1].Value = pcustomerid;
            objp[2].Value = ptc;

            return ExecuteTable("SPSelGetKeyPersonDetails", objp);
        }
        public DataTable GetKeyPersonName(string ptc)
        {
            //,int crmid, int pcustomerid
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@name", SqlDbType.VarChar,50)
                                                   // new SqlParameter("@crmid", SqlDbType.Int, 4),
                                                   // new SqlParameter("@pcustomerid", SqlDbType.Int, 4) 
            };

            objp[0].Value = ptc;
            // objp[1].Value = crmid;
            //objp[2].Value = pcustomerid;

            return ExecuteTable("SPSelKeyPersonName", objp);
        }
        public void InsCRMProductDetails(int crmid, int productid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@crmid", SqlDbType.Int, 4),
                                                   new SqlParameter("@productid", SqlDbType.Int, 4) 
            };
            objp[0].Value = crmid;
            objp[1].Value = productid;
            ExecuteQuery("SPInsCRMProductDetails", objp);

        }
        public void InsCRMPortDetails(int crmid, int por, int pol, int pod, int fd, int commodity, string indicurr, decimal indirate, int competitor, char freightterms, int incoterms, char hazardous, string imcodtls, string UNCode, string packgrp, char msds)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int, 4),
                                                        new SqlParameter("@por", SqlDbType.Int,4),
                                                        new SqlParameter("@pol", SqlDbType.Int,4),
                                                        new SqlParameter("@pod", SqlDbType.Int,4),
                                                        new SqlParameter("@fd", SqlDbType.Int,4),
                                                        new SqlParameter("@commodity", SqlDbType.Int,4),
                                                        new SqlParameter("@indicurr", SqlDbType.VarChar,3),
                                                        new SqlParameter("@indirate",SqlDbType .Money),
                                                        new SqlParameter("@competitor",SqlDbType.Int),
                                                        new SqlParameter("@freightterms",SqlDbType.Char,1),
                                                        new SqlParameter("@incoterms",SqlDbType.Int),
                                                        new SqlParameter("@hazardous",SqlDbType.Char,1),
                                                         new SqlParameter("@imcodtls", SqlDbType.VarChar,25),
                                                         new SqlParameter("@UNCode", SqlDbType.VarChar,25),
                                                         new SqlParameter("@packgrp", SqlDbType.VarChar,25),
                                                         new SqlParameter("@msds",SqlDbType.Char,1)
                                                        
                        };

            objp[0].Value = crmid;
            objp[1].Value = por;
            objp[2].Value = pol;
            objp[3].Value = pod;
            objp[4].Value = fd;
            objp[5].Value = commodity;
            objp[6].Value = indicurr;
            objp[7].Value = indirate;
            objp[8].Value = competitor;
            objp[9].Value = freightterms;
            objp[10].Value = incoterms;
            objp[11].Value = hazardous;
            objp[12].Value = imcodtls;
            objp[13].Value = UNCode;
            objp[14].Value = packgrp;
            objp[15].Value = msds;
            ExecuteQuery("SPInsCRMPortDetails", objp);
        }
        public DataTable GetKeyPersonDetails4Grid(int pcustomerid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pcustomerid", SqlDbType.Int )
               // new SqlParameter("@@crmkeyid", SqlDbType.Int )
                                                      };

            objp[0].Value = pcustomerid;
            //  objp[1].Value = crmkeyid;
            return ExecuteTable("SPSelGetKeyPersonDetails4Grid", objp);
        }
        public DataTable GetCRMPortDtls4Grid(int crmid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@crmid", SqlDbType.Int )
               // new SqlParameter("@@crmkeyid", SqlDbType.Int )
                                                      };

            objp[0].Value = crmid;
            //  objp[1].Value = crmkeyid;
            return ExecuteTable("SPSelCRMPortDtls4Grid", objp);
        }
        public void UpdCRMSaleDetails4Req(string reqcustint, string otherspefn, int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@reqcust", SqlDbType.VarChar,100),
                                                   new SqlParameter("@otherspefn", SqlDbType.VarChar,100), 
                                                   new SqlParameter("@crmid", SqlDbType.Int )
            };
            objp[0].Value = reqcustint;
            objp[1].Value = otherspefn;
            objp[2].Value = crmid;
            ExecuteQuery("SPUpdCRMSaleDetails4Req", objp);

        }
        public void UpdCRMDtls4StatusQ(char status, int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@status", SqlDbType.Char,1),
                                                   new SqlParameter("@crmid", SqlDbType.Int )
            };
            objp[0].Value = status;
            objp[1].Value = crmid;
            ExecuteQuery("SPUpdCRMDtls4StatusQ", objp);

        }
        public void UpdCRMSalesPersonAptDtls4followup(DateTime adate, TimeSpan ftime, TimeSpan ttime, int crmid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@adate", SqlDbType.DateTime ),
                                                   new SqlParameter("@ftime", SqlDbType.Time ),
                                                   new SqlParameter("@ttime", SqlDbType.Time ),
                                                   new SqlParameter("@crmid", SqlDbType.Int  ),
                                                   new SqlParameter("@empid", SqlDbType.Int  )
                                                   
            };
            objp[0].Value = adate;
            objp[1].Value = ftime;
            objp[2].Value = ttime;
            objp[3].Value = crmid;
            objp[4].Value = empid;
            ExecuteQuery("SPUpdCRMSalesPersonAptDtls4followup", objp);

        }
        public DataTable GetQuoValCount(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPSelQDetails", objp);

        }
        public DataTable GetApptCount()
        {
            return ExecuteTable("SPSelAppCount");

        }
        public DataTable GetSalesVisitAdvise(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPSelSalesVisitAdvise", objp);

        }
        public DataTable GetDSR()
        {
            //SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            // objp[0].Value = empid;
            return ExecuteTable("SPSelDSR");

        }
        public DataTable GetDSR1(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SPSelDSR", objp);

        }
        public DataTable GetCRMSalesPersonApoinmentDetails(DateTime adaet, int empid,int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@adaet", SqlDbType.Int),
                new SqlParameter("@empid", SqlDbType.Int),
                new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = adaet ;
            objp[1].Value = empid;
            objp[2].Value = crmid;
            return ExecuteTable("SPUpdCRMSalesPersonApoinmentDetails", objp);

        }

        public DataTable GetDSRfromto(int empid, DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
            new SqlParameter("@fromdate", SqlDbType.SmallDateTime ),
            new SqlParameter("@todate", SqlDbType.SmallDateTime)};
            objp[0].Value = empid;
            objp[1].Value = from;
            objp[2].Value = to;

            return ExecuteTable("SPSelDSRFromToNew", objp);

        }

        public DataTable GetCustomerNameForSalesName(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar ,50)
             
                 };
            objp[0].Value = customername;

            return ExecuteTable("SPSelCustomerNameForSalesName", objp);

        }
        public DataTable GetCustomerNameCargo(string cargo)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cargo", SqlDbType.VarChar ,50)
             
                 };
            objp[0].Value = cargo;

            return ExecuteTable("SPSelCustomerNameCargo", objp);

        }
        public DataTable GetIncoTerms(string incodesc)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@inco", SqlDbType.VarChar ,50)
             
                 };
            objp[0].Value = incodesc;

            return ExecuteTable("SPSelIncoTerms", objp);

        }

        public DataSet GetQuot4CRM(int crmid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar ,50)};

            objp[0].Value = crmid;
            objp[1].Value = trantype;
            return ExecuteDataSet("SPGetQuot4CRM", objp);

        }


        public DataTable GetCompetetor(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customer", SqlDbType.VarChar ,50)
             
                 };
            objp[0].Value = customername;

            return ExecuteTable("SPSelCompetetor", objp);

        }
        public DataTable GetCRM4grd(string trantype, int empid, string pdt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 5),
                                                        new SqlParameter("@empid", SqlDbType.Int),
                                                        new SqlParameter("@pdttype", SqlDbType.VarChar ,3)};
            objp[0].Value = trantype;
            objp[1].Value = empid;
            objp[2].Value = pdt;
            return ExecuteTable("SPGetCRM4Grid", objp);

        }
        public int GetCRMid(int quotno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int ) ,
                                                         new SqlParameter("@bid", SqlDbType.Int ) };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            return int.Parse(ExecuteReader("SPGetCRMid", objp));
        }
        public void InsCRM4Quot(int crmid, int por, int pol, int pod, int fd, int quot, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@crmid", SqlDbType.Int),
                                                   new SqlParameter("@por", SqlDbType.Int) ,
                                                    new SqlParameter("@pol", SqlDbType.Int),
                                                   new SqlParameter("@pod", SqlDbType.Int) ,
                                                    new SqlParameter("@fd", SqlDbType.Int),
                                                   new SqlParameter("@quotno", SqlDbType.Int) ,
                                                    new SqlParameter("@bid", SqlDbType.Int)
                                                   
            };
            objp[0].Value = crmid;
            objp[1].Value = por;
            objp[2].Value = pol;
            objp[3].Value = pod;
            objp[4].Value = fd;
            objp[5].Value = quot;
            objp[6].Value = bid;

            ExecuteQuery("SPInsQuot4Crm", objp);

        }

        //Prabha  and  Arun


        public void InsForCallDetails(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@pcustomerid", SqlDbType.Int)
                                                   
            };
            objp[0].Value = crmid;

            ExecuteQuery("SPInsCallDetailsFromSales", objp);
        }
        //public void InsForCallDetailsNew(int crmid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //                                           new SqlParameter("@pcustomerid", SqlDbType.Int)
                                                   
        //    };
        //    objp[0].Value = crmid;

        //    ExecuteQuery("SpGetInsCrmIddetails", objp);
        //}


        public int InsForCallDetailsNew(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] {                                                   
                                                      new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                       new SqlParameter("@crmid", SqlDbType.Int)                                                   
            };
            objp[0].Value = crmid;
            objp[1].Direction = ParameterDirection.Output;
            return ExecuteQuery("SpGetInsCrmIddetails", objp, "@crmid");
        }
        public void UpdateCalldetailsNew(int customerid, int crmid, char mode, string spokenwith, DateTime spokedon, char status, string remarks, string spdept, string spdesg, string spmobile, string splandline, string salesby, int callstatus)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                   new SqlParameter("@crmid", SqlDbType.Int) ,
                                                   
                                                    new SqlParameter("@mode", SqlDbType.Char),
                                                     new SqlParameter("@spokenwith", SqlDbType.VarChar,50),
                                                       new SqlParameter("@spokenon", SqlDbType.SmallDateTime),
                                                         new SqlParameter("@status", SqlDbType.Char),

                                                         new SqlParameter("@remarks", SqlDbType.VarChar,100),
                                                         new SqlParameter("@spdept", SqlDbType.VarChar,50),
                                                         new SqlParameter("@spdesg", SqlDbType.VarChar,50),
                                                       
                                                            new SqlParameter("@spmobile", SqlDbType.VarChar,30),
                                                             new SqlParameter("@splandline", SqlDbType.VarChar,30),

                                                             new SqlParameter("@salesby", SqlDbType.VarChar,5),
                                                             new SqlParameter("@callstatus", SqlDbType.Int),
            };
            objp[0].Value = customerid;
            objp[1].Value = crmid;
            objp[2].Value = mode;
            objp[3].Value = spokenwith;
            objp[4].Value = spokedon;
            objp[5].Value = status;
            objp[6].Value = remarks;
            objp[7].Value = spdept;
            objp[8].Value = spdesg;
            objp[9].Value = spmobile;
            objp[10].Value = splandline;
            objp[11].Value = salesby;
            objp[12].Value = callstatus;

            ExecuteQuery("SPUpdateCallDetailNew", objp);
        }

        public DataTable GetCustomerNameForSalesForNew(string customername, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 50),
            new SqlParameter("@salesid", SqlDbType.Int)};

            objp[0].Value = customername;
            objp[1].Value = salesid;

            return ExecuteTable("SPSelCustomerNameForSalesCallDetails", objp);
        }
       

        //Dinesh

        public void DelForCallDetails(int crmkeyid, int pcustid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@crmkeyid", SqlDbType.Int),
                                                   new SqlParameter("@pcustomerid", SqlDbType.Int)

            };
            objp[0].Value = crmkeyid;
            objp[1].Value = pcustid;
            ExecuteQuery("SP_DelCRMPCustomerContactDetails", objp);
        }


        public DataTable ChkKeypersondetails(int custid, string ptc, string dept, string desc)
        {
            SqlParameter[] objp = new SqlParameter[] {
            new SqlParameter("@pcustomerid", SqlDbType.Int),
            new SqlParameter("@ptc", SqlDbType.VarChar,100),
            new SqlParameter("@dept", SqlDbType.VarChar,100),
            new SqlParameter("@desig", SqlDbType.VarChar,100)};

            objp[0].Value = custid;
            objp[1].Value = ptc;
            objp[2].Value = dept;
            objp[3].Value = desc;


            return ExecuteTable("SP_chkKeypersonname", objp);
        }



        //Dinesh

        public void Updatefiollowupdatetime(int custid, int crmid, DateTime followdate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                   new SqlParameter("@crmid", SqlDbType.Int) ,
                                                    new SqlParameter("@folowupdate", SqlDbType.DateTime),
                                               
                                                   
            };
            objp[0].Value = custid;
            objp[1].Value = crmid;
            objp[2].Value = followdate;


            ExecuteQuery("SP_Updatefiollowupdatetime", objp);

        }


        public DataTable retrivefiollowupdatetime(int custid, int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                   new SqlParameter("@crmid", SqlDbType.Int) 
                                                   
                                               
                                                   
            };
            objp[0].Value = custid;
            objp[1].Value = crmid;

            return ExecuteTable("SP_retrivefiollowupdatetime", objp);
        }


        public DataTable GetContactDetailsfornew(int custid, int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@pcustomerid", SqlDbType.Int),
             new SqlParameter("@crmid", SqlDbType.Int)};

            objp[0].Value = custid;
            objp[1].Value = crmid;

            return ExecuteTable("SPGetContactDetailsfornew", objp);
        }
    }

}
