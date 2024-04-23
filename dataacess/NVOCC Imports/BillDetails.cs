using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.NVOCC_Imports
{
    public class BillDetails : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BillDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsMasterDetDem(int portid,string sizetype,int sfrom,int sto,string curr,double rate,string Ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@portid",SqlDbType.Int),
                                                     new SqlParameter("@sizetype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@sfrom",SqlDbType.Int,4),
                                                     new SqlParameter("@sto",SqlDbType.Int,4),
                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                     new SqlParameter("@rate",SqlDbType.SmallMoney,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2)};
            objp[0].Value = portid;
            objp[1].Value = sizetype;
            objp[2].Value = sfrom;
            objp[3].Value = sto;
            objp[4].Value = curr;
            objp[5].Value = rate;
            objp[6].Value = Ftype;
            ExecuteQuery("SPNIInsMasterDetentionDemurrage", objp);
        }

        public void UpdMasterDetDem(int slabid, string curr, double rate, string Ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@slabid",SqlDbType.Int),
                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                     new SqlParameter("@rate",SqlDbType.SmallMoney,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2)};
            objp[0].Value = slabid;
            objp[1].Value = curr;
            objp[2].Value = rate;
            objp[3].Value = Ftype;
            ExecuteQuery("SPNIUpdMasterDetentionDemurrage", objp);
        }

        public void DelMasterDetDem(int slabid, string Ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@slabid",SqlDbType.Int),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2)};
            objp[0].Value = slabid;
            objp[1].Value = Ftype;
            ExecuteQuery("SPNIDelMasterDetentionDemurrage", objp);
        }

        public DataTable SelMasterDetDem(int portid, string sizetype,string Ftype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@portid",SqlDbType.Int),
                                                     new SqlParameter("@sizetype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,2)};
            objp[0].Value = portid;
            objp[1].Value = sizetype;
            objp[2].Value = Ftype;
            return ExecuteTable("SPNISelDetentionDemurrage", objp);
        }

        public DataSet InsAndSelWorkingDetailsAll(string blno,int jobno,DateTime validtill,DateTime portout,DateTime plotin,int portid,int bid,int cid,int customerid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@portout",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@plotin",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@portid",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = validtill;
            objp[3].Value = portout;
            objp[4].Value = plotin;
            objp[5].Value = portid;
            objp[6].Value = bid;
            objp[7].Value = cid;
            objp[8].Value = customerid;
            return ExecuteDataSet("SPNIInsWorkingDetails", objp);
        }

        public DataSet SelWorkingDetailsAllFromWid(int wid, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@wid",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = wid;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelWorkingDetailsFromWid", objp);
        }

        public DataSet SelWorkingDetailsAllFromBLNO(string blno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelWorkingDetailsFromBLNO", objp);
        }

        public DataSet InsAndSelPIDetailsAll(string blno, int jobno, DateTime validtill, DateTime portout, DateTime plotin, int portid, int bid, int cid, int customerid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@portout",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@plotin",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@portid",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = validtill;
            objp[3].Value = portout;
            objp[4].Value = plotin;
            objp[5].Value = portid;
            objp[6].Value = bid;
            objp[7].Value = cid;
            objp[8].Value = customerid;
            return ExecuteDataSet("SPNIInsPIDetails", objp);
        }

        public DataSet SelPIDetailsAllFromPid(int pid, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pid",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = pid;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelPIDetailsFromPid", objp);
        }

        public DataSet SelPIDetailsAllFromBLNO(string blno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelPIDetailsFromBLNO", objp);
        }


        public DataSet InsAndSelExtentionDetailsAll(string blno, int jobno, DateTime validtill, DateTime portout, DateTime plotin, int portid, int bid, int cid, int customerid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@validtill",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@portout",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@plotin",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@portid",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = validtill;
            objp[3].Value = portout;
            objp[4].Value = plotin;
            objp[5].Value = portid;
            objp[6].Value = bid;
            objp[7].Value = cid;
            objp[8].Value = customerid;
            return ExecuteDataSet("SPNIInsExtentionDetails", objp);
        }

        public DataSet SelExtentionDetailsAllFromEid(int eid, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@eid",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = eid;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelExtentionDetailsFromeid", objp);
        }

        public DataSet SelExtentionDetailsAllFromBLNO(string blno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelExtentionDetailsFromBLNO", objp);
        }

        public DataSet InsAndSelFinalDetailsAll(string blno, int jobno, int portid, int bid, int cid, int customerid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@portid",SqlDbType.Int),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@customerid",SqlDbType.Int,4)};
            objp[0].Value = blno;
            objp[1].Value = jobno;
            objp[2].Value = portid;
            objp[3].Value = bid;
            objp[4].Value = cid;
            objp[5].Value = customerid;
            return ExecuteDataSet("SPNIInsFIDetails", objp);
        }

        public DataSet SelFinalDetailsAllFromFid(int fid, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@fid",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = fid;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelFIDetailsFromfid", objp);
        }

        public DataSet SelFinalDetailsAllFromBLNO(string blno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteDataSet("SPNISelFIDetailsFromBLNO", objp);
        }
          public void InsmasterBussiness(string planname)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@planname", SqlDbType.VarChar, 30) };

            objp[0].Value = planname;

            ExecuteDataSet("SPInsmasterbusinessplan", objp);
        }

        //public void InsmasterBussiness(int planid, string planname)
        //{

        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@planid",SqlDbType.Int),
        //                                             new SqlParameter("@planname",SqlDbType.VarChar,30)};

        //    objp[0].Value = planid;
        //    objp[1].Value = planname;
        //    ExecuteDataSet("SPInsmasterbusinessplan", objp);
        //}

        public DataTable getplanname(string planname)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@planid",SqlDbType.Int),
                                                     new SqlParameter("@planname",SqlDbType.VarChar,30)};

            objp[0].Value = planname;

            return ExecuteTable("SPplan", objp);
        }


        public void updmasterBussiness(string planname, int planid)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@planname", SqlDbType.VarChar, 30),
                                                         new SqlParameter("@planid", SqlDbType.Int) };

            objp[0].Value = planname;
            objp[1].Value = planid;
            ExecuteDataSet("SPupdmasterbusinessplan", objp);
        }
    }
    }

