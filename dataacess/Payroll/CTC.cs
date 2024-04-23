using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess.Payroll
{
   public  class CTC : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public CTC()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetCTCDtls(string option, int div, int branch, int dept, DateTime date)
        {


            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@option",SqlDbType.VarChar,10),
                        new SqlParameter("@divsn",SqlDbType.Int,4),
                        new SqlParameter("@branch",SqlDbType.Int),
                        new SqlParameter("@dept",SqlDbType.Int,4),
                         new SqlParameter("@date",SqlDbType.DateTime,8)
                    };
            objp[0].Value = option;
            objp[1].Value = div;
            objp[2].Value = branch;
            objp[3].Value = dept;
            objp[4].Value = date;
            return ExecuteTable("SPGetCTCDtls", objp);
        }
        public DataTable GetCTCDtls4earn(string option, int div, int branch, int dept, DateTime date)
        {


            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@option",SqlDbType.VarChar,10),
                        new SqlParameter("@divsn",SqlDbType.Int,4),
                        new SqlParameter("@branch",SqlDbType.Int),
                        new SqlParameter("@dept",SqlDbType.Int,4),
                         new SqlParameter("@date",SqlDbType.DateTime,8)
                    };
            objp[0].Value = option;
            objp[1].Value = div;
            objp[2].Value = branch;
            objp[3].Value = dept;
            objp[4].Value = date;
            return ExecuteTable("SPGetCTCDtls4earn", objp);
        }



       //By ManiG
       public DataTable GetCTCDtls4FromTo(string option, int div, int branch, int dept, DateTime Frmdate, DateTime Todate)
       {


           SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@option",SqlDbType.VarChar,10),
                        new SqlParameter("@divsn",SqlDbType.Int,4),
                        new SqlParameter("@branch",SqlDbType.Int),
                        new SqlParameter("@dept",SqlDbType.Int,4),
                         new SqlParameter("@From",SqlDbType.DateTime,8),
                        new SqlParameter("@To",SqlDbType.DateTime,8)
                    };
           objp[0].Value = option;
           objp[1].Value = div;
           objp[2].Value = branch;
           objp[3].Value = dept;
           objp[4].Value = Frmdate;
           objp[5].Value = Todate;
           return ExecuteTable("SPGetCTCDtls4FromandTo", objp);
       }

       public DataTable GetCTCDtls4earnFromTo(string option, int div, int branch, int dept, DateTime dateFrm, DateTime dateTo)
       {


           SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@option",SqlDbType.VarChar,10),
                        new SqlParameter("@divsn",SqlDbType.Int,4),
                        new SqlParameter("@branch",SqlDbType.Int),
                        new SqlParameter("@dept",SqlDbType.Int,4),
                         new SqlParameter("@From",SqlDbType.DateTime,8),
                        new SqlParameter("@To",SqlDbType.DateTime,8)
                    };
           objp[0].Value = option;
           objp[1].Value = div;
           objp[2].Value = branch;
           objp[3].Value = dept;
           objp[4].Value = dateFrm;
           objp[5].Value = dateTo;
           return ExecuteTable("SPGetCTCDtls4earnFromTo", objp);
       }
    }
}
