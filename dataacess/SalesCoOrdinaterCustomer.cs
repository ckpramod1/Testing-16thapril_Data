using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;


namespace DataAccess
{
    public class SalesCoOrdinaterCustomer:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public SalesCoOrdinaterCustomer()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetSalesCoordinater(string empname, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sales", SqlDbType.VarChar, 100),
             new SqlParameter("@cid", SqlDbType.Int )};
            objp[0].Value = empname;
            objp[1].Value = division;
            return ExecuteTable("SPSelGetSalesCoordinater", objp);
        }
        public DataSet  GetCustomer4SalesCoordinater(int empid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@empid", SqlDbType.Int ),
             new SqlParameter("@cid", SqlDbType.Int )};
            objp[0].Value = empid;
            objp[1].Value = cid;

            return ExecuteDataSet("SPSELGetCustomer4SalesCoordinater", objp);
        }
        public void UpdMAsterCustomerSC(int sc,int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {new SqlParameter("@sc",SqlDbType.Int,4),

                new SqlParameter("@customerid",SqlDbType.Int,4)
            };
            objp[0].Value = sc;
            objp[1].Value = customerid ;
            ExecuteQuery("SPUpdMAsterCustomerSC", objp);
        }
        public DataTable GetSelCustomerSales(int empid,int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@empid", SqlDbType.Int ),
             new SqlParameter("@cid", SqlDbType.Int )};
            objp[0].Value = empid ;
            objp[1].Value = cid ;

            return ExecuteTable("SPSelCustomerSales", objp);
        }

        public void SPUpdMAsterCustomerSCUnChk(int sc, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {new SqlParameter("@sc",SqlDbType.Int,4),

                new SqlParameter("@customerid",SqlDbType.Int,4)
            };
            objp[0].Value = sc;
            objp[1].Value = customerid;
            ExecuteQuery("SPUpdMAsterCustomerSCUnChk", objp);
        }
        public DataTable sPGetRights4BM(int empid, int cid,int portid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@empid", SqlDbType.Int ),
             new SqlParameter("@cid", SqlDbType.Int ),
            new SqlParameter("@bid", SqlDbType.Int )};
            objp[0].Value = empid;
            objp[1].Value = cid;
            objp[2].Value = portid;

            return ExecuteTable("sPGetRights4BM", objp);
        }


        //Dinesh  -->Amend job close date 


        public void Updatejobclosingdetachanges(int jobno, int bid, string trantype, DateTime jobdate)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int,4),
                                               new SqlParameter("@bid",SqlDbType.Int,4),
                                               new SqlParameter("@trantype",SqlDbType.VarChar,30),
                                               new SqlParameter("@closedate",SqlDbType.SmallDateTime,4),
                                     };

            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            objp[3].Value = jobdate;

            ExecuteQuery("spjobclosingdetachanges", objp);
        }

        public void spinsjobclosedatechk(int uiid, int jobno, string trantype, int bid,int empid, DateTime jobdatebf, DateTime jobdateaf)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@uiid",SqlDbType.Int,4),
                                                 new SqlParameter("@jobno",SqlDbType.Int,4),                                              
                                               new SqlParameter("@trantype",SqlDbType.VarChar,30),
                                                new SqlParameter("@branchid",SqlDbType.Int,4),
                                                   new SqlParameter("@empid",SqlDbType.Int,4),
                                               new SqlParameter("@closdeatebefore",SqlDbType.SmallDateTime,4),
                                               new SqlParameter("@closdeatedafter",SqlDbType.SmallDateTime,4),
                                     };


            objp[0].Value = uiid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            objp[4].Value = empid;
            objp[5].Value = jobdatebf;
            objp[6].Value = jobdateaf;

            ExecuteQuery("spinsjobclosedatechk", objp);
        }


        public DataTable getjobclosingdeta(int jobno, int bid, string trantype)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int,4),
                                               new SqlParameter("@bid",SqlDbType.Int,4),
                                               new SqlParameter("@trantype",SqlDbType.VarChar,30)
                                              
                                     };

            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = trantype;


            return ExecuteTable("spgetjobclosingdeta", objp);
        }


        public void updvoucherjobclosingdetachanges(int jobno, int bid, string trantype, DateTime jobdate, int vouno, string voutype, int vouyear, string dbname)
        {

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int,4),
                                               new SqlParameter("@bid",SqlDbType.Int,4),
                                               new SqlParameter("@trantype",SqlDbType.VarChar,30),
                                               new SqlParameter("@closedate",SqlDbType.SmallDateTime,4),
                                                 new SqlParameter("@vouno",SqlDbType.Int,4),
                                                 
                                                   new SqlParameter("@voutype",SqlDbType.VarChar,30),
                                                    new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                     };

            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = trantype;
            objp[3].Value = jobdate;
            objp[4].Value = vouno;
            objp[5].Value = voutype;
            objp[6].Value = vouyear;
            objp[7].Value = dbname;
            ExecuteQuery("spvoucherjobclosingdetachanges", objp);
        }




    }
}
