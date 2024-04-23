using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.Masters
{
   public class MailingList:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MailingList()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetMailingListAll(string ccase,string module,string menu,string submenu,int bid)
       {
           SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@case", SqlDbType.VarChar, 1),
                                                        new SqlParameter("@module",SqlDbType.VarChar,50),
                                                        new SqlParameter("@menuname",SqlDbType.VarChar,50),
                                                        new SqlParameter("@submenuname",SqlDbType.VarChar,50),
                                                        new SqlParameter("@bid",SqlDbType.Int,4)};
           objp[0].Value = ccase;
           objp[1].Value = module;
           objp[2].Value = menu;
           objp[3].Value = submenu;
           objp[4].Value = bid;
           return ExecuteTable("SPGetMailListModule", objp);
       }
       public DataSet GetAllMailings(string module,string submenu,string sub)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@module", SqlDbType.VarChar, 50),
                                                        new SqlParameter("@submenu",SqlDbType.VarChar,50),
                                                        new SqlParameter("@sub",SqlDbType.VarChar,50) };
           objp[0].Value = module;
           objp[1].Value=submenu;
           objp[2].Value=sub;
           return ExecuteDataSet("SPGetMenufrmMailinglist",objp);
       }
       public void InsMalingList(int branchid, int uiid, int empid)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     {
                                                       new SqlParameter("@branchid",SqlDbType.Int,4),
                                                       new SqlParameter("@uiid", SqlDbType.Int,4),
                                                       new SqlParameter("@empid",SqlDbType.Int ,4)
                                                     };
           objp[0].Value = branchid;
           objp[1].Value = uiid;
           objp[2].Value = empid;
           ExecuteQuery("SPInsMailingList", objp);
       }
       public void DelMailingList(int empid, int bid, int uiid)
       {
           SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@empid",SqlDbType.Int,4), 
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@uiid",SqlDbType.Int,4)};
           objp[0].Value = empid;
           objp[1].Value = bid;
           objp[2].Value = uiid;
           ExecuteQuery("SpDelMailingList", objp);
       }
       public DataTable GetALLMailingList(int bid)
       {
           SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@bid",SqlDbType.Int,4)};
                 objp[0].Value = bid;
                 return ExecuteTable("SpGetAllMasterMail", objp);
       }
       public DataTable GetALLMailingListDivwise(int cid,int bid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cid", SqlDbType.Int, 4),
                                                      new SqlParameter("@bid", SqlDbType.Int, 4)};
           objp[0].Value = cid;
           objp[1].Value = bid;
           return ExecuteTable("SPGetMailingListDivwise", objp);
       }
       public void UpdMailingList(int empid, int bid, int uiid,int oldempid)
       {
           SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@empid",SqlDbType.Int,4), 
                                                       new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@uiid",SqlDbType.Int,4),
                                                       new SqlParameter("@oldempid",SqlDbType.Int,4)};
           objp[0].Value = empid;
           objp[1].Value = bid;
           objp[2].Value = uiid;
           objp[3].Value = oldempid;
           ExecuteQuery("SPUpdMailingList", objp);
       }
       public DataTable GetMailList4uiid(int empid,int uiid, int bid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                      new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                      new SqlParameter("@bid", SqlDbType.Int, 4)};

           objp[0].Value = empid;
           objp[1].Value = uiid;
           objp[2].Value=bid;
           return ExecuteTable("SPGetMailList4uiid", objp);
       }
    }
}
