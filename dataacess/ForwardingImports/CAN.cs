using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
   public class CAN:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CAN()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetDetails(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("SPSelFICAN", objp);
       }





       //Kumar
       public DataTable GetDetailsNew(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("SPSelFICANNew", objp);
       }




       public DataTable ShowCANDetails(int intBranchID, int intDivisionID, int jobno)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           objp[2].Value = jobno;
           return ExecuteTable("SPSelFICANDetails", objp);
       }




       public void UpdateCANDate(DateTime candate, int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@candate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                   };
           objp[0].Value = jobno;
           objp[1].Value = candate;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           ExecuteQuery("SPUpdFICANDate", objp);
       }


       public bool CheckBLDetails(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           Dt = ExecuteTable("SPSelFICANBL", objp);
           if (Dt.Rows.Count == 0)
               return false;
           else
               return true;
       }


       public DataTable GetBLDetails(int jobno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@trantype",SqlDbType.Char,2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelFIEBLJobno",objp);
        }

       //MUTHURAJ
       public DataTable GetDetailsfinalnotice(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("SPSelFICANfinalnotice", objp);
       }
       public DataTable GetDetailsremindernotice(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("SPSelFICANremindernotice", objp);
       }
       public DataTable GetDetailsfinalnoticecount(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("SPSelFICANfinalnoticeCOUNT", objp);
       }
       public DataTable GetDetailsremindernoticecount(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("SPSelFICANremindernoticecount", objp);
       }



    }
}
