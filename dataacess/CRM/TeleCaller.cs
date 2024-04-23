using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRM
{
    public class TeleCaller : DBObject
    {
        //*********************************************ELAKKIYA************************************************
        //

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TeleCaller()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetAllCustDetailsCallers(char status)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Char, 1) };
            objp[0].Value = status;
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

       public DataTable GetNewAdviseValues()
        {
            return ExecuteTable("SPSelNewAdviseValues");
        }

       public DataTable GetFollwupAdviseValues()
       {
           return ExecuteTable("SPSelFollwupAdviseValues");

       }

       public DataTable GetCallReportVal(DateTime callon)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@calledon", SqlDbType.DateTime) };
           objp[0].Value = callon;
           return ExecuteTable("SPSelCallReportVal", objp);

       }

       public DataTable GetApptCount()
       {
           return ExecuteTable("SPSelAppCount");

       }

       public DataTable GetCallCount()
       {
           return ExecuteTable("SPSelCallCount");

       }

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



        
    }
}
