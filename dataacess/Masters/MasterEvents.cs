using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterEvents:DBObject
    {
        //Check the Event already exist or not.

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterEvents()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable CheckEventExist(string Eventname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@eventname", SqlDbType.VarChar, 100) };
            objp[0].Value = Eventname;
            return ExecuteTable("SPEventidEName", objp);

        }


        //Insert Event Name.
        public void InsertEvent(string Eventname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@eventname", SqlDbType.VarChar, 100) };
            objp[0].Value = Eventname;
            ExecuteQuery("SPInsEventDetails", objp);
        }

        //Update Event Name.
        public void UpdateEvent(int Eventid, string Eventname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@eventname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@eventid",SqlDbType.Int,4)  };
            objp[0].Value = Eventname;
            objp[1].Value = Eventid;
            ExecuteQuery("SPUpdEventDetails", objp);

        }

        //Get Eventid based on Eventname. 
        public int GetEventid(string Eventname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@eventname", SqlDbType.VarChar, 100) };
            objp[0].Value = Eventname;
            return int.Parse(ExecuteReader("SPEventidEName", objp));
        }

        //Get Eventname based on Eventid. 
        public DataTable GetEventName(int Eventid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@eventid", SqlDbType.Int, 4) };
            objp[0].Value = Eventid;
            return ExecuteTable("SPEventnameEId", objp);
            
        }


        //Methods for windows Application.
        public DataTable LikeEventName(string eventname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@eventname", SqlDbType.VarChar, 100) };
            objp[0].Value = eventname;
            return ExecuteTable("SpLikeEvents", objp);
        }
        ///GURU

        //gridevent
        public DataTable GetGridview()
        {
            return ExecuteTable("Spgridevent");
        }
        //DelEvents
        public void DelEvent(int eventid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@eventid", SqlDbType.Int) };
            objp[0].Value = eventid;
            ExecuteQuery("SPDelName", objp);
        }

        public DataTable GetTOPEventRows()
        {
            return ExecuteTable("SPEventTopRows");
        }
        public void DelTableEvent(int eventid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@eventid", SqlDbType.Int)
            
        };
            objp[0].Value = eventid;
            ExecuteQuery("Sp_DelEvent", objp);

        }

    }
}
