using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
   public class MasterVessel :DBObject
    {
        //Check the vessel already exist or not.


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterVessel()
        {
            Conn = new SqlConnection(DBCS);
        }
        public bool CheckVesselExist(string vesselname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselname", SqlDbType.VarChar, 50) };
           objp[0].Value = vesselname;
           string ret = ExecuteReader("SPVesselidVName", objp);
           if (ret.Equals("0"))
               return false;
           else
               return true;
       }

       //Insert Vessel Name.
       public void InsertVessel(string vesselname,string strimoCode)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@vesselname", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@imocode", SqlDbType.VarChar, 30)
                                                     };
           objp[0].Value = vesselname;
           objp[1].Value = strimoCode;
           ExecuteQuery("SPInsVesselDetails", objp);
       }

       //Update Vessel Name.
       public void UpdateVessel(int vesselid, string vesselname, string strimoCode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselname", SqlDbType.VarChar, 50),
                                                      new SqlParameter("@vesselid",SqlDbType.Int),
                                                      new SqlParameter("@imocode", SqlDbType.VarChar, 30)};
           objp[0].Value = vesselname;
           objp[1].Value = vesselid;
           objp[2].Value = strimoCode;
           ExecuteTable("SPUpdVesselDetails",objp);
       }



       //Get Vesselid based on Vesselname.
       public int GetVesselid(string vesselname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselname", SqlDbType.VarChar, 50) };
           objp[0].Value = vesselname;
           return int.Parse(ExecuteReader("SPVesselidVName", objp));
       }

       //Get Vesselname based on Vesselid.  
       public string GetVesselname(int vesselid)
       {
           SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vesselid",SqlDbType.Int)};
           objp[0].Value = vesselid;
           return ExecuteReader("SPVesselnameVId", objp);
       }


       // *******Methods For Windows Application.*********

       //Get LikeVessel
       public DataTable GetLikeVessel(string vesselname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtVessel", SqlDbType.VarChar, 50) };
           objp[0].Value = vesselname;
           return ExecuteTable("SPLikeVessel", objp);
       }
       //salquery
       public DataTable GetSalesLikeVessel(string vesselname, int salesid, string trantype, int bid)
       {
           SqlParameter[] objp = new SqlParameter[] 
           { 
               new SqlParameter("@txtVessel", SqlDbType.VarChar, 50),
               new SqlParameter ("@salesid",SqlDbType .Int ,4),
               new SqlParameter ("@trantype",SqlDbType .VarChar ,2),
               new SqlParameter ("@bid",SqlDbType .TinyInt )
           };
           objp[0].Value = vesselname;
           objp[1].Value = salesid;
           objp[2].Value = trantype;
           objp[3].Value = bid;
           return ExecuteTable("SPLikeSalesVessel", objp);
       }
       //public DataTable GetVesselDetails(int vesselid)
       ////{
       ////    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselid", SqlDbType.Int) };
       ////    objp[0].Value = vesselid;
       ////    return ExecuteTable("SPGetVesselDetails", objp);
       ////}

       //RATHA
       public DataTable GetVesselDetails(int vesselid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselid", SqlDbType.Int) };
           objp[0].Value = vesselid;
           return ExecuteTable("SPGetVesselDetails", objp);
       }

       //Update Vessel Name.
       public void UpdateIMOCode(int vesselid,  string strimoCode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselid", SqlDbType.Int),
                                                      new SqlParameter("@imocode", SqlDbType.VarChar, 30)};
           objp[0].Value = vesselid;
           objp[1].Value = strimoCode;
           ExecuteTable("SPUpdateIMOCode", objp);
       }

       ///-------------------------Elakkiya------------------------------


       public void InsertVesselValues(string vesselname, string imoCode, string vescode)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@vesselname", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@imocode", SqlDbType.VarChar, 30),
                                                         new SqlParameter("@vessalcode", SqlDbType.VarChar, 30)
                                                     };
           objp[0].Value = vesselname;
           objp[1].Value = imoCode;
           objp[2].Value = vescode;

           ExecuteQuery("SPInsertValues", objp);
       }
      
       public DataTable SPGetVesselName(string vesselname)
       {

           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselname", SqlDbType.VarChar, 50) };

           objp[0].Value = vesselname;

           return ExecuteTable("SPGetVesselName", objp);
       }

       public void SPUpdVesselvalues(int vesselid, string vesselname, string imocode, string vescode)
       {

           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselid",SqlDbType.Int),
                                                      new SqlParameter("@vesselname", SqlDbType.VarChar, 50),
                                                      new SqlParameter("@imocode",SqlDbType.VarChar,30),
                                                      new SqlParameter("@vesselcode", SqlDbType.VarChar, 30)};
           objp[0].Value = vesselid;
           objp[1].Value = vesselname;
           objp[2].Value = imocode; ;
           objp[3].Value = vescode;

           ExecuteTable("SPUpdVesselValues", objp);
       }

       public DataTable SPGetALlVesselValues(int vesselid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselid", SqlDbType.Int) };

           objp[0].Value = vesselid;

           return ExecuteTable("SpGetALLVesselValues", objp);

       }

       public DataTable SPVesselView()
       {
           return ExecuteTable("SPVesselView");

       }
       public DataTable RetriveTopVessel()
       {
           return ExecuteTable("SPSelectTopVesssel");
       }


       public DataTable GetDuplicateVal(string vesname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselname", SqlDbType.VarChar, 50) };

           objp[0].Value = vesname;

           return ExecuteTable("SPCheckDuplicate", objp);
       }

       public DataTable GETDeleteVessel(int vesselid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselid", SqlDbType.Int) };

           objp[0].Value = vesselid;

           return ExecuteTable("SPDelValVessel", objp);

       }

       public DataTable GETVesselID(string vesselname)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vesselname", SqlDbType.VarChar, 50) };

           objp[0].Value = vesselname;

           return ExecuteTable("SPSelVesselId", objp);

       }

       public DataTable GETCheckVesselCode(string vescode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vessalcode", SqlDbType.VarChar, 30) };

           objp[0].Value = vescode;

           return ExecuteTable("SPCheckVesselcode", objp);

       }
       public DataTable GETCheckIMOCode(string imocode)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@imocode", SqlDbType.VarChar, 30) };

           objp[0].Value = imocode;

           return ExecuteTable("SPCheckImoCode", objp);

       }
    }
}
