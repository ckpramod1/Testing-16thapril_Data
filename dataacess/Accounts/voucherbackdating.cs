using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Accounts
{
   public  class voucherbackdating : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public voucherbackdating()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable Getacvoudategetdetails (int vouyear,string voutype,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@vouyear", SqlDbType.Int, 4),
                   new SqlParameter("@voutype", SqlDbType.VarChar),
                new SqlParameter("@branchid", SqlDbType.Int)
           };
            objp[0].Value = vouyear;
            objp[1].Value = voutype;
            objp[2].Value = branchid ;
            return ExecuteTable("acvoudategetdetails", objp);
        }
       public DataTable Getoldvoudate(int vouno,int branchid,int vouyear,string voutype)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@vouno", SqlDbType.Int),
                   new SqlParameter("@branchid", SqlDbType.Int ),
                new SqlParameter("@vouyear", SqlDbType.Int),
               new SqlParameter("@voutype", SqlDbType.VarChar)
           };
           objp[0].Value = vouno;
           objp[1].Value = branchid;
           objp[2].Value = vouyear;
           objp[3].Value = voutype;
           return ExecuteTable("sp_chkvaliddate", objp);
       }

       public void Insertacvoudatechange(int vouno,string voutype,int vouyear,int branchid,DateTime olddate ,DateTime newdate,int empid)
        {
          
            SqlParameter[] objp = new SqlParameter[] 
               {         
               new SqlParameter("@vouno",SqlDbType.Int),        
             new SqlParameter("@voutype",SqlDbType.VarChar,15), 
             new SqlParameter("@vouyear",SqlDbType.Int ),
             new SqlParameter("@branchid",SqlDbType.Int ),
             new SqlParameter("@Oldvoudate",SqlDbType.DateTime),
             new SqlParameter("@newvoudate",SqlDbType.DateTime),
              new SqlParameter("@empid",SqlDbType.Int )
               };
            objp[0].Value = vouno;
            objp[1].Value = voutype;
            objp[2].Value = vouyear;
            objp[3].Value = branchid;
            objp[4].Value = olddate;
            objp[5].Value = newdate;
            objp[6].Value = empid;
            ExecuteQuery("spinsertacvoudatechange", objp);
        }
       //public void updateacvoudate(string voutype, DateTime voudate, int vouno,int vouyear,int branchid,string dbname)
       // {
       //     SqlParameter[] objp = new SqlParameter[] 
       //    {
       //          new SqlParameter("@voutypechar",SqlDbType.VarChar,15),        
       //          new SqlParameter("@voudate",SqlDbType.DateTime ), 
       //          new SqlParameter("@vouno",SqlDbType.Int ),
       //          new SqlParameter("@vouyear",SqlDbType.Int ),
       //          new SqlParameter("@branchid",SqlDbType.Int ),
       //        new SqlParameter("@dbname",SqlDbType.VarChar,50 ) 
       //     };
       //     objp[0].Value = voutype;
       //     objp[1].Value = voudate;
       //     objp[2].Value = vouno;
       //     objp[3].Value = vouyear;
       //     objp[4].Value = branchid;
       //     objp[5].Value = dbname; 
       //     ExecuteQuery("updateacvoudate", objp);
       // }


       //public DataTable Getacvoudate4journal(int vouyear, int branchid, string dbname)
       //{
       //    SqlParameter[] objp = new SqlParameter[] {
       //        new SqlParameter("@vouyear", SqlDbType.Int, 4),
       //         new SqlParameter("@branchid", SqlDbType.Int),             
       //            new SqlParameter("@dbname", SqlDbType.VarChar)
              
       //    };
       //    objp[0].Value = vouyear;
       //    objp[1].Value = branchid;
       //    objp[2].Value = dbname;

       //    return ExecuteTable("getacvoujournaldtls", objp);
       //}

       public void updateacvoudate(string voutype, DateTime voudate, int vouno, int vouyear, int branchid, string dbname, DateTime oldvoudate)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                               {
                                                     new SqlParameter("@voutypechar",SqlDbType.VarChar,15),         
                                                     new SqlParameter("@newvoudate",SqlDbType.DateTime ), 
                                                     new SqlParameter("@vouno",SqlDbType.Int ),
                                                     new SqlParameter("@vouyear",SqlDbType.Int ),
                                                     new SqlParameter("@branchid",SqlDbType.Int ),
                                                   new SqlParameter("@oldvoudate",SqlDbType.DateTime ), 
                                                   new SqlParameter("@dbname",SqlDbType.VarChar,50 ) 
                                                };
           objp[0].Value = voutype;
           objp[1].Value = voudate;
           objp[2].Value = vouno;
           objp[3].Value = vouyear;
           objp[4].Value = branchid;
           objp[5].Value = oldvoudate;
           objp[6].Value = dbname;

           if (voutype == "BP" || voutype == "BR")
           {
               ExecuteQuery("updateacvoudateRP", objp);
           }
           else
           {
               ExecuteQuery("updateacvoudate", objp);
           }
       }

       public DataTable Getacvoudate4journal(int vouyear, int branchid, string dbname, string type)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@vouyear", SqlDbType.Int, 4),
                new SqlParameter("@branchid", SqlDbType.Int),             
                   new SqlParameter("@dbname", SqlDbType.VarChar,20),
               new SqlParameter("@type", SqlDbType.VarChar,10)
              
           };
           objp[0].Value = vouyear;
           objp[1].Value = branchid;
           objp[2].Value = dbname;
           objp[3].Value = type;
           return ExecuteTable("getacvoujournaldtls", objp);
       }

    }
}





