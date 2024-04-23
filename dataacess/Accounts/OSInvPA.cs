using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class OSInvPA : DBObject
    {
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterEmployee EmpObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public OSInvPA()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetAllJobs(int jobno, string strTranType,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelAllJobs", objp);
        }

        public void InsertInvPAHead(int ipno, DateTime ipdate, string strTranType, int jobno, int customerid, string remarks, int branchid, int preparedby, int vouyear, string curr, double exrate, string ftype, string refno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ipno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@ipdate",SqlDbType.SmallDateTime,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                      new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@exrate",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,25)};
            objp[0].Value = ipno;
            objp[1].Value = ipdate;
            objp[2].Value = strTranType;
            objp[3].Value = jobno;
            objp[4].Value = customerid;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = preparedby;
            objp[8].Value = vouyear;
            objp[9].Value = curr;
            objp[10].Value = exrate;
            objp[11].Value = ftype;
            objp[12].Value = refno;
            ExecuteQuery("SPInsOSInvPAHead", objp);
        }

        public void UpdateInvPAHead(int ipno, string strTranType, int jobno, int customerid, string remarks, int branchid, int vouyear, string curr, double exrate, string ftype,string refno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ipno",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@exrate",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,25)};
            objp[0].Value = ipno;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = customerid;
            objp[4].Value = remarks;
            objp[5].Value = branchid;
            objp[6].Value = vouyear;
            objp[7].Value = curr;
            objp[8].Value = exrate;
            objp[9].Value = ftype;
            objp[10].Value = refno;
            ExecuteQuery("SPUpdOSInvPAHead", objp);
        }
        public void InsOSInvPADetails(int jobno, string trantype, string blno, int intchargeid, double rate, double exrate, string cmbbase, double oamount, double famount, string ftype, int branchid, int vouyear, string remarks, int ipno)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@charges",SqlDbType.Int,4),
                                                         new SqlParameter("@famount",SqlDbType.Money,8),
                                                         new SqlParameter("@rate",SqlDbType.Money,8),
                                                         new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                         new SqlParameter("@base",SqlDbType.VarChar,6),
                                                         new SqlParameter("@oamount",SqlDbType.Money,8),
                                                         new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                         new SqlParameter("@vouyear", SqlDbType.Int),
                                                         new SqlParameter("@ipno", SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = famount;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = oamount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = vouyear;
            objp[13].Value = ipno;
            ExecuteQuery("SPInsOSInvPADetails", objp);
        }
        public void UpdOSInvPADetails(int jobno, string trantype, string blno, int intchargeid, double rate, double exrate, string cmbbase, double oamount, double famount, string ftype, int branchid, int vouyear, string remarks, int ipno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4), 
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@charges",SqlDbType.Int,4),
                                                     new SqlParameter("@famount",SqlDbType.Money,8),
                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                     new SqlParameter("@exrate",SqlDbType.Money,8), 
                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                     new SqlParameter("@oamount",SqlDbType.Money,8),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                    new SqlParameter("@branchid",SqlDbType.Int,4),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                    new SqlParameter("@vouyear", SqlDbType.Int),
                                                    new SqlParameter("@ipno", SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = blno;
            objp[3].Value = intchargeid;
            objp[4].Value = famount;
            objp[5].Value = rate;
            objp[6].Value = exrate;
            objp[7].Value = cmbbase;
            objp[8].Value = oamount;
            objp[9].Value = ftype;
            objp[10].Value = branchid;
            objp[11].Value = remarks;
            objp[12].Value = vouyear;
            objp[13].Value = ipno;
            ExecuteQuery("SPUpdOSInvPADetails", objp);
        }
        
        public int GetOSInvNo(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCOSInv", objp));
        }
        //to generate the OS PA number
        public int GetOSPANo(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCOSPANo", objp));
        }
        public int GetOSInvPAChargescount(string blno, int intchargeid, string ftype, int ipno, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                                           new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@ipno", SqlDbType.Int,4),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@vouyear", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = intchargeid;
            objp[2].Value = ftype;
            objp[3].Value = ipno;
            objp[4].Value = branchid;
            objp[5].Value = vouyear;
            return int.Parse(ExecuteReader("SPOSInvPACountchrgs", objp));
        }
        public int GetOSInvPABasecount(string blno,int intchargeid, string ftype, int ipno, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                                           new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@ipno", SqlDbType.Int,4),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@vouyear", SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = intchargeid;
            objp[2].Value = ftype;
            objp[3].Value = ipno;
            objp[4].Value = branchid;
            objp[5].Value = vouyear;
            return int.Parse(ExecuteReader("SPOSInvPACountBase", objp));
        }

        //used to fill the invoice details in the form when invoiceno given
        public DataTable GetOSinvPADetails(int ipno, string ftype, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ipno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,20), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1) };
            objp[0].Value = ipno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelOSInvPADetails", objp);
        }
        public DataTable ShowOSIPHead(int ipno, string strantype, string ftype, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ipno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),  
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = ipno;
            objp[1].Value = strantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            return ExecuteTable("SPSelOSIPHead", objp);
        }
        public DataTable ShowOSIPHead4Jobno(int jobno, string strantype, string ftype, int vouyear, int branchid,int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),  
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1), 
                                                                            new SqlParameter("@customerid", SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = strantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = customerid;
            return ExecuteTable("SPSelOSIPHead4JobNo", objp);
        }
        public void DelIPDetails(int ipno, int intcharge, string strbase, string ftype, int jobno, int vouyear, int branchid, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@ipno",SqlDbType.Int,4),  
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                             new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                           new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                           new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                                           new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                                            new SqlParameter("@blno",SqlDbType.VarChar,30)};
            objp[0].Value = ipno;
            objp[1].Value = intcharge;
            objp[2].Value = strbase;
            objp[3].Value = ftype;
            objp[4].Value = jobno;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = trantype;
            objp[8].Value = blno;
            ExecuteQuery("SPDelOSInvPADetails", objp);
        }
    }
}
