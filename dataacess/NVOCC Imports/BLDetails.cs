using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.NVOCC_Imports
{
    public class BLDetails : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BLDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void InsertBLDetails(int jobno,string blno,DateTime bldate,int issuedat,string freight,int shipper,string SAddress,int consignee,string CAddress,int notify,string NAddress,int agent,int por,int pol,int pod,int fd,string marks,string descr,decimal grwt,string grwttype,decimal netwt,string netwttype,decimal cbm,int noofpkgs,int pkgtype,int shipment,int hblstatus,string nomination,int commodity,string unocode,string imocode,int salesid,string splitbl,string remarks, int bid,int cid,string Ftype,int cont20,int cont40)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@issuedat",SqlDbType.Int),
                                                     new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                     new SqlParameter("@shipper",SqlDbType.Int,4),
                                                     new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@consignee",SqlDbType.Int,4),
                                                     new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@notify",SqlDbType.Int,4),
                                                     new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@agent",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),       
                                                     new SqlParameter("@marks",SqlDbType.VarChar,250), 
                                                     new SqlParameter("@descr",SqlDbType.VarChar,250),
                                                     new SqlParameter("@grwt",SqlDbType.Real,8),
                                                     new SqlParameter("@grwttype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@netwt",SqlDbType.Real,8),
                                                     new SqlParameter("@netwttype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cbm",SqlDbType.Real,8),
                                                     new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                     new SqlParameter("@pkgtype",SqlDbType.Int),
                                                     new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@hblstatus",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                     new SqlParameter("@commodity",SqlDbType.Int),
                                                     new SqlParameter("@unocode",SqlDbType.VarChar,10),
                                                     new SqlParameter("@imocode",SqlDbType.VarChar,10),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@splitbl",SqlDbType.VarChar,30),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,50),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@Ftype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cont20",SqlDbType.Int),
                                                     new SqlParameter("@cont40",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = bldate;
            objp[3].Value = issuedat;
            objp[4].Value = freight;
            objp[5].Value = shipper;
            objp[6].Value = SAddress;
            objp[7].Value = consignee;
            objp[8].Value = CAddress;
            objp[9].Value = notify;
            objp[10].Value = NAddress;
            objp[11].Value = agent;
            objp[12].Value = por;
            objp[13].Value = pol;
            objp[14].Value = pod;
            objp[15].Value = fd;
            objp[16].Value = marks;
            objp[17].Value = descr;
            objp[18].Value = grwt;
            objp[19].Value = grwttype;
            objp[20].Value = netwt;
            objp[21].Value = netwttype;
            objp[22].Value = cbm;
            objp[23].Value = noofpkgs;
            objp[24].Value = pkgtype;
            objp[25].Value = shipment;
            objp[26].Value = hblstatus;
            objp[27].Value = nomination;
            objp[28].Value = commodity;
            objp[29].Value = unocode;
            objp[30].Value = imocode;
            objp[31].Value = salesid;
            objp[32].Value = splitbl;
            objp[33].Value = remarks;
            objp[34].Value = bid;
            objp[35].Value = cid;
            objp[36].Value = Ftype;
            objp[37].Value = cont20;
            objp[38].Value = cont40;
            ExecuteQuery("SPNIInsBLDetails", objp);
        }
        public void UpdateBLDetails(int jobno, string blno, DateTime bldate, int issuedat, string freight, int shipper, string SAddress, int consignee, string CAddress, int notify, string NAddress, int agent, int por, int pol, int pod, int fd, string marks, string descr, decimal grwt, string grwttype, decimal netwt, string netwttype, decimal cbm, int noofpkgs, int pkgtype, int shipment, int hblstatus, string nomination, int commodity, string unocode, string imocode, int salesid, string splitbl, string remarks, int bid, int cid, string Ftype, int cont20, int cont40)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bldate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@issuedat",SqlDbType.Int),
                                                     new SqlParameter("@freight",SqlDbType.VarChar,1),
                                                     new SqlParameter("@shipper",SqlDbType.Int,4),
                                                     new SqlParameter("@saddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@consignee",SqlDbType.Int,4),
                                                     new SqlParameter("@caddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@notify",SqlDbType.Int,4),
                                                     new SqlParameter("@naddress",SqlDbType.VarChar,250),
                                                     new SqlParameter("@agent",SqlDbType.Int,4),
                                                     new SqlParameter("@por",SqlDbType.Int),
                                                     new SqlParameter("@pol",SqlDbType.Int),
                                                     new SqlParameter("@pod",SqlDbType.Int),
                                                     new SqlParameter("@fd",SqlDbType.Int),       
                                                     new SqlParameter("@marks",SqlDbType.VarChar,250), 
                                                     new SqlParameter("@descr",SqlDbType.VarChar,250),
                                                     new SqlParameter("@grwt",SqlDbType.Real,8),
                                                     new SqlParameter("@grwttype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@netwt",SqlDbType.Real,8),
                                                     new SqlParameter("@netwttype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cbm",SqlDbType.Real,8),
                                                     new SqlParameter("@noofpkgs",SqlDbType.Int,4),
                                                     new SqlParameter("@pkgtype",SqlDbType.Int),
                                                     new SqlParameter("@shipment",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@hblstatus",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@nomination",SqlDbType.VarChar,1),
                                                     new SqlParameter("@commodity",SqlDbType.Int),
                                                     new SqlParameter("@unocode",SqlDbType.VarChar,10),
                                                     new SqlParameter("@imocode",SqlDbType.VarChar,10),
                                                     new SqlParameter("@salesid",SqlDbType.Int),
                                                     new SqlParameter("@splitbl",SqlDbType.VarChar,30),
                                                     new SqlParameter("@remarks",SqlDbType.VarChar,50),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@Ftype",SqlDbType.VarChar,1),
                                                     new SqlParameter("@cont20",SqlDbType.Int),
                                                     new SqlParameter("@cont40",SqlDbType.Int)};
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = bldate;
            objp[3].Value = issuedat;
            objp[4].Value = freight;
            objp[5].Value = shipper;
            objp[6].Value = SAddress;
            objp[7].Value = consignee;
            objp[8].Value = CAddress;
            objp[9].Value = notify;
            objp[10].Value = NAddress;
            objp[11].Value = agent;
            objp[12].Value = por;
            objp[13].Value = pol;
            objp[14].Value = pod;
            objp[15].Value = fd;
            objp[16].Value = marks;
            objp[17].Value = descr;
            objp[18].Value = grwt;
            objp[19].Value = grwttype;
            objp[20].Value = netwt;
            objp[21].Value = netwttype;
            objp[22].Value = cbm;
            objp[23].Value = noofpkgs;
            objp[24].Value = pkgtype;
            objp[25].Value = shipment;
            objp[26].Value = hblstatus;
            objp[27].Value = nomination;
            objp[28].Value = commodity;
            objp[29].Value = unocode;
            objp[30].Value = imocode;
            objp[31].Value = salesid;
            objp[32].Value = splitbl;
            objp[33].Value = remarks;
            objp[34].Value = bid;
            objp[35].Value = cid;
            objp[36].Value = Ftype;
            objp[37].Value = cont20;
            objp[38].Value = cont40;
            ExecuteQuery("SPNIUpdBLDetails", objp);
        }

        public DataTable ShowBLDetails(string blno, int bid, int cid, string Ftype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("Ftype",SqlDbType.VarChar,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = Ftype;
            return ExecuteTable("SPNISelBLDetails", objp);
        }

        public DataTable LikeBLNoAll(string blno, int bid, int cid, string Ftype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("Ftype",SqlDbType.VarChar,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = Ftype;
            return ExecuteTable("SPNILikeBLNoALL", objp);
        }

        public DataTable LikeBLNoWOCJobInFormwise(string blno, int bid, int cid, string Ftype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("Ftype",SqlDbType.VarChar,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = Ftype;
            return ExecuteTable("SPNILikeBLNoFTypeWOCJob", objp);
        }

        public DataTable LikeBLNoWOCJobInWOFWDBL(string blno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNILikeBLNo", objp);
        }

        public int CheckExistsBLNo(string blno, int bid, int cid,string Ftype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("blno",SqlDbType.VarChar,30),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                        new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("Ftype",SqlDbType.VarChar,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = Ftype;
            return int.Parse(ExecuteReader("SPNICheckExistsBLNo", objp));
        }
        public DataTable GetFwdBLdetailsFromJob(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetForwarderBLDetailsFromJob", objp);
        }
        public string GetBookinkNo(string blno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteReader("SPNIGetBookingno", objp);
        }
        public DataTable GetBookingDtls(string bookingno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIBLBookingDtls", objp);
        }
        public void UpdateBookingNo(string bookingno, string blno,int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = bookingno;
            objp[1].Value = blno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPNIUpdBookingBL", objp);
        }

        public DataTable GetBLNoFromJobNoForCFS(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetBLNoFromJobNoforCFS", objp);
        }

        public DataTable GetBLNoFromJobNoandCFSID(int jobno, int bid, int cid,int cfs)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cfs",SqlDbType.Int,4)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            objp[3].Value = cfs;
            return ExecuteTable("SPNIGetBLNoFromJobNoandCFSID", objp);
        }

        public void UpdateBLCFS(int jobno, string blno, int cfs,int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@cfs",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = cfs;
            objp[3].Value = bid;
            objp[4].Value = cid;
            ExecuteQuery("SPNIUpdBLCFS", objp);
        }

        public void DelBLCFS(int jobno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            ExecuteQuery("SPNIDelBLCFS", objp);
        }

        public DataTable GetBLNoFromJobNo(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetBLNoFromJob", objp);
        }
        public void UpdateBLLineNo(int jobno, string blno, string lineno, string sublineno, int bid, int cid, string itemtype, string cargotype)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@lineno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@sublineno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@itemtype",SqlDbType.VarChar,5),
                                                     new SqlParameter("@cargommt",SqlDbType.VarChar,5)};
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = lineno;
            objp[3].Value = sublineno;
            objp[4].Value = bid;
            objp[5].Value = cid;
            objp[6].Value = itemtype;
            objp[7].Value = cargotype;
            ExecuteQuery("SPNIUpdBLLineNo", objp);
        }

        public DataTable GetContainerdtsFromBLFD(int fd)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@fd", SqlDbType.Int)};
            objp[0].Value = fd;
            return ExecuteTable("SPNIGetNIContainerDtsFromBLFD", objp);
        }
        public void InsNContainerDetails(int principal,int conatinerid, int impjobno, string impblno,int impfreedays,string containerno,string sizetype,string impsealno,int imppkgs,int imppackageid,double impwt,string impwttype,string imco,string isocode,string socflag,int bid,int cid,int trackid,int arrport,DateTime arrdate,int arrvessel,string arrvoyage)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@principal",SqlDbType.Int,4),
                                                     new SqlParameter("@containerid",SqlDbType.Int,4),
                                                     new SqlParameter("@impjobno",SqlDbType.Int,4),
                                                     new SqlParameter("@impblno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@impfreedays",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@containerno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@sizetype",SqlDbType.VarChar,4),
                                                     new SqlParameter("@impsealno",SqlDbType.VarChar,15),
                                                     new SqlParameter("@imppkgs",SqlDbType.Int,4),
                                                     new SqlParameter("@imppackageid",SqlDbType.Int,4),
                                                     new SqlParameter("@impwt",SqlDbType.Real,8),
                                                     new SqlParameter("@impwttype",SqlDbType.Char,1),
                                                     new SqlParameter("@imco",SqlDbType.VarChar,15),
                                                     new SqlParameter("@isocode",SqlDbType.VarChar,5),
                                                     new SqlParameter("@socflag",SqlDbType.VarChar,5),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),       
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@trackid",SqlDbType.Int,4),
                                                     new SqlParameter("@arrport",SqlDbType.Int),
                                                     new SqlParameter("@arrdate",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@arrvessel",SqlDbType.Int),
                                                     new SqlParameter("@arrvoyage",SqlDbType.VarChar,10)};
            objp[0].Value = principal;
            objp[1].Value = conatinerid;
            objp[2].Value = impjobno;
            objp[3].Value = impblno;
            objp[4].Value = impfreedays;
            objp[5].Value = containerno;
            objp[6].Value = sizetype;
            objp[7].Value = impsealno;
            objp[8].Value = imppkgs;
            objp[9].Value = imppackageid;
            objp[10].Value = impwt;
            objp[11].Value = impwttype;
            objp[12].Value = imco;
            objp[13].Value = isocode;
            objp[14].Value = socflag;
            objp[15].Value = bid;
            objp[16].Value = cid;
            objp[17].Value = trackid;
            objp[18].Value = arrport;
            objp[19].Value = arrdate;
            objp[20].Value = arrvessel;
            objp[21].Value = arrvoyage;
            ExecuteQuery("SPNIInsNContainerDetails", objp);
        }

        public DataTable GetNContainerDetails(int impjobno, string impblno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@impjobno",SqlDbType.Int,4),
                                                     new SqlParameter("@impblno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = impjobno;
            objp[1].Value = impblno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            return ExecuteTable("SPNISelNContainerDetails", objp);
        }

        public void DelNContainerDetails(int impjobno, string impblno,int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@impjobno",SqlDbType.Int,4),
                                                     new SqlParameter("@impblno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),       
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = impjobno;
            objp[1].Value = impblno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPNIDelNContainerDetails", objp);
        }

        public void InsNISplitContainerDetails(int jobno, string blno,string containerno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),       
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@containerno",SqlDbType.VarChar,15)};
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            objp[4].Value = containerno;
            ExecuteQuery("SPNIInsNISplitContainerDetails", objp);
        }

        public void DelNISplitContainerDetails(int jobno, string blno, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),
                                                     new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),       
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = blno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            ExecuteQuery("SPNIDelNISplitContainerDetails", objp);
        }

        public DataTable GetNISplitContainerDetails(int impjobno, string impblno, int bid, int cid,string ftype,string FBLNO)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@impjobno",SqlDbType.Int,4),
                                                     new SqlParameter("@impblno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@FBLNO",SqlDbType.VarChar,30),
                                                     new SqlParameter("@ftype",SqlDbType.VarChar,30)};
            objp[0].Value = impjobno;
            objp[1].Value = impblno;
            objp[2].Value = bid;
            objp[3].Value = cid;
            objp[4].Value = FBLNO;
            objp[5].Value = ftype;
            return ExecuteTable("SPNISelNISplitContainerDetails", objp);
        }
        public DataTable LikeBLNoFromNContainerDetails(string blno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@impblno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNILikeBLnoFromNContainerDetails", objp);
        }


        public DataTable GetBLContSizeCountDetails(string blno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@impblno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = blno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetContSizeCountDetails", objp);
        }
        public void UpdateBLDOIssuedON(string blno,DateTime doissuedon, int depotid,int cnf, int bid, int cid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                     new SqlParameter("@depot",SqlDbType.Int,4),
                                                     new SqlParameter("@doissuedon",SqlDbType.SmallDateTime,4),
                                                     new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cid",SqlDbType.TinyInt,1),
                                                     new SqlParameter("@cnf",SqlDbType.Int,4)};
            objp[0].Value = blno;
            objp[1].Value = depotid;
            objp[2].Value = doissuedon;
            objp[3].Value = bid;
            objp[4].Value = cid;
            objp[5].Value = cnf;
            ExecuteQuery("SPNIUpdDOIssue", objp);
        }

        public DataTable GetNIContWtPkgCustomEdi(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetSumOfWtForCustomEdi", objp);
        }

        public DataTable GetNIBLWtPkgCustomEdi(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int,4),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetSumBLWtForCustomEdi", objp);
        }

        public DataTable GetNIBLDetailJobno(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetBLDetailsJobno", objp);

        }

        public DataTable GetNIBLContDtJobno(int jobno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                    new SqlParameter("@cid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPNIGetContDtJobno", objp);

        }

        public DataTable getcreditdaygroupname(int qoutno, int bid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@quotno",SqlDbType.Int),
                                                    new SqlParameter("@bid",SqlDbType.Int),
                                                  };
            objp[0].Value = qoutno;
            objp[1].Value = bid;

            return ExecuteTable("spgetgroupcreditday", objp);

        }
    }
}
