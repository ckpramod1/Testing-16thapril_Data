using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Masters
{
    public class MasterDivision : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public MasterDivision()
        {
            Conn = new SqlConnection(DBCS);
        }
        public void InsertMasterDivision(string divisionname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionname",SqlDbType.Char,100)
                                                     };

            objp[0].Value = divisionname;
            ExecuteQuery("SPInsDivisionDetails", objp);


        }

        public void UpdateMasterDivision(int id, string divisionname)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                   new SqlParameter("@divisionname",SqlDbType.Char,1000),
                new SqlParameter("@divisionid",SqlDbType.Int,10)
                                               

                                       };
            objp[0].Value = divisionname;
            objp[1].Value = id;

            ExecuteQuery("SPUpdMasterDivision", objp);

        }

        public DataTable GetBranchidsFromDivisionid(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                    new SqlParameter("@divisionid",SqlDbType.TinyInt,1)
                                                     };
            objp[0].Value = divisionid;
            return (ExecuteTable("SPGetBranchIDFromDivisionid", objp));
        }

        public string GetShortName(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int, 4) };
            objp[0].Value = divisionid;
            return ExecuteReader("SPGetDivisionShortName", objp);
        }


        public DataTable GetLikeMasterDivision(string divisionname)
        {
            SqlParameter[] objp1 = new SqlParameter[] { 
                                                     new SqlParameter("@divisionname",SqlDbType.VarChar, 1000)
                                                     };
            objp1[0].Value = divisionname;
            return ExecuteTable("SPLikeMasterDivision", objp1);

        }

        public DataTable GetAllDivisionId()
        {
            return ExecuteTable("SPGetAllDivisionId");
        }

        public DataTable GetLikeDivision(string divionname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                   { 
                                                     new SqlParameter("@divisionname", SqlDbType.VarChar, 100) 
                                                   };
            objp[0].Value = divionname;
            return ExecuteTable("SPSelectLikeDivision", objp);
        }

        //public DataTable GetAllDivisionNames()
        //{
        //    return ExecuteTable("SPGetAllDivisionNames");
        //}


        public int GetDivisionid(string divisionname)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                  new SqlParameter("@divisionname", SqlDbType.VarChar, 1000) 
                                                     };
            objp[0].Value = divisionname;

            return int.Parse(ExecuteReader("SPSelDivisionId", objp));
        }


        //public bool CheckDivisionName(string Divisionname)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionname", SqlDbType.VarChar, 100) };
        //    objp[0].Value = Divisionname;
        //    string ret = ExecuteReader("SPDivisionidName", objp);
        //    if (ret.Equals("0"))
        //        return false;
        //    else
        //        return true;
        //}



        public DataTable GetMasterDivisionDetails(int divisionid)
        {
            SqlParameter[] objp1 = new SqlParameter[] { 
                                                     new SqlParameter("@divisionid",SqlDbType.Int,4)
                                                     };
            objp1[0].Value = divisionid;
            return ExecuteTable("SPGetMasterDivisionDetails", objp1);
        }

        //public void InsertMasterDivision(string divisionname, string phoneno, string fax, string panno, string stno, string corpadd, int city, string tanno, DateTime fyfrom, DateTime fyto, byte[] dlogo, string bankname, string bankaddress, string swift, string carr, string acno)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //                                              new SqlParameter("@divisionname",SqlDbType.Char,100),
        //        new SqlParameter("@phoneno",SqlDbType.VarChar,25),
        //        new SqlParameter("@fax",SqlDbType.VarChar,25),
        //        new SqlParameter("@panno",SqlDbType.VarChar,25),
        //        new SqlParameter("@stno",SqlDbType.VarChar,25),
        //        new SqlParameter("@corpadd",SqlDbType.VarChar,100),
        //        new SqlParameter("@city",SqlDbType.Int,4),
        //        new SqlParameter("@tanno",SqlDbType.VarChar,25),
        //        new SqlParameter("@fyfrom",SqlDbType.SmallDateTime,10),
        //        new SqlParameter("@fyto",SqlDbType.SmallDateTime,10),
        //        new SqlParameter("@dlogo",SqlDbType.Image),
        //         new SqlParameter("@bank",SqlDbType.VarChar,30),
        //         new SqlParameter("@bankaddress",SqlDbType.VarChar,100),
        //         new SqlParameter("@swift",SqlDbType.VarChar,25),
        //         new SqlParameter("@carrno",SqlDbType.VarChar,25),
        //         new SqlParameter("@acno",SqlDbType.VarChar,25)
        //                                             };

        //    objp[0].Value = divisionname;
        //    objp[1].Value = phoneno;
        //    objp[2].Value = fax;
        //    objp[3].Value = panno;
        //    objp[4].Value = stno;
        //    objp[5].Value = corpadd;
        //    objp[6].Value = city;
        //    objp[7].Value = tanno;
        //    objp[8].Value = fyfrom;
        //    objp[9].Value = fyto;
        //    objp[10].Value = dlogo;
        //    objp[11].Value = bankname;
        //    objp[12].Value = bankaddress;
        //    objp[13].Value = swift;
        //    objp[14].Value = carr;
        //    objp[15].Value = acno;
        //    ExecuteQuery("SPInsDivisionDetails", objp);


        //}


        public void InsertMasterDivision(string divisionname, string phoneno, string fax, string panno, string corpadd, int city, string tanno, DateTime fyfrom, DateTime fyto, byte[] dlogo, string stno, int bank, string swift, string acno, string carrno, string bankaddress, string door, string bname, string street, int locationid, string pincode, int stateid, int countryid, int pisd, string pstd, int fisd, string fstd, string curr, string paise, int deci, string dateformat, string unit, string pfno, string esino, string email,string ifscode,string accounttype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@divisionname",SqlDbType.Char,1000),
                new SqlParameter("@phoneno",SqlDbType.VarChar,50),
                new SqlParameter("@fax",SqlDbType.VarChar,25),
                new SqlParameter("@panno",SqlDbType.VarChar,25),
                new SqlParameter("@corpadd",SqlDbType.VarChar,100),                
                new SqlParameter("@city",SqlDbType.Int,4),
                new SqlParameter("@tanno",SqlDbType.VarChar,25),
                new SqlParameter("@fyfrom",SqlDbType.SmallDateTime,10),
                new SqlParameter("@fyto",SqlDbType.SmallDateTime,10),
                new SqlParameter("@dlogo",SqlDbType.Image),
                new SqlParameter("@stno",SqlDbType.VarChar,25),
                 new SqlParameter("@bank",SqlDbType.Int,4),
                 new SqlParameter("@swift ",SqlDbType.VarChar,25),
                 new SqlParameter("@acno",SqlDbType.VarChar,25),
                 new SqlParameter("@carrno",SqlDbType.VarChar,25),
                 new SqlParameter("@bankaddress ",SqlDbType.VarChar,100),
                new SqlParameter("@door",SqlDbType.VarChar,25),
                 new SqlParameter("@bname",SqlDbType.VarChar,50),
                new SqlParameter("@street",SqlDbType.VarChar,25),
                 new SqlParameter("@locationid",SqlDbType.Int),
                   new SqlParameter("@pincode",SqlDbType.VarChar,6),
                           new SqlParameter("@stateid",SqlDbType.Int),
                        new SqlParameter("@countryid",SqlDbType.Int),
                           new SqlParameter("@pisd ", SqlDbType.TinyInt),
                         new SqlParameter("@pstd", SqlDbType.VarChar, 10),
                         new SqlParameter("@fisd", SqlDbType.TinyInt),
                    new SqlParameter("@fstd", SqlDbType.VarChar, 10),
                    new SqlParameter("@curr", SqlDbType.VarChar, 10),
                        new SqlParameter("@paise", SqlDbType.VarChar, 5),
                           new SqlParameter("@decimal", SqlDbType.TinyInt),
                          new SqlParameter("@dateformat", SqlDbType.VarChar, 15),                           
                            new SqlParameter("@unit", SqlDbType.VarChar, 10),
                            new SqlParameter("@pfno",SqlDbType.VarChar,20),
                                   new SqlParameter("@esino",SqlDbType.VarChar,20),
                                    new SqlParameter("@email",SqlDbType.VarChar,20),
                                     new SqlParameter("@ifscode",SqlDbType.VarChar,20),
                                       new SqlParameter("@accounttype",SqlDbType.VarChar,20)
            };
          

                                                    

            objp[0].Value = divisionname;
            objp[1].Value = phoneno;
            objp[2].Value = fax;
            objp[3].Value = panno;
            objp[4].Value =  corpadd;
            objp[5].Value = city;      //
            objp[6].Value = tanno;
            objp[7].Value = fyfrom;
            objp[8].Value = fyto;
            objp[9].Value = dlogo;
            objp[10].Value = stno;
            objp[11].Value = bank;
            objp[12].Value = swift;
            objp[13].Value = acno;
            objp[14].Value = carrno;
            objp[15].Value = bankaddress;
            objp[16].Value = door;
            objp[17].Value = bname;
            objp[18].Value = street ;
            objp[19].Value = locationid;
            objp[20].Value = pincode;
            objp[21].Value = stateid;
            objp[22].Value = countryid;
            objp[23].Value = pisd;
            objp[24].Value = pstd;
            objp[25].Value = fisd;
            objp[26].Value = fstd;
            objp[27].Value = curr;
            objp[28].Value = paise;
            objp[29].Value = deci;
            objp[30].Value = dateformat;          
            objp[31].Value = unit;
            objp[32].Value = pfno;
            objp[33].Value = esino;
            objp[34].Value = email;
            objp[35].Value = ifscode;
            objp[36].Value = accounttype;
            ExecuteQuery("SPInsDivisionmaster", objp);


        }





        //public void UpdateMasterDivision(int id, string divisionname, string address, string panno, string tanno, string stno, string faxno, string phoneno, int portid, DateTime fyfrom, DateTime fyto, byte[] arrimage, string bank, string bankaddress, string swift, string acno, string carrno)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //        new SqlParameter("@divisionname",SqlDbType.VarChar,100),
        //        new SqlParameter("@divisionid",SqlDbType.TinyInt),
        //        new SqlParameter("@panno",SqlDbType.VarChar,50),
        //        new SqlParameter("@tanno",SqlDbType.VarChar,25),
        //        new SqlParameter("@stno",SqlDbType.VarChar,50),
        //        new SqlParameter("@faxno",SqlDbType.VarChar,25),
        //        new SqlParameter("@phoneno",SqlDbType.VarChar,25),
        //        new SqlParameter("@corpadd",SqlDbType.VarChar,100),
        //        new SqlParameter("@city",SqlDbType.Int,4),
        //        new SqlParameter("@fyfrom",SqlDbType.SmallDateTime,10),
        //        new SqlParameter("@fyto",SqlDbType.SmallDateTime,10),
        //        new SqlParameter("@dlogo",SqlDbType.Image),
        //     new SqlParameter("@bank",SqlDbType.Int),
        //     new SqlParameter("@swift",SqlDbType.VarChar,25),
        //     new SqlParameter("@acno",SqlDbType.VarChar,25),
        //     new SqlParameter("@carrno",SqlDbType.VarChar,25),
        //     new SqlParameter("@bankaddress",SqlDbType.VarChar,100)};

        //    objp[0].Value = divisionname;
        //    objp[1].Value = id;
        //    objp[2].Value = panno;
        //    objp[3].Value = tanno;
        //    objp[4].Value = stno;
        //    objp[5].Value = faxno;
        //    objp[6].Value = phoneno;
        //    objp[7].Value = address;
        //    objp[8].Value = portid;
        //    objp[9].Value = fyfrom;
        //    objp[10].Value = fyto;
        //    objp[11].Value = arrimage;
        //    objp[12].Value = bank;
        //    objp[13].Value = swift;
        //    objp[14].Value = acno;
        //    objp[15].Value = carrno;
        //    objp[16].Value = bankaddress;
        //    ExecuteQuery("SPUpdMasterDivision", objp);
        //}

        public void UpdateMasterDivision(int divisionid, string divisionname, string phoneno, string fax, string panno, string corpadd, int city, string tanno, DateTime fyfrom, DateTime fyto, byte[] dlogo, string stno, int bank, string swift, string acno, string carrno, string bankaddress, string door, string bname, string street, int locationid, string pincode, int stateid, int countryid, int pisd, string pstd, int fisd, string fstd, string curr, string paise, int deci, string dateformat, string unit, string pfno, string esino, string email, string ifscode, string accounttype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@divisionid",SqlDbType.Int),
                                                      new SqlParameter("@divisionname",SqlDbType.Char,1000),
                new SqlParameter("@phoneno",SqlDbType.VarChar,50),
                new SqlParameter("@fax",SqlDbType.VarChar,25),
                new SqlParameter("@panno",SqlDbType.VarChar,25),
                new SqlParameter("@corpadd",SqlDbType.VarChar,100),                
                new SqlParameter("@city",SqlDbType.Int,4),
                new SqlParameter("@tanno",SqlDbType.VarChar,25),
                new SqlParameter("@fyfrom",SqlDbType.SmallDateTime,10),
                new SqlParameter("@fyto",SqlDbType.SmallDateTime,10),
                new SqlParameter("@dlogo",SqlDbType.Image),
                new SqlParameter("@stno",SqlDbType.VarChar,25),
                 new SqlParameter("@bank",SqlDbType.Int,4),
                 new SqlParameter("@swift ",SqlDbType.VarChar,25),
                 new SqlParameter("@acno",SqlDbType.VarChar,25),
                 new SqlParameter("@carrno",SqlDbType.VarChar,25),
                 new SqlParameter("@bankaddress ",SqlDbType.VarChar,100),
                new SqlParameter("@door",SqlDbType.VarChar,25),
                 new SqlParameter("@bname",SqlDbType.VarChar,50),
                new SqlParameter("@street",SqlDbType.VarChar,25),
                 new SqlParameter("@locationid",SqlDbType.Int),
                   new SqlParameter("@pincode",SqlDbType.VarChar,6),
                           new SqlParameter("@stateid",SqlDbType.Int),
                        new SqlParameter("@countryid",SqlDbType.Int),
                           new SqlParameter("@pisd ", SqlDbType.TinyInt),
                         new SqlParameter("@pstd", SqlDbType.VarChar, 10),
                         new SqlParameter("@fisd", SqlDbType.TinyInt),
                    new SqlParameter("@fstd", SqlDbType.VarChar, 10),
                    new SqlParameter("@curr", SqlDbType.VarChar, 10),
                        new SqlParameter("@paise", SqlDbType.VarChar, 5),
                           new SqlParameter("@decimal", SqlDbType.TinyInt),
                          new SqlParameter("@dateformat", SqlDbType.VarChar, 15),                           
                            new SqlParameter("@unit", SqlDbType.VarChar, 10),
                            new SqlParameter("@pfno",SqlDbType.VarChar,20),
                                   new SqlParameter("@esino",SqlDbType.VarChar,20),
                                    new SqlParameter("@email",SqlDbType.VarChar,20),
                                     new SqlParameter("@ifscode",SqlDbType.VarChar,20),
                                      new SqlParameter("@accounttype",SqlDbType.VarChar,20)
            };



            objp[0].Value = divisionid;
            objp[1].Value = divisionname;
            objp[2].Value = phoneno;
            objp[3].Value = fax;
            objp[4].Value = panno;
            objp[5].Value = corpadd;
            objp[6].Value = city;      //
            objp[7].Value = tanno;
            objp[8].Value = fyfrom;
            objp[9].Value = fyto;
            objp[10].Value = dlogo;
            objp[11].Value = stno;
            objp[12].Value = bank;
            objp[13].Value = swift;
            objp[14].Value = acno;
            objp[15].Value = carrno;
            objp[16].Value = bankaddress;
            objp[17].Value = door;
            objp[18].Value = bname;
            objp[19].Value = street;
            objp[20].Value = locationid;
            objp[21].Value = pincode;
            objp[22].Value = stateid;
            objp[23].Value = countryid;
            objp[24].Value = pisd;
            objp[25].Value = pstd;
            objp[26].Value = fisd;
            objp[27].Value = fstd;
            objp[28].Value = curr;
            objp[29].Value = paise;
            objp[30].Value = deci;
            objp[31].Value = dateformat;
            objp[32].Value = unit;
            objp[33].Value = pfno;
            objp[34].Value = esino;
            objp[35].Value = email;
            objp[36].Value = ifscode;
            objp[37].Value = accounttype;
            ExecuteQuery("SPUpdDivisionmaster", objp);


        }
        //Dinesh

        public string GetMasterDivisionName(int id)
        {
            SqlParameter[] objp = new SqlParameter[] {                                                   
                new SqlParameter("@divisionid",SqlDbType.Int,10)
                                               

                                       };

            objp[0].Value = id;

            return ExecuteReader("SPGetMasterDivisionName", objp);

        }
        // apprval credit 28/12/2022
        public int GetDivisionId_new(string strDivision)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.VarChar,100)
                        };
            objp[0].Value = strDivision;
            Dt = ExecuteTable("SPDivisionIDnew", objp);
            int intResult = 0;
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }

        public void Logoimguploadindiv(int divisionid,byte[] dlogo)
        {
            SqlParameter[] objp1 = new SqlParameter[] { 
                                                     new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                     new SqlParameter("@dlogo",SqlDbType.Image)
                                                     };
            objp1[0].Value = divisionid;
            objp1[1].Value = dlogo;
            ExecuteTable("spLogoimguploadindiv", objp1);
        }

        public DataTable Getlogo(int divisionid)
        {
            SqlParameter[] objp1 = new SqlParameter[] { 
                                                     new SqlParameter("@divid",SqlDbType.Int,4)
                                                     };
            objp1[0].Value = divisionid;
            return ExecuteTable("SpGetlogo", objp1);
        }
        public DataTable Getdivnamerblrelease(int divisionid)
        {
            SqlParameter[] objp1 = new SqlParameter[] { 
                                                     new SqlParameter("@divid",SqlDbType.Int,4)
                                                     };
            objp1[0].Value = divisionid;
            return ExecuteTable("SPGetdivnamerblrelease", objp1);
        }
        public string Selsite(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divid", SqlDbType.Int, 4) };
            objp[0].Value = divisionid;
            return ExecuteReader("SPSelsite", objp);
        }
        public void BLimguploadindiv(int divisionid, byte[] dlogo)
        {
            SqlParameter[] objp1 = new SqlParameter[] {
                                                     new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                     new SqlParameter("@dlogo",SqlDbType.Image)
                                                     };
            objp1[0].Value = divisionid;
            objp1[1].Value = dlogo;
            ExecuteTable("spBLimguploadindiv", objp1);
        }
        public DataTable Getblformtrpt(int divisionid)
        {
            SqlParameter[] objp1 = new SqlParameter[] {
                                                     new SqlParameter("@divid",SqlDbType.Int,4)
                                                     };
            objp1[0].Value = divisionid;
            return ExecuteTable("SPGetblformtrpt", objp1);
        }

        public DataTable GetBLDetails2(string strBlno)
        {
            SqlParameter[] array = new SqlParameter[1]
            {
     new SqlParameter("@blno", SqlDbType.VarChar, 30)
            };
            array[0].Value = strBlno;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPFEBLDetailBLNO", parameters);
        }

        public DataTable ShowBLDetailsBLNO(string blno)
        {
            SqlParameter[] array = new SqlParameter[1]
            {
     new SqlParameter("@blno", SqlDbType.VarChar, 30)
            };
            array[0].Value = blno;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPSelOIBLDetailsBLNO", parameters);
        }

        public DataTable GetAIEDetailBLNO(string strhawblno, string strType)
        {
            SqlParameter[] array = new SqlParameter[2]
            {
     new SqlParameter("@hawblno", SqlDbType.VarChar, 30),
     new SqlParameter("@trantype", SqlDbType.VarChar, 2)
            };
            array[0].Value = strhawblno;
            array[1].Value = strType;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPSelAIEBLDetailsBLNO", parameters);
        }
    }
}

