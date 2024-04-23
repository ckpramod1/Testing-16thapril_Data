using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class NewCustomerRequest:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public NewCustomerRequest()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertNewCustomer(string customername, string customertype, string address, string location, string country, string zip, string phone, string fax, string managid, string ptc, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, string remarks, string status, DateTime requestedon, int requestedby,int custtypeid)
        {
            //char ctype = CheckCustomerType(customertype);
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@custname",SqlDbType.VarChar,100),
                                                      new SqlParameter("@custtype",SqlDbType.Char,1),        
                                                      new SqlParameter("@address",SqlDbType.VarChar,100), 
                                                      new SqlParameter("@location",SqlDbType.VarChar,50),
                                                      new SqlParameter("@country",SqlDbType.VarChar,50),
                                                      new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                      new SqlParameter("@phone",SqlDbType.VarChar,25),
                                                      new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                      new SqlParameter("@managid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                      new SqlParameter("@status",SqlDbType.Char,1),
                                                      new SqlParameter("@requestedon",SqlDbType.DateTime,8),
                                                      new SqlParameter("@requestedby",SqlDbType.Int,4),
                                                      new SqlParameter("@custtypeid",SqlDbType.Int,4) };

            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = address;
            objp[3].Value = location;
            objp[4].Value = country;
            objp[5].Value = zip;
            objp[6].Value = phone;
            objp[7].Value = fax;
            objp[8].Value = managid;
            objp[9].Value = ptc;
            objp[10].Value = commailid;
            objp[11].Value = expmailid;
            objp[12].Value = impmailid;
            objp[13].Value = finmailid;
            objp[14].Value = comptc;
            objp[15].Value = expptc;
            objp[16].Value = impptc;
            objp[17].Value = finptc;
            objp[18].Value = remarks;
            objp[19].Value = status;
            objp[20].Value = requestedon;
            objp[21].Value = requestedby;
            objp[22].Value = custtypeid;
            ExecuteQuery("SPNewCustomerRequest", objp);
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
        public DataTable GetNewcustdetails(string flag)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@flag", SqlDbType.Char, 1) };
            objp[0].Value = flag;
            return ExecuteTable("SPSelNewCustomer",objp);
        }
        public void UpdateNewCustomer(string customername, string customertype, string address, string location, string country, string zip, string phone, string fax, string managid, string ptc, string commailid, string expmailid, string impmailid, string finmailid, string comptc, string expptc, string impptc, string finptc, string remarks, string status,DateTime requestedon,int requestedby,DateTime approvedon,int approvedby,int custtypeid,int requestid,char flag)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@custname",SqlDbType.VarChar,100),
                                                      new SqlParameter("@custtype",SqlDbType.Char,1),        
                                                      new SqlParameter("@address",SqlDbType.VarChar,100), 
                                                      new SqlParameter("@location",SqlDbType.VarChar,50),
                                                      new SqlParameter("@country",SqlDbType.VarChar,50),
                                                      new SqlParameter("@zip",SqlDbType.VarChar,15),
                                                      new SqlParameter("@phone",SqlDbType.VarChar,25),
                                                      new SqlParameter("@fax",SqlDbType.VarChar,25),
                                                      new SqlParameter("@status",SqlDbType.Char,1),
                                                      new SqlParameter("@managid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@ptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@commailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expmailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impmailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finmailid",SqlDbType.VarChar,50),
                                                      new SqlParameter("@comptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@expptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@impptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@finptc",SqlDbType.VarChar,50),
                                                      new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                      new SqlParameter("@requestedon",SqlDbType.DateTime,8),
                                                      new SqlParameter("@requestedby",SqlDbType.Int,4),
                                                      new SqlParameter("@approvedon",SqlDbType.DateTime,8),
                                                      new SqlParameter("@approvedby",SqlDbType.Int,4),
                                                      new SqlParameter("@custtypeid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@requestid",SqlDbType.TinyInt,1),
                                                      new SqlParameter("@flag",SqlDbType.Char,1)};

            objp[0].Value = customername;
            objp[1].Value = customertype;
            objp[2].Value = address;
            objp[3].Value = location;
            objp[4].Value = country;
            objp[5].Value = zip;
            objp[6].Value = phone;
            objp[7].Value = fax;
            objp[8].Value = status;
            objp[9].Value = managid;
            objp[10].Value = ptc;
            objp[11].Value = commailid;
            objp[12].Value = expmailid;
            objp[13].Value = impmailid;
            objp[14].Value = finmailid;
            objp[15].Value = comptc;
            objp[16].Value = expptc;
            objp[17].Value = impptc;
            objp[18].Value = finptc;
            objp[19].Value = remarks;
            objp[20].Value = requestedon;
            objp[21].Value = requestedby;
            objp[22].Value = approvedon;
            objp[23].Value = approvedby;
            objp[24].Value = custtypeid;
            objp[25].Value = requestid;
            objp[26].Value = flag;
            ExecuteQuery("SPUpdNewCustomer", objp);
        }
    }
}
