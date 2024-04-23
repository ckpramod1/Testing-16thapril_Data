using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterSector : DBObject
    {
        //Insert Sector Name.
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterSector()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertSector(string sectorname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 30) };
            objp[0].Value = sectorname;
            ExecuteQuery("SPInsMasterSector", objp);
        }
        //Update  Sector Name.

        public void UpdSector(string sectorname, int sectorid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 30),
                                                      
                                                       new SqlParameter("@sectorid",SqlDbType.TinyInt,1)};
            objp[0].Value = sectorname;
            objp[1].Value = sectorid;
            ExecuteQuery("SPUpdMasterSector", objp);
        }
        public DataTable Selsectorname(string sectorname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 30) };
            objp[0].Value = sectorname;
            return ExecuteTable("SPSelMasterSector", objp);
        }
        public DataTable GetLikesectorname(string sectorname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtsectorname", SqlDbType.VarChar, 30) };
            objp[0].Value = sectorname;
            return ExecuteTable("SPLikeSector", objp);

        }


        //TreadeLane

        public DataTable GetAllSectornname()
        {

            return ExecuteTable("SPGetSector");
        }
        public DataTable GetCountryname4Sector(int sector)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sector", SqlDbType.Int, 4) };
            objp[0].Value = sector;
            return ExecuteTable("SPGetCountry4Sector", objp);

        }

        public DataSet GetTradelaneDetails(int sectorid, int countryid, int branchid, int divisionid, int fmonth, int fyear, int tmonth, int tyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorid", SqlDbType.Int),
             new SqlParameter("@countryid", SqlDbType.Int),
             new SqlParameter("@branchid", SqlDbType.TinyInt),
             new SqlParameter("@divisionid", SqlDbType.TinyInt),
             new SqlParameter("@fmonth", SqlDbType.Int ,4),
                 new SqlParameter("@fyear", SqlDbType.Int,4),
                 new SqlParameter("@tmonth", SqlDbType.Int,4),
                 new SqlParameter("@tyear", SqlDbType.Int,4)
            };

            objp[0].Value = sectorid;
            objp[1].Value = countryid;
            objp[2].Value = branchid;
            objp[3].Value = divisionid;
            objp[4].Value = fmonth;
            objp[5].Value = fyear;
            objp[6].Value = tmonth;
            objp[7].Value = tyear;

            return ExecuteDataSet("SPGetTradelaneDtls", objp);

        }

        //--------------------- ELLAKIYA-----------------------------------------

        public int insmastersector(string sectorname, String description)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@sectorname", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@descn",SqlDbType.VarChar, 100),
                                        new SqlParameter("@sectorid",SqlDbType.Int)  };

            objp[0].Value = sectorname;
            objp[1].Value = description;
            objp[2].Direction = ParameterDirection.Output;

            return ExecuteQuery("sp_insmastersector", objp, "@sectorid");

        }
        public void updateselecttable(int id, string sectorname, string description)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter ("@sectorid",SqlDbType.Int),
                                                        new SqlParameter("@sectorname", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@descn", SqlDbType.VarChar, 100), };
            objp[0].Value = id;
            objp[1].Value = sectorname;
            objp[2].Value = description;

            ExecuteQuery("spupdmastersector", objp);

        }
        public void GetDeleteSector(int id)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorid", SqlDbType.Int) };

            objp[0].Value = id;


            ExecuteQuery("SPDelvalSector", objp);

        }

        public DataTable GetallsectorDetatails(string secname)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 30) };

            objp[0].Value = secname;

            return ExecuteTable("SPGetSector", objp);
        }

        public DataTable Getonsectorname(string sectname)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 30) };

            objp[0].Value = sectname;

            return ExecuteTable("spgetsectorname", objp);
        }

        public DataTable GetallDetails()
        {

            return ExecuteTable("GetSector");
        }
        //public DataTable GetallDetailsSector()
        //{

        //    return ExecuteTable("GetSectorDetails");
        //}
        public DataTable GetAllSectorDetails(int sectorid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorid", SqlDbType.VarChar, 30) };

            objp[0].Value = sectorid;

            return ExecuteTable("GetAllDeatils", objp);
        }

        public DataTable RetriveTopSectors()
        {
            return ExecuteTable("SpSelectTopRows");
        }

        public DataTable GetsecId(string secname)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 30) };

            objp[0].Value = secname;

            return ExecuteTable("GetSectorid", objp);
        }
        
    }
}
