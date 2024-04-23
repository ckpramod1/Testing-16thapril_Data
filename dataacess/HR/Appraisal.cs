using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.HR
{
    public class Appraisal : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Appraisal()
        {
            Conn = new SqlConnection(DBCS);
        }


        public void InsHRPersonalKPI(int empid, int qid, double selfrating, string selfremarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@qid", SqlDbType.Int, 4),
                                                       new SqlParameter("@selfrating", SqlDbType.Money, 8),
                                                       new SqlParameter("@selfremarks", SqlDbType.VarChar, 50) };
            objp[0].Value = empid;
            objp[1].Value = qid;
            objp[2].Value = selfrating;
            objp[3].Value = selfremarks;

            ExecuteQuery("SPInsHRPersonalKPI", objp);
        }

        public DataTable getSubOrdinatesQuestions( int empid , int year)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@year",SqlDbType.Int,4)
            };

            objp[0].Value = empid;
            objp[1].Value = year;

            return ExecuteTable("spSubOrdinatesQuestions",objp);
        }

        public DataTable getHRIMSperiorsQuestions(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@year",SqlDbType.Int,4)
            };

            objp[0].Value = empid;
            objp[1].Value = year;

            return ExecuteTable("spHRIMSperiorsQuestions",objp);
        }

        public void UpdSubOrdinatesQuestions(int subqid, int subrating,int empid,int year )
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@subqid", SqlDbType.Int, 4),
                                                       new SqlParameter("@subrating", SqlDbType.Int, 4),
                                                       new SqlParameter("@empid",SqlDbType.Int,4),
                                                       new SqlParameter("@year",SqlDbType.Int,4),

                                                     };
            objp[0].Value = subqid;
            objp[1].Value = subrating;
            objp[2].Value = empid;
            objp[3].Value = year;

            ExecuteQuery("spUpdSubOrdinatesQuestions", objp);
        }

        public void UpdHRIMSperiorsQuestions(int empid, int year, int imqid, int imrating)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@empid",SqlDbType.Int,4),
                                                       new SqlParameter("@year",SqlDbType.Int,4),
                                                       new SqlParameter("@ImpQid", SqlDbType.Int, 4),
                                                       new SqlParameter("@ImpRating", SqlDbType.Int,4)
                                                     };
            objp[0].Value = empid;
            objp[1].Value = year;
            objp[2].Value = imqid;
            objp[3].Value = imrating;

            ExecuteQuery("spUpdHRIMSperiorsQuestions", objp);
        }

        public DataTable GetHRKPISubmit(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@year",SqlDbType.Int,4)
            };

            objp[0].Value = empid;
            objp[1].Value = year;

            return ExecuteTable("SPGetKPISubmit", objp);
        }

        public DataTable GetRatingCompetencies(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid",SqlDbType.Int,4),
                new SqlParameter("@ryear",SqlDbType.Int,4)
            };

            objp[0].Value = empid;
            objp[1].Value = year;

            return ExecuteTable("SPGetRatingCompetencies", objp);
        }

        public void InsGapsCompetency(int empid, int compid, string gaps, int year, string func)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@compid", SqlDbType.Int ,4),
                                                       new SqlParameter("@gaps",SqlDbType.VarChar,1000),
                                                       new SqlParameter("@year", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@func",SqlDbType.Char,1)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = compid;
            objp[2].Value = gaps;
            objp[3].Value = year;
            objp[4].Value = func;
            ExecuteQuery("SPInsGapsinCompetency", objp);
        }

        public DataSet GetEmpsalarydetails(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid",SqlDbType.Int,4)
            };

            objp[0].Value = empid;
            return ExecuteDataSet("SPGetEmpLatestSalaryDetails", objp);
        }
    }
}
