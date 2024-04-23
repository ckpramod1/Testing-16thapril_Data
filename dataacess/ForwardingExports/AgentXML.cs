using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.ForwardingExports
{
  public class AgentXML : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public AgentXML()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataSet GetAgentXML(int intJobno, int intBranchID, string strTrantype, int intDivisionID)
      {
          SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@cid",SqlDbType.Int,4)
                                                   };

          objp[0].Value = intJobno;
          objp[1].Value = intBranchID;
          objp[2].Value = strTrantype;
          objp[3].Value = intDivisionID;
          return ExecuteDataSet("SPSelAgentXML", objp);
      }

      public void InsHBL(int intJobno, int intBranchID, string strBLNo, DateTime dtmBLDate, string strBLIssuedAt, string strFreight, string strShipper, string strConsignee, string strNotify, string strPoR, string strPoL, string strPoD, string strFD, double dblGrWt, double dblNetWt, double dblCBM, int intNoOfPkgs, string strPackage, string strMarks, string strDescn, string strBLType,int intDivisionID)
      {
          SqlParameter[] objp = new SqlParameter[] {  
                                                          new SqlParameter("@jobno",SqlDbType.Int,4),
                                                          new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                          new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                          new SqlParameter("@blissuedat",SqlDbType.VarChar,50),
                                                          new SqlParameter("@freight",SqlDbType.VarChar,2),
                                                          new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                          new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                          new SqlParameter("@notify",SqlDbType.VarChar,100),
                                                          new SqlParameter("@por",SqlDbType.VarChar,50),
                                                          new SqlParameter("@pol",SqlDbType.VarChar,50),
                                                          new SqlParameter("@pod",SqlDbType.VarChar,50),
                                                          new SqlParameter("@fd",SqlDbType.VarChar,50),
                                                          new SqlParameter("@grwt",SqlDbType.Real,4),
                                                          new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                          new SqlParameter("@cbm",SqlDbType.Real,4),
                                                          new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                          new SqlParameter("@pkg",SqlDbType.VarChar,30),
                                                          new SqlParameter("@marks",SqlDbType.VarChar,500),
                                                          new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                          new SqlParameter("@bltype",SqlDbType.VarChar,1),
                                                          new SqlParameter("@bid",SqlDbType.TinyInt),
                                                          new SqlParameter("@cid",SqlDbType.TinyInt)
                                                   };

          objp[0].Value  = intJobno;
          objp[1].Value  = strBLNo;
          objp[2].Value  = dtmBLDate;
          objp[3].Value  = strBLIssuedAt;
          objp[4].Value  = strFreight;
          objp[5].Value  = strShipper;
          objp[6].Value  = strConsignee;
          objp[7].Value  = strNotify;
          objp[8].Value  = strPoR;
          objp[9].Value  = strPoL;
          objp[10].Value = strPoD;
          objp[11].Value = strFD;
          objp[12].Value = dblGrWt;
          objp[13].Value = dblNetWt;
          objp[14].Value = dblCBM;
          objp[15].Value = intNoOfPkgs;
          objp[16].Value = strPackage;
          objp[17].Value = strMarks;
          objp[18].Value = strDescn;
          objp[19].Value = strBLType;
          objp[20].Value = intBranchID;
          objp[21].Value = intDivisionID;
          ExecuteQuery("SPInsAgentXML", objp);
      }
    }
}
