using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterCountry :DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterCountry()
        {
            Conn = new SqlConnection(DBCS);
        }

        //Get countryname based on city 
        public String GetCountryName(string cityname)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@city",SqlDbType.VarChar,50) };
            objp[0].Value = cityname;
            return ExecuteReader("SPCountrynameCityName", objp);
         }

        //Get All Currency.
        public DataTable GetAllCurrency()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPCurrency",objp);
       }

       //Methods For Windows Application.

       //Get All CountryNames
       public DataTable GetAllCountry(string countryname)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                                                      new   SqlParameter("@country",SqlDbType.VarChar,10)};
           objp[0].Value = countryname;
           return ExecuteTable("SPLikeCountry", objp);
       }
        public String GetCountryNamefrmid(string countryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryid", SqlDbType.VarChar, 50) };
            objp[0].Value = countryid;
            return ExecuteReader("SPCountryname", objp);
        }
        //raja-----

        public DataTable GetCountryname(string countryname)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@CountryName", SqlDbType.VarChar, 50) };

            objp[0].Value = countryname;

            return ExecuteTable("selcountryname", objp);
        }
        public DataTable GetCountryname4Auto(string countryname)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@CountryName", SqlDbType.VarChar, 50) };

            objp[0].Value = countryname;

            return ExecuteTable("sp_autocountry", objp);
        }
        public DataTable GetSectorname(string sectorname)
        {

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@sectorname", SqlDbType.VarChar, 50) };

            objp[0].Value = sectorname;

            return ExecuteTable("SPSelSectorName", objp);
        }
        //RajaGuru

        public void MasterCountryInsert(string CountryName, string Currency, string Cents, int ISDcode, int Sectorid, string MRcode, byte[] flag)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@CountryName", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@Currency", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@Cents", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@ISDcode", SqlDbType.TinyInt),
                                                       new SqlParameter("@Sectorid", SqlDbType.Int),
                                                       new SqlParameter("@MRcode", SqlDbType.Char,1),
                                                       new SqlParameter("@Flag", SqlDbType.Image )
                                                       
                                                     
                                                        };

            objp[0].Value = CountryName;
            objp[1].Value = Currency;
            objp[2].Value = Cents;
            objp[3].Value = ISDcode;
            objp[4].Value = Sectorid;
            objp[5].Value = MRcode;
            objp[6].Value = flag;

            ExecuteQuery("sp_MasterInsert", objp);

        }



        public DataTable GetUpdateCountry(string CountryName, string Currency, string Cents, int ISDcode, string MRcode, int Sectorid, byte[] Flag, int countryid)
        {

            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@CountryName", SqlDbType.VarChar, 50),
                                                       new SqlParameter("@Currency", SqlDbType.VarChar, 10),
                                                       new SqlParameter("@Cents", SqlDbType.VarChar, 5),
                                                       new SqlParameter("@ISDcode", SqlDbType.TinyInt),
                                                        new SqlParameter("@MRcode", SqlDbType.Char,1),
                                                       new SqlParameter("@Sectorid", SqlDbType.Int),
                                                       new SqlParameter("@Flag", SqlDbType.Image) ,
                                                    new SqlParameter("@Countryid", SqlDbType.Int )};



            objp[0].Value = CountryName;
            objp[1].Value = Currency;
            objp[2].Value = Cents;
            objp[3].Value = ISDcode;
            objp[4].Value = MRcode;
            objp[5].Value = Sectorid;
            objp[6].Value = Flag;
            objp[7].Value = countryid;



            return ExecuteTable("SPupdate", objp);


        }
        public DataTable GetGridview()
        {
            return ExecuteTable("Getalldetails");
        }

        public DataTable CountryTopGridRow()
        {
            return ExecuteTable("SPCountryTopRow");
        }
        public String GetCountryNamefrmid(int countryid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@countryid", SqlDbType.Int) };
            objp[0].Value = countryid;
            return ExecuteReader("SPCountrynameCId", objp);
        }


        //Arun and Prabha


        public int GetLikeCountryNAme(string cntryname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                 new   SqlParameter("@country",SqlDbType.VarChar,10)};
            objp[0].Value = cntryname;
            // return int.Parse(ExecuteReader("SPGetCRMid", objp));
            return Convert.ToInt32(ExecuteReader("SPGetLikeCountryNAme", objp));
        }
    }
}
