using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class RegCustomer : DBObject
    {
        public int cityid = 0;
        Masters.MasterPort Portobj = new Masters.MasterPort();
        Masters.MasterCustomer CustObj = new Masters.MasterCustomer();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public RegCustomer()
        {
            Conn = new SqlConnection(DBCS);
        }
        public enum EventType
        {
            LoginSuccess,
            LoginFailed,
            OceanExports,
            OceanImports,
            AirExports,
            AirImports,
            AccountsVouchers,
            AccountsReceipts,
            ChangePassword,
            XML
        }

       
        public void InsRegDetails(string customername, string customertype, string address, string city, string zip, string phone, string fax, string email, string contactperson)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@custname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@custtype",SqlDbType.Char,1),        
                                                                                     new SqlParameter("@addr",SqlDbType.VarChar,250), 
                                                                                     new SqlParameter("@city",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mail",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100)};

            char ctype = CustObj.CheckCustomerType(customertype);
            objp[0].Value = customername;
            objp[1].Value = ctype;
            objp[2].Value = address;
            objp[3].Value = city;
            objp[4].Value = zip;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = contactperson;
            ExecuteQuery("SPInsRegCustomer", objp);
        }

        public bool ChkRegCust(string strCustomerName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custname", SqlDbType.VarChar, 100) };
            objp[0].Value = strCustomerName;
            Dt = ExecuteTable("SPSelRegCustomer", objp);
            if (Dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public DataTable SelAllRegCus()
        {
            return ExecuteTable("SPSelAllRegCust");
        }

        public DataTable SelRefCus(string refer, string customertype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ref", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@customertype", SqlDbType.VarChar, 1) };
            objp[0].Value = refer;
            objp[1].Value = customertype;
            return ExecuteTable("SPSelRefCust", objp);
        }

        public void InsCusLoginDet(int customerid, string username, string password)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int,4),
                                                       new SqlParameter("@username", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@password", SqlDbType.VarChar, 20) };
            objp[0].Value = customerid;
            objp[1].Value = username;
            objp[2].Value = password;
            ExecuteQuery("SPInsCustLoginDet", objp);
        }

        public void DelRegCusDet(int RegID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regid", SqlDbType.Int) };
            objp[0].Value = RegID;
            ExecuteQuery("SPDelRegCustomer", objp);
        }

        public DataTable SelCusLoginDet(string username)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 50) };
            objp[0].Value = username;
            return ExecuteTable("SPSelCustLoginDet", objp);
        }
        public void UpdCusPassword(string username, string password)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@username",SqlDbType.VarChar,50),
                                                      new SqlParameter("@password",SqlDbType.VarChar,20) };
            objp[0].Value = username;
            objp[1].Value = password;
            ExecuteQuery("SPUpdCustPassword", objp);
        }

        public DataTable SelCusFIEBLInfo(int customerid, string TranType, DateTime FrmDt, DateTime ToDt)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                      new SqlParameter("@from",SqlDbType.SmallDateTime, 4),        
                                                      new SqlParameter("@to",SqlDbType.SmallDateTime, 2)};

            objp[0].Value = customerid;
            objp[1].Value = TranType;
            objp[2].Value = FrmDt;
            objp[3].Value = ToDt;
            return ExecuteTable("SPSelCustomerDetail", objp);
        }
        public DataTable GetCustomerInvoice(int intCustID, string strTrantype, DateTime datFrom, DateTime datTo)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                    new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@to",SqlDbType.SmallDateTime,4)
                                                    };
            objp[0].Value = intCustID;
            objp[1].Value = strTrantype;
            objp[2].Value = datFrom;
            objp[3].Value = datTo;
            return ExecuteTable("SPSelCustSerInvoice", objp);
        }

        public DataTable GetCustomerInvoiceAll(int intCustID, DateTime datFrom, DateTime datTo)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@from",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@to",SqlDbType.SmallDateTime,4) };
            objp[0].Value = intCustID;
            objp[1].Value = datFrom;
            objp[2].Value = datTo;
            return ExecuteTable("SPSelCustSerInvoiceAll", objp);
        }

        public string ChkBLorMBL(string dbname, string trantype, string mblno)
        {
            string BLorMBL;
            switch (trantype)
            {
                case "Ocean Export":
                    trantype = "FE";
                    break;
                case "Ocean Import":
                    trantype = "FI";
                    break;
                case "Air Export":
                    trantype = "AE";
                    break;
                case "Air Import":
                    trantype = "AI";
                    break;
            }

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Tdbname", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar, 2),
                                                       new SqlParameter("@mblno",SqlDbType.VarChar, 20) };
            objp[0].Value = dbname;
            objp[1].Value = trantype;
            objp[2].Value = mblno;
            Dt = ExecuteTable("SPCheckMblno", objp);
            if (Dt.Rows.Count > 0)
                BLorMBL = "MBL";
            else
                BLorMBL = "BL";

            return BLorMBL;
        }

        public DataTable GetNews(DateTime validity)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@validity", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = validity;
            return ExecuteTable("SPGetNewsForCust", objp);
        }

        public DataTable GetLikeCustomerReg(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 50) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerforReg", objp);
        }
        public int InsMasterNews(string title, string news, DateTime validity,char newstype,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@title",SqlDbType.VarChar,50),
                                                        new SqlParameter("@news",SqlDbType.VarChar,5000),
                                                        new SqlParameter("@validity",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@newstype",SqlDbType.Char,1),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@newsid",SqlDbType.Int,4)
                                                        };


            objp[0].Value = title;
            objp[1].Value = news;
            objp[2].Value = validity;
            objp[3].Value = newstype;
            objp[4].Value = empid;
            objp[5].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsMasterNews", objp, "@newsid");
        }
        public int InsMasterNewsWithStatus(string title, string news, DateTime validity, char newstype,char newsstatus,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@title",SqlDbType.VarChar,50),
                                                        new SqlParameter("@news",SqlDbType.VarChar,5000),
                                                        new SqlParameter("@validity",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@newstype",SqlDbType.Char,1),
                                                        new SqlParameter("@newsstatus",SqlDbType.Char,1),
                                                        new SqlParameter("@empid",SqlDbType.Int,1),
                                                        new SqlParameter("@newsid",SqlDbType.Int,4)
                                                        };


            objp[0].Value = title;
            objp[1].Value = news;
            objp[2].Value = validity;
            objp[3].Value = newstype;
            objp[4].Value = newsstatus;
            objp[5].Value = empid;
            objp[6].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsNewswithstatus", objp, "@newsid");
        }

        public void UpdMasterNews(string title, string news, DateTime validity,int empid, int newsid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@title",SqlDbType.VarChar,50),
                                                        new SqlParameter("@news",SqlDbType.VarChar,5000),
                                                        new SqlParameter("@validity",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@newsid",SqlDbType.Int,4)
                                                        };


            objp[0].Value = title;
            objp[1].Value = news;
            objp[2].Value = validity;
            objp[3].Value = empid;
            objp[4].Value = newsid;
            ExecuteQuery("SPUpdMasterNews", objp);

        }
        public void UpdMasterNewsWithStatus(string title, string news, DateTime validity,char newsstatus,int empid,int newsid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@title",SqlDbType.VarChar,50),
                                                        new SqlParameter("@news",SqlDbType.VarChar,5000),
                                                        new SqlParameter("@validity",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@newsstatus",SqlDbType.Char,1),
                                                        new SqlParameter("@empid",SqlDbType.Int,4),
                                                        new SqlParameter("@newsid",SqlDbType.Int,4)
                                                        };


            objp[0].Value = title;
            objp[1].Value = news;
            objp[2].Value = validity;
            objp[3].Value = newsstatus;
            objp[4].Value = empid;
            objp[5].Value = newsid;
            ExecuteQuery("SPUpdMasterNewswithstatus", objp);

        }


        public DataTable GetMasterNews(int newsid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@newsid", SqlDbType.Int, 4)
                                                   
                                                    };
            objp[0].Value = newsid;
            return ExecuteTable("SPSelMasterNews", objp);
        }
        public DataTable CheckValidity(DateTime validity, int newsid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@validity ", SqlDbType.SmallDateTime, 4),
                                                        new SqlParameter("@newsid",SqlDbType.Int,4)
                                                   
                                                    };
            objp[0].Value = validity;
            objp[1].Value = newsid;
            return ExecuteTable("SPGetNewsValidity", objp);
        }
        public DataTable GetRecptforCust(int custid, DateTime fromdt, DateTime todt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdt", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@todt", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = custid;
            objp[1].Value = fromdt;
            objp[2].Value = todt;
            return ExecuteTable("SPReceiptForCustLogin", objp);
        }
        public DataTable GetBLByBkgBLNo(int intCustID, string strTranType, string strBLBkgNo, string strOptn)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@optn", SqlDbType.VarChar, 2)};
            objp[0].Value = intCustID;
            objp[1].Value = strTranType;
            objp[2].Value = strBLBkgNo;
            objp[3].Value = strOptn;
            return ExecuteTable("SPSelCustBLInfoByblno", objp);
        }
        public DataTable GetCustIDsByGroupID(int intGroupID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupid", SqlDbType.Int) };
            objp[0].Value = intGroupID;
            return ExecuteTable("SPSelCustIDsByGroupid", objp);
        }
        public void InsWebCustLogDtl(int intGroupID,EventType eType,DateTime dtmEDateTime,string strRemarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupid", SqlDbType.Int),
                                                       new SqlParameter("@event",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@edatetime",SqlDbType.DateTime,8),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,50)};
            objp[0].Value = intGroupID;
            objp[1].Value = GetLogEventID(eType);
            objp[2].Value = dtmEDateTime;
            objp[3].Value = strRemarks;
            ExecuteQuery("SPInsWebCustLogDtl",objp);
        }
        public short GetLogEventID(EventType etypeTemp)
        {
            short shrtTemp = 0;
            switch (etypeTemp)
            {
                case EventType.LoginSuccess:
                    shrtTemp = 1;
                    break;
                case EventType.LoginFailed:
                    shrtTemp = 2;
                    break;
                case EventType.OceanExports:
                    shrtTemp = 3;
                    break;
                case EventType.OceanImports:
                    shrtTemp = 4;
                    break;
                case EventType.AirExports:
                    shrtTemp = 5;
                    break;
                case EventType.AirImports:
                    shrtTemp = 6;
                    break;
                case EventType.AccountsVouchers:
                    shrtTemp = 7;
                    break;
                case EventType.AccountsReceipts:
                    shrtTemp = 8;
                    break;
                case EventType.ChangePassword:
                    shrtTemp = 9;
                    break;
                case EventType.XML:
                    shrtTemp = 10;
                    break;
            }
            return shrtTemp;
        }
        public DataTable GetMasterNewsempid(int empid, int newsid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                        new SqlParameter("@newsid", SqlDbType.Int, 4)
                                                   
                                                    };
            objp[0].Value = empid;
            objp[1].Value = newsid;
            return ExecuteTable("SPSelMasterNews4empid", objp);
        }
        public DataTable CusloginBookingStatus(string Bookingno, int Webgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
                new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                new SqlParameter("@Webgroupid",SqlDbType.Int)
            };
            objp[0].Value = Bookingno;
            objp[1].Value = Webgroupid;
            return ExecuteTable("SPCusloginBookingStatus", objp);
        }
    }
}
