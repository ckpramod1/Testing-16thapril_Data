using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace DataAccess.AirImportExports
{
    public class AIEBLDetails : DBObject
    {
        Masters.MasterPort prtObj = new Masters.MasterPort();
        Masters.MasterCustomer custObj = new Masters.MasterCustomer();
        Masters.MasterPackages pkgobj = new Masters.MasterPackages();
        Masters.MasterCountry currobj = new Masters.MasterCountry();

        string SPName;
        int intFromPortID;
        int intToPortID;
        int intShipperID;
        int intConsigneeID;
        int intNotifypartyID1;
        int intNotifypartyID2;
        int intissuedatID;
        int intcarrierID1;
        int intcarrierID2;
        int intcarrierID3;
        int inttoID1;
        int inttoID2;
        int inttoID3;
        int intpkgID;
        int intcnfID;


            public void GetDataBase(string Ccode)
            {
                Clientcode = Ccode;
                xyz(Ccode);


            }
            public AIEBLDetails()
            {
                Conn = new SqlConnection(DBCS);
            }

            public void InsAEBLDetails(int jobno, string hawblno, DateTime issuedon, string issuedat, string strshipper, string strSHloc, string strconsignee, string strCONloc, string strnotifyparty1, string strN1loc, string strnotifyparty2, string strN2loc, string strcnf, string strCNFloc, string strfromport, string strtoport, string strcarrier1, string strC1loc, string strpod1, string strcarrier2, string strC2loc, string strpod2, string strcarrier3, string strC3loc, string strpod3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, string rcamt, string Saddress, string Caddress, string N1address, string N2address, double rate, string accno, string accinfo, string chgscode, string wtnval, string other, double dv4carriage, double dv4customs, string sci, double wtchargepp, double wtchargecc, double valchargepp, double valchargecc, double dueagentpp, double dueagentcc, double duecarrpp, double duecarrcc, double ccr, double cccdestcurr, double destchrgs, double totccchrgs, string otherchrgs, string shortby1, string shortby2, int PreparedBy, int bid, int cid)
        {
            intFromPortID = prtObj.GetNPortid(strfromport);
            intToPortID = prtObj.GetNPortid(strtoport);
            intissuedatID = prtObj.GetNPortid(issuedat);
            inttoID1 = prtObj.GetNPortid(strpod1);
            inttoID2 = prtObj.GetNPortid(strpod2);
            inttoID3 = prtObj.GetNPortid(strpod3);
            intShipperID = custObj.GetCustomerid(strshipper, "Shipper", strSHloc);
            intConsigneeID = custObj.GetCustomerid(strconsignee, "Consignee", strCONloc);
            intNotifypartyID1 = custObj.GetCustomerid(strnotifyparty1, "Notify Party", strN1loc);
            intNotifypartyID2 = custObj.GetCustomerid(strnotifyparty2, "Notify Party", strN2loc);
            intcnfID = custObj.GetCustomerid(strcnf, "CHA / CNF", strCNFloc);
            intcarrierID1 = custObj.GetCustomerid(strcarrier1, "Carrier / Airliner / MLO / Freight Forwarder", strC1loc);
            intcarrierID2 = custObj.GetCustomerid(strcarrier2, "Carrier / Airliner / MLO / Freight Forwarder", strC2loc);
            intcarrierID3 = custObj.GetCustomerid(strcarrier3, "Carrier / Airliner / MLO / Freight Forwarder", strC3loc);
            intpkgID = pkgobj.GetNPackageid(strpkg);

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@sname",SqlDbType.VarChar,100),
                                                    new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@cname",SqlDbType.VarChar,100),
                                                    new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@n1name",SqlDbType.VarChar,100),
                                                    new SqlParameter("@n1address",SqlDbType.VarChar,250),
                                                    new SqlParameter("@n2name",SqlDbType.VarChar,100),
                                                    new SqlParameter("@n2address",SqlDbType.VarChar,250),
                                                    new SqlParameter("@rate",SqlDbType.Money,8),
                                                    new SqlParameter("@accno",SqlDbType.VarChar,25),
                                                    new SqlParameter("@accinfo",SqlDbType.VarChar,100),
                                                    new SqlParameter("@chgscode",SqlDbType.Char,1),
                                                    new SqlParameter("@wtnval",SqlDbType.Char,1),
                                                    new SqlParameter("@other",SqlDbType.Char,1),
                                                    new SqlParameter("@dv4carriage",SqlDbType.Money,8),
                                                    new SqlParameter("@dv4customs",SqlDbType.Money,8),
                                                    new SqlParameter("@sci",SqlDbType.VarChar,25),
                                                    new SqlParameter("@wtchargepp",SqlDbType.Money,8),
                                                    new SqlParameter("@wtchargecc",SqlDbType.Money,8),
                                                    new SqlParameter("@valchargepp",SqlDbType.Money,8),
                                                    new SqlParameter("@valchargecc",SqlDbType.Money,8),
                                                    new SqlParameter("@dueagentpp",SqlDbType.Money,8),
                                                    new SqlParameter("@dueagentcc", SqlDbType.Money,8),
                                                    new SqlParameter("@duecarrpp",SqlDbType.Money,8),
                                                    new SqlParameter("@duecarrcc",SqlDbType.Money,8),
                                                    new SqlParameter("@ccr",SqlDbType.Money,8),
                                                    new SqlParameter("@cccdestcurr",SqlDbType.Money,8),
                                                    new SqlParameter("@destchrgs",SqlDbType.Money,8),
                                                    new SqlParameter("@totccchrgs",SqlDbType.Money,8),
                                                    new SqlParameter("@otherchrgs",SqlDbType.VarChar,25),
                                                    new SqlParameter("@shortby1",SqlDbType.VarChar,3),
                                                    new SqlParameter("@shortby2", SqlDbType.VarChar, 3),
                                                    new SqlParameter("@preparedby",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = jobno;
            objp[1].Value = hawblno;
            objp[2].Value = issuedon;
            objp[3].Value = intissuedatID;
            objp[4].Value = intShipperID;
            objp[5].Value = intConsigneeID;
            objp[6].Value = intNotifypartyID1;
            objp[7].Value = intNotifypartyID2;
            objp[8].Value = intFromPortID;
            objp[9].Value = intToPortID;
            objp[10].Value = intcnfID;
            objp[11].Value = intcarrierID1;
            objp[12].Value = inttoID1;
            objp[13].Value = intcarrierID2;
            objp[14].Value = inttoID2;
            objp[15].Value = intcarrierID3;
            objp[16].Value = inttoID3;
            objp[17].Value = freight;
            objp[18].Value = curr;
            objp[19].Value = handling;
            objp[20].Value = noofpkg;
            objp[21].Value = intpkgID;
            objp[22].Value = rateclass;
            objp[23].Value = citemno;
            objp[24].Value = grosswt;
            objp[25].Value = chargewt;
            objp[26].Value = descn;
            objp[27].Value = nomination;
            objp[28].Value = strType;
            objp[29].Value = branchid;
            objp[30].Value = rcamt;
            objp[31].Value = strshipper;
            objp[32].Value = Saddress;
            objp[33].Value = strconsignee;
            objp[34].Value = Caddress;
            objp[35].Value = strnotifyparty1;
            objp[36].Value = N1address;
            objp[37].Value = strnotifyparty2;
            objp[38].Value = N2address;
            objp[39].Value = rate;
            objp[40].Value = accno;
            objp[41].Value = accinfo;
            objp[42].Value = chgscode;
            objp[43].Value = wtnval;
            objp[44].Value = other;
            objp[45].Value = dv4carriage;
            objp[46].Value = dv4customs;
            objp[47].Value = sci;
            objp[48].Value = wtchargepp;
            objp[49].Value = wtchargecc;
            objp[50].Value = valchargepp;
            objp[51].Value = valchargecc;
            objp[52].Value = dueagentpp;
            objp[53].Value = dueagentcc;
            objp[54].Value = duecarrpp;
            objp[55].Value = duecarrcc;
            objp[56].Value = ccr;
            objp[57].Value = cccdestcurr;
            objp[58].Value = destchrgs;
            objp[59].Value = totccchrgs;
            objp[60].Value = otherchrgs;
            objp[61].Value = shortby1;
            objp[62].Value = shortby2;
            objp[63].Value = PreparedBy;
            objp[64].Value = bid;
            objp[65].Value = cid;
            ExecuteQuery("SPInsAIEBLDetails", objp);
        }

        public void InsAEBLDetails(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs)
        {
            intpkgID = pkgobj.GetNPackageid(strpkg);

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500)};


            objp[0].Value = jobno;
            objp[1].Value = hawblno;
            objp[2].Value = issuedon;
            objp[3].Value = intissuedatID;
            objp[4].Value = intShipperID;
            objp[5].Value = intConsigneeID;
            objp[6].Value = intNotifypartyID1;
            objp[7].Value = intNotifypartyID2;
            objp[8].Value = intFromPortID;
            objp[9].Value = intToPortID;
            objp[10].Value = intcnfID;
            objp[11].Value = intcarrierID1;
            objp[12].Value = inttoID1;
            objp[13].Value = intcarrierID2;
            objp[14].Value = inttoID2;
            objp[15].Value = intcarrierID3;
            objp[16].Value = inttoID3;
            objp[17].Value = freight;
            objp[18].Value = curr;
            objp[19].Value = handling;
            objp[20].Value = noofpkg;
            objp[21].Value = intpkgID;
            objp[22].Value = rateclass;
            objp[23].Value = citemno;
            objp[24].Value = grosswt;
            objp[25].Value = chargewt;
            objp[26].Value = descn;
            objp[27].Value = nomination;
            objp[28].Value = strType;
            objp[29].Value = rcamt;
            objp[30].Value = salesid;
            objp[31].Value = cargoid;
            objp[32].Value = bid;
            objp[33].Value = cid;
            objp[34].Value = wttype;
            objp[35].Value = dvca;
            objp[36].Value = dvcu;
            objp[37].Value = chgcode;
            objp[38].Value = wtval;
            objp[39].Value = otherwt;
            objp[40].Value = inscurr;
            objp[41].Value = insamt;
            objp[42].Value = othchgs;
            ExecuteQuery("SPInsAIEBLDetails", objp);
        }

        public void InsAIEBLDimension(string hawblno, Double length, Double breadth, Double width, int pieces, char chrCMI, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@length",SqlDbType.Real,4),
                                                    new SqlParameter("@breadth",SqlDbType.Real,4),
                                                    new SqlParameter("@width",SqlDbType.Real,4),
                                                    new SqlParameter("@pieces",SqlDbType.Real,4),
                                                    new SqlParameter("@cminch",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = hawblno;
            objp[1].Value = length;
            objp[2].Value = breadth;
            objp[3].Value = width;
            objp[4].Value = pieces;
            objp[5].Value = chrCMI;
            objp[6].Value = strType;
            objp[7].Value = bid;
            objp[8].Value = cid;
            ExecuteQuery("SPInsAIEBLDimension", objp);
        }





        public void UpdAIEBLDetails(int jobno, string hawblno, DateTime issuedon, string issuedat, string strshipper, string strSHloc, string strconsignee, string strCONloc, string strnotifyparty1, string strN1loc, string strnotifyparty2, string strN2loc, string strcnf, string strCNFloc, string strfromport, string strtoport, string strcarrier1, string strC1loc, string strpod1, string strcarrier2, string strC2loc, string strpod2, string strcarrier3, string strC3loc, string strpod3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, string rcamt, string Saddress, string Caddress, string N1address, string N2address, double rate, string accno, string accinfo, string chgscode, string wtnval, string other, double dv4carriage, double dv4customs, string sci, double wtchargepp, double wtchargecc, double valchargepp, double valchargecc, double dueagentpp, double dueagentcc, double duecarrpp, double duecarrcc, double ccr, double cccdestcurr, double destchrgs, double totccchrgs, string otherchrgs, string shortby1, string shortby2, int bid, int cid)
        {
            intFromPortID = prtObj.GetNPortid(strfromport);
            intToPortID = prtObj.GetNPortid(strtoport);
            intissuedatID = prtObj.GetNPortid(issuedat);
            inttoID1 = prtObj.GetNPortid(strpod1);
            inttoID2 = prtObj.GetNPortid(strpod2);
            inttoID3 = prtObj.GetNPortid(strpod3);
            intShipperID = custObj.GetCustomerid(strshipper, "Shipper", strSHloc);
            intConsigneeID = custObj.GetCustomerid(strconsignee, "Consignee", strCONloc);
            intNotifypartyID1 = custObj.GetCustomerid(strnotifyparty1, "Notify Party", strN1loc);
            intNotifypartyID2 = custObj.GetCustomerid(strnotifyparty2, "Notify Party", strN2loc);
            intcnfID = custObj.GetCustomerid(strcnf, "CHA / CNF", strCNFloc);
            intcarrierID1 = custObj.GetCustomerid(strcarrier1, "Carrier / Airliner / MLO / Freight Forwarder", strC1loc);
            intcarrierID2 = custObj.GetCustomerid(strcarrier2, "Carrier / Airliner / MLO / Freight Forwarder", strC2loc);
            intcarrierID3 = custObj.GetCustomerid(strcarrier3, "Carrier / Airliner / MLO / Freight Forwarder", strC3loc);
            intpkgID = pkgobj.GetNPackageid(strpkg);

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@sname",SqlDbType.VarChar,100),
                                                    new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@cname",SqlDbType.VarChar,100),
                                                    new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@n1name",SqlDbType.VarChar,100),
                                                    new SqlParameter("@n1address",SqlDbType.VarChar,250),
                                                    new SqlParameter("@n2name",SqlDbType.VarChar,100),
                                                    new SqlParameter("@n2address",SqlDbType.VarChar,250),
                                                    new SqlParameter("@rate",SqlDbType.Money,8),
                                                    new SqlParameter("@accno",SqlDbType.VarChar,25),
                                                    new SqlParameter("@accinfo",SqlDbType.VarChar,100),
                                                    new SqlParameter("@chgscode",SqlDbType.Char,1),
                                                    new SqlParameter("@wtnval",SqlDbType.Char,1),
                                                    new SqlParameter("@other",SqlDbType.Char,1),
                                                    new SqlParameter("@dv4carriage",SqlDbType.Money,8),
                                                    new SqlParameter("@dv4customs",SqlDbType.Money,8),
                                                    new SqlParameter("@sci",SqlDbType.VarChar,25),
                                                    new SqlParameter("@wtchargepp",SqlDbType.Money,8),
                                                    new SqlParameter("@wtchargecc",SqlDbType.Money,8),
                                                    new SqlParameter("@valchargepp",SqlDbType.Money,8),
                                                    new SqlParameter("@valchargecc",SqlDbType.Money,8),
                                                    new SqlParameter("@dueagentpp",SqlDbType.Money,8),
                                                    new SqlParameter("@dueagentcc", SqlDbType.Money,8),
                                                    new SqlParameter("@duecarrpp",SqlDbType.Money,8),
                                                    new SqlParameter("@duecarrcc",SqlDbType.Money,8),
                                                    new SqlParameter("@ccr",SqlDbType.Money,8),
                                                    new SqlParameter("@cccdestcurr",SqlDbType.Money,8),
                                                    new SqlParameter("@destchrgs",SqlDbType.Money,8),
                                                    new SqlParameter("@totccchrgs",SqlDbType.Money,8),
                                                    new SqlParameter("@otherchrgs",SqlDbType.VarChar,25),
                                                    new SqlParameter("@shortby1",SqlDbType.VarChar,3),
                                                    new SqlParameter("@shortby2", SqlDbType.VarChar, 3),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};


            objp[0].Value = jobno;
            objp[1].Value = hawblno;
            objp[2].Value = issuedon;
            objp[3].Value = intissuedatID;
            objp[4].Value = intShipperID;
            objp[5].Value = intConsigneeID;
            objp[6].Value = intNotifypartyID1;
            objp[7].Value = intNotifypartyID2;
            objp[8].Value = intFromPortID;
            objp[9].Value = intToPortID;
            objp[10].Value = intcnfID;
            objp[11].Value = intcarrierID1;
            objp[12].Value = inttoID1;
            objp[13].Value = intcarrierID2;
            objp[14].Value = inttoID2;
            objp[15].Value = intcarrierID3;
            objp[16].Value = inttoID3;
            objp[17].Value = freight;
            objp[18].Value = curr;
            objp[19].Value = handling;
            objp[20].Value = noofpkg;
            objp[21].Value = intpkgID;
            objp[22].Value = rateclass;
            objp[23].Value = citemno;
            objp[24].Value = grosswt;
            objp[25].Value = chargewt;
            objp[26].Value = descn;
            objp[27].Value = nomination;
            objp[28].Value = strType;
            objp[29].Value = branchid;
            objp[30].Value = rcamt;
            objp[31].Value = strshipper;
            objp[32].Value = Saddress;
            objp[33].Value = strconsignee;
            objp[34].Value = Caddress;
            objp[35].Value = strnotifyparty1;
            objp[36].Value = N1address;
            objp[37].Value = strnotifyparty2;
            objp[38].Value = N2address;
            objp[39].Value = rate;
            objp[40].Value = accno;
            objp[41].Value = accinfo;
            objp[42].Value = chgscode;
            objp[43].Value = wtnval;
            objp[44].Value = other;
            objp[45].Value = dv4carriage;
            objp[46].Value = dv4customs;
            objp[47].Value = sci;
            objp[48].Value = wtchargepp;
            objp[49].Value = wtchargecc;
            objp[50].Value = valchargepp;
            objp[51].Value = valchargecc;
            objp[52].Value = dueagentpp;
            objp[53].Value = dueagentcc;
            objp[54].Value = duecarrpp;
            objp[55].Value = duecarrcc;
            objp[56].Value = ccr;
            objp[57].Value = cccdestcurr;
            objp[58].Value = destchrgs;
            objp[59].Value = totccchrgs;
            objp[60].Value = otherchrgs;
            objp[61].Value = shortby1;
            objp[62].Value = shortby2;
            objp[63].Value = bid;
            objp[64].Value = cid;
            ExecuteQuery("SPUpdAIEBLDetails", objp);
        }

        public void UpdAIEBLDetails(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, double oldchargewt, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs)
        {
           intpkgID = pkgobj.GetNPackageid(strpkg);

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@oldchargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500)};

            objp[0].Value = jobno;
            objp[1].Value = hawblno;
            objp[2].Value = issuedon;
            objp[3].Value = intissuedatID;
            objp[4].Value = intShipperID;
            objp[5].Value = intConsigneeID;
            objp[6].Value = intNotifypartyID1;
            objp[7].Value = intNotifypartyID2;
            objp[8].Value = intFromPortID;
            objp[9].Value = intToPortID;
            objp[10].Value = intcnfID;
            objp[11].Value = intcarrierID1;
            objp[12].Value = inttoID1;
            objp[13].Value = intcarrierID2;
            objp[14].Value = inttoID2;
            objp[15].Value = intcarrierID3;
            objp[16].Value = inttoID3;
            objp[17].Value = freight;
            objp[18].Value = curr;
            objp[19].Value = handling;
            objp[20].Value = noofpkg;
            objp[21].Value = intpkgID;
            objp[22].Value = rateclass;
            objp[23].Value = citemno;
            objp[24].Value = grosswt;
            objp[25].Value = chargewt;
            objp[26].Value = descn;
            objp[27].Value = nomination;
            objp[28].Value = strType;
            objp[29].Value = branchid;
            objp[30].Value = oldchargewt;
            objp[31].Value = rcamt;
            objp[32].Value = salesid;
            objp[33].Value = cargoid;
            objp[34].Value = bid;
            objp[35].Value = cid;
            objp[36].Value = wttype;
            objp[37].Value = dvca;
            objp[38].Value = dvcu;
            objp[39].Value = chgcode;
            objp[40].Value = wtval;
            objp[41].Value = otherwt;
            objp[42].Value = inscurr;
            objp[43].Value = insamt;
            objp[44].Value = othchgs;
            ExecuteQuery("SPUpdAIEBLDetails ", objp);

        }

        //Updating AI/AE BLDimension Details but process is deleting
        public void UpdAIEBLDimension(string hawblno, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = hawblno;
            objp[1].Value = strType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPDelAIEBLDimension  ", objp);
        }

        //Updating AI/AE BLDimension Details the process also update
        public void UpdAIEBLDimen(string strhawblno, double dbllength, double dblbreadth, double dblwidth, int intQty, char chrcminch, string strType, double dbllength1, double dblbreadth1, double dblwidth1, int intQty1, char chrcminch1, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@length",SqlDbType.Real,4),
                                                    new SqlParameter("@breadth",SqlDbType.Real,4),
                                                    new SqlParameter("@width",SqlDbType.Real,4),
                                                    new SqlParameter("@pieces",SqlDbType.Real,4),
                                                    new SqlParameter("@cminch",SqlDbType.VarChar,1),
                                                    new SqlParameter("@length1",SqlDbType.Real,4),
                                                    new SqlParameter("@breadth1",SqlDbType.Real,4),
                                                    new SqlParameter("@width1",SqlDbType.Real,4),
                                                    new SqlParameter("@pieces1",SqlDbType.Real,4),
                                                    new SqlParameter("@cminch1",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};

            objp[0].Value = strhawblno;
            objp[1].Value = dbllength;
            objp[2].Value = dblbreadth;
            objp[3].Value = dblwidth;
            objp[4].Value = intQty;
            objp[5].Value = chrcminch;
            objp[6].Value = dbllength1;
            objp[7].Value = dblbreadth1;
            objp[8].Value = dblwidth1;
            objp[9].Value = intQty1;
            objp[10].Value = chrcminch1;
            objp[11].Value = strType;
            objp[12].Value = bid;
            objp[13].Value = cid;
            ExecuteQuery("SPUpdAIEBLDimension ", objp);
        }

        //Return all AE or AI Details
        public DataTable GetAIEDetail(string strhawblno, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@hawblno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = strType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPSelAIEBLDetails";
            return ExecuteTable(SPName, objp);
        }


        public DataTable GetAIEBLDimension(string strhawblno, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@hawblno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = strType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPSelAIEBLDimension";
            return ExecuteTable(SPName, objp);
        }


        //----------------------------------------

        public void DelAIEBLDimension(string strhawblno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPDelAIEBLDimension ", objp);
        }

        public DataTable GetLikeAIEBLDetails(string strhawblno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPLikeAIEBLNo";
            return ExecuteTable(SPName, objp);
        }
        public DataTable GetLikeOTHERAIEBLDetails(string strhawblno, string chrType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = chrType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPLikeOTHERAIEBLNo";
            return ExecuteTable(SPName, objp);
        }
        //cost sheet
        public DataTable GetAIEDetail4CostSheet(string strhawblno, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@hawblno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = strType;
            objp[2].Value = bid;
            objp[3].Value = cid;
            SPName = "SPSelAIEBLDetails4CostSheet";
            return ExecuteTable(SPName, objp);
        }

        public void Updagreedrate(string ar, string ablno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@ar", SqlDbType.VarChar,1),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.Int,4) 
                                                     
            };

            objp[0].Value = ar;
            objp[1].Value = ablno;
            objp[2].Value = bid;

            ExecuteQuery("SPUpdagreedrate", objp);
        }


        public void InsAEBLChargeDtls(int jobno, int chargeid, double amount, string ppcc, string ablno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                  new SqlParameter("@jobno", SqlDbType.Int,4),
                new SqlParameter("@chargeid", SqlDbType.Int),
                                                       new SqlParameter("@amount", SqlDbType.Money, 8),
                                                       new SqlParameter("@freight",SqlDbType.Char,1),
                                                       new SqlParameter("@ablno",SqlDbType.VarChar,30),
          new SqlParameter("@bid", SqlDbType.Int,4)  };
            objp[0].Value = jobno;
            objp[1].Value = chargeid;
            objp[2].Value = amount;
            objp[3].Value = ppcc;
            objp[4].Value = ablno;
            objp[5].Value = bid;
            ExecuteQuery("SPInsAEBLChargedtls", objp);
        }

        public void DelAEBLChargeDtls(int jobno, string ablno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                  new SqlParameter("@jobno", SqlDbType.Int,4),
              
                                                       new SqlParameter("@ablno",SqlDbType.VarChar,30),
          new SqlParameter("@bid", SqlDbType.Int,4)  };
            objp[0].Value = jobno;

            objp[1].Value = ablno;
            objp[2].Value = bid;
            ExecuteQuery("SPDelAEBLChargedtls", objp);
        }
        public DataTable SelAEBLChargeDtls(int jobno, string ablno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                  new SqlParameter("@jobno", SqlDbType.Int,4),
              
                                                       new SqlParameter("@ablno",SqlDbType.VarChar,30),
          new SqlParameter("@bid", SqlDbType.Int,4)  };
            objp[0].Value = jobno;

            objp[1].Value = ablno;
            objp[2].Value = bid;
            return ExecuteTable("SPSelAEBLChargedtls", objp);
        }
        public void UpdAccInfo4febl(int jobno, string ablno, int bid, string accinfo)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@ablno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.Int,4) ,
                                                       new SqlParameter("@accinfo",SqlDbType.VarChar,250)
            };
            objp[0].Value = jobno;

            objp[1].Value = ablno;
            objp[2].Value = bid;
            objp[3].Value = accinfo;
            ExecuteQuery("SPUpdAccInfo4febl", objp);
        }
        public DataTable GetAEBLDtls(string strhawblno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@hawblno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPGetAEBLDtls", objp);
        }
        public void UpdAETextDtls(string sname, string saddress, string cname, string caddress, string n1name, string n1address, string n2name, string n2address, string poldetails, string poddetails, string blno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sname", SqlDbType.VarChar,200),
                                                       new SqlParameter("@saddress",SqlDbType.VarChar,500),
                                                       new SqlParameter("@cname", SqlDbType.VarChar,200) ,
                                                       new SqlParameter("@caddress",SqlDbType.VarChar,500),
                                                       new SqlParameter("@n1name", SqlDbType.VarChar,200),
                                                       new SqlParameter("@n1address",SqlDbType.VarChar,500),
                                                       new SqlParameter("@n2name", SqlDbType.VarChar,200) ,
                                                       new SqlParameter("@n2address",SqlDbType.VarChar,500),
                                                       new SqlParameter("@poldetails", SqlDbType.VarChar,200) ,
                                                       new SqlParameter("@poddetails",SqlDbType.VarChar,500),
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30) ,
                                                       new SqlParameter("@bid",SqlDbType.Int,4)
            };
            objp[0].Value = sname;
            objp[1].Value = saddress;
            objp[2].Value = cname;
            objp[3].Value = caddress;
            objp[4].Value = n1name;
            objp[5].Value = n1address;
            objp[6].Value = n2name;
            objp[7].Value = n2address;
            objp[8].Value = poldetails;
            objp[9].Value = poddetails;
            objp[10].Value = blno;
            objp[11].Value = bid;
            ExecuteQuery("SPUpdAETextDtls", objp);
        }
        public void InsDelOrd(int bid, int empid, string blno, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@branchid", SqlDbType.Int,4),
                                                       new SqlParameter("@empid",SqlDbType.Int,4),
                                                      new SqlParameter("@blno", SqlDbType.VarChar,100) ,
                                                       new SqlParameter("@jobno",SqlDbType.Int,4)
                                                     };
            objp[0].Value = bid;
            objp[1].Value = empid;
            objp[2].Value = blno;
            objp[3].Value = jobno;

            ExecuteQuery("SPInsDelOrd", objp);
        }

        public DataTable GetBkngDtls(string strhawblno, string strType, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@hawblno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = strhawblno;
            objp[1].Value = strType;
            objp[2].Value = bid;
            objp[3].Value = cid;

            return ExecuteTable("SPGetBkngDtls", objp);
        }


        public DataTable GetAIBLDtls4EDI(int jobno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int,4),
                                                       new SqlParameter("@bid",SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            return ExecuteTable("SPGetAIBLDetails4EDI", objp);
        }

        public DataTable GetAIJobDtls4EDI(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid", SqlDbType.Int, 4) };
            objp[0].Value = bid;
            return ExecuteTable("SPGetAIJobDetails4EDI", objp);
        }

        public DataTable ShowAIEInfoQuery(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@ftype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@cbm",SqlDbType.Real,8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = ftype;
            objp[3].Value = cbm;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;

            string str = "";
            if (trantype == "AE")
            {
                str = "SPSelAEInfo";
            }
            else if (trantype == "AI")
            {
                str = "SPSelAIInfo";
            }

            return ExecuteTable(str, objp);
        }
        public DataTable GetBLDetails4BLPrint(string strBlno, int intBranchID, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar,2)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            objp[2].Value = trantype;
            return ExecuteTable("SPAIEBLDetails4BLPrint", objp);
        }

        //

        public void updaeblminwt(int jobno, string blno, double minwt, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@hawblno", SqlDbType.VarChar,30),
                                                         new SqlParameter("@minwt", SqlDbType.Real,8),
                                                       new SqlParameter("@bid", SqlDbType.Int,4),
                                                                                                          
                                                      
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = minwt;
            objp[3].Value = bid;

            ExecuteQuery("spupdaeblminwt", objp);
        }
          //salquery
       public DataTable SalesShowFIInfo(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID, int salesid)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@ftype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@cbm",SqlDbType.Real,8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                       new SqlParameter ("@salesid",SqlDbType.Int ,4)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = ftype;
           objp[3].Value = cbm;
           objp[4].Value = intBranchID;
           objp[5].Value = intDivisionID;
           objp[6].Value = salesid;
           return ExecuteTable("SPSalesSelFIInfo", objp);
       }

       public DataTable GetLikeSalesOTHERIBL(string blno, int intBranchID, int intDivisionID, int salesid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                            new SqlParameter ("@salesid",SqlDbType .Int ,4)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           objp[3].Value = salesid;
           return ExecuteTable("SPLikeSalesOTHERFIBL", objp);
       }
       public DataTable GetLikeSalesFBLWOCJob(string blno, int intBranchID, int salesid)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter ("@salesid",SqlDbType .Int ,4)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;

           objp[2].Value = salesid;
           return ExecuteTable("SPLikeSalesFIFBLWOCJob", objp);
       }
       public DataTable Bookdetails(string trantype, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                          {
                                                               new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                               new SqlParameter("@bid",SqlDbType.TinyInt),
                                                               new SqlParameter("@cid",SqlDbType.TinyInt)
                                                          };
           objp[0].Value = trantype;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPBookBLPENDings", objp);
       }
       //cost sheet
       public DataTable ShowBLDetails4CostSheet(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                      new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPSelOIBLDetails4CostSheet", objp);
       }

       /// Import BL Transfer Created by Priya //////
       public DataTable GetBLDetail4Jobno(int jobno, int intBranchID, int portid)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@portid", SqlDbType.Int)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = portid;
           return ExecuteTable("SPGetFIBLdtls4Job", objp);
       }

       public void InsGRPFIBLTransfer(string blno, int branchid, int rjobno, int rbranchid)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@rjobno",SqlDbType.Int),
                                                       new SqlParameter("@rbranchid",SqlDbType.TinyInt,1) 
                                                     };

           objp[0].Value = blno;
           objp[1].Value = branchid;
           objp[2].Value = rjobno;
           objp[3].Value = rbranchid;
           ExecuteQuery("SPInsGRPFIBLTransfer", objp);
       }

       public int InsFIJobOnTransfer(int fjobno, int fbid, int fcid, int rbid, int rcid)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       new SqlParameter("@fjobno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@fbid",SqlDbType.TinyInt,1),
                                                          new SqlParameter("@fcid",SqlDbType.TinyInt,1),
                                                       
                                                       new SqlParameter("@rbid",SqlDbType.TinyInt,1), 
                                                          new SqlParameter("@rcid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@rjobno",SqlDbType.Int,4)
                                                     };

           objp[0].Value = fjobno;
           objp[1].Value = fbid;
           objp[2].Value = fcid;
           objp[3].Value = rbid;
           objp[4].Value = rcid;
           objp[5].Direction = ParameterDirection.Output;
           return ExecuteQuery("SPInsFIJobOnTransfer", objp, "@rjobno");

       }

       public void InsFIBLOnTransfer(int rjobno, int rbid, int rcid, string blno, int fjobno, int fbid, int fcid)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                       
                                                       new SqlParameter("@rjobno",SqlDbType.Int,4),
                                                       new SqlParameter("@rbid",SqlDbType.TinyInt,1), 
                                                          new SqlParameter("@rcid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@fjobno",SqlDbType.Int,4),
                                                         new SqlParameter("@fbid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@fcid",SqlDbType.TinyInt,1)
                                                              
                                                        
                                                     };

           objp[0].Value = rjobno;
           objp[1].Value = rbid;
           objp[2].Value = rcid;
           objp[3].Value = blno;
           objp[4].Value = fjobno;
           objp[5].Value = fbid;
           objp[6].Value = fcid;



           ExecuteQuery("SPInsFIBLOnTransfer", objp);

       }

       public DataTable chkBLTransfer(int fjobno, int fbid, string blno)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                     { 
                                                         new SqlParameter("@fjobno",SqlDbType.Int),
                                                       new SqlParameter("@fbid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30)
                                                     };
           objp[0].Value = fjobno;
           objp[1].Value = fbid;
           objp[2].Value = blno;


           return ExecuteTable("SPChkBLTransfer", objp);
       }
       public DataTable GetCustMail4BL(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetCustMail4BL", objp);
       }

       public DataTable GetJobDetails4Upld(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@intjobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPFIJobQry", objp);
       }

       public DataTable GetDOIssue(int branchid, int empid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@empid", SqlDbType.Int, 4) };
           objp[0].Value = branchid;
           objp[1].Value = empid;

           return ExecuteTable("SPGetDOIssue", objp);//SPGetInvRecptDtls
       }

       public int GetCont2040(string strBLNo, int intconttype, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@size", SqlDbType.VarChar,6),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = strBLNo;
           objp[1].Value = intconttype;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return int.Parse(ExecuteReader("SPFIGetContainerType", objp));
       }

       public DataTable GetCBMLimt4cont()
       {

           return ExecuteTable("SPSelCBMLimt");
       }

       public string GetminValue(int job, string blno, int branchid)
       {

           SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid",SqlDbType.Int)};
           objp[0].Value = job;
           objp[1].Value = blno;
           objp[2].Value = branchid;

           return ExecuteReader("sp_getminwt", objp);
       }
       public string GetHawBlNum(string hawblnum, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@hawblno",SqlDbType.VarChar,30),
               new SqlParameter("@trantype", SqlDbType.VarChar,2)
              };

           objp[0].Value = hawblnum;
           objp[1].Value = trantype;
           return ExecuteReader("SpGetHawblNum", objp);
       }

        //Dinesh


       public void insairFreightratereq(int cargoid, int fromport,int toport,int Commodity,int noofpkg,Double grosswt,string Dimensions,Double volume,string stackab,string dgno,string normaltemp,string shippaddr,string consigneeaddr,DateTime issuedon)
       {



           SqlParameter[] objp = new SqlParameter[]{
                                                    new SqlParameter("@cargoid",SqlDbType.VarChar,50),
                                                    new SqlParameter("@fromport",SqlDbType.VarChar,50),
                                                    new SqlParameter("@toport",SqlDbType.VarChar,50),
                                                    new SqlParameter("@Commodity",SqlDbType.VarChar,50),                                                                                                 
                                                    new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                     new SqlParameter("@Dimensions",SqlDbType.VarChar,50),
                                                    new SqlParameter("@volume",SqlDbType.Real,4),
                                                    new SqlParameter("@stackab",SqlDbType.VarChar,50),
                                                     new SqlParameter("@dgno",SqlDbType.VarChar,50),
                                                      new SqlParameter("@normaltemp",SqlDbType.VarChar,50),
                                                       new SqlParameter("@shippaddr",SqlDbType.VarChar,500),
                                                    new SqlParameter("@consigneeaddr",SqlDbType.VarChar,500),
                                                   new SqlParameter("@issuedon",SqlDbType.DateTime,8)};


           objp[0].Value = cargoid;
           objp[1].Value = fromport;
           objp[2].Value = toport;
           objp[3].Value = Commodity;
           objp[4].Value = noofpkg;
           objp[5].Value = grosswt;
           objp[6].Value = Dimensions;
           objp[7].Value = volume;
           objp[8].Value = stackab;
           objp[9].Value = dgno;
           objp[10].Value = normaltemp;
           objp[11].Value = shippaddr;
           objp[12].Value = consigneeaddr;
           objp[13].Value = issuedon;
           ExecuteQuery("SPInsairFreightratereq", objp);
       }

       //Dinesh

       public DataTable GetLikeAIEBLDetailsnew(string strhawblno, string chrType, int bid, int cid)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@cid",SqlDbType.TinyInt,1)};
           objp[0].Value = strhawblno;
           objp[1].Value = chrType;
           objp[2].Value = bid;
           objp[3].Value = cid;
           SPName = "SPLikeAIEBLNonew";
           return ExecuteTable(SPName, objp);
       }


       public void Delshipperinvoice(string shipperinv, string hawblno, int bid, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@shipperinvoice", SqlDbType.VarChar,50),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                       new SqlParameter("@branchid", SqlDbType.Int) ,
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)
                                                      
            };
           objp[0].Value = shipperinv;
           objp[1].Value = hawblno;
           objp[2].Value = bid;
           objp[3].Value = trantype;

           ExecuteQuery("sp_shipperinvoicedelete", objp);
       }

       //muthu

       public DataTable GetQuotchgs4debitcredit(int quotno, int bid, string bookingno)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
           objp[0].Value = quotno;
           objp[1].Value = bid;
           objp[2].Value = bookingno;
           return ExecuteTable("sp_autodebitcredit", objp);
       }


       public DataTable GetQuotchgs4debitcreditAI(int quotno, int bid, string bookingno)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
           objp[0].Value = quotno;
           objp[1].Value = bid;
           objp[2].Value = bookingno;
           return ExecuteTable("sp_autodebitcreditAI", objp);
       }

       public DataTable GetQuotchgs4InvAE(int quotno, int bid, string bookingno)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
           objp[0].Value = quotno;
           objp[1].Value = bid;
           objp[2].Value = bookingno;
           return ExecuteTable("SPGetQuotChgs4InvAE", objp);
       }

       public DataTable GetQuotchgs4InvAI(int quotno, int bid, string bookingno)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@quotno", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.Int,4),
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30)
                                                     };
           objp[0].Value = quotno;
           objp[1].Value = bid;
           objp[2].Value = bookingno;
           return ExecuteTable("SPGetQuotChgs4InvAI", objp);
       }

       public void InsAEBLDetailsAE(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt, string switchbl)
       {
           intpkgID = pkgobj.GetNPackageid(strpkg);

           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),new SqlParameter("@volwt",SqlDbType.Real,4), new SqlParameter("@swicthbl",SqlDbType.VarChar,3),   };


           objp[0].Value = jobno;
           objp[1].Value = hawblno;
           objp[2].Value = issuedon;
           objp[3].Value = intissuedatID;
           objp[4].Value = intShipperID;
           objp[5].Value = intConsigneeID;
           objp[6].Value = intNotifypartyID1;
           objp[7].Value = intNotifypartyID2;
           objp[8].Value = intFromPortID;
           objp[9].Value = intToPortID;
           objp[10].Value = intcnfID;
           objp[11].Value = intcarrierID1;
           objp[12].Value = inttoID1;
           objp[13].Value = intcarrierID2;
           objp[14].Value = inttoID2;
           objp[15].Value = intcarrierID3;
           objp[16].Value = inttoID3;
           objp[17].Value = freight;
           objp[18].Value = curr;
           objp[19].Value = handling;
           objp[20].Value = noofpkg;
           objp[21].Value = intpkgID;
           objp[22].Value = rateclass;
           objp[23].Value = citemno;
           objp[24].Value = grosswt;
           objp[25].Value = chargewt;
           objp[26].Value = descn;
           objp[27].Value = nomination;
           objp[28].Value = strType;
           objp[29].Value = rcamt;
           objp[30].Value = salesid;
           objp[31].Value = cargoid;
           objp[32].Value = bid;
           objp[33].Value = cid;
           objp[34].Value = wttype;
           objp[35].Value = dvca;
           objp[36].Value = dvcu;
           objp[37].Value = chgcode;
           objp[38].Value = wtval;
           objp[39].Value = otherwt;
           objp[40].Value = inscurr;
           objp[41].Value = insamt;
           objp[42].Value = othchgs;
           objp[43].Value = volwt;
           objp[44].Value = switchbl;

           ExecuteQuery("SPInsAIEBLDetailsae", objp);
       }


       public void InsAEBLDetailsAEnew(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt, string switchbl,int pallet)
       {
           intpkgID = pkgobj.GetNPackageid(strpkg);

           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),new SqlParameter("@volwt",SqlDbType.Real,4), new SqlParameter("@swicthbl",SqlDbType.VarChar,3), 
           
                                                            new SqlParameter("@noofpallet",SqlDbType.Int,4),
           
           };


           objp[0].Value = jobno;
           objp[1].Value = hawblno;
           objp[2].Value = issuedon;
           objp[3].Value = intissuedatID;
           objp[4].Value = intShipperID;
           objp[5].Value = intConsigneeID;
           objp[6].Value = intNotifypartyID1;
           objp[7].Value = intNotifypartyID2;
           objp[8].Value = intFromPortID;
           objp[9].Value = intToPortID;
           objp[10].Value = intcnfID;
           objp[11].Value = intcarrierID1;
           objp[12].Value = inttoID1;
           objp[13].Value = intcarrierID2;
           objp[14].Value = inttoID2;
           objp[15].Value = intcarrierID3;
           objp[16].Value = inttoID3;
           objp[17].Value = freight;
           objp[18].Value = curr;
           objp[19].Value = handling;
           objp[20].Value = noofpkg;
           objp[21].Value = intpkgID;
           objp[22].Value = rateclass;
           objp[23].Value = citemno;
           objp[24].Value = grosswt;
           objp[25].Value = chargewt;
           objp[26].Value = descn;
           objp[27].Value = nomination;
           objp[28].Value = strType;
           objp[29].Value = rcamt;
           objp[30].Value = salesid;
           objp[31].Value = cargoid;
           objp[32].Value = bid;
           objp[33].Value = cid;
           objp[34].Value = wttype;
           objp[35].Value = dvca;
           objp[36].Value = dvcu;
           objp[37].Value = chgcode;
           objp[38].Value = wtval;
           objp[39].Value = otherwt;
           objp[40].Value = inscurr;
           objp[41].Value = insamt;
           objp[42].Value = othchgs;
           objp[43].Value = volwt;
           objp[44].Value = switchbl;
           objp[45].Value = pallet;

           ExecuteQuery("SPInsAIEBLDetailsaenew", objp);
       }
      
        
        

        
        public void UpdAETextDtlsnew(string sname, string saddress, string cname, string caddress, string n1name, string n1address, string n2name, string n2address, string poldetails, string poddetails, string blno, int bid, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@sname", SqlDbType.VarChar,200),
                                                       new SqlParameter("@saddress",SqlDbType.VarChar,500),
                                                       new SqlParameter("@cname", SqlDbType.VarChar,200) ,
                                                       new SqlParameter("@caddress",SqlDbType.VarChar,500),
                                                       new SqlParameter("@n1name", SqlDbType.VarChar,200),
                                                       new SqlParameter("@n1address",SqlDbType.VarChar,500),
                                                       new SqlParameter("@n2name", SqlDbType.VarChar,200) ,
                                                       new SqlParameter("@n2address",SqlDbType.VarChar,500),
                                                       new SqlParameter("@poldetails", SqlDbType.VarChar,200) ,
                                                       new SqlParameter("@poddetails",SqlDbType.VarChar,500),
                                                       new SqlParameter("@blno", SqlDbType.VarChar,30) ,
                                                       new SqlParameter("@bid",SqlDbType.Int,4), new SqlParameter("@trantype",SqlDbType.VarChar,30)
            };
           objp[0].Value = sname;
           objp[1].Value = saddress;
           objp[2].Value = cname;
           objp[3].Value = caddress;
           objp[4].Value = n1name;
           objp[5].Value = n1address;
           objp[6].Value = n2name;
           objp[7].Value = n2address;
           objp[8].Value = poldetails;
           objp[9].Value = poddetails;
           objp[10].Value = blno;
           objp[11].Value = bid;
           objp[12].Value = trantype;
           ExecuteQuery("SPUpdAIAETextDtls", objp);
       }
       public void UpdAETextDtlsOurbl(string hawblno, int jobno, int bid, string ourbl)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@hawblno", SqlDbType.VarChar,50),
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.Int) ,
                                                       new SqlParameter("@Ourbl",SqlDbType.VarChar,2),
                                                      
            };
           objp[0].Value = hawblno;
           objp[1].Value = jobno;
           objp[2].Value = bid;
           objp[3].Value = ourbl;

           ExecuteQuery("spupd_aebldetails", objp);
       }



       public void UpdAIEBLDetailsAE(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, double oldchargewt, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt, string switchbl)
       {
           intpkgID = pkgobj.GetNPackageid(strpkg);

           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@oldchargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),
                                                        new SqlParameter("@volwt",SqlDbType.Real,4), new SqlParameter("@swicthbl",SqlDbType.VarChar,3),};

           objp[0].Value = jobno;
           objp[1].Value = hawblno;
           objp[2].Value = issuedon;
           objp[3].Value = intissuedatID;
           objp[4].Value = intShipperID;
           objp[5].Value = intConsigneeID;
           objp[6].Value = intNotifypartyID1;
           objp[7].Value = intNotifypartyID2;
           objp[8].Value = intFromPortID;
           objp[9].Value = intToPortID;
           objp[10].Value = intcnfID;
           objp[11].Value = intcarrierID1;
           objp[12].Value = inttoID1;
           objp[13].Value = intcarrierID2;
           objp[14].Value = inttoID2;
           objp[15].Value = intcarrierID3;
           objp[16].Value = inttoID3;
           objp[17].Value = freight;
           objp[18].Value = curr;
           objp[19].Value = handling;
           objp[20].Value = noofpkg;
           objp[21].Value = intpkgID;
           objp[22].Value = rateclass;
           objp[23].Value = citemno;
           objp[24].Value = grosswt;
           objp[25].Value = chargewt;
           objp[26].Value = descn;
           objp[27].Value = nomination;
           objp[28].Value = strType;
           objp[29].Value = branchid;
           objp[30].Value = oldchargewt;
           objp[31].Value = rcamt;
           objp[32].Value = salesid;
           objp[33].Value = cargoid;
           objp[34].Value = bid;
           objp[35].Value = cid;
           objp[36].Value = wttype;
           objp[37].Value = dvca;
           objp[38].Value = dvcu;
           objp[39].Value = chgcode;
           objp[40].Value = wtval;
           objp[41].Value = otherwt;
           objp[42].Value = inscurr;
           objp[43].Value = insamt;
           objp[44].Value = othchgs;
           objp[45].Value = volwt;
           objp[46].Value = switchbl;

           ExecuteQuery("SPUpdAIEBLDetailsae ", objp);

       }



       public void UpdAIEBLDetailsAEnew(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, double oldchargewt, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt, string switchbl ,int pallet)
       {
           intpkgID = pkgobj.GetNPackageid(strpkg);

           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@oldchargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),
                                                        new SqlParameter("@volwt",SqlDbType.Real,4), new SqlParameter("@swicthbl",SqlDbType.VarChar,3),
                                          new SqlParameter("@noofpallet",SqlDbType.Int,4),
           };

           objp[0].Value = jobno;
           objp[1].Value = hawblno;
           objp[2].Value = issuedon;
           objp[3].Value = intissuedatID;
           objp[4].Value = intShipperID;
           objp[5].Value = intConsigneeID;
           objp[6].Value = intNotifypartyID1;
           objp[7].Value = intNotifypartyID2;
           objp[8].Value = intFromPortID;
           objp[9].Value = intToPortID;
           objp[10].Value = intcnfID;
           objp[11].Value = intcarrierID1;
           objp[12].Value = inttoID1;
           objp[13].Value = intcarrierID2;
           objp[14].Value = inttoID2;
           objp[15].Value = intcarrierID3;
           objp[16].Value = inttoID3;
           objp[17].Value = freight;
           objp[18].Value = curr;
           objp[19].Value = handling;
           objp[20].Value = noofpkg;
           objp[21].Value = intpkgID;
           objp[22].Value = rateclass;
           objp[23].Value = citemno;
           objp[24].Value = grosswt;
           objp[25].Value = chargewt;
           objp[26].Value = descn;
           objp[27].Value = nomination;
           objp[28].Value = strType;
           objp[29].Value = branchid;
           objp[30].Value = oldchargewt;
           objp[31].Value = rcamt;
           objp[32].Value = salesid;
           objp[33].Value = cargoid;
           objp[34].Value = bid;
           objp[35].Value = cid;
           objp[36].Value = wttype;
           objp[37].Value = dvca;
           objp[38].Value = dvcu;
           objp[39].Value = chgcode;
           objp[40].Value = wtval;
           objp[41].Value = otherwt;
           objp[42].Value = inscurr;
           objp[43].Value = insamt;
           objp[44].Value = othchgs;
           objp[45].Value = volwt;
           objp[46].Value = switchbl;
           objp[47].Value = pallet;
           ExecuteQuery("SPUpdAIEBLDetailsaenew", objp);

       }

        
        
        
        
        public void InsAEBLDetails(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt)
       {
           intpkgID = pkgobj.GetNPackageid(strpkg);

           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),new SqlParameter("@volwt",SqlDbType.Real,4)};


           objp[0].Value = jobno;
           objp[1].Value = hawblno;
           objp[2].Value = issuedon;
           objp[3].Value = intissuedatID;
           objp[4].Value = intShipperID;
           objp[5].Value = intConsigneeID;
           objp[6].Value = intNotifypartyID1;
           objp[7].Value = intNotifypartyID2;
           objp[8].Value = intFromPortID;
           objp[9].Value = intToPortID;
           objp[10].Value = intcnfID;
           objp[11].Value = intcarrierID1;
           objp[12].Value = inttoID1;
           objp[13].Value = intcarrierID2;
           objp[14].Value = inttoID2;
           objp[15].Value = intcarrierID3;
           objp[16].Value = inttoID3;
           objp[17].Value = freight;
           objp[18].Value = curr;
           objp[19].Value = handling;
           objp[20].Value = noofpkg;
           objp[21].Value = intpkgID;
           objp[22].Value = rateclass;
           objp[23].Value = citemno;
           objp[24].Value = grosswt;
           objp[25].Value = chargewt;
           objp[26].Value = descn;
           objp[27].Value = nomination;
           objp[28].Value = strType;
           objp[29].Value = rcamt;
           objp[30].Value = salesid;
           objp[31].Value = cargoid;
           objp[32].Value = bid;
           objp[33].Value = cid;
           objp[34].Value = wttype;
           objp[35].Value = dvca;
           objp[36].Value = dvcu;
           objp[37].Value = chgcode;
           objp[38].Value = wtval;
           objp[39].Value = otherwt;
           objp[40].Value = inscurr;
           objp[41].Value = insamt;
           objp[42].Value = othchgs;
           objp[43].Value = volwt;
           ExecuteQuery("SPInsAIEBLDetails", objp);
       }




        public void InsAEBLDetailsnew(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt,int pallet)
        {
            intpkgID = pkgobj.GetNPackageid(strpkg);

            SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),new SqlParameter("@volwt",SqlDbType.Real,4),
                                                         new SqlParameter("@noofpallet",SqlDbType.Int,4)            
            };


            objp[0].Value = jobno;
            objp[1].Value = hawblno;
            objp[2].Value = issuedon;
            objp[3].Value = intissuedatID;
            objp[4].Value = intShipperID;
            objp[5].Value = intConsigneeID;
            objp[6].Value = intNotifypartyID1;
            objp[7].Value = intNotifypartyID2;
            objp[8].Value = intFromPortID;
            objp[9].Value = intToPortID;
            objp[10].Value = intcnfID;
            objp[11].Value = intcarrierID1;
            objp[12].Value = inttoID1;
            objp[13].Value = intcarrierID2;
            objp[14].Value = inttoID2;
            objp[15].Value = intcarrierID3;
            objp[16].Value = inttoID3;
            objp[17].Value = freight;
            objp[18].Value = curr;
            objp[19].Value = handling;
            objp[20].Value = noofpkg;
            objp[21].Value = intpkgID;
            objp[22].Value = rateclass;
            objp[23].Value = citemno;
            objp[24].Value = grosswt;
            objp[25].Value = chargewt;
            objp[26].Value = descn;
            objp[27].Value = nomination;
            objp[28].Value = strType;
            objp[29].Value = rcamt;
            objp[30].Value = salesid;
            objp[31].Value = cargoid;
            objp[32].Value = bid;
            objp[33].Value = cid;
            objp[34].Value = wttype;
            objp[35].Value = dvca;
            objp[36].Value = dvcu;
            objp[37].Value = chgcode;
            objp[38].Value = wtval;
            objp[39].Value = otherwt;
            objp[40].Value = inscurr;
            objp[41].Value = insamt;
            objp[42].Value = othchgs;
            objp[43].Value = volwt;
            objp[44].Value = pallet;
            ExecuteQuery("SPInsAIEBLDetailsnew", objp);
        }






       public void UpdAIEBLDetails(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, double oldchargewt, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt)
       {
           intpkgID = pkgobj.GetNPackageid(strpkg);

           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@oldchargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),
                                                        new SqlParameter("@volwt",SqlDbType.Real,4)};

           objp[0].Value = jobno;
           objp[1].Value = hawblno;
           objp[2].Value = issuedon;
           objp[3].Value = intissuedatID;
           objp[4].Value = intShipperID;
           objp[5].Value = intConsigneeID;
           objp[6].Value = intNotifypartyID1;
           objp[7].Value = intNotifypartyID2;
           objp[8].Value = intFromPortID;
           objp[9].Value = intToPortID;
           objp[10].Value = intcnfID;
           objp[11].Value = intcarrierID1;
           objp[12].Value = inttoID1;
           objp[13].Value = intcarrierID2;
           objp[14].Value = inttoID2;
           objp[15].Value = intcarrierID3;
           objp[16].Value = inttoID3;
           objp[17].Value = freight;
           objp[18].Value = curr;
           objp[19].Value = handling;
           objp[20].Value = noofpkg;
           objp[21].Value = intpkgID;
           objp[22].Value = rateclass;
           objp[23].Value = citemno;
           objp[24].Value = grosswt;
           objp[25].Value = chargewt;
           objp[26].Value = descn;
           objp[27].Value = nomination;
           objp[28].Value = strType;
           objp[29].Value = branchid;
           objp[30].Value = oldchargewt;
           objp[31].Value = rcamt;
           objp[32].Value = salesid;
           objp[33].Value = cargoid;
           objp[34].Value = bid;
           objp[35].Value = cid;
           objp[36].Value = wttype;
           objp[37].Value = dvca;
           objp[38].Value = dvcu;
           objp[39].Value = chgcode;
           objp[40].Value = wtval;
           objp[41].Value = otherwt;
           objp[42].Value = inscurr;
           objp[43].Value = insamt;
           objp[44].Value = othchgs;
           objp[45].Value = volwt;
           ExecuteQuery("SPUpdAIEBLDetails ", objp);

       }
       public void UpdAIEBLDetailsnew(int jobno, string hawblno, DateTime issuedon, int intissuedatID, int intShipperID, int intConsigneeID, int intNotifypartyID1, int intNotifypartyID2, int intcnfID, int intFromPortID, int intToPortID, int intcarrierID1, int inttoID1, int intcarrierID2, int inttoID2, int intcarrierID3, int inttoID3, char freight, string curr, string handling, int noofpkg, string strpkg, double rateclass, string citemno, Double grosswt, Double chargewt, string descn, string nomination, string strType, int branchid, double oldchargewt, string rcamt, int salesid, int cargoid, int bid, int cid, String wttype, int dvca, int dvcu, string chgcode, string wtval, string otherwt, string inscurr, double insamt, string othchgs, double volwt,int pallet)
       {
           intpkgID = pkgobj.GetNPackageid(strpkg);

           SqlParameter[] objp = new SqlParameter[]{new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@hawblno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@issuedon",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@issuedat",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty1",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty2",SqlDbType.Int,4),
                                                    new SqlParameter("@fromport",SqlDbType.Int,4),
                                                    new SqlParameter("@toport",SqlDbType.Int,4),
                                                    new SqlParameter("@cnf",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier1",SqlDbType.Int,4),
                                                    new SqlParameter("@pod1",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier2",SqlDbType.Int,4),
                                                    new SqlParameter("@pod2",SqlDbType.Int,4),
                                                    new SqlParameter("@carrier3",SqlDbType.Int,4),
                                                    new SqlParameter("@pod3",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                    new SqlParameter("@curr",SqlDbType.VarChar,3),
                                                    new SqlParameter("@handling",SqlDbType.VarChar,160),
                                                    new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int,2),
                                                    new SqlParameter("@rateclass",SqlDbType.Real,4),
                                                    new SqlParameter("@citemno",SqlDbType.VarChar,3),
                                                    new SqlParameter("@grosswt",SqlDbType.Real,4),
                                                    new SqlParameter("@chargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@descn",SqlDbType.VarChar,1000),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@oldchargewt",SqlDbType.Real,4),
                                                    new SqlParameter("@rcamt",SqlDbType.VarChar,20),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@wttype",SqlDbType.VarChar,1),
                                                        new SqlParameter("@dvca",SqlDbType.Int,4),
                                                        new SqlParameter("@dvcu",SqlDbType.Int,4),
                                                        new SqlParameter("@chgcode",SqlDbType.VarChar,2),
                                                        new SqlParameter("@wtval",SqlDbType.VarChar,2),
                                                        new SqlParameter("@other",SqlDbType.VarChar,2),
                                                        new SqlParameter("@inscurr",SqlDbType.VarChar,3),
                                                        new SqlParameter("@insamt",SqlDbType.Money,4),
                                                        new SqlParameter("@othchg",SqlDbType.VarChar,500),
                                                        new SqlParameter("@volwt",SqlDbType.Real,4),
             new SqlParameter("@noofpallet",SqlDbType.Int,4)};

           objp[0].Value = jobno;
           objp[1].Value = hawblno;
           objp[2].Value = issuedon;
           objp[3].Value = intissuedatID;
           objp[4].Value = intShipperID;
           objp[5].Value = intConsigneeID;
           objp[6].Value = intNotifypartyID1;
           objp[7].Value = intNotifypartyID2;
           objp[8].Value = intFromPortID;
           objp[9].Value = intToPortID;
           objp[10].Value = intcnfID;
           objp[11].Value = intcarrierID1;
           objp[12].Value = inttoID1;
           objp[13].Value = intcarrierID2;
           objp[14].Value = inttoID2;
           objp[15].Value = intcarrierID3;
           objp[16].Value = inttoID3;
           objp[17].Value = freight;
           objp[18].Value = curr;
           objp[19].Value = handling;
           objp[20].Value = noofpkg;
           objp[21].Value = intpkgID;
           objp[22].Value = rateclass;
           objp[23].Value = citemno;
           objp[24].Value = grosswt;
           objp[25].Value = chargewt;
           objp[26].Value = descn;
           objp[27].Value = nomination;
           objp[28].Value = strType;
           objp[29].Value = branchid;
           objp[30].Value = oldchargewt;
           objp[31].Value = rcamt;
           objp[32].Value = salesid;
           objp[33].Value = cargoid;
           objp[34].Value = bid;
           objp[35].Value = cid;
           objp[36].Value = wttype;
           objp[37].Value = dvca;
           objp[38].Value = dvcu;
           objp[39].Value = chgcode;
           objp[40].Value = wtval;
           objp[41].Value = otherwt;
           objp[42].Value = inscurr;
           objp[43].Value = insamt;
           objp[44].Value = othchgs;
           objp[45].Value = volwt;

           objp[46].Value = pallet;
           
           ExecuteQuery("SPUpdAIEBLDetailsnew", objp);

       }


       public void SPUpdAEhblreleasedon(string strBLNo, int intBranchID, int intDivisionID)
       {

           SqlParameter[] objp = new SqlParameter[] {
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),        
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

           objp[0].Value = strBLNo;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           ExecuteQuery("SPUpdAEhblreleasedon", objp);
       }



        //Dinesh

       public DataTable ShowchInfoQuery(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@ftype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@cbm",SqlDbType.Real,8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = ftype;
           objp[3].Value = cbm;
           objp[4].Value = intBranchID;
           objp[5].Value = intDivisionID;

           string str = "";

           str = "SPSelchInfo";
           
           

           return ExecuteTable(str, objp);
       }



       public DataTable ShowSeljobinfonew(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@ftype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@cbm",SqlDbType.Real,8),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,4)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = ftype;
           objp[3].Value = cbm;
           objp[4].Value = intBranchID;
           objp[5].Value = intDivisionID;
           objp[6].Value = trantype;

           string str = "";

           str = "SPSeljobinfonew";
           //if (trantype == "AE")
           //{
           //    str = "SPSelAEInfo";
           //}
           //else if (trantype == "AI")
           //{
           //    str = "SPSelAIInfo";
           //}



           return ExecuteTable(str, objp);
       }



    }
}



