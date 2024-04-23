using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Masters
{
    public class Carrier : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public Carrier()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsertMasterCarrierNew(string carriercode, string Carriername, string SCACcode)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                                                   
                                                                                     new SqlParameter("@CarrierCode",SqlDbType.VarChar,300),        
                                                                                     new SqlParameter("@CarrierName",SqlDbType.VarChar,300), 
                                                                                     new SqlParameter("@SCACcode",SqlDbType.VarChar,300),
                                                                                   new SqlParameter("@Carrierid",SqlDbType.Int)};

            objp[0].Value = carriercode;
            objp[1].Value = Carriername;
            objp[2].Value = SCACcode;
            objp[3].Direction = ParameterDirection.Output;
            return ExecuteQuery("SPInsForCarrierDetailsNew", objp, "@Carrierid");

        }

        public void UpdateMasterCarriernew( int carrierid,string carriercode, string Carriername, string SCACcode)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                                                   
                                                                                     new SqlParameter("@CarrierCode",SqlDbType.VarChar,300),        
                                                                                     new SqlParameter("@CarrierName",SqlDbType.VarChar,300), 
                                                                                     new SqlParameter("@SCACcode",SqlDbType.VarChar,300),
                                                                                   new SqlParameter("@Carrierid",SqlDbType.Int)};

            objp[0].Value = carriercode;
            objp[1].Value = Carriername;
            objp[2].Value = SCACcode;
            objp[3].Value = carrierid;
            ExecuteQuery("SPUpdateForCarrierDetailsNew", objp);
        }


        public DataTable RetrivemastercarrierDetails(int carrierid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                          new SqlParameter("@Carrierid",SqlDbType.Int)};
            objp[0].Value = carrierid;

            return ExecuteTable("SPRetivecarrierDetailsForNew", objp);
        }


        public DataTable GetCarrierNameForNew(string carrieerName)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@carrierName", SqlDbType.VarChar, 300) 
                                                     };
            objp[0].Value = carrieerName;
            return ExecuteTable("SpGetCarrierNameNew", objp);
        }

    }
}
