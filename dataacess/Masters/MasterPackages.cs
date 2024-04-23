using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterPackages:DBObject
    {
        //Get Packageid based on packagecode 


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterPackages()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int GetPackageid(string pkgcode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@packagecode", SqlDbType.VarChar, 3) };
            objp[0].Value = pkgcode;
            return int.Parse(ExecuteReader("SPPkgidPkgCode",objp));
        }

        //Get Packageid  based on packagename
        public int GetNPackageid(string pkgname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@packagename", SqlDbType.VarChar, 50) };
            objp[0].Value = pkgname;
            return int.Parse(ExecuteReader("SPPkgidPkgName", objp));
        }

        //To get all package names to bind with DDL. 
        public DataTable GetPackagenames()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPPkgNames",objp);
        }

        //To Get Pkgname based on Pkgid 
        public string GetPackagename(int pkgid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@packageid",SqlDbType.Int) };
            objp[0].Value = pkgid;
            return ExecuteReader("SPPkgnamePkgId ", objp);
        }
        public DataTable GetPackageCode()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return (ExecuteTable("SPPkgCode",objp));
        }
        public string GetPackageCodePkgID(int packageid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@packageid", SqlDbType.Int) };
            objp[0].Value = packageid;
            return ExecuteReader("SPPkgCodePkgID", objp);
        }
        public DataTable GetLikepackage(string descn)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtpackage", SqlDbType.VarChar, 30) };
            objp[0].Value = descn;
            return ExecuteTable("SPLikePackage", objp);
        }

        //RATHA---FAMasterPackage Data Entry Form
        public DataTable GetLikePackageCode(string strPkgCode)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                     new SqlParameter("@packagecode", SqlDbType.VarChar, 3) 
                                                   };
            objp[0].Value = strPkgCode;
            return ExecuteTable("SPLikePackageCode", objp);
        }

        public void InsMasterPackages(string PkgCode,string Descn)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@packagecode", SqlDbType.VarChar, 3),
                                                         new SqlParameter("@descn", SqlDbType.VarChar, 30)};
            objp[0].Value = PkgCode;
            objp[1].Value = Descn;
            ExecuteQuery("SPInsMasterPackages", objp);
        }

        public void UpdMasterPackages(int pkgID, string PkgCode, string Descn)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@pkgid", SqlDbType.Int),
                                                         new SqlParameter("@packagecode", SqlDbType.VarChar, 3),
                                                         new SqlParameter("@descn", SqlDbType.VarChar, 30)};
            objp[0].Value = pkgID; 
            objp[1].Value = PkgCode;
            objp[2].Value = Descn;
            ExecuteQuery("SPUpdMasterPackages", objp);
        }
        //Yuvaraja 
        //insert 
        public string packinsert(string packagecode, string package_des)
        {
            SqlParameter[] sp = new SqlParameter[]{
                                                    new SqlParameter("@packagecode",SqlDbType.VarChar,3),
                                                    new SqlParameter("@packagedes",SqlDbType.VarChar,30)
                                                  };
            sp[0].Value = packagecode;
            sp[1].Value = package_des;
            return ExecuteReader("packinsert", sp);
        }
        //update
        public void Updatepackage(int id, string packagecode, string packagedes)
        {
            SqlParameter[] sp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@id",SqlDbType.Int),
                                                         new SqlParameter("@packagecode",SqlDbType.VarChar,3),
                                                    new SqlParameter("@packagedes",SqlDbType.VarChar,30)
                                                    };
            sp[0].Value = id;
            sp[1].Value = packagecode;
            sp[2].Value = packagedes;
            ExecuteQuery("packupdate", sp);
        }
        //delete
        public void Deletepackage(int id)
        {
            SqlParameter[] sp = new SqlParameter[] 
                                                    {
                                                         new SqlParameter("@id",SqlDbType.Int)
                                                    };
            sp[0].Value = id;
            ExecuteQuery("packdelete", sp);
        }
        //auto fill package des
        public DataTable Getpackagedes(string packagecode)
        {
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@packagecode", SqlDbType.VarChar, 3) };
            sp[0].Value = packagecode;
            return ExecuteTable("fillpack", sp);
        }
        //like package code  
        public DataTable getlikepackagecode(string packagecode)
        {
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@packagecode", SqlDbType.VarChar, 3) };
            sp[0].Value = packagecode;
            return ExecuteTable("sppack", sp);
        }
        public DataSet getgridpackage()
        {
            return ExecuteDataSet("gridpackage");
        }


        public DataSet packagepagegrid()
        {

            return ExecuteDataSet("packagepagegrid");

        }

        public DataTable PackageCkeck(string packagecode)
        {
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@packagecode", SqlDbType.VarChar, 3) };
            sp[0].Value = packagecode;
            return ExecuteTable("SPSelRetPackageName", sp);
        }
   }
}
