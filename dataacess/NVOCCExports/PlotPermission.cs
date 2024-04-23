using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.NVOCCExports
{
    public class PlotPermission : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public PlotPermission()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetContainers4PP(int PrincID, int Branchid, int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@principal", SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1) };
            objp[0].Value = PrincID;
            objp[1].Value = Branchid;
            objp[2].Value = DivisionID;
            return ExecuteTable("SPGetContainers4PP", objp);
        }

        public int InsPlotPermission(int intCID, int intBID, DateTime dtPPDate, int intBkngNo, int intCustomer, int intPrincipal, int intCha, int intDepot, char chrNCntr, int intNoOf20, int intNoOf40)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@ppdate", SqlDbType.SmallDateTime,4),
                                                       new SqlParameter("@bookingno", SqlDbType.Int,4),
                                                       new SqlParameter("@customer", SqlDbType.Int, 4),
                                                       new SqlParameter("@principal", SqlDbType.Int, 4),
                                                       new SqlParameter("@cha", SqlDbType.Int, 4),
                                                       new SqlParameter("@depot", SqlDbType.Int, 4),
                                                       new SqlParameter("@ncntr", SqlDbType.Char,1),
                                                       new SqlParameter("@noof20", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@noof40", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@ppno", SqlDbType.Int,4) };
            objp[0].Value = intCID;
            objp[1].Value = intBID;
            objp[2].Value = dtPPDate;
            objp[3].Value = intBkngNo;
            objp[4].Value = intCustomer;
            objp[5].Value = intPrincipal;
            objp[6].Value = intCha;
            objp[7].Value = intDepot;
            objp[8].Value = chrNCntr;
            objp[9].Value = intNoOf20;
            objp[10].Value = intNoOf40;
            objp[11].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPNEInsPlotPermission", objp, "@ppno");
        }

        public void UpdPlotPermission(int intCID, int intBID, int PPno, int intCha, int intDepot, char chrNCntr, int intNoOf20, int intNoOf40)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@ppno", SqlDbType.Int,4),
                                                       new SqlParameter("@cha", SqlDbType.Int, 4),
                                                       new SqlParameter("@depot", SqlDbType.Int, 4),
                                                       new SqlParameter("@ncntr", SqlDbType.Char,1),
                                                       new SqlParameter("@noof20", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@noof40", SqlDbType.TinyInt,1)};
            objp[0].Value = intCID;
            objp[1].Value = intBID;
            objp[2].Value = PPno;
            objp[3].Value = intCha;
            objp[4].Value = intDepot;
            objp[5].Value = chrNCntr;
            objp[6].Value = intNoOf20;
            objp[7].Value = intNoOf40;
            ExecuteQuery("SPNEUpdPlotPermission", objp);
        }

        public void InsPPContainer(int BID, int CID, int PPno, int ContainerID, int nTrackID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@ppno",SqlDbType.Int,4),
                                                       new SqlParameter("containerid",SqlDbType.Int,4),
                                                       new SqlParameter("ntrackid",SqlDbType.Int,4)};
            objp[0].Value = BID;
            objp[1].Value = CID;
            objp[2].Value = PPno;
            objp[3].Value = ContainerID;
            objp[4].Value = nTrackID;
            ExecuteQuery("SPNEInsPPContainer", objp);
        }

        public DataSet SelPlotPermDtlsByPPNum(int intPPNum, int intCID, int intBID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ppno",SqlDbType.Int,4),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1) };
            objp[0].Value = intPPNum;
            objp[1].Value = intCID;
            objp[2].Value = intBID;
            return ExecuteDataSet("SPNESelPlotPermission", objp);
        }

        public DataTable GetContainerByPPno(int PPno, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ppno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = PPno;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            return ExecuteTable("SPGetContainerByPPno", objp);
        }

        public DataTable SelPPDtlsByBookingID(string BookingID, int Bid, int Cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingid",SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = BookingID;
            objp[1].Value = Bid;
            objp[2].Value = Cid;
            return ExecuteTable("SPNESelPPbyBkngID", objp);
        }
    }
}
