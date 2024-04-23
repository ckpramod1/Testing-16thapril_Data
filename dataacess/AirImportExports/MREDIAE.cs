using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.AirImportExports
{
    public class MREDIAE : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MREDIAE()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetAEJobBLDtls4MREDI(string blno, int bid)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@blno",SqlDbType .VarChar,30),
                new SqlParameter("@bid", SqlDbType.Int,4),
            };

            obj[0].Value = blno;
            obj[1].Value = bid;
            return ExecuteTable("SPGetAEJobBLDtls4MREDI", obj);
        }

        public void InsMREDIDtls(string blno, string shiporderno, DateTime arrdate, string conttype, string contno, string dgrgoods, string undgcode, string edijobno, int bid, string shipcode, string consgcode, string notifycode, int carrid, string carriercode,string @jobtype )
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@blno",SqlDbType .VarChar,30),
                new SqlParameter("@shiporderno", SqlDbType.VarChar,15),
                new SqlParameter("@arrdate", SqlDbType.DateTime),
                new SqlParameter("@conttype", SqlDbType.VarChar,15),
                new SqlParameter("@contno", SqlDbType.VarChar,15),
                new SqlParameter("@dgrgoods", SqlDbType.Char,1),
                new SqlParameter("@undgcode", SqlDbType.VarChar,15),
                new SqlParameter("@edijobno", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int,4),
                new SqlParameter ("@shipcode",SqlDbType.VarChar,15),
                new SqlParameter ("@consgcode",SqlDbType.VarChar,15),
                new SqlParameter ("@notifycode",SqlDbType.VarChar,15),
                new SqlParameter ("@carrierid",SqlDbType.Int,4),
                new SqlParameter ("@carriercode",SqlDbType.VarChar,10),
                new SqlParameter ("@jobtype",SqlDbType.VarChar,10),
            };

            obj[0].Value = blno;
            obj[1].Value = shiporderno;
            obj[2].Value = arrdate;
            obj[3].Value = conttype;
            obj[4].Value = contno;
            obj[5].Value = dgrgoods;
            obj[6].Value = undgcode;
            obj[7].Value = edijobno;
            obj[8].Value = bid;
            obj[9].Value = shipcode;
            obj[10].Value = consgcode;
            obj[11].Value = notifycode;
            obj[12].Value = carrid;
            obj[13].Value = carriercode;
            obj[14].Value = jobtype;
            ExecuteQuery("SPInsAEMRDEI", obj);
        }

        public void UpdAEMREDIDtls(string blno, string shiporderno, DateTime arrdate, string conttype, string contno, string dgrgoods, string undgcode, string edijobno, int bid, string shipcode, string consgcode, string notifycode, int carrid, string carriercode,string jobtype)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@blno",SqlDbType .VarChar,30),
                new SqlParameter("@shiporderno", SqlDbType.VarChar,15),
                new SqlParameter("@arrdate", SqlDbType.DateTime),
                new SqlParameter("@conttype", SqlDbType.VarChar,2),
                new SqlParameter("@contno", SqlDbType.VarChar,15),
                new SqlParameter("@dgrgoods", SqlDbType.Char,1),
                new SqlParameter("@undgcode", SqlDbType.VarChar,15),
                new SqlParameter("@edijobno", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int,4),
                new SqlParameter ("@shipcode",SqlDbType.VarChar,15),
                new SqlParameter ("@consgcode",SqlDbType.VarChar,15),
                new SqlParameter ("@notifycode",SqlDbType.VarChar,15),
                new SqlParameter ("@carrierid",SqlDbType.Int,4),
                new SqlParameter ("@carriercode",SqlDbType.VarChar,10),
                new SqlParameter ("@jobtype",SqlDbType.VarChar,10)
            };

            obj[0].Value = blno;
            obj[1].Value = shiporderno;
            obj[2].Value = arrdate;
            obj[3].Value = conttype;
            obj[4].Value = contno;
            obj[5].Value = dgrgoods;
            obj[6].Value = undgcode;
            obj[7].Value = edijobno;
            obj[8].Value = bid;
            obj[9].Value = shipcode;
            obj[10].Value = consgcode;
            obj[11].Value = notifycode;
            obj[12].Value = carrid;
            obj[13].Value = carriercode;
            obj[14].Value = jobtype;
            ExecuteQuery("SPUpdAEMREIDtls", obj);
        }

        public string GetMRJobnoAE(int jmonth, int jyear, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@jmonth", SqlDbType.Int, 4),
                new SqlParameter("@jyear", SqlDbType.Int, 4),
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                        };
            objp[0].Value = jmonth;
            objp[1].Value = jyear;
            objp[2].Value = blno;
            return ExecuteReader("SPGetMRJobnoAE", objp);
        }
        public DataTable GetCustDtls4MREDI(int custid)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter("@custid", SqlDbType.Int,4),
            };

            obj[0].Value = custid;
            return ExecuteTable("SPGetCustDtls4MREDI", obj);
        }

        public void UpdedijobnoAE(int jobno, string blno, string edijobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                      new SqlParameter("@blno",SqlDbType.VarChar,20),
             new SqlParameter("@edijobno",SqlDbType.VarChar,10),
            new SqlParameter("@bid", SqlDbType.TinyInt, 1)
            };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = edijobno;
            objp[3].Value = bid;
            ExecuteQuery("SPUpdedijobnoAE", objp);
        }

        public string GetedijobnoAE(int jobno, int bid, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                new SqlParameter("@bid", SqlDbType.TinyInt,1),
             new SqlParameter("@blno",SqlDbType.VarChar,20),};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = blno;
            return ExecuteReader("SPGetedijobAE", objp);
        }


        public DataTable GetMREDIDets4soAE(string @sono, int bid)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@sono",SqlDbType .VarChar,30),
                new SqlParameter("@bid", SqlDbType.Int,4),
            };

            obj[0].Value = sono;
            obj[1].Value = bid;
            return ExecuteTable("SPGetMREDIDets4soAE", obj);
        }
    }
}
