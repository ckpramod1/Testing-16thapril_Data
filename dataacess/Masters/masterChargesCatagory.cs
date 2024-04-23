using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
    public class masterChargesCategory : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public masterChargesCategory()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertChargesCategory(string Category, string descr)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@Category" ,SqlDbType.VarChar,50),
                                                                                     new SqlParameter( "@descr",SqlDbType.VarChar,50)};

            objp[0].Value = Category;
            objp[1].Value = descr;
            ExecuteQuery("SPInsMasterChargesCategory", objp);
        }

        public void UpdateChargesCategory(string Category, string descr,int Categoryid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@Category" ,SqlDbType.VarChar,50),
                                                                                     new SqlParameter( "@descr",SqlDbType.VarChar,50),
                                                                                     new SqlParameter( "@Categoryid",SqlDbType.Int)};

            objp[0].Value = Category;
            objp[1].Value = descr;
            objp[2].Value = Categoryid;
            ExecuteQuery("SPUpdMasterChargesCategory", objp);
        }

        public void DeleteChargesCategory(int Categoryid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter( "@Categoryid",SqlDbType.Int)};

            objp[0].Value = Categoryid;
            ExecuteQuery("SPdelMasterChargesCategory", objp);
        }

        public void UpdateCategoryid4Charges(int Categoryid,int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Categoryid", SqlDbType.Int),
                                                       new SqlParameter("@chargeid", SqlDbType.Int,4) };

            objp[0].Value = Categoryid;
            objp[1].Value = chargeid;
            ExecuteQuery("SPUpdCategoryid4Charges", objp);
        }
        public void DeleteCategoryid4Charges(int Categoryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Categoryid", SqlDbType.Int)};

            objp[0].Value = Categoryid;
            ExecuteQuery("SPDelCategoryid4Charges", objp);
        }
        public DataTable ShowChargesCategory(int Categoryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Categoryid", SqlDbType.Int) };
            objp[0].Value = Categoryid;
            return ExecuteTable("SPSelMasterChargesCategory", objp);
        }

        public DataTable SelCategoryCharges(int Categoryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Categoryid", SqlDbType.Int) };
            objp[0].Value = Categoryid;
            return ExecuteTable("SPSelCategoryCharges", objp);
        }


        public DataTable LikeChargesCategory(string Category)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Category", SqlDbType.VarChar, 50) };
            objp[0].Value = Category;
            return ExecuteTable("SPLikeMasterChargesCategory", objp);
        }

        public int GetChargesCategoryid(string Category)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Category", SqlDbType.VarChar, 50) };

            objp[0].Value = Category;
            return int.Parse(ExecuteReader("SPGetMasterChargesCategoryID", objp));

        }
    }
}
