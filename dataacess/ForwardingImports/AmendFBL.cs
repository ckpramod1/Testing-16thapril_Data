using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
    public  class AmendFBL:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public AmendFBL()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable FillFBLNo(int jobno, string strtrantype, int bid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                        };
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = bid;
        
            return ExecuteTable("SPFillFBLno", objp);
        }
        public DataTable GetFBLno(string strTranType, string blno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),                                                       
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)
                                                        };
            objp[0].Value = strTranType;
            objp[1].Value = blno;
            objp[2].Value = bid;
          
           
            return ExecuteTable("SPGetFBLNo", objp);
        }
        public void UpdAmendForwarderBL(string stroldblno, string strnewblno, string trantype, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@oldblno",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@newblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2) ,       
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};


            objp[0].Value = stroldblno;
            objp[1].Value = strnewblno;
            objp[2].Value = trantype;
            objp[3].Value = bid;
            ExecuteQuery("SPAmendForwarderBL", objp);
        }


    }
}
