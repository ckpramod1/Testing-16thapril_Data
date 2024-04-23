using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.Masters
{
    public class MasterBank : DBObject
    {
        ////Insert Bank Name.
        //public void InsertBank(string Bankname)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankname", SqlDbType.VarChar, 50) };
        //    objp[0].Value = Bankname;
        //    ExecuteQuery("SPInsBank", objp);
        //}
        ////Update  Bank Name.

        //public void UpdBank(string Bankname, int bankid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankname", SqlDbType.VarChar, 50),
        //                                               new SqlParameter("@bankid",SqlDbType.Int)};
        //    objp[0].Value = Bankname;
        //    objp[1].Value = bankid;
        //    ExecuteQuery("SPUpdBank", objp);
        //}

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterBank()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetSelBillid(string cname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cname", SqlDbType.VarChar, 50) };
            //new SqlParameter("@billtype", SqlDbType.VarChar, 2)};
            objp[0].Value = cname;
            //objp[1].Value= billtype;
            return ExecuteTable("SPSelBillId", objp);
        }
        public DataTable GetLikeBillName(string billname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billname", SqlDbType.VarChar, 50) };
            objp[0].Value = billname;
            return ExecuteTable("SPGetLikeBillName", objp);
        }
        public void InsertMasterBill(string billname, string billtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billname", SqlDbType.VarChar, 50),
                new SqlParameter("@billtype", SqlDbType.VarChar, 2),
            };
            objp[0].Value = billname;
            objp[1].Value = billtype;
            ExecuteQuery("SPMAINSBill", objp);
        }

        public void UpdMasterBill(string billname, string billtype, int billid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@billname", SqlDbType.VarChar, 50),
                new SqlParameter("@billtype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@billid",SqlDbType.Int)};
            objp[0].Value = billname;
            objp[1].Value = billtype;
            objp[2].Value = billid;

            ExecuteQuery("SPUpdMABill", objp);
        }

        //RajaGuru
        //Insert Bank Name.
        public void InsertBank(string Bankname, string ourbank)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankname", SqlDbType.VarChar, 50), new SqlParameter("@ourbank", SqlDbType.Char, 1) };
            objp[0].Value = Bankname;
            objp[1].Value = ourbank;
            ExecuteQuery("SPInsBank", objp);
        }

        //Update  Bank Name.

        public void UpdBank(string Bankname, string ourbank, int bankid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankname", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@ourbank", SqlDbType.Char,1),
                                                       new SqlParameter("@bankid",SqlDbType.Int)};
            objp[0].Value = Bankname;
            objp[1].Value = ourbank;
            objp[2].Value = bankid;
            ExecuteQuery("SPUpdBank", objp);
        }

        public DataTable GetLikeBankName(string bankname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankname", SqlDbType.VarChar, 50) };
            objp[0].Value = bankname;
            return ExecuteTable("SpLikeBank", objp);
        }

        //Check the bank already exist or not.

        public DataTable CheckbankExist(string bankname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankname", SqlDbType.VarChar, 50)
                                                       };
            objp[0].Value = bankname;

            return ExecuteTable("Sp_Check_Bank", objp);

        }

        public DataTable GetGridview()
        {
            return ExecuteTable("SpgridBank");
        }

        public DataTable GetAllBankDetails(int bankid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankid", SqlDbType.Int)
                                                       };
            objp[0].Value = bankid;

            return ExecuteTable("SPGetAllBankDetalis", objp);

        }

       
        public DataTable GetTopBankRows()
        {
            return ExecuteTable("SPGetBankTopRows");
        }
        public void DelTableBank(int bankid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankid", SqlDbType.Int)
            
        };
            objp[0].Value = bankid;
            ExecuteQuery("Sp_DelBank", objp);
            
        }


    }
}
