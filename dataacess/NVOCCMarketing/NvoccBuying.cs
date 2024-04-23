using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.nvoccmarketing
{
    public class NvoccBuying : DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public NvoccBuying()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsBuyingHead(int Carrier, int SlotOper, int POR, int POL, int POD, int FD, int Cargo, DateTime validtill, string remarks,int preparedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@liner", SqlDbType.Int, 4),
                                                       new SqlParameter("@slotoperator", SqlDbType.Int, 4),
                                                       new SqlParameter("@por",SqlDbType.Int,4),
                                                       new SqlParameter("@pol", SqlDbType.Int, 4),
                                                       new SqlParameter("@pod", SqlDbType.Int, 4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4),
                                                       new SqlParameter("@cargo", SqlDbType.Int),
                                                       new SqlParameter("@validity", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@rateid",SqlDbType.Int,4) };
            objp[0].Value = Carrier;
            objp[1].Value = SlotOper;
            objp[2].Value = POR;
            objp[3].Value = POL;
            objp[4].Value = POD;
            objp[5].Value = FD;
            objp[6].Value = Cargo;
            objp[7].Value = validtill;
            objp[8].Value = remarks;
            objp[9].Value = preparedby;
            objp[10].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPNVInsBuyingHead", objp, "@rateid");
        }

        public void InsBuyingDetails(int intRateid, int intChargeid, string currency, double Rate, string Base)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int, 4),
                                                       new SqlParameter("@curr", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@rate", SqlDbType.Money, 8),
                                                       new SqlParameter("@base", SqlDbType.VarChar, 6) };
            objp[0].Value = intRateid;
            objp[1].Value = intChargeid;
            objp[2].Value = currency;
            objp[3].Value = Rate;
            objp[4].Value = Base;
            ExecuteQuery("SPNVInsBuyingDetails", objp);
        }

        public void UpdBuyingHead(int RateID, int Carrier, int SlotOper, int POR, int POL, int POD, int FD, int Cargo, DateTime validtill, string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid",SqlDbType.Int,4),
                                                       new SqlParameter("@liner", SqlDbType.Int, 4),
                                                       new SqlParameter("@slotoperator", SqlDbType.Int, 4),
                                                       new SqlParameter("@por",SqlDbType.Int,4),
                                                       new SqlParameter("@pol", SqlDbType.Int, 4),
                                                       new SqlParameter("@pod", SqlDbType.Int, 4),
                                                       new SqlParameter("@fd",SqlDbType.Int,4),
                                                       new SqlParameter("@cargo", SqlDbType.Int),
                                                       new SqlParameter("@validity", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 100) };
            objp[0].Value = RateID;
            objp[1].Value = Carrier;
            objp[2].Value = SlotOper;
            objp[3].Value = POR;
            objp[4].Value = POL;
            objp[5].Value = POD;
            objp[6].Value = FD;
            objp[7].Value = Cargo;
            objp[8].Value = validtill;
            objp[9].Value = remarks;
            ExecuteQuery("SPNVUpdBuyingHead", objp);
        }

        public void UpdBuyingDetails(int intRateid, int intChargeid, string currency, double Rate, string Base)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int, 4),
                                                       new SqlParameter("@curr", SqlDbType.VarChar, 3),
                                                       new SqlParameter("@rate", SqlDbType.Money, 8),
                                                       new SqlParameter("@base", SqlDbType.VarChar, 6) };
            objp[0].Value = intRateid;
            objp[1].Value = intChargeid;
            objp[2].Value = currency;
            objp[3].Value = Rate;
            objp[4].Value = Base;
            ExecuteQuery("SPNVUpdBuyingDetails", objp);
        }

        public DataTable SelBuyingHead(int intRateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = intRateid;
            return ExecuteTable("SPNVselectBuyingHead", objp);
        }

        public DataTable SelBuyingDetails(int intRateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rateid", SqlDbType.Int, 4) };
            objp[0].Value = intRateid;
            return ExecuteTable("SPNVselBuyingDetails", objp);
        }
    }
}
