using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess.Masters
{
    public class MasterBranch:DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterBranch()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsertMasterBranch(int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage,int bm  , int rm)
        {

            SqlParameter[] objp = new SqlParameter[] 
                                                    {
                                                                                   
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regionid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4)
                                                    };

            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = branchname;
            objp[3].Value = ptc;
            objp[4].Value = address;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = panno;
            objp[9].Value = stno;
            objp[10].Value = favouring;
            objp[11].Value = bankname;
            objp[12].Value = bankaddress;
            objp[13].Value = swiftcode;
            objp[14].Value = acnos;
            objp[15].Value = regionid;
            objp[16].Value = carrno;
            objp[17].Value = arrimage;
            objp[18].Value = bm;
            objp[19].Value = rm;
            ExecuteQuery("SPInsMasterBranch", objp);

        }



        public void UpdateMasterBranchDetails(int branchid, int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage,int bmid,int rmid)
        {

            SqlParameter[] objp = new SqlParameter[]                                 {
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15) ,
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@regionid",SqlDbType.TinyInt,1) ,
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4)
                                                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = portid;
            objp[3].Value = branchname;
            objp[4].Value = ptc;
            objp[5].Value = address;
            objp[6].Value = phone;
            objp[7].Value = fax;
            objp[8].Value = email;
            objp[9].Value = panno;
            objp[10].Value = stno;
            objp[11].Value = favouring;
            objp[12].Value = bankname;
            objp[13].Value = bankaddress;
            objp[14].Value = swiftcode;
            objp[15].Value = acnos;
            objp[16].Value = regionid;
            objp[17].Value = carrno;
            objp[18].Value = arrimage;
            objp[19].Value = bmid;
            objp[20].Value = rmid;
            
            ExecuteQuery("SPUpdMasterBranchDetails", objp);

        }

        public DataTable GetLikeBranch(string employeename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchname", SqlDbType.VarChar, 50) };
            objp[0].Value = employeename;
            return ExecuteTable("SPLikeBranch", objp);

        }

        
        public DataTable RetrieveMasterBranchDetails(int divisionid,int portid,int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                      { 
                                                new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                new SqlParameter("@portid", SqlDbType.Int),
                                                new SqlParameter("@branchid", SqlDbType.TinyInt, 1)
                                                      };



            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = branchid;
           

            return ExecuteTable("SPSelMasterBranchDetails", objp);

        }

        public int GetBranchId(int divisionid,int portid, string branchname)
        {

            SqlParameter[] ob = new SqlParameter[]
                                                      { 
                                                new SqlParameter("@divisionid", SqlDbType.TinyInt,1),
                                                new SqlParameter("@portid", SqlDbType.Int),
                                                new SqlParameter("@branchname", SqlDbType.VarChar,100)
                                                      };



            ob[0].Value = divisionid;
            ob[1].Value = portid;
            ob[2].Value = branchname;
            return int.Parse(ExecuteReader("SPGetBranchId1", ob));
           
        }
        public string GetShortName(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4) };
            objp[0].Value = branchid;
            return ExecuteReader("SPGetBranchShortName", objp);
        }

        public DataSet getbmrmid(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@BID", SqlDbType.TinyInt  , 1)};

            //objp[0].Value = bid;
            objp[0].Value = bid;
            // objp[1].Value = todate;
            return ExecuteDataSet("spgetbmrmid", objp);

        }
        public DataTable GetBranchByDivID(int intDivID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divid", SqlDbType.TinyInt, 1) };
            objp[0].Value = intDivID;
            return ExecuteTable("SPSelBranchWithIDBYDivID", objp);
        }
        public DataTable GetBranchwithdso()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPGetbranchwithdso", objp);
        }

        public void Updbranchwithdso(int dsodays, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@dsodays",SqlDbType.Int),
                new SqlParameter("@branchid",SqlDbType.Int,4)
            };
            objp[0].Value = dsodays;
            objp[1].Value = branchid;
            ExecuteQuery("SPUpdbranchwithDso", objp);
        }
        public DataTable GetBranchname()
        {
            SqlParameter[] objp = new SqlParameter[] { };
            return ExecuteTable("SPGetbranchname", objp);
        }

        public DataTable FilterBranch(int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@divid",SqlDbType.Int,4)};
            objp[0].Value = divid;
            return ExecuteTable("SPFilterbranch4mdivid", objp);
        }
 
        // Created by Priya//

        public DataTable GetBranchandDivision(int divisionid, int portid)
        {

            SqlParameter[] ob = new SqlParameter[]
                                                      { 
                                                new SqlParameter("@divisionid", SqlDbType.TinyInt,1),
                                                new SqlParameter("@portid", SqlDbType.Int)
                                                      };

           ob[0].Value = divisionid;
           ob[1].Value = portid;

           return ExecuteTable("SPGetDivisionandBranch", ob);

        }
        //Branchname from branchid

        public string Getbranchname(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@bid", SqlDbType.Int)
                                                     };


            objp[0].Value = bid;

            return ExecuteReader("SPSelBranchname4mbid", objp);

        }

        //Prabha




        public void InsertMasterBranch4New(int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage, int bm, int rm, string localacno, string mrcode, string ediuserid, string basecurr, string transbondno, string basepaise, string cinno, string neftcode, string Locfavouring, string Locbankname, string Locbankaddress, string shortname, string accemail, string doxexpemail, string doximpemail, string codexpemail, string codimpemail, string opsexpemail, string opsimpemail)
        {

            SqlParameter[] objp = new SqlParameter[] 
                                                    {                              
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regionid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@localacno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mrcode",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@ediuserid",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basecurr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@transbondno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basepaise",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@cinno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@neftcode",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@Locfavouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@shortname",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@accemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doxexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doximpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsimpemail",SqlDbType.VarChar,100)
                                                    };

            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = branchname;
            objp[3].Value = ptc;
            objp[4].Value = address;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = panno;
            objp[9].Value = stno;
            objp[10].Value = favouring;
            objp[11].Value = bankname;
            objp[12].Value = bankaddress;
            objp[13].Value = swiftcode;
            objp[14].Value = acnos;
            objp[15].Value = regionid;
            objp[16].Value = carrno;
            objp[17].Value = arrimage;
            objp[18].Value = bm;
            objp[19].Value = rm;
            objp[20].Value = localacno;
            objp[21].Value = mrcode;
            objp[22].Value = ediuserid;
            objp[23].Value = basecurr;
            objp[24].Value = transbondno;
            objp[25].Value = basepaise;
            objp[26].Value = cinno;
            objp[27].Value = neftcode;
            objp[28].Value = Locfavouring;
            objp[29].Value = Locbankname;
            objp[30].Value = Locbankaddress;
            objp[31].Value = shortname;
            objp[32].Value = accemail;
            objp[33].Value = doxexpemail;
            objp[34].Value = doximpemail;
            objp[35].Value = codexpemail;
            objp[36].Value = codimpemail;
            objp[37].Value = opsexpemail;
            objp[38].Value = opsimpemail;

            ExecuteQuery("SPInsMasterBranch4New", objp);
        }

        public void UpdateMasterBranchDetails4New(int branchid, int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage, int bmid, int rmid, string localacno, string mrcode, string ediuserid, string basecurr, string transbondno, string basepaise, string cinno, string neftcode, string Locfavouring, string Locbankname, string Locbankaddress, string shortname, string accemail, string doxexpemail, string doximpemail, string codexpemail, string codimpemail, string opsexpemail, string opsimpemail)
        {

            SqlParameter[] objp = new SqlParameter[]                                 {
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15) ,
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@regionid",SqlDbType.TinyInt,1) ,
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@localacno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mrcode",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@ediuserid",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basecurr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@transbondno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basepaise",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@cinno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@neftcode",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@Locfavouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@shortname",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@accemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doxexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doximpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsimpemail",SqlDbType.VarChar,100)
                                                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = portid;
            objp[3].Value = branchname;
            objp[4].Value = ptc;
            objp[5].Value = address;
            objp[6].Value = phone;
            objp[7].Value = fax;
            objp[8].Value = email;
            objp[9].Value = panno;
            objp[10].Value = stno;
            objp[11].Value = favouring;
            objp[12].Value = bankname;
            objp[13].Value = bankaddress;
            objp[14].Value = swiftcode;
            objp[15].Value = acnos;
            objp[16].Value = regionid;
            objp[17].Value = carrno;
            objp[18].Value = arrimage;
            objp[19].Value = bmid;
            objp[20].Value = rmid;
            objp[21].Value = localacno;
            objp[22].Value = mrcode;
            objp[23].Value = ediuserid;
            objp[24].Value = basecurr;
            objp[25].Value = transbondno;
            objp[26].Value = basepaise;
            objp[27].Value = cinno;
            objp[28].Value = neftcode;
            objp[29].Value = Locfavouring;
            objp[30].Value = Locbankname;
            objp[31].Value = Locbankaddress;
            objp[32].Value = shortname;
            objp[33].Value = accemail;
            objp[34].Value = doxexpemail;
            objp[35].Value = doximpemail;
            objp[36].Value = codexpemail;
            objp[37].Value = codimpemail;
            objp[38].Value = opsexpemail;
            objp[39].Value = opsimpemail;

            ExecuteQuery("SPUpdMasterBranchDetails4New", objp);
        }

        public DataTable RetrieveMasterBranchDetails4New(int divisionid, int portid, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                      { 
                                                new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                new SqlParameter("@portid", SqlDbType.Int),
                                                new SqlParameter("@branchid", SqlDbType.TinyInt, 1)
                                                      };



            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = branchid;


            return ExecuteTable("SPSelMasterBranchDetails4New", objp);

        }


        //************************************Elakkiya**********************************************

        public DataTable GetDivisionId(string divname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@divisionname", SqlDbType.Char, 50) 
                                                     };
            objp[0].Value = divname;
            return ExecuteTable("SpGetDivisionId", objp);
        }

        public DataTable GetDivisionAllDteails(int divId)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@divisionid", SqlDbType.Int) 
                                                     };
            objp[0].Value = divId;
            return ExecuteTable("SpGetDivisionName", objp);
        }

        public DataTable GetDivCommon()
        {
            return ExecuteTable("SPGetDivisionCommon");
        }

        public DataTable GetAllRegionNames()
        {
            return ExecuteTable("SPGETAllRegionNames");
        }

      
        public void InsertAllValuesBranch(int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage, int bm, int rm, string localacno, string mrcode, string ediuserid, string basecurr, string transbondno, string basepaise, string cinno, string neftcode, string Locfavouring, string Locbankname, string Locbankaddress, string shortname, string accemail, string doxexpemail, string doximpemail, string codexpemail, string codimpemail, string opsexpemail, string opsimpemail,int locationid)
        {

            SqlParameter[] objp = new SqlParameter[] 
                                                    {                              
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,500),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regionid",SqlDbType.Int),
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@localacno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mrcode",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@ediuserid",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basecurr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@transbondno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basepaise",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@cinno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@neftcode",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@Locfavouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@shortname",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@accemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doxexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doximpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@locationid",SqlDbType.Int)
                                                    };

            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = branchname;
            objp[3].Value = ptc;
            objp[4].Value = address;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = panno;
            objp[9].Value = stno;
            objp[10].Value = favouring;
            objp[11].Value = bankname;
            objp[12].Value = bankaddress;
            objp[13].Value = swiftcode;
            objp[14].Value = acnos;
            objp[15].Value = regionid;
            objp[16].Value = carrno;
            objp[17].Value = arrimage;
            objp[18].Value = bm;
            objp[19].Value = rm;
            objp[20].Value = localacno;
            objp[21].Value = mrcode;
            objp[22].Value = ediuserid;
            objp[23].Value = basecurr;
            objp[24].Value = transbondno;
            objp[25].Value = basepaise;
            objp[26].Value = cinno;
            objp[27].Value = neftcode;
            objp[28].Value = Locfavouring;
            objp[29].Value = Locbankname;
            objp[30].Value = Locbankaddress;
            objp[31].Value = shortname;
            objp[32].Value = accemail;
            objp[33].Value = doxexpemail;
            objp[34].Value = doximpemail;
            objp[35].Value = codexpemail;
            objp[36].Value = codimpemail;
            objp[37].Value = opsexpemail;
            objp[38].Value = opsimpemail;
            objp[39].Value = locationid;

            ExecuteQuery("SPInsValMasterBranch", objp);
        }

        public void UpdateValOfMasterBranch(int branchid, int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage, int bmid, int rmid, string localacno, string mrcode, string ediuserid, string basecurr, string transbondno, string basepaise, string cinno, string neftcode, string Locfavouring, string Locbankname, string Locbankaddress, string shortname, string accemail, string doxexpemail, string doximpemail, string codexpemail, string codimpemail, string opsexpemail, string opsimpemail,int locationid)
        {

            SqlParameter[] objp = new SqlParameter[]                                 {
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15) ,
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@regionid",SqlDbType.Int) ,
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@localacno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mrcode",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@ediuserid",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basecurr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@transbondno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basepaise",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@cinno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@neftcode",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@Locfavouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@shortname",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@accemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doxexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doximpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@locationid",SqlDbType.Int)
                                                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = portid;
            objp[3].Value = branchname;
            objp[4].Value = ptc;
            objp[5].Value = address;
            objp[6].Value = phone;
            objp[7].Value = fax;
            objp[8].Value = email;
            objp[9].Value = panno;
            objp[10].Value = stno;
            objp[11].Value = favouring;
            objp[12].Value = bankname;
            objp[13].Value = bankaddress;
            objp[14].Value = swiftcode;
            objp[15].Value = acnos;
            objp[16].Value = regionid;
            objp[17].Value = carrno;
            objp[18].Value = arrimage;
            objp[19].Value = bmid;
            objp[20].Value = rmid;
            objp[21].Value = localacno;
            objp[22].Value = mrcode;
            objp[23].Value = ediuserid;
            objp[24].Value = basecurr;
            objp[25].Value = transbondno;
            objp[26].Value = basepaise;
            objp[27].Value = cinno;
            objp[28].Value = neftcode;
            objp[29].Value = Locfavouring;
            objp[30].Value = Locbankname;
            objp[31].Value = Locbankaddress;
            objp[32].Value = shortname;
            objp[33].Value = accemail;
            objp[34].Value = doxexpemail;
            objp[35].Value = doximpemail;
            objp[36].Value = codexpemail;
            objp[37].Value = codimpemail;
            objp[38].Value = opsexpemail;
            objp[39].Value = opsimpemail;
            objp[40].Value = locationid;
            ExecuteQuery("SPUpdateValsMasterBranch", objp);
        }

        public DataTable GetSelofAllMasterBranchDetails(int divisionid, int portid, int branchid,int locationid)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                      { 
                                                new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                new SqlParameter("@portid", SqlDbType.Int),
                                                new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                new SqlParameter("@locationid", SqlDbType.Int)
                                                      };



            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = branchid;
            objp[3].Value = locationid;

            return ExecuteTable("SPretriveMasterBranchDetails", objp);

        }

        public DataTable GetValOfBranchhId(int divisionid, string strBranchName, int portid,int locationid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                                      { 
                                                new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
                                                new SqlParameter("@branchname", SqlDbType.VarChar,100),
                                                new SqlParameter("@portid", SqlDbType.Int),
                                                new SqlParameter("@locationid", SqlDbType.Int)
                                                      };



            objp[0].Value = divisionid;
            objp[1].Value = strBranchName;
            objp[2].Value = portid;
            objp[3].Value = locationid;


            return ExecuteTable("SPGetValNewBranchID", objp);
        }


        public DataTable ChecKPersonContact(string ename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empname", SqlDbType.VarChar,50)
                                                       };
            objp[0].Value = ename;

            return ExecuteTable("SpCHeckNewPersonEmployee", objp);

        }

        public DataTable CheckEmpNameNew(int eid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@employeeid", SqlDbType.Int)
                                                       };
            objp[0].Value = eid;

            return ExecuteTable("SPCheckEmpName", objp);

        }

        public DataTable CheckBranchMgrNameNew(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empname", SqlDbType.VarChar,50)
                                                       };
            objp[0].Value = empname;

            return ExecuteTable("SPCheckBranchManagerName", objp);

        }



        public int BranchDSO(int branchid,int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    
                                                     new SqlParameter("@branchid", SqlDbType.Int),
                                                     new SqlParameter("@divisionid", SqlDbType.Int)
                                                       };

          
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            return int.Parse(ExecuteReader("SP_BranchDSO", objp));
            
        }
        public DataTable GetBranchWiseConfirmation(int divisionid)
        {
            SqlParameter[] obj = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int) };
            obj[0].Value = divisionid;

            return ExecuteTable("SpGetConfirmAndProbNew", obj);
        }


        //FA
        //Manoj

        public DataTable GetShortnameListFromdivisionid(int intDivID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1) };
            objp[0].Value = intDivID;
            return ExecuteTable("SPGetShortNamefromBranch", objp);
        }

        public string Getexact_ShortnameListFromdivisionid(int intDivID, string shortname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.TinyInt, 1),
            new SqlParameter("@portname", SqlDbType.VarChar, 20)};
            objp[0].Value = intDivID;
            objp[1].Value = shortname;
            return ExecuteReader("SPexact_GetShortNamefromBranch", objp);
        } 


        //MUTHURAJ

        public void InsertAllValuesBranch(int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage, int bm, int rm, string localacno, string mrcode, string ediuserid, string basecurr, string transbondno, string basepaise, string cinno, string neftcode, string Locfavouring, string Locbankname, string Locbankaddress, string shortname, string accemail, string doxexpemail, string doximpemail, string codexpemail, string codimpemail, string opsexpemail, string opsimpemail, int locationid, string gstin, int stateid)
        {

            SqlParameter[] objp = new SqlParameter[] 
                                                    {                              
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,500),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),        
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25), 
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@regionid",SqlDbType.Int),
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@localacno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mrcode",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@ediuserid",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basecurr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@transbondno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basepaise",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@cinno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@neftcode",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@Locfavouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@shortname",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@accemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doxexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doximpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@locationid",SqlDbType.Int),
                                                                                     new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@stateid",SqlDbType.Int)

                                                    };

            objp[0].Value = divisionid;
            objp[1].Value = portid;
            objp[2].Value = branchname;
            objp[3].Value = ptc;
            objp[4].Value = address;
            objp[5].Value = phone;
            objp[6].Value = fax;
            objp[7].Value = email;
            objp[8].Value = panno;
            objp[9].Value = stno;
            objp[10].Value = favouring;
            objp[11].Value = bankname;
            objp[12].Value = bankaddress;
            objp[13].Value = swiftcode;
            objp[14].Value = acnos;
            objp[15].Value = regionid;
            objp[16].Value = carrno;
            objp[17].Value = arrimage;
            objp[18].Value = bm;
            objp[19].Value = rm;
            objp[20].Value = localacno;
            objp[21].Value = mrcode;
            objp[22].Value = ediuserid;
            objp[23].Value = basecurr;
            objp[24].Value = transbondno;
            objp[25].Value = basepaise;
            objp[26].Value = cinno;
            objp[27].Value = neftcode;
            objp[28].Value = Locfavouring;
            objp[29].Value = Locbankname;
            objp[30].Value = Locbankaddress;
            objp[31].Value = shortname;
            objp[32].Value = accemail;
            objp[33].Value = doxexpemail;
            objp[34].Value = doximpemail;
            objp[35].Value = codexpemail;
            objp[36].Value = codimpemail;
            objp[37].Value = opsexpemail;
            objp[38].Value = opsimpemail;
            objp[39].Value = locationid;
            objp[40].Value = gstin;
            objp[41].Value = stateid;

            ExecuteQuery("SPInsValMasterBranch", objp);
        }

       /* public void UpdateValOfMasterBranch1(int branchid, int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage, int bmid, int rmid, string localacno, string mrcode, string ediuserid, string basecurr, string transbondno, string basepaise, string cinno, string neftcode, string Locfavouring, string Locbankname, string Locbankaddress, string shortname, string accemail, string doxexpemail, string doximpemail, string codexpemail, string codimpemail, string opsexpemail, string opsimpemail, int locationid, string gstin, int stateid)
        {

            SqlParameter[] objp = new SqlParameter[]                                 {
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15) ,
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@regionid",SqlDbType.Int) ,
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@localacno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mrcode",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@ediuserid",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basecurr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@transbondno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basepaise",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@cinno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@neftcode",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@Locfavouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@shortname",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@accemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doxexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doximpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@locationid",SqlDbType.Int),
                                                                                     new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@stateid",SqlDbType.Int
                                                                                         )
                                                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = portid;
            objp[3].Value = branchname;
            objp[4].Value = ptc;
            objp[5].Value = address;
            objp[6].Value = phone;
            objp[7].Value = fax;
            objp[8].Value = email;
            objp[9].Value = panno;
            objp[10].Value = stno;
            objp[11].Value = favouring;
            objp[12].Value = bankname;
            objp[13].Value = bankaddress;
            objp[14].Value = swiftcode;
            objp[15].Value = acnos;
            objp[16].Value = regionid;
            objp[17].Value = carrno;
            objp[18].Value = arrimage;
            objp[19].Value = bmid;
            objp[20].Value = rmid;
            objp[21].Value = localacno;
            objp[22].Value = mrcode;
            objp[23].Value = ediuserid;
            objp[24].Value = basecurr;
            objp[25].Value = transbondno;
            objp[26].Value = basepaise;
            objp[27].Value = cinno;
            objp[28].Value = neftcode;
            objp[29].Value = Locfavouring;
            objp[30].Value = Locbankname;
            objp[31].Value = Locbankaddress;
            objp[32].Value = shortname;
            objp[33].Value = accemail;
            objp[34].Value = doxexpemail;
            objp[35].Value = doximpemail;
            objp[36].Value = codexpemail;
            objp[37].Value = codimpemail;
            objp[38].Value = opsexpemail;
            objp[39].Value = opsimpemail;
            objp[40].Value = locationid;
            objp[41].Value = gstin;
            objp[42].Value = stateid;
            ExecuteQuery("SPUpdateValsMasterBranch", objp);
        }

        */
      
        //sathya
        public void UpdateValOfMasterBranch1(int branchid, int divisionid, int portid, string branchname, string ptc, string address, string phone, string fax, string email, string panno, string stno, string favouring, string bankname, string bankaddress, string swiftcode, string acnos, int regionid, string carrno, byte[] arrimage, int bmid, int rmid, string localacno, string mrcode, string ediuserid, string basecurr, string transbondno, string basepaise, string cinno, string neftcode, string Locfavouring, string Locbankname, string Locbankaddress, string shortname, string accemail, string doxexpemail, string doximpemail, string codexpemail, string codimpemail, string opsexpemail, string opsimpemail, int locationid, string gstin, int stateid, int closingdays, int backdatedays)
        {

            SqlParameter[] objp = new SqlParameter[]                                 {
                                                                                     new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                                                     new SqlParameter("@divisionid",SqlDbType.TinyInt,1),        
                                                                                     new SqlParameter("@portid",SqlDbType.Int), 
                                                                                     new SqlParameter("@branchname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@ptc",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@address",SqlDbType.VarChar,500),
                                                                                     new SqlParameter("@phone",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@fax",SqlDbType.VarChar,50), 
                                                                                     new SqlParameter("@email",SqlDbType.VarChar,50),
                                                                                     new SqlParameter("@panno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@stno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@favouring",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankname",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@bankaddress",SqlDbType.VarChar,100) ,
                                                                                     new SqlParameter("@swiftcode",SqlDbType.VarChar,15) ,
                                                                                     new SqlParameter("@acnos",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@regionid",SqlDbType.Int) ,
                                                                                     new SqlParameter("@carrno",SqlDbType.VarChar,25) ,
                                                                                     new SqlParameter("@arrimage",SqlDbType.Image),
                                                                                     new SqlParameter("@bm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@rm",SqlDbType.Int,4),
                                                                                     new SqlParameter("@localacno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@mrcode",SqlDbType.VarChar,3),
                                                                                     new SqlParameter("@ediuserid",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basecurr",SqlDbType.VarChar,6),
                                                                                     new SqlParameter("@transbondno",SqlDbType.VarChar,25),
                                                                                     new SqlParameter("@basepaise",SqlDbType.VarChar,15),
                                                                                     new SqlParameter("@cinno",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@neftcode",SqlDbType.VarChar,30),
                                                                                     new SqlParameter("@Locfavouring",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankname",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@Locbankaddress",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@shortname",SqlDbType.VarChar,10),
                                                                                     new SqlParameter("@accemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doxexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@doximpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@codimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsexpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@opsimpemail",SqlDbType.VarChar,100),
                                                                                     new SqlParameter("@locationid",SqlDbType.Int),
                                                                                     new SqlParameter("@gstin",SqlDbType.VarChar,20),
                                                                                     new SqlParameter("@stateid",SqlDbType.Int),
                                                                                     new SqlParameter("@closingdays",SqlDbType.Int),
                                                                                     new SqlParameter("@backdatedays",SqlDbType.Int)

                                                                                        
                                                                                         
                                                                                     };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            objp[2].Value = portid;
            objp[3].Value = branchname;
            objp[4].Value = ptc;
            objp[5].Value = address;
            objp[6].Value = phone;
            objp[7].Value = fax;
            objp[8].Value = email;
            objp[9].Value = panno;
            objp[10].Value = stno;
            objp[11].Value = favouring;
            objp[12].Value = bankname;
            objp[13].Value = bankaddress;
            objp[14].Value = swiftcode;
            objp[15].Value = acnos;
            objp[16].Value = regionid;
            objp[17].Value = carrno;
            objp[18].Value = arrimage;
            objp[19].Value = bmid;
            objp[20].Value = rmid;
            objp[21].Value = localacno;
            objp[22].Value = mrcode;
            objp[23].Value = ediuserid;
            objp[24].Value = basecurr;
            objp[25].Value = transbondno;
            objp[26].Value = basepaise;
            objp[27].Value = cinno;
            objp[28].Value = neftcode;
            objp[29].Value = Locfavouring;
            objp[30].Value = Locbankname;
            objp[31].Value = Locbankaddress;
            objp[32].Value = shortname;
            objp[33].Value = accemail;
            objp[34].Value = doxexpemail;
            objp[35].Value = doximpemail;
            objp[36].Value = codexpemail;
            objp[37].Value = codimpemail;
            objp[38].Value = opsexpemail;
            objp[39].Value = opsimpemail;
            objp[40].Value = locationid;
            objp[41].Value = gstin;
            objp[42].Value = stateid;
            objp[43].Value = closingdays;
            objp[44].Value = backdatedays;
            ExecuteQuery("SPUpdateValsMasterBranchnew1", objp);
        }


        public void UpdMasterBranchImage(int branchid, byte[] arrimage)
        {

            SqlParameter[] objp = new SqlParameter[]                              
            {
                                  new SqlParameter("@branchid",SqlDbType.Int,4),
                                  new SqlParameter("@arrimage",SqlDbType.Image)

            };
            objp[0].Value = branchid;
            objp[1].Value = arrimage;
            ExecuteQuery("SPUpdMasterBranchImage", objp);

        }

        public void UpdMasterDIVISIONImage(int divisionid, byte[] arrimage)
        {

            SqlParameter[] objp = new SqlParameter[]                              
            {
                                  new SqlParameter("@divisionid ",SqlDbType.Int,4),
                                  new SqlParameter("@arrimage",SqlDbType.Image)

            };
            objp[0].Value = divisionid;
            objp[1].Value = arrimage;
            ExecuteQuery("SPUpdMasterDivisionImage", objp);

        }

        //RAJ
        public DataTable GetBankDetails(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int)
                                                       };
            objp[0].Value = branchid;

            return ExecuteTable("SP_getbankdetails", objp);

        }


        public DataTable GetBranchGST(int divisionid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int),
                                           new SqlParameter("@branchid", SqlDbType.Int)
                                                       };
            objp[0].Value = divisionid;
            objp[1].Value = branchid;
            return ExecuteTable("spbranchgst", objp);

        }

        public DataTable getSelBranchdetails(int id)
        {

            SqlParameter[] ob = new SqlParameter[]
                                                      { 
                                                  new SqlParameter("@bid", SqlDbType.TinyInt,1)
                                             
                                                      };

            ob[0].Value = id;


            return ExecuteTable("SPSelBranchdetails", ob);

        }


        public int GetClosingid(int branchid, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                                           new SqlParameter("@divisionid", SqlDbType.Int)
                                           
                                                       };
            objp[0].Value = branchid;
            objp[1].Value = divisionid;
            return int.Parse(ExecuteReader("spbranchclosingdays", objp));

        }

        public DataTable getmasterbranchgstin(int portid)
        {

            SqlParameter[] ob = new SqlParameter[]
                                                      { 
                                                  new SqlParameter("@portid", SqlDbType.Int)
                                             
                                                      };

            ob[0].Value = portid;


            return ExecuteTable("spmasterbranchgstin", ob);

        }

        public DataTable getvouincurrentmonth(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                      { 
                                                new SqlParameter("@branchid", SqlDbType.TinyInt, 1)
                                              
                                                      };



            objp[0].Value = branchid;
       

            return ExecuteTable("spvouincurrentmonth", objp);

        }

        public DataTable GetBranchandDivisionnew(int id)
        {

            SqlParameter[] ob = new SqlParameter[]
                                                      { 
                                                  new SqlParameter("@bid", SqlDbType.TinyInt,1)
                                             
                                                      };

            ob[0].Value = id;


            return ExecuteTable("SPSelBranchname4mbidnew", ob);

        }



        //Asvin

        public DataTable GetClosingdays(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]{                                                  
                                                     new SqlParameter("@branchid", SqlDbType.Int)
                                                    };
            objp[0].Value = branchid;


            return ExecuteTable("SPselectclosingdays", objp);

        }

        public DataTable getclosedate(int branchid)
        {

            SqlParameter[] objp = new SqlParameter[]
                                                      {
                                                          new SqlParameter("@branchid", SqlDbType.Int)
                                                      };


            objp[0].Value = branchid;


            return ExecuteTable("SPselectjobclosedate", objp);

        }

        public DataTable GetBranchJobvoucher(int divisionid)
        {

            SqlParameter[] objp = new SqlParameter[]{                                                  
                                                     new SqlParameter("@divisionid", SqlDbType.VarChar,500)  
                                                    };
            objp[0].Value = divisionid;

            return ExecuteTable("SPselectBranchJobvoucher", objp);

        }

        public void Updatejobclosebackdate(int branchid, int closingdays, int backdatedays)
        {
            SqlParameter[] objp = new SqlParameter[]{                                                  
                                                     new SqlParameter("@branchid", SqlDbType.Int),
                                                     new SqlParameter("@closingdays", SqlDbType.Int),
                                                     new SqlParameter("@backdatedays", SqlDbType.Int)
                                                    };
            objp[0].Value = branchid;
            objp[1].Value = closingdays;
            objp[2].Value = backdatedays;

            ExecuteQuery("Spudatejobclosebackdate", objp);
        }
        // yuvaraj 08/09/2022

        public DataSet getmailcredentials(int bid)
        {
            SqlParameter[] objp = new SqlParameter[] {//new SqlParameter("@bid",SqlDbType.Int,4),
                                                       new SqlParameter("@BID", SqlDbType.TinyInt  , 1)};

            //objp[0].Value = bid;
            objp[0].Value = bid;
            // objp[1].Value = todate;
            return ExecuteDataSet("getmailcredentials", objp);


        }

        public DataTable Selcountry4login()
        {
            return ExecuteTable("SPSelcountry4login");
        }

        public DataTable Selbranch4login(string div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@div ", SqlDbType.VarChar, 50) };
            objp[0].Value = div; ;
            return ExecuteTable("SPSelbranch4login", objp);
        }


        public DataTable GetDBName(string DBName)
        {
            SqlParameter[] array = new SqlParameter[1]
            {
            new SqlParameter("@DBName", SqlDbType.VarChar, 50)
            };
            array[0].Value = DBName;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPGetDataBaseName", parameters);
        }

    }
}
