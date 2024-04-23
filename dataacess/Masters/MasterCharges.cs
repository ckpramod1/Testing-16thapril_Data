using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterCharges : DBObject
    {
        //Methods.
        //Insert charge details without servicetax
        /*public void InsertChargeDetails(string chargename, string currency, double amount, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@currency",SqlDbType.VarChar,3),
                                                                                     new SqlParameter( "@amount" , SqlDbType.SmallMoney ,4),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};

            objp[0].Value = chargename;
            objp[1].Value = currency;
            objp[2].Value = amount;
            objp[3].Value = chargetype;
            ExecuteQuery("SPInsChargeDetails", objp);

        }*/

        //Priya

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterCharges()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsertSTCodeNE(string chargename, string currency, double amount, string chargetype, int Groupid)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@currency" , SqlDbType.VarChar ,3),
                                                                                     new SqlParameter( "@amount",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
             new SqlParameter( "@groupid",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = currency;
            objp[2].Value = amount;
            objp[3].Value = chargetype;
            objp[4].Value = Groupid;
            ExecuteQuery("SPInsSTDetailsNE", objp);

        }


        //Insert charge details with sevicetax
        public void InsertChargeDetails(string chargename, string currency, double amount, double stpercentage, double edupercentage, double hedupercentage, string chargetype, double sbcessper, double kkcessper)
        {
            //Insert Chargedetails into database  
            string chgname = "ST on " + chargename;
            string eduname = "EduCess on " + chargename;
            string hedname = "HigherEduCess on " + chargename;
            string sbname = "Swachh Bharat Cess On " + chargename;
            string kkname = "KRISHI KALYAN CESS ON " + chargename;
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@currency",SqlDbType.VarChar,3),
                                                                                     new SqlParameter( "@amount" , SqlDbType.SmallMoney ,4),
                                                                                     new SqlParameter( "@percentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@edpercentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@hedpercentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter( "@SBCessper",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@KKCessper",SqlDbType.Real,4),};
            objp[0].Value = chargename;
            objp[1].Value = currency;
            objp[2].Value = amount;
            objp[3].Value = stpercentage;
            objp[4].Value = edupercentage;
            objp[5].Value = hedupercentage;
            objp[6].Value = chargetype;
            objp[7].Value = sbcessper;
            objp[8].Value = kkcessper;



            ExecuteQuery("SPInsChargeDetailsNE", objp);

            double stamount = (amount * stpercentage) / 100;        //Amount inclueds ServiceTax
            int chargeid = GetChargeid(chargename);
            InsertSTCodeNE(chgname, currency, stamount, chargetype, 2);       //INSERT A NEW ROW WITH SERVICE TAX
            int stcode = GetChargeid(chgname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, stcode, "S");                //UPDATE THE EXISTING ROW WITH STCODE.

            double edamount = (stamount * edupercentage) / 100;        //Amount inclueds Edu Cess
            int echargeid = GetChargeid(chgname);
            InsertSTCodeNE(eduname, currency, edamount, chargetype, 3);       //INSERT A NEW ROW WITH Edu Cess
            int edcode = GetChargeid(eduname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, edcode, "E");

            double hedamount = (edamount * hedupercentage) / 100;        //Amount inclueds Edu Cess
            int hchargeid = GetChargeid(eduname);
            InsertSTCodeNE(hedname, currency, hedamount, chargetype, 4);       //INSERT A NEW ROW WITH Edu Cess
            int hedcode = GetChargeid(hedname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, hedcode, "H");




            double sbamount = (amount * sbcessper) / 100;        //Amount incluedsSBCESS
            //int sbchargeid = GetChargeid(chgname);
            InsertSTCodeNE(sbname, currency, sbamount, chargetype, 6);       //INSERT A NEW ROW WITH SBCESS
            int sbcode = GetChargeid(sbname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, sbcode, "B");

            double kkamount = (amount * kkcessper) / 100;        //Amount inclueds KKCESS
            //int kkchargeid = GetChargeid(chgname);
            InsertSTCodeNE(kkname, currency, kkamount, chargetype, 7);       //INSERT A NEW ROW WITH KKCESS
            int kkcode = GetChargeid(kkname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, kkcode, "K");

        }



        //Update Chrarge details without tax.   
        public void UpdateChargeDetails(int chargeid, string chargename, string currency, double amount, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@currency" , SqlDbType.VarChar ,3),
                                                                                     new SqlParameter( "@amount",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};

            objp[0].Value = chargename;
            objp[1].Value = chargeid;
            objp[2].Value = currency;
            objp[3].Value = amount;
            objp[4].Value = chargetype;

            ExecuteQuery("SPUpdChargeDetails", objp);

            int stcode = GetSTCode(chargeid, "S");
            if (stcode != 0)
                RemoveSTRow(stcode, "S");
            int edcode = GetSTCode(chargeid, "E");
            if (edcode != 0)
                RemoveSTRow(edcode, "E");
            int hedcode = GetSTCode(chargeid, "H");
            if (hedcode != 0)
                RemoveSTRow(hedcode, "H");
            int sbccode = GetSTCode(chargeid, "B");
            if (sbccode != 0)
                RemoveSTRow(sbccode, "B");
            int kkccode = GetSTCode(chargeid, "K");
            if (kkccode != 0)
                RemoveSTRow(kkccode, "K");

        }
        //Update charge details with tax.
        public void UpdateChargeDetails(int chargeid, string chargename, string currency, double amount, double percentage, double edupercentage, double hedupercentage, string chargetype, double sbcessper, double kkcessper)
        {
            string chgname = "ST on " + chargename;
            string edname = "EduCess on " + chargename;
            string hedname = "HigherEduCess on " + chargename;
            string sbname = "Swachh Bharat Cess On " + chargename;
            string kkname = "KRISHI KALYAN CESS ON " + chargename;

            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@currency" , SqlDbType.VarChar ,3),
                                                                                     new SqlParameter( "@amount",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter( "@percentage",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@edcess",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@hedcess",SqlDbType.Real,4 ) ,
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
             new SqlParameter( "@sbcess",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@KKcess",SqlDbType.Real,4 ) ,};
            objp[0].Value = chargename;
            objp[1].Value = chargeid;
            objp[2].Value = currency;
            objp[3].Value = amount;
            objp[4].Value = percentage;
            objp[5].Value = edupercentage;
            objp[6].Value = hedupercentage;
            objp[7].Value = chargetype;
            objp[8].Value = sbcessper;
            objp[9].Value = kkcessper;

            ExecuteQuery("SPUpdChargeDetailsNe", objp);

            int stcode = GetSTCode(chargeid, "S");
            double stamount = 0;
            if (stcode != 0)
            {
                stamount = (amount * percentage) / 100;
                UpdateSTDetails(stcode, chgname, currency, stamount, chargetype);
            }
            else
            {
                stamount = (amount * percentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCodeNE(chgname, currency, stamount, chargetype, 2);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(chgname);
                UpdateSTCode(chargeid, stcode, "S");
            }

            int edcode = GetSTCode(chargeid, "E");
            double edamount = 0;
            if (edcode != 0)
            {
                edamount = (stamount * edupercentage) / 100;
                UpdateSTDetails(edcode, edname, currency, edamount, chargetype);
            }
            else
            {
                edamount = (stamount * edupercentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCodeNE(edname, currency, edamount, chargetype, 3);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(edname);
                UpdateSTCode(chargeid, stcode, "E");
            }

            int hedcode = GetSTCode(chargeid, "H");
            double hedamount = 0;
            if (hedcode != 0)
            {
                hedamount = (edamount * hedupercentage) / 100;
                UpdateSTDetails(hedcode, hedname, currency, hedamount, chargetype);
            }
            else
            {
                hedamount = (edamount * hedupercentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCodeNE(hedname, currency, hedamount, chargetype, 4);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(hedname);
                UpdateSTCode(chargeid, stcode, "H");
            }

            int sbccode = GetSTCode(chargeid, "B");
            double sbcamount = 0;
            if (sbccode != 0)
            {
                sbcamount = (amount * sbcessper) / 100;
                UpdateSTDetails(sbccode, sbname, currency, sbcamount, chargetype);
            }
            else
            {
                sbcamount = (amount * sbcessper) / 100;        //Amount inclueds ServiceTax
                InsertSTCodeNE(sbname, currency, hedamount, chargetype, 6);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(sbname);
                UpdateSTCode(chargeid, stcode, "B");
            }

            int kkccode = GetSTCode(chargeid, "K");
            double kkcamount = 0;
            if (kkccode != 0)
            {
                kkcamount = (amount * kkcessper) / 100;
                UpdateSTDetails(kkccode, kkname, currency, kkcamount, chargetype);
            }
            else
            {
                kkcamount = (amount * kkcessper) / 100;        //Amount inclueds ServiceTax
                InsertSTCodeNE(kkname, currency, kkcamount, chargetype, 7);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(kkname);
                UpdateSTCode(chargeid, stcode, "K");
            }

        }



        //Insert charge details with sevicetax
        public void InsertChargeDetails(string chargename, string currency, double amount, double stpercentage, double edupercentage, double hedupercentage, string chargetype)
        {
            //Insert Chargedetails into database  
            string chgname = "ST on " + chargename;
            string eduname = "EduCess on " + chargename;
            string hedname = "HigherEduCess on " + chargename;
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@currency",SqlDbType.VarChar,3),
                                                                                     new SqlParameter( "@amount" , SqlDbType.SmallMoney ,4),
                                                                                     new SqlParameter( "@percentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@edpercentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@hedpercentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = currency;
            objp[2].Value = amount;
            objp[3].Value = stpercentage;
            objp[4].Value = edupercentage;
            objp[5].Value = hedupercentage;
            objp[6].Value = chargetype;

            ExecuteQuery("SPInsChargeDetails", objp);

            double stamount = (amount * stpercentage) / 100;        //Amount inclueds ServiceTax
            int chargeid = GetChargeid(chargename);
            InsertSTCode(chgname, currency, stamount, chargetype);       //INSERT A NEW ROW WITH SERVICE TAX
            int stcode = GetChargeid(chgname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, stcode, "S");                //UPDATE THE EXISTING ROW WITH STCODE.

            double edamount = (stamount * edupercentage) / 100;        //Amount inclueds Edu Cess
            int echargeid = GetChargeid(chgname);
            InsertSTCode(eduname, currency, edamount, chargetype);       //INSERT A NEW ROW WITH Edu Cess
            int edcode = GetChargeid(eduname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, edcode, "E");

            double hedamount = (edamount * hedupercentage) / 100;        //Amount inclueds Edu Cess
            int hchargeid = GetChargeid(eduname);
            InsertSTCode(hedname, currency, hedamount, chargetype);       //INSERT A NEW ROW WITH Edu Cess
            int hedcode = GetChargeid(hedname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, hedcode, "H");

        }

        //Update Chrarge details without tax.   
      /*  public void UpdateChargeDetailstax(int chargeid, string chargename, string currency, double amount, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@currency" , SqlDbType.VarChar ,3),
                                                                                     new SqlParameter( "@amount",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};

            objp[0].Value = chargename;
            objp[1].Value = chargeid;
            objp[2].Value = currency;
            objp[3].Value = amount;
            objp[4].Value = chargetype;

            ExecuteQuery("SPUpdChargeDetails", objp);

            int stcode = GetSTCode(chargeid, "S");
            if (stcode != 0)
                RemoveSTRow(stcode, "S");
            int edcode = GetSTCode(chargeid, "E");
            if (edcode != 0)
                RemoveSTRow(edcode, "E");
            int hedcode = GetSTCode(chargeid, "H");
            if (hedcode != 0)
                RemoveSTRow(hedcode, "H");

        }*/



        //Update charge details with tax.
        public void UpdateChargeDetails(int chargeid, string chargename, string currency, double amount, double percentage, double edupercentage, double hedupercentage, string chargetype)
        {
            string chgname = "ST on " + chargename;
            string edname = "EduCess on " + chargename;
            string hedname = "HigherEduCess on " + chargename;
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@currency" , SqlDbType.VarChar ,3),
                                                                                     new SqlParameter( "@amount",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter( "@percentage",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@edcess",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@hedcess",SqlDbType.Real,4 ) ,
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = chargeid;
            objp[2].Value = currency;
            objp[3].Value = amount;
            objp[4].Value = percentage;
            objp[5].Value = edupercentage;
            objp[6].Value = hedupercentage;
            objp[7].Value = chargetype;

            ExecuteQuery("SPUpdChargeDetails", objp);

            int stcode = GetSTCode(chargeid, "S");
            double stamount = 0;
            if (stcode != 0)
            {
                stamount = (amount * percentage) / 100;
                UpdateSTDetails(stcode, chgname, currency, stamount, chargetype);
            }
            else
            {
                stamount = (amount * percentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCode(chgname, currency, stamount, chargetype);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(chgname);
                UpdateSTCode(chargeid, stcode, "S");
            }

            int edcode = GetSTCode(chargeid, "E");
            double edamount = 0;
            if (edcode != 0)
            {
                edamount = (stamount * edupercentage) / 100;
                UpdateSTDetails(edcode, edname, currency, edamount, chargetype);
            }
            else
            {
                edamount = (stamount * edupercentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCode(edname, currency, edamount, chargetype);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(edname);
                UpdateSTCode(chargeid, stcode, "E");
            }

            int hedcode = GetSTCode(chargeid, "H");
            double hedamount = 0;
            if (hedcode != 0)
            {
                hedamount = (edamount * hedupercentage) / 100;
                UpdateSTDetails(hedcode, hedname, currency, hedamount, chargetype);
            }
            else
            {
                hedamount = (edamount * hedupercentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCode(hedname, currency, hedamount, chargetype);       //INSERT A NEW ROW WITH SERVICE TAX
                //stcode = GetSTChargeid(chargename, stamount);
                stcode = GetChargeid(hedname);
                UpdateSTCode(chargeid, stcode, "H");
            }

        }

        public void UpdateSTDetails(int stcode, string cname, string curr, double amount, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[]{  new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@currency" , SqlDbType.VarChar ,3),
                                                                                     new SqlParameter( "@amount",SqlDbType.SmallMoney,4) ,
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};
            objp[0].Value = stcode;
            objp[1].Value = cname;
            objp[2].Value = curr;
            objp[3].Value = amount;
            objp[4].Value = chargetype;

            ExecuteQuery("SPUpdSTDetails", objp);

        }

        public int GetSTCode(int cid, string stype)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@chargeid",SqlDbType.Int),
                                                     new SqlParameter("@stype",SqlDbType.VarChar,1)};
            objp[0].Value = cid;
            objp[1].Value = stype;
            return int.Parse(ExecuteReader("SPSTCodeCId", objp));

        }

        ////Display details based on Chargename  
        //public DataTable ShowChargeNameDetails(string chargename)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename", SqlDbType.VarChar, 100) };
        //    objp[0].Value = chargename;
        //    return ExecuteTable("SPSelChargeName", objp);
        //}


        //Display details based on Chargename  
        public DataTable ShowChargeNameDetails(string chargename, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename", SqlDbType.VarChar, 100),
                                                    new SqlParameter("@chargetype", SqlDbType.VarChar, 1)};
            objp[0].Value = chargename;
            objp[1].Value = chargetype;
            if (chargetype == "")
            {
                return ExecuteTable("SPSelChargeName", objp);
            }
            else
            {
                return ExecuteTable("SPSelChargeName4type", objp);
            }

        }

        //Insert a row with  amount includes servicetax
        public void InsertSTCode(string chargename, string currency, double amount, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@currency" , SqlDbType.VarChar ,3),
                                                                                     new SqlParameter( "@amount",SqlDbType.SmallMoney,4),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = currency;
            objp[2].Value = amount;
            objp[3].Value = chargetype;
            ExecuteQuery("SPInsSTDetailsNew", objp);

        }

        //Get Service tax code based on chargename and amount
        public int GetSTChargeid(string chargename, double amount)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename",SqlDbType.VarChar,100),
                                                                                      new SqlParameter("@amount",SqlDbType.SmallMoney,4)  };

            objp[0].Value = chargename;
            objp[1].Value = amount;

            return int.Parse(ExecuteReader("SPSTChargeidCNameAmt", objp));

        }

        //Update the row which includes ST with STCode
        public void UpdateSTCode(int chargeid, int stcode, string stype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int) ,
                                                                                     new SqlParameter("@stcode", SqlDbType.Int),
                                                                                     new SqlParameter("@stype", SqlDbType.VarChar, 1)};
            objp[0].Value = chargeid;
            objp[1].Value = stcode;
            objp[2].Value = stype;
            ExecuteQuery("SPUpdSTCode", objp);

        }

        //Get chargeid based on chargename
        public int GetChargeid(string Chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename", SqlDbType.VarChar, 100) };

            objp[0].Value = Chargename;
            return int.Parse(ExecuteReader("SPChargeidCName", objp));

        }

        //Get Chargeid basedon chargename and percentage when ST exist.
        public int GetChargeid(string Chargename, double percentage)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename", SqlDbType.VarChar, 100),
                                                                                      new SqlParameter("@percentage",SqlDbType.Real,4) };
            objp[0].Value = Chargename;
            objp[1].Value = percentage;

            return int.Parse(ExecuteReader("SPChargeidCNamePer", objp));

        }

        public int GetCurrID(string Curr)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Curr", SqlDbType.VarChar, 3) };
            objp[0].Value = Curr;

            return int.Parse(ExecuteReader("SPGetCurrID", objp));

        }
        //Remove servicetax row & update Charge details.
        public void RemoveSTRow(int stid, string stype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@chargeid",SqlDbType.Int),
                                                      new SqlParameter("@stype",SqlDbType.VarChar,1)};
            objp[0].Value = stid;
            objp[1].Value = stype;
            ExecuteQuery("SPDelSTDetails", objp);

        }

        // *******Methods For Windows Application.*********

        //Get Like Charges
        public DataTable GetLikeCharges(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeCharges", objp);

        }
        public DataTable GetLikeChargesWChargeType(string chargename, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@chargetype", SqlDbType.VarChar, 1)};
            objp[0].Value = chargename;
            objp[1].Value = chargetype;
            return ExecuteTable("SPLikeChargesWChargeType", objp);

        }

        //Get Like Currency
        public DataTable GetLikeCurrency(string currency)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr", SqlDbType.VarChar, 3) };
            objp[0].Value = currency;
            return ExecuteTable("SPLikeCurr", objp);
        }

        public double CheckChargeST(int charge)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@charge", SqlDbType.Int) };
            objp[0].Value = charge;
            return double.Parse(ExecuteReader("SPCheckChargeST", objp));
        }
        public DataTable GetLikePaymentCharges(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPPaymentLikeCharges", objp);

        }
        public DataTable GetLikeCashPaymentCharges(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeChargesWOType", objp);

        }
        //raja 4 FA

        public string GetChargeName(int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int, 4) };

            objp[0].Value = chargeid;
            return ExecuteReader("SPChargeNameFCid", objp);

        }

        //Manoj

        public DataTable GetLikeMasterCharges4ADMDCN(string chargename, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@chargetype", SqlDbType.VarChar, 1)};
            objp[0].Value = chargename;
            objp[1].Value = chargetype;
            return ExecuteTable("SPLikeCharges4AdmDCN", objp);

        }


        //********************************BHUVANA*****************************************//
        public DataTable GetLikeChargesName(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeChargesname", objp);
        }
        //@chargename VARCHAR(100),@servicetype varchar(1)
        public void InsertSTCode4charges(string chargename, string servicetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                      new SqlParameter( "@servicetype",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = servicetype;
            ExecuteQuery("SPInsSTDetailsNew", objp);

        }

        //SPInsChargeDetails
        //@chargename VARCHAR(100),@percentage REAL = NULL,@edpercentage REAL = NULL,@hedpercentage REAL = NULL,@servicetype varchar(1)
        public void InsertChargeTaxDetails(string chargename, double stpercentage, double edupercentage, double hedupercentage, string servicetype, string chargetype)
        {
            //Insert Chargedetails into database  
            string chgname = "ST on " + chargename;
            string eduname = "EduCess on " + chargename;
            string hedname = "HigherEduCess on " + chargename;
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@percentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@edpercentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@hedpercentage",SqlDbType.Real,4),
                                                                                     new SqlParameter( "@servicetype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = stpercentage;
            objp[2].Value = edupercentage;
            objp[3].Value = hedupercentage;
            objp[4].Value = servicetype;
            objp[5].Value = chargetype;
            ExecuteQuery("SPInsChargeDetailsnew", objp);



            InsertSTCode4charges(chgname, servicetype);       //INSERT A NEW ROW WITH SERVICE TAX
            int stcode = GetChargeid(chgname);
            int chargeid = GetChargeid(chargename);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, stcode, "S");                //UPDATE THE EXISTING ROW WITH STCODE.



            InsertSTCode4charges(eduname, servicetype);       //INSERT A NEW ROW WITH Edu Cess
            int edcode = GetChargeid(eduname);
            //int echargeid = GetChargeid(chgname);
            //int stcode = GetSTChargeid(chargename, stamount);
            UpdateSTCode(chargeid, edcode, "E");



            InsertSTCode4charges(hedname, servicetype);       //INSERT A NEW ROW WITH Edu Cess
            int hedcode = GetChargeid(hedname);
            //int hchargeid = GetChargeid(eduname);
            UpdateSTCode(chargeid, hedcode, "H");

        }

        public void InsertChargeTaxDetails(string chargename, string servicetype, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                      new SqlParameter( "@servicetype",SqlDbType.VarChar,1),
                                                      new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};

            objp[0].Value = chargename;
            objp[1].Value = servicetype;
            objp[2].Value = chargetype;
            ExecuteQuery("SPInsChargeDetailsnew", objp);

        }
        //Update charge details without tax.
        public void UpdateChargeDetails4withouttax(int chargeid, string chargename, string servicetype, string chargetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                        new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                        new SqlParameter( "@servicetype",SqlDbType.VarChar,1),
                                                                        new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};

            objp[0].Value = chargename;
            objp[1].Value = chargeid;
            objp[2].Value = servicetype;
            objp[3].Value = chargetype;
            ExecuteQuery("SPUpdChargeDetailsnew", objp);

            int stcode = GetSTCode(chargeid, "S");
            if (stcode != 0)
                RemoveSTRow(stcode, "S");
            int edcode = GetSTCode(chargeid, "E");
            if (edcode != 0)
                RemoveSTRow(edcode, "E");
            int hedcode = GetSTCode(chargeid, "H");
            if (hedcode != 0)
                RemoveSTRow(hedcode, "H");

        }

        //Update charge details with tax.
        public void UpdateChargeDetails4withtax(int chargeid, string chargename, double percentage, double edupercentage, double hedupercentage, string servicetype, string chargetype)
        {
            string chgname = "ST on " + chargename;
            string edname = "EduCess on " + chargename;
            string hedname = "HigherEduCess on " + chargename;
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@percentage",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@edcess",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@hedcess",SqlDbType.Real,4 ) ,
                                                                                     new SqlParameter( "@servicetype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = chargeid;
            objp[2].Value = percentage;
            objp[3].Value = edupercentage;
            objp[4].Value = hedupercentage;
            objp[5].Value = servicetype;
            objp[6].Value = chargetype;
            ExecuteQuery("SPUpdChargeDetailsnew", objp);

            int stcode = GetSTCode(chargeid, "S");

            if (stcode != 0)
            {
                //stamount = (amount * percentage) / 100;
                UpdateSTDetails(stcode, chgname, servicetype);
            }
            else
            {
                //stamount = (amount * percentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCode(chgname, servicetype);


                stcode = GetChargeid(chgname);
                UpdateSTCode(chargeid, stcode, "S");
            }

            int edcode = GetSTCode(chargeid, "E");

            if (edcode != 0)
            {
                //edamount = (stamount * edupercentage) / 100;
                UpdateSTDetails(edcode, edname, servicetype);
            }
            else
            {
                //edamount = (stamount * edupercentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCode4charges(edname, servicetype);       //INSERT A NEW ROW WITH SERVICE TAX

                stcode = GetChargeid(edname);
                UpdateSTCode(chargeid, stcode, "E");
            }

            int hedcode = GetSTCode(chargeid, "H");
            if (hedcode != 0)
            {
                // hedamount = (edamount * hedupercentage) / 100;
                UpdateSTDetails(hedcode, hedname, servicetype);
            }
            else
            {
                //hedamount = (edamount * hedupercentage) / 100;        //Amount inclueds ServiceTax
                InsertSTCode(hedname, servicetype);       //INSERT A NEW ROW WITH SERVICE TAX

                stcode = GetChargeid(hedname);
                UpdateSTCode(chargeid, stcode, "H");
            }

        }
        public void UpdateSTDetails(int stcode, string servicetype)
        {
            SqlParameter[] objp = new SqlParameter[]{  new SqlParameter( "@chargeid",SqlDbType.Int),
                                                       new SqlParameter( "@servicetype",SqlDbType.VarChar,1)};
            objp[0].Value = stcode;
            objp[1].Value = servicetype;

            ExecuteQuery("SPUpdSTDetailsNew", objp);

        }
        public void UpdateSTDetails(int stcode, string cname, string servicetype)
        {
            SqlParameter[] objp = new SqlParameter[]{  new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@servicetype",SqlDbType.VarChar,1)};
            objp[0].Value = stcode;
            objp[1].Value = cname;
            objp[2].Value = servicetype;

            ExecuteQuery("SPUpdSTDetailsNew", objp);

        }
        //Insert a row with  amount includes servicetax
        public void InsertSTCode(string chargename, string servicetype)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                      new SqlParameter( "@servicetype",SqlDbType.VarChar,1)};
            objp[0].Value = chargename;
            objp[1].Value = servicetype;
            ExecuteQuery("SPInsSTDetailsNew", objp);

        }
        public DataTable ShowChargeDetails()
        {

            return ExecuteTable("SPSelAllChargeDetails");
        }


        public DataTable FillGridOnPageLoad2Charges()
        {

            return ExecuteTable("SPFillGrid4Charges");
        }


        public void DelChargeDetails(int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int) };
            objp[0].Value = chargeid;
            ExecuteQuery("SPDelChargeDetails", objp);

        }
        //@chargeid smallint
        //public DataTable ShowChargeNameDetails(int chargeid)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int) };
        //    objp[0].Value = chargeid;
        //    return ExecuteTable("SPSelChargeName", objp);
        //}

        //@chargename
        public DataTable CheckDuplicateForCharges(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPChechDuplicate4Charges", objp);
        }

        //Service Tax Update


        //Service Tax updated Details

        public void UpdateSTbasedonstcode(double percentage, double sbarath, double kkalyan, int intchargid)
        {

            SqlParameter[] objp = new SqlParameter[]{ 
                                                                                     new SqlParameter( "@st",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@eduge",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@hedu",SqlDbType.Real,4 ),
            new SqlParameter( "@charge",SqlDbType.Int ,4 )};

            objp[0].Value = percentage;
            objp[1].Value = sbarath;
            objp[2].Value = kkalyan;
            objp[3].Value = intchargid;

            ExecuteQuery("spupdstempty", objp);
        }

        //By ManiG
        public DataTable GetServiceTaxDtls(double percentage, double sbarath, double kkalyan)
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                                                                                     new SqlParameter( "@per",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@edcess",SqlDbType.Real,4 ),
                                                                                     new SqlParameter( "@hedcess",SqlDbType.Real,4 ) };

            objp[0].Value = percentage;
            objp[1].Value = sbarath;
            objp[2].Value = kkalyan;
            return ExecuteTable("SpSelServiceTaxType", objp);
        }

        //

        public DataTable GetLikeChargesWOType4pay(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeChargesWOType4pay", objp);
        }

        public DataTable GetLikeCharges4Corp(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeCharges4Corp", objp);
        }



        //GST

        //DINESH

        public DataTable GetLikeChargesnew(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeChargesnew", objp);

        }

        public void InsertChargeDetails(string chargename, string chargetype, string SACCode, double GSTP)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     
                                                                                   

                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter( "@SACCode" , SqlDbType.VarChar,15),
                                                                                     new SqlParameter( "@GSTP" , SqlDbType.Real,4)
            };

            objp[0].Value = chargename;

            objp[1].Value = chargetype;
            objp[2].Value = SACCode;
            objp[3].Value = GSTP;

            ExecuteQuery("SPInsChargeDetails4gst", objp);

        }

        //GST
        public void UpdateChargeDetailstax(int chargeid, string chargename, string chargetype, string SACCode, Decimal GSTP)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                   
                                                                                   
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter( "@SACCode",SqlDbType.VarChar,10),
                                                                                     new SqlParameter( "@GSTP",SqlDbType.Float,8)
            };

            objp[0].Value = chargename;
            objp[1].Value = chargeid;


            objp[2].Value = chargetype;
            objp[3].Value = SACCode;
            objp[4].Value = GSTP;

            ExecuteQuery("SPUpdChargeDetails4gst", objp);

            //int stcode = GetSTCode(chargeid, "S");
            //if (stcode != 0)
            //    RemoveSTRow(stcode, "S");
            //int edcode = GetSTCode(chargeid, "E");
            //if (edcode != 0)
            //    RemoveSTRow(edcode, "E");
            //int hedcode = GetSTCode(chargeid, "H");
            //if (hedcode != 0)
            //    RemoveSTRow(hedcode, "H");

        }

        //MUTHU

        public int SPChargeidCNamewithblock(string Chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargename", SqlDbType.VarChar, 100) };

            objp[0].Value = Chargename;
            return int.Parse(ExecuteReader("SPChargeidCNamewithblock", objp));

        }


        //Dinesh

        public int GetGSTP(int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int, 4) };

            objp[0].Value = chargeid;
            return int.Parse(ExecuteReader("spgstp", objp));

        }


        //------------------Karthika_K

        public DataTable GetLikeMasterCharges4ADMDCN(string chargename, string chargetype, string custtype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@chargetype", SqlDbType.VarChar, 1),
            new SqlParameter("@custtype", SqlDbType.VarChar, 1)};
            objp[0].Value = chargename;
            objp[1].Value = chargetype;
            objp[2].Value = custtype;
            return ExecuteTable("SPLikeCharges4AdmDCN", objp);
        }

        public DataTable GetLikeChargesall(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeCharges4all", objp);

        }

        public DataTable GetLikeCharges4rpt(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeCharges4rpt", objp);

        }
        public void InsertChargeDetails(string chargename, string chargetype, string SACCode, double GSTP, string Exempted, char TDS)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),



new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
new SqlParameter( "@SACCode" , SqlDbType.VarChar,15),
new SqlParameter( "@GSTP" , SqlDbType.Real,4),
new SqlParameter( "@Exempted",SqlDbType.VarChar,1),
new SqlParameter( "@TDS",SqlDbType.Char,1)
            };

            objp[0].Value = chargename;

            objp[1].Value = chargetype;
            objp[2].Value = SACCode;
            objp[3].Value = GSTP;
            objp[4].Value = Exempted;
            objp[5].Value = TDS;
            ExecuteQuery("SPInsChargeDetails4gst", objp);

        }

        //GST
        public void UpdateChargeDetailstax(int chargeid, string chargename, string chargetype, string SACCode, Decimal GSTP, string Exempted, char TDS)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
new SqlParameter( "@chargeid",SqlDbType.Int),


new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
new SqlParameter( "@SACCode",SqlDbType.VarChar,10),
new SqlParameter( "@GSTP",SqlDbType.Float,8),
new SqlParameter( "@Exempted",SqlDbType.VarChar,1),
new SqlParameter( "@TDS",SqlDbType.Char,1)
            };

            objp[0].Value = chargename;
            objp[1].Value = chargeid;


            objp[2].Value = chargetype;
            objp[3].Value = SACCode;
            objp[4].Value = GSTP;
            objp[5].Value = Exempted;
            objp[6].Value = TDS;
            ExecuteQuery("SPUpdChargeDetails4gst", objp);

            //int stcode = GetSTCode(chargeid, "S");
            //if (stcode != 0)
            //    RemoveSTRow(stcode, "S");
            //int edcode = GetSTCode(chargeid, "E");
            //if (edcode != 0)
            //    RemoveSTRow(edcode, "E");
            //int hedcode = GetSTCode(chargeid, "H");
            //if (hedcode != 0)
            //    RemoveSTRow(hedcode, "H");

        }

        public DataTable SPLikeMasterChargesExceldownload()
        {
            return ExecuteTable("SPLikeMasterChargesExceldownload");
        }



        public void spdeletecharges(int chargeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@chargeid", SqlDbType.Int) 
                                                                                     };
            objp[0].Value = chargeid;

            ExecuteQuery("spdeletechargesid", objp);

        }

        //Dinesh

        public DataTable ShowChargeDetailsnew()
        {

            return ExecuteTable("SPAllChargeDetails");
        }

        //for cfs

        public int Insmastercfschargehead(int customerid, string address, DateTime cfsdate, DateTime validfrom, DateTime validto, string remarks, int updatedby, DateTime updatedon, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@customerid" ,SqlDbType.Int),
                 new SqlParameter( "@address",SqlDbType.VarChar,500),
                                                                                     new SqlParameter( "@cfsdate" , SqlDbType.DateTime),
                                                                                     new SqlParameter( "@validfrom",SqlDbType.DateTime),
                                                                                     new SqlParameter( "@validto",SqlDbType.DateTime),
             new SqlParameter( "@remarks",SqlDbType.VarChar,500),
            new SqlParameter( "@updatedby" ,SqlDbType.Int),
             new SqlParameter( "@updatedon",SqlDbType.DateTime),
              new SqlParameter( "@cfsid" ,SqlDbType.Int),
             new SqlParameter( "@type",SqlDbType.VarChar,10)
            };
            objp[0].Value = customerid;
            objp[1].Value = address;
            objp[2].Value = cfsdate;
            objp[3].Value = validfrom;
            objp[4].Value = validto;
            objp[5].Value = remarks;
            objp[6].Value = updatedby;
            objp[7].Value = updatedon;
            objp[8].Direction = ParameterDirection.Output;
            objp[9].Value = type;
            return ExecuteQuery("SPInsmastercfschargehead", objp, "@cfsid");


        }
        public void Insmastercfschargedetails(int cfsid, int chargeid, string curr, double rate, string basetype, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@cfsid" ,SqlDbType.Int),
                                                                                     new SqlParameter( "@chargeid" , SqlDbType.Int),
                                                                                     new SqlParameter( "@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter( "@rate",SqlDbType.Money),
             new SqlParameter( "@basetype",SqlDbType.VarChar,10),
             new SqlParameter( "@type",SqlDbType.VarChar,10)
          
            
            };
            objp[0].Value = cfsid;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = basetype;
            objp[5].Value = type;
            ExecuteQuery("SPInsmastercfschargedetails", objp);

        }

        public DataTable CfsChargebaseExist(int cfsid, int intchargeid, string bbase, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cfsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int), 
                                                        new SqlParameter("@base",SqlDbType.VarChar,10),
            new SqlParameter("@type",SqlDbType.VarChar,10)};
            objp[0].Value = cfsid;
            objp[1].Value = intchargeid;
            objp[2].Value = bbase;
            objp[3].Value = type;
            return ExecuteTable("SPCFSchargebaseexist", objp);
        }
        public DataTable SelCFSDetails(int cfsid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cfsid", SqlDbType.Int, 4), 
            new SqlParameter( "@type",SqlDbType.VarChar,10)};
            objp[0].Value = cfsid;
            objp[1].Value = type;
            return ExecuteTable("SPselCFSDetails", objp);

        }


        public void Updmastercfschargehead(int cfsid, DateTime validfrom, DateTime validto, string remarks, int updatedby, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@cfsid" ,SqlDbType.Int),
                                                                                     
                                                                                     new SqlParameter( "@validfrom",SqlDbType.DateTime),
                                                                                     new SqlParameter( "@validto",SqlDbType.DateTime),
             new SqlParameter( "@remarks",SqlDbType.VarChar,500),
            new SqlParameter( "@updatedby" ,SqlDbType.Int),
           new SqlParameter( "@type",SqlDbType.VarChar,10)
             
            
            };
            objp[0].Value = cfsid;

            objp[1].Value = validfrom;
            objp[2].Value = validto;
            objp[3].Value = remarks;
            objp[4].Value = updatedby;
            objp[5].Value = type;

            ExecuteQuery("Updmastercfschargehead", objp);


        }

        public void UPdmastercfschargedetails(int cfsid, int chargeid, string curr, double rate, string basetype, string type)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@cfsid" ,SqlDbType.Int),
                                                                                     new SqlParameter( "@chargeid" , SqlDbType.Int),
                                                                                     new SqlParameter( "@curr",SqlDbType.VarChar,3),
                                                                                     new SqlParameter( "@rate",SqlDbType.Money),
             new SqlParameter( "@basetype",SqlDbType.VarChar,10),
             new SqlParameter( "@type",SqlDbType.VarChar,10)
          
            
            };
            objp[0].Value = cfsid;
            objp[1].Value = chargeid;
            objp[2].Value = curr;
            objp[3].Value = rate;
            objp[4].Value = basetype;
            objp[5].Value = type;

            ExecuteQuery("SPUPdmastercfschargedetails", objp);

        }


        public DataTable selCFSheaddtls(int cfsid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cfsid", SqlDbType.Int, 4) ,
             new SqlParameter( "@type",SqlDbType.VarChar,10)};
            objp[0].Value = cfsid;
            objp[1].Value = type;
            return ExecuteTable("SPselCFSheaddtls", objp);
        }


        public void DelcfschargeDetail(int cfsid, int intchargeid, String bases)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cfsid", SqlDbType.Int, 4),
                                                       new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@base", SqlDbType.VarChar, 10)
            };
            objp[0].Value = cfsid;
            objp[1].Value = intchargeid;
            objp[2].Value = bases;
            ExecuteQuery("SPDelcfschargeDetails", objp);

        }
        public DataTable Getcfschargesdtls4id(int cfsid, string type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@cfsid", SqlDbType.Int, 4), new SqlParameter("@type", SqlDbType.VarChar, 10) };
            objp[0].Value = cfsid;
            objp[1].Value = type;
            return ExecuteTable("SPGetcfschargesdtls4id", objp);
        }
        public DataTable GEtCFSdtls4consignee(int consigneeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@consigneeid", SqlDbType.Int, 4) };
            objp[0].Value = consigneeid;
            return ExecuteTable("SPGEtCFSdtls4consignee", objp);
        }

        public void InsChargeDetails4gst_new_24_08_2022(string chargename, string chargetype, string SACCode, double GSTP, double vat, int countryid, string reimbursement, string newinv)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     
                                                                                   

                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter( "@SACCode" , SqlDbType.VarChar,15),
                                                                                     new SqlParameter( "@GSTP" , SqlDbType.Real,4),
                                                                                     new SqlParameter( "@vat" , SqlDbType.Real,4),
                                                                                     new SqlParameter( "@countryid" , SqlDbType.Int),
                                                                                     new SqlParameter( "@reimbursement" , SqlDbType.VarChar,10),
                                                                                       new SqlParameter( "@newinv", SqlDbType.VarChar,10)

            };

            objp[0].Value = chargename;

            objp[1].Value = chargetype;
            objp[2].Value = SACCode;
            objp[3].Value = GSTP;
            objp[4].Value = vat;
            objp[5].Value = countryid;
            objp[6].Value = reimbursement;
            objp[7].Value = newinv;
            ExecuteQuery("SPInsChargeDetails4gst_new_06_10_2022", objp);
            //ExecuteQuery("SPInsChargeDetails4gst_new_24_08_2022", objp);

        }




        public void UpdChargeDetails4gstnew_24_08_2022(int chargeid, string chargename, string chargetype, string SACCode, double GSTP, int countryid, double VAT, string reimbursement, string newinv)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter( "@chargename" ,SqlDbType.VarChar,100),
                                                                                     new SqlParameter( "@chargeid",SqlDbType.Int),
                                                                                     new SqlParameter( "@chargetype",SqlDbType.VarChar,1),
                                                                                     new SqlParameter( "@SACCode",SqlDbType.VarChar,10),
                                                                                     new SqlParameter( "@GSTP",SqlDbType.Float,8),
                                                                                     new SqlParameter( "@countryid" ,SqlDbType.Int),
                                                                                     new SqlParameter( "@vat", SqlDbType.Real,4),
                                                                                     new SqlParameter( "@reimbursement", SqlDbType.VarChar,10),
                                                                                      new SqlParameter( "@newinv", SqlDbType.VarChar,10)

            };

            objp[0].Value = chargename;
            objp[1].Value = chargeid;
            objp[2].Value = chargetype;
            objp[3].Value = SACCode;
            objp[4].Value = GSTP;
            objp[5].Value = countryid;
            objp[6].Value = VAT;
            objp[7].Value = reimbursement;
            objp[8].Value = newinv;
            ExecuteQuery("SPUpdChargeDetails4gstnew_06_10_2022", objp);
            // ExecuteQuery("SPUpdChargeDetails4gstnew_24_08_2022", objp);
        }
        public DataTable GetLikeChargesName_new(string chargename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@txtcharges", SqlDbType.VarChar, 100) };
            objp[0].Value = chargename;
            return ExecuteTable("SPLikeChargesname_NEW", objp);
        }
        public DataTable GetLikeCurrency_new(string currency)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr", SqlDbType.VarChar, 3) };
            objp[0].Value = currency;
            return ExecuteTable("SPLikeCurr_NEW", objp);
        }
        public DataTable GetLikeCurrency4OS(string currency, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@curr", SqlDbType.VarChar, 3),
     new SqlParameter( "@bid" , SqlDbType.Int),
     };
            objp[0].Value = currency;
            objp[1].Value = bid;
            return ExecuteTable("SPLikeCurr4OS", objp);
        }
    }
}

