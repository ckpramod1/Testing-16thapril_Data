using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterDesignation:DBObject 
    {
        //Insert Designation Name.
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterDesignation()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertDesignation(string designame)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@designame", SqlDbType.VarChar, 30) };
            objp[0].Value = designame;
            ExecuteQuery("SPInsMasterDesignation", objp);
        }
        //Update  Designation Name.

        public void UpdDesignation(string designame, int desigid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@designame", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@desigid",SqlDbType.TinyInt,1)};
            objp[0].Value = designame;
            objp[1].Value = desigid;
            ExecuteQuery("SPUpdMasterDesignation", objp);
        }
        public DataTable Seldesigname(string designame)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@designame", SqlDbType.VarChar, 30) };
            objp[0].Value = designame;
            return ExecuteTable("SPSelMasterDesignation", objp);
        }
        public DataTable GetLikedesigname(string designame)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtdesigname", SqlDbType.VarChar, 30) };
            objp[0].Value = designame;
            return ExecuteTable("SPLikeDesignation", objp);

        }

        //vignesh

        public int insertdesignationfun(string designame)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@designame", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@desigid",SqlDbType.Int)};
            objp[0].Value = designame;
            objp[1].Direction = ParameterDirection.Output;

            return ExecuteQuery("SP_InsertDesignation", objp, "@desigid");
        }


        public void updatedesignation(string designame, int desigid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@designame",SqlDbType.VarChar,30),
                                                    new SqlParameter("@desigid",SqlDbType.Int)
                                                    };
            objp[0].Value = designame;
            objp[1].Value = desigid;
            ExecuteQuery("SP_UpdateDesignation", objp);
        }

        public DataTable viewdesignationfun()
        {
            return ExecuteTable("SP_viewdesig");
        }

        public DataTable GetDesignationfun(string designame)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@designame", SqlDbType.VarChar, 30) };
            objp[0].Value = designame;
            return ExecuteTable("SP_GetDesignation", objp);
        }
        public DataTable GetDesignationNamefun(string designame)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@designame", SqlDbType.VarChar, 30) };
            objp[0].Value = designame;
            return ExecuteTable("SP_GetDesignationName", objp);
        }

        public DataTable GETGridTopDesignation()
        {

            return ExecuteTable("SP_DesignationTop");
        }
        public void DeltFun(int desigid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@desigid", SqlDbType.Int) };


            objp[0].Value = desigid;
            ExecuteQuery("SP_DeleteDesignation", objp);
        }
 
    }
}
