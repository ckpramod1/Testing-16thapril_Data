using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class ProAdminDCNNo:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ProAdminDCNNo()
        {
            Conn = new SqlConnection(DBCS);
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

        //KUMAR
        ////public int InsertProDCNHead( DateTime Dtdate, int customerid, string refno, string remarks, int branchid, string strbilltype, int preparedby, string ftype, int vouyear)
        ////{
        ////    string billtype = CheckBillType(strbilltype);
        ////    SqlParameter[] objp = new SqlParameter[] {       
        ////                                                                             new SqlParameter("@dndate",SqlDbType.DateTime,8), 
        ////                                                                             new SqlParameter("@customerid",SqlDbType.Int,4),
        ////                                                                             new SqlParameter("@refno",SqlDbType.VarChar,30),
        ////                                                                             new SqlParameter("@remarks",SqlDbType.VarChar,150), 
        ////                                                                             new SqlParameter("@branchid",SqlDbType.TinyInt,1),
        ////                                                                             new SqlParameter("@billtype",SqlDbType.VarChar,1),
        ////                                                                             new SqlParameter("@preparedby",SqlDbType.Int,4),
        ////                                                                             new SqlParameter("@vouyear",SqlDbType.Int),
        ////                                                                             new SqlParameter("@ftype",SqlDbType.VarChar,2),
        ////     new SqlParameter("@prorefno",SqlDbType.Int,4)};
  
        ////    objp[0].Value = Dtdate;
        ////    objp[1].Value = customerid;
        ////    objp[2].Value = refno;
        ////    objp[3].Value = remarks;
        ////    objp[4].Value = branchid;
        ////    objp[5].Value = billtype;
        ////    objp[6].Value = preparedby;
        ////    objp[7].Value = vouyear;
        ////    objp[8].Value = ftype;
        ////    objp[9].Direction =ParameterDirection.Output ;
        ////    return ExecuteQuery("SPProInsAdminDCNHead", objp, "@prorefno");
        ////}
      /*  public int InsertProDCNHead(DateTime Dtdate, int customerid, string refno, string remarks, int branchid, string strbilltype, int preparedby, string ftype, int vouyear, string vendorrefno, int creditdays)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {       
                                                                                     new SqlParameter("@dndate",SqlDbType.DateTime,8), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@prorefno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar ,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt )};

            objp[0].Value = Dtdate;
            objp[1].Value = customerid;
            objp[2].Value = refno;
            objp[3].Value = remarks;
            objp[4].Value = branchid;
            objp[5].Value = billtype;
            objp[6].Value = preparedby;
            objp[7].Value = vouyear;
            objp[8].Value = ftype;
            objp[9].Direction = ParameterDirection.Output;
            objp[10].Value = vendorrefno;
            objp[11].Value = creditdays;
            return ExecuteQuery("SPProInsAdminDCNHead", objp, "@prorefno");
        }*/

        //KUMAR
        ////public void UpdProDCNHead(int prorefno, int customerid, string remarks, int branchid, string strbilltype, string ftype, int vouyear, string refno)
        ////{
        ////    string billtype = CheckBillType(strbilltype);
        ////    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4), 
        ////                                                                             new SqlParameter("@customerid",SqlDbType.Int,4),
        ////                                                                             new SqlParameter("@remarks",SqlDbType.VarChar,150), 
        ////                                                                             new SqlParameter("@branchid",SqlDbType.TinyInt,1),
        ////                                                                             new SqlParameter("@billtype",SqlDbType.VarChar,1),
        ////                                                                             new SqlParameter("@vouyear",SqlDbType.Int),
        ////                                                                             new SqlParameter("@ftype",SqlDbType.VarChar,2),
        ////                                                                             new SqlParameter("@refno",SqlDbType.VarChar,30)};
        ////    objp[0].Value = prorefno;
        ////    objp[1].Value = customerid;
        ////    objp[2].Value = remarks;
        ////    objp[3].Value = branchid;
        ////    objp[4].Value = billtype;
        ////    objp[5].Value = vouyear;
        ////    objp[6].Value = ftype;
        ////    objp[7].Value = refno;
        ////    ExecuteQuery("SPUpdProAdminDCNHead", objp);
        ////}
       /* public void UpdProDCNHead(int prorefno, int customerid, string remarks, int branchid, string strbilltype, string ftype, int vouyear, string refno, string vendorrefno, int creditdays)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt )};
            objp[0].Value = prorefno;
            objp[1].Value = customerid;
            objp[2].Value = remarks;
            objp[3].Value = branchid;
            objp[4].Value = billtype;
            objp[5].Value = vouyear;
            objp[6].Value = ftype;
            objp[7].Value = refno;
            objp[8].Value = vendorrefno;
            objp[9].Value = creditdays;
            ExecuteQuery("SPUpdProAdminDCNHead", objp);
        }*/




        public void InsertProAdminDCNDetails(int prorefno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, string ftype, int vouyear, string strbilltype, string servicetax, string opstype)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4),        
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
                                                                                     new SqlParameter("@servicetax",SqlDbType.Char,1),
              new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
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
            objp[12].Value = opstype;
            ExecuteQuery("SPInsProAdminDCNDetails", objp);
        }
        public void UpdProAdminDCNDetails(int prorefno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, string ftype, int vouyear, string oldbase, string opstype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,6),
              new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
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
            objp[11].Value = opstype;
            ExecuteQuery("SPUpdProAdminDCNDetails", objp);
        }
        public DataTable GetProAdminDCNDetails(int prorefno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = prorefno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetProAdminDCNDetails", objp);
        }
        public void DelProAdminDCNDetails(int prorefno, int chargeid, string strbase, int branchid, string ftype, int vouyear, string opstype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
              new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
            objp[1].Value = chargeid;
            objp[2].Value = strbase;
            objp[3].Value = branchid;
            objp[4].Value = ftype;
            objp[5].Value = vouyear;
            objp[6].Value = opstype;
            ExecuteQuery("SPDelProAdminDCNDetails", objp);
        }
        public DataTable ShowProAdminDCNHeadFromDCNNo(int prorefno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = prorefno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelProAdminDCNHeadFromDCNNo", objp);
        }
        public DataTable GetApproveProAdminDCN(string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            return ExecuteTable("SPApproveProAdmDCN", objp);
        }

        public void UpdApprovalProAdminDCN(int dnno, int approvedby, string ftype, int vouyear, int branchid,int prorefno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),    
                                                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
            new SqlParameter("@prorefno",SqlDbType.Int,4)};
            objp[0].Value = dnno;
            objp[1].Value = approvedby;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = prorefno;
            ExecuteQuery("SPUpdApprovalProAdminDCN", objp);
        }
        public DataTable CheckApp4proadmin(string qtype, int branchid,int prorefno,int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qtype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
            new SqlParameter("@prorefno", SqlDbType.Int,4),
            new SqlParameter("@vouyear", SqlDbType.Int,4)};
            objp[0].Value = qtype;
            objp[1].Value = branchid;
            objp[2].Value = prorefno;
            objp[3].Value = vouyear;
            return ExecuteTable("spcheckproadminapprove", objp);
        }

        //Manoj\

        public void InsertProAdminDCNDetails4Cust(int prorefno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, string ftype, int vouyear, string strbilltype, string servicetax, string opstype)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4),        
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
                                                                                     new SqlParameter("@servicetax",SqlDbType.Char,1),
                                                                                     new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
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
            objp[12].Value = opstype;
            ExecuteQuery("SPInsProAdminDCNDetails4Customer", objp);
        }

        public DataTable GetProAdminDCNDetails4Cust(int prorefno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = prorefno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetProAdminDCNDetails4Cust", objp);
        }

        public void InsertTmpAdminDCNDtls(int prorefno, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4),         
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                    };
            objp[0].Value = prorefno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            ExecuteQuery("SPInstmpadmdndtlsforrpt", objp);
        }


        //ARUN
        public DataSet GetCoutForAdminOtherCnDn(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@branchid", SqlDbType.Int)
            };
            objp[0].Value = bid;
            return ExecuteDataSet("SPAdminCnDnCouns", objp);
        }


        //GST

        //Dinesh
        //GST

        public void UpdProDCNHead(int prorefno, int customerid, string remarks, int branchid, string strbilltype, string ftype, int vouyear, string refno, string vendorrefno, int creditdays, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),new SqlParameter("@supplyto",SqlDbType.Int,4)};
            objp[0].Value = prorefno;
            objp[1].Value = customerid;
            objp[2].Value = remarks;
            objp[3].Value = branchid;
            objp[4].Value = billtype;
            objp[5].Value = vouyear;
            objp[6].Value = ftype;
            objp[7].Value = refno;
            objp[8].Value = vendorrefno;
            objp[9].Value = creditdays;
            objp[10].Value = supplyto;
            ExecuteQuery("SPUpdProAdminDCNHead", objp);
        }


        public void UpdProDCNHeadnew(int prorefno, int customerid, string remarks, int branchid, string strbilltype, string ftype, int vouyear, string refno, string vendorrefno, int creditdays, int supplyto,DateTime vendorrefdate)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),new SqlParameter("@supplyto",SqlDbType.Int,4),
                                                                                       new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8)};
            objp[0].Value = prorefno;
            objp[1].Value = customerid;
            objp[2].Value = remarks;
            objp[3].Value = branchid;
            objp[4].Value = billtype;
            objp[5].Value = vouyear;
            objp[6].Value = ftype;
            objp[7].Value = refno;
            objp[8].Value = vendorrefno;
            objp[9].Value = creditdays;
            objp[10].Value = supplyto;
            objp[11].Value = vendorrefdate;
            ExecuteQuery("SPUpdProAdminDCNHead", objp);
        }



        //GST
        //Dinesh

        public int InsertProDCNHead(DateTime Dtdate, int customerid, string refno, string remarks, int branchid, string strbilltype, int preparedby, string ftype, int vouyear, string vendorrefno, int creditdays, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {       
                                                                                     new SqlParameter("@dndate",SqlDbType.DateTime,8), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@prorefno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar ,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),new SqlParameter("@supplyto",SqlDbType.Int,4)};

            objp[0].Value = Dtdate;
            objp[1].Value = customerid;
            objp[2].Value = refno;
            objp[3].Value = remarks;
            objp[4].Value = branchid;
            objp[5].Value = billtype;
            objp[6].Value = preparedby;
            objp[7].Value = vouyear;
            objp[8].Value = ftype;
            objp[9].Direction = ParameterDirection.Output;
            objp[10].Value = vendorrefno;
            objp[11].Value = creditdays;
            objp[12].Value = supplyto;
            return ExecuteQuery("SPProInsAdminDCNHead", objp, "@prorefno");
        }

        public int InsertProDCNHeadnew(DateTime Dtdate, int customerid, string refno, string remarks, int branchid, string strbilltype, int preparedby, string ftype, int vouyear, string vendorrefno, int creditdays, int supplyto, DateTime vendorrefdate)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {       
                                                                                     new SqlParameter("@dndate",SqlDbType.DateTime,8), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@prorefno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar ,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),new SqlParameter("@supplyto",SqlDbType.Int,4),
            new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8)};

            objp[0].Value = Dtdate;
            objp[1].Value = customerid;
            objp[2].Value = refno;
            objp[3].Value = remarks;
            objp[4].Value = branchid;
            objp[5].Value = billtype;
            objp[6].Value = preparedby;
            objp[7].Value = vouyear;
            objp[8].Value = ftype;
            objp[9].Direction = ParameterDirection.Output;
            objp[10].Value = vendorrefno;
            objp[11].Value = creditdays;
            objp[12].Value = supplyto;
            objp[13].Value = vendorrefdate;
            return ExecuteQuery("SPProInsAdminDCNHead", objp, "@prorefno");
        }

        //Raj for ServiceTax

        public void UpdApprovalProAdminDCNopsnew(int dnno, int approvedby, string ftype, int vouyear, int branchid, int prorefno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),
new SqlParameter("@approvedby",SqlDbType.Int,4),
new SqlParameter("@ftype",SqlDbType.VarChar,20),
new SqlParameter("@vouyear",SqlDbType.Int),
new SqlParameter("@branchid",SqlDbType.TinyInt,1),
            new SqlParameter("@prorefno",SqlDbType.Int,4)};
            objp[0].Value = dnno;
            objp[1].Value = approvedby;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = prorefno;
            ExecuteQuery("SPUpdApprovalProAdminDCNopsnew", objp);
        }


        //Dinesh

        public DataTable GetApproveProAdminDCNTDS(string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            return ExecuteTable("SPApproveProAdmDCNTDS", objp);
        }

        public void UpdApprovalProAdminDCN_backdated(int dnno, int approvedby, string ftype, int vouyear, int branchid, int prorefno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),    
                                                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
            new SqlParameter("@prorefno",SqlDbType.Int,4)};
            objp[0].Value = dnno;
            objp[1].Value = approvedby;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = prorefno;
            ExecuteQuery("SPUpdApprovalProAdminDCN_backdatedGST", objp);
        }

        //NewOne    //08/08/2022
        public DataTable GetApproveProAdminDCNTDSNewOne(string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            return ExecuteTable("SPApproveProAdmDCNTDSNewOne", objp);
        }

        public int InsertProAdminvouHead(DateTime Dtdate, int customerid, string refno, string remarks, int branchid, string strbilltype, int preparedby, int ftype, int vouyear, string vendorrefno, int creditdays, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {       
                                                                                     new SqlParameter("@dndate",SqlDbType.DateTime,8), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@prorefno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar ,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),new SqlParameter("@supplyto",SqlDbType.Int,4)};

            objp[0].Value = Dtdate;
            objp[1].Value = customerid;
            objp[2].Value = refno;
            objp[3].Value = remarks;
            objp[4].Value = branchid;
            objp[5].Value = billtype;
            objp[6].Value = preparedby;
            objp[7].Value = vouyear;
            objp[8].Value = ftype;
            objp[9].Direction = ParameterDirection.Output;
            objp[10].Value = vendorrefno;
            objp[11].Value = creditdays;
            objp[12].Value = supplyto;
            return ExecuteQuery("SPProInsAdminvoucherHead", objp, "@prorefno");
        }
        public DataTable CheckApp4proadminvouchers(string qtype, int branchid, int prorefno, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qtype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
            new SqlParameter("@prorefno", SqlDbType.Int,4),
            new SqlParameter("@vouyear", SqlDbType.Int,4)};
            objp[0].Value = qtype;
            objp[1].Value = branchid;
            objp[2].Value = prorefno;
            objp[3].Value = vouyear;
            return ExecuteTable("spcheckproadminapprove", objp);
        }
        public void UpdProDCNHeadvouchers(int prorefno, int customerid, string remarks, int branchid, string strbilltype, int ftype, int vouyear, string refno, string vendorrefno, int creditdays, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@refno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),new SqlParameter("@supplyto",SqlDbType.Int,4)};
            objp[0].Value = prorefno;
            objp[1].Value = customerid;
            objp[2].Value = remarks;
            objp[3].Value = branchid;
            objp[4].Value = billtype;
            objp[5].Value = vouyear;
            objp[6].Value = ftype;
            objp[7].Value = refno;
            objp[8].Value = vendorrefno;
            objp[9].Value = creditdays;
            objp[10].Value = supplyto;
            ExecuteQuery("SPUpdProAdminDCNHeadvouchers", objp);
        }
        public void InsertProAdminDCNDetailsvouchers(int prorefno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, int ftype, int vouyear, string strbilltype, string servicetax, string opstype)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@servicetax",SqlDbType.Char,1),
              new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
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
            objp[12].Value = opstype;
            ExecuteQuery("SPInsProAdminDCNDetailsvouchers", objp);
        }
        public void InsertProAdminDCNDetails4Custvouchers(int prorefno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, int ftype, int vouyear, string strbilltype, string servicetax, string opstype)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@servicetax",SqlDbType.Char,1),
                                                                                     new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
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
            objp[12].Value = opstype;
            ExecuteQuery("SPInsProAdminDCNDetails4Customervouchers", objp);
        }
        public DataTable ShowProAdminDCNHeadFromDCNNovouchers(int prorefno, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@ftype",SqlDbType.Int), 
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = prorefno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelProAdminDCNHeadFromDCNNovouchers", objp);
        }
        public DataTable GetProAdminDCNDetailsvouchers(int prorefno, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.Int), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = prorefno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetProAdminDCNDetailsvouchers", objp);
        }
        public DataTable GetProAdminDCNDetails4Custvouchers(int prorefno, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dnno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.Int), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = prorefno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetProAdminDCNDetails4Custvouchers", objp);
        }
        public void UpdProAdminDCNDetailsvouchers(int prorefno, int chargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, int ftype, int vouyear, string oldbase, string opstype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@prorefno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,6),
              new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
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
            objp[11].Value = opstype;
            ExecuteQuery("SPUpdProAdminDCNDetailsvouchers", objp);
        }
        public DataTable GetApproveProAdminDCNCOM(int ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            return ExecuteTable("SPApproveProAdmDCNcom", objp);
        }
        public void UpdApprovalProAdminDCNCOM(int dnno, int approvedby, int ftype, int vouyear, int branchid, int prorefno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),    
                                                                                     new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
            new SqlParameter("@prorefno",SqlDbType.Int,4)};
            objp[0].Value = dnno;
            objp[1].Value = approvedby;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = prorefno;
            ExecuteQuery("SPUpdApprovalProAdminDCNCOM", objp);
        }
        public DataTable CheckApp4proadminvouchersCOM(string qtype, int branchid, int prorefno, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qtype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
            new SqlParameter("@prorefno", SqlDbType.Int,4),
            new SqlParameter("@vouyear", SqlDbType.Int,4)};
            objp[0].Value = qtype;
            objp[1].Value = branchid;
            objp[2].Value = prorefno;
            objp[3].Value = vouyear;
            return ExecuteTable("spcheckproadminapprovevouchers", objp);
        }
        public void DelProAdminDCNDetailsCOM(int prorefno, int chargeid, string strbase, int branchid, int ftype, int vouyear, string opstype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@charges",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
              new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = prorefno;
            objp[1].Value = chargeid;
            objp[2].Value = strbase;
            objp[3].Value = branchid;
            objp[4].Value = ftype;
            objp[5].Value = vouyear;
            objp[6].Value = opstype;
            ExecuteQuery("SPDelProAdminDCNDetailsCOM", objp);
        }
    }
}
