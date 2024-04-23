using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.FAMaster
{
    public class MasterVoutypes:DBObject 
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterVoutypes()
        {
            Conn = new SqlConnection(DBCS);
        }


        public void InsMasterVoutype(string voutypename, string remarks,string dbanme)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Voutypename", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                       
                                                        };
            objp[0].Value = voutypename;
            objp[1].Value = remarks;
            objp[2].Value = dbanme;

            ExecuteQuery("SPInsFAMasterVouType", objp);
        }
        public void UpdMasterVoutype(string voutypename, string remarks,int voutypeid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Voutypename", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@voutypeid",SqlDbType.TinyInt,4),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                       
                                                        };
            objp[0].Value = voutypename;
            objp[1].Value = remarks;
            objp[2].Value = voutypeid;
            objp[3].Value = dbname;

            ExecuteQuery("SPUPdFAMasterVoutype", objp);
        }
        public DataTable SelMasterVoutype(int voutypeid,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@voutypeid", SqlDbType.Int, 4),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = voutypeid;
            objp[1].Value = dbname;
            return ExecuteTable("SPSelFAMasterVouType", objp);
        }
        public DataTable GetLikevoutypename(string voutypename,string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Voutypename", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = voutypename;
            objp[1].Value = dbname;
            return ExecuteTable("SPFAMastervoutypenamelike", objp);
        }

    }
}
