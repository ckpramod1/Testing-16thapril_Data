using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DashBoard
{
   public class LeftFrame : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }


        public LeftFrame()
        {
            Conn = new SqlConnection(DBCS);             
        }

        public int GetQuotPendingApproval(string strTranType,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
            objp[0].Value = branchid;
            objp[1].Value = strTranType;
            return int.Parse(ExecuteTable("SPPngAprovalCount",objp).Rows[0]["PendingApproval"].ToString());
        }

       public DataTable GetBooking(string strTranType, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
           objp[0].Value = branchid;
           objp[1].Value = strTranType;
           return ExecuteTable("SPSelShiprefno", objp);
       }
       public int GetEventPendingOceanEXP(string eventtype, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@eventtype", SqlDbType.VarChar, 3)};
           objp[0].Value = branchid;
           objp[1].Value = eventtype;
           return int.Parse(ExecuteTable("SPGetFECountPenEvent", objp).Rows[0].ItemArray[0].ToString());
       }

       public int GetEventPendingOceanIMP(string eventtype, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@eventtype", SqlDbType.VarChar, 3)};
           objp[0].Value = branchid;
           objp[1].Value = eventtype;
           return int.Parse(ExecuteTable("SPGetFICountPenEvent", objp).Rows[0].ItemArray[0].ToString());
       }
   
       public DataTable GetFollowupforCRM(int branchid,DateTime followupdate,int empid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@followupdate", SqlDbType.DateTime,8),
                                                      new SqlParameter("@empid",SqlDbType.Int)};
           objp[0].Value = branchid;
           objp[1].Value = followupdate;
           objp[2].Value = empid;
           return ExecuteTable("SPSelFEEventforsidemenu", objp);
       }
    
       public DataTable GetFollowupdateforCRM(int branchid,int empid)
           {
               SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                           new SqlParameter("@empid",SqlDbType.Int)};
           objp[0].Value = branchid;
           objp[1].Value = empid;
           return ExecuteTable("SPGetFollowdtsforsidemenu", objp);
         }
       public DataTable GetQuotPendingApprovalforCRM(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1) };
           objp[0].Value = branchid;
           return ExecuteTable("SPPngAprovalCountforCRM", objp);
       }

       public DataTable GetCount4Fa(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.Int,4)};
           objp[0].Value = branchid;
           return ExecuteTable("SPgetcountofAC4Dash", objp);
       }

       public DataTable GetDeposit4dash(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) };
           objp[0].Value = branchid;
           return ExecuteTable("SPGetDeposit4Dash", objp);
       }

       public DataTable GetTDS4dash(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) };
           objp[0].Value = branchid;
           return ExecuteTable("SPGetTDS4Dash", objp);
       }

       public DataTable Getcreditapp4dash(int divisionid,int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int, 4),
           new SqlParameter("@branchid",SqlDbType.Int,4)};
           objp[0].Value = divisionid;
           objp[1].Value = branchid;
           return ExecuteTable("SPgetcreditapproval4dash", objp);
       }
       public DataTable GetPendCAN(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                      };
           objp[0].Value = branchid;
           return ExecuteTable("SPSelPendCAN", objp);
       }
       public DataTable GetPendLineno(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                      };
           objp[0].Value = branchid;
           return ExecuteTable("SPSelPendLineno", objp);
       }
       public DataTable GetPendStuff(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                      };
           objp[0].Value = branchid;
           return ExecuteTable("SPSelPendDeStuff", objp);
       }
       public DataTable GetFlwUpDtls(int intBranchID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@bid", SqlDbType.TinyInt)
                                                        //new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = intBranchID;
           // objp[1].Value = intDivisionID;
           return ExecuteTable("SPFolwusdDtls", objp);
       }
       public DataTable GetFEHBLDetails(string strTranType, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
           objp[0].Value = branchid;
           objp[1].Value = strTranType;
           return ExecuteTable("SPfehbldetails", objp);
       }




       public DataTable GetFEMBLDetails(string strTranType, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
           objp[0].Value = branchid;
           objp[1].Value = strTranType;
           return ExecuteTable("SPfembldetails", objp);//SPFolwusdDtls
       }




       public DataTable GetFillDtls(int intBranchID, DateTime eventdate)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                           new SqlParameter("@nextfollowup",SqlDbType.DateTime),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt)
                                                           //new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = eventdate;
           objp[1].Value = intBranchID;
           //objp[2].Value = intDivisionID;
           return ExecuteTable("SPFilDtls", objp);
       }


       //ARUN

       public DataTable GetFEHBLDetailsForNew(string strTranType, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
           objp[0].Value = branchid;
           objp[1].Value = strTranType;
           return ExecuteTable("SPfehbldetailsForNew", objp);
       }

       public DataTable GetFEHBLDetailsForNewOpsDoc(string strTranType, int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2)};
           objp[0].Value = branchid;
           objp[1].Value = strTranType;
           return ExecuteTable("SPfehbldetailsForOpsDoc", objp);
       }

       public DataTable GetFEHBLDetailsForNewOpsDocNew(string strTranType, int branchid, int shipperid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@shipperid", SqlDbType.Int)
           };
           objp[0].Value = branchid;
           objp[1].Value = strTranType;
           objp[2].Value = shipperid;
           return ExecuteTable("SPfehbldetailsForOpsDocNew", objp);
       }


       //ARUN
       public DataTable GetTDsCountForNew(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int) };
           objp[0].Value = branchid;
           return ExecuteTable("SpGetTds_Counts", objp);
       }
       public DataTable GetDepositAmtTotal(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int) };
           objp[0].Value = branchid;
           return ExecuteTable("SPDepositeTotal", objp);
       }
       public DataTable GetValueForTds(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt) };
           objp[0].Value = branchid;
           return ExecuteTable("SPGetPATDSNew", objp);
       }

       //Raj
       public DataTable GetChkreqpending4Branch(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) };
           objp[0].Value = branchid;
           return ExecuteTable("SPGetChkreqpending4Branch", objp);
       }
        public DataTable GetFEHBLDetailsForNewOpsDocTask(string strTranType, int branchid,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
            new SqlParameter("@empid", SqlDbType.Int)};
            objp[0].Value = branchid;
            objp[1].Value = strTranType;
            objp[2].Value = empid;
            return ExecuteTable("SPfehbldetailsForOpsDocTask", objp);
        }
    }
}
