using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.Accounts
{
    public class STAdjustment : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public STAdjustment()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataSet GetHead(int intVouno, int intVouYear, int intBranchid, string strVouType)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.VarChar,50),
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int)};
            objp[0].Value = strVouType;
            objp[1].Value = intVouno;
            objp[2].Value = intVouYear;
            objp[3].Value = intBranchid;
            return ExecuteDataSet("SPSelVou4AdjSTAmt", objp);
        }

        public void UpdateCharges(int intVouno, int intVouYear, int intBranchid, int intChargeID, double dblAmount, string strVouType)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.VarChar,50),
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money,8)
                                                     };
            objp[0].Value = strVouType;
            objp[1].Value = intVouno;
            objp[2].Value = intVouYear;
            objp[3].Value = intBranchid;
            objp[4].Value = intChargeID;
            objp[5].Value = dblAmount;
            ExecuteQuery("SPUpdSTAmtACNPACN", objp);
        }

        //ARUN

        public DataSet GetServiceTaxAmtForNew(int vouno, int vouyear, int branchid, string voutype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int), 
                                                       new SqlParameter("@vouyear", SqlDbType.Int), 
                                                     new SqlParameter("@branchid", SqlDbType.Int), 
                                                      new SqlParameter("@voutype", SqlDbType.VarChar ,2)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            return ExecuteDataSet("SPSelVou4AdjSTAmtForChangeGst", objp);
        }
        public void UpdateChargesForNew(int intVouno, int intVouYear, int intBranchid, int intChargeID, double dblAmount, string strVouType, string bbase, double igsta, double cgsta, double sgsta)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.VarChar,50),
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money,8),
                                                       new SqlParameter("@base", SqlDbType.VarChar ,10),
                                                        new SqlParameter("@igsta", SqlDbType.Money),
                                                         new SqlParameter("@cgsta", SqlDbType.Money),
                                                          new SqlParameter("@sgsta", SqlDbType.Money)
                                                     };
            objp[0].Value = strVouType;
            objp[1].Value = intVouno;
            objp[2].Value = intVouYear;
            objp[3].Value = intBranchid;
            objp[4].Value = intChargeID;
            objp[5].Value = dblAmount;
            objp[6].Value = bbase;
            objp[7].Value = igsta;
            objp[8].Value = cgsta;
            objp[9].Value = sgsta;
            ExecuteQuery("SPUpdSTAmtACNPACNForGstNew", objp);
        }

        //Dinesh

        public DataSet GetServiceTaxAmtForNewPro(int vouno, int vouyear, int branchid, string voutype)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                     new SqlParameter("@branchid", SqlDbType.Int),
                                                      new SqlParameter("@voutype", SqlDbType.VarChar ,2)};
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = branchid;
            objp[3].Value = voutype;
            return ExecuteDataSet("SPSelVou4AdjSTAmtForChangeGstnew", objp);
        }

        public void UpdateChargesForNewpro(int intVouno, int intVouYear, int intBranchid, int intChargeID, double dblAmount, string strVouType, string bbase, double igsta, double cgsta, double sgsta, int igstp, int cgstp, int sgstp)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.VarChar,50),
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money,8),
                                                       new SqlParameter("@base", SqlDbType.VarChar ,10),
                                                        new SqlParameter("@igsta", SqlDbType.Money),
                                                         new SqlParameter("@cgsta", SqlDbType.Money),
                                                          new SqlParameter("@sgsta", SqlDbType.Money),
                                                          new SqlParameter("@igstp", SqlDbType.Int),
                                                          new SqlParameter("@cgstp", SqlDbType.Int),
                                                            new SqlParameter("@sgstp", SqlDbType.Int)
                                                     };
            objp[0].Value = strVouType;
            objp[1].Value = intVouno;
            objp[2].Value = intVouYear;
            objp[3].Value = intBranchid;
            objp[4].Value = intChargeID;
            objp[5].Value = dblAmount;
            objp[6].Value = bbase;
            objp[7].Value = igsta;
            objp[8].Value = cgsta;
            objp[9].Value = sgsta;

            objp[10].Value = igstp;
            objp[11].Value = cgstp;
            objp[12].Value = sgstp;
            ExecuteQuery("SPUpdSTAmtACNPACNForGstNewpro", objp);
        }

        public void UpdateCharges(int intVouno, int intVouYear, int intBranchid, int intChargeID, double dblAmount, string strVouType, string bbase)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutype", SqlDbType.VarChar,50),
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money,8),
                                                       new SqlParameter("@base", SqlDbType.VarChar ,10)
                                                     };
            objp[0].Value = strVouType;
            objp[1].Value = intVouno;
            objp[2].Value = intVouYear;
            objp[3].Value = intBranchid;
            objp[4].Value = intChargeID;
            objp[5].Value = dblAmount;
            objp[6].Value = bbase;
            ExecuteQuery("SPUpdSTAmtACNPACN", objp);
        }
    }
}
