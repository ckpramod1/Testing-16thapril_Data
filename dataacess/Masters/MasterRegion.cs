using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
    public class MasterRegion:DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterRegion()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertMasterRegion(string Regionname,string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                  new SqlParameter("@regionname", SqlDbType.VarChar, 100) ,
                                  new SqlParameter("@remarks", SqlDbType.VarChar, 100) 
                                  };
            objp[0].Value = Regionname;
            objp[1].Value = remarks;
            ExecuteQuery("SPInsMasterRegion", objp);
        }

        public DataTable GetLikeRegion(string regionname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionname", SqlDbType.VarChar, 50) };
            objp[0].Value = regionname;
            return ExecuteTable("SPLikeRegion", objp);

        }



        public void UpdMasterRegion(int regionid,string regionname,string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@regionid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@regionname",SqlDbType.VarChar,100),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar,100)
      
                
                         
                             };
            objp[0].Value = regionid;
            objp[1].Value = regionname;
            objp[2].Value = remarks;          
            ExecuteQuery("SPUpdMasterRegion", objp);

        }


      
        public int GetRegionid(string regionname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionname", SqlDbType.VarChar, 30) };
            objp[0].Value =regionname;

            return int.Parse(ExecuteReader("SPSelRegionId", objp));
        }



        public string GetRegionname(int regionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.Int, 4) };
            objp[0].Value = regionid;
            return ExecuteReader("SPSelRegionName", objp);
        }


        public DataTable SelRegionDetails(int regionid)
        {
            SqlParameter[] obj = new SqlParameter[] 
                                                    {
                                                    new SqlParameter("@regionid", SqlDbType.TinyInt,1)
                                                    };
            obj[0].Value = regionid;
            return ExecuteTable("SPSelRegionDetails",obj);
        }

        public DataTable getAllRegionNames()
        {

            return ExecuteTable("SPSelAllRegion");
        }


        //vignesh

        public int insertnewfun(string region, string description)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                    new SqlParameter("@region",SqlDbType.VarChar,30),
                                                    new SqlParameter("@description",SqlDbType.VarChar,100),
                                                    new SqlParameter("@regionid",SqlDbType.Int)
                                                    };
            objp[0].Value = region;
            objp[1].Value = description;
            objp[2].Direction = ParameterDirection.Output;

            return ExecuteQuery("SP_newinsert", objp, "@regionid");
        }
        public DataTable GetRegion(string region)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@region", SqlDbType.VarChar, 30) };
            objp[0].Value = region;
            return ExecuteTable("SP_GetRegion2", objp);


        }

        public DataTable GetRegionName(string region)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@region", SqlDbType.VarChar, 30) };
            objp[0].Value = region;
            return ExecuteTable("SP_GetRegionName", objp);


        }
        public DataTable Deletefun(string regionid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.Int, 10) };


            objp[0].Value = regionid;
            return ExecuteTable("SP_delete2", objp);
        }
        public void updatefun(int regionid, string region, string description)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid",SqlDbType.Int),
                                                       new SqlParameter("@region", SqlDbType.VarChar,30),
                                                       new SqlParameter("@description", SqlDbType.VarChar,100),
                                                      
                                                       
                                                         };
            objp[0].Value = regionid;
            objp[1].Value = region;
            objp[2].Value = description;

            ExecuteQuery("SP_update", objp);
        }
        public DataTable viewfun()
        {

            return ExecuteTable("SP_grid");
        }

        public int InsertRegionDeatils(string region, string description)
        {
            SqlParameter[] objp = new SqlParameter[]{
                                                    new SqlParameter("@region",SqlDbType.VarChar,30),
                                                    new SqlParameter("@description",SqlDbType.VarChar,100),
                                                    new SqlParameter("@regionid",SqlDbType.Int)
                                                    };
            objp[0].Value = region;
            objp[1].Value = description;
            objp[2].Direction = ParameterDirection.Output;

            return ExecuteQuery("SP_newinsert", objp, "@regionid");
        }

        public DataTable GETGridTopRegion()
        {

            return ExecuteTable("SP_RegionTop10");
        }
        public void DeltFun(int regionid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@regionid", SqlDbType.Int) };


            objp[0].Value = regionid;
            ExecuteQuery("SP_DeleteRegion", objp);
        }

    }
}
