using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
   public class MasterCustomerProspective:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterCustomerProspective()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, int landline, int mblisd, string mobile, int faxisd, string faxstd, int fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, string managptc, string managmail, int createdby)
        {
            //  char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                       new SqlParameter("@llisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.Int),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.Int),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                         new SqlParameter("@managmailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@createdby",SqlDbType.VarChar,50)

                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            objp[23].Value = status;
            objp[24].Value = commailid;
            objp[25].Value = expmailid;
            objp[26].Value = impmailid;
            objp[27].Value = finmailid;
            objp[28].Value = comptc;
            objp[29].Value = expptc;
            objp[30].Value = impptc;
            objp[31].Value = finptc;
            objp[32].Value = managptc;
            objp[33].Value = managmail;
            objp[34].Value = createdby;

            ExecuteQuery("SPInsMasterCustomerProspective", objp);

        }
        public void UpdMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, int landline, int mblisd, string mobile, int faxisd, string faxstd, int fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, string managptc, string managmail, int customerid)
        {
            // char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                        new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@customertype", SqlDbType.Char,1),
                                                       new SqlParameter("@unit#", SqlDbType.VarChar,10),
                                                       new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
                                                       new SqlParameter ("@door#",SqlDbType.VarChar,10),
                                                       new SqlParameter ("@street",SqlDbType.VarChar,100),
                                                       new SqlParameter ("@location",SqlDbType.Int),
                                                       new SqlParameter ("@city",SqlDbType.Int),
                                                       new SqlParameter("@district",SqlDbType.Int),
                                                       new SqlParameter("@state",SqlDbType.Int),
                                                       new SqlParameter("@country",SqlDbType.Int),
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,6),
                                                       new SqlParameter("@llisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.Int),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.Int),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                        new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                         new SqlParameter("@managmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int)
                                                       };
            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = unit;
            objp[3].Value = buildingname;
            objp[4].Value = door;
            objp[5].Value = street;
            objp[6].Value = locationid;
            objp[7].Value = cityid;
            objp[8].Value = districtid;
            objp[9].Value = stateid;
            objp[10].Value = countryid;
            objp[11].Value = pincode;
            objp[12].Value = llisd;
            objp[13].Value = llstd;
            objp[14].Value = landline;
            objp[15].Value = mblisd;
            objp[16].Value = mobile;
            objp[17].Value = faxisd;
            objp[18].Value = faxstd;
            objp[19].Value = fax;
            objp[20].Value = email;
            objp[21].Value = panno;
            objp[22].Value = stno;
            objp[23].Value = status;
            objp[24].Value = commailid;
            objp[25].Value = expmailid;
            objp[26].Value = impmailid;
            objp[27].Value = finmailid;
            objp[28].Value = comptc;
            objp[29].Value = expptc;
            objp[30].Value = impptc;
            objp[31].Value = finptc;
            objp[32].Value = managptc;
            objp[33].Value = managmail;
            objp[34].Value = customerid;
            ExecuteQuery("SPUpdMasterCustomerProspective", objp);

        }
       public DataTable GetCustomerName(string customername)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100)
         };
           objp[0].Value = customername;

           return ExecuteTable("SPSelCustomerNameProspective", objp);
       }
       public DataTable GetCustomerDetails(int customerid, string customertype, int locationid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int),
                                                        new SqlParameter("@customertype",SqlDbType.Char,1),
                                                        new SqlParameter("@location",SqlDbType.Int)
         };
           objp[0].Value = customerid;
           objp[1].Value = customertype;
           objp[2].Value = locationid;

           return ExecuteTable("SPSelCustomerDetailsProspective", objp);
       }
       public DataTable GetCustomerDetails4Grid()
       {
           SqlParameter[] objp = new SqlParameter[] { 
         };

           return ExecuteTable("SPSelMasterCustomerProspective4Grid");
       }
       public DataTable GetCustomerNameExist(string customername)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customer", SqlDbType.VarChar, 100) };
           objp[0].Value = customername;

           return ExecuteTable("SPSelCustomerProspectiveNameExist", objp);

       }
       public DataTable SPSelGetCustomerDetails(string customername, int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100),
           new SqlParameter("@customerid", SqlDbType.Int ),
           //new SqlParameter("@type", SqlDbType.Char ,1 )
           };
           objp[0].Value = customername;
           objp[1].Value = customerid;
           //objp[2].Value = type;
           return ExecuteTable("SPSelGetCustomerDetailsProspective", objp);

       }
       public DataTable SPSelLikeLocationWithCity(string locationname, int city)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.VarChar, 100),
           new SqlParameter("@cityport", SqlDbType.Int )};
           objp[0].Value = locationname;
           objp[1].Value = city;

           return ExecuteTable("SPSelLikeLocationWithCity", objp);
       }
       public string GetLocationname(int LocationId)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.Int) };
           objp[0].Value = LocationId;
           return ExecuteReader("SPSelGetLoctionNameId", objp);
       }


       /////bharathi
       public string GetStatename(int StateId)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@stateid", SqlDbType.Int) };
           objp[0].Value = StateId;
           return ExecuteReader("SPSelGetStateNameId", objp);
       }


       public string GetStateDistrictname(int DistrictId)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@districtid", SqlDbType.Int) };
           objp[0].Value = DistrictId;
           return ExecuteReader("SPSelGetDistrictNameId", objp);
       }
    }
}
