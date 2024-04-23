using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MISGrd : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MISGrd()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetshipmentDetails(string trantype, int branchid , DateTime fromdate,DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;

            return ExecuteTable("SPGetShipmentdetailsGrdForMIS", objp);
        }

        public DataTable GetForwarder(string trantype, int branchid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;

            return ExecuteTable("SPGetForwarderGrdForMIS", objp);
        }

        public DataTable GetshipmentDetails4AgentOld(int consigneeid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid", SqlDbType.TinyInt, 4)};
            objp[0].Value = consigneeid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetShipmentDetailforAgent", objp);
        }

        public DataTable Getjobwisecosting(string trantype, int branchid, DateTime fromdate, DateTime todate,int divisionid)
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
            return ExecuteTable("SPGetJobwiseCostingGrd", objp);
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


        public DataTable GetDORegister( int branchid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10)};
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPGetDORegisterGrd", objp);
        }


        public DataTable GetOperatingProfit(int branchid,int divisionid,string trantype, DateTime fromdate, DateTime todate)
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
            return ExecuteTable("SPGetOperatingProfitGrd", objp);
        }

        public DataTable GetYear2DateMIS(int branchid,int empid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetYearToMisForGrid", objp);
        }


        public DataTable GetYear2DateMISNew(int branchid, int empid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = branchid;
            objp[1].Value = empid;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetYearToMisForGridNewRaj", objp);
        }

        public DataTable GetShipperWise(int bid, DateTime fromdate, DateTime todate, string trantype, string cust, int divisionid)
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
            return ExecuteTable("SPGetShipperSummaryGrd", objp);
        }

        //RAJ

        public DataTable GetShipperWiseNew(int bid, DateTime fromdate, DateTime todate, string trantype, string cust, int divisionid)
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
            return ExecuteTable("SPGetShipperSummaryGrdNew", objp);
        }

        public DataTable GetshipmentDetails4Shipper(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteTable("SPGetShipmentDetailforShipper", objp);
        }

        public DataTable GetshipmentDetails4Consignee(int consigneeid, int branchid, DateTime fromdate, DateTime todate, string trantype,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = consigneeid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetShipmentDetailforConsignee", objp);
        }

        public DataTable GetshipmentDetails4Agent(int consigneeid, int branchid, DateTime fromdate, DateTime todate, string trantype,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = consigneeid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetShipmentDetailforAgent", objp);
        }

        public DataTable GetJobDetailsFrmoJobNew(int jobno, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                new SqlParameter("@divisionid", SqlDbType.TinyInt, 4)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteTable("SpgetJobDetailsFromJobno", objp);
        }

        public DataTable GetshipmentDetails4Agent1(int consigneeid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       //new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid", SqlDbType.TinyInt, 4)};
            objp[0].Value = consigneeid;
            //objp[1].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = trantype;
            objp[4].Value = divisionid;
            return ExecuteTable("SPGetShipmentDetailforAgentNew", objp);
        }


        public DataTable GetshipmentDetailsfromjobnoNew(string trantype, int branchid, DateTime fromdate, DateTime todate, int jobno, int divisionid, string nomination)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@jobno",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4),
            new SqlParameter("@nomination",SqlDbType.VarChar,1)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = jobno;
            objp[5].Value = divisionid;
            objp[6].Value = nomination;
            return ExecuteTable("SPGetShipmentdetailsGrdForMISJob", objp);

        }
        public DataTable GetJobDetailsFrmoJob(int jobno, int branchid, DateTime fromdate, DateTime todate, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            return ExecuteTable("SpgetJobDetailsFromJobno", objp);
        }

        public DataTable GetPOlwise(string trantype, int branchid, DateTime fromdate, DateTime todate,int divisionid)
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
            return ExecuteTable("SPgetPolWise4NewMIS", objp);
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

        public DataTable GetPODwise(string trantype, int branchid, DateTime fromdate, DateTime todate,int divisionid)
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
            return ExecuteTable("SPgetPodWise4NewMIS", objp);
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

        public DataTable GetSaleswise(string trantype, int branchid, DateTime fromdate, DateTime todate,int divisionid)
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
            return ExecuteTable("SPGetSalesForShipmentGrid", objp);
        }

        public DataTable GetNominationwise(string trantype, int branchid, DateTime fromdate, DateTime todate,string nomination,int divisionid)
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
            return ExecuteTable("SPGetNominationForShipmentGrid", objp);
        }

        public DataTable Getshipmentnew(string trantype, int branchid, DateTime fromdate, DateTime todate,int division)
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

            return ExecuteTable("SPgetShipmentNewForMIS", objp);
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


        public DataTable GetshipmentDetailsfromjobno(string trantype, int branchid, DateTime fromdate, DateTime todate,int jobno,int divisionid,string nomination)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@jobno",SqlDbType.Int,4),
            new SqlParameter("@divisionid",SqlDbType.Int,4),
            new SqlParameter("@nomination",SqlDbType.VarChar,1)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = jobno;
            objp[5].Value = divisionid;
            objp[6].Value = nomination;
            return ExecuteTable("SPGetShipmentdetailsGrdForMISJob", objp);
        }

        public DataTable GetshipmentDetailsfrompolno(string trantype, int branchid, DateTime fromdate, DateTime todate, int polno,int divisionid)
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
            return ExecuteTable("SPGetShipmentdetailsGrdForMISPoL", objp);
        }

        public DataTable GetshipmentDetailsfrompodno(string trantype, int branchid, DateTime fromdate, DateTime todate, int polno,int divisionid)
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
            return ExecuteTable("SPGetShipmentdetailsGrdForMISPoD", objp);
        }

        public DataTable GetshipmentDetailsfromsales(string trantype, int branchid, DateTime fromdate, DateTime todate, int sales,int divisionid)
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
            objp[4].Value = sales;
            objp[5].Value = divisionid;
            return ExecuteTable("SPGetShipmentdetailsGrdForMISSales", objp);
        }

        public DataTable GetNVsFFromJobtype(string trantype, int branchid, DateTime fromdate, DateTime todate,int jobtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@jobtype",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = jobtype;
            return ExecuteTable("SPgetNVsFFromJobtype", objp);
        }

        public DataTable GetShipperWiseFilter(int bid, DateTime fromdate, DateTime todate, string trantype, string cust,int shipperid,int divisionid)
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
            return ExecuteTable("SPGetShipperSummaryGrdFilter", objp);
        }

        public DataTable GetShipperWiseFilterNew(int bid, DateTime fromdate, DateTime todate, string trantype, string cust, int shipperid, int divisionid)
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
            return ExecuteTable("SPGetShipperSummaryGrdFilterNew", objp);
        }

        public DataTable GetSaleswiseFilter(string trantype, int branchid, DateTime fromdate, DateTime todate,int salesid,int divisionid)
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
            return ExecuteTable("SPGetSalesForShipmentGridFilter", objp);
        }

        public DataTable GetPODwiseFilter(string trantype, int branchid, DateTime fromdate, DateTime todate, int podid,int divisionid)
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
            return ExecuteTable("SPgetPodWise4NewMISFilter", objp);
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

        public DataTable GetPOlwiseFilter(string trantype, int branchid, DateTime fromdate, DateTime todate,int polid,int divisionid)
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
            return ExecuteTable("SPgetPolWise4NewMISFilter", objp);
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

        public int GetNoOfBlForRetention(DateTime fromdate, DateTime todate, int branchid, int agentid, string jobtype, string nom)
        {
            //int cityid = Portobj.GetNPortid(location);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                      new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                      new SqlParameter("@branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@agent",SqlDbType.Int,4),
                                                      new SqlParameter("@nom",SqlDbType.VarChar,1),
                                                      new SqlParameter("@jobtype",SqlDbType.VarChar,1)};

            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = branchid;
            objp[3].Value = agentid;
            objp[4].Value = nom;
            objp[5].Value = jobtype;

            return int.Parse(ExecuteReader("SPGetnoofblFromJobImports", objp));
        }

        public DataTable GetLogdetails(int empid, DateTime fromdate, DateTime todate,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate", SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@branchid",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = branchid;
            return ExecuteTable("SPGetLogdetails", objp);
        }

        public DataTable GetDORegister4Audit(int branchid, DateTime fromdate, DateTime todate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10)};
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            return ExecuteTable("SPDORegister4Audit", objp);
        }
        //Elakkiya
        public DataTable GetLinerDetails(string trantype, int branchid, DateTime fromdate, DateTime todate, int division, int liner)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                    new SqlParameter("@liner",SqlDbType.Int,4) };
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = division;
            objp[5].Value = liner;
            return ExecuteTable("SPgetLinerNewForMISElaa", objp);
        }

        //Manoj
        public DataTable GetTeus4Shipper(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteTable("SPGetShipperTeusDtls", objp);
        }

        public DataSet GetTeus4ShipperYearwise(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetShipperDetailsYearwise", objp);
        }

        public DataTable GetTeus4consignee(int Consigneeid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@consignee", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = Consigneeid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteTable("SPGetConsigneeTeusDtls", objp);
        }

        public DataSet GetTeus4consigneeYearwise(int Consigneeid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@consignee", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = Consigneeid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetConsigneeDetailsYearwise", objp);
        }

        public DataTable GetTeus4Agent(int agentid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@agent", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = agentid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteTable("SPGetAgentTeusDtls", objp);
        }

        public DataSet GetTeus4agentYearwise(int agentid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@agent", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = agentid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetAgentDetailsYearwise", objp);
        }

        public DataTable GetTeus4NotifyParty(int NPid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@NPid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = NPid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteTable("SPGetNPTeusDtls", objp);
        }

        public DataSet GetTeus4NPYearwise(int NPid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@NPid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = NPid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetNPDetailsYearwise", objp);
        }

        public DataTable GetTeus4SalesPerson(int SPid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@SPid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = SPid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteTable("SPGetSPTeusDtls", objp);
        }

        public DataSet GetTeus4SPYearwise(int SPid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@SPid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = SPid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetSPDetailsYearwise", objp);
        }

        //For Corporate manoj

        public DataSet GetTeus4ShipperYearwisecor(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@shipper", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetShipperDetailsYearwiseCor", objp);
        }

        public DataSet GetTeus4SPYearwisecor(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@SPid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetSPDetailsYearwiseCor", objp);
        }

        public DataSet GetTeus4NPYearwisecor(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@NPid", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetNPDetailsYearwiseCor", objp);
        }

        public DataSet GetTeus4ConsigneeYearwisecor(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@consignee", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetConsigneeDetailsYearwiseCor", objp);
        }

        public DataSet GetTeus4AgentYearwisecor(int shipperid, int branchid, DateTime fromdate, DateTime todate, string trantype, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@agent", SqlDbType.Int,4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
            new SqlParameter("@trantype",SqlDbType.VarChar,2),
            new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = shipperid;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = trantype;
            objp[5].Value = divisionid;

            return ExecuteDataSet("SPGetAgentDetailsYearwiseCor", objp);
        }
        //Dinesh
        
      
        public DataTable GetOPsDocHomeCount(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("SPGetOperatingProfitGrdhomeCount", objp);

        }

        public DataTable GetOurAgentGrdhomeCount(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@divisionid", SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("SPGetOurAgentGrdhomeCount", objp);

        }


        public DataTable Getshipmentnewhome(string trantype, int branchid, DateTime fromdate, DateTime todate, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@todate",SqlDbType.SmallDateTime,10),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            objp[2].Value = fromdate;
            objp[3].Value = todate;
            objp[4].Value = division;

            return ExecuteTable("SPgetShipmentNewForMISHomeCount", objp);
        }


        public DataTable Getnewoutstanding4MIS(int empid, int branchid, int divisionid, int subgroupid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),               
                                                         new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@subgroupid",SqlDbType.Int,4),
             new SqlParameter("@trantype",SqlDbType.VarChar,2),};
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = trantype;
            return ExecuteTable("spnewoutstanding4MIS", objp);
        }

        public DataTable Getnewoutstanding4MISHomeOutStndTotal(int empid, int branchid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),               
                                                         new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                        new SqlParameter("@subgroupid",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            return ExecuteTable("spnewoutstanding4MISHomeOutStndTotal", objp);
        }



        public DataTable GetOperatingProfitnew(int branchid, int divisionid, string trantype, DateTime fromdate, DateTime todate)
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
            return ExecuteTable("SPGetOperatingProfitGrdnew", objp);
        }

        //muthu
        public DataSet unclosedFAnew(DateTime fromdate, DateTime todate, int vouyear, int bid, string dbname, string div)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@from",SqlDbType.DateTime),        
                                                       new SqlParameter("@to",SqlDbType.DateTime), 
                                                       new SqlParameter("@vouyear",SqlDbType.Int),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                       new SqlParameter("@div",SqlDbType.Char,1)};
            objp[0].Value = fromdate;
            objp[1].Value = todate;
            objp[2].Value = vouyear;
            objp[3].Value = bid;
            objp[4].Value = dbname;
            objp[5].Value = div;

            return ExecuteDataSet("SPGetMISReconsOP4FAGP", objp);
        }
        public DataTable getunclosejobandclosedcount(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@divid", SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("sp_getunclosejobandclosedcount", objp);

        }
        //corporate added std
        public DataTable getunclosejobandclosedcountcorp(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@divid", SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("sp_getunclosejobandclosedcountcorp", objp);

        }
        //end
        public DataTable Getretentionforcustomerfordiv_NEWONE( int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                      // new SqlParameter("@from",SqlDbType.DateTime,8),
                                                       //new SqlParameter("@to", SqlDbType.DateTime,8),
                                                        new SqlParameter("@branchid", SqlDbType.Int,4)
            };

            objp[0].Value = branchid;
            //objp[1].Value = to;
            //objp[2].Value = branchid;
            return ExecuteTable("Spgetalltrantype4corppiechartfordiv_NEWONE", objp);


        }
        public DataTable Getretentionforcustomerfordiv_NEWONE(DateTime from, DateTime to, int branchid, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[] {
                                                new SqlParameter("@from",SqlDbType.DateTime,8),
                                                new SqlParameter("@to", SqlDbType.DateTime,8),
                                                 new SqlParameter("@branchid", SqlDbType.Int,4),
                                                 new SqlParameter("@trantype", SqlDbType.VarChar,2)
     };

            objp[0].Value = from;
            objp[1].Value = to;
            objp[2].Value = branchid;
            objp[3].Value = trantype;
            return ExecuteTable("Spgetalltrantype4corppiechartfordiv_NEWONE", objp);
        }
        }
}
