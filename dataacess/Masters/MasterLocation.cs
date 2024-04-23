using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
  public class MasterLocation : DBObject
    {
        //@locationname varchar(40)
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterLocation()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetLocationname(string locationname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationname", SqlDbType.VarChar, 40) };
          objp[0].Value = locationname;
          return ExecuteTable("SPSellocationnameNEW", objp);
      }
      //@cityname varchar(30)
      public DataTable GetCity(string cityname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cityname", SqlDbType.VarChar, 30) };
          objp[0].Value = cityname;
          return ExecuteTable("SPSelCityname", objp);
      }
      //@portid int
      public DataTable SelCityDeatils(int portid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
          objp[0].Value = portid;
          return ExecuteTable("SPSelCityDetails", objp);
      }
      //@locationid int
      public DataTable SelLocationDeatils(int locationid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationid", SqlDbType.Int) };
          objp[0].Value = locationid;
          return ExecuteTable("SPSelLocationDetails", objp);
      }
      //@locationname varchar(60),@portid int,@pincode varchar(6)
      public void InsertLocationDetails(string locationname, int portid, string pincode)
      {
          SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@locationname",SqlDbType.VarChar,60),
                                                      new SqlParameter("@portid",SqlDbType.Int),
                                                      new SqlParameter("@pincode",SqlDbType.VarChar,6)};

          objp[0].Value = locationname;
          objp[1].Value = portid;
          objp[2].Value = pincode;
          ExecuteQuery("SPInsLocationDet", objp);

      }
     // @locationname varchar(60),@portid int,@pincode varchar(6),@locationid int
      public void UpdateLocationDetails(string locationname, int portid, string pincode,int locationid)
      {

          SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@locationname",SqlDbType.VarChar,60), 
                                                                                  new SqlParameter("@portid",SqlDbType.Int),
                                                                                  new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                                                  new SqlParameter("@locationid",SqlDbType.Int)};
          objp[0].Value = locationname;
          objp[1].Value = portid;
          objp[2].Value = pincode;
          objp[3].Value = locationid;
          ExecuteQuery("SPUpdLocationDet", objp);
      }
      //@countryname
      public DataTable SelFillGrid(string countryname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryname", SqlDbType.VarChar,50) };
          objp[0].Value = countryname;
          return ExecuteTable("SPSelFillGrid", objp);
      }


      //@portname varchar(50)
      public DataTable CheckCityName(string portname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
          objp[0].Value = portname;
          return ExecuteTable("SPCheckCityName", objp);
      }

      public DataTable FillGridOnPageLoad2location()
      {
          //SqlParameter[] objp = new SqlParameter[] {  };
          //objp[0].Value = countryname;
          return ExecuteTable("SPFillGrid4Country");
      }



      public void DelLocationDetails(int locationid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationid", SqlDbType.Int) };
          objp[0].Value = locationid;
          ExecuteQuery("SPDelLocationDetails", objp);

      }

      //@Locationname varchar(30)
      public DataTable CheckDuplicateForLocation(string Locationname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Locationname", SqlDbType.VarChar, 30) };
          objp[0].Value = Locationname;
          return ExecuteTable("SPChechDuplicate4Location", objp);
      }

      //SPSelcitylocation 
      //(@locationname int, @Portid int)

      public DataTable Checklocationcity(string locationname, int Portid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationname", SqlDbType.VarChar,60),
                                                    new SqlParameter("@Portid", SqlDbType.Int)};
          objp[0].Value = locationname;
          objp[1].Value = Portid;
          return ExecuteTable("SPSelcitylocation", objp);
      }
      // SPCheckPincodeExist
      //(@pincode varchar(6))
      public DataTable Checkpincodeexist(string pincode)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode", SqlDbType.VarChar,60) };
          objp[0].Value = pincode;

          return ExecuteTable("SPCheckPincodeExist", objp);
      }
      public DataTable GetlocationnameNEWLocation(string locationname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationname", SqlDbType.VarChar, 40) };
          objp[0].Value = locationname;
          return ExecuteTable("SPSellocationnameNEWLocation", objp);
      }

      public DataTable GetlocationnameNEWpincode(string PINCode)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode", SqlDbType.VarChar, 6) };
          objp[0].Value = PINCode;
          return ExecuteTable("SPSellocationnameNEWpincode", objp);
      }
      public DataTable CheckDuplicateForLocationNew(string Locationname)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Locationname", SqlDbType.VarChar, 30) };
          objp[0].Value = Locationname;
          return ExecuteTable("SPChechDuplicate4Locationnew", objp);
      }


      public DataTable GetPincodeDetailsForLocation(string pincode)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pincode", SqlDbType.VarChar, 50) };
          objp[0].Value = pincode;
          return ExecuteTable("SPSelPincodeDetailsForLocation", objp);
      }

      public void UpdCityportInLocation(int cityport, int locationid)
      {
          SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@cityport",SqlDbType.VarChar,60),
                                                      new SqlParameter("@locationid",SqlDbType.Int)
                                                      };

          objp[0].Value = cityport;
          objp[1].Value = locationid;

          ExecuteQuery("SPUpdCityportInLocation", objp);
      }
      public DataTable CheckDuplicateForLocationPincode(string Locationname, string pincode)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Locationname", SqlDbType.VarChar, 50) ,
          new SqlParameter("@pincode", SqlDbType.VarChar, 6)};
          objp[0].Value = Locationname;
          objp[1].Value = pincode;
          return ExecuteTable("SPChechDuplicate4Locationwithpincode", objp);
      }
      public DataTable GetState(string statename)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30)
        };
          objp[0].Value = statename;

          return ExecuteTable("SPSelState", objp);
      }

      public string GetLocationnew(int  locationid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationid", SqlDbType.Int) };
          objp[0].Value = locationid;
          return ExecuteReader("sp_locationname", objp);
      }


      //Dinesh
      public DataTable GetlocationDetails4Grid()
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter() };

          return ExecuteTable("SPSelMasterlocation4Grid");
      }

      //masterlocationnewform
      public DataTable GetLocName(string locname)
      {
          SqlParameter[] objp = new SqlParameter[] 
             {                
                 new SqlParameter("@locname",SqlDbType.VarChar,10),
             };
          objp[0].Value = locname;
          return ExecuteTable("GetLocName", objp);

      }

      public DataTable GetDisrictName(string disname)
      {
          SqlParameter[] objp = new SqlParameter[] 
             {                
                 new SqlParameter("@disname",SqlDbType.VarChar,10),
             };
          objp[0].Value = disname;
          return ExecuteTable("GetDisrictName", objp);
      }
      public DataTable GetStateName(string stname)
      {
          SqlParameter[] objp = new SqlParameter[] 
             {                
                 new SqlParameter("@stname",SqlDbType.VarChar,10),
             };
          objp[0].Value = stname;
          return ExecuteTable("GetStateName", objp);
      }
      public DataTable GetCountryName(string cname)
      {
          SqlParameter[] objp = new SqlParameter[] 
             {                
                 new SqlParameter("@cname",SqlDbType.VarChar,10),
             };
          objp[0].Value = cname;
          return ExecuteTable("GetCountryName", objp);
      }

      public DataTable GetPortName(string pname)
      {
          SqlParameter[] objp = new SqlParameter[] 
             {                
                 new SqlParameter("@pname",SqlDbType.VarChar,10),
             };
          objp[0].Value = pname;
          return ExecuteTable("GetPortName", objp);
      }
      public DataTable chklocnamepincode(string locname, string pincode)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locname", SqlDbType.VarChar, 50),
                                                      new SqlParameter("@pincode", SqlDbType.VarChar, 6)              };
          objp[0].Value = locname;
          objp[1].Value = pincode;
          return ExecuteTable("spchklocnamepincode", objp);

      }

      public void InsertLocationDtls(string locationname, int portid, int stateid, int districtid, int countryid, string pincode, string circle, string potype)
      {
          SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@locationname",SqlDbType.VarChar,60),
                                                     new SqlParameter("@portid",SqlDbType.Int),
                                                      new SqlParameter("@stateid",SqlDbType.Int),
                                                      new SqlParameter("@districtid",SqlDbType.Int),
                                                      new SqlParameter("@countryid",SqlDbType.Int),
                                                      new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                      new SqlParameter("@circle",SqlDbType.VarChar,10),
                                                      new SqlParameter("@potype",SqlDbType.VarChar,10)};


          objp[0].Value = locationname;
          objp[1].Value = portid;
          objp[2].Value = stateid;
          objp[3].Value = districtid;
          objp[4].Value = countryid;
          objp[5].Value = pincode;
          objp[6].Value = circle;
          objp[7].Value = potype;
          ExecuteQuery("SPInsLocationDtls", objp);

      }

      public void UpdateLocationDtls(string locationname, int portid, int stateid, int districtid, int countryid, string pincode, string circle, string potype, int locationid)
      {

          SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@locationname",SqlDbType.VarChar,60), 
                                                                                  new SqlParameter("@portid",SqlDbType.Int),
                                                                                  new SqlParameter("@stateid",SqlDbType.Int),
                                                                                  new SqlParameter("@districtid",SqlDbType.Int),
                                                                                  new SqlParameter("@countryid",SqlDbType.Int),
                                                                                  new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                                                  
                                                                                   new SqlParameter("@circle",SqlDbType.VarChar,10),
                                                                                   new SqlParameter("@potype",SqlDbType.VarChar,10),
                                                                                  new SqlParameter("@locationid",SqlDbType.Int)};
          objp[0].Value = locationname;
          objp[1].Value = portid;
          objp[2].Value = stateid;
          objp[3].Value = districtid;
          objp[4].Value = countryid;
          objp[5].Value = pincode;
          objp[6].Value = circle;
          objp[7].Value = potype;
          objp[8].Value = locationid;
          ExecuteQuery("SPUpdLocationDtls", objp);
      }
      public DataTable GetLocationDtls4Grid()
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter() };

          return ExecuteTable("SPMasterLocation4Grid");
      }
      public DataTable SelLocationDtls(int locationid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@locationid", SqlDbType.Int) };
          objp[0].Value = locationid;
          return ExecuteTable("SPSelLocationDtls", objp);
      }
      public DataTable StateGstcode(int stateid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateid", SqlDbType.Int) };
          objp[0].Value = stateid;
          return ExecuteTable("SPStateGstcode", objp);
      }
      public DataTable SelCityDetailsnew(int portid)
      {
          SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
          objp[0].Value = portid;
          return ExecuteTable("SPSelCityDetailsnew", objp);
      }
    }
}
