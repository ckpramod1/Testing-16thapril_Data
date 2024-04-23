using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterDistrict:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterDistrict()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetGrid()
        {
            SqlParameter[] objp = new SqlParameter[] { };

           // objp[0].Value = countryname;
            return ExecuteTable("SPSelMasterDistrict4Page");
        }
        public DataTable GetCountryName(string countryname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryname", SqlDbType.VarChar, 50) };
            objp[0].Value = countryname;
            return ExecuteTable("SPSelCountryName", objp);
        }
        public DataTable GetStateName(string statename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30) };
            objp[0].Value = statename ;
            return ExecuteTable("SPSelStateName", objp);
        }
        public void InsMasterDistrict(string districtname, int state, int country)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtname", SqlDbType.VarChar,50),
                                                       new SqlParameter("@state", SqlDbType.Int, 4),
                                                       new SqlParameter("@country", SqlDbType.VarChar, 3)
                                                        };
            objp[0].Value = districtname;
            objp[1].Value = state;
            objp[2].Value = country;
            ExecuteQuery("SPInsMasterDistrict", objp);
        }
        public DataTable GetDistrictName(string districtname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtname", SqlDbType.VarChar, 30) };
            objp[0].Value = districtname ;
            return ExecuteTable("SPSelDistrictName", objp);
        }
        public DataTable GetDistrictDetails4Grid()
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter() };

            return ExecuteTable("SPSelMasterDistrict");
        }

        public DataTable GetDistrictDetails4All(int districtid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtid", SqlDbType.Int) };
            objp[0].Value = districtid;
            
            return ExecuteTable("SPSelMasterDistrict4All",objp );
        }
        public void UpdMasterDistrict(string districtname, int stateid, int countryid ,int districtid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtname", SqlDbType.VarChar,50),
                                                       new SqlParameter("@stateid", SqlDbType.Int, 4),
                                                       new SqlParameter("@countryid", SqlDbType.Int),
                                                       new SqlParameter("@districtid",SqlDbType.Int)
                                                        };
            objp[0].Value = districtname;
            objp[1].Value = stateid;
            objp[2].Value = countryid;
            objp[3].Value = districtid;
            ExecuteQuery("SPUpdMasterDistrict", objp);
        }
        public DataTable GetDistrictName4textbox(string districtname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@district", SqlDbType.VarChar, 30) };
            objp[0].Value = districtname;
            return ExecuteTable("SPSelDistrictNameExist", objp);
        }
        public DataTable Getstate4country(string statename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@statename", SqlDbType.VarChar, 30) };
            objp[0].Value = statename;
            return ExecuteTable("SPSelStateforCountry", objp);
        }

    }
}
