using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterTDSType:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterTDSType()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsertTDSType(string desc, char type, string slab, double percentage, string section)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@desc", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@type", SqlDbType.Char, 1), 
                                                       new SqlParameter("@slab", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@percentage", SqlDbType.Real, 4),
                                                       new SqlParameter("@section", SqlDbType.VarChar, 10) };
            objp[0].Value = desc;
            objp[1].Value = type;
            objp[2].Value = slab;
            objp[3].Value = percentage;
            objp[4].Value = section;
            ExecuteQuery("SPInsMstrTDSType", objp);
        }

        public void UpdateTDSType(int tdsid, string desc, char type, string slab, double percentage)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tdsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@desc", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@type", SqlDbType.Char, 1), 
                                                       new SqlParameter("@slab", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@percentage", SqlDbType.Real, 4) };
            objp[0].Value = tdsid;
            objp[1].Value = desc;
            objp[2].Value = type;
            objp[3].Value = slab;
            objp[4].Value = percentage;
            ExecuteQuery("SPUpdMstrTDSType", objp);
        }

        public DataTable GetTDSDtls(string desc)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@desc", SqlDbType.VarChar, 50) };
            objp[0].Value = desc;
            return ExecuteTable("SPGetMasterTDSDtls", objp);
        }

        public DataTable SelAllTDSDtls()
        {
            return ExecuteTable("SPSelAllMasterTDSDtls");
        }

        public void UpdTDSid(int tdsid, int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tdsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = tdsid;
            objp[1].Value = custid;
            ExecuteQuery("SPUpdTDSidForCustomer", objp);
        }




        public DataTable GetTDSDtlsForCustomer(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int, 4) };
            objp[0].Value = custid;
            return ExecuteTable("SPGetTDSDtlsForCustomer", objp);
        }

        public int GetTDSid(string Desc, char Type, string Slab, double Percent)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@desc", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@type", SqlDbType.Char, 1), 
                                                       new SqlParameter("@slab", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@percent", SqlDbType.Real, 4) };
            objp[0].Value = Desc;
            objp[1].Value = Type;
            objp[2].Value = Slab;
            objp[3].Value = Percent;
            return int.Parse(ExecuteReader("SPGetTDSid", objp));
        }


        ///vignesh

        public void InsertTDSTypeFun(string desc, char type, string slab, double percentage, string section)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@desc", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@type", SqlDbType.Char, 1), 
                                                       new SqlParameter("@slab", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@percentage", SqlDbType.Real, 4),
                                                       new SqlParameter("@section", SqlDbType.VarChar, 10) };
            objp[0].Value = desc;
            objp[1].Value = type;
            objp[2].Value = slab;
            objp[3].Value = percentage;
            objp[4].Value = section;
            ExecuteQuery("SPInsMstrTDSType", objp);
        }


        public void UpdateTDSTypeFun(int tdsid, string desc, char type, string slab, double percentage)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tdsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@desc", SqlDbType.VarChar, 50), 
                                                       new SqlParameter("@type", SqlDbType.Char, 1), 
                                                       new SqlParameter("@slab", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@percentage", SqlDbType.Real, 4) };
            objp[0].Value = tdsid;
            objp[1].Value = desc;
            objp[2].Value = type;
            objp[3].Value = slab;
            objp[4].Value = percentage;
            ExecuteQuery("SPUpdMstrTDSType", objp);
        }


        public DataTable GetTDSDtlsFun(string desc)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@desc", SqlDbType.VarChar, 50) };
            objp[0].Value = desc;
            return ExecuteTable("SPGetMasterTDSDtls", objp);
        }

        public DataTable GetDescriptionFun(string section)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@section", SqlDbType.VarChar, 10) };
            objp[0].Value = section;
            return ExecuteTable("SP_GetDescription", objp);

        }

        public DataTable GetDescriptionFun2(string section)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@section", SqlDbType.VarChar, 10) };
            objp[0].Value = section;
            return ExecuteTable("SPGetMasterDescriptionNew", objp);
        }

        public DataTable ViewTDSFun()
        {
            return ExecuteTable("SP_TDSView");
        }
        public DataTable GETGridTopTDS()
        {
            return ExecuteTable("SP_TDSTop");
        }
        public DataTable ViewSave()
        {
            return ExecuteTable("SP_ViewTds");
        }


        public DataTable GetTDSinTDSdetails(int vouno, int branchid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@vouno", SqlDbType.Int, 4),
            new SqlParameter("@branchid", SqlDbType.Int, 4),
            new SqlParameter("@vouyear", SqlDbType.Int, 4),
            new SqlParameter("@voutype", SqlDbType.VarChar, 1)
            };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            return ExecuteTable("SPGetTDSDtlsForCustomerwithper", objp);

        }

        //Dinesh
        public void UpdTDSidnew(int tdsid, int custid, double percentage)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tdsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@custid", SqlDbType.Int, 4),
                                                   new SqlParameter("@percentage", SqlDbType.Real, 4) };
            objp[0].Value = tdsid;
            objp[1].Value = custid;
            objp[2].Value = percentage;
            ExecuteQuery("SPUpdTDSidForCustomer", objp);
        }


        public void UpdPANTDSidnew(int int_TDSid, string panno, double percentage)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tdsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@panno", SqlDbType.VarChar,50),
                                                   new SqlParameter("@percentage", SqlDbType.Real, 4) };
            objp[0].Value = int_TDSid;
            objp[1].Value = panno;
            objp[2].Value = percentage;
            ExecuteQuery("SPUpdTDSidForCustomerpan", objp);
        }
        public DataTable GetdetailsTDSDtlsForCustomerPan(string panno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar,50) };
            objp[0].Value = panno;
            return ExecuteTable("SPGetTDSDtlsForCustomerPan", objp);
        }
    }
}
