using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.BondedTrucking
{
    public class BTInvoice : DBObject
    {
        DataAccess.Masters.MasterCharges chrgobj = new DataAccess.Masters.MasterCharges();
        DataAccess.Masters.MasterEmployee EmpObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BTInvoice()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetLikeTruckNo(string truck, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@truck",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1), 
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = truck;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPLikeBTTruckNo", objp);
        }
        public float GetVolume(int jobno, int customer, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@customer",SqlDbType.Int,4), 
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1), 
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = customer;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return float.Parse(ExecuteReader("SPBTVolume", objp));
        }
        public float GetWeight(int jobno, int customer, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@customer",SqlDbType.Int,4), 
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1), 
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = customer;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return float.Parse(ExecuteReader("SPBTWeight", objp));
        }
        public float GetVolumeFSBNo(string sbno, int customer, int bid, int cid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@sbno",SqlDbType.VarChar,30),        
                                                      new SqlParameter("@customer",SqlDbType.Int,4), 
                                                      new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1), 
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = sbno;
            objp[1].Value = customer;
            objp[2].Value = jobno;
            objp[3].Value = bid;
            objp[4].Value = cid;
            return float.Parse(ExecuteReader("SPBTVolumeFSBNo", objp));
        }
        public float GetWeightFSBNo(string sbno, int customer, int bid, int cid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@sbno",SqlDbType.VarChar,30),    
                                                      new SqlParameter("@customer",SqlDbType.Int,4), 
                                                      new SqlParameter("@jobno",SqlDbType.Int,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt,1), 
                                                      new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = sbno;
            objp[1].Value = customer;
            objp[2].Value = jobno;
            objp[3].Value = bid;
            objp[4].Value = cid;
            return float.Parse(ExecuteReader("SPBTWeightFSBNo", objp));
        }
    }
}
