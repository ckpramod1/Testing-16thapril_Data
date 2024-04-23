using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Masters;
using DataAccess.Marketing;

namespace DataAccess.ForwardingImports
{
   public class BLDetails:DBObject
    {
        //Variable Declaration.
        public int status;
        public int blissuedat;
        public int shipperid;
        public int consigneeid;
        public int notifypartyid;
        public int agentid;
        public int vesselid;
        public int pkgid;
        public char fgt;
        public int porid;
        public int podid;
        public int polid;
        public int fdid;
        public string jobdetails = "";

        MasterCustomer Custobj = new MasterCustomer();
        MasterVessel Vessobj = new MasterVessel();
        MasterPackages Pkgobj = new MasterPackages();
        MasterPort Portobj = new MasterPort();
        Quotation Quotobj = new Quotation();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BLDetails()
        {
            Conn = new SqlConnection(DBCS);
        }


        public void InsertBLDetails(int jobno, string blno, DateTime bldate, int blissuedat, int shipperid, string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty, string naddress, int agentid, int porid, int polid, int podid, int fdid, string marks, string desn, double cbm, double grswt, double ntwt, string shipment, string freight, int NoOfpkg, string unit, char nomination, string vessel, string voyage, int inttranshipedat, string unocode, string imocode, int fi20, int fi40, int branchid, string remarks, string blsurrendered, int intBranchID, int salesid, int PreparedBy, int cargoid, int intDivisionID)
        {
            if (shipment == "FCL/FCL")
                status = 1;
            else if (shipment == "FCL/LCL")
                status = 2;
            else if (shipment == "LCL/LCL")
                status = 3;
            else if (shipment == "LCL/FCL")
                status = 4;
           vesselid = Vessobj.GetVesselid(vessel);
           pkgid = Pkgobj.GetNPackageid(unit);
           fgt = Quotobj.GetFrighttype(freight);
           SqlParameter[] objp = new SqlParameter[]{ 
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@blissuedat",SqlDbType.Int),
                                                        new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                        new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                        new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                        new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                        new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                        new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                        new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@agentid",SqlDbType.Int,4),
                                                        new SqlParameter("@por",SqlDbType.Int,4),
                                                        new SqlParameter("@pol",SqlDbType.Int,4),
                                                        new SqlParameter("@pod",SqlDbType.Int,4),
                                                        new SqlParameter("@fd",SqlDbType.Int,4),
                                                        new SqlParameter("@freight",SqlDbType.VarChar,5),
                                                        new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@nomination",SqlDbType.VarChar,5),
                                                        new SqlParameter("@marks",SqlDbType.VarChar,250),
                                                        new SqlParameter("@desn",SqlDbType.VarChar,250),
                                                        new SqlParameter("@grswt",SqlDbType.Real,4),
                                                        new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                        new SqlParameter("@cbm",SqlDbType.Real,4),
                                                        new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                        new SqlParameter("@pkgid",SqlDbType.Int),
                                                        new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@transhipedat",SqlDbType.Int,4),
                                                        new SqlParameter("@unocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@imocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@fi20",SqlDbType.Int),
                                                        new SqlParameter("@fi40",SqlDbType.Int),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@blsurrendered",SqlDbType.VarChar,1),
                                                        new SqlParameter("@salesid",SqlDbType.Int),
                                                        new SqlParameter("@preparedby",SqlDbType.Int),
                                                        new SqlParameter("@cargoid",SqlDbType.Int),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                };
            objp[0].Value =  jobno;
            objp[1].Value =  blno;
            objp[2].Value =  bldate;
            objp[3].Value =  blissuedat;
            objp[4].Value =  shipperid;
            objp[5].Value = shipper;
            objp[6].Value =  saddress;
            objp[7].Value =  consigneeid;
            objp[8].Value =  consignee;
            objp[9].Value =  caddress;
            objp[10].Value =  notifypartyid;
            objp[11].Value =  notifyparty;
            objp[12].Value =  naddress;
            objp[13].Value =  agentid;
            objp[14].Value = porid;
            objp[15].Value =  polid;
            objp[16].Value =  podid;
            objp[17].Value =  fdid;
            objp[18].Value =  fgt;
            objp[19].Value =  status ;
            objp[20].Value =  nomination;
            objp[21].Value =  marks;
            objp[22].Value =  desn;
            objp[23].Value =  grswt;
            objp[24].Value =  ntwt;
            objp[25].Value =  cbm;
            objp[26].Value =  NoOfpkg;
            objp[27].Value =  pkgid;
            objp[28].Value =  vesselid;
            objp[29].Value =  voyage;
            objp[30].Value = inttranshipedat;
            objp[31].Value =  unocode;
            objp[32].Value =  imocode;
            objp[33].Value = fi20;
            objp[34].Value = fi40;
            objp[35].Value = intBranchID;
            objp[36].Value = remarks;
            objp[37].Value = blsurrendered;
            objp[38].Value = salesid;
            objp[39].Value = PreparedBy;
            objp[40].Value = cargoid;
            objp[41].Value = intDivisionID;
            ExecuteQuery("SPInsOIBLdetails",objp);
        }

       public void InsertAmendBLDetails(int jobno, string blno, DateTime bldate, int blissuedat, int shipperid, string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty, string naddress, int agentid, int porid, int polid, int podid, int fdid, string marks, string desn, double cbm, double grswt, double ntwt, string shipment, string freight, int NoOfpkg, string unit, char nomination, string vessel, string voyage, int inttranshipedat, string unocode, string imocode, int fi20, int fi40, int branchid, string remarks, int intDivisionID)
       {
           if (shipment == "FCL/FCL")
               status = 1;
           else if (shipment == "FCL/LCL")
               status = 2;
           else if (shipment == "LCL/LCL")
               status = 3;
           else if (shipment == "LCL/FCL")
               status = 4;
           vesselid = Vessobj.GetVesselid(vessel);
           pkgid = Pkgobj.GetNPackageid(unit);
           fgt = Quotobj.GetFrighttype(freight);
           SqlParameter[] objp = new SqlParameter[]{ 
                                                    new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@blissuedat",SqlDbType.Int),
                                                    new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                    new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                    new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                    new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@agentid",SqlDbType.Int,4),
                                                    new SqlParameter("@por",SqlDbType.Int,4),
                                                    new SqlParameter("@pol",SqlDbType.Int,4),
                                                    new SqlParameter("@pod",SqlDbType.Int,4),
                                                    new SqlParameter("@fd",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,5),
                                                    new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,5),
                                                    new SqlParameter("@marks",SqlDbType.VarChar,250),
                                                    new SqlParameter("@desn",SqlDbType.VarChar,250),
                                                    new SqlParameter("@grswt",SqlDbType.Real,4),
                                                    new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                    new SqlParameter("@cbm",SqlDbType.Real,4),
                                                    new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int),
                                                    new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                    new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                    new SqlParameter("@transhipedat",SqlDbType.Int,6),
                                                    new SqlParameter("@unocode",SqlDbType.VarChar,5),
                                                    new SqlParameter("@imocode",SqlDbType.VarChar,5),
                                                    new SqlParameter("@fi20",SqlDbType.Int),
                                                    new SqlParameter("@fi40",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt)};
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = bldate;
           objp[3].Value = blissuedat;
           objp[4].Value = shipperid;
           objp[5].Value = shipper;
           objp[6].Value = saddress;
           objp[7].Value = consigneeid;
           objp[8].Value = consignee;
           objp[9].Value = caddress;
           objp[10].Value = notifypartyid;
           objp[11].Value = notifyparty;
           objp[12].Value = naddress;
           objp[13].Value = agentid;
           objp[14].Value = porid;
           objp[15].Value = polid;
           objp[16].Value = podid;
           objp[17].Value = fdid;
           objp[18].Value = fgt;
           objp[19].Value = status;
           objp[20].Value = nomination;
           objp[21].Value = marks;
           objp[22].Value = desn;
           objp[23].Value = grswt;
           objp[24].Value = ntwt;
           objp[25].Value = cbm;
           objp[26].Value = NoOfpkg;
           objp[27].Value = pkgid;
           objp[28].Value = vesselid;
           objp[29].Value = voyage;
           objp[30].Value = inttranshipedat;
           objp[31].Value = unocode;
           objp[32].Value = imocode;
           objp[33].Value = fi20;
           objp[34].Value = fi40;
           objp[35].Value = branchid;
           objp[36].Value = remarks;
           objp[37].Value = intDivisionID ;
           ExecuteQuery("SPInsFIAmendBLdetails", objp);
       }

       public void InsertFBLDetails(int jobno, string blno, DateTime bldate, int blissuedat, int shipperid, string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty, string naddress, int agentid, int porid, int polid, int podid, int fdid, string marks, string desn, double cbm, double grswt, double ntwt, string shipment, string freight, int NoOfpkg, string unit, char nomination, string vessel, string voyage, int inttranshipedat, string unocode, string imocode, string remarks, int intBranchID, int salesid, int cargoid, int intDivisionID, string fblsurrendered)
        {
            if (shipment == "FCL/FCL")
                status = 1;
            else if (shipment == "FCL/LCL")
                status = 2;
            else if (shipment == "LCL/LCL")
                status = 3;
            else if (shipment == "LCL/FCL")
                status = 4;
            vesselid = Vessobj.GetVesselid(vessel);
            pkgid = Pkgobj.GetNPackageid(unit);
            fgt = Quotobj.GetFrighttype(freight);
            SqlParameter[] objp = new SqlParameter[]
                                                   { 
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@blissuedat",SqlDbType.Int),
                                                        new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                        new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                        new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                        new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                        new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                        new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                        new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@agentid",SqlDbType.Int,4),
                                                        new SqlParameter("@por",SqlDbType.Int,4),
                                                        new SqlParameter("@pol",SqlDbType.Int,4),
                                                        new SqlParameter("@pod",SqlDbType.Int,4),
                                                        new SqlParameter("@fd",SqlDbType.Int,4),
                                                        new SqlParameter("@freight",SqlDbType.VarChar,5),
                                                        new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@nomination",SqlDbType.VarChar,5),
                                                        new SqlParameter("@marks",SqlDbType.VarChar,250),
                                                        new SqlParameter("@desn",SqlDbType.VarChar,250),
                                                        new SqlParameter("@grswt",SqlDbType.Real,4),
                                                        new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                        new SqlParameter("@cbm",SqlDbType.Real,4),
                                                        new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                        new SqlParameter("@pkgid",SqlDbType.Int),
                                                        new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@transhipedat",SqlDbType.Int,6),
                                                        new SqlParameter("@unocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@imocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@salesid",SqlDbType.Int),
                                                        new SqlParameter("@cargoid",SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter("@fblsurrendered", SqlDbType.VarChar,1)
                                                   };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = bldate;
            objp[3].Value = blissuedat;
            objp[4].Value = shipperid;
            objp[5].Value = shipper;
            objp[6].Value = saddress;
            objp[7].Value = consigneeid;
            objp[8].Value = consignee;
            objp[9].Value = caddress;
            objp[10].Value = notifypartyid;
            objp[11].Value = notifyparty;
            objp[12].Value = naddress;
            objp[13].Value = agentid;
            objp[14].Value = porid;
            objp[15].Value = polid;
            objp[16].Value = podid;
            objp[17].Value = fdid;
            objp[18].Value = fgt;
            objp[19].Value = status;
            objp[20].Value = nomination;
            objp[21].Value = marks;
            objp[22].Value = desn;
            objp[23].Value = grswt;
            objp[24].Value = ntwt;
            objp[25].Value = cbm;
            objp[26].Value = NoOfpkg;
            objp[27].Value = pkgid;
            objp[28].Value = vesselid;
            objp[29].Value = voyage;
            objp[30].Value = inttranshipedat;
            objp[31].Value = unocode;
            objp[32].Value = imocode;
            objp[33].Value = remarks;
            objp[34].Value = salesid;
            objp[35].Value = cargoid;
            objp[36].Value = intBranchID;
            objp[37].Value = intDivisionID;
            objp[38].Value = fblsurrendered;
            ExecuteQuery("SPInsFIFBLdetails", objp);
        }

        //Insert SplitBLDetails.M
       public void InsertSBLDetails(int jobno, string blno, DateTime bldate, int blissuedat, int shipperid, string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty, string naddress, int agentid, int porid, int polid, int podid, int fdid, string marks, string desn, double cbm, double grswt, double ntwt, string shipment, string freight, int NoOfpkg, string unit, char nomination, string vessel, string voyage, int inttranshipedat, string unocode, string imocode, string splitbl, int fi20, int fi40, string remarks, string blsurrendered, int intBranchID, int salesid, int cargoid, int intDivisionID)
       {
           if (shipment == "FCL/FCL")
               status = 1;
           else if (shipment == "FCL/LCL")
               status = 2;
           else if (shipment == "LCL/LCL")
               status = 3;
           else if (shipment == "LCL/FCL")
               status = 4;
           vesselid = Vessobj.GetVesselid(vessel);
           pkgid = Pkgobj.GetNPackageid(unit);
           fgt = Quotobj.GetFrighttype(freight);
           SqlParameter[] objp = new SqlParameter[]{
                                                    new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                    new SqlParameter("@blissuedat",SqlDbType.Int),
                                                    new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                    new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                    new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                    new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                    new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                    new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                    new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                    new SqlParameter("@agentid",SqlDbType.Int,4),
                                                    new SqlParameter("@por",SqlDbType.Int,4),
                                                    new SqlParameter("@pol",SqlDbType.Int,4),
                                                    new SqlParameter("@pod",SqlDbType.Int,4),
                                                    new SqlParameter("@fd",SqlDbType.Int,4),
                                                    new SqlParameter("@freight",SqlDbType.VarChar,5),
                                                    new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@nomination",SqlDbType.VarChar,5),
                                                    new SqlParameter("@marks",SqlDbType.VarChar,250),
                                                    new SqlParameter("@desn",SqlDbType.VarChar,250),
                                                    new SqlParameter("@grswt",SqlDbType.Real,4),
                                                    new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                    new SqlParameter("@cbm",SqlDbType.Real,4),
                                                    new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                    new SqlParameter("@pkgid",SqlDbType.Int),
                                                    new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                    new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                    new SqlParameter("@transhipedat",SqlDbType.Int,6),
                                                    new SqlParameter("@unocode",SqlDbType.VarChar,5),
                                                    new SqlParameter("@imocode",SqlDbType.VarChar,5),
                                                    new SqlParameter("@splitbl",SqlDbType.VarChar,30),
                                                    new SqlParameter("@fi20",SqlDbType.Int),
                                                    new SqlParameter("@fi40",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                    new SqlParameter("@blsurrendered",SqlDbType.VarChar,1),
                                                    new SqlParameter("@salesid",SqlDbType.Int),
                                                    new SqlParameter("@cargoid",SqlDbType.Int),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt)};
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = bldate;
           objp[3].Value = blissuedat;
           objp[4].Value = shipperid;
           objp[5].Value = shipper;
           objp[6].Value = saddress;
           objp[7].Value = consigneeid;
           objp[8].Value = consignee;
           objp[9].Value = caddress;
           objp[10].Value = notifypartyid;
           objp[11].Value = notifyparty;
           objp[12].Value = naddress;
           objp[13].Value = agentid;
           objp[14].Value = porid;
           objp[15].Value = polid;
           objp[16].Value = podid;
           objp[17].Value = fdid;
           objp[18].Value = fgt;
           objp[19].Value = status;
           objp[20].Value = nomination;
           objp[21].Value = marks;
           objp[22].Value = desn;
           objp[23].Value = grswt;
           objp[24].Value = ntwt;
           objp[25].Value = cbm;
           objp[26].Value = NoOfpkg;
           objp[27].Value = pkgid;
           objp[28].Value = vesselid;
           objp[29].Value = voyage;
           objp[30].Value = inttranshipedat;
           objp[31].Value = unocode;
           objp[32].Value = imocode;
           objp[33].Value = splitbl;
           objp[34].Value = fi20;
           objp[35].Value = fi40;
           objp[36].Value = intBranchID;
           objp[37].Value = remarks;
           objp[38].Value = blsurrendered;
           objp[39].Value = salesid;
           objp[40].Value = cargoid;
           objp[41].Value = intDivisionID;
           ExecuteQuery("SPInsOIBLdetails", objp);
       }
   
        //****** Container Details ********
        //Insert Container details.M

       public void InsertContDetails(int jobno, string blno, string containerno, int intBranchID, int intDivisionID)
        {
            string sealno = "";
            int total = 0;
            double wgt = 0;
            Dt = GetContainerDetails(jobno, containerno,intBranchID,intDivisionID);
            String size = Dt.Rows[0].ItemArray[3].ToString();
            if (Dt.Rows[0].ItemArray[4].ToString() != "")
            {
                 sealno = Dt.Rows[0].ItemArray[4].ToString();
            }
            else
            {
                 sealno = "";
            }
            
            if (Dt.Rows[0].ItemArray[5].ToString() != "")
            {
                 total = int.Parse(Dt.Rows[0].ItemArray[5].ToString());
            }
            else
            {
                 total = 0;
            }
            if (Dt.Rows[0].ItemArray[6].ToString() != "")
            {
                wgt = double.Parse(Dt.Rows[0].ItemArray[6].ToString());
            }
            else
            {
                 wgt = 0;
            }
          
            //int wgt = int.Parse(Dt.Rows[0].ItemArray[6].ToString());
            string isocode = Dt.Rows[0].ItemArray[7].ToString();
            char socflag = char.Parse(Dt.Rows[0].ItemArray[8].ToString());

            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@jobno",SqlDbType.Int),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                         new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@total",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Real,4),
                                                         new SqlParameter("@isocode",SqlDbType.VarChar,10),
                                                         new SqlParameter("@socflag",SqlDbType.VarChar,1),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = containerno;
            objp[3].Value = size;
            objp[4].Value = sealno;
            objp[5].Value = total;
            objp[6].Value = wgt;
            objp[7].Value = isocode;
            objp[8].Value = socflag;
            objp[9].Value = intBranchID;
            objp[10].Value = intDivisionID;
            ExecuteQuery("SPInsFIContainer", objp);
        }

       public void InsertAmendContDetails(int jobno, string blno, string containerno, int intBranchID, int intDivisionID)
       {
           string sealno = "";
           int total = 0;
           double wgt = 0;
           Dt = GetContainerDetails(jobno, containerno, intBranchID, intDivisionID);
           String size = Dt.Rows[0].ItemArray[3].ToString();
           if (Dt.Rows[0].ItemArray[4].ToString() != "")
               sealno = Dt.Rows[0].ItemArray[4].ToString();
           else
               sealno = "";
           if (Dt.Rows[0].ItemArray[5].ToString() != "")
               total = int.Parse(Dt.Rows[0].ItemArray[5].ToString());
           else
               total = 0;
           if (Dt.Rows[0].ItemArray[6].ToString() != "")
               wgt = double.Parse(Dt.Rows[0].ItemArray[6].ToString());
           else
               wgt = 0;
           string isocode = Dt.Rows[0].ItemArray[7].ToString();
           char socflag = char.Parse(Dt.Rows[0].ItemArray[8].ToString());

           SqlParameter[] objp = new SqlParameter[] {    new SqlParameter("@jobno",SqlDbType.Int),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@sizetype",SqlDbType.VarChar,6),
                                                         new SqlParameter("@sealno",SqlDbType.VarChar,15),
                                                         new SqlParameter("@total",SqlDbType.Int,4),
                                                         new SqlParameter("@weight",SqlDbType.Real,4),
                                                         new SqlParameter("@isocode",SqlDbType.VarChar,10),
                                                         new SqlParameter("@socflag",SqlDbType.VarChar,1),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = containerno;
           objp[3].Value = size;
           objp[4].Value = sealno;
           objp[5].Value = total;
           objp[6].Value = wgt;
           objp[7].Value = isocode;
           objp[8].Value = socflag;
           objp[9].Value = intBranchID;
           objp[10].Value = intDivisionID;
           ExecuteQuery("SPInsFIAmendContainer", objp);
       }


       public void DelAmendContDetails(int jobno, string blno, string containerno, int intBranchID,int intDivisionID)
       {    
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@jobno",SqlDbType.Int),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                         new SqlParameter("@bid",SqlDbType.TinyInt),
                                                         new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = containerno;
           objp[3].Value = intBranchID;
           objp[4].Value = intDivisionID;
           ExecuteQuery("SPDelFIAmendContainer", objp);
       }


        //Show container details for job. 
       public DataTable GetContainerDetail(int jobno, string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return ExecuteTable("SPFIContDtls", objp);
       }



       public DataTable GetAmendContainerDetail(int jobno, string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return ExecuteTable("SPFIAmendContDtls", objp);
       }



       public string GetBookinkNo(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteReader("SPGetBookingno", objp);
       }

       public DataTable GetBLDetailJobno(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetOIBLDetailsJobno", objp);
       }

       public DataTable GetBLDtJobno(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetFIBLDtsJobno", objp);
       }


       //Kumar





       public DataTable GetBLDtJobnoNew(int jobno, int intBranchID, int intDivisionID,string type)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                        new SqlParameter ("@type",SqlDbType.Char,1)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           objp[3].Value = type;
           return ExecuteTable("SPGetFIBLDtsJobnoNew", objp);
       }




       public DataTable GetBLContDtJobno(int jobno,int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetFIContDtJobno", objp);
       }

        //Get Container Details using jobno and contno
       public DataTable GetContainerDetails(int jobno, string containerno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@contno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = containerno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPFIContainer", objp);
         }


        //Get containername basedon jobno and blno. 
       public DataTable GetContainerName(int jobno, string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return ExecuteTable("SPFICheckcontainer", objp);
       }




       public DataTable GetAmendContainerName(int jobno, string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {  
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                   };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return ExecuteTable("SPFIAmendCheckcontainer", objp);
       }


        //Get container sizetype
       public int GetContainersizetype(string blno, int size, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@size",SqlDbType.VarChar,5),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
           objp[0].Value = blno;
           objp[1].Value = size;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return int.Parse(ExecuteReader("SPFIGetContainerType", objp));
       }


        //Update BL Details with fields cont20 and cont40 
       public void UpdateContsize(string blno, int cont20, int cont40, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                        new SqlParameter("@cont20",SqlDbType.Int,4),
                                                        new SqlParameter("@cont40",SqlDbType.Int,4),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)  
                                                    };
            objp[0].Value = cont20;
            objp[1].Value = cont40;
            objp[2].Value = blno;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPUpdFIBLContainerSizeCount", objp);
        }


       public void UpdateAmendContsize(string blno, int cont20, int cont40, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@cont20",SqlDbType.Int,4),
                                                         new SqlParameter("@cont40",SqlDbType.Int,4),
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)   
                                                    };
           objp[0].Value = cont20;
           objp[1].Value = cont40;
           objp[2].Value = blno;
           objp[3].Value = intBranchID;
           objp[4].Value = intDivisionID;
           ExecuteQuery("SPUpdFIAmendBLContainerSizeCount", objp);
       }

        //Delete container details. 
       public void DeleteContainer(int jobno, string blno, string containerno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] {   
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@containerno",SqlDbType.VarChar,12),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = jobno;
            objp[1].Value = containerno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            ExecuteQuery("SPDelFIContainerDetls", objp);
        }


       public void DelContainerDetails(int intJbNo, string strBLNo, int intBranchID,int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30), 
                                                     new SqlParameter("@bid", SqlDbType.TinyInt),
                                                     new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = intJbNo;
           objp[1].Value = strBLNo;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           ExecuteQuery("SPDelOIContainerDetails", objp);
       }


       //Update BLDetails. 
       public void UpdateBLDetails(int jobno, string blno, DateTime bldate, int blissuedat, int shipperid, string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty, string naddress, int agentid, int porid, int polid, int podid, int fdid, string marks, string desn, double cbm, double grswt, double ntwt, string shipment, string freight, int NoOfpkg, string unit, char nomination, string vessel, string voyage, int inttranshipedat, string unocode, string imocode, double oldcbm, int cont20, int cont40, string remarks, string blsurrendered, int intBranchID, int salesid, int cargoid, int intDivisionID)
       {
           if (shipment == "FCL/FCL") status = 1;
           else if (shipment == "FCL/LCL") status = 2;
           else if (shipment == "LCL/LCL") status = 3;
           else if (shipment == "LCL/FCL") status = 4;
           pkgid = Pkgobj.GetNPackageid(unit);
           vesselid = Vessobj.GetVesselid(vessel);
           fgt = Quotobj.GetFrighttype(freight);
           SqlParameter[] objp = new SqlParameter[]
                                                  {     
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@blissuedat",SqlDbType.Int),
                                                        new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                        new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                        new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                        new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                        new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                        new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                        new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@agentid",SqlDbType.Int,4),
                                                        new SqlParameter("@por",SqlDbType.Int),
                                                        new SqlParameter("@pol",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@fd",SqlDbType.Int),
                                                        new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                        new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                        new SqlParameter("@marks",SqlDbType.VarChar,250),
                                                        new SqlParameter("@desn",SqlDbType.VarChar,250),
                                                        new SqlParameter("@grswt",SqlDbType.Real,4),
                                                        new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                        new SqlParameter("@cbm",SqlDbType.Real,4),
                                                        new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                        new SqlParameter("@pkgid",SqlDbType.Int),
                                                        new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@transhipedat",SqlDbType.Int,6),
                                                        new SqlParameter("@unocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@imocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@oldcbm",SqlDbType.Real,4),
                                                        new SqlParameter("@cont20",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cont40",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@blsurrendered",SqlDbType.VarChar,1),
                                                        new SqlParameter("@salesid",SqlDbType.Int),
                                                        new SqlParameter("@cargoid",SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                  };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = bldate;
           objp[3].Value = blissuedat;
           objp[4].Value = shipperid;
           objp[5].Value = shipper;
           objp[6].Value = saddress;
           objp[7].Value = consigneeid;
           objp[8].Value = consignee;
           objp[9].Value = caddress;
           objp[10].Value = notifypartyid;
           objp[11].Value = notifyparty;
           objp[12].Value = naddress;
           objp[13].Value = agentid;
           objp[14].Value = porid;
           objp[15].Value = polid;
           objp[16].Value = podid;
           objp[17].Value = fdid;
           objp[18].Value = fgt;
           objp[19].Value = status;
           objp[20].Value = nomination;
           objp[21].Value = marks;
           objp[22].Value = desn;
           objp[23].Value = grswt;
           objp[24].Value = ntwt;
           objp[25].Value = cbm;
           objp[26].Value = NoOfpkg;
           objp[27].Value = pkgid;
           objp[28].Value = vesselid;
           objp[29].Value = voyage;
           objp[30].Value = inttranshipedat;
           objp[31].Value = unocode;
           objp[32].Value = imocode;
           objp[33].Value = oldcbm;
           objp[34].Value = cont20;
           objp[35].Value = cont40;
           objp[36].Value = remarks;
           objp[37].Value = blsurrendered;
           objp[38].Value = salesid;
           objp[39].Value = cargoid;
           objp[40].Value = intBranchID;
           objp[41].Value = intDivisionID;
           ExecuteQuery("SPUpdOIBLdetails", objp);
       }
   
       
       //Update ForwardedBLDetails. M
       public void UpdateFBLDetails(int jobno, string blno, DateTime bldate, int blissuedat, int shipperid, string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty, string naddress, int agentid, int porid, int polid, int podid, int fdid, string marks, string desn, double cbm, double grswt, double ntwt, string shipment, string freight, int NoOfpkg, string unit, char nomination, string vessel, string voyage, int inttranshipedat, string unocode, string imocode, string remarks, int intBranchID, int salesid, int cargoid, int intDivisionID, string fblsurrendered)
       {
           if (shipment == "FCL/FCL")
               status = 1;
           else if (shipment == "FCL/LCL")
               status = 2;
           else if (shipment == "LCL/LCL")
               status = 3;
           else if (shipment == "LCL/FCL")
               status = 4;
           pkgid = Pkgobj.GetNPackageid(unit);
           vesselid = Vessobj.GetVesselid(vessel);
           fgt = Quotobj.GetFrighttype(freight);
           SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@blissuedat",SqlDbType.Int),
                                                        new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                        new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                        new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                        new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                        new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                        new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                        new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@agentid",SqlDbType.Int,4),
                                                        new SqlParameter("@por",SqlDbType.Int),
                                                        new SqlParameter("@pol",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@fd",SqlDbType.Int),
                                                        new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                        new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                        new SqlParameter("@marks",SqlDbType.VarChar,250),
                                                        new SqlParameter("@desn",SqlDbType.VarChar,250),
                                                        new SqlParameter("@grswt",SqlDbType.Real,4),
                                                        new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                        new SqlParameter("@cbm",SqlDbType.Real,4),
                                                        new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                        new SqlParameter("@pkgid",SqlDbType.Int),
                                                        new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@transhipedat",SqlDbType.Int,6),
                                                        new SqlParameter("@unocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@imocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@salesid",SqlDbType.Int),
                                                        new SqlParameter("@cargoid",SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt),
                                                         new SqlParameter("@fblsurrendered", SqlDbType.VarChar,1)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = bldate;
           objp[3].Value = blissuedat;
           objp[4].Value = shipperid;
           objp[5].Value = shipper;
           objp[6].Value = saddress;
           objp[7].Value = consigneeid;
           objp[8].Value = consignee;
           objp[9].Value = caddress;
           objp[10].Value = notifypartyid;
           objp[11].Value = notifyparty;
           objp[12].Value = naddress;
           objp[13].Value = agentid;
           objp[14].Value = porid;
           objp[15].Value = polid;
           objp[16].Value = podid;
           objp[17].Value = fdid;
           objp[18].Value = fgt;
           objp[19].Value = status;
           objp[20].Value = nomination;
           objp[21].Value = marks;
           objp[22].Value = desn;
           objp[23].Value = grswt;
           objp[24].Value = ntwt;
           objp[25].Value = cbm;
           objp[26].Value = NoOfpkg;
           objp[27].Value = pkgid;
           objp[28].Value = vesselid;
           objp[29].Value = voyage;
           objp[30].Value = inttranshipedat;
           objp[31].Value = unocode;
           objp[32].Value = imocode;
           objp[33].Value = remarks;
           objp[34].Value = salesid;
           objp[35].Value = cargoid;
           objp[36].Value = intBranchID;
           objp[37].Value = intDivisionID;
           objp[38].Value = fblsurrendered;
           ExecuteQuery("SPUpdFIFBLdetails", objp);
       }


       //Update SplitBLDetails. 
       public void UpdateSBLDetails(int jobno, string blno, DateTime bldate, int blissuedat, int shipperid, string shipper, string saddress, int consigneeid, string consignee, string caddress, int notifypartyid, string notifyparty, string naddress, int agentid, int porid, int polid, int podid, int fdid, string marks, string desn, double cbm, double grswt, double ntwt, string shipment, string freight, int NoOfpkg, string unit, char nomination, string vessel, string voyage, int inttranshipedat, string unocode, string imocode, string splitbl, int branchid, double oldcbm, int cont20, int cont40, string remarks, string blsurrendered, int intBranchID, int salesid, int cargoid, int intDivisionID)
       {
           if (shipment == "FCL/FCL")               status = 1;
           else if (shipment == "FCL/LCL")          status = 2;
           else if (shipment == "LCL/LCL")          status = 3;
           else if (shipment == "LCL/FCL")          status = 4;
           pkgid = Pkgobj.GetNPackageid(unit);
           vesselid = Vessobj.GetVesselid(vessel);
           fgt = Quotobj.GetFrighttype(freight);
           SqlParameter[] objp = new SqlParameter[]
                                                  {     
                                                        new SqlParameter("@jobno",SqlDbType.Int),
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                        new SqlParameter("@blissuedat",SqlDbType.Int),
                                                        new SqlParameter("@shipperid",SqlDbType.Int,4),
                                                        new SqlParameter("@shipper",SqlDbType.VarChar,100),
                                                        new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@consigneeid",SqlDbType.Int,4),
                                                        new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                        new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@notifypartyid",SqlDbType.Int,4),
                                                        new SqlParameter("@notifyparty",SqlDbType.VarChar,100),
                                                        new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                        new SqlParameter("@agentid",SqlDbType.Int,4),
                                                        new SqlParameter("@por",SqlDbType.Int),
                                                        new SqlParameter("@pol",SqlDbType.Int),
                                                        new SqlParameter("@pod",SqlDbType.Int),
                                                        new SqlParameter("@fd",SqlDbType.Int),
                                                        new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                        new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                        new SqlParameter("@marks",SqlDbType.VarChar,250),
                                                        new SqlParameter("@desn",SqlDbType.VarChar,250),
                                                        new SqlParameter("@grswt",SqlDbType.Real,4),
                                                        new SqlParameter("@ntwt",SqlDbType.Real,4),
                                                        new SqlParameter("@cbm",SqlDbType.Real,4),
                                                        new SqlParameter("@noofpkg",SqlDbType.Int,4),
                                                        new SqlParameter("@pkgid",SqlDbType.Int),
                                                        new SqlParameter("@vesselid",SqlDbType.Int,4),
                                                        new SqlParameter("@voyage",SqlDbType.VarChar,15),
                                                        new SqlParameter("@transhipedat",SqlDbType.Int,6),
                                                        new SqlParameter("@unocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@imocode",SqlDbType.VarChar,5),
                                                        new SqlParameter("@oldcbm",SqlDbType.Real,4),
                                                        new SqlParameter("@cont20",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cont40",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@remarks",SqlDbType.VarChar,100),
                                                        new SqlParameter("@blsurrendered",SqlDbType.VarChar,1),
                                                        new SqlParameter("@salesid",SqlDbType.Int),
                                                        new SqlParameter("@cargoid",SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                  };
           objp[0].Value = jobno;
           objp[1].Value = blno;
           objp[2].Value = bldate;
           objp[3].Value = blissuedat;
           objp[4].Value = shipperid;
           objp[5].Value = shipper;
           objp[6].Value = saddress;
           objp[7].Value = consigneeid;
           objp[8].Value = consignee;
           objp[9].Value = caddress;
           objp[10].Value = notifypartyid;
           objp[11].Value = notifyparty;
           objp[12].Value = naddress;
           objp[13].Value = agentid;
           objp[14].Value = porid;
           objp[15].Value = polid;
           objp[16].Value = podid;
           objp[17].Value = fdid;
           objp[18].Value = fgt;
           objp[19].Value = status;
           objp[20].Value = nomination;
           objp[21].Value = marks;
           objp[22].Value = desn;
           objp[23].Value = grswt;
           objp[24].Value = ntwt;
           objp[25].Value = cbm;
           objp[26].Value = NoOfpkg;
           objp[27].Value = pkgid;
           objp[28].Value = vesselid;
           objp[29].Value = voyage;
           objp[30].Value = inttranshipedat;
           objp[31].Value = unocode;
           objp[32].Value = imocode;
           objp[33].Value = oldcbm;
           objp[34].Value = cont20;
           objp[35].Value = cont40;
           objp[36].Value = remarks;
           objp[37].Value = blsurrendered;
           objp[38].Value = salesid;
           objp[39].Value = cargoid;
           objp[40].Value = intBranchID;
           objp[41].Value = intDivisionID;
           ExecuteQuery("SPUpdOIBLdetails", objp);
       }

       //Get Bookinking Details Based on Bookingno and Trantype.
       public DataTable GetBookingDtls(string bookingno, string trantype, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                        { 
                                                            new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                            new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                            new SqlParameter("@bid", SqlDbType.TinyInt),
                                                            new SqlParameter("@cid", SqlDbType.TinyInt)
                                                        };
           objp[0].Value = bookingno;
           objp[1].Value = trantype;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return ExecuteTable("SPOIBLBookingDtls", objp);
       }


       //Show BL Details.  
       public DataTable ShowBLDetails(string blno, int intBranchID, int intDivisionID)
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
           return ExecuteTable("SPSelOIBLDetails", objp);
       }



       public DataTable ShowAmendBLDetails(string blno, int intBranchID, int intDivisionID)
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
           return ExecuteTable("SPSelFIAmendBLDetails", objp);
       }


       //Update Booking With BL Number. 
       public void UpdateBooking(string bookingno, string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = bookingno;
           objp[1].Value = blno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           ExecuteQuery("SPUpdBookingBL", objp);
       }

       
       //******** JobInfo Gridview **********
       public DataTable JobInfo(int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = intBranchID;
           objp[1].Value = intDivisionID;
           return ExecuteTable("SPFIJob", objp);
       }

       //Get Job Details based on Jobno. 
       public string GetJobDetails(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@intjobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           Dt = ExecuteTable("SPFIJobQry", objp);
           if (Dt.Rows.Count > 0)
           {
               string vessel = Dt.Rows[0].ItemArray[0].ToString();
               string mblno = Dt.Rows[0].ItemArray[2].ToString();
               string eta = Dt.Rows[0].ItemArray[1].ToString();
               string pol = Dt.Rows[0].ItemArray[3].ToString();
               jobdetails = vessel + " / " + eta + " / " + mblno + " / " + pol;
           }
           return jobdetails;
       }



            //******** Booking Gridview **********
       public DataTable Bookingdetails(string trantype, int intBranchID, int intDivisionID)
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
           return ExecuteTable("SPBookingBLPENDings", objp);
       }

       public DataTable Bookingdetailsnew(string trantype, int intBranchID, int intDivisionID,int jobno)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                          {
                                                               new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                               new SqlParameter("@bid",SqlDbType.TinyInt),
                                                               new SqlParameter("@cid",SqlDbType.TinyInt),
                                                               new SqlParameter("@jobno",SqlDbType.Int)
                                                          };
           objp[0].Value = trantype;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           objp[3].Value = jobno;
           return ExecuteTable("SPBookingBLPENDingsnew", objp);
       }



       public DataTable BookingdetailsShipping(string trantype, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                               new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                               new SqlParameter("@bid",SqlDbType.TinyInt),
                                                               new SqlParameter("@cid",SqlDbType.TinyInt)
                                                          };
           objp[0].Value = trantype;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPBookingBLPENDingsShipping", objp);
       }


       //******** BL Gridview **********
       public DataTable BLdetails(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                         };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPFIForwarderBLDetails", objp);
       }



        //Methods for Windows Application.
        //Get like BL
       public DataTable GetLikeBL(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPLikeFIBL", objp);
       }

       public DataTable GetLikeBLFromJob(string blno, int intBranchID, int jobno, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    }; 
           objp[0].Value = blno;
           objp[1].Value = jobno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return ExecuteTable("SPLikeFIBLFromJob", objp);
       }


       public DataTable GetLikeIBL(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPLikeIFIBL", objp);
       }

       public DataTable GetLikeOTHERIBL(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPLikeOTHERFIBL", objp);
       }


       public DataTable GetLikeSBL(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPLikeFISBL", objp);
       }

        
       
       
       public void DeleteContDtls(int jobno, string blno, int intBranchID,int intDivisionID)
            {
                SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid",SqlDbType.TinyInt),
                                                           new SqlParameter("@cid",SqlDbType.TinyInt)
                                                         };
                objp[0].Value = jobno;
                objp[1].Value = blno;
                objp[2].Value = intBranchID;
                objp[3].Value = intDivisionID;
                ExecuteQuery("SPDelFIContDtls", objp);
            }



       public DataTable GetLikeFBL(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value =  blno;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPLikeFIFBL", objp);
        }



       public DataTable GetLikeFBLWOCJob(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPLikeFIFBLWOCJob", objp);
       }


       public DataTable ShowFBLDetails(string blno, int intBranchID, int intDivisionID)
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
           return ExecuteTable("SPSelFIFBLDetails", objp);
       }


       public DataTable ShowFIInfo(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID)
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
           return ExecuteTable("SPSelFIInfo", objp);
       }
       //muthu

       public DataTable ShowFIInfonew(int jobno, string blno, string ftype, double cbm, int intBranchID, int intDivisionID)
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
           return ExecuteTable("SPSelFIInfonew", objp);
       }


       public int GetPendingDODays(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return int.Parse(ExecuteReader("SPGetPendingDODays", objp));
       }



       public int GetFBLConsFromSplit(string blno, int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = jobno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           return int.Parse(ExecuteReader("SPGetFBLConsFromSplitBL", objp));
       }


       public DataTable GetBLWtPkgCustomEdi(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                        new SqlParameter("@jobno",SqlDbType.Int,4),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                   };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetSumBLWtForCustomEdi", objp);
       }



       public DataTable GetContWtPkgCustomEdi(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno",SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID ;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetSumOfWtForCustomEdi", objp);
       }



       public DataTable GetForwarderName(string consignee, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                     new SqlParameter("@consignee",SqlDbType.VarChar,100),
                                                     new SqlParameter("@bid", SqlDbType.TinyInt),
                                                     new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = consignee;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPLikeFRConsignee", objp);
       }


       public DataTable GetConsigneeforforwarder(string forwarder, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {  
                                                       new SqlParameter("@forwarder",SqlDbType.VarChar,100),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = forwarder;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetConsignee4forwarder", objp);
       }



       public DataTable GetFIBLTrans4BT(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                      new SqlParameter("@jobno", SqlDbType.Int,4),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPSelFIBLTransfer", objp);
       }


       public void InsFI4BTTrans(int JobNo, string BLno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                      new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                      new SqlParameter("@bid", SqlDbType.TinyInt),
                                                      new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = JobNo;
           objp[1].Value = BLno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           ExecuteQuery("SPInsFI4BTTrans", objp);
       }

       public DataTable ForwarderVsHBL(int jobno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int,4),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPForwderVsHBldtls", objp);
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


       //MUTHURAJ
       public DataTable GetBLDtJobnoNewAI(int jobno, int intBranchID, int intDivisionID, string type)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@jobno",SqlDbType.Int),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt),
                                                       new SqlParameter("@cid", SqlDbType.TinyInt),
                                                        new SqlParameter ("@type",SqlDbType.Char,1)
                                                    };
           objp[0].Value = jobno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           objp[3].Value = type;
           return ExecuteTable("SPGetFIBLDtsJobnoNewAI", objp);
       }

       public DataTable GetCustMail4BLAI(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@blno",SqlDbType.VarChar,50),
                                                       new SqlParameter("@bid", SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           return ExecuteTable("SPGetCustMail4BLAI", objp);
       }

       public DataTable BookingdetailsAEAI(string trantype, int intBranchID, int intDivisionID,int jobno)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                          {
                                                               new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                               new SqlParameter("@bid",SqlDbType.TinyInt),
                                                               new SqlParameter("@cid",SqlDbType.TinyInt), 
                                                               new SqlParameter("@jobno",SqlDbType.Int, 4)
                                                          };
           objp[0].Value = trantype;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           objp[3].Value = jobno;
           return ExecuteTable("SPBookingBLPENDingsAEAI", objp); 
 
      
       }

       public DataTable Bookdetailsnewly(string trantype, int intBranchID, int intDivisionID)
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
           return ExecuteTable("SPBookBLPENDingsnewly", objp);
       }


       public void UpdateBookingnew(string bookingno, string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
           objp[0].Value = bookingno;
           objp[1].Value = blno;
           objp[2].Value = intBranchID;
           objp[3].Value = intDivisionID;
           ExecuteQuery("SPUpdBookingBLnew", objp);
       }
       //
       public DataTable getdetailsinvoiceno(string blno, int intBranchID, int intDivisionID, string trantype)
       {
           SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                      new SqlParameter("@blno",SqlDbType.VarChar,100),
                                                      new SqlParameter("@bid", SqlDbType.Int),
                                                      new SqlParameter("@cid", SqlDbType.Int),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,5)
                                                    };
           objp[0].Value = blno;
           objp[1].Value = intBranchID;
           objp[2].Value = intDivisionID;
           objp[3].Value = trantype;
           return ExecuteTable("sp_getdetailsinvoiceno", objp);
       }

    }
}

