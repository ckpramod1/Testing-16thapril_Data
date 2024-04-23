using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.BondedTrucking
{
    public class BTJobInfo : DBObject
    {
        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BTJobInfo()
        {
            Conn = new SqlConnection(DBCS);
        }



        public int InsBTJobInfo(string Truckno, int FromPort, DateTime etd, int ToPort, DateTime eta, int branchid, int PreparedBy, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@truckno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@fromport",SqlDbType.Int,4),
                                                        new SqlParameter("etd",SqlDbType.DateTime,8),
                                                        new SqlParameter("@toport",SqlDbType.Int,4),
                                                        new SqlParameter("@eta",SqlDbType.DateTime,8),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@preparedby",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                      };
            objp[0].Value = Truckno;
            objp[1].Value = FromPort;
            objp[2].Value = etd;
            objp[3].Value = ToPort;
            objp[4].Value = eta;
            objp[5].Direction = ParameterDirection.Output;
            objp[6].Value = PreparedBy;
            objp[7].Value = bid;
            objp[8].Value = cid;
            return ExecuteQuery("SPInsBTJobInfo", objp, "@jobno");

        }
        public void InsBTJobDetails(int jobno, int customer, int noofpkgs, int pkgtype, double weight, double cbm, string sbno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@customer",SqlDbType.Int,4),
                                                        new SqlParameter ("noofpkgs",SqlDbType.Int,4),
                                                        new SqlParameter("@pkgtype",SqlDbType.Int,4),
                                                        new SqlParameter("@weight",SqlDbType.Float,8),
                                                        new SqlParameter("@cbm",SqlDbType.Float,8),
                                                        new SqlParameter("@sbno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};


            objp[0].Value = jobno;
            objp[1].Value = customer;
            objp[2].Value = noofpkgs;
            objp[3].Value = pkgtype;
            objp[4].Value = weight;
            objp[5].Value = cbm;
            objp[6].Value = sbno;
            objp[7].Value = bid;
            objp[8].Value = cid;
            ExecuteQuery("SPInsBTJobDetails", objp);

        }
        public void UpdBTJobInfo(string Truckno, int FromPort, DateTime etd, int ToPort, DateTime eta, int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@truckno",SqlDbType.VarChar,15),
                                                        new SqlParameter("@fromport",SqlDbType.Int,4),
                                                        new SqlParameter ("etd",SqlDbType.DateTime,8),
                                                        new SqlParameter("@toport",SqlDbType.Int,4),
                                                        new SqlParameter("@eta",SqlDbType.DateTime,8),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};


            objp[0].Value = Truckno;
            objp[1].Value = FromPort;
            objp[2].Value = etd;
            objp[3].Value = ToPort;
            objp[4].Value = eta;
            objp[5].Value = jobno;
            objp[6].Value = bid;
            objp[7].Value = cid;
            ExecuteQuery("SPUpdBTJobInfo", objp);

        }
        public void UpdBTJobDetails(int jobno, int customer, int noofpkgs, int pkgtype, double weight, double cbm, string sbno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@customer",SqlDbType.Int,4),
                                                        new SqlParameter ("noofpkgs",SqlDbType.Int,4),
                                                        new SqlParameter("@pkgtype",SqlDbType.Int,4),
                                                        new SqlParameter("@weight",SqlDbType.Float,8),
                                                        new SqlParameter("@cbm",SqlDbType.Float,8),
                                                        new SqlParameter("@sbno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};


            objp[0].Value = jobno;
            objp[1].Value = customer;
            objp[2].Value = noofpkgs;
            objp[3].Value = pkgtype;
            objp[4].Value = weight;
            objp[5].Value = cbm;
            objp[6].Value = sbno;
            objp[7].Value = bid;
            objp[8].Value = cid;
            ExecuteQuery("SPUpdBTJobDetails", objp);

        }
        public void DeleteBTJobCustomer(int jobno, string sbno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@sbno",SqlDbType.Char,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = sbno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPDelBTJobCustomer", objp);
        }
        public DataTable GetBTJobInfo(int intjobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intjobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelBTJobInfo", objp);
        }
        public DataTable GetBTJobInfoFSBNo(string sbno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sbno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = sbno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPGetBTJobDetailsFShipBillNo", objp);
        }
        public DataTable GetBTJobDetails(int intjobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 2),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intjobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelBTJobDetails", objp);
        }

        public DataTable GetBTJobInfoALL(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt,1), 
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPSelBTJobInfoALL", objp);
        }
        public DataTable GetLikeBTCustomer(string customername, int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customer", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)};
            objp[0].Value = customername;
            objp[1].Value = jobno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return ExecuteTable("SPLikeBTCustomer", objp);
        }

        public DataTable GetLikeBTSBNo(string sbno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sbno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)};
            objp[0].Value = sbno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPLikeBTSBnoNo", objp);
        }


        public void InsICDMovement(string trantype, int jobno, string icdmmt, DateTime etd, DateTime eta, int ToPort, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@icdmmt",SqlDbType.VarChar,25),
                                                        new SqlParameter ("etd",SqlDbType.DateTime,8),
                                                        new SqlParameter("@eta",SqlDbType.DateTime,8),
                                                        new SqlParameter("@toport",SqlDbType.Int,4),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)
                                                        };


            objp[0].Value = trantype;
            objp[1].Value = jobno;
            objp[2].Value = icdmmt;
            objp[3].Value = etd;
            objp[4].Value = eta;
            objp[5].Value = ToPort;
            objp[6].Value = bid;
            objp[7].Value = cid;
            ExecuteQuery("SPInsICDMovement", objp);

        }
        public void UpdICDMovement(int jobno, string icdmmt, DateTime etd, DateTime eta, int ToPort, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@icdmmt",SqlDbType.VarChar,25),
                                                        new SqlParameter ("etd",SqlDbType.DateTime,8),
                                                        new SqlParameter("@eta",SqlDbType.DateTime,8),
                                                        new SqlParameter("@toport",SqlDbType.Int,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)
                                                        };



            objp[0].Value = jobno;
            objp[1].Value = icdmmt;
            objp[2].Value = etd;
            objp[3].Value = eta;
            objp[4].Value = ToPort;
            objp[5].Value = bid;
            objp[6].Value = cid;
            ExecuteQuery("SPUpdICDMovement", objp);

        }
        public DataTable GetICDMovement(int intjobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1)};
            objp[0].Value = intjobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelICDMovement", objp);
        }
        public int CheckCustomeridExist(int customerid, int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customer",SqlDbType.Int,4),        
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid", SqlDbType.TinyInt,1)};
            objp[0].Value = customerid;
            objp[1].Value = jobno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return int.Parse(ExecuteReader("SPCheckBTJobCustomer", objp));
        }

        public DataTable SelFIBT4Transfer(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1) };
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPSelFIBT4Transfer", objp);
        }

        public void InsBTSBDtls(int JobNo, string BLno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt,1) };
            objp[0].Value = JobNo;
            objp[1].Value = BLno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPInsBTSBDtls", objp);
        }

        public DataTable GetLikeBTSBNoAfterJobclose(string sbno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sbno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = sbno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPLikeBTSBnoNoAfterjobclose", objp);
        }
    }
}
