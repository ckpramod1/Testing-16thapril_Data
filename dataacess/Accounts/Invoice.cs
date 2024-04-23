using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class Invoice : DBObject
    {
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterEmployee EmpObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();

        //Method to fillReaderopdownlist base

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Invoice()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable BaseFill()
        {

            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPShowContype", objp);
        }
        //Method to get invoiceHead for FE and FI 
        public DataTable GetHblInvoiceHead(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelInvHead", objp);
        }

        //method to get InvoiceHead for masterBL (AE/AI)
        public DataTable GetMblInvoiceHead(string mblno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = mblno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPInvHeadMbl", objp);
        }

        //to fill Containernumber,volume,weight in  containerlistbox for FE HBL
        public DataTable GetHBLContainerDtls(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPHblInvContno", objp);
        }

        // to fill containerlistbox for FE MBL
        public DataTable GetMblContainerDtls(int jobno, string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = strTranType;
            objp[3].Value = branchid;
            return ExecuteTable("SPInvMblContno", objp);
        }

        //  FE,to fill corresponding container sizetye and no of containers for hbl & mbl
        public DataTable GetHblNoOfContainers(int jobno, string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = strTranType;
            objp[3].Value = branchid;
            return ExecuteTable("SPHblInvNoofContLV", objp);
        }

        //FI,for MBL
        public DataTable GetFIMblNContainers(string jobno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            return ExecuteTable("SPFIInvMblNCont", objp);
        }

        //to generate the invoice number
        public int GetInvoiceNo(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCInv", objp));
        }

        // to generate the paymentAdvice number
        public int GetPaymentadviceNo(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCPA", objp));
        }

        //to check particular customer and blno exist for all trantype in invoice 
        public DataTable CheckInvCustblno(string blno, int custid, string strTranType, string ftype, int branchid, int vouyear, char agent)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@custid",SqlDbType.Int,4),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = custid;
            objp[2].Value = strTranType;
            objp[3].Value = ftype;
            objp[4].Value = branchid;
            objp[5].Value = vouyear;

            return ExecuteTable("SPGetInvoiceno", objp);
        }


        //------------------------------------------------------------------------------------------

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






        //----------------------------------------------------------------------------------------------
        public String GetBillType(char strbilltype)
        {
            switch (strbilltype)
            {
                case 'C':
                    return "Cash/Cheque";

                case 'D':
                    return "Credit";

                case 'S':
                    return "Service Tax Exemption";

                case 'I':
                    return "Internal";
                case 'P':
                    return "Profit Share";

                default:
                    return "Invalid";
            }
        }
        //----------------------------------------------------------------------------------
        public void InsertInvoiceHead(int invoiceno, DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int userid, string ftype, int vouyear, char agent, string vendorrefno)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                     new SqlParameter("@invoicedate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@vendorrefno",SqlDbType.VarChar,30)};
            objp[0].Value = invoiceno;
            objp[1].Value = Dtdate;
            objp[2].Value = strTranType;
            objp[3].Value = jobno;
            objp[4].Value = intcustomerid;
            objp[5].Value = blno;
            objp[6].Value = remarks;
            objp[7].Value = branchid;
            objp[8].Value = billtype;
            objp[9].Value = userid;
            objp[10].Value = vouyear;
            objp[11].Value = vendorrefno;

            //objp[10].Value = vouyear;
            //objp[11].Value = billtype;
            if (ftype == "Invoice" || ftype == "BTInvoice")
            {
                ExecuteQuery("SPInsInvoice", objp);
            }
            else if (ftype == "Debit Note")
            {
                ExecuteQuery("SPInsDNHead", objp);
            }
            else if (ftype == "Credit Note")
            {
                ExecuteQuery("SPInsCNHead", objp);
            }
        }


        //KUMAR

        ////public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int userid, string ftype, int vouyear, string type, string vendor)
        ////{
        ////    string billtype = CheckBillType(strbilltype);
        ////    SqlParameter[] objp = new SqlParameter[] {       
        ////                                             new SqlParameter("@invoicedate",SqlDbType.DateTime,8), 
        ////                                             new SqlParameter("@trantype",SqlDbType.VarChar,2),
        ////                                             new SqlParameter("@jobno",SqlDbType.Int,4),
        ////                                             new SqlParameter("@customerid",SqlDbType.Int,4),
        ////                                             new SqlParameter("@blno",SqlDbType.VarChar,30),
        ////                                             new SqlParameter("@remarks",SqlDbType.VarChar,150), 
        ////                                             new SqlParameter("@branchid",SqlDbType.Int,4),
        ////                                             new SqlParameter("@billtype",SqlDbType.VarChar,1),
        ////                                             new SqlParameter("@preparedby",SqlDbType.Int,4),
        ////                                             new SqlParameter("@vouyear",SqlDbType.Int),
        ////        new SqlParameter("@type",SqlDbType.VarChar,30),
        ////        new SqlParameter("@vendor",SqlDbType.VarChar,30),
        ////                                             new SqlParameter("@refno",SqlDbType.Int,4)};
        ////    objp[0].Value = Dtdate;
        ////    objp[1].Value = strTranType;
        ////    objp[2].Value = jobno;
        ////    objp[3].Value = intcustomerid;
        ////    objp[4].Value = blno;
        ////    objp[5].Value = remarks;
        ////    objp[6].Value = branchid;
        ////    objp[7].Value = billtype;
        ////    objp[8].Value = userid;
        ////    objp[9].Value = vouyear;
        ////    objp[10].Value = type;
        ////    objp[11].Value = vendor;
        ////    objp[12].Direction = ParameterDirection.Output;
        ////    return ExecuteQuery("SpInsProDCnHead", objp, "@refno");

        ////}

        /*    public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int userid, string ftype, int vouyear, string type, string vendor, int creditdays)
            {
                string billtype = CheckBillType(strbilltype);
                SqlParameter[] objp = new SqlParameter[] {       
                                                         new SqlParameter("@invoicedate",SqlDbType.DateTime,8), 
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
                                                         new SqlParameter("@vendor",SqlDbType.VarChar,30),
                                                         new SqlParameter("@refno",SqlDbType.Int,4),
                                                         new SqlParameter("@creditdays",SqlDbType.Int,4)};
                objp[0].Value = Dtdate;
                objp[1].Value = strTranType;
                objp[2].Value = jobno;
                objp[3].Value = intcustomerid;
                objp[4].Value = blno;
                objp[5].Value = remarks;
                objp[6].Value = branchid;
                objp[7].Value = billtype;
                objp[8].Value = userid;
                objp[9].Value = vouyear;
                objp[10].Value = type;
                objp[11].Value = vendor;
                objp[12].Direction = ParameterDirection.Output;
                objp[13].Value = creditdays;
                return ExecuteQuery("SpInsProDCnHead", objp, "@refno");

            }*/



        //public void InsertInvoiceHead(int invoiceno, DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int userid, string ftype, int vouyear, char agent, string vendorrefno)
        //{
        //    string billtype = CheckBillType(strbilltype);
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),        
        //                                             new SqlParameter("@invoicedate",SqlDbType.DateTime,8), 
        //                                             new SqlParameter("@trantype",SqlDbType.VarChar,2),
        //                                             new SqlParameter("@jobno",SqlDbType.Int,4),
        //                                             new SqlParameter("@customerid",SqlDbType.Int,4),
        //                                             new SqlParameter("@blno",SqlDbType.VarChar,30),
        //                                             new SqlParameter("@remarks",SqlDbType.VarChar,150), 
        //                                             new SqlParameter("@branchid",SqlDbType.Int,4),
        //                                             new SqlParameter("@billtype",SqlDbType.VarChar,1),
        //                                             new SqlParameter("@preparedby",SqlDbType.Int,4),
        //                                             new SqlParameter("@vouyear",SqlDbType.Int),
        //                                             new SqlParameter("@vendorrefno",SqlDbType.VarChar,30)};
        //    objp[0].Value = invoiceno;
        //    objp[1].Value = Dtdate;
        //    objp[2].Value = strTranType;
        //    objp[3].Value = jobno;
        //    objp[4].Value = intcustomerid;
        //    objp[5].Value = blno;
        //    objp[6].Value = remarks;
        //    objp[7].Value = branchid;
        //    objp[8].Value = billtype;
        //    objp[9].Value = userid;
        //    objp[10].Value = vouyear;
        //    objp[11].Value = vendorrefno;

        //    //objp[10].Value = vouyear;
        //    //objp[11].Value = billtype;
        //    if (ftype == "Invoice" || ftype == "BTInvoice")
        //    {
        //        ExecuteQuery("SPInsInvoice", objp);
        //    }
        //    else if (ftype == "Debit Note")
        //    {
        //        ExecuteQuery("SPInsDNHead", objp);
        //    }
        //    else if (ftype == "Credit Note")
        //    {
        //        ExecuteQuery("SPInsCNHead", objp);
        //    }
        //}


        public void InsertPAHead(int pano, DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int userid, int vouyear, string vendorrefno)
        {
            string billtype = CheckBillType(strbilltype);
            //int userid = EmpObj.GetEmpid(preparedby);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pano",SqlDbType.Int,4),
                                                         new SqlParameter("@padate",SqlDbType.SmallDateTime,4),
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                         new SqlParameter("@jobno",SqlDbType.Int,4),
                                                         new SqlParameter("@customerid",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@remarks",SqlDbType.VarChar,150),
                                                         new SqlParameter("@branchid",SqlDbType.Int,4),
                                                         new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                          new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                          new SqlParameter ("@venrefno",SqlDbType.VarChar,30)};
            objp[0].Value = pano;
            objp[1].Value = Dtdate;
            objp[2].Value = strTranType;
            objp[3].Value = jobno;
            objp[4].Value = intcustomerid;
            objp[5].Value = blno;
            objp[6].Value = remarks;
            objp[7].Value = branchid;
            objp[8].Value = billtype;
            objp[9].Value = userid;
            objp[10].Value = vouyear;
            objp[11].Value = vendorrefno;
            ExecuteQuery("SPInsPAHead", objp);
        }

        //method to get chargedetails using blno and date
        public DataTable GetChargedetails(string blno, DateTime Dtdate, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@Dtdate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = Dtdate;
            objp[2].Value = branchid;
            return ExecuteTable("SPInvCharge", objp);
        }

        public DataTable GetChargeFromBuyingdetails(string blno, DateTime Dtdate, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@dtdate",SqlDbType.SmallDateTime,4),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = Dtdate;
            objp[2].Value = branchid; ;
            return ExecuteTable("SPInvChargeFromBBuyingDts", objp);
        }

        public void InsertInvoiceDetails(int invoiceno, int intchargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, string ftype, int customerid, int vouyear, string billtype, string trantype)
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
                                                         new SqlParameter("@ftype",SqlDbType.VarChar,10),
                                                         new SqlParameter("@customerid",SqlDbType.Int,4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int),
                                                         new SqlParameter("@billtype",SqlDbType.VarChar,1),
                                                         new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = invoiceno;
            objp[1].Value = intchargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = exrate;
            objp[5].Value = strbase;
            objp[6].Value = famount;
            objp[7].Value = branchid;
            objp[8].Value = ftype;
            objp[9].Value = customerid;
            objp[10].Value = vouyear;
            objp[11].Value = billtype;
            objp[12].Value = trantype;
            ExecuteQuery("SPInsInvDetails", objp);
        }

        // method to insert the payment details
        public void InsertPADetails(int pano, int intchargeid, string curr, double rate, double exrate, string strbase, double famount, int branchid, int vouyear, string ServiceTax, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pano",SqlDbType.Int,4),
                                                     new SqlParameter("@charges",SqlDbType.Int,4),
                                                     new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                     new SqlParameter("@base",SqlDbType.VarChar,45),
                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                     new SqlParameter("@STA",SqlDbType.VarChar,1),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = pano;
            objp[1].Value = intchargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = exrate;
            objp[5].Value = strbase;
            objp[6].Value = famount;
            objp[7].Value = branchid;
            objp[8].Value = vouyear;
            objp[9].Value = ServiceTax;
            objp[10].Value = trantype;
            ExecuteQuery("SPInsPADetails", objp);
        }


        // method to get the volume to fill in containerlistbox
        public float GetVolume(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPInvVolume", objp));
        }
        //--------------------------------------------------------------

        //method to fill the weight in containerlistbox
        public float GetWeight(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPInvWeightLV", objp));
        }

        //------------------------------------------------------------
        // method to get chargeweight for AE/AI
        public float GetChargeWeight(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPAIEInvChrgweight", objp));
        }
        //-----------------------------------------------------------------------

        //method is used in checkbase function to calculate amount
        public float GetSumofChargeWght(int jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPAIEInvSumChrgweight", objp));
        }

        //----------------------------------------------------------------------
        // method is used to get sum of volume to calculate the amount in checkbase function
        public float GetSumofVolume(string jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPFIEInvSVolume", objp));
        }
        //---------------------------------------------------------------

        // method is used to get sum of weight to calculate the amount in checkbase function
        public float GetSumofWeight(string jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPFIEInvSWeight", objp));
        }
        //-------------------------------------------------------------------------

        //to count the particular chargebase for given blno
        public int GetBaseCount(string blno, string chargebase, string strTranType, string bltype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@chargebase",SqlDbType.VarChar,6),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bltype",SqlDbType.VarChar,3),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = chargebase;
            objp[2].Value = strTranType;
            objp[3].Value = bltype;
            objp[4].Value = branchid;
            return int.Parse(ExecuteReader("SPFIEInvchrgbase", objp));
        }
        public int GetSBillCount(string blno, int jobno, string billtype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@billtype",SqlDbType.VarChar,3),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = billtype;
            objp[3].Value = branchid;
            return int.Parse(ExecuteReader("SPCountShippingBill", objp));
        }

        // method to get grossweight for CH
        public float GetGrossWeight(string docno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1) };

            objp[0].Value = docno;
            objp[1].Value = branchid;
            return float.Parse(ExecuteReader("SPCHInvGrosswt", objp));
        }

        // method to get grossweight for CH
        public float GetVolumeQty(string docno, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1) };

            objp[0].Value = docno;
            objp[1].Value = branchid; ;
            return float.Parse(ExecuteReader("SPCHInvVolumeQty", objp));
        }

        //used to fill the invoice details in the form when invoiceno given
        public DataTable GetInvoiceDetails(int invoiceno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invno", SqlDbType.Int,4),
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,5),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetInvoiceDtls", objp);
        }

        //to update the details in Grid 
        public void UpdateDetails(int intinvpano, int chargeid, string curr, double rate, double exrate, string chabase, double amount, string strvtype, string oldbase, int vouyear, int branchid, string ServiceTax, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@rate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@exrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                                     new SqlParameter("@amount",SqlDbType.Money,8),
                                                                                     new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                                     new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@oldbase",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@vouyear", SqlDbType.Int),
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@STA",SqlDbType.VarChar,1),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = curr;
            objp[1].Value = rate;
            objp[2].Value = exrate;
            objp[3].Value = chabase;
            objp[4].Value = amount;
            objp[5].Value = intinvpano;
            objp[6].Value = chargeid;
            objp[7].Value = oldbase;
            objp[8].Value = strvtype;
            objp[9].Value = vouyear;
            objp[10].Value = branchid;
            objp[11].Value = ServiceTax;
            objp[12].Value = trantype;
            ExecuteQuery("SPUpdInvGridChrgs", objp);
        }
        //method to update the payment advice details
        public DataTable GetPADetails(int pano, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pano", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1) };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetPADtls", objp);
        }

        //to get the exchange rate for current date and currency
        public double GetExRate(string currency, DateTime Dtdate, string extype, int div)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@Dtdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@extype",SqlDbType.VarChar,1),
            new SqlParameter("@divisionid", SqlDbType.Int)};
            objp[0].Value = currency;
            objp[1].Value = Dtdate;
            objp[2].Value = extype;
            objp[3].Value = div;
            return double.Parse(ExecuteReader("SPExRateCurrDate", objp));
        }
        public double GetOSExRate(string currency, DateTime Dtdate, string extype, int div)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@Dtdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@extype",SqlDbType.VarChar,1),
             new SqlParameter("@div",SqlDbType.Int)};
            objp[0].Value = currency;
            objp[1].Value = Dtdate;
            objp[2].Value = extype;
            objp[3].Value = div;
            return double.Parse(ExecuteReader("SPExRateOSCurrDate", objp));
        }


        public void UpdateHead(int intinvpano, int custid, string remarks, string strbilltype, string strvtype, int userid, int vouyear, int branchid, char agent, string vendorrefno)
        {


            string billtype = CheckBillType(strbilltype);
            // int userid = EmpObj.GetEmpid(preparedby);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,150),
                                                                                     new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                                     new SqlParameter("@billtype",SqlDbType.Char,1),
                                                                                     new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@preparedby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@venrefno",SqlDbType.VarChar,30)};
            objp[0].Value = custid;
            objp[1].Value = remarks;
            objp[2].Value = intinvpano;
            objp[3].Value = billtype;
            objp[4].Value = strvtype;
            objp[5].Value = userid;
            objp[6].Value = vouyear;
            objp[7].Value = branchid;
            objp[8].Value = vendorrefno;
            ExecuteQuery("SPUpdIPHead", objp);
        }


        public DataTable ShowIPHead(int invpano, string strantype, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invpano;
            objp[1].Value = strantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            return ExecuteTable("SPSelIPHeadLV", objp);
        }
        public DataTable ShowIPHeadWoJ(int invpano, string strantype, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invpano;
            objp[1].Value = strantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            return ExecuteTable("SPSelIPHeadWoJ", objp);
        }
        public DataTable ShowTallyDt(int invpano, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            //return ExecuteTable("SPSelTallyDt", objp);
            return ExecuteTable("SPSelxmlvouchers", objp); ////haribalaji

        }


        public double GetIPDNAmountST(int invpano, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return double.Parse(ExecuteReader("SPGetAmtST", objp));
        }
        public double GetIPDNAmountWOST(int invpano, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return double.Parse(ExecuteReader("SPGetAmtWOST", objp));
        }
        public double GetIPDNAmount(int invpano, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return double.Parse(ExecuteReader("SPGetAmtIPDC", objp));
        }

        public int GetInvChargescount(int invpano, int intchargeid, string ftype, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@chargeid",SqlDbType.Int,4),
                                                                           new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                           new SqlParameter("@vouyear",SqlDbType.Int),
                                                                           new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invpano;
            objp[1].Value = intchargeid;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            return int.Parse(ExecuteReader("SPIPCountchrgs", objp));
        }
        //---------------------------------------------------------------------

        public int GetInvBaseCount(int invoiceno, string strbase, int intchargeid, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@base",SqlDbType.VarChar,45),
                                                                             new SqlParameter("@charge",SqlDbType.Int,4),
                                                                           new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                           new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = strbase;
            objp[2].Value = intchargeid;
            objp[3].Value = ftype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            return int.Parse(ExecuteReader("SPIPCountbase", objp));
        }
        //------------------------------------------------------------------------------------------------
        public void DelIPDetails(int invoiceno, int intcharge, string strbase, string ftype, int customerid, int vouyear, int branchid, string trantype)
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
            ExecuteQuery("SPDelInvCharge", objp);
        }

        public void DelIinvoiceDetailsFromInvNo(int invoiceno, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                                           new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            ExecuteQuery("SPDelInvoiceDetailsFromInvNo", objp);
        }
        public void UpdVouTally(int invoiceno, int branchid, int vouyear, string ftype, int FAby)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                      new SqlParameter("@branchid", SqlDbType.Int,4),
                                                      new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                      new SqlParameter("@faby",SqlDbType.Int)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = ftype;
            objp[4].Value = FAby;
            //ExecuteQuery("SPUpdVouTally", objp);
            ExecuteQuery("SPUpdVouTally_allhd", objp); ///haribalaji
        }

        //--------------------------------------------------------------------------------------
        public DataTable RptIP(int invoiceno, string strtrantype, string strvtype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                        new SqlParameter("@strtrantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.Int,4),
                                                        new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                        new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = invoiceno;
            objp[1].Value = strtrantype;
            objp[2].Value = branchid;
            objp[3].Value = strvtype;
            objp[4].Value = vouyear;
            return ExecuteTable("SPRptIP", objp);
        }

        public DataTable CheckHblno(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPCheckHblno", objp);
        }

        public DataTable CheckMblno(string mblno, string strTranType, int branchid)
        {

            //Conn = new SqlConnection(cs);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = mblno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPCheckMblno", objp);
        }


        // to get cityid using customername
        public int GetCityid(string customername)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Customername", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return int.Parse(ExecuteReader("SPInvGetCityId", objp));
        }

        public DataTable CheckIPDCWMBL(string mblno, string trantype, int branchid, int vouyear, int ftype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@ftype", SqlDbType.TinyInt,1)};
            objp[0].Value = mblno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = ftype;
            return ExecuteTable("SPCheckIPDCWMBL", objp);
        }
        public DataTable CheckIPDCWBL(string mblno, string trantype, int branchid, int vouyear, int ftype, string basetype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@ftype", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@basetype",SqlDbType.VarChar,4)};
            objp[0].Value = mblno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = ftype;
            objp[5].Value = basetype;
            return ExecuteTable("SPCheckIPDCWBL", objp);
        }
        public DataTable GetInvPACust(string custname, string ftype, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custname",SqlDbType.VarChar,30),
                                                      new SqlParameter("@ftype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = custname;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            return ExecuteTable("SPGetInvPACust", objp);
        }
        public int GetJVNo(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1) };
            objp[0].Value = branchid;
            return int.Parse(ExecuteReader("SPUpdMCJV", objp));
        }
        public int GetAlreadyJVNo(string voutype, int vouno, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int)};
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return int.Parse(ExecuteReader("SPGetJVNo", objp));
        }

        public void InsDCNJV(string voutype, int vouno, int jvno, int branchid, int vouyear, int intDivID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@jvno",SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)
                                                      };
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = jvno;
            objp[3].Value = branchid;
            objp[4].Value = vouyear;
            objp[5].Value = intDivID;
            ExecuteQuery("SPInsDCN2JV", objp);
        }

        public double GetCheckInvExrate(int jobno, string trantype, int branchid, string curr)
        {

            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@curr",SqlDbType.VarChar,3)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = curr;
            return double.Parse(ExecuteReader("SPCheckInvExrateLV", objp));
        }
        public DataTable GetPATDSDetails(int branchid, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1)};
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            return ExecuteTable("SPGetPATDS", objp);
        }
        public DataTable GetInvNoFromJobno(int jobno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetInvNoFromJobNo", objp);
        }

        public DataTable GetInvNoFromJobnonew(int jobno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetInvNoFromJobNoexrateLV", objp);
        }
        public DataTable GetCurrFromInvNo(int jobno, int invno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            return ExecuteTable("SPGetCurrFromInvNo", objp);
        }
        public string GetBLNoFromInvNo(int jobno, int invno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            return ExecuteReader("SPGetBLNoFromInvNo", objp).ToString();
        }
        /*  public void InsertPATDS(int vouno, string voutype, int branchid, int customerid, int vouyear, double cstamount, double tdsamount)
          {
              SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),        
                                                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1), 
                                                                                       new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                       new SqlParameter("@cstamount",SqlDbType.Real,8),
                                                                                       new SqlParameter("@tdsamount",SqlDbType.Real,8),
                                                                                       new SqlParameter("@voutype",SqlDbType.Char,1)};
              objp[0].Value = vouno;
              objp[1].Value = branchid;
              objp[2].Value = customerid;
              objp[3].Value = vouyear;
              objp[4].Value = cstamount;
              objp[5].Value = tdsamount;
              objp[6].Value = voutype;
              ExecuteQuery("SPInsPATDS", objp);
          }

          */

        public void InsertPATDS(int vouno, string voutype, int branchid, int customerid, int vouyear, double cstamount, double tdsamount, string tdssection, double acttdsper)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@cstamount",SqlDbType.Decimal),  // update real to decimal on 28112021 nambi dhiya
                                                                                     new SqlParameter("@tdsamount",SqlDbType.Decimal),
                                                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                                                     new SqlParameter("@tdssection",SqlDbType.VarChar,5),
                                                                                     new SqlParameter("@acttdsper",SqlDbType.Decimal)
            };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = customerid;
            objp[3].Value = vouyear;
            objp[4].Value = cstamount;
            objp[5].Value = tdsamount;
            objp[6].Value = voutype;
            objp[7].Value = tdssection.Trim();
            objp[8].Value = acttdsper;

            ExecuteQuery("SPInsPATDS", objp);
        }


        public void UpdateExRateFromJobNo(int invno, int branchid, int jobno, string curr, double newexrate, string trantype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@newexrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = invno;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = curr;
            objp[4].Value = newexrate;
            objp[5].Value = trantype;
            objp[6].Value = vouyear;
            ExecuteQuery("SPUpdExrateFromInvNo", objp);
        }
        public void InsAmendExRateDetable(int invoiceno, int branchid, int jobno, string curr, double exrateupd, string trantype, int vouyear, double exratemast, double exratepa, int empid, DateTime updateon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@exrateupd",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@exratemast",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@exratepa",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@empid",SqlDbType.Int,2),
                                                                                     new SqlParameter("@updateon",SqlDbType.DateTime,4)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = curr;
            objp[4].Value = exrateupd;
            objp[5].Value = trantype;
            objp[6].Value = vouyear;
            objp[7].Value = exratemast;
            objp[8].Value = exratepa;
            objp[9].Value = empid;
            objp[10].Value = updateon;
            ExecuteQuery("SPInsAmendExRateDetable", objp);
        }

        public DataTable GetCreditOSAmount(string blno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1) };
            objp[0].Value = blno;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetCreditOSAmount", objp);
        }


        public DataTable CheckPACustblno(string blno, int intCustID, string strTranType, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@custid",SqlDbType.Int,4),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = intCustID;
            objp[2].Value = strTranType;
            objp[3].Value = branchid;
            objp[4].Value = vouyear;
            return ExecuteTable("SPGetPAno", objp);
        }
        public double GetPATDSAmt(int vouno, string voutype, int customerid, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@voutype",SqlDbType.VarChar,1),
                                                    new SqlParameter("@customerid",SqlDbType.Int,4),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = customerid;
            objp[3].Value = branchid;
            objp[4].Value = vouyear;
            return double.Parse(ExecuteReader("SPGetTDSAmt", objp));
        }
        public int CheckTDSApplyORNot(string voutype, int vouno, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1)};
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return int.Parse(ExecuteReader("SPCheckTDSApplyORNot", objp));
        }
        public int CheckClosedJobs(string trantype, int jobno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1)};
            objp[0].Value = trantype;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            return int.Parse(ExecuteReader("SPCheckClosedJobs", objp));
        }

        public DataTable GetOtherDCNAmount(int vouno, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetCurrExAmountFromDCNVou", objp);
        }

        public DataTable GetAgentRebateChargeDetails(int agent, int pol, int pod, char ctype, char cargo)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@agent",SqlDbType.Int,4),
                                                                            new SqlParameter("@pol",SqlDbType.Int,4),
                                                                            new SqlParameter("@pod", SqlDbType.Int,4),
              new SqlParameter("@ctype", SqlDbType.Char,1),
            new SqlParameter("@cargo", SqlDbType.Char,1)};
            objp[0].Value = agent;
            objp[1].Value = pol;
            objp[2].Value = pod;
            objp[3].Value = ctype;
            objp[4].Value = cargo;
            return ExecuteTable("SPGetAgentRebateCharge", objp);
        }
        public DataTable GetPartyLedger4PAAdmin(int vouno, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                            new SqlParameter("@type",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPartyLedger4PAAdmin", objp);
        }

        public DataTable SelMBLInvPADtls(int JobNo, int BranchID, string TranType, char Voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@voutype",SqlDbType.Char,1) };
            objp[0].Value = JobNo;
            objp[1].Value = BranchID;
            objp[2].Value = TranType;
            objp[3].Value = Voutype;
            return ExecuteTable("SPSelMBLInvPADtls", objp);
        }

        public DataTable GetFrankingDts(int JobNo, int BranchID, string TranType, string blno, int chargeid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar,1) };
            objp[0].Value = JobNo;
            objp[1].Value = BranchID;
            objp[2].Value = TranType;
            objp[3].Value = blno;
            objp[4].Value = chargeid;
            objp[5].Value = type;
            return ExecuteTable("SPGetFrankingDts", objp);
        }
        public void updateUntransferTallyEdi(string voutype, int vouno, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype",SqlDbType.VarChar,100),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            ExecuteQuery("SPUnChecktallyEdi", objp);

        }
        public string GetObJ()
        {
            StringBuilder sr = new StringBuilder(" ", 0, 29, 30);

            //sr.Remove(0, sr.Length);
            sr.Append(" ", 0, 29);
            sr.Insert(0, "Age");
            return sr.ToString();
        }
        public void InsAllVoucherSummaryJobGreaterThanVou(DateTime dtVou, DateTime dtJob, int empid, int VouYear)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                       new SqlParameter("@voudate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@jobdate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@empid",SqlDbType.Int ,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int ,4)
                                                     };
            objp[0].Value = dtVou;
            objp[1].Value = dtJob;
            objp[2].Value = empid;
            objp[3].Value = VouYear;
            ExecuteQuery("SPSelAllVoucherSummaryVoucherLessThanJob", objp);
        }
        public void InsAllVoucherSummaryVouGreaterThanJob(DateTime dtVou, DateTime dtJob, int empid, int VouYear)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                     {
                                                       new SqlParameter("@voudate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@jobdate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@empid",SqlDbType.Int ,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int ,4)
                                                     };
            objp[0].Value = dtVou;
            objp[1].Value = dtJob;
            objp[2].Value = empid;
            objp[3].Value = VouYear;
            ExecuteQuery("SPSelAllVoucherSummaryVouGreaterThanJob", objp);
        }

        public DataSet GetAllVoucherSummary(int empid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@empid", SqlDbType.Int, 4)
                                                     };
            objp[0].Value = empid;
            return ExecuteDataSet("SPGetAllVoucherSummary", objp);
        }



        public DataTable GetReversalVoucher(int vouno, int vouyear, int branchid, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@vouno",SqlDbType.Int,4),
                new SqlParameter ("@vouyear",SqlDbType.Int),
                new SqlParameter ("@branchid",SqlDbType.TinyInt ,1),
                new SqlParameter ("@voutype",SqlDbType.Char ,1)
            };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            return ExecuteTable("SPGetReversalVoucher", objp);
        }
        public DataTable getLikeCusblon(string invoiceno, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@invoiceno",SqlDbType.VarChar,10),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2)

                                                    };
            objp[0].Value = invoiceno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            objp[3].Value = trantype;
            return ExecuteTable("SPLikeCusInvno", objp);
        }
        public DataTable GetCheckApprovedProfoma(int refno, int branchid, int vouyear, string trantype, string type, string function)
        {
            SqlParameter[] objp = new SqlParameter[] {
            new SqlParameter("@refno",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.VarChar,30),
                new SqlParameter("@func",SqlDbType.VarChar,30)
            };

            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = type;
            objp[5].Value = function;
            return ExecuteTable("SPcheckapprovedProfoma", objp);
        }
        public DataTable Getrefid(int refno, int vouyear, int branchid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {
            new SqlParameter("@refno",SqlDbType.Int,4),
            new SqlParameter("@vouyear",SqlDbType.Int,4),
            new SqlParameter("@branchid",SqlDbType.Int,4),
            new SqlParameter("@type",SqlDbType.VarChar,30)};

            objp[0].Value = refno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteTable("SPGetrefforvalidate", objp);
        }


        public string GetVouAgainstRcptPay(int vouno, int branchid, int vouyear, string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteReader("SPGetVouAgainstRcptPay", objp).ToString();
        }

        //For Tally RR and RP

        public DataTable ShowTallyDt4OS(int invpano, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPSelTallyDtForOS", objp);
        }

        //raja 4 FA

        public DataTable FAShowTallyDt(int invpano, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@accdbname",SqlDbType.VarChar,10)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = "FAPL";
            return ExecuteTable("SPSelTallyDtFA", objp);
            //return ExecuteTable("SPSelTallyDtFAlv", objp);
        }


        //RAJA
        public DataTable GetPartyLedger4proPAAdmin(int vouno, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                            new SqlParameter("@type",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPartyLedger4proPAAdmin", objp);
        }

        public DataTable GetPartyLedger4PAAdminwithCust(int vouno, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                            new SqlParameter("@type",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPartyLedger4PAAdminwithcust", objp);
        }

        public DataTable GetPartyLedger4PAPROAdminwithCust(int vouno, string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                            new SqlParameter("@type",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPartyLedger4PAPROAdminwithcust", objp);
        }

        public DataTable SelEmpDtls4Acc(int employeeid, int jobno, int branchid, string trantype, string blno)
        {

            SqlParameter[] objp = new SqlParameter[]
                        {
                          new SqlParameter("@employeeid",SqlDbType.Int),
                          new SqlParameter("@jobno",SqlDbType.Int,4),
                          new SqlParameter("@bid",SqlDbType.TinyInt,1),
                          new SqlParameter("@trantype",SqlDbType.VarChar,2),
                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                        };
            objp[0].Value = employeeid;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = blno;
            return ExecuteTable("SPSelEmpDtls4Acc", objp);
        }
        //Dinesh

        public DataTable SelEmpDtls4Accnew(int employeeid, int jobno, int branchid, string trantype, string blno)
        {

            SqlParameter[] objp = new SqlParameter[]
                        {
                          new SqlParameter("@employeeid",SqlDbType.Int),
                          new SqlParameter("@jobno",SqlDbType.Int,4),
                          new SqlParameter("@bid",SqlDbType.TinyInt,1),
                          new SqlParameter("@trantype",SqlDbType.VarChar,2),
                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                        };
            objp[0].Value = employeeid;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = blno;
            return ExecuteTable("SPSelEmpDtls4Accnew", objp);
        }
        public int CheckClosedJobsnew(string trantype, int jobno, int branchid, int did)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1),new SqlParameter("@cid", SqlDbType.TinyInt, 1)};
            objp[0].Value = trantype;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = did;
            return int.Parse(ExecuteReader("SPCheckClosedJobsnew", objp));
        }

        public DataTable GetInvoiceReg(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SpGetInvoiceNew", objp);
        }

        public DataTable GetInterBilling(int empid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@empid", SqlDbType.Int,4),
                               new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = empid;
            objp[1].Value = divisionid;

            return ExecuteTable("SpGetInterBranchBill", objp);
        }

        public DataTable GetInterCompanyBilling(int empid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@empid", SqlDbType.Int,4),
                               new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = empid;
            objp[1].Value = divisionid;

            return ExecuteTable("SpGetInnerCompanyBill", objp);
        }

        public DataTable GetAdminRegister(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SpAdmDebitRegister", objp);
        }
        public DataTable GetCreditNotAdmin(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SpGetCreditNoteAdmin", objp);
        }
        public DataTable GetCreditNotOper(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SpGetCreditNoteoperation", objp);
        }
        public DataTable GetSTChargewise(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{

                 new SqlParameter("@empid",SqlDbType.Int)
            };


            objp[0].Value = empid;

            return ExecuteTable("SpGetSTChargewise", objp);
        }


        public DataTable GetDebiteNoteNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SPGetDebitenote", objp);
        }

        public DataTable GetCrediteNoteNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SpGetCrediteNotOper", objp);
        }


        public DataTable GetSpGetOtherDebiNote(DateTime fromdate, DateTime todate, int brnachid, char custtype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@ctype",SqlDbType.Char)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custtype;

            return ExecuteTable("SpGetOterDebitNote", objp);
        }

        public DataTable GetSpGetOtherCrediteNote(DateTime fromdate, DateTime todate, int brnachid, char custtype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@ctype",SqlDbType.Char)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custtype;

            return ExecuteTable("SpGetOterCredebitNote", objp);
        }

        public DataTable GetServiceTaxInv(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetServiceTaxInv", objp);
        }


        public DataTable GetServiceTaxInvCNOps(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetServiceTaxCnOps", objp);
        }
        public DataTable GetServiceTaxOtherDn(DateTime fromdate, DateTime todate, int brnachid, char custype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@custype ",SqlDbType.Char)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custype;

            return ExecuteTable("SpGetServiceTaxOtherDn", objp);
        }


        public DataTable GetServiceTaxOtherCnNew(DateTime fromdate, DateTime todate, int brnachid, char custype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@custype ",SqlDbType.Char)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custype;

            return ExecuteTable("SpGetServiceTaxOtherCn", objp);
        }

        public DataTable GetReceiptBank(DateTime fromdate, DateTime todate, int brnachid, char mode)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@mode",SqlDbType.Char)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = mode;

            return ExecuteTable("SpGetReceiptBankReg", objp);
        }


        public DataTable GetReceiptCashNew(DateTime fromdate, DateTime todate, int brnachid, char mode)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@mode",SqlDbType.Char)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = mode;

            return ExecuteTable("SPGetReceiptCash", objp);
        }


        public DataTable GetTdsNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SPGetTdsNew", objp);
        }
        public DataTable GetTdsTypeNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SPGetTdsTypeNew", objp);
        }

        public DataTable GetPaymentForBank(DateTime fromdate, DateTime todate, int brnachid, char mode, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                   new SqlParameter("@mode",SqlDbType.Char),
                    new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = mode;
            objp[4].Value = divisionid;



            return ExecuteTable("SPGetPaymetForBankNew", objp);
        }

        public DataTable GetPaymentcashNew(DateTime fromdate, DateTime todate, int brnachid, char mode)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@mode",SqlDbType.Char)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = mode;

            return ExecuteTable("SpGetPaymentCashQuery", objp);
        }

        public DataTable GetSTLedgerwiseCNOps(int userid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@empid",SqlDbType.Int )


            };

            objp[0].Value = userid;


            return ExecuteTable("SpSTLedgerviceInvOp", objp);
        }

        public DataTable ProformaInvNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetProformaInvNew", objp);
        }
        public DataTable ProformaCNOperations(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetProformaCnOperations", objp);
        }
        public DataTable GetPerformaOSDN(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetPerformaOSDN", objp);
        }
        public DataTable GetPerformaOSCN(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetPerformaOSCN", objp);
        }

        public DataTable GetPerformaOtherDnNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetPerformaOtherDn", objp);
        }
        public DataTable GetProOtherCnRegister(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetProOtherCnRegister", objp);
        }
        public DataTable GEtProProformaCNAdminNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetProPAAdminRegister", objp);
        }

        public DataTable GEtProProformaDNAdminNew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;


            return ExecuteTable("SpGetProProformaDNAdminNew", objp);
        }



        //Raj


        public DataTable CheckTransfer(string voutype, int vouno, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype",SqlDbType.VarChar,100),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPCHKTRANSFER", objp);

        }

        public DataTable GetSTAmt4STType(string voutype, int vouno, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@invno", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = voutype;
            objp[1].Value = vouno;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetSTAmt4STType", objp);

        }

        //Dinesh
        public DataTable GetCurrFromInvNonew(int jobno, int invno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            return ExecuteTable("SPGetCurrFromInvNopro", objp);
        }

        //Dinesh
        public string GetBLNoFromInvNonew(int jobno, int invno, string trantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            return ExecuteReader("SPGetBLNoFromInvNopro", objp).ToString();
        }

        //Raj


        public DataTable get_containerdetails(int job, int bid, string blno, string trantype, string bltype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.Int, 4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@Bl",SqlDbType.VarChar, 1)};
            objp[0].Value = job;
            objp[1].Value = bid;
            objp[2].Value = blno;
            objp[3].Value = trantype;
            objp[4].Value = bltype;
            return ExecuteTable("sp_getcontainer", objp);
        }


        //Raj

        /* public double Getinvoiceservicetax(int invoiceno, int branchid, int vouyear, string chargename)
         {
             SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                        new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                        new SqlParameter("@chargename",SqlDbType.VarChar, 21)};
             objp[0].Value = invoiceno;
             objp[1].Value = branchid;
             objp[2].Value = vouyear;
             objp[3].Value = chargename;
             return double.Parse(ExecuteReader("sp_getservicetaxcalc", objp));
         }*/

        public DataTable get_tdspayable(int vouno, int branchid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int,4),
               new SqlParameter("@voutype", SqlDbType.VarChar,1),};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("sp_gettdspayable", objp);
        }


        /*  public DataTable Getinvoicedetailsgrid(int invoiceno, int branchid, int vouyear, string trantype)
          {
              SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                         new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                         new SqlParameter("@trantype",SqlDbType.VarChar, 2)};
              objp[0].Value = invoiceno;
              objp[1].Value = branchid;
              objp[2].Value = vouyear;
              objp[3].Value = trantype;
              return ExecuteTable("sp_getinvoicedetailsgrid", objp);
          }
          */

        public DataTable get_servicetax(int invoiceno, int branchid, int vouyear, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno", SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int,4),
               new SqlParameter("@trantype", SqlDbType.VarChar,3),};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            return ExecuteTable("sp_getservicetax", objp);
        }


        /*  public DataTable Getinvoicedetailsforreport(int branchid, string trantype, int invoiceno, int vouyear, string bltype, string header)
          {
              SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int, 4),
                                                         new SqlParameter("@trantype", SqlDbType.VarChar,3),
                                                         new SqlParameter("@invoiceno", SqlDbType.Int, 4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                         new SqlParameter("@bltype", SqlDbType.VarChar,1),
                                                         new SqlParameter("@header", SqlDbType.VarChar,10)};
              objp[0].Value = branchid;
              objp[1].Value = trantype;
              objp[2].Value = invoiceno;
              objp[3].Value = vouyear;
              objp[4].Value = bltype;
              objp[5].Value = header;
              return ExecuteTable("sp_getinvoicedetails", objp);
          }*/



        //GST

        //Dinesh



        public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int userid, string ftype, int vouyear, string type, string vendor, int creditdays, int supplyto)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@invoicedate",SqlDbType.DateTime,8),
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
                                                     new SqlParameter("@vendor",SqlDbType.VarChar,30),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                     new SqlParameter("@creditdays",SqlDbType.Int,4),
            new SqlParameter("@supplyto",SqlDbType.Int,4)};
            objp[0].Value = Dtdate;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = intcustomerid;
            objp[4].Value = blno;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = billtype;
            objp[8].Value = userid;
            objp[9].Value = vouyear;
            objp[10].Value = type;
            objp[11].Value = vendor;
            objp[12].Direction = ParameterDirection.Output;
            objp[13].Value = creditdays;
            objp[14].Value = supplyto;
            return ExecuteQuery("SpInsProDCnHead", objp, "@refno");

        }


        public int InsertProInvoiceHeadnew(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int userid, string ftype, int vouyear, string type, string vendor, int creditdays, int supplyto, DateTime vendorrefdate)
        {
            string billtype = CheckBillType(strbilltype);
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@invoicedate",SqlDbType.DateTime,8),
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
                                                     new SqlParameter("@vendor",SqlDbType.VarChar,30),
                                                     new SqlParameter("@refno",SqlDbType.Int,4),
                                                     new SqlParameter("@creditdays",SqlDbType.Int,4),
            new SqlParameter("@supplyto",SqlDbType.Int,4),
             new SqlParameter("@vendorrefdate",SqlDbType.DateTime,8)};
            objp[0].Value = Dtdate;
            objp[1].Value = strTranType;
            objp[2].Value = jobno;
            objp[3].Value = intcustomerid;
            objp[4].Value = blno;
            objp[5].Value = remarks;
            objp[6].Value = branchid;
            objp[7].Value = billtype;
            objp[8].Value = userid;
            objp[9].Value = vouyear;
            objp[10].Value = type;
            objp[11].Value = vendor;
            objp[12].Direction = ParameterDirection.Output;
            objp[13].Value = creditdays;
            objp[14].Value = supplyto;
            objp[15].Value = vendorrefdate;
            return ExecuteQuery("SpInsProDCnHead", objp, "@refno");

        }


        //Raj

        public double Getinvoiceservicetax(int invoiceno, int branchid, int vouyear, string chargename, string header, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@chargename",SqlDbType.VarChar, 21),
                                                       new SqlParameter("@header",SqlDbType.VarChar, 20),
                                                       new SqlParameter("@profoma",SqlDbType.VarChar, 10)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = chargename;
            objp[4].Value = header;
            objp[5].Value = profoma;
            return double.Parse(ExecuteReader("sp_getservicetaxcalc", objp));
        }


        /*  public DataTable Getinvoicedetailsforreport(int branchid, string trantype, int invoiceno, int vouyear, string bltype, string header, string agent)
          {
              SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int, 4),
                                                         new SqlParameter("@trantype", SqlDbType.VarChar,3),
                                                         new SqlParameter("@invoiceno", SqlDbType.Int, 4),
                                                         new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                         new SqlParameter("@bltype", SqlDbType.VarChar,1),
                                                         new SqlParameter("@header", SqlDbType.VarChar,10),
                                                         new SqlParameter("@agent", SqlDbType.VarChar,1)};
              objp[0].Value = branchid;
              objp[1].Value = trantype;
              objp[2].Value = invoiceno;
              objp[3].Value = vouyear;
              objp[4].Value = bltype;
              objp[5].Value = header;
              objp[6].Value = agent;
              return ExecuteTable("sp_getinvoicedetails", objp);
          }*/




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

        public DataTable Getinvoicedetailsgrid(int invoiceno, int branchid, int vouyear, string trantype, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@profoma",SqlDbType.VarChar, 10)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = profoma;
            return ExecuteTable("sp_getinvoicedetailsgrid", objp);
        }
        public DataTable Getinvoicedetailsforreport(int branchid, string trantype, int invoiceno, int vouyear, string bltype, string header, string agent, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,3),
                                                       new SqlParameter("@invoiceno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@bltype", SqlDbType.VarChar,1),
                                                       new SqlParameter("@header", SqlDbType.VarChar,10),
                                                       new SqlParameter("@agent", SqlDbType.VarChar,1)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = invoiceno;
            objp[3].Value = vouyear;
            objp[4].Value = bltype;
            objp[5].Value = header;
            objp[6].Value = agent;
            if (profoma == "Profoma")
            {
                return ExecuteTable("sp_getproinvoicedetails", objp);
            }
            else
            {
                return ExecuteTable("sp_getinvoicedetails", objp);
                // return ExecuteTable("sp_getinvoicedetailsnew", objp);
            }

        }


        public DataTable sp_getinvoiceno(int branchid, string trantype, int invoiceno, int vouyear, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,3),
                                                       new SqlParameter("@invoiceno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4) ,
              new SqlParameter("@type",SqlDbType.VarChar,30) };
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = invoiceno;
            objp[3].Value = vouyear;
            objp[4].Value = type;

            return ExecuteTable("sp_getinvoiceno", objp);


        }

        public DataTable GetPartyLedger4INVCN(int vouno, string ftype, int branchid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
            new SqlParameter("@type",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPartyLedger4INVCN", objp);
        }

        //nambi //DINESH
        public string Chkjobvalid(int jobno, int branchid, string strtype)
        {

            SqlParameter[] objp = new SqlParameter[]
              {
                  new SqlParameter("@jobno",SqlDbType.Int),
                  new SqlParameter("@bid",SqlDbType.Int),
                  new SqlParameter("@trantype",SqlDbType.VarChar,2)

                };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = strtype;

            return ExecuteReader("sp_chkjobvalid", objp);
            //return ExecuteReader("sp_chkjobvalid",objp);
        }

        public void InsDelVouDetails(int vouno, string voutype, int vouyear, int branchid, int jobno, string trantype, string blno, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar,100),
            };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = jobno;
            objp[5].Value = trantype;
            objp[6].Value = blno;
            objp[7].Value = dbname;
            ExecuteQuery("SPInsDelVouDetails", objp);

        }



        //FA

        public void updateinvoiceno(int invoiceno, int refno)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@invno",SqlDbType.Int) ,
                                                      new SqlParameter("@refno",SqlDbType.Int)

            };
            objp[0].Value = invoiceno;
            objp[1].Value = refno;

            ExecuteQuery("Spupdateinvoiceno", objp);

        }

        public string GetVouAgainstRcptPayOS(int vouno, int branchid, int vouyear, string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteReader("SPGetVouAgainstRcptPayOS", objp).ToString();
        }

        //---------------Karthika_K

        public DataTable fn_ServiceTaxPA(DateTime Fromdate, DateTime ToDate, int Branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                new SqlParameter("@fromdate", SqlDbType.DateTime),
                                new SqlParameter("@todate", SqlDbType.DateTime),
                                new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = Fromdate;
            objp[1].Value = ToDate;
            objp[2].Value = Branchid;

            return ExecuteTable("ServiceTaxPA", objp);
        }

        public DataTable fn_STChargewise_PACN(int EmpId)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@EmpId",SqlDbType.Int)
            };

            objp[0].Value = EmpId;

            return ExecuteTable("Sp_STChargewise_PACN", objp);
        }
        public DataTable fn_Ledgerwise_AdminPA(int EmpId)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@EmpId",SqlDbType.Int)
            };

            objp[0].Value = EmpId;

            return ExecuteTable("Sp_Ledgerwise_AdminPA", objp);
        }

        public DataTable fn_Ledgerwise_AdminDN(int EmpId)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@EmpId",SqlDbType.Int)
            };

            objp[0].Value = EmpId;

            return ExecuteTable("Sp_Ledgerwise_AdminDN", objp);
        }

        public DataTable fn_OnAccount_Receipt(DateTime Fromdate, DateTime ToDate, int Branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                new SqlParameter("@FromDate", SqlDbType.DateTime),
                                new SqlParameter("@ToDate", SqlDbType.DateTime),
                                new SqlParameter("@BranchId",SqlDbType.Int)
            };

            objp[0].Value = Fromdate;
            objp[1].Value = ToDate;
            objp[2].Value = Branchid;

            return ExecuteTable("Sp_OnAccount_Receipt", objp);
        }

        public DataTable fn_OnAccount_Payment(DateTime Fromdate, DateTime ToDate, int Branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                new SqlParameter("@FromDate", SqlDbType.DateTime),
                                new SqlParameter("@ToDate", SqlDbType.DateTime),
                                new SqlParameter("@BranchId",SqlDbType.Int)
            };

            objp[0].Value = Fromdate;
            objp[1].Value = ToDate;
            objp[2].Value = Branchid;

            return ExecuteTable("Sp_OnAccount_Payment", objp);
        }

        public DataTable fn_TDSReceivable(int EmpId)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@EmpId",SqlDbType.Int)
            };

            objp[0].Value = EmpId;

            return ExecuteTable("Sp_TDSReceivable", objp);
        }

        public DataTable fn_TDSPayable(int EmpId)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@EmpId",SqlDbType.Int)
            };

            objp[0].Value = EmpId;

            return ExecuteTable("Sp_TDSPayable", objp);
        }
        //Ruban

        public string GetVoucherAgainstRcptPay(int vouno, int branchid, int vouyear, string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteReader("SPGetVouAgainstRcptPayraj", objp);
        }
        public DataTable finanlegderwise(int branchid, int groupid, int subgroupid, DateTime fromdate, DateTime todate, int divisionid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@branchid",SqlDbType.Int),
                               new SqlParameter("@groupid",SqlDbType.Int),
                               new SqlParameter("@subgroupid",SqlDbType.Int),
                               new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                               new SqlParameter("@todate",SqlDbType.SmallDateTime),
                               new SqlParameter("@cid",SqlDbType.Int),
                               new SqlParameter("@dbname",SqlDbType.VarChar,50)

            };

            objp[0].Value = branchid;
            objp[1].Value = groupid;
            objp[2].Value = subgroupid;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            objp[5].Value = divisionid;
            objp[6].Value = dbname;


            return ExecuteTable("SPGetIndirectExpensesGroupnewledgerwise", objp);
        }

        //muthu

        public int getjobnobldetails(string blno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar,50),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2)};
            objp[0].Value = blno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            return int.Parse(ExecuteReader("sp_getjobbldetails", objp));
        }
        public void sp_updjobbldet(int jobno, string blno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@blno", SqlDbType.VarChar,50),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            ExecuteQuery("sp_updjobbldet", objp);

        }


        public DataTable sp_ddlsection()
        {

            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("sp_ddlsection", objp);
        }



        public DataTable sp_ddlsectionnew1()
        {

            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("sp_ddlsectionnew1", objp);
        }

        public DataTable sp_ddltds(string section)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@section", SqlDbType.VarChar, 50) };

            objp[0].Value = section;

            return ExecuteTable("sp_ddltds", objp);

        }

        //RAJ

        public DataTable Get_TDSPercentage(string tdssection)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@tdssection",SqlDbType.VarChar)
            };

            objp[0].Value = tdssection;

            return ExecuteTable("SP_gettdsperfromtdssection", objp);
        }


        public DataTable Get_TDSPercentagenew(string tdssection, int tdsid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                               new SqlParameter("@tdssection",SqlDbType.VarChar),
                                 new SqlParameter("@tdsid",SqlDbType.Int)
            };

            objp[0].Value = tdssection;
            objp[1].Value = tdsid;
            return ExecuteTable("SP_gettdsperfromtdssectionnew", objp);
        }



        //Dinesh

        public DataTable CheckIPDCWBLShipperinvoice(string mblno, string trantype, int branchid, int vouyear, int ftype, string basetype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@mblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@ftype", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@basetype",SqlDbType.VarChar,4)};
            objp[0].Value = mblno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = ftype;
            objp[5].Value = basetype;
            return ExecuteTable("SPCheckIPDCWBLSHIPPINV", objp);
        }

        public void inspaheadgsttype(string gsttype, int pano, int branchid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@gsttype",SqlDbType.VarChar,10),
                                                    new SqlParameter("@pano",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                      new SqlParameter("@voutype", SqlDbType.VarChar,2)
                                                    };
            objp[0].Value = gsttype;
            objp[1].Value = pano;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = voutype;
            ExecuteQuery("sppaheadgsttype", objp);
        }

        public DataTable GetinvoicedetailsgridBOS(int invoiceno, int branchid, int vouyear, string trantype, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@profoma",SqlDbType.VarChar, 10)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = profoma;
            return ExecuteTable("sp_getinvoicedetailsgridBOS", objp);
        }
        public DataTable GetChargeFromQuotationOnlyMinusFigure(string blno, DateTime Dtdate, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                                            new SqlParameter("@Dtdate",SqlDbType.SmallDateTime,4),
                                                                            new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = Dtdate;
            objp[2].Value = bid;
            return ExecuteTable("SPInvChargeFroQuotOnlyMinusFigure", objp);
        }
        public DataTable GetChargeFrombuyinginvoicenew(string blno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            return ExecuteTable("SPInvChargeFrombuyinginvoicenew", objp);
        }

        public DataTable GetChargeFrombuyinginvoicenew1(string blno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            return ExecuteTable("SPInvChargeFrombuyinginvoicenew1", objp);
        }

        public float Getchargepallet(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPAIEInvpallet", objp));
        }



        public float Getchargepalletmbl(int jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPAIEsumInvpallet", objp));
        }




        public float Getchargetruck(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPAIEInvpkgs", objp));
        }


        public float Getchargetrucknew(int jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPAIESumSPAIEInvpkgs", objp));
        }

        public string GetCreditDaysfromVoucher(int branchid, int vouno, char voutype, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[]
              {
                  new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@vouno",SqlDbType.Int),
                  new SqlParameter("@voutype",SqlDbType.VarChar,4),
                    new SqlParameter("@vouyear",SqlDbType.Int)
                };
            objp[0].Value = branchid;
            objp[1].Value = vouno;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;

            return ExecuteReader("SPGetCreditDaysfromVoucher", objp);

        }


        public DataTable GET_exratecheck(int refno, int bid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
             new SqlParameter("@voutype", SqlDbType.VarChar, 50)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("sp_exratecheck", objp);
        }


        //Dinesh

        public DataTable Get_checkwithSGSTPIGST(int refno, int bid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
             new SqlParameter("@voutype", SqlDbType.VarChar, 50)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("sp_checkwithSGSTPIGST", objp);
        }


        //Dinesh

        public DataTable Get_checkwithSGSTPIGST1(int refno, int bid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
             new SqlParameter("@voutype", SqlDbType.VarChar, 50)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("sp_checkwithSGSTPIGST1", objp);
        }




        public DataTable GetInvoiceRegBOS(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SpGetInvoiceNewBOS", objp);
        }
        public DataTable SPCheckApprovaldate(int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@divisionid",SqlDbType.Int,4)


            };
            objp[0].Value = divisionid;

            return ExecuteTable("SPCheckApprovaldate", objp);
        }
        public void UpdateExRateFromJobNoOSCNDN(int invno, int branchid, int jobno, string curr, double newexrate, string trantype, int vouyear, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invno",SqlDbType.Int,4),
new SqlParameter("@branchid",SqlDbType.TinyInt,1),
new SqlParameter("@jobno",SqlDbType.Int,4),
new SqlParameter("@curr",SqlDbType.VarChar,3),
new SqlParameter("@newexrate",SqlDbType.Money,8),
new SqlParameter("@trantype",SqlDbType.VarChar,2),
new SqlParameter("@vouyear",SqlDbType.Int),
            new SqlParameter("@type",SqlDbType.VarChar,6)};
            objp[0].Value = invno;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = curr;
            objp[4].Value = newexrate;
            objp[5].Value = trantype;
            objp[6].Value = vouyear; objp[7].Value = type;
            ExecuteQuery("SPUpdExrateFromInvNoOSCNDNLV", objp);
        }
        public DataTable GetCurrFromInvNonewOSCNDN(int jobno, int invno, string trantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4),
            new SqlParameter("@type",SqlDbType.VarChar,6)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            objp[4].Value = type;
            return ExecuteTable("SPGetCurrFromInvNoproOSCNDNOSV", objp);
        }

        public string GetBLNoFromInvNoOSCNDN(int jobno, int invno, string trantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4),
            new SqlParameter("@type",SqlDbType.VarChar,6)};
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            objp[4].Value = type;
            return ExecuteReader("SPGetBLNoFromInvNoproOSCNOSV", objp).ToString();
        }

        //Lawrence
        public DataTable GetInvoiceDetailsnew(int invoiceno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invno", SqlDbType.Int,4),
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetInvoiceDtlsrev", objp);
        }

        public DataTable GetPADetailsnew(int pano, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pano", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1) };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetPADtlsrev", objp);
        }

        public DataTable GetOSDNCNDetailsnew(int vouno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int,4),
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetOSDNCNdtlsrev", objp);
        }

        public DataTable getuserrightsforjobclose()
        {

            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("spuserrightsforjobclose", objp);
        }

        //RajBharath
        public DataSet GetTurnOverForVouchers(int branchid, DateTime fromdate, DateTime todate, string incexp)
        {
            SqlParameter[] objp = new SqlParameter[] {
            new SqlParameter("@branchid",SqlDbType.Int,4),
            new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
        new SqlParameter("@incexp",SqlDbType.VarChar,1)};

            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = incexp;
            return ExecuteDataSet("SPGetTurnOverOfVouchers", objp);
        }

        public DataTable GetInvoiceRegall(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;
            return ExecuteTable("SpGetInvoiceNew", objp);
        }
        public DataTable GetCreditNotAdminnew(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetCreditNoteAdmin", objp);
        }
        public DataTable GetAdminRegisterall(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpAdmDebitRegister", objp);
        }
        public DataTable GetSpGetOtherDebiNoteall(DateTime fromdate, DateTime todate, int brnachid, char custtype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@ctype",SqlDbType.Char),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custtype;
            objp[4].Value = divisionid;

            return ExecuteTable("SpGetOterDebitNote", objp);
        }
        public DataTable GetAdminRegisternew(DateTime fromdate, DateTime todate, int brnachid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            return ExecuteTable("SpAdmDebitRegisternew", objp);
        }

        public DataTable GetSpGetOtherCrediteNoteall(DateTime fromdate, DateTime todate, int brnachid, char custtype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@ctype",SqlDbType.Char),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custtype;
            objp[4].Value = divisionid;

            return ExecuteTable("SpGetOterCredebitNote", objp);
        }

        public DataTable GetServiceTaxInv(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
                 ,
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[2].Value = divisionid;


            return ExecuteTable("SpGetServiceTaxInv", objp);
        }
        public DataTable GetServiceTaxInvCNOps(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
              ,
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetServiceTaxCnOps", objp);
        }
        public DataTable GetServiceTaxOtherDn(DateTime fromdate, DateTime todate, int brnachid, char custype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@custype ",SqlDbType.Char),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custype;
            objp[4].Value = divisionid;
            return ExecuteTable("SpGetServiceTaxOtherDn", objp);
        }

        public DataTable GetServiceTaxOtherCnNew(DateTime fromdate, DateTime todate, int brnachid, char custype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@custype ",SqlDbType.Char),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = custype;
            objp[4].Value = divisionid;

            return ExecuteTable("SpGetServiceTaxOtherCn", objp);
        }

        public DataTable GetReceiptBank(DateTime fromdate, DateTime todate, int brnachid, char mode, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@mode",SqlDbType.Char),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = mode;
            objp[4].Value = divisionid;

            return ExecuteTable("SpGetReceiptBankReg", objp);
        }

        public DataTable GetReceiptCashNew(DateTime fromdate, DateTime todate, int brnachid, char mode, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@mode",SqlDbType.Char),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = mode;
            objp[4].Value = divisionid;
            return ExecuteTable("SPGetReceiptCash", objp);
        }

        public DataTable ProformaInvNew(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;


            return ExecuteTable("SpGetProformaInvNew", objp);
        }
        public DataTable ProformaCNOperations(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetProformaCnOperations", objp);
        }
        public DataTable GetPerformaOSDN(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetPerformaOSDN", objp);
        }
        public DataTable GetPerformaOSCN(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetPerformaOSCN", objp);
        }

        public DataTable GetPerformaOtherDnNew(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetPerformaOtherDn", objp);
        }

        public DataTable GetProOtherCnRegister(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetProOtherCnRegister", objp);
        }
        public DataTable GEtProProformaCNAdminNew(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetProPAAdminRegister", objp);
        }

        public DataTable GEtProProformaDNAdminNew(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetProProformaDNAdminNew", objp);
        }
        public DataTable fn_ServiceTaxPA(DateTime Fromdate, DateTime ToDate, int Branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                new SqlParameter("@fromdate", SqlDbType.DateTime),
                                new SqlParameter("@todate", SqlDbType.DateTime),
                                new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = Fromdate;
            objp[1].Value = ToDate;
            objp[2].Value = Branchid;
            objp[3].Value = divisionid;
            return ExecuteTable("ServiceTaxPA", objp);
        }

        public DataTable get_containerdetailsForslot(int jobno, int bid, int procnno, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@procnno",SqlDbType.Int),
                                                       new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = procnno;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetcontainerdetailsslot", objp);
        }

        public DataTable getrepairdetails(int refno, int bid, int vouyear, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@type",SqlDbType.VarChar,10)
            };
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = type;
            return ExecuteTable("spgetrepairdetail", objp);
        }
        public DataTable spcountinvoice4particularcustomer(int customerid, int branchid, int vouyear, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid",SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@empid",SqlDbType.Int)
            };
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = empid;
            return ExecuteTable("spcountinvoice4particularcustomer", objp);
        }
        public DataTable GetInvoiceDetailsneww(int invoiceno, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invno", SqlDbType.Int,4),
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetInvoiceDtlsrev", objp);
        }


        public DataTable GetPADetailsneww(int pano, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pano", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1) };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetPADtlsrev", objp);
        }
        //public DataTable spcountinvoice4particularcustomer(int customerid, int branchid, int vouyear, int empid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid",SqlDbType.Int),
        //                                               new SqlParameter("@branchid", SqlDbType.Int),
        //                                               new SqlParameter("@vouyear",SqlDbType.Int),
        //                                               new SqlParameter("@empid",SqlDbType.Int)
        //    };
        //    objp[0].Value = customerid;
        //    objp[1].Value = branchid;
        //    objp[2].Value = vouyear;
        //    objp[3].Value = empid;
        //    return ExecuteTable("spcountinvoice4particularcustomer", objp);
        //}
        public DataTable GETTALLYCostname(int voufrom, int vouto,
string ftype, int branchid, int vouyear, DateTime date)
        {

            SqlParameter[] objp = new SqlParameter[] {new
SqlParameter("@voufrom",SqlDbType.Int,4),
new SqlParameter("@voutype",SqlDbType.VarChar,100),
new SqlParameter("@branchid",SqlDbType.TinyInt,1),
new SqlParameter("@vouyear", SqlDbType.Int),
new SqlParameter("@vouto",SqlDbType.Int,4),
            new SqlParameter("@date",SqlDbType.DateTime,10)};
            objp[0].Value = voufrom;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = vouto;
            objp[5].Value = date;
            return ExecuteTable("SPTALLYGETCostname", objp);
        }


        public DataTable GetHBLContainerDtlssms(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPHblInvContnoforsms", objp);
        }

        public DataTable GetMblContainerDtlssms(int jobno, string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = strTranType;
            objp[3].Value = branchid;
            return ExecuteTable("SPInvMblContnoforsms", objp);
        }
        public DataTable GetDebiteNoteNewall(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SPGetDebitenote", objp);
        }

        ///Rubannew for tdstypeallnew
        public DataTable GetTdsTypeNewall(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;


            return ExecuteTable("SPGetTdsTypeNew", objp);
        }

        public DataTable GetTdsNewall(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
              ,
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;

            objp[3].Value = divisionid;


            return ExecuteTable("SPGetTdsNew", objp);
        }

        public DataTable GetCrediteNoteNewall(DateTime fromdate, DateTime todate, int brnachid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetCrediteNotOper", objp);
        }
        //INvoice.cs
        //For TallyXMl
        public DataTable GETTALLYLedgername(int voufrom, int vouto,
string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new
SqlParameter("@voufrom",SqlDbType.Int,4),
new SqlParameter("@voutype",SqlDbType.VarChar,100),
new SqlParameter("@branchid",SqlDbType.TinyInt,1),
new SqlParameter("@vouyear", SqlDbType.Int),
new SqlParameter("@vouto",SqlDbType.Int,4) };
            objp[0].Value = voufrom;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = vouto;
            //  return ExecuteTable("SPTALLYGETLedgername", objp);
            return ExecuteTable("logixSPTALLYledgernamelv", objp); ////haribalaji

        }
        public DataTable GETTALLYCostname(int voufrom, int vouto,
string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new
SqlParameter("@voufrom",SqlDbType.Int,4),
new SqlParameter("@voutype",SqlDbType.VarChar,100),
new SqlParameter("@branchid",SqlDbType.TinyInt,1),
new SqlParameter("@vouyear", SqlDbType.Int),
new SqlParameter("@vouto",SqlDbType.Int,4) };
            objp[0].Value = voufrom;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            objp[4].Value = vouto;
            //return ExecuteTable("SPTALLYGETCostname", objp);
            return ExecuteTable("SPTALLYGETCostname_allhd", objp); ////haribalaji

        }
        public DataTable GetVouchDtlswiseStaxcreate(int fromno, int
tono, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new
SqlParameter("@fromno", SqlDbType.Int,4),
                                                       new
SqlParameter("@tono", SqlDbType.Int,4),
                                                       new
SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new
SqlParameter("@vouyear", SqlDbType.Int),
                                                       new
SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = fromno;
            objp[1].Value = tono;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            // return ExecuteTable("SPGetvoucherwiseSTaxonlyforledgercreation", objp);
            return ExecuteTable("SPGetvoucherwiseSTaxonlyforledgercreation_allhd", objp); ////haribalaji
        }

        public DataTable GetInvPAChargeamountWithCur4Charge(int vouno,
string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new
SqlParameter("@vouno",SqlDbType.Int,4),
new SqlParameter("@ftype",SqlDbType.VarChar,20),
new SqlParameter("@branchid",SqlDbType.TinyInt,1),
new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return
ExecuteTable("SPGetInvPAChargeAndAmountWithCur4Charge", objp);
        }

        public DataTable GetInvPAChargeamountWithCur4Cust(int vouno,
string ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new
SqlParameter("@vouno",SqlDbType.Int,4),
new SqlParameter("@ftype",SqlDbType.VarChar,20),
new SqlParameter("@branchid",SqlDbType.TinyInt,1),
new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return
ExecuteTable("SPGetInvPAChargeAndAmountWithCur4Cust", objp);
        }
        public DataTable GetHblInvoiceHeadnew(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelInvHeadfornewtally", objp);
        }

        public DataTable GetPolPod(int invoiceno, string ftype, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invno", SqlDbType.Int,4),
                                                       new SqlParameter("@ftype", SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetInvoicedtlsForNew", objp);
        }

        //Micheal 
        public int getcustomercountry(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@customerid",SqlDbType.Int)

        };
            objp[0].Value = customerid;
            return int.Parse(ExecuteReader("spgetcustomercountry", objp));
        }

        public DataTable ShowTallyDtNEW(int invpano, string ftype, int vouyear, int branchid, int to)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
            new SqlParameter("@to",SqlDbType.Int,4)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = to;
            return ExecuteTable("SPSelTallyDtNEW", objp);
        }

        public DataTable GET_exratechecknew(int refno, int bid, int vouyear, int jobno, string trantype, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
                                                         new SqlParameter("@jobno",  SqlDbType.Int, 4),
                                                            new SqlParameter("@trantype", SqlDbType.VarChar, 50),
             new SqlParameter("@voutype", SqlDbType.VarChar, 50)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = voutype;

            return ExecuteTable("sp_exratecheckOSDNCN", objp);
        }





        /// invoice.cs*******************

        public DataTable GetdncnNoFromJobno(int jobno, string trantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                  new SqlParameter("@type",SqlDbType.VarChar,10)
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteTable("SPGetdncnNoFromJobNo", objp);
        }
        public void UpdateExRateFromDNCNJobNo(int invno, int branchid, int jobno, string curr, double newexrate, string trantype, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@newexrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
             new SqlParameter("@voutype",SqlDbType.VarChar,10)
            };
            objp[0].Value = invno;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = curr;
            objp[4].Value = newexrate;
            objp[5].Value = trantype;
            objp[6].Value = vouyear;
            objp[7].Value = voutype;
            ExecuteQuery("SPUpdExrateFromDNCNNo", objp);
        }



        public void InsDNCNAmendExRateDetable(int invoiceno, int branchid, int jobno, string curr, double exrateupd, string trantype, int vouyear, double exratemast, double exratepa, int empid, DateTime updateon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invoiceno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@exrateupd",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@exratemast",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@exratepa",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter("@empid",SqlDbType.Int,2),
                                                                                     new SqlParameter("@updateon",SqlDbType.DateTime,4)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = curr;
            objp[4].Value = exrateupd;
            objp[5].Value = trantype;
            objp[6].Value = vouyear;
            objp[7].Value = exratemast;
            objp[8].Value = exratepa;
            objp[9].Value = empid;
            objp[10].Value = updateon;
            ExecuteQuery("SPInsDNCNAmendExRateDetable", objp);
        }

        public string GetBLNoFromDNCNNonew(int jobno, int invno, string trantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4),
             new SqlParameter("@type",SqlDbType.VarChar,10)
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            objp[4].Value = type;
            return ExecuteReader("SPGetBLNoFromDNCNNopro", objp).ToString();
        }
        public DataTable GetCurrFromDNCNNonew(int jobno, int invno, string trantype, int branchid, string type)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@invno",SqlDbType.Int,4),
                                                    new SqlParameter("@type",SqlDbType.VarChar,10)
            };
            objp[0].Value = jobno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            objp[3].Value = invno;
            objp[4].Value = type;
            return ExecuteTable("SPGetCurrFromDNCNNopro", objp);
        }

        //10122020


        public DataTable ProformaInvPending(int bid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = bid;
            objp[1].Value = div;
            return ExecuteTable("SpGetProformaInvpending", objp);
        }

        public DataTable ProformaCNOperationsPending(int bid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                 new SqlParameter("@branchid",SqlDbType.Int) ,
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = bid;
            objp[1].Value = div;
            return ExecuteTable("SpGetProformaCnOperationspending", objp);
        }
        public DataTable GetPerformaOSDNPending(int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                 new SqlParameter("@branchid",SqlDbType.Int) ,
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = brnachid;
            objp[1].Value = div;
            return ExecuteTable("SpGetPerformaOSDNpending", objp);
        }


        public DataTable GetPerformaOSCNPending(int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = brnachid;
            objp[1].Value = div;
            return ExecuteTable("SpGetPerformaOSCNpending", objp);
        }

        public DataTable GetPerformaOtherDnPending(int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };
            objp[0].Value = brnachid;
            objp[1].Value = div;
            return ExecuteTable("SpGetPerformaOtherDnpending", objp);
        }
        public DataTable GetProOtherCnRegisterPending(int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{

                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };


            objp[0].Value = brnachid;
            objp[1].Value = div;

            return ExecuteTable("SpGetProOtherCnRegisterpending", objp);
        }
        public DataTable GEtProProformaCNAdminPending(int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{

                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };


            objp[0].Value = brnachid;

            objp[1].Value = div;
            return ExecuteTable("SpGetProPAAdminRegisterpending", objp);
        }

        public DataTable GEtProProformaDNAdminPending(int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{

                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };


            objp[0].Value = brnachid;
            objp[1].Value = div;

            return ExecuteTable("SpGetProProformaDNAdminpending", objp);
        }

        public DataTable ProformaCNOperationsnew(DateTime fromdate, DateTime todate, int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;

            return ExecuteTable("SpGetProformaCnOperations", objp);
        }

        public DataTable GetPerformaOSDNnew1(DateTime fromdate, DateTime todate, int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;

            return ExecuteTable("SpGetPerformaOSDN", objp);
        }


        public DataTable GetPerformaOSCNnew(DateTime fromdate, DateTime todate, int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;

            return ExecuteTable("SpGetPerformaOSCN", objp);
        }

        public DataTable GetPerformaOtherDnNew1(DateTime fromdate, DateTime todate, int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;

            return ExecuteTable("SpGetPerformaOtherDn", objp);
        }
        public DataTable GetProOtherCnRegisternew(DateTime fromdate, DateTime todate, int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)
              ,
                 new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;

            return ExecuteTable("SpGetProOtherCnRegister", objp);
        }
        public DataTable GEtProProformaCNAdminNew1(DateTime fromdate, DateTime todate, int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int)  ,
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;

            return ExecuteTable("SpGetProPAAdminRegister", objp);
        }

        public DataTable GEtProProformaDNAdminNew1(DateTime fromdate, DateTime todate, int brnachid, int div)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int) ,
                 new SqlParameter("@divisionid",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;

            return ExecuteTable("SpGetProProformaDNAdminNew", objp);
        }



        public float GetWeightnew(string blno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPInvWeightnew", objp));
        }


        // method is used to get sum of weight to calculate the amount in checkbase function
        public float GetSumofWeightnew(string jobno, string strTranType, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strTranType;
            objp[2].Value = branchid;
            return float.Parse(ExecuteReader("SPFIEInvSWeightnew", objp));
        }


        public DataTable GetRecPmtDtls(string type, DateTime fromdate, DateTime todate, string mode, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                        new SqlParameter("@type", SqlDbType.VarChar,2),
                                                        new SqlParameter("@frmdate", SqlDbType.DateTime),
                                                        new SqlParameter("@todate", SqlDbType.DateTime),
                                                        new SqlParameter("@mode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@branchid",SqlDbType.Int)
                                                    };

            objp[0].Value = type;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = mode;
            objp[4].Value = branchid;

            return ExecuteTable("MyUseRecPmtDtls", objp);
        }

        public DataTable GetVoucherAgainstRcptPayNEW(int vouno, int branchid, int vouyear, string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetVouAgainstRcptPayraj", objp);
        }

        //Nov242021reversal
        public DataTable GetDNCN4MISFromJobNoReversal(int jobno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            return ExecuteTable("SPGetDNCNForMISFromJobnoReversalLV", objp);
        }

        public void InsertPATDS(int vouno, string voutype, int branchid, int customerid, int vouyear, double cstamount, double tdsamount)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@cstamount",SqlDbType.Real,8),
                                                                                     new SqlParameter("@tdsamount",SqlDbType.Real,8),
                                                                                     new SqlParameter("@voutype",SqlDbType.Char,1)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = customerid;
            objp[3].Value = vouyear;
            objp[4].Value = cstamount;
            objp[5].Value = tdsamount;
            objp[6].Value = voutype;
            //ExecuteQuery("SPInsPATDS", objp);
            ExecuteQuery("SPInsPATDSRCM", objp);
        }

        // add by yuvaraj 30-12-2022

        public DataTable InvChargeFrombuyinginvoiceAllTrantype(int quotno, int Bid, string bookingno, string trantypes)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@trantypes",SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = quotno;
            objp[1].Value = Bid;
            objp[2].Value = bookingno;
            objp[3].Value = trantypes;

            return ExecuteTable("SPInvChargeFrombuyinginvoiceAllTrantype", objp);
        }
        public DataTable Getbranchdetails4report(string vtype, int invoiceno, int vouyear, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                        new SqlParameter("@ftype", SqlDbType.VarChar,1),
                                                       new SqlParameter("@invoiceno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                        new SqlParameter("@bid",SqlDbType.Int, 4)
                                                      };
            objp[0].Value = vtype;
            objp[1].Value = invoiceno;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetBranchDetails", objp);
        }
        public DataTable getsizetype(string blno, int jobno, int branchid, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[] {    new SqlParameter("@blno", SqlDbType.VarChar,50),
                                                       new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
             new SqlParameter("@trantype", SqlDbType.VarChar,50)};
            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            return ExecuteTable("Get_sizetypeblno", objp);
        }
        ////////////////////////////
        public double GetOSExRate_new(string currency, DateTime Dtdate, string extype, int did)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr",SqlDbType.VarChar,6),
                                                       new SqlParameter("@Dtdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@extype",SqlDbType.VarChar,1),
                                                       new SqlParameter("@did",SqlDbType.Int)};
            objp[0].Value = currency;
            objp[1].Value = Dtdate;
            objp[2].Value = extype;
            objp[3].Value = did;
            return double.Parse(ExecuteReader("SPExRateOSCurrDate_new", objp));
        }
        /////////////////////////////////
        public DataTable Getcusrefnofromquot4rpt(int branchid, string trantype, string blno, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,3),
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30),

              new SqlParameter("@rpttype",SqlDbType.VarChar,10) };
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = blno;

            objp[3].Value = type;

            return ExecuteTable("SPGetcusrefnofromquot4rpt", objp);
        }

        //new


        public DataTable GetinvoicedetailsgridBOSFC(int invoiceno, int branchid, int vouyear, string trantype, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@profoma",SqlDbType.VarChar, 10)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = profoma;
            return ExecuteTable("sp_getinvoicedetailsgridBOSFC", objp);
        }
        public DataTable GetinvoicedetailsgridFC(int invoiceno, int branchid, int vouyear, string trantype, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@profoma",SqlDbType.VarChar, 10)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = profoma;
            return ExecuteTable("sp_getinvoicedetailsgridFC", objp);
        }
        public DataTable GSTFC(int invoiceno, int branchid, int vouyear, string trantype, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                      new SqlParameter("@profoma",SqlDbType.VarChar, 10)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = profoma;
            return ExecuteTable("sp_GSTFC", objp);
        }
        public DataTable GSTFC_PA(int pano, int branchid, int vouyear, string trantype, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pano",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                      new SqlParameter("@profoma",SqlDbType.VarChar, 10)};
            objp[0].Value = pano;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = profoma;
            return ExecuteTable("sp_GSTFC_PA", objp);
        }

        public DataTable GetPADetailsFC(int pano, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pano", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1) };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetPADtlsFC", objp);
        }
        public DataTable GetPADetailsnewFC(int pano, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pano", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1) };
            objp[0].Value = pano;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetPADtlsrevFC", objp);
        }

        public void UpdateExRateFromJobNo_InvFC(int invno, int branchid, int jobno, string curr, double newexrate, string trantype, int vouyear, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@newexrate",SqlDbType.Money,8),
                                                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                                     new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                     new SqlParameter("@type",SqlDbType.VarChar,50)};
            objp[0].Value = invno;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            objp[3].Value = curr;
            objp[4].Value = newexrate;
            objp[5].Value = trantype;
            objp[6].Value = vouyear;
            objp[7].Value = type;
            ExecuteQuery("SPUpdExrateFromInvNo_InvFC", objp);
        }
        public DataTable getInvJobDtChk(int refno, int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2)};
            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;

            return ExecuteTable("sp_getInvJobDtChk", objp);//

        }
        public DataTable Checkrefid4ProLV(int refno, int vouyear, int branchid, int type)
        {
            SqlParameter[] objp = new SqlParameter[] {
            new SqlParameter("@refno",SqlDbType.Int,4),
            new SqlParameter("@vouyear",SqlDbType.Int,4),
            new SqlParameter("@branchid",SqlDbType.Int,4),
            new SqlParameter("@type",SqlDbType.Int)};

            objp[0].Value = refno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteTable("SPGetrefforPRoLV", objp);
        }
        public DataTable GetCheckApprovedProfomaLV(int refno, int branchid, int vouyear, string trantype, int type, string function)
        {
            SqlParameter[] objp = new SqlParameter[] {
            new SqlParameter("@refno",SqlDbType.Int,4),
                new SqlParameter("@branchid",SqlDbType.Int,4),
                new SqlParameter("@vouyear",SqlDbType.Int,4),
                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@func",SqlDbType.VarChar,30)
            };

            objp[0].Value = refno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = type;
            objp[5].Value = function;
            return ExecuteTable("SPcheckapprovedProfomaLV", objp);
        }
        public string GetCreditDaysfromVoucher4LV(int branchid, int vouno, int voutype, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[]
              {
                  new SqlParameter("@branchid",SqlDbType.Int),
                  new SqlParameter("@vouno",SqlDbType.Int),
                  new SqlParameter("@voutype",SqlDbType.Int),
                    new SqlParameter("@vouyear",SqlDbType.Int)
                };
            objp[0].Value = branchid;
            objp[1].Value = vouno;
            objp[2].Value = voutype;
            objp[3].Value = vouyear;

            return ExecuteReader("SPGetCreditDaysfromVoucher4LV", objp);

        }
        public DataTable Getlvdetailsforreport(int branchid, string trantype, int invoiceno, int vouyear, string bltype, int header, string agent, string profoma)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,3),
                                                       new SqlParameter("@invoiceno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@bltype", SqlDbType.VarChar,1),
                                                       new SqlParameter("@header", SqlDbType.Int),
                                                       new SqlParameter("@agent", SqlDbType.VarChar,1)};
            objp[0].Value = branchid;
            objp[1].Value = trantype;
            objp[2].Value = invoiceno;
            objp[3].Value = vouyear;
            objp[4].Value = bltype;
            objp[5].Value = header;
            objp[6].Value = agent;
            if (profoma == "Profoma")
            {
                return ExecuteTable("sp_getprolvdetails", objp);
            }
            else
            {
                return ExecuteTable("sp_getLVreportdetails", objp);
                // return ExecuteTable("sp_getinvoicedetailsnew", objp);
            }
        }
        public DataTable GetLVdetailsgrid(int invoiceno, int branchid, int vouyear, string trantype, string profoma, int type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invoiceno",SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@profoma",SqlDbType.VarChar, 10), new SqlParameter("@type",SqlDbType.Int, 4)};
            objp[0].Value = invoiceno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = trantype;
            objp[4].Value = profoma;
            objp[5].Value = type;
            return ExecuteTable("sp_getLVdetailsgrid", objp);
        }

        public DataTable Getrefidvouchers(int refno, int vouyear, int branchid, int type)
        {
            SqlParameter[] objp = new SqlParameter[] {
            new SqlParameter("@refno",SqlDbType.Int,4),
            new SqlParameter("@vouyear",SqlDbType.Int,4),
            new SqlParameter("@branchid",SqlDbType.Int,4),
            new SqlParameter("@type",SqlDbType.Int)};

            objp[0].Value = refno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = type;
            return ExecuteTable("SPGetrefforvalidatevouchers", objp);
        }
        public DataTable ShowLVHead(int invpano, string strantype, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                                            new SqlParameter("@ftype",SqlDbType.Int),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invpano;
            objp[1].Value = strantype;
            objp[2].Value = ftype;
            objp[3].Value = vouyear;
            objp[4].Value = branchid;
            return ExecuteTable("SPSelLVHead", objp);
        }

        public DataTable GetLVDetails(int invoiceno, int ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@invno", SqlDbType.Int,4),
                                                       new SqlParameter("@ftype", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt,1)};
            objp[0].Value = invoiceno;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetlVdtls", objp);
        }
        public DataTable CheckLVCustblno(string blno, int custid, string strTranType, int ftype, int branchid, int vouyear, char agent)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@custid",SqlDbType.Int,4),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@ftype",SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = custid;
            objp[2].Value = strTranType;
            objp[3].Value = ftype;
            objp[4].Value = branchid;
            objp[5].Value = vouyear;

            return ExecuteTable("SPGetLVno", objp);
        }

        public DataTable GET_exratecheckLV(int refno, int bid, int vouyear, int voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
             new SqlParameter("@voutype", SqlDbType.Int)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("sp_exratecheckLV", objp);
        }
        public DataTable Get_checkwithSGSTPIGSTLV(int refno, int bid, int vouyear, int voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
             new SqlParameter("@voutype", SqlDbType.Int)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("sp_checkwithSGSTPIGSTLV", objp);
        }


        //Dinesh

        public DataTable Get_checkwithSGSTPIGST1LV(int refno, int bid, int vouyear, int voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
             new SqlParameter("@voutype", SqlDbType.Int)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("sp_checkwithSGSTPIGST1LV", objp);
        }
        //
        public DataTable GET_exratechecknewLV(int refno, int bid, int vouyear, int jobno, string trantype, int voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int, 4),

                                                    new SqlParameter("@branchid",  SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",  SqlDbType.Int, 4),
                                                         new SqlParameter("@jobno",  SqlDbType.Int, 4),
                                                            new SqlParameter("@trantype", SqlDbType.VarChar, 50),
             new SqlParameter("@voutype", SqlDbType.VarChar, 50)};
            objp[0].Value = refno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;
            objp[3].Value = jobno;
            objp[4].Value = trantype;
            objp[5].Value = voutype;

            return ExecuteTable("sp_exratecheckOSDNCNLV", objp);
        }

        public DataTable GetRegdtlsLV(DateTime fromdate, DateTime todate, int brnachid, int divisionid, int voutype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int),
                  new SqlParameter("@vtype",SqlDbType.Int)
            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = divisionid;
            objp[4].Value = voutype;
            return ExecuteTable("SpGetregdtlsLV", objp);
        }
        public DataTable GetRegdtlsProLV(DateTime fromdate, DateTime todate, int brnachid, int div, int voutype)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@fromdate", SqlDbType.DateTime),
                new SqlParameter("@todate", SqlDbType.DateTime),
                 new SqlParameter("@branchid",SqlDbType.Int),
                 new SqlParameter("@divisionid",SqlDbType.Int),
                  new SqlParameter("@vtype",SqlDbType.Int)

            };

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = brnachid;
            objp[3].Value = div;
            objp[4].Value = voutype;
            return ExecuteTable("SpGetRegdtlsProLV", objp);
        }
        public DataTable GetPartyLedger4PAPROAdminwithCustCOM(int vouno, int ftype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                                            new SqlParameter("@type",SqlDbType.Int),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetPartyLedger4PAPROAdminwithcustCOM", objp);
        }
        public string GetVoucherAgainstRcptPayCOM(int vouno, int branchid, int vouyear, string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteReader("SPGetVouAgainstRcptPayrajCOM", objp);
        }
        public DataTable GetVoucherAgainstRcptPayNEWCOM(int vouno, int branchid, int vouyear, string ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,1),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = vouno;
            objp[1].Value = ftype;
            objp[2].Value = branchid;
            objp[3].Value = vouyear;
            return ExecuteTable("SPGetVouAgainstRcptPayrajCOM", objp);
        }
        public DataTable FAShowTallyDtlv(int invpano, string ftype, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@invpano",SqlDbType.Int,4),
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20),
                                                                            new SqlParameter("@vouyear",SqlDbType.Int),
                                                                            new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                                            new SqlParameter("@accdbname",SqlDbType.VarChar,10)};
            objp[0].Value = invpano;
            objp[1].Value = ftype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = "FAPL";
            return ExecuteTable("SPSelTallyDtFAlv", objp);
        }
        public DataTable Get_shipper(int branchid, string trantype, string blno)
        {
            SqlParameter[] array = new SqlParameter[3]
            {
            new SqlParameter("@bid", SqlDbType.Int, 4),
            new SqlParameter("@trantype", SqlDbType.VarChar, 3),
            new SqlParameter("@blno", SqlDbType.VarChar, 30)
            };
            array[0].Value = branchid;
            array[1].Value = trantype;
            array[2].Value = blno;
            return ExecuteTable("sp_Get_shipper", array);
        }

        public DataTable GetOsdncnforreportshippercosignee(int bid, string trantype, int refno, int voyear, string type)
        {
            SqlParameter[] array = new SqlParameter[5]
            {
            new SqlParameter("@bid", SqlDbType.Int),
            new SqlParameter("@trantype", SqlDbType.VarChar, 3),
            new SqlParameter("@dncn", SqlDbType.Int),
            new SqlParameter("@vouyear", SqlDbType.Int),
            new SqlParameter("@bltype", SqlDbType.VarChar, 10)
            };
            array[0].Value = bid;
            array[1].Value = trantype;
            array[2].Value = refno;
            array[3].Value = voyear;
            array[4].Value = type;
            return ExecuteTable("OSSIcnshiperconsignee", array);
        }
        public DataTable get_OSDNCNgrwt(string blno, int bid, int cid, string trantype)
        {
            SqlParameter[] array = new SqlParameter[4]
            {
            new SqlParameter("@blno", SqlDbType.VarChar, 50),
            new SqlParameter("@bid", SqlDbType.Int, 4),
            new SqlParameter("@cid", SqlDbType.Int, 4),
            new SqlParameter("@trantype", SqlDbType.VarChar, 50)
            };
            array[0].Value = blno;
            array[1].Value = bid;
            array[2].Value = cid;
            array[3].Value = trantype;
            return ExecuteTable("spgetosdncngrwt", array);
        }
        public DataTable Getspgetosdncngrwtntwt(int bid, string trantype, int refno, int voyear, string type)
        {
            SqlParameter[] array = new SqlParameter[5]
            {
            new SqlParameter("@bid", SqlDbType.Int),
            new SqlParameter("@trantype", SqlDbType.VarChar, 3),
            new SqlParameter("@dncn", SqlDbType.Int),
            new SqlParameter("@vouyear", SqlDbType.Int),
            new SqlParameter("@bltype", SqlDbType.VarChar, 10)
            };
            array[0].Value = bid;
            array[1].Value = trantype;
            array[2].Value = refno;
            array[3].Value = voyear;
            array[4].Value = type;
            return ExecuteTable("spgetOSSIcngrwtntwt", array);
        }

        public DataTable Getblformtrpt(int divisionid)
        {
            SqlParameter[] objp1 = new SqlParameter[] {
                                                     new SqlParameter("@divid",SqlDbType.Int,4)
                                                     };
            objp1[0].Value = divisionid;
            return ExecuteTable("SPGetblformtrpt", objp1);
        }
        public DataTable GETsign4invoice()
        {

            return ExecuteTable("SPGETsign4invoice");
        }
    }
}
