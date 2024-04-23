using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.NVOCC_Imports
{
    public class JobInfo : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public JobInfo()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsertJoboinfo(int vessel, string voyage, int pol, int pod,  DateTime etd, DateTime eta, int principal, int counterpart, int carrier, int slotoperator, string viano,string vslcode,string agentcode,string linecode,string remarks,int jobopenedby,int bid,int cid, DateTime jobdate,string ourprincipal,string imno, DateTime imdate)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vessel",SqlDbType.Int),
                                                     new SqlParameter("@voyage",SqlDbType.VarChar,15),        
                                                     new SqlParameter("@pol",SqlDbType.Int), 
                                                     new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@principal",SqlDbType.Int,4),
                                                     new SqlParameter("@counterpart",SqlDbType.Int,4), 
                                                     new SqlParameter("@carrier",SqlDbType.Int,4),
                                                     new SqlParameter("@slotoperator",SqlDbType.Int,4),        
                                                     new SqlParameter("@viano",SqlDbType.VarChar,15), 
                                                     new SqlParameter("@vslcode",SqlDbType.VarChar,15),        
                                                     new SqlParameter("@agentcode",SqlDbType.VarChar,15), 
                                                     new SqlParameter("@linecode",SqlDbType.VarChar,15),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,50),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@jobopenedby",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@jobdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@ourprincipal",SqlDbType.Char,1),
                                                     new SqlParameter("@imno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@imdate",SqlDbType.SmallDateTime,4)};
            objp[0].Value = vessel;
            objp[1].Value = voyage;
            objp[2].Value = pol;
            objp[3].Value = etd;
            objp[4].Value = pod;
            objp[5].Value = eta;
            objp[6].Value = principal;
            objp[7].Value = counterpart;
            objp[8].Value = carrier;
            objp[9].Value = slotoperator;
            objp[10].Value = viano;
            objp[11].Value = vslcode;
            objp[12].Value = agentcode;
            objp[13].Value = linecode;
            objp[14].Value = remarks;
            objp[15].Direction = ParameterDirection.Output;
            objp[16].Value = jobopenedby;
            objp[17].Value = bid;
            objp[18].Value = cid;
            objp[19].Value = jobdate;
            objp[20].Value = ourprincipal;
            objp[21].Value = imno;
            objp[22].Value = imdate;
            return ExecuteQuery("SPNIInsJobInfo", objp, "@jobno");
        }

        public void UpdateJoboinfo(int jobno, int vessel, string voyage, int pol, int pod, DateTime etd, DateTime eta, int principal, int counterpart, int carrier, int slotoperator, string viano, string vslcode, string agentcode, string linecode, string remarks, int bid, int cid, string ourprincipal,string imno, DateTime imdate)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@vessel",SqlDbType.Int),
                                                     new SqlParameter("@voyage",SqlDbType.VarChar,15),        
                                                     new SqlParameter("@pol",SqlDbType.Int), 
                                                     new SqlParameter("@etd",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@eta",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@principal",SqlDbType.Int,4),
                                                     new SqlParameter("@counterpart",SqlDbType.Int,4), 
                                                     new SqlParameter("@carrier",SqlDbType.Int,4),
                                                     new SqlParameter("@slotoperator",SqlDbType.Int,4),        
                                                     new SqlParameter("@viano",SqlDbType.VarChar,15), 
                                                     new SqlParameter("@vslcode",SqlDbType.VarChar,15),        
                                                     new SqlParameter("@agentcode",SqlDbType.VarChar,15), 
                                                     new SqlParameter("@linecode",SqlDbType.VarChar,15),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,50),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@ourprincipal",SqlDbType.Char,1),
                                                     new SqlParameter("@imno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@imdate",SqlDbType.SmallDateTime,4)};
            objp[0].Value = vessel;
            objp[1].Value = voyage;
            objp[2].Value = pol;
            objp[3].Value = etd;
            objp[4].Value = pod;
            objp[5].Value = eta;
            objp[6].Value = principal;
            objp[7].Value = counterpart;
            objp[8].Value = carrier;
            objp[9].Value = slotoperator;
            objp[10].Value = viano;
            objp[11].Value = vslcode;
            objp[12].Value = agentcode;
            objp[13].Value = linecode;
            objp[14].Value = remarks;
            objp[15].Value = jobno;
            objp[16].Value = bid;
            objp[17].Value = cid;
            objp[18].Value = ourprincipal;
            objp[19].Value = imno;
            objp[20].Value = imdate;
            ExecuteQuery("SPNIUpdJobInfo", objp);
        }

        public DataTable ShowJobInfoAll(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPNISelJobInfoAll", objp);
        }

        public DataTable ShowJobInfoAllWithOutClosedJob(int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bid;
            objp[1].Value = cid;
            return ExecuteTable("SPNISelJobInfoAllWithOutClosedJob", objp);
        }

        public DataTable ShowJobInfoFromJobno(int intjobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = intjobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNISelJobInfoFromJobno", objp);
        }

        public int CheckJobClose(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return int.Parse(ExecuteReader("SPNICheckJobClose", objp));
        }
        public void UpdateCanDate(int jobno, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            ExecuteQuery("SPNIUpdCanDate", objp);
        }
    }
}
