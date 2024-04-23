using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace DataAccess.Accounts
{
   public class NotOverCheque: DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public NotOverCheque()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsNotOverCheque(int bid, int customerid, string fvrname, DateTime date, double amount, int bank, string bbranch, string naration, string chequeno,DateTime chqdate)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@customerid", SqlDbType.Int, 4),
               new SqlParameter("@fvrname", SqlDbType.VarChar,100),
               new SqlParameter("@date", SqlDbType.SmallDateTime,8),
                  new SqlParameter("@amount", SqlDbType.Money,8),
                  new SqlParameter("@bank", SqlDbType.Int,4),
                new SqlParameter("@bbranch", SqlDbType.VarChar,25),
                new SqlParameter("@naration", SqlDbType.VarChar,100),
                 new SqlParameter("@chequeno", SqlDbType.VarChar,10),
                 new SqlParameter("@chqdate", SqlDbType.SmallDateTime,8),
               new SqlParameter("@nono", SqlDbType.Int,4),
           };

           objp[0].Value = bid;
           objp[1].Value = customerid;
           objp[2].Value = fvrname;
           objp[3].Value = date;
           objp[4].Value = amount;
           objp[5].Value = bank;
           objp[6].Value = bbranch;
           objp[7].Value = naration;
           objp[8].Value = chequeno;
           objp[9].Value = chqdate;
           objp[10].Direction = ParameterDirection.Output;
           return ExecuteQuery("SPInsNotOverCheque", objp, "@nono");
       }

       public void UpdNotOverCheque(int refno,int bid, int customerid, string fvrname, DateTime date, double amount, int bank, string bbranch, string naration, string chequeno, DateTime chqdate)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@refno",SqlDbType.Int,4),
               new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@customerid", SqlDbType.Int, 4),
               new SqlParameter("@fvrname", SqlDbType.VarChar,100),
               new SqlParameter("@date", SqlDbType.SmallDateTime,8),
                  new SqlParameter("@amount", SqlDbType.Money,8),
                  new SqlParameter("@bank", SqlDbType.Int,4),
                new SqlParameter("@bbranch", SqlDbType.VarChar,25),
                new SqlParameter("@naration", SqlDbType.VarChar,100),
                 new SqlParameter("@chequeno", SqlDbType.VarChar,10),
                 new SqlParameter("@chqdate", SqlDbType.SmallDateTime,8)
           };

           objp[0].Value = refno;
           objp[1].Value = bid;
           objp[2].Value = customerid;
           objp[3].Value = fvrname;
           objp[4].Value = date;
           objp[5].Value = amount;
           objp[6].Value = bank;
           objp[7].Value = bbranch;
           objp[8].Value = naration;
           objp[9].Value = chequeno;
           objp[10].Value = chqdate;          
           ExecuteQuery("SPUpdNotOverCheque", objp);
       }


       public DataTable SelNotOverCheque(int nono,int bid)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@nono", SqlDbType.Int, 4),
                   new SqlParameter("@bid", SqlDbType.Int, 4),
           };
           objp[0].Value = nono;
           objp[1].Value = bid;
             return ExecuteTable("SPSelNotOverCheque", objp);
       }

       public bool CheckChequeNo4Nono(string chqno, int bankid)
       {
           bool existance;
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chqno", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@bank", SqlDbType.Int, 4)
                                                     };
           objp[0].Value = chqno;
           objp[1].Value = bankid;

           Dt = ExecuteTable("SPCheckCheque4Nono", objp);
           if (Dt.Rows.Count > 0)
               existance = true;
           else
               existance = false;

           return existance;
       }


       public DataTable GetNotOverChequelikeCheque(string chequeno, int bid)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@chqno", SqlDbType.VarChar , 15),
                   new SqlParameter("@bid", SqlDbType.Int, 4),
           };
           objp[0].Value = chequeno;
           objp[1].Value = bid;
           return ExecuteTable("SPSelNOCLikeChequeNo", objp);
       }

       
       public int UpdateNotOverChequeAccounted(int bid, int nono)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@bid", SqlDbType.Int, 4),
                new SqlParameter("@nono", SqlDbType.Int, 4)
              
           };

           objp[0].Value = bid;
           objp[1].Value = nono;

           return ExecuteQuery("SPUpdateNotOverChequeAccounted", objp, "@nono");
       }


       public DataTable SelNotOverCheque4ChequeNo(string chequeno, int bid)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@chqno", SqlDbType.VarChar , 15),
                   new SqlParameter("@bid", SqlDbType.Int, 4),
           };
           objp[0].Value = chequeno;
           objp[1].Value = bid;
           return ExecuteTable("SPSelNotOverCheque4ChequeNo", objp);
       }

       public DataTable DelNotOverCheque(int refno)
       {
           SqlParameter[] objp = new SqlParameter[] {
               
                   new SqlParameter("@refno", SqlDbType.Int),
           };
           objp[0].Value = refno;

           return ExecuteTable("SPDelNotOverCheque", objp);
       }

       public DataTable SelNotOverCheque4ChequeNodiv(string chequeno,int division)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@chqno", SqlDbType.VarChar , 15),
               new SqlParameter("@division", SqlDbType.Int , 4)
               
           };
           objp[0].Value = chequeno;
           objp[1].Value = division;
           return ExecuteTable("SPSelNotOverCheque4ChequeNowithoutbranch", objp);
       }
       public DataTable GetNotOverChequelikeChequediv(string chequeno, int division)
       {
           SqlParameter[] objp = new SqlParameter[] {
               new SqlParameter("@chqno", SqlDbType.VarChar , 15),
               new SqlParameter("@division", SqlDbType.Int , 4)
                   
           };
           objp[0].Value = chequeno;
           objp[1].Value = division;
           return ExecuteTable("SPSelNOCLikeChequeNowithouthtbranch", objp);
       }
    }
}
