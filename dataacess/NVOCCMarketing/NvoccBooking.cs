using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.nvoccmarketing
{
    public class NvoccBooking : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public NvoccBooking()
        {
            Conn = new SqlConnection(DBCS);
        }


        Masters.MasterBranch BranchObj = new DataAccess.Masters.MasterBranch();
        public DataTable BuyingGrdDetails(int pol, int pod, int por, int fd)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int)};
            objp[0].Value = pol;
            objp[1].Value = pod;
            objp[2].Value = por;
            objp[3].Value = fd;
            return ExecuteTable("SPNVSelBuyingGrd", objp);
        }

        public DataTable QuotGrdDetails(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1) };
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPNVSelQuotApproved", objp);
        }

        public int GetShipRefno()
        {
            return int.Parse(ExecuteReader("SPUpdMCShipRef"));
        }

        public string InsertBookingDetails(int quotno, double volume, DateTime bookingdate, string trantype, string division, string branch, int branchid, int PreparedBy, int incoid, int BranchID, int DivisionID)
        {
            int shipref = 0;
            string shiprefno = null;
            string ShortName = null;
            string monthyear = "";
            string m, y;
            //if (trantype == "FE")
            //{
            shipref = GetShipRefno();
            ShortName = BranchObj.GetShortName(BranchID);
            m = DateTime.Today.Month.ToString();
            if (m.Length < 2)
                m = "0" + m;
            y = DateTime.Today.Year.ToString();
            y = y.Substring(2, 2);
            monthyear = m + y;
            //if (shipref < 9)
            //    shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString() + "00000" + shipref.ToString();
            //else if ((shipref > 9) && (shipref < 100))
            //    shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString() + "0000" + shipref.ToString();
            //else if ((shipref > 99) && (shipref < 1000))
            //    shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString() + "000" + shipref.ToString();
            //else if ((shipref > 999) && (shipref < 10000))
            //    shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString() + "00" + shipref.ToString();
            //else if ((shipref > 9999) && (shipref < 100000))
            //    shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString() + "0" + shipref.ToString();
            //else if ((shipref > 99999) && (shipref < 1000000))
            //    shiprefno = division.Substring(0, 1) + branch.Substring(0, 3) + monthyear.ToString() + shipref.ToString();

            if (shipref < 9)
                shiprefno = ShortName  + "00000" + shipref.ToString();
            else if ((shipref > 9) && (shipref < 100))
                shiprefno = ShortName  + "0000" + shipref.ToString();
            else if ((shipref > 99) && (shipref < 1000))
                shiprefno = ShortName  + "000" + shipref.ToString();
            else if ((shipref > 999) && (shipref < 10000))
                shiprefno = ShortName  + "00" + shipref.ToString();
            else if ((shipref > 9999) && (shipref < 100000))
                shiprefno = ShortName  + "0" + shipref.ToString();
            else if ((shipref > 99999) && (shipref < 1000000))
                shiprefno = ShortName  + shipref.ToString();

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno", SqlDbType.Int,4),
                                                       new SqlParameter("@volume",SqlDbType.Real,4),
                                                       new SqlParameter("@bookingdate",SqlDbType.DateTime,8),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@shiprefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@srefno",SqlDbType.VarChar,30),                        
                                                       new SqlParameter("@preparedby",SqlDbType.Int),
                                                       new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = quotno;
            objp[1].Value = volume;
            objp[2].Value = bookingdate;
            objp[3].Value = trantype;
            objp[4].Value = shiprefno;
            objp[5].Direction = ParameterDirection.Output;
            objp[6].Value = PreparedBy;
            objp[7].Value = incoid;
            objp[8].Value = BranchID;
            objp[9].Value = DivisionID;
            return ExecuteQuery("SPInsBooking", "@srefno", objp).ToString();
        }

        public void UpdateBookingDetails(double volume, string bookingno, int branchid, int incoid, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@volume", SqlDbType.Real,4), 
                                                        new SqlParameter("@bookingno", SqlDbType.VarChar,30), 
                                                        new SqlParameter("@inco",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = volume;
            objp[1].Value = bookingno;
            objp[2].Value = incoid;
            objp[3].Value = bid;
            objp[4].Value = cid;
            ExecuteQuery("SPUpdBooking", objp);
        }

        public DataTable GetBookingPending(string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPSelBookingPending", objp);
        }

        public DataTable GetBookingDetails(string Bookingno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1) };
            objp[0].Value = Bookingno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelBookingdtls", objp);
        }

        public DataTable SelMasterInco(int incoid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@incoid", SqlDbType.TinyInt,1) };
            objp[0].Value = incoid;
            return ExecuteTable("SPselMasterInco", objp);
        }
    }
}
