using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Accounts
{
    public class OSDNCN:DBObject 
    {
        DataAccess.Masters.MasterEmployee EmpObj = new DataAccess.Masters.MasterEmployee();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public OSDNCN()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetGirdFillQry(string strTranType,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = strTranType;
            objp[1].Value = branchid;
            return ExecuteTable("SPOSNJobdtls", objp);
        }
    
      public DataTable GetDCAmount(int jobno, string strTranType,string ftype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[]  { new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteTable("SPOSNDCSumAmnt", objp);
        }

        public DataTable GetOSDCNDtls(int jobno, string strTranType, string ftype, int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelOSDCNDtls", objp);
        }

        //new  10/29/2021

        public DataTable GetOSDCNDtls_new(int jobno, string strTranType, string ftype, int branchid,int dnno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
          new SqlParameter("@dnno",SqlDbType.Int,4)  };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = dnno;
            return ExecuteTable("SPSelOSDCNDtls_new", objp);
        }

        public int GetSalesID(string blno,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = branchid;
            return int.Parse(ExecuteReader("SPSelBookingSalPer", objp));
        }


        public int GetOSDCNnumber(int jobno, string strTranType, string ftype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return int.Parse(ExecuteReader("SPShowOSDCN", objp));
        }
        public string GetCurrOSDCN(int jobno, string strTranType, string ftype, int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteReader("SPGetCurrDCAdvise", objp);
        }

        public int GetDCNJobcount(int jobno, string strTranType, string ftype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return int.Parse(ExecuteReader("SPOSDCNJobCount", objp));
        }

        public int GetOSDCNno(string ftype,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ftype", SqlDbType.VarChar, 20),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCOSDCN", objp));
         }

        public void InsertOSDN(int dnno, DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear)
        {
            
             SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@dndate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customer",SqlDbType.Int,4),
                                                         new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = dnno;
            objp[1].Value = dndate;
            objp[2].Value = StrTranType;
            objp[3].Value = jobno;
            objp[4].Value = amount;
            objp[5].Value = branchid;
            objp[6].Value = customer;
            objp[7].Value = userid;
            objp[8].Value = vouyear;
            ExecuteQuery("SPInsOSDN", objp);
        }
        public void InsertOSCN(int cnno, DateTime cndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@cnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@cndate",SqlDbType.SmallDateTime,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customer",SqlDbType.Int,4),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = cnno;
            objp[1].Value = cndate;
            objp[2].Value = StrTranType;
            objp[3].Value = jobno;
            objp[4].Value = amount;
            objp[5].Value = branchid;
            objp[6].Value = customer;
            objp[7].Value = userid;
            objp[8].Value = vouyear;
            ExecuteQuery("SPInsOSCN", objp);
        }

        public void UpdateOSDCN(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, string ftype,int vouyear)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            ExecuteQuery("SPUpdOSDCN", objp);
        }

        public void DelOSDCN(int jobno, string strtrantype, string ftype,int vouyear,int branchid)
        {
            
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                           new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            ExecuteQuery("SPDelOSDCN", objp);
        }

        public DataTable RptOSDNCN(string strTranType, int dnno, int branchid, string ftype,int vouyear)
        {
            
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = dnno;
            objp[1].Value = branchid;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            return ExecuteTable("SPRptOSDCN", objp);
        }

        public DataSet RptOSDNCNFromJobNo(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteDataSet("SPRptOSDCNFromJobnoOSV", objp);
        }

        public DataTable RptOSDNCharges(int dncno, string strvtype, string strTranType, int vouyear,int branchid)
         {
             
             SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@ostype",SqlDbType.VarChar,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,2)};
             objp[0].Value = dncno;
             objp[1].Value = strvtype;
             objp[2].Value = strTranType;
             objp[3].Value = vouyear;
             objp[4].Value = branchid;
             return ExecuteTable("SPRptOSDNCharges", objp);
         }
        public DataTable RptOSCNCharges(int dncno, string strvtype, string strTranType, int vouyear, int branchid)
         {
             
             SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@cnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@ostype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,2)};
             objp[0].Value = dncno;
             objp[1].Value = strvtype;
             objp[2].Value = strTranType;
             objp[3].Value = vouyear;
             objp[4].Value = branchid;
             return ExecuteTable("SPRptOSCNCharges", objp);
         }
        public string GetPortCode(int branchid)
        {
            string portcode = "";
            //
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4)};
            objp[0].Value = branchid;
            //return ExecuteTable("SPGetPortCode", objp);
            Dt = ExecuteTable("SPGetPortCode", objp);
            if (Dt.Rows.Count > 0)
            {
                portcode = Dt.Rows[0].ItemArray[0].ToString();
            }
            return portcode;
        }
        public DataSet CheckOSDNCN(int intJobno, int intBranchID, string strTrantype)
        {
            SqlParameter[] objp = new SqlParameter[]  { new SqlParameter("@jobno",SqlDbType.Int,4) ,
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4) ,
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                      };
            objp[0].Value = intJobno;
            objp[1].Value = intBranchID;
            objp[2].Value = strTrantype;
            return ExecuteDataSet("SPCheckOSDNCN", objp);
        }
        public void InsOSDCNAnnexure(int intJobno, int intBranchID, string strTrantype,int intEmpID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4) ,
                                                                        new SqlParameter("@branchid", SqlDbType.TinyInt, 4) ,
                                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                        new SqlParameter("@empid", SqlDbType.Int, 4)
                                                                      };
            objp[0].Value = intJobno;
            objp[1].Value = intBranchID;
            objp[2].Value = strTrantype;
            objp[3].Value = intEmpID;
            ExecuteQuery("SPInsOSDCNAnnexureTemp", objp);
        }
        public DataTable GetOverseasVoucher(DateTime fromdate, DateTime todate, string voucher, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@fromdate",SqlDbType.DateTime,10),        
                                                         new SqlParameter("@todate",SqlDbType.DateTime,10), 
                                                         new SqlParameter("@voucher",SqlDbType.VarChar,30),
                                                         new SqlParameter("@branchid",SqlDbType.TinyInt,2)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;

            objp[2].Value = voucher;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetOverseasVouchers", objp);
        }

        //Nambi
        public DataTable GetOSDCNProDtls(int jobno, string strTranType, string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelOSDCNProDtls", objp);
        }
        public int GetOSDCNProJobCount(int jobno, string strTranType, string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return int.Parse(ExecuteReader("SPOSDCNProJobCount", objp));
        }
        public void InsertOSDNPro(DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno)
        {

            SqlParameter[] objp = new SqlParameter[] { // new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@dndate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customer",SqlDbType.Int,4),
                                                         new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                           new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),};
            //objp[0].Value = dnno;
            objp[0].Value = dndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            ExecuteQuery("SPInsOSDNPro", objp);
        }
        public void InsertOSCNPro(DateTime cndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno)
        {

            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@cnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@cndate",SqlDbType.SmallDateTime,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customer",SqlDbType.Int,4),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                      new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),};
            //objp[0].Value = cnno;
            objp[0].Value = cndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            ExecuteQuery("SPInsOSCNPro", objp);
        }
        public void UpdateOSDCNPro(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, string ftype, int vouyear, string vendorrefno)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),};
            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            objp[7].Value = vendorrefno;
            ExecuteQuery("SPUpdOSDCNPro", objp);
        }

        public void DelOSDCNPro(int jobno, string strtrantype, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                           new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            ExecuteQuery("SPDelOSDCNPro", objp);
        }
        public int GetOSDCNPronumber(int jobno, string strTranType, string ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return int.Parse(ExecuteReader("SPShowOSDCNPro", objp));
        }
        public DataSet RptOSDNCNProFromJobNo(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SPRptOSDCNProFromJobnoOSV", objp);
        }

        //Arun

        public DataSet RptOSDNCNProFromJobNoForNew(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SPRptOSDCNProFromJobnoForNew", objp);
        }
        //public DataTable getCheckosdncnrpr(string strTranType, int jobno, int branchid)
        //{

        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
        //                                                new SqlParameter("@trantype",SqlDbType.VarChar,4),
        //                                                new SqlParameter("@branchid",SqlDbType.Int,4),
        //   // new SqlParameter("@type",SqlDbType.VarChar,20),
        //    };
        //    objp[0].Value = jobno;
        //    objp[1].Value = strTranType;
        //    objp[2].Value = branchid;
        //    //objp[2].Value = ftype;
        //    return ExecuteTable("SpCheckosdncnrpr", objp);
        //}

        public DataTable GetCheckosdncnnew(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
           // return int.Parse(ExecuteReader("SpCheckosdncnnew", objp));
            return ExecuteTable("SpCheckosdncnnew", objp);
        }

        public DataTable GetIncoTemsVal(string bookingno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bookingno",SqlDbType.VarChar,100)

                                                       };
            objp[0].Value = bookingno;

            return ExecuteTable("SPRetriveIncode", objp);
        }


    /*    public void UpdateOSDCNProGst(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, string ftype, int vouyear, string vendorrefno, double act, int suopplyto)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                                                         new SqlParameter("@supplyto",SqlDbType.Int)};

            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            objp[7].Value = vendorrefno;
            objp[8].Value = act;
            objp[9].Value = suopplyto;
            ExecuteQuery("SPUpdOSDCNProGst", objp);
        }*/





    /*    public void InsertOSDNProForGst(DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, double act, int suopplyto)
        {

            SqlParameter[] objp = new SqlParameter[] { // new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@dndate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customer",SqlDbType.Int,4),
                                                         new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                           new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                            new SqlParameter("@actamt",SqlDbType.Money),
             new SqlParameter("@supplyto",SqlDbType.Int)};
            //objp[0].Value = dnno;
            objp[0].Value = dndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Value = act;
            objp[10].Value = suopplyto;
            ExecuteQuery("SPInsOSDNProForGst", objp);
        }

        public void InsertOSCNProGst(DateTime cndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, int suopplyto)
        {

            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@cnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@cndate",SqlDbType.SmallDateTime,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customer",SqlDbType.Int,4),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                      new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
             new SqlParameter("@supplyto",SqlDbType.Int)};
            //objp[0].Value = cnno;
            objp[0].Value = cndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Value = suopplyto;
            ExecuteQuery("SPInsOSCNProGst", objp);
        }
        */

        //public void UpdateOSDCNProGst(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, string ftype, int vouyear, string vendorrefno, double act, int suopplyto)
        //{

        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
        //                                                                            new SqlParameter("@amount",SqlDbType.Money,8), 
        //                                                                            new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
        //                                                                            new SqlParameter("@branchid",SqlDbType.Int,4),
        //                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
        //                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
        //                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
        //                                                                            new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
        //                                                                            new SqlParameter("@actamt",SqlDbType.Money),
        //                                                                                new SqlParameter("@supplyto",SqlDbType.Int)};

        //    objp[0].Value = intjobno;
        //    objp[1].Value = amount;
        //    objp[2].Value = dtdate;
        //    objp[3].Value = branchid;
        //    objp[4].Value = strTranType;
        //    objp[5].Value = ftype;
        //    objp[6].Value = vouyear;
        //    objp[7].Value = vendorrefno;
        //    objp[8].Value = act;
        //    objp[9].Value = suopplyto;
        //    ExecuteQuery("SPUpdOSDCNProGst", objp);
        //}



        //GST

        //ARUN

        public DataTable GetOSNDCSumAmntmultiple(int jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]  { new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;

            objp[2].Value = branchid;
            return ExecuteTable("SPOSNDCSumAmntmultiple", objp);
        }



        public DataTable RptOSDNCNProFromJobNoForNewForParticularRef(string strTranType, int jobno, int branchid, string type, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                                                      new SqlParameter("@refno",SqlDbType.Int)
           
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Value = refno;
            return ExecuteTable("SPRptOSDCNProFromJobnoRetriveDetails", objp);
        }
       /* public void UpdateOSDCNProGst(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, string ftype, int vouyear, string vendorrefno, double act, int suopplyto, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                                                         new SqlParameter("@supplyto",SqlDbType.Int),
             new SqlParameter("@refno",SqlDbType.Int) };

            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            objp[7].Value = vendorrefno;
            objp[8].Value = act;
            objp[9].Value = suopplyto;
            objp[10].Value = refno;
            //@refno
            ExecuteQuery("SPUpdOSDCNProGst", objp);
        }*/


        public void UpdateOSDCNProGst(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, string ftype, int vouyear, string vendorrefno, double act, int suopplyto, int refno, DateTime vendorrefdate)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                                                         new SqlParameter("@supplyto",SqlDbType.Int),
             new SqlParameter("@refno",SqlDbType.Int),
           new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,8)  };

            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            objp[7].Value = vendorrefno;
            objp[8].Value = act;
            objp[9].Value = suopplyto;
            objp[10].Value = refno;
            objp[11].Value = vendorrefdate;
            //@refno
            ExecuteQuery("SPUpdOSDCNProGst", objp);
        }





      /*  public int InsertOSDNProForGst(DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, double act, int suopplyto)
        {

            SqlParameter[] objp = new SqlParameter[] { // new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@dndate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customer",SqlDbType.Int,4),
                                                         new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                           new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                            new SqlParameter("@actamt",SqlDbType.Money),
                                                              new SqlParameter("@refno",SqlDbType.Int,4),
             new SqlParameter("@supplyto",SqlDbType.Int)
           };
            //objp[0].Value = dnno;
            objp[0].Value = dndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Value = act;
            objp[10].Direction = ParameterDirection.Output;
            objp[11].Value = suopplyto;
            //return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
            return ExecuteQuery("SPInsOSDNProForGst", objp, "@refno");
        }*/



        //DINESH

        public int InsertOSDNProForGst(DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, double act, int suopplyto, DateTime vendorrefdate)
        {

            SqlParameter[] objp = new SqlParameter[] { // new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@dndate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customer",SqlDbType.Int,4),
                                                         new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                           new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                            new SqlParameter("@actamt",SqlDbType.Money),
                                                              new SqlParameter("@refno",SqlDbType.Int,4),
             new SqlParameter("@supplyto",SqlDbType.Int), new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,4)
           };
            //objp[0].Value = dnno;
            objp[0].Value = dndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Value = act;
            objp[10].Direction = ParameterDirection.Output;
            objp[11].Value = suopplyto;
            objp[12].Value = vendorrefdate;
            //return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
            return ExecuteQuery("SPInsOSDNProForGst", objp, "@refno");
        }

   /*     public int InsertOSCNProGst(DateTime cndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, int suopplyto)
        {

            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@cnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@cndate",SqlDbType.SmallDateTime,4), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customer",SqlDbType.Int,4),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                      new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                                                       new SqlParameter("@refno",SqlDbType.Int,4),
             new SqlParameter("@supplyto",SqlDbType.Int)
             };
            //objp[0].Value = cnno;
            objp[0].Value = cndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Direction = ParameterDirection.Output;
            objp[10].Value = suopplyto;
            //return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
            return ExecuteQuery("SPInsOSCNProGst", objp, "@refno");
        }*/

        //DINESH 

        public int InsertOSCNProGst(DateTime cndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, int suopplyto, DateTime vendorrefdate)
        {

            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@cnno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@cndate",SqlDbType.SmallDateTime,8), 
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customer",SqlDbType.Int,4),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                      new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                                                       new SqlParameter("@refno",SqlDbType.Int,4),
             new SqlParameter("@supplyto",SqlDbType.Int,4),
               new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,8)
             };
            //objp[0].Value = cnno;
            objp[0].Value = cndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Direction = ParameterDirection.Output;
            objp[10].Value = suopplyto;
            objp[11].Value = vendorrefdate;
            //return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
            return ExecuteQuery("SPInsOSCNProGst", objp, "@refno");
        }
       
        
        public DataSet RptOSDNCNProFromJobNoForNewEmpty(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4)
            
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteDataSet("SPRptOSDCNProFromJobnoForNewEmpty", objp);
        }

        //Arun
        public DataTable GetAppDetails(string ftype, int branchid, int jobno, string strTranType)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@type",SqlDbType.VarChar,30),        
                                                        new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        
            new SqlParameter("@trantype",SqlDbType.VarChar,2)
           };
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = strTranType;

            return ExecuteTable("SpGEtApprovCheck", objp);
        }

        public DataTable GetOSDCNProDtlsForNew(int jobno, string strTranType, string ftype, int branchid, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        
            new SqlParameter("@bid",SqlDbType.TinyInt,1),
            new SqlParameter("@refno",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = refno;
            return ExecuteTable("SPSelOSDCNProDtlsNew", objp);
        }

        public DataSet GetParticularRefNoDetails(string strTranType, int refno, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
            new SqlParameter("@type",SqlDbType.VarChar,20)};
            objp[0].Value = refno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteDataSet("SPRptOSDCNFromJobnoForrefno", objp);
        }

        public DataSet GetOsDnDetailsForRefno(string strTranType, int refno, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@type",SqlDbType.VarChar,20)
           
            };
            objp[0].Value = refno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteDataSet("SPRptOSDCNProRetriveDetailsForrefno", objp);
        }

        //MUTHURAJ

        public string GetCurrOSDCNcurrenty(int jobno, string strTranType, string ftype, int branchid, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@refno",SqlDbType.Int)
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = refno;
            return ExecuteReader("SPGetCurrDCAdviseCURRENCY", objp);
        }


        //Muthu

        public DataTable GetCurrOSDCN1(int jobno, string strTranType, string ftype, int branchid, int dnno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@dnno",SqlDbType.Int)


            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = dnno;

            return ExecuteTable("SPGetCurrDCAdviseMULTI", objp);
        }

        public string GetCurrOSDCNNEW(int jobno, string strTranType, string ftype, int branchid, int dnno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@dnno",SqlDbType.Int)

            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = dnno;


            return ExecuteReader("SPGetCurrDCAdvisenew", objp);
        } 


        //Arun
        public DataTable GetOsdncnforreport(int jobno, string trantype, string type, int voyear, int refno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@type", SqlDbType.VarChar,10),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = type;
            objp[3].Value = voyear;
            objp[4].Value = refno;
            objp[5].Value = bid;
            return ExecuteTable("SpGetAllValuesForOSSICn", objp);
          //  return ExecuteTable("SpGetAllValuesForOSSICnnewnew1", objp);
        }

        public DataTable GetOsdncnforreportnew(int jobno, string trantype, string type, int voyear, int refno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@type", SqlDbType.VarChar,10),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = type;
            objp[3].Value = voyear;
            objp[4].Value = refno;
            objp[5].Value = bid;
            return ExecuteTable("SpGetAllValuesForOSSICnnew", objp);
        }
        //RAJ
        public DataTable get_containerdetailsOSDNCN(int job, int bid, string blno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.Int, 4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2)};
            objp[0].Value = job;
            objp[1].Value = bid;
            objp[2].Value = blno;
            objp[3].Value = trantype;
            return ExecuteTable("sp_getcontainerOSDNCN", objp);
        }

        public DataTable GetVouDtls4MRInterBranch(int dnno, int branchid, string ftype, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = dnno;
            objp[1].Value = branchid;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetVouDtls4MRInterBranch", objp);
        }
        public DataTable GetVouDtls4MRInterBranchnew(int dnno, int branchid, string ftype, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = dnno;
            objp[1].Value = branchid;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetVouDtls4MRInterBranchNEW", objp);
        }

        //dinesh
        public DataTable Getcustomerledgername(string dbname, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15),    new SqlParameter("@customerid", SqlDbType.Int, 4),};

            objp[0].Value = dbname;
            objp[1].Value = customerid;
            return ExecuteTable("spcustomerledgername", objp);
        }


        //muthu

        public DataTable Getupdacdebitfcamt(int refno, string trantype, int branchid, int voyear, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@prodn",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),

            };
            objp[0].Value = refno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = voyear;
            objp[4].Value = jobno;

            return ExecuteTable("sp_acdebitadviseOSV", objp);
        }

        public void Getupdacosdnproupd(int refno, string trantype, int branchid, int voyear, int jobno, Double fcamount)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@prodn",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money),

            };
            objp[0].Value = refno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = voyear;
            objp[4].Value = jobno;
            objp[5].Value = fcamount;
            ExecuteQuery("sp_aacosdnproupd", objp);
            // return ExecuteTable("sp_aacosdnproupd", objp);
        }

        public void Getupdacosdnproupdnew(int refno, string trantype, int branchid, int voyear, int jobno, Double fcamount,string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@prodn",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money),
                                                       new SqlParameter("@type", SqlDbType.VarChar,30),

            };
            objp[0].Value = refno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = voyear;
            objp[4].Value = jobno;
            objp[5].Value = fcamount;
            objp[6].Value = type;
            ExecuteQuery("sp_aacosdnproupdnewOSV", objp);
            // return ExecuteTable("sp_aacosdnproupd", objp);
        }


        public DataTable Getupdacdebitfcamtnew(int refno, string trantype, int branchid, int voyear, int jobno,string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@prodn",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                      new SqlParameter("@type", SqlDbType.VarChar,30),

            };
            objp[0].Value = refno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = voyear;
            objp[4].Value = jobno;
            objp[5].Value = type;
            return ExecuteTable("sp_acdebitadvisenew", objp);
        }


        //Dinesh

        public DataTable GetCheckosdnForAgent(int jobno, string trantype, int bid, string type, int customerid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@type",SqlDbType.VarChar,20),
                                                         new SqlParameter("@customerid",SqlDbType.Int)
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = type;
            objp[4].Value = customerid;
            //objp[2].Value = ftype;
            // return int.Parse(ExecuteReader("SpCheckosdncnnew", objp));
            return ExecuteTable("SPCheckOsdncnForAgent", objp);
        }

        public DataTable GetCheckcloseUnclose(int jobno, int branchid, string strTranType)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int),        
                                                        new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,5)
                                                        
            
           };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = strTranType;

            return ExecuteTable("SpCheckJobClosedorunclosed", objp);
        }


        public DataTable RptOSDNCNProFromJobNoForNewForParticularRef(string strTranType, int jobno, int branchid, string type, int refno, int custid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                                                      new SqlParameter("@refno",SqlDbType.Int),
                                                                                      new SqlParameter("@customerid",SqlDbType.Int)
           
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Value = refno;
            objp[5].Value = custid;
            return ExecuteTable("SPRptOSDCNProFromJobnoRetriveDetailsnew", objp);
        }


        /*public void UpdDCAdviseForGstForNew(string curr, double rate, double exrate, string strbase, double amount, string blno, int intchargeid, string oldbase, string ftype, int branchid, string remarks, int jobno, string trantype, int fd, double cbm, int supplyto, string chk, int refno, int agentid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                        new SqlParameter("@rate",SqlDbType.Money,8), 
                                                        new SqlParameter("@exrate",SqlDbType.Money,8),
                                                        new SqlParameter("@base",SqlDbType.VarChar,6),
                                                        new SqlParameter("@amount",SqlDbType.Money,8),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                        new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                                                        new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                        new SqlParameter("@fd", SqlDbType.Int),
                                                        new SqlParameter("@cbm", SqlDbType.Real,10),
                                                          new SqlParameter("@supplyto", SqlDbType.Int),
                                                           new SqlParameter("@GSTCHK", SqlDbType.VarChar,1),
                                                            new SqlParameter("@refno", SqlDbType.Int),
                                                            new SqlParameter("@agentid", SqlDbType.Int)
            };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = strbase;
            objp[4].Value = amount;
            objp[5].Value = blno;
            objp[6].Value = intchargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = branchid;
            objp[10].Value = remarks;
            objp[11].Value = jobno;
            objp[12].Value = trantype;
            objp[13].Value = fd;
            objp[14].Value = cbm;
            objp[15].Value = supplyto;
            objp[16].Value = chk;
            objp[17].Value = refno;
            objp[18].Value = agentid;
            //agentid
            ExecuteQuery("SPUpdDCAdviseForGstForRefNotnullnew", objp);
        }

        */


      

        public void UpdateOSDCNagent(int intjobno, int branchid, string strTranType, string ftype, int suopplyto, int refno, int customer)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),   
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@supplyto",SqlDbType.Int),
                                                                                     new SqlParameter("@refno",SqlDbType.Int),      
                                                                                     new SqlParameter("@customer",SqlDbType.Int)};

            objp[0].Value = intjobno;

            objp[1].Value = branchid;
            objp[2].Value = strTranType;
            objp[3].Value = ftype;

            objp[4].Value = suopplyto;
            objp[5].Value = refno;

            objp[6].Value = customer;

            ExecuteQuery("SPUpdOSDCNagent", objp);
        }

        public DataTable GetOSNDCSumAmntmultipleNew(int jobno, string strTranType, int branchid, int agentid)
        {

            SqlParameter[] objp = new SqlParameter[]  { new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
             new SqlParameter("@agentid",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;

            objp[2].Value = branchid;
            objp[3].Value = agentid;
            return ExecuteTable("SPOSNDCSumAmntmultipleNew", objp);
        }


        public void UpdateOSDCNProGst(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, string ftype, int vouyear, string vendorrefno, double act, int suopplyto, int refno, DateTime vendorrefdate, int customer)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                                                         new SqlParameter("@supplyto",SqlDbType.Int),
             new SqlParameter("@refno",SqlDbType.Int),
           new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,8),
            new SqlParameter("@customer",SqlDbType.Int)};

            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            objp[7].Value = vendorrefno;
            objp[8].Value = act;
            objp[9].Value = suopplyto;
            objp[10].Value = refno;
            objp[11].Value = vendorrefdate;
            objp[12].Value = customer;
            //@refno
            ExecuteQuery("SPUpdOSDCNProGstnew", objp);
        }

        //Sinosh

        public void InsertOSDNProForGst_remarks(string StrTranType, int jobno, int branchid, int vouyear, int refno, string remarks)
        {

            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                         new SqlParameter("@refno",SqlDbType.Int,4),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,30)
            };
            objp[0].Value = StrTranType;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = refno;
            objp[5].Value = remarks;
            ExecuteQuery("SPInsOSDNProForGst_remarks", objp);
        }


        public void DelOSDCNPronew(int jobno, string strtrantype, string ftype, int vouyear, int branchid, int agentid, int procn)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                           new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                              new SqlParameter("@agentid",SqlDbType.Int),
                                                                            new SqlParameter("@procn",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = agentid;
            objp[6].Value = procn;
            ExecuteQuery("SPDelOSDCNPronew", objp);
        }

        public void InsertOSCNProGst_remarks(string StrTranType, int jobno, int branchid, int vouyear, int cnrefno, string remarks)
        {

            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                         //new SqlParameter("@cnrefno",SqlDbType.Int,4),

                                                           new SqlParameter("@refno",SqlDbType.Int,4),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,30)
            };
            objp[0].Value = StrTranType;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = cnrefno;
            objp[5].Value = remarks;
            ExecuteQuery("SPInsOSCNProGst_remarks", objp);
        }



        public DataSet RptOSDNCNProForGrd(string strTranType, int jobno, int branchid, int custid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4)
                                                                                    
            
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = custid;
            return ExecuteDataSet("SPGetvalueforosdngrid", objp);
        }
        public DataSet RptOSDNCNProForGrd(string strTranType, int jobno, int branchid, int custid, string Flag)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),       
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                      new SqlParameter("@Flag",SqlDbType.VarChar,10)
                                                                                   
           
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = custid;
            objp[4].Value = Flag;
            return ExecuteDataSet("SPGetvalueforosdngrid", objp);
        }

        public DataSet RptOSDNCNProFromJobNoForGrid(string strTranType, int jobno, int branchid, int custid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4)
                                                                                     
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = custid;
            //objp[2].Va objp[2].Value = branchid;lue = ftype;
            return ExecuteDataSet("SPRptOSDCNProFromJobnoForGrd", objp);
        }

        public DataSet GetOSDCNnotraised(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SPGetOSDCNnotraised", objp);
        }


        public DataSet GetOsDnDetailsForRefnojobnonew(string strTranType, int refno, int branchid, string type, int jobno, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@refno",SqlDbType.Int,4),
                                                        new SqlParameter("@strtrantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.VarChar,20),
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int)

            };
            objp[0].Value = refno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Value = jobno;
            objp[5].Value = vouyear;
            return ExecuteDataSet("SPRptOSDCNProRetriveDetailsForrefnonew", objp);
        }




        public void UpdateOSDCNagentnew(int intjobno, int branchid, string strTranType, string ftype,int refno, string orgin)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),   
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),                                                                                 
                                                                                     new SqlParameter("@refno",SqlDbType.Int),      
                                                                                     new SqlParameter("@orgin",SqlDbType.VarChar,100), };     

            objp[0].Value = intjobno;

            objp[1].Value = branchid;
            objp[2].Value = strTranType;
            objp[3].Value = ftype;

          
            objp[4].Value = refno;

            objp[5].Value = orgin;

            ExecuteQuery("SPUpdOSDCNagentnew1", objp);
        }
        //OSDNCN
        //Tally
        public string GetPortCodeForTally(int branchid)
        {
            string portcode = "";
            //
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) };
            objp[0].Value = branchid;
            //return ExecuteTable("SPGetPortCode", objp);
            Dt = ExecuteTable("SPGetPortCodefortallyxml", objp);
            if (Dt.Rows.Count > 0)
            {
                portcode = Dt.Rows[0].ItemArray[0].ToString();
            }
            return portcode;
        }
        public DataSet SelOSDebitCreditDetails(int dcnno, int vouyear, int branchid, string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@dnno",SqlDbType.Int,4),
new SqlParameter("@ftype",SqlDbType.VarChar,4),
new SqlParameter("@vouyear",SqlDbType.Int),
new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = dcnno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            //return ExecuteDataSet("SPSelOSDebitCreditDetailstally   ", objp);
            return ExecuteDataSet("SPSelOSDebitCreditDetailstally_allhd", objp); ////haribalaji
        }


        public DataTable GetstateidcheckwithOSDNCN(int jobno,  string blno,int branchid, string strTranType)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@loc_bid",SqlDbType.Int),        
                                                        new SqlParameter("@blnohead",SqlDbType.VarChar,35),
                                                        new SqlParameter("@jobnoblbl",SqlDbType.Int),   
                                                        new SqlParameter("@loc_trantype",SqlDbType.VarChar,35),
                                                        
            
           };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = branchid;
            objp[3].Value = strTranType;

            return ExecuteTable("spstateidcheckwithOSDNCN", objp);
        }

        //25-05-2021
        public DataSet GetParticularRefNoDetailsnew(string strTranType, int refno, int branchid, string type, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@type",SqlDbType.VarChar,20),
                                                                                       new SqlParameter("@vouyear",SqlDbType.Int)              };
            objp[0].Value = refno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Value = vouyear;
            return ExecuteDataSet("SPRptOSDCNFromJobnoForrefnonew", objp);
        }


        //
        public DataTable GetAppDetails4OSV(int ftype, int branchid, int jobno, string strTranType)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@type",SqlDbType.Int),        
                                                        new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        
            new SqlParameter("@trantype",SqlDbType.VarChar,2)
           };
            objp[0].Value = ftype;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = strTranType;

            return ExecuteTable("SpGEtApprovCheck4OSV", objp);
        }

        public DataTable CheckForAgentOSV(int jobno, string trantype, int bid, int type, int customerid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@type",SqlDbType.Int),
                                                         new SqlParameter("@customerid",SqlDbType.Int)
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = type;
            objp[4].Value = customerid;
            //objp[2].Value = ftype;
            // return int.Parse(ExecuteReader("SpCheckosdncnnew", objp));
            return ExecuteTable("SPCheckForAgentOSV", objp);
        }

        public DataSet RptOSDNCNProForGrdOSV(string strTranType, int jobno, int branchid, int custid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4)
                                                                                    
            
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = custid;
            return ExecuteDataSet("SPGetvalueforosdngridOSV", objp);
        }
        public DataSet RptOSDNCNProFromJobNoForGridOSV(string strTranType, int jobno, int branchid, int custid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4)
                                                                                     
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = custid;
            //objp[2].Va objp[2].Value = branchid;lue = ftype;
            return ExecuteDataSet("SPRptOSDCNProFromJobnoForGrdOSV", objp);
        }
        public DataTable RptOSDNCNProFromJobNoForNewForParticularRefOSV(string strTranType, int jobno, int branchid, int type, int refno, int custid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@type",SqlDbType.Int),
                                                                                      new SqlParameter("@refno",SqlDbType.Int),
                                                                                      new SqlParameter("@customerid",SqlDbType.Int)
           
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Value = refno;
            objp[5].Value = custid;
            return ExecuteTable("SPRptOSDCNProFromJobnoRetriveDetailsnewOSV", objp);
        }

        public void UpdateOSDCNagentOSV(int intjobno, int branchid, string strTranType, int ftype, int suopplyto, int refno, int customer)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),   
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@supplyto",SqlDbType.Int),
                                                                                     new SqlParameter("@refno",SqlDbType.Int),      
                                                                                     new SqlParameter("@customer",SqlDbType.Int)};

            objp[0].Value = intjobno;

            objp[1].Value = branchid;
            objp[2].Value = strTranType;
            objp[3].Value = ftype;

            objp[4].Value = suopplyto;
            objp[5].Value = refno;

            objp[6].Value = customer;

            ExecuteQuery("SPUpdOSDCNagentOSV", objp);
        }

        public void UpdateOSDCNagentnewOSV(int intjobno, int branchid, string strTranType, int ftype, int refno, string orgin)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),   
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),                                                                                 
                                                                                     new SqlParameter("@refno",SqlDbType.Int),      
                                                                                     new SqlParameter("@orgin",SqlDbType.VarChar,100), };

            objp[0].Value = intjobno;

            objp[1].Value = branchid;
            objp[2].Value = strTranType;
            objp[3].Value = ftype;


            objp[4].Value = refno;

            objp[5].Value = orgin;

            ExecuteQuery("SPUpdOSDCNagentnew1OSV", objp);
        }
        public DataTable GetOSNDCSumAmntmultipleNewOSV(int jobno, string strTranType, int branchid, int agentid)
        {

            SqlParameter[] objp = new SqlParameter[]  { new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
             new SqlParameter("@agentid",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;

            objp[2].Value = branchid;
            objp[3].Value = agentid;
            return ExecuteTable("SPOSNDCSumAmntmultipleNewOSV", objp);
        }
        public int GetOSDCNProJobCountOSV(int jobno, string strTranType, int ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return int.Parse(ExecuteReader("SPOSDCNProJobCountOSV", objp));
        }

        public DataTable GetOSDCNProDtlsOSV(int jobno, string strTranType, int ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelOSDCNProDtlsOSV", objp);
        }
        public void UpdateOSDCNProGstOSV(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, int ftype, int vouyear, string vendorrefno, double act, int suopplyto, int refno, DateTime vendorrefdate)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                                                         new SqlParameter("@supplyto",SqlDbType.Int),
             new SqlParameter("@refno",SqlDbType.Int),
           new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,8)  };

            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            objp[7].Value = vendorrefno;
            objp[8].Value = act;
            objp[9].Value = suopplyto;
            objp[10].Value = refno;
            objp[11].Value = vendorrefdate;
            //@refno
            ExecuteQuery("SPUpdOSDCNProGstOSV", objp);
        }
        public void InsertOSDNProForGst_remarksOSV(string StrTranType, int jobno, int branchid, int vouyear, int refno, string remarks)
        {

            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                         new SqlParameter("@refno",SqlDbType.Int,4),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,30)
            };
            objp[0].Value = StrTranType;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = refno;
            objp[5].Value = remarks;
            ExecuteQuery("SPInsOSDNProForGst_remarksOSV", objp);
        }
        public int InsertOSDCNProForGstOSV(DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, double act, int suopplyto, DateTime vendorrefdate,int type)
        {

            SqlParameter[] objp = new SqlParameter[] { // new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@dndate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customer",SqlDbType.Int,4),
                                                         new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                           new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                            new SqlParameter("@actamt",SqlDbType.Money),
                                                              new SqlParameter("@refno",SqlDbType.Int,4),
             new SqlParameter("@supplyto",SqlDbType.Int), new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,4), new SqlParameter("@type",SqlDbType.Int)
           };
            //objp[0].Value = dnno;
            objp[0].Value = dndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Value = act;
            objp[10].Direction = ParameterDirection.Output;
            objp[11].Value = suopplyto;
            objp[12].Value = vendorrefdate;
            objp[13].Value = type;
            //return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
            return ExecuteQuery("SPInsOSDNProForGstOSV", objp, "@refno");
        }
        public DataTable GetOSDCNDtlsOSV(int jobno, string strTranType, int ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelOSDCNDtlsOSV", objp);
        }
        public void DelOSDCNPronewOSV(int jobno, string strtrantype, int ftype, int vouyear, int branchid, int agentid, int procn)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                           new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                                            new SqlParameter("@ftype",SqlDbType.Int),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                              new SqlParameter("@agentid",SqlDbType.Int),
                                                                            new SqlParameter("@procn",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = agentid;
            objp[6].Value = procn;
            ExecuteQuery("SPDelOSDCNPronewOSV", objp);
        }
        public string GetCurrOSDCNOSV(int jobno, string strTranType, int ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            return ExecuteReader("SPGetCurrDCAdviseOSV", objp);
        }

        public string GetCurrOSDCNcurrentyOSV(int jobno, string strTranType, int ftype, int branchid, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@refno",SqlDbType.Int)
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = refno;
            return ExecuteReader("SPGetCurrDCAdviseCURRENCYOSV", objp);
        }
        public DataSet RptOSDNCNProFromJobNoForNewEmptyOSV(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4)
            
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteDataSet("SPRptOSDCNProFromJobnoForNewEmptyOSV", objp);
        }
        public DataSet RptOSDNCNProFromJobNoForNewOSV(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SPRptOSDCNProFromJobnoForNewOSV", objp);
        }
        public DataSet GetOSDCNnotraisedOSV(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            return ExecuteDataSet("SPGetOSDCNnotraisedOSV", objp);
        }
        public DataSet RptOSDNCNProForGrdOSV(string strTranType, int jobno, int branchid, int custid, string Flag)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),       
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                      new SqlParameter("@Flag",SqlDbType.VarChar,10)
                                                                                   
           
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = custid;
            objp[4].Value = Flag;
            return ExecuteDataSet("SPGetvalueforosdngridOSV", objp);
        }
        public DataTable GetOSDCNProDtlsForNewOSV(int jobno, string strTranType, int ftype, int branchid, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        
            new SqlParameter("@bid",SqlDbType.TinyInt,1),
            new SqlParameter("@refno",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = refno;
            return ExecuteTable("SPSelOSDCNProDtlsNewOSV", objp);
        }
        public int InsertOSDNCNProForGstOSV(DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid, int vouyear, string vendorrefno, double act, int suopplyto, DateTime vendorrefdate,int type)
        {

            SqlParameter[] objp = new SqlParameter[] { // new SqlParameter("@dnno",SqlDbType.Int,4),        
                                                         new SqlParameter("@dndate",SqlDbType.SmallDateTime,4), 
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customer",SqlDbType.Int,4),
                                                         new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                           new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                            new SqlParameter("@actamt",SqlDbType.Money),
                                                              new SqlParameter("@refno",SqlDbType.Int,4),
             new SqlParameter("@supplyto",SqlDbType.Int), new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,4), new SqlParameter("@type",SqlDbType.Int)
           };
            //objp[0].Value = dnno;
            objp[0].Value = dndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Value = act;
            objp[10].Direction = ParameterDirection.Output;
            objp[11].Value = suopplyto;
            objp[12].Value = vendorrefdate;
            objp[13].Value = type;

            //return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
            return ExecuteQuery("SPInsOSDNProForGstOSV", objp, "@refno");
        }

        public void UpdateOSDCNProGstOSV(int intjobno, double amount, DateTime dtdate, int branchid, string strTranType, int ftype, int vouyear, string vendorrefno, double act, int suopplyto, int refno, DateTime vendorrefdate, int customer)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@ftype",SqlDbType.Int),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                                                         new SqlParameter("@supplyto",SqlDbType.Int),
             new SqlParameter("@refno",SqlDbType.Int),
           new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,8),
            new SqlParameter("@customer",SqlDbType.Int)};

            objp[0].Value = intjobno;
            objp[1].Value = amount;
            objp[2].Value = dtdate;
            objp[3].Value = branchid;
            objp[4].Value = strTranType;
            objp[5].Value = ftype;
            objp[6].Value = vouyear;
            objp[7].Value = vendorrefno;
            objp[8].Value = act;
            objp[9].Value = suopplyto;
            objp[10].Value = refno;
            objp[11].Value = vendorrefdate;
            objp[12].Value = customer;
            //@refno
            ExecuteQuery("SPUpdOSDCNProGstnewOSV", objp);
        }

        public DataSet GetOsDnDetailsForRefnojobnonewOSV(string strTranType, int refno, int branchid, int type, int jobno, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@refno",SqlDbType.Int,4),
                                                        new SqlParameter("@strtrantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@type",SqlDbType.Int),
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@vouyear",SqlDbType.Int)

            };
            objp[0].Value = refno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Value = jobno;
            objp[5].Value = vouyear;
            return ExecuteDataSet("SPRptOSDCNProRetriveDetailsForrefnonewOSV", objp);
        }
        public DataTable GetOsdncnforreportOSV(int jobno, string trantype, string type, int voyear, int refno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@type", SqlDbType.VarChar,10),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@refno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = type;
            objp[3].Value = voyear;
            objp[4].Value = refno;
            objp[5].Value = bid;
            return ExecuteTable("SpGetAllValuesForOSSICnOSV", objp);
            //  return ExecuteTable("SpGetAllValuesForOSSICnnewnew1", objp);
        }
        public DataTable get_containerdetailsOSDNCNOSV(int job, int bid, string blno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.Int, 4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2)};
            objp[0].Value = job;
            objp[1].Value = bid;
            objp[2].Value = blno;
            objp[3].Value = trantype;
            return ExecuteTable("sp_getcontainerOSDNCNOSV", objp);
        }

        public DataSet GetParticularRefNoDetailsOSV(string strTranType, int refno, int branchid, int type, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int),        
                                                                                     new SqlParameter("@strtrantype",SqlDbType.VarChar,4), 
                                                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@type",SqlDbType.Int),
                                                                                       new SqlParameter("@vouyear",SqlDbType.Int)              };
            objp[0].Value = refno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            objp[3].Value = type;
            objp[4].Value = vouyear;
            return ExecuteDataSet("SPGetOSDCNOSV", objp);
        }
        //
        public DataTable GetCheckosdncnnewLV(string strTranType, int jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
           // new SqlParameter("@type",SqlDbType.VarChar,20),
            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            //objp[2].Value = ftype;
            // return int.Parse(ExecuteReader("SpCheckosdncnnew", objp));
            return ExecuteTable("SpCheckosdncnnewLV", objp);
        }
        public DataTable GetOSDCNDtlsForNewOSV(int jobno, string strTranType, int ftype, int branchid, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        
            new SqlParameter("@bid",SqlDbType.TinyInt,1),
            new SqlParameter("@refno",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = refno;
            return ExecuteTable("SPSelOSDCNPDtlsNewOSV", objp);
        }
        public DataTable GetCurrOSDCN1OSV(int jobno, string strTranType, int ftype, int branchid, int dnno)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,3),
                                                        new SqlParameter("@ftype",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@dnno",SqlDbType.Int)


            };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = ftype;
            objp[3].Value = branchid;
            objp[4].Value = dnno;

            return ExecuteTable("SPGetCurrDCAdviseMULTIOSV", objp);
        }
        public int InsproOSvouchershead(DateTime dndate, string StrTranType, double amount, int jobno, int branchid, int customer, int userid,
    int vouyear, string vendorrefno, double act, int suopplyto, DateTime vendorrefdate, int type, string remarks, string origin)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                  new SqlParameter("@dndate",SqlDbType.SmallDateTime,4),
                                                  new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                  new SqlParameter("@amount",SqlDbType.Money,8),
                                                  new SqlParameter("@branchid",SqlDbType.Int,4),
                                                  new SqlParameter("@customer",SqlDbType.Int,4),
                                                  new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                  new SqlParameter("@vouyear",SqlDbType.Int),
                                                    new SqlParameter("@vendorrefno",SqlDbType.VarChar,100),
                                                     new SqlParameter("@actamt",SqlDbType.Money),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),
      new SqlParameter("@supplyto",SqlDbType.Int), new SqlParameter("@vendorrefdate",SqlDbType.SmallDateTime,4), new SqlParameter("@type",SqlDbType.Int)
      , new SqlParameter("@remarks",SqlDbType.VarChar,50)
      , new SqlParameter("@origin",SqlDbType.VarChar,100)
    };

            objp[0].Value = dndate;
            objp[1].Value = StrTranType;
            objp[2].Value = jobno;
            objp[3].Value = amount;
            objp[4].Value = branchid;
            objp[5].Value = customer;
            objp[6].Value = userid;
            objp[7].Value = vouyear;
            objp[8].Value = vendorrefno;
            objp[9].Value = act;
            objp[10].Direction = ParameterDirection.Output;
            objp[11].Value = suopplyto;
            objp[12].Value = vendorrefdate;
            objp[13].Value = type;
            objp[14].Value = remarks;
            objp[15].Value = origin;

            return ExecuteQuery("SPInsproOSvouchershead", objp, "@refno");
        }

        public void UpdOSVhead(int intjobno, int branchid, string strTranType, int ftype, int suopplyto, int refno, int customer,String vendorrefno,DateTime vendordate)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                              new SqlParameter("@branchid",SqlDbType.Int,4),
                                                                              new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                              new SqlParameter("@ftype",SqlDbType.Int),
                                                                              new SqlParameter("@supplyto",SqlDbType.Int),
                                                                              new SqlParameter("@refno",SqlDbType.Int),
                                                                              new SqlParameter("@customer",SqlDbType.Int),
             new SqlParameter("@vendrefno",SqlDbType.VarChar,100),
             new SqlParameter("@vendrefdate",SqlDbType.DateTime)};

            objp[0].Value = intjobno;
            objp[1].Value = branchid;
            objp[2].Value = strTranType;
            objp[3].Value = ftype;
            objp[4].Value = suopplyto;
            objp[5].Value = refno;
            objp[6].Value = customer;
            objp[7].Value = vendorrefno;
            objp[8].Value = vendordate;
            ExecuteQuery("SPUpdOSVhead", objp);
        }
        public DataTable GetOSVhead(int dnno, int ftype, int branchid,string trantype)
        {

            SqlParameter[] objp = new SqlParameter[] {
          new SqlParameter("@refno",SqlDbType.Int),
                                                 new SqlParameter("@voutype",SqlDbType.Int),
                                                 new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                  new SqlParameter("@trantype",SqlDbType.VarChar,2),
     };
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetOSVhead", objp);
        }
        public DataTable GetOSVdetails(int dnno, int ftype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {
          new SqlParameter("@refno",SqlDbType.Int),
                                                 new SqlParameter("@voutype",SqlDbType.Int),
                                                 new SqlParameter("@bid",SqlDbType.TinyInt,1),
     };
            objp[0].Value = dnno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetOSVdetails", objp);
        }
        public DataTable SPGetOSVjobdetails(int jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                 new SqlParameter("@strtrantype",SqlDbType.VarChar,4),


     new SqlParameter("@branchid",SqlDbType.TinyInt,1)
    };
            objp[0].Value = jobno;
            objp[1].Value = strTranType;

            objp[2].Value = branchid;

            return ExecuteTable("SPGetOSVjobdetails", objp);
        }

        public DataTable SPGetAEBLdetails(string hawblno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@hawblno",SqlDbType.VarChar,20),
                                               new SqlParameter("@bid",SqlDbType.Int)

    };
            objp[0].Value = hawblno;
            objp[1].Value = bid;

            return ExecuteTable("SPGetAEBLdetails", objp);
        }
        public DataSet Getagentbooking(string jobno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.VarChar,20),
                                               new SqlParameter("@bid",SqlDbType.Int)

    };
            objp[0].Value = jobno;
            objp[1].Value = bid;

            return ExecuteDataSet("SPGetagentbooking", objp);
        }
        public DataTable GetFIFinalReport(string blno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,20),
                                               new SqlParameter("@bid",SqlDbType.Int)

    };
            objp[0].Value = blno;
            objp[1].Value = bid;

            return ExecuteTable("SPFIFinalReport", objp);
        }

        public DataTable GetRemainderNoticeReport(string blno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,20),
                                               new SqlParameter("@bid",SqlDbType.Int)

    };
            objp[0].Value = blno;
            objp[1].Value = bid;

            return ExecuteTable("SPRemainderNotice", objp);
        }
        public DataTable GetFwdRemainderNoticeReport(string blno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,20),
                                               new SqlParameter("@bid",SqlDbType.Int)

    };
            objp[0].Value = blno;
            objp[1].Value = bid;

            return ExecuteTable("SPFwdRemainderNotice", objp);
        }
        public DataTable GetFCReport(string blno, string trantype, int bid, int jobno)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,20),
                                               new SqlParameter("@bid",SqlDbType.Int),
                                               new SqlParameter("@trantype",SqlDbType.VarChar,20),
                                               new SqlParameter("@jobno",SqlDbType.Int)

    };
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            objp[3].Value = jobno;

            return ExecuteTable("SPGetFCReport", objp);
        }

    }
}

