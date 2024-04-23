using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.FAMaster
{
    public  class MasterGroup:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterGroup()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsMasterGroup(string groupname,char ct,char gt,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@ct", SqlDbType.Char, 1),
                                                       new SqlParameter("@gt", SqlDbType.Char, 1),
                                                        new SqlParameter("@dbname", SqlDbType.VarChar,15)
                                                        };
            objp[0].Value = groupname;
            objp[1].Value = ct;
            objp[2].Value = gt;
            objp[3].Value = dbname;

            ExecuteQuery("SPInsFAMasterGroup", objp);
        }
        public void UpdMasterGroup(string groupname, char ct, char gt,int groupid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@ct", SqlDbType.Char, 1),
                                                       new SqlParameter("@gt", SqlDbType.Char, 1),
                                                        new SqlParameter("@groupid",SqlDbType.Int,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                        };
            objp[0].Value = groupname;
            objp[1].Value = ct;
            objp[2].Value = gt;
            objp[3].Value = groupid;
            objp[4].Value = dbname;

            ExecuteQuery("SPUpdFAMasterGroup", objp);
        }
        public DataTable SelMasterGroup(int groupid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = groupid;
            objp[1].Value = dbname;
            return ExecuteTable("SPSelFAMasterGroup", objp);
        }
        public DataTable GetLikeGroupname(string groupname,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = groupname;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAMasterGroupnamelike", objp);
        }
        public DataTable GetLikeGroupnameNEW(string groupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = groupname;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAMasterGroupname", objp);
        }
        public DataTable SelMasterGroup4Grd(string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};

            objp[0].Value = dbname;
            return ExecuteTable("SPSelFAMasterGroup4grd", objp);
        }

        //---------Karthika_K

        public void temp_InsMasterGroup(int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@dbname", SqlDbType.VarChar,15)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = dbname;

            ExecuteQuery("SP_tempInsFAMasterGroup", objp);
        }
       
    }
}
