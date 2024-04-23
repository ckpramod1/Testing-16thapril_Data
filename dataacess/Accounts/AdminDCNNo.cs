using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class AdminDCNNo : DBObject
    {
        //to generate the AdmDN number

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public AdminDCNNo()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int GetAdmDNno(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCAdmdnno", objp));
        }
        //to generate the AdmCN number
        public int GetAdmCNno(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCAdmcnno", objp));
        }
        public string CheckBillType(string strbilltype)
        {
            switch (strbilltype)
            {
                case ("Cash/Cheque"):
                    return "C";

                case ("Credit"):
                    return "D";

                case ("Internal"):
                    return "I";

                default:
                    return "X";
            }
        }

        //----------------------------------------------------------------------------------------------
        public String GetBillType(char strbilltype)
        {
            switch (strbilltype)
            {
                case 'C':
                    return "Cash/Cheque";

                case 'D':
                    return "Credit";

                case 'I':
                    return "Internal";

                default:
                    return "Invalid";
            }
        }
        public void InsertDCNHead(int dnno, DateTime Dtdate, int customerid, string refno, string remarks, int branchid, string strbilltype, int preparedby, string ftype, int vouyear)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@dndate",SqlDbType.DateTime,8), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2)};
            objp[0].Value = dnno;
            objp[1].Value = Dtdate;
            objp[2].Value = customerid;
            objp[3].Value = refno;
            objp[4].Value = remarks;
            objp[5].Value = branchid;
            objp[6].Value = billtype;
            objp[7].Value = preparedby;
            objp[8].Value = vouyear;
            objp[9].Value = ftype;
            ExecuteQuery("SPInsAdminDCNHead", objp);
        }
        public void UpdDCNHead(int dnno, int customerid, string remarks, int branchid, string strbilltype, string ftype, int vouyear,string refno)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30)};
            objp[0].Value = dnno;
            objp[1].Value = customerid;
            objp[2].Value = remarks;
            objp[3].Value = branchid;
            objp[4].Value = billtype;
            objp[5].Value = vouyear;
            objp[6].Value = ftype;
            objp[7].Value = refno;
            ExecuteQuery("SPUpdAdminDCNHead", objp);
        }
        public void InsertAdminDCNDetails(int dnno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, string ftype, int vouyear, string strbilltype,string servicetax)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@servicetax",SqlDbType.Char,1)};
            objp[0].Value = dnno;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = exrate;
            objp[5].Value = strbase;
            objp[6].Value = famount;
            objp[7].Value = branchid;
            objp[8].Value = ftype;
            objp[9].Value = vouyear;
            objp[10].Value = billtype;
            objp[11].Value = servicetax;
            ExecuteQuery("SPInsAdminDCNDetails", objp);
        }
        public void UpdAdminDCNDetails(int dnno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, string ftype, int vouyear, string oldbase)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,6)};
            objp[0].Value = dnno;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = exrate;
            objp[5].Value = strbase;
            objp[6].Value = famount;
            objp[7].Value = branchid;
            objp[8].Value = ftype;
            objp[9].Value = vouyear;
            objp[10].Value = oldbase;
            ExecuteQuery("SPUpdAdminDCNDetails", objp);
        }
        public void DelAdminDCNDetails(int dnno, int chargeid, string strbase, int branchid, string ftype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = dnno;
            objp[1].Value = chargeid;
            objp[2].Value = strbase;
            objp[3].Value = branchid;
            objp[4].Value = ftype;
            objp[5].Value = vouyear;
            ExecuteQuery("SPDelAdminDCNDetails", objp);
        }
        public DataTable ShowAdminDCNHeadFromDCNNo(int dnno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelAdminDCNHeadFromDCNNo", objp);
        }
        public DataTable ShowAdminDCNHeadFromRefNo(string refno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.VarChar,30), 
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = refno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelAdminDCNHeadFromRefNo", objp);
        }
        public DataTable GetAdminDCNDetails(int dnno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetAdminDCNDetails", objp);
        }
        public DataTable GetApproveAdminDCN(string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            return ExecuteTable("SPApproveAdmDCN", objp);
        }
        public void UpdApprovalAdminDCN(int dnno, int approvedby, string ftype, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),    
                                                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = dnno;
            objp[1].Value = approvedby;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            ExecuteQuery("SPUpdApprovalAdminDCN", objp);
        }

        //Manoj
        public DataTable GetAdminDCNDetailswithCust(int dnno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetAdminDCNDetailswithCust", objp);
        }

        //raj for service Tax

        public int GetAdmDNnonew(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCAdmdnnonew", objp));
        } 



        //MUTHU

        public DataTable Getsp_BRRpt(int empid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
            };

            objp[0].Value = empid;

            return ExecuteTable("sp_BRRpt", objp);
        }
        public DataTable Getsp_BPRpt(int empid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
            };

            objp[0].Value = empid;

            return ExecuteTable("SP_BPRpt", objp);
        }
        public DataTable getSP_BROverseas(int empid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
            };

            objp[0].Value = empid;

            return ExecuteTable("SP_BROverseas", objp);
        }
        public DataTable GetSP_BPOverseas(int empid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
            };

            objp[0].Value = empid;

            return ExecuteTable("SP_BPOverseas", objp);
        }
        public DataTable getsp_BRRptbrach(int empid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
              new SqlParameter("@branchid",SqlDbType.Int),
            };

            objp[0].Value = empid;
            objp[1].Value = branchid;

            return ExecuteTable("sp_BRRptbrach", objp);
        }
        public DataTable GetSP_BPRrptbranch(int empid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
              new SqlParameter("@branchid",SqlDbType.Int),
            };

            objp[0].Value = empid;
            objp[1].Value = branchid;

            return ExecuteTable("SP_BPRrptbranch", objp);
        }
        public DataTable GetSP_BROverseasbranch(int empid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
              new SqlParameter("@branchid",SqlDbType.Int),
            };

            objp[0].Value = empid;
            objp[1].Value = branchid;

            return ExecuteTable("SP_BROverseasbranch", objp);
        }
        public DataTable GetSP_BPOverseasbranch(int empid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
              new SqlParameter("@empid",SqlDbType.Int),
              new SqlParameter("@branchid",SqlDbType.Int),
            };

            objp[0].Value = empid;
            objp[1].Value = branchid;

            return ExecuteTable("SP_BPOverseasbranch", objp);
        }

        public int GetAdmCNnonew(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCAdmcnnonew", objp));
        }


        public int GetAdmDNno_backdated(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCAdmdnno_backdated", objp));
        }


        public int GetAdmCNno_backdated(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCAdmcnno_backdated", objp));
        }
        public int GetAdmvounoCOM(int branchid,int type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@type", SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = type;
            return int.Parse(ExecuteReader("SPUpdMCAdmvounoCOM", objp));
        }
        public DataTable ShowAdminDCNHeadFromDCNNoCOM(int dnno, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@ftype",SqlDbType.Int), 
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelAdminDCNHeadFromDCNNoCOM", objp);
        }
        public DataTable GetAdminDCNDetailsCOM(int dnno, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.Int), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetAdminDCNDetailsCOM", objp);
        }
        public DataTable GetAdminDCNDetailswithCustCOM(int dnno, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.Int), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetAdminDCNDetailswithCustCOM", objp);
        }
    }
}
