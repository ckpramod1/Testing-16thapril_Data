using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingExports
{
    public class MREDI : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MREDI()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsMREDIDtls(string blno, string type, string salescode, string conttype, string contno, DateTime cydate, DateTime cfsdate, string isfflag, string amsflag, string dgrgoods, string switchflag, int bid, int ctype, string shipcode, string consgcode, string notifycode, DateTime podeta, DateTime fdeta, string shiporderno, int carrid, string carriercode)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                 new SqlParameter ("@type",SqlDbType.Char,1),
                new SqlParameter ("@salescode",SqlDbType.VarChar,15),
                 new SqlParameter ("@conttype",SqlDbType.VarChar,2),
                 new SqlParameter ("@contno",SqlDbType.VarChar,15),
                new SqlParameter("@cydate",SqlDbType.SmallDateTime,4),
                new SqlParameter("@cfsdate",SqlDbType.SmallDateTime,4),
               new SqlParameter ("@isfflag",SqlDbType.Char  ,1),
                new SqlParameter ("@amsflag",SqlDbType.Char  ,1),
                 new SqlParameter ("@dgrgoods",SqlDbType.Char,1),
                new SqlParameter ("@switchflag",SqlDbType.Char  ,1),
                new SqlParameter ("@bid",SqlDbType .Int ,4),
                new SqlParameter ("@ctype",SqlDbType .TinyInt ,1),
                new SqlParameter ("@shipcode",SqlDbType.VarChar,15),
                new SqlParameter ("@consgcode",SqlDbType.VarChar,15),
                new SqlParameter ("@notifycode",SqlDbType.VarChar,15),
                 new SqlParameter("@podeta",SqlDbType.SmallDateTime,4),
                new SqlParameter("@fdeta",SqlDbType.SmallDateTime,4),
                new SqlParameter ("@shiporderno",SqlDbType.VarChar,15),
                new SqlParameter ("@carrierid",SqlDbType.Int,4),
                 new SqlParameter ("@carriercode",SqlDbType.VarChar,10),


        };
            obj[0].Value = blno;
            obj[1].Value = type;
            obj[2].Value = salescode;
            obj[3].Value = conttype;
            obj[4].Value = contno;
            obj[5].Value = cydate;
            obj[6].Value = cfsdate;
            obj[7].Value = isfflag;
            obj[8].Value = amsflag;
            obj[9].Value = dgrgoods;
            obj[10].Value = switchflag;
            obj[11].Value = bid;
            obj[12].Value = ctype;
            obj[13].Value = shipcode;
            obj[14].Value = consgcode;
            obj[15].Value = notifycode;
            obj[16].Value = podeta;
            obj[17].Value = fdeta;
            obj[18].Value = shiporderno;
            obj[19].Value = carrid;
            obj[20].Value = carriercode;
            ExecuteQuery("SPInsMREDIDtls", obj);
        }
        public void UpdMREDIDtls(string blno, string type, string salescode, string conttype, string contno, DateTime cydate, DateTime cfsdate, string isfflag, string amsflag, string dgrgoods, string switchflag, int bid, int ctype, string shipcode, string consgcode, string notifycode, DateTime podeta, DateTime fdeta, string shiporderno, int carrid, string carriercode)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                 new SqlParameter ("@type",SqlDbType.Char,1),
                new SqlParameter ("@salescode",SqlDbType.VarChar,15),
                 new SqlParameter ("@conttype",SqlDbType.VarChar,2),
                 new SqlParameter ("@contno",SqlDbType.VarChar,15),
                new SqlParameter("@cydate",SqlDbType.SmallDateTime,4),
                new SqlParameter("@cfsdate",SqlDbType.SmallDateTime,4),
               new SqlParameter ("@isfflag",SqlDbType.Char  ,1),
                new SqlParameter ("@amsflag",SqlDbType.Char  ,1),
                 new SqlParameter ("@dgrgoods",SqlDbType.Char,1),
                new SqlParameter ("@switchflag",SqlDbType.Char  ,1),
                new SqlParameter ("@bid",SqlDbType .Int ,4),
                new SqlParameter ("@ctype",SqlDbType .TinyInt ,1),
                new SqlParameter ("@shipcode",SqlDbType.VarChar,15),
                new SqlParameter ("@consgcode",SqlDbType.VarChar,15),
                new SqlParameter ("@notifycode",SqlDbType.VarChar,15),
                 new SqlParameter("@podeta",SqlDbType.SmallDateTime,4),
                new SqlParameter("@fdeta",SqlDbType.SmallDateTime,4),
                 new SqlParameter ("@shiporderno",SqlDbType.VarChar,15),
                 new SqlParameter ("@carrierid",SqlDbType.Int,4),
                new SqlParameter ("@carriercode",SqlDbType.VarChar,10),
                
        };
            obj[0].Value = blno;
            obj[1].Value = type;
            obj[2].Value = salescode;
            obj[3].Value = conttype;
            obj[4].Value = contno;
            obj[5].Value = cydate;
            obj[6].Value = cfsdate;
            obj[7].Value = isfflag;
            obj[8].Value = amsflag;
            obj[9].Value = dgrgoods;
            obj[10].Value = switchflag;
            obj[11].Value = bid;
            obj[12].Value = ctype;
            obj[13].Value = shipcode;
            obj[14].Value = consgcode;
            obj[15].Value = notifycode;
            obj[16].Value = podeta;
            obj[17].Value = fdeta;
            obj[18].Value = shiporderno;
            obj[19].Value = carrid;
            obj[20].Value = carriercode;
            ExecuteQuery("SPUpdMREDIDtls", obj);
        }
        //old
        //public void UpdMREDIDtls(string blno, string salescode, string undgno, string imocode, string dgrgoods, string isfflag, string amsflag, string switchflag, int bid)
        //{
        //    SqlParameter[] obj = new SqlParameter[]
        //    {
        //        new SqlParameter("@blno",SqlDbType.VarChar ,30),
        //        new SqlParameter ("@salescode",SqlDbType.VarChar,15),
        //         new SqlParameter ("@undgno",SqlDbType.VarChar,15),
        //         new SqlParameter ("@imocode",SqlDbType.VarChar,15),
        //        new SqlParameter ("@dgrgoods",SqlDbType.VarChar,15),
        //        new SqlParameter ("@isfflag",SqlDbType.VarChar  ,1),
        //        new SqlParameter ("@amsflag",SqlDbType.VarChar  ,1),
        //        new SqlParameter ("@switchflag",SqlDbType.VarChar  ,1),
        //        new SqlParameter ("@bid",SqlDbType .Int ,4)
                

        //};
        //    obj[0].Value = blno;
        //    obj[1].Value = salescode;
        //    obj[2].Value = undgno;
        //    obj[3].Value = imocode;
        //    obj[4].Value = dgrgoods;
        //    obj[5].Value = isfflag;
        //    obj[6].Value = amsflag;
        //    obj[7].Value = switchflag;
        //    obj[8].Value = bid;
        //    ExecuteQuery("SPUpdMREDIDtls", obj);
        //}
        public DataTable GetMREDIDets(string blno, int bid)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@blno",SqlDbType .VarChar,30),
                new SqlParameter("@bid", SqlDbType.Int,4),
            };

            obj[0].Value = blno;
            obj[1].Value = bid;
            return ExecuteTable("SPGetMREDIDets", obj);
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

        public string GetCountryMRcode(int portid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@portid", SqlDbType.Int) };
            objp[0].Value = portid;
            return ExecuteReader("SPGetCountryMRcode", objp);
        }

        public string GetMRJobno(int jmonth,int jyear,string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@jmonth", SqlDbType.Int, 4),
                new SqlParameter("@jyear", SqlDbType.Int, 4),
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                        };
            objp[0].Value = jmonth;
            objp[1].Value = jyear;
            objp[2].Value = blno;
            return ExecuteReader("SPGetMRJobno", objp);
        }


        //new code 4 EDIJobNo
        public string Getedijobno(int jobno,int bid,string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                new SqlParameter("@bid", SqlDbType.TinyInt,1),
             new SqlParameter("@blno",SqlDbType.VarChar,20),};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = blno;
            return ExecuteReader("SPGetedijob", objp);
        }
        public void Updedijobno(int jobno, string blno, string edijobno, int bid)
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
            ExecuteQuery("SPUpdedijobno", objp);
        }

        //
        public DataTable GetMREDIDets4so(string @sono, int bid)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@sono",SqlDbType .VarChar,30),
                new SqlParameter("@bid", SqlDbType.Int,4),
            };

            obj[0].Value = sono;
            obj[1].Value = bid;
            return ExecuteTable("SPGetMREDIDets4so", obj);
        }

        //Nambi
        public DataTable GetMREDIDets4consol(int jobno, int bid)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@jobno",SqlDbType.Int,4),
                new SqlParameter("@bid", SqlDbType.Int,4),
            };

            obj[0].Value = jobno;
            obj[1].Value = bid;
            return ExecuteTable("SPGetMREDIDets4consol", obj);
        }

        //Nambi
        public DataTable GetMREDIDets4consolNew(int jobno, int bid, string contno)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@jobno",SqlDbType.Int,4),
                new SqlParameter("@bid", SqlDbType.Int,4),
                new SqlParameter("@contno",SqlDbType.VarChar ,30),
            };

            obj[0].Value = jobno;
            obj[1].Value = bid;
            obj[2].Value = contno;
            return ExecuteTable("SPGetMREDIDets4consolNew", obj);
        }

        public void UpdMREDIDtlsnew(string blno, string type, string salescode, string conttype, string contno, DateTime cydate, DateTime cfsdate, string isfflag, string amsflag, string dgrgoods, string switchflag, int bid, int ctype, string shipcode, string consgcode, string notifycode, DateTime podeta, DateTime fdeta, string shiporderno, int carrid, string carriercode, string mblno)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                 new SqlParameter ("@type",SqlDbType.Char,1),
                new SqlParameter ("@salescode",SqlDbType.VarChar,15),
                 new SqlParameter ("@conttype",SqlDbType.VarChar,2),
                 new SqlParameter ("@contno",SqlDbType.VarChar,15),
                new SqlParameter("@cydate",SqlDbType.SmallDateTime,4),
                new SqlParameter("@cfsdate",SqlDbType.SmallDateTime,4),
               new SqlParameter ("@isfflag",SqlDbType.Char  ,1),
                new SqlParameter ("@amsflag",SqlDbType.Char  ,1),
                 new SqlParameter ("@dgrgoods",SqlDbType.Char,1),
                new SqlParameter ("@switchflag",SqlDbType.Char  ,1),
                new SqlParameter ("@bid",SqlDbType .Int ,4),
                new SqlParameter ("@ctype",SqlDbType .TinyInt ,1),
                new SqlParameter ("@shipcode",SqlDbType.VarChar,15),
                new SqlParameter ("@consgcode",SqlDbType.VarChar,15),
                new SqlParameter ("@notifycode",SqlDbType.VarChar,15),
                 new SqlParameter("@podeta",SqlDbType.SmallDateTime,4),
                new SqlParameter("@fdeta",SqlDbType.SmallDateTime,4),
                 new SqlParameter ("@shiporderno",SqlDbType.VarChar,15),
                 new SqlParameter ("@carrierid",SqlDbType.Int,4),
                new SqlParameter ("@carriercode",SqlDbType.VarChar,10),
                 new SqlParameter ("@mblno",SqlDbType.VarChar,50),
                
        };
            obj[0].Value = blno;
            obj[1].Value = type;
            obj[2].Value = salescode;
            obj[3].Value = conttype;
            obj[4].Value = contno;
            obj[5].Value = cydate;
            obj[6].Value = cfsdate;
            obj[7].Value = isfflag;
            obj[8].Value = amsflag;
            obj[9].Value = dgrgoods;
            obj[10].Value = switchflag;
            obj[11].Value = bid;
            obj[12].Value = ctype;
            obj[13].Value = shipcode;
            obj[14].Value = consgcode;
            obj[15].Value = notifycode;
            obj[16].Value = podeta;
            obj[17].Value = fdeta;
            obj[18].Value = shiporderno;
            obj[19].Value = carrid;
            obj[20].Value = carriercode;
            obj[21].Value = mblno;
            ExecuteQuery("SPUpdMREDIDtlsNEW", obj);
        }


        public void InsMREDIDtlsnew(string blno, string type, string salescode, string conttype, string contno, DateTime cydate, DateTime cfsdate, string isfflag, string amsflag, string dgrgoods, string switchflag, int bid, int ctype, string shipcode, string consgcode, string notifycode, DateTime podeta, DateTime fdeta, string shiporderno, int carrid, string carriercode, string mblno)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                 new SqlParameter ("@type",SqlDbType.Char,1),
                new SqlParameter ("@salescode",SqlDbType.VarChar,15),
                 new SqlParameter ("@conttype",SqlDbType.VarChar,2),
                 new SqlParameter ("@contno",SqlDbType.VarChar,15),
                new SqlParameter("@cydate",SqlDbType.SmallDateTime,4),
                new SqlParameter("@cfsdate",SqlDbType.SmallDateTime,4),
               new SqlParameter ("@isfflag",SqlDbType.Char  ,1),
                new SqlParameter ("@amsflag",SqlDbType.Char  ,1),
                 new SqlParameter ("@dgrgoods",SqlDbType.Char,1),
                new SqlParameter ("@switchflag",SqlDbType.Char  ,1),
                new SqlParameter ("@bid",SqlDbType .Int ,4),
                new SqlParameter ("@ctype",SqlDbType .TinyInt ,1),
                new SqlParameter ("@shipcode",SqlDbType.VarChar,15),
                new SqlParameter ("@consgcode",SqlDbType.VarChar,15),
                new SqlParameter ("@notifycode",SqlDbType.VarChar,15),
                 new SqlParameter("@podeta",SqlDbType.SmallDateTime,4),
                new SqlParameter("@fdeta",SqlDbType.SmallDateTime,4),
                new SqlParameter ("@shiporderno",SqlDbType.VarChar,15),
                new SqlParameter ("@carrierid",SqlDbType.Int,4),
                 new SqlParameter ("@carriercode",SqlDbType.VarChar,10),
                 new SqlParameter ("@mblno",SqlDbType.VarChar,50),


        };
            obj[0].Value = blno;
            obj[1].Value = type;
            obj[2].Value = salescode;
            obj[3].Value = conttype;
            obj[4].Value = contno;
            obj[5].Value = cydate;
            obj[6].Value = cfsdate;
            obj[7].Value = isfflag;
            obj[8].Value = amsflag;
            obj[9].Value = dgrgoods;
            obj[10].Value = switchflag;
            obj[11].Value = bid;
            obj[12].Value = ctype;
            obj[13].Value = shipcode;
            obj[14].Value = consgcode;
            obj[15].Value = notifycode;
            obj[16].Value = podeta;
            obj[17].Value = fdeta;
            obj[18].Value = shiporderno;
            obj[19].Value = carrid;
            obj[20].Value = carriercode;
            obj[21].Value = mblno;
            ExecuteQuery("SPInsMREDIDtlsNEW", obj);
        }
    }
}
