using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace DataAccess.Marketing
{
    public class FIBookingwithBL:DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FIBookingwithBL()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsFIBookingWithBL(string bookingno, string blno, int vessel, string voy, DateTime etd, int consignee, double cbm, double grwt, double ntwt, char blstatus, string remarks, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                   new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                   new SqlParameter("@vessel",SqlDbType.Int,4),
                                                   new SqlParameter("@voy",SqlDbType.VarChar,15),
                                                   new SqlParameter("@etd",SqlDbType.DateTime,8),                                   
                                                   new SqlParameter("@consignee",SqlDbType.Int,4),
                                                   new SqlParameter("@cbm",SqlDbType.Real,8),
                                                   new SqlParameter("@grwt",SqlDbType.Real,8),
                                                   new SqlParameter("@ntwt",SqlDbType.Real,8),
                                                   new SqlParameter("@blstatus",SqlDbType.Char,1),
                                                   new SqlParameter("@remarks",SqlDbType.VarChar,150),
                                                   new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                   new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = blno;
            objp[2].Value = vessel;
            objp[3].Value = voy;
            objp[4].Value = etd;
            objp[5].Value = consignee;
            objp[6].Value = cbm;
            objp[7].Value = grwt;
            objp[8].Value = ntwt;
            objp[9].Value = blstatus;
            objp[10].Value = remarks;
            objp[11].Value =intBranchID;
            objp[12].Value = intDivisionID;
            ExecuteQuery("SPInsFIBookingDtls", objp);

        }

        public void UpdFIBookingWithBL(string bookingno, string blno, int vessel, string voy, DateTime etd, int consignee, double cbm, double grwt, double ntwt, char blstatus, string remarks, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                   new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                   new SqlParameter("@vessel",SqlDbType.Int,4),
                                                   new SqlParameter("@voy",SqlDbType.VarChar,15),
                                                   new SqlParameter("@etd",SqlDbType.DateTime,8),                                   
                                                   new SqlParameter("@consignee",SqlDbType.Int,4),
                                                   new SqlParameter("@cbm",SqlDbType.Real,8),
                                                   new SqlParameter("@grwt",SqlDbType.Real,8),
                                                   new SqlParameter("@ntwt",SqlDbType.Real,8),
                                                   new SqlParameter("@blstatus",SqlDbType.Char,1),
                                                   new SqlParameter("@remarks",SqlDbType.VarChar,150),
                                                   new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                   new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = blno;
            objp[2].Value = vessel;
            objp[3].Value = voy;
            objp[4].Value = etd;
            objp[5].Value = consignee;
            objp[6].Value = cbm;
            objp[7].Value = grwt;
            objp[8].Value = ntwt;
            objp[9].Value = blstatus;
            objp[10].Value = remarks;
            objp[11].Value = intBranchID;
            objp[12].Value = intDivisionID;
            ExecuteQuery("SPUpdFIBookingDtls", objp);

        }

        public DataTable SelFIBkgwithBlDtls(int intbranchid, string type, string blno, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@type",SqlDbType.VarChar,10),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value =  intbranchid;
            objp[1].Value = type;
            objp[2].Value = blno;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelFIBookingBL", objp);

        }
        public DataTable CheckAssociatedBLs(int intbranchid, string blno,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value =intbranchid;
            objp[1].Value = blno;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPChkBkgAssociatedBL", objp);
        }
        public DataTable SelBlno(string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno", SqlDbType.VarChar, 30) };
            objp[0].Value = bookingno;
            return ExecuteTable("SPSelblnofrmBooking", objp);
        }
        public DataTable SelBookingBLDtls(int branchID,int DivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt, 1)};
            objp[0].Value = branchID;
            objp[1].Value = DivisionID;
            return ExecuteTable("SPSelBookingBLDtls",objp);
        }
        public DataTable DelBLfromBooking(int branchID, int DivisionID, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@bookingno",SqlDbType.VarChar,30)};
            objp[0].Value = branchID;
            objp[1].Value = DivisionID;
            objp[2].Value = bookingno;
            return ExecuteTable("SPDelBLfrmBooking", objp);
        }
        public DataSet CheckBLExistToDelete(string strBlNo)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30)};
            objp[0].Value = strBlNo;
            return ExecuteDataSet("SPCheckBLExist", objp);
        }
        public DataTable GetBkgPending4FIBkgBL(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelBkPng4FIBkgBl", objp);
        }
    }
}
