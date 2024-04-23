using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.PAYROLL
{
    public class MasterSection:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterSection()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertMasterSection(string seccode, string secname,double maxlimit)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@seccode" ,SqlDbType.VarChar,10),
                                                      new SqlParameter( "@secname",SqlDbType.VarChar,100),
                 new SqlParameter("@maxlimit",SqlDbType.Money),
                                                      new SqlParameter( "@secid",SqlDbType.Int,4)};

            objp[0].Value = seccode;
            objp[1].Value = secname;
            objp[2].Value = maxlimit;
            objp[3].Direction = ParameterDirection.Output;
            ExecuteQuery("SPInsMasterSection", objp);

        }

        public void UpdMasterSection(string seccode, string secname,double maxlimit,int secid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@seccode",SqlDbType.VarChar,10),
                new SqlParameter("@secname",SqlDbType.VarChar,100),
                new SqlParameter("@maxlimit",SqlDbType.Money),
                new SqlParameter("@secid",SqlDbType.Int,4)};

            objp[0].Value = seccode;
            objp[1].Value = secname;
            objp[2].Value = maxlimit;
            objp[3].Value = secid;
            ExecuteQuery("SPupdMastersection", objp);
        }

        public void DelMasterSection(int secid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@secid",SqlDbType.Int,4)};

            objp[0].Value = secid;
            ExecuteQuery("SpDelMastersection", objp);
        }

        public DataTable getsectiondtls(int secid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@secid",SqlDbType.Int,4)};
            objp[0].Value = secid;
            return ExecuteTable("SPgetSectiondtls", objp);
        }

        public DataTable getSecid(string seccode)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@seccode",SqlDbType.VarChar,10)};
            objp[0].Value = seccode;
            return ExecuteTable("SpgetsecidfrmMastersection", objp);
        }

        public DataTable GetLikeSeccode(string seccode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@seccode", SqlDbType.VarChar, 10) };
            objp[0].Value = seccode;
            return ExecuteTable("SPlikeSeccode", objp);
        }
        //public DataTable GradeInsDtls(string gname, double ea, double driverall, DateTime efrom, DateTime eto)
        //{
        //    SqlParameter[] objp = new SqlParameter[]
        //    {
        //        new SqlParameter ("@gname",SqlDbType.VarChar ,10),
        //        new SqlParameter ("@ea",SqlDbType .Money ,8),
        //        new SqlParameter ("@driverall",SqlDbType .Money ,8),
        //        new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
        //        new SqlParameter ("@eto",SqlDbType .DateTime ,10)
        //    };
        //    objp[0].Value = gname;
        //    objp[1].Value = ea;
        //    objp[2].Value = driverall;
        //    objp[3].Value = efrom;
        //    objp[4].Value = eto;
        //    return ExecuteTable("SPGradeInsDtls", objp);
        //}


        public DataTable GradeInsDtls(string gname, double ea, double driverall, DateTime efrom, DateTime eto, double medical)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@gname",SqlDbType.VarChar ,10),
                new SqlParameter ("@ea",SqlDbType .Money ,8),
                new SqlParameter ("@driverall",SqlDbType .Money ,8),
                new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
                new SqlParameter ("@eto",SqlDbType .DateTime ,10),
                new SqlParameter ("@medical",SqlDbType .Money ,8),
            };
            objp[0].Value = gname;
            objp[1].Value = ea;
            objp[2].Value = driverall;
            objp[3].Value = efrom;
            objp[4].Value = eto;
            objp[5].Value = medical;
            return ExecuteTable("SPGradeInsDtls", objp);
        }

        public void GradeUpdDtls(int gid, double ea, double driverall, DateTime efrom, DateTime eto, double medical)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter ("@gradeid",SqlDbType.VarChar ,10),
                new SqlParameter ("@ea",SqlDbType .Money ,8),
                new SqlParameter ("@driverall",SqlDbType .Money ,8),
                new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
                new SqlParameter ("@eto",SqlDbType .DateTime ,10),
                new SqlParameter ("@medical",SqlDbType .Money ,8),
            };
            objp[0].Value = gid;
            objp[1].Value = ea;
            objp[2].Value = driverall;
            objp[3].Value = efrom;
            objp[4].Value = eto;
            objp[5].Value = medical;
            ExecuteQuery("SPGradeupdDtls", objp);
        }
        //// public void GradeUpdDtls(int gid, double ea, double driverall)
        //public void GradeUpdDtls(int gid, double ea, double driverall, DateTime efrom, DateTime eto)
        //{
        //    SqlParameter[] objp = new SqlParameter[]
        //    {
        //        new SqlParameter ("@gradeid",SqlDbType.VarChar ,10),
        //        new SqlParameter ("@ea",SqlDbType .Money ,8),
        //        new SqlParameter ("@driverall",SqlDbType .Money ,8),
        //        new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
        //        new SqlParameter ("@eto",SqlDbType .DateTime ,10)
        //    };
        //    objp[0].Value = gid;
        //    objp[1].Value = ea;
        //    objp[2].Value = driverall;
        //    objp[3].Value = efrom;
        //    objp[4].Value = eto;
        //    ExecuteQuery("SPGradeupdDtls", objp);
        //}
        public DataTable GradeSelDtls(int gradeid, string gname, DateTime efrom, DateTime eto)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter ("@gradeid",SqlDbType.VarChar ,10),
                new SqlParameter("@gname",SqlDbType.VarChar,10),
            new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
                new SqlParameter ("@eto",SqlDbType .DateTime ,10)
            };
            objp[0].Value = gradeid;
            objp[1].Value = gname;
            objp[2].Value = efrom;
            objp[3].Value = eto;
            return ExecuteTable("SPGradeSelectedDtls", objp);
        }

        public void GradeDelDtls(int gid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@gradeid",SqlDbType.Int,4)};

            objp[0].Value = gid;
            ExecuteQuery("SPGradeDelDtls", objp);
        }
        public DataTable GradeSelDtls1(string gname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter ("@gradename",SqlDbType.VarChar ,10)
                
            };
            objp[0].Value = gname;
            return ExecuteTable("SPGradeSelectedDtls12", objp);
        }
        public DataTable GradeSelDtls12(string gname, DateTime efrom, DateTime eto)
        {
            SqlParameter[] objp = new SqlParameter[] {
                
                new SqlParameter("@gname",SqlDbType.VarChar,10),
            new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
                new SqlParameter ("@eto",SqlDbType .DateTime ,10)
            };

            objp[0].Value = gname;
            objp[1].Value = efrom;
            objp[2].Value = eto;
            return ExecuteTable("SPGradeSelectedDtls123", objp);
        }



    }
}
