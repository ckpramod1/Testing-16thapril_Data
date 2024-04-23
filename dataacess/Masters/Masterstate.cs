using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
    public class Masterstate :DBObject
    { //@statename varchar(30)

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Masterstate()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetStatename(string statename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30) };
            objp[0].Value = statename;
            return ExecuteTable("SPGetStateName", objp);
        }
        //@statename varchar(30),
        //@countryid int
        public void InsertState(string statename, int countryid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@statename",SqlDbType.VarChar ,30),
                                                      new SqlParameter("@countryid",SqlDbType.Int)};

            objp[0].Value = statename;
            objp[1].Value = countryid;
            ExecuteQuery("SPInsstates", objp);

        }
        //@countryname
        public DataTable GetCountryName(string countryname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryname", SqlDbType.VarChar, 30) };
            objp[0].Value = countryname;
            return ExecuteTable("SPSelCountryName", objp);
        }
        //@stateid int,@statename varchar(50)
        public DataTable GetCountryname4state(int stateid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateid", SqlDbType.Int) 
                                                       //new SqlParameter("@statename", SqlDbType.VarChar, 50) 
            };
            objp[0].Value = stateid;
            //objp[1].Value = statename;
            return ExecuteTable("Getcountry4state", objp);
        }
        //@statename varchar(50),@stateid int,@countryid int
        public void UpdateStatename(int stateid, string statename, int countryid)
        {

            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@stateid",SqlDbType.Int), 
                                                                                  new SqlParameter("@statename",SqlDbType.VarChar,50),
                                                                                  new SqlParameter("@countryid",SqlDbType.Int)};
            objp[0].Value = stateid;
            objp[1].Value = statename;
            objp[2].Value = countryid;
            ExecuteQuery("SPUpdStatename", objp);
        }
        //SPFillGridWithCountryState,(@countryid int)

        public DataTable GetCountryFillGrid(int countryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryid", SqlDbType.Int) };
            objp[0].Value = countryid;
            return ExecuteTable("SPFillGridWithCountryState", objp);
        }

        //@countryname varchar(50)
        public DataTable CheckCountryName(string countryname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryname", SqlDbType.VarChar, 50) };
            objp[0].Value = countryname;
            return ExecuteTable("SPCheckCountryName", objp);
        }

        public DataTable FillGridOnPageLoad()
        {
            //SqlParameter[] objp = new SqlParameter[] {  };
            //objp[0].Value = countryname;
            return ExecuteTable("SPFillGrid4States");
        }

        //SPChechDuplicate4State
        //@statename varchar(30)
        public DataTable CheckDuplicateForStatename(string statename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30) };
            objp[0].Value = statename;
            return ExecuteTable("SPChechDuplicate4State", objp);
        }
    }
}
