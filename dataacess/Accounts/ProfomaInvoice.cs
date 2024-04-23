using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class ProfomaInvoice : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ProfomaInvoice()
        {
            Conn = new SqlConnection(DBCS);
        }

        ////public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear)
        ////{
        ////    string billtype = CheckBillType(strbilltype);
        ////    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoicedate",SqlDbType.DateTime,8), 
        ////                                               new SqlParameter("@trantype",SqlDbType.VarChar,2),
        ////                                               new SqlParameter("@jobno",SqlDbType.Int,4),
        ////                                               new SqlParameter("@customerid",SqlDbType.Int,4),
        ////                                               new SqlParameter("@blno",SqlDbType.VarChar,30),
        ////                                               new SqlParameter("@remarks",SqlDbType.VarChar,50), 
        ////                                               new SqlParameter("@branchid",SqlDbType.Int,4),
        ////                                               new SqlParameter("@billtype",SqlDbType.VarChar,1),
        ////                                               new SqlParameter("@preparedby",SqlDbType.Int,4),
        ////                                               new SqlParameter("@vouyear",SqlDbType.Int),
        ////                                               new SqlParameter("@refno",SqlDbType.Int,4)};

        ////    objp[0].Value = Dtdate;
        ////    objp[1].Value = strTranType;
        ////    objp[2].Value = jobno;
        ////    objp[3].Value = intcustomerid;
        ////    objp[4].Value = blno;
        ////    objp[5].Value = remarks;
        ////    objp[6].Value = branchid;
        ////    objp[7].Value = billtype;
        ////    objp[8].Value = preparedby;
        ////    objp[9].Value = vouyear;
        ////    objp[10].Direction = ParameterDirection.Output;
        ////    return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
        ////}

        //Manoj

        ////public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, string type)
        ////{
        ////    string billtype = CheckBillType(strbilltype);
        ////    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@date",SqlDbType.DateTime,8), 
        ////                                               new SqlParameter("@trantype",SqlDbType.VarChar,2),
        ////                                               new SqlParameter("@jobno",SqlDbType.Int,4),
        ////                                               new SqlParameter("@customerid",SqlDbType.Int,4),
        ////                                               new SqlParameter("@blno",SqlDbType.VarChar,30),
        ////                                               new SqlParameter("@remarks",SqlDbType.VarChar,50), 
        ////                                               new SqlParameter("@branchid",SqlDbType.Int,4),
        ////                                               new SqlParameter("@billtype",SqlDbType.VarChar,1),
        ////                                               new SqlParameter("@preparedby",SqlDbType.Int,4),
        ////                                               new SqlParameter("@vouyear",SqlDbType.Int),
        ////                                               new SqlParameter("@type",SqlDbType.VarChar,30),
        ////                                               new SqlParameter("@refno",SqlDbType.Int,4)};

        ////    objp[0].Value = Dtdate;
        ////    objp[1].Value = strTranType;
        ////    objp[2].Value = jobno;
        ////    objp[3].Value = intcustomerid;
        ////    objp[4].Value = blno;
        ////    objp[5].Value = remarks;
        ////    objp[6].Value = branchid;
        ////    objp[7].Value = billtype;
        ////    objp[8].Value = preparedby;
        ////    objp[9].Value = vouyear;
        ////    objp[10].Value = type;
        ////    objp[11].Direction = ParameterDirection.Output;
        ////    return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
        ////}
        /* public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, string type, string vendorrefno, int creditdays)
         {
             string billtype = CheckBillType(strbilltype);
             SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@date",SqlDbType.DateTime,8), 
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@customerid",SqlDbType.Int,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,50), 
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                        new SqlParameter("@type",SqlDbType.VarChar,30),
                                                        new SqlParameter("@refno",SqlDbType.Int,4),
                                                        new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                        new SqlParameter("@creditdays",SqlDbType.TinyInt )};

             objp[0].Value = Dtdate;
             objp[1].Value = strTranType;
             objp[2].Value = jobno;
             objp[3].Value = intcustomerid;
             objp[4].Value = blno;
             objp[5].Value = remarks;
             objp[6].Value = branchid;
             objp[7].Value = billtype;
             objp[8].Value = preparedby;
             objp[9].Value = vouyear;
             objp[10].Value = type;
             objp[11].Direction = ParameterDirection.Output;
             objp[12].Value = vendorrefno;
             objp[13].Value = creditdays;
             return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
         }
         */


        /*   public string CheckBillType(string strbilltype)
           {
               switch (strbilltype)
               {
                   case ("Cash/Cheque"):
                       return "C";

                   case ("Credit"):
                       return "D";

                   case ("Service Tax Exemption"):
                       return "S";

                   case ("Internal"):
                       return "I";
                   case ("Profit Share"):
                       return "P";
                   default:
                       return "X";
               }
           }*/


        //public void UpdateProHead(int refno,int custid,string remarks, string strbilltype, int preparedby, int vouyear, int branchid,string trantype)
        //{
        //    string billtype = CheckBillType(strbilltype);
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
        //                                                                             new SqlParameter("@remarks",SqlDbType.VarChar,150), 
        //                                                                             new SqlParameter("@refno",SqlDbType.Int,4),
        //                                                                             new SqlParameter("@billtype",SqlDbType.Char,1),
        //                                                                             new SqlParameter("@preparedby",SqlDbType.Int,4), 
        //                                                                             new SqlParameter("@vouyear",SqlDbType.Int), 
        //                                                                             new SqlParameter("@branchid", SqlDbType.TinyInt,1),
        //                                                                             new SqlParameter("@trantype",SqlDbType.VarChar,2)};
        //    objp[0].Value = custid;
        //    objp[1].Value = remarks;
        //    objp[2].Value = refno;
        //    objp[3].Value = billtype;
        //    objp[4].Value =preparedby;
        //    objp[5].Value = vouyear;
        //    objp[6].Value = branchid;
        //    objp[7].Value = trantype;
        //    ExecuteQuery("SPUpdProinvHead", objp);
        //}


        //Manoj
        ////public void UpdateProHead(int refno, int custid, string remarks, string strbilltype, int preparedby, int vouyear, int branchid, string trantype, string type, string vendor)
        ////{
        ////    string billtype = CheckBillType(strbilltype);
        ////    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
        ////                                                                             new SqlParameter("@remarks",SqlDbType.VarChar,150), 
        ////                                                                             new SqlParameter("@refno",SqlDbType.Int,4),
        ////                                                                             new SqlParameter("@billtype",SqlDbType.Char,1),
        ////                                                                             new SqlParameter("@preparedby",SqlDbType.Int,4), 
        ////                                                                             new SqlParameter("@vouyear",SqlDbType.Int), 
        ////                                                                             new SqlParameter("@branchid", SqlDbType.TinyInt,1),
        ////                                                                             new SqlParameter("@trantype",SqlDbType.VarChar,2),
        ////                                                                             new SqlParameter("@type",SqlDbType.VarChar,30),
        ////                                                                             new SqlParameter("@vendor",SqlDbType.VarChar,30)};
        ////    objp[0].Value = custid;
        ////    objp[1].Value = remarks;
        ////    objp[2].Value = refno;
        ////    objp[3].Value = billtype;
        ////    objp[4].Value = preparedby;
        ////    objp[5].Value = vouyear;
        ////    objp[6].Value = branchid;
        ////    objp[7].Value = trantype;
        ////    objp[8].Value = type;
        ////    objp[9].Value = vendor;
        ////    ExecuteQuery("SPUpdProinvHead", objp);
        ////}
        //KUMAR
        /*  public void UpdateProHead(int refno, int custid, string remarks, string strbilltype, int preparedby, int vouyear, int branchid, string trantype, string type, string vendor, int creditdays)
          {
              string billtype = CheckBillType(strbilltype);
              SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
                                                                                       new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                       new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                       new SqlParameter("@billtype",SqlDbType.Char,1),
                                                                                       new SqlParameter("@preparedby",SqlDbType.Int,4), 
                                                                                       new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                       new SqlParameter("@type",SqlDbType.VarChar,30),
                                                                                       new SqlParameter("@vendor",SqlDbType.VarChar,30),
                                                                                       new SqlParameter("@creditdays",SqlDbType.TinyInt )};
              objp[0].Value = custid;
              objp[1].Value = remarks;
              objp[2].Value = refno;
              objp[3].Value = billtype;
              objp[4].Value = preparedby;
              objp[5].Value = vouyear;
              objp[6].Value = branchid;
              objp[7].Value = trantype;
              objp[8].Value = type;
              objp[9].Value = vendor;
              objp[10].Value = creditdays;
              ExecuteQuery("SPUpdProinvHead", objp);
          }*/


        //public DataTable SelProInvHead(int refno, string strantype,int vouyear, int branchid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
        //                                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),  
        //                                                                    new SqlParameter("@vouyear",SqlDbType.Int), 
        //                                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
        //    objp[0].Value = refno;
        //    objp[1].Value = strantype;
        //    objp[2].Value = vouyear;
        //    objp[3].Value = branchid;
        //    return ExecuteTable("SPSelProInvHead", objp);
        //}

        //Manoj
        public DataTable SelProInvHead(int refno, string strantype, int vouyear, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),  
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@type",SqlDbType.VarChar,30)};
            objp[0].Value = refno;
            objp[1].Value = strantype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = type;
            return ExecuteTable("SPSelProInvHead", objp);
        }
        //public DataTable CheckchrgInvPro(int refno, string cbase,int charge,int vouyear, int branchid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
        //                                                                    new SqlParameter("@base",SqlDbType.VarChar,6), 
        //                                                                    new SqlParameter("@charge",SqlDbType.Int,4),
        //                                                                    new SqlParameter("@vouyear",SqlDbType.Int), 
        //                                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
        //    objp[0].Value = refno;
        //    objp[1].Value = cbase;
        //    objp[2].Value = charge;
        //    objp[3].Value = vouyear;
        //    objp[4].Value = branchid;
        //    return ExecuteTable("SPCheckchrgInvPro", objp);
        //}


        //Manoj

        public DataTable CheckchrgInvPro(int refno, string cbase, int charge, int vouyear, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@base",SqlDbType.VarChar,6), 
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@type",SqlDbType.VarChar,30)};
            objp[0].Value = refno;
            objp[1].Value = cbase;
            objp[2].Value = charge;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = type;
            return ExecuteTable("SPCheckchrgInvPro", objp);
        }
        //public DataTable GetProInvoiceDetails(int refno,int vouyear, int branchid)
        //{

        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int,4), 

        //                                               new SqlParameter("@vouyear", SqlDbType.Int),
        //                                               new SqlParameter("@branchid", SqlDbType.TinyInt,1)
        //                                                                    };
        //    objp[0].Value = refno;
        //    objp[1].Value = vouyear;
        //    objp[2].Value = branchid;
        //    return ExecuteTable("SPGetProInvoiceDtls", objp);
        //}//Manoj

        public DataTable GetProInvoiceDetails(int refno, int vouyear, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int,4), 
                                                      
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteTable("SPGetProInvoiceDtls", objp);
        }

        //public void InsertProInvoiceDetails(int refno, int charge, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, string strbilltype,string trantype)
        //{
        //    string billtype = CheckBillType(strbilltype);
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billtype",SqlDbType.VarChar,1),
        //                                               new SqlParameter("@refno",SqlDbType.Int,4),        
        //                                               new SqlParameter("@charges",SqlDbType.Int,4), 
        //                                               new SqlParameter("@curr",SqlDbType.VarChar,6),
        //                                               new SqlParameter("@rate",SqlDbType.Money,8),
        //                                               new SqlParameter("@exrate",SqlDbType.Money,8),
        //                                               new SqlParameter("@base",SqlDbType.VarChar,6),
        //                                               new SqlParameter("@amount",SqlDbType.Money,8), 
        //                                               new SqlParameter("@branchid",SqlDbType.Int,4),
        //                                               new SqlParameter("@vouyear",SqlDbType.Int),
        //                                               new SqlParameter("@trantype",SqlDbType.VarChar,2)
        //                                            };
        //    objp[0].Value = billtype;
        //    objp[1].Value = refno;
        //    objp[2].Value = charge;
        //    objp[3].Value = curr;
        //    objp[4].Value = rate;
        //    objp[5].Value = exrate;
        //    objp[6].Value = strbase;
        //    objp[7].Value = famount;
        //    objp[8].Value = branchid;
        //    objp[9].Value = vouyear;
        //    objp[10].Value = trantype;
        //    ExecuteQuery("SPInsProInvDtls", objp);
        //}



        public void InsertProInvoiceDetails(int refno, int charge, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, string strbilltype, string trantype, string type, string ServiceTax, double unit)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),        
                                                       new SqlParameter("@charges",SqlDbType.Int,4), 
                                                       new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@rate",SqlDbType.Money,8),
                                                       new SqlParameter("@exrate",SqlDbType.Money,8),
                                                       new SqlParameter("@base",SqlDbType.VarChar,45),
                                                       new SqlParameter("@amount",SqlDbType.Money,8), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@ServiceTax",SqlDbType.VarChar,2),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                    };
            objp[0].Value = billtype;
            objp[1].Value = refno;
            objp[2].Value = charge;
            objp[3].Value = curr;
            objp[4].Value = rate;
            objp[5].Value = exrate;
            objp[6].Value = strbase;
            objp[7].Value = famount;
            objp[8].Value = branchid;
            objp[9].Value = vouyear;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = ServiceTax;
            objp[13].Value = unit;
            ExecuteQuery("SPInsProInvDtls", objp);
        }


        //public void UpdateProInvoiceDetails(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount,string oldbase, int vouyear, int branchid,string trantype)
        //{

        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
        //                                                                             new SqlParameter("@rate",SqlDbType.Money,8), 
        //                                                                             new SqlParameter("@exrate",SqlDbType.Money,8),
        //                                                                             new SqlParameter("@base",SqlDbType.VarChar,6),
        //                                                                             new SqlParameter("@amount",SqlDbType.Money,8),
        //                                                                             new SqlParameter("@refno",SqlDbType.Int,4),
        //                                                                             new SqlParameter("@chargeid",SqlDbType.Int,4), 
        //                                                                             new SqlParameter("@oldbase",SqlDbType.VarChar,6),                                                                                  
        //                                                                             new SqlParameter("@vouyear", SqlDbType.Int), 
        //                                                                             new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
        //                                                                             new SqlParameter("@trantype",SqlDbType.VarChar,2)
        //                                                                            };
        //    objp[0].Value = curr;
        //    objp[1].Value = rate;
        //    objp[2].Value = exrate;
        //    objp[3].Value = chabase;
        //    objp[4].Value = amount;
        //    objp[5].Value = refno;
        //    objp[6].Value = chargeid;
        //    objp[7].Value = oldbase;
        //    objp[8].Value = vouyear;
        //    objp[9].Value = branchid;
        //    objp[10].Value = trantype;
        //    ExecuteQuery("SPUpdProGridChrgs", objp);
        //}

        //Manoj

        public void UpdateProInvoiceDetails(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string oldbase, int vouyear, int branchid, string trantype, string type, double unit)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,45),                                                                                  
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                                                    };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = vouyear;
            objp[9].Value = branchid;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = unit;
            ExecuteQuery("SPUpdProGridChrgs", objp);
        }
        //public void DelProinvDetails(int refno, int  charge, string strbase,int vouyear, int branchid,string trantype)
        //{

        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),  
        //                                                                    new SqlParameter("@charge",SqlDbType.Int,4),
        //                                                                    new SqlParameter("@base",SqlDbType.VarChar,6),
        //                                                                    new SqlParameter("@vouyear",SqlDbType.Int), 
        //                                                                    new SqlParameter("@branchid", SqlDbType.TinyInt,1),
        //                                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2)
        //                                                                    };
        //    objp[0].Value = refno;
        //    objp[1].Value = charge;
        //    objp[2].Value = strbase;
        //    objp[3].Value = vouyear;
        //    objp[4].Value = branchid;
        //    objp[5].Value = trantype;
        //    ExecuteQuery("SPDelProInvcharge", objp);
        //}

        //Manoj

        public void DelProinvDetails(int refno, int charge, string strbase, int vouyear, int branchid, string trantype, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),  
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = charge;
            objp[2].Value = strbase;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = trantype;
            objp[6].Value = type;
            ExecuteQuery("SPDelProInvcharge", objp);
        }
        public DataTable CheckProinvCustblno(string blno, int custid, string strTranType, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@custid",SqlDbType.Int,4),  
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int), 
                                                     };
            objp[0].Value = blno;
            objp[1].Value = custid;
            objp[2].Value = strTranType;
            objp[3].Value = branchid;
            objp[4].Value = vouyear;
            return ExecuteTable("SPGetRefno", objp);
        }
        public DataTable CheckProinvCustblno(string blno, int custid, string strTranType, int branchid, int vouyear, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@custid",SqlDbType.Int,4),  
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2), 
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int), 
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = custid;
            objp[2].Value = strTranType;
            objp[3].Value = branchid;
            objp[4].Value = vouyear;
            objp[5].Value = type;
            return ExecuteTable("SPGetRefno", objp);
        }


        // Bonded Trucking//////

        /*public int InsertBTProfomaHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, string vendor, string type)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@date",SqlDbType.DateTime,8), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,50), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@vendorrefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@type",SqlDbType.VarChar,30),
                                                       new SqlParameter("@refno",SqlDbType.Int,4)};

            objp[0].Value = Dtdate;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = intcustomerid;
            objp[4].Value = blno;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = billtype;
            objp[8].Value = preparedby;
            objp[9].Value = vouyear;
            objp[10].Value = vendor;
            objp[11].Value = type;
            objp[12].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsBTProfomahead", objp, "@refno");
        }
        */


        /*  public void UpdateBTProfomaHead(int refno, int custid, string remarks, string strbilltype, int preparedby, int vouyear, int branchid, string trantype, string vendor, string type)
          {
              string billtype = CheckBillType(strbilltype);
              SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
                                                                                       new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                       new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                       new SqlParameter("@billtype",SqlDbType.Char,1),
                                                                                       new SqlParameter("@preparedby",SqlDbType.Int,4), 
                                                                                       new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
              new SqlParameter("@vendorrefno",SqlDbType.VarChar,30),
              new SqlParameter("@type",SqlDbType.VarChar,30)};
              objp[0].Value = custid;
              objp[1].Value = remarks;
              objp[2].Value = refno;
              objp[3].Value = billtype;
              objp[4].Value = preparedby;
              objp[5].Value = vouyear;
              objp[6].Value = branchid;
              objp[7].Value = trantype;
              objp[8].Value = vendor;
              objp[9].Value = type;
              ExecuteQuery("SPUpdBTProfomaHead", objp);
          }
          */

      /*  public void InsertBTProInvDetails(int invoiceno, int intchargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, int customerid, int vouyear, string billtype, string trantype, string ftype, double unit)
        {

            //int intchargeid = chrgobj.GetChargeid(chargename);
            //int customerid = GetCustomerid(customer, custcity);
            //string billtype = CheckBillType(billtypename);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),        
                                                         new SqlParameter("@charges",SqlDbType.Int,4), 
                                                         new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                         new SqlParameter("@rate",SqlDbType.Money,8),
                                                         new SqlParameter("@exrate",SqlDbType.Money,8),
                                                         new SqlParameter("@base",SqlDbType.VarChar,6),
                                                         new SqlParameter("@amount",SqlDbType.Money,8), 
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customerid",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                         new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@ftype",SqlDbType.VarChar,30),
                                                         new SqlParameter("@unit",SqlDbType.Decimal)};
            objp[0].Value = invoiceno;
            objp[1].Value = intchargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = exrate;
            objp[5].Value = strbase;
            objp[6].Value = famount;
            objp[7].Value = branchid;
            objp[8].Value = customerid;
            objp[9].Value = vouyear;
            objp[10].Value = billtype;
            objp[11].Value = trantype;
            objp[12].Value = ftype;
            objp[13].Value = unit;
            ExecuteQuery("SPInsBTProInvDetails", objp);
        }
        */




        public void InsertBTProInvDetails(int invoiceno, int intchargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, int customerid, int vouyear, string billtype, string trantype, string ftype, string servicetax, double unit)
        {

            //int intchargeid = chrgobj.GetChargeid(chargename);
            //int customerid = GetCustomerid(customer, custcity);
            //string billtype = CheckBillType(billtypename);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                         new SqlParameter("@charges",SqlDbType.Int,4),
                                                         new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                         new SqlParameter("@rate",SqlDbType.Money,8),
                                                         new SqlParameter("@exrate",SqlDbType.Money,8),
                                                         new SqlParameter("@base",SqlDbType.VarChar,45),
                                                         new SqlParameter("@amount",SqlDbType.Money,8),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@customerid",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                         new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@ftype",SqlDbType.VarChar,30),
                                                         new SqlParameter("@ServiceTax",SqlDbType.VarChar,1),
                                                         new SqlParameter("@unit",SqlDbType.Decimal)};
            objp[0].Value = invoiceno;
            objp[1].Value = intchargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = exrate;
            objp[5].Value = strbase;
            objp[6].Value = famount;
            objp[7].Value = branchid;
            objp[8].Value = customerid;
            objp[9].Value = vouyear;
            objp[10].Value = billtype;
            objp[11].Value = trantype;
            objp[12].Value = ftype;
            objp[13].Value = servicetax;
            objp[14].Value = unit;
            ExecuteQuery("SPInsBTProInvDetails", objp);
            // ExecuteQuery("SPInsProInvDtls", objp);
        }

        public int GetBTProBaseCharges(int refno, string strbase, int intchargeid, string type, int vouyear, int branchid, string func)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),  
                                                                            new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                             new SqlParameter("@charge",SqlDbType.Int,4),
                                                                           new SqlParameter("@type",SqlDbType.VarChar,20), 
                                                                           new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@func",SqlDbType.VarChar,30)};
            objp[0].Value = refno;
            objp[1].Value = strbase;
            objp[2].Value = intchargeid;
            objp[3].Value = type;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = func;
            return int.Parse(ExecuteReader("SPIProBTCountbase", objp));
        }

        public DataTable GetInvoiceDetailsforBT(int invoiceno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invno", SqlDbType.Int,4), 
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetProInvoicedtlsforBT", objp);
        }

        public void DelIPDetailsForBT(int invoiceno, int intcharge, string strbase, string ftype, int customerid, int vouyear, int branchid, string trantype)
        {
            //int customerid = GetCustomerid(customer, cityid);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),  
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                             new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                           new SqlParameter("@ftype",SqlDbType.VarChar,2), 
                                                                           new SqlParameter("@customerid",SqlDbType.Int,4), 
                                                                           new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@trantype", SqlDbType.VarChar,2)};
            objp[0].Value = invoiceno;
            objp[1].Value = intcharge;
            objp[2].Value = strbase;
            objp[3].Value = ftype;
            objp[4].Value = customerid;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = trantype;
            ExecuteQuery("SPDelInvchargeforBT", objp);
        }

        /* public void UpdateDetailsforBT(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string ftype, string oldbase, int vouyear, int branchid, string trantype,double unit)
         {

             SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                      new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                      new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                      new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                      new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                      new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                                      new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                      new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                                                      new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                                      new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                          new SqlParameter("@unit",SqlDbType.Decimal)};
             objp[0].Value = curr;
             objp[1].Value = rate;
             objp[2].Value = exrate;
             objp[3].Value = chabase;
             objp[4].Value = amount;
             objp[5].Value = refno;
             objp[6].Value = chargeid;
             objp[7].Value = oldbase;
             objp[8].Value = ftype;
             objp[9].Value = vouyear;
             objp[10].Value = branchid;
             objp[11].Value = trantype;
             objp[12].Value = unit;
             ExecuteQuery("SPUpdBTProdetails", objp);
         }*/

        //DINESH



        public void UpdateDetailsforBT(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string ftype, string oldbase, int vouyear, int branchid, string trantype, double unit, string servicetax, string headtype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),
            new SqlParameter("@rate",SqlDbType.Money,8),
            new SqlParameter("@exrate",SqlDbType.Money,8),
            new SqlParameter("@base",SqlDbType.VarChar,45),
new SqlParameter("@amount",SqlDbType.Money,8),
new SqlParameter("@invpano",SqlDbType.Int,4),
new SqlParameter("@chargeid",SqlDbType.Int,4),
new SqlParameter("@oldbase",SqlDbType.VarChar,45),
new SqlParameter("@ftype",SqlDbType.VarChar,20),
new SqlParameter("@vouyear", SqlDbType.Int),
new SqlParameter("@branchid", SqlDbType.TinyInt,1),
new SqlParameter("@trantype",SqlDbType.VarChar,2),
new SqlParameter("@unit",SqlDbType.Decimal),
new SqlParameter("@ServiceTax",SqlDbType.VarChar,1),
new SqlParameter("@ftypenew",SqlDbType.VarChar,30)
            };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = ftype;
            objp[9].Value = vouyear;
            objp[10].Value = branchid;
            objp[11].Value = trantype;
            objp[12].Value = unit;
            objp[13].Value = servicetax;
            objp[14].Value = headtype;
            ExecuteQuery("SPUpdBTProdetails", objp);
        }

        //Manoj
        public DataTable CheckchrgInvProDCN(int refno, string cbase, int charge, int vouyear, int branchid, string type, string opstype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@base",SqlDbType.VarChar,45), 
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@type",SqlDbType.VarChar,30),
            new SqlParameter("@opstype",SqlDbType.VarChar,1)};
            objp[0].Value = refno;
            objp[1].Value = cbase;
            objp[2].Value = charge;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = type;
            objp[6].Value = opstype;
            return ExecuteTable("SPCheckchrgInvProDCN", objp);
        }



        //GST

        //DINESH

        public void UpdateProHead(int refno, int custid, string remarks, string strbilltype, int preparedby, int vouyear, int branchid, string trantype, string type, string vendor, int creditdays, int SupplyTo)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@billtype",SqlDbType.Char,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@vendor",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),
                                                                                    new SqlParameter("@supplyto",SqlDbType.Int,4),  };
            objp[0].Value = custid;
            objp[1].Value = remarks;
            objp[2].Value = refno;
            objp[3].Value = billtype;
            objp[4].Value = preparedby;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = trantype;
            objp[8].Value = type;
            objp[9].Value = vendor;
            objp[10].Value = creditdays;
            objp[11].Value = SupplyTo;
            ExecuteQuery("SPUpdProinvHead", objp);
        }





        public void UpdateProHeadnew(int refno, int custid, string remarks, string strbilltype, int preparedby, int vouyear, int branchid, string trantype, string type, string vendor, int creditdays, int SupplyTo, DateTime vendorrefdate)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@billtype",SqlDbType.Char,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@type",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@vendor",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),
                                                                                    new SqlParameter("@supplyto",SqlDbType.Int,4),
                                                                                    new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8) };
            objp[0].Value = custid;
            objp[1].Value = remarks;
            objp[2].Value = refno;
            objp[3].Value = billtype;
            objp[4].Value = preparedby;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = trantype;
            objp[8].Value = type;
            objp[9].Value = vendor;
            objp[10].Value = creditdays;
            objp[11].Value = SupplyTo;
            objp[12].Value = vendorrefdate;
            ExecuteQuery("SPUpdProinvHead", objp);
        }



        public void UpdChargesGST4OldVou(int refno, int branchid, int vouyear, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int,4), 
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,30)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = type;
            ExecuteQuery("SPUpdChargesGST4OldVou", objp);
            //return ExecuteTable("SPUpdChargesGST4OldVou", objp);
        }


        public void UpdateBTProfomaHead(int refno, int custid, string remarks, string strbilltype, int preparedby, int vouyear, int branchid, string trantype, string vendor, string type, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@billtype",SqlDbType.Char,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@vendorrefno",SqlDbType.VarChar,30),
            new SqlParameter("@type",SqlDbType.VarChar,30),
            new SqlParameter("@supplyto",SqlDbType.Int,4)};
            objp[0].Value = custid;
            objp[1].Value = remarks;
            objp[2].Value = refno;
            objp[3].Value = billtype;
            objp[4].Value = preparedby;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = trantype;
            objp[8].Value = vendor;
            objp[9].Value = type;
            objp[10].Value = supplyto;
            ExecuteQuery("SPUpdBTProfomaHead", objp);
        }


        //Dinesh

        public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, string type, string vendorrefno, int creditdays, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@date",SqlDbType.DateTime,8), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,30),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),
                                                       new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@creditdays",SqlDbType.TinyInt ),  new SqlParameter("@supplyto",SqlDbType.Int,4)
                                   };

            objp[0].Value = Dtdate;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = intcustomerid;
            objp[4].Value = blno;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = billtype;
            objp[8].Value = preparedby;
            objp[9].Value = vouyear;
            objp[10].Value = type;
            objp[11].Direction = ParameterDirection.Output;
            objp[12].Value = vendorrefno;
            objp[13].Value = creditdays;
            objp[14].Value = supplyto;
            return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
        }



        public int InsertProInvoiceHeadnew(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, string type, string vendorrefno, int creditdays, int supplyto, DateTime vendorrefdate)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@date",SqlDbType.DateTime,8), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,30),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),
                                                       new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@creditdays",SqlDbType.TinyInt ),  new SqlParameter("@supplyto",SqlDbType.Int,4),new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8)
                                   };

            objp[0].Value = Dtdate;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = intcustomerid;
            objp[4].Value = blno;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = billtype;
            objp[8].Value = preparedby;
            objp[9].Value = vouyear;
            objp[10].Value = type;
            objp[11].Direction = ParameterDirection.Output;
            objp[12].Value = vendorrefno;
            objp[13].Value = creditdays;
            objp[14].Value = supplyto;
            objp[15].Value = vendorrefdate;
            return ExecuteQuery("SPInsProInvoicehead", objp, "@refno");
        }





        //Dinesh
        public int InsertBTProfomaHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, string vendor, string type, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@date",SqlDbType.DateTime,8), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,50), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@vendorrefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@type",SqlDbType.VarChar,30),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),new SqlParameter("@supplyto",SqlDbType.Int,4)};

            objp[0].Value = Dtdate;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = intcustomerid;
            objp[4].Value = blno;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = billtype;
            objp[8].Value = preparedby;
            objp[9].Value = vouyear;
            objp[10].Value = vendor;
            objp[11].Value = type;
            objp[12].Direction = ParameterDirection.Output;
            objp[13].Value = supplyto;
            return ExecuteQuery("SPInsBTProfomahead", objp, "@refno");
        }



        //GST

        public string CheckBillType(string strbilltype)
        {
            switch (strbilltype)
            {
                case ("Cash/Cheque"):
                    return "C";

                case ("Credit"):
                    return "D";

                case ("ST/GST Exemption"):
                    return "S";

                case ("Internal"):
                    return "I";
                case ("Profit Share"):
                    return "P";
                default:
                    return "X";
            }
        }
        public void UpdateProInvoiceDetailsertax(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string oldbase, int vouyear, int branchid, string trantype, string type, double unit, string gst)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,6),                                                                                  
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@unit",SqlDbType.Decimal),
                new SqlParameter("@GST",SqlDbType.VarChar,1)
                                                                                    };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = vouyear;
            objp[9].Value = branchid;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = unit;
            objp[13].Value = gst;
            ExecuteQuery("SPUpdProGridChrgservicetaxgst", objp);
        }


        //Dinesh

        public DataTable GetProInvoiceDetailsnew(int refno, int vouyear, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int,4), 
                                                      
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteTable("SPGetProInvoiceDtlsnew", objp);
        }


        public DataTable GetStateid(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@customerid",SqlDbType.Int,4)
                    };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetsateid", objp);
        }

        public DataTable GetbranchStateid(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@branchid",SqlDbType.Int,4)
                    };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetbranchsateid", objp);
        }



        public void InsertProInvoiceDetailsamend(int refno, int charge, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, string strbilltype, string trantype, string type, string ServiceTax, double unit, double lcamt, double totgst, double sgstp, double sgsta, double cgstp, double cgsta, double igstp, double igsta)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),        
                                                       new SqlParameter("@charges",SqlDbType.Int,4), 
                                                       new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@rate",SqlDbType.Money,8),
                                                       new SqlParameter("@exrate",SqlDbType.Money,8),
                                                       new SqlParameter("@base",SqlDbType.VarChar,45),
                                                       new SqlParameter("@amount",SqlDbType.Money,8), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@ServiceTax",SqlDbType.VarChar,2),
                new SqlParameter("@unit",SqlDbType.Decimal),
                new SqlParameter("@loc_amount",SqlDbType.Money,8),
                new SqlParameter("@Totgst",SqlDbType.Real,8),    
                    new SqlParameter("@sgstp",SqlDbType.Money,8),
                   new SqlParameter("@sgsta",SqlDbType.Money,8),
                new SqlParameter("@cgstp",SqlDbType.Real,8), 
             new SqlParameter("@cgsta",SqlDbType.Money,8),
              new SqlParameter("@igstp",SqlDbType.Real,8),
                new SqlParameter("@igsta",SqlDbType.Money,8)
                                                    };
            objp[0].Value = billtype;
            objp[1].Value = refno;
            objp[2].Value = charge;
            objp[3].Value = curr;
            objp[4].Value = rate;
            objp[5].Value = exrate;
            objp[6].Value = strbase;
            objp[7].Value = famount;
            objp[8].Value = branchid;
            objp[9].Value = vouyear;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = ServiceTax;
            objp[13].Value = unit;
            objp[14].Value = lcamt;
            objp[15].Value = totgst;
            objp[16].Value = sgstp;
            objp[17].Value = sgsta;
            objp[18].Value = cgstp;
            objp[19].Value = cgsta;
            objp[20].Value = igstp;
            objp[21].Value = igsta;
            ExecuteQuery("SPInsProInvDtlsAmendcnops", objp);
        }


        public void updateProInvoiceDetailsamend(int refno, int charge, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, string strbilltype, string trantype, string type, string ServiceTax, double unit, double lcamt, double totgst, double sgstp, double sgsta, double cgstp, double cgsta, double igstp, double igsta)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),        
                                                       new SqlParameter("@charges",SqlDbType.Int,4), 
                                                       new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@rate",SqlDbType.Money,8),
                                                       new SqlParameter("@exrate",SqlDbType.Money,8),
                                                       new SqlParameter("@base",SqlDbType.VarChar,45),
                                                       new SqlParameter("@amount",SqlDbType.Money,8), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@ServiceTax",SqlDbType.VarChar,2),
                new SqlParameter("@unit",SqlDbType.Decimal),
                new SqlParameter("@loc_amount",SqlDbType.Money,8),
                new SqlParameter("@Totgst",SqlDbType.Real,8),    
                    new SqlParameter("@sgstp",SqlDbType.Money,8),
                   new SqlParameter("@sgsta",SqlDbType.Money,8),
                new SqlParameter("@cgstp",SqlDbType.Real,8), 
             new SqlParameter("@cgsta",SqlDbType.Money,8),
              new SqlParameter("@igstp",SqlDbType.Real,8),
                new SqlParameter("@igsta",SqlDbType.Money,8)
                                                    };
            objp[0].Value = billtype;
            objp[1].Value = refno;
            objp[2].Value = charge;
            objp[3].Value = curr;
            objp[4].Value = rate;
            objp[5].Value = exrate;
            objp[6].Value = strbase;
            objp[7].Value = famount;
            objp[8].Value = branchid;
            objp[9].Value = vouyear;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = ServiceTax;
            objp[13].Value = unit;
            objp[14].Value = lcamt;
            objp[15].Value = totgst;
            objp[16].Value = sgstp;
            objp[17].Value = sgsta;
            objp[18].Value = cgstp;
            objp[19].Value = cgsta;
            objp[20].Value = igstp;
            objp[21].Value = igsta;
            ExecuteQuery("SPupdateProInvDtlsAmendcnops", objp);
        }

        //Dinesh
        public DataTable SelProInvHeadnew(int refno, string strantype, int vouyear, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),  
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@type",SqlDbType.VarChar,30)};
            objp[0].Value = refno;
            objp[1].Value = strantype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = type;
            //return ExecuteTable("SPSelProInvHead", objp);

            return ExecuteTable("SPSelProInvHeadajobclose", objp);

        }

        //dINESH
        public void InsertProInvoiceDetailsNEW(int refno, int charge, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, string strbilltype, string trantype, string type, string ServiceTax, double unit)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),        
                                                       new SqlParameter("@charges",SqlDbType.Int,4), 
                                                       new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@rate",SqlDbType.Money,8),
                                                       new SqlParameter("@exrate",SqlDbType.Money,8),
                                                       new SqlParameter("@base",SqlDbType.VarChar,45),
                                                       new SqlParameter("@amount",SqlDbType.Money,8), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@ServiceTax",SqlDbType.VarChar,2),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                    };
            objp[0].Value = billtype;
            objp[1].Value = refno;
            objp[2].Value = charge;
            objp[3].Value = curr;
            objp[4].Value = rate;
            objp[5].Value = exrate;
            objp[6].Value = strbase;
            objp[7].Value = famount;
            objp[8].Value = branchid;
            objp[9].Value = vouyear;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = ServiceTax;
            objp[13].Value = unit;
            ExecuteQuery("SPInsProInvDtlsnew", objp);
        }

        public void UpdateProInvoiceDetailsNEW(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string oldbase, int vouyear, int branchid, string trantype, string type, double unit)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,45),                                                                                  
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                                                    };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = vouyear;
            objp[9].Value = branchid;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = unit;
            ExecuteQuery("SPUpdProGridChrgsnew", objp);
        }

        public void DelProinvDetailsNEW(int refno, int charge, string strbase, int vouyear, int branchid, string trantype, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),  
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = charge;
            objp[2].Value = strbase;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = trantype;
            objp[6].Value = type;
            ExecuteQuery("SPDelProInvchargenew", objp);
        }


        //Dinesh

        public DataTable CheckProfomainvoice(string blno, string strantype, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),  
                                                       new SqlParameter("@branchid", SqlDbType.Int,3),
                                                       new SqlParameter("@type",SqlDbType.VarChar,35)};
            objp[0].Value = blno;
            objp[1].Value = strantype;
            objp[2].Value = branchid;
            objp[3].Value = type;
            //return ExecuteTable("SPSelProInvHead", objp);
            return ExecuteTable("SP_Checkprofomainvoice", objp);
        }

        //dinesh

        public DataTable Getinvoicecount(string blno, int bid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@blno",SqlDbType.VarChar,50),

             
                new SqlParameter("@branchid", SqlDbType.Int), 
                  new SqlParameter("@jobno", SqlDbType.Int)

         };
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = jobno;
            return ExecuteTable("spinvoicecount", objp);
        }

        public DataTable Getpacount(string blno, int bid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@blno",SqlDbType.VarChar,50),

             
                new SqlParameter("@branchid", SqlDbType.Int), 
                  new SqlParameter("@jobno", SqlDbType.Int)

         };
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = jobno;
            return ExecuteTable("sppacount", objp);
        }
        //new


        


        



       

        


         
       
        public void InsertProInvoiceDetailsFC(int refno, int charge, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, string strbilltype, string trantype, string type, string ServiceTax, double unit)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),        
                                                       new SqlParameter("@charges",SqlDbType.Int,4), 
                                                       new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@rate",SqlDbType.Money,8),
                                                       new SqlParameter("@exrate",SqlDbType.Money,8),
                                                       new SqlParameter("@base",SqlDbType.VarChar,35),
                                                       new SqlParameter("@amount",SqlDbType.Money,8), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@ServiceTax",SqlDbType.VarChar,2),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                    };
            objp[0].Value = billtype;
            objp[1].Value = refno;
            objp[2].Value = charge;
            objp[3].Value = curr;
            objp[4].Value = rate;
            objp[5].Value = exrate;
            objp[6].Value = strbase;
            objp[7].Value = famount;
            objp[8].Value = branchid;
            objp[9].Value = vouyear;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = ServiceTax;
            objp[13].Value = unit;
            ExecuteQuery("SPInsProInvDtlsFC", objp);
        }
        public void UpdateProInvoiceDetailsertaxFC(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string oldbase, int vouyear, int branchid, string trantype, string type, double unit, string gst)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,6),                                                                                  
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@unit",SqlDbType.Decimal),
                new SqlParameter("@GST",SqlDbType.VarChar,1)
                                                                                    };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = vouyear;
            objp[9].Value = branchid;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = unit;
            objp[13].Value = gst;
            ExecuteQuery("SPUpdProGridChrgservicetaxgstFC", objp);
        }

        public void UpdateProInvoiceDetailsFC(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string oldbase, int vouyear, int branchid, string trantype, string type, double unit)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,35),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,35),                                                                                  
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                                                    };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = vouyear;
            objp[9].Value = branchid;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = unit;
            ExecuteQuery("SPUpdProGridChrgsFC", objp);
        }
        //

        public DataTable SelProLVHead(int refno, string strantype, int vouyear, int branchid, int type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),  
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@type",SqlDbType.Int)};
            objp[0].Value = refno;
            objp[1].Value = strantype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = type;
            return ExecuteTable("SPSelProLVHead", objp);
        }
        public DataTable GetProLVDetails(int refno, int vouyear, int branchid, int type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int,4), 
                                                      
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                new SqlParameter("@type",SqlDbType.Int)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteTable("SPGetProLVDtls", objp);
        }
        public int InsProLVhead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, int type, string vendorrefno, int creditdays, int supplyto, DateTime vendorrefdate)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@date",SqlDbType.DateTime,8), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.Int),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),
                                                       new SqlParameter("@vendorrefno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@creditdays",SqlDbType.TinyInt ),  new SqlParameter("@supplyto",SqlDbType.Int,4),new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8)
                                   };

            objp[0].Value = Dtdate;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = intcustomerid;
            objp[4].Value = blno;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = billtype;
            objp[8].Value = preparedby;
            objp[9].Value = vouyear;
            objp[10].Value = type;
            objp[11].Direction = ParameterDirection.Output;
            objp[12].Value = vendorrefno;
            objp[13].Value = creditdays;
            objp[14].Value = supplyto;
            objp[15].Value = vendorrefdate;
            return ExecuteQuery("SPInsProLVhead", objp, "@refno");
        }
        public void UpdateProLVHead(int refno, int custid, string remarks, string strbilltype, int preparedby, int vouyear, int branchid, string trantype, int type, string vendor, int creditdays, int SupplyTo, DateTime vendorrefdate)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150), 
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@billtype",SqlDbType.Char,1),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@type",SqlDbType.Int),
                                                                                     new SqlParameter("@vendor",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt ),
                                                                                    new SqlParameter("@supplyto",SqlDbType.Int,4),
                                                                                    new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8) };
            objp[0].Value = custid;
            objp[1].Value = remarks;
            objp[2].Value = refno;
            objp[3].Value = billtype;
            objp[4].Value = preparedby;
            objp[5].Value = vouyear;
            objp[6].Value = branchid;
            objp[7].Value = trantype;
            objp[8].Value = type;
            objp[9].Value = vendor;
            objp[10].Value = creditdays;
            objp[11].Value = SupplyTo;
            objp[12].Value = vendorrefdate;
            ExecuteQuery("SPUpdProLVHead", objp);
        }
        public void UpdChargesGST4OldVouLV(int refno, int branchid, int vouyear, int type)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int,4), 
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.Int)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = type;
            ExecuteQuery("SPUpdChargesGST4OldVouLV", objp);
            //return ExecuteTable("SPUpdChargesGST4OldVou", objp);
        }
        public DataTable CheckchrgInvProLV(int refno, string cbase, int charge, int vouyear, int branchid, int type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@base",SqlDbType.VarChar,6), 
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@type",SqlDbType.Int)};
            objp[0].Value = refno;
            objp[1].Value = cbase;
            objp[2].Value = charge;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = type;
            return ExecuteTable("SPCheckchrgInvProLV", objp);
        }

        public void InsertProLVDetails(int refno, int charge, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, 
            string strbilltype, string trantype, int type, string ServiceTax, double unit)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@refno",SqlDbType.Int,4),        
                                                       new SqlParameter("@charges",SqlDbType.Int,4), 
                                                       new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@rate",SqlDbType.Money,8),
                                                       new SqlParameter("@exrate",SqlDbType.Money,8),
                                                       new SqlParameter("@base",SqlDbType.VarChar,45),
                                                       new SqlParameter("@amount",SqlDbType.Money,8), 
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@ServiceTax",SqlDbType.VarChar,2),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                    };
            objp[0].Value = billtype;
            objp[1].Value = refno;
            objp[2].Value = charge;
            objp[3].Value = curr;
            objp[4].Value = rate;
            objp[5].Value = exrate;
            objp[6].Value = strbase;
            objp[7].Value = famount;
            objp[8].Value = branchid;
            objp[9].Value = vouyear;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = ServiceTax;
            objp[13].Value = unit;
            ExecuteQuery("SPInsProLVDtls", objp);
        }
        public void UpdateProLVDetails(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string oldbase, int vouyear, int branchid, string trantype, int type, double unit)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,45),                                                                                  
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@unit",SqlDbType.Decimal)
                                                                                    };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = vouyear;
            objp[9].Value = branchid;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = unit;
            ExecuteQuery("SPUpdProLVdetails", objp);
        }
        public void UpdateProLVDetailsertax(int refno, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string oldbase, int vouyear, int branchid, string trantype, int type, double unit, string gst)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),        
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4), 
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,6),                                                                                  
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int), 
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),                                                    
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@unit",SqlDbType.Decimal),
                new SqlParameter("@GST",SqlDbType.VarChar,1)
                                                                                    };
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = refno;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = vouyear;
            objp[9].Value = branchid;
            objp[10].Value = trantype;
            objp[11].Value = type;
            objp[12].Value = unit;
            objp[13].Value = gst;
            ExecuteQuery("SPUpdProLVChrgservicetaxgst", objp);
        }

        public void DelProLVDetails(int refno, int charge, string strbase, int vouyear, int branchid, string trantype, int type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@refno",SqlDbType.Int,4),  
                                                                            new SqlParameter("@charge",SqlDbType.Int,4),
                                                                            new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int), 
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.Int)
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = charge;
            objp[2].Value = strbase;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            objp[5].Value = trantype;
            objp[6].Value = type;
            ExecuteQuery("SPDelProLVcharge", objp);
        }
        public DataTable CheckProfomainvoiceOSV(string blno, string strantype, int branchid, int type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),  
                                                       new SqlParameter("@branchid", SqlDbType.Int,3),
                                                       new SqlParameter("@type",SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = strantype;
            objp[2].Value = branchid;
            objp[3].Value = type;
            //return ExecuteTable("SPSelProInvHead", objp);
            return ExecuteTable("SP_CheckprofomainvoiceOSV", objp);
        }
        public DataTable Checkvenrefno(string vendrefno)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@vendrefno",SqlDbType.VarChar,50),

              

         };
            objp[0].Value = vendrefno;

            return ExecuteTable("SPCheckvenrefno", objp);
        }
        public void UpdAfterjobclose(int refno,int bid,int voutype,string type)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@refno",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@voutype",SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.VarChar,10)
              

         };
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = voutype;
            objp[3].Value = type;


            ExecuteQuery("SPUpdAfterjobclose", objp);
        }
        public DataTable Checksamegst4Proforma(int bid,int custid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid",SqlDbType.Int),
            new SqlParameter("@custid",SqlDbType.Int)

              

         };
            objp[0].Value = bid;
            objp[1].Value = custid;

            return ExecuteTable("SPChecksamegst4Proforma", objp);
        }
    }
}
