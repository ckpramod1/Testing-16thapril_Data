using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterCustomer : DBObject
    {

        Masters.MasterPort Portobj = new MasterPort();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterCustomer()
        {
            Conn = new SqlConnection(DBCS);
        }
        //Methods
       

        //Insert MasterCustomer details
        public void InsertCustomerDetails(string customername, string customertype, string contactperson, string address, string city, string zip, string phone, string fax, string email, string commail, string expmail, string impmail, string finmail, double tds, string comptc, string expptc, string impptc, string finptc)
        {
            char ctype = CheckCustomerType(customertype);
            int cityid = Portobj.GetNPortid(city);
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                      new SqlParameter("@customertype",SqlDbType.Char,1),        
                                                      new SqlParameter("@address",SqlDbType.VarChar,250), 
                                                      new SqlParameter("@city",SqlDbType.Int),
                                                      new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                      new SqlParameter("@phone",SqlDbType.VarChar,25),
                                                      new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                      new SqlParameter("@email",SqlDbType.VarChar,50), 
                                                      new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@commail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@tds",SqlDbType.Real,4) ,
                                                      new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finptc",SqlDbType.VarChar,50)}
                                                     ;

            objp[0].Value = customername;
            objp[1].Value = ctype;
            objp[2].Value = address;
            objp[3].Value = cityid;
            objp[4].Value = zip;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = contactperson;
            objp[9].Value = commail;
            objp[10].Value = expmail;
            objp[11].Value = impmail;
            objp[12].Value = finmail;
            objp[13].Value = tds;
            objp[14].Value = comptc;
            objp[15].Value = expptc;
            objp[16].Value = impptc;
            objp[17].Value = finptc;
            ExecuteQuery("SPInsCustomerDetails", objp);
        }

        //Retrieve Customer Details   
        public DataTable RetrieveCustomerDetails(string customername, string customertype, string location)
        {
            char ctype = CheckCustomerType(customertype);
            int locationid = Portobj.GetNPortid(location);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customertype",SqlDbType.Char,1),        
                                                                                     new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@city",SqlDbType.Int)};

            objp[0].Value = ctype;
            objp[1].Value = customername;
            objp[2].Value = locationid;

            return ExecuteTable("SPSelCustomerDetails", objp);

        }

        //Update customer Details.  
        public void UpdateCustomerDetails(int customerid, string customername, string customertype, string address, string city, string zip, string phone, string fax, string email, string ptc, string commail, string expmail, string impmail, string finmail, double tds, string comptc, string expptc, string impptc, string finptc)
        {
            char ctype = CheckCustomerType(customertype);
            int cityid = Portobj.GetNPortid(city);
            // int custid = GetCustomerid(customername, customertype, city);
            SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                      new SqlParameter("@customertype",SqlDbType.Char,1),        
                                                      new SqlParameter("@address",SqlDbType.VarChar,250), 
                                                      new SqlParameter("@city",SqlDbType.Int),
                                                      new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                      new SqlParameter("@phone",SqlDbType.VarChar,25),
                                                      new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                      new SqlParameter("@email",SqlDbType.VarChar,50), 
                                                      new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@customerid",SqlDbType.Int,4),
                                                      new SqlParameter("@commail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@tds",SqlDbType.Real,4),
                                                      new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finptc",SqlDbType.VarChar,50)
                                                    };
            objp[0].Value = customername;
            objp[1].Value = ctype;
            objp[2].Value = address;
            objp[3].Value = cityid;
            objp[4].Value = zip;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = ptc;
            objp[9].Value = customerid;
            objp[10].Value = commail;
            objp[11].Value = expmail;
            objp[12].Value = impmail;
            objp[13].Value = finmail;
            objp[14].Value = tds;
            objp[15].Value = comptc;
            objp[16].Value = expptc;
            objp[17].Value = impptc;
            objp[18].Value = finptc;
            ExecuteQuery("SPUpdCustomerDetails", objp);
        }

        //Get customertypecode based on customertype. 
        public char CheckCustomerType(string customertype)
        {
            switch (customertype)
            {
                case ("Shipper"):
                    return 'C';

                case ("Consignee"):
                    return 'C';

                case ("Notify Party"):
                    return 'C';

                case ("Agent / Principal/CounterPart"):
                    return 'P';

                case ("CHA / CNF"):
                    return 'C';

                case ("Carrier / Airliner / MLO / Freight Forwarder"):
                    return 'C';

                case ("Transporter"):
                    return 'C';

                case ("Others"):
                    return 'C';

                case ("Counter Part"):
                    return 'C';

                case ("CFS"):
                    return 'C';

                case ("Warehouse"):
                    return 'C';

                default:
                    return 'C';
            }
        }

        //Get Customerid Based on Customername and Customertype.  
        public int GetCustomerid(string customername, string customertype, string location)
        {
            char ctype = CheckCustomerType(customertype);
            int cityid = Portobj.GetNPortid(location);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customertype",SqlDbType.Char,1),        
                                                                                     new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@city",SqlDbType.Int)};
            objp[0].Value = ctype;
            objp[1].Value = customername;
            objp[2].Value = cityid;
            return int.Parse(ExecuteReader("SPCustomeridCTypeNameCity", objp));
        }
        public int GetCustomerid(string customername, string location)
        {
            Portobj.GetDataBase(Clientcode);
            int cityid = Portobj.GetNPortid(location);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@city",SqlDbType.Int)};

            objp[0].Value = customername;
            objp[1].Value = cityid;
            return int.Parse(ExecuteReader("SPCustomeridCNameCity", objp));
        }
        //Get Customerid Based on Customername.  
        public int GetCustomerid(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return int.Parse(ExecuteReader("SPCustomeridCName", objp));

        }

        //Get Customername Based on Customerid. 
        public string GetCustomername(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteReader("SPCustomernameCId", objp);
        }

        public string GetLedgerName(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteReader("SPLedgernameCId", objp);
        }

        //Get Customer location based on customerid.
        public string GetCustlocation(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteReader("SPCustomercityCId", objp);
        }

        public string GetRegCustlocation(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteReader("SPRegCustomercityName", objp);
        }

        //Get Customer AdReaderess. 
        public string GetCustomerAddress(string customername, string customertype, string location)
        {
            string fulladress = "";
            int cusid = GetCustomerid(customername, location);
            if (cusid != 0)
            {
                SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
                objp[0].Value = cusid;
                Dt = ExecuteTable("SPCustomeraddressCId", objp);
                string address = Dt.Rows[0].ItemArray[0].ToString();
                string city = Portobj.GetPortname(int.Parse(Dt.Rows[0].ItemArray[1].ToString()));
                string zip = Dt.Rows[0].ItemArray[2].ToString();
                fulladress = address.Trim() + " , " + city + " - " + zip;
            }
            return fulladress;
        }
        //public string GetCustomerAddress(int intcustid)
        //{
        //    string fulladress = "";
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
        //    objp[0].Value = intcustid;
        //    Dt = ExecuteTable("SPCustomeraddressCId", objp);
        //    string address = Dt.Rows[0].ItemArray[0].ToString();
        //    string city = Portobj.GetPortname(int.Parse(Dt.Rows[0].ItemArray[1].ToString()));
        //    string zip = Dt.Rows[0].ItemArray[2].ToString();
        //    fulladress = address.Trim() + " , " + city + " - " + zip; return fulladress;
        //} 
        //public string GetCusMailaddrs(int cusid)
        //{
        //    string strTemp = "";
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
        //    objp[0].Value = cusid;
        //    Dt = ExecuteTable("SPSelCusEmailid", objp);
        //    if (Dt.Rows.Count > 0)
        //    {
        //        if (Dt.Rows[0]["email"].ToString() != "")
        //        {

        //            strTemp = Dt.Rows[0]["email"].ToString();

        //        }


        //    }
        //    return strTemp;
        //}


        public string GetCusMailaddrs(int cusid)
        {
            string strTemp = "";
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = cusid;
            Dt = ExecuteTable("SPSelCusEmailid", objp);
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0]["email"].ToString() != "")
                {
                    if (Dt.Rows[0]["commailid"].ToString() != "")
                    {
                        strTemp = Dt.Rows[0]["email"].ToString() + ";" + Dt.Rows[0]["commailid"].ToString();
                    }
                    else
                    {
                        strTemp = Dt.Rows[0]["email"].ToString();
                    }
                }
            }
            return strTemp;
        }
        // *******Methods For Windows Application.*********

        //Get LikeCustomer
        public DataTable GetLikeCustomer(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomer", objp);
        }

        public DataTable GetLikeIndianCustomer(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeIndianCustomer", objp);
        }

        public DataTable GetLikeCustomerAll(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerAll", objp);
        }

        public DataTable GetLikeCustomer(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPLikeCustomertype", objp);

        }

        public DataTable GetLikeCustomerForSales(string customername, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = empid;
            return ExecuteTable("SPLikeCustomerforSales", objp);

        }

        public DataTable GetLikeCustomerWDL(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomertypeWDL", objp);

        }

        public DataTable GetLikeCustomerWSCFL(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomertypeWFL", objp);

        }
        public int GetCustomeridwcusttype(string customername, string custtype)
        {
            if (custtype == "P")
            {
                custtype = "P";
            }
            else
            {
                custtype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                     new SqlParameter("@ctype",SqlDbType.VarChar,1)};

            objp[0].Value = customername;
            objp[1].Value = custtype;
            return int.Parse(ExecuteReader("SPCustomeridCtypeName", objp));
        }

        public String GetCustomerType(int intCustID)
        {
            string strTemp = "";
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = intCustID;
            Dt = ExecuteTable("SPCusTypeCusID", objp);
            if (Dt.Rows.Count > 0)
            {
                strTemp = Dt.Rows[0]["customertype"].ToString();
            }
            return strTemp;
        }


        public void UpdateOpeningBalance(int customerid, double opbalance)
        {


            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@opbalance",SqlDbType.Money,8) };
            objp[0].Value = customerid;
            objp[1].Value = opbalance;

            ExecuteQuery("SPUpdCustomerOpbal", objp);

        }
        public double GetCustomerOpeningBal(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return double.Parse(ExecuteReader("SPSelCustomerOpbal", objp));

        }

        public double CheckCreditAmount(string blno, int branchid, int division, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1) };
            objp[0].Value = blno;
            objp[1].Value = branchid;
            objp[2].Value = division;
            return double.Parse(ExecuteReader("SPCheckCreditAmount", objp));
        }
        public double CheckCreditAmount(int customerid, int branchid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1) };
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = division;
            return double.Parse(ExecuteReader("SPCheckCreditAmountCustomer", objp));
        }

        public double CheckCreditAmountOLDOUTSTD(int customerid, int branchid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1) };
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = division;
            return double.Parse(ExecuteReader("SPCheckCreditAmountCustomer", objp));
        }

        public double GetCreditAmount(int customerid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1)};
            objp[0].Value = customerid;
            objp[1].Value = division;
            return double.Parse(ExecuteReader("SPGetCreditAmountForCustomer", objp));
        }
        public int CheckCreditDays4Customer(int customerid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1) };
            objp[0].Value = customerid;
            objp[1].Value = division;
            return int.Parse(ExecuteReader("SPCheckCreditDays4Customer", objp));
        }
        public DataTable GetCreditAllDt4Customer(int customerid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1) };
            objp[0].Value = customerid;
            objp[1].Value = division;
            return ExecuteTable("SPGetCreditAllDt4Customer", objp);

        }
        public int GetCreditDays(int customerid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1) };
            objp[0].Value = customerid;
            objp[1].Value = division;
            return int.Parse(ExecuteReader("SPGetCreditDays4Customer", objp));
        }
        public double UpdOutStandingAmountCustomert(int customerid, int branchid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1)};
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = division;
            return double.Parse(ExecuteReader("SPUpdOutStandingAmountCustomer", objp));
        }


        public double GetOutStandingAmount(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return double.Parse(ExecuteReader("SPUpdOutStandingAmountCustomerTEST", objp));
        }


        //-----MasterCustomer MailID--------//
        public void InsertMCMailID(int customerid, string mailid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid",SqlDbType.Int,4),
                                                        new SqlParameter("@mailid", SqlDbType.VarChar, 50) };
            objp[0].Value = customerid;
            objp[1].Value = mailid;
            ExecuteQuery("SPInsMCusMailID", objp);
        }
        public void UpdateMCMailID(int customerid, string mailid, string oldmailid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid",SqlDbType.Int,4),
                                                        new SqlParameter("@mailid", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@oldmailid", SqlDbType.VarChar, 50)};
            objp[0].Value = customerid;
            objp[1].Value = mailid;
            objp[2].Value = oldmailid;
            ExecuteQuery("SPUpdMCusMailID", objp);
        }
        public DataTable SelMCMailID(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPSelMCusMailID", objp);
        }
        public void DeleteMCMailID(int customerid, string mailid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid",SqlDbType.Int,4),
                                                        new SqlParameter("@mailid", SqlDbType.VarChar, 50),
                                                       };
            objp[0].Value = customerid;
            objp[1].Value = mailid;
            ExecuteQuery("SPDelMCusMailID", objp);
        }
        public DataTable CheckMCMailID(int customerid, string mailid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@mailid",SqlDbType.VarChar,50)};
            objp[0].Value = customerid;
            objp[1].Value = mailid;
            return ExecuteTable("SPCheckMCusMailID", objp);
        }

        public void ChangeLedgerName(int CustID, string LedgerName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@ledgername",SqlDbType.VarChar,100)};
            objp[0].Value = CustID;
            objp[1].Value = LedgerName;
            ExecuteQuery("SPUpdLedgerName", objp);
        }
        //Agent Rebate
        public DataTable GetLikeCustomer4Inbound(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPLikeCustomertypeAgent", objp);
        }
        public String CheckCreditException(string docno, string trantype, int branchid)
        {
            string strTemp = "";
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1)};
            objp[0].Value = docno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            Dt = ExecuteTable("SPCheckCreditException", objp);
            if (Dt.Rows.Count > 0)
            {
                strTemp = Dt.Rows[0]["docno"].ToString();
            }
            else
            {
                strTemp = "";
            }
            return strTemp;
        }
        public DataTable RetrieveCustGroupDetails(string strCustGroupName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100) };

            objp[0].Value = strCustGroupName;

            return ExecuteTable("SPSelCustGroupDtsByName", objp);
        }
        public int GetCustomerGroupID(string groupname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100) };

            objp[0].Value = groupname;

            return int.Parse(ExecuteReader("SPGetCustomerGroupID", objp));

        }
        public DataTable RetrieveCustomerDetails(int intCustID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = intCustID;
            return ExecuteTable("SPSelCustomerDetails4web", objp);
        }
        public int GetCustomerIdFrmName(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return int.Parse(ExecuteReader("SPGetCustId", objp));
        }
        public DataTable GetCustomerForProfile(int intCustID, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt, 1) };
            objp[0].Value = intCustID;
            objp[1].Value = division;
            return ExecuteTable("SPGetCustomerPf", objp);
        }
        public DataTable GetCreditExpForProfile(int intCustID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = intCustID;
            return ExecuteTable("SPGetCreditExpforCP", objp);
        }
        public DataTable GetSubGroupForProfile(int intCustID, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt, 1) };
            objp[0].Value = intCustID;
            objp[1].Value = division;
            return ExecuteTable("SPGETSubGroupforCP", objp);
        }
        //Get LikeCustomer  For CustomerDetails
        public DataTable GetCustomer4cd(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCustomer4cd", objp);
        }

        public DataTable GetCustomershipment(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPSelShipmentDet4cd", objp);
        }
        public DataTable GetCustomerDetailsforSales(string cname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cname", SqlDbType.VarChar, 150) };
            objp[0].Value = cname;
            return ExecuteTable("SPSelCustomerDetailsforsales", objp);
        }
        public DataTable UpdSalesInMCustomer(int salesid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@salesid", SqlDbType.Int,4),
                                                      new SqlParameter("@customerid", SqlDbType.Int,4)};
            objp[0].Value = salesid;
            objp[1].Value = customerid;
            return ExecuteTable("SPUpdSalesIdInMCustomer", objp);
        }
        public DataTable GetAllLikeCustomer(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPAllCustomer", objp);

        }
        //code 4 Cust PAN nad ST No
        public DataTable GetCustDetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCustDetails", objp);
        }

        public void UpdCustPAN_STNo(int customerid, string panno, string stno)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@custid", SqlDbType.Int, 4),
                                                      new SqlParameter("@panno",SqlDbType.VarChar,25),        
                                                      new SqlParameter("@stno",SqlDbType.VarChar,25), 
                                                                                                         };
            objp[0].Value = customerid;
            objp[1].Value = panno;
            objp[2].Value = stno;
            ExecuteQuery("SPUpdCustPAN_STNo", objp);
        }
        public DataTable GetLikeCustomerNotAgent(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerNotAgent", objp);
        }
        //code 4 Cust MR Code

        public void InsMasterCust4MRCode(int customerid, string mrship, string mrconsg, string mrair, string mrsea, string mrscac, string mrnotify)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@custid", SqlDbType.Int, 4),
                                                      new SqlParameter("@mrship",SqlDbType.VarChar,15),        
                                                      new SqlParameter("@mrconsg",SqlDbType.VarChar,15), 
                                                      new SqlParameter("@mrair",SqlDbType.VarChar,15),        
                                                      new SqlParameter("@mrsea",SqlDbType.VarChar,15), 
                                                      new SqlParameter("@mrscac",SqlDbType.VarChar,15), 
                                                      new SqlParameter("@mrnotify",SqlDbType.VarChar,15), 
                                                                                                         };
            objp[0].Value = customerid;
            objp[1].Value = mrship;
            objp[2].Value = mrconsg;
            objp[3].Value = mrair;
            objp[4].Value = mrsea;
            objp[5].Value = mrscac;
            objp[6].Value = mrnotify;
            ExecuteQuery("SPInsMasterCust4MRCode", objp);
        }
        public void UpdMasterCust4MRCode(int customerid, string mrship, string mrconsg, string mrair, string mrsea, string mrscac, string mrnotify)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@custid", SqlDbType.Int, 4),
                                                      new SqlParameter("@mrship",SqlDbType.VarChar,15),        
                                                      new SqlParameter("@mrconsg",SqlDbType.VarChar,15), 
                                                      new SqlParameter("@mrair",SqlDbType.VarChar,15),        
                                                      new SqlParameter("@mrsea",SqlDbType.VarChar,15), 
                                                      new SqlParameter("@mrscac",SqlDbType.VarChar,15), 
                                                      new SqlParameter("@mrnotify",SqlDbType.VarChar,15), 
                                                                                                         };
            objp[0].Value = customerid;
            objp[1].Value = mrship;
            objp[2].Value = mrconsg;
            objp[3].Value = mrair;
            objp[4].Value = mrsea;
            objp[5].Value = mrscac;
            objp[6].Value = mrnotify;
            ExecuteQuery("SPUpdMasterCust4MRCode", objp);
        }
        public DataTable SelMasterCust4MRCode(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPSelMasterCust4MRCode", objp);
        }
        public void DelMasterCust4MRCode(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            ExecuteQuery("SPDelMasterCust4MRCode", objp);
        }
        public string GetCustName2MRCode(string code, char type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@code", SqlDbType.VarChar, 15),
                                                         new SqlParameter("@type",SqlDbType.Char,1)};
            objp[0].Value = code;
            objp[1].Value = type;
            return ExecuteReader("SPGetCustName2MRCode", objp);
        }

        //public string GetFILossCustomer(int empid, DateTime fdate, DateTime tdate, int bid, string type)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { 
        //                                                new SqlParameter("@empid", SqlDbType.Int, 4),
        //                                                new SqlParameter("@fdate", SqlDbType.SmallDateTime , 8),
        //                                                new SqlParameter("@tdate", SqlDbType.SmallDateTime , 8),
        //                                                new SqlParameter("@bid", SqlDbType.TinyInt, 1) ,
        //                                                new SqlParameter("@type", SqlDbType.VarChar, 10),
        //                                                 };
        //    objp[0].Value = empid;
        //    objp[1].Value = fdate;
        //    objp[2].Value = tdate;
        //    objp[3].Value = bid;
        //    objp[4].Value = type;
        //    return ExecuteReader("SPGetFILossCustomer", objp);
        //}

        //public string GetFINewCustomer(int empid, DateTime fdate, DateTime tdate, int bid, string type)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { 
        //                                                new SqlParameter("@empid", SqlDbType.Int, 4),
        //                                                new SqlParameter("@fdate", SqlDbType.SmallDateTime , 8),
        //                                                new SqlParameter("@tdate", SqlDbType.SmallDateTime , 8),
        //                                                new SqlParameter("@bid", SqlDbType.TinyInt, 1) ,
        //                                                new SqlParameter("@type", SqlDbType.VarChar, 10),
        //                                                 };
        //    objp[0].Value = empid;
        //    objp[1].Value = fdate;
        //    objp[2].Value = tdate;
        //    objp[3].Value = bid;
        //    objp[4].Value = type;
        //    return ExecuteReader("SPGetFINewCustomer", objp);
        //}


        public void GetFILossCustomer(int empid, DateTime fdate, DateTime tdate, int bid, string type, string tran, string mtype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fdate", SqlDbType.SmallDateTime , 8),
                                                       new SqlParameter("@tdate", SqlDbType.SmallDateTime , 8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) ,
                                                       new SqlParameter("@type", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@tran",SqlDbType.VarChar,2),
                                                       new SqlParameter("@mtype",SqlDbType.VarChar,1)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = bid;
            objp[4].Value = type;
            objp[5].Value = tran;
            objp[6].Value = mtype;

            if (tran == "FI")
            {
                ExecuteQuery("SPGetFILossCustomer", objp);
            }
            else if (tran == "FE")
            {
                ExecuteQuery("SPGetFELossCustomer", objp);
            }
            else if (tran == "AE")
            {
                ExecuteQuery("SPGetAELossCustomer", objp);
            }
            else if (tran == "AI")
            {
                ExecuteQuery("SPGetAILossCustomer", objp);
            }
            else if (tran == "AC")
            {
                ExecuteQuery("SPGetACLossCustomer", objp);
            }

        }

        public void GetFINewCustomer(int empid, DateTime fdate, DateTime tdate, int bid, string type, string trantype, string mtype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fdate", SqlDbType.SmallDateTime , 8),
                                                       new SqlParameter("@tdate", SqlDbType.SmallDateTime , 8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt, 1) ,
                                                       new SqlParameter("@type", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@tran",SqlDbType.VarChar,2),
                                                       new SqlParameter("@mtype",SqlDbType.VarChar,1)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = bid;
            objp[4].Value = type;
            objp[5].Value = trantype;
            objp[6].Value = mtype;

            if (trantype == "FI")
            {
                ExecuteQuery("SPGetFINewCustomer", objp);
            }
            else if (trantype == "FE")
            {
                ExecuteQuery("SPGetFENewCustomer", objp);
            }
            else if (trantype == "AE")
            {
                ExecuteQuery("SPGetAENewCustomer", objp);
            }
            else if (trantype == "AI")
            {
                ExecuteQuery("SPGetAINewCustomer", objp);
            }
            else if (trantype == "AC")
            {
                ExecuteQuery("SPGetACNewCustomer", objp);
            }
        }
        // get SCAC code


        public DataTable GetSCACCode2Custid(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetSCACCode2Custid", objp);
        }
        public DataTable GetOutstandforCustomer(int branchid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@customerid", SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = customerid;
            return ExecuteTable("SPAccGetOutstandforcustomer", objp);
        }

        public void InsMasterAirlineShortCode(string customername, string shortcode)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@shortcode", SqlDbType.VarChar,6)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = shortcode;
            ExecuteQuery("SPInsAirlineShortCode", objp);

        }
        public DataTable GetMASterAirlineShortCode(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                              
                                                        new SqlParameter("@customerid", SqlDbType.Int, 4)
                                                

                                                
                                                    };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetShortCodeFromAiLiner", objp);
        }
        public DataTable GetLikeCustomerForSales4Search(string customername, int empid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int),
                                                                                     new SqlParameter("@bid",SqlDbType.Int,4)};
            objp[0].Value = customername;
            objp[1].Value = empid;
            objp[2].Value = bid;
            return ExecuteTable("SPLikeCustomerforSales4search", objp);

        }
        public DataTable GetLikeCustomerproforma(string customername, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100),
           new SqlParameter("@cid", SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = cid;
            return ExecuteTable("SPLikeCustomer4proforma", objp);
        }

        //Bharathi
        public void InsMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, int landline, int mblisd, string mobile, int faxisd, string faxstd, int fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                       new SqlParameter("@llisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.Int),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.Int),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@createdby",SqlDbType.Int)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;

            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = managmail;
            objp[32].Value = managptc;
            objp[33].Value = tds;
            objp[34].Value = createdby;

            ExecuteQuery("SPInsMasterCustomerNew", objp);

        }
        public DataTable GetLocationDetails(string locationname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.VarChar, 50)
         };
            objp[0].Value = locationname; ;

            return ExecuteTable("SPSelDetails4Location", objp);
        }
        public DataTable GetLocationDetailsInt(int locatonid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.Int)
         };
            objp[0].Value = locatonid; ;

            return ExecuteTable("SPSelDetails4LocationInt", objp);
        }

        public DataTable GetCustomerName(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100)
         };
            objp[0].Value = customername;

            return ExecuteTable("SPSelCustomerName", objp);
        }


        public DataTable GetCustomerDetails(int customerid, string customertype, int locationid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int),
                                                        new SqlParameter("@customertype",SqlDbType.Char,1),
                                                        new SqlParameter("@location",SqlDbType.Int)
         };
            objp[0].Value = customerid;
            objp[1].Value = customertype;
            objp[2].Value = locationid;

            return ExecuteTable("SPSelCustomerDetailsNew", objp);
        }
        public void UpdMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, int landline, int mblisd, string mobile, int faxisd, string faxstd, int fax, string email, string panno, string stno)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                       new SqlParameter("@llisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.Int),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.Int),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;

            ExecuteQuery("SPUpdMasterCustomer", objp);

        }

        public DataTable GetCustomerDetails4Grid()
        {
            SqlParameter[] objp = new SqlParameter[] { 
         };

            return ExecuteTable("SPSelMasterCustomer4Grid");
        }
        public DataTable GetCustomerNameExist(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;

            return ExecuteTable("SPSelCustomerNameExist", objp);

        }
        public void DeleteCustomer(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customer", SqlDbType.Int) };
            objp[0].Value = customerid;

            ExecuteQuery("SPDelMasterCustomer", objp);
        }



        //Bhuvana

        public string GetCustomerAddress(int intcustid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = intcustid;


            return ExecuteReader("SPCustomeraddressCId", objp);
        }

        public DataTable GetLikeCustomerNameMail(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = custid;
            return ExecuteTable("SPCustomernamewithMail", objp);
        }
        //yuvaraja 
        //customer details for asp
        public DataTable GetCustDetailsasp(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetCustDetailsuv", objp);
        }

        //***********************************************Guru*********************************************

        public DataTable GetCustomeridNew(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;

            return ExecuteTable("SPCustomeridCName", objp);

        }

        //############################################uv###########################################
        public DataTable GetCustomerdetailswithid(int customerid, string Custtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.VarChar, 100),
                                        new SqlParameter ("@Custtype", SqlDbType.Char, 1)                        
            };
            objp[0].Value = customerid;
            objp[1].Value = Custtype;

            return ExecuteTable("SPLikeCustomertypewithID", objp);

        }

        //bharathi
        public DataTable GetLocationDetailsIntNEw(int locatonid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.Int)
         };
            objp[0].Value = locatonid;

            return ExecuteTable("SPSelDetails4LocationIntNew", objp);
        }
        public DataTable GETDetails4LocationIntNewPort(int locatonid, int cityport)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.Int),
               new SqlParameter("@city", SqlDbType.Int)
         };
            objp[0].Value = locatonid;
            objp[1].Value = cityport;

            return ExecuteTable("SPSelDetails4LocationIntNewPort", objp);
        }

        //july 03
        public void UpdPortFromCustomer(int district, int stateid, string stdcode, int portid)
        {

            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@district", SqlDbType.Int ),
                                                       new SqlParameter("@stateid", SqlDbType.Int),
                                                       new SqlParameter("@stdcode", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@portid",SqlDbType.Int)
           };
            objp[0].Value = district;
            objp[1].Value = stateid;
            objp[2].Value = stdcode;
            objp[3].Value = portid;

            ExecuteQuery("SPUpdPortFromCustomer", objp);
        }
        //Raj
        public void UpdMasterCustomerNew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, int landline, int mblisd, string mobile, int faxisd, string faxstd, int fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                       new SqlParameter("@llisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.Int),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.Int),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int)                                                       
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;


            ExecuteQuery("SPUpdMasterCustomer", objp);

        }


        public DataTable SPSelGetCustomerDetails(string customername, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 200),
           new SqlParameter("@customerid", SqlDbType.Int )
           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };
            objp[0].Value = customername;
            objp[1].Value = customerid;
            //objp[2].Value = type;
            return ExecuteTable("SPSelGetCustomerDetails", objp);

        }
        //


        public string GetLocationname(int LocationId)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.Int) };
            objp[0].Value = LocationId;
            return ExecuteReader("SPSelGetLoctionNameId", objp);
        }


        public DataTable GetAllDetailsForCustomer(string customername, int customerid, char type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100),
           new SqlParameter("@customerid", SqlDbType.Int ),
           new SqlParameter("@type", SqlDbType.Char ,1 )};
            objp[0].Value = customername;
            objp[1].Value = customerid;
            objp[2].Value = type;
            return ExecuteTable("SPSelGetAllDetailsForCustomer", objp);

        }
        /////bharathi
        public string GetStatename(int StateId)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateid", SqlDbType.Int) };
            objp[0].Value = StateId;
            return ExecuteReader("SPSelGetStateNameId", objp);
        }


        public string GetStateDistrictname(int DistrictId)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtid", SqlDbType.Int) };
            objp[0].Value = DistrictId;
            return ExecuteReader("SPSelGetDistrictNameId", objp);
        }
        public DataTable GetLikeCustomerForAddress(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPLikeCustomertypeWithAddress", objp);

        }
        //bharathi
        public DataTable SPLikeCustomerDetailAll(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int) };
            objp[0].Value = custid;

            return ExecuteTable("SPLikeCustomerDetailAll", objp);
        }

        // change
        //@panreq varchar(1),@customerid int 
        public void UpdPAnno(int customerid, string panreq)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@customerid",SqlDbType.Int),
                                                new SqlParameter("@panreq",SqlDbType.VarChar,1)
                                              };
            objp[0].Value = customerid;
            objp[1].Value = panreq;


            ExecuteQuery("SPupdCustomerDetails4panno", objp);
        }
        //@customerid
        public DataTable GetAllCustDetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = customerid;

            return ExecuteTable("SPSelGetAllCustDetails", objp);
        }


        public DataTable GetLikeCustomerForSalesnew(string customername, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = empid;
            return ExecuteTable("SPLikeCustomerforSalesNew", objp);

        }

        public int GetMccidNew(int cusid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custid",SqlDbType.Int)
                                                                                     };
            objp[0].Value = cusid;
            //return ExecuteTable("SPGetMccid", objp);
            return int.Parse(ExecuteReader("SPGetMccid", objp));

        }

        // -------Rajaguru-----***************//
        //--------------------------------SOP--------------------------------------------


        public DataTable GetLikeCustomersop(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikesopCustomer", objp);
        }


        public void inssop(int customerid, string sop, string status)
        {
            SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@customerid", SqlDbType.Int),
           new SqlParameter("@sop", SqlDbType.VarChar) ,
           new SqlParameter("@status", SqlDbType.Char) };
            objp[0].Value = customerid;
            objp[1].Value = sop;
            objp[2].Value = status;
            ExecuteQuery("SPInsSOP", objp);
        }

        public DataTable Getsop(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            return ExecuteTable("spgetsop", objp);
        }


        public void Delsop(int customerid, string sop, string status)
        {
            SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@customerid", SqlDbType.Int),
           new SqlParameter("@sop", SqlDbType.VarChar) ,
           new SqlParameter("@status", SqlDbType.Char) };
            objp[0].Value = customerid;
            objp[1].Value = sop;
            objp[2].Value = status;
            ExecuteQuery("SPDelSOP", objp);
        }

        //---------------
        public DataTable Getsopnew(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar) };
            objp[0].Value = customername;
            return ExecuteTable("spgetsopnew", objp);
        }

        public DataTable GetLikeCustsop(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikesopCust", objp);
        }


        public void insertsop(int customerid, string sop, string status, string customername)
        {
            SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@customerid", SqlDbType.Int),
           new SqlParameter("@sop", SqlDbType.VarChar) ,
           new SqlParameter("@status", SqlDbType.Char) ,
             new SqlParameter("@customername", SqlDbType.VarChar)};
            objp[0].Value = customerid;
            objp[1].Value = sop;
            objp[2].Value = status;
            objp[3].Value = customername;
            ExecuteQuery("SPInsertSOP", objp);
        }

        public DataTable GetCustid4msop(string status, string sop, string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sop", SqlDbType.VarChar) ,
           new SqlParameter("@status", SqlDbType.Char) ,
             new SqlParameter("@customername", SqlDbType.VarChar)};

            objp[0].Value = sop;
            objp[1].Value = status;
            objp[2].Value = customername;
            return ExecuteTable("SPgetsopcustid", objp);
        }


        public DataTable GetCustid4msopNewweb(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { 
             new SqlParameter("@txtCustomer", SqlDbType.VarChar,100)};

            objp[0].Value = customername;
            return ExecuteTable("SPLikesopCustpoerNew", objp);
        }

        //For KYC Customer Proof

        public DataTable SPSelKYCProof(string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Char, 5) };
            objp[0].Value = type;
            return ExecuteTable("spselallproof", objp);
        }

        public void inskycproofcustomer(int customerid, int id, string idfilename, int add, string addfilename, string ieccode, int updatedby)
        {
            SqlParameter[] objp = new SqlParameter[] {
                       new SqlParameter("@cid", SqlDbType.Int),
                       new SqlParameter("@id", SqlDbType.Int),
                       new SqlParameter("@idfile", SqlDbType.VarChar,400) ,
                       new SqlParameter("@add", SqlDbType.Int),
                       new SqlParameter("@addfile", SqlDbType.VarChar,400) ,
                       //new SqlParameter("@iec", SqlDbType.Int),
                       new SqlParameter("@ieccode", SqlDbType.VarChar,400),
          new SqlParameter("@updatedby", SqlDbType.Int)};
            objp[0].Value = customerid;
            objp[1].Value = id;
            objp[2].Value = idfilename;
            objp[3].Value = add;
            objp[4].Value = addfilename;
            //objp[5].Value = iec;
            objp[5].Value = ieccode;
            objp[6].Value = updatedby;
            ExecuteQuery("spinskycproof4cus", objp);
        }
        //Approved KYC4 Customer      
        public DataTable FillDt4ProKYC()
        {
            return ExecuteTable("SPGetUnapproveKYC");
        }

        //Update the Kyc Approved By

        public void Updkyc4Proof(int customerid, int Verifiedby)
        {
            SqlParameter[] objp = new SqlParameter[] {
                       new SqlParameter("@cid", SqlDbType.Int),
                       
          new SqlParameter("@verifiedby", SqlDbType.Int)};
            objp[0].Value = customerid;

            objp[1].Value = Verifiedby;
            ExecuteQuery("SPUpdUnapproveKYC", objp);
        }

        public int Getcustidfromledger(int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4) };

            objp[0].Value = ledgerid;

            return int.Parse(ExecuteReader("SPGetcustidfromledger", objp));
        }

        //prabha
        public DataTable SelledgeridinHead4RPLedger(int ledgerid, int divisionid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@ledgerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                    };
            objp[0].Value = ledgerid;
            objp[1].Value = divisionid;
            objp[2].Value = dbname;

            return ExecuteTable("SPSelledgeridinHead4RPLedger", objp);
        }

        //Arun
        /*   public void SPInsMasterCustomerNew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string ptc)
           {
               //  char ctype = CheckCustomerType(customertype);
               SqlParameter[] objp = new SqlParameter[] { 
            
                                                          new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                          new SqlParameter("@customertype", SqlDbType.Char,1),
                                                          new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                          new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                          new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                          new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                          new SqlParameter ("@location",SqlDbType.Int),
                                                          new SqlParameter ("@city",SqlDbType.Int),
                                                          new SqlParameter("@district",SqlDbType.Int),
                                                          new SqlParameter("@state",SqlDbType.Int),
                                                          new SqlParameter("@country",SqlDbType.Int),
                                                          new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                          new SqlParameter("@llisd",SqlDbType.Int),
                                                          new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                          new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                          new SqlParameter("@mblisd",SqlDbType.Int),
                                                          new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                          new SqlParameter("@faxisd",SqlDbType.Int),
                                                          new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                          new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                          new SqlParameter("@email",SqlDbType.VarChar,100),
                                                          new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                          new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                         // new SqlParameter("@status",SqlDbType.Char ,1),
                                                          new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                           new SqlParameter("@createdby",SqlDbType.Int ),
                                                                new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                     new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                     new SqlParameter("@tds",SqlDbType.Int)};
               objp[0].Value = customername;
               objp[1].Value = customertype;
               objp[2].Value = unit;
               objp[3].Value = buildingname;
               objp[4].Value = door;
               objp[5].Value = street;
               objp[6].Value = locationid;
               objp[7].Value = cityid;
               objp[8].Value = districtid;
               objp[9].Value = stateid;
               objp[10].Value = countryid;
               objp[11].Value = pincode;
               objp[12].Value = llisd;
               objp[13].Value = llstd;
               objp[14].Value = landline;
               objp[15].Value = mblisd;
               objp[16].Value = mobile;
               objp[17].Value = faxisd;
               objp[18].Value = faxstd;
               objp[19].Value = fax;
               objp[20].Value = email;
               objp[21].Value = panno;
               objp[22].Value = stno;
               // objp[23].Value = status;
               objp[23].Value = commailid;
               objp[24].Value = expmailid;
               objp[25].Value = impmailid;
               objp[26].Value = finmailid;
               objp[27].Value = comptc;
               objp[28].Value = expptc;
               objp[29].Value = impptc;
               objp[30].Value = finptc;
               objp[31].Value = createdby;
               objp[32].Value = managmail;
               objp[33].Value = managptc;
               objp[34].Value = tds;


               ExecuteQuery("SPInsMasterCustomerNew", objp);

           }
           */

        /*public void SPUpdMasterCustomerNewDesign(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int )
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            ExecuteQuery("SPUpdMasterCustomerNewDesign", objp);

        }*/
        //Arun
        public DataTable SpCustName(int city, char custype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@city", SqlDbType.Int),
                                                      new SqlParameter("@custype", SqlDbType.Char)
                                                     
                                                    };
            objp[0].Value = city;
            objp[1].Value = custype;


            return ExecuteTable("SPCity", objp);
        }



        public DataTable GetLikeIndianCustomer4Corp(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeIndianCustomer4Corp", objp);
        }
        //Arun
        public DataTable SpCustAddress(string customername, int city, char custype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                     
                                                      new SqlParameter("@customername", SqlDbType.VarChar,100)  ,
                                                       new SqlParameter("@city", SqlDbType.Int),
                                                        new SqlParameter("@custype", SqlDbType.Char)
                                                    };
            objp[0].Value = customername;
            objp[1].Value = city;
            objp[2].Value = custype;



            return ExecuteTable("SPCustnameNew", objp);
        }

        //RajaGuru
        public DataTable GetLikeCustomer4Carrier(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomer4Carrier", objp);
        }
        //raj
        public DataTable GetexactCustomer(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                        new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPexactCustomertype", objp);

        }

        //raj
        public DataTable GetexactCustomer(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPexactCustomer", objp);
        }
        //Dinesh
        public DataTable GetexactCustomerForSales(string customername, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = empid;
            return ExecuteTable("SPexactCustomerforSales", objp);

        }
        //RajaGuru

        public DataTable GetExactCustomer4Carrier(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomer4Carrier", objp);
        }


        //Raj

        public DataTable GetexactCustomerForSalesnew(string customername, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                        new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = empid;
            return ExecuteTable("SPexactCustomerforSalesNew", objp);

        }

        //Raj


        public DataTable GetexactCustomer4Inbound(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,50),
                            new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPexactCustomertypeAgent", objp);
        }

        //Raj
        public DataTable GetexactIndianCustomer(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPexactIndianCustomer", objp);
        }
        //Raj
        public DataTable Get_customerdetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            return ExecuteTable("sp_getcustomerdetails", objp);
        }


        //MUTHU
        //public void SPUpdMasterCustomerNewDesign(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno)
        //{
        //    // char ctype = CheckCustomerType(customertype);
        //    SqlParameter[] objp = new SqlParameter[] { 

        //                                                new SqlParameter("@customername", SqlDbType.VarChar, 100),
        //                                               new SqlParameter("@customertype", SqlDbType.Char,1),
        //                                               new SqlParameter("@unit#", SqlDbType.VarChar,10),
        //                                               new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
        //                                               new SqlParameter ("@door#",SqlDbType.VarChar,10),
        //                                               new SqlParameter ("@street",SqlDbType.VarChar,100),
        //                                               new SqlParameter ("@location",SqlDbType.Int),
        //                                               new SqlParameter ("@city",SqlDbType.Int),
        //                                               new SqlParameter("@district",SqlDbType.Int),
        //                                               new SqlParameter("@state",SqlDbType.Int),
        //                                               new SqlParameter("@country",SqlDbType.Int),
        //                                               new SqlParameter("@pincode",SqlDbType.VarChar,15),
        //                                               new SqlParameter("@llisd",SqlDbType.Int),
        //                                               new SqlParameter("@llstd",SqlDbType.VarChar,10),
        //                                               new SqlParameter("@landline",SqlDbType.VarChar,25),
        //                                               new SqlParameter("@mblisd",SqlDbType.Int),
        //                                               new SqlParameter("@mobile",SqlDbType.VarChar,10),
        //                                               new SqlParameter("@faxisd",SqlDbType.Int),
        //                                               new SqlParameter("@faxstd",SqlDbType.VarChar,10),
        //                                               new SqlParameter("@fax",SqlDbType.VarChar,25),
        //                                               new SqlParameter("@email",SqlDbType.VarChar,100),
        //                                               new SqlParameter("@panno",SqlDbType.VarChar,25),
        //                                               new SqlParameter("@stno",SqlDbType.VarChar,25),
        //                                             //  new SqlParameter("@status",SqlDbType.Char ,1),
        //                                               new SqlParameter("@commailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@expmailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@impmailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@finmailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@comptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@expptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@impptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@finptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@customerid",SqlDbType.Int),
        //                                                new SqlParameter("@managmail",SqlDbType.VarChar,50),
        //                                                          new SqlParameter("@managptc",SqlDbType.VarChar,50),
        //                                                          new SqlParameter("@tds",SqlDbType.Int ),
        //                                                          new SqlParameter("@gstin",SqlDbType.VarChar,20),
        //                                                          new SqlParameter("@uinno",SqlDbType.VarChar,20),
        //                                               };
        //    objp[0].Value = customername;
        //    objp[1].Value = customertype;
        //    objp[2].Value = unit;
        //    objp[3].Value = buildingname;
        //    objp[4].Value = door;
        //    objp[5].Value = street;
        //    objp[6].Value = locationid;
        //    objp[7].Value = cityid;
        //    objp[8].Value = districtid;
        //    objp[9].Value = stateid;
        //    objp[10].Value = countryid;
        //    objp[11].Value = pincode;
        //    objp[12].Value = llisd;
        //    objp[13].Value = llstd;
        //    objp[14].Value = landline;
        //    objp[15].Value = mblisd;
        //    objp[16].Value = mobile;
        //    objp[17].Value = faxisd;
        //    objp[18].Value = faxstd;
        //    objp[19].Value = fax;
        //    objp[20].Value = email;
        //    objp[21].Value = panno;
        //    objp[22].Value = stno;
        //    // objp[23].Value = status;
        //    objp[23].Value = commailid;
        //    objp[24].Value = expmailid;
        //    objp[25].Value = impmailid;
        //    objp[26].Value = finmailid;
        //    objp[27].Value = comptc;
        //    objp[28].Value = expptc;
        //    objp[29].Value = impptc;
        //    objp[30].Value = finptc;
        //    objp[31].Value = customerid;
        //    objp[32].Value = managmail;
        //    objp[33].Value = managptc;
        //    objp[34].Value = tds;
        //    objp[35].Value = gstin;
        //    objp[36].Value = uinno;
        //    ExecuteQuery("SPUpdMasterCustomerNewDesign", objp);

        //}


        //public void SPInsMasterCustomerNew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc)
        //{
        //    //  char ctype = CheckCustomerType(customertype);
        //    SqlParameter[] objp = new SqlParameter[] { 

        //                                               new SqlParameter("@customername", SqlDbType.VarChar, 100),
        //                                               new SqlParameter("@customertype", SqlDbType.Char,1),
        //                                               new SqlParameter("@unit#", SqlDbType.VarChar,10),
        //                                               new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
        //                                               new SqlParameter ("@door#",SqlDbType.VarChar,10),
        //                                               new SqlParameter ("@street",SqlDbType.VarChar,100),
        //                                               new SqlParameter ("@location",SqlDbType.Int),
        //                                               new SqlParameter ("@city",SqlDbType.Int),
        //                                               new SqlParameter("@district",SqlDbType.Int),
        //                                               new SqlParameter("@state",SqlDbType.Int),
        //                                               new SqlParameter("@country",SqlDbType.Int),
        //                                               new SqlParameter("@pincode",SqlDbType.VarChar,15),
        //                                               new SqlParameter("@llisd",SqlDbType.Int),
        //                                               new SqlParameter("@llstd",SqlDbType.VarChar,10),
        //                                               new SqlParameter("@landline",SqlDbType.VarChar,25),
        //                                               new SqlParameter("@mblisd",SqlDbType.Int),
        //                                               new SqlParameter("@mobile",SqlDbType.VarChar,10),
        //                                               new SqlParameter("@faxisd",SqlDbType.Int),
        //                                               new SqlParameter("@faxstd",SqlDbType.VarChar,10),
        //                                               new SqlParameter("@fax",SqlDbType.VarChar,25),
        //                                               new SqlParameter("@email",SqlDbType.VarChar,100),
        //                                               new SqlParameter("@pan",SqlDbType.VarChar,25),
        //                                               new SqlParameter("@stno",SqlDbType.VarChar,25),
        //                                              // new SqlParameter("@status",SqlDbType.Char ,1),
        //                                               new SqlParameter("@commailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@expmailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@impmailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@finmailid",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@comptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@expptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@impptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@finptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@createdby",SqlDbType.Int ),
        //                                               new SqlParameter("@managmail",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@managptc",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@tds",SqlDbType.Int),
        //                                               new SqlParameter("@gstin",SqlDbType.VarChar,20),
        //                                               new SqlParameter("@uinno",SqlDbType.VarChar,20)
        //    };
        //    objp[0].Value = customername;
        //    objp[1].Value = customertype;
        //    objp[2].Value = unit;
        //    objp[3].Value = buildingname;
        //    objp[4].Value = door;
        //    objp[5].Value = street;
        //    objp[6].Value = locationid;
        //    objp[7].Value = cityid;
        //    objp[8].Value = districtid;
        //    objp[9].Value = stateid;
        //    objp[10].Value = countryid;
        //    objp[11].Value = pincode;
        //    objp[12].Value = llisd;
        //    objp[13].Value = llstd;
        //    objp[14].Value = landline;
        //    objp[15].Value = mblisd;
        //    objp[16].Value = mobile;
        //    objp[17].Value = faxisd;
        //    objp[18].Value = faxstd;
        //    objp[19].Value = fax;
        //    objp[20].Value = email;
        //    objp[21].Value = panno;
        //    objp[22].Value = stno;
        //    // objp[23].Value = status;
        //    objp[23].Value = commailid;
        //    objp[24].Value = expmailid;
        //    objp[25].Value = impmailid;
        //    objp[26].Value = finmailid;
        //    objp[27].Value = comptc;
        //    objp[28].Value = expptc;
        //    objp[29].Value = impptc;
        //    objp[30].Value = finptc;
        //    objp[31].Value = createdby;
        //    objp[32].Value = managmail;
        //    objp[33].Value = managptc;
        //    objp[34].Value = tds;
        //    objp[35].Value = gstin;
        //    objp[36].Value = uinno;


        //    ExecuteQuery("SPInsMasterCustomerNew", objp);

        //}

        /*    //MUTHU
            public void SPInsMasterCustomerNew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered)
            {
                //  char ctype = CheckCustomerType(customertype);
                SqlParameter[] objp = new SqlParameter[] { 
            
                                                           new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                           new SqlParameter("@customertype", SqlDbType.Char,1),
                                                           new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                           new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                           new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                           new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                           new SqlParameter ("@location",SqlDbType.Int),
                                                           new SqlParameter ("@city",SqlDbType.Int),
                                                           new SqlParameter("@district",SqlDbType.Int),
                                                           new SqlParameter("@state",SqlDbType.Int),
                                                           new SqlParameter("@country",SqlDbType.Int),
                                                           new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                           new SqlParameter("@llisd",SqlDbType.Int),
                                                           new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                           new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                           new SqlParameter("@mblisd",SqlDbType.Int),
                                                           new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                           new SqlParameter("@faxisd",SqlDbType.Int),
                                                           new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                           new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                           new SqlParameter("@email",SqlDbType.VarChar,100),
                                                           new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                           new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                          // new SqlParameter("@status",SqlDbType.Char ,1),
                                                           new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                           new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                           new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                           new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                           new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                           new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                           new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                           new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                           new SqlParameter("@createdby",SqlDbType.Int ),
                                                           new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                           new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                           new SqlParameter("@tds",SqlDbType.Int),
                                                           new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                           new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                           new SqlParameter("@RCM",SqlDbType.Char,1),
                                                           new SqlParameter("@UnRegistered",SqlDbType.Char,1)
                };
                objp[0].Value = customername;
                objp[1].Value = customertype;
                objp[2].Value = unit;
                objp[3].Value = buildingname;
                objp[4].Value = door;
                objp[5].Value = street;
                objp[6].Value = locationid;
                objp[7].Value = cityid;
                objp[8].Value = districtid;
                objp[9].Value = stateid;
                objp[10].Value = countryid;
                objp[11].Value = pincode;
                objp[12].Value = llisd;
                objp[13].Value = llstd;
                objp[14].Value = landline;
                objp[15].Value = mblisd;
                objp[16].Value = mobile;
                objp[17].Value = faxisd;
                objp[18].Value = faxstd;
                objp[19].Value = fax;
                objp[20].Value = email;
                objp[21].Value = panno;
                objp[22].Value = stno;
                // objp[23].Value = status;
                objp[23].Value = commailid;
                objp[24].Value = expmailid;
                objp[25].Value = impmailid;
                objp[26].Value = finmailid;
                objp[27].Value = comptc;
                objp[28].Value = expptc;
                objp[29].Value = impptc;
                objp[30].Value = finptc;
                objp[31].Value = createdby;
                objp[32].Value = managmail;
                objp[33].Value = managptc;
                objp[34].Value = tds;
                objp[35].Value = gstin;
                objp[36].Value = uinno;
                objp[37].Value = RCM;
                objp[38].Value = Unregistered;


                ExecuteQuery("SPInsMasterCustomerNew", objp);

            }
            */


        //ARUN

        public void SPInsMasterCustomerNew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                         new SqlParameter("@Sez",SqlDbType.Char,1),
                                                         new SqlParameter("@Register",SqlDbType.Char,1)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            ExecuteQuery("SPInsMasterCustomerNew", objp);

        }



        //Dinesh

        /*   public void SPInsMasterCustomerNew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp)
           {
               //  char ctype = CheckCustomerType(customertype);
               SqlParameter[] objp = new SqlParameter[] { 
            
                                                          new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                          new SqlParameter("@customertype", SqlDbType.Char,1),
                                                          new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                          new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                          new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                          new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                          new SqlParameter ("@location",SqlDbType.Int),
                                                          new SqlParameter ("@city",SqlDbType.Int),
                                                          new SqlParameter("@district",SqlDbType.Int),
                                                          new SqlParameter("@state",SqlDbType.Int),
                                                          new SqlParameter("@country",SqlDbType.Int),
                                                          new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                          new SqlParameter("@llisd",SqlDbType.Int),
                                                          new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                          new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                          new SqlParameter("@mblisd",SqlDbType.Int),
                                                          new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                          new SqlParameter("@faxisd",SqlDbType.Int),
                                                          new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                          new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                          new SqlParameter("@email",SqlDbType.VarChar,100),
                                                          new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                          new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                         // new SqlParameter("@status",SqlDbType.Char ,1),
                                                          new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@createdby",SqlDbType.Int ),
                                                          new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                          new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@tds",SqlDbType.Int),
                                                          new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                          new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                          new SqlParameter("@RCM",SqlDbType.Char,1),
                                                          new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                           new SqlParameter("@gstexemption",SqlDbType.Char,1)
               };
               objp[0].Value = customername;
               objp[1].Value = customertype;
               objp[2].Value = unit;
               objp[3].Value = buildingname;
               objp[4].Value = door;
               objp[5].Value = street;
               objp[6].Value = locationid;
               objp[7].Value = cityid;
               objp[8].Value = districtid;
               objp[9].Value = stateid;
               objp[10].Value = countryid;
               objp[11].Value = pincode;
               objp[12].Value = llisd;
               objp[13].Value = llstd;
               objp[14].Value = landline;
               objp[15].Value = mblisd;
               objp[16].Value = mobile;
               objp[17].Value = faxisd;
               objp[18].Value = faxstd;
               objp[19].Value = fax;
               objp[20].Value = email;
               objp[21].Value = panno;
               objp[22].Value = stno;
               // objp[23].Value = status;
               objp[23].Value = commailid;
               objp[24].Value = expmailid;
               objp[25].Value = impmailid;
               objp[26].Value = finmailid;
               objp[27].Value = comptc;
               objp[28].Value = expptc;
               objp[29].Value = impptc;
               objp[30].Value = finptc;
               objp[31].Value = createdby;
               objp[32].Value = managmail;
               objp[33].Value = managptc;
               objp[34].Value = tds;
               objp[35].Value = gstin;
               objp[36].Value = uinno;
               objp[37].Value = RCM;
               objp[38].Value = Unregistered;
               objp[39].Value = gstexemp;

               ExecuteQuery("SPInsMasterCustomerNew", objp);

           }
   */




        /*   public void SPUpdMasterCustomerNewDesign(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered)
           {
               // char ctype = CheckCustomerType(customertype);
               SqlParameter[] objp = new SqlParameter[] { 
            
                                                           new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                          new SqlParameter("@customertype", SqlDbType.Char,1),
                                                          new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                          new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                          new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                          new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                          new SqlParameter ("@location",SqlDbType.Int),
                                                          new SqlParameter ("@city",SqlDbType.Int),
                                                          new SqlParameter("@district",SqlDbType.Int),
                                                          new SqlParameter("@state",SqlDbType.Int),
                                                          new SqlParameter("@country",SqlDbType.Int),
                                                          new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                          new SqlParameter("@llisd",SqlDbType.Int),
                                                          new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                          new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                          new SqlParameter("@mblisd",SqlDbType.Int),
                                                          new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                          new SqlParameter("@faxisd",SqlDbType.Int),
                                                          new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                          new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                          new SqlParameter("@email",SqlDbType.VarChar,100),
                                                          new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                          new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                        //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                          new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                          new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                          new SqlParameter("@customerid",SqlDbType.Int),
                                                           new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                     new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                     new SqlParameter("@tds",SqlDbType.Int ),
                                                                     new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                     new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                     new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                     new SqlParameter("@UnRegistered ",SqlDbType.Char,1)

                                                          };
               objp[0].Value = customername;
               objp[1].Value = customertype;
               objp[2].Value = unit;
               objp[3].Value = buildingname;
               objp[4].Value = door;
               objp[5].Value = street;
               objp[6].Value = locationid;
               objp[7].Value = cityid;
               objp[8].Value = districtid;
               objp[9].Value = stateid;
               objp[10].Value = countryid;
               objp[11].Value = pincode;
               objp[12].Value = llisd;
               objp[13].Value = llstd;
               objp[14].Value = landline;
               objp[15].Value = mblisd;
               objp[16].Value = mobile;
               objp[17].Value = faxisd;
               objp[18].Value = faxstd;
               objp[19].Value = fax;
               objp[20].Value = email;
               objp[21].Value = panno;
               objp[22].Value = stno;
               // objp[23].Value = status;
               objp[23].Value = commailid;
               objp[24].Value = expmailid;
               objp[25].Value = impmailid;
               objp[26].Value = finmailid;
               objp[27].Value = comptc;
               objp[28].Value = expptc;
               objp[29].Value = impptc;
               objp[30].Value = finptc;
               objp[31].Value = customerid;
               objp[32].Value = managmail;
               objp[33].Value = managptc;
               objp[34].Value = tds;
               objp[35].Value = gstin;
               objp[36].Value = uinno;
               objp[37].Value = RCM;
               objp[38].Value = Unregistered;
               ExecuteQuery("SPUpdMasterCustomerNewDesign", objp);

           }
           */
        public void SPUpdMasterCustomerNewDesign(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp, string sez, string Register)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                                   new SqlParameter("@Sez",SqlDbType.Char,1),
                                                                     new SqlParameter("@Register",SqlDbType.Char,1)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;

            ExecuteQuery("SPUpdMasterCustomerNewDesign", objp);

        }


        /*  public void SPUpdMasterCustomerNewDesign(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp)
          {
              // char ctype = CheckCustomerType(customertype);
              SqlParameter[] objp = new SqlParameter[] { 
            
                                                          new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                         new SqlParameter("@customertype", SqlDbType.Char,1),
                                                         new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                         new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                         new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                         new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                         new SqlParameter ("@location",SqlDbType.Int),
                                                         new SqlParameter ("@city",SqlDbType.Int),
                                                         new SqlParameter("@district",SqlDbType.Int),
                                                         new SqlParameter("@state",SqlDbType.Int),
                                                         new SqlParameter("@country",SqlDbType.Int),
                                                         new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                         new SqlParameter("@llisd",SqlDbType.Int),
                                                         new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                         new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                         new SqlParameter("@mblisd",SqlDbType.Int),
                                                         new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                         new SqlParameter("@faxisd",SqlDbType.Int),
                                                         new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                         new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                         new SqlParameter("@email",SqlDbType.VarChar,100),
                                                         new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                         new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                       //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                         new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                         new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                         new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                         new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                         new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                         new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                         new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                         new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                         new SqlParameter("@customerid",SqlDbType.Int),
                                                          new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                    new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                    new SqlParameter("@tds",SqlDbType.Int ),
                                                                    new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                    new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                    new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                    new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                    new SqlParameter("@gstexemption",SqlDbType.Char,1)

                                                         };
              objp[0].Value = customername;
              objp[1].Value = customertype;
              objp[2].Value = unit;
              objp[3].Value = buildingname;
              objp[4].Value = door;
              objp[5].Value = street;
              objp[6].Value = locationid;
              objp[7].Value = cityid;
              objp[8].Value = districtid;
              objp[9].Value = stateid;
              objp[10].Value = countryid;
              objp[11].Value = pincode;
              objp[12].Value = llisd;
              objp[13].Value = llstd;
              objp[14].Value = landline;
              objp[15].Value = mblisd;
              objp[16].Value = mobile;
              objp[17].Value = faxisd;
              objp[18].Value = faxstd;
              objp[19].Value = fax;
              objp[20].Value = email;
              objp[21].Value = panno;
              objp[22].Value = stno;
              // objp[23].Value = status;
              objp[23].Value = commailid;
              objp[24].Value = expmailid;
              objp[25].Value = impmailid;
              objp[26].Value = finmailid;
              objp[27].Value = comptc;
              objp[28].Value = expptc;
              objp[29].Value = impptc;
              objp[30].Value = finptc;
              objp[31].Value = customerid;
              objp[32].Value = managmail;
              objp[33].Value = managptc;
              objp[34].Value = tds;
              objp[35].Value = gstin;
              objp[36].Value = uinno;
              objp[37].Value = RCM;
              objp[38].Value = Unregistered;
              objp[39].Value = gstexemp;

              ExecuteQuery("SPUpdMasterCustomerNewDesign", objp);

          }
          */


        public DataTable SPSelGetCustomerDetailsGSTIN(string customername, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100),
           new SqlParameter("@customerid", SqlDbType.Int )
           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };
            objp[0].Value = customername;
            objp[1].Value = customerid;
            //objp[2].Value = type;
            return ExecuteTable("SPSelGetCustomerDetailsGSTIN", objp);

        }


        //GST

        //Dinesh

        public DataTable GetIndianCustomergstadd(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@Custid", SqlDbType.VarChar, 100)
            };
            objp[0].Value = customerid;
            return ExecuteTable("Sp_getIndiancustomerGSTadd", objp);
        }


        public DataTable GetIndianCustomergst(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@Custid", SqlDbType.VarChar, 100)
            };
            objp[0].Value = customerid;
            return ExecuteTable("Sp_getIndiancustomerGST", objp);
        }




        //Dinesh

        public void Insertupdloggst(int customerid, string eventdocs, int updatedby, DateTime updatedon)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@eventdocs",SqlDbType.NVarChar,5000),        
                                                      new SqlParameter("@updatedby",SqlDbType.Int, 4), 
                                                      new SqlParameter("@updatedon",SqlDbType.SmallDateTime , 8)
                                                   
                                                     }
                                                     ;

            objp[0].Value = customerid;
            objp[1].Value = eventdocs;
            objp[2].Value = updatedby;
            objp[3].Value = updatedon;

            ExecuteQuery("updloggst", objp);
        }


        //FA  

        public DataTable Getinvcountfrmcusid(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@customerid", SqlDbType.Int,7)};

            objp[0].Value = customerid;
            return ExecuteTable("SPGetinvcountfrmcusid", objp);
        }

        public DataTable getdescr4proinvrpt(int refno, int vouyear, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@refno",SqlDbType.Int),
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.Int)
                
            };
            objp[0].Value = refno;
            objp[1].Value = vouyear;
            objp[2].Value = bid;

            return ExecuteTable("getdescr4proinvrpt", objp);
        }

        public DataTable getdescr4invrpt(int invoiceno, int vouyear, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@invoiceno",SqlDbType.Int),
                new SqlParameter("@vouyear",SqlDbType.Int),
                new SqlParameter("@bid",SqlDbType.Int)
                
            };
            objp[0].Value = invoiceno;
            objp[1].Value = vouyear;
            objp[2].Value = bid;

            return ExecuteTable("getdescr4invrpt", objp);
        }

        public DataTable ledgercustomer(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] 
           { 
               new SqlParameter("@custid", SqlDbType.Int) 
           };

            objp[0].Value = custid;
            return ExecuteTable("SPGetledgerid4mcustid", objp);
        }

        public DataTable GetCustomerForProfile(int intCustID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = intCustID;
            return ExecuteTable("SPGetCustomerPf", objp);
        }

        public DataTable GetSubGroupForProfile(int intCustID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = intCustID;
            return ExecuteTable("SPGETSubGroupforCP", objp);
        }


        public DataTable Getbusinessplan()
        {
            SqlParameter[] objp = new SqlParameter[] { };

            return ExecuteTable("SPgetbusinessplan", objp);
        }

        public DataTable GetLikePlanname(string planname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Planname", SqlDbType.VarChar, 100) };
            objp[0].Value = planname;
            return ExecuteTable("SPLikebusinessplan", objp);
        }

        public DataTable GetLikeCustomerAll4Grd(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerAll4grd", objp);
        }

        public DataTable SPSelLikeLocationWithCity(string locationname, int city)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.VarChar, 100),
           new SqlParameter("@cityport", SqlDbType.Int )};
            objp[0].Value = locationname;
            objp[1].Value = city;

            return ExecuteTable("SPSelLikeLocationWithCity", objp);
        }

        public DataTable GetlocationnameNEWLocation(string locationname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationname", SqlDbType.VarChar, 40) };
            objp[0].Value = locationname;
            return ExecuteTable("SPSellocationnameNEWLocation", objp);
        }

        public DataTable GetLikePlan(string planname)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@Planname",SqlDbType.VarChar)
                           };
            objp[0].Value = planname;

            return ExecuteTable("SPGetLikePlan", objp);
        }
        public DataTable GetLikeCurrency(string currency)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr", SqlDbType.VarChar, 3) };
            objp[0].Value = currency;
            return ExecuteTable("SPLikeCurr", objp);
        }

        public DataTable GetlocationnameNEWpincode(string PINCode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode", SqlDbType.VarChar, 6) };
            objp[0].Value = PINCode;
            return ExecuteTable("SPSellocationnameNEWpincode", objp);
        }

        public DataTable getREQMasterCustomer()
        {
            SqlParameter[] objp = new SqlParameter[]
            {

            };
            return ExecuteTable("SPGetREQMasterCustomer", objp);
        }

        public DataTable CheckDuplicateForLocationPincode(string Locationname, string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Locationname", SqlDbType.VarChar, 30) ,
          new SqlParameter("@pincode", SqlDbType.VarChar, 6)};
            objp[0].Value = Locationname;
            objp[1].Value = pincode;
            return ExecuteTable("SPChechDuplicate4Locationwithpincode", objp);
        }

        public int Getledgeridfromcustid(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };

            objp[0].Value = custid;

            return int.Parse(ExecuteReader("SPGetledgeridfromcustid", objp));
        }

        public DataTable sp_getcuntryid(int statename)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@StateName", SqlDbType.Int)
            };

            objp[0].Value = statename;

            return ExecuteTable("sp_getcuntryid", objp);
        }


        //Rajbharath
        public int SPInsMasterCustomerNew1(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                        new SqlParameter("@customerid",SqlDbType.Int)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsMasterCustomerNew1", objp, "@customerid");

        }


        public void UpdTransinReqCus(int cusid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@cusid",SqlDbType.Int,4)
            };
            objp[0].Value = cusid;
            ExecuteQuery("SPUpdTransferinReqCus", objp);
        }




        public void insertplandetails(int planid, int noofuser, string curr, Double amt, char mode, DateTime efffrom, DateTime dffto, int customerid, string desc, string inidescr, int amout)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@planid",SqlDbType.Int),
                                                     new SqlParameter("@noofuser",SqlDbType.Int),
                                                     new SqlParameter("@curr",SqlDbType.VarChar,4),
                                                     new SqlParameter("@amt",SqlDbType.Money),
                                                     new SqlParameter("@mode",SqlDbType.Char),
                                                     new SqlParameter("@efffrom",SqlDbType.DateTime),
                                                     new SqlParameter("@effto",SqlDbType.DateTime),
                                                     new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@desc",SqlDbType.NVarChar,300),
                                                     
                                                        new SqlParameter("@inidesc",SqlDbType.NVarChar,100),
            new SqlParameter("@iniamount",SqlDbType.Int)};
            objp[0].Value = planid;
            objp[1].Value = noofuser;
            objp[2].Value = curr;
            objp[3].Value = amt;
            objp[4].Value = mode;
            objp[5].Value = efffrom;
            objp[6].Value = dffto;
            objp[7].Value = customerid;
            objp[8].Value = desc;
            objp[9].Value = inidescr;
            objp[10].Value = amout;

            ExecuteQuery("SP_insertplandetails", objp);
        }

        public DataTable SPSelGetCustomerPlanDetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {
           new SqlParameter("@customerid", SqlDbType.Int )
          
           };
            objp[0].Value = customerid;


            return ExecuteTable("SPSelGetCustomerPlanDetails", objp);

        }

        public void SPUpdMasterCustomerNewDesign(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int )
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            ExecuteQuery("SPUpdMasterCustomerNewDesign", objp);

        }

        public String GetCountryNamefrmid(string countryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryid", SqlDbType.VarChar, 50) };
            objp[0].Value = countryid;
            return ExecuteReader("SPCountryname", objp);
        }


        public int SPSelPortByCountryId(string portname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@port", SqlDbType.VarChar, 50) };
            objp[0].Value = portname;
            return int.Parse(ExecuteReader("SPSelPortByCountryId", objp));

        }

        public DataTable GetPincodeDetailsForLocation(string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode", SqlDbType.VarChar, 6) };
            objp[0].Value = pincode;
            return ExecuteTable("SPSelPincodeDetailsForLocation", objp);
        }

        public DataTable getOtherReqCustomerDtls(int cusid, string cusname, string custpye)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@cusid",SqlDbType.Int,4),
                new SqlParameter("@cusname",SqlDbType.VarChar,100),
                new SqlParameter("@custpye",SqlDbType.VarChar,1)
            };
            objp[0].Value = cusid;
            objp[1].Value = cusname;
            objp[2].Value = custpye;
            return ExecuteTable("SPGetOtherREQCusDtls", objp);
        }

        public void SPUpdReqCustomerReject(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            ExecuteReader("SPUpdReqCustomerReject", objp);
        }

        public void SPUpdMasterCustomerNewDesign(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1)

                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;

            ExecuteQuery("SPUpdMasterCustomerNewDesign", objp);

        }

        public String GetCountryNamefrmid(int countryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryid", SqlDbType.Int) };
            objp[0].Value = countryid;
            return ExecuteReader("SPCountrynameCId", objp);
        }

        public DataTable Getplan4profoma()
        {
            SqlParameter[] objp = new SqlParameter[] { 
         };

            return ExecuteTable("sp_getplan4profoma");
        }

        public DateTime GetDate()
        {
            return DateTime.Parse(ExecuteReader("SPGetDate"));
        }


        public int InsertProInvoiceHead(DateTime Dtdate, string strTranType, int jobno, int intcustomerid, string blno, string remarks, int branchid, string strbilltype, int preparedby, int vouyear, string type, string vendorrefno, int creditdays, int supplyto)
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


        public void insertinvoiceno(int refno, string descr, int vouyear, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int), 
                                                       new SqlParameter("@descr", SqlDbType.NVarChar,300),
                                                       new SqlParameter("@vouyear", SqlDbType.Int), 
                                                       new SqlParameter("@branchid", SqlDbType.Int)
                                                       
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = descr;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;

            ExecuteQuery("sp_insertinvoiceno", objp);
            //return ExecuteTable("SPUpdChargesGST4OldVou", objp);
        }

        public void Updateinvcount(int count, int customerid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@count", SqlDbType.Int,1), 
                                                       new SqlParameter("@customerid", SqlDbType.Int)
                                                       
                                                                            };
            objp[0].Value = count;
            objp[1].Value = customerid;

            ExecuteQuery("SP_updateinvcount", objp);
            //return ExecuteTable("SPUpdChargesGST4OldVou", objp);
        }

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

        public DataTable Getplan4profoma(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int), 
         };
            objp[0].Value = customerid;
            return ExecuteTable("sp_get4profoma", objp);
        }

        public void insertinvoiceno(int refno, string descr, int vouyear, int branchid, DateTime invgendate)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@refno", SqlDbType.Int), 
                                                       new SqlParameter("@descr", SqlDbType.NVarChar,300),
                                                       new SqlParameter("@vouyear", SqlDbType.Int), 
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                        new SqlParameter("@invgendate", SqlDbType.DateTime)
                                                       
                                                                            };
            objp[0].Value = refno;
            objp[1].Value = descr;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = invgendate;

            ExecuteQuery("sp_insertinvoiceno1", objp);
            //return ExecuteTable("SPUpdChargesGST4OldVou", objp);
        }

        public double GetExRate(string currency, DateTime Dtdate, string extype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr",SqlDbType.VarChar,6),        
                                                       new SqlParameter("@Dtdate",SqlDbType.SmallDateTime,4),        
                                                       new SqlParameter("@extype",SqlDbType.VarChar,1)};
            objp[0].Value = currency;
            objp[1].Value = Dtdate;
            objp[2].Value = extype;
            return double.Parse(ExecuteReader("SPExRateCurrDate", objp));
        }

        //MUTHURAJ
        public DataTable SPSelGetStateNameIdGet(string statename)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@StateName", SqlDbType.VarChar, 50)
            };

            objp[0].Value = statename;

            return ExecuteTable("SPSelGetStateNameIdGet", objp);
        }


        public DataTable GetStatenameGSTnew()
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
              
            };

            return ExecuteTable("SPSelGetStateNameGSTNEW");
        }

        public DataTable Getlikecustomer4rec(DateTime fdate, DateTime tdate, char custtype, string customer, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@from", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@custtype",SqlDbType.Char,1),
                                                    new SqlParameter("@txtcustomer",SqlDbType.VarChar,50),
                                                    new SqlParameter("@branchid",SqlDbType.Int,4)
                                                     };

            objp[0].Value = fdate;
            objp[1].Value = tdate;
            objp[2].Value = custtype;
            objp[3].Value = customer;
            objp[4].Value = branchid;

            return ExecuteTable("SPGETLikeOuSdREcCustomer", objp);
        }


        public DataTable Getlikecustomer4pay(DateTime fdate, DateTime tdate, char custtype, string customer, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@from", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@custtype",SqlDbType.Char,1),
                                                    new SqlParameter("@txtcustomer",SqlDbType.VarChar,50),
                                                    new SqlParameter("@branchid",SqlDbType.Int,4)
                                                     };
            objp[0].Value = fdate;
            objp[1].Value = tdate;
            objp[2].Value = custtype;
            objp[3].Value = customer;
            objp[4].Value = branchid;

            return ExecuteTable("SPGETLikeOuSdPayCustomer", objp);
        }


        public DataTable Getlikesalesperson(DateTime fdate, DateTime tdate, char tran, string sales, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@from", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@to", SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@tran",SqlDbType.Char,1),
                                                    new SqlParameter("@sales",SqlDbType.VarChar,50),
                                                    new SqlParameter("@bid",SqlDbType.Int,4)
                                                     };

            objp[0].Value = fdate;
            objp[1].Value = tdate;
            objp[2].Value = tran;
            objp[3].Value = sales;
            objp[4].Value = branchid;

            return ExecuteTable("SPGetOutstdSalesPerson", objp);
        }

        //Dinesh

        public void SPInsMasterCustomerNewimage(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                         new SqlParameter("@Sez",SqlDbType.Char,1),
                                                         new SqlParameter("@Register",SqlDbType.Char,1),
                                                            new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            ExecuteQuery("SPInsMasterCustomerNewimage", objp);

        }



        //Dinesh

        public void SPUpdMasterCustomerNewDesignimage(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                                   new SqlParameter("@Sez",SqlDbType.Char,1),
                                                                     new SqlParameter("@Register",SqlDbType.Char,1),
                                                                     new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            ExecuteQuery("SPUpdMasterCustomerNewDesignimage", objp);

        }


        //RAj
        public DataTable SPSelGetCustomerDetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {
           new SqlParameter("@customerid", SqlDbType.Int )
           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };

            objp[0].Value = customerid;
            //objp[2].Value = type;
            return ExecuteTable("SPSelGetCustomerDetailsbyID", objp);
        }


        //ruban
        public DataTable Getcustomeridfromledger(int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int, 4) };

            objp[0].Value = ledgerid;
            return ExecuteTable("spgetcustomeridfromledger", objp);
            //return int.Parse(ExecuteReader("spgetcustomeridfromledger", objp));
        }

        public DataTable GetCustomernamegroupid(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPCustomernameCId", objp);
        }


        //Sinosh

        public DataTable GetLikeCustomerShipCons(int customerid, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteTable("SPLikeCustMailIDnew", objp);
        }

        //MUTHURAJ

        public void SPInsMasterCustomerNewimagereques(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int saleid)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                        new SqlParameter("@Sez",SqlDbType.Char,1),
                                                        new SqlParameter("@Register",SqlDbType.Char,1),
                                                        new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                        new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                        new SqlParameter("@expheadimg",SqlDbType.Image),
                                                        new SqlParameter("@finheadimg",SqlDbType.Image),
                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                             new SqlParameter("@salesid",SqlDbType.Int)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = saleid;
            ExecuteQuery("SPInsMasterCustomerNewimagerequest", objp);

        }

        public DataTable SPSelGetCustomerDetailsrequest(string customername, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 200),
           new SqlParameter("@customerid", SqlDbType.Int )
           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };
            objp[0].Value = customername;
            objp[1].Value = customerid;
            //objp[2].Value = type;
            return ExecuteTable("SPSelGetCustomerDetailsrequest", objp);

        }

        public void SPUpdMasterCustomerNewDesignimagerequest(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int saleid)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                                   new SqlParameter("@Sez",SqlDbType.Char,1),
                                                                     new SqlParameter("@Register",SqlDbType.Char,1),
                                                                     new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                          new SqlParameter("@salesid",SqlDbType.Int)
                                                                        
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = saleid;
            ExecuteQuery("SPUpdMasterCustomerNewDesignimageRequest", objp);

        }

        public DataTable GetLikeCustomernew(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPLikeCustomertypenew", objp);

        }

        public DataTable sgetcustomerdetailexport()
        {
            SqlParameter[] objp = new SqlParameter[] { 
         };

            return ExecuteTable("sp_getcustomerdetailexport");
        }



        //Dinesh

        public void SPInsMasterCustomerNewimagenew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int salesid)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                         new SqlParameter("@Sez",SqlDbType.Char,1),
                                                         new SqlParameter("@Register",SqlDbType.Char,1),
                                                            new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                      new SqlParameter ("@salesid",SqlDbType.Int),
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = salesid;
            ExecuteQuery("SPInsMasterCustomerNewimagenew", objp);

        }




        //Dinesh

        public void SPUpdMasterCustomerNewDesignimagenew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int salesid)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                                   new SqlParameter("@Sez",SqlDbType.Char,1),
                                                                     new SqlParameter("@Register",SqlDbType.Char,1),
                                                                     new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                         new SqlParameter ("@salesid",SqlDbType.Int)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = salesid;
            ExecuteQuery("SPUpdMasterCustomerNewDesignimagenew", objp);

        }


        public DataTable GetLikeCustomerForSalesWithAgent(string customername, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = empid;
            return ExecuteTable("SPLikeCustomerforSalesWithAgent", objp);

        }
        //RajBharath

        public DataTable checkvoucherraise(int custid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int), };

            objp[0].Value = custid;


            return ExecuteTable("voucherraise", objp);

        }



        public void Block_customer(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@customerid", SqlDbType.Int, 4)
            };
            objp[0].Value = customerid;
            ExecuteQuery("Sp_blockcustomer", objp);
        }


        public DataTable Get4customercheckblock(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@customerid", SqlDbType.Int, 4)
            };
            objp[0].Value = customerid;
            return ExecuteTable("SP_blockcustomercheck", objp);
        }



        public void updcustomertranfer(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@cusid",SqlDbType.Int)
                                               
                                              };
            objp[0].Value = customerid;



            ExecuteQuery("sp_customertranfer", objp);
        }



        //Sinosh
        public void inskycproofcustomerwithgst(int proofid, int customerid, int id, string idfilename, int updatedby)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@proofid", SqlDbType.Int),
                       new SqlParameter("@cid", SqlDbType.Int),
                       new SqlParameter("@id", SqlDbType.Int),
                       new SqlParameter("@idfile", SqlDbType.VarChar,400) ,                       
          new SqlParameter("@updatedby", SqlDbType.Int)};
            objp[0].Value = proofid;
            objp[1].Value = customerid;
            objp[2].Value = id;
            objp[3].Value = idfilename;
            objp[4].Value = updatedby;
            ExecuteQuery("spinskycproof4cusgst", objp);
        }

        public DataTable Getkycdetails(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@customerid", SqlDbType.Int, 4)
            };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetkycdetails", objp);
        }

        public void Delkycdetails(int proofid, int customerid, string filename)
        {
            SqlParameter[] objp = new SqlParameter[] {
                        new SqlParameter("@proofid", SqlDbType.Int),
                        new SqlParameter("@cid", SqlDbType.Int),                       
                        new SqlParameter("@filename", SqlDbType.VarChar,400)
            };
            objp[0].Value = proofid;
            objp[1].Value = customerid;
            objp[2].Value = filename;
            ExecuteQuery("SPDelkycdetails", objp);
        }

        public int getcustgroupid(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };

            objp[0].Value = custid;

            return int.Parse(ExecuteReader("spcustgroupid", objp));
        }
        //Mastercustomer.cs
        //Tally
        public DataTable Get_customerdetailsnew(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            return ExecuteTable("sp_getcustomerdetailsfortally", objp);
        }

        //Dinesh
        public void inskycproofcustomerwithgstreqcust(int proofid, int customerid, int id, string idfilename, int updatedby)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@proofid", SqlDbType.Int),
                       new SqlParameter("@cid", SqlDbType.Int),
                       new SqlParameter("@id", SqlDbType.Int),
                       new SqlParameter("@idfile", SqlDbType.VarChar,400) ,
          new SqlParameter("@updatedby", SqlDbType.Int)};
            objp[0].Value = proofid;
            objp[1].Value = customerid;
            objp[2].Value = id;
            objp[3].Value = idfilename;
            objp[4].Value = updatedby;
            ExecuteQuery("spinskycproof4cusgstreqcust", objp);
        }
        public DataTable Getkycdetailsreq(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@customerid", SqlDbType.Int, 4)
            };
            objp[0].Value = customerid;
            return ExecuteTable("SPGetkycdetailsrew", objp);
        }

        public void Delkycdetailsreq(int proofid, int customerid, string filename)
        {
            SqlParameter[] objp = new SqlParameter[] {
                        new SqlParameter("@proofid", SqlDbType.Int),
                        new SqlParameter("@cid", SqlDbType.Int),                       
                        new SqlParameter("@filename", SqlDbType.VarChar,400)
            };
            objp[0].Value = proofid;
            objp[1].Value = customerid;
            objp[2].Value = filename;
            ExecuteQuery("SPDelkycdetailsreq", objp);
        }

        public void insertmastercustomerkyc(int reqcustomerid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {
             
                       new SqlParameter("@reqcustomerid", SqlDbType.Int),
                        new SqlParameter("@customerid", SqlDbType.Int)
                     };
            objp[0].Value = reqcustomerid;
            objp[1].Value = customerid;

            ExecuteQuery("insertmastercustomerkyc", objp);
        }



        //dinesh




        public void SPInsMasterCustomerNewimagerequesnew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int saleid, double limit, string empperiodfrom, string empperiodto, string certno, double tdsemp, string SEZIgst)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                        new SqlParameter("@Sez",SqlDbType.Char,1),
                                                        new SqlParameter("@Register",SqlDbType.Char,1),
                                                        new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                        new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                        new SqlParameter("@expheadimg",SqlDbType.Image),
                                                        new SqlParameter("@finheadimg",SqlDbType.Image),
                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                        new SqlParameter("@salesid",SqlDbType.Int),
                                                        new SqlParameter("@limit",SqlDbType.Money,8),
                                                        new SqlParameter("@empperiodfrom",SqlDbType.VarChar,50),
                                                        new SqlParameter("@empperiodto",SqlDbType.VarChar,50),
                                                        new SqlParameter("@certno",SqlDbType.VarChar,150 ),
                                                          new SqlParameter("@tdsemp",SqlDbType.Money,8 ),
                                                          new SqlParameter("@sezexemption",SqlDbType.Char,1)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = saleid;
            objp[48].Value = limit;
            objp[49].Value = empperiodfrom;
            objp[50].Value = empperiodto;
            objp[51].Value = certno;
            objp[52].Value = tdsemp;
            objp[53].Value = SEZIgst;
            ExecuteQuery("SPInsMasterCustomerNewimagerequestnew", objp);

        }






        public void SPUpdMasterCustomerNewDesignimagerequestnew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int saleid, double limit, string empperiodfrom, string empperiodto, string certno, double tdsemp, string SEZIgst)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                                   new SqlParameter("@Sez",SqlDbType.Char,1),
                                                                     new SqlParameter("@Register",SqlDbType.Char,1),
                                                                     new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                          new SqlParameter("@salesid",SqlDbType.Int),
                                                                           new SqlParameter("@limit",SqlDbType.Money,8),
                                                        new SqlParameter("@empperiodfrom",SqlDbType.VarChar,50),
                                                        new SqlParameter("@empperiodto",SqlDbType.VarChar,50),
                                                        new SqlParameter("@certno",SqlDbType.VarChar,150),
                                                         new SqlParameter("@tdsemp",SqlDbType.Money,8),
                                                         new SqlParameter("@sezexemption",SqlDbType.Char,1)
                                                                        
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = saleid;
            objp[48].Value = limit;
            objp[49].Value = empperiodfrom;
            objp[50].Value = empperiodto;
            objp[51].Value = certno;
            objp[52].Value = tdsemp;
            objp[53].Value = SEZIgst;
            ExecuteQuery("SPUpdMasterCustomerNewDesignimageRequestnew", objp);

        }


        //Dinesh

        public void SPUpdMasterCustomerNewDesignimagenewnew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int salesid, double limit, string empperiodfrom, string empperiodto, string certno, double tdsemp, string SEZIgst)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                                   new SqlParameter("@Sez",SqlDbType.Char,1),
                                                                     new SqlParameter("@Register",SqlDbType.Char,1),
                                                                     new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                         new SqlParameter ("@salesid",SqlDbType.Int),
                                                                           new SqlParameter("@limit",SqlDbType.Money,8),
                                                        new SqlParameter("@empperiodfrom",SqlDbType.VarChar,50),
                                                        new SqlParameter("@empperiodto",SqlDbType.VarChar,50),
                                                        new SqlParameter("@certno",SqlDbType.VarChar,150 ),
                                                       new SqlParameter("@tdsemp",SqlDbType.Money,8 ),
                                                       new SqlParameter("@Sezexemption",SqlDbType.Char,1)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = salesid;
            objp[48].Value = limit;
            objp[49].Value = empperiodfrom;
            objp[50].Value = empperiodto;
            objp[51].Value = certno;
            objp[52].Value = tdsemp;
            objp[53].Value = SEZIgst;
            ExecuteQuery("SPUpdMasterCustomerNewDesignimagenewnew", objp);

        }


        //Dinesh

        public void SPInsMasterCustomerNewimagenewnew(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int salesid, double limit, string empperiodfrom, string empperiodto, string certno, double tdsemp, string SEZIgst)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                         new SqlParameter("@Sez",SqlDbType.Char,1),
                                                         new SqlParameter("@Register",SqlDbType.Char,1),
                                                            new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                      new SqlParameter ("@salesid",SqlDbType.Int),
                                                                        new SqlParameter("@limit",SqlDbType.Money,8),
                                                        new SqlParameter("@empperiodfrom",SqlDbType.VarChar,50),
                                                        new SqlParameter("@empperiodto",SqlDbType.VarChar,50),
                                                        new SqlParameter("@certno",SqlDbType.VarChar, 150 ),
                                                          new SqlParameter("@tdsemp",SqlDbType.Money,8 ),
                                                       new SqlParameter("@Sezexemption",SqlDbType.Char,1)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = salesid;
            objp[48].Value = limit;
            objp[49].Value = empperiodfrom;
            objp[50].Value = empperiodto;
            objp[51].Value = certno;
            objp[52].Value = tdsemp;
            objp[53].Value = SEZIgst;
            ExecuteQuery("SPInsMasterCustomerNewimagenewnew", objp);

        }



        //Dinesh
        public DataTable GetexactCustomerForSalescustid(int custid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomerid",SqlDbType.Int),
                                                                                     new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = custid;
            objp[1].Value = empid;
            return ExecuteTable("SPexactCustomerforSalescusid", objp);

        }




        public int Getkycddetails(string customername)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@customername", SqlDbType.VarChar,200)
            };
            objp[0].Value = customername;
            return int.Parse(ExecuteReader("spkycddetails", objp));
        }



        public string getsezcustid(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = customerid;
            return ExecuteReader("spsezcustid", objp);
        }


        //Dinesh
        public DataTable getcustomerblk(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int)
                                                                                  };
            objp[0].Value = custid;

            return ExecuteTable("spgetcustomerblk", objp);

        }





        //SATHYA


        public void SPUpdMasterCustomerNewDesignimagenewnew_updlp(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int salesid, double limit, string empperiodfrom, string empperiodto, string certno, double tdsemp, string SEZIgst, string livehold)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                  new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                                  new SqlParameter("@RCM",SqlDbType.Char,1),
                                                                  new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                                  new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                                   new SqlParameter("@Sez",SqlDbType.Char,1),
                                                                     new SqlParameter("@Register",SqlDbType.Char,1),
                                                                     new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                         new SqlParameter ("@salesid",SqlDbType.Int),
                                                                           new SqlParameter("@limit",SqlDbType.Money,8),
                                                        new SqlParameter("@empperiodfrom",SqlDbType.VarChar,50),
                                                        new SqlParameter("@empperiodto",SqlDbType.VarChar,50),
                                                        new SqlParameter("@certno",SqlDbType.VarChar,150 ),
                                                       new SqlParameter("@tdsemp",SqlDbType.Money,8 ),
                                                       new SqlParameter("@Sezexemption",SqlDbType.Char,1),
                                                           new SqlParameter("@livehold",SqlDbType.VarChar,10)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = salesid;
            objp[48].Value = limit;
            objp[49].Value = empperiodfrom;
            objp[50].Value = empperiodto;
            objp[51].Value = certno;
            objp[52].Value = tdsemp;
            objp[53].Value = SEZIgst;
            objp[54].Value = livehold;
            ExecuteQuery("SPUpdMasterCustomerNewDesignimagenewonelhupd", objp);

        }


        public void SPInsMasterCustomerNewimagenewnew_onelh(string customername, string customertype, string unit, string buildingname,
          string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode,
          int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email,
          string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc,
          string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno,
          string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg,
          byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int salesid, double limit, string empperiodfrom,
          string empperiodto, string certno, double tdsemp, string SEZIgst, string livehold)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                        new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                         new SqlParameter("@Sez",SqlDbType.Char,1),
                                                         new SqlParameter("@Register",SqlDbType.Char,1),
                                                            new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                               new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                                  new SqlParameter("@expheadimg",SqlDbType.Image),
                                                                     new SqlParameter("@finheadimg",SqlDbType.Image),
                                                                        new SqlParameter("@impimg",SqlDbType.Image),
                                                                      new SqlParameter ("@salesid",SqlDbType.Int),
                                                                        new SqlParameter("@limit",SqlDbType.Money,8),
                                                        new SqlParameter("@empperiodfrom",SqlDbType.VarChar,50),
                                                        new SqlParameter("@empperiodto",SqlDbType.VarChar,50),
                                                        new SqlParameter("@certno",SqlDbType.VarChar, 150 ),
                                                          new SqlParameter("@tdsemp",SqlDbType.Money,8 ),
                                                       new SqlParameter("@Sezexemption",SqlDbType.Char,1),
                                                       new SqlParameter("@livehold",SqlDbType.VarChar,10)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = salesid;
            objp[48].Value = limit;
            objp[49].Value = empperiodfrom;
            objp[50].Value = empperiodto;
            objp[51].Value = certno;
            objp[52].Value = tdsemp;
            objp[53].Value = SEZIgst;
            objp[54].Value = livehold;

            ExecuteQuery("SPInsMasterCustomerNewimagenewnewONE_LH", objp);

        }



        public DataTable SPSelGetCustomerDetailsLiHold(string customername, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 200),
           new SqlParameter("@customerid", SqlDbType.Int )
           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };
            objp[0].Value = customername;
            objp[1].Value = customerid;
            //objp[2].Value = type;
            return ExecuteTable("SPSelGetCustomerDetailsLH", objp);

        }

        //Sinosh
        public void inskycproofcustomerwithgstreq(int proofid, int customerid, int id, string idfilename, int updatedby)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@proofid", SqlDbType.Int),
                       new SqlParameter("@cid", SqlDbType.Int),
                       new SqlParameter("@id", SqlDbType.Int),
                       new SqlParameter("@idfile", SqlDbType.VarChar,400) ,                       
          new SqlParameter("@updatedby", SqlDbType.Int)};
            objp[0].Value = proofid;
            objp[1].Value = customerid;
            objp[2].Value = id;
            objp[3].Value = idfilename;
            objp[4].Value = updatedby;
            ExecuteQuery("spinskycproof4cusgstreques", objp);
        }


        public DataTable SPLikeCustomerAll4Customer(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerAll4Customer", objp);
        }


        public DataTable SPLikeCustomerAll4CustomernewEbooking(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerAll4Customerwebgroup", objp);
        }



        public DataTable GetLikeCustomer4Inboundnewly(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPLikeCustomertypeAgentnewly", objp);
        }




        public DataTable spcustomernamemailid(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
           new SqlParameter("@customerid", SqlDbType.Int )
          
           };

            objp[0].Value = customerid;

            return ExecuteTable("spcustomernamemailid", objp);

        }


        public DataTable GetLikeCustomer1(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeMultiCustomer", objp);
        }



        public DataTable getmailidforebooking(string blno, int bid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@blno", SqlDbType.VarChar, 100 ),
           new SqlParameter("@bid", SqlDbType.Int ),
             new SqlParameter("@trantype", SqlDbType.VarChar, 10 )
          
           };

            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            return ExecuteTable("spemailids", objp);

        }



        public int Getkycddetailsnew(string customername, string pincode, string porid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@customername", SqlDbType.VarChar,200),
                 new SqlParameter("@pincode", SqlDbType.VarChar,20),
                   new SqlParameter("@porid", SqlDbType.VarChar,20)
            };
            objp[0].Value = customername;
            objp[1].Value = pincode;
            objp[2].Value = porid;
            return int.Parse(ExecuteReader("spkycddetailsnew", objp));
        }

        public int GetCustomeridnew(string customername, string pincode, string street, string city)
        {
            SqlParameter[] objp = new SqlParameter[] {          new SqlParameter("@customername",SqlDbType.VarChar,500),
                                                                new SqlParameter("@pincode",SqlDbType.VarChar,500),      
                                                                 new SqlParameter("@street",SqlDbType.VarChar,500),
                                                                  new SqlParameter("@city",SqlDbType.VarChar,500)
                                                                                     };
            objp[0].Value = customername;
            objp[1].Value = pincode;
            objp[2].Value = street;
            objp[3].Value = city;
            return int.Parse(ExecuteReader("sp_getdetails4customerid", objp));
        }
        // yuvaraj 14/09/2022
        public DataTable Getlikepanno(string PANno)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar,50),                                                                 
            };
            objlim[0].Value = PANno;
            return ExecuteTable("SPGetlikepanno", objlim);
        }
        public DataTable GetCustomerbygstin(string gstno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@GSTNO", SqlDbType.VarChar, 15) };
            objp[0].Value = gstno;
            return ExecuteTable("GetGSTNoAutoComplete", objp);
        }
        public DataTable GetLikeBankName(string bankname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bname", SqlDbType.VarChar, 50) };
            objp[0].Value = bankname;
            return ExecuteTable("SPBanknamelikenew", objp);
        }
        public DataTable Gettextchangeledgernamenew(int Customerid, string Accountnumber, int bankid)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
               
               new SqlParameter("@Customerid", SqlDbType.Int),
               new SqlParameter("@Accountnumber", SqlDbType.VarChar, 30),
               new SqlParameter("@bankid", SqlDbType.Int)
               
          };
            objp[0].Value = Customerid;
            objp[1].Value = Accountnumber;
            objp[2].Value = bankid;


            return ExecuteTable("typetexteventledgernamenew", objp);
        }
        public string SPInsMasterCustomerNewimageNews(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid,
            int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd,
            string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc,
            string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno, string ptc, string RCM,
            string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg,
            string Tanno, string Cinno, char SezIgst)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,250),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                       new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                       new SqlParameter("@Sez",SqlDbType.Char,1),
                                                       new SqlParameter("@Register",SqlDbType.Char,1),
                                                       new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                       new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                       new SqlParameter("@expheadimg",SqlDbType.Image),
                                                       new SqlParameter("@finheadimg",SqlDbType.Image),
                                                       new SqlParameter("@impimg",SqlDbType.Image),
                                                       new SqlParameter("@Tanno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@Cinno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@SezIgst",SqlDbType.Char,1),

            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = Tanno;
            objp[48].Value = Cinno;
            objp[49].Value = SezIgst;

            return ExecuteReader("SPInsMasterCustomerNewimageNews", objp);

        }



        public void SPUpdColoadDetails(int customerid, string iscoload, string coloadremarks, string coloadercode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int),
                                                       new SqlParameter("@iscoload", SqlDbType.Char,1),
                                                       new SqlParameter ("@coloadremarks",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@coloadercode",SqlDbType.VarChar,10)
            
            };
            objp[0].Value = customerid;
            objp[1].Value = iscoload;
            objp[2].Value = coloadremarks;
            objp[3].Value = coloadercode;

            ExecuteReader("SPUpdColoadDetails", objp);
        }

        public string Sp_UploadLimitDetails(double limit, DateTime empperiodfrom, DateTime empperiodto, string certno, int customerid, double tdsemp)
        {
            SqlParameter[] objlim = new SqlParameter[] {  new SqlParameter("@limit",SqlDbType.Money,8),
                                                       new SqlParameter("@empperiodfrom",SqlDbType.SmallDateTime,50),
                                                       new SqlParameter("@empperiodto",SqlDbType.SmallDateTime,50),
                                                       new SqlParameter("@certno",SqlDbType.VarChar,150 ),
                                                         new SqlParameter("@customerid ",SqlDbType.Int,5),
                                                        new SqlParameter("@tdsemp",SqlDbType.Money,8 )
            
            };
            objlim[0].Value = limit;
            objlim[1].Value = empperiodfrom;
            objlim[2].Value = empperiodto;
            objlim[3].Value = certno;
            objlim[4].Value = customerid;
            objlim[5].Value = tdsemp;
            return ExecuteReader("Sp_UploadLimitDetails", objlim);
        }
        public DataTable Insmastercustpandtls(string PANno, string PANName, string TANno, string CINno, string UINno, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                       new SqlParameter("@PANno", SqlDbType.VarChar,50),
                       new SqlParameter("@PANName", SqlDbType.VarChar,200),
                       new SqlParameter("@TANno", SqlDbType.VarChar,50) ,                    
                       new SqlParameter("@CINno", SqlDbType.VarChar,50),                     
                       new SqlParameter("@UINno", SqlDbType.VarChar,50),
                       new SqlParameter("@saleid",SqlDbType.Int)
                     
        };
            objp[0].Value = PANno;
            objp[1].Value = PANName;
            objp[2].Value = TANno;

            objp[3].Value = CINno;
            objp[4].Value = UINno;
            objp[5].Value = salesid; // add yuvaraj pantable 

            return ExecuteTable("SpInsmastercustpandtls", objp);
        }
        public void UPdEnvoice4cust(int customerid, string einvoice)
        {


            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int),        
                                                                                     new SqlParameter("@einvoice",SqlDbType.VarChar,1) };
            objp[0].Value = customerid;
            objp[1].Value = einvoice;

            ExecuteQuery("SPUPdEnvoice4cust", objp);

        }
        public DataTable Getcustgridwithpan(string PANno)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar,50),                                                                 
            };
            objlim[0].Value = PANno;
            return ExecuteTable("SPgetcustgridwithpan", objlim);
        }
        public DataTable GetCustomerDetailsById(int CustomerId)
        {

            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@CustomerId",SqlDbType.Int)};
            objp[0].Value = CustomerId;
            return ExecuteTable("GetCustomerDetaisById", objp);
        }
        public void SPUpdMasterCustomerNewDesignimage(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid,
     int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd,
     string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc,
     string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds, string ptc, string gstin, string uinno, string RCM,
     string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg, byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg,
     string Tanno, string Cinno, char SezIgst)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,250),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int ),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1), 
                                                       new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                       new SqlParameter("@Sez",SqlDbType.Char,1),
                                                       new SqlParameter("@Register",SqlDbType.Char,1),
                                                       new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                       new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                       new SqlParameter("@expheadimg",SqlDbType.Image),
                                                       new SqlParameter("@finheadimg",SqlDbType.Image),
                                                       new SqlParameter("@impimg",SqlDbType.Image),
                                                       new SqlParameter("@Tanno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@Cinno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@SezIgst",SqlDbType.Char,1)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = Tanno;
            objp[48].Value = Cinno;
            objp[49].Value = SezIgst;
            ExecuteQuery("SPUpdMasterCustomerNewDesignimage", objp);

        }
        public DataTable checklikepanno(string PANno, string customername)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar,50),  
                new SqlParameter("@customername", SqlDbType.VarChar, 200),
                                               
            };
            objlim[0].Value = PANno;
            objlim[1].Value = customername;
            return ExecuteTable("SPchecklikepanno", objlim);
        }
        public DataTable GetEmployeeDetByGSTIN(string GSTIN)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@GSTIN", SqlDbType.VarChar, 50) 
            };
            objp[0].Value = GSTIN;
            return ExecuteTable("GetEmployeeDetByGSTIN", objp);
        }
        public void DeleteMCUploadinfo(int MCUploadinfo, int CustomerId)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@MCUploadinfo", SqlDbType.Int) ,
            new SqlParameter("@CustomerId", SqlDbType.Int) 
            };
            objp[0].Value = MCUploadinfo;
            objp[1].Value = CustomerId;
            ExecuteQuery("DeleteMCUploadinfo", objp);
        }
        public string InsertBusinessCardInfotoCustomer(int CustomerId, string Position, string Name, string CardFileName, string Title)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@CustomerId", SqlDbType.Int) ,
            new SqlParameter("@Position", SqlDbType.Char,3) ,
            new SqlParameter("@Name", SqlDbType.VarChar,100) ,
            new SqlParameter("@CardFileName", SqlDbType.VarChar,500) ,
            new SqlParameter("@Title", SqlDbType.VarChar,3)

            };
            objp[0].Value = CustomerId;
            objp[1].Value = Position;
            objp[2].Value = Name;
            objp[3].Value = CardFileName;
            objp[4].Value = Title;
            return ExecuteReader("InsertBusinessCardInfotoCustomer", objp);
        }
        public void Updmail4businesscard(int CustomerId, string email)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@CustomerId", SqlDbType.Int) ,
              new SqlParameter("@email", SqlDbType.VarChar,50) ,
            };
            objp[0].Value = CustomerId;
            objp[1].Value = email;
            ExecuteQuery("SPUpdmail4businesscard", objp);
        }
        public DataTable GetBusinessCardInfotoCustomer(int CustomerId)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@CustomerId", SqlDbType.Int) ,
            };
            objp[0].Value = CustomerId;
            return ExecuteTable("GetBusinessCardInfotoCustomer", objp);
        }
        public DataTable GetShipperdtls(int customerid, string ctype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int),
                                                       new SqlParameter("@ctype", SqlDbType.Char,1)
                                                         };
            objp[0].Value = customerid;
            objp[1].Value = ctype;

            return ExecuteTable("SPGetShipperdtls", objp);
        }
        public DataTable SPSelKYCProofCust(string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Char, 5) };
            objp[0].Value = type;
            return ExecuteTable("spselallproofCust", objp);
        }
        public DataTable KycUploadnew(int mode, int Customerid, int Empid, int Proofid, string proof, string FileName, int customerpanid)
        {
            SqlParameter[] objkyc = new SqlParameter[]{new SqlParameter("@mode",SqlDbType.Int,5),
                                                new SqlParameter("@CustomerId",SqlDbType.Int,5),
                                            new SqlParameter("@Empid",SqlDbType.Int,5),
                                            new SqlParameter("@Proofid",SqlDbType.Int,5),
                                            new SqlParameter("@Proof",SqlDbType.VarChar,50),
                                            new SqlParameter("@FileName",SqlDbType.VarChar,45),
                                                 new SqlParameter("@customerpanid",SqlDbType.Int)};
            objkyc[0].Value = mode;
            objkyc[1].Value = Customerid;
            objkyc[2].Value = Empid;
            objkyc[3].Value = Proofid;
            objkyc[4].Value = proof;
            objkyc[5].Value = FileName;
            objkyc[6].Value = customerpanid;
            return ExecuteTable("sp_masterKycCustomernew", objkyc);
        }


        public void Inscustpandtls(string PANno, string customername, int legaltype, int category, int facategory)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar,50),  
                new SqlParameter("@customername", SqlDbType.VarChar, 200),
                new SqlParameter("@legaltype", SqlDbType.Int),
                new SqlParameter("@category", SqlDbType.Int),
                new SqlParameter("@facategory", SqlDbType.Int)
                                               
            };
            objlim[0].Value = PANno;
            objlim[1].Value = customername;
            objlim[2].Value = legaltype;
            objlim[3].Value = category;
            objlim[4].Value = facategory;

            ExecuteQuery("Inscustpandtls", objlim);
        }
        public void UPdEnvoice4custpan(int panid, string einvoice)
        {


            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@panid",SqlDbType.Int),        
                                                       new SqlParameter("@einvoice",SqlDbType.VarChar,1) };
            objp[0].Value = panid;
            objp[1].Value = einvoice;

            ExecuteQuery("SPUPdEnvoice4custpan", objp);

        }
        public string kycDeleteProof(int mode, int Customerid, string Filename, int proofid)
        {
            SqlParameter[] objgridp = new SqlParameter[]{new SqlParameter("@mode",SqlDbType.Int,5),
                                                        new SqlParameter("@CustomerId",SqlDbType.Int,5),
                                                        new SqlParameter("@FileName",SqlDbType.VarChar,45),
                                                        new SqlParameter("@Proofid",SqlDbType.Int,5),};
            objgridp[0].Value = mode;
            objgridp[1].Value = Customerid;
            objgridp[2].Value = Filename;
            objgridp[3].Value = proofid;
            return ExecuteReader("sp_masterKycCustomer", objgridp);
        }
        public string INSmastercustomersiscodeupdate(int CustomerId, string status, string errormsg, int updatedby)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@CustomerId", SqlDbType.Int) ,
            new SqlParameter("@status", SqlDbType.VarChar,500) ,
            new SqlParameter("@errormsg", SqlDbType.VarChar,500) ,
            new SqlParameter("@updatedby", SqlDbType.Int) ,
        

            };
            objp[0].Value = CustomerId;
            objp[1].Value = status;
            objp[2].Value = errormsg;
            objp[3].Value = updatedby;

            return ExecuteReader("SPINSmastercustomersiscodeupdate", objp);
        }
        public DataTable SPSelGetCustomerDetails4pan(string customername, int customerid, string gst)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 200),
           new SqlParameter("@customerid", SqlDbType.Int ),
           new SqlParameter("@gst", SqlDbType.VarChar, 50)

           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };
            objp[0].Value = customername;
            objp[1].Value = customerid;
            objp[2].Value = gst;
            return ExecuteTable("SPSelGetCustomerDetails4pan", objp);

        }
        public void insertcustomerbankaccountnew(int Customerid, int Bankid, string Accountnumber, string Account, string IFSCCode)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@Customerid", SqlDbType.Int),  
                new SqlParameter("@Bankid", SqlDbType.Int),
                new SqlParameter("@Accountnumber", SqlDbType.VarChar, 30),
                 new SqlParameter("@Account", SqlDbType.VarChar, 30),
                 new SqlParameter("@IFSCCode", SqlDbType.VarChar, 30),
            };
            objp[0].Value = Customerid;
            objp[1].Value = Bankid;
            objp[2].Value = Accountnumber;
            objp[3].Value = Account;
            objp[4].Value = IFSCCode;

            ExecuteQuery("insertcustomerbankaccountdetnew", objp);
        }
        public DataTable get_Gridviewnewone(int Customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                  new SqlParameter("@Customerid",SqlDbType.Int),
             };
            objp[0].Value = Customerid;

            return ExecuteTable("get_Gridviewdatadisplaynewshownew", objp);
        }
        public DataTable Getbankdetails(int Customerid, string panno)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                  new SqlParameter("@Customerid",SqlDbType.Int),
                   new SqlParameter("@panno",SqlDbType.VarChar,50)
             };
            objp[0].Value = Customerid;
            objp[1].Value = panno;
            return ExecuteTable("SPgetbankdetails", objp);
        }

        public DataTable Getstatus4custxml(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int)
                                                         };
            objp[0].Value = customerid;

            return ExecuteTable("SPGetstatus4custxml", objp);
        }
        public DataTable SP_GetallPannumberdetails(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar,50)
                                                         };
            objp[0].Value = customername;

            return ExecuteTable("SP_GetallPannumber", objp);
        }
        // kalai 28/10/2022

        public DataTable SPLikeCustomerAll4Customernewtype(string customername, char customertype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100),
            new SqlParameter("@customertype",SqlDbType.Char,1),};


            objp[0].Value = customername;
            objp[1].Value = customertype;

            return ExecuteTable("SPLikeCustomerAll4Customerwithtype", objp);

        }

        public DataTable customergetdetails(string panno, string pancustomer, string Gst)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                  new SqlParameter("@panno",SqlDbType.VarChar,50),
                   new SqlParameter("@customername",SqlDbType.VarChar,50),
                   new SqlParameter("@gstin",SqlDbType.VarChar,50)
             };
            objp[0].Value = panno;
            objp[1].Value = pancustomer;
            objp[2].Value = Gst;
            return ExecuteTable("sp_customergetdetails", objp);
        }
        // yuvaraj 15/11/2022

        public DataTable Sp_mastercustomerpancredit(string branchid, double amount, int days, string panno, string panname, int Limit, int due, string per)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@branchid",SqlDbType.VarChar),
                  new SqlParameter("@amount",SqlDbType.Money,10),
                   new SqlParameter("@days",SqlDbType.Int,4),
                    new SqlParameter("@panno",SqlDbType.VarChar,50),
                    
                    new SqlParameter("@panname",SqlDbType.VarChar,50),
                    new SqlParameter("@EXLIMIT",SqlDbType.Int,4),
                    new SqlParameter("@OVERDUE",SqlDbType.Int,4),
                    new SqlParameter("@EXMODE",SqlDbType.VarChar,1),
                  };
            objp[0].Value = branchid;
            objp[1].Value = amount;
            objp[2].Value = days;
            objp[3].Value = panno;
            objp[4].Value = panname;
            objp[5].Value = Limit;
            objp[6].Value = due;
            objp[7].Value = per;

            return ExecuteTable("Sp_mastercustomerpancredit", objp);//, "@empid");
        }
        // yuvaraj 19/12/22

        public DataTable getcustgridwithcustomeragent(int cusid, string cusname)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                  new SqlParameter("@custid",SqlDbType.Int),
                   new SqlParameter("@cusname",SqlDbType.VarChar,100),
               
             };
            objp[0].Value = cusid;
            objp[1].Value = cusname;

            return ExecuteTable("SPgetcustgridwithcustomeragent", objp);
        }
        public DataTable SP_getbankdetailsAgent(int cusid, string cusname)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                  new SqlParameter("@custid",SqlDbType.Int),
                   new SqlParameter("@cusname",SqlDbType.VarChar,100),
               
             };
            objp[0].Value = cusid;
            objp[1].Value = cusname;

            return ExecuteTable("SPgetbankdetailsAgent", objp);
        }
        public DataTable SPSelGetCustomerDetailsCustomer(int cusid, string cusname)
        {
            SqlParameter[] objp = new SqlParameter[]
             {
                  new SqlParameter("@custid",SqlDbType.Int),
                   new SqlParameter("@cusname",SqlDbType.VarChar,100),
               
             };
            objp[0].Value = cusid;
            objp[1].Value = cusname;

            return ExecuteTable("spSPSelGetCustomerDetailsCustomer", objp);
        }
        public string PanUploadLimitDetails(double limit, string custpan, DateTime empperiodfrom, DateTime empperiodto, string certno, double tdsemp, string customerpan)
        {
            SqlParameter[] objlim = new SqlParameter[] {  new SqlParameter("@limit",SqlDbType.Money,8),
            new SqlParameter("@custpan",SqlDbType.VarChar,50),
                                                       new SqlParameter("@empperiodfrom",SqlDbType.SmallDateTime,50),
                                                       new SqlParameter("@empperiodto",SqlDbType.SmallDateTime,50),
                                                       new SqlParameter("@certno",SqlDbType.VarChar,150 ),
                                                         
                                                        new SqlParameter("@tdsemp",SqlDbType.Money,8 ),
                                                        new SqlParameter("@customerpan",SqlDbType.VarChar,50),
            
            };
            objlim[0].Value = limit;
            objlim[1].Value = custpan;
            objlim[2].Value = empperiodfrom;
            objlim[3].Value = empperiodto;
            objlim[4].Value = certno;
            
            objlim[5].Value = tdsemp;
            objlim[6].Value = customerpan;
            return ExecuteReader("Sp_PanUploadLimitDetails", objlim);
        }

        public string UpdateDetailsupload(int CustomerId, string Position, string Name, string CardFileName, string Title)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
            new SqlParameter("@CustomerId", SqlDbType.Int) ,
            new SqlParameter("@Position", SqlDbType.Char,3) ,
            new SqlParameter("@Name", SqlDbType.VarChar,100) ,
            new SqlParameter("@CardFileName", SqlDbType.VarChar,500) ,
            new SqlParameter("@Title", SqlDbType.VarChar,3)

            };
            objp[0].Value = CustomerId;
            objp[1].Value = Position;
            objp[2].Value = Name;
            objp[3].Value = CardFileName;
            objp[4].Value = Title;
            return ExecuteReader("SPUpdateDetailsupload", objp);
        }
        // add by yuvaraj 
        public DataTable GetCreditAmount4product(int customerid, int division, int branchid, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1), 
                                                    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30)};
            objp[0].Value = customerid;
            objp[1].Value = division;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            objp[4].Value = blno;

            return ExecuteTable("SPCheckCreditCustomer4Product", objp);
        }

        public double CheckCreditOSAmount(int branchid, int year, int customerid, int jobno, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                     new SqlParameter("@bid",SqlDbType.Int,4),
                                                      new SqlParameter("@year",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid", SqlDbType.Int,4),
                                                      new SqlParameter("@jobno", SqlDbType.Int,4),
                                                      new SqlParameter("@divisionid", SqlDbType.Int,2) };
            objp[0].Value = branchid;
            objp[1].Value = year;
            objp[2].Value = customerid;
            objp[3].Value = jobno;
            objp[4].Value = division;

            return double.Parse(ExecuteReader("sp_outstanding_osamt", objp));
        }
        public int CheckCreditDays4Customer4product(int customerid, int division, int bid, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@bid",SqlDbType.Int,4),     
                                                        new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),};
            objp[0].Value = customerid;
            objp[1].Value = division;
            objp[2].Value = bid;
            objp[3].Value = trantype;
            objp[4].Value = blno;
            return int.Parse(ExecuteReader("SPCheckCreditDays4Customer4Product", objp));
        }
        public double CheckCreditAmount4product(int customerid, int branchid, int division, string trantype, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@division", SqlDbType.TinyInt,1) ,
                                                      new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30)};
            objp[0].Value = customerid;
            objp[1].Value = branchid;
            objp[2].Value = division;
            objp[3].Value = trantype;
            objp[4].Value = blno;
            return double.Parse(ExecuteReader("SPCheckCreditAmountCustomer4Product", objp));
        }

        public DataTable getspseltallyraj(int ledgerid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ledgerid", SqlDbType.Int),
            new SqlParameter("@cid", SqlDbType.Int) };
            objp[0].Value = ledgerid;
            objp[1].Value = customerid;

            return ExecuteTable("spseltallyraj", objp);
        }
        // Vino New for Change Ledgername [17-02-2023]
        public DataTable GetCustomerDetails4Ledger(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = customerid;

            return ExecuteTable("SPGetCustomerDetails4Ledger", objp);
        }


        public DataTable sp_getBusinessCardInfoCustomer(int CustomerId, string name, string Position)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
            new SqlParameter("@CustomerId", SqlDbType.Int),
            new SqlParameter("@name",SqlDbType.VarChar,100),
             new SqlParameter("@Position", SqlDbType.Char,3),

            };
            objp[0].Value = CustomerId;
            objp[1].Value = name;
            objp[2].Value = Position;
            return ExecuteTable("sp_getBusinessCardInfoCustomer", objp);
        }
        public void SPfileuploadbusinesscard(int CustomerId, string email, int MCUploadinfo)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
            new SqlParameter("@CustomerId", SqlDbType.Int) ,
              new SqlParameter("@email", SqlDbType.VarChar,50) ,
               new SqlParameter("@MCUploadinfo",SqlDbType.Int),

            };
            objp[0].Value = CustomerId;
            objp[1].Value = email;
            objp[2].Value = MCUploadinfo;
            ExecuteQuery("SPfileuploadbusinesscard", objp);/// add me 
        }
 

        //

        public DataTable SPgetallpannodetails(string panno)
        {
            SqlParameter[] objp = new SqlParameter[]
             {                 
                   new SqlParameter("@panno",SqlDbType.VarChar,100),
               
             };
            objp[0].Value = panno;

            return ExecuteTable("SPgetallpannodetails", objp);
        }
        //sp_paninputupdate
        public DataTable sp_paninputupdate(string Panno, string panname, string paninput)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Panno", SqlDbType.VarChar,50),
                                                       new SqlParameter("@panname",SqlDbType.VarChar,50),
                                                       new SqlParameter("@paninput",SqlDbType.VarChar,1)
                                                                 
            };

            objp[0].Value = Panno;
            objp[1].Value = panname;
            objp[2].Value = paninput;
            return ExecuteTable("sp_paninputupdate", objp);
        }

        public DataTable sp_panupdatedetails(string PANno, string PANName, string TANno, string CINno, string UINno, int salesid, int panid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                       new SqlParameter("@PANno", SqlDbType.VarChar,50),
                       new SqlParameter("@PANName", SqlDbType.VarChar,200),
                       new SqlParameter("@TANno", SqlDbType.VarChar,50) ,                    
                       new SqlParameter("@CINno", SqlDbType.VarChar,50),                     
                       new SqlParameter("@UINno", SqlDbType.VarChar,50),
                       new SqlParameter("@saleid",SqlDbType.Int),
                       new SqlParameter("@panid",SqlDbType.Int)
                     
        };
            objp[0].Value = PANno;
            objp[1].Value = PANName;
            objp[2].Value = TANno;

            objp[3].Value = CINno;
            objp[4].Value = UINno;
            objp[5].Value = salesid;
            objp[6].Value = panid;

            return ExecuteTable("sp_panupdatedetails", objp);
        }//SPgetallpannodetails

        public DataTable sp_getdetailcustomerpan(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@customername",SqlDbType.Int)
            };
            objp[0].Value = @customername;



            return ExecuteTable("sp_getdetailcustomerpan", objp);
        }
        public DataTable customerreport(string panno, string customer)
        {
            SqlParameter[] objp = new SqlParameter[]
             {                 
                   new SqlParameter("@panno",SqlDbType.VarChar,100),
                   new SqlParameter("@customer",SqlDbType.VarChar,100)
               
             };
            objp[0].Value = panno;
            objp[1].Value = customer;

            return ExecuteTable("spcustomerreport", objp);
        }


        public DataTable GetCustomer4quotcountrywise(string customername, string ctype, int div)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)
            ,
            new SqlParameter("@div", SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            objp[2].Value = div;
            return ExecuteTable("SPLikeCustomer4quotcountrywise", objp);

        }

        public DataTable SPLikeCustomerAll4Customerwithtypeforpan(string customername, char customertype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100),
            new SqlParameter("@customertype",SqlDbType.Char,1),};


            objp[0].Value = customername;
            objp[1].Value = customertype;

            return ExecuteTable("SPLikeCustomerAll4Customerwithtypeforpan1", objp);

        }

        ////////////////////////////////////////////////
        public DataTable GetLikeIndianCustomer(string customername, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 200),
                                                       new SqlParameter("@bid", SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = bid;
            return ExecuteTable("SPLikeIndianCustomer_new", objp);
        }
        ////////////////////////////////////////////////
       //new
        
        public DataTable GetLikeCustomerproformaFC(string customername, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 150),
           new SqlParameter("@cid", SqlDbType.Int)};
            objp[0].Value = customername;
            objp[1].Value = cid;
            return ExecuteTable("SPLikeCustomer4proformaFC", objp);
        }

        public DataTable GetLikeIndianCustomerFC(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 200) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeIndianCustomerFC", objp);
        }
        //
        public DataTable GetLikeCustomer4dn(string customername, string ctype)
        {
            if (ctype == "P")
            {
                ctype = "P";
            }
            else
            {
                ctype = "C";
            }
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@txtCustomer",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Custtype",SqlDbType.Char,1)};
            objp[0].Value = customername;
            objp[1].Value = ctype;
            return ExecuteTable("SPLikeCustomertypenew4dn", objp);

        }
        public void Insmastercustportalcredentials(int panid  ,string username  ,string pwd  ,string active  )
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panid", SqlDbType.Int),  
                new SqlParameter("@username", SqlDbType.VarChar,50),
                new SqlParameter("@pwd", SqlDbType.VarChar,50),
                new SqlParameter("@active", SqlDbType.VarChar,1),
            
                                               
            };
            objlim[0].Value = panid;
            objlim[1].Value = username;
            objlim[2].Value = pwd;
            objlim[3].Value = active;
           

            ExecuteQuery("SpInsmastercustportalcredentials", objlim);
        }
        public void Updmastercustportalcredentials(int panid, string username, string pwd, string active)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panid", SqlDbType.Int),  
                new SqlParameter("@username", SqlDbType.VarChar,50),
                new SqlParameter("@pwd", SqlDbType.VarChar,50),
                new SqlParameter("@active", SqlDbType.VarChar,1),
            
                                               
            };
            objlim[0].Value = panid;
            objlim[1].Value = username;
            objlim[2].Value = pwd;
            objlim[3].Value = active;


            ExecuteQuery("SpUpdmastercustportalcredentials", objlim);
        }
        public DataTable Getprotalcred(int panid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@panid", SqlDbType.Int) };
            objp[0].Value = panid;
            return ExecuteTable("SpGetprotalcred", objp);
        }

        //////////////////////
        public DataTable GetLikeCustomerpan(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerPANO", objp);
        }

        public DataTable GetLikeCustomergst(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomergst", objp);
        }
        public DataTable GetLikeCustomergst(string customername, string pano)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) ,
            new SqlParameter("@pano", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            objp[1].Value = pano;
            return ExecuteTable("SPLikeCustomergst", objp);
        }
        ///////////////////////
        public void UPDusdinv(int CustomerId, Char usd)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
            new SqlParameter("@customerid", SqlDbType.Int) ,
              new SqlParameter("@usd", SqlDbType.Char)  
             

            };
            objp[0].Value = CustomerId;
            objp[1].Value = usd;
           
            ExecuteQuery("SPUPDusdinv", objp);/// add me 
        }
        public DataTable GetEvent()
        {

            return ExecuteTable("SP_Events");
        }
        public DataTable GetEmpoyee()
        {

            return ExecuteTable("SP_Employeedetails");
        }
        public void InsCustomerTaskdetails(int cus_id, int Event_id, string Product, string Emp_Name, int CreateBy)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@CustomerId", SqlDbType.Int),
        new SqlParameter("@EventId", SqlDbType.Int),
        new SqlParameter("@Product", SqlDbType.VarChar,20),
        new SqlParameter("@EmployeeName", SqlDbType.VarChar,200),
        new SqlParameter("@CreatedBy", SqlDbType.Int)


    };
            objlim[0].Value = cus_id;
            objlim[1].Value = Event_id;
            objlim[2].Value = Product;
            objlim[3].Value = Emp_Name;
            objlim[4].Value = CreateBy;
            ExecuteQuery("Sp_InsTaskDetails", objlim);
        }
        public DataTable GetEmpoyeeName(string Product, int customerId)
        {
            SqlParameter[] objlim = new SqlParameter[] {
    new SqlParameter("@product", SqlDbType.VarChar,20),new SqlParameter("@customerId", SqlDbType.Int)};
            objlim[0].Value = Product;
            objlim[1].Value = customerId;
            return ExecuteTable("Sp_GetEventDeatails", objlim);
        }
        public DataTable GetEmpoyeeName()
        {

            return ExecuteTable("sp_employee");
        }
        public void ExitTrantype(string product, int customerid)
        {
            SqlParameter[] objlim = new SqlParameter[] {
new SqlParameter("@product", SqlDbType.VarChar,20)
        ,
    new SqlParameter("@customerid", SqlDbType.Int)};
            objlim[0].Value = product;
            objlim[1].Value = customerid;
            ExecuteQuery("SP_ExitEmpolee", objlim);
        }
        public DataTable GetEVentType(string product)
        {
            SqlParameter[] objlim = new SqlParameter[] {
    new SqlParameter("@product", SqlDbType.VarChar,20)};
            objlim[0].Value = product;
            return ExecuteTable("SP_eventType", objlim);
        }


        // PAN - Ledger [19-02-2024] 
        public DataTable GetLikeCustomerpantype(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerPANOtypeahead", objp);
        }
        public DataTable GetLikeCustomergst_lgd(string customername, string pano, string portname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gstin", SqlDbType.VarChar, 100) ,
            new SqlParameter("@pano", SqlDbType.VarChar, 100),
            new SqlParameter("@portname", SqlDbType.VarChar, 100)};
            objp[0].Value = customername;
            objp[1].Value = pano;
            objp[2].Value = portname;
            return ExecuteTable("SPLikeCustomergst_lgd", objp);
        }


        public DataTable GetLikeCustomerpan_gst_in(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerPANO_gst_in", objp);
        }
        public DataTable LikeCustomerid_get(int customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.Int) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerid_get", objp);
        }
        public DataTable GetLikeCustomergst_12(string customername, string pano)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) ,
            new SqlParameter("@pano", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            objp[1].Value = pano;
            return ExecuteTable("SPLikeCustomergst_12", objp);
        }

        public DataTable Getcustgridwithpantask(string PANno)
        {
            SqlParameter[] objlim = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar,50),
          };
            objlim[0].Value = PANno;
            return ExecuteTable("SPgetcustgridwithpantask", objlim);
        }

        public DataTable GetLikeCustomer4TaskDashBord(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomer4TaskDashBord", objp);
        }

        public string InsertBusinessCardInfotoCustomerContactpage(int CustomerId, string Position, string Name, string CardFileName, string Title, string desgination, string phoneno, string email)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
      new SqlParameter("@CustomerId", SqlDbType.Int) ,
      new SqlParameter("@Position", SqlDbType.Char,3) ,
      new SqlParameter("@Name", SqlDbType.VarChar,100) ,
      new SqlParameter("@CardFileName", SqlDbType.VarChar,500) ,
      new SqlParameter("@Title", SqlDbType.VarChar,3),
         new SqlParameter("@Designation", SqlDbType.VarChar,300) ,
           new SqlParameter("@PhoneNo", SqlDbType.VarChar,50),
           new SqlParameter("@email", SqlDbType.VarChar,300)

            };
            objp[0].Value = CustomerId;
            objp[1].Value = Position;
            objp[2].Value = Name;
            objp[3].Value = CardFileName;
            objp[4].Value = Title;
            objp[5].Value = desgination;
            objp[6].Value = phoneno;
            objp[7].Value = email;
            return ExecuteReader("InsertBusinessCardInfotoCustomerContactpage", objp);
        }

        public string UpdateDetailsuploadContactpage(int CustomerId, string Position, string Name, string CardFileName, string Title, string desgination, string phoneno, string email)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
      new SqlParameter("@CustomerId", SqlDbType.Int) ,
      new SqlParameter("@Position", SqlDbType.Char,3) ,
      new SqlParameter("@Name", SqlDbType.VarChar,100) ,
      new SqlParameter("@CardFileName", SqlDbType.VarChar,500) ,
      new SqlParameter("@Title", SqlDbType.VarChar,3),
         new SqlParameter("@Designation", SqlDbType.VarChar,300) ,
           new SqlParameter("@PhoneNo", SqlDbType.VarChar,50),
           new SqlParameter("@email", SqlDbType.VarChar,300)

            };
            objp[0].Value = CustomerId;
            objp[1].Value = Position;
            objp[2].Value = Name;
            objp[3].Value = CardFileName;
            objp[4].Value = Title;
            objp[5].Value = desgination;
            objp[6].Value = phoneno;
            objp[7].Value = email;
            return ExecuteReader("SPUpdateDetailsuploadContactpage", objp);
        }
        public DataTable GetLikeCustomertype4OSSIPI(string customername, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100),
            new SqlParameter("@bid", SqlDbType.Int) };
            objp[0].Value = customername;
            objp[1].Value = bid;
            return ExecuteTable("SPLikeCustomertype4OSSIPI", objp);
        }


        // Vino New for OPBal Breakup St [09-04-2024]
        public DataTable GetcheckLedgeridOB(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 200) };
            objp[0].Value = customername;
            return ExecuteTable("Sp_CustLedgidCheck", objp);
        }
        public DataTable SPSelLikewithoutLocationCity(int city)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cityport", SqlDbType.Int) };
            objp[0].Value = city;

            return ExecuteTable("SPSelLikewithoutLocationCity", objp);
        }
        public void SPInsMasterCustomerNewimagenewnew_onelhnew(string customername, string customertype, string unit, string buildingname,
                    string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode,
                    int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email,
                    string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc,
                    string impptc, string finptc, int createdby, string managmail, string managptc, int tds, string gstin, string uinno,
                    string ptc, string RCM, string Unregistered, string gstexemp, string sez, string Register, byte[] mgmtheadimg,
                    byte[] cmheadimg, byte[] expheadimg, byte[] finheadimg, byte[] impimg, int salesid, double limit, string empperiodfrom,
                    string empperiodto, string certno, double tdsemp, string SEZIgst, string livehold, string AgentState, string SezAgent)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] {

                                                       new SqlParameter("@customername", SqlDbType.VarChar, 300),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,500),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.Int),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.Int),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.Int),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@createdby",SqlDbType.Int ),
                                                       new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                       new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@tds",SqlDbType.Int),
                                                       new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                       new SqlParameter("@uinno",SqlDbType.VarChar,20),
                                                       new SqlParameter("@RCM",SqlDbType.Char,1),
                                                       new SqlParameter("@UnRegistered",SqlDbType.Char,1),
                                                       new SqlParameter("@gstexemption",SqlDbType.Char,1),
                                                       new SqlParameter("@Sez",SqlDbType.Char,1),
                                                       new SqlParameter("@Register",SqlDbType.Char,1),
                                                       new SqlParameter("@mgmtheadimg",SqlDbType.Image),
                                                       new SqlParameter("@cmheadimg",SqlDbType.Image),
                                                       new SqlParameter("@expheadimg",SqlDbType.Image),
                                                       new SqlParameter("@finheadimg",SqlDbType.Image),
                                                       new SqlParameter("@impimg",SqlDbType.Image),
                                                       new SqlParameter ("@salesid",SqlDbType.Int),
                                                       new SqlParameter("@limit",SqlDbType.Money,8),
                                                       new SqlParameter("@empperiodfrom",SqlDbType.VarChar,50),
                                                       new SqlParameter("@empperiodto",SqlDbType.VarChar,50),
                                                       new SqlParameter("@certno",SqlDbType.VarChar, 150 ),
                                                       new SqlParameter("@tdsemp",SqlDbType.Money,8 ),
                                                       new SqlParameter("@Sezexemption",SqlDbType.Char,1),
                                                       new SqlParameter("@livehold",SqlDbType.VarChar,10),
                                                       new SqlParameter("@AgentState",SqlDbType.VarChar,35),
                                                       new SqlParameter("@SezAgent",SqlDbType.VarChar,10)
            };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Value = gstin;
            objp[36].Value = uinno;
            objp[37].Value = RCM;
            objp[38].Value = Unregistered;
            objp[39].Value = gstexemp;
            objp[40].Value = sez;
            objp[41].Value = Register;
            objp[42].Value = mgmtheadimg;
            objp[43].Value = cmheadimg;
            objp[44].Value = expheadimg;
            objp[45].Value = finheadimg;
            objp[46].Value = impimg;
            objp[47].Value = salesid;
            objp[48].Value = limit;
            objp[49].Value = empperiodfrom;
            objp[50].Value = empperiodto;
            objp[51].Value = certno;
            objp[52].Value = tdsemp;
            objp[53].Value = SEZIgst;
            objp[54].Value = livehold;
            objp[55].Value = AgentState;
            objp[56].Value = SezAgent;
            ExecuteQuery("SPInsMasterCustomerNewimagenewnewONE_LHnew1", objp);

        }


        // Vino New for OPBal Breakup End [09-04-2024]  

        public DataTable CheckCustomerExit(string pano, string zip)
        {
            SqlParameter[] objp = new SqlParameter[] {
    new SqlParameter("@panno", SqlDbType.VarChar, 100), new SqlParameter("@zip", SqlDbType.VarChar, 100) };
            objp[0].Value = pano;
            objp[1].Value = zip;
            return ExecuteTable("SP_checkCustomerpin", objp);
        }

        public DataTable GetcheckLedgeridOBNew(string customername, string portname)
        {
            SqlParameter[] array = new SqlParameter[2]
            {
        new SqlParameter("@customername", SqlDbType.VarChar, 200),
        new SqlParameter("@portname", SqlDbType.VarChar, 200)
            };
            array[0].Value = customername;
            array[1].Value = portname;
            IDataParameter[] parameters = array;
            return ExecuteTable("Sp_CustLedgidNew", parameters);
        }


    }
}
