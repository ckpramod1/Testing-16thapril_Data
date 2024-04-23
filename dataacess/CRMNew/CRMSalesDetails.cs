using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRMNew
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

        //public DataTable GetCustomerNameForSales(string customername)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 50) };

        //    objp[0].Value = customername;

        //    return ExecuteTable("SPSelCustomerNameForSales", objp);
        //}

        public DataTable GetCustomerNameForSales(string customername, int salesperson)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 50),
            new SqlParameter("@salesid", SqlDbType.Int )};

            objp[0].Value = customername;
            objp[1].Value = salesperson;

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
        public void InsCRMProductDetails(int crmid, int productid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@crmid", SqlDbType.Int, 4),
                                                   new SqlParameter("@productid", SqlDbType.Int, 4),
                                                   new SqlParameter("@pcustomerid", SqlDbType.Int, 4)
            };
            objp[0].Value = crmid;
            objp[1].Value = productid;
            objp[2].Value = customerid;

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
        public DataTable GetKeyPersonDetails4Grid(int pcustomerid, int crmid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pcustomerid", SqlDbType.Int ),
                                                      new SqlParameter("@crmid", SqlDbType.Int )
               // new SqlParameter("@@crmkeyid", SqlDbType.Int )
                                                      };

            objp[0].Value = pcustomerid;
            objp[1].Value = crmid;

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
        public void UpdCRMSaleDetails4Req(int crmid, int empid, string reqcustint, string otherspefn)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@crmid", SqlDbType.Int ),
                                                   new SqlParameter("@EMPID", SqlDbType.Int ), 
                                                   new SqlParameter("@reqcust", SqlDbType.VarChar,100 ),
                                                   new SqlParameter("@otherspefn", SqlDbType.VarChar,100)
            };
            objp[0].Value = crmid;
            objp[1].Value = empid;
            objp[2].Value = reqcustint;
            objp[3].Value = otherspefn;
            ExecuteQuery("SPUpdCRMSaleDetails4Req", objp);
            //@ ,@ ,@ ,@

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
        //public DataTable GetQuoValCount(int empid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
        //    objp[0].Value = empid;
        //    return ExecuteTable("SPSelQDetails", objp);

        //}

        public DataTable GetQuoValCount()
        {
            //   SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            // objp[0].Value = empid;
            return ExecuteTable("SPSelQDetails");

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
        public DataTable GetDSR(int empid)
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
        public DataTable GetCompetetor(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customer", SqlDbType.VarChar ,50)
             
                 };
            objp[0].Value = customername;

            return ExecuteTable("SPSelCompetetor", objp);

        }
        //14/08/2015
        public DataTable GetCustomerNameForSalesDetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.Int ) };

            objp[0].Value = customerid;

            return ExecuteTable("SPSelCustomerNameForSalesDetails", objp);
        }

        //bhuvana

        public DataSet GetQuot4CRM(int crmid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar ,50)};

            objp[0].Value = crmid;
            objp[1].Value = trantype;
            return ExecuteDataSet("SPGetQuot4CRM", objp);

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
        //@crmid int,@por int ,@pol int ,@pod int  , @fd int, @quotno int, @bid int 
        //@quotno int,@bid int
        public int GetCRMid(int quotno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int ) ,
                                                         new SqlParameter("@bid", SqlDbType.Int ) };
            objp[0].Value = quotno;
            objp[1].Value = bid;
            return int.Parse(ExecuteReader("SPGetCRMid", objp));
        }
        public DataTable SPSelGETCRMDetails(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = crmid;

            return ExecuteTable("SPSelGETCRMDetails", objp);
        }
        public void SPUpdCRMDetailsX(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = crmid;

            ExecuteQuery("SPUpdCRMDetailsX", objp);
        }

        public DataTable SPSelSalesVisitAdvisewithfromto(int empid, DateTime from, DateTime to,int div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
            new SqlParameter("@fromdate", SqlDbType.SmallDateTime ),
            new SqlParameter("@todate", SqlDbType.SmallDateTime),
            new SqlParameter("@division", SqlDbType.Int) };
            objp[0].Value = empid;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = div;
            return ExecuteTable("SPSelSalesVisitAdvisewithfromto", objp);

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

        //bharathi sep 29
        public void UpdCRMPortDetails(int crmid, int por, int pol, int pod, int fd, int commodity, string indicurr, decimal indirate, int competitor, char freightterms, int incoterms, char hazardous, string imcodtls, string UNCode, string packgrp, char msds, int crmportid)
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
                                                         new SqlParameter("@msds",SqlDbType.Char,1),
                                                            new SqlParameter("@crmportid",SqlDbType.Int)
                                                        
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
            objp[16].Value = crmportid;
            ExecuteQuery("SPUpdCRMPortDetails", objp);
        }

        public DataTable SPGETCRMContact(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = crmid;

            return ExecuteTable("SPGETCRMContact", objp);
        }
        public DataTable SPGETCRMPort(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = crmid;

            return ExecuteTable("SPGETCRMPort", objp);
        }
        public DataTable SPGETCRMProduct(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = crmid;

            return ExecuteTable("SPGETCRMProduct", objp);
        }
        public DataTable SPGETCRMSales(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) };
            objp[0].Value = crmid;

            return ExecuteTable("SPGETCRMSales", objp);
        }

        public DataTable SPSelQuotvsBkng(int empid,int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
            new SqlParameter("@cid", SqlDbType.Int)
            //new SqlParameter("@bid", SqlDbType.Int)
        };
            objp[0].Value = empid ;
            objp[1].Value = cid;
           // objp[2].Value = bid;

            return ExecuteTable("SPSelQuotvsBkng", objp);
        }

        //05/10/2015
        public DataTable SPGETQoVSBokWithYear(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
            new SqlParameter("@year", SqlDbType.Int)
            //new SqlParameter("@bid", SqlDbType.Int)
        };
            objp[0].Value = empid;
            objp[1].Value = year;
            // objp[2].Value = bid;

            return ExecuteTable("SPGETQoVSBokWithYear", objp);
        }
        public DataTable SPGETQoVSBokWithYearMonth(int empid, int year, string month)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
            new SqlParameter("@year", SqlDbType.Int),
            new SqlParameter("@month", SqlDbType.VarChar ,50)
            //new SqlParameter("@bid", SqlDbType.Int)
        };
            objp[0].Value = empid;
            objp[1].Value = year;
            objp[2].Value = month;
            // objp[2].Value = bid;

            return ExecuteTable("SPGETQoVSBokWithYearMonth", objp);
        }

        public DataSet SPGETBARWITHYear(int year, int empid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@year", SqlDbType.Int),
                 new SqlParameter("@empid", SqlDbType.Int)
           
           
        };
            objp[0].Value = year;
            objp[1].Value = empid;

            // objp[2].Value = bid;

            return ExecuteDataSet("SPGETBARWITHYear", objp);
        }
        public DataTable SPSelCustomerNameIncotermValidate(string incodesc)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cargo", SqlDbType.VarChar ,50)
             
                 };
            objp[0].Value = incodesc;

            return ExecuteTable("SPSelCustomerNameIncotermValidate", objp);

        }
        public DataSet SPAPPCallaxis(int empid, int year)
        {

            SqlParameter[] objp = new SqlParameter[] {
                
                 new SqlParameter("@empid", SqlDbType.Int),
                    new SqlParameter("@year", SqlDbType.Int)
           
           
        };
            objp[0].Value = empid;
            objp[1].Value = year;

            // objp[2].Value = bid;

            return ExecuteDataSet("SPAPPCallaxis", objp);
        }
        //09/10/2015
        public void UpdCRMPortDetailsNew(int crmid, int por, int pol, int pod, int fd, int commodity, string indicurr, decimal indirate, int competitor, char freightterms, int incoterms, char hazardous, string imcodtls, string UNCode, string packgrp, char msds, int crmportid,string product,string producttype,string unittype,float unitno,string remarks ,string descr)
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
                                                         new SqlParameter("@msds",SqlDbType.Char,1),
                                                            new SqlParameter("@crmportid",SqlDbType.Int),
                                                             new SqlParameter("@product", SqlDbType.VarChar,5),
                                                         new SqlParameter("@producttype", SqlDbType.VarChar,5),
                                                         new SqlParameter("@unittype", SqlDbType.VarChar,15),
                                                         new SqlParameter("@unitno", SqlDbType.Float ),
                                                              new SqlParameter("@remarks", SqlDbType.VarChar,100),
                                                         new SqlParameter("@descr", SqlDbType.VarChar,100 )
                                                        
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
            objp[16].Value = crmportid;
            objp[17].Value = product;
            objp[18].Value = producttype ;
            objp[19].Value = unittype ;
            objp[20].Value = unitno;
            objp[21].Value = remarks;
            objp[22].Value = descr;
            ExecuteQuery("SPUpdCRMPortDetailsNew", objp);
        }
        public void InsCRMPortDetailsNew (int crmid, int por, int pol, int pod, int fd, int commodity, string indicurr, decimal indirate, int competitor, char freightterms, int incoterms, char hazardous, string imcodtls, string UNCode, string packgrp, char msds, string product, string producttype, string unittype,float unitno,string remarks ,string descr)
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
                                                         new SqlParameter("@msds",SqlDbType.Char,1),
                                                           new SqlParameter("@product", SqlDbType.VarChar,5),
                                                         new SqlParameter("@producttype", SqlDbType.VarChar,5),
                                                         new SqlParameter("@unittype", SqlDbType.VarChar,15),
                                                          new SqlParameter("@unitno", SqlDbType.Float ),
                                                             new SqlParameter("@remarks", SqlDbType.VarChar,100),
                                                         new SqlParameter("@descr", SqlDbType.VarChar,100 )
                                                        
                                                        
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
            objp[16].Value = product;
            objp[17].Value = producttype;
            objp[18].Value = unittype;
            objp[19].Value = unitno;
            objp[20].Value = remarks;
            objp[21].Value = descr;
            ExecuteQuery("SPInsCRMPortDetailsnew", objp);
        }
        public DataTable SPSElProduct(int crmid, int pcustomerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int),
                                                       new SqlParameter("@pcustomerid", SqlDbType.Int)};
            objp[0].Value = crmid;
            objp[1].Value = pcustomerid;

            return ExecuteTable("SPSElProduct", objp);
        }
        //14-10-2015
        public DataTable SPSelCustomerNameForSalesCrmnO( int salesperson)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@salesid", SqlDbType.Int )};

            
            objp[0].Value = salesperson;

            return ExecuteTable("SPSelCustomerNameForSalesCrmnO", objp);
        }
        public void SPUPdMCCidprospective(int mccid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@mccid", SqlDbType.Int ),
            new SqlParameter("@customerid", SqlDbType.Int )};


            objp[0].Value = mccid ;
            objp[1].Value = customerid ;

            ExecuteQuery("SPUPdMCCidprospective", objp);
        }

        public void SPUPdcustomerSC(int sc, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@mccid", SqlDbType.Int ),
            new SqlParameter("@customerid", SqlDbType.Int )};


            objp[0].Value = sc;
            objp[1].Value = customerid;

            ExecuteQuery("SPUPdcustomerSC", objp);
        }

        //Elakkiya
        public DataTable GetCRMdetilaswithCrmid(int crmid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@crmid", SqlDbType.Int )};


            objp[0].Value = crmid;

            return ExecuteTable("SpgetCRMIDetailsElaa", objp);
        }

        public DataTable GetDSRNewElaa(int empid,int bid,DateTime fdate,DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) ,
                new SqlParameter("@bid", SqlDbType.Int) ,
                new SqlParameter("@fromdate", SqlDbType.DateTime) ,
                                                new SqlParameter("@todate", SqlDbType.DateTime)};


            objp[0].Value = empid;
            objp[1].Value = bid;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteTable("SPSelDSRFromToNewAllBranch", objp);
        }

      
        public int GetCRMIDVsCustomer(string customer)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cname", SqlDbType.VarChar,150) 
                };

            objp[0].Value = customer;
            return int.Parse(ExecuteReader("SPSelCustomerDetailsforsalesCRM", objp));
        }

         public DataTable GetCallDetailsName()
        {
            return ExecuteTable("SPGetCallDetailsCutName");
        }

    
         public DataTable GetCallKeyPerson(int customerid)
         {
             SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pcustomerid", SqlDbType.Int) 
                };
             objp[0].Value = customerid;
             return ExecuteTable("SPGetCallKeyPersondetails", objp);
         }

         public DataTable GetCallDetailNewPort(int crmid)
         {
             SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@crmid", SqlDbType.Int) 
                };
             objp[0].Value = crmid;
             return ExecuteTable("SPCallDetailsNew", objp);
         }

         public DataTable GetCrmIdDetails(int Empid)
         {
             SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) 
                };
             objp[0].Value = Empid;
             return ExecuteTable("SpGetCrmIddetails", objp);
         }
  
    }

}
