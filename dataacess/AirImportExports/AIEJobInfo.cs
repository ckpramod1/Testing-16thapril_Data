using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.AirImportExports
{
    public class AIEJobInfo : DBObject
    {
        string SPName;
        Masters.MasterPort prtObj = new Masters.MasterPort();
        Masters.MasterCustomer custObj = new Masters.MasterCustomer();



        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public AIEJobInfo()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsAIEJobInfo(int intAirlineID, string strMawblno, DateTime datMawbldate, string strFlightno, DateTime datFlightDate, int intAgentID, string strStatus, string strHlgInfo, int intFromPortID, int intToPortID, string strType, DateTime jobdate, string iatacarrier, string manifestno, DateTime manifestdate, int branchid, int PreparedBy, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@airline",SqlDbType.Int,4),
                                               new SqlParameter("@mawblno",SqlDbType.VarChar,30),
                                               new SqlParameter("@mawbldate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@flightno",SqlDbType.VarChar,15),
                                               new SqlParameter("@flightdate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@agent",SqlDbType.Int,4),
                                               new SqlParameter("@status",SqlDbType.VarChar,1),
                                               new SqlParameter("@handlinginfo",SqlDbType.VarChar,200),
                                               new SqlParameter("@fromport",SqlDbType.Int,4),
                                               new SqlParameter("@toport",SqlDbType.Int,4),
                                               new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                               new SqlParameter("@jobdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@iatacarrier",SqlDbType.VarChar,2),
                                               new SqlParameter("@manifestno", SqlDbType.VarChar, 15),
                                               new SqlParameter("@mfdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@preparedby",SqlDbType.Int),
                                               new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                               new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                               new SqlParameter("@jobno",SqlDbType.Int,4)};
            objp[0].Value = intAirlineID;
            objp[1].Value = strMawblno;
            objp[2].Value = datMawbldate;
            objp[3].Value = strFlightno;
            objp[4].Value = datFlightDate;
            objp[5].Value = intAgentID;
            objp[6].Value = strStatus;
            objp[7].Value = strHlgInfo;
            objp[8].Value = intFromPortID;
            objp[9].Value = intToPortID;
            objp[10].Value = strType;
            objp[11].Value = jobdate;
            objp[12].Value = iatacarrier;
            objp[13].Value = manifestno;
            objp[14].Value = manifestdate;
            objp[15].Value = PreparedBy;
            objp[16].Value = bid;
            objp[17].Value = cid;
            objp[18].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsAIEJobinfo", objp,"@jobno");
        }

        public void UpdAIEJobInfo(int intJobNo, int intAirlineID, string strMawblno, DateTime datMawbldate, string strFlightno, DateTime datFlightDate, int intAgentID, string strStatus, string strHlgInfo, int intFromPortID, int intToPortID, string strType, DateTime jobdate, string iatacarrier, string manifestno, DateTime manifestdate, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                               new SqlParameter("@airline",SqlDbType.Int,4),
                                               new SqlParameter("@mawblno",SqlDbType.VarChar,30),
                                               new SqlParameter("@mawbldate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@flightno",SqlDbType.VarChar,15),
                                               new SqlParameter("@flightdate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@agent",SqlDbType.Int,4),
                                               new SqlParameter("@status",SqlDbType.VarChar,1),
                                               new SqlParameter("@handlinginfo",SqlDbType.VarChar,200),
                                               new SqlParameter("@fromport",SqlDbType.Int,4),
                                               new SqlParameter("@toport",SqlDbType.Int,4),
                                               new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                               new SqlParameter("@jobdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@iatacarrier",SqlDbType.VarChar,2),
                                               new SqlParameter("@manifestno", SqlDbType.VarChar, 15),
                                               new SqlParameter("@mfdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                               new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = intJobNo;
            objp[1].Value = intAirlineID;
            objp[2].Value = strMawblno;
            objp[3].Value = datMawbldate;
            objp[4].Value = strFlightno;
            objp[5].Value = datFlightDate;
            objp[6].Value = intAgentID;
            objp[7].Value = strStatus;
            objp[8].Value = strHlgInfo;
            objp[9].Value = intFromPortID;
            objp[10].Value = intToPortID;
            objp[11].Value = strType;
            objp[12].Value = jobdate;
            objp[13].Value = iatacarrier;
            objp[14].Value = manifestno;
            objp[15].Value = manifestdate;
            objp[16].Value = bid;
            objp[17].Value = cid;
            ExecuteQuery("SPUpdAIEJobinfo", objp);
        }

        //Return all AE or AI Details
        public DataTable GetAIEAllDetails(string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strType;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPAIEJobInfo", objp);
        }

        public DataTable GetAIEDetail(int intJobNo, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intJobNo;
            objp[1].Value = strType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPSelAIEJobInfo";
            return ExecuteTable(SPName, objp);
        }


        //-------------------------------------------


        public DataTable GetLikeAIEJobDetails(int intjobno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intjobno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPLikeAIEJobNo";
            return ExecuteTable(SPName, objp);
        }

        public DataTable GetLikeOTHERAIEJobMBLNo(string mblno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mawblno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = mblno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPLikeOTHERAIEMblno";
            return ExecuteTable(SPName, objp);
        }
        public DataTable GetLikeAIEJobMBLNo(string mblno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mawblno", SqlDbType.VarChar, 150),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@cid",SqlDbType.Int)};
            objp[0].Value = mblno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPLikeAIEMblno";
            return ExecuteTable(SPName, objp);
        }
        public DataTable GetAIEDetailregion(int intJobNo, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intJobNo;
            objp[1].Value = strType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPSelAIEJobInfo";
            return ExecuteTable(SPName, objp);
        }
        public string GetMawBlnotNum(string mawblnum, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@mawblno",SqlDbType.VarChar,30),
                new SqlParameter("@trantype", SqlDbType.VarChar,2)
              };

            objp[0].Value = mawblnum;
            objp[1].Value = trantype;
            return ExecuteReader("SpGetMawblnoNum", objp);
        }


        public DataTable GETAEJOBINFO(int branchid, string jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.VarChar, 10),
             new SqlParameter("@jobno", SqlDbType.VarChar, 20)};
            objp[0].Value = branchid;
            objp[1].Value = jobno;
            return ExecuteTable("SPAEJOBINFO", objp);
        }

        public DataTable GETAIJOBINFO(int branchid, string jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.VarChar, 10),
             new SqlParameter("@jobno", SqlDbType.VarChar, 20)};
            objp[0].Value = branchid;
            objp[1].Value = jobno;
            return ExecuteTable("SPAIJOBINFO", objp);
        }

        //Dinesh

        public DataTable GetLikeAIEJobMBLNonew(string mblno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mawblno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = mblno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPLikeAIEMblnonew";
            return ExecuteTable(SPName, objp);
        }

        //muthu

        public DataTable GetAIagentid(string strType, int bid, int cid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1),
             new SqlParameter("@jobno",SqlDbType.Int)};
            objp[0].Value = strType;
            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = jobno;
            return ExecuteTable("sp_getagentname", objp);
        }

        public void insertshipperinvoice(string blno, string trantype, string shipperinvoice, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                     new SqlParameter("@shipperinvoice",SqlDbType.VarChar,100),
                                                     new SqlParameter("@branchid",SqlDbType.Int)};

            objp[0].Value = blno;
            objp[1].Value = trantype;
            objp[2].Value = shipperinvoice;
            objp[3].Value = branchid;

            ExecuteQuery("sp_insertshipperinvoice", objp);
        }

        public int InsAIEJobInfo(int intAirlineID, string strMawblno, DateTime datMawbldate, string strFlightno, DateTime
           datFlightDate, int intAgentID, string strStatus, string strHlgInfo, int intFromPortID, int intToPortID,
           string strType, DateTime jobdate, string iatacarrier, string manifestno, DateTime manifestdate, int branchid, int PreparedBy,
           int bid, int cid, string flightno2, DateTime flightdate2)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@airline",SqlDbType.Int,4),
                                               new SqlParameter("@mawblno",SqlDbType.VarChar,30),
                                               new SqlParameter("@mawbldate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@flightno",SqlDbType.VarChar,15),
                                               new SqlParameter("@flightdate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@agent",SqlDbType.Int,4),
                                               new SqlParameter("@status",SqlDbType.VarChar,1),
                                               new SqlParameter("@handlinginfo",SqlDbType.VarChar,200),
                                               new SqlParameter("@fromport",SqlDbType.Int,4),
                                               new SqlParameter("@toport",SqlDbType.Int,4),
                                               new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                               new SqlParameter("@jobdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@iatacarrier",SqlDbType.VarChar,2),
                                               new SqlParameter("@manifestno", SqlDbType.VarChar, 15),
                                               new SqlParameter("@mfdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@preparedby",SqlDbType.Int),
                                               new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                               new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                               new SqlParameter("@jobno",SqlDbType.Int,4),
                                                new SqlParameter("@flightno2",SqlDbType.VarChar,25),
                                                 new SqlParameter("@flightdate2",SqlDbType.DateTime)
            
            };
            objp[0].Value = intAirlineID;
            objp[1].Value = strMawblno;
            objp[2].Value = datMawbldate;
            objp[3].Value = strFlightno;
            objp[4].Value = datFlightDate;
            objp[5].Value = intAgentID;
            objp[6].Value = strStatus;
            objp[7].Value = strHlgInfo;
            objp[8].Value = intFromPortID;
            objp[9].Value = intToPortID;
            objp[10].Value = strType;
            objp[11].Value = jobdate;
            objp[12].Value = iatacarrier;
            objp[13].Value = manifestno;
            objp[14].Value = manifestdate;
            objp[15].Value = PreparedBy;
            objp[16].Value = bid;
            objp[17].Value = cid;
            objp[18].Direction = ParameterDirection.Output;
            objp[19].Value = flightno2;
            objp[20].Value = flightdate2;
            return ExecuteQuery("SPInsAIEJobinfo", objp, "@jobno");
        }

        public void UpdAIEJobInfo(int intJobNo, int intAirlineID, string strMawblno, DateTime datMawbldate, string strFlightno,
            DateTime datFlightDate, int intAgentID, string strStatus, string strHlgInfo, int intFromPortID, int intToPortID,
            string strType, DateTime jobdate, string iatacarrier, string manifestno, DateTime manifestdate, int bid, int cid, string flightno2, DateTime flightdate2)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                               new SqlParameter("@airline",SqlDbType.Int,4),
                                               new SqlParameter("@mawblno",SqlDbType.VarChar,30),
                                               new SqlParameter("@mawbldate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@flightno",SqlDbType.VarChar,15),
                                               new SqlParameter("@flightdate",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@agent",SqlDbType.Int,4),
                                               new SqlParameter("@status",SqlDbType.VarChar,1),
                                               new SqlParameter("@handlinginfo",SqlDbType.VarChar,200),
                                               new SqlParameter("@fromport",SqlDbType.Int,4),
                                               new SqlParameter("@toport",SqlDbType.Int,4),
                                               new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                               new SqlParameter("@jobdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@iatacarrier",SqlDbType.VarChar,2),
                                               new SqlParameter("@manifestno", SqlDbType.VarChar, 15),
                                               new SqlParameter("@mfdate", SqlDbType.SmallDateTime, 4),
                                               new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                               new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                new SqlParameter("@flightno2",SqlDbType.VarChar,25),
                                                 new SqlParameter("@flightdate2",SqlDbType.DateTime),};

            objp[0].Value = intJobNo;
            objp[1].Value = intAirlineID;
            objp[2].Value = strMawblno;
            objp[3].Value = datMawbldate;
            objp[4].Value = strFlightno;
            objp[5].Value = datFlightDate;
            objp[6].Value = intAgentID;
            objp[7].Value = strStatus;
            objp[8].Value = strHlgInfo;
            objp[9].Value = intFromPortID;
            objp[10].Value = intToPortID;
            objp[11].Value = strType;
            objp[12].Value = jobdate;
            objp[13].Value = iatacarrier;
            objp[14].Value = manifestno;
            objp[15].Value = manifestdate;
            objp[16].Value = bid;
            objp[17].Value = cid;
            objp[18].Value = flightno2;
            objp[19].Value = flightdate2;
            ExecuteQuery("SPUpdAIEJobinfo", objp);
        }
        public void UpdAIEJobInfo1(int intJobNo, int bid, int cid, string cargo)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                             
                                               new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                               new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                               new SqlParameter("@cargo",SqlDbType.VarChar,500)
                                                };

            objp[0].Value = intJobNo;

            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = cargo;
            ExecuteQuery("SPUpdAIEJobinfocargo", objp);
        }




        public DataTable GetAEQrywithoutJobinfonew(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.VarChar, 10),
            new SqlParameter("@cid", SqlDbType.VarChar, 10)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPAEQrywithoutJobinfonew", objp);
        }



        public DataTable GetAIQrywithoutJobinfonew(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.VarChar, 10),
             new SqlParameter("@cid", SqlDbType.VarChar, 10)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPAIQrywithoutJobinfonew", objp);
        }

        public DataTable getLikeAIEblnojob(string blno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 150),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                      new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@cid",SqlDbType.Int)};
            objp[0].Value = blno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPLikeAIEblnojob";
            return ExecuteTable(SPName, objp);
        }


    }
}