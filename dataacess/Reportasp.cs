using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Reportasp : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Reportasp()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataSet GetReceiptRptByRecId(int ReceiptId, string Type)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@ReceiptId",SqlDbType.BigInt),  
                new SqlParameter("@Type",SqlDbType.VarChar,1),   
            };
            objp[0].Value = ReceiptId;
            objp[1].Value = Type;
           // return ExecuteDataSet("GetReceiptRptByRecIdnew", objp);
            return ExecuteDataSet("GetReceiptRptByRecIdnew_jobnew", objp);
        }
        public DataSet GetReceiptRptByRecId(int ReceiptId)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@ReceiptId",SqlDbType.BigInt),   
            };
            objp[0].Value = ReceiptId;
            return ExecuteDataSet("GetReceiptRptByRecId", objp);
        }

        public DataSet GetRemittanceReceiptRptByRecId(int ReceiptId, string Type)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@ReceiptId",SqlDbType.BigInt),
                new SqlParameter("@Type",SqlDbType.VarChar,1),   
            };
            objp[0].Value = ReceiptId;
            objp[1].Value = Type;
            return ExecuteDataSet("GetRemittanceReceiptRptByRecId", objp);
        }
        public DataSet GetQuoteandBookDtls4Rpt(int Bookingno, int Bid, int Cid, string Type, string TranType)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@QuoteOrBookno",SqlDbType.Int),
                new SqlParameter("@Bid",SqlDbType.Int),  
                new SqlParameter("@Cid",SqlDbType.Int),                
                new SqlParameter("@Type",SqlDbType.VarChar,1),  
                new SqlParameter("@TranType",SqlDbType.VarChar,2),  
            };
            objp[0].Value = Bookingno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            objp[3].Value = Type;
            objp[4].Value = TranType;
            return ExecuteDataSet("GetQuoteandBookDtls4Rpt", objp);
        }
        public DataTable GetBLDetails4Rpt(string blno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter ("@Blno",SqlDbType.VarChar,20),
                                                        new SqlParameter("@Bid", SqlDbType.Int, 1),
                                                       new SqlParameter("@Cid", SqlDbType.Int, 1)};
            objp[0].Value = blno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            return ExecuteTable("GetBLDetails4Rpt", objp);
        }
        public DataTable Getcontdtls4MR(string blno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter ("@Blno",SqlDbType.VarChar,20),
                                                        new SqlParameter("@Bid", SqlDbType.Int, 1),
                                                       new SqlParameter("@Cid", SqlDbType.Int, 1)};
            objp[0].Value = blno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            return ExecuteTable("SPgetcontdtls4MR", objp);
        }

        public DataSet GetCANRpt(int jobno, int Bid, int Cid, string Type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter ("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@Bid", SqlDbType.Int, 1),
                                                       new SqlParameter("@Cid", SqlDbType.Int, 1),
                                                    new SqlParameter("@Type", SqlDbType.VarChar, 5)};
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            objp[3].Value = Type;
            return ExecuteDataSet("GetCANRpt", objp);
        }
        //magic form replaced
        public DataSet GetCANRpt(int jobno, int Bid, int Cid, string Type, string Blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1),
                new SqlParameter("@Type", SqlDbType.VarChar, 5),
                new SqlParameter("@Blno", SqlDbType.VarChar, 20),
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            objp[3].Value = Type;
            objp[4].Value = Blno;
            return ExecuteDataSet("GetCANRpt", objp);
        }
        public DataTable Getaddress4MR(int jobno, int Bid, int Cid, string Type, string Blno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                        new SqlParameter ("@type",SqlDbType.VarChar,12),
                                                        new SqlParameter ("@Blno",SqlDbType.VarChar,20),
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            objp[3].Value = Type;
            objp[4].Value = Blno;
            //return ExecuteTable("SPgetaddress4MR", objp);
            return ExecuteTable("SPgetaddress4SCM", objp);
        }
        //end
        public DataTable Getaddress4MR(int jobno, int Bid, int Cid, string Type)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                        new SqlParameter ("@type",SqlDbType.VarChar,12)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            objp[3].Value = Type;
            return ExecuteTable("SPgetaddress4MR", objp);
        }
        public DataTable GetAnnex1(int jobno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1)
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;

            return ExecuteTable("SPGetAnnex1", objp);
        }

        public DataTable GetAnnexure(int jobno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1)
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;

            return ExecuteTable("SPGetannexure", objp);
        }

        public DataTable Getcancontdet(int jobno, int Bid, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@blno", SqlDbType.VarChar, 30)
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = blno;

            return ExecuteTable("SPcancontdet", objp);
        }
        public DataSet GetAnnex3rpt(int jobno, int Bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1)
                
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;

            return ExecuteDataSet("SPGetAnnex3", objp);
        }

        public DataSet GetForm2rpt(int jobno, int Bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1)
                
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;

            return ExecuteDataSet("SPGetForm2rpt", objp);
        }
        public DataSet GetForm3RPT(int jobno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1)
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;

            return ExecuteDataSet("SPForm3RPT", objp);
        }
        public DataTable GetICDTSA(int jobno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1)
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;

            return ExecuteTable("SPGetICDTSA", objp);
        }
        public DataTable GetCMNote(int jobno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1)
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;

            return ExecuteTable("SPGetCMNote", objp);
        }
        public DataSet GetConsolletter(int jobno, int Bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1)
                
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;

            return ExecuteDataSet("SPGetConsolletter", objp);
        }
        public DataTable GetICDCFS(int jobno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1)
               
               
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;

            return ExecuteTable("SPGetICDCFS", objp);
        }

        public DataSet GetCANFWRpt(int jobno, int Bid, int Cid, string Type, string Blno)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@Bid", SqlDbType.Int, 1),
                new SqlParameter("@Cid", SqlDbType.Int, 1),
                new SqlParameter("@Type", SqlDbType.VarChar, 5),
                new SqlParameter("@Blno", SqlDbType.VarChar, 20),
            };
            objp[0].Value = jobno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            objp[3].Value = Type;
            objp[4].Value = Blno;
            return ExecuteDataSet("GetCANFWRpt", objp);
     
        
        }


        public DataTable Getquotmultiportrpt(int Bid, string trantype, string quotno)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@bid",SqlDbType.Int),
                new SqlParameter("@trantype", SqlDbType.VarChar,2),
                 new SqlParameter("@quotno", SqlDbType.VarChar,50)
                 
               
               
            };
            objp[0].Value = Bid;
            objp[1].Value = trantype;
            objp[2].Value = quotno;
            return ExecuteTable("SPgetquotmultiportrpt", objp);
        }
        public DataTable GetCustomersupportall(int Bid, string trantype,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@bid",SqlDbType.Int),
                new SqlParameter("@trantype", SqlDbType.VarChar,2) ,
                 new SqlParameter ("@EmployeeId",SqlDbType.Int),
            };
            objp[0].Value = Bid;
            objp[1].Value = trantype;
            objp[2].Value = empid;

            return ExecuteTable("SPCustomersupportall", objp);
        }

        public DataTable Getmastereventdetails(string eventname)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@event",SqlDbType.VarChar,100),
                                                                           
            };
            objp[0].Value = eventname;
            return ExecuteTable("SPGetmastereventdetails", objp);
        }

        public void InsOEeventdetails(int jobno, string bookingno, string containerno, string eventname, DateTime eventdate, int updatedby, int Bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter ("@bookingno",SqlDbType.VarChar ,30),
                new SqlParameter ("@containerno",SqlDbType.VarChar ,30),
                new SqlParameter ("@eventname",SqlDbType.VarChar ,100),
                new SqlParameter ("@eventdate",SqlDbType.DateTime),
                 new SqlParameter ("@updatedby",SqlDbType.Int),
                new SqlParameter ("@bid",SqlDbType.Int),
                new SqlParameter("@trantype", SqlDbType.VarChar,2)                                                             
            };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = containerno;
            objp[3].Value = eventname;
            objp[4].Value = eventdate;
            objp[5].Value = updatedby;
            objp[6].Value = Bid;
            objp[7].Value = trantype;

            ExecuteTable("SpInsOEeventdetails", objp);
        }

        public DataTable Geteventcontent4mail(int job,int Bid,string eventid, string trantype )
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                 new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter ("@bid",SqlDbType.Int),
                 new SqlParameter ("@event",SqlDbType.VarChar,100),
                new SqlParameter("@trantype", SqlDbType.VarChar,2),
                
                 
               
               
            };
            objp[0].Value = job;
            objp[1].Value = Bid;
            objp[2].Value = eventid;
            objp[3].Value = trantype;
            return ExecuteTable("SPGeteventcontent4mail", objp);
        }
        public DataTable GetCustomersupportallpancustwise(int Bid, string trantype,int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@bid",SqlDbType.Int),
                new SqlParameter("@trantype", SqlDbType.VarChar,2)  ,
                new SqlParameter ("@custid",SqlDbType.Int)                                           
            };
            objp[0].Value = Bid;
            objp[1].Value = trantype;
            objp[2].Value = customerid;
            return ExecuteTable("SPCustomersupportallpancustwise", objp);
        }
        public DataSet GEtdropdownvalues4CS(int Bid, string trantype, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@bid",SqlDbType.Int),
                new SqlParameter("@trantype", SqlDbType.VarChar,2)  ,
                new SqlParameter ("@custid",SqlDbType.Int)                                           
            };
            objp[0].Value = Bid;
            objp[1].Value = trantype;
            objp[2].Value = customerid;
            return ExecuteDataSet("SPGEtdropdownvalues4CS", objp);
        }
        public DataTable Eventpendingcount(int Bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter ("@bid",SqlDbType.Int),
                new SqlParameter("@trantype", SqlDbType.VarChar,2)                                                             
            };
            objp[0].Value = Bid;
            objp[1].Value = trantype;

            return ExecuteTable("SPeventpendingcount", objp);
        }
        public DataTable GetCustomersupportallTask(int Bid, string trantype, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@bid",SqlDbType.Int),
                new SqlParameter("@trantype", SqlDbType.VarChar,2) ,
                 new SqlParameter ("@EmployeeId",SqlDbType.Int),
            };
            objp[0].Value = Bid;
            objp[1].Value = trantype;
            objp[2].Value = empid;

            return ExecuteTable("SPCustomersupportallTask", objp);
        }

        public void InsOEeventdetailsTask(int jobno, string bookingno, string containerno, string eventname, DateTime eventdate, int updatedby, int Bid, string trantype, int refno, string voutype, int taskid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
         new SqlParameter ("@jobno",SqlDbType.Int),
         new SqlParameter ("@bookingno",SqlDbType.VarChar ,30),
         new SqlParameter ("@containerno",SqlDbType.VarChar ,30),
         new SqlParameter ("@eventname",SqlDbType.VarChar ,100),
         new SqlParameter ("@eventdate",SqlDbType.DateTime),
          new SqlParameter ("@updatedby",SqlDbType.Int),
         new SqlParameter ("@bid",SqlDbType.Int),
         new SqlParameter("@trantype", SqlDbType.VarChar,2),
          new SqlParameter("@refno", SqlDbType.Int),
           new SqlParameter("@voutype", SqlDbType.VarChar,200),
           new SqlParameter ("@eventid",SqlDbType.Int)
            };
            objp[0].Value = jobno;
            objp[1].Value = bookingno;
            objp[2].Value = containerno;
            objp[3].Value = eventname;
            objp[4].Value = eventdate;
            objp[5].Value = updatedby;
            objp[6].Value = Bid;
            objp[7].Value = trantype;
            objp[8].Value = refno;
            objp[9].Value = voutype;
            objp[10].Value = taskid;

            ExecuteTable("SpInsOEeventdetailsTask", objp);
        }
        public DataTable Selcustomedirpt(int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@bid", SqlDbType.Int)
            };
            objp[0].Value = jobno;
            objp[1].Value = bid;

            return ExecuteTable("SPselcustomedirpt", objp);
        }

        public DataTable Seldlconfirmrpt(string blno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@blno",SqlDbType.VarChar,30),
                new SqlParameter("@bid", SqlDbType.Int)
            };
            objp[0].Value = blno;
            objp[1].Value = bid;

            return ExecuteTable("SPseldlconfirmrpt", objp);
        }
        public DataTable SelIGMFINALrpt(int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@bid", SqlDbType.Int)
            };
            objp[0].Value = jobno;
            objp[1].Value = bid;

            return ExecuteTable("SPSeligmfinalrpt", objp);
        }

        public DataTable SelCntnrldplanRpt(int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@bid", SqlDbType.Int)
            };
            objp[0].Value = jobno;
            objp[1].Value = bid;

            return ExecuteTable("SPSelconloadrpt", objp);
        }
        public DataTable SelcgdescRpt(int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@jobno",SqlDbType.Int),
                new SqlParameter("@bid", SqlDbType.Int)
            };
            objp[0].Value = jobno;
            objp[1].Value = bid;

            return ExecuteTable("SPSelcgdescRpt", objp);
        }
        public DataTable SelFIPDORegisterRpt(int agentid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@agentid",SqlDbType.Int),
                new SqlParameter("@bid", SqlDbType.Int)
            };
            objp[0].Value = agentid;
            objp[1].Value = bid;

            return ExecuteTable("SPSelFIPDORegisterRpt", objp);
        }

        public DataTable SelFIDOStatusForAgentRpt(int agentid, int bid, DateTime dtfrom, DateTime dtto)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter ("@agentid",SqlDbType.Int),
                new SqlParameter ("@dtfrom",SqlDbType.DateTime),
                new SqlParameter ("@dtto",SqlDbType.DateTime)
            };
            objp[0].Value = bid;
            objp[1].Value = agentid;
            objp[2].Value = dtfrom;
            objp[3].Value = dtto;

            return ExecuteTable("SPSelFIDOStatusForAgentRpt", objp);
        }
        public DataTable GetCustomersupportallTaskDashBord(string Bid, string trantype, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
    new SqlParameter ("@bid",SqlDbType.VarChar,100),
    new SqlParameter("@trantype", SqlDbType.VarChar,100) ,
     new SqlParameter ("@EmployeeId",SqlDbType.Int),
            };
            objp[0].Value = Bid;
            objp[1].Value = trantype;
            objp[2].Value = empid;

            return ExecuteTable("SPCustomersupportallTaskDashbord", objp);
        }
        public DataTable SelAICANRpt(string hawblno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@hawblno",SqlDbType.VarChar,30),
                new SqlParameter("@bid", SqlDbType.Int)
            };
            objp[0].Value = hawblno;
            objp[1].Value = bid;

            return ExecuteTable("SPSelAICANRpt", objp);
        }

        public DataTable Seljobinfo(int? jobno, int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter ("@trantype",SqlDbType.VarChar,30),
                new SqlParameter("@jobno", SqlDbType.Int)
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = jobno;

            return ExecuteTable("SPSeljobinfo", objp);
        }

        public DataTable Seljobinfo(int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter ("@trantype",SqlDbType.VarChar,30)
            };
            objp[0].Value = bid;
            objp[1].Value = trantype;

            return ExecuteTable("SPSeljobinfo", objp);
        }

        public DataTable SelAEJobdetails(int jobno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                               new SqlParameter("@bid",SqlDbType.Int)

            };
            objp[0].Value = jobno;
            objp[1].Value = bid;

            return ExecuteTable("SPSelAEJobdetails", objp);
        }
        public DataTable GetMBLDetails4Rpt(int jobno, int bid)
        {
            SqlParameter[] array = new SqlParameter[2]
            {
            new SqlParameter("@jobno", SqlDbType.Int),
            new SqlParameter("@bid", SqlDbType.Int)
            };
            array[0].Value = jobno;
            array[1].Value = bid;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPGetMBLDetails4Rpt", parameters);
        }

    }

}

