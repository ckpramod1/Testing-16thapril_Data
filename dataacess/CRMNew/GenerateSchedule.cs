using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.CRMNew
{
    public class GenerateSchedule : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public GenerateSchedule()
        {
            Conn = new SqlConnection(DBCS);
        }


        public DataTable GetLikeCRMCustomer(string customer, int empid, int city)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@customername", SqlDbType.VarChar, 100),
                                                        new SqlParameter("@empid", SqlDbType.Int),
                                                        new SqlParameter("@city", SqlDbType.Int)};
            objp[0].Value = customer;
            objp[1].Value = empid;
            objp[2].Value = city;

            return ExecuteTable("CRMLikeSPSelCustomerName", objp);
        }

        public DataTable CRMGetCustomerSalesPersonWise(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@empid", SqlDbType.Int)  };
           
            objp[0].Value = empid;

            return ExecuteTable("CRMSpGetCustomer4SalesWise", objp);
        }

        public int InsertPcustValSalesWiseSCM(int pcusid, DateTime FlupDate, int callby,DateTime callon)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pcustomerid", SqlDbType.Int),
                                                        new SqlParameter("@followupdatetime",SqlDbType.DateTime),
                                                        new SqlParameter("@calledby",SqlDbType.Int),                                                   
                                                       new SqlParameter("@calledon",SqlDbType.DateTime),                                                     
                                                             new SqlParameter("@crmid",SqlDbType.Int)  };

            objp[0].Value = pcusid;
            objp[1].Value = FlupDate;
            objp[2].Value = callby;      
            objp[3].Value = callon;         
            objp[4].Direction = ParameterDirection.Output;

            return ExecuteQuery("CRMInsertVal4CRmdetails", objp, "@crmid");

        }

        public int InsertPcustmerdetails4CRM(DateTime createdon, int createdby, int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@createdon", SqlDbType.DateTime),
                                                        new SqlParameter("@createdby",SqlDbType.Int),
                                                        new SqlParameter("@customerid",SqlDbType.Int),
 
                                        new SqlParameter("@pcusid",SqlDbType.Int)  };

            objp[0].Value = createdon;
            objp[1].Value = createdby;
            objp[2].Value = customerid;        
            objp[3].Direction = ParameterDirection.Output;

            return ExecuteQuery("CRMInsertValues4Custprosective", objp, "@pcusid");

        }

        public DataTable CheckMcustimer4CRM(int mcustid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@cusid", SqlDbType.Int)                                            
          };

            objp[0].Value = mcustid;

            return ExecuteTable("SPGetCheckCrmMCustomer", objp);
        }

        public DataTable GetLikeportname4CRM(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                           
                                                new SqlParameter("@empid", SqlDbType.Int)  };
            objp[0].Value = empid;
            return ExecuteTable("CRMLikeSPSelPortName", objp);
        }

        public DataTable GerCRMMastercustomerDetails( int customerid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@customerid", SqlDbType.Int)
                                           
                                                 };

            objp[0].Value = customerid;

            return ExecuteTable("CRMSpGetCustomerNew", objp);
        }

        public DataTable GetCRMportnameNew(int city)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@city", SqlDbType.Int)
                                           
                                                 };

            objp[0].Value = city;

            return ExecuteTable("CRMSpGetCityNew", objp);
        }

        public DataTable GetCityDetails4CRM(int empid,int city)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@empid", SqlDbType.Int),
                                            new SqlParameter("@city", SqlDbType.Int)
                                           
                                                 };

            objp[0].Value = empid;
            objp[1].Value = city;
            return ExecuteTable("CRMSpGetCustomer4CityWise", objp);
        }

        public DataTable GetSalespersonCRMExts(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@empid", SqlDbType.Int)                                         
                                                 };
            objp[0].Value = empid;
            return ExecuteTable("SPGetExtsCustCRMSales", objp);
        }

        public DataTable GetChkCRMExtsWithCustname(int customerid,int cityid,string custname)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@cusid", SqlDbType.Int)  ,
                new SqlParameter("@cityid", SqlDbType.Int),
                new SqlParameter("@customername", SqlDbType.VarChar) };
            objp[0].Value = customerid;
            objp[1].Value = cityid;
            objp[2].Value = custname;
            return ExecuteTable("SPGetCheckCrmMCustomerWithName", objp);
        }

        public void UpdMccid(int pcusid, int mccid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        new SqlParameter("@pcusid",SqlDbType.Int),
                                                        new SqlParameter("@Mccusid",SqlDbType.Int)  };

            objp[0].Value = pcusid;
            objp[1].Value = mccid;
            ExecuteQuery("SPUpdMccid", objp);
        }

   
       

        
        
    }
}
