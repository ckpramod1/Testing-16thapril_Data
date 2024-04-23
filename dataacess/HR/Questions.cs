using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.HR
{
    public class Questions : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Questions()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsQuestionHead(string QHTitle, int DeptID, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qhtitle", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@deptid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@qhid", SqlDbType.Int, 4) };
            objp[0].Value = QHTitle;
            objp[1].Value = DeptID;
            objp[2].Value = empid;
            objp[3].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsQuestionHead", objp, "@qhid");
        }

        public void InsQuestionDtls(int QHid, string Question, string Opt1, string Opt2, string Opt3, string Opt4, string Opt5)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qhid", SqlDbType.Int, 4),
                                                       new SqlParameter("@question", SqlDbType.VarChar, 250),
                                                       new SqlParameter("@opt1", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@opt2", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@opt3", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@opt4", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@opt5", SqlDbType.VarChar, 50), };
            objp[0].Value = QHid;
            objp[1].Value = Question;
            objp[2].Value = Opt1;
            objp[3].Value = Opt2;
            objp[4].Value = Opt3;
            objp[5].Value = Opt4;
            objp[6].Value = Opt5;
            ExecuteQuery("SPInsQuestionDtls", objp);
        }

        public void UpdQuestionHead(string QHTitle, int DeptID, int QHid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qhtitle", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@deptid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@qhid", SqlDbType.Int, 4) };
            objp[0].Value = QHTitle;
            objp[1].Value = DeptID;
            objp[2].Value = QHid;
            ExecuteQuery("SPUpdQuestionHead", objp);
        }

        public void UpdQuestionDtls(string Question, string Opt1, string Opt2, string Opt3, string Opt4, string Opt5, int Qid, int QHid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@question", SqlDbType.VarChar, 250),
                                                       new SqlParameter("@opt1", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@opt2", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@opt3", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@opt4", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@opt5", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@qid", SqlDbType.Int, 4),
                                                       new SqlParameter("@qhid", SqlDbType.Int, 4) };
            objp[0].Value = Question;
            objp[1].Value = Opt1;
            objp[2].Value = Opt2;
            objp[3].Value = Opt3;
            objp[4].Value = Opt4;
            objp[5].Value = Opt5;
            objp[6].Value = Qid;
            objp[7].Value = QHid;
            ExecuteQuery("SPUpdQuestionDtls", objp);
        }

        public DataTable GetLikeTitle(string QHTitle, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qhtitle", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = QHTitle;
            objp[1].Value = empid;
            return ExecuteTable("SPLikeQuestionTitle", objp);
        }

        public DataTable GetQHead(int QHid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qhid", SqlDbType.Int, 4) };
            objp[0].Value = QHid;
            return ExecuteTable("SPGetQuestionHead", objp);
        }

        public DataTable GetQDetails(int QHid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qhid", SqlDbType.Int, 4) };
            objp[0].Value = QHid;
            return ExecuteTable("SPGetQuestionDtls", objp);
        }

        public DataTable GetQuestion(int UserID, int QHid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@userid", SqlDbType.Int),
                                                       new SqlParameter("@qhid", SqlDbType.Int, 4) };
            objp[0].Value = UserID;
            objp[1].Value = QHid;
            return ExecuteTable("SPGetQuestion", objp);
        }

        public void InsQuestionnaire(int Empid, int Qid, int Answer)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@qid", SqlDbType.Int, 4),
                                                       new SqlParameter("@answer", SqlDbType.TinyInt, 1) };
            objp[0].Value = Empid;
            objp[1].Value = Qid;
            objp[2].Value = Answer;
            ExecuteQuery("SPInsQuestionnaire", objp);
        }

        public void UpdQuestionnaire(int Empid, int Qid, int Answer)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@qid", SqlDbType.Int, 4),
                                                       new SqlParameter("@answer", SqlDbType.TinyInt, 1) };
            objp[0].Value = Empid;
            objp[1].Value = Qid;
            objp[2].Value = Answer;
            ExecuteQuery("SPUpdQuestionnaire", objp);
        }

        public DataTable GetQuestTitle()
        {
            return ExecuteTable("SPGetQuestionTitle");
        }

        public bool CheckTestAttend(int QHid, int UserID)
        {
            DataTable DtK; bool Atnd;
            
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qhid", SqlDbType.Int, 4),
                                                       new SqlParameter("@userid", SqlDbType.Int) };
            objp[0].Value = QHid; ;
            objp[1].Value = UserID;
            DtK = ExecuteTable("SPCheckTestAttend", objp);

            if (Dt.Rows.Count > 0)
                Atnd = true;
            else
                Atnd = false;

            return Atnd;
        }

        public void DelQuestion(int Qid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@qid", SqlDbType.Int, 4) };
            objp[0].Value = Qid; ;
            ExecuteQuery("SPDelQuestionDtl", objp);
        }
        public void InsQuestionnairePts(int Empid, int Qid, string pt1, string pt2)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@qid", SqlDbType.Int, 4),
                                                       new SqlParameter("@pt1", SqlDbType.VarChar, 200),
                                                       new SqlParameter("@pt2",SqlDbType.VarChar,200)};
            objp[0].Value = Empid;
            objp[1].Value = Qid;
            objp[2].Value = pt1;
            objp[3].Value = pt2;
            ExecuteQuery("SPInsQuestionarieDetails", objp);
        }
        public void UpdQuestionnairePts(int Empid, int Qid, string pt1, string pt2)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@qid", SqlDbType.Int, 4),
                                                       new SqlParameter("@pt1", SqlDbType.VarChar, 200),
                                                       new SqlParameter("@pt2",SqlDbType.VarChar,200)};
            objp[0].Value = Empid;
            objp[1].Value = Qid;
            objp[2].Value = pt1;
            objp[3].Value = pt2;
            ExecuteQuery("SPUpdQuestionarieDetails", objp);
        }
        public DataTable SelQuestionarieDetails(int empid, int qid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@qid", SqlDbType.Int, 4)};
            objp[0].Value = empid;
            objp[1].Value = qid;
            return ExecuteTable("SPSelQuestionarieDetails", objp);
        }
        public int Getlastqhid()
        {

            SqlParameter[] objp = new SqlParameter[] { };
            return int.Parse(ExecuteReader("SPGetlatestQHid"));
        }
        //GetSuggestionDetails 
        public DataTable GetSuggestionDtls(int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divid", SqlDbType.Int)
                                                       };
            objp[0].Value = divid;

            return ExecuteTable("SPGetSuggestionDtls", objp);
        }
    }
}
