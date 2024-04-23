using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.NvoccExports 
{
    public class JobInfo : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public JobInfo()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsJobInfo(int Bid, int Cid, int Vessel, string Voyage, int PoL, DateTime ETD, int PoD, DateTime ETA, int Principal, int CounterPart, int Carrier, int SlotOperator, string Remarks, int JobOpenBy, string strOurPrincipal, string EMno, string EMdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@vessel", SqlDbType.Int),
                                                       new SqlParameter("@voyage", SqlDbType.VarChar,15),
                                                       new SqlParameter("@pol", SqlDbType.Int),
                                                       new SqlParameter("@etd", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@pod", SqlDbType.Int),
                                                       new SqlParameter("@eta", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@principal", SqlDbType.Int,4),
                                                       new SqlParameter("@counterpart", SqlDbType.Int,4),
                                                       new SqlParameter("@carrier", SqlDbType.Int,4),
                                                       new SqlParameter("@slotoperator", SqlDbType.Int,4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar,50),
                                                       new SqlParameter("@jobopenedby", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@ourprincipal",SqlDbType.Char,1),
                                                       new SqlParameter("@emno",SqlDbType.VarChar,15),
                                                       new SqlParameter("@emdate",SqlDbType.SmallDateTime,4) };
            objp[0].Value = Bid;
            objp[1].Value = Cid;
            objp[2].Value = Vessel;
            objp[3].Value = Voyage;
            objp[4].Value = PoL;
            objp[5].Value = ETD;
            objp[6].Value = PoD;
            objp[7].Value = ETA;
            objp[8].Value = Principal;
            objp[9].Value = CounterPart;
            objp[10].Value = Carrier;
            objp[11].Value = SlotOperator;
            objp[12].Value = Remarks;
            objp[13].Value = JobOpenBy;
            objp[14].Direction = ParameterDirection.Output;
            objp[15].Value = strOurPrincipal;
            objp[16].Value = EMno;
            objp[17].Value = EMdate;
            return ExecuteQuery("SPNEInsJobInfo", objp, "@jobno");
        }

        public void UpdJobInfo(int Bid, int Cid, int JobNo, int Vessel, string Voyage, int PoL, DateTime ETD, int PoD, DateTime ETA, int Principal, int CounterPart, int Carrier, int SlotOperator, string Remarks, string strOurPrincipal, string EMno, string EMdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@vessel", SqlDbType.Int),
                                                       new SqlParameter("@voyage", SqlDbType.VarChar,15),
                                                       new SqlParameter("@pol", SqlDbType.Int),
                                                       new SqlParameter("@etd", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@pod", SqlDbType.Int),
                                                       new SqlParameter("@eta", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@principal", SqlDbType.Int,4),
                                                       new SqlParameter("@counterpart", SqlDbType.Int,4),
                                                       new SqlParameter("@carrier", SqlDbType.Int,4),
                                                       new SqlParameter("@slotoperator", SqlDbType.Int,4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar,50),
                                                       new SqlParameter("@ourprincipal",SqlDbType.Char,1),
                                                       new SqlParameter("@emno",SqlDbType.VarChar,15),
                                                       new SqlParameter("@emdate",SqlDbType.SmallDateTime,4) };
            objp[0].Value = Bid;
            objp[1].Value = Cid;
            objp[2].Value = JobNo;
            objp[3].Value = Vessel;
            objp[4].Value = Voyage;
            objp[5].Value = PoL;
            objp[6].Value = ETD;
            objp[7].Value = PoD;
            objp[8].Value = ETA;
            objp[9].Value = Principal;
            objp[10].Value = CounterPart;
            objp[11].Value = Carrier;
            objp[12].Value = SlotOperator;
            objp[13].Value = Remarks;
            objp[14].Value = strOurPrincipal;
            objp[15].Value = EMno;
            objp[16].Value = EMdate;
            ExecuteQuery("SPNEUpdJobInfo", objp);
        }

        public DataTable SelJobDetails(int Bid, int Cid, int JobNo)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@jobno", SqlDbType.Int,4) };
            objp[0].Value = Bid;
            objp[1].Value = Cid;
            objp[2].Value = JobNo;
            return ExecuteTable("SPNESelJobInfoFromJobno", objp);
        }

        public DataTable GetJobNoList(int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt, 1)};
            objp[0].Value = intBranchID;
            objp[1].Value = intDivisionID;
            return ExecuteTable("SPNEQery", objp);
        }
    }
}
