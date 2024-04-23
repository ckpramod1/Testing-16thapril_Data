using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterChequeReq_App : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterChequeReq_App()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetChequeRequest(string type,string trantype, int bid,int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = divid ;
            return ExecuteTable("SPGetChequeRequestlv", objp);
            //return ExecuteTable("SPGetChequeRequest", objp);

        }
        public void UpdChequeRequest(int vouno, int vouyear, string trantype, int bid, int reqby,string type,char pmtmode,string pmtRemarks,string favname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@reqby", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar , 2),
                                                       new SqlParameter("@pmtmode",SqlDbType.Char ,1),
                                                       new SqlParameter("@pmtremarks",SqlDbType.VarChar,100),
                                                       new SqlParameter("@favname",SqlDbType.VarChar,100)
                                                        };

            
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = reqby;
            objp[5].Value = type ;
            objp[6].Value = pmtmode;
            objp[7].Value = pmtRemarks;
            objp[8].Value = favname ;
            ExecuteQuery("SPUpdChequeRequest", objp);
        }


        //--------------------------APPROVAL------------------------------------------------------

        public DataTable GetChequeApproval(string type,string trantype, int divid,int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = divid;
            objp[3].Value = bid;
            return ExecuteTable("SPGetChequeApproval", objp);
        }

        public void UpdChequeApproval4BrHead(int vouno, int vouyear, string trantype, int bid, int appby,string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@appby", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar, 2)

            };

            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = appby;
            objp[5].Value = type ;
            ExecuteQuery("SPUpdChequeApproval4BrHead", objp);
        }
        public void UpdChequeApproval4Co(int vouno, int vouyear, string trantype, int bid, int appby, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@appby", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar, 2)

            };

            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = appby;
            objp[5].Value = type;
            ExecuteQuery("SPUpdChequeApproval4Co", objp);
        }

        public void UpdChequeApproval4Rcpt(int vouno,char vtype,int vouyear, int bid, int appby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vtype",SqlDbType.Char,1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@appby", SqlDbType.Int)

            };

            objp[0].Value = vouno;
            objp[1].Value = vtype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = appby;
            ExecuteQuery("SPUpdChequeApproval4Rcpt", objp);
        }

        //  For Report
        public DataTable GetPendingPayment4ChqReq(string type, string trantype, int bid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@empid", SqlDbType.Int )};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = empid;
            return ExecuteTable("SPGetPendingPayment4ChqReqTemp", objp);
        }


        public DataTable GetPendingPayment4ChqApp(string type, string trantype, int bid, int divid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt),
                                                       new SqlParameter("@empid", SqlDbType.Int  )};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = divid;
            objp[4].Value = empid;
            return ExecuteTable("SPGetPendingPayment4ChqAppTemp", objp);
        }


        //Check PAN# for Cheque Approve  START KUMAR
        public DataTable GetVendorPanno4Cust(int vouno, int vouyear, string type, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                       new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt)
                                                      };

            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = type;
            objp[3].Value = bid;
            return ExecuteTable("SPSelCustomerPanno", objp);
        }


        public DataTable GetVendorPanno4CustPro(int vouno, int vouyear, string type, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                       new SqlParameter("@type",SqlDbType.VarChar ,3),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt)
                                                      };

            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = type;
            objp[3].Value = bid;
            return ExecuteTable("SPSelCustomerPanno4ProVou", objp);
        }

        //Check PAN# for Cheque Approve  END KUMAR


       
        public int ChecqueRequestDecline(int vouno, int vouyear, string trantype, int bid, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@type", SqlDbType.VarChar , 2),
                                                       new SqlParameter("@chq",SqlDbType.TinyInt)
            };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = type;
            objp[5].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPChequeRequestDecline", objp, "@chq");

        }

        //ARUN

        //public DataTable GetChequeRequest(string trantype, int bid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { 
        //                                               new SqlParameter("@trantype",SqlDbType.VarChar ,2),
        //                                               new SqlParameter("@bid", SqlDbType.Int)
        //    };


        //    objp[0].Value = trantype;
        //    objp[1].Value = bid;

        //    return ExecuteTable("SPGetChequeRequest", objp);
        //}
        public DataSet GetCoutForRequest(string trantype, int did, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@trantype", SqlDbType.VarChar,2),
                new SqlParameter("@divid", SqlDbType.Int),
                 new SqlParameter("@branchid", SqlDbType.Int)
            };
            objp[0].Value = trantype;
            objp[1].Value = did;
            objp[2].Value = branchid;
            return ExecuteDataSet("SPGetChequeApprovalCounts", objp);
        }


        public DataTable GetCOApproval(string type, string trantype, int divid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = divid;
            objp[3].Value = bid;
            return ExecuteTable("SPGetCOCChequeReqApp", objp);


        }



        public DataTable GetPendingPayment4ChqReqVouyearwise(string type, string trantype, int bid, int empid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int,4)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = empid;
            objp[4].Value = vouyear;

            return ExecuteTable("SPGetPendingPayment4ChqReqTempVoucheryearwise", objp);
        }


        public DataTable GetChequeApprovalVouyearwise(string type, string trantype, int divid, int bid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@vyear", SqlDbType.Int,4)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = divid;
            objp[3].Value = bid;
            objp[4].Value = vouyear;

            return ExecuteTable("SPGetChequeApprovalVouyearwise", objp);
        }

        public void COCDecline(int vouno, int vouyear, string trantype, int bid, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@type", SqlDbType.VarChar , 2)
            };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = type;
            ExecuteQuery("SPCODecline", objp);

        }
        public DataTable GetChequeRequestVouyearwise(string type, string trantype, int bid, int divid, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt),
                                                       new SqlParameter("@vouyear", SqlDbType.Int,4)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = divid;
            objp[4].Value = vouyear;

            return ExecuteTable("SPGetChequeRequestVouyearwise", objp);
        }
        public void UpdChequeApproval4Rcptnew(int vouno, string vtype, int vouyear, int bid, int appby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vtype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@appby", SqlDbType.Int)

            };

            objp[0].Value = vouno;
            objp[1].Value = vtype;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = appby;
            ExecuteQuery("SPUpdChequeApproval4Rcpt", objp);
        }
        // Vino [22-10-2023]
        public DataTable GetChequeRequestNewVou(string type, string trantype, int bid, int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = bid;
            objp[3].Value = divid;
            return ExecuteTable("SPGetChequeRequestNewVou", objp);
        }
        public void UpdChequeRequestNewVou(int vouno, int vouyear, string trantype, int bid, int reqby, string type, char pmtmode, string pmtRemarks, string favname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@reqby", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar , 2),
                                                       new SqlParameter("@pmtmode",SqlDbType.Char ,1),
                                                       new SqlParameter("@pmtremarks",SqlDbType.VarChar,100),
                                                       new SqlParameter("@favname",SqlDbType.VarChar,100)
                                                        };


            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = reqby;
            objp[5].Value = type;
            objp[6].Value = pmtmode;
            objp[7].Value = pmtRemarks;
            objp[8].Value = favname;
            ExecuteQuery("SPUpdChequeRequestNewVou", objp);
        }
        public DataTable GetChequeApprovalNewVou(string type, string trantype, int divid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@type",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2),
                                                       new SqlParameter("@divid", SqlDbType.TinyInt),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt)};

            objp[0].Value = type;
            objp[1].Value = trantype;
            objp[2].Value = divid;
            objp[3].Value = bid;
            return ExecuteTable("SPGetChequeApprovalNewVou", objp);
        }

        public void UpdChequeApproval4BrHeadNewVou(int vouno, int vouyear, string trantype, int bid, int appby, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@appby", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar, 2)

            };

            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = appby;
            objp[5].Value = type;
            ExecuteQuery("SPUpdChequeApproval4BrHeadNewVou", objp);
        }
        public void UpdChequeApproval4CoNewVou(int vouno, int vouyear, string trantype, int bid, int appby, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno",SqlDbType.Int,4),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 50),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@appby", SqlDbType.Int),
                                                       new SqlParameter("@type", SqlDbType.VarChar, 2)

            };

            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = appby;
            objp[5].Value = type;
            ExecuteQuery("SPUpdChequeApproval4CoNewVou", objp);
        }
    }
}
