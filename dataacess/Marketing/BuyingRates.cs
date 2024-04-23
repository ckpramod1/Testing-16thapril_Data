using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Marketing
{
  public  class BuyingRates:DBObject
    {
        Masters.MasterCustomer Custobj = new DataAccess.Masters.MasterCustomer();
        Masters.MasterPort Portobj = new DataAccess.Masters.MasterPort();
        Masters.MasterCharges Chargesobj = new DataAccess.Masters.MasterCharges();

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public BuyingRates()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertFFDRates(string FPort, string TPort, string liner, string chargebase, string charges, string curr, int amount, DateTime updated, DateTime valid)
        {
            int custid = Custobj.GetCustomerid(liner);
            int fportid = Portobj.GetNPortid(FPort);
            int tportid = Portobj.GetNPortid(TPort);
            int chargeid = Chargesobj.GetChargeid(charges);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromport",SqlDbType.Int,4),
                                                     new SqlParameter("@toport",SqlDbType.Int,4),
                                                     new SqlParameter("@liner",SqlDbType.Int,4),
                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                     new SqlParameter("@charges",SqlDbType.Int,4),
                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                     new SqlParameter("@amount",SqlDbType.Real,4),
                                                     new SqlParameter("@updatedon",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@valid",SqlDbType.SmallDateTime,4)};
            objp[0].Value = fportid;
            objp[1].Value = tportid;
            objp[2].Value =custid;
            objp[3].Value =chargebase;
            objp[4].Value =chargeid;
            objp[5].Value =curr;
            objp[6].Value =amount;
            objp[7].Value =updated;
            objp[8].Value =valid;
            ExecuteQuery("SPInsRatesFFD", objp);
        }

      public bool CheckChargeExists(string FPort, string TPort, string liner, string chargebase, string charges)
        {
            int custid = Custobj.GetCustomerid(liner);
            //int custid = Custobj.GetCustomerid(liner);
            int fportid = Portobj.GetNPortid(FPort);
            int tportid = Portobj.GetNPortid(TPort);
            int chargeid = Chargesobj.GetChargeid(charges);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@liner",SqlDbType.Int,4),
                                                         new SqlParameter("@fromport",SqlDbType.Int,4),
                                                         new SqlParameter("@toport",SqlDbType.Int,4),
                                                         new SqlParameter("@base",SqlDbType.VarChar,6),
                                                         new SqlParameter("@chargeid",SqlDbType.Int,4)};
            objp[0].Value = custid;
            objp[1].Value = fportid;
            objp[2].Value = tportid;
            objp[3].Value = chargebase;
            objp[4].Value = chargeid;
            if (ExecuteTable("SPSelRatesChargeExists", objp).Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

      public DataTable GetRates(string liner, string fport, string tport)
        {
            int custid = Custobj.GetCustomerid(liner);
            int fportid = Portobj.GetNPortid(fport);
            int tportid = Portobj.GetNPortid(tport);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@liner",SqlDbType.Int,4),
                                                     new SqlParameter("@fromport",SqlDbType.Int,4),
                                                     new SqlParameter("@toport",SqlDbType.Int,4)};
            objp[0].Value = custid;
            objp[1].Value = fportid;
            objp[2].Value = tportid;
            return ExecuteTable("SPSelGetRatesFFD", objp);
        }

      public void UpdRatesFFD(string FPort, string TPort, string liner, string chargebase, string charges, string curr, int amount, DateTime updated, DateTime valid)
        {
            int custid = Custobj.GetCustomerid(liner);
            int fportid = Portobj.GetNPortid(FPort);
            int tportid = Portobj.GetNPortid(TPort);
            int chargeid = Chargesobj.GetChargeid(charges);
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fromport",SqlDbType.Int,4),
                                                     new SqlParameter("@toport",SqlDbType.Int,4),
                                                     new SqlParameter("@liner",SqlDbType.Int,4),
                                                     new SqlParameter("@base",SqlDbType.VarChar,6),
                                                     new SqlParameter("@charges",SqlDbType.Int,4),
                                                     new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                     new SqlParameter("@amount",SqlDbType.SmallMoney,4),
                                                     new SqlParameter("@updatedon",SqlDbType.DateTime,8),
                                                     new SqlParameter("@dtvalid",SqlDbType.DateTime,8)};
            objp[0].Value = fportid;
            objp[1].Value = tportid;
            objp[2].Value = custid;
            objp[3].Value = chargebase;
            objp[4].Value = chargeid;
            objp[5].Value = curr;
            objp[6].Value = amount;
            objp[7].Value = updated;
            objp[8].Value = valid;
            ExecuteQuery("SPUpdRatesFFD", objp);
        }

      public bool CheckRateExists(string liner, string fport, string tport)
        {
            int custid = Custobj.GetCustomerid(liner);
            int fportid = Portobj.GetNPortid(fport);
            int tportid = Portobj.GetNPortid(tport);

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@liner",SqlDbType.Int,4),
                                                        new SqlParameter("@fromport",SqlDbType.Int,4),
                                                        new SqlParameter("@toport",SqlDbType.Int,4)};
            objp[0].Value =  custid;
            objp[1].Value = fportid;
            objp[2].Value = tportid;
            if (ExecuteTable("SPSelGetRatesFFD",objp).Rows.Count ==0)
            {
                return false;
            }
                return true;
        }

        public string GetSystemDate()
        {
            return ExecuteReader("SPGetToday");
         }

        public void DelRatesCharges(string FPort, string TPort, string liner, string chargebase, string charges)
        {
            int custid = Custobj.GetCustomerid(liner);
            int fportid = Portobj.GetNPortid(FPort);
            int tportid = Portobj.GetNPortid(TPort);
            int chargeid = Chargesobj.GetChargeid(charges);

            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fport",SqlDbType.Int,4),
                                                         new SqlParameter("@tport",SqlDbType.Int,4),
                                                         new SqlParameter("@liner",SqlDbType.Int,4),
                                                         new SqlParameter("@base",SqlDbType.VarChar,6),
                                                         new SqlParameter("@chargeid",SqlDbType.Int,4)};
            objp[0].Value = fportid;
            objp[1].Value = tportid;
            objp[2].Value = custid;
            objp[3].Value = chargebase;
            objp[4].Value = chargeid;
            ExecuteQuery("SPDelRatesCharges", objp);
         }
    }
}
