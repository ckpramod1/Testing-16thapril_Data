using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Complaints : DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Complaints()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetLikeComplaintDocNo(int customerid,string trantype,string reftype,int branchid,string DocNo)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@customerid",SqlDbType.Int,2),
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2 ),
                                                         new SqlParameter("@reftype",SqlDbType.Char,1 ),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1),        
                                                         new SqlParameter("@docno",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = customerid;
            objp[1].Value = trantype;
            objp[2].Value = reftype;
            objp[3].Value = branchid;
            objp[4].Value = DocNo;
            return ExecuteTable("SPLikeComplaintDocs", objp);
        }



        //For Registration Form
        public string InsertComplaints(int divisionid,int branchid,int customerid, string reftype,int comptype, string compdtls, int recdby, DateTime recdon, int recdmode,string docno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@divisionid",SqlDbType.TinyInt,1 ),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,1 ),
                                                         new SqlParameter("@customerid",SqlDbType.Int,4 ),
                                                         new SqlParameter("@reftype",SqlDbType.Char,1),        
                                                         new SqlParameter("@comptype",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@compdtls",SqlDbType.VarChar,500),
                                                         new SqlParameter("@recdby",SqlDbType.Int),
                                                         new SqlParameter("@recdon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@recdmode",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@docno",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = divisionid;
            objp[1].Value = branchid;
            objp[2].Value = customerid;
            objp[3].Value = reftype;
            objp[4].Value = comptype;
            objp[5].Value = compdtls;
            objp[6].Value = recdby;
            objp[7].Value = recdon;
            objp[8].Value = recdmode;
            objp[9].Value = docno;
            return ExecuteReader("SPInsComplaints", objp);
        }

        //For Registration Form
        public void UpdateComplaints(int divisionid, int branchid, int customerid, string reftype, string refno, int comptype, string compdtls, int recdby, DateTime recdon, int recdmode, int complaintid)
        {
                                                         SqlParameter[] objp = new SqlParameter[] 
                                                         {
                                                             new SqlParameter("@divisionid",SqlDbType.TinyInt,1 ),
                                                             new SqlParameter("@branchid",SqlDbType.TinyInt,1 ),
                                                             new SqlParameter("@customerid",SqlDbType.Int,4 ),
                                                             new SqlParameter("@reftype",SqlDbType.Char,1),        
                                                             new SqlParameter("@refno",SqlDbType.VarChar,15), 
                                                             new SqlParameter("@comptype",SqlDbType.TinyInt,1),
                                                             new SqlParameter("@compdtls",SqlDbType.VarChar,500),
                                                             new SqlParameter("@recdby",SqlDbType.Int),
                                                             new SqlParameter("@recdon",SqlDbType.SmallDateTime,4),
                                                             new SqlParameter("@recdmode",SqlDbType.TinyInt,1),
                                                             new SqlParameter("@complaintid",SqlDbType.Int,4 )
                                                         };
            objp[0].Value = divisionid;
            objp[1].Value = branchid;   
            objp[2].Value = customerid;
            objp[3].Value = reftype;
            objp[4].Value = refno;
            objp[5].Value = comptype;
            objp[6].Value = compdtls;
            objp[7].Value = recdby;
            objp[8].Value = recdon;
            objp[9].Value = recdmode;
            objp[10].Value = complaintid;
            ExecuteQuery("SPUpdComplaints", objp);
        }

        //For Registration Form
        public void DeleteComplaints(int compalintid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@complaintid",SqlDbType.Int,4 )
                                                    };
            objp[0].Value = compalintid;
            ExecuteQuery("SPDelComplaints", objp);
        }

        //For Registration Form
        public int GetComplaintID(string refno,int divisionid,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@refno", SqlDbType.VarChar, 15),
                                                           new SqlParameter("@divisionid", SqlDbType.TinyInt,1),
                                                           new SqlParameter("@branchid", SqlDbType.TinyInt,1) 
                                                     };
            objp[0].Value = refno;
            objp[1].Value = divisionid;
            objp[2].Value = branchid;
            return int.Parse(ExecuteReader("SPGetComplaintID", objp));
        }

        //For Registration Form Retrieve  Complaint Registartion Details   
        public DataTable RetrieveComplaintRegistartionDetails(int customerid, int branchid, int divisionid, string reftype, string refno)
        {
            int complaintid = GetComplaintID(refno,divisionid,branchid);
            SqlParameter[] objp = new SqlParameter[] 
                                                   {
                                                        new SqlParameter("@complaintid",SqlDbType.Int,4)
                                                   };

            objp[0].Value = complaintid;
            return ExecuteTable("SPSelComplaintRegDtls", objp);
        }

        public DataTable RetrieveComplaintRegistartionDtlsRefNo(string refno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   {
                                                        new SqlParameter("@refno",SqlDbType.VarChar,15)
                                                   };

            objp[0].Value = refno;
            return ExecuteTable("SPSelComplaintRegDtlsRefNo", objp);
        }

        //For Acknoledgemant Complaint Form to allot the complaints to employee  
        public void AllotComplaintsToEmployee(string refno,int updby, DateTime updon,DateTime compackon,int ackby,int allotedto,string allcommts,DateTime etc)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@refno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@updby",SqlDbType.Int,4 ),
                                                         new SqlParameter("@updon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@compackon",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@ackby",SqlDbType.Int ),
                                                         new SqlParameter("@allotedto",SqlDbType.Int),        
                                                         new SqlParameter("@allcommts",SqlDbType.VarChar,100),
                                                         new SqlParameter("@etc",SqlDbType.SmallDateTime,4)
                                                     };
            objp[0].Value = refno;
            objp[1].Value = updby;
            objp[2].Value = updon;
            objp[3].Value = compackon;
            objp[4].Value = ackby;
            objp[5].Value = allotedto;
            objp[6].Value = allcommts;
            objp[7].Value = etc;
            ExecuteQuery("SPAllotComplaints", objp);
        }

        public void CloseComplaints(string refno,DateTime atc,int compclosedby,string closcommts)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   {
                                                        new SqlParameter("@refno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@atc",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@compclosedby",SqlDbType.Int ),
                                                        new SqlParameter("@closcommts",SqlDbType.VarChar,100)
                                                   };

            objp[0].Value = refno;
            objp[1].Value = atc;
            objp[2].Value = compclosedby;
            objp[3].Value = closcommts;
            ExecuteQuery("SPCloseComplaints", objp);
        }


        //Get All Complaints Based On Status
        //If '0', Returns all opened Complaints only
        //If '1',Returns all Complaints
        public DataTable GetAllComplaints(int status)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   {
                                                      new SqlParameter("@status",SqlDbType.Int,4)
                                                   };
            objp[0].Value = status;
            return ExecuteTable("SPGetAllComplaints", objp);
        }
        public DataTable RetrieveComplaintRegistartionDtlsRefNo4web(string refno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   {
                                                        new SqlParameter("@refno",SqlDbType.VarChar,15)
                                                   };

            objp[0].Value = refno;
            return ExecuteTable("SPSelComplaintRegDtlsRefNo4web", objp);
        }
    }
}
