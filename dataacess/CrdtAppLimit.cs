using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace DataAccess
{
    public  class CrdtAppLimit : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CrdtAppLimit()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetLikeEmpNameDivBranch(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = empname;
            return ExecuteTable("SPLikeEmpNameDivBranch", objp);
        }

        public DataTable GetLikeBranchName(int divisionid, string branchname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int ,4),
                                                       new SqlParameter("@branchname",SqlDbType.VarChar ,30)};
            objp[0].Value = divisionid;
            objp[1].Value = branchname;
            return ExecuteTable("SPLikeBranchName", objp);
        }

        public DataTable GetCrdtAppLimitDetails(int bid,int division,int dsodays)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int , 2) ,
                                                       new SqlParameter("@division", SqlDbType.Int ,2) ,
                                                       new SqlParameter("@dsodays", SqlDbType.Int , 4) 
                                                     };
            objp[0].Value = bid;
            objp[1].Value = division;
            objp[2].Value = dsodays;
            return ExecuteTable("SPGetCrdtAppLimitDetails", objp);

        }

        public DataTable GetCrdtAmtLimitEmpwise(int bid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int , 2) ,
                                                       new SqlParameter("@division", SqlDbType.Int ,2) 
                                                     };
            objp[0].Value = bid;
            objp[1].Value = division;
            return ExecuteTable("SPGetCrdtAmtLimitEmpwise", objp);

        }


        public void InsCrdtLimit(int empid,int bid,int division,double amt,int day,int excem)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@empid",SqlDbType.Int),
                                new SqlParameter("@bid",SqlDbType.TinyInt ),
                                new SqlParameter("@division",SqlDbType.TinyInt ),
                                new SqlParameter("@amt",SqlDbType.Money ,8),
                                new SqlParameter("@day",SqlDbType.Int ,4),
                                new SqlParameter("@excem",SqlDbType.Int,4)
                            };

            objp[0].Value = empid;
            objp[1].Value = bid;
            objp[2].Value = division;
            objp[3].Value = amt;
            objp[4].Value = day;
            objp[5].Value = excem;
            ExecuteQuery("SPInsMasterCrdtAppLimit", objp);
        }

        public void UpdCrdtLimit(int empid, int bid, int division, double amt, int day, int excem)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@empid",SqlDbType.Int),
                                new SqlParameter("@bid",SqlDbType.TinyInt ),
                                new SqlParameter("@division",SqlDbType.TinyInt ),
                                new SqlParameter("@amt",SqlDbType.Money ,8),
                                new SqlParameter("@day",SqlDbType.Int ,4),
                                new SqlParameter("@excem",SqlDbType.Int,4)
                            };

            objp[0].Value = empid;
            objp[1].Value = bid;
            objp[2].Value = division;
            objp[3].Value = amt;
            objp[4].Value = day;
            objp[5].Value = excem;
            ExecuteQuery("SPUpdMasterCrdtAppLimit", objp);
        }

        public void DelCrdtLimit(int empid,int bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@empid",SqlDbType.Int),
                                new SqlParameter("@bid",SqlDbType.TinyInt )
                            };
            objp[0].Value = empid;
            objp[1].Value = bid;
            ExecuteQuery("SPDelMasterCrdtAppLimit", objp);
        }
        

        public DataTable SelCrdtLimit()
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                            };
           return ExecuteTable("SPSelMasterCrdtAppLimit", objp);
        }

        public DataTable SelPortwiseCrdtLimit(int portid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@portid",SqlDbType.Int,4)
                            };
            objp[0].Value = portid;
            return ExecuteTable("SPSelPortwiseMasterCrdtAppLimit", objp);
        }

        public DataTable SelPortwiseCrdtLimitNew(int bid,int DivID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@bid",SqlDbType.Int,4),
                                new SqlParameter("@DivID",SqlDbType.TinyInt)
                            };
            objp[0].Value = bid;
            objp[1].Value = DivID;
            return ExecuteTable("SPSelPortwiseMasterCrdtAppLimitNew", objp);
        }

        public DataTable SelEmpCrdtLimit(int empid,int bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@empid",SqlDbType.Int,4),
                                new SqlParameter("@bid",SqlDbType.TinyInt)
                            };
            objp[0].Value = empid;
            objp[1].Value = bid;
            return ExecuteTable("SPSelEmpMasterCrdtAppLimit", objp);
        }

      public Double GetAmountLmt(int bid,int divisionid,int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@bid",SqlDbType.Int,4),
                                new SqlParameter("@divisionid",SqlDbType.TinyInt),
                                new SqlParameter("@empid",SqlDbType.Int,4)
                            };
            objp[0].Value = bid;
            objp[1].Value = divisionid ;
            objp[2].Value = empid;
            return double.Parse(ExecuteReader("SPGetAmountLmt", objp));
        }

       
        public Double GetDayLmt(int bid, int divisionid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@bid",SqlDbType.Int,4),
                                new SqlParameter("@divisionid",SqlDbType.TinyInt),
                                new SqlParameter("@empid",SqlDbType.Int,4)
                            };
            objp[0].Value = bid;
            objp[1].Value = divisionid;
            objp[2].Value = empid;
            return double.Parse(ExecuteReader("SPGetDayLmt", objp));
        }

        public string GetPortName(int bid,int division)
        {
            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt  , 1),
                                                       new SqlParameter("@division", SqlDbType.TinyInt  , 1)};

            //objp[0].Value = bid;
            objp[0].Value = bid;
             objp[1].Value = division ;
             return ExecuteReader("SPGetBranchName4CrdtLmt", objp);

        }


        public DataTable GetLikeCreditCustomer(string customername, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100),
             new SqlParameter("@division", SqlDbType.TinyInt  , 1)};

            objp[0].Value = customername;
            objp[1].Value = division;
            return ExecuteTable("SPGetCreditCustomer", objp);
        }
        public void InsExemptionDtls(int canid, int branch, int maxlimit)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@canid",SqlDbType.Int,4),
                new SqlParameter("@division",SqlDbType.Int,4),
                new SqlParameter("@maxlimit",SqlDbType.Int,4)

            };
            objp[0].Value = canid;
            objp[1].Value = branch;
            objp[2].Value = maxlimit;
            ExecuteQuery("SPInsExemptionLimit", objp);
        }
        public void UpdExemptionDtls(int canid, int maxlimit)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@canid",SqlDbType.Int,4),
                new SqlParameter("@maxlimit",SqlDbType.Int,4)

            };
            objp[0].Value = canid;
            objp[1].Value = maxlimit;
            ExecuteQuery("SPUpdExlimit", objp);
        }
        public void DelExempDtls(int canid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                new SqlParameter("@canid",SqlDbType.Int,4)

            };
            objp[0].Value = canid;
            ExecuteQuery("SPDelexemp", objp);
        }
        public DataTable GetExemptionLimit(int canid)
        {
            SqlParameter[] objp = new SqlParameter[]{
                 new SqlParameter("@canid",SqlDbType.Int,4)
            };
            objp[0].Value = canid;
            return ExecuteTable("SPGetExemptionLimit", objp);
        }
        
    }
}
