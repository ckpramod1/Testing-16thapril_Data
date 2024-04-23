using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRMNew
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


        //public int InsMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid,
        //   int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd,
        //   string fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc,
        //   string expptc, string impptc, string finptc, string managptc, string managmail, int createdby, string titleceo, string titlech, string titleeh, string titleih,
        //   string titlefh, int updateby, int officetype, string website, string grade, string remarks, int divisionid)
        //{
        //    //  char ctype = CheckCustomerType(customertype);
        //    SqlParameter[] objp = new SqlParameter[] { 

        //                                                new SqlParameter("@customername", SqlDbType.VarChar, 100),
        //                                                new SqlParameter("@customertype", SqlDbType.Char,1),
        //                                                new SqlParameter("@unit#", SqlDbType.VarChar,10),
        //                                                new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
        //                                                new SqlParameter ("@door#",SqlDbType.VarChar,10),
        //                                                new SqlParameter ("@street",SqlDbType.VarChar,100),
        //                                                new SqlParameter ("@location",SqlDbType.Int),
        //                                                new SqlParameter ("@city",SqlDbType.Int),
        //                                                new SqlParameter("@district",SqlDbType.Int),
        //                                                new SqlParameter("@state",SqlDbType.Int),
        //                                                new SqlParameter("@country",SqlDbType.Int),
        //                                                new SqlParameter("@pincode",SqlDbType.VarChar,6),
        //                                                new SqlParameter("@llisd",SqlDbType.TinyInt),
        //                                                new SqlParameter("@llstd",SqlDbType.VarChar,10),
        //                                                new SqlParameter("@landline",SqlDbType.VarChar ,25),
        //                                                new SqlParameter("@mblisd",SqlDbType.TinyInt),
        //                                                new SqlParameter("@mobile",SqlDbType.VarChar,10),
        //                                                new SqlParameter("@faxisd",SqlDbType.TinyInt),
        //                                                new SqlParameter("@faxstd",SqlDbType.VarChar,10),
        //                                                new SqlParameter("@fax",SqlDbType.VarChar ,25),
        //                                                new SqlParameter("@email",SqlDbType.VarChar,100),
        //                                                new SqlParameter("@pan",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@stno",SqlDbType.VarChar,25),
        //                                                new SqlParameter("@status",SqlDbType.Char ,1),
        //                                                new SqlParameter("@commailid",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@expmailid",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@impmailid",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@finmailid",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@comptc",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@expptc",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@impptc",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@finptc",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@managptc",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@managmailid",SqlDbType.VarChar,50),
        //                                                new SqlParameter("@createdby",SqlDbType.Int),
        //                                                new SqlParameter("@titleceo",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@titlech",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@titleeh",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@titleih",SqlDbType.VarChar,5),
        //                                               new SqlParameter("@titlefh",SqlDbType.VarChar,5),
        //                                               new SqlParameter("@updatedby",SqlDbType.Int),
        //                                               new SqlParameter("@officetype",SqlDbType.Int,4),
        //                                              new SqlParameter("@website",SqlDbType.VarChar,100),
        //                                               new SqlParameter("@pcustid",SqlDbType.Int,4),
        //                                               new SqlParameter("@grade",SqlDbType.VarChar,5),
        //                                                new SqlParameter("@remarks",SqlDbType.VarChar,200),
        //                                                new SqlParameter("@companyid",SqlDbType.Int)
        //                                                };
        //    objp[0].Value = customername;
        //    objp[1].Value = customertype;
        //    objp[2].Value = unit;
        //    objp[3].Value = buildingname;
        //    objp[4].Value = door;
        //    objp[5].Value = street;
        //    objp[6].Value = locationid;
        //    objp[7].Value = cityid;
        //    objp[8].Value = districtid;
        //    objp[9].Value = stateid;
        //    objp[10].Value = countryid;
        //    objp[11].Value = pincode;
        //    objp[12].Value = llisd;
        //    objp[13].Value = llstd;
        //    objp[14].Value = landline;
        //    objp[15].Value = mblisd;
        //    objp[16].Value = mobile;
        //    objp[17].Value = faxisd;
        //    objp[18].Value = faxstd;
        //    objp[19].Value = fax;
        //    objp[20].Value = email;
        //    objp[21].Value = panno;
        //    objp[22].Value = stno;
        //    objp[23].Value = status;
        //    objp[24].Value = commailid;
        //    objp[25].Value = expmailid;
        //    objp[26].Value = impmailid;
        //    objp[27].Value = finmailid;
        //    objp[28].Value = comptc;
        //    objp[29].Value = expptc;
        //    objp[30].Value = impptc;
        //    objp[31].Value = finptc;
        //    objp[32].Value = managptc;
        //    objp[33].Value = managmail;
        //    objp[34].Value = createdby;
        //    objp[35].Value = titleceo;
        //    objp[36].Value = titlech;
        //    objp[37].Value = titleeh;
        //    objp[38].Value = titleih;
        //    objp[39].Value = titlefh;
        //    objp[40].Value = updateby;
        //    objp[41].Value = officetype;
        //    objp[42].Value = website;
        //    objp[43].Direction = ParameterDirection.Output;
        //    objp[44].Value = grade;
        //    objp[45].Value = remarks;
        //    objp[46].Value = divisionid;


        //    return ExecuteQuery("SPInsMasterCustomerProspective", objp, "@pcustid");
        //}
        public int InsMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid,
         int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd,
         string fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc,
         string expptc, string impptc, string finptc, string managptc, string managmail, int createdby, string titleceo, string titlech, string titleeh, string titleih,
         string titlefh, int updateby, int officetype, string website, string grade, string remarks, int divisionid, int resourceid)
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
                                                       new SqlParameter("@landline",SqlDbType.VarChar ,25),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar ,25),
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
                                                       new SqlParameter("@createdby",SqlDbType.Int),
                                                       new SqlParameter("@titleceo",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titlech",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleeh",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleih",SqlDbType.VarChar,5),
                                                      new SqlParameter("@titlefh",SqlDbType.VarChar,5),
                                                      new SqlParameter("@updatedby",SqlDbType.Int),
                                                      new SqlParameter("@officetype",SqlDbType.Int,4),
                                                     new SqlParameter("@website",SqlDbType.VarChar,100),
                                                      new SqlParameter("@pcustid",SqlDbType.Int,4),
                                                      new SqlParameter("@grade",SqlDbType.VarChar,5),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,200),
                                                       new SqlParameter("@companyid",SqlDbType.Int),
                                                        new SqlParameter("@Resourceid",SqlDbType.Int)
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
           objp[35].Value = titleceo;
           objp[36].Value = titlech;
           objp[37].Value = titleeh;
           objp[38].Value = titleih;
           objp[39].Value = titlefh;
           objp[40].Value = updateby;
           objp[41].Value = officetype;
           objp[42].Value = website;
           objp[43].Direction = ParameterDirection.Output;
           objp[44].Value = grade;
           objp[45].Value = remarks;
           objp[46].Value = divisionid;
           objp[47].Value = resourceid;

           return ExecuteQuery("SPInsMasterCustomerProspective", objp, "@pcustid");
       }
       //public void UpdMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, string managptc, string managmail, int customerid, string titleceo, string titlech, string titleeh, string titleih, string titlefh, int updateby, int createdby, int officetype, string website, string grade, string remarks, int divisionid)
       //{
       //    // char ctype = CheckCustomerType(customertype);
       //    SqlParameter[] objp = new SqlParameter[] { 
            
       //                                                 new SqlParameter("@customername", SqlDbType.VarChar, 100),
       //                                                new SqlParameter("@customertype", SqlDbType.Char,1),
       //                                                new SqlParameter("@unit#", SqlDbType.VarChar,10),
       //                                                new SqlParameter ("@buildingname",SqlDbType.VarChar,50),
       //                                                new SqlParameter ("@door#",SqlDbType.VarChar,10),
       //                                                new SqlParameter ("@street",SqlDbType.VarChar,100),
       //                                                new SqlParameter ("@location",SqlDbType.Int),
       //                                                new SqlParameter ("@city",SqlDbType.Int),
       //                                                new SqlParameter("@district",SqlDbType.Int),
       //                                                new SqlParameter("@state",SqlDbType.Int),
       //                                                new SqlParameter("@country",SqlDbType.Int),
       //                                                new SqlParameter("@pincode",SqlDbType.VarChar,6),
       //                                                new SqlParameter("@llisd",SqlDbType.TinyInt),
       //                                                new SqlParameter("@llstd",SqlDbType.VarChar,10),
       //                                                new SqlParameter("@landline",SqlDbType.VarChar ,25),
       //                                                new SqlParameter("@mblisd",SqlDbType.TinyInt),
       //                                                new SqlParameter("@mobile",SqlDbType.VarChar,10),
       //                                                new SqlParameter("@faxisd",SqlDbType.TinyInt),
       //                                                new SqlParameter("@faxstd",SqlDbType.VarChar,10),
       //                                                new SqlParameter("@fax",SqlDbType.VarChar ,25),
       //                                                new SqlParameter("@email",SqlDbType.VarChar,100),
       //                                                new SqlParameter("@panno",SqlDbType.VarChar,25),
       //                                                new SqlParameter("@stno",SqlDbType.VarChar,25),
       //                                                new SqlParameter("@status",SqlDbType.Char ,1),
       //                                                new SqlParameter("@commailid",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@expmailid",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@impmailid",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@finmailid",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@comptc",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@expptc",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@impptc",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@finptc",SqlDbType.VarChar,50),
       //                                                 new SqlParameter("@managptc",SqlDbType.VarChar,50),
       //                                                  new SqlParameter("@managmailid",SqlDbType.VarChar,50),
       //                                                new SqlParameter("@customerid",SqlDbType.Int),
       //                                                new SqlParameter("@titleceo",SqlDbType.VarChar,5),
       //                                                new SqlParameter("@titlech",SqlDbType.VarChar,5),
       //                                                new SqlParameter("@titleeh",SqlDbType.VarChar,5),
       //                                                new SqlParameter("@titleih",SqlDbType.VarChar,5),
       //                                               new SqlParameter("@titlefh",SqlDbType.VarChar,5),
       //                                                new SqlParameter("@updatedby",SqlDbType.Int),
       //                                                 new SqlParameter("@createdby",SqlDbType.Int),
       //                                               new SqlParameter("@officetype",SqlDbType.Int,4),
       //                                               new SqlParameter("@website",SqlDbType.VarChar,100),
       //                                               new SqlParameter("@grade",SqlDbType.VarChar,5),
       //                                                new SqlParameter("@remarks",SqlDbType.VarChar,200),
       //                                                new SqlParameter("@companyid",SqlDbType.Int)
       //                                                };
       //    objp[0].Value = customername;
       //    objp[1].Value = customertype;
       //    objp[2].Value = unit;
       //    objp[3].Value = buildingname;
       //    objp[4].Value = door;
       //    objp[5].Value = street;
       //    objp[6].Value = locationid;
       //    objp[7].Value = cityid;
       //    objp[8].Value = districtid;
       //    objp[9].Value = stateid;
       //    objp[10].Value = countryid;
       //    objp[11].Value = pincode;
       //    objp[12].Value = llisd;
       //    objp[13].Value = llstd;
       //    objp[14].Value = landline;
       //    objp[15].Value = mblisd;
       //    objp[16].Value = mobile;
       //    objp[17].Value = faxisd;
       //    objp[18].Value = faxstd;
       //    objp[19].Value = fax;
       //    objp[20].Value = email;
       //    objp[21].Value = panno;
       //    objp[22].Value = stno;
       //    objp[23].Value = status;
       //    objp[24].Value = commailid;
       //    objp[25].Value = expmailid;
       //    objp[26].Value = impmailid;
       //    objp[27].Value = finmailid;
       //    objp[28].Value = comptc;
       //    objp[29].Value = expptc;
       //    objp[30].Value = impptc;
       //    objp[31].Value = finptc;
       //    objp[32].Value = managptc;
       //    objp[33].Value = managmail;
       //    objp[34].Value = customerid;
       //    objp[35].Value = titleceo;
       //    objp[36].Value = titlech;
       //    objp[37].Value = titleeh;
       //    objp[38].Value = titleih;
       //    objp[39].Value = titlefh;
       //    objp[40].Value = updateby;
       //    objp[41].Value = createdby;
       //    objp[42].Value = officetype;
       //    objp[43].Value = website;
       //    objp[44].Value = grade;
       //    objp[45].Value = remarks;
       //    objp[46].Value = divisionid;
       //    ExecuteQuery("SPUpdMasterCustomerProspective", objp);
       //}
       /*public void UpdMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, string managptc, string managmail, int customerid, string titleceo, string titlech, string titleeh, string titleih, string titlefh, int updateby, int createdby, int officetype, string website, string grade, string remarks, int divisionid, int resourceid)
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
                                                       new SqlParameter("@landline",SqlDbType.VarChar ,25),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar ,25),
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
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                       new SqlParameter("@titleceo",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titlech",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleeh",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleih",SqlDbType.VarChar,5),
                                                      new SqlParameter("@titlefh",SqlDbType.VarChar,5),
                                                       new SqlParameter("@updatedby",SqlDbType.Int),
                                                        new SqlParameter("@createdby",SqlDbType.Int),
                                                      new SqlParameter("@officetype",SqlDbType.Int,4),
                                                      new SqlParameter("@website",SqlDbType.VarChar,100),
                                                      new SqlParameter("@grade",SqlDbType.VarChar,5),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,200),
                                                       new SqlParameter("@companyid",SqlDbType.Int),
                                                        new SqlParameter("@Resourceid",SqlDbType.Int)
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
           objp[35].Value = titleceo;
           objp[36].Value = titlech;
           objp[37].Value = titleeh;
           objp[38].Value = titleih;
           objp[39].Value = titlefh;
           objp[40].Value = updateby;
           objp[41].Value = createdby;
           objp[42].Value = officetype;
           objp[43].Value = website;
           objp[44].Value = grade;
           objp[45].Value = remarks;
           objp[46].Value = divisionid;
           objp[47].Value = resourceid;
           ExecuteQuery("SPUpdMasterCustomerProspective", objp);
       }*/




       public void UpdMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, string managptc, string managmail, int customerid, string titleceo, string titlech, string titleeh, string titleih, string titlefh, int updateby, int createdby, int officetype, string website, string grade, string remarks, int divisionid, int resourceid, int salescordin)
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
                                                       new SqlParameter("@landline",SqlDbType.VarChar ,25),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar ,25),
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
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                       new SqlParameter("@titleceo",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titlech",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleeh",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleih",SqlDbType.VarChar,5),
                                                      new SqlParameter("@titlefh",SqlDbType.VarChar,5),
                                                       new SqlParameter("@updatedby",SqlDbType.Int),
                                                        new SqlParameter("@createdby",SqlDbType.Int),
                                                      new SqlParameter("@officetype",SqlDbType.Int,4),
                                                      new SqlParameter("@website",SqlDbType.VarChar,100),
                                                      new SqlParameter("@grade",SqlDbType.VarChar,5),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,200),
                                                       new SqlParameter("@companyid",SqlDbType.Int),
                                                        new SqlParameter("@Resourceid",SqlDbType.Int),
                                                         new SqlParameter("@salescordin",SqlDbType.Int)
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
           objp[35].Value = titleceo;
           objp[36].Value = titlech;
           objp[37].Value = titleeh;
           objp[38].Value = titleih;
           objp[39].Value = titlefh;
           objp[40].Value = updateby;
           objp[41].Value = createdby;
           objp[42].Value = officetype;
           objp[43].Value = website;
           objp[44].Value = grade;
           objp[45].Value = remarks;
           objp[46].Value = divisionid;
           objp[47].Value = resourceid;
           objp[48].Value = salescordin;
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

       //prabha
       public void Insprospectcommodity(int pcustomerid, int commodityid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                new SqlParameter("@commodityid", SqlDbType.Int)
           };
           objp[0].Value = pcustomerid;
           objp[1].Value = commodityid;

           ExecuteQuery("SPInsprospectcommodity", objp);
       }

       public void Insprospectcountry(int pcustomerid, int countryid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                new SqlParameter("@countryid", SqlDbType.Int)
           };
           objp[0].Value = pcustomerid;
           objp[1].Value = countryid;

           ExecuteQuery("SPInsprospectcountry", objp);
       }

       public DataTable GetCommodity(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pcustomerid", SqlDbType.Int )
           };
           objp[0].Value = customerid;

           return ExecuteTable("SPGetCommodity", objp);
       }

       public DataTable GetProspectCountry(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pcustomerid", SqlDbType.Int )
           };
           objp[0].Value = customerid;

           return ExecuteTable("SPGetProspectCountry", objp);
       }

       
       public void DelCommodity(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pcustomerid", SqlDbType.Int) };
           objp[0].Value = customerid;
           ExecuteQuery("SPdelComm", objp);
       }

       public void Delcountry(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@pcustomerid", SqlDbType.Int) };
           objp[0].Value = customerid;
           ExecuteQuery("SPdelCountry", objp);
       }


       public int GETCommodityid(string comm)
       {
           int sales;
           SqlParameter[] objp = new SqlParameter[] { 
                                    new SqlParameter("@comm", SqlDbType.VarChar, 500)
           };
           objp[0].Value = comm;

           return sales = int.Parse(ExecuteReader("SPGETCommodityid", objp));
       }
       public int GETCountryid(string comm)
       {
           int sales;
           SqlParameter[] objp = new SqlParameter[] { 
                                    new SqlParameter("@comm", SqlDbType.VarChar, 500)
           };
           objp[0].Value = comm;

           return sales = int.Parse(ExecuteReader("SPGETCountryid", objp));
       }       

       public string GetCustomerProspectname(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
           objp[0].Value = customerid;
           return ExecuteReader("SPCustomerprospectnameCId", objp);
       }
       //arun

       public string GetFreetext(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int, 4) };
           objp[0].Value = customerid;
           return ExecuteReader("SPGetFreetext", objp);
       }

       public void CustTeleCast(int CustID, string Pretext)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int),
                                                      new SqlParameter("@freetext",SqlDbType.Text)};
           objp[0].Value = CustID;
           objp[1].Value = Pretext;
           ExecuteQuery("SPGetInsQuery", objp);
       }
       public DataTable GetCrmCustNameNew(int empid)
       {
           SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid", SqlDbType.Int)
           };
          
           objp[0].Value = empid;
          
           return ExecuteTable("SPGetrMasterCustProResNew", objp);
       }

       public DataTable GetrMasterCustProResNewDate(int empid, DateTime fromdate, DateTime todate)
       {
           SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid", SqlDbType.Int),
                new SqlParameter("@fromdate", SqlDbType.DateTime ),
                new SqlParameter("@todate", SqlDbType.DateTime)
           };

           objp[0].Value = empid;
           objp[1].Value = fromdate;
           objp[2].Value = todate;

           return ExecuteTable("SPGetrMasterCustProResNewDate", objp);
       }

       public int getcustomerprospectivelist()
       {
           int count;
           return count = int.Parse(ExecuteReader("spgetcustomerprospectivelist"));
       }

       public DataTable GetPortnameNew()
        {

            return ExecuteTable("SPGetPortNameNew");
        }



       //Sinosh
       public DataTable GetPortnameNewcity()
       {

           return ExecuteTable("SPGetPortNameNewcity");
       }
        public DataTable GetCountryNew()
        {

            return ExecuteTable("SPGetCountryNew");
        }

        public DataTable GetCommdityNew()
        {

            return ExecuteTable("SPGetCommedityNew");
        }
        
        public DataTable GetGradeNew()
        {

            return ExecuteTable("SPgetCustomerGrade");
        }
        
        public DataTable GetTeleCalDetails(int type,int commdityid,int productid,int custid,string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                new SqlParameter("@type", SqlDbType.Int),
                                                new SqlParameter("@commodityid", SqlDbType.Int),
                                                new SqlParameter("@productid", SqlDbType.Int),
                                                 new SqlParameter("@customerid", SqlDbType.Int),
                                                 new SqlParameter("@remarks", SqlDbType.VarChar,2000)
           };
            objp[0].Value = type;
            objp[1].Value = commdityid;
            objp[2].Value = productid;
            objp[3].Value = custid;
            objp[4].Value = remarks;
            return ExecuteTable("SPGetTeleCallDetailsNew", objp);
        }

        public DataTable GetTeleCalDetailsFilterTC(int empid, int commodityid, int productid, int customerid, string remarks, int cityid, int countryid, string grade, string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                 new SqlParameter("@empid", SqlDbType.Int),
                                                 new SqlParameter("@commodityid", SqlDbType.Int),
                                                 new SqlParameter("@productid", SqlDbType.Int),
                                                 new SqlParameter("@customerid", SqlDbType.Int),
                                                 new SqlParameter("@remarks", SqlDbType.VarChar,2000),
                                                 new SqlParameter("@cityid", SqlDbType.Int),
                                                 new SqlParameter("@countryid", SqlDbType.Int),
                                                 new SqlParameter("@grade", SqlDbType.VarChar,30),
                                                 new SqlParameter("@pincode", SqlDbType.VarChar,15)
           };
            objp[0].Value = empid;
            objp[1].Value = commodityid;
            objp[2].Value = productid;
            objp[3].Value = customerid;
            objp[4].Value = remarks;
            objp[5].Value = cityid;
            objp[6].Value = countryid;
            objp[7].Value = grade;
            objp[8].Value = pincode;

            return ExecuteTable("SPGetTeleCallDetailsTC", objp);
        }

        public DataTable GetTeleCalDetailsFilterAC(int empid, int commodityid, int productid, int customerid, string remarks, int cityid, int countryid, string grade, string pincode)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                 new SqlParameter("@empid", SqlDbType.Int),
                                                 new SqlParameter("@commodityid", SqlDbType.Int),
                                                 new SqlParameter("@productid", SqlDbType.Int),
                                                 new SqlParameter("@customerid", SqlDbType.Int),
                                                 new SqlParameter("@remarks", SqlDbType.VarChar,2000),
                                                 new SqlParameter("@cityid", SqlDbType.Int),
                                                 new SqlParameter("@countryid", SqlDbType.Int),
                                                 new SqlParameter("@grade", SqlDbType.VarChar,30),
                                                 new SqlParameter("@pincode", SqlDbType.VarChar,15)
           };
            objp[0].Value = empid;
            objp[1].Value = commodityid;
            objp[2].Value = productid;
            objp[3].Value = customerid;
            objp[4].Value = remarks;
            objp[5].Value = cityid;
            objp[6].Value = countryid;
            objp[7].Value = grade;
            objp[8].Value = pincode;

            return ExecuteTable("SPGetTeleCallDetailsAC", objp);
        }
        
        public int GetLikeCommodityNAme(string commodityname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                 new   SqlParameter("@commodity",SqlDbType.VarChar,300)};
            objp[0].Value = commodityname;

            return Convert.ToInt32(ExecuteReader("SPGetLikeCommodityNAme", objp));
        }

        public DataTable GetLikeRemarksNew(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@remarks ",SqlDbType.VarChar,2000)
                        };
            objp[0].Value = empname;
            return ExecuteTable("SPGetRemarksNew", objp);
        }
       
        public DataTable GetTeleCallEntryDetails()
        {
            return ExecuteTable("SPGetKeyPersonCountDetails");
        }

        public DataTable UPdateTeleCallDetails(int customerid, int TelecalId)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            
                                                       new SqlParameter("@customerid ", SqlDbType.Int),
                                                       new SqlParameter("@telecallerid", SqlDbType.Int)
           };
            objp[0].Value = customerid;
            objp[1].Value = TelecalId;

            return ExecuteTable("SPUpdTeleAssinCall", objp);
        }


       public DataTable SellocationnameNEWpincodeFilter()
      {
          return ExecuteTable("SPSellocationnameNEWpincodeFilter");
      }

       public void DelFreetext(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
           objp[0].Value = customerid;
           ExecuteQuery("SPDelFreetext", objp);
       }


       // Dinesh
       public DataTable GetTeleCalDetailsFilterFU(int empid, int commodityid, int productid, int customerid, string remarks, int cityid, int countryid, string grade, string pincode)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                 new SqlParameter("@empid", SqlDbType.Int),
                                                 new SqlParameter("@commodityid", SqlDbType.Int),
                                                 new SqlParameter("@productid", SqlDbType.Int),
                                                 new SqlParameter("@customerid", SqlDbType.Int),
                                                 new SqlParameter("@remarks", SqlDbType.VarChar,2000),
                                                 new SqlParameter("@cityid", SqlDbType.Int),
                                                 new SqlParameter("@countryid", SqlDbType.Int),
                                                 new SqlParameter("@grade", SqlDbType.VarChar,30),
                                                 new SqlParameter("@pincode", SqlDbType.VarChar,15)
           };
           objp[0].Value = empid;
           objp[1].Value = commodityid;
           objp[2].Value = productid;
           objp[3].Value = customerid;
           objp[4].Value = remarks;
           objp[5].Value = cityid;
           objp[6].Value = countryid;
           objp[7].Value = grade;
           objp[8].Value = pincode;

           return ExecuteTable("SPGetTeleCallDetailsTCforfollow", objp);
       } 




       //Dinesh

       public int InsMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid,
         int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd,
         string fax, string email, string panno, string stno, char status, string commailid, string expmailid, string impmailid, string finmailid, string comptc,
         string expptc, string impptc, string finptc, string managptc, string managmail, int createdby, string titleceo, string titlech, string titleeh, string titleih,
         string titlefh, int updateby, int officetype, string website, string grade, string remarks, int divisionid, int resourceid, int salescordin)
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
                                                       new SqlParameter("@landline",SqlDbType.VarChar ,25),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar ,25),
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
                                                       new SqlParameter("@createdby",SqlDbType.Int),
                                                       new SqlParameter("@titleceo",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titlech",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleeh",SqlDbType.VarChar,5),
                                                       new SqlParameter("@titleih",SqlDbType.VarChar,5),
                                                      new SqlParameter("@titlefh",SqlDbType.VarChar,5),
                                                      new SqlParameter("@updatedby",SqlDbType.Int),
                                                      new SqlParameter("@officetype",SqlDbType.Int,4),
                                                     new SqlParameter("@website",SqlDbType.VarChar,100),
                                                      new SqlParameter("@pcustid",SqlDbType.Int,4),
                                                      new SqlParameter("@grade",SqlDbType.VarChar,5),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,200),
                                                       new SqlParameter("@companyid",SqlDbType.Int),
                                                        new SqlParameter("@Resourceid",SqlDbType.Int),
                                                        new SqlParameter("@salescordin",SqlDbType.Int)
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
           objp[35].Value = titleceo;
           objp[36].Value = titlech;
           objp[37].Value = titleeh;
           objp[38].Value = titleih;
           objp[39].Value = titlefh;
           objp[40].Value = updateby;
           objp[41].Value = officetype;
           objp[42].Value = website;
           objp[43].Direction = ParameterDirection.Output;
           objp[44].Value = grade;
           objp[45].Value = remarks;
           objp[46].Value = divisionid;
           objp[47].Value = resourceid;
           objp[48].Value = salescordin;
           return ExecuteQuery("SPInsMasterCustomerProspective", objp, "@pcustid");
       }


       public DataTable GetProspectiveCustomerdetails(int customerid)
       {
           SqlParameter[] objp = new SqlParameter[] {


                                                       new SqlParameter("@customerid", SqlDbType.Int)
           };
           objp[0].Value = customerid;


           return ExecuteTable("Get_ProspectiveCustomerdetails", objp);
       }

    }
}
