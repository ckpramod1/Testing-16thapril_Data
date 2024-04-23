using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class WebMasterCustomerGroup : DBObject
    {
        Masters.MasterPort Portobj = new MasterPort();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public WebMasterCustomerGroup()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsertCustomerDetails(string company, string contactperson, string address, string city, string zip, string phone, string fax, string email)
        {
            int cityid = Portobj.GetNPortid(city);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@gname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,250), 
                                                                                     new SqlParameter("@city",SqlDbType.Int),
                                                                                     new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@groupid",SqlDbType.Int)};

            objp[0].Value = company;
            objp[1].Value = address;
            objp[2].Value = cityid;
            objp[3].Value = zip;
            objp[4].Value = phone;
            objp[5].Value = fax;
            objp[6].Value = email;
            objp[7].Value = contactperson;
            objp[8].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsWebMasterCustGroup", objp, "@groupid");
            //ExecuteQuery("SPInsertMasterCustGroup", objp);
        }

        public DataTable RetrieveCustGroupDetails(int Groupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@groupid",SqlDbType.Int)};

            objp[0].Value = Groupid;

            return ExecuteTable("SPSelwebMasterCustGroupDts", objp);
        }
       
        public DataTable RetrieveMasterCustGroupIDs(int Groupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupid", SqlDbType.Int) };

            objp[0].Value = Groupid;

            return ExecuteTable("SPGetWebMasterCustGroup", objp);
        }

        public int RetrieveCustGroupID(string Company)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100) };

            objp[0].Value = Company;

            return int.Parse(ExecuteReader("SPGetWebMCustGroupID", objp));
        }

        public void UpdCustGroupDetails(string company, int groupid, string contactperson, string address, string city, string zip, string phone, string fax, string email)
        {
            int cityid = Portobj.GetNPortid(city);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@gname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@groupid",SqlDbType.Int),        
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,250), 
                                                                                     new SqlParameter("@city",SqlDbType.Int),
                                                                                     new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50)};

            objp[0].Value = company;
            objp[1].Value = groupid;
            objp[2].Value = address;
            objp[3].Value = cityid;
            objp[4].Value = zip;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = contactperson;
            ExecuteQuery("SPUpdateWebMasterCustGroup", objp);
        }

        public DataTable GetLikeWebCustGroup(string company)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100) };
            objp[0].Value = company;
            return ExecuteTable("SPLikeWebMasterCustGroupName", objp);
        }

        public void UpdateCustomerGroupid(int customerid, int groupid,int status)
        {
            // int custid = GetCustomerid(customername, customertype, city);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customerid",SqlDbType.Int,4),
                                                                                     new SqlParameter("@groupid",SqlDbType.Int),
                                                                                     new SqlParameter("@status",SqlDbType.TinyInt,2) };
            objp[0].Value = customerid;
            objp[1].Value = groupid;
            objp[2].Value = status;

            ExecuteQuery("SPUpdateWebMasterCustGroupid", objp);
        }


    }
}
