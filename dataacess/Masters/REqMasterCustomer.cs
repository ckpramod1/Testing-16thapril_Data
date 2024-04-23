using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess.Masters
{
    public class REqMasterCustomer : DBObject
    {
        Masters.MasterPort Portobj = new MasterPort();
        Masters.MasterCustomer CusObj = new MasterCustomer();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public REqMasterCustomer()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertReqCustomerDetails(string customername, string customertype, string contactperson, string address, string city, string zip, string phone, string fax, string email, string commail, string expmail, string impmail, string finmail, double tds, string comptc, string expptc, string impptc, string finptc)
        {
            char ctype = CusObj.CheckCustomerType(customertype);
            int cityid = Portobj.GetNPortid(city);
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                      new SqlParameter("@customertype",SqlDbType.Char,1),        
                                                      new SqlParameter("@address",SqlDbType.VarChar,100), 
                                                      new SqlParameter("@city",SqlDbType.Int),
                                                      new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                      new SqlParameter("@phone",SqlDbType.VarChar,25),
                                                      new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                      new SqlParameter("@email",SqlDbType.VarChar,50), 
                                                      new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@commail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@tds",SqlDbType.Real,4) ,
                                                      new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finptc",SqlDbType.VarChar,50)}
                                                     ;

            objp[0].Value = customername;
            objp[1].Value = ctype;
            objp[2].Value = address;
            objp[3].Value = cityid;
            objp[4].Value = zip;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = contactperson;
            objp[9].Value = commail;
            objp[10].Value = expmail;
            objp[11].Value = impmail;
            objp[12].Value = finmail;
            objp[13].Value = tds;
            objp[14].Value = comptc;
            objp[15].Value = expptc;
            objp[16].Value = impptc;
            objp[17].Value = finptc;
            ExecuteQuery("SPInsREQCustomerDetails", objp);
        }

        public void UpdateReqCustomerDetails(int customerid, string customername, string customertype, string address, string city, string zip, string phone, string fax, string email, string ptc, string commail, string expmail, string impmail, string finmail, double tds, string comptc, string expptc, string impptc, string finptc)
        {
            char ctype = CusObj.CheckCustomerType(customertype);
            int cityid = Portobj.GetNPortid(city);
            // int custid = GetCustomerid(customername, customertype, city);
            SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                      new SqlParameter("@customertype",SqlDbType.Char,1),        
                                                      new SqlParameter("@address",SqlDbType.VarChar,100), 
                                                      new SqlParameter("@city",SqlDbType.Int),
                                                      new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                      new SqlParameter("@phone",SqlDbType.VarChar,25),
                                                      new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                      new SqlParameter("@email",SqlDbType.VarChar,50), 
                                                      new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@customerid",SqlDbType.Int,4),
                                                      new SqlParameter("@commail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finmail",SqlDbType.VarChar,50),
                                                      new SqlParameter("@tds",SqlDbType.Real,4),
                                                      new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finptc",SqlDbType.VarChar,50)
                                                    };
            objp[0].Value = customername;
            objp[1].Value = ctype;
            objp[2].Value = address;
            objp[3].Value = cityid;
            objp[4].Value = zip;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = ptc;
            objp[9].Value = customerid;
            objp[10].Value = commail;
            objp[11].Value = expmail;
            objp[12].Value = impmail;
            objp[13].Value = finmail;
            objp[14].Value = tds;
            objp[15].Value = comptc;
            objp[16].Value = expptc;
            objp[17].Value = impptc;
            objp[18].Value = finptc;
            ExecuteQuery("SPUpdReqCustomerDetails", objp);
        }


        public DataTable getREQMasterCustomer()
        {
            SqlParameter[] objp = new SqlParameter[]
            {

            };
            return ExecuteTable("SPGetREQMasterCustomer", objp);
        }
        public DataTable getOtherReqCustomerDtls(int cusid, string cusname, string custpye)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@cusid",SqlDbType.Int,4),
                new SqlParameter("@cusname",SqlDbType.VarChar,100),
                new SqlParameter("@custpye",SqlDbType.VarChar,1)
            };
            objp[0].Value = cusid;
            objp[1].Value = cusname;
            objp[2].Value = custpye;
            return ExecuteTable("SPGetOtherREQCusDtls", objp);
        }
        public void UpdTransinReqCus(int cusid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@cusid",SqlDbType.Int,4)
            };
            objp[0].Value = cusid;
            ExecuteQuery("SPUpdTransferinReqCus", objp);
        }
        //public DataTable GetLikeCustomerAllreq(string customername)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
        //    objp[0].Value = customername;
        //    return ExecuteTable("SPLikeCustomerAllreq", objp);
        //}
        public DataTable RetrieveCustomerDetails(string customername, string customertype, string location)
        {
            char ctype = CheckCustomerType(customertype);
            int locationid = Portobj.GetNPortid(location);
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@customertype",SqlDbType.Char,1),        
                                                                                     new SqlParameter("@customername",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@city",SqlDbType.Int)};

            objp[0].Value = ctype;
            objp[1].Value = customername;
            objp[2].Value = locationid;

            return ExecuteTable("SPSelCustomerDetailsreq", objp);

        }
        public char CheckCustomerType(string customertype)
        {
            switch (customertype)
            {
                case ("Shipper"):
                    return 'C';

                case ("Consignee"):
                    return 'C';

                case ("Notify Party"):
                    return 'C';

                case ("Agent / Principal"):
                    return 'P';

                case ("CHA / CNF"):
                    return 'C';

                case ("Carrier / Airliner / MLO / Freight Forwarder"):
                    return 'C';

                case ("Transporter"):
                    return 'C';

                case ("Others"):
                    return 'C';

                case ("Counter Part"):
                    return 'C';

                case ("CFS"):
                    return 'C';

                case ("Warehouse"):
                    return 'C';

                default:
                    return 'C';
            }
        }
        //bharathi
        //bharathi
        public int InsReqMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int createdby, string managmail, string managptc, int tds)
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
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar,25),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@pan",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                      // new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                        new SqlParameter("@createdby",SqlDbType.VarChar,50),
                                                             new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int ),
                                                                 new SqlParameter("@customerid",SqlDbType.Int )

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
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = createdby;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            objp[35].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsReqMasterCustomer", objp, "@customerid");
        }
        public void UpdReqMasterCustomer(string customername, string customertype, string unit, string buildingname, string door, string street, int locationid, int cityid, int districtid, int stateid, int countryid, string pincode, int llisd, string llstd, string landline, int mblisd, string mobile, int faxisd, string faxstd, string fax, string email, string panno, string stno, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, int customerid, string managmail, string managptc, int tds)
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
                                                       new SqlParameter("@pincode",SqlDbType.VarChar,15),
                                                       new SqlParameter("@llisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@llstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@landline",SqlDbType.VarChar ,25),
                                                       new SqlParameter("@mblisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@mobile",SqlDbType.VarChar,10),
                                                       new SqlParameter("@faxisd",SqlDbType.TinyInt),
                                                       new SqlParameter("@faxstd",SqlDbType.VarChar,10),
                                                       new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                       new SqlParameter("@email",SqlDbType.VarChar,100),
                                                       new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                       new SqlParameter("@stno",SqlDbType.VarChar,25),
                                                     //  new SqlParameter("@status",SqlDbType.Char ,1),
                                                       new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                       new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                       new SqlParameter("@customerid",SqlDbType.Int),
                                                        new SqlParameter("@managmail",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@managptc",SqlDbType.VarChar,50),
                                                                  new SqlParameter("@tds",SqlDbType.Int )
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
            // objp[23].Value = status;
            objp[23].Value = commailid;
            objp[24].Value = expmailid;
            objp[25].Value = impmailid;
            objp[26].Value = finmailid;
            objp[27].Value = comptc;
            objp[28].Value = expptc;
            objp[29].Value = impptc;
            objp[30].Value = finptc;
            objp[31].Value = customerid;
            objp[32].Value = managmail;
            objp[33].Value = managptc;
            objp[34].Value = tds;
            ExecuteQuery("SPUpdreqMasterCustomer", objp);

        }

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
        public string GetLocationname(int LocationId)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.Int) };
            objp[0].Value = LocationId;
            return ExecuteReader("SPSelGetLoctionNameId", objp);
        }

        public void SPUpdReqCustomerReject(int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = customerid;
            ExecuteReader("SPUpdReqCustomerReject", objp);
        }

        public int SPGetReqCustomeridfromname(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            //ExecuteReader("SPGetReqCustomeridfromname", objp);
            return int.Parse(ExecuteReader("SPGetReqCustomeridfromname", objp));
        }
        //20/08/2015
        public int spselexistreqcustomer(string customername, int city, string customertype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcustomer", SqlDbType.VarChar, 100),
            new SqlParameter("@port", SqlDbType.Int ),
            new SqlParameter("@type", SqlDbType.VarChar, 1)};
            objp[0].Value = customername;
            objp[1].Value = city;
            objp[2].Value = customertype;
            //ExecuteReader("SPGetReqCustomeridfromname", objp);
            return int.Parse(ExecuteReader("spselexistreqcustomer", objp));
        }

        //Raj


        public DataTable GetLikeCustomerAllreq(string customername)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtCustomer", SqlDbType.VarChar, 100) };
            objp[0].Value = customername;
            return ExecuteTable("SPLikeCustomerAllreq", objp);
        }

        public DataTable SPrequestCustomerDetailAll(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@custid", SqlDbType.Int) };
            objp[0].Value = custid;

            return ExecuteTable("SPLikeCustomerDetailAllreqcustomer", objp);
        }

    }
}
