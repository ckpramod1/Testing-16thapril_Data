using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Masters
{
    public class MasterUI:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterUI()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetMenudtlsfromUI(string trantype, int uiid , string func)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@uiid",SqlDbType.Int,4),
                                                       new SqlParameter("@func",SqlDbType.VarChar,1)
                                                     };

            objp[0].Value = trantype;
            objp[1].Value = uiid;
            objp[2].Value = func;
            return ExecuteTable("SPgetmenudetailsfrom", objp);
        }

        public DataTable GetScreendtlsfromMenu(string trantype, string menuname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@menuname",SqlDbType.VarChar,50)};

            objp[0].Value = trantype;
            objp[1].Value = menuname;
            return ExecuteTable("SPgetScreendetailsfromMenu", objp);
        }

        public DataTable GetUIDtlsFromScreen(string trantype, string menuname, string screenname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@menuname",SqlDbType.VarChar,50),
                                                       new SqlParameter("@submenuname",SqlDbType.VarChar,50)};

            objp[0].Value = trantype;
            objp[1].Value = menuname;
            objp[2].Value = screenname;
            return ExecuteTable("SPgetUiidfromMasterUI", objp);
        }

        public DataTable GetUIDTLSFromUIID(int uiid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@uiid", SqlDbType.Int,4)};

            objp[0].Value = uiid;
            return ExecuteTable("SPGetUIDetailsfromUIID", objp);
        }



        

    }
}
