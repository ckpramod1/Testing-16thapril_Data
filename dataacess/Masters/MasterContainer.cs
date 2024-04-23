using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterContainer :DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterContainer()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetContainersizes()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPShowContype", objp);

        }
        //Insert Container Type.
        public void InsertMasterConttype(string conttype,string descn,string strHeight)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@conttype", SqlDbType.VarChar, 4),
                                                       new SqlParameter("@descn",SqlDbType.VarChar,30),
                                                       new SqlParameter("@height",SqlDbType.VarChar,10)
                                                     };
            objp[0].Value = conttype;
            objp[1].Value = descn;
            objp[2].Value = strHeight;
            ExecuteQuery("SPInsMasterconttype", objp);
        }
        //Update  Bank Name.

        public void UpdMasterConttype(string conttype, string descn, int conttypeid, string strHeight)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@conttype", SqlDbType.VarChar, 4),
                                                        new SqlParameter("@descn",SqlDbType.VarChar,30),
                                                        new SqlParameter("@conttypeid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@height",SqlDbType.VarChar,10)};
            objp[0].Value = conttype;
            objp[1].Value = descn;
            objp[2].Value = conttypeid;
            objp[3].Value = strHeight;
            ExecuteQuery("SPUpdMasterconttype", objp);
        }
        public DataTable SelMasterConttype(string conttype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@conttype",SqlDbType.VarChar,4)};
            objp[0].Value = conttype;
            return ExecuteTable("SPSelMasterconttype", objp);
        }
        public DataTable GetLikeContType(string conttype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtconttype", SqlDbType.VarChar, 4) };
            objp[0].Value = conttype;
            return ExecuteTable("SPLikeConttype", objp);

        }
        public DataSet GetContainersize()
        {

            return ExecuteDataSet("SPShowContype");

        }
        public void Deletecontainertype(int id)
        {
            SqlParameter[] sp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@id",SqlDbType.Int)
                                                    };
            sp[0].Value = id;
            ExecuteQuery("contentdelete", sp);
        }
       
       public DataSet containerpagegird()
        {

            return ExecuteDataSet("containerpagegrid");

        }

    }

}
