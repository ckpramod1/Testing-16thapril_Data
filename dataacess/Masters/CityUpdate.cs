using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
    public class CityUpdate : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public CityUpdate()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetStatename(string statename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30) };
            objp[0].Value = statename;
            return ExecuteTable("SPGetStateName", objp);
        }
        public DataTable GetCity(string cityname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cityname", SqlDbType.VarChar, 30) };
            objp[0].Value = cityname;
            return ExecuteTable("SPSelCityname", objp);
        }

        public DataTable GetLocationname(string locationname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationname", SqlDbType.VarChar, 40) };
            objp[0].Value = locationname;
            return ExecuteTable("SPSellocationname", objp);
        }

        public DataTable GetPinCode(string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode", SqlDbType.VarChar, 6) };
            objp[0].Value = pincode;
            return ExecuteTable("SPSelPinCode", objp);
        }

        public DataTable GetPincode4location(string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode ", SqlDbType.VarChar, 6) };
            objp[0].Value = pincode;
            return ExecuteTable("SPSelPinCode4location", objp);
        }


        public void Updport4location(int portid, int locationid, string pincode)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                     new SqlParameter("@locationid",SqlDbType.Int),
                                                     new SqlParameter("@pincode",SqlDbType.VarChar,6)
                                                     };
            objp[0].Value = portid;
            objp[1].Value = locationid;
            objp[2].Value = pincode;
            ExecuteQuery("SPInsLocation", objp);
        }

        public DataTable GetLocwithid(string locationname, string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationname", SqlDbType.VarChar, 40),
                                                       new SqlParameter("@pincode", SqlDbType.VarChar, 40)};
            objp[0].Value = locationname;
            objp[1].Value = pincode;
            return ExecuteTable("SPSellocationnamewithid", objp);
        }


        //(@locid int)
        public DataTable GetLocName(int locid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locid", SqlDbType.Int),
                                                      };
            objp[0].Value = locid;

            return ExecuteTable("SPGetLocationWithid", objp);
        }

        //(@locationid int, @stateid int,@pincode varchar(6))
        public DataTable GetCity4Loc(int stateid, int locationid, string pincode)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@stateid",SqlDbType.Int), 
                                                     new SqlParameter("@locationid",SqlDbType.Int),
                                                     new SqlParameter("@pincode",SqlDbType.VarChar,6)
                                                     };
            objp[0].Value = stateid;
            objp[1].Value = locationid;
            objp[2].Value = pincode;
            return ExecuteTable("SPGetCity4LocidNew", objp);
        }

        //bhuvana

        public string GetPort4loct(string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode", SqlDbType.VarChar,6),
                                                      };
            objp[0].Value = pincode;

            return ExecuteReader("SPGetPort4PinCode", objp);
        }
        public DataTable CheckDuplicateForLocationPincode(string Locationname, string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Locationname", SqlDbType.VarChar, 30) ,
          new SqlParameter("@pincode", SqlDbType.VarChar, 6)};
            objp[0].Value = Locationname;
            objp[1].Value = pincode;
            return ExecuteTable("SPChechDuplicate4Locationwithpincode", objp);
        }

        public int Getname4state(string statename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30) };
            objp[0].Value = statename;
            return int.Parse(ExecuteReader("SPSelStateName", objp));

        }
        public string GetPort4loctid(int locationid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locid", SqlDbType.VarChar,6),
                                                      };
            objp[0].Value = locationid;

            return ExecuteReader("SPGetCity4Locid", objp);
        }


        //ARUN

        public void Insertport4location(string pincode, string location, int cityid, int stateid)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@pincode",SqlDbType.VarChar,6), 
                                                     new SqlParameter("@location",SqlDbType.VarChar,510),
                                                     new SqlParameter("@cityport",SqlDbType.Int),
                                                      new SqlParameter("@stateid",SqlDbType.Int)
                                                     };
            objp[0].Value = pincode;
            objp[1].Value = location;
            objp[2].Value = cityid;
            objp[3].Value = stateid;
            ExecuteQuery("SPInsLocValues", objp);
        }

        public DataTable GetPortNameForNew(string PortName)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@portname",SqlDbType.VarChar,50)
                                                     
                                                     };
            objp[0].Value = PortName;

            return ExecuteTable("SPGetPortNameForNew", objp);
        }

    }
}
