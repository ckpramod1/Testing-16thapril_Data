using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
    public class RcptpmtAdjustment:DBObject 
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public RcptpmtAdjustment()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable SelRcptPmt  (int vouno, string strvtype, int branchid, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@ftype",SqlDbType.VarChar,20), 
                                                                            
                                                                             new SqlParameter("@branchid",SqlDbType.Int,4) ,
                                                                              new SqlParameter("@vouyear",SqlDbType.Int)
                                                                           
                                                                           };
            objp[0].Value = vouno;
           
            objp[1].Value = strvtype;
            objp[2].Value = branchid;
           
            objp[3].Value = vouyear;

            return ExecuteTable("SPAdjRPt", objp);
        }
        public void insertRcptPmt(int tranid, char rptype, int vouno, char voutype, int vouyear, int branchid, double vamount, double tamount, char setteled, int ravouyear)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                                           {    
                                                                                new SqlParameter("@tranid",SqlDbType.Int,4), 
                                                                                new SqlParameter("@rptype",SqlDbType.Char ,1), 
                                                                                new SqlParameter("@vouno",SqlDbType.Int,4) ,
                                                                                new SqlParameter("@voutype",SqlDbType.Char ,1), 
                                                                                new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                new SqlParameter("@branchid",SqlDbType.Int,4) ,
                                                                                new SqlParameter("@vamount",SqlDbType.Money ,8) ,
                                                                                new SqlParameter("@tamount",SqlDbType.Money ,8) ,
                                                                                 new SqlParameter("@setteled",SqlDbType.Char ,1), 
                                                                                new SqlParameter("@ravouyear",SqlDbType.Int)
                                                                           };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vamount;
            objp[7].Value = tamount;
            objp[8].Value = setteled;
            objp[9].Value = ravouyear;
             ExecuteQuery("SPInsRcptPmt", objp);
        }
        public DataTable RetRcptPmt(int vouno, char voutype, char rptype, int vouyear)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vouno",SqlDbType.Int,4), 
                                                                            new SqlParameter("@voutype",SqlDbType.Char,1), 
                                                                                new SqlParameter("@rptype",SqlDbType.Char ,1) ,
                                                                              new SqlParameter("@vouyear",SqlDbType.Int)
                                                                           
                                                                           };
            objp[0].Value = vouno;

            objp[1].Value = voutype;
            objp[2].Value = rptype;

            objp[3].Value = vouyear;

            return ExecuteTable("SPSelRcptpmt", objp);
        }
        //NewOne    //24/06/2022
        public void insertRcptPmt_new(int tranid, char rptype, int vouno, char voutype, int vouyear, int branchid, double vamount, double tamount, char setteled, int ravouyear, int subgroupid, int @ledgerid, string @ledgertype, string jrefno, string fcurr, double exrate)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                                           {    
                                                                                new SqlParameter("@tranid",SqlDbType.Int,4), 
                                                                                new SqlParameter("@rptype",SqlDbType.Char ,1), 
                                                                                new SqlParameter("@vouno",SqlDbType.Int,4) ,
                                                                                new SqlParameter("@voutype",SqlDbType.Char ,1), 
                                                                                new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                new SqlParameter("@branchid",SqlDbType.Int,4) ,
                                                                                new SqlParameter("@vamount",SqlDbType.Money ,8) ,
                                                                                new SqlParameter("@tamount",SqlDbType.Money ,8) ,
                                                                                 new SqlParameter("@setteled",SqlDbType.Char ,1), 
                                                                                new SqlParameter("@ravouyear",SqlDbType.Int),
                                                                                new SqlParameter("@subgroupid",SqlDbType.Int),
                                                                                new SqlParameter("@ledgerid",SqlDbType.Int),
                                                                                new SqlParameter("@ledgertype",SqlDbType.VarChar,5),
                                                                                new SqlParameter("@jrefno",SqlDbType.VarChar,100),
                                                                                new SqlParameter("@fcurr",SqlDbType.VarChar,5),
                                                                                new SqlParameter("@exrate",SqlDbType.Money ,8) ,
                                                                           };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vamount;
            objp[7].Value = tamount;
            objp[8].Value = setteled;
            objp[9].Value = ravouyear;
            objp[10].Value = subgroupid;
            objp[11].Value = ledgerid;
            objp[12].Value = ledgertype;
            objp[13].Value = jrefno;
            objp[14].Value = fcurr;
            objp[15].Value = exrate;
            ExecuteQuery("SPInsRcptPmt_new", objp);
        }


        // Vino New for Outstd Adjustment Table [19-02-2024] 
        public int osadjustmenthead_new(int empid, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {

                                                     new SqlParameter("@empid",SqlDbType.Int),
                                                      new SqlParameter("@bid",SqlDbType.Int),
                                                      new SqlParameter("@refid",SqlDbType.BigInt)
                                                     };
            objp[0].Value = empid;
            objp[1].Value = bid;
            objp[2].Direction = ParameterDirection.Output;
            return ExecuteQuery("sp_osadjustmenthead_new", objp, "@refid");
        }

        public void insertRcptPmt_new(int tranid, char rptype, int vouno, string voutype, int vouyear, int branchid, double vamount, double tamount, char setteled, int ravouyear, int subgroupid, int @ledgerid, string @ledgertype, string jrefno, string fcurr, double exrate, string vendorref, int refid, int jmonth, string WIZvouno)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                                           {
                                                                                new SqlParameter("@tranid",SqlDbType.Int,4),
                                                                                new SqlParameter("@rptype",SqlDbType.Char ,1),
                                                                                new SqlParameter("@vouno",SqlDbType.Int,4) ,
                                                                                new SqlParameter("@voutype",SqlDbType.VarChar,5),
                                                                                new SqlParameter("@vouyear",SqlDbType.Int),
                                                                                new SqlParameter("@branchid",SqlDbType.Int,4) ,
                                                                                new SqlParameter("@vamount",SqlDbType.Money ,8) ,
                                                                                new SqlParameter("@tamount",SqlDbType.Money ,8) ,
                                                                                 new SqlParameter("@setteled",SqlDbType.Char ,1),
                                                                                new SqlParameter("@ravouyear",SqlDbType.Int),
                                                                                new SqlParameter("@subgroupid",SqlDbType.Int),
                                                                                new SqlParameter("@ledgerid",SqlDbType.Int),
                                                                                new SqlParameter("@ledgertype",SqlDbType.VarChar,5),
                                                                                new SqlParameter("@jrefno",SqlDbType.VarChar,100),
                                                                                new SqlParameter("@fcurr",SqlDbType.VarChar,5),
                                                                                new SqlParameter("@exrate",SqlDbType.Money ,8) ,
                                                                                 new SqlParameter("@VENDORREFNO",SqlDbType.VarChar,100) ,
                                                                                 new SqlParameter("@refid",SqlDbType.BigInt),
                                                                                new SqlParameter("@jmonth",SqlDbType.Int),
                                                                                new SqlParameter("@WIZvouno",SqlDbType.VarChar,100)
                                                                           };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = vouyear;
            objp[5].Value = branchid;
            objp[6].Value = vamount;
            objp[7].Value = tamount;
            objp[8].Value = setteled;
            objp[9].Value = ravouyear;
            objp[10].Value = subgroupid;
            objp[11].Value = ledgerid;
            objp[12].Value = ledgertype;
            objp[13].Value = jrefno;
            objp[14].Value = fcurr;
            objp[15].Value = exrate;
            objp[16].Value = vendorref;
            objp[17].Value = refid;
            objp[18].Value = jmonth;
            objp[19].Value = WIZvouno;
            ExecuteQuery("SPInsRcptPmt_new1", objp);
            //ExecuteQuery("SPInsRcptPmt_new", objp);
        }




    }
}
