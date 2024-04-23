using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.ForwardingExports
{
    public class ISFDetails:DBObject 
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ISFDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetJobDetails(string blno, int intBranchID, int intDivisionID)
       {
           SqlParameter [] obj=new SqlParameter []
           {
               new SqlParameter ("@blno",SqlDbType .VarChar,30),
                new SqlParameter("@bid", SqlDbType.TinyInt,1),
                new SqlParameter("@cid", SqlDbType.TinyInt,1)

           };

           obj[0].Value = blno;
           obj[1].Value = intBranchID;
           obj[2].Value = intDivisionID;
           return ExecuteTable("SPGetFIJobDetails", obj);
       }

        public DataTable GetContainerDetails(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@blno",SqlDbType .VarChar,30),
                new SqlParameter("@bid", SqlDbType.TinyInt,1),
                new SqlParameter("@cid", SqlDbType.TinyInt,1)

           };

            obj[0].Value = blno;
            obj[1].Value = intBranchID;
            obj[2].Value = intDivisionID;
            return ExecuteTable("SPGetContainerDetails", obj);
        }
        public DataTable GetBookingDet(string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] obj = new SqlParameter[]
           {
               new SqlParameter ("@blno",SqlDbType .VarChar,30),
                new SqlParameter("@bid", SqlDbType.TinyInt,1),
                new SqlParameter("@cid", SqlDbType.TinyInt,1)

           };

            obj[0].Value = blno;
            obj[1].Value = intBranchID;
            obj[2].Value = intDivisionID;
            return ExecuteTable("SPGetBookingDet", obj);
        }


     /*   public void InsISFDetails(string bookingno, string blno, int importerid, string importerdtls, int buyerid, string buyerdtls, int consigneeid, string consigneedtls, int supplierid, string supplierdtls, int shipperid, string shipperdtls, int eforwarderid, string eforwarderdtls, string stuffloc, int iforwarderid, string iforwarderdtls, int chaid, string chadtls, int carridid, string carrscac, string mblno, string pono, string htscode, int bid, int stuffid, string amshbl, int consolid, string consoldtls, int shiptoid, string shiptodtls)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@bookingno",SqlDbType.VarChar ,30),
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                new SqlParameter ("@importerid",SqlDbType.Int ,4),
                new SqlParameter ("@importerdtls",SqlDbType.VarChar  ,250),
                new SqlParameter ("@buyerid",SqlDbType.Int ,4),
                new SqlParameter ("@buyerdtls",SqlDbType.VarChar,250),
                new SqlParameter ("@consigneeid",SqlDbType.Int ,4),
                new SqlParameter ("@consigneedtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@supplierid",SqlDbType.Int   ,4),
                 new SqlParameter ("@supplierdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shipperid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shipperdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@eforwarderid",SqlDbType.Int  ,4),
                 new SqlParameter ("@eforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@stuffloc",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@iforwarderid",SqlDbType.Int   ,4),
                 new SqlParameter ("@iforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@chaid",SqlDbType.Int   ,4),
                 new SqlParameter ("@chadtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@carridid",SqlDbType.Int   ,4),
                 new SqlParameter ("@carrscac",SqlDbType.VarChar  ,25),
                new SqlParameter ("@mblno",SqlDbType.VarChar  ,30),
                new SqlParameter ("@pono",SqlDbType.VarChar  ,30),
                new SqlParameter ("@htscode",SqlDbType.VarChar  ,25),
                new SqlParameter ("@bid",SqlDbType .TinyInt ,1),
                new SqlParameter ("@stuffid",SqlDbType .Int ,4),
                 new SqlParameter ("@amshbl",SqlDbType.VarChar  ,30),
                new SqlParameter ("@consolid",SqlDbType.Int   ,4),
                 new SqlParameter ("@consoldtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shiptoid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shiptodtls",SqlDbType.VarChar  ,250),

        };
            obj[0].Value = bookingno;
            obj[1].Value = blno;
            obj[2].Value = importerid;
            obj[3].Value = importerdtls;
            obj[4].Value = buyerid;
            obj[5].Value = buyerdtls;
            obj[6].Value = consigneeid;
            obj[7].Value = consigneedtls;
            obj[8].Value = supplierid;
            obj[9].Value = supplierdtls;
            obj[10].Value = shipperid;
            obj[11].Value = shipperdtls;
            obj[12].Value = eforwarderid;
            obj[13].Value = eforwarderdtls;
            obj[14].Value = stuffloc;
            obj[15].Value = iforwarderid;
            obj[16].Value = iforwarderdtls;
            obj[17].Value = chaid;
            obj[18].Value = chadtls;
            obj[19].Value = carridid;
            obj[20].Value = carrscac;
            obj[21].Value = mblno;
            obj[22].Value = pono;
            obj[23].Value = htscode;
            obj[24].Value = bid;
            obj[25].Value = stuffid;
            obj[26].Value = amshbl;
            obj[27].Value = consolid;
            obj[28].Value = consoldtls;
            obj[29].Value = shiptoid;
            obj[30].Value = shiptodtls;
            ExecuteQuery ("SPInsISFDtls", obj);
        }


        public void UpdISFDetails(string blno, string bookingno, int importerid, string importerdtls, int buyerid, string buyerdtls, int consigneeid, string consigneedtls, int supplierid, string supplierdtls, int shipperid, string shipperdtls, int eforwarderid, string eforwarderdtls, string stuffloc, int iforwarderid, string iforwarderdtls, int chaid, string chadtls, int carridid, string carrscac, string mblno, string pono, string htscode, int bid, int stuffid, string amshbl, int consolid, string consoldtls, int shiptoid, string shiptodtls)
        {
            SqlParameter[] obj = new SqlParameter[]
        {
            new SqlParameter ("@blno",SqlDbType .VarChar ,30),
              new SqlParameter ("@bookingno",SqlDbType.VarChar ,30),
               new SqlParameter ("@importerid",SqlDbType.Int ,4),
                new SqlParameter ("@importerdtls",SqlDbType.VarChar  ,250),
                new SqlParameter ("@buyerid",SqlDbType.Int ,4),
                new SqlParameter ("@buyerdtls",SqlDbType.VarChar,250),
                new SqlParameter ("@consigneeid",SqlDbType.Int ,4),
                 new SqlParameter ("@consigneedtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@supplierid",SqlDbType.Int   ,4),
                 new SqlParameter ("@supplierdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shipperid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shipperdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@eforwarderid",SqlDbType.Int  ,4),
                 new SqlParameter ("@eforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@stuffloc",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@iforwarderid",SqlDbType.Int   ,4),
                 new SqlParameter ("@iforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@chaid",SqlDbType.Int   ,4),
                 new SqlParameter ("@chadtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@carridid",SqlDbType.Int   ,4),
                 new SqlParameter ("@carrscac",SqlDbType.VarChar  ,25),
                new SqlParameter ("@mblno",SqlDbType.VarChar  ,30),
                new SqlParameter ("@pono",SqlDbType.VarChar  ,30),
                new SqlParameter ("@htscode",SqlDbType.VarChar  ,25),   
                new SqlParameter ("@bid",SqlDbType .TinyInt ,1),
                new SqlParameter ("@stuffid",SqlDbType .Int ,4),
                 new SqlParameter ("@amshbl",SqlDbType.VarChar  ,30),
             new SqlParameter ("@consolid",SqlDbType.Int   ,4),
                 new SqlParameter ("@consoldtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shiptoid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shiptodtls",SqlDbType.VarChar  ,250),

                 };
            obj[0].Value = blno;
            obj[1].Value = bookingno;
            obj[2].Value = importerid;
            obj[3].Value = importerdtls;
            obj[4].Value = buyerid;
            obj[5].Value = buyerdtls;
            obj[6].Value = consigneeid;
            obj[7].Value = consigneedtls;
            obj[8].Value = supplierid;
            obj[9].Value = supplierdtls;
            obj[10].Value = shipperid;
            obj[11].Value = shipperdtls;
            obj[12].Value = eforwarderid;
            obj[13].Value = eforwarderdtls;
            obj[14].Value = stuffloc;
            obj[15].Value = iforwarderid;
            obj[16].Value = iforwarderdtls;
            obj[17].Value = chaid;
            obj[18].Value = chadtls;
            obj[19].Value = carridid;
            obj[20].Value = carrscac;
            obj[21].Value = mblno;
            obj[22].Value = pono;
            obj[23].Value = htscode;
            obj[24].Value = bid;
            obj[25].Value = stuffid;
            obj[26].Value = amshbl;
            obj[27].Value = consolid;
            obj[28].Value = consoldtls;
            obj[29].Value = shiptoid;
            obj[30].Value = shiptodtls;
            ExecuteQuery("UpdISFDetails", obj);
        }


        */
        public void InsISFDetails(string bookingno, string blno, int importerid, string importerdtls, int buyerid, string buyerdtls, int consigneeid, string consigneedtls, int supplierid, string supplierdtls, int shipperid, string shipperdtls, int eforwarderid, string eforwarderdtls, string stuffloc, int iforwarderid, string iforwarderdtls, int chaid, string chadtls, int carridid, string carrscac, string mblno, string pono, string htscode, int bid, int stuffid, string amshbl, int consolid, string consoldtls, int shiptoid, string shiptodtls, int manuid, string manudtls)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@bookingno",SqlDbType.VarChar ,30),
                new SqlParameter("@blno",SqlDbType.VarChar ,30),
                new SqlParameter ("@importerid",SqlDbType.Int ,4),
                new SqlParameter ("@importerdtls",SqlDbType.VarChar  ,250),
                new SqlParameter ("@buyerid",SqlDbType.Int ,4),
                new SqlParameter ("@buyerdtls",SqlDbType.VarChar,250),
                new SqlParameter ("@consigneeid",SqlDbType.Int ,4),
                new SqlParameter ("@consigneedtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@supplierid",SqlDbType.Int   ,4),
                 new SqlParameter ("@supplierdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shipperid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shipperdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@eforwarderid",SqlDbType.Int  ,4),
                 new SqlParameter ("@eforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@stuffloc",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@iforwarderid",SqlDbType.Int   ,4),
                 new SqlParameter ("@iforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@chaid",SqlDbType.Int   ,4),
                 new SqlParameter ("@chadtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@carridid",SqlDbType.Int   ,4),
                 new SqlParameter ("@carrscac",SqlDbType.VarChar  ,25),
                new SqlParameter ("@mblno",SqlDbType.VarChar  ,30),
                new SqlParameter ("@pono",SqlDbType.VarChar  ,30),
                new SqlParameter ("@htscode",SqlDbType.VarChar  ,55),
                new SqlParameter ("@bid",SqlDbType .TinyInt ,1),
                new SqlParameter ("@stuffid",SqlDbType .Int ,4),
                 new SqlParameter ("@amshbl",SqlDbType.VarChar  ,30),
                new SqlParameter ("@consolid",SqlDbType.Int   ,4),
                 new SqlParameter ("@consoldtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shiptoid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shiptodtls",SqlDbType.VarChar  ,250),
                 new SqlParameter("@manuid",SqlDbType.Int,4),
                 new SqlParameter("@manudtls",SqlDbType.VarChar,250)
        };
            obj[0].Value = bookingno;
            obj[1].Value = blno;
            obj[2].Value = importerid;
            obj[3].Value = importerdtls;
            obj[4].Value = buyerid;
            obj[5].Value = buyerdtls;
            obj[6].Value = consigneeid;
            obj[7].Value = consigneedtls;
            obj[8].Value = supplierid;
            obj[9].Value = supplierdtls;
            obj[10].Value = shipperid;
            obj[11].Value = shipperdtls;
            obj[12].Value = eforwarderid;
            obj[13].Value = eforwarderdtls;
            obj[14].Value = stuffloc;
            obj[15].Value = iforwarderid;
            obj[16].Value = iforwarderdtls;
            obj[17].Value = chaid;
            obj[18].Value = chadtls;
            obj[19].Value = carridid;
            obj[20].Value = carrscac;
            obj[21].Value = mblno;
            obj[22].Value = pono;
            obj[23].Value = htscode;
            obj[24].Value = bid;
            obj[25].Value = stuffid;
            obj[26].Value = amshbl;
            obj[27].Value = consolid;
            obj[28].Value = consoldtls;
            obj[29].Value = shiptoid;
            obj[30].Value = shiptodtls;
            obj[31].Value = manuid;
            obj[32].Value = manudtls;
            ExecuteQuery("SPInsISFDtls", obj);
        }


        public void UpdISFDetails(string blno, string bookingno, int importerid, string importerdtls, int buyerid, string buyerdtls, int consigneeid, string consigneedtls, int supplierid, string supplierdtls, int shipperid, string shipperdtls, int eforwarderid, string eforwarderdtls, string stuffloc, int iforwarderid, string iforwarderdtls, int chaid, string chadtls, int carridid, string carrscac, string mblno, string pono, string htscode, int bid, int stuffid, string amshbl, int consolid, string consoldtls, int shiptoid, string shiptodtls, int manuid, string manudtls)
        {
            SqlParameter[] obj = new SqlParameter[]
        {
            new SqlParameter ("@blno",SqlDbType .VarChar ,30),
              new SqlParameter ("@bookingno",SqlDbType.VarChar ,30),
               new SqlParameter ("@importerid",SqlDbType.Int ,4),
                new SqlParameter ("@importerdtls",SqlDbType.VarChar  ,250),
                new SqlParameter ("@buyerid",SqlDbType.Int ,4),
                new SqlParameter ("@buyerdtls",SqlDbType.VarChar,250),
                new SqlParameter ("@consigneeid",SqlDbType.Int ,4),
                 new SqlParameter ("@consigneedtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@supplierid",SqlDbType.Int   ,4),
                 new SqlParameter ("@supplierdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shipperid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shipperdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@eforwarderid",SqlDbType.Int  ,4),
                 new SqlParameter ("@eforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@stuffloc",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@iforwarderid",SqlDbType.Int   ,4),
                 new SqlParameter ("@iforwarderdtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@chaid",SqlDbType.Int   ,4),
                 new SqlParameter ("@chadtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@carridid",SqlDbType.Int   ,4),
                 new SqlParameter ("@carrscac",SqlDbType.VarChar  ,25),
                new SqlParameter ("@mblno",SqlDbType.VarChar  ,30),
                new SqlParameter ("@pono",SqlDbType.VarChar  ,30),
                new SqlParameter ("@htscode",SqlDbType.VarChar  ,55),   
                new SqlParameter ("@bid",SqlDbType .TinyInt ,1),
                new SqlParameter ("@stuffid",SqlDbType .Int ,4),
                 new SqlParameter ("@amshbl",SqlDbType.VarChar  ,30),
             new SqlParameter ("@consolid",SqlDbType.Int   ,4),
                 new SqlParameter ("@consoldtls",SqlDbType.VarChar  ,250),
                 new SqlParameter ("@shiptoid",SqlDbType.Int   ,4),
                 new SqlParameter ("@shiptodtls",SqlDbType.VarChar  ,250),
                 new SqlParameter("@manuid",SqlDbType.Int,4),
                 new SqlParameter("@manudtls",SqlDbType.VarChar,250)
                 };
            obj[0].Value = blno;
            obj[1].Value = bookingno;
            obj[2].Value = importerid;
            obj[3].Value = importerdtls;
            obj[4].Value = buyerid;
            obj[5].Value = buyerdtls;
            obj[6].Value = consigneeid;
            obj[7].Value = consigneedtls;
            obj[8].Value = supplierid;
            obj[9].Value = supplierdtls;
            obj[10].Value = shipperid;
            obj[11].Value = shipperdtls;
            obj[12].Value = eforwarderid;
            obj[13].Value = eforwarderdtls;
            obj[14].Value = stuffloc;
            obj[15].Value = iforwarderid;
            obj[16].Value = iforwarderdtls;
            obj[17].Value = chaid;
            obj[18].Value = chadtls;
            obj[19].Value = carridid;
            obj[20].Value = carrscac;
            obj[21].Value = mblno;
            obj[22].Value = pono;
            obj[23].Value = htscode;
            obj[24].Value = bid;
            obj[25].Value = stuffid;
            obj[26].Value = amshbl;
            obj[27].Value = consolid;
            obj[28].Value = consoldtls;
            obj[29].Value = shiptoid;
            obj[30].Value = shiptodtls;
            obj[31].Value = manuid;
            obj[32].Value = manudtls;
            ExecuteQuery("UpdISFDetails", obj);
        }

       
        public DataTable GetISFDetails(string blno)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@blno",SqlDbType.VarChar  ,30)
                
            };
            obj[0].Value = blno;
            return ExecuteTable("SPGetISFDetails", obj);
        }
        
        public void DelBLnodtls(string blno)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@blno",SqlDbType.VarChar  ,30)
            };
            obj[0].Value = blno;
            ExecuteQuery("SPDelISFDtls", obj);
        }
        public int GetBranch(string branchname)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter("@branchname",SqlDbType.VarChar ,250)
            };
            obj[0].Value = branchname;
            return int.Parse(ExecuteReader("SPGetBid", obj));
        }
        public DataTable GetBranchName(int branchid,int divisionid)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@branchid",SqlDbType .Int ,4),
                new SqlParameter ("@divisionid",SqlDbType .Int ,4)
                
            };
            obj[0].Value = branchid ;
            obj[1].Value = divisionid ;
            return ExecuteTable("SPGetBranchDtls", obj);
        }

        public DataTable GetCNFid(string blno)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@blno",SqlDbType.VarChar  ,30)
                
            };
            obj[0].Value = blno;
            return ExecuteTable ("SPgetcnfid", obj);
        }
       
        //public DataTable GetCNFdtls(string blno,int cnf)
        //{
        //    SqlParameter[] obj = new SqlParameter[]
        //    {
        //        new SqlParameter ("@blno",SqlDbType.VarChar  ,30),
        //        new SqlParameter ("@cnf",SqlDbType .Int ,4)
                                  
        //    };
        //    obj[0].Value = blno;
        //    obj[1].Value = cnf;
        //   return ExecuteTable("SPGetCNF", obj);
        //}
     
        public DataTable GetCNFdtls(string blno)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@blno",SqlDbType.VarChar  ,30)
               
            };
            obj[0].Value = blno;
            return ExecuteTable("SPGetCNF", obj);
        }
        public DataTable GetImportDtls(string blno)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@blno",SqlDbType.VarChar  ,30)
               
            };
            obj[0].Value = blno;
            return ExecuteTable("SPGetImpFrwd", obj);
        }
      
        public DataTable GetBdtls(int bid)
        {
            SqlParameter[] obj = new SqlParameter[]
            {
                new SqlParameter ("@bid",SqlDbType .Int ,4),
                               
            };
            obj[0].Value = bid;
           
            return ExecuteTable("SPGetBranch", obj);
        }
        public DataTable GetISFdtls(string blno)
        {
            SqlParameter[] obj = new SqlParameter[] 
            {
                new SqlParameter ("@blno",SqlDbType .VarChar  ,30)
            };
            obj[0].Value = blno;
            return ExecuteTable("SPGetISFdtls", obj);


        }

        //Nambi

        public DataTable INSUPDISFManuf(string strBlno, int manuid, string manuname, string manudtls, int intBranchID ,string HBL)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@manuid", SqlDbType.Int,4),
                                                           new SqlParameter("@manuname", SqlDbType.VarChar, 150),
                                                           new SqlParameter("@manudtls", SqlDbType.VarChar,250),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),                                                               
                                                           new SqlParameter("@HBL", SqlDbType.VarChar, 55)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = manuid;
            objp[2].Value = manuname;
            objp[3].Value = manudtls;
            objp[4].Value = intBranchID;
            objp[5].Value = HBL;
            return ExecuteTable("SPINSUPDISFManuf", objp);
        }

        public DataTable SELISFManuf(string strBlno, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSELISFManuf", objp);
        }

        public DataTable DELISFManuf(string strBlno, int manuid, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@manuid", SqlDbType.Int,4),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = manuid;
            objp[2].Value = intBranchID;
            return ExecuteTable("SPDELISFManuf", objp);
        }

    }
}
