using System;
using System.Collections.Generic;
using System.Text;
using System .Data ;
using System .Data .SqlClient ;
namespace DataAccess
{
    public class FEAMSDetails:DBObject 
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public FEAMSDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsFEAMSDtls(string blno, string scacno, int mothervessel, string mothervoyage, int vesselcountry, int pol, DateTime  etd, int pod, DateTime eta,string nameofshipper, string saddress, int scity, string sstate, string szipcode, int scountry, string scontactname, string stelephone, string sfax, string nameoftheconsignee, string caddress, int ccity, string cstate, string czipcode, int ccountry, string ccontactname, string ctelephone, string cfax, string nameofthenotify1, string naddress, int ncity, string nstate, string nzipcode, int ncountry, string ncontactname, string ntelephone, string nfax, string nameofthenotify2, string address, int city, string state, string zipcode, int country, string contactname, string telephone, string fax, int por, int blpol, int blpod, int fd, string containernumber, string sealnumber, int quantity, int packagetype, string briefdescriptionofcargo, string htscode, string markandnumbers, int grwt,string mblno,string mscacno,DateTime dtpor,DateTime dtpol,DateTime dtpod,DateTime dtfd)
        {
            SqlParameter[] obj = new SqlParameter[]

            {
                new SqlParameter ("@blno",SqlDbType .VarChar ,30),
                new SqlParameter ("@scacno",SqlDbType .VarChar ,10),
                new SqlParameter ("@mothervessel",SqlDbType .Int ,4),
                new SqlParameter ("@mothervoyage",SqlDbType .VarChar ,15),
                new SqlParameter ("@vesselcountry",SqlDbType .Int ,4),
                new SqlParameter ("@pol",SqlDbType .Int ,4),
                new SqlParameter ("@etd",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@pod",SqlDbType .Int ,4),
                new SqlParameter ("@eta",SqlDbType .SmallDateTime ,4),
                new SqlParameter ("@nameofshipper",SqlDbType .VarChar ,100),
                new SqlParameter ("@saddress",SqlDbType .VarChar ,100),
                new SqlParameter ("@scity",SqlDbType .Int ,4),
                new SqlParameter ("@sstate",SqlDbType .VarChar ,25),
                new SqlParameter ("@szipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@scountry",SqlDbType .Int ,4),
                new SqlParameter ("@scontactname",SqlDbType .VarChar ,50),
                new SqlParameter ("@stelephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@sfax",SqlDbType .VarChar ,50),
                new SqlParameter ("@nameofconsignee",SqlDbType .VarChar ,100),
                new SqlParameter("@caddress",SqlDbType .VarChar ,100),
                new SqlParameter ("@ccity",SqlDbType .Int ,4),
                new SqlParameter ("@cstate",SqlDbType .VarChar ,25),
                new SqlParameter ("@czipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@ccountry",SqlDbType .Int ,4),
                new SqlParameter ("@ccontactname",SqlDbType .VarChar ,50),
                new SqlParameter("@ctelephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@cfax",SqlDbType .VarChar ,50),
                new SqlParameter ("@nameofnotify1",SqlDbType .VarChar ,100),
                new SqlParameter ("@naddress",SqlDbType .VarChar ,100),
                new SqlParameter ("@ncity",SqlDbType .Int ,4),
                new SqlParameter ("@nstate",SqlDbType .VarChar ,25),
                new SqlParameter ("@nzipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@ncountry",SqlDbType .Int ,4),
                new SqlParameter ("@ncontactname",SqlDbType .VarChar ,50),
                new SqlParameter ("@ntelephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@nfax",SqlDbType .VarChar ,50),
                new SqlParameter ("@nameofnotify2",SqlDbType .VarChar ,100),
                new SqlParameter ("@address",SqlDbType .VarChar ,100),
                new SqlParameter ("@city",SqlDbType .Int ,4),
                new SqlParameter ("@state",SqlDbType .VarChar ,25),
                new SqlParameter ("@zipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@country",SqlDbType .Int ,4),
                new SqlParameter ("@contactname",SqlDbType .VarChar ,50),
                new SqlParameter ("@telephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@fax",SqlDbType .VarChar ,50),
                new SqlParameter ("@por",SqlDbType.Int ,4),
                new SqlParameter ("@blpol",SqlDbType .Int ,4),
                new SqlParameter ("@blpod",SqlDbType .Int ,4),
                new SqlParameter ("@fd",SqlDbType .Int ,4),
                new SqlParameter ("@containerno",SqlDbType .VarChar ,12),
                new SqlParameter ("@sealnumber",SqlDbType .VarChar ,15),
                new SqlParameter ("@quantity",SqlDbType .VarChar ,10),
                new SqlParameter ("@packagetype",SqlDbType .Int ,2),
                new SqlParameter ("@briefdescriptionofcargo",SqlDbType.VarChar ,1000),
                new SqlParameter ("@htscode",SqlDbType .VarChar ,25),
                new SqlParameter ("@marksandnumbers",SqlDbType .VarChar ,500),
                new SqlParameter ("@grwt",SqlDbType.Real ,4),
                 new SqlParameter ("@mblno",SqlDbType .VarChar ,30),
                new SqlParameter ("@mscacno",SqlDbType .VarChar ,30),
                new SqlParameter ("@dtpor",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@dtpol",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@dtpod",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@dtfd",SqlDbType .SmallDateTime , 4)
            };
            obj[0].Value = blno;
            obj[1].Value = scacno;
            obj[2].Value = mothervessel;
            obj[3].Value = mothervoyage;
            obj[4].Value = vesselcountry;
            obj[5].Value = pol;
            obj[6].Value = etd;
            obj[7].Value = pod;
            obj[8].Value = eta;
            obj[9].Value = nameofshipper;
            obj[10].Value = saddress;
            obj[11].Value = scity;
            obj[12].Value = sstate;
            obj[13].Value = szipcode;
            obj[14].Value = scountry;
            obj[15].Value = scontactname;
            obj[16].Value = stelephone;
            obj[17].Value = sfax;
            obj[18].Value = nameoftheconsignee;
            obj[19].Value = caddress;
            obj[20].Value = ccity;
            obj[21].Value = cstate;
            obj[22].Value = czipcode;
            obj[23].Value = ccountry;
            obj[24].Value = ccontactname;
            obj[25].Value = ctelephone;
            obj[26].Value = cfax;
            obj[27].Value = nameofthenotify1;
            obj[28].Value = naddress;
            obj[29].Value = ncity;
            obj[30].Value = nstate;
            obj[31].Value = nzipcode;
            obj[32].Value = ncountry;
            obj[33].Value = ncontactname;
            obj[34].Value = ntelephone;
            obj[35].Value = nfax;
            obj[36].Value = nameofthenotify2;
            obj[37].Value = address;
            obj[38].Value = city;
            obj[39].Value = state;
            obj[40].Value = zipcode;
            obj[41].Value = country;
            obj[42].Value = contactname;
            obj[43].Value = telephone;
            obj[44].Value = fax;
            obj[45].Value = por;
            obj[46].Value = blpol;
            obj[47].Value = blpod;
            obj[48].Value = fd;
            obj[49].Value = containernumber;
            obj[50].Value = sealnumber;
            obj[51].Value = quantity;
            obj[52].Value = packagetype;
            obj[53].Value = briefdescriptionofcargo;
            obj[54].Value = htscode;
            obj[55].Value = markandnumbers;
            obj[56].Value = grwt;
            obj[57].Value = mblno;
            obj[58].Value = mscacno;
            obj[59].Value = dtpor;
            obj[60].Value = dtpol;
            obj[61].Value = dtpod;
            obj[62].Value = dtfd;
            ExecuteQuery("SPInsFEAMSDetails", obj);
        }


        public void UpdFEAMSDtls(string blno, string scacno, int mothervessel, string mothervoyage, int vesselcountry, int pol, DateTime etd, int pod, DateTime eta, string nameofshipper, string saddress, int scity, string sstate, string szipcode, int scountry, string scontactname, string stelephone, string sfax, string nameoftheconsignee, string caddress, int ccity, string cstate, string czipcode, int ccountry, string ccontactname, string ctelephone, string cfax, string nameofthenotify1, string naddress, int ncity, string nstate, string nzipcode, int ncountry, string ncontactname, string ntelephone, string nfax, string nameofthenotify2, string address, int city, string state, string zipcode, int country, string contactname, string telephone, string fax, int por, int blpol, int blpod, int fd, string containernumber, string sealnumber, int quantity, int packagetype, string briefdescriptionofcargo, string htscode, string markandnumbers, int grwt, string mblno, string mscacno, DateTime dtpor, DateTime dtpol, DateTime dtpod, DateTime dtfd)
        {
            SqlParameter[] obj = new SqlParameter[]

            {
                new SqlParameter ("@blno",SqlDbType .VarChar ,30),
                new SqlParameter ("@scacno",SqlDbType .VarChar ,10),
                new SqlParameter ("@mothervessel",SqlDbType .Int ,4),
                new SqlParameter ("@mothervoyage",SqlDbType .VarChar ,15),
                new SqlParameter ("@vesselcountry",SqlDbType .Int ,4),
                new SqlParameter ("@pol",SqlDbType .Int ,4),
                new SqlParameter ("@etd",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@pod",SqlDbType .Int ,4),
                new SqlParameter ("@eta",SqlDbType .SmallDateTime ,4),
                new SqlParameter ("@nameofshipper",SqlDbType .VarChar ,100),
                new SqlParameter ("@saddress",SqlDbType .VarChar ,100),
                new SqlParameter ("@scity",SqlDbType .Int ,4),
                new SqlParameter ("@sstate",SqlDbType .VarChar ,25),
                new SqlParameter ("@szipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@scountry",SqlDbType .Int ,4),
                new SqlParameter ("@scontactname",SqlDbType .VarChar ,50),
                new SqlParameter ("@stelephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@sfax",SqlDbType .VarChar ,50),
                new SqlParameter ("@nameofconsignee",SqlDbType .VarChar ,100),
                new SqlParameter("@caddress",SqlDbType .VarChar ,100),
                new SqlParameter ("@ccity",SqlDbType .Int ,4),
                new SqlParameter ("@cstate",SqlDbType .VarChar ,25),
                new SqlParameter ("@czipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@ccountry",SqlDbType .Int ,4),
                new SqlParameter ("@ccontactname",SqlDbType .VarChar ,50),
                new SqlParameter("@ctelephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@cfax",SqlDbType .VarChar ,50),
                new SqlParameter ("@nameofnotify1",SqlDbType .VarChar ,100),
                new SqlParameter ("@naddress",SqlDbType .VarChar ,100),
                new SqlParameter ("@ncity",SqlDbType .Int ,4),
                new SqlParameter ("@nstate",SqlDbType .VarChar ,25),
                new SqlParameter ("@nzipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@ncountry",SqlDbType .Int ,4),
                new SqlParameter ("@ncontactname",SqlDbType .VarChar ,50),
                new SqlParameter ("@ntelephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@nfax",SqlDbType .VarChar ,50),
                new SqlParameter ("@nameofnotify2",SqlDbType .VarChar ,100),
                new SqlParameter ("@address",SqlDbType .VarChar ,100),
                new SqlParameter ("@city",SqlDbType .Int ,4),
                new SqlParameter ("@state",SqlDbType .VarChar ,25),
                new SqlParameter ("@zipcode",SqlDbType .VarChar ,15),
                new SqlParameter ("@country",SqlDbType .Int ,4),
                new SqlParameter ("@contactname",SqlDbType .VarChar ,50),
                new SqlParameter ("@telephone",SqlDbType .VarChar ,50),
                new SqlParameter ("@fax",SqlDbType .VarChar ,50),
                new SqlParameter ("@por",SqlDbType.Int ,4),
                new SqlParameter ("@blpol",SqlDbType .Int ,4),
                new SqlParameter ("@blpod",SqlDbType .Int ,4),
                new SqlParameter ("@fd",SqlDbType .Int ,4),
                new SqlParameter ("@containerno",SqlDbType .VarChar ,12),
                new SqlParameter ("@sealnumber",SqlDbType .VarChar ,15),
                new SqlParameter ("@quantity",SqlDbType .VarChar ,10),
                new SqlParameter ("@packagetype",SqlDbType .Int ,2),
                new SqlParameter ("@briefdescriptionofcargo",SqlDbType.VarChar ,1000),
                new SqlParameter ("@htscode",SqlDbType .VarChar ,25),
                new SqlParameter ("@marksandnumbers",SqlDbType .VarChar ,500),
                new SqlParameter ("@grwt",SqlDbType.Real ,4),
                 new SqlParameter ("@mblno",SqlDbType .VarChar ,30),
                new SqlParameter ("@mscacno",SqlDbType.VarChar ,30),
                new SqlParameter ("@dtpor",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@dtpol",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@dtpod",SqlDbType .SmallDateTime , 4),
                new SqlParameter ("@dtfd",SqlDbType .SmallDateTime , 4)
            };
            obj[0].Value = blno;
            obj[1].Value = scacno;
            obj[2].Value = mothervessel;
            obj[3].Value = mothervoyage;
            obj[4].Value = vesselcountry;
            obj[5].Value = pol;
            obj[6].Value = etd;
            obj[7].Value = pod;
            obj[8].Value = eta;
            obj[9].Value = nameofshipper;
            obj[10].Value = saddress;
            obj[11].Value = scity;
            obj[12].Value = sstate;
            obj[13].Value = szipcode;
            obj[14].Value = scountry;
            obj[15].Value = scontactname;
            obj[16].Value = stelephone;
            obj[17].Value = sfax;
            obj[18].Value = nameoftheconsignee;
            obj[19].Value = caddress;
            obj[20].Value = ccity;
            obj[21].Value = cstate;
            obj[22].Value = czipcode;
            obj[23].Value = ccountry;
            obj[24].Value = ccontactname;
            obj[25].Value = ctelephone;
            obj[26].Value = cfax;
            obj[27].Value = nameofthenotify1;
            obj[28].Value = naddress;
            obj[29].Value = ncity;
            obj[30].Value = nstate;
            obj[31].Value = nzipcode;
            obj[32].Value = ncountry;
            obj[33].Value = ncontactname;
            obj[34].Value = ntelephone;
            obj[35].Value = nfax;
            obj[36].Value = nameofthenotify2;
            obj[37].Value = address;
            obj[38].Value = city;
            obj[39].Value = state;
            obj[40].Value = zipcode;
            obj[41].Value = country;
            obj[42].Value = contactname;
            obj[43].Value = telephone;
            obj[44].Value = fax;
            obj[45].Value = por;
            obj[46].Value = blpol;
            obj[47].Value = blpod;
            obj[48].Value = fd;
            obj[49].Value = containernumber;
            obj[50].Value = sealnumber;
            obj[51].Value = quantity;
            obj[52].Value = packagetype;
            obj[53].Value = briefdescriptionofcargo;
            obj[54].Value = htscode;
            obj[55].Value = markandnumbers;
            obj[56].Value = grwt;
            obj[57].Value = mblno;
            obj[58].Value = mscacno;
            obj[59].Value = dtpor;
            obj[60].Value = dtpol;
            obj[61].Value = dtpod;
            obj[62].Value = dtfd;
            ExecuteQuery("SPUpdFEAMSDetails", obj);
        }

        public DataTable GetAMSDetailswithBL(string strBlno,int bid,int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt, 1)};
            objp[0].Value = strBlno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelAMSFrmBL", objp);
        }

        public DataTable GetAMSAllDetails(string strBlno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30) };
            objp[0].Value = strBlno;
            return ExecuteTable("SPSelFEAMSDetails", objp);
        }
        public DataTable SelAMScontdetail(string strBlno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt, 1),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt, 1)};
            objp[0].Value = strBlno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPSelAMScontdetail", objp);
        }
    }
}
