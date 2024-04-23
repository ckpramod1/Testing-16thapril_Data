using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccess;
namespace DataAccess.HR
{
    public class Employee : DBObject
    {
       // DataAccess.MIS MISObj = new DataAccess.MIS();
        int intEmpID, intDivisionID, intDesigID,intDeptID;
        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterPort prtObj = new DataAccess.Masters.MasterPort();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }


      
        public Employee()
        {
            Conn = new SqlConnection(DBCS);
        }
        //public void InsEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto)
        //{
        //    SqlParameter[] objp = new SqlParameter[] 
        //                {
        //                    new SqlParameter("@title",SqlDbType.VarChar,3),
        //                    new SqlParameter("@empcode",SqlDbType.VarChar,10),
        //                    new SqlParameter("@empname",SqlDbType.VarChar,50),
        //                    new SqlParameter("@fathername",SqlDbType.VarChar,50),
        //                    new SqlParameter("@spousename",SqlDbType.VarChar,50),
        //                    new SqlParameter("@dob",SqlDbType.DateTime,8),
        //                    new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
        //                    new SqlParameter("@addressc",SqlDbType.VarChar,150),
        //                    new SqlParameter("@addressp",SqlDbType.VarChar,150),
        //                    new SqlParameter("@phonehp",SqlDbType.VarChar,15),
        //                    new SqlParameter("@phoneres",SqlDbType.VarChar,15),
        //                    new SqlParameter("@email",SqlDbType.VarChar,50),
        //                     new SqlParameter("@accno",SqlDbType.VarChar,25),
        //                    new SqlParameter("@panno",SqlDbType.VarChar,20),
        //                    new SqlParameter("@empphoto",SqlDbType.Image)  
        //                };
        //    objp[0].Value = strTitle;
        //    objp[1].Value = strEmpCode;
        //    objp[2].Value = strEmpName;
        //    objp[3].Value = strFName;
        //    objp[4].Value = strSPName;
        //    objp[5].Value = datDob;
        //    objp[6].Value = strBG;
        //    objp[7].Value = strCA;
        //    objp[8].Value = strPA; 
        //    objp[9].Value = strph;
        //    objp[10].Value = strphres;
        //    objp[11].Value = strEmail;
        //    objp[12].Value = accountno;
        //    objp[13].Value = panno;
        //    objp[14].Value = empphoto;
        //   ExecuteQuery("SPInsEmpPersonal",objp);            
        //}
        //public void UpdEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto)
        //{
        //    SqlParameter[] objp = new SqlParameter[] 
        //                {
        //                    new SqlParameter("@title",SqlDbType.VarChar,3),
        //                    new SqlParameter("@empcode",SqlDbType.VarChar,10),
        //                    new SqlParameter("@empname",SqlDbType.VarChar,50),
        //                    new SqlParameter("@fathername",SqlDbType.VarChar,50),
        //                    new SqlParameter("@spousename",SqlDbType.VarChar,50),
        //                    new SqlParameter("@dob",SqlDbType.DateTime,8),
        //                    new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
        //                    new SqlParameter("@addressc",SqlDbType.VarChar,150),
        //                    new SqlParameter("@addressp",SqlDbType.VarChar,150),
        //                    new SqlParameter("@phonehp",SqlDbType.VarChar,15),
        //                    new SqlParameter("@phoneres",SqlDbType.VarChar,15),
        //                    new SqlParameter("@email",SqlDbType.VarChar,50),
        //                     new SqlParameter("@accno",SqlDbType.VarChar,25),
        //                    new SqlParameter("@panno",SqlDbType.VarChar,20),
        //                    new SqlParameter("@empphoto",SqlDbType.Image)
        //                };
        //    objp[0].Value = strTitle;
        //    objp[1].Value = strEmpCode;
        //    objp[2].Value = strEmpName;
        //    objp[3].Value = strFName;
        //    objp[4].Value = strSPName;
        //    objp[5].Value = datDob;
        //    objp[6].Value = strBG;
        //    objp[7].Value = strCA;
        //    objp[8].Value = strPA;
        //    objp[9].Value = strph;
        //    objp[10].Value = strphres;
        //    objp[11].Value = strEmail;
        //    objp[12].Value = accountno;
        //    objp[13].Value = panno;
        //    objp[14].Value = empphoto;
        //    ExecuteQuery("SPUpdEmpPersonal", objp);            
        //}

        //public void InsEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto,string pfno,string esino,char ouremp)
        //{
        //    SqlParameter[] objp = new SqlParameter[] 
        //                {
        //                    new SqlParameter("@title",SqlDbType.VarChar,3),
        //                    new SqlParameter("@empcode",SqlDbType.VarChar,10),
        //                    new SqlParameter("@empname",SqlDbType.VarChar,50),
        //                    new SqlParameter("@fathername",SqlDbType.VarChar,50),
        //                    new SqlParameter("@spousename",SqlDbType.VarChar,50),
        //                    new SqlParameter("@dob",SqlDbType.DateTime,8),
        //                    new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
        //                    new SqlParameter("@addressc",SqlDbType.VarChar,150),
        //                    new SqlParameter("@addressp",SqlDbType.VarChar,150),
        //                    new SqlParameter("@phonehp",SqlDbType.VarChar,15),
        //                    new SqlParameter("@phoneres",SqlDbType.VarChar,15),
        //                    new SqlParameter("@email",SqlDbType.VarChar,50),
        //                     new SqlParameter("@accno",SqlDbType.VarChar,25),
        //                    new SqlParameter("@panno",SqlDbType.VarChar,20),
        //                    new SqlParameter("@empphoto",SqlDbType.Image)  ,
        //                    //new SqlParameter("@sign",SqlDbType.Image),
        //                    new SqlParameter("@pfno",SqlDbType.VarChar,25),
        //                    new SqlParameter("@esino",SqlDbType.VarChar,25),
        //                    new SqlParameter("@tmpemp",SqlDbType.Char,1)

        //                };
        //    objp[0].Value = strTitle;
        //    objp[1].Value = strEmpCode;
        //    objp[2].Value = strEmpName;
        //    objp[3].Value = strFName;
        //    objp[4].Value = strSPName;
        //    objp[5].Value = datDob;
        //    objp[6].Value = strBG;
        //    objp[7].Value = strCA;
        //    objp[8].Value = strPA;
        //    objp[9].Value = strph;
        //    objp[10].Value = strphres;
        //    objp[11].Value = strEmail;
        //    objp[12].Value = accountno;
        //    objp[13].Value = panno;
        //    objp[14].Value = empphoto;
        //    //objp[15].Value = sign;
        //    objp[15].Value = pfno;
        //    objp[16].Value = esino;
        //    objp[17].Value = ouremp;
        //    ExecuteQuery("SPInsEmpPersonal", objp);
        //}
        //public void UpdEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto, string pfno, string esino,char ouremp)
        //{
        //    SqlParameter[] objp = new SqlParameter[] 
        //                {
        //                    new SqlParameter("@title",SqlDbType.VarChar,3),
        //                    new SqlParameter("@empcode",SqlDbType.VarChar,10),
        //                    new SqlParameter("@empname",SqlDbType.VarChar,50),
        //                    new SqlParameter("@fathername",SqlDbType.VarChar,50),
        //                    new SqlParameter("@spousename",SqlDbType.VarChar,50),
        //                    new SqlParameter("@dob",SqlDbType.DateTime,8),
        //                    new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
        //                    new SqlParameter("@addressc",SqlDbType.VarChar,150),
        //                    new SqlParameter("@addressp",SqlDbType.VarChar,150),
        //                    new SqlParameter("@phonehp",SqlDbType.VarChar,15),
        //                    new SqlParameter("@phoneres",SqlDbType.VarChar,15),
        //                    new SqlParameter("@email",SqlDbType.VarChar,50),
        //                     new SqlParameter("@accno",SqlDbType.VarChar,25),
        //                    new SqlParameter("@panno",SqlDbType.VarChar,20),
        //                    new SqlParameter("@empphoto",SqlDbType.Image) ,
        //                    //new SqlParameter("@sign",SqlDbType.Image),
        //                    new SqlParameter("@pfno",SqlDbType.VarChar,25),
        //                    new SqlParameter("@esino",SqlDbType.VarChar,25),
        //                     new SqlParameter("@tmpemp",SqlDbType.Char,1)
        //                };
        //    objp[0].Value = strTitle;
        //    objp[1].Value = strEmpCode;
        //    objp[2].Value = strEmpName;
        //    objp[3].Value = strFName;
        //    objp[4].Value = strSPName;
        //    objp[5].Value = datDob;
        //    objp[6].Value = strBG;
        //    objp[7].Value = strCA;
        //    objp[8].Value = strPA;
        //    objp[9].Value = strph;
        //    objp[10].Value = strphres;
        //    objp[11].Value = strEmail;
        //    objp[12].Value = accountno;
        //    objp[13].Value = panno;
        //    objp[14].Value = empphoto;
        //    objp[15].Value = pfno;
        //    objp[16].Value = esino;
        //    objp[17].Value = ouremp;
        //    ExecuteQuery("SPUpdEmpPersonal", objp);
        //}
        //For change in hrpersonalinfo(add pfno and esI no)
       /* public void InsEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto, string pfno, string esino, string tempemp, string phoneoth)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@title",SqlDbType.VarChar,3),
                            new SqlParameter("@empcode",SqlDbType.VarChar,10),
                            new SqlParameter("@empname",SqlDbType.VarChar,50),
                            new SqlParameter("@fathername",SqlDbType.VarChar,50),
                            new SqlParameter("@spousename",SqlDbType.VarChar,50),
                            new SqlParameter("@dob",SqlDbType.DateTime,8),
                            new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
                            new SqlParameter("@addressc",SqlDbType.VarChar,150),
                            new SqlParameter("@addressp",SqlDbType.VarChar,150),
                            new SqlParameter("@phonehp",SqlDbType.VarChar,15),
                            new SqlParameter("@phoneres",SqlDbType.VarChar,15),
                            new SqlParameter("@email",SqlDbType.VarChar,50),
                             new SqlParameter("@accno",SqlDbType.VarChar,25),
                            new SqlParameter("@panno",SqlDbType.VarChar,20),
                            new SqlParameter("@empphoto",SqlDbType.Image)  ,
                            //new SqlParameter("@sign",SqlDbType.Image),
                            new SqlParameter("@pfno",SqlDbType.VarChar,25),
                            new SqlParameter("@esino",SqlDbType.VarChar,25),
                            new SqlParameter("@tmpemp",SqlDbType.Char,1),
                            new SqlParameter("@phoneoth",SqlDbType.VarChar,15)
                        };
            objp[0].Value = strTitle;
            objp[1].Value = strEmpCode;
            objp[2].Value = strEmpName;
            objp[3].Value = strFName;
            objp[4].Value = strSPName;
            objp[5].Value = datDob;
            objp[6].Value = strBG;
            objp[7].Value = strCA;
            objp[8].Value = strPA;
            objp[9].Value = strph;
            objp[10].Value = strphres;
            objp[11].Value = strEmail;
            objp[12].Value = accountno;
            objp[13].Value = panno;
            objp[14].Value = empphoto;
            //objp[15].Value = sign;
            objp[15].Value = pfno;
            objp[16].Value = esino;
            objp[17].Value = tempemp;
            objp[18].Value = phoneoth;
            ExecuteQuery("SPInsEmpPersonal", objp);
        }
        public void UpdEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto, string pfno, string esino, string tempemp, string phoneoth)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@title",SqlDbType.VarChar,3),
                            new SqlParameter("@empcode",SqlDbType.VarChar,10),
                            new SqlParameter("@empname",SqlDbType.VarChar,50),
                            new SqlParameter("@fathername",SqlDbType.VarChar,50),
                            new SqlParameter("@spousename",SqlDbType.VarChar,50),
                            new SqlParameter("@dob",SqlDbType.DateTime,8),
                            new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
                            new SqlParameter("@addressc",SqlDbType.VarChar,150),
                            new SqlParameter("@addressp",SqlDbType.VarChar,150),
                            new SqlParameter("@phonehp",SqlDbType.VarChar,15),
                            new SqlParameter("@phoneres",SqlDbType.VarChar,15),
                            new SqlParameter("@email",SqlDbType.VarChar,50),
                             new SqlParameter("@accno",SqlDbType.VarChar,25),
                            new SqlParameter("@panno",SqlDbType.VarChar,20),
                            new SqlParameter("@empphoto",SqlDbType.Image) ,
                            //new SqlParameter("@sign",SqlDbType.Image),
                            new SqlParameter("@pfno",SqlDbType.VarChar,25),
                            new SqlParameter("@esino",SqlDbType.VarChar,25),
                            new SqlParameter("@tmpemp",SqlDbType.Char,1),
                            new SqlParameter("@phoneoth",SqlDbType.VarChar,15)
                        };
            objp[0].Value = strTitle;
            objp[1].Value = strEmpCode;
            objp[2].Value = strEmpName;
            objp[3].Value = strFName;
            objp[4].Value = strSPName;
            objp[5].Value = datDob;
            objp[6].Value = strBG;
            objp[7].Value = strCA;
            objp[8].Value = strPA;
            objp[9].Value = strph;
            objp[10].Value = strphres;
            objp[11].Value = strEmail;
            objp[12].Value = accountno;
            objp[13].Value = panno;
            objp[14].Value = empphoto;
            objp[15].Value = pfno;
            objp[16].Value = esino;
            objp[17].Value = tempemp;
            objp[18].Value = phoneoth;
            ExecuteQuery("SPUpdEmpPersonal", objp);
        }
        */
        //Arun
        /*public void InsEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto, string pfno, string esino, string tempemp, string phoneoth, int reporting)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@title",SqlDbType.VarChar,3),
                            new SqlParameter("@empcode",SqlDbType.VarChar,10),
                            new SqlParameter("@empname",SqlDbType.VarChar,50),
                            new SqlParameter("@fathername",SqlDbType.VarChar,50),
                            new SqlParameter("@spousename",SqlDbType.VarChar,50),
                            new SqlParameter("@dob",SqlDbType.DateTime,8),
                            new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
                            new SqlParameter("@addressc",SqlDbType.VarChar,150),
                            new SqlParameter("@addressp",SqlDbType.VarChar,150),
                            new SqlParameter("@phonehp",SqlDbType.VarChar,15),
                            new SqlParameter("@phoneres",SqlDbType.VarChar,15),
                            new SqlParameter("@email",SqlDbType.VarChar,50),
                             new SqlParameter("@accno",SqlDbType.VarChar,25),
                            new SqlParameter("@panno",SqlDbType.VarChar,20),
                            new SqlParameter("@empphoto",SqlDbType.Image)  ,
                            //new SqlParameter("@sign",SqlDbType.Image),
                            new SqlParameter("@pfno",SqlDbType.VarChar,25),
                            new SqlParameter("@esino",SqlDbType.VarChar,25),
                            new SqlParameter("@tmpemp",SqlDbType.Char,1),
                            new SqlParameter("@phoneoth",SqlDbType.VarChar,15),
                             new SqlParameter("@reportingto",SqlDbType.Int)
                        };
            objp[0].Value = strTitle;
            objp[1].Value = strEmpCode;
            objp[2].Value = strEmpName;
            objp[3].Value = strFName;
            objp[4].Value = strSPName;
            objp[5].Value = datDob;
            objp[6].Value = strBG;
            objp[7].Value = strCA;
            objp[8].Value = strPA;
            objp[9].Value = strph;
            objp[10].Value = strphres;
            objp[11].Value = strEmail;
            objp[12].Value = accountno;
            objp[13].Value = panno;
            objp[14].Value = empphoto;
            //objp[15].Value = sign;
            objp[15].Value = pfno;
            objp[16].Value = esino;
            objp[17].Value = tempemp;
            objp[18].Value = phoneoth;
            objp[19].Value = reporting;
            ExecuteQuery("SPInsEmpPersonal", objp);
        }




        public void UpdEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto, string pfno, string esino, string tempemp, string phoneoth, int reporting)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@title",SqlDbType.VarChar,3),
                            new SqlParameter("@empcode",SqlDbType.VarChar,10),
                            new SqlParameter("@empname",SqlDbType.VarChar,50),
                            new SqlParameter("@fathername",SqlDbType.VarChar,50),
                            new SqlParameter("@spousename",SqlDbType.VarChar,50),
                            new SqlParameter("@dob",SqlDbType.DateTime,8),
                            new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
                            new SqlParameter("@addressc",SqlDbType.VarChar,150),
                            new SqlParameter("@addressp",SqlDbType.VarChar,150),
                            new SqlParameter("@phonehp",SqlDbType.VarChar,15),
                            new SqlParameter("@phoneres",SqlDbType.VarChar,15),
                            new SqlParameter("@email",SqlDbType.VarChar,50),
                             new SqlParameter("@accno",SqlDbType.VarChar,25),
                            new SqlParameter("@panno",SqlDbType.VarChar,20),
                            new SqlParameter("@empphoto",SqlDbType.Image) ,
                            //new SqlParameter("@sign",SqlDbType.Image),
                            new SqlParameter("@pfno",SqlDbType.VarChar,25),
                            new SqlParameter("@esino",SqlDbType.VarChar,25),
                            new SqlParameter("@tmpemp",SqlDbType.Char,1),
                            new SqlParameter("@phoneoth",SqlDbType.VarChar,15),
                             new SqlParameter("@reportingto",SqlDbType.Int)
                        };
            objp[0].Value = strTitle;
            objp[1].Value = strEmpCode;
            objp[2].Value = strEmpName;
            objp[3].Value = strFName;
            objp[4].Value = strSPName;
            objp[5].Value = datDob;
            objp[6].Value = strBG;
            objp[7].Value = strCA;
            objp[8].Value = strPA;
            objp[9].Value = strph;
            objp[10].Value = strphres;
            objp[11].Value = strEmail;
            objp[12].Value = accountno;
            objp[13].Value = panno;
            objp[14].Value = empphoto;
            objp[15].Value = pfno;
            objp[16].Value = esino;
            objp[17].Value = tempemp;
            objp[18].Value = phoneoth;
            objp[19].Value = reporting;
            ExecuteQuery("SPUpdEmpPersonal", objp);
        }

        */

        //MUTHU
        public void InsEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto, string pfno, string esino, string tempemp, string phoneoth, int rptto, string aadharno, string uanno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@title",SqlDbType.VarChar,3),
                            new SqlParameter("@empcode",SqlDbType.VarChar,10),
                            new SqlParameter("@empname",SqlDbType.VarChar,50),
                            new SqlParameter("@fathername",SqlDbType.VarChar,50),
                            new SqlParameter("@spousename",SqlDbType.VarChar,50),
                            new SqlParameter("@dob",SqlDbType.DateTime,8),
                            new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
                            new SqlParameter("@addressc",SqlDbType.VarChar,150),
                            new SqlParameter("@addressp",SqlDbType.VarChar,150),
                            new SqlParameter("@phonehp",SqlDbType.VarChar,15),
                            new SqlParameter("@phoneres",SqlDbType.VarChar,15),
                            new SqlParameter("@email",SqlDbType.VarChar,50),
                             new SqlParameter("@accno",SqlDbType.VarChar,25),
                            new SqlParameter("@panno",SqlDbType.VarChar,20),
                            new SqlParameter("@empphoto",SqlDbType.Image)  ,
                            //new SqlParameter("@sign",SqlDbType.Image),
                            new SqlParameter("@pfno",SqlDbType.VarChar,25),
                            new SqlParameter("@esino",SqlDbType.VarChar,25),
                            new SqlParameter("@tmpemp",SqlDbType.Char,1),
                            new SqlParameter("@phoneoth",SqlDbType.VarChar,15),
                            new SqlParameter("@reportingto",SqlDbType.Int),
                            new SqlParameter("@aadharno",SqlDbType.VarChar,15),
                            new SqlParameter("@UANno",SqlDbType.VarChar,15),
                        };
            objp[0].Value = strTitle;
            objp[1].Value = strEmpCode;
            objp[2].Value = strEmpName;
            objp[3].Value = strFName;
            objp[4].Value = strSPName;
            objp[5].Value = datDob;
            objp[6].Value = strBG;
            objp[7].Value = strCA;
            objp[8].Value = strPA;
            objp[9].Value = strph;
            objp[10].Value = strphres;
            objp[11].Value = strEmail;
            objp[12].Value = accountno;
            objp[13].Value = panno;
            objp[14].Value = empphoto;
            //objp[15].Value = sign;
            objp[15].Value = pfno;
            objp[16].Value = esino;
            objp[17].Value = tempemp;
            objp[18].Value = phoneoth;
            objp[19].Value = rptto;
            objp[20].Value = aadharno;
            objp[21].Value = uanno;
            ExecuteQuery("SPInsEmpPersonal", objp);
        }



        //MUTHU
        public void UpdEmpPersonal(string strTitle, string strEmpCode, string strEmpName, string strFName, string strSPName, DateTime datDob, string strBG, string strCA, string strPA, string strph, string strphres, string strEmail, string accountno, string panno, byte[] empphoto, string pfno, string esino, string tempemp, string phoneoth, int rptto, string aadharno, string uanno)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@title",SqlDbType.VarChar,3),
                            new SqlParameter("@empcode",SqlDbType.VarChar,10),
                            new SqlParameter("@empname",SqlDbType.VarChar,50),
                            new SqlParameter("@fathername",SqlDbType.VarChar,50),
                            new SqlParameter("@spousename",SqlDbType.VarChar,50),
                            new SqlParameter("@dob",SqlDbType.DateTime,8),
                            new SqlParameter("@bloodgroup",SqlDbType.VarChar,5),
                            new SqlParameter("@addressc",SqlDbType.VarChar,150),
                            new SqlParameter("@addressp",SqlDbType.VarChar,150),
                            new SqlParameter("@phonehp",SqlDbType.VarChar,15),
                            new SqlParameter("@phoneres",SqlDbType.VarChar,15),
                            new SqlParameter("@email",SqlDbType.VarChar,50),
                             new SqlParameter("@accno",SqlDbType.VarChar,25),
                            new SqlParameter("@panno",SqlDbType.VarChar,20),
                            new SqlParameter("@empphoto",SqlDbType.Image) ,
                            //new SqlParameter("@sign",SqlDbType.Image),
                            new SqlParameter("@pfno",SqlDbType.VarChar,25),
                            new SqlParameter("@esino",SqlDbType.VarChar,25),
                            new SqlParameter("@tmpemp",SqlDbType.Char,1),
                            new SqlParameter("@phoneoth",SqlDbType.VarChar,15),
                             new SqlParameter("@reportingto",SqlDbType.Int),
                            new SqlParameter("@aadharno",SqlDbType.VarChar,15),
                            new SqlParameter("@UANno",SqlDbType.VarChar,15),
                        };
            objp[0].Value = strTitle;
            objp[1].Value = strEmpCode;
            objp[2].Value = strEmpName;
            objp[3].Value = strFName;
            objp[4].Value = strSPName;
            objp[5].Value = datDob;
            objp[6].Value = strBG;
            objp[7].Value = strCA;
            objp[8].Value = strPA;
            objp[9].Value = strph;
            objp[10].Value = strphres;
            objp[11].Value = strEmail;
            objp[12].Value = accountno;
            objp[13].Value = panno;
            objp[14].Value = empphoto;
            objp[15].Value = pfno;
            objp[16].Value = esino;
            objp[17].Value = tempemp;
            objp[18].Value = phoneoth;
            objp[19].Value = rptto;
            objp[20].Value = aadharno;
            objp[21].Value = uanno;
            ExecuteQuery("SPUpdEmpPersonal", objp);
        }







        public void UpdEmpOfficial(string strEmpCode, string strDivisionName, string strBranch, string strDesignation, string strDept, string strGrade, DateTime datDOJ, string strMailID, string strExtNo, string strPwd, string qualification, string experience, byte[] sign)
        {
            int intPortID;
            intPortID = prtObj.GetNPortid(strBranch);
            SqlParameter[] objp = new SqlParameter[] 
                     {
                         new SqlParameter("@empcode",SqlDbType.VarChar,10),
                         new SqlParameter("@division",SqlDbType.Int,4),
                         new SqlParameter("@branch",SqlDbType.Int,4),
                         new SqlParameter("@desigid",SqlDbType.Int,4),
                         new SqlParameter("@deptid",SqlDbType.Int,4),
                         new SqlParameter("@grade",SqlDbType.VarChar,5),
                         new SqlParameter("@doj",SqlDbType.DateTime,8),
                         //new SqlParameter("@doc",SqlDbType.DateTime,8),
                         new SqlParameter("@offmailid",SqlDbType.VarChar,50),
                         new SqlParameter("@extensionno",SqlDbType.VarChar,5),
                         new SqlParameter("@pwd",SqlDbType.VarChar,50),
                         new SqlParameter("@qualification",SqlDbType.VarChar,10),
                         new SqlParameter("@experience",SqlDbType.VarChar,10),
                         new SqlParameter("@sign",SqlDbType.Image)
                     };
            intDivisionID = GetDivisionId(strDivisionName);
            intDesigID = empObj.GetDesgnid(strDesignation);
            intDeptID = empObj.GetDeptid(strDept);
            objp[0].Value = strEmpCode;
            objp[1].Value = intDivisionID;
            objp[2].Value = intPortID;
            objp[3].Value = intDesigID;
            objp[4].Value = intDeptID;
            objp[5].Value = strGrade;
            objp[6].Value = datDOJ;
            //objp[7].Value = datDOC;
            objp[7].Value = strMailID;
            objp[8].Value = strExtNo;
            objp[9].Value = strPwd;
            objp[10].Value = qualification;
            objp[11].Value = experience;
            objp[12].Value = sign;
            ExecuteQuery("SPUpdEmpOfficial", objp);
        }

        public DataTable GetEmp4Rel(string strEmpCode)
        {
            intEmpID = GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = intEmpID;
            return ExecuteTable("SPSelEmp4Rel", objp);
        }


        //Return Detail PERSONAL / EDUCATION / EXPERIENCE / OFFICIAL / SALARY / COMPENSATION
        //CONTRIBUTION / ALLOWANCES / LOAN AND ADVANCES
        public DataTable selEmpDetails(string strEmpCode,string strDetail)
        {
            intEmpID = GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = intEmpID;
            string strProc = "";
            switch (strDetail)
            {
                case "PER":
                    strProc = "SPSelEmpPersonal";
                    break;
                case "EDU":
                    strProc = "SPSelEmpEducation";
                    break;
                case "EXP":
                    strProc = "SPSelEmpExperience";
                    break;
                case "OFF":
                    strProc = "SPSelEmpOfficial";
                    break;
                case "SAL":
                    strProc = "SPSelEmpSalaryDetails";
                    break;   
                case "COM":
                    strProc = "SPSelEmpAnualCompensation";
                    break;
                case "CON":
                    strProc = "SPSelEmpContribution";
                    break;
                case "ALL":
                    strProc = "SPSelAllowances";
                    break;
                case "LAD":
                    strProc = "SPSelLoanAdvance";
                    break;
            }
            return ExecuteTable(strProc, objp);
        }
        //Salary Packeges New
        //public DataSet SelEmpSalDtls(string strEmpCode)
        //{
        //    intEmpID = GetEmpId(strEmpCode);

        //    SqlParameter[] objp = new SqlParameter[]
        //            { 
        //                new SqlParameter("@empid",SqlDbType.Int)
        //            };
        //    objp[0].Value = intEmpID;
        //    return ExecuteDataSet("SPSelEmpSalDtls", objp);
        //}
        

        public DataTable selEmpDetailsWOROL(string strEmpCode)
        {
            intEmpID = GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = intEmpID;            
            return ExecuteTable("SPSelEmpOfficialWOROL", objp);
        }
        public void InsEmpEducation(string strEmpCode,string strCertificate,string strYop,string strPerCentage)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@empid",SqlDbType.Int),
                                new SqlParameter("@certificate",SqlDbType.VarChar,10),
                                new SqlParameter("@yop",SqlDbType.VarChar,8),
                                new SqlParameter("percentage",SqlDbType.VarChar,5)
                            };

            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = strCertificate;
            objp[2].Value = strYop;
            objp[3].Value = strPerCentage;
            ExecuteQuery("SPInsEmpEducation", objp);
        }
        public void UpdEmpEducation(string strEmpCode, string strOldCertificate,string strNewCeritificate, string strYop, string strPerCentage)
        {
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@empid",SqlDbType.Int),
                                new SqlParameter("@oldcertificate",SqlDbType.VarChar,10),
                                new SqlParameter("@newcertificate",SqlDbType.VarChar,10),
                                new SqlParameter("@yop",SqlDbType.VarChar,8),
                                new SqlParameter("percentage",SqlDbType.VarChar,5)
                            };

            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = strOldCertificate;
            objp[2].Value = strNewCeritificate;
            objp[3].Value = strYop;
            objp[4].Value = strPerCentage;
            ExecuteQuery("SPUpdEmpEducation", objp);           
        }
        public void DelEmpEducation(string strEmpCode, string strCertificate, string strYop, string strPerCentage)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                            {
                                new SqlParameter("@empid",SqlDbType.Int),
                                new SqlParameter("@certificate",SqlDbType.VarChar,10),
                                new SqlParameter("@yop",SqlDbType.VarChar,8),
                                new SqlParameter("percentage",SqlDbType.VarChar,5)
                            };
            objp[0].Value = intEmpID;
            objp[1].Value = strCertificate;
            objp[2].Value = strYop;
            objp[3].Value = strPerCentage;            
            ExecuteQuery("SPDelEmpEducation", objp);
        }
        
        public void InsEmpExperience(string strEmpCode, string strOrgName, string strexfrom, string strexto,string strDesignation)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int),
                            new SqlParameter("@orgname", SqlDbType.VarChar,100),
                            new SqlParameter("@exfrom",SqlDbType.VarChar,8),
                            new SqlParameter("@exto",SqlDbType.VarChar,8),
                            new SqlParameter("@designation",SqlDbType.VarChar,40)
                        };
            intEmpID = GetEmpId(strEmpCode);

            objp[0].Value = intEmpID;
            objp[1].Value = strOrgName;
            objp[2].Value = strexfrom;
            objp[3].Value = strexto;
            objp[4].Value = strDesignation;

            ExecuteQuery("SPInsEmpExperience", objp);
        }
        public void UpdEmpExperience(string strEmpCode, string strOldOrgName,string strNewOrgName, string strexfrom, string strexto, string strDesignation)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int),
                            new SqlParameter("@oldorgname", SqlDbType.VarChar,100),
                            new SqlParameter("@neworgname",SqlDbType.VarChar,100),
                            new SqlParameter("expfrom",SqlDbType.VarChar,8),
                            new SqlParameter("expto",SqlDbType.VarChar,8),
                            new SqlParameter("designation",SqlDbType.VarChar,40)
                        };
            intEmpID = GetEmpId(strEmpCode);

            objp[0].Value = intEmpID;
            objp[1].Value = strOldOrgName;
            objp[2].Value = strNewOrgName;
            objp[3].Value = strexfrom;
            objp[4].Value = strexto;
            objp[5].Value = strDesignation;

            ExecuteQuery("SPUpdEmpExperience", objp);
           
        }
        public void DelEmpExperience(string strEmpCode, string strOrgName, string strexfrom, string strexto, string strDesignation)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int),
                            new SqlParameter("@orgname", SqlDbType.VarChar,100),
                            new SqlParameter("exfrom",SqlDbType.VarChar,8),
                            new SqlParameter("exto",SqlDbType.VarChar,8),
                            new SqlParameter("designation",SqlDbType.VarChar,40)
                        };
            intEmpID = GetEmpId(strEmpCode);

            objp[0].Value = intEmpID;
            objp[1].Value = strOrgName;
            objp[2].Value = strexfrom;
            objp[3].Value = strexto;
            objp[4].Value = strDesignation;
            ExecuteQuery("SPDelEmpExperience", objp);            
        }
        
        //public void UpdEmpOfficial(string strEmpCode, string strDivisionName, string strBranch, string strDesignation, string strDept, string strGrade, DateTime datDOJ, string strMailID, string strExtNo,string strPwd,string qualification,string experience,byte[] sign)
        //{
        //    int intPortID;
        //    intPortID = prtObj.GetNPortid(strBranch);
        //    SqlParameter[] objp = new SqlParameter[] 
        //             {
        //                 new SqlParameter("@empcode",SqlDbType.VarChar,10),
        //                 new SqlParameter("@division",SqlDbType.Int,4),
        //                 new SqlParameter("@branch",SqlDbType.Int,4),
        //                 new SqlParameter("@desigid",SqlDbType.Int,4),
        //                 new SqlParameter("@deptid",SqlDbType.Int,4),
        //                 new SqlParameter("@grade",SqlDbType.VarChar,5),
        //                 new SqlParameter("@doj",SqlDbType.DateTime,8),
        //                 //new SqlParameter("@doc",SqlDbType.DateTime,8),
        //                 new SqlParameter("@offmailid",SqlDbType.VarChar,50),
        //                 new SqlParameter("@extensionno",SqlDbType.VarChar,5),
        //                 new SqlParameter("@pwd",SqlDbType.VarChar,10),
        //                 new SqlParameter("@qualification",SqlDbType.VarChar,10),
        //                 new SqlParameter("@experience",SqlDbType.VarChar,10),
        //                 new SqlParameter("@sign",SqlDbType.Image)
        //             };
        //    intDivisionID = GetDivisionId(strDivisionName);
        //    intDesigID = empObj.GetDesgnid(strDesignation);
        //    intDeptID = empObj.GetDeptid(strDept);
        //    objp[0].Value = strEmpCode;
        //    objp[1].Value = intDivisionID;
        //    objp[2].Value = intPortID;
        //    objp[3].Value = intDesigID;
        //    objp[4].Value = intDeptID;
        //    objp[5].Value = strGrade;
        //    objp[6].Value = datDOJ;
        //    //objp[7].Value = datDOC;
        //    objp[7].Value = strMailID;
        //    objp[8].Value = strExtNo;
        //    objp[9].Value = strPwd;
        //    objp[10].Value = qualification;
        //    objp[11].Value = experience;
        //    objp[12].Value = sign;
        //    ExecuteQuery("SPUpdEmpOfficial", objp);
        //}

        public void InsEmpSalary(string strEmpCode, double dblBasic, double dblHRA, double dblSAllowence, double dblLAllowence, double dblConveyance, double dblOthers, DateTime datSfrom, DateTime datSto, double loyalty, double entertainallow, double driverallow, double dblsalmed)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@basic",SqlDbType.Money,8),
                        new SqlParameter("@hra",SqlDbType.Money,8),
                        new SqlParameter("@sallowence",SqlDbType.Money,8),
                        new SqlParameter("@lallowence",SqlDbType.Money,8),
                        new SqlParameter("@conveyance",SqlDbType.Money,8),
                        new SqlParameter("@others",SqlDbType.Money,8),
                        new SqlParameter("@sfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@sto",SqlDbType.DateTime,8),
                        new SqlParameter("@loyalty",SqlDbType.Money,8),
                        new SqlParameter("@entertainallow",SqlDbType.Money,8),
                        new SqlParameter("@driverallow",SqlDbType.Money,8),
                         new SqlParameter("@medical",SqlDbType.Money,8)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = dblBasic;
            objp[2].Value = dblHRA;
            objp[3].Value = dblSAllowence;
            objp[4].Value = dblLAllowence;
            objp[5].Value = dblConveyance;
            objp[6].Value = dblOthers;
            objp[7].Value = datSfrom;
            objp[8].Value = datSto;
            objp[9].Value = loyalty;
            objp[10].Value = entertainallow;
            objp[11].Value = driverallow;
            objp[12].Value = dblsalmed ;
            ExecuteQuery("SPInsEmpSalaryDetails", objp);
        }
        //public void UpdEmpSalary(string strEmpCode, double dblBasic, double dblHRA, double dblSAllowence, double dblLAllowence, double dblConveyance, double dblOthers, DateTime datSfrom, DateTime datSto, double loyalty, double entertainallow, double driverallow)
        //{
        //    intEmpID = GetEmpId(strEmpCode);
        //    SqlParameter[] objp = new SqlParameter[] 
        //            {
        //                new SqlParameter("@empid",SqlDbType.Int),
        //                new SqlParameter("@basic",SqlDbType.Money,8),
        //                new SqlParameter("@hra",SqlDbType.Money,8),
        //                new SqlParameter("@sallowence",SqlDbType.Money,8),
        //                new SqlParameter("@lallowence",SqlDbType.Money,8),
        //                new SqlParameter("@conveyance",SqlDbType.Money,8),
        //                new SqlParameter("@others",SqlDbType.Money,8),
        //                new SqlParameter("@sfrom",SqlDbType.DateTime,8),
        //                new SqlParameter("@sto",SqlDbType.DateTime,8),
        //                new SqlParameter("@loyalty",SqlDbType.Money,8),
        //                new SqlParameter("@entertainallow",SqlDbType.Money,8),
        //                new SqlParameter("@driverallow",SqlDbType.Money,8)
        //            };
        //    objp[0].Value = intEmpID;
        //    objp[1].Value = dblBasic;
        //    objp[2].Value = dblHRA;
        //    objp[3].Value = dblSAllowence;
        //    objp[4].Value = dblLAllowence;
        //    objp[5].Value = dblConveyance;
        //    objp[6].Value = dblOthers;
        //    objp[7].Value = datSfrom;
        //    objp[8].Value = datSto;
        //    objp[9].Value = loyalty;
        //    objp[10].Value = entertainallow;
        //    objp[11].Value = driverallow;
        //    ExecuteQuery("SPUpdEmpSalaryDetails", objp);            
        //}


        public void UpdEmpSalary(string strEmpCode, double dblBasic, double dblHRA, double dblSAllowence, double dblLAllowence, double dblConveyance, double dblOthers, DateTime datSfrom, DateTime datSto, double loyalty, double entertainallow, double driverallow, double dblsalmed, DateTime datEfrom, DateTime datArrtkOn, int chkArr)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@basic",SqlDbType.Money,8),
                        new SqlParameter("@hra",SqlDbType.Money,8),
                        new SqlParameter("@sallowence",SqlDbType.Money,8),
                        new SqlParameter("@lallowence",SqlDbType.Money,8),
                        new SqlParameter("@conveyance",SqlDbType.Money,8),
                        new SqlParameter("@others",SqlDbType.Money,8),
                        new SqlParameter("@sfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@sto",SqlDbType.DateTime,8),
                        new SqlParameter("@loyalty",SqlDbType.Money,8),
                        new SqlParameter("@entertainallow",SqlDbType.Money,8),
                        new SqlParameter("@driverallow",SqlDbType.Money,8),
                         new SqlParameter("@medical",SqlDbType.Money,8),
                         //Newly Inserted Three Fields
                        new SqlParameter ("@efrom",SqlDbType.DateTime ,8),
                        new SqlParameter ("@arrtakeon",SqlDbType .DateTime ,8),
                        new SqlParameter ("@archeck",SqlDbType .Int)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = dblBasic;
            objp[2].Value = dblHRA;
            objp[3].Value = dblSAllowence;
            objp[4].Value = dblLAllowence;
            objp[5].Value = dblConveyance;
            objp[6].Value = dblOthers;
            objp[7].Value = datSfrom;
            objp[8].Value = datSto;
            objp[9].Value = loyalty;
            objp[10].Value = entertainallow;
            objp[11].Value = driverallow;
            objp[12].Value = dblsalmed ;
            //Newly Added Field
            objp[13].Value = datEfrom;
            objp[14].Value = datArrtkOn;
            objp[15].Value = chkArr;
            ExecuteQuery("SPUpdEmpSalaryDetails", objp);
        }
        // HRM Salary Packages New Start
        public DataTable SelEmpSalDtls(string strEmpCode)
        {
            intEmpID = GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = intEmpID;
            return ExecuteTable("SPSelEmpSalDtls", objp);
        }

        public void InsEmpSalaryNew(string strEmpCode, double dblBasic, double dblHRA, double dblSAllowence, double dblLAllowence, double dblConveyance, double dblOthers, DateTime datSfrom, DateTime datSto, double loyalty, double entertainallow, double driverallow, double dblsalmed, double gross)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@basic",SqlDbType.Money,8),
                        new SqlParameter("@hra",SqlDbType.Money,8),
                        new SqlParameter("@sallowence",SqlDbType.Money,8),
                        new SqlParameter("@lallowence",SqlDbType.Money,8),
                        new SqlParameter("@conveyance",SqlDbType.Money,8),
                        new SqlParameter("@others",SqlDbType.Money,8),
                        new SqlParameter("@sfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@sto",SqlDbType.DateTime,8),
                        new SqlParameter("@loyalty",SqlDbType.Money,8),
                        new SqlParameter("@entertainallow",SqlDbType.Money,8),
                        new SqlParameter("@driverallow",SqlDbType.Money,8),
                          new SqlParameter("@medical",SqlDbType.Money,8),
                        new SqlParameter("@gross",SqlDbType.Money,8)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = dblBasic;
            objp[2].Value = dblHRA;
            objp[3].Value = dblSAllowence;
            objp[4].Value = dblLAllowence;
            objp[5].Value = dblConveyance;
            objp[6].Value = dblOthers;
            objp[7].Value = datSfrom;
            objp[8].Value = datSto;
            objp[9].Value = loyalty;
            objp[10].Value = entertainallow;
            objp[11].Value = driverallow;
            objp[12].Value = dblsalmed ;
            objp[13].Value = gross;
            ExecuteQuery("SPInsEmpSalaryDetailsNew", objp);
        }
        public void UpdEmpSalaryNew(string strEmpCode, double dblBasic, double dblHRA, double dblSAllowence, double dblLAllowence, double dblConveyance, double dblOthers, DateTime datSfrom, DateTime datSto, double loyalty, double entertainallow, double driverallow, double dblsalmed, double gross)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@basic",SqlDbType.Money,8),
                        new SqlParameter("@hra",SqlDbType.Money,8),
                        new SqlParameter("@sallowence",SqlDbType.Money,8),
                        new SqlParameter("@lallowence",SqlDbType.Money,8),
                        new SqlParameter("@conveyance",SqlDbType.Money,8),
                        new SqlParameter("@others",SqlDbType.Money,8),
                        new SqlParameter("@sfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@sto",SqlDbType.DateTime,8),
                        new SqlParameter("@loyalty",SqlDbType.Money,8),
                        new SqlParameter("@entertainallow",SqlDbType.Money,8),
                        new SqlParameter("@driverallow",SqlDbType.Money,8),
                          new SqlParameter("@medical",SqlDbType.Money,8),
                         new SqlParameter("@gross",SqlDbType.Money,8)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = dblBasic;
            objp[2].Value = dblHRA;
            objp[3].Value = dblSAllowence;
            objp[4].Value = dblLAllowence;
            objp[5].Value = dblConveyance;
            objp[6].Value = dblOthers;
            objp[7].Value = datSfrom;
            objp[8].Value = datSto;
            objp[9].Value = loyalty;
            objp[10].Value = entertainallow;
            objp[11].Value = driverallow;
            objp[12].Value = dblsalmed ;
            objp[13].Value = gross;
            ExecuteQuery("SPUpdEmpSalaryDetailsNew", objp);
        }

        public DataTable GetEADA4salPkg(string gname, DateTime efrom, DateTime eto)
        {
            SqlParameter[] objp = new SqlParameter[] {
                
                new SqlParameter("@gname",SqlDbType.VarChar,10),
            new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
                new SqlParameter ("@eto",SqlDbType .DateTime ,10)
            };

            objp[0].Value = gname;
            objp[1].Value = efrom;
            objp[2].Value = eto;
            return ExecuteTable("SPGetEADA4salPkg", objp);
        }

        public int GetSalDtls4Ins(string strEmpCode, DateTime sfrom, DateTime sto)
        {
            //bool existance, a;
           // int i;
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] {
                           new SqlParameter("@empid",SqlDbType.Int),
            new SqlParameter ("@efrom",SqlDbType .DateTime ,10),
                new SqlParameter ("@eto",SqlDbType .DateTime ,10),
                            new SqlParameter("@bit", SqlDbType.Int,4) 
                                                        
        };
            objp[0].Value = intEmpID;
            objp[1].Value = sfrom;
            objp[2].Value = sto;
            objp[3].Direction = ParameterDirection.Output;
            return ExecuteQuery("spGetSalDtls4Ins", objp, "@bit");
            //return ExecuteTable("sp_selMasterUserLogin", objp);
            //if (i==1)
            //    existance = true;
            //else
            //    existance = false;

            //return existance;


        }
        // HRM Salary Packages New End


        public void DelEmpSalary(string strEmpCode,DateTime datSfrom, DateTime datSto)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@sfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@sto",SqlDbType.DateTime,8)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = datSfrom;
            objp[2].Value = datSto;
            ExecuteQuery("SPDelEmpSalaryDetails", objp);            
        }
        
        
        public void InsEmpAnualCompensation(string strEmpCode, double dblLTA, double dblMedical, double dblBonus, double dblOthers, DateTime datAfrom, DateTime datAto)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    { 
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@lta",SqlDbType.Money,8),
                        new SqlParameter("@medical",SqlDbType.Money,8),
                        new SqlParameter("@bonus",SqlDbType.Money,8),
                        new SqlParameter("@others",SqlDbType.Money,8),
                        new SqlParameter("@acfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@acto",SqlDbType.DateTime,8)
                    };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = dblLTA;
            objp[2].Value = dblMedical;
            objp[3].Value = dblBonus;
            objp[4].Value = dblOthers;
            objp[5].Value = datAfrom;
            objp[6].Value = datAto;
            ExecuteQuery("SPInsEmpAnualCompensation", objp);            
        }
        public void UpdEmpAnualCompensation(string strEmpCode, double dblLTA, double dblMedical, double dblBonus, double dblOthers, DateTime datAfrom, DateTime datAto)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    { 
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@lta",SqlDbType.Money,8),
                        new SqlParameter("@medical",SqlDbType.Money,8),
                        new SqlParameter("@bonus",SqlDbType.Money,8),
                        new SqlParameter("@others",SqlDbType.Money,8),
                        new SqlParameter("@acfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@acto",SqlDbType.DateTime,8)
                    };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = dblLTA;
            objp[2].Value = dblMedical;
            objp[3].Value = dblBonus;
            objp[4].Value = dblOthers;
            objp[5].Value = datAfrom;
            objp[6].Value = datAto;
            ExecuteQuery("SPUpdEmpAnualCompensation", objp);             
        }
        public void DelEmpACompensation(string strEmpCode, DateTime datAComfrom, DateTime datAComto)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    { 
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@acfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@acto",SqlDbType.DateTime,8)
                    };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = datAComfrom;
            objp[2].Value = datAComto;
            ExecuteQuery("SPDelEmpAComDetails", objp);            
        }
        
        public void InsEmpContribution(string strEmpCode, double dblESI, double dblPF, DateTime datCfrom, DateTime datCto)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    { 
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@pf",SqlDbType.Money,8),
                        new SqlParameter("@esi",SqlDbType.Money,8),
                        new SqlParameter("@cfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@cto",SqlDbType.DateTime,8)
                    };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = dblPF;
            objp[2].Value = dblESI;
            objp[3].Value = datCfrom;
            objp[4].Value = datCto;
            ExecuteQuery("SPInsEmpContribution",objp);            
        }
        public void UpdEmpContribution(string strEmpCode, double dblESI, double dblPF, DateTime datCfrom, DateTime datCto)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    { 
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@pf",SqlDbType.Money,8),
                        new SqlParameter("@esi",SqlDbType.Money,8),
                        new SqlParameter("@cfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@cto",SqlDbType.DateTime,8)
                    };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = dblPF;
            objp[2].Value = dblESI;
            objp[3].Value = datCfrom;
            objp[4].Value = datCto;
            ExecuteQuery("SPUpdEmpContribution", objp);            
        }
        public void DelEmpContribution(string strEmpCode, DateTime datCfrom, DateTime datCto)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    { 
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@cfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@cto",SqlDbType.DateTime,8)
                    };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = datCfrom;
            objp[2].Value = datCto;
            ExecuteQuery("SPDelEmpContribution", objp);            
        }

        public void InsEmpAllowances(string strEmpCode, double dblPetrol, double dblMobile, double dblPhoner, double dblDatacard, double dblOthers, DateTime datFrom, DateTime datTo, double vma, double driverwages, double mc, double mcamt)
        {
            SqlParameter[] objp = new SqlParameter[] 
                   {    
                       new SqlParameter("@empid",SqlDbType.Int),
                       new SqlParameter("@petrol",SqlDbType.Money,8),
                       new SqlParameter("@mobile",SqlDbType.Money,8),
                       new SqlParameter("@phoner",SqlDbType.Money,8),
                       new SqlParameter("@datacard",SqlDbType.Money,8),
                       new SqlParameter("@others",SqlDbType.Money,8),
                       new SqlParameter("@afrom",SqlDbType.DateTime,8),
                       new SqlParameter("@ato",SqlDbType.DateTime,8),
                       new SqlParameter("@vma",SqlDbType.Money,8),
                       new SqlParameter("@driverwages",SqlDbType.Money,8),
                        new SqlParameter("@mc",SqlDbType.Money,8),
                        new SqlParameter("@mcamt",SqlDbType.Money,8)
                   };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = dblPetrol;
            objp[2].Value = dblMobile;
            objp[3].Value = dblPhoner;
            objp[4].Value = dblDatacard;
            objp[5].Value = dblOthers;
            objp[6].Value = datFrom;
            objp[7].Value = datTo;
            objp[8].Value = vma;
            objp[9].Value = driverwages;
            objp[10].Value = mc;
            objp[11].Value = mcamt;
            ExecuteQuery("SPInsAllowances",objp);            
        }
        public void UpdEmpAllowances(string strEmpCode, double dblPetrol, double dblMobile, double dblPhoner, double dblDatacard, double dblOthers, DateTime datFrom, DateTime datTo, double vma, double driverwages, double mc, double mcamt)
        {
            SqlParameter[] objp = new SqlParameter[] 
                   {    
                       new SqlParameter("@empid",SqlDbType.Int),
                       new SqlParameter("@petrol",SqlDbType.Money,8),
                       new SqlParameter("@mobile",SqlDbType.Money,8),
                       new SqlParameter("@phoner",SqlDbType.Money,8),
                       new SqlParameter("@datacard",SqlDbType.Money,8),
                       new SqlParameter("@others",SqlDbType.Money,8),
                       new SqlParameter("@afrom",SqlDbType.DateTime,8),
                       new SqlParameter("@ato",SqlDbType.DateTime,8),
                       new SqlParameter("@vma",SqlDbType.Money,8),
                       new SqlParameter("@driverwages",SqlDbType.Money,8),
                        new SqlParameter("@mc",SqlDbType.Money,8),
                       new SqlParameter("@mcamt",SqlDbType.Money,8)
                   };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = dblPetrol;
            objp[2].Value = dblMobile;
            objp[3].Value = dblPhoner;
            objp[4].Value = dblDatacard;
            objp[5].Value = dblOthers;
            objp[6].Value = datFrom;
            objp[7].Value = datTo;
            objp[8].Value = vma;
            objp[9].Value = driverwages;
            objp[10].Value = mc;
            objp[11].Value = mcamt;
            ExecuteQuery("SPUpdAllowances",objp);            
        }
        
        public void DelEmpAllowances(string strEmpCode,DateTime datFrom,DateTime datTo)
        {
            SqlParameter[] objp = new SqlParameter[] 
                   {    
                       new SqlParameter("@empid",SqlDbType.Int),
                       new SqlParameter("@afrom",SqlDbType.DateTime,8),
                       new SqlParameter("@ato",SqlDbType.DateTime,8)
                   };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = datFrom;
            objp[2].Value = datTo;

            ExecuteQuery("SPDelAllowances", objp);            
        }

        //===============finish
        public void InsEmpLoansAdvance(string strEmpCode, double dblLAmt, int intTenure, DateTime datTakenOn, string strRemarks)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@loanamount",SqlDbType.Money,8),
                        new SqlParameter("@tenure",SqlDbType.Int,4),
                        new SqlParameter("@takenon",SqlDbType.DateTime,8),
                        new SqlParameter("@remarks",SqlDbType.VarChar,25)
                    };
            intEmpID = GetEmpId(strEmpCode);

            objp[0].Value = intEmpID;
            objp[1].Value = dblLAmt;
            objp[2].Value = intTenure;
            objp[3].Value = datTakenOn;
            objp[4].Value = strRemarks;

            ExecuteQuery("SPInsLoansAdvance", objp);
            
        }
        //public void UpdEmpLoansAdvance(string strEmpCode, double dblLAmt, int intTenure, DateTime datTakenOn)
        //{
        //    SqlParameter[] objp = new SqlParameter[] 
        //            {
        //                new SqlParameter("@empid",SqlDbType.Int),
        //                new SqlParameter("@loanamount",SqlDbType.Money,8),
        //                new SqlParameter("@tenure",SqlDbType.Int,4),
        //                new SqlParameter("@takenon",SqlDbType.DateTime,8)
        //            };
        //    intEmpID = GetEmpId(strEmpCode);

        //    objp[0].Value = intEmpID;
        //    objp[1].Value = dblLAmt;
        //    objp[2].Value = intTenure;
        //    objp[3].Value = datTakenOn;
       

        //    ExecuteQuery("SPUpdLoansAdvance", objp);            
        //}
        public void UpdEmpLoansAdvance(string strEmpCode, double dblLAmt, int intTenure, DateTime datTakenOn, string strRemarks, string str_LoanStatus)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@loanamount",SqlDbType.Money,8),
                        new SqlParameter("@tenure",SqlDbType.Int,4),
                        new SqlParameter("@takenon",SqlDbType.DateTime,8),
                        new SqlParameter("@remarks",SqlDbType.VarChar,25),
                         new SqlParameter("@LoanStatus",SqlDbType.VarChar,25)
                    };
            intEmpID = GetEmpId(strEmpCode);

            objp[0].Value = intEmpID;
            objp[1].Value = dblLAmt;
            objp[2].Value = intTenure;
            objp[3].Value = datTakenOn;
            objp[4].Value = strRemarks;
            objp[5].Value = str_LoanStatus;
            ExecuteQuery("SPUpdLoansAdvance", objp);
        }
        public void DelLoansAdvance(string strEmpCode,DateTime datTakenOn, string strRemarks)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@takenon",SqlDbType.DateTime,8),
                        new SqlParameter("@remarks",SqlDbType.VarChar,25)
                    };
            intEmpID = GetEmpId(strEmpCode);

            objp[0].Value = intEmpID;
            objp[1].Value = datTakenOn;
            objp[2].Value = strRemarks;

            ExecuteQuery("SPDelLoanAdvance", objp);
            
        }
        
       
        public int GetEmpId(string strEmpCode)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empcode",SqlDbType.VarChar,10)
                        };
            objp[0].Value = strEmpCode;
            int intResult = 0;
            Dt = ExecuteTable("SPEmpId", objp);
            if (Dt.Rows.Count > 0)
            {


                intResult =int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }
        public int GetDivisionId(string strDivision)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.VarChar,100)
                        };
            objp[0].Value = strDivision;
            Dt=ExecuteTable("SPDivisionID", objp);
            int intResult = 0;
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }
        public int GetBranchId(int intDivision, string strBranchName)
        {
            int portid = GetBranchId(strBranchName);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.Int,4),
                            new SqlParameter("@portid",SqlDbType.Int,4)
                        };
            objp[0].Value = intDivision;
            objp[1].Value = portid;
            int intResult = 0;
            Dt = ExecuteTable("SPBranchID", objp);
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }
        public int GetBranchId(string strBranchName)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {                           
                            new SqlParameter("@branchname",SqlDbType.VarChar,100)
                        };
            objp[0].Value = strBranchName;
            int intResult = 0;
            Dt = ExecuteTable("SPGetBranchID", objp);
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }
        public DataTable selBranchList(string strDivision)
        {
            intDivisionID = GetDivisionId(strDivision);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.Int,4)
                        };
            objp[0].Value = intDivisionID;
            return ExecuteTable("SPBranchListinDivision", objp);            
        }
      
        //Return All Division Names
        public DataTable GetDivision()
        {
            return ExecuteTable("SPSelAllDivision");
        }
        public DataTable GetDivision(string division)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.VarChar,2)
                        };
            objp[0].Value = division;
            return ExecuteTable("SPSelAllDivision", objp);
        }
        public DataTable GetDivisionhrm(string division)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.VarChar,2)
                        };
            objp[0].Value = division;
            return ExecuteTable("SPSelAllDivision", objp);
        }
        public void UpdDOC(string strEmpCode, DateTime datDOC)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@doc",SqlDbType.DateTime,8)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = datDOC;
            ExecuteQuery("SPUpdEmpDOC", objp);
        }
        public void UpdReleave(string strEmpCode, DateTime datDOL, int intROL)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@dol",SqlDbType.DateTime,8),
                        new SqlParameter("@rol",SqlDbType.TinyInt,1)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = datDOL;
            objp[2].Value = intROL;
            ExecuteQuery("SPUpdEmpROL", objp);
        }
        //public void ChangeEmpPasswd(string pwd, string empcode)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pwd", SqlDbType.VarChar, 10),
        //                                              new SqlParameter("@empcode", SqlDbType.VarChar, 10) };
        //    objp[0].Value = pwd;
        //    objp[1].Value = empcode;
        //    ExecuteQuery("SPChangeEmpPassword", objp);
        //}

        public void ChangeEmpPasswd(string pwd, string empcode, DateTime updatedon, string ipaddress)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@pwd", SqlDbType.VarChar, 50),
                                                      new SqlParameter("@empcode", SqlDbType.VarChar, 10) ,
             new SqlParameter("@updatedon", SqlDbType.SmallDateTime,8),
             new SqlParameter("@ipaddress", SqlDbType.VarChar, 15) ,};
            objp[0].Value = pwd;
            objp[1].Value = empcode;
            objp[2].Value = updatedon;
            objp[3].Value = ipaddress;

            ExecuteQuery("SPChangeEmpPassword", objp);
        }

        public DataTable GetDOCDetail(string strEmpCode)
        {
            intEmpID = GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = intEmpID;
            return ExecuteTable("SPSelEmpDOC",objp);
        }
        public DataTable GetROLDetail(string strEmpCode)
        {
            intEmpID = GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = intEmpID;
            return ExecuteTable("SPSelEmpROL",objp);
        }

        public DataTable GetLikeEmpName(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = empname;
            return ExecuteTable("SPLikeEmpNameHR", objp);
        }

        public void UpdLiveUser(string strEmpCode)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,10)};
            objp[0].Value = strEmpCode;
            ExecuteQuery("SPLiveUserUpd", objp);
        }
        public void UpdLiveUserCan(string strEmpCode)
        {
            SqlParameter[] objp = new SqlParameter[] 
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,10)};
            objp[0].Value = strEmpCode;
            ExecuteQuery("SPLiveUserUpdCan", objp);
        }
        public DataTable GetLiveUser()
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {};
            return ExecuteTable("SPSelLiveUser", objp);
        }

        public string GetMailAdd(int empid)
        {
            string mailadd = "";
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int)};
            objp[0].Value = empid;
            Dt = ExecuteTable("SPGetEmpMail", objp);
            if (Dt.Rows.Count > 0)
            {
                mailadd = Dt.Rows[0].ItemArray[0].ToString();
            }
            return mailadd;
        }
        public DataTable GetBranchandDivision(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branchid",SqlDbType.TinyInt,1)
                        };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetBranchandDivision", objp);
        }

        public DataTable SelForPermission(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empcode", SqlDbType.VarChar, 10) };
            objp[0].Value = empcode;
            return ExecuteTable("SPSelForHRPermission", objp);
        }

        public void InsPermissions(int empid, DateTime permissiondate, int minutes, char fnan)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@permissiondate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@minutes", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fnan", SqlDbType.Char, 1) };
            objp[0].Value = empid;
            objp[1].Value = permissiondate;
            objp[2].Value = minutes;
            objp[3].Value = fnan;
            ExecuteQuery("SPInsHRPermission", objp);
        }

        public DataTable SelHRPermissDtls(int empid, DateTime HRDate)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@hrdate", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = empid;
            objp[1].Value = HRDate;
            return ExecuteTable("SPSelHRPermissDtls", objp);
        }

        public void UpdPermissions(int empid, DateTime permissiondate, int minutes, char fnan)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@grddate", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@minutes", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@fnan", SqlDbType.Char, 1) };
            objp[0].Value = empid;
            objp[1].Value = permissiondate;
            objp[2].Value = minutes;
            objp[3].Value = fnan;
            ExecuteQuery("SPUpdHRPermission", objp);
        }

        //dinesh 

        public void DelPermissions(int empid, DateTime permissiondate, char fnan)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,4),
                                                       new SqlParameter("@grddate", SqlDbType.SmallDateTime, 4),
                                                        new SqlParameter("@fnan", SqlDbType.Char, 1)};

            objp[0].Value = empid;
            objp[1].Value = permissiondate;
            objp[2].Value = fnan;
           
            ExecuteQuery("SPDelHRPermission", objp);
        }

        public DataTable SelForEmpLeaveDetails(string intempid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@intempid", SqlDbType.Int, 4) };
            objp[0].Value = intempid;
            return ExecuteTable("SPSelEmpLeaveDtls", objp);
        }

        public DataTable SELPermissiondtls(int intempid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@intempid", SqlDbType.Int, 4) };
            objp[0].Value = intempid;
            return ExecuteTable("SPSelHRPer", objp);

        }
        public DataTable GetBranchandDivisionempid(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4)
                        };
            objp[0].Value = empid;
            return ExecuteTable("SPGetBranchandDivisionempid", objp);
        }

        public DataTable GetMailId4BranchManager(string division,string branch)
        {
            int divisonid, branchid = 0;
            divisonid = GetDivisionId(division);
            branchid = prtObj.GetNPortid(branch);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.TinyInt,1),
                            new SqlParameter("@branch",SqlDbType.Int,4)
                        };
            objp[0].Value = divisonid;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetMailId4BranchManager", objp);
        }


        public void InsEmpClaim(int empid, char claimtype, double claimamt, DateTime claimdate, int clchk, DateTime seton)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@claimtype", SqlDbType.Char, 1),
                                                       new SqlParameter("@claimamt", SqlDbType.Money, 8),
                                                       new SqlParameter("@claimdate", SqlDbType.DateTime, 8),
             new SqlParameter("@chck", SqlDbType.Int , 32),
            new SqlParameter("@seton", SqlDbType.DateTime, 8)
            };
            objp[0].Value = empid;
            objp[1].Value = claimtype;
            objp[2].Value = claimamt;
            objp[3].Value = claimdate;
            objp[4].Value = clchk;
            objp[5].Value = seton;
            ExecuteQuery("SPInsEmpClaimDtls", objp);
        }
        public void UpdEmpClaim(int empid, char claimtype, double claimamt, DateTime claimdate, double oldcamt, int clchk, DateTime seton)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@claimtype", SqlDbType.Char, 1),
                                                       new SqlParameter("@claimamt", SqlDbType.Money, 8),
                                                       new SqlParameter("@claimdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@oldcamt", SqlDbType.Money, 8),
                 new SqlParameter("@clchk", SqlDbType.Int , 8),
               new SqlParameter("@seton", SqlDbType.DateTime, 8)
            };
            objp[0].Value = empid;
            objp[1].Value = claimtype;
            objp[2].Value = claimamt;
            objp[3].Value = claimdate;
            objp[4].Value = oldcamt;
            objp[5].Value = clchk;
            objp[6].Value = seton;
            ExecuteQuery("SPUpdHRClaim", objp);
        }
        /*Dinesh*/
        //public void DelEmpClaim(int empid, char claimtype, double oldcamt)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
        //                                               new SqlParameter("@claimtype", SqlDbType.Char, 1),
        //                                                new SqlParameter("@oldcamt", SqlDbType.Money, 8)};
        //    objp[0].Value = empid;
        //    objp[1].Value = claimtype;
        //    objp[2].Value = oldcamt;
        //    ExecuteQuery("SPDelHRClaim", objp);
        //}

         public void DelEmpClaim(int empid, char claimtype, double oldcamt, DateTime claimon, DateTime seton)
          {
              SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                         new SqlParameter("@claimtype", SqlDbType.Char, 1),
                                                          new SqlParameter("@oldcamt", SqlDbType.Money, 8),
              new SqlParameter("@claimon", SqlDbType.DateTime, 8),
              new SqlParameter("@seton", SqlDbType.DateTime, 8)};
              objp[0].Value = empid;
              objp[1].Value = claimtype;
              objp[2].Value = oldcamt;
              objp[3].Value = claimon;
              objp[4].Value = seton;
              ExecuteQuery("SPDelHRClaim", objp);
          }
      
        public DataTable GetEmpDetailsforClaim(int employeeid)
        {
            
            SqlParameter[] objp = new SqlParameter[] 
                        {
                          new SqlParameter("@employeeid",SqlDbType.Int)
                        };
            objp[0].Value = employeeid;
            return ExecuteTable("SPSelEmpDtlsForClaim", objp);
        }

        public DataTable SelDesigid4Updmail(string strEmpCode)
        {


            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@empcode",SqlDbType.VarChar,10)
                                                        };
            objp[0].Value = strEmpCode;
            return ExecuteTable("SPSeldesigid4updmail", objp);
        }
        public DataTable GetLikeEmpNameBranchwise(int Division, int  branch, string empname)
        {
                  SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branch",SqlDbType.Int,4),
                            new SqlParameter("@division",SqlDbType.Int,4),
                            new SqlParameter("@empname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = branch;
            objp[1].Value = Division;
            objp[2].Value = empname;
            return ExecuteTable("GetLikeEmpNameBranchwise", objp);
        }
        public DataTable CheckEmpSign(int employeeid)
        {

            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@employeeid",SqlDbType.Int ,10)
            };
            objp[0].Value = employeeid;
            return ExecuteTable("SPCheckEmpSign", objp);
        }
        public DataTable SelForPermission4profile(string empcode, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@empcode", SqlDbType.VarChar, 10),
                new SqlParameter("@divisionid", SqlDbType.TinyInt , 1) 
                
            
            };
            objp[0].Value = empcode;
            objp[1].Value = divisionid;

            return ExecuteTable("SPSelForHRPermission4profile", objp);
        }
        //public DataTable GetEmp4Rel(string strEmpCode)
        //{
        //    intEmpID = GetEmpId(strEmpCode);

        //    SqlParameter[] objp = new SqlParameter[]
        //            { 
        //                new SqlParameter("@empid",SqlDbType.Int)
        //            };
        //    objp[0].Value = intEmpID;
        //    return ExecuteTable("SPSelEmp4Rel", objp);
        //}

        public DataTable selEmployDetails(string strEmpCode, DateTime datSfrom, DateTime datSto)
        {
            intEmpID = GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int),
                         new SqlParameter("@sfrom",SqlDbType.DateTime,8),
                        new SqlParameter("@sto",SqlDbType.DateTime,8)
                    };
            objp[0].Value = intEmpID;
            objp[1].Value = datSfrom;
            objp[2].Value = datSto;
            return ExecuteTable("SPselEmploySalDtls", objp);
        }
        public void UpdArrear(string strEmpCode, DateTime datEfrom, DateTime datArrtkOn, int chkArr)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
                        {
                             new SqlParameter("@empid",SqlDbType.Int),
            new SqlParameter ("@efrom",SqlDbType.DateTime ,8),
            new SqlParameter ("@arrtakeon",SqlDbType .DateTime ,8),
            new SqlParameter ("@archeck",SqlDbType .Int)
                        };
            objp[0].Value = intEmpID;
            objp[1].Value = datEfrom;
            objp[2].Value = datArrtkOn;
            objp[3].Value = chkArr;

            ExecuteQuery("SPInsArrear", objp);

        }
        //4 medical

        public double getMedicalamt(string strEmpCode, DateTime dtfrm)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@empid",SqlDbType.Int),
            new SqlParameter ("@dtfrm",SqlDbType.DateTime ,8),
               
                                                       
               };
            objp[0].Value = intEmpID;
            objp[1].Value = dtfrm;
            return double.Parse(ExecuteReader("spgetMedicalamt", objp));
        }
        public DataTable getgradedtls4salary(string strEmpCode, DateTime dtfrm, DateTime dtto)
        {
            intEmpID = GetEmpId(strEmpCode);
            SqlParameter[] objp = new SqlParameter[] 
            { 
                new SqlParameter("@empid",SqlDbType.Int),
            new SqlParameter ("@dtfrm",SqlDbType.SmallDateTime ,4),
                new SqlParameter ("@dtto",SqlDbType.SmallDateTime ,4),
               
                                                       
               };
            objp[0].Value = intEmpID;
            objp[1].Value = dtfrm;
            objp[2].Value = dtto;
            return ExecuteTable("spgetgradedtls4salary", objp);
        }
        ///Newly Added
        public void InsUpd4CmnClimDtls(string strEmpCode, string ctype, DateTime con, DateTime son, double camt, char ttyp)
        {
            SqlParameter[] objp = new SqlParameter[] 
                   {    
                       new SqlParameter("@empid",SqlDbType.Int),  
                       new SqlParameter("@ctype",SqlDbType.VarChar ,15),
                       new SqlParameter("@con",SqlDbType.DateTime,8),
                       new SqlParameter("@son",SqlDbType.DateTime,8),                      
                        new SqlParameter("@camt",SqlDbType.Money,8),
                         new SqlParameter("@ttyp", SqlDbType.Char, 1) 
                   };
            intEmpID = GetEmpId(strEmpCode);
            objp[0].Value = intEmpID;
            objp[1].Value = ctype;
            objp[2].Value = con;
            objp[3].Value = son;
            objp[4].Value = camt;
            objp[5].Value = ttyp;
            ExecuteQuery("SPInsUpd4ComClimDtls", objp);
        }

        /*Dinesh*/
      /*  public void InsHRClaimDtls(int empid, string claimtype, DateTime seton, double claimamt, char taxfy, DateTime claimon)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                 
                                                       new SqlParameter("@claimtype", SqlDbType.VarChar , 15),
                 new SqlParameter("@claimon", SqlDbType.DateTime, 8),
                                                      
                                                       new SqlParameter("@claimamt",SqlDbType.Money, 8 ),
                new SqlParameter("@taxfy", SqlDbType.Char , 1),
                 new SqlParameter("@seton", SqlDbType.DateTime, 8)
          };
            objp[0].Value = empid;
            objp[1].Value = claimtype;
            objp[2].Value = claimon;
            objp[3].Value = claimamt;
            objp[4].Value = taxfy;
            objp[5].Value = seton;
            ExecuteQuery("SPInsHRClaimDtls", objp);
        }*/
        /*Dinesh*/
      /*  public void UpdHRClaimDtls(int empid, string claimtype, double claimamt, DateTime claimdate, double oldcamt, DateTime seton, char taxfy)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@claimtype", SqlDbType.VarChar , 15),
                                                       new SqlParameter("@claimamt", SqlDbType.Money, 8),
                                                       new SqlParameter("@claimdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@oldcamt", SqlDbType.Money, 8),
          
               new SqlParameter("@seton", SqlDbType.DateTime, 8),
                 new SqlParameter("@taxfy", SqlDbType.Char, 1) 
            };
            objp[0].Value = empid;
            objp[1].Value = claimtype;
            objp[2].Value = claimamt;
            objp[3].Value = claimdate;
            objp[4].Value = oldcamt;
            objp[5].Value = seton;
            objp[6].Value = taxfy;
            ExecuteQuery("SPUpdHrclaimDtls", objp);
        }*/

        public void InsHRClaimDtls(int empid, string claimtype, DateTime seton, double claimamt, char taxfy, DateTime claimon, double ablamt, double nonablamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                 
                                                       new SqlParameter("@claimtype", SqlDbType.VarChar , 15),
                 new SqlParameter("@claimon", SqlDbType.DateTime, 8),
                                                      
                                                       new SqlParameter("@claimamt",SqlDbType.Money, 8 ),
                new SqlParameter("@taxfy", SqlDbType.Char , 1),
                 new SqlParameter("@seton", SqlDbType.DateTime, 8),
                   new SqlParameter("@ablamt",SqlDbType.Money, 8 ),
                   new SqlParameter("@nonablamt",SqlDbType.Money, 8 )
          };
            objp[0].Value = empid;
            objp[1].Value = claimtype;
            objp[2].Value = claimon;
            objp[3].Value = claimamt;
            objp[4].Value = taxfy;
            objp[5].Value = seton;
            objp[6].Value = ablamt;
            objp[7].Value = nonablamt;
            ExecuteQuery("SPInsHRClaimDtls", objp);
        }
        
        
       public void UpdHRClaimDtls(int empid, string claimtype, double claimamt, DateTime claimdate, double oldcamt, DateTime seton, char taxfy, double ablamt, double nonablamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@claimtype", SqlDbType.VarChar , 15),
                                                       new SqlParameter("@claimamt", SqlDbType.Money, 8),
                                                       new SqlParameter("@claimdate", SqlDbType.DateTime, 8),
                                                        new SqlParameter("@oldcamt", SqlDbType.Money, 8),
          
               new SqlParameter("@seton", SqlDbType.DateTime, 8),
                 new SqlParameter("@taxfy", SqlDbType.Char, 1) ,
                 new SqlParameter("@ablamt", SqlDbType.Money, 8),
                 new SqlParameter("@nonablamt", SqlDbType.Money, 8)
            };
            objp[0].Value = empid;
            objp[1].Value = claimtype;
            objp[2].Value = claimamt;
            objp[3].Value = claimdate;
            objp[4].Value = oldcamt;
            objp[5].Value = seton;
            objp[6].Value = taxfy;
            objp[7].Value = ablamt;
            objp[8].Value = nonablamt;
            ExecuteQuery("SPUpdHrclaimDtls", objp);
        }
        /*Dinesh*/
        //public void Del4EmpClaimDtls(int empid, string claimtype, double oldcamt)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
        //                                               new SqlParameter("@claimtype", SqlDbType.VarChar , 15),
        //                                                new SqlParameter("@oldcamt", SqlDbType.Money, 8)};
        //    objp[0].Value = empid;
        //    objp[1].Value = claimtype;
        //    objp[2].Value = oldcamt;
        //    ExecuteQuery("SPDelHR4ClaimDtls", objp);
        //}

     public void Del4EmpClaimDtls(int empid, string claimtype, double oldcamt, DateTime claimon, DateTime seton)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                       new SqlParameter("@claimtype", SqlDbType.VarChar , 15),
                                                        new SqlParameter("@oldcamt", SqlDbType.Money, 8),
            new SqlParameter("@claimon", SqlDbType.DateTime, 8),
            new SqlParameter("@seton", SqlDbType.DateTime, 8)};
            objp[0].Value = empid;
            objp[1].Value = claimtype;
            objp[2].Value = oldcamt;
            objp[3].Value = claimon;
            objp[4].Value = seton;
            ExecuteQuery("SPDelHR4ClaimDtls", objp);
        }
        //RAJA
        //To Update Employee Password

        public void UPDmailpwd4emp(string  empcode, string mailpwd)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empcode", SqlDbType.VarChar , 4),
                                                       new SqlParameter("@mailpwd", SqlDbType.VarChar , 30)
                                                        };
            objp[0].Value = empcode;
            objp[1].Value = mailpwd;

            ExecuteQuery("SPUPDmailpwd4emp", objp);
        }

        public DataTable selmailpwd4emp(int empid)
        {
           

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteTable("SPselmailpwd4emp", objp);
        }
        public DataTable BlockGetDivisionAll()
        {
            return ExecuteTable("SPSelAllDivisionBlock2");
        }

        //Manoj
        public DataTable GetLikeEmpNameWithCode(string empname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empname",SqlDbType.VarChar,30)
                        };
            objp[0].Value = empname;
            return ExecuteTable("SPLikeEmpNameHRwithCode", objp);
        }

        public DataTable GetIP(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                { 
                    new SqlParameter("@empid", SqlDbType.Int) 
                };

            objp[0].Value = empid;

            return ExecuteTable("spgetip", objp);
        }

        //public void UpdIP(int empid, string ipaddress, string div)
        //{
        //    SqlParameter[] objp = new SqlParameter[]
        //            {
        //                new SqlParameter("@empid",SqlDbType.Int),
        //                new SqlParameter("@ipaddress",SqlDbType.VarChar,15),
        //                new SqlParameter("@div",SqlDbType.VarChar,1)
        //            };
        //    objp[0].Value = empid;
        //    objp[1].Value = ipaddress;
        //    objp[2].Value = div;

        //    ExecuteQuery("updip", objp);


        //}

        public string UpdIP(int empid, string ipaddress, string div)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@ipaddress",SqlDbType.VarChar,15),
                        new SqlParameter("@div",SqlDbType.VarChar,1)
                    };
            objp[0].Value = empid;
            objp[1].Value = ipaddress;
            objp[2].Value = div;

            return ExecuteReader("updip", objp);
        }

        public int GetBId(int intDivision, string shortname)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.Int,4),
                            new SqlParameter("@shortname",SqlDbType.VarChar)
                        };
            objp[0].Value = intDivision;
            objp[1].Value = shortname;
            int intResult = 0;
            Dt = ExecuteTable("SPGetbid4mshortname", objp);
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }

        //*----------------------------------------------------Elakkiya-------------------------------------------

        public DataTable GetCreditDivision(string division)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@division",SqlDbType.VarChar,2)
                        };
            objp[0].Value = division;
            return ExecuteTable("SPSelAllDivision", objp);
        }
        //Arun

        public DataTable GetEmpDetailsNew(string strEmpCode)
        {


            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = strEmpCode;
            return ExecuteTable("SPSelEmpDOC", objp);
        }




        //MuthuRaj

        public DataTable getupdateempdatail(string empcode, int adminreport, int functionreport, int AppraisalBy, int workprocess, int reviewedby, int functid)
        {
            SqlParameter[] objp = new SqlParameter[]
               {
                       new SqlParameter("@empcode",SqlDbType.VarChar,4),
                       new SqlParameter("@adminreporting",SqlDbType.Int),
                       new SqlParameter("@functionalreporting",SqlDbType.Int),
                       new SqlParameter("@AppraisalBy",SqlDbType.Int),
                       new SqlParameter("@workprocess",SqlDbType.TinyInt),
                       new SqlParameter("@reviewedby",SqlDbType.Int),
                        new SqlParameter("@functid",SqlDbType.Int)

               };

            objp[0].Value = empcode;
            objp[1].Value = adminreport;
            objp[2].Value = functionreport;
            objp[3].Value = AppraisalBy;
            objp[4].Value = workprocess;
            objp[5].Value = reviewedby;
            objp[6].Value = functid;
            return ExecuteTable("SPmasterempUpdate", objp);

        }



        public DataTable selempudate(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empcode",SqlDbType.VarChar,4)
                    };
            objp[0].Value = empcode;
            return ExecuteTable("SPSelEmpupdatedetail", objp);
        }


        //MuthuRaj

        public DataTable getupdateempdatail(string empcode, int adminreport, int functionreport, int AppraisalBy, int workprocess, int reviewedby)
        {
            SqlParameter[] objp = new SqlParameter[]
               {
                       new SqlParameter("@empcode",SqlDbType.VarChar,4),
                       new SqlParameter("@adminreporting",SqlDbType.Int),
                       new SqlParameter("@functionalreporting",SqlDbType.Int),
                       new SqlParameter("@AppraisalBy",SqlDbType.Int),
                       new SqlParameter("@workprocess",SqlDbType.TinyInt),
                       new SqlParameter("@reviewedby",SqlDbType.Int)

               };

            objp[0].Value = empcode;
            objp[1].Value = adminreport;
            objp[2].Value = functionreport;
            objp[3].Value = AppraisalBy;
            objp[4].Value = workprocess;
            objp[5].Value = reviewedby;
            return ExecuteTable("SPmasterempUpdate", objp);

        }

        //Arun

        public DataTable selempudate(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@branchid",SqlDbType.Int)
                    };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetComfirmEmpNamenew", objp);
        }


        public DataTable GetConfirmemempname(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@branchid",SqlDbType.Int)
                    };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetComfirmEmpNamenew", objp);
        }
        //Dinesh

        public DataTable Getbranchwiseapprisal(int divisionid,int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@divisionid",SqlDbType.Int),
                        new SqlParameter("@year",SqlDbType.Int)
                    };
            objp[0].Value = divisionid;
            objp[1].Value = year;
            return ExecuteTable("spbranchwiseapprisal", objp);
        }



        public DataTable Getdepartmentwiseapprisal(int branchid,int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@branchid",SqlDbType.Int),
                        new SqlParameter("@year",SqlDbType.Int)
                    };
            objp[0].Value = branchid;
            objp[1].Value = year;
            return ExecuteTable("spdepartmentwiseapprisal", objp);
        }

        public DataTable Getemployeewiseapprisal(int branchid, int deptid, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@branchid",SqlDbType.Int),
                         new SqlParameter("@deptid",SqlDbType.Int),  new SqlParameter("@year",SqlDbType.Int)
                    };
            objp[0].Value = branchid;
            objp[1].Value = deptid;
            objp[2].Value = year;
            return ExecuteTable("spemployeewiseapprisal", objp);
        }



        //Manoj Appraisal

        public DataTable GetEmpidAppraisalCom(int empid)
        {


            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteTable("SPGetEMPAppraisalCom", objp);
        }


        public DataTable GetEmpidMasterCompeten(int empid)
        {


            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteTable("SPGetMasCompetencies", objp);
        }

        public DataSet GetEmpidKPI(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteDataSet("SPGetKPIForEmpid", objp);
        }

        public void UPDKpiforEmployee(int empid, int kpiyear, int selfrating, int kpiid, int agree)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@kpiyear", SqlDbType.Int ,4),
                                                       new SqlParameter("@selfrating", SqlDbType.Int ,4),
                                                       new SqlParameter("@kpiid", SqlDbType.Int , 4),
                                                       new SqlParameter("@agree", SqlDbType.Int , 4)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = selfrating;
            objp[3].Value = kpiid;
            objp[4].Value = agree;

            ExecuteQuery("SPUpdSelfrating", objp);
        }

        public void InsKpiCompforEmployee(int empid, int kpiyear, int selfrating, int qid, string selfremarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4),
                                                       new SqlParameter("@selfrating", SqlDbType.Int ,4),
                                                       new SqlParameter("@qid", SqlDbType.Int , 4),
                                                       new SqlParameter("@selfremarks", SqlDbType.VarChar , 500)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = selfrating;
            objp[3].Value = qid;
            objp[4].Value = selfremarks;

            ExecuteQuery("SPInsPersonalKPI", objp);
        }

        public void InsKpiforPage3(int empid, int year, string Q1Ans, int q2aans, int q2bans, int q2cans, int q2dans, int q2eans, int q2fans, int q2gans, string q2gansremarks, int q3aans, string q3bansT, string q3bAnsF, string q3bansS, string q4aans, string q4bans, string q3spans)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4),
                                                      new SqlParameter("@Q1Ans", SqlDbType.VarChar, 1000),
                                                       new SqlParameter("@q2aans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2bans", SqlDbType.Int, 4),
                                                       new SqlParameter("@q2cans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2dans", SqlDbType.Int, 4),
                                                       new SqlParameter("@q2eans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2fans", SqlDbType.Int, 4),
                                                       new SqlParameter("@q2gans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2gansremarks", SqlDbType.VarChar,100),
                                                       new SqlParameter("@q3aans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q3bansT", SqlDbType.VarChar,50),
                                                       new SqlParameter("@q3bAnsF", SqlDbType.VarChar,50),
                                                       new SqlParameter("@q3bansS", SqlDbType.VarChar,50),
                                                       new SqlParameter("@q4aans", SqlDbType.VarChar,100),
                                                       new SqlParameter("@q4bans", SqlDbType.VarChar,100),
                                                       new SqlParameter("@q3spans",SqlDbType.VarChar,500)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = year;
            objp[2].Value = Q1Ans;
            objp[3].Value = q2aans;
            objp[4].Value = q2bans;
            objp[5].Value = q2cans;
            objp[6].Value = q2dans;
            objp[7].Value = q2eans;
            objp[8].Value = q2fans;
            objp[9].Value = q2gans;
            objp[10].Value = q2gansremarks;
            objp[11].Value = q3aans;
            objp[12].Value = q3bansT;
            objp[13].Value = q3bAnsF;
            objp[14].Value = q3bansS;
            objp[15].Value = q4aans;
            objp[16].Value = q4bans;
            objp[17].Value = q3spans;

            ExecuteQuery("SPInsAppraisalPage3", objp);
        }


        public void UpdKpiforPage3(int empid, int year, string Q1Ans, int q2aans, int q2bans, int q2cans, int q2dans, int q2eans, int q2fans, int q2gans, string q2gansremarks, int q3aans, string q3bansT, string q3bAnsF, string q3bansS, string q4aans, string q4bans, int Appid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4),
                                                      new SqlParameter("@Q1Ans", SqlDbType.VarChar, 1000),
                                                       new SqlParameter("@q2aans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2bans", SqlDbType.Int, 4),
                                                       new SqlParameter("@q2cans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2dans", SqlDbType.Int, 4),
                                                       new SqlParameter("@q2eans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2fans", SqlDbType.Int, 4),
                                                       new SqlParameter("@q2gans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q2gansremarks", SqlDbType.VarChar,100),
                                                       new SqlParameter("@q3aans", SqlDbType.Int ,4),
                                                       new SqlParameter("@q3bansT", SqlDbType.VarChar,50),
                                                       new SqlParameter("@q3bAnsF", SqlDbType.VarChar,50),
                                                       new SqlParameter("@q3bansS", SqlDbType.VarChar,50),
                                                       new SqlParameter("@q4aans", SqlDbType.VarChar,100),
                                                       new SqlParameter("@q4bans", SqlDbType.VarChar,100),
                                                       new SqlParameter("appid",SqlDbType.Int,4)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = year;
            objp[2].Value = Q1Ans;
            objp[3].Value = q2aans;
            objp[4].Value = q2bans;
            objp[5].Value = q2cans;
            objp[6].Value = q2dans;
            objp[7].Value = q2eans;
            objp[8].Value = q2fans;
            objp[9].Value = q2gans;
            objp[10].Value = q2gansremarks;
            objp[11].Value = q3aans;
            objp[12].Value = q3bansT;
            objp[13].Value = q3bAnsF;
            objp[14].Value = q3bansS;
            objp[15].Value = q4aans;
            objp[16].Value = q4bans;
            objp[17].Value = Appid;

            ExecuteQuery("SPUpdAppraisalPage3", objp);
        }


        public DataTable GetAppraisalpage3(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@year",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            objp[1].Value = year;
            return ExecuteTable("SPGetAppraisalPage3", objp);
        }

        public void InsKpiEmpSubmit(int empid, int kpiyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            ExecuteQuery("SPInsSubmitAppraisal", objp);
        }


        public DataSet GetKPITotalRating(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@year",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            objp[1].Value = year;
            return ExecuteDataSet("SPGetTotalRating", objp);
        }


        public DataSet GetEmplistfroAppraiser(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteDataSet("SPGetemplistforAppraiser", objp);
        }

        public DataSet GetEmpidKPIForAppraise(int empid, int kpiyear)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@kpiyear",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            return ExecuteDataSet("SPGetKPIForEmpidforappraise", objp);
        }

        public void UPDKpiforAppraiser(int empid, int kpiyear, int selfrating, int kpiid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@kpiyear", SqlDbType.Int ,4),
                                                       new SqlParameter("@selfrating", SqlDbType.Int ,4),
                                                       new SqlParameter("@kpiid", SqlDbType.Int , 4)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = selfrating;
            objp[3].Value = kpiid;
            ExecuteQuery("SPUpdAppraisalrating", objp);
        }

        public DataTable GetAppraiseridMasterCompeten(int empid, int year)
        {


            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@year",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            objp[1].Value = year;
            return ExecuteTable("SPGetPersonalKPI4Appraiser", objp);
        }

        public void InsKpiCompforAppraiser(int empid, int kpiyear, int selfrating, int qid, string selfremarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4),
                                                       new SqlParameter("@selfrating", SqlDbType.Int ,4),
                                                       new SqlParameter("@qid", SqlDbType.Int , 4),
                                                       new SqlParameter("@selfremarks", SqlDbType.VarChar , 500)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = selfrating;
            objp[3].Value = qid;
            objp[4].Value = selfremarks;

            ExecuteQuery("SPInsPersonalKPI4Appraiser", objp);
        }

        public void InsKpiAppraiserSubmit(int empid, int kpiyear, int salrev, double salrevamt, int redesig, int redesigid, int regrade, string regradeid, string spremarks, int revsalmode)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4),
                                                       new SqlParameter("@salrev",SqlDbType.Int,4),
                                                       new SqlParameter("@salrevamt",SqlDbType.Money),
                                                       new SqlParameter("@redesig",SqlDbType.Int,4),
                                                       new SqlParameter("@redesigid",SqlDbType.Int,4),
                                                       new SqlParameter("@regrade",SqlDbType.Int,4),
                                                       new SqlParameter("@regradeid",SqlDbType.VarChar,4),
                                                       new SqlParameter("@spremarks",SqlDbType.VarChar,1000),
                                                       new SqlParameter("@revsalmode",SqlDbType.Int,4)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = salrev;
            objp[3].Value = salrevamt;
            objp[4].Value = redesig;
            objp[5].Value = redesigid;
            objp[6].Value = regrade;
            objp[7].Value = regradeid;
            objp[8].Value = spremarks;
            objp[9].Value = revsalmode;
            ExecuteQuery("SPInsSubmitAppraiserstatus", objp);
        }

        public DataTable GetGradeForKPI()
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                    };
            return ExecuteTable("SPGetGradeforKPI", objp);
        }


        public void InsKpiAppraiserSubmittedon(int empid, int kpiyear, string remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4),
                                                       new SqlParameter("@remarks",SqlDbType.VarChar,1000)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = remarks;
            ExecuteQuery("SPInsSubmitAppraisersubmit", objp);
        }

        public DataSet GetEmplistforReviewer(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteDataSet("SPGetemplistforReviewer", objp);
        }


        public DataSet GetKpiSubmittedDateDetails(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteDataSet("SPGetEmpSubon", objp);
        }


        public void InsEmpConfirm(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = empid;
            ExecuteQuery("SPUpdEmpConfirmation", objp);
        }

        public DataTable GetDivisionForCOO( int year)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@year", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = year;
            return ExecuteTable("SPGetDivisionDetails4COO", objp);
        }

        public DataTable GetEmpListForCOO()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        };
            return ExecuteTable("SPGetCOOEmpList", objp);
        }

        public DataTable GetBranchForCOO(int divisionid, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year",SqlDbType.Int,4)
                                                        };
            objp[0].Value = divisionid;
            objp[1].Value = year;
            return ExecuteTable("spbranchwiseCoo", objp);
        }

        public DataTable GetDeptForCOO(int branchid, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year",SqlDbType.Int,4)
                                                        };
            objp[0].Value = branchid;
            objp[1].Value = year;
            return ExecuteTable("spdepartmentwiseCOO", objp);
        }

        public DataTable GetEmplistForCOOFromDeptbranch(int deptid, int branchid, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year",SqlDbType.Int,4)
                                                        };
            objp[0].Value = deptid;
            objp[1].Value = branchid;
            objp[2].Value = year;
            return ExecuteTable("SPGetEmpDetailsCOOfromDept", objp);
        }

        public void InsKpiCOOSubmit(int empid, int kpiyear, int salrev, double salrevamt, int redesig, int redesigid, int regrade, string regradeid, string spremarks, int coosalmode, double coappamt)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@year", SqlDbType.Int ,4),
                                                       new SqlParameter("@salrev",SqlDbType.Int,4),
                                                       new SqlParameter("@salrevamt",SqlDbType.Money),
                                                       new SqlParameter("@redesig",SqlDbType.Int,4),
                                                       new SqlParameter("@redesigid",SqlDbType.Int,4),
                                                       new SqlParameter("@regrade",SqlDbType.Int,4),
                                                       new SqlParameter("@regradeid",SqlDbType.VarChar,4),
                                                       new SqlParameter("@spremarks",SqlDbType.VarChar,1000),
                                                       new SqlParameter("@coosalmode",SqlDbType.Int,4),
                                                       new SqlParameter("@coappamt",SqlDbType.Money),
                                                        };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = salrev;
            objp[3].Value = salrevamt;
            objp[4].Value = redesig;
            objp[5].Value = redesigid;
            objp[6].Value = regrade;
            objp[7].Value = regradeid;
            objp[8].Value = spremarks;
            objp[9].Value = coosalmode;
            objp[10].Value = coappamt;
            ExecuteQuery("SPInsSubmitCOOrstatus", objp);
        }

        public DataSet GetEmpAppraiserDtlsforMail(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteDataSet("SPGetEmpAppraiseForAutoMail", objp);
        }

        public DataTable GetEmpForKPI(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteTable("SPGetKPIFRomEmp", objp);
        }

        public DataTable GetAppraisalEnable(int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@year",SqlDbType.Int)
                    };
            objp[0].Value = year;
            return ExecuteTable("SPGetHRAppraisal", objp);
        }

        public void InsAppraisalEnable(int enabledby, int closedby, int year)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@enableby", SqlDbType.Int, 4),
                                                       new SqlParameter("@closedby", SqlDbType.Int ,4),
                                                       new SqlParameter("@year",SqlDbType.Int,4)
                                                        };
            objp[0].Value = enabledby;
            objp[1].Value = closedby;
            objp[2].Value = year;

            ExecuteQuery("SPInsHrAppraisalEnable", objp);
        }

        public DataTable GetDateDiffAppraisal(int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@year",SqlDbType.Int)
                    };
            objp[0].Value = year;
            return ExecuteTable("SPGetDateDiffAppraisal", objp);
        }

        public DataTable GetAppraisarCommentspage(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@year",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            objp[1].Value = year;
            return ExecuteTable("SPGetAppraiserCommentsPage", objp);
        }

        public void InsAppraiserComments(int empid, int year, string strength, string improvement, string training, string effectiveness, string gaps, int train, string trainneed)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@Empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@Appyear", SqlDbType.Int ,4),
                                                       new SqlParameter("@Strength",SqlDbType.VarChar,1000),
                                                       new SqlParameter("@Improvement", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@Training", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@Effectiveness",SqlDbType.VarChar,1000),
                                                       new SqlParameter("@Gaps", SqlDbType.VarChar,1000),
                                                       new SqlParameter("@train", SqlDbType.Int ,4),
                                                       new SqlParameter("@trainneed",SqlDbType.VarChar,1000)
                                                        };
            objp[0].Value = empid;
            objp[1].Value = year;
            objp[2].Value = strength;
            objp[3].Value = improvement;
            objp[4].Value = training;
            objp[5].Value = effectiveness;
            objp[6].Value = gaps;
            objp[7].Value = train;
            objp[8].Value = trainneed;
            ExecuteQuery("SPInsAppCommentsPage", objp);
        }

        public DataSet GetFunctionCompetencies(int employeeid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@employeeid",SqlDbType.Int)
                    };
            objp[0].Value = employeeid;
            return ExecuteDataSet("SPGetFunctionCompetencies", objp);
        }

        public DataTable GetKPIComparision(int employeeid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = employeeid;
            return ExecuteTable("SPGetKPIComparision", objp);
        }

        public DataTable GetEmpAppraisalEnable(int employeeid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = employeeid;
            return ExecuteTable("SPgetEmpAppraisalEnable", objp);
        }
        public DataSet GetEmplistforCompleteReviewer(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = empid;
            return ExecuteDataSet("SPGetemplistforCompReviewer", objp);
        }

        public DataTable GetEmpListForCompleteCOO()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        };
            return ExecuteTable("SPGetCompleteCOOEmpList", objp);
        }

        public DataTable GetEmplistForCompleteCOOFromDeptbranch(int deptid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = deptid;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetEmpDetailsCompleteCOOfromDept", objp);
        }

        public DataTable GetCurrentSalary(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = empid;
            return ExecuteTable("SpGetcurrentsalarystructure", objp);
        }

        public void InsSalaryCalculation(int employeeid, string grade, double gross, DateTime sfrom, DateTime sto, string Witharr, DateTime Efrom, DateTime Atakenon)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@grade",SqlDbType.VarChar,4),
                        new SqlParameter("@gross",SqlDbType.Money),
                        new SqlParameter("@sfrom",SqlDbType.SmallDateTime),
                        new SqlParameter("@sto",SqlDbType.SmallDateTime),
                        new SqlParameter("@witharr",SqlDbType.VarChar,1),
                        new SqlParameter("@efrom",SqlDbType.SmallDateTime),
                        new SqlParameter("@atakenon",SqlDbType.SmallDateTime)
                    };
            objp[0].Value = employeeid;
            objp[1].Value = grade;
            objp[2].Value = gross;
            objp[3].Value = sfrom;
            objp[4].Value = sto;
            objp[5].Value = Witharr;
            objp[6].Value = Efrom;
            objp[7].Value = Atakenon;
            ExecuteQuery("spSalarycalc", objp);
        }


        public DataTable GetRevisedSalary(int employeeid, string grade, double gross, DateTime sfrom, DateTime sto, string Witharr, DateTime Efrom, DateTime Atakenon)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empid",SqlDbType.Int),
                        new SqlParameter("@grade",SqlDbType.VarChar,4),
                        new SqlParameter("@gross",SqlDbType.Money),
                        new SqlParameter("@sfrom",SqlDbType.SmallDateTime),
                        new SqlParameter("@sto",SqlDbType.SmallDateTime),
                        new SqlParameter("@witharr",SqlDbType.VarChar,1),
                        new SqlParameter("@efrom",SqlDbType.SmallDateTime),
                        new SqlParameter("@atakenon",SqlDbType.SmallDateTime)
                    };
            objp[0].Value = employeeid;
            objp[1].Value = grade;
            objp[2].Value = gross;
            objp[3].Value = sfrom;
            objp[4].Value = sto;
            objp[5].Value = Witharr;
            objp[6].Value = Efrom;
            objp[7].Value = Atakenon;
            return ExecuteTable("SpGetrevisedsalarystructure", objp);
        }

        public DataTable GetSalaryQryforCoo(string comp,int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@comp",SqlDbType.Char,1),
                         new SqlParameter("@kpiyear",SqlDbType.Int,4)
                    };
            objp[0].Value = comp;
            objp[1].Value = year;
            return ExecuteTable("SPGetSalaryQueryDtlsForCOO", objp);
        }

        public DataTable GetDivision4Appraisalletter()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        };
            return ExecuteTable("SPGetDivisionDetails4Appletter", objp);
        }

        public DataTable GetBranch4Appraisalletter(int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = divisionid;
            return ExecuteTable("spbranchwise4AppLetter", objp);
        }

        public DataTable GetDept4AppraisalLetter(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = branchid;
            return ExecuteTable("spdepartmentwise4Appletter", objp);
        }

        public DataTable GetEmplistFor4appletter(int deptid, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@deptid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = deptid;
            objp[1].Value = branchid;
            return ExecuteTable("SPGetEmpDetails4appletter", objp);
        }

        public void UpdGrdandDesigfromKpi(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,5000)
                    };
            objp[0].Value = empcode;

            ExecuteQuery("SpUpdAppraisalFromKPI", objp);
        }

        //Manoj Appraisal End



        public DataTable sp_hrpayslip(int divisionid, int empid, int fromyear, int toyear, int frommonth, int tomonth)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@divisionid",SqlDbType.Int),
                        new SqlParameter("@empid",SqlDbType.Int),
                         new SqlParameter("@frompayyear",SqlDbType.Int),
                        new SqlParameter("@topayyear",SqlDbType.Int),
                         new SqlParameter("@Fromonth",SqlDbType.Int),
                         new SqlParameter("@TOmonth",SqlDbType.Int),

                       
                    };
            objp[0].Value = divisionid;
            objp[1].Value = empid;
            objp[2].Value = fromyear;
            objp[3].Value = toyear;
            objp[4].Value = frommonth;
            objp[5].Value = tomonth;
            return ExecuteTable("sp_hrpayslip", objp);

        }

        //MUTHU

        public DataTable sp_hrmpackages(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,4)
                    };
            objp[0].Value = empcode;
            return ExecuteTable("sp_hrmpackages", objp);
        }
        public DataTable sp_HRMSalaryPackages(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@employeeid",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            return ExecuteTable("sp_HRMSalaryPackages", objp);
        }
        public DataTable sp_compensation(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@employeeid",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            return ExecuteTable("sp_compensation", objp);
        }
        public DataTable sp_allowances(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@employeeid",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            return ExecuteTable("sp_allowances", objp);
        }
        public DataTable sp_Contribution(int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@employeeid",SqlDbType.Int,4)
                    };
            objp[0].Value = empid;
            return ExecuteTable("sp_Contribution", objp);
        }

        public DataTable sp_getbranchname(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@branchid",SqlDbType.Int)
                    };
            objp[0].Value = branchid;
            return ExecuteTable("sp_getbranchnamenew", objp);
        }
        public DataTable sp_userrights(int processid, string trantype="")
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@processid",SqlDbType.Int),
                        new SqlParameter("@modulename",SqlDbType.VarChar,4)
                    };
            objp[0].Value = processid;
            objp[1].Value = trantype;
            return ExecuteTable("sp_userrightsnew", objp);
        }
        public DataTable sp_userrightsnew(int processid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@processid",SqlDbType.Int)

                    };
            objp[0].Value = processid;

            return ExecuteTable("sp_userrightsnew", objp);
        }
        public DataTable sp_userrightsnewFA(int processid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@processid",SqlDbType.Int),
                        new SqlParameter("@modulename",SqlDbType.VarChar,4)

                    };
            objp[0].Value = processid;
            objp[1].Value = trantype;

            return ExecuteTable("sp_userrightsnewFA", objp);
        } 
        public DataTable sp_touchlogoimage(int divid)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@divid",SqlDbType.Int)
                    };
            objp[0].Value = divid;
            return ExecuteTable("sp_touchlogoimagenew", objp);
        }

        public DataTable SP_USERRIGHTSCRM(int processid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@processid",SqlDbType.Int),
                        new SqlParameter("@modulename",SqlDbType.VarChar,4)
                    };
            objp[0].Value = processid;
            objp[1].Value = trantype;
            return ExecuteTable("SP_USERRIGHTSCRM", objp);
        }

        public DataTable sp_userrightsfinans(string trantype)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@modulename",SqlDbType.VarChar,4)
                    };
            objp[0].Value = trantype;
            return ExecuteTable("sp_userrightsfinans", objp);
        }

        public DataTable apprisalcheckforitcomputation(int employeeid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4) };
            objp[0].Value = employeeid;
            return ExecuteTable("spapprisalcheckforitcomputation", objp);

        } 

        //MUTHURAJ

        public int sp_likemasterprocessname(string processname)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@processname",SqlDbType.VarChar,100)
                    };
            objp[0].Value = processname;

            return int.Parse(ExecuteReader("sp_likemasterprocessname", objp));
        }

        public DataTable Getemplistdetails()
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                        };
            return ExecuteTable("spemplistdetails", objp);
        }

        public int GetBranchIdNEW(string strBranchName)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {                           
                            new SqlParameter("@branchname",SqlDbType.VarChar,100)
                        };
            objp[0].Value = strBranchName;
            int intResult = 0;
            Dt = ExecuteTable("SPGetBranchIDnew", objp);
            if (Dt.Rows.Count > 0)
            {
                intResult = int.Parse(Dt.Rows[0][0].ToString());
            }
            return intResult;
        }
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
        public DataTable GetBranchandDivision_new(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@branchid",SqlDbType.TinyInt,1)
                        };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetBranchandDivision_new", objp);
        }
        public DataTable GetLikeroleName(string rolename)
        {
            SqlParameter[] objp = new SqlParameter[]
                        {
                            new SqlParameter("@rolename",SqlDbType.VarChar,50)
                        };
            objp[0].Value = rolename;
            return ExecuteTable("SPLikeroleName", objp);
        }
        public DataTable Getrolename()
        {
            return ExecuteTable("spgetrolename");
        }
        public void Updroleinemployee(string empcode,string role)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,4),
                        new SqlParameter("@role",SqlDbType.VarChar,100)
                    };
            objp[0].Value = empcode;
            objp[1].Value = role;
            ExecuteQuery("SPupdroleinemployee", objp);
        }
        public void InsRole4employee(string empcode, string role)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,4),
                        new SqlParameter("@role",SqlDbType.VarChar,50)
                    };
            objp[0].Value = empcode;
            objp[1].Value = role;
            ExecuteQuery("SPInsRole4employee", objp);
        }
        public DataTable Getroleforemployee(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,4),
                       
                    };
            objp[0].Value = empcode;

            return ExecuteTable("SPgetroleforemployee", objp);
        }
        public DataTable Insuserrightsfromroleforemployee(string empcode)
        {
            SqlParameter[] objp = new SqlParameter[]
                    {
                        new SqlParameter("@empcode",SqlDbType.VarChar,4),

                    };
            objp[0].Value = empcode;

            return ExecuteTable("SPInsuserrightsfromroleforemployee", objp);
        }
        public string GetFtdFolder(int strDivisionId)
        {
            SqlParameter[] objp = new SqlParameter[]
                        {
                            new SqlParameter("@division",SqlDbType.Int)
                        };
            objp[0].Value = strDivisionId;
            string ftdfoldername = "";
            Dt = ExecuteTable("SPSelFtdfoldername", objp);
            if (Dt.Rows.Count > 0)
            {
                ftdfoldername = Dt.Rows[0][0].ToString();
            }
            return ftdfoldername;
        }
    }
}
