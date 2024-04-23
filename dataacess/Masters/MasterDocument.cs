using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterDocument : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterDocument()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetDocTypes()
        {
            return ExecuteTable("SPSelDoctype");
        }

        //public int GetDocTypeID(string DocName)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docname", SqlDbType.VarChar, 30) };
        //    objp[0].Value = DocName;
        //    return int.Parse(ExecuteReader("SPSelDoctypeID", objp));
        //}
        public int GetDocTypeID(string DocName, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@docname", SqlDbType.VarChar, 30),
             new SqlParameter("@trantype", SqlDbType.VarChar,25)};
            objp[0].Value = DocName;
            objp[1].Value = trantype;
            return int.Parse(ExecuteReader("SPSelDoctypeID", objp));
        }
        public int GetDocTypeID(string DocName)
        {
            SqlParameter[] array = new SqlParameter[1]
            {
            new SqlParameter("@docname", SqlDbType.VarChar, 30)
            };
            array[0].Value = DocName;
            IDataParameter[] parameters = array;
            return int.Parse(ExecuteReader("SPSelDoctypeIDnew", parameters));
        }

        //public DataTable GetUplodDtls(int jobno, string Trantype)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
        //                                               new SqlParameter("@Trantyp", SqlDbType.Char , 2) };
        //    objp[0].Value = jobno;
        //    objp[1].Value = Trantype;

        //    return ExecuteTable("SPGetUplodDtls", objp);
        //}
        public DataTable GetUplodDtls(int jobno, string Trantype, int branchid, int docid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@Trantyp", SqlDbType.Char , 2),
                  new SqlParameter("@branchid",SqlDbType.Int,6),
                 new SqlParameter("@docid",SqlDbType.Int,6)
            };
            objp[0].Value = jobno;
            objp[1].Value = Trantype;
            objp[2].Value = branchid;
            objp[3].Value = docid;
            return ExecuteTable("SPGetUplodDtls", objp);
        }

       

    }
}
