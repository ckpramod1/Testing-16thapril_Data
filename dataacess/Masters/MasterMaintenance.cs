using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
    public class MasterMaintenance:DBObject 
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterMaintenance()
        {
            Conn = new SqlConnection(DBCS);
        }

        public string  InsMasterMaintenance(char tickettype,string tickethead,string ticketdetails,int Requestedby,DateTime Requestedon,string location)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tickettype",SqlDbType.Char,1),
                                                       new SqlParameter("@tickethead", SqlDbType.VarChar,50),
                                                       new SqlParameter("@ticketdetails", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@requestedby ", SqlDbType.Int),
                                                       new SqlParameter("@reqdate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@ticketcode",SqlDbType.VarChar,25),
                                                       new SqlParameter("@location",SqlDbType.VarChar,3)};
            objp[0].Value =tickettype;
            objp[1].Value = tickethead;
            objp[2].Value = ticketdetails;
            objp[3].Value = Requestedby;
            objp[4].Value = Requestedon;
            objp[5].Direction = ParameterDirection.Output;
            objp[6].Value = location;
            return ExecuteQuery("SPInsMasterMaintenance", "@ticketcode", objp);

        }
        public void  UpdMasterMaintenance(char tickettype,string tickethead,string ticketdetails,int Requestedby,DateTime Requestedon,string ticketcode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tickettype",SqlDbType.Char,1),
                                                       new SqlParameter("@tickethead", SqlDbType.VarChar,50),
                                                       new SqlParameter("@ticketdetails", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@requestedby ", SqlDbType.Int),
                                                       new SqlParameter("@reqdate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@ticketcode",SqlDbType.VarChar,25)};
            objp[0].Value = tickettype;
            objp[1].Value = tickethead;
            objp[2].Value = ticketdetails;
            objp[3].Value = Requestedby;
            objp[4].Value = Requestedon;
            objp[5].Value = ticketcode;
            ExecuteQuery("SPUpdMasterMaintenance", objp);
            
        }

        public DataTable SelMasterMaintenance(string ticketcode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ticketcode", SqlDbType.VarChar, 25) };
            objp[0].Value = ticketcode;
            return ExecuteTable("SPSelMasterMaintenance", objp);
        }
        public DataTable GetLikeTicketcode(string Ticketcode, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ticketcode", SqlDbType.VarChar, 25),
                                                       new SqlParameter("@requestedby", SqlDbType.Int) };
            objp[0].Value = Ticketcode;
            objp[1].Value = empid;
            return ExecuteTable("SPLikeTicketcode", objp);
        }
        public DataTable GetDetails4TicketApproval()
        {
            return ExecuteTable("SPSelDetails4ticketApproval");
        }
        public DataTable GetFrontNews()
        {
            return ExecuteTable("SPGetFrontNews");
        }
        public void UpdTicketApproval(int approvedby, DateTime approvedon, int allotedto, DateTime etd, string ticketcode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@approvedby",SqlDbType.Int),
                                                       new SqlParameter("@approvedon", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@allotedto", SqlDbType.Int),
                                                       new SqlParameter("@etd", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@ticketcode",SqlDbType.VarChar,25)};
            objp[0].Value = approvedby;
            objp[1].Value = approvedon;
            objp[2].Value = allotedto;
            objp[3].Value = etd;
            objp[4].Value = ticketcode;
            ExecuteQuery("SPUpdTicketApproval", objp);

        }
        public DataTable GetDetails4TicketConfirmation(char ticketstatus)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ticketstatus",SqlDbType.Char,1) };
            objp[0].Value = ticketstatus;
            return ExecuteTable("SPSelDetails4ticketConfirmation", objp);
        }
        
        public void UpdTicketConfirmation(int confirmedby, DateTime confirmedon, int completedby, DateTime atd, string ticketcode,string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@confirmedby",SqlDbType.Int),
                                                       new SqlParameter("@confirmedon", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@completedby", SqlDbType.Int),
                                                       new SqlParameter("@atd", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@ticketcode",SqlDbType.VarChar,25),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,100) };
            objp[0].Value =confirmedby;
            objp[1].Value = confirmedon;
            objp[2].Value = completedby;
            objp[3].Value = atd;
            objp[4].Value = ticketcode;
            objp[5].Value=remarks;
            ExecuteQuery("SPUpdTicketConfirmation", objp);

        }
        public DataTable GetFinishedRequirements(char ticketstatus,DateTime confirmdate)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ticketstatus",SqlDbType.Char,1),
                                                       new SqlParameter("@confirmedon", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = ticketstatus; 
            objp[1].Value = confirmdate;
            return ExecuteTable("SPGetFinishedMaint", objp);
        }
        public void UpdTicketRejected(string ticketcode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ticketcode", SqlDbType.VarChar, 25) };

            objp[0].Value = ticketcode;

            ExecuteQuery("SPUpdRejected", objp);

        }



        //FOR ISP COMPLAINTS TABLE(HARDWARE COMPLAINTS)
        public string InsertISPComplaints(string ticketid, DateTime ticketdate, string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@ticketid",SqlDbType.VarChar,30),
                                                         new SqlParameter("@ticketdate",SqlDbType.DateTime,8),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,100)
                                                     };
            objp[0].Value = ticketid;
            objp[1].Value = ticketdate;
            objp[2].Value = remarks;
            return ExecuteReader("SPInsISPComplaints", objp);
        }

        public void UpdateISPComplaints(string ticketid, DateTime ticketdate, string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@ticketid",SqlDbType.VarChar,30),
                                                         new SqlParameter("@ticketdate",SqlDbType.DateTime,8),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,100)
                                                     };
            objp[0].Value = ticketid;
            objp[1].Value = ticketdate;
            objp[2].Value = remarks;
            ExecuteQuery("SPUpdISPComplaints", objp);
        }

        public DataTable SelISPComplaints(string ticketid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@ticketid",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = ticketid;
            return ExecuteTable("SPSelISPComplaints", objp);
        }
        
        public DataSet SelISPComplaintsByStatus()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@temp",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = "aaa";
            return ExecuteDataSet("SPSelAllISPComplaints", objp);
        }

        //Manoj - New Ticket
        public string InsMasterTicket(char tickettype, string module, int screen, string requirement, string Details, int reqby, DateTime reqdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tickettype",SqlDbType.Char,1),
                                                       new SqlParameter("@module", SqlDbType.Char,2),
                                                       new SqlParameter("@screen", SqlDbType.Int),
                                                       new SqlParameter("@requirement", SqlDbType.VarChar,100),
                                                       new SqlParameter("@details", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@reqby",SqlDbType.Int),
                                                       new SqlParameter("@reqdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@ticketid",SqlDbType.Int)};
            objp[0].Value = tickettype;
            objp[1].Value = module;
            objp[2].Value = screen;
            objp[3].Value = requirement;
            objp[4].Value = Details;
            objp[5].Value = reqby;
            objp[6].Value = reqdate;
            objp[7].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsMasterTicket", "@ticketid", objp);
        }

        public void UpdMasterTicket(char tickettype, string module, int screen, string requirement, string Details, int reqby, DateTime reqdate, int ticketid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@tickettype",SqlDbType.Char,1),
                                                       new SqlParameter("@module", SqlDbType.Char,2),
                                                       new SqlParameter("@screen", SqlDbType.Int),
                                                       new SqlParameter("@requirement", SqlDbType.VarChar,100),
                                                       new SqlParameter("@details", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@reqby",SqlDbType.Int),
                                                       new SqlParameter("@reqdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@ticketid",SqlDbType.Int)};
            objp[0].Value = tickettype;
            objp[1].Value = module;
            objp[2].Value = screen;
            objp[3].Value = requirement;
            objp[4].Value = Details;
            objp[5].Value = reqby;
            objp[6].Value = reqdate;
            objp[7].Value = ticketid;
            ExecuteQuery("SPUpdMasterTicket", objp);
        }

        public DataTable getMasterTicket(int ticketid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@ticketid",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4)
            };
            objp[0].Value = ticketid;
            objp[1].Value = empid;
            return ExecuteTable("spgetticketdetails", objp);
        }

        public DataTable getMasterTicketForRecommend(int ticketid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@ticketid",SqlDbType.Int,4)};
            objp[0].Value = ticketid;
            return ExecuteTable("spgetticketdetailsForRecommend", objp);
        }

        public DataTable Getrecommdtlsforticket(int ticketid, int empid, string func)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@ticketid",SqlDbType.Int,4),
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@func",SqlDbType.Char,1)
            };
            objp[0].Value = ticketid;
            objp[1].Value = empid;
            objp[2].Value = func;
            return ExecuteTable("SPGetRecommendDtlsForTicket", objp);
        }

        public void UpdMasterTicketForRecommend(int recby, DateTime recdate, string reccmts, string recstatus, int ticketid)
        {
            SqlParameter[] objp = new SqlParameter[] {  
                                                         new SqlParameter("@recby", SqlDbType.Int,4),
                                                         new SqlParameter("@recdate", SqlDbType.SmallDateTime),
                                                         new SqlParameter("@reccmts", SqlDbType.VarChar,1000),
                                                         new SqlParameter("@recstatus", SqlDbType.Char,1),
                                                         new SqlParameter("@ticketid",SqlDbType.Int,4)
                                                       };
            objp[0].Value = recby;
            objp[1].Value = recdate;
            objp[2].Value = reccmts;
            objp[3].Value = recstatus;
            objp[4].Value = ticketid;
            ExecuteQuery("SPUPDRecommendDtlsForTicket", objp);
        }

        public DataTable GetTicketDtlsForGrd(int branchid, int divisionid, string func)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@divisionid",SqlDbType.Int,4),
                new SqlParameter("@func",SqlDbType.Char,1)
            };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = func;
            return ExecuteTable("SPGetTicketDtlsForGrd", objp);
        }

        public void UpdMasterTicketForApproval(int recby, DateTime recdate, string reccmts, string recstatus, int ticketid)
        {
            SqlParameter[] objp = new SqlParameter[] {  
                                                         new SqlParameter("@recby", SqlDbType.Int,4),
                                                         new SqlParameter("@recdate", SqlDbType.SmallDateTime),
                                                         new SqlParameter("@reccmts", SqlDbType.VarChar,1000),
                                                         new SqlParameter("@recstatus", SqlDbType.Char,1),
                                                         new SqlParameter("@ticketid",SqlDbType.Int,4)
                                                       };
            objp[0].Value = recby;
            objp[1].Value = recdate;
            objp[2].Value = reccmts;
            objp[3].Value = recstatus;
            objp[4].Value = ticketid;
            ExecuteQuery("SPUPDApprovedDtlsForTicket", objp);
        }
        //masterincoterm
        public DataTable GetIncoCode(string ICode)
        {
            SqlParameter[] objp = new SqlParameter[] 
             {                
                 new SqlParameter("@ICode",SqlDbType.VarChar,5),
             };
            objp[0].Value = ICode;
            return ExecuteTable("GetIncocode", objp);
        }
        public void InsertIncoDetails(string ICode, string IDesn)
        {
            SqlParameter[] objp = new SqlParameter[] 
             {
                    new SqlParameter("@ICode",SqlDbType.VarChar,5),      
                    new SqlParameter("@IDescn",SqlDbType.VarChar,50)
             };
            objp[0].Value = ICode;
            objp[1].Value = IDesn;
            ExecuteQuery("InsIncoDetails", objp);
        }
        public void UpdateIncoDetails(string ICode, string IDesn, int ID)
        {
            SqlParameter[] objp = new SqlParameter[] 
             {
                    new SqlParameter("@ICode",SqlDbType.VarChar,5),      
                    new SqlParameter("@IDescn",SqlDbType.VarChar,50),
                    new SqlParameter("@ID",SqlDbType.Int)
             };
            objp[0].Value = ICode;
            objp[1].Value = IDesn;
            objp[2].Value = ID;
            ExecuteQuery("UpdateIncoDetails", objp);
        }
        public DataTable GetIncogrid()
        {

            return ExecuteTable("GetIncogrid");
        }
        public string GetIncoDescn(int ID)
        {
            SqlParameter[] objp = new SqlParameter[] 
             {                
                 new SqlParameter("@ID",SqlDbType.Int)
             };
            objp[0].Value = ID;
            return ExecuteReader("GetIncoDescn", objp);
        }

    }
}
