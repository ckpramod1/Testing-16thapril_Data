using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public  class MasterCompany:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public MasterCompany()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetPortDetails(string locationname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@location", SqlDbType.VarChar, 50) };
            objp[0].Value = locationname;

            return ExecuteTable("SPSelPortDetails4Company", objp);
        }
        public DataTable GetBankDetails(string bankname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bankname", SqlDbType.VarChar, 50) };
            objp[0].Value = bankname;

            return ExecuteTable("SPSelBankName4Company", objp);
        }
        public void companyinsert(string divisionname, string unit, string bname, string door, string street, int locationid, string pincode, int stateid, int countryid, int pisd, string pstd, string phone, int fisd, string fstd, string fax, string email, string panno, string stno, string tanno, string pfno, string esino, string currency, string cents, int dei, string dateformat, DateTime fyfrom, DateTime fyto, int bank, string bankaddress, string acno, string swiftcode, string carrno, byte[] dlogo, int portid,string ifsccode, string actype)
        {
            SqlParameter[] obj = new SqlParameter[] {
                                                               new SqlParameter("@divisionname", SqlDbType.Char, 100),
                                                               new SqlParameter("@unit", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@bname", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@door", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@street", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@locationid",SqlDbType.Int),
                                                               new SqlParameter("@pincode", SqlDbType.VarChar, 6),
                                                               new SqlParameter("@stateid",SqlDbType.Int),
                                                               new SqlParameter("@countryid",SqlDbType.Int),
                                                               new SqlParameter("@pisd", SqlDbType.TinyInt),
                                                               new SqlParameter("@pstd", SqlDbType.VarChar, 10),
                                                               new SqlParameter("@phone", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@fisd", SqlDbType.TinyInt),
                                                               new SqlParameter("@fstd", SqlDbType.VarChar, 10),
                                                               new SqlParameter("@fax", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@email", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@panno", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@stno", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@tan", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@pf", SqlDbType.VarChar, 20),
                                                               new SqlParameter("@esi", SqlDbType.VarChar, 20),
                                                               new SqlParameter("@curr", SqlDbType.VarChar, 10),
                                                               new SqlParameter("@paise", SqlDbType.VarChar, 5),
                                                               new SqlParameter("@decimal", SqlDbType.TinyInt),
                                                               new SqlParameter("@dateformat", SqlDbType.VarChar, 15),
                                                               new SqlParameter("@fyfrom", SqlDbType.DateTime),
                                                               new SqlParameter("@fyto", SqlDbType.DateTime),
                                                               new SqlParameter("@bank",SqlDbType.Int),
                                                               new SqlParameter("@address",SqlDbType.VarChar, 100),
                                                               new SqlParameter("@ac", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@swiftcode", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@carno", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@dlogo", SqlDbType.Image ),                                                               
                                                               new SqlParameter("@portid",SqlDbType.Int),
                                                               new SqlParameter("@ifsc",SqlDbType.VarChar, 11),
                                                                 new SqlParameter("@actype", SqlDbType.VarChar, 25)
                                                        };
            obj[0].Value = divisionname;
            obj[1].Value = unit;
            obj[2].Value = bname;
            obj[3].Value = door;
            obj[4].Value = street;
            obj[5].Value = locationid;
            obj[6].Value = pincode;
            obj[7].Value = stateid;
            obj[8].Value = countryid;
            obj[9].Value = pisd;
            obj[10].Value = pstd;
            obj[11].Value = phone;
            obj[12].Value = fisd;
            obj[13].Value = fstd;
            obj[14].Value = fax;
            obj[15].Value = email;
            obj[16].Value = panno;
            obj[17].Value = stno;
            obj[18].Value = tanno;
            obj[19].Value = pfno;
            obj[20].Value = esino;
            obj[21].Value = currency;
            obj[22].Value = cents;
            obj[23].Value = dei;
            obj[24].Value = dateformat;
            obj[25].Value = fyfrom;
            obj[26].Value = fyto;
            obj[27].Value = bank;
            obj[28].Value = bankaddress;
            obj[29].Value = acno;
            obj[30].Value = swiftcode;
            obj[31].Value = carrno;
            obj[32].Value = dlogo;
            obj[33].Value = portid;
            obj[34].Value = ifsccode;
            obj[35].Value = actype;

            ExecuteQuery("SPInsertCompanyVal", obj);

        }

        public DataTable GetLikeDivision(string divionname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                     new SqlParameter("@divisionname", SqlDbType.VarChar, 100) 
                                                   };
            objp[0].Value = divionname;
            return ExecuteTable("SPSelLikeDivision", objp);
        }
        public DataTable GetCompanyDetails(int divionid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                     new SqlParameter("@divisionid", SqlDbType.Int) 
                                                   };
            objp[0].Value = divionid;
            return ExecuteTable("SPSelMasterCompanyDetails", objp);
        }

        public void UpdateCompany(string divisionname, string unit, string bname, string door, string street, int locationid, string pincode, int stateid, int countryid, int pisd, string pstd, string phone, string fax, string fisd, string fstd, string email, string panno, string stno, string tanno, string pfno, string esino, string currency, string cents, int dei, string dateformat, DateTime fyfrom, DateTime fyto, int bank, string bankaddress, string acno, string swiftcode, string carrno, byte[] dlogo, int portid, int divisionid, string ifsccode, string actype)
        {
            SqlParameter[] obj = new SqlParameter[] {
                                                              
                                                               new SqlParameter("@divisionname", SqlDbType.Char, 100),
                                                               new SqlParameter("@unit", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@bname", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@door", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@street", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@locationid",SqlDbType.Int),
                                                               new SqlParameter("@pincode", SqlDbType.VarChar, 6),
                                                               new SqlParameter("@stateid",SqlDbType.Int),
                                                               new SqlParameter("@countryid",SqlDbType.Int),
                                                               new SqlParameter("@pisd", SqlDbType.TinyInt),
                                                               new SqlParameter("@pstd", SqlDbType.VarChar, 10),
                                                               new SqlParameter("@phone", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@fisd", SqlDbType.TinyInt),
                                                               new SqlParameter("@fstd", SqlDbType.VarChar, 10),
                                                               new SqlParameter("@fax", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@email", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@panno", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@stno", SqlDbType.VarChar, 50),
                                                               new SqlParameter("@tan", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@pf", SqlDbType.VarChar, 20),
                                                               new SqlParameter("@esi", SqlDbType.VarChar, 20),
                                                               new SqlParameter("@curr", SqlDbType.VarChar, 10),
                                                               new SqlParameter("@paise", SqlDbType.VarChar, 5),
                                                               new SqlParameter("@decimal", SqlDbType.TinyInt),
                                                               new SqlParameter("@dateformat", SqlDbType.VarChar, 15),
                                                               new SqlParameter("@fyfrom", SqlDbType.DateTime),
                                                               new SqlParameter("@fyto", SqlDbType.DateTime),
                                                               new SqlParameter("@bank",SqlDbType.Int),
                                                               new SqlParameter("@address",SqlDbType.VarChar, 100),
                                                               new SqlParameter("@ac", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@swiftcode", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@carno", SqlDbType.VarChar, 25),
                                                               new SqlParameter("@dlogo", SqlDbType.Image ),                                                               
                                                               new SqlParameter("@portid",SqlDbType.Int),                             
                                                               new SqlParameter("@divisionid",SqlDbType.Int),
                                                                   new SqlParameter("@ifsc",SqlDbType.VarChar, 11),
                                                                   new SqlParameter("@actype", SqlDbType.VarChar, 25)
                                                        };

            obj[0].Value = divisionname;
            obj[1].Value = unit;
            obj[2].Value = bname;
            obj[3].Value = door;
            obj[4].Value = street;
            obj[5].Value = locationid;
            obj[6].Value = pincode;
            obj[7].Value = stateid;
            obj[8].Value = countryid;
            obj[9].Value = pisd;
            obj[10].Value = pstd;
            obj[11].Value = phone;
            obj[12].Value = fisd;
            obj[13].Value = fstd;
            obj[14].Value = fax;
            obj[15].Value = email;
            obj[16].Value = panno;
            obj[17].Value = stno;
            obj[18].Value = tanno;
            obj[19].Value = pfno;
            obj[20].Value = esino;
            obj[21].Value = currency;
            obj[22].Value = cents;
            obj[23].Value = dei;
            obj[24].Value = dateformat;
            obj[25].Value = fyfrom;
            obj[26].Value = fyto;
            obj[27].Value = bank;
            obj[28].Value = bankaddress;
            obj[29].Value = acno;
            obj[30].Value = swiftcode;
            obj[31].Value = carrno;
            obj[32].Value = dlogo;
            obj[33].Value = portid;
            obj[34].Value = divisionid;
            obj[35].Value = ifsccode;
            obj[36].Value = actype;


            ExecuteQuery("SPUpdateCompany", obj);

        }
        public void CompanyDelete(int divisionid)
        {
            SqlParameter[] obj = new SqlParameter[]{
                                                  new SqlParameter("@divisionid", SqlDbType.Int)
                                                 };
            obj[0].Value = divisionid;

            ExecuteQuery("SPCompanyDelete", obj);
        }
        //[SPSelLocation4Company](@locationid int)

        public DataTable SelectLocation4company(int locationid)
        {
            SqlParameter[] obj = new SqlParameter[]{new SqlParameter("@locationid", SqlDbType.Int)  };
            obj[0].Value = locationid;

            return ExecuteTable("SPSelLocation4Company", obj);
        }

        

    }
}
