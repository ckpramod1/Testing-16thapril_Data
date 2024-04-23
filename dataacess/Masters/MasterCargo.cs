using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterCargo : DBObject
    {

        //Check the Cargo already exist or not.
        //public bool CheckCargoExist(string cargoname)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@cargotype",SqlDbType.VarChar,50)};
        //    objp[0].Value = cargoname;
        //    string retval = ExecuteReader("SPCargoidCargoName", objp);
        //    if (retval.Equals("0"))
        //        return false;
        //    else
        //        return true;
        //}

        //Insert Cargo Name.

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterCargo()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsertCargo(string Cargoname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cargotype",SqlDbType.VarChar,50) };
            objp[0].Value = Cargoname;
            ExecuteQuery("SPInsCargoDetails", objp);
            
        }

        //Update Cargo Name.
        public void UpdateCargo(int Cargoid, string Cargoname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cargotype", SqlDbType.VarChar, 50),
                                                                                      new SqlParameter("@cargoid",SqlDbType.Int)};

            objp[0].Value = Cargoname;
            objp[1].Value = Cargoid;
             ExecuteQuery("SPUpdCargodetails",objp);
                   
        }

        //Get Cargoid based on Cargoname. 
        public int GetCargoid(string Cargoname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@cargotype",SqlDbType.VarChar,50)};
            objp[0].Value = Cargoname;
            return int.Parse(ExecuteReader("SPCargoidCargoName", objp));
        }

        //Get Cargoname based on Cargoid. @txtCargo
        public string GetCargoname(int Cargoid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cargoid", SqlDbType.Int) };
            objp[0].Value = Cargoid;
            return ExecuteReader("SPCargotypeCargoId", objp);
       }

        // *******Methods For Windows Application.*********
        //Get Like Cargo
        public DataTable GetLikeCargo(string cargoname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCargo", SqlDbType.VarChar, 50) };
            objp[0].Value = cargoname;
            return ExecuteTable("SPLikeCargo",objp);                   
        }
        //yuvaraja
        public DataTable CheckCargoExist(string cargotype)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                     new SqlParameter("@cargotype", SqlDbType.VarChar, 100) 
                                                   };
            objp[0].Value = cargotype;
            return ExecuteTable("SPCargoidCargoName", objp);
        }
        public void deletecargo(int cargoid)
        {
            SqlParameter[] sp = new SqlParameter[]{
                                                new SqlParameter("@cargoid",SqlDbType.Int) 
                                              };
            sp[0].Value = cargoid;
            ExecuteQuery("deletecargo", sp);
        }
        public DataSet cargogrid()
        {
            return ExecuteDataSet("cargogird");
        }
        public DataSet pagecargogrid()
        {
            return ExecuteDataSet("cargopagegrid");
        }

    }
}
