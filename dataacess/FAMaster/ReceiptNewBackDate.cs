using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.FAMaster
{
    public  class ReceiptNewBackDate : DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ReceiptNewBackDate()
        {
            Conn = new SqlConnection(DBCS);
        }


        public void InsRecptHeadCashBackDate(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 150),
                                                       new SqlParameter("@preparedby", SqlDbType.Int)};
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            ExecuteQuery("SPInsReciptHeadcashBackDate", objp);
        }

        public void InsPaymentHeadCashBackDate(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, string Naration, int preparedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 150),
                                                       new SqlParameter("@preparedby", SqlDbType.Int)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Naration;
            objp[8].Value = preparedby;
            ExecuteQuery("SPInsPaymentHeadcashBackDate", objp);
        }


        public void InsRecptHeadBankBackDate(int Recptno, DateTime RecptDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 150),
                                                       new SqlParameter("@preparedby", SqlDbType.Int) };
            objp[0].Value = Recptno;
            objp[1].Value = RecptDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            ExecuteQuery("SPInsReciptHeadBankBackDate", objp);
        }



        public void InsPaymentHeadBankBackdate(int payno, DateTime payDate, char Mode, int Branchid, int vouyr, int Cust, double rfAmount, int Bankid, string BankBranch, string chkno, DateTime chkDate, string Naration, int preparedby, char ACPayee, string fvrname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@rno", SqlDbType.Int, 4),
                                                       new SqlParameter("@rdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@mode", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt , 1),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@customer", SqlDbType.Int , 4),
                                                       new SqlParameter("@rfamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@bank", SqlDbType.Int),
                                                       new SqlParameter("@bbranch", SqlDbType.VarChar, 15),
                                                       new SqlParameter("@checkno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@checkdate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@naration", SqlDbType.VarChar, 150),
                                                       new SqlParameter("@preparedby", SqlDbType.Int),
                                                       new SqlParameter("@status", SqlDbType.Char, 1),
                                                       new SqlParameter("@fvrname", SqlDbType.VarChar,100)};
            objp[0].Value = payno;
            objp[1].Value = payDate;
            objp[2].Value = Mode;
            objp[3].Value = Branchid;
            objp[4].Value = vouyr;
            objp[5].Value = Cust;
            objp[6].Value = rfAmount;
            objp[7].Value = Bankid;
            objp[8].Value = BankBranch;
            objp[9].Value = chkno;
            objp[10].Value = chkDate;
            objp[11].Value = Naration;
            objp[12].Value = preparedby;
            objp[13].Value = ACPayee;
            objp[14].Value = fvrname;
            ExecuteQuery("SPInsPaymentHeadBankBackdate", objp);
        }

        public int GetCRBRNo4BackDated(int branchid, string mode,DateTime curdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 5),
            new SqlParameter("@curdate", SqlDbType.DateTime )};
            objp[0].Value = branchid;
            objp[1].Value = mode;
              objp[2].Value = curdate ;
            return int.Parse(ExecuteReader("SPUpdCRBRno4Backdated", objp));
        }

        public int GetCPBPNo4BackDated(int branchid, string mode,DateTime curdate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@mode", SqlDbType.VarChar, 5) ,
            new SqlParameter("@curdate", SqlDbType.DateTime ) };
            objp[0].Value = branchid;
            objp[1].Value = mode;
            objp[2].Value = curdate ;
            return int.Parse(ExecuteReader("SPUpdCPBPno4BackDated", objp));
        }

        public void InsRecptAginstInvjBackDated(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear, string jrefno, string jltype,int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@jrefno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jltype",SqlDbType.VarChar,2),
                                                       new SqlParameter("@vouyear",SqlDbType.Int)};
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = jrefno;
            objp[10].Value = jltype;
            objp[11].Value = vouyear;
            ExecuteQuery("SPInsReciptAgInvj4BackDated", objp);
        }

        public void InsRecptAginstInvBackDated(int tranid, char rptype, int vouno, char voutype, int branchid, double vamount, double tamount, char setteled, int RAVouYear,int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@tranid", SqlDbType.Int, 4),
                                                       new SqlParameter("@rptype", SqlDbType.Char, 1),
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@voutype", SqlDbType.Char, 1),
                                                       new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@vamount", SqlDbType.Money , 8),
                                                       new SqlParameter("@tamount", SqlDbType.Money, 8),
                                                       new SqlParameter("@setteled", SqlDbType.Char, 1),
                                                       new SqlParameter("@ravouyear", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int) };
            objp[0].Value = tranid;
            objp[1].Value = rptype;
            objp[2].Value = vouno;
            objp[3].Value = voutype;
            objp[4].Value = branchid;
            objp[5].Value = vamount;
            objp[6].Value = tamount;
            objp[7].Value = setteled;
            objp[8].Value = RAVouYear;
            objp[9].Value = vouyear;
            ExecuteQuery("SPInsReciptAgInv4BackDated", objp);
        }
    }
}
