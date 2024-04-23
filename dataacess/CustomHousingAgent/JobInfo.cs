using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CustomHousingAgent
{
    public class JobInfo : DBObject
    {

        int intPkgID, intUserID;
        DataAccess.Masters.MasterPort prtObj = new DataAccess.Masters.MasterPort();
        DataAccess.Masters.MasterPackages pkgObj = new DataAccess.Masters.MasterPackages();
        DataAccess.Masters.MasterCustomer custObj = new DataAccess.Masters.MasterCustomer();
        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }


        public JobInfo()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsJobInfo(string strJobType, string strDocNo, DateTime datDocDate, string strMDocNo, string strMode, int intCustID, int intSprID, int intCneeID, int intNptID, int intPrplID, string strUser, string strCargo, int intNoofPkgs, string strPackage, double dblGrWt, double dblNtWt, int intVolQty, string strVolType, int intPOL, int intPOD, int intFD, string strDocs, DateTime jobdate, int branchid, int PreparedBy, int bid, int cid)
        {
            intPkgID = pkgObj.GetNPackageid(strPackage);
            intUserID = empObj.GetNEmpid(strUser);

            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@jobtype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@docno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@docdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@mdocno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@mode",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customer",SqlDbType.Int,4),
                                                       new SqlParameter("@shipper",SqlDbType.Int,4),
                                                       new SqlParameter("@consignee",SqlDbType.Int,4),
                                                       new SqlParameter("@notifyparty",SqlDbType.Int,4),
                                                       new SqlParameter("@principal",SqlDbType.Int,4),
                                                       new SqlParameter("@userid",SqlDbType.Int,4),
                                                       new SqlParameter("@cargo",SqlDbType.VarChar,100),
                                                       new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                       new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                       new SqlParameter("@grosswt",SqlDbType.Real,8),
                                                       new SqlParameter("@netwt",SqlDbType.Real,8),
                                                       new SqlParameter("@volumeqty",SqlDbType.Int),
                                                       new SqlParameter("@volumetype",SqlDbType.VarChar,30),
                                                       new SqlParameter("@pol",SqlDbType.Int,4),
                                                       new SqlParameter("@pod",SqlDbType.Int,4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4),
                                                       new SqlParameter("@docs",SqlDbType.VarChar,100),
                                                       new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@preparedby",SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4)};
            objp[0].Value = strJobType;
            objp[1].Value = strDocNo;
            objp[2].Value = datDocDate;
            objp[3].Value = strMDocNo;
            objp[4].Value = strMode;
            objp[5].Value = intCustID;
            objp[6].Value = intSprID;
            objp[7].Value = intCneeID;
            objp[8].Value = intNptID;
            objp[9].Value = intPrplID;
            objp[10].Value = intUserID;
            objp[11].Value = strCargo;
            objp[12].Value = intNoofPkgs;
            objp[13].Value = intPkgID;
            objp[14].Value = dblGrWt;
            objp[15].Value = dblNtWt;
            objp[16].Value = intVolQty;
            objp[17].Value = strVolType;
            objp[18].Value = intPOL;
            objp[19].Value = intPOD;
            objp[20].Value = intFD;
            objp[21].Value = strDocs;
            objp[22].Value = jobdate;
            objp[23].Value = branchid;
            objp[24].Value = PreparedBy;
            objp[25].Value = bid;
            objp[26].Value = cid;
            objp[27].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsCHJobInfo", objp, "@jobno");
        }

        public void UpdJobInfo(int intJobNo, string strJobType, string strDocNo, DateTime datDocDate, string strMDocNo, string strMode, int intCustID, int intSprID, int intCneeID, int intNptID, int intPrplID, string strUser, string strCargo, int intNoofPkgs, string strPackage, double dblGrWt, double dblNtWt, int intVolQty, string strVolType, int intPOL, int intPOD, int intFD, string strDocs, DateTime jobdate, int bid, int cid)
        {
            intUserID = empObj.GetNEmpid(strUser);
            intPkgID = pkgObj.GetNPackageid(strPackage);

            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@jobtype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@docno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@docdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@mdocno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@mode",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customer",SqlDbType.Int,4),
                                                       new SqlParameter("@shipper",SqlDbType.Int,4),
                                                       new SqlParameter("@consignee",SqlDbType.Int,4),
                                                       new SqlParameter("@notifyparty",SqlDbType.Int,4),
                                                       new SqlParameter("@principal",SqlDbType.Int,4),
                                                       new SqlParameter("@userid",SqlDbType.Int,4),
                                                       new SqlParameter("@cargo",SqlDbType.VarChar,100),
                                                       new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                       new SqlParameter("@pkgid",SqlDbType.Int,4),
                                                       new SqlParameter("@grosswt",SqlDbType.Real,8),
                                                       new SqlParameter("@netwt",SqlDbType.Real,8),
                                                       new SqlParameter("@volumeqty",SqlDbType.Int),
                                                       new SqlParameter("@volumetype",SqlDbType.VarChar,30),
                                                       new SqlParameter("@pol",SqlDbType.Int,4),
                                                       new SqlParameter("@pod",SqlDbType.Int,4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4),
                                                       new SqlParameter("@docs",SqlDbType.VarChar,100),
                                                       new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)};
            objp[0].Value = intJobNo;
            objp[1].Value = strJobType;
            objp[2].Value = strDocNo;
            objp[3].Value = datDocDate;
            objp[4].Value = strMDocNo;
            objp[5].Value = strMode;
            objp[6].Value = intCustID;
            objp[7].Value = intSprID;
            objp[8].Value = intCneeID;
            objp[9].Value = intNptID;
            objp[10].Value = intPrplID;
            objp[11].Value = intUserID;
            objp[12].Value = strCargo;
            objp[13].Value = intNoofPkgs;
            objp[14].Value = intPkgID;
            objp[15].Value = dblGrWt;
            objp[16].Value = dblNtWt;
            objp[17].Value = intVolQty;
            objp[18].Value = strVolType;
            objp[19].Value = intPOL;
            objp[20].Value = intPOD;
            objp[21].Value = intFD;
            objp[22].Value = strDocs;
            objp[23].Value = jobdate;
            objp[24].Value = bid;
            objp[25].Value = bid;
            objp[26].Value = cid;
            ExecuteQuery("SPUpdCHJobInfo", objp);
        }

        public DataTable GetCHJobInfo(int intJobNo, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intJobNo;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelCHJobInfo", objp);
        }


        public int GetJobNo(string strDocno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strDocno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return int.Parse(ExecuteReader("SPSelCHJobNo", objp));
        }

        public string GetJobtype(string strJobType)
        {
            string str = "";
            switch (strJobType)
            {
                case "Air Export":
                    str = "AE";
                    break;
                case "Air Import":
                    str = "AI";
                    break;
                case "Sea Export":
                    str = "SE";
                    break;
                case "Sea Import":
                    str = "SI";
                    break;
                case "Road Export":
                    str = "RE";
                    break;
                case "Road Import":
                    str = "RI";
                    break;
                case "By Road":
                    str = "BR";
                    break;
            }
            return str;
        }


        public string SetJobtype(string strJobType)
        {
            string str = "";
            switch (strJobType)
            {
                case "AE":
                    str = "Air Export";
                    break;
                case "AI":
                    str = "Air Import";
                    break;
                case "SE":
                    str = "Sea Export";
                    break;
                case "SI":
                    str = "Sea Import";
                    break;
                case "RE":
                    str = "Road Export";
                    break;
                case "RI":
                    str = "Road Import";
                    break;
                case "BR":
                    str = "By Road";
                    break;
            }
            return str;
        }

        public DataTable GetAllCHJobInfo(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPSelCHJobInfoAll", objp);
        }

        //Windows Application Methods.

        public DataTable GetLikeDocno(string docno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = docno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPLikeCHA", objp);
        }
        public DataTable GetLikeOTHERDocno(string docno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,2),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,2)};
            objp[0].Value = docno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPLikeOTHERCHA", objp);
        }

        //Dinesh
        public DataTable GetLikeDocnonew(string docno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = docno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPLikeCHAnew", objp);
        }
    }
}
