using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MisCorporate : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MisCorporate()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable Getjobwisecosting4Cor(string trantype, int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = divisionid;
            return ExecuteTable("SPGetJobwiseCostingGrdForCOR", objp);
        }

        public DataTable Getshipmentnew4cor(string trantype, int branchid, DateTime fromdate, DateTime todate, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = division;

            return ExecuteTable("SPgetShipmentNewForMIS4Cor", objp);
        }


        public DataTable GetshipmentDetails4ConsigneeCorpNew(int consigneeid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       //new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = consigneeid;
            //objp[1].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = divisionid;
            return ExecuteTable("SPGetShipmentDetailforConsigneeCorpNew", objp);
        }

      


        public DataTable GetShipperWisewithname(int bid, DateTime fromdate, DateTime todate, string trantype, string cust, int shipperid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@cust",SqlDbType.VarChar,2),
            new SqlParameter("@shipperid",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};

            objp[0].Value = bid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = trantype;
            objp[4].Value = cust;
            objp[5].Value = shipperid;
            objp[6].Value = divisionid;
            return ExecuteTable("SpGetMISCorShippers", objp);
        }

        public DataTable GetShipperWisewithoutname(int bid, DateTime fromdate, DateTime todate, string trantype, string cust, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.Int),
                                                new SqlParameter("@fromdate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@todate",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                new SqlParameter("@cust",SqlDbType.VarChar,2),
                                                new SqlParameter("@divisionid",SqlDbType.Int,4)};

            objp[0].Value = bid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = trantype;
            objp[4].Value = cust;
            objp[5].Value = divisionid;
            return ExecuteTable("SpGetMISCorShipperswithoutname", objp);
        }

        public DataTable GetNominationwiseCorp(string trantype, int branchid, DateTime fromdate, DateTime todate, string nomination, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@nomination",SqlDbType.VarChar,1),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = nomination;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetNominationForShipmentGrid4corp", objp);
        }

        public DataTable GetSaleswisewithname(string trantype, int branchid, DateTime fromdate, DateTime todate, int salesid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@salesid",SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = salesid;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetSalesForShipmentGridFilter4Corp", objp);
        }

        public DataTable GetSaleswisewithoutname(string trantype, int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = divisionid;
            return ExecuteTable("SPGetSalesForShipmentGridFilter4Corpwoname", objp);
        }

        public DataTable GetPODwiseFilter4cor(string trantype, int branchid, DateTime fromdate, DateTime todate, int podid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@podid",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = podid;
            objp[5].Value = divisionid;
            return ExecuteTable("SPgetPodWise4NewMISFilter4cor", objp);
        }

        public DataTable GetPODwise4cor(string trantype, int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = divisionid;
            return ExecuteTable("SPgetPodWise4NewMIS4cor", objp);
        }

        public DataTable GetPOlwiseFilter4cor(string trantype, int branchid, DateTime fromdate, DateTime todate, int polid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@polid",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = polid;
            objp[5].Value = divisionid;
            return ExecuteTable("SPgetPolWise4NewMISFilter4cor", objp);
        }

        public DataTable GetPOlwise4cor(string trantype, int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = divisionid;
            return ExecuteTable("SPgetPolWise4NewMIS4cor", objp);
        }

        public DataTable GetRetentionperunitforCorporate(int branch, int division, DateTime fromdate, DateTime todate, string Trantype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@branchid",SqlDbType.Int,4),
                                                    new SqlParameter("@division",SqlDbType.Int,4),
                                                    new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@todate",SqlDbType.DateTime,8),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = branch;
            objp[1].Value = division;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = Trantype;
            return ExecuteTable("SPRetentionperUnit4corp", objp);
        }

        public DataTable GetYear2DateMISCorp(int branchid, int empid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@empid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetYearToMisForGrid", objp);
        }

        public DataTable GetOperatingProfitcorp(int branchid, int divisionid, string trantype, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10)};
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = trantype;
            objp[3].Value = fromdate;
            objp[4].Value = todate;
            return ExecuteTable("SPGetOperatingProfitGrdCorpNew", objp);
        }

        public DataTable GetNVsFFromJobtype4Corp(string trantype, int division, DateTime fromdate, DateTime todate, int jobtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@divisionid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@jobtype",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = division;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = jobtype;
            return ExecuteTable("SpgetNvsFforCorp", objp);
        }

        public DataTable getSectorwiseForCorp(int division, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10)};
            objp[0].Value = division;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SpgetSectorwiseRetentionforCorp", objp);
        }

        public DataTable GetshipmentDetails4ConsigneeCorp(int consigneeid, int branchid, DateTime fromdate, DateTime todate,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = consigneeid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = divisionid;
            return ExecuteTable("SPGetShipmentDetailforConsigneeCorp", objp);
        }

        public DataTable GetshipmentDetailsfromsalesCorp(int branchid, DateTime fromdate, DateTime todate, int sales, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@polno",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};

            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = sales;
            objp[4].Value = divisionid;
            return ExecuteTable("SPGetShipmentdetailsGrdForMISSalesCorp", objp);
        }

        public DataTable GetshipmentDetails4ShipperCorp(int shipperid, int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = divisionid;

            return ExecuteTable("SPGetShipmentDetailforShipperCorp", objp);
        }

        public DataTable GetLogdetailswithName(int empid, int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = divisionid;

            return ExecuteTable("SpGetLogForCorpwithname", objp);
        }

        public DataTable GetLogdetailswithoutName(int branchid, DateTime fromdate, DateTime todate, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};

            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = divisionid;

            return ExecuteTable("SpGetLogForCorpwithoutname", objp);
        }

        public DataTable GetPODMISForCorp(string trantype, int branchid, DateTime fromdate, DateTime todate, int polno, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@polno",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = polno;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetShipmentdetailsGrdForMISPoDCorp", objp);
        }


        public DataTable GetPOLMISForCorp(string trantype, int branchid, DateTime fromdate, DateTime todate, int polno, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@polno",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = polno;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetPlMisForCorp", objp);
        }

        public DataTable GetQuotCustomer(string trantype, int branchid, DateTime fromdate, DateTime todate, string nomination, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@nomination",SqlDbType.VarChar,1),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = nomination;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetquotcustomerForShipmentGrid4corp", objp);
        }


        public DataTable GetQuotCustomernew(string trantype, int branchid, DateTime fromdate, DateTime todate, string nomination, int customerid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@nomination",SqlDbType.VarChar,1),
              new SqlParameter("@custid", SqlDbType.Int, 4),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = nomination;
            objp[5].Value = customerid;
            objp[6].Value = divisionid;
            return ExecuteTable("SPGetquotcustomerForShipmentGrid4corpnewcustomerwise", objp);
        }
    }
}
