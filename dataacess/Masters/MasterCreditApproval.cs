using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterCreditApproval : DBObject
    {
        DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterPort PortObj = new DataAccess.Masters.MasterPort();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterCreditApproval()
        {
            Conn = new SqlConnection(DBCS);
        }


        public void InsertMasterCreditApp(int groupid, int category, string pan, string regn, DateTime regndate, DateTime incorpdate, string docsrecd, string ptc, string phone, string mobile, string email, int clienttype, string volume, string types, double revenue, string about, int creditdays, double creditamt, int creditype, int owner, int salesman, string remarks, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@category",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@pan",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@regn",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regndate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@incorpdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@docsrecd",SqlDbType.VarChar,100), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@mobile",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@clienttype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@volume",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@types",SqlDbType.VarChar,4),
                                                                                     new SqlParameter("@revenue",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@about",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@creditamt",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@creditype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@owner",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@salesman",SqlDbType.Int),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1)
                                                                                     };

            objp[0].Value = groupid;
            objp[1].Value = category;
            objp[2].Value = pan;
            objp[3].Value = regn;
            objp[4].Value = regndate;
            objp[5].Value = incorpdate;
            objp[6].Value = docsrecd;
            objp[7].Value = ptc;
            objp[8].Value = phone;
            objp[9].Value = mobile;
            objp[10].Value = email;
            objp[11].Value = clienttype;
            objp[12].Value = volume;
            objp[13].Value = types;
            objp[14].Value = revenue;
            objp[15].Value = about;
            objp[16].Value = creditdays;
            objp[17].Value = creditamt;
            objp[18].Value = creditype;
            objp[19].Value = owner;
            objp[20].Value = salesman;
            objp[21].Value = remarks;
            objp[22].Value = division;
            ExecuteQuery("SPInsMasterCreditApp", objp);

        }




        public void InsertMasterCreditReqDetails(int canid, string product, decimal camount, decimal cdays, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@canid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@product",SqlDbType.VarChar,2),        
                                                                                     new SqlParameter("@camount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@cdays",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1)};

            objp[0].Value = canid;
            objp[1].Value = product;
            objp[2].Value = camount;
            objp[3].Value = cdays;
            objp[4].Value = division;
            ExecuteQuery("SPInsMasterCreditReqDetails", objp);

        }

        public void UpdMasterCreditApp(int groupid, int category, string pan, string regn, DateTime regndate, DateTime incorpdate, string docsrecd, string ptc, string phone, string mobile, string email, int clienttype, string volume, string types, double revenue, string about, int creditdays, double creditamt, int creditype, int owner, int salesman, string remarks, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@category",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@pan",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@regn",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regndate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@incorpdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@docsrecd",SqlDbType.VarChar,100), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@mobile",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@clienttype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@volume",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@types",SqlDbType.VarChar,4),
                                                                                     new SqlParameter("@revenue",SqlDbType.Money,8), 
                                                                                      new SqlParameter("@about",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@creditamt",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@creditype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@owner",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@salesman",SqlDbType.Int),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1)};

            objp[0].Value = groupid;
            objp[1].Value = category;
            objp[2].Value = pan;
            objp[3].Value = regn;
            objp[4].Value = regndate;
            objp[5].Value = incorpdate;
            objp[6].Value = docsrecd;
            objp[7].Value = ptc;
            objp[8].Value = phone;
            objp[9].Value = mobile;
            objp[10].Value = email;
            objp[11].Value = clienttype;
            objp[12].Value = volume;
            objp[13].Value = types;
            objp[14].Value = revenue;
            objp[15].Value = about;
            objp[16].Value = creditdays;
            objp[17].Value = creditamt;
            objp[18].Value = creditype;
            objp[19].Value = owner;
            objp[20].Value = salesman;
            objp[21].Value = remarks;
            objp[22].Value = division;
            ExecuteQuery("SPUpdMasterCreditApp", objp);

        }

        public string UpdMasterCApp(int groupid, string can, DateTime recdon, int daysfh, double amtfh, int typefh, char appfh, int dayscoo, double amtcoo, int typecoo, char appcoo, int daysmd, double amtmd, int typemd, char appmd)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),   
                                                                                     new SqlParameter("@recdon",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@daysfh",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@amtfh",SqlDbType.Money,8),
                                                                                     new SqlParameter("@typefh",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@appfh",SqlDbType.Char,1),
                                                                                     new SqlParameter("@dayscoo",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@amtcoo",SqlDbType.Money,8),
                                                                                     new SqlParameter("@typecoo",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@appcoo",SqlDbType.Char,1),        
                                                                                     new SqlParameter("@daysmd",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@amtmd",SqlDbType.Money,8),
                                                                                     new SqlParameter("@typemd",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@appmd",SqlDbType.Char,1)};

            objp[0].Value = groupid;
            objp[1].Value = recdon;
            objp[2].Value = daysfh;
            objp[3].Value = amtfh;
            objp[4].Value = typefh;
            objp[5].Value = appfh;
            objp[6].Value = dayscoo;
            objp[7].Value = amtcoo;
            objp[8].Value = typecoo;
            objp[9].Value = appcoo;
            objp[10].Value = daysmd;
            objp[11].Value = amtmd;
            objp[12].Value = typemd;
            objp[13].Value = appmd;

            return ExecuteReader("SPUpdMasterCApproval", objp);

        }


        public string UpdMasterCAppNew(int groupid, string can, DateTime recdon, int daysfh, double amtfh, int typefh, char appfh, int dayscoo, double amtcoo, int typecoo, char appcoo, int daysmd, double amtmd, int typemd, char appmd,int appby,double bappamount,int bappdays,int apptype,int divid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),   
                                                                                     new SqlParameter("@recdon",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@daysfh",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@amtfh",SqlDbType.Money,8),
                                                                                     new SqlParameter("@typefh",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@appfh",SqlDbType.Char,1),
                                                                                     new SqlParameter("@dayscoo",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@amtcoo",SqlDbType.Money,8),
                                                                                     new SqlParameter("@typecoo",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@appcoo",SqlDbType.Char,1),        
                                                                                     new SqlParameter("@daysmd",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@amtmd",SqlDbType.Money,8),
                                                                                     new SqlParameter("@typemd",SqlDbType.TinyInt,1), 
                                                                                     new SqlParameter("@appmd",SqlDbType.Char,1),
                                                                                     new SqlParameter("@appby",SqlDbType.Int,4),
                                                                                     new SqlParameter("@bappamount",SqlDbType.Money ,8),
                                                                                     new SqlParameter("@bappdays",SqlDbType.TinyInt ,1),
                                                                                     new SqlParameter ("@apptype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter ("@divid",SqlDbType.TinyInt,1)};

            objp[0].Value = groupid;
            objp[1].Value = recdon;
            objp[2].Value = daysfh;
            objp[3].Value = amtfh;
            objp[4].Value = typefh;
            objp[5].Value = appfh;
            objp[6].Value = dayscoo;
            objp[7].Value = amtcoo;
            objp[8].Value = typecoo;
            objp[9].Value = appcoo;
            objp[10].Value = daysmd;
            objp[11].Value = amtmd;
            objp[12].Value = typemd;
            objp[13].Value = appmd;
            objp[14].Value = appby ;
            objp[15].Value = bappamount ;
            objp[16].Value = bappdays ;
            objp[17].Value = apptype;
            objp[18].Value = divid ;
            return ExecuteReader("SPUpdMasterCApprovalNew", objp);

        }



        public DataTable RetrieveCreditAppDts(int groupid,int division)
        {
           SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)};

            objp[0].Value = groupid;
            objp[1].Value = division;
            return ExecuteTable("SPGetMasterCreditAppDts", objp);

        }

        public DataTable GetAppAmtandDays4OutstdCust(int custid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)};

            objp[0].Value = custid;
            objp[1].Value = division;
            return ExecuteTable("SPGetAppAmtandDays4OutstdCust", objp);

        }

        public DataSet RetrieveCreditAppDtsNew(int groupid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)};

            objp[0].Value = groupid;
            objp[1].Value = division;
            return ExecuteDataSet("SPGetMasterCreditAppDtsNew", objp);

        }

        public DataTable SelCreditAppDetails(int groupid, int division,string appper)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@appper", SqlDbType.VarChar, 3)};

            objp[0].Value = groupid;
            objp[1].Value = division;
            objp[2].Value = appper;
            return ExecuteTable("SPGetMasterCreditAppDetails", objp);

        }
        public DataTable RetrieveCreditReqDetails(int canid,int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@canid", SqlDbType.Int, 4),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)};

            objp[0].Value = canid;
            objp[1].Value = division;
            return ExecuteTable("SPSelMasterCreditReqDetails", objp);

        }
        public DataTable GetLikeCustomerAllWGroupid(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerAllWGroupid", objp);
        }

        public DataTable RetrieveCApprovalDts(int groupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4) };

            objp[0].Value = groupid;

            return ExecuteTable("SPGetMasterCApprovalDts", objp);

        }

        public string CheckMCreditCanExist(string can)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@can", SqlDbType.VarChar, 25) };
            objp[0].Value = can;
            return ExecuteReader("SPCheckMCreditCANExist", objp);
        }
        public DataTable MCrdAppToShowGrd(int empid,int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)};
            objp[0].Value = empid;
            objp[1].Value = division;
            return ExecuteTable("SPSelMCrdAppToShowGrd",objp);
        }

        public DataTable MCrdAppToShowGrdNew(int empid,int branch, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@branch", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)};
            objp[0].Value = empid;
            objp[1].Value = branch ;
            objp[2].Value = division;
            return ExecuteTable("SPSelMCrdAppToShowGrdNew", objp);
        }


        public DataTable GetLikeCustomerMBLNotReleased(string customername, int bid, string ctype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@Custtype", SqlDbType.VarChar,1)};
            objp[0].Value = customername;
            objp[1].Value = bid;
            objp[2].Value = ctype;
            return ExecuteTable("SPLikeCustomerMBLNotReleased", objp);
        }
        public DataTable GetContainerDetails(int intJbNo, string strBLNo, int intBranchid, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt),
                                                          new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = intJbNo;
            objp[1].Value = strBLNo;
            objp[2].Value = intBranchid;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPFEContainers", objp);
        }

        public DataTable GetFEJobInfo(int intjbno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno", SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = intjbno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFEQryJobinfo", objp);
        }



        
        public DataTable GetUnapprovedCust(int option, int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@option",SqlDbType.Int,1),
                new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                new SqlParameter("@divid",SqlDbType.TinyInt,1)
            };

            objp[0].Value = option;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetunapprovedcustomer", objp);
        }

        public DataTable GetAmountLmt4CrdtApp(int bid, int divisionid, int empid,int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@bid",SqlDbType.Int,4),
                                new SqlParameter("@divisionid",SqlDbType.TinyInt),
                                new SqlParameter("@empid",SqlDbType.Int,4),
                                 new SqlParameter("@customerid",SqlDbType.Int,4)
                            };
            objp[0].Value = bid;
            objp[1].Value = divisionid;
            objp[2].Value = empid;
            objp[3].Value = customerid;
            return ExecuteTable("SPGetAmountLmt4CrdtApp", objp);
        }



        //KUMAR
        public DataTable RetrieveCApprovalDtsNew(int groupid, int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt)
                                                                };

            objp[0].Value = groupid;
            objp[1].Value = divid;

            return ExecuteTable("SPGetMasterCApprovalDtsNew", objp);

        }
        public DataTable GetApprovedListgrd(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.Int)
                                                                };

            objp[0].Value = bid;

            return ExecuteTable("SPGetCrdt4CanlGrd", objp);

        }
        public void updCancelcreditrequest(int bid, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};

            objp[0].Value = bid;
            objp[1].Value = customerid;
            ExecuteQuery("SPUpdCancelCredit", objp);

        }

        public void InsCreditCancel(int customerid, int creditdays, double creditamount, DateTime date, int empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@creditdays",SqlDbType.Int,4),        
                                                                                     new SqlParameter("@creditamount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@date",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@empid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1)};

            objp[0].Value = customerid;
            objp[1].Value = creditdays;
            objp[2].Value = creditamount;
            objp[3].Value = date;
            objp[4].Value = empid;
            objp[5].Value = branchid;
            ExecuteQuery("SPInsCreditCancel", objp);

        }

        //Manoj
        public DataTable GetCustomerRate()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPGetCustomerRate", objp);
        }
         

        //RAj

        public void UpdMasterCreditApprovalCUSTLIMITS(int CUSTID, int BID, int DIVISIONID, int EXLIMIT, int OVERDUE, string EXMODE)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@custid",SqlDbType.Int,4),
                  new SqlParameter("@bid",SqlDbType.Int,4),
                   new SqlParameter("@divisionid",SqlDbType.Int,4),
                    new SqlParameter("@exlimit",SqlDbType.Int,4),
                     new SqlParameter("@overdue",SqlDbType.Int,4),
                     new SqlParameter("@exmode",SqlDbType.Char,1)};

            objp[0].Value = CUSTID;
            objp[1].Value = BID;
            objp[2].Value = DIVISIONID;
            objp[3].Value = EXLIMIT;
            objp[4].Value = OVERDUE;
            objp[5].Value = EXMODE;
            ExecuteQuery("SPUpdMasterCreditApprovalCUSTLIMITS", objp);


        }
        public DataTable GetCustomerRateFromType(string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@type",SqlDbType.Char,1) };
            objp[0].Value = type;
            return ExecuteTable("SPGetCustomerRateFromType", objp);
        }

        public DataTable GetCustomerRateFromTypeandrating(string type,string rating)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type", SqlDbType.Char, 1),
                                                       new SqlParameter("@rating",SqlDbType.Char,1)
                                                     };
            objp[0].Value = type;
            objp[1].Value = rating;
            return ExecuteTable("SPGetCustomerRateFromTypeandRating", objp);
        }

        public void InsCustomerRate( double from,double to ,string grade,string type, string fix)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@from",SqlDbType.Money),
                                                                                     new SqlParameter("@to",SqlDbType.Money),        
                                                                                     new SqlParameter("@grade",SqlDbType.Char,1), 
                                                                                     new SqlParameter("@type",SqlDbType.Char,1),
                                                                                     new SqlParameter("@fixed",SqlDbType.Char,1)};

            objp[0].Value = from;
            objp[1].Value = to;
            objp[2].Value = grade;
            objp[3].Value = type;
            objp[4].Value = fix;
            ExecuteQuery("SPInsCustomerRate", objp);
        }

        public void UpdCustomerRate(double from, double to, string grade, string type, double oldfrom, double oldto, string oldgrade, string oldtype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@from",SqlDbType.Money),
                                                                                     new SqlParameter("@to",SqlDbType.Money),        
                                                                                     new SqlParameter("@grade",SqlDbType.Char,1), 
                                                                                     new SqlParameter("@type",SqlDbType.Char,1),
                                                                                     new SqlParameter("@oldfrom",SqlDbType.Money),
                                                                                     new SqlParameter("@oldto",SqlDbType.Money),        
                                                                                     new SqlParameter("@oldgrade",SqlDbType.Char,1), 
                                                                                     new SqlParameter("@oldtype",SqlDbType.Char,1)};

            objp[0].Value = from;
            objp[1].Value = to;
            objp[2].Value = grade;
            objp[3].Value = type;
            objp[4].Value = oldfrom;
            objp[5].Value = oldto;
            objp[6].Value = oldgrade;
            objp[7].Value = oldtype;
            ExecuteQuery("SPUpdCustomerRate", objp);
        }

        public void DelCustomerRate(double from, double to, string grade, string type)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@oldfrom",SqlDbType.Money),
                                                                                     new SqlParameter("@oldto",SqlDbType.Money),        
                                                                                     new SqlParameter("@oldgrade",SqlDbType.Char,1), 
                                                                                     new SqlParameter("@oldtype",SqlDbType.Char,1)};

            objp[0].Value = from;
            objp[1].Value = to;
            objp[2].Value = grade;
            objp[3].Value = type;
            ExecuteQuery("SPDelCustomerRate", objp);

        }

        public DataTable GetDivision()
        {
            return ExecuteTable("SPSelAllDivision");
        }

        public int CanCreditId(int gruopid, int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@canid", SqlDbType.Int),
                                                              new SqlParameter("@division", SqlDbType.TinyInt)
                                    
            };

            objp[0].Value = gruopid;
            objp[1].Value = divid;

            return int.Parse(ExecuteReader("GetCanCreditId", objp));

        }

        public void InsertMasterCreditReqDetailsNew(int canid, string product, decimal camount, decimal cdays)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@canid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@product",SqlDbType.VarChar,2),        
                                                                                     new SqlParameter("@camount",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@cdays",SqlDbType.TinyInt,1)
                                                                                     };

            objp[0].Value = canid;
            objp[1].Value = product;
            objp[2].Value = camount;
            objp[3].Value = cdays;

            ExecuteQuery("SPInsMasterCreditReqDetails", objp);

        }

        public DataTable GetCreditCudGrupname(string Sname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@groupname",SqlDbType.VarChar,100)
                        };
            objp[0].Value = Sname;

            return ExecuteTable("SpGetCreditCusGroupName", objp);
        }


        public DataTable SPGETEmp(int empid, int DIVISIONID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,4),
                  new SqlParameter("@division",SqlDbType.Int,4)
                  };
            objp[0].Value = empid;
            objp[1].Value = DIVISIONID;

            return ExecuteTable("SPGETEmp", objp);//, "@empid");
        }



        //MUTHU

        public int get_creditapproval_homecount(int branchid, int salesperson)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@branchid",SqlDbType.Int,4),
                  new SqlParameter("@salesper",SqlDbType.Int,4)
                  };
            objp[0].Value = branchid;
            objp[1].Value = salesperson;
            return Convert.ToInt32(ExecuteReader("Sp_getCreditrequestcount4sales", objp));//, "@empid");
        }

        public DataTable get_creditapproval_home(int branchid, int salesperson)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@branchid",SqlDbType.Int,4),
                  new SqlParameter("@salesper",SqlDbType.Int,4)
                  };
            objp[0].Value = branchid;
            objp[1].Value = salesperson;
            return ExecuteTable("sp_getcreditrequestsales_home", objp);//, "@empid");
        }

        // yuvaraj 

        public DataTable mastercustomercreditrequest(double amount, int days, int limit, int Due, string mode, string panno, string panname, int div, int bid, int group, int owner, string branch)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@Amount",SqlDbType.Money),
                  new SqlParameter("@days",SqlDbType.Int,4),
                  new SqlParameter("@Limit",SqlDbType.Int,4),
                  new SqlParameter("@DUe",SqlDbType.Int,4),
                  new SqlParameter("@mode",SqlDbType.VarChar,1),
                  new SqlParameter("@panno",SqlDbType.VarChar,50),
                  new SqlParameter("@panname",SqlDbType.VarChar,50),
                   new SqlParameter("@div",SqlDbType.Int),
                  new SqlParameter("@bid",SqlDbType.Int),
                   new SqlParameter("@group",SqlDbType.Int),
                    new SqlParameter("@owner",SqlDbType.Int),
                   new SqlParameter("@branch",SqlDbType.VarChar,50),

                  };
            objp[0].Value = amount;
            objp[1].Value = days;
            objp[2].Value = limit;
            objp[3].Value = Due;
            objp[4].Value = mode;
            objp[5].Value = panno;
            objp[6].Value = panname;
            objp[7].Value = div;
            objp[8].Value = bid;
            objp[9].Value = group;
            objp[10].Value = owner;
            objp[11].Value = branch;
            return ExecuteTable("sp_mastercustomercreditrequest", objp);//, "@empid");
        }
        // yuvaraj 
        public DataTable selgridMasterCreditApp4Prod(int groupid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@division", SqlDbType.TinyInt, 1)
            };

            objp[0].Value = groupid;
            objp[1].Value = division;

            return ExecuteTable("selgridMasterCreditApp4Prod", objp);
        }
        public DataTable delgridMasterCreditApp4Prod(int groupid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                       new SqlParameter("@division", SqlDbType.Int,4)
            };

            objp[0].Value = groupid;
            objp[1].Value = division;

            return ExecuteTable("delgridMasterCreditApp4Prod", objp);

        }

        public void UpdMasterCreditApp(int groupid, int category, string pan, string regn, DateTime regndate, DateTime incorpdate, string docsrecd, string ptc, string phone, string mobile, string email, int clienttype, string volume, string types, double revenue, string about, int creditdays, double creditamt, int creditype, int owner, int salesman, string remarks, int division, int producttype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@category",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@pan",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@regn",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regndate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@incorpdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@docsrecd",SqlDbType.VarChar,100), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@mobile",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@clienttype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@volume",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@types",SqlDbType.VarChar,4),
                                                                                     new SqlParameter("@revenue",SqlDbType.Money,8), 
                                                                                      new SqlParameter("@about",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@creditamt",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@creditype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@owner",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@salesman",SqlDbType.Int),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@producttype",SqlDbType.TinyInt,1)};

            objp[0].Value = groupid;
            objp[1].Value = category;
            objp[2].Value = pan;
            objp[3].Value = regn;
            objp[4].Value = regndate;
            objp[5].Value = incorpdate;
            objp[6].Value = docsrecd;
            objp[7].Value = ptc;
            objp[8].Value = phone;
            objp[9].Value = mobile;
            objp[10].Value = email;
            objp[11].Value = clienttype;
            objp[12].Value = volume;
            objp[13].Value = types;
            objp[14].Value = revenue;
            objp[15].Value = about;
            objp[16].Value = creditdays;
            objp[17].Value = creditamt;
            objp[18].Value = creditype;
            objp[19].Value = owner;
            objp[20].Value = salesman;
            objp[21].Value = remarks;
            objp[22].Value = division;
            objp[23].Value = producttype;
            ExecuteQuery("SPUpdMasterCreditApp4prod", objp);

        }
        public DataTable updateCreditapprovalproduct(int customerid, int type, int creditdays, int appdays, double appamount, DateTime appon, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@customerid",SqlDbType.Int),
                  new SqlParameter("@type",SqlDbType.Int,4),
                  new SqlParameter("@pcreditdays",SqlDbType.Int,4),
                  new SqlParameter("@appdays",SqlDbType.Int,4),
                  new SqlParameter("@appamt",SqlDbType.Money),
                  new SqlParameter("@appon",SqlDbType.VarChar,50),
                  new SqlParameter("@empid",SqlDbType.VarChar,50),               

                  };
            objp[0].Value = customerid;
            objp[1].Value = type;
            objp[2].Value = creditdays;
            objp[3].Value = appdays;
            objp[4].Value = appamount;
            objp[5].Value = appon;
            objp[6].Value = empid;

            return ExecuteTable("sp_updateCreditapprovalproduct", objp);//, "@empid");
        }

        public DataTable Getdetailscreditapproval(int customerid, int Div_ID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@customerid",SqlDbType.Int),
                  new SqlParameter("@division",SqlDbType.Int,4)};
            objp[0].Value = customerid;
            objp[1].Value = Div_ID;


            return ExecuteTable("sp_getdetailscreditapproval", objp);
        }
        // approval 28/12/2022 yuvaraj
        public void UpdMasterCreditAppDetailsNew(int customerid, int pcanid, decimal appdays, decimal appamount, int appby, int exmp, string exmode, int ovrdue)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                    new SqlParameter("@pcanid",SqlDbType.Int),
                                                                                    new SqlParameter("@appdays",SqlDbType.Int),
                                                                                    new SqlParameter("@appamount",SqlDbType.Money,8),                                                                                  
                                                                                    new SqlParameter("@appby",SqlDbType.Int),
                                                                                    new SqlParameter("@exmp",SqlDbType.Int),   
                                                                                    new SqlParameter("@exmode",SqlDbType.VarChar,1),
                                                                                    new SqlParameter("@ovrdue",SqlDbType.Int),
                                                                                     };

            objp[0].Value = customerid;
            objp[1].Value = pcanid;
            objp[2].Value = appdays;
            objp[3].Value = appamount;
            objp[4].Value = appby;
            objp[5].Value = exmp;
            objp[6].Value = exmode;
            objp[7].Value = ovrdue;
            ExecuteQuery("SPInsertCreditApproval4prod", objp);

        }
        //newly added for credit reequest prduct type

        public void InsertMasterCreditApp(int groupid, int category, string pan, string regn, DateTime regndate, DateTime incorpdate, string docsrecd, string ptc, string phone, string mobile, string email, int clienttype, string volume, string types, double revenue, string about, int creditdays, double creditamt, int creditype, int owner, int salesman, string remarks, int division, int producttype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@category",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@pan",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@regn",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regndate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@incorpdate",SqlDbType.SmallDateTime,4),
                                                                                     new SqlParameter("@docsrecd",SqlDbType.VarChar,100), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@mobile",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@clienttype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@volume",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@types",SqlDbType.VarChar,4),
                                                                                     new SqlParameter("@revenue",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@about",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@creditdays",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@creditamt",SqlDbType.Money,8), 
                                                                                     new SqlParameter("@creditype",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@owner",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@salesman",SqlDbType.Int),
                                                                                     new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1),
                                                                                      new SqlParameter("@producttype",SqlDbType.TinyInt,1)
                                                                                     };

            objp[0].Value = groupid;
            objp[1].Value = category;
            objp[2].Value = pan;
            objp[3].Value = regn;
            objp[4].Value = regndate;
            objp[5].Value = incorpdate;
            objp[6].Value = docsrecd;
            objp[7].Value = ptc;
            objp[8].Value = phone;
            objp[9].Value = mobile;
            objp[10].Value = email;
            objp[11].Value = clienttype;
            objp[12].Value = volume;
            objp[13].Value = types;
            objp[14].Value = revenue;
            objp[15].Value = about;
            objp[16].Value = creditdays;
            objp[17].Value = creditamt;
            objp[18].Value = creditype;
            objp[19].Value = owner;
            objp[20].Value = salesman;
            objp[21].Value = remarks;
            objp[22].Value = division;
            objp[23].Value = producttype;
            ExecuteQuery("SPInsMasterCreditApp4prod", objp);

        }


        //
        // yuvaraj 16/03/2023
        public DataTable sp_getdetailcustomerpan(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] {
                  new SqlParameter("@customername",SqlDbType.VarChar,50)
            };
            objp[0].Value = @customername;



            return ExecuteTable("sp_getdetailcustomerpan", objp);
        }
    }
}
