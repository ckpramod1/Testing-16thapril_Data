using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterExRate : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
       
        public MasterExRate()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertEXRateDetails(string currency, double local, double overseas, string extype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@excurr",SqlDbType.VarChar,6),
                                                         new SqlParameter("@localexrate",SqlDbType.Real,4),
                                                         new SqlParameter("@osexrate",SqlDbType.Real,4),
                                                         new  SqlParameter("@extype",SqlDbType.Char,1)
                                                     };

            objp[0].Value = currency;
            objp[1].Value = local;
            objp[2].Value = overseas;
            objp[3].Value = GetExType(extype);
            ExecuteQuery("SPInsExrateDetails", objp);
        }

        public void UpdateExRateDetails(DateTime ExDate, string currency, double local, double overseas, string extype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@excurr",SqlDbType.VarChar,6),
                                                         new SqlParameter("@localexrate",SqlDbType.Real,4),
                                                         new SqlParameter("@osexrate",SqlDbType.Real,4),
                                                         new  SqlParameter("@exdate",SqlDbType.SmallDateTime,4),
                                                         new  SqlParameter("@extype",SqlDbType.Char,1)
                                                     };

            objp[0].Value = currency;
            objp[1].Value = local;
            objp[2].Value = overseas;
            objp[3].Value = ExDate;
            objp[4].Value = GetExType(extype);
            ExecuteQuery("SPUpdExrateDetails", objp);
        }

        public DataTable RetrieveExRateDetails(DateTime ExDate, string currency, string extype, int div)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new  SqlParameter("@exdate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@excurr",SqlDbType.VarChar,6),
                                                        new  SqlParameter("@extype",SqlDbType.Char,1),
                                                    new SqlParameter("@div", SqlDbType.Int)};
            objp[0].Value = ExDate;
            objp[1].Value = currency;
            objp[2].Value = GetExType(extype);
            objp[3].Value = div;
            return ExecuteTable("SPSelExrateDetails", objp);
        }
        public char GetExType(string strExtype)
        {
            char chrTmpExtype;
            if (strExtype == "COST")
                chrTmpExtype = 'C';
            else
                chrTmpExtype = 'R';
            return chrTmpExtype;
        }


        public DataTable GetExRateDetails(DateTime datCurrDate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@exdate", SqlDbType.SmallDateTime, 4)};
            objp[0].Value = datCurrDate;
            
            return ExecuteTable("SPExratedetailsDate", objp);
        }


        // *******Methods For Windows Application.*********
        public DataTable GetLikeCurrency(string currency)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@Curr", SqlDbType.VarChar, 6) 
                                                     };
            objp[0].Value = currency;
            return ExecuteTable("SPLikeCurr", objp);
        }

        //------------------------------------------Elakkiya---------------------------------


        public void GetInsertExRate(string extype, string currency, double localrate, double overseas, int div)
        {
            SqlParameter[] objp = new SqlParameter[] {  new  SqlParameter("@exctype",SqlDbType.Char,1),
                                                         new SqlParameter("@excurr",SqlDbType.VarChar,6),
                                                         new SqlParameter("@localexrate",SqlDbType.Real,4),
                                                         new SqlParameter("@osexrate",SqlDbType.Real,4),
            new SqlParameter("@div", SqlDbType.Int)};
                                                         
                                                    
            objp[0].Value = GetExType(extype);
            objp[1].Value = currency;
            objp[2].Value = localrate;
            objp[3].Value = overseas;
    objp[4].Value = div;
            ExecuteQuery("SPExcRateInsValues", objp);
        }

        public void GetUpdExcRateValues(string extype, string currency, double localrate, double overseas, DateTime ExDate, int div)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new  SqlParameter("@exctype",SqlDbType.Char,1),
                                                         new SqlParameter("@excurr",SqlDbType.VarChar,6),
                                                         new SqlParameter("@localexrate",SqlDbType.Real,4),
                                                         new SqlParameter("@osexrate",SqlDbType.Real,4),
                                                         new  SqlParameter("@excdate",SqlDbType.SmallDateTime,4), new SqlParameter("@div", SqlDbType.Int)};
            objp[0].Value = GetExType(extype);
            objp[1].Value = currency;
            objp[2].Value = localrate;
            objp[3].Value = overseas;
            objp[4].Value = ExDate;
            objp[5].Value = div;
            ExecuteQuery("SPExcRateUpdate", objp);
        }

        public DataTable GetCurrencyValue(string currency)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@excurr", SqlDbType.VarChar, 6) 
                                                     };
            objp[0].Value = currency;
            return ExecuteTable("SPGetCurrencyValue", objp);
        }

        public DataTable GetAllExValues(String currency)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@excurr", SqlDbType.VarChar, 6) };

            objp[0].Value = currency;
            return ExecuteTable("SpGetAllExvalues", objp);
        }


        public DataTable GetExRateView(int div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@div", SqlDbType.Int) };
            objp[0].Value = div;
            return ExecuteTable("SPGetView");

        }

        public DataTable RetriveTopExRateVal()
        {
            return ExecuteTable("SPSelectTopExRateVal");
        }

        public DateTime GetDate()
        {
            return DateTime.Parse(ExecuteReader("SPGetDate"));
        }

        //sinosh
        public DataTable GetEventPendingOECS(string trantype, string eventtype, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@trantype", SqlDbType.VarChar, 3),
                new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@cid", SqlDbType.Int, 4),
                                                        new SqlParameter("@eventtype", SqlDbType.VarChar, 3)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = eventtype;
            return ExecuteTable("SPGetFEPenEvent", objp);
        }
        public DataTable GetEventPendingOICS(string trantype, string eventtype, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@trantype", SqlDbType.VarChar, 3),
                new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@cid", SqlDbType.Int, 4),
                                                        new SqlParameter("@eventtype", SqlDbType.VarChar, 3)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = eventtype;
            return ExecuteTable("SPGetFIPenEvent", objp);
        }

        public DataTable GetEventPendingAECS(string trantype, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@trantype", SqlDbType.VarChar, 3),
                new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@cid", SqlDbType.Int, 4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetAEPenEvent", objp);
        }

        public DataTable GetEventPendingAICS(string trantype, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@trantype", SqlDbType.VarChar, 3),
                new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@cid", SqlDbType.Int, 4)};

            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;

            return ExecuteTable("SPGetAIPenEvent", objp);
        }

        public string GetBaseCurrency(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return (ExecuteReader("SPSELBaseCurr", objp));
        }

        
       

        public DataTable ShowExRate(DateTime passdate,int div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@exdat", SqlDbType.DateTime) ,new SqlParameter("@div", SqlDbType.Int)};
            objp[0].Value = passdate;
            objp[1].Value = div;
            return ExecuteTable("Inexrate", objp);
            //return ExecuteTable("ExrateDetails");
        }

        public DataTable updlocalosrate(double lrate, double orate, DateTime xdate, string curr, string type,int div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@localrate", SqlDbType.Real),
            
                                                         new SqlParameter("@OSreate", SqlDbType.Real),

                                                         new SqlParameter("@xdate", SqlDbType.DateTime),
                                                          new SqlParameter("@curr", SqlDbType.VarChar,10),
                                                           new SqlParameter("@xtype", SqlDbType.VarChar,10) ,
new SqlParameter("@div", SqlDbType.Int)};

            objp[0].Value = lrate;
            objp[1].Value = orate;
            objp[2].Value = xdate;
            objp[3].Value = curr;
            objp[4].Value = type;
            objp[5].Value = div;
            return ExecuteTable("updlocalosrate", objp);
        }


        // yuvaraj Feb03

        public DataTable ExrateInsFileupload(DateTime exratedate, string filename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@exratedate", SqlDbType.SmallDateTime,50),
           
                                                         new SqlParameter("@filename", SqlDbType.VarChar,255)
             };
            objp[0].Value = exratedate;
            objp[1].Value = filename;

            return ExecuteTable("Sp_InsExchangerateFile", objp);
        }

        public DataTable SpGetExrateFile()
        {
            return ExecuteTable("SpGetExrateFile");
        }
        public DataTable GetExrateFiledetails(DateTime Exratedate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Exratedate", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = Exratedate;
            return ExecuteTable("Sp_GetExrateFiledetails", objp);
        }

        public DataTable ExrateInsFileupload(string filename, int Id)
        {
            SqlParameter[] objp = new SqlParameter[] {            
                                                         new SqlParameter("@filename", SqlDbType.VarChar,255),
                                                          new SqlParameter("@Id", SqlDbType.Int)};
            objp[0].Value = filename;
            objp[1].Value = Id;
            return ExecuteTable("Sp_ExchangeRateFileDeleted", objp);
        }
        public DataTable GetExrateFileUploadname(string Filename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Filename", SqlDbType.VarChar, 255) };
            objp[0].Value = Filename;
            return ExecuteTable("Sp_GetExrateFileUploadname", objp);
        }


        public DataTable ShowExRate_LocalOS(DateTime passdate, int div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@exdat", SqlDbType.DateTime), new SqlParameter("@div", SqlDbType.Int) };
            objp[0].Value = passdate;
            objp[1].Value = div;
            return ExecuteTable("Inexrate_LocalOS", objp);
            //return ExecuteTable("ExrateDetails");
        }
       
    }
}
