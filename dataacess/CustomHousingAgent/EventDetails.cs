using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.CustomHousingAgent
{
    public class EventDetails : DBObject
    {
        DataAccess.Masters.MasterEvents evntObj = new DataAccess.Masters.MasterEvents();
        int intEvntID;


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public EventDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        //Insert the CH Event Details
        public void InsEventDetails(int intJobno, string strEvent, DateTime datEventDate, string strRemarks, int bid, int cid)
        {
            intEvntID = evntObj.GetEventid(strEvent);

            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                       new SqlParameter("@eventid",SqlDbType.Int,4),
                                                       new SqlParameter("@eventdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intJobno;
            objp[1].Value = intEvntID;
            objp[2].Value = datEventDate;
            objp[3].Value = strRemarks;
            objp[4].Value = bid;
            objp[5].Value = cid;
            ExecuteQuery("SPInsCHEventDetails", objp);
        }
        //Update the CH Event Details
        public void UpdEventDetails(int intJobNo, string strEventName, DateTime datEventDate, string strRemarks, int bid, int cid)
        {
            intEvntID = evntObj.GetEventid(strEventName);

            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                       new SqlParameter("@eventid",SqlDbType.Int,4),
                                                       new SqlParameter("@eventdate",SqlDbType.SmallDateTime),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intJobNo;
            objp[1].Value = intEvntID;
            objp[2].Value = datEventDate;
            objp[3].Value = strRemarks;
            objp[4].Value = bid;
            objp[5].Value = cid;
            ExecuteQuery("SPUpdCHEventDetails", objp);
        }
        //Delete the CH Event Details
        public void DelEventDetails(int intJobNo, string strEventName, int bid, int cid)
        {
            intEvntID = evntObj.GetEventid(strEventName);

            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@jobno",SqlDbType.Int,4), 
                                                      new SqlParameter("@eventid",SqlDbType.Int,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intJobNo;
            objp[1].Value = intEvntID;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPDelCHEventDetail", objp);
        }
        //Get the CH Event Details
        public DataTable GetEventDetails(int intJobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4) ,
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intJobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelCHEventDetails", objp);
        }
    }
}
