using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.FAMaster
{
    public class MasterSubGroup:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterSubGroup()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsMasterSubGroup(string sgroupname,int groupid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@groupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                       
                                                        };
            objp[0].Value = sgroupname;
            objp[1].Value = groupid;
            objp[2].Value = dbname;
            ExecuteQuery("SPInsFAMasterSubGroup", objp);
        }
        public void UpdMastersubGroup(string sgroupname,int groupid,int subgroupid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@groupid",SqlDbType.Int,4),
                                                        new SqlParameter("@sgroupid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                        };
            objp[0].Value = sgroupname;
            objp[1].Value = groupid;
            objp[2].Value = subgroupid;
            objp[3].Value = dbname;
            ExecuteQuery("SPUpdFAMastersubGroup", objp);
        }
        public DataTable SelMastersubGroup(int subgroupid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@subgroupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = subgroupid;
            objp[1].Value = dbname;
            return ExecuteTable("SPSelFAMastersubGroup", objp);
        }
        public DataTable GetLikesubGroupname(string sgroupname,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = sgroupname;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAMastersubGroupnamelike", objp);
        }
        public DataTable SelMastersubGroup4grd(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname", SqlDbType.VarChar, 15) };

            objp[0].Value = dbname;
            return ExecuteTable("SPSelFAMastersubGroup4grd", objp);
        }



        //----------Karthika_K

        public void temp_InsMasterSubGroup(int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar,15)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = dbname;

            ExecuteQuery("SP_tempInsFAMasterSubGroup", objp);
        }


        public DataTable GetRecsubGroupname4outstd(string sgroupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = sgroupname;
            objp[1].Value = dbname;
            return ExecuteTable("SPRecOutstdsubGroupnamelike", objp);
        }

        public DataTable GetLikesubGroupname4outstd(string sgroupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = sgroupname;
            objp[1].Value = dbname;
            return ExecuteTable("SPOutstdsubGroupnamelike", objp);
        }



        public DataTable GetLikesubGroupname4outstd(string sgroupname, string dbname, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15),
            new SqlParameter("@branchid",SqlDbType.Int)};
            objp[0].Value = sgroupname;
            objp[1].Value = dbname;
            objp[2].Value = branchid;
            return ExecuteTable("SPOutstdsubGroupnamelikenew", objp);
        }
        //NewOne    //19/08/2022
        public DataTable GetLikesubGroupid(string sgroupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = sgroupname;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAMastersubGroupid", objp);
        }
    }
}
