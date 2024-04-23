using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterCustomerGroup : DBObject
    {
        Masters.MasterPort Portobj = new MasterPort();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterCustomerGroup()
        {
            Conn = new SqlConnection(DBCS);
        }
        public int InsertCustomerDetails(string company, string contactperson, string address, string city, string zip, string phone, string fax, string email, int location)
        {
            int cityid = Portobj.GetNPortid(city);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@gname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,250), 
                                                                                     new SqlParameter("@city",SqlDbType.Int,4),
                                                                                     new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@groupid",SqlDbType.Int),
                                                                                     new SqlParameter("@location",SqlDbType.Int,4) };

            objp[0].Value = company;
            objp[1].Value = address;
            objp[2].Value = cityid;
            objp[3].Value = zip;
            objp[4].Value = phone;
            objp[5].Value = fax;
            objp[6].Value = email;
            objp[7].Value = contactperson;
            objp[8].Direction = ParameterDirection.Output;
            objp[9].Value = location;
            //return ExecuteQuery("SPInsertMasterCustGroup", objp, "@groupid");
            return ExecuteQuery("SPInsertMasterCustGroupnew", objp, "@groupid");
            //ExecuteQuery("SPInsertMasterCustGroup", objp);

        }

        public DataTable RetrieveCustGroupDetails(int Groupid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@groupid",SqlDbType.Int)};

            objp[0].Value = Groupid;

            return ExecuteTable("SPGetMasterCustGroupDts", objp);

        }
        public DataTable RetrieveMasterCustGroupIDs(int Groupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupid", SqlDbType.Int) };

            objp[0].Value = Groupid;

            return ExecuteTable("SPGetMasterCustGroup", objp);
        }

        public int RetrieveCustGroupID(string Company)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100) };

            objp[0].Value = Company;

            return int.Parse(ExecuteReader("SPGetMCustGroupID", objp));

        }

        public void UpdCustGroupDetails(string company, int groupid, string contactperson, string address, string city, string zip, string phone, string fax, string email,int location)
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
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@location",SqlDbType.Int,4)};

            objp[0].Value = company;
            objp[1].Value = groupid;
            objp[2].Value = address;
            objp[3].Value = cityid;
            objp[4].Value = zip;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = contactperson;
            objp[9].Value = location;
            ExecuteQuery("SPUpdateMasterCustGroupnew", objp);

        }

        public DataTable GetLikeCustGroup(string company)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100) };
            objp[0].Value = company;
            return ExecuteTable("SPLikeMasterCustGroupName", objp);
        }
        public DataTable GetLikeCustGroup4Division(string company,int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1) };
            objp[0].Value = company;
            objp[1].Value = division;
            return ExecuteTable("SPLikeMasterGroupName4division", objp);
        }

        public DataTable GetLikeCustGroup4DivisionNew(string company, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1) };
            objp[0].Value = company;
            objp[1].Value = division;
            return ExecuteTable("SPLikeMasterGroupName4divisionNew", objp);
        }



        public DataTable GetLikePendingApp4CreditApp(string company, int empid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1) };
            objp[0].Value = company;
            objp[1].Value = empid;
            objp[2].Value = division;
            return ExecuteTable("SPPendingApp4CreditApp", objp);
        }

        public DataTable GetLikePendingApp4CreditAppNew(string company, int empid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1) };
            objp[0].Value = company;
            objp[1].Value = empid;
            objp[2].Value = division;
            return ExecuteTable("SPPendingApp4CreditAppNew", objp);
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

            ExecuteQuery("SPUpdateMasterCustGroupid", objp);
        }
        public DataTable RetrieveCustGroupDetails(string strCustGroupName)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100) };

            objp[0].Value = strCustGroupName;

            return ExecuteTable("SPSelCustGroupDtsByName", objp);
        }
        public int GetCustomerGroupID(string groupname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupname", SqlDbType.VarChar, 100) };

            objp[0].Value = groupname;

            return int.Parse(ExecuteReader("SPGetCustomerGroupID", objp));

        }

        //KUMAR
        public DataTable GetLikeCustGroup4DivisionNew(string company, int bid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@division",SqlDbType.TinyInt,1)};
            objp[0].Value = company;
            objp[1].Value = bid;
            objp[2].Value = division;
            return ExecuteTable("SPLikeMasterGroupName4divisionNew", objp);
        }




        public DataTable GetLikePendingApp4CreditAppNew(string company, int empid, int bid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100),
                                                                                     new SqlParameter("@empid",SqlDbType.Int),
                                                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@division",SqlDbType.TinyInt,1) };
            objp[0].Value = company;
            objp[1].Value = empid;
            objp[2].Value = bid;
            objp[3].Value = division;
            return ExecuteTable("SPPendingApp4CreditAppNew", objp);
        }


        //***************************************Elakkiya****************************************

        public DataTable GetIdcusVal(int Groupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@groupid", SqlDbType.Int) };

            objp[0].Value = Groupid;

            return ExecuteTable("SPRetriveAllDtcust", objp);
        }
        public DataTable GetexactCustGroup(string company)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100) };
            objp[0].Value = company;
            return ExecuteTable("SPexactMasterCustGroupName", objp);
        }

        //RajBharath

        public DataTable GetLikeCustGroupForPota(string company)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100) };
            objp[0].Value = company;
            return ExecuteTable("SPLikeMasterCustGroupNameForPota", objp);
        }

        public DataTable GetLikeCustGroup4DivisionNewCredit(string company, int bid, int division)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@gname", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@division",SqlDbType.TinyInt,1)};
            objp[0].Value = company;
            objp[1].Value = bid;
            objp[2].Value = division;
            return ExecuteTable("SPLikeMasterGroupName4divisionCreditCustomer", objp);
        }
        public DataTable SpUpdateGroupidMasterPan(string panno, string panname, int groupid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@panname",SqlDbType.VarChar,50),
                                                       new SqlParameter("@groupid",SqlDbType.Int,1)};
            objp[0].Value = panno;
            objp[1].Value = panname;
            objp[2].Value = groupid;
            return ExecuteTable("Sp_UpdateGroupidMasterPan", objp);
        }
        public DataTable GetAllGrouppan(string panno, string panname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@panname",SqlDbType.VarChar,50)};
                                                     
            objp[0].Value = panno;
            objp[1].Value = panname;

            return ExecuteTable("Sp_GetAllGrouid", objp);
        }
        public DataTable GetAllGrouppan(string panno, string panname, string zip, int city)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@panno", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@panname",SqlDbType.VarChar,50),
                                                       new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                       new SqlParameter("@City",SqlDbType.Int)

            
            };

            objp[0].Value = panno;
            objp[1].Value = panname;
            objp[2].Value = zip;
            objp[3].Value = city;


            return ExecuteTable("Sp_GetAllGrouid", objp);
        }

        public DataTable customerpanidupdate(int customerpanno, string panname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerpanno", SqlDbType.Int),
                                                       new SqlParameter("@panname",SqlDbType.VarChar,50)
                                                     

            
            };

            objp[0].Value = customerpanno;
            objp[1].Value = panname;



            return ExecuteTable("SP_customerpanidupdate", objp);
        }

        public DataTable customerpanidselect(string Panno, string panname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Panno", SqlDbType.VarChar,50),
                                                       new SqlParameter("@panname",SqlDbType.VarChar,50)
                                                     

            
            };

            objp[0].Value = Panno;
            objp[1].Value = panname;



            return ExecuteTable("spupdatemastercustomerpan", objp);
        }

        //

        
 // yuvaraj add by 16-03-2023
        public DataTable customerpanidselects(string Panno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Panno", SqlDbType.VarChar,50),
                                                   
                                                                
            };

            objp[0].Value = Panno;

            return ExecuteTable("spupdatemastercustomerpans", objp);
        }





    }
}
