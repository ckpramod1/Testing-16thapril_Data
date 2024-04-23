using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Masters;
using DataAccess.Marketing;
namespace DataAccess.ForwardingImports
{

   public  class Updatebooking : DBObject
    {

        MasterCustomer Custobj = new MasterCustomer();
        MasterVessel Vessobj = new MasterVessel();
        MasterPackages Pkgobj = new MasterPackages();
        MasterPort Portobj = new MasterPort();
        Quotation Quotobj = new Quotation();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Updatebooking()
        {
            Conn = new SqlConnection(DBCS);
        }


        //For Update Booking form

        public DataTable Getupdatebkngdtls(int jobno, int branchid, int vslid, string voyage)
        {
            SqlParameter[] objp = new SqlParameter[] 
           { 
                new SqlParameter("@jobno",SqlDbType.Int),
                new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@vesselid", SqlDbType.Int),
              new SqlParameter("@voyage", SqlDbType.VarChar,30)
           };
            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = vslid;
            objp[3].Value = voyage;
            return ExecuteTable("SPupdatebkngdetails", objp);
        }
        public DataTable Getnullbookingno(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
           {                
                new SqlParameter("@branchid", SqlDbType.Int)
               
           };
            objp[0].Value = branchid;
            return ExecuteTable("spgetnullbooking", objp);
        }
        public string Getbookingparty(string bookingno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
           {       
               new SqlParameter("@bookingno", SqlDbType.VarChar,30),
                new SqlParameter("@bid", SqlDbType.Int)
               
           };
            objp[0].Value = bookingno;
            objp[1].Value = branchid;
            return ExecuteReader("spgetbookingparty", objp);
        }
        public void updatecombkng(int branchid, string blno, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] 
           { 
                
                new SqlParameter("@branchid", SqlDbType.Int),
              new SqlParameter("@blno", SqlDbType.VarChar,30),
                new SqlParameter("@shiprefno", SqlDbType.VarChar,30)
           };
            objp[0].Value = branchid;
            objp[1].Value = blno;
            objp[2].Value = bookingno;
            ExecuteQuery("spupdatebooking", objp);
        }
        public DataTable Chkalreadybkngnohvblno(string bookingno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
           {     
               new SqlParameter("@bkngno", SqlDbType.VarChar,30),           
                new SqlParameter("@bid", SqlDbType.Int)
               
           };
            objp[0].Value = bookingno;
            objp[1].Value = branchid;
            return ExecuteTable("spchkbookingnohaveblno", objp);
        }
        public DataTable Getblnowithshiprefno(string blno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
           {     
               new SqlParameter("@blno", SqlDbType.VarChar,30),           
                new SqlParameter("@bid", SqlDbType.Int)
               
           };
            objp[0].Value = blno;
            objp[1].Value = branchid;
            return ExecuteTable("spblnowithshiprefno", objp);
        }

    }
}
