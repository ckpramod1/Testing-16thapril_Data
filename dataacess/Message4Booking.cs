using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class Message4Booking : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Message4Booking()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable SelBooking4Msg(string bookno, int intBranchID,string strtrantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = bookno;
            objp[1].Value = intBranchID;
            objp[2].Value = strtrantype;
            return ExecuteTable("SPSelMsg4Booking", objp);
        }

        public void InsMsg4Booking(string brefno,string msg, string tomail, string ccmail,DateTime currdate,string sentby,string toshipper,string toOther,string strAttach)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@brefno", SqlDbType.VarChar , 30),
                                                       new SqlParameter("@msg", SqlDbType.VarChar , 4000),
                                                       new SqlParameter("@tomail", SqlDbType.VarChar, 500),
                                                       new SqlParameter("@ccmail", SqlDbType.VarChar, 500),
                                                       new SqlParameter("@currdate", SqlDbType.DateTime),
                                                       new SqlParameter("@sentby", SqlDbType.VarChar,100),
                                                       new SqlParameter("@toshipper", SqlDbType.VarChar,500),
                                                       new SqlParameter("@toother", SqlDbType.VarChar,500),
                                                       new SqlParameter("@attachment",SqlDbType.VarChar,100)
                                                       };
            objp[0].Value = brefno;
            objp[1].Value = msg;
            objp[2].Value = tomail;
            objp[3].Value = ccmail ;
            objp[4].Value = currdate;
            objp[5].Value = sentby;
            objp[6].Value = toshipper;
            objp[7].Value = toOther;
            objp[8].Value = strAttach;
            ExecuteQuery("SPInsMsg4Booking", objp);
        }


        public DataTable SelMsgBooking(string sentby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sentby",SqlDbType.VarChar,100)
                                                      };
            objp[0].Value = sentby ;
            return ExecuteTable("SPSelMessage4Booking", objp);
        }

        //-------------------------For BL Number
        
        public DataTable SelBlNo4Msg(string blno, int intBranchID,string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar ,2)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = intBranchID;
            objp[2].Value = trantype;
            return ExecuteTable("SPSelMsg4BlNo", objp);
        }



        public DataTable GetBlDet4Msg(string blno,string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = bookingno;
            return ExecuteTable("SPGetBLDet4BookMail", objp);
        }
    }
}
