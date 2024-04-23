using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Accounts
{
    public class TDS_Removal:DBObject
     {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public TDS_Removal()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetTDSDetailsforremoval(int branchid,char voutype,DateTime fdate,DateTime tdate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@fdate",SqlDbType.DateTime,8),
                                                     new SqlParameter("@tdate",SqlDbType.DateTime,8)};
            objp[0].Value = branchid;
            objp[1].Value = voutype;
            objp[2].Value = fdate;
            objp[3].Value = tdate;
            return ExecuteTable("SPGetPATDforremoval",objp);
        }
       
        public void  RemoveTDSEntry(int vouno,int branchid,int vouyear,int customerid,char voutype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,8),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1)};
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = customerid;
            objp[4].Value = voutype;
            ExecuteQuery("SPRemoveTDSEntry",objp);
        }
        public void UpdateTDSRemoval(int vouno, int branchid, int vouyear, int customerid, char voutype, double cstamount, double tdsamount, double TDSNEW, double TDSold, string DBname, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),
                                                     new SqlParameter("@customerid",SqlDbType.Int,8),
                                                     new SqlParameter("@voutype",SqlDbType.Char,1),
                                                     new SqlParameter("@cstamount",SqlDbType.Money),
                                                     new SqlParameter("@tdsamount",SqlDbType.Money),
                                                     new SqlParameter("@TDSNEW",SqlDbType.Money),
                                                     new SqlParameter("@TDSold",SqlDbType.Money),
                                                     new SqlParameter("@DBName",SqlDbType.VarChar,15),
                                                      new SqlParameter("@empid",SqlDbType.Int,4)
            };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = customerid;
            objp[4].Value = voutype;
            objp[5].Value = cstamount;
            objp[6].Value = tdsamount;
            objp[7].Value = TDSNEW;
            objp[8].Value = TDSold;
            objp[9].Value = DBname;
            objp[10].Value = empid;
            ExecuteQuery("SPUpdTDSRemoval", objp);
        }


        public DataTable TDSRemovalnew(int CNno, int vouyear, int Branchid, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@VOUNO", SqlDbType.Int, 4),
                                                      new SqlParameter("@vouyear", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@voutype",SqlDbType.Char,1) };
            objp[0].Value = CNno;
            objp[1].Value = vouyear;
            objp[2].Value = Branchid;
            objp[3].Value = voutype;
            return ExecuteTable("SPTDSREMOVE", objp);
        }
        public void VendornoUpdate(int vouno, int branchid, int vouyear, char voutype, string vendorno, string dbname, DateTime vndate)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@vouno",SqlDbType.Int,4),
                                                     new SqlParameter("@branchid",SqlDbType.Int,4),
                                                     new SqlParameter("@vouyear",SqlDbType.Int,4),                                                
                                                     new SqlParameter("@voutype",SqlDbType.VarChar,100),
                                                     new SqlParameter("@vendorno",SqlDbType.VarChar,20),
                                                      new SqlParameter("@dbname",SqlDbType.VarChar,20),
                                                       new SqlParameter("@vendordate",SqlDbType.Date),
            };
            objp[0].Value = vouno;
            objp[1].Value = branchid;
            objp[2].Value = vouyear;
            objp[3].Value = voutype;
            objp[4].Value = vendorno;
            objp[5].Value = dbname;
            objp[6].Value = vndate;
            ExecuteQuery("VendornoUpdate", objp);
        }
        public DataTable VendorNoChange(int CNno, int vouyear, int Branchid, char voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@VOUNO", SqlDbType.Int, 4),
                                                      new SqlParameter("@vouyear", SqlDbType.Int),
                                                      new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                      new SqlParameter("@voutype",SqlDbType.Char,1) };
            objp[0].Value = CNno;
            objp[1].Value = vouyear;
            objp[2].Value = Branchid;
            objp[3].Value = voutype;

            return ExecuteTable("VendorNoChange", objp);
        }
      }
}
