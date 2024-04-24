using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Outstanding : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Outstanding()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable OutStanding(DateTime fdate, DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@fromdate",SqlDbType.DateTime,8),
                                                      new SqlParameter("@todate",SqlDbType.DateTime,8)
                                                     };
            objp[0].Value = fdate;
            objp[1].Value = tdate;

            return ExecuteTable("SPOutStanding_Apr5", objp);
        }

        public DataTable OUTSTDCLOSEBALEQUAL(DateTime from, DateTime tdate, int divisionid, int subgroupid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int), 
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;

            return ExecuteTable("SPOUTSTDCLOSEBALEQUAL", objp);
        }

        public DataTable OUTSTDCLOSEBALEQUAL_old(DateTime from, DateTime tdate, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int), 
                                                      new SqlParameter("@subgroupid",SqlDbType.Int)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;

            return ExecuteTable("SPOUTSTDCLOSEBALEQUAL_old", objp);
        }

        public DataTable OUTSTDCLOSEBALEQUALNew(DateTime from, DateTime tdate, int divisionid, int subgroupid, string dbname, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@empid",SqlDbType.Int,4)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = empid;

            return ExecuteTable("SPOUTSTDCLOSEBALEQUALNew", objp);
        }

        public DataTable OUTSTDCLOSEBALEQUALNew_Branchwise(DateTime from, DateTime tdate, int divisionid, int subgroupid, string dbname, int empid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@bid",SqlDbType.Int,4)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = empid;
            objp[6].Value = branchid;

            return ExecuteTable("SPOUTSTDCLOSEBALEQUALNew_Branchwise", objp);
        }

        public DataTable OutStanding_Voucherwise(int lid, int fda, int tda, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;

            return ExecuteTable("SPOutStanding_Voucherwise", objp);
        }

        public DataTable OutStanding_Ledgerwise(DateTime from, DateTime tdate, int divisionid, int subgroupid, string dbname, int empid, int lid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@lid", SqlDbType.Int)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = empid;
            objp[6].Value = lid;

            return ExecuteTable("SPOutStanding_Ledgerwise", objp);
        }

        public DataTable OutStanding_LWBranch(DateTime from, DateTime tdate, int divisionid, int subgroupid, string dbname, int empid, int lid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@lid", SqlDbType.Int),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt, 1)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = empid;
            objp[6].Value = lid;
            objp[7].Value = branchid;

            return ExecuteTable("SPOutStanding_LWBranch", objp);
        }
        public DataTable OutStanding_LWVoucherwise(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int fda, int tda, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};
            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = fda;
            objp[6].Value = tda;
            objp[7].Value = empid;
            objp[8].Value = dbname;

            return ExecuteTable("SPOutStanding_LWVoucherwise", objp);
        }
        public DataTable OutStanding_LWBranchVoucherwise(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int fda, int tda, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = fda;
            objp[6].Value = tda;
            objp[7].Value = empid;
            objp[8].Value = dbname;

            return ExecuteTable("SPOutStanding_LWBranchVoucherwise", objp);
        }
        public DataTable OutStanding_Voucherwiseold(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int fda, int tda, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};
            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = fda;
            objp[6].Value = tda;
            objp[7].Value = empid;
            objp[8].Value = dbname;

            return ExecuteTable("SPOutStanding_Voucherwiseold", objp);
        }

        public DataTable OutStanding_Voucherwise_BW(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int fda, int tda, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = fda;
            objp[6].Value = tda;
            objp[7].Value = empid;
            objp[8].Value = dbname;

            return ExecuteTable("SPOutStanding_Voucherwise_BW", objp);
        }

        public DataTable OUTSTDCLOSEBALEQUALNew_modify(DateTime from, DateTime tdate, int divisionid, int subgroupid, string dbname, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@empid",SqlDbType.Int,4)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = empid;

            return ExecuteTable("SPOUTSTDCLOSEBALEQUALNew_modify", objp);
        }
        public DataSet OUTSTDCLOSEBALEQUALNew_AS(DateTime from, DateTime tdate, int divisionid, int subgroupid, string dbname, int empid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = empid;
            objp[6].Value = salesid;

            return ExecuteDataSet("SPOUTSTDCLOSEBALEQUALNew_AS", objp);
        }




        public DataTable OutStandingNewPandi29May(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int branchid, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = branchid;
            objp[6].Value = empid;
            objp[7].Value = dbname;

            return ExecuteTable("spoutstdnewon29may", objp);
        }



        public DataTable OutStandingNewPandi29MayPreviousYear(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int branchid, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = branchid;
            objp[6].Value = empid;
            objp[7].Value = dbname;

            return ExecuteTable("spoutstdnewon29mayPreviousYear", objp);
        }


        public DataTable OutStandingNewPandi29MayPreviousYearRegion(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int branchid, int empid, string dbname, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar,10)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = branchid;
            objp[6].Value = empid;
            objp[7].Value = dbname;
            objp[8].Value = trantype;

            return ExecuteTable("spoutstdnewon29mayPreviousYearRegion", objp);
        }


        public DataTable OutStandingNewPandi29MayPreviousYearBranch(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int branchid, int empid, string dbname, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                                                      new SqlParameter("@trantype", SqlDbType.VarChar,10)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = branchid;
            objp[6].Value = empid;
            objp[7].Value = dbname;
            objp[8].Value = trantype;

            return ExecuteTable("spoutstdnewon29mayPreviousYearBranch", objp);
        }

        public DataTable OutStandingNewPandi29MayAgewise(int lid, int fda, int tda, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;

            return ExecuteTable("spoutstdnewon29maybyagewise", objp);
        }

        public DataTable OutStandingNewPandi29MayOS(DateTime from, DateTime tdate, int divisionid, int subgroupid, int lid, int branchid, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@from",SqlDbType.DateTime,8),
                                                      new SqlParameter("@to",SqlDbType.DateTime,8),
                                                      new SqlParameter("@divisionid", SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = from;
            objp[1].Value = tdate;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = lid;
            objp[5].Value = branchid;
            objp[6].Value = empid;
            objp[7].Value = dbname;

            return ExecuteTable("spoutstdnewon29mayOS", objp);
        }

        public DataTable OutStandingNewPandi29MayAgewiseOS(int lid, int fda, int tda, int empid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15)};

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;

            return ExecuteTable("spoutstdnewon29maybyagewiseOS", objp);
        }


        public DataTable OutStandingNew(int empid, int divisionid, int subgroupid, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;


            return ExecuteTable("SPSivapriyaOutStd", objp);
            //Dt = ExecuteTable("SPSivapriyaOutStd", objp);
            //double amt = 0;

            //double overdue = 0;
            //for (int i = 0; i <= Dt.Rows.Count; i++)
            //{

            //    amt = amt + double.Parse(Dt.Rows[i]["amount"].ToString());
            //    overdue = overdue + double.Parse(Dt.Rows[i]["overdue"].ToString());
            //}
            //Dr = Dt.NewRow();
            //Dr["customer"] = "Total";
            //Dr["amount"] = amt;
            //Dr["overdue"] = overdue;

            //return Dt;
        }



        public DataTable OutStandingNewTILLDATE(int empid, int divisionid, int subgroupid, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;


            return ExecuteTable("SPSivapriyaOutStdTILLDATE", objp);
            //Dt = ExecuteTable("SPSivapriyaOutStd", objp);
            //double amt = 0;

            //double overdue = 0;
            //for (int i = 0; i <= Dt.Rows.Count; i++)
            //{

            //    amt = amt + double.Parse(Dt.Rows[i]["amount"].ToString());
            //    overdue = overdue + double.Parse(Dt.Rows[i]["overdue"].ToString());
            //}
            //Dr = Dt.NewRow();
            //Dr["customer"] = "Total";
            //Dr["amount"] = amt;
            //Dr["overdue"] = overdue;

            //return Dt;
        }



        public DataTable OutStdageingNew(int empid, int divisionid, int bid, int subgroupid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;

            return ExecuteTable("SPOutstdAgeing", objp);
        }

        public DataTable OutStdageingNewTILLDATE(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;
            return ExecuteTable("SPOutstdAgeingTILLDATEonline", objp); 
            //return ExecuteTable("SPOutstdAgeingTILLDATE", objp);
        }

        public DataTable Outstdagingvounew(int lid, int fda, int tda, int empid, string dbname,int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            return ExecuteTable("SPOutstdagingnew", objp);
        }

        public DataTable OutStdageingNewfcurr(int empid, int divisionid, int bid, int subgroupid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;

            return ExecuteTable("SPOutstdAgeingfcurr", objp);
        }

        public DataTable OutStdageingNewTILLDATEfcurr(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;

            return ExecuteTable("SPOutstdAgeingTILLDATEfcurr", objp);
        }

        public DataTable OutStandingNewBranch(int empid, int divisionid, int subgroupid, DateTime to, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@branchid",SqlDbType.Int),
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = branchid;

            return ExecuteTable("SPSivapriyaOutStdBranch", objp);
        }

        //Outstanding.cs
        public DataTable OutStdageingNewsales(int empid, int divisionid, int bid, int subgroupid, string dbname, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = salesid;


            return ExecuteTable("SPOutstdAgeingSales", objp);
        }
        public DataTable Outstdagingvounewsales(int lid, int fda, int tda, int empid, string dbname, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;



            objp[4].Value = dbname;
            objp[5].Value = bid;
            return ExecuteTable("SPOutstdagingnewsales", objp);
        }


        public DataTable OutStdageingNew(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;

            return ExecuteTable("SPOutstdAgeing", objp);
        }



        public DataTable OutStdingGET(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            return ExecuteTable("SPgetOutstdschedule", objp);
        }



        public DataTable OutStdageingSchedule(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;

            return ExecuteTable("SPOutstdAgeingchedule", objp);
        }


        public DataTable OutstdagingVouSchedule(int lid, int fda, int tda, int empid, string dbname, int bid,int divisionid,int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            objp[7].Value = subgroupid;
            return ExecuteTable("SPOutstdagingSchedule", objp);
        }
        public DataTable OutstdagingvounewsalesSchedule(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            return ExecuteTable("SPOutstdagingnewsalesSchedule", objp);
        }

        public DataTable OutStdageingNewsalesSchedule(int empid, int divisionid, int bid, int subgroupid, string dbname, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = salesid;


            return ExecuteTable("SPOutstdAgeingSalesSchedule", objp);
        }


  //------------------

        public DataTable OutStdingGET12N(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

           return ExecuteTable("SPgetOutstdschedule12N", objp);
           

            
        }



        public DataTable OutStdageingSchedule12N(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;

            return ExecuteTable("SPOutstdAgeingschedule12N", objp);
        }


        public DataTable OutstdagingVouSchedule12N(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            objp[7].Value = subgroupid;
            return ExecuteTable("SPOutstdagingSchedule12N", objp);
        }
        public DataTable OutstdagingvounewsalesSchedule12N(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            return ExecuteTable("SPOutstdagingnewsalesSchedule12N", objp);
        }

        public DataTable OutStdageingNewsalesSchedule12N(int empid, int divisionid, int bid, int subgroupid, string dbname, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = salesid;


            return ExecuteTable("SPOutstdAgeingSalesSchedule12N", objp);
        }

        //-------------
        public DataTable OutStdingGET3PM(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            return ExecuteTable("SPgetOutstdschedule3PM", objp);
        }



        public DataTable OutStdageingSchedule3PM(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;

            return ExecuteTable("SPOutstdAgeingschedule3PM", objp);
        }


        public DataTable OutstdagingVouSchedule3PM(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            objp[7].Value = subgroupid;
            return ExecuteTable("SPOutstdagingSchedule3PM", objp);
        }
        public DataTable OutstdagingvounewsalesSchedule3PM(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            return ExecuteTable("SPOutstdagingnewsalesSchedule3PM", objp);
        }

        public DataTable OutStdageingNewsalesSchedule3PM(int empid, int divisionid, int bid, int subgroupid, string dbname, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = salesid;


            return ExecuteTable("SPOutstdAgeingSalesSchedule3PM", objp);
        }



        ///////////////////Operations

        public DataTable OpsOutStdingGET(int empid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;

            return ExecuteTable("SPOpsOutstdschedule", objp);
        }

        public DataTable OpsOutStdingGET12N(int empid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;

            return ExecuteTable("SPOpsOutstdschedule12N", objp);
        }
        public DataTable OpsOutStdingGET3PM(int empid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;

            return ExecuteTable("SPOpsOutstdschedule3PM", objp);
        }

        //ageing

          public DataTable OpsOSageingSchedule(int empid, int divisionid,int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
               
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            
            objp[2].Value = salesid;


            return ExecuteTable("SPOpsOutstdAgeingSchedule", objp);
        }
        public DataTable OpsOSageingSchedule12N(int empid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
               
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;


            return ExecuteTable("SPOpsOutstdAgeingSchedule12N", objp);
        }
        public DataTable OpsOSageingSchedule3PM(int empid, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
               
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;

            objp[2].Value = salesid;


            return ExecuteTable("SPOpsOutstdAgeingSchedule3PM", objp);
        }


        public DataTable OpsagingVouSchedule(int lid, int fda, int tda, int empid, string dbname, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
           
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = divisionid;
            objp[6].Value = salesid;
            return ExecuteTable("SPOpsOutstdagingSchedule", objp);
        }



        public DataTable OpsagingVouSchedule12N(int lid, int fda, int tda, int empid, string dbname, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
           
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = divisionid;
            objp[6].Value = salesid;
            return ExecuteTable("SPOpsOutstdagingSchedule12N", objp);
        }

        public DataTable OpsagingVouSchedule3PM(int lid, int fda, int tda, int empid, string dbname, int divisionid, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
           
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@salesid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = divisionid;
            objp[6].Value = salesid;
            return ExecuteTable("SPOpsOutstdagingSchedule3PM", objp);
        }

        public DataTable OutstdagingvounewsalesSchedule3PM(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid, int sgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@sgroupid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            objp[7].Value = sgroupid;
            return ExecuteTable("SPOutstdagingnewsalesSchedule3PM", objp);
        }

        public DataTable OutstdagingvounewsalesSchedule12N(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid, int sgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@sgroupid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            objp[7].Value = sgroupid;
            return ExecuteTable("SPOutstdagingnewsalesSchedule12N", objp);
        }


        public DataTable OutstdagingvounewsalesSchedule(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid, int sgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@sgroupid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            objp[7].Value = sgroupid;
            return ExecuteTable("SPOutstdagingnewsalesSchedule", objp);
        }



        public DataTable GetLikesubGroupname4outstd(string sgroupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sgroupname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@dbname",SqlDbType.VarChar,15)};
            objp[0].Value = sgroupname;
            objp[1].Value = dbname;
            return ExecuteTable("SPOutstdsubGroupnamelike", objp);
        }

        //Yuvaraja

        public DataTable OpsOutStdingGETlike(int empid, int divisionid, int salesid, string prefix)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@salesid",SqlDbType.Int),
                new SqlParameter("@prefix",SqlDbType.VarChar,30)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;
            objp[3].Value = prefix;

            return ExecuteTable("SPOpsOutstdscheduleweblike", objp);
        }
        public DataTable OpsOutStdingGET12Nlike(int empid, int divisionid, int salesid, string prefix)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@salesid",SqlDbType.Int),
                 new SqlParameter("@prefix",SqlDbType.VarChar,30)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;
            objp[3].Value = prefix;
            return ExecuteTable("SPOpsOutstdschedule12Nweblike", objp);
        }
        public DataTable OpsOutStdingGET3PMlike(int empid, int divisionid, int salesid, string prefix)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@salesid",SqlDbType.Int),
                new SqlParameter("@prefix",SqlDbType.VarChar,30)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = salesid;
            objp[3].Value = prefix;

            return ExecuteTable("SPOpsOutstdschedule3PMweblike", objp);
        }

        //Arun

        public DataTable GetOutStandingForSalesNew(int salesid, int branchid, int time, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@time",SqlDbType.Int),
                 new SqlParameter("@divisionid ",SqlDbType.Int)
               
                                                  };

            objp[0].Value = salesid;
            objp[1].Value = branchid;
            objp[2].Value = time;
            objp[3].Value = divisionid;

            return ExecuteTable("SPGetSalesOut4New", objp);
        }

        public DataTable GetOutStandingProcessUiNew(int salesid, int time, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                 
                new SqlParameter("@time",SqlDbType.Int),
                 new SqlParameter("@divisionid ",SqlDbType.Int)
               
                                                  };

            objp[0].Value = salesid;

            objp[1].Value = time;
            objp[2].Value = divisionid;

            return ExecuteTable("SPGetSalesOutStaing4New", objp);
        }

        public DataTable GetOutStandingCountProcessUi(int salesid, int time, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  
                new SqlParameter("@time",SqlDbType.Int),
                 new SqlParameter("@divisionid ",SqlDbType.Int)
               
                                                  };

            objp[0].Value = salesid;

            objp[1].Value = time;
            objp[2].Value = divisionid;

            return ExecuteTable("SPGetOutstandingCount", objp);
        }

        public DataTable GetWorkProces(int salesid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  
                
                 new SqlParameter("@branchid ",SqlDbType.Int)
               
                                                  };

            objp[0].Value = salesid;

            objp[1].Value = branchid;


            return ExecuteTable("SPGetWorkingProcesss", objp);
        }

        //public DataTable GetOutStandingCountProcessUi(int salesid, int time, int divisionid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  
        //        new SqlParameter("@time",SqlDbType.Int),
        //         new SqlParameter("@divisionid ",SqlDbType.Int)
               
        //                                          };

        //    objp[0].Value = salesid;

        //    objp[1].Value = time;
        //    objp[2].Value = divisionid;

        //    return ExecuteTable("SPGetOutstandingCount", objp);
        //}

        public DataTable GetWorkProcesNew(int salesid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                  
                
                 new SqlParameter("@branchid ",SqlDbType.Int)
               
                                                  };

            objp[0].Value = salesid;

            objp[1].Value = branchid;


            return ExecuteTable("SPGetWorkingProcesssNew", objp);
        }


        //MUTHU

        public DataTable getcountcreditexamp(int marketedby, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] 
             { 
               new SqlParameter("@marketedby",SqlDbType.Int,4),
               new SqlParameter("@branchid",SqlDbType.Int,4)
            };

            objp[0].Value = marketedby;
            objp[1].Value = branchid;

            return ExecuteTable("sp_overallcreditexam", objp);
        }

        public DataTable getcreditexception(int marketedby, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
                new SqlParameter("@marketedby", SqlDbType.Int),
                new SqlParameter("@customerid", SqlDbType.Int)                                         
            };
            objp[0].Value = marketedby;
            objp[1].Value = customerid;
            return ExecuteTable("sp_creditexception", objp);

        }

        public DataTable getgrpcreditexception(int marketedby)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
                new SqlParameter("@marketedby", SqlDbType.Int),                                         
            };

            objp[0].Value = marketedby;

            return ExecuteTable("sp_grpcreditexception", objp);

        }
        //muthu

        public DataTable getbookinghome(string trantype, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
                new SqlParameter("@trantype", SqlDbType.VarChar,3),  
                new SqlParameter("@bid", SqlDbType.Int),  
                new SqlParameter("@cid", SqlDbType.Int)            
            };

            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = cid;

            return ExecuteTable("sp_bookingcshome", objp);

        }
        public DataTable getbookinghomecount(string trantype, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
                new SqlParameter("@trantype", SqlDbType.VarChar,3),  
                new SqlParameter("@bid", SqlDbType.Int),  
                new SqlParameter("@cid", SqlDbType.Int)            
            };

            objp[0].Value = trantype;
            objp[1].Value = bid;
            objp[2].Value = cid;

            return ExecuteTable("sp_bookcounting", objp);

        }


        //MUTHURAJ

        public DataTable getOverduecorporatebaroverdue(int empid, int branchid, int divisionid, int subgroupid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
            {
                new SqlParameter("@empid", SqlDbType.Int),     
                new SqlParameter("@branchid", SqlDbType.Int) ,
                new SqlParameter("@divisionid", SqlDbType.Int),
                new SqlParameter("@subgroupid", SqlDbType.Int),  
                new SqlParameter("@trantype", SqlDbType.VarChar),   
               
            };


            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = divisionid;
            objp[3].Value = subgroupid;
            objp[4].Value = trantype;


            return ExecuteTable("SP_CorpOverdue4HomeCountbaroverdue", objp);
        }


        public DataTable OutStdingGET2013(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            return ExecuteTable("SPgetOutstdschedule2013", objp);
        }


        public DataTable OutStdageingSchedule2013(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                 new SqlParameter("@ledgerid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;
            objp[6].Value = ledgerid;

            return ExecuteTable("SPOutstdAgeingschedule2013", objp);
        }

        public DataTable OutStdageingNewsalesSchedule2013(int empid, int divisionid, int bid, int subgroupid, string dbname, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                  new SqlParameter("@salesid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = salesid;


            return ExecuteTable("SPOutstdAgeingSalesSchedule2013", objp);
        }

        public DataTable Unclearedcheque(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@divisionid", SqlDbType.Int), 
                                                  new SqlParameter("@branchid",SqlDbType.Int)              
                                                  };

            objp[0].Value = branchid;
            objp[1].Value = divisionid;

            return ExecuteTable("Sp_Unclearedcheque", objp);
        }

        //------------Muthuraj

        public DataTable deleteTempOutstandingOnline(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid",SqlDbType.Int,4)


            };

            objp[0].Value = empid;

            return ExecuteTable("SPDELTempOutstandingOnline", objp);
        }


        public DataTable getTempOutstandingOnline(string Branch, string Product, string VouType, int Vou, string vdate, string BL, string Salesperson, string Ledger, Double Amount, int NoofDays, Double AppAmt, int AppDay, Double OverDue, int overduedays, string shipper, string POR, string POL, string POD, string Shipment, Double Volume, int empid, int branchid, int divisionid, string vendorrefno)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@Branch", SqlDbType.VarChar,50),
                                                      new SqlParameter("@Product",SqlDbType.VarChar,50),
                                                      new SqlParameter("@VouType",SqlDbType.VarChar,50),
                                                      new SqlParameter("@Vou",SqlDbType.Int,4),
                                                      new SqlParameter("@vdate", SqlDbType.VarChar,20),
                                                      new SqlParameter("@BL", SqlDbType.VarChar,50),
                                                      new SqlParameter("@Salesperson",SqlDbType.VarChar,200),
                                                      new SqlParameter("@Ledger",SqlDbType.VarChar,500),
                                                      new SqlParameter("@Amount", SqlDbType.Money),
                                                      new SqlParameter("@NoofDays", SqlDbType.Int),
                                                      new SqlParameter("@AppAmt",SqlDbType.Money),
                                                      new SqlParameter("@AppDay",SqlDbType.Int),
                                                      new SqlParameter("@OverDue",SqlDbType.Money),
                                                      new SqlParameter("@overduedays",SqlDbType.Int),
                                                        new SqlParameter("@shipper", SqlDbType.VarChar,50),
                                                        new SqlParameter("@POR", SqlDbType.VarChar,50),
                                                        new SqlParameter("@POL", SqlDbType.VarChar,50),
                                                        new SqlParameter("@POD", SqlDbType.VarChar,50),
                                                        new SqlParameter("@Shipment", SqlDbType.VarChar,30),
                                                        new SqlParameter("@Volume", SqlDbType.Money,50),
                                                        new SqlParameter("@empid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@divisionid",SqlDbType.Int),
                                                         new SqlParameter("@vendorrefno",SqlDbType.VarChar,50)
            };

            objp[0].Value = Branch;
            objp[1].Value = Product;
            objp[2].Value = VouType;
            objp[3].Value = Vou;
            objp[4].Value = vdate;
            objp[5].Value = BL;
            objp[6].Value = Salesperson;
            objp[7].Value = Ledger;
            objp[8].Value = Amount;
            objp[9].Value = NoofDays;
            objp[10].Value = AppAmt;
            objp[11].Value = AppDay;
            objp[12].Value = OverDue;
            objp[13].Value = overduedays;
            objp[14].Value = shipper;
            objp[15].Value = POR;
            objp[16].Value = POL;
            objp[17].Value = POD;
            objp[18].Value = Shipment;
            objp[19].Value = Volume;
            objp[20].Value = empid;
            objp[21].Value = branchid;
            objp[22].Value = divisionid;
            objp[23].Value = vendorrefno;

            return ExecuteTable("SP_TempOutstandingOnline", objp);
        }

        public DataTable deleteTempOutstandingOnlineledger(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid",SqlDbType.Int,4)
            };

            objp[0].Value = empid;

            return ExecuteTable("SPDELTempOutstandingOnlineledger", objp);
        }

        public DataTable getTempOutstandingledger(string Customer, Double a15, Double a1630, Double a3145, Double a4660, Double a6190, Double a91180, Double a181365, Double a365, Double totalos, Double ledgerblance, string Address, string Phone, string Email, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@Customer", SqlDbType.VarChar,50), 
                                                      new SqlParameter("@a15",SqlDbType.Money),
                                                      new SqlParameter("@a1630",SqlDbType.Money),
                                                      new SqlParameter("@a3145",SqlDbType.Money),
                                                      new SqlParameter("@a4660",SqlDbType.Money),
                                                      new SqlParameter("@a6190",SqlDbType.Money),
                                                      new SqlParameter("@a91180",SqlDbType.Money),
                                                      new SqlParameter("@a181365",SqlDbType.Money),
                                                      new SqlParameter("@a365",SqlDbType.Money),
                                                        new SqlParameter("@totalos",SqlDbType.Money),
                                                        new SqlParameter("@ledgerbalance", SqlDbType.Money),
                                                        new SqlParameter("@Address", SqlDbType.VarChar,50),
                                                        new SqlParameter("@Phone",SqlDbType.VarChar,50),
                                                        new SqlParameter("@Email", SqlDbType.VarChar,50),
                                                        new SqlParameter("@empid",SqlDbType.Int)
                                                   
                                                        
            };

            objp[0].Value = Customer;
            objp[1].Value = a15;
            objp[2].Value = a1630;
            objp[3].Value = a3145;
            objp[4].Value = a4660;
            objp[5].Value = a6190;
            objp[6].Value = a91180;
            objp[7].Value = a181365;
            objp[8].Value = a365;
            objp[9].Value = totalos;
            objp[10].Value = ledgerblance;
            objp[11].Value = Address;
            objp[12].Value = Phone;
            objp[13].Value = Email;
            objp[14].Value = empid;



            return ExecuteTable("SpinsRptOutustdageing", objp);
        }



        public DataTable getTempOutstandingledger_New(string Customer, Double a15, Double a1630, Double a3145, Double a4660, Double a6190, Double a91120, Double a121180,
           Double a181365, Double a365, Double totalos, Double ledgerblance, string Address, string Phone, string Email, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@Customer", SqlDbType.VarChar,50),
                                                      new SqlParameter("@a15",SqlDbType.Money),
                                                      new SqlParameter("@a1630",SqlDbType.Money),
                                                      new SqlParameter("@a3145",SqlDbType.Money),
                                                      new SqlParameter("@a4660",SqlDbType.Money),
                                                      new SqlParameter("@a6190",SqlDbType.Money),
                                                      new SqlParameter("@a91120",SqlDbType.Money),
                                                      new SqlParameter("@a121180",SqlDbType.Money),
                                                      new SqlParameter("@a181365",SqlDbType.Money),
                                                      new SqlParameter("@a365",SqlDbType.Money),
                                                        new SqlParameter("@totalos",SqlDbType.Money),
                                                        new SqlParameter("@ledgerbalance", SqlDbType.Money),
                                                        new SqlParameter("@Address", SqlDbType.VarChar,50),
                                                        new SqlParameter("@Phone",SqlDbType.VarChar,50),
                                                        new SqlParameter("@Email", SqlDbType.VarChar,50),
                                                        new SqlParameter("@empid",SqlDbType.Int)

            };

            objp[0].Value = Customer;
            objp[1].Value = a15;
            objp[2].Value = a1630;
            objp[3].Value = a3145;
            objp[4].Value = a4660;
            objp[5].Value = a6190;
            objp[6].Value = a91120;
            objp[7].Value = a121180;
            objp[8].Value = a181365;
            objp[9].Value = a365;
            objp[10].Value = totalos;
            objp[11].Value = ledgerblance;
            objp[12].Value = Address;
            objp[13].Value = Phone;
            objp[14].Value = Email;
            objp[15].Value = empid;

            return ExecuteTable("SpinsRptOutustdageing_New", objp);
        }




        public DataTable deleteTempOutstandingOnlineledger_New(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@empid",SqlDbType.Int,4)

            };

            objp[0].Value = empid;

            return ExecuteTable("SPDELTempOutstandingOnlineledger_New", objp);
        }


        public DataTable OutstdagingVouSchedule2013(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int,4)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            objp[7].Value = subgroupid;
            return ExecuteTable("SPOutstdagingSchedule2013", objp);
        }

        public DataTable OutstdagingvounewsalesSchedule2013(int lid, int fda, int tda, int empid, string dbname, int bid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int),
                new SqlParameter("@divisionid",SqlDbType.Int)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            objp[6].Value = divisionid;
            return ExecuteTable("SPOutstdagingnewsalesSchedule2013", objp);
        }





        public DataTable Get_GSTvoucher4xl4charges(int branchid, DateTime fromdate, DateTime todate, string vouchertype, int charge) //string type,
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@todate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@vouchertype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@chargeid", SqlDbType.Int,4)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = vouchertype;
            objp[4].Value = charge;
            return ExecuteTable("SP_getGSTvoucher4xl4charge", objp);
        }


        //Raj

        public DataTable Get_GSTvoucher4xlGSTReport(int branchid, DateTime fromdate, DateTime todate, string vouchertype, string charge) //string type,
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@todate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@vouchertype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@charge",SqlDbType.VarChar,20)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = vouchertype;
            objp[4].Value = charge;
            if (charge == "Charge")
            {
                return ExecuteTable("SP_getGSTvoucher4xl", objp);
            }
            else //if (vouchertype == "B2B" || vouchertype == "B2CL" || vouchertype == "B2CS" || vouchertype == "CDNR" || vouchertype == "CDNUR" || vouchertype == "EXP" || vouchertype == "Exemption" || vouchertype == "SAC")
            {
                // return ExecuteTable("SP_getGSTvoucher4xlGSTReport", objp);

                return ExecuteTable("SP_getGSTvoucher4xlGSTReportNEW", objp);
            }
        }

        public DataTable OutStdageingSchedule(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                 new SqlParameter("@ledgerid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;
            objp[6].Value = ledgerid;
            return ExecuteTable("SPOutstdAgeingchedule", objp);
        }


        public DataTable OutStdageingSchedule12N(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                 new SqlParameter("@ledgerid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;
            objp[6].Value = ledgerid;

            return ExecuteTable("SPOutstdAgeingschedule12N", objp);
        }

        public DataTable OutStdageingSchedule3PM(int empid, int divisionid, int bid, int subgroupid, DateTime to, string dbname, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@to",SqlDbType.SmallDateTime),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
               new SqlParameter("@ledgerid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = to;
            objp[5].Value = dbname;
            objp[6].Value = ledgerid;

            return ExecuteTable("SPOutstdAgeingschedule3PM", objp);
        }


        public DataTable Get_GSTvoucher4xl(int branchid, DateTime fromdate, DateTime todate, string vouchertype, string charge) //string type,
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@todate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@vouchertype",SqlDbType.VarChar,10)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = vouchertype;
            if (charge == "Charge")
            {
             // return ExecuteTable("SP_getGSTvoucher4xl", objp);
                

              // return ExecuteTable("SP_getGSTvoucher4xlnewbl", objp);

                return ExecuteTable("SP_getGSTvoucher4xlnewblnewly", objp);

                
            }
            else
            {
                //return ExecuteTable("SP_getGSTvoucher4xlReg", objp);
                //return ExecuteTable("SP_getGSTvoucher4xlRegnewBL", objp);

                return ExecuteTable("SP_getGSTvoucher4xlRegnewBLnew", objp);
            }
        }

        public DataTable GetOutStandingProcessUiHomepage(int salesid, int time, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@salesid", SqlDbType.Int), 
                                                 
                new SqlParameter("@time",SqlDbType.Int),
                 new SqlParameter("@divisionid ",SqlDbType.Int)
               
                                                  };

            objp[0].Value = salesid;

            objp[1].Value = time;
            objp[2].Value = divisionid;

            return ExecuteTable("SPGetSalesOutStaing4Newtst", objp);
        }


        //Ruban

        public DataTable OutStandingNewonlineformat(int empid, int divisionid, int subgroupid, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;


            return ExecuteTable("SPSivapriyaOutStdcurr", objp);
            //Dt = ExecuteTable("SPSivapriyaOutStd", objp);
            //double amt = 0;

            //double overdue = 0;
            //for (int i = 0; i <= Dt.Rows.Count; i++)
            //{

            //    amt = amt + double.Parse(Dt.Rows[i]["amount"].ToString());
            //    overdue = overdue + double.Parse(Dt.Rows[i]["overdue"].ToString());
            //}
            //Dr = Dt.NewRow();
            //Dr["customer"] = "Total";
            //Dr["amount"] = amt;
            //Dr["overdue"] = overdue;

            //return Dt;
        }

        public DataTable OutStdageingNewOnlineFormat(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            return ExecuteTable("SPOutstdAgeingcurr", objp);
        }
        //public DataTable OutStandingCheckUSD(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid, string tillnow = "")
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
        //                                              new SqlParameter("@divisionid",SqlDbType.Int),
        //                                              new SqlParameter("@subgroupid",SqlDbType.Int),
        //                                              new SqlParameter("@to",SqlDbType.DateTime),
        //                                              new SqlParameter("@ledgerid", SqlDbType.Int),
        //                                              new SqlParameter("@tillnow", SqlDbType.VarChar,1)
        //                                          };

        //    objp[0].Value = empid;
        //    objp[1].Value = divisionid;
        //    objp[2].Value = subgroupid;
        //    objp[3].Value = to;
        //    objp[4].Value = ledgerid;
        //    objp[5].Value = tillnow;
        //    return ExecuteTable("spopbaloutstdnewusd", objp);

        //}
        public DataTable OutStandingCheck(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid, string tillnow = "")
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int),
                                                      new SqlParameter("@tillnow", SqlDbType.VarChar,1)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;
            objp[5].Value = tillnow;
            return ExecuteTable("spopbaloutstdnew", objp);

        } 

        //Rajkumar

        public DataTable OutStandingCheckUSD(int empid, int divisionid, int subgroupid, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            if (subgroupid == 65 || subgroupid == 59 || subgroupid==44)
            {
                return ExecuteTable("spopbaloutstdnewusdaaaa", objp);
            }else
            {
                return ExecuteTable("spopbaloutstdnewaaaa", objp);
            }
            

        }

        public DataTable Getoutstd_breakuopdetails(int empid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@ledgerid",SqlDbType.Int)
                                                      };
            objp[0].Value = empid;
            objp[1].Value = ledgerid;
            return ExecuteTable("Sp_getoutstdbreakup", objp);
        }

        //public DataTable OutStandingNewLedger(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
        //                                              new SqlParameter("@divisionid",SqlDbType.Int),
        //                                              new SqlParameter("@subgroupid",SqlDbType.Int),
        //                                              new SqlParameter("@to",SqlDbType.DateTime),
        //                                              new SqlParameter("@ledgerid", SqlDbType.Int)
        //                                          };

        //    objp[0].Value = empid;
        //    objp[1].Value = divisionid;
        //    objp[2].Value = subgroupid;
        //    objp[3].Value = to;
        //    objp[4].Value = ledgerid;


        //    return ExecuteTable("SPSivapriyaOutStdtocheck", objp);

        //} 

        //Rajkumar
        public DataTable OutStdageingNewOnlineFormatnew(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            return ExecuteTable("SPOutstdAgeingcurrrajOS", objp);
        }

        //Ruban Outstanding Ledgerwise for Local Vouchers
        public DataTable OutStandingNewLedger(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
               return ExecuteTable("SPoutstandingonlineUSDrajosv", objp);
                //return ExecuteTable("SPoutstandingonlineUSDnew", objp);
            }
            else
            {
               return ExecuteTable("SPOutstandingOnlinerajlocalvouchers", objp);
               //return ExecuteTable("SPOutstandingOnlinenew", objp);
            }

        }


       
        public DataTable OutStandingNewLedgerTillDate(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDtilldaterajosvouchers", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinetilldaterajlv", objp);
            }

        }

        //Ruban Outstanding Ledgerwise for Local Vouchers for Zero Balance or not
        public DataTable OutStandingNewLedger(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid,int zero)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int),
                                                      new SqlParameter("@zerobalance", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to; 
            objp[4].Value = ledgerid;
            objp[5].Value = zero;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
               return ExecuteTable("SPoutstandingonlineUSDrajosv", objp);
              //  return ExecuteTable("SPoutstandingonlineUSDnew", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinerajlocalvouchers", objp);
               // return ExecuteTable("SPOutstandingOnlinenew", objp);
            }

        }

        public DataTable OutStandingNewLedgerTillDate(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid, int zero)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int),
                                                      new SqlParameter("@zerobalance", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;
            objp[5].Value = zero;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDtilldaterajosvouchers", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinetilldaterajlv", objp);
            }

        }

        //Rajkumar
        public DataTable OutStdageingNewOnlineFormatnew(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid,int zero)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15),
                new SqlParameter("@zerobalance",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = zero;
            return ExecuteTable("SPOutstdAgeingcurrrajOS", objp);
        }

        ////Ruban For Ledgeragin
        //public DataTable OutStdageingNewOnlineFormatnewfordate(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid, int zero,DateTime dte)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
        //                                          new SqlParameter("@divisionid",SqlDbType.Int),
        //        new SqlParameter("@branchid",SqlDbType.Int),
        //        new SqlParameter("@subgroupid",SqlDbType.Int),
        //        new SqlParameter("@dbname",SqlDbType.VarChar,15),
        //        new SqlParameter("@customerid",SqlDbType.VarChar,15),
        //        new SqlParameter("@zerobalance",SqlDbType.Int),
        //                                              new SqlParameter("@to",SqlDbType.DateTime)
        //                                          };

        //    objp[0].Value = empid;
        //    objp[1].Value = divisionid;
        //    objp[2].Value = bid;
        //    objp[3].Value = subgroupid;
        //    objp[4].Value = dbname;
        //    objp[5].Value = customerid;
        //    objp[6].Value = zero;
        //    objp[7].Value = dte;
        //    return ExecuteTable("SPOutstdAgeingcurrrajOS", objp);
        //}



        public DataTable getOutstdschedule12NFACor(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            //  return ExecuteTable("SPgetOutstdschedule12N", objp);
            return ExecuteTable("SPgetOutstdschedule12NFACor", objp);


        }


        public DataTable OutStdingGETFACor(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            return ExecuteTable("SPgetOutstdscheduleFACor", objp);
        }


        public DataTable OutStdingGET3PMFACor(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            return ExecuteTable("SPgetOutstdschedule3PMFACor", objp);
        }


        public DataTable OutStdingGETtildateCorhome(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            return ExecuteTable("SPgetOutstdscheduletildateCorhome", objp);
        }


        public DataSet Get_GSTvoucher4xlGSTReportFormatnew(int branchid, DateTime fromdate, DateTime todate, string vouchertype, string charge) //string type,
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@todate",SqlDbType.SmallDateTime),
                                                     new SqlParameter("@vouchertype",SqlDbType.VarChar,10),
                                                     new SqlParameter("@charge",SqlDbType.VarChar,20)
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = vouchertype;
            objp[4].Value = charge;
            if (charge == "Charge")
            {
                return ExecuteDataSet("SP_getGSTvoucher4xl", objp);
            }
            else //if (vouchertype == "B2B" || vouchertype == "B2CL" || vouchertype == "B2CS" || vouchertype == "CDNR" || vouchertype == "CDNUR" || vouchertype == "EXP" || vouchertype == "Exemption" || vouchertype == "SAC")
            {
                return ExecuteDataSet("SP_getGSTvoucher4xlGSTReportFormat", objp);
            }
        }
        //Ruban For Ledgeragin
        public DataTable OutStdageingNewOnlineFormatnewfordate(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid, int zero, DateTime dte)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15),
                new SqlParameter("@zerobalance",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = zero;
            objp[7].Value = dte;
            if (subgroupid == 0)
            {
                return ExecuteTable("SPOutstdAgeingcurrrajOSAll", objp);
            }
            else
            {
                return ExecuteTable("SPOutstdAgeingcurrrajOS", objp);
            }

        }



        public DataTable OutStandingNewLedgerall(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDrajosv", objp);
            }
            else if (subgroupid == 0)
            {
                return ExecuteTable("SPOutstandingOnlineALLnew", objp);    //SPOutstandingOnlineall
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinerajlocalvouchers", objp);
            }

        }



        //GetSubgroupName Ruban
        public string GetSubgroupName(int ledgerid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@ledgerid",SqlDbType.Int),
                                                        new SqlParameter("@dbname", SqlDbType.VarChar,15)
                                                    };
            objp[0].Value = ledgerid;
            objp[1].Value = dbname;

            return ExecuteReader("GetSubgroupName", objp);
        }
        public int SpGroupid(string groupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@groupname",SqlDbType.VarChar,200),
                                                        new SqlParameter("@dbname", SqlDbType.VarChar,30)
                                                    };
            objp[0].Value = groupname;
            objp[1].Value = dbname;

            return int.Parse(ExecuteReader("SpGroupid", objp));
        }
        public int SPSubgroupid(string subgroupname, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@subgroupname",SqlDbType.VarChar,200),
                                                        new SqlParameter("@dbname", SqlDbType.VarChar,30)
                                                    };
            objp[0].Value = subgroupname;
            objp[1].Value = dbname;
            return int.Parse(ExecuteReader("SPSubgroupid", objp));
        }

        public DataTable SpSubGroupname(int groupid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@groupid",SqlDbType.Int,2),
                                                        new SqlParameter("@dbname", SqlDbType.VarChar,30)
                                                    };
            objp[0].Value = groupid;
            objp[1].Value = dbname;

            return ExecuteTable("SpSubGroupname", objp);
        }
        public DataTable OutStandingNewLedgerall(int empid, int divisionid, string subgroupid, DateTime to, int ledgerid, int groupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.VarChar,200),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int),
                                                      new SqlParameter("@groupid",SqlDbType.Int)
                                                       //new SqlParameter("@count",SqlDbType.VarChar,20)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;
            objp[5].Value = groupid;
            //objp[6].Value = count;
            //return ExecuteTable("Spoutstandingonlineall", objp);
            return ExecuteTable("SPOutstandingOnlineALLnew", objp);
          //  return ExecuteTable("SPOutstandingOnlineALLnewcount", objp);

        }
        public DataTable OutStdageingNewOnlineFormatnewfordate(int empid, int divisionid, int bid, string subgroupid, string dbname, int customerid, int zero, DateTime dte, int groupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.VarChar,100),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15),
                new SqlParameter("@zerobalance",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                new SqlParameter("@groupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = zero;
            objp[7].Value = dte;
            objp[8].Value = groupid;

            return ExecuteTable("SPOutstdAgeingcurrrajOSAllTestProcess", objp);

            //return ExecuteTable("SPOutstdAgeingcurrrajOS", objp);


        }
        public DataTable SPGetCustomerCredit(int customerid, string dbname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter ("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@dbname", SqlDbType.VarChar,30)
                                                    };
            objp[0].Value = customerid;
            objp[1].Value = dbname;
            return ExecuteTable("SPGetCustomerCredit", objp);
        }

        public DataTable SpoutstandingonlineCreditCustomerwise(int empid, int divisionid, string subgroupid, DateTime to, string ledgerid, string groupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.VarChar,200),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.VarChar,100),
                                                      new SqlParameter("@groupid",SqlDbType.VarChar,100)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;
            objp[5].Value = groupid;

            return ExecuteTable("SpoutstandingonlineCreditCustomerwise", objp);

        }

        //Ruban For Ledgeragin
        public DataTable SPOutstdAgeingcurrrajOSCustomerwise(int empid, int divisionid, int bid, string subgroupid, string dbname, string customerid, int zero, DateTime dte)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.VarChar,100),
                new SqlParameter("@dbname",SqlDbType.VarChar,50),
                new SqlParameter("@customerid",SqlDbType.VarChar,100),
                new SqlParameter("@zerobalance",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = zero;
            objp[7].Value = dte;

            return ExecuteTable("SPOutstdAgeingcurrrajOSCustomerwise", objp);


        }

        public DataTable OutStdageingNew(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid,string fcurr)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int), 
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15),
             
                new SqlParameter("@fcurr",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = fcurr;
            return ExecuteTable("SPOutstdAgeing", objp);
        }



        //public string OutStandingNewLedgeralltotrowcount(int empid, int divisionid, string subgroupid, DateTime to, int ledgerid, int groupid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
        //                                              new SqlParameter("@divisionid",SqlDbType.Int),
        //                                              new SqlParameter("@subgroupid",SqlDbType.VarChar,200),
        //                                              new SqlParameter("@to",SqlDbType.DateTime),
        //                                              new SqlParameter("@ledgerid", SqlDbType.Int),
        //                                              new SqlParameter("@groupid",SqlDbType.Int)
                                                      
        //                                          };

        //    objp[0].Value = empid;
        //    objp[1].Value = divisionid;
        //    objp[2].Value = subgroupid;
        //    objp[3].Value = to;
        //    objp[4].Value = ledgerid;
        //    objp[5].Value = groupid;

        //    return ExecuteReader("SPOutstandingOnlineALLnewtotalcount", objp);

        //}

        public DataTable OutStdageingNewOnlineFormatnewfordate_newslab(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid, int zero, DateTime dte, double slab1, double slab2, double slab3, double slab4, double slab5)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15),
                new SqlParameter("@zerobalance",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                        new SqlParameter("@slab1", SqlDbType.Money,50),
                                                        new SqlParameter("@slab2", SqlDbType.Money,50),
                                                        new SqlParameter("@slab3", SqlDbType.Money,50),
                                                        new SqlParameter("@slab4", SqlDbType.Money,50),
                                                         new SqlParameter("@slab5", SqlDbType.Money,50),

                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = zero;
            objp[7].Value = dte;
            objp[8].Value = slab1;
            objp[9].Value = slab2;
            objp[10].Value = slab3;
            objp[11].Value = slab4;
            objp[12].Value = slab5;
            if (subgroupid == 0)
            {
                return ExecuteTable("SPOutstdAgeingcurrrajOSAll", objp);
            }
            else
            {
                return ExecuteTable("SPOutstdAgeingcurrrajOS_newslab", objp);
            }

        }


        public DataTable OutStdageingNew_new(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid, string fcurr)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                  new SqlParameter("@divisionid",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int),
                new SqlParameter("@subgroupid",SqlDbType.Int),
                new SqlParameter("@dbname",SqlDbType.VarChar,15),
                new SqlParameter("@customerid",SqlDbType.VarChar,15),
             
                new SqlParameter("@fcurr",SqlDbType.VarChar,15)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = fcurr;
            return ExecuteTable("SPOutstdAgeing_new", objp);
        }

        public DataTable OutStdageingNew_newfortilldate(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid, string fcurr, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@empid", SqlDbType.Int),
                                                        new SqlParameter("@divisionid",SqlDbType.Int),
                                                        new SqlParameter("@branchid",SqlDbType.Int),
                                                        new SqlParameter("@subgroupid",SqlDbType.Int),
                                                        new SqlParameter("@dbname",SqlDbType.VarChar,15),
                                                        new SqlParameter("@customerid",SqlDbType.VarChar,15),             
                                                        new SqlParameter("@fcurr",SqlDbType.VarChar,15),
                                                        new SqlParameter("@to",SqlDbType.SmallDateTime)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = fcurr;
            objp[7].Value = to;

            return ExecuteTable("SPOutstdAgeing_new", objp);
        }

        ///// 01-07-2022

        public DataTable Outstdagingvounewusd(int lid, int fda, int tda, int empid, string dbname, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@lid", SqlDbType.Int), 
                                                      new SqlParameter("@fda",SqlDbType.Int),
                                                      new SqlParameter("@tda",SqlDbType.Int),
                                                      new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@dbname", SqlDbType.VarChar,15),
                new SqlParameter("@bid", SqlDbType.Int)
            };

            objp[0].Value = lid;
            objp[1].Value = fda;
            objp[2].Value = tda;
            objp[3].Value = empid;
            objp[4].Value = dbname;
            objp[5].Value = bid;
            return ExecuteTable("SPOutstdagingnewusd", objp);
        }

        public DataTable Getoutstd_breakuopdetailsusd(int empid, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@ledgerid",SqlDbType.Int)
                                                      };
            objp[0].Value = empid;
            objp[1].Value = ledgerid;
            return ExecuteTable("Sp_getoutstdbreakupusd", objp);
        }


        ///////////////////////////////




        public DataTable OutStandingNewLedgerlv(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDrajosv", objp);
                //return ExecuteTable("SPoutstandingonlineUSDnew", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinerajlocalvouchers", objp);
                //return ExecuteTable("SPOutstandingOnlinenew", objp);
            }

        }



        public DataTable OutStandingNewLedgerTillDatelv(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDtilldaterajosvouchers", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinetilldaterajlv", objp);
            }

        }

        //Ruban Outstanding Ledgerwise for Local Vouchers for Zero Balance or not
        public DataTable OutStandingNewLedgerlv(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid, int zero)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int),
                                                      new SqlParameter("@zerobalance", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;
            objp[5].Value = zero;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDrajosv", objp);
                //  return ExecuteTable("SPoutstandingonlineUSDnew", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinerajlocalvouchers", objp);
                // return ExecuteTable("SPOutstandingOnlinenew", objp);
            }

        }

        public DataTable OutStandingNewLedgerTillDatelv(int empid, int divisionid, int subgroupid, DateTime to, int ledgerid, int zero)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime),
                                                      new SqlParameter("@ledgerid", SqlDbType.Int),
                                                      new SqlParameter("@zerobalance", SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;
            objp[4].Value = ledgerid;
            objp[5].Value = zero;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDtilldaterajosvouchers", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinetilldaterajlv", objp);
            }

        }

        //////////////////////////////////
        public DataSet OutStandingNewLedgerNew(int empid, int divisionid, int subgroupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteDataSet("SPoutstandingonlineUSDrajosv", objp);
            }
            else
            {
                return ExecuteDataSet("SPOutstandingOnlinerajlocalvouchers4Cal", objp);
            }

        }


        public DataTable OutStandingNewLedgerTillDateNew(int empid, int divisionid, int subgroupid, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                                      new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@subgroupid",SqlDbType.Int),
                                                      new SqlParameter("@to",SqlDbType.DateTime)
                                                  };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = subgroupid;
            objp[3].Value = to;

            if (subgroupid == 65 || subgroupid == 59 || subgroupid == 44)
            {
                return ExecuteTable("SPoutstandingonlineUSDtilldaterajosvouchers", objp);
            }
            else
            {
                return ExecuteTable("SPOutstandingOnlinetilldaterajlvnew", objp);
            }

        }

        // Outstanding Home [26-11-2023]
        public DataSet GetCalenderDetails4Home()
        {
            return ExecuteDataSet("SPGetCalenderDetails4Home");
        }
        public DataSet GetCalenderDetails4Home(int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouyear", SqlDbType.Int) };

            objp[0].Value = vouyear;

            return ExecuteDataSet("SPGetCalenderDetails4Home");
        }

        public DataTable GetCalenderDetails4PopupGrid(DateTime todate, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                 new SqlParameter("@todate", SqlDbType.SmallDateTime),
                                                 new SqlParameter("@vouyear",SqlDbType.Int)
                                           };

            objp[0].Value = todate;
            objp[1].Value = vouyear;

            return ExecuteTable("SPGetCalenderDetails4PopupGrid", objp);
        }
        public DataSet GetCalenderDetails4HomeNew(int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouyear", SqlDbType.Int) };

            objp[0].Value = vouyear;

            return ExecuteDataSet("SPGetCalenderDetails4HomeNew");
        }

        public DataTable GetCalenderDetails4PopupGridNew(DateTime todate, int vouyear, string title)
        {
            SqlParameter[] objp = new SqlParameter[] {
new SqlParameter("@todate", SqlDbType.SmallDateTime),
new SqlParameter("@vouyear",SqlDbType.Int),
new SqlParameter("@title",SqlDbType.VarChar,30)
};

            objp[0].Value = todate;
            objp[1].Value = vouyear;
            objp[2].Value = title;

            return ExecuteTable("SPGetCalenderDetails4PopupGridNew", objp);
        }

        public DataTable Get_GSTvoucher4xlGSTReportNew(int branchid, DateTime fromdate, DateTime todate, string vouchertype, string charge) //string type,
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int,4),
                                                 new SqlParameter("@fromdate",SqlDbType.SmallDateTime),
                                               new SqlParameter("@todate",SqlDbType.SmallDateTime),
                                               new SqlParameter("@vouchertype",SqlDbType.VarChar,10),
                                               new SqlParameter("@charge",SqlDbType.VarChar,20)
                                               };
            objp[0].Value = branchid;
            objp[1].Value = fromdate;
            objp[2].Value = todate;
            objp[3].Value = vouchertype;

            objp[4].Value = charge;

            //return ExecuteDataSet("SP_getGSTvoucher4xlGSTReportFormat", objp);
            return ExecuteTable("SP_getGSTvoucher4xlGSTReportFormatNew", objp);

        }

        public DataTable OutStdageingNewOnlineFormatnewfordate_USD(int empid, int divisionid, int bid, int subgroupid, string dbname, int customerid, int zero, DateTime dte)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empid", SqlDbType.Int),
                                           new SqlParameter("@divisionid",SqlDbType.Int),
         new SqlParameter("@branchid",SqlDbType.Int),
         new SqlParameter("@subgroupid",SqlDbType.Int),
         new SqlParameter("@dbname",SqlDbType.VarChar,15),
         new SqlParameter("@customerid",SqlDbType.VarChar,15),
         new SqlParameter("@zerobalance",SqlDbType.Int),
                                               new SqlParameter("@to",SqlDbType.DateTime)
                                           };

            objp[0].Value = empid;
            objp[1].Value = divisionid;
            objp[2].Value = bid;
            objp[3].Value = subgroupid;
            objp[4].Value = dbname;
            objp[5].Value = customerid;
            objp[6].Value = zero;
            objp[7].Value = dte;
            if (subgroupid == 0)
            {
                return ExecuteTable("SPOutstdAgeingcurrrajOSAll", objp);
            }
            else
            {
                return ExecuteTable("SPOutstdAgeingcurrrajOSUSD", objp);
            }

        }

    }

}

