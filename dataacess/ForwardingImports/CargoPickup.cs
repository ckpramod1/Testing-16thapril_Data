using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ForwardingImports
{
    public class CargoPickup : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CargoPickup()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable getcfsDtls(int customerid,int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt, 1)
            };
            objp[0].Value = customerid;
            objp[1].Value = bid;
            return ExecuteTable("SPgetcfsDtls", objp);
        }

        public void Updcargopickdate(int jobno, string blno,DateTime cargopick,int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,20),
             new SqlParameter("@cargopick",SqlDbType.SmallDateTime,4),
            new SqlParameter("@bid", SqlDbType.TinyInt, 1)
            };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = cargopick;
            objp[3].Value = bid;
            ExecuteQuery("SPUpdcargopickdate", objp);
        }



        public void InsTempCargoPickupConfirm(int bid, string blno, int agentid, DateTime pickedon)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid", SqlDbType.TinyInt , 4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@agentid", SqlDbType.Int , 4),
                                                        new SqlParameter("@pickedon",SqlDbType.SmallDateTime,4)
            };
            objp[0].Value = bid ;
            objp[1].Value = blno;
            objp[2].Value = agentid ;
            objp[3].Value = pickedon ;
            ExecuteQuery("SPInsTempCargoPickupConfirm", objp);
        }

        //Arun

        public DataTable GetDetailsForCargoPickUp(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@bid", SqlDbType.Int)
            };

            objp[0].Value = bid;
            return ExecuteTable("SPGetPendingCargoPickup", objp);
        }

        //muthu

        public DataTable GetDetailsForCargoPickUpOICS(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@bid", SqlDbType.Int)
            };

            objp[0].Value = bid;
            return ExecuteTable("SPGetPendingCargoPickupOICScount", objp);
        }
    }
}
