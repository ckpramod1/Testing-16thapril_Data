using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class ComTVBackDateRights : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ComTVBackDateRights()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsCtBDtRights(int empid, int branchid, int noofmonth)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@noofmonth", SqlDbType.Int, 4)
                                
                        };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = noofmonth;

            ExecuteQuery("SPInsCtBDtRights", objp);
        }

        public DataTable SelCtBDtRights(int empid,int Branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@Branchid", SqlDbType.TinyInt)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = Branchid;
            return ExecuteTable("SPSelCtBDtRights", objp);
        }

        public void UpdCtBDtRights(int empid, int branchid, int noofmonth)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@noofmonth", SqlDbType.Int, 4)
            };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = noofmonth;

            ExecuteQuery("SPUpdCtBDtRights", objp);

        }


        //Ruban
        public void InsCtBDtRights(int empid, int branchid, int noofmonth, int noofdays)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@noofmonth", SqlDbType.Int, 4),
                                                        new SqlParameter("@noofdays", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = noofmonth;
            objp[3].Value = noofdays;

            ExecuteQuery("SPInsCtBDtRightsNew", objp);
        }
        public void UpdCtBDtRights(int empid, int branchid, int noofmonth, int noofdays)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@noofmonth", SqlDbType.Int, 4),
                                                        new SqlParameter("@noofdays", SqlDbType.Int, 4)
            };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = noofmonth;
            objp[3].Value = noofdays;

            ExecuteQuery("SPUpdCtBDtRightsNew", objp);

        }
        public string Getdate_4JV(string dbname, int branchid, DateTime voudate, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@dbname", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@voudate", SqlDbType.DateTime),
                                                        new SqlParameter("@vouyear", SqlDbType.Int, 4)
            };
            objp[0].Value = dbname;
            objp[1].Value = branchid;
            objp[2].Value = voudate;
            objp[3].Value = vouyear;

            return ExecuteReader("SP_getdate4JV", objp);

        } 
     
    }
}
