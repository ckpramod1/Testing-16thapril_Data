using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRMNew
{
    public class TeleCaller : DBObject
    {
        //*********************************************ELAKKIYA************************************************  


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TeleCaller()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetAllCustDetailsCallers(char status,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Char, 1),
             new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = status;
            objp[1].Value = empid;
            return ExecuteTable("SPRetriveallCustomerDel", objp);

        }

        public DataTable GetPcusNameInTele(string cusname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cusname", SqlDbType.VarChar, 100) };
            objp[0].Value = cusname;
            return ExecuteTable("SPLikePCusNameInTele", objp);

        }

        public DataTable GetAllPersonDetails(int cusid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = cusid;
            return ExecuteTable("SPSelAllPTCVal", objp);

        }

        public DataTable GetAllDetailsTeleSales(int cusid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cusid", SqlDbType.Int) };
            objp[0].Value = cusid;
            return ExecuteTable("SPNewPcusDetailsTelesales", objp);

        }

        public DataTable GetAllSalesPersonDetailsTcall(string cusname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empname", SqlDbType.VarChar,50) };
            objp[0].Value = cusname;
            return ExecuteTable("SPgetSaelsPersonval", objp);

        }

        public int InsertTeleCallerVal(int pcusid, DateTime FlupDate, int callby, string meetwith, string dept, string desgn, char mode, string spokenwith, DateTime spokenon, char status, string remarks, string Spdept, string Spdesgn, DateTime callon, string mtmobile, string mtlandline, string Spmobile, string Splandline)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                        new SqlParameter("@followupdatetime",SqlDbType.DateTime),
                                                        new SqlParameter("@calledby",SqlDbType.Int),
                                                        new SqlParameter("@meetwith",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@dept",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@desgn",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@spokenwith",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@spokenon",SqlDbType.DateTime),
                                                       new SqlParameter("@status",SqlDbType.Char,1),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar, 100),
                                                       new SqlParameter("@spdept",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@spdesg",SqlDbType.VarChar,50),
                                                       new SqlParameter("@calledon",SqlDbType.DateTime),   
                                                       new SqlParameter("@mtmobile",SqlDbType.VarChar,30),
                                                       new SqlParameter("@mtlandline",SqlDbType.VarChar,30),
                                                       new SqlParameter("@spmobile",SqlDbType.VarChar,30),
                                                       new SqlParameter("@splandline",SqlDbType.VarChar,30),
                                        new SqlParameter("@crmid",SqlDbType.Int)  };

            objp[0].Value = pcusid;
            objp[1].Value = FlupDate;
            objp[2].Value = callby;
            objp[3].Value = meetwith;
            objp[4].Value = dept;
            objp[5].Value = desgn;
            objp[6].Value = mode;
            objp[7].Value = spokenwith;
            objp[8].Value = spokenon;
            objp[9].Value = status;
            objp[10].Value = remarks;
            objp[11].Value = Spdept;
            objp[12].Value = Spdesgn;
            objp[13].Value = callon;
            objp[14].Value = mtmobile;
            objp[15].Value = mtlandline;
            objp[16].Value = Spmobile;
            objp[17].Value = Splandline;
            objp[18].Direction = ParameterDirection.Output;

            return ExecuteQuery("SPInsertTeleCaller", objp, "@crmid");

        }

        public DataTable GetPcusIDTC(string cusname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100) };
            objp[0].Value = cusname;
            return ExecuteTable("SpgetPcusId", objp);
        }

        public void InsertAppDetails(int crmid, int empid, DateTime date, TimeSpan tfrom, TimeSpan tto)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@crmid", SqlDbType.Int),
                                                new SqlParameter("@empid",SqlDbType.Int),
                                                new SqlParameter("@adate",SqlDbType.Date),
                                                new SqlParameter("@ftime",SqlDbType.Time),
                                                new SqlParameter("@ttime",SqlDbType.Time)
                                                    };
            objp[0].Value = crmid;
            objp[1].Value = empid;
            objp[2].Value = date;
            objp[3].Value = tfrom;
            objp[4].Value = tto;

            ExecuteQuery("SPInsertAppdetails", objp);
        }

        public void InsertSalesPersonDetailsTC(int crmid,int salespenrid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@crmid", SqlDbType.Int),
                                                new SqlParameter("@salesperson",SqlDbType.Int)
                                               
                                                    };
            objp[0].Value = crmid;
            objp[1].Value = salespenrid;


            ExecuteQuery("SPInsertSalesPersonTcdetails", objp);

        }

        public DataTable GetAppTime(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            return ExecuteTable("SpGetAppointmentTime", objp);

        }

        public DataTable GetAllMonthDate()
        {
            return ExecuteTable("SPSelCallsDate");

        }
        //SPSelNewAdviseValues   SPSelFollwupAdviseValues  SPSelCallReportVal
      
       public DataTable GetQuoValCount(int empid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
           objp[0].Value = empid;
           return ExecuteTable("SPSelQDetails", objp);

       }

       public DataTable GetSalesApptimeCompare(int empid,DateTime date,TimeSpan ftime)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@adate", SqlDbType.Date),
                                                      new SqlParameter("@ftime", SqlDbType.Time)
           };

           objp[0].Value = empid;
           objp[1].Value = date;
           objp[2].Value = ftime;

           return ExecuteTable("SPSelCompareSalesTime", objp);

       }

       public DataTable GETStateDetails4CRM(char status)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Char,1)
           };
           objp[0].Value = status;

           return ExecuteTable("SPGetStateName4CRM", objp);

       }

       public DataTable GETDistcDetails4CRM(int stateid,char status)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateID", SqlDbType.Int),
                                                       new  SqlParameter("@type", SqlDbType.Char,1) };
           objp[0].Value = stateid;
           objp[1].Value = status;
           return ExecuteTable("SPGetDistcName4CRM", objp);

       }

       public DataTable GETLocationDetails4CRM(int disticid,char status)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtid", SqlDbType.Int),
                                                     new  SqlParameter("@type", SqlDbType.Char,1)  };
           objp[0].Value = disticid;
           objp[1].Value = status;

           return ExecuteTable("SPGetLocationName4CRM", objp);

       }

       public int  GetStateIDCRM(string  stateName)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30) };
           objp[0].Value = stateName;

           return int.Parse(ExecuteReader("SPGetStateId4CRM", objp));         
       }

       public int  GetDistcIDCRM(string  distc)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@DistrictName", SqlDbType.VarChar, 510) };
           objp[0].Value = distc;

           return int.Parse(ExecuteReader("SPGetDistcId4CRM", objp));         
       }

       public int GetlocationIDCRM(string location)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Location", SqlDbType.VarChar, 510) };
           objp[0].Value = location;

           return int.Parse(ExecuteReader("SPGetLocId4CRM", objp));
       }

       public DataTable GETCRMCustomerDisticWise(int disticid, char status)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@distcId", SqlDbType.Int),
                                                    new SqlParameter("@type", SqlDbType.Char,1) 
           };

           objp[0].Value = disticid;
           objp[1].Value = status;

           return ExecuteTable("SPSelCRMDistsWiseDetails", objp);

       }

      public DataTable GETCRMCustomerStateWise(int stateid,char status)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateID", SqlDbType.Int) ,
                                                         new SqlParameter("@type", SqlDbType.Char,1) 
           };
           objp[0].Value = stateid;
           objp[1].Value = status;
           return ExecuteTable("SPSelCRMStateWiseDetails", objp);

       }

      public DataTable GETCRMCustomerLocationWise(int locId, char status)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locId", SqlDbType.Int),
                                                        new SqlParameter("@type", SqlDbType.Char,1) 
           };
           objp[0].Value = locId;
           objp[1].Value = status;
           return ExecuteTable("SPSelCRMLoctionWiseDetails", objp);

       }

      public DataTable GetCRMPCustomers4LocationOnly(int locationid, char type)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationid", SqlDbType.Int),
                                                     new SqlParameter("@type", SqlDbType.Char,1)
                                                                };
          objp[0].Value = locationid;
          objp[1].Value = type;
          return ExecuteTable("SPRetCustomerDet4CRMLocation", objp);
      }

      public DataTable GetCRMPCustomers4StateOnly(int Stateid, char type)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateId", SqlDbType.Int) ,
                                                      new SqlParameter("@type", SqlDbType.Char,1)
                                                      };
          objp[0].Value = Stateid;
          objp[1].Value = type;
          return ExecuteTable("SPRetCustomerDet4CRMState", objp);
      }

      public DataTable GetCRMPCustomers4DisrtictOnly(int districtid, char type)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtid", SqlDbType.Int),
                                                      new SqlParameter("@type", SqlDbType.Char,1)
                                                      };
          objp[0].Value = districtid;
          objp[1].Value = type;
          return ExecuteTable("SPRetCustomerDet4CRMDistrict", objp);
      }

      public DataTable GetEmployeBranchWise(string Empname, int portid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtEmployee", SqlDbType.VarChar,100),
                                                      new SqlParameter("@portid", SqlDbType.Int)
                                                      };
          objp[0].Value = Empname;
          objp[1].Value = portid;
          return ExecuteTable("SPLikeEmployeeBranchWise", objp);
      }

      public int GetBranchID4CRM(string portname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchname", SqlDbType.VarChar, 30) };
          objp[0].Value = portname;

          return int.Parse(ExecuteReader("SPGet4BranchIDCRM", objp));
      }

      public DataTable GetStateDetailsAll()
      {
          return ExecuteTable("SPGetCRMStateDel4All");

      }

      public DataTable GetMonthWiseCal(int empid,int MONTH)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                    new SqlParameter("@MONTH", SqlDbType.Int) 
          };

          objp[0].Value = empid;
          objp[1].Value = MONTH;

          return ExecuteTable("SpgetCrmForMonthCal", objp);
          //return ExecuteTable("SpgetCrmForMonthCal");

      }


      public DataTable GetMonthWiseCalSalesCRmCustomerElaa(int custIomerid)
      {
          SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@customerid", SqlDbType.Int)
                                                      };
          objp[0].Value = custIomerid;

          return ExecuteTable("SpgetCRMCustomer4MonthWiseElaa", objp);
      }

      public DataTable GetCalllAppCount4Pie()
      {
          return ExecuteTable("SpGetCountforCRMpie");
      }

      public DataTable GetQuatationAppCount4Pie()
      {
          return ExecuteTable("SpGetCountforQuatationCRMpie");

      }

      public DataTable GetFDistcName4CRMAllDDL(char status)
      {
          SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@type", SqlDbType.Char,1)
                                                      };
          objp[0].Value = status;

          return ExecuteTable("SPGetDistcName4CRMAllDDL", objp);
      }

      public DataTable GetFLocationName4CRMAllDDL(int stateid,char status)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@stateID", SqlDbType.Int),

                                                      new SqlParameter("@type", SqlDbType.Char,1)
          };
          objp[0].Value = stateid;                                         
          objp[1].Value = status;

          return ExecuteTable("SPGetLocationName4CRMDDL", objp);
      }

      public DataTable GetCrmDetails4Followup(int custid)
      {
          SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@Cusid", SqlDbType.Int)                                            
          };

          objp[0].Value = custid;

          return ExecuteTable("SpgetAllCrmDetails4FlwupCust", objp);
      }

      public DataTable GetPortDetailsNCACRM(int empid)
      {
          SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@empid", SqlDbType.Int) };
         
          objp[0].Value = empid;
          return ExecuteTable("SPPortNewCRMSalesAdvise", objp);
          
      }



      public DataTable AppCountCRM(int empid, int year, int month)
      {
          SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@empid", SqlDbType.Int),
                                                          new SqlParameter("@year", SqlDbType.Int),
                                                          new SqlParameter("@month", SqlDbType.Int)};

          objp[0].Value = empid;
          objp[1].Value = year;
          objp[2].Value = month;
          return ExecuteTable("CRMSPAPPCountNew", objp);

      }

      public DataTable CallsCountCRM(int empid, int year, int month)
      {
          SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@empid", SqlDbType.Int),
                                                          new SqlParameter("@year", SqlDbType.Int),
                                                          new SqlParameter("@month", SqlDbType.Int)};

          objp[0].Value = empid;
          objp[1].Value = year;
          objp[2].Value = month;
          return ExecuteTable("SPAPPCallaxis", objp);

      }

      public DataTable GetApptCount(int empid, int month)
      {
          SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@empid", SqlDbType.Int),
                                                    new SqlParameter("@Month", SqlDbType.Int)};
          objp[0].Value = empid;
          objp[1].Value = month;
          return ExecuteTable("SPSelAppCount", objp);
      }

      public DataTable GetCallCount(int empid, int month)
      {
          SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@empid", SqlDbType.Int),
                                                    new SqlParameter("@Month", SqlDbType.Int)};
          objp[0].Value = empid;
          objp[1].Value = month;
          return ExecuteTable("SPSelCallCount", objp);
      }

      public DataTable GetSpNewSalesPersonCRM(int empid)
      {
          SqlParameter[] objp = new SqlParameter[] {
                                                    new SqlParameter("@empid", SqlDbType.Int)
                                                    };
          objp[0].Value = empid;

          return ExecuteTable("SPGetNewMainSalesPerson", objp);
      }

      public DataTable GetNewAdviseValues(int cityid, int empid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@City", SqlDbType.Int) ,
                                                     new SqlParameter("@empid", SqlDbType.Int)  };

          objp[0].Value = cityid;
          objp[1].Value = empid;
          return ExecuteTable("SPSelNewAdviseValues", objp);

      }

      public DataTable GetFollwupAdviseValues(DateTime Fromdate, DateTime Todate, int empid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Fromdate", SqlDbType.DateTime),
                new SqlParameter("@Todate", SqlDbType.DateTime),
                                                    new SqlParameter("@empid", SqlDbType.Int) };

          objp[0].Value = Fromdate;
          objp[1].Value = Todate;
          objp[2].Value = empid;
          return ExecuteTable("SPSelFollwupAdviseValues", objp);
          //return ExecuteTable("SPSelFollwupAdviseValues");

      }

      public DataTable GetCallReportVal(DateTime callon, DateTime Fromdate, DateTime Todate, int empid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@calledon", SqlDbType.DateTime),
                                                     new SqlParameter("@Fromdate", SqlDbType.DateTime),
                                                    new SqlParameter("@Todate", SqlDbType.DateTime),
                                                new SqlParameter("@empid", SqlDbType.Int) };
          objp[0].Value = callon;
          objp[1].Value = Fromdate;
          objp[2].Value = Todate;
          objp[3].Value = empid;
          return ExecuteTable("SPSelCallReportVal", objp);        
      }

      public DataTable GetNewAdviseValuesAllBranch(int region, int bid, int empid, int division)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.Int) ,
                                                     new SqlParameter("@bid", SqlDbType.Int),
                                                     new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@division", SqlDbType.Int)  };

          objp[0].Value = region;
          objp[1].Value = bid;
          objp[2].Value = empid;
          objp[3].Value = division ;
          return ExecuteTable("SPSelNewAdviseValuesElaaALLBranch", objp);
      }

      public DataTable GetFollowpAllBranch(DateTime Fromdate, DateTime Todate, int empid, int region, int bid, int division)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromdate", SqlDbType.DateTime),
                                                    new SqlParameter("@todate", SqlDbType.DateTime) ,
                                                     new SqlParameter("@empid", SqlDbType.Int),
                                                            new SqlParameter("@regionid", SqlDbType.Int) ,
                                                     new SqlParameter("@bid", SqlDbType.Int),                                                                                                   
                                                    new SqlParameter("@division", SqlDbType.Int)   };

          
          objp[0].Value = Fromdate ;
          objp[1].Value = Todate;          
          objp[2].Value = empid;
          objp[3].Value = region;
          objp[4].Value = bid;
          objp[5].Value = division;
          return ExecuteTable("SPSelFollwupAdviseValuesElaaNew", objp);
      }

      public DataTable GetCallRptAllBranch(int region, int bid, int empid, DateTime Fromdate, DateTime Todate,int division)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.Int) ,
                                                     new SqlParameter("@bid", SqlDbType.Int),
                                                     new SqlParameter("@empid", SqlDbType.Int),
                                                     new SqlParameter("@fromdate", SqlDbType.DateTime),
                                                    new SqlParameter("@todate", SqlDbType.DateTime), 
                                                    new SqlParameter("@division", SqlDbType.Int ) };

          objp[0].Value = region;
          objp[1].Value = bid;
          objp[2].Value = empid;
          objp[3].Value = Fromdate;
          objp[4].Value = Todate;
          objp[5].Value = division;
          return ExecuteTable("SPSelCallReportAllBranchElaa", objp);
      }

      public DataTable GetDSRRptAllBranch(int region, int bid, int empid, DateTime Fromdate, DateTime Todate, int division)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.Int) ,
                                                     new SqlParameter("@bid", SqlDbType.Int),
                                                     new SqlParameter("@empid", SqlDbType.Int),
                                                     new SqlParameter("@fromdate", SqlDbType.DateTime),
                                                    new SqlParameter("@todate", SqlDbType.DateTime) ,
                                                    new SqlParameter("@division", SqlDbType.Int ) };

          objp[0].Value = region;
          objp[1].Value = bid;
          objp[2].Value = empid;
          objp[3].Value = Fromdate;
          objp[4].Value = Todate;
          objp[5].Value = division;
          return ExecuteTable("SPSelDSRFromToNewAllBranchPrabha", objp);
      }

      public DataTable GetSalesRpts4AllBranch(int region, int bid, int empid, DateTime Fromdate, DateTime Todate, int division)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.Int) ,
                                                     new SqlParameter("@bid", SqlDbType.Int),
                                                     new SqlParameter("@empid", SqlDbType.Int),
                                                     new SqlParameter("@fromdate", SqlDbType.DateTime),
                                                    new SqlParameter("@todate", SqlDbType.DateTime),
                                                    new SqlParameter("@division", SqlDbType.Int )   };

          objp[0].Value = region;
          objp[1].Value = bid;
          objp[2].Value = empid;
          objp[3].Value = Fromdate;
          objp[4].Value = Todate;
          objp[5].Value = division;
          return ExecuteTable("SPSelSalesAdviseALlBranchElaa", objp);
      }

      public DataTable GetAllBranchRegionWise(int region,int div)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@region", SqlDbType.Int) ,
                                                     
                                                    new SqlParameter("@divid", SqlDbType.Int)   };

          objp[0].Value = region;
          objp[1].Value = div;

          return ExecuteTable("SPSelBranchWithRegion", objp);
      }

      public DataTable GetTeleCallStatus(int customerid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) 
                                                     
                                                    };

          objp[0].Value = customerid;


          return ExecuteTable("SpGetCallStatusNew", objp);
      }




      public void UpdateTeleCallerVal(int pcusid, DateTime FlupDate, int callby, string meetwith, string dept, string desgn, char mode, string spokenwith, DateTime spokenon, char status, string remarks, string Spdept, string Spdesgn, DateTime callon, string mtmobile, string mtlandline, string Spmobile, string Splandline, int crmid)
      {
          SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                        new SqlParameter("@followupdatetime",SqlDbType.DateTime),
                                                        new SqlParameter("@calledby",SqlDbType.Int),
                                                        new SqlParameter("@meetwith",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@dept",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@desgn",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@mode",SqlDbType.Char,1),
                                                       new SqlParameter("@spokenwith",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@spokenon",SqlDbType.DateTime),
                                                       new SqlParameter("@status",SqlDbType.Char,1),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar, 100),
                                                       new SqlParameter("@spdept",SqlDbType.VarChar, 50),
                                                       new SqlParameter("@spdesg",SqlDbType.VarChar,50),
                                                       new SqlParameter("@calledon",SqlDbType.DateTime),
                                                       new SqlParameter("@mtmobile",SqlDbType.VarChar,30),
                                                       new SqlParameter("@mtlandline",SqlDbType.VarChar,30),
                                                       new SqlParameter("@spmobile",SqlDbType.VarChar,30),
                                                       new SqlParameter("@splandline",SqlDbType.VarChar,30),
                                        new SqlParameter("@crmid",SqlDbType.Int)  };

          objp[0].Value = pcusid;
          objp[1].Value = FlupDate;
          objp[2].Value = callby;
          objp[3].Value = meetwith;
          objp[4].Value = dept;
          objp[5].Value = desgn;
          objp[6].Value = mode;
          objp[7].Value = spokenwith;
          objp[8].Value = spokenon;
          objp[9].Value = status;
          objp[10].Value = remarks;
          objp[11].Value = Spdept;
          objp[12].Value = Spdesgn;
          objp[13].Value = callon;
          objp[14].Value = mtmobile;
          objp[15].Value = mtlandline;
          objp[16].Value = Spmobile;
          objp[17].Value = Splandline;
          objp[18].Value = crmid;

          ExecuteQuery("SPUpdateTeleCaller", objp);

      }


    }
}
