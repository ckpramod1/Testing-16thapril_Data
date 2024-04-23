using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
   public class MasterPort : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterPort()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsertPortDetails(string portcode, string portname, string country, string sector)
       {
           int countryid = GetCountryid(country);
           int sectorid = GetSectorid(sector);
           string pcode = portcode.Equals("") ? "null" : portcode;
           SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@portcode",SqlDbType.VarChar,6),
                                                                                   new SqlParameter("@portname",SqlDbType.VarChar,30),
                                                                                   new SqlParameter("@countryid",SqlDbType.Int),
                                                                                   new SqlParameter("@sectorid",SqlDbType.Int)};
           objp[0].Value = pcode;
           objp[1].Value = portname;
           objp[2].Value = countryid;
           objp[3].Value = sectorid;

           ExecuteQuery("SPInsPortDetails", objp);
          
       }
      
       public void UpdatePortDetails(int portid, string portcode, string portname, string country, string sector)
       {
           int countryid = GetCountryid(country);
           int sectorid = GetSectorid(sector);
           SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@portid",SqlDbType.Int), 
                                                                                  new SqlParameter("@portcode",SqlDbType.VarChar,6),
                                                                                   new SqlParameter("@portname",SqlDbType.VarChar,30),
                                                                                   new SqlParameter("@countryid",SqlDbType.Int),
                                                                                   new SqlParameter("@sectorid",SqlDbType.Int)};
           objp[0].Value = portid;
           objp[1].Value = portcode;
           objp[2].Value = portname;
           objp[3].Value = countryid;
           objp[4].Value = sectorid;

           ExecuteQuery("SPUpdPortDetails",objp);
       }

       public void InsertPortDetails(string portcode, string portname, string country, string sector, int stateid, int districtid, string stdcode, string airpodecode)
       {
           int countryid = GetCountryid(country);
           int sectorid = GetSectorid(sector);
           string pcode = portcode.Equals("") ? "null" : portcode;
           SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@portcode",SqlDbType.VarChar,6),
                                                                                   new SqlParameter("@portname",SqlDbType.VarChar,30),
                                                                                   new SqlParameter("@countryid",SqlDbType.Int),
                                                                                   new SqlParameter("@sectorid",SqlDbType.Int),
                                                                                    new SqlParameter("@stateid",SqlDbType.Int),
                                                                                    new SqlParameter("@districtid",SqlDbType.Int ),
                                                                                    new SqlParameter("@stdcode",SqlDbType.VarChar ,10),
                                                                                    new SqlParameter("@airportcode",SqlDbType.VarChar ,6)
           };
           objp[0].Value = pcode;
           objp[1].Value = portname;
           objp[2].Value = countryid;
           objp[3].Value = sectorid;
           objp[4].Value = stateid;
           objp[5].Value = districtid;
           objp[6].Value = stdcode;
           objp[7].Value = airpodecode;

           ExecuteQuery("SPInsPortDetails", objp);

       }

       public void UpdatePortDetails(int portid, string portcode, string portname, string country, string sector, int stateid, int districtid, string stdcode, string airpodecode)
       {
           int countryid = GetCountryid(country);
           int sectorid = GetSectorid(sector);
           SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@portid",SqlDbType.Int), 
                                                                                  new SqlParameter("@portcode",SqlDbType.VarChar,6),
                                                                                   new SqlParameter("@portname",SqlDbType.VarChar,30),
                                                                                   new SqlParameter("@countryid",SqlDbType.Int),
                                                                                   new SqlParameter("@sectorid",SqlDbType.Int),
                                                                                    new SqlParameter("@stateid",SqlDbType.Int),
                                                                                    new SqlParameter("@districtid",SqlDbType.Int ),
                                                                                    new SqlParameter("@stdcode",SqlDbType.VarChar ,10),
                                                                                    new SqlParameter("@airportcode",SqlDbType.VarChar ,6)

           };
           objp[0].Value = portid;
           objp[1].Value = portcode;
           objp[2].Value = portname;
           objp[3].Value = countryid;
           objp[4].Value = sectorid;
           objp[5].Value = stateid;
           objp[6].Value = districtid;
           objp[7].Value = stdcode;
           objp[8].Value = airpodecode;

           ExecuteQuery("SPUpdPortDetails", objp);
       }


       public DataTable RetrievePortcodeDetails(string portcode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portcode", SqlDbType.VarChar, 6) };
           objp[0].Value = portcode;
           return ExecuteTable("SPSelPortCode", objp);
       }
      
       public DataTable RetrievePortnameDetails(string portname)
           {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 30) };
           objp[0].Value = portname;
            return ExecuteTable("SPSelPortName", objp);
       }

       public DataTable GetLikePort4grd(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@PortName", SqlDbType.VarChar, 30) };
           objp[0].Value = portname;
           return ExecuteTable("SPLikePort4grd", objp);

       }
      
       //Show Sectorname based on Countryname  
       public int GetSectoridCN(string countryname)
       {
           //Get Sectorid based on CountryName
           int sectorid = 0;
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryname", SqlDbType.VarChar, 30) };
           objp[0].Value = countryname ;
           sectorid = int.Parse(ExecuteReader("SPSectorIdCName", objp));
           return sectorid;
      }

       public string GetSectorName(string countryname)
       {
           //Get Sectorid based on CountryName
           int sectorid = GetSectoridCN(countryname);
           if (sectorid == 0)
           {
               return "";
           }
           else
           {
               //Get SectorName based on Sectorid
               SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorid", SqlDbType.Int) };
               objp[0].Value = sectorid;
               return ExecuteReader("SPSectorNameSId", objp);
           }
       }

       //Get Portid based on Portcode 
       public int GetPortid(string portcode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portcode", SqlDbType.VarChar, 6) };
           objp[0].Value = portcode;

           return int.Parse(ExecuteReader("SPPortIdPCode", objp));
       }

       //Get Portid based on PortName 
       public int GetNPortid(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar,30) };
           objp[0].Value = portname;
           return int.Parse(ExecuteReader("SPPortIdPName", objp));
                 
       }

       //Get portname based on portid. 
       public string GetPortname(int portid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
           objp[0].Value = portid;
           return ExecuteReader("SPPortnamePId", objp);
       }

       //Get Portcode based on portname.
       public string GetPortcode(string portname)
       {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 30) };
           objp[0].Value = portname;
           return ExecuteReader("SPPortcodePName", objp);
        }

       //Get Portname based on Portcode.  
       public string GetPortname(string portcode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portcode", SqlDbType.VarChar, 6) };
           objp[0].Value = portcode;
           return ExecuteReader("SPPortnamePCode", objp);
        }

       //Get Sectorid based on Sectorname 
       public int GetSectorid(string sectorname)
       {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 30) };
           objp[0].Value = sectorname;
           string result = ExecuteReader("SPSectoridSName", objp);
           if (result.Equals("0"))
               return 0;
           else
            return int.Parse(result.ToString());
        }

       //Get Countryid based on Countryname 
       public int GetCountryid(string countryname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryname", SqlDbType.VarChar, 30) };
           objp[0].Value = countryname;
           string result = ExecuteReader("SPCountryidCName", objp);
           if (result.Equals("0"))
               return 0;
           else
               return int.Parse(result.ToString());
           
       }

       //Get Countryname based on Countryid  
       public string GetCountryname(int countryid)
       {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryid", SqlDbType.Int) };
           objp[0].Value = countryid;
            return ExecuteReader("SPCountrynameCId", objp);
       }

       public DataTable GetAllBranchNameforPortName()
       {
           return ExecuteTable("SPGetBranchFromPortName");
       }

       // *******Methods For Windows Application.*********
       public DataTable GetLikePort(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@PortName", SqlDbType.VarChar,30) };
           objp[0].Value = portname;
           return  ExecuteTable("SPLikePort", objp);

        }

       //Agent Rebate 
        public DataTable GetLikeIndianPortname(string portname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
            objp[0].Value = portname;
            return ExecuteTable("SPLikeIndianPortNames", objp);
        }
        public DataTable GetLikeForeignPortname(string portname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
            objp[0].Value = portname;
            return ExecuteTable("SPLikeForeignPortNames", objp);
        }
       public DataTable GetSalesLikePort(string portname, int salesid, string trantype, int bid)
       {
           SqlParameter[] objp = new SqlParameter[] 
        { 
              new SqlParameter("@PortName", SqlDbType.VarChar, 30),
              new SqlParameter ("@salesid",SqlDbType .Int ,4),
              new SqlParameter ("@trantype",SqlDbType .VarChar ,2),
              new SqlParameter ("@bid",SqlDbType .TinyInt)
        };
           objp[0].Value = portname;
           objp[1].Value = salesid;
           objp[2].Value = trantype;
           objp[3].Value = bid;
           return ExecuteTable("SPLikeSalesPort", objp);

       }
       public DataTable GetLikePortforbranch(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
           objp[0].Value = portname;
           return ExecuteTable("SPlikeportfromdivision", objp);

       }
       public void UpdAirPortCode(int portid, string airportcode)
       {

           SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                     new SqlParameter("@airportcode",SqlDbType.VarChar,6)
                                                     };
           objp[0].Value = portid;
           objp[1].Value = airportcode;
           ExecuteQuery("SPUpdAirPortCode", objp);
       }
       //bharathi

       public DataTable GetLikeDistrict(string districtname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtname", SqlDbType.VarChar, 30) };
           objp[0].Value = districtname;
           return ExecuteTable("SPSelMasterDistrict4Port", objp);

       }
       public void InsMasterPort(string portcode, string portname, int countryid, int sectorid, string unloccode, string airportcode, int districtid, int stateid, string stdcode)
       {

           SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@portcode",SqlDbType.VarChar,6), 
                                                     new SqlParameter("@portname",SqlDbType.VarChar,50),
                                                     new SqlParameter("@countryid",SqlDbType.Int),
                                                     new SqlParameter("@sectorid",SqlDbType.Int),
                                                     new SqlParameter("@unloccode",SqlDbType.VarChar,5),
                                                     new SqlParameter("@airportcode",SqlDbType.VarChar,6),
                                                     new SqlParameter("@districtid",SqlDbType.Int),
                                                     new SqlParameter("@stateid",SqlDbType.Int),
                                                     new SqlParameter("@stdcode",SqlDbType.VarChar,10)
                                                    };
           objp[0].Value = portcode;
           objp[1].Value = portname;
           objp[2].Value = countryid;
           objp[3].Value = sectorid;
           objp[4].Value = unloccode;
           objp[5].Value = airportcode;
           objp[6].Value = districtid;
           objp[7].Value = stateid;
           objp[8].Value = stdcode;
           ExecuteQuery("SPInsMasterPort", objp);
       }
       public DataTable GetPortDetails(int portid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
           objp[0].Value = portid;
           return ExecuteTable("SPSelMasterPort", objp);

       }

       public DataTable GetPortDetails4name(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50
               ) };
           objp[0].Value = portname ;
           return ExecuteTable("SPSelMasterPort4name", objp);

       }
       public DataTable GetPortCodeDetails(string portcode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portcode", SqlDbType.VarChar, 6) };
           objp[0].Value = portcode;
           return ExecuteTable("SPSelPortCode", objp);

       }
       public DataTable GetPortNameDetails(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
           objp[0].Value = portname;
           return ExecuteTable("SPSelPortNameNew", objp);

       }
       public DataTable GetPortNameDetails4event(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
           objp[0].Value = portname;

           return ExecuteTable("SPSelMasterPortName4event", objp);

       }
       public void UpdMasterPort(string portcode, string portname, int countryid, int sectorid, string unloccode, string airportcode, int districtid, int stateid, string stdcode, int portid)
       {

           SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@portcode",SqlDbType.VarChar,6), 
                                                     new SqlParameter("@portname",SqlDbType.VarChar,50),
                                                     new SqlParameter("@countryid",SqlDbType.Int),
                                                     new SqlParameter("@sectorid",SqlDbType.Int),
                                                     new SqlParameter("@unloccode",SqlDbType.VarChar,5),
                                                     new SqlParameter("@airportcode",SqlDbType.VarChar,6),
                                                     new SqlParameter("@districtid",SqlDbType.Int),
                                                     new SqlParameter("@stateid",SqlDbType.Int),
                                                     new SqlParameter("@stdcode",SqlDbType.VarChar,10),
                                                     new SqlParameter("@portid",SqlDbType.Int)
                                                    };
           objp[0].Value = portcode;
           objp[1].Value = portname;
           objp[2].Value = countryid;
           objp[3].Value = sectorid;
           objp[4].Value = unloccode;
           objp[5].Value = airportcode;
           objp[6].Value = districtid;
           objp[7].Value = stateid;
           objp[8].Value = stdcode;
           objp[9].Value = portid;
           ExecuteQuery("SPUpdMasterPort", objp);
       }
       public DataTable GetPortDetails4Grid()
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter() };

           return ExecuteTable("SPSelMasterPort4Grid");
       }


       public DataTable GetPortDetails4GridPage()
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter() };

           return ExecuteTable("SPSelMasterPort4GridPage");
       }

       public DataTable GetPortName(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
           objp[0].Value = portname;

           return ExecuteTable("SPSelPortNameExist", objp);

       }

       public DataTable GetPortDetailsNew(int portid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
           objp[0].Value = portid;
           return ExecuteTable("SPSelMasterPortNew", objp);

       }

       public DataTable SPSelGetPortNameFromId(int portid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
           objp[0].Value = portid;
           return ExecuteTable("SPSelGetPortNameFromId", objp);

       }
       public int SPSelPortByCountryId(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@port", SqlDbType.VarChar, 50) };
           objp[0].Value = portname;
           return int.Parse(ExecuteReader("SPSelPortByCountryId", objp));

       }
       /////bharathi
       public string GetStatename(int StateId)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateid", SqlDbType.Int) };
           objp[0].Value = StateId;
           return ExecuteReader("SPSelGetStateNameId", objp);
       }


       public string GetStateDistrictname(int DistrictId)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtid", SqlDbType.Int) };
           objp[0].Value = DistrictId;
           return ExecuteReader("SPSelGetDistrictNameId", objp);
       }

       //Arun
       public string GetPortnameNew(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50) };
           objp[0].Value = portname;
           return ExecuteReader("SPPort", objp);
       }

       //Arun
       public string GetPortCodefrmPort(int portid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int, 4) };
           objp[0].Value = portid;
           return ExecuteReader("SPGetPortCodefrmportid", objp);

       } 
       //muthu
       public DataTable GetPortNameDetailsnew(string portname, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar,2)};
           objp[0].Value = portname;
           objp[1].Value = trantype;
           return ExecuteTable("SPSelPortNameNewargenti", objp);

       }
       public void Updapprovedport(string bookingno, string approved)
       {

           SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@shiprefno",SqlDbType.VarChar,50), 
                                                     new SqlParameter("@approved",SqlDbType.Char,1)
                                                     };
           objp[0].Value = bookingno;
           objp[1].Value = approved;
           ExecuteQuery("sp_updateapprovedfield", objp);
       }
       public int sp_countryidprt(int portid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
           objp[0].Value = portid;
           return int.Parse(ExecuteReader("sp_countryidprt", objp));

       }
       public void Updapprovedagentinabooking(string bookingno, int bid, string trantype)
       {

           SqlParameter[] objp = new SqlParameter[]
                                                    { 
                                                     new SqlParameter("@shiprefno",SqlDbType.VarChar,50), 
                                                     new SqlParameter("@bid",SqlDbType.Int),
                                                     new SqlParameter("@trantype",SqlDbType.VarChar,2)

                                                     };
           objp[0].Value = bookingno;
           objp[1].Value = bid;
           objp[1].Value = trantype;
           ExecuteQuery("sp_approvedbookingstatus", objp);
       }

       //dinesh
       public string GetPortCodeportid(int branchid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) };
           objp[0].Value = branchid;
           return ExecuteReader("SPGetPortCodeportid", objp);

       }

       //Get Portcode based on portname.
       public string GetPortcode4BlrDelHyd(string portname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 30) };
           objp[0].Value = portname;
           return ExecuteReader("SPPortcodePName4MumDelHyd", objp);
       }

       public DataTable SelPortName4typepadimg(string portname, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portname", SqlDbType.VarChar, 50),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar,2)};
           objp[0].Value = portname;
           objp[1].Value = trantype;
           return ExecuteTable("SPSelPortName4typepadimg", objp);

       }
    }
}
