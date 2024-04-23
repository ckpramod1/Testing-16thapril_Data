using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using DataAccess.Masters;
namespace DataAccess
{
    public class SailingSchedule : DBObject
    {
        public int intTemp;
        public MasterVessel vslObj = new MasterVessel();
        public MasterPort portObj = new MasterPort();
        public DataTable DtTemp;

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public SailingSchedule()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsSSHead(int intVessel, string strVoyage)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                new SqlParameter("@ssid",SqlDbType.Int,4),
                                                new SqlParameter("@vesselid",SqlDbType.Int),
                                                new SqlParameter("@voyage",SqlDbType.VarChar,15)
                                                     };
            objp[0].Direction = ParameterDirection.Output;
            objp[1].Value = intVessel;
            objp[2].Value = strVoyage;
            
            intTemp = ExecuteQuery("SPInsSScheduleHead", objp, "@ssid");
            return intTemp;
        }
        public DataTable GetSSHead(int intVessel, string strVoyage)
        {
            intTemp = 0;
            SqlParameter[] objp = new SqlParameter[] {
                                                new SqlParameter("@vesselid",SqlDbType.Int),
                                                new SqlParameter("@voyage",SqlDbType.VarChar,15)
                                                     };
            objp[0].Value = intVessel;
            objp[1].Value = strVoyage;
            return ExecuteTable("SPCheckScheduleHead", objp);
        }


        public string GetVessel(int intSSid)
        {
            string strTemp = "";
            intTemp = 0;
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@ssid", SqlDbType.Int, 4) };
            objp[0].Value = intSSid;
            DtTemp = ExecuteTable("SPSelVslForSSid", objp);
            if (DtTemp.Rows.Count > 0)
            {
                strTemp = DtTemp.Rows[0][0].ToString();
            }
            return strTemp;
        }

        public void InsSSDetail(int intSSiD, int intPort, DateTime datETA, DateTime datETD, char chrFD)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                new SqlParameter("@ssid",SqlDbType.Int,4),
                                                new SqlParameter("@portid",SqlDbType.Int),
                                                new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                new SqlParameter("@fd",SqlDbType.Char,1)
                                                     };
            objp[0].Value = intSSiD;
            objp[1].Value = intPort;
            objp[2].Value = datETA;
            objp[3].Value = datETD;
            objp[4].Value = chrFD;
            ExecuteQuery("SPInsSSDetail", objp);
        }

        public void UpdSSDetail(int intSSiD, int intPort, DateTime datETA, DateTime datETD, char chrFD)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                new SqlParameter("@ssid",SqlDbType.Int,4),
                                                new SqlParameter("@portid",SqlDbType.Int),
                                                new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                new SqlParameter("@fd",SqlDbType.Char,1)
                                                     };
            objp[0].Value = intSSiD;
            objp[1].Value = intPort;
            objp[2].Value = datETA;
            objp[3].Value = datETD;
            objp[4].Value = chrFD;

            ExecuteQuery("SPUpdSSDetail", objp);
        }

        public void DelSSDetail(int intSSiD, int intPort)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                new SqlParameter("@ssid",SqlDbType.Int,4),
                                                new SqlParameter("@portid",SqlDbType.Int)
                                                     };
            objp[0].Value = intSSiD;
            objp[1].Value = intPort;
            ExecuteQuery("SPDelSSDetail", objp);
        }

        public DataTable GetSSDetail(int intSSID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@ssid",SqlDbType.Int,4)
                                                      };
            objp[0].Value = intSSID;
            return ExecuteTable("SPSelSSDetail", objp);
        }
        public DataTable GetAllConnSSDetail(int intSSID, string strToPort)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@ssid",SqlDbType.Int,4),
                                                        new SqlParameter("@fromport",SqlDbType.VarChar,100)
                                                      };
            objp[0].Value = intSSID;
            objp[1].Value = strToPort;
            return ExecuteTable("SPSelALLSchedule", objp);
        }
        public DataTable GetConSSDetail(int intSSID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@ssid",SqlDbType.Int,4)
                                                      };
            objp[0].Value = intSSID;
            return ExecuteTable("SPSelConSchedule", objp);
        }

        public DataTable GetConSSids(int intSSID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@ssid",SqlDbType.Int,4)
                                                      };
            objp[0].Value = intSSID;
            return ExecuteTable("SPGetConSSids", objp);
        }

        public void DelConSSids(int intSSID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@ssid",SqlDbType.Int,4)
                                                      };
            objp[0].Value = intSSID;
            ExecuteQuery("SPDelConnSS", objp);
        }

        public void InsConSSids(int intSSID, int intConSSID)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                                    new SqlParameter("@ssid1",SqlDbType.Int,4),
                                                                    new SqlParameter("@ssid2",SqlDbType.Int,4)
                                                                  };
            objp[0].Value = intSSID;
            objp[1].Value = intConSSID;
            ExecuteQuery("SPInsConSSids", objp);
        }

        public DataTable GetDirectVessel(string strFromPort, string strToPort)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                                    new SqlParameter("@from",SqlDbType.VarChar,50),
                                                                    new SqlParameter("@to",SqlDbType.VarChar,50)
                                                                  };

            //objp[0].Value=portObj.GetNPortid(strFromPort);
            //objp[1].Value = portObj.GetNPortid(strToPort);
            objp[0].Value = strFromPort;
            objp[1].Value = strToPort;
            return ExecuteTable("SPSelSCheduleDirect", objp);
        }


        public DataTable GetConnectedVessel(string strFromPort, string strToPort)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                                    new SqlParameter("@pol",SqlDbType.Int),
                                                                    new SqlParameter("@pod",SqlDbType.Int)
                                                                  };

            objp[0].Value = portObj.GetNPortid(strFromPort);
            objp[1].Value = portObj.GetNPortid(strToPort);
            return ExecuteTable("SPSelScheduleConnected", objp);
        }

        public DataTable GetCurrentSchedule()
        {
            return ExecuteTable("SPSelScheduleLst");
        }
        public DataTable GetFromOrToPortList(char chrPrtType)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                  new SqlParameter("@option",SqlDbType.Char,1)};
            objp[0].Value = chrPrtType;
            return ExecuteTable("SPSelSSFromToPort", objp);
        }
        public DataTable SelAllCurrentSchedule4mail()
        {
            return ExecuteTable("SPSelAllCurrentSchedule4mail");
        }
        public DataTable GetMailALLDirectConnSchedule()
        {
            return ExecuteTable("SPSelAllCurrentSchedule4mail");
        }
        public void UpdSSHeadVoyage(int ssid, int vesselid, string voyage)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@ssid",SqlDbType.Int,4),
                                                         new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                         new SqlParameter("@voyage",SqlDbType.VarChar,15)};
            objp[0].Value = ssid;
            objp[1].Value = vesselid;
            objp[2].Value = voyage;
            ExecuteQuery("SPUpdSScheduleHead", objp);
        }
    }
}