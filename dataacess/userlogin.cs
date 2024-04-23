using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace DataAccess
{
    public class userlogin : DBObject
    {
        int intEmpID;// intDivisionID, intDesigID, intDeptID;
        DataAccess.Masters.MasterEmployee empObj = new DataAccess.Masters.MasterEmployee();
        DataAccess.Masters.MasterPort prtObj = new DataAccess.Masters.MasterPort();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public userlogin()
        {
            Conn = new SqlConnection(DBCS);
        }

        public int InsertUserLoginDetails(string username,string macaddress,string hostname, DateTime logindate,int divisionid,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@username",SqlDbType.VarChar,15),
                                                      new SqlParameter("@macaddress",SqlDbType.VarChar,30),
                                                      new SqlParameter("@hostname",SqlDbType.VarChar,50),
                                                      new SqlParameter("@Logindatetime",SqlDbType.SmallDateTime),
                                                      new SqlParameter("@divisionid",SqlDbType.Int,4),
                                                      new SqlParameter("@branchid",SqlDbType.Int,4),
                                                      new SqlParameter("@loginid",SqlDbType.Int,4)
                                                     };
            objp[0].Value = username;
            objp[1].Value = macaddress;
            objp[2].Value = hostname;
            objp[3].Value = logindate;
            objp[4].Value = divisionid;
            objp[5].Value = branchid;
            objp[6].Direction = ParameterDirection.Output;

            return ExecuteQuery("SPInsUserLoginDetails", objp,"@loginid");
        }

        public DataTable GetUserLoginDetails(string username,string function)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@func",SqlDbType.VarChar,1)};
            objp[0].Value = username;
            objp[1].Value = function;
            return ExecuteTable("SPGetUserLoginDetails", objp);
        }

        public void UpdateUserLoginDetails(string username, DateTime logoutdate, int loginid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                      new SqlParameter("@username",SqlDbType.VarChar,15),
                                                      new SqlParameter("@logoutdate",SqlDbType.SmallDateTime),
                                                      new SqlParameter("@loginid",SqlDbType.Int)
                                                     };
            objp[0].Value = username;
            objp[1].Value = logoutdate;
            objp[2].Value = loginid;
            ExecuteQuery("SPUpdLogoutDate", objp);
        }

        public DataTable GetUserLoginDetails4scm(string username, string function, int divisionid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@username", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@func",SqlDbType.VarChar,1),
                                                       new SqlParameter("@divisionid",SqlDbType.Int,4)};
            objp[0].Value = username;
            objp[1].Value = function;
            objp[2].Value = divisionid;
            return ExecuteTable("SPGetUserLoginDetails4SCM", objp);
        }


        //BHARATHI

        public DataTable GetdivisionName(string divisionname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.VarChar, 100) };
            objp[0].Value = divisionname;
            return ExecuteTable("SPSelMasterdivision4login", objp);
        }
        public DataTable GetBranchnName(int divisionid, string portname)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int ) ,
                                                        new SqlParameter("@portname",SqlDbType.VarChar,100)};
            objp[0].Value = divisionid;
            objp[1].Value = portname;
            return ExecuteTable("SPSelMasterPort4login", objp);
        }
        public string Decrypt(string input, string key)
        {
            int i = 0;
            string decryptPWD = "";
            string[] s = input.Split('~');
            if (s.Length > 1)
            {
                for (i = 0; i < s.Length - 1; i++)
                {
                    decryptPWD = decryptPWD + (Char.ConvertFromUtf32(Convert.ToInt32(s[i]) - Convert.ToInt32(key))).ToString();
                }
            }
            else
            {
                decryptPWD = input;
            }
            return decryptPWD;
        }
        public DataTable selEmpDetailsWOROL(string strEmpCode)
        {
            intEmpID = empObj.GetEmpid(strEmpCode);
            //intEmpID =GetEmpId(strEmpCode);

            SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@empid",SqlDbType.Int)
                    };
            objp[0].Value = intEmpID;
            return ExecuteTable("SPSelEmpOfficialWOROL", objp);
        }
        public DataTable SelGetMail4pwd(string offmailid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mailid", SqlDbType.VarChar, 100) };
            objp[0].Value = offmailid;
            return ExecuteTable("SPSelmailid4login", objp);
        }

        //Dinesh
        public DataTable selEmpDetailsWOROLnew(string stremp)
        {
            //intEmpID = GetEmpId(strEmpCode);
            if (stremp.Length == 4)
            {
                empObj.GetDataBase(Clientcode);
                intEmpID = empObj.GetEmpid(stremp);

                SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@emp",SqlDbType.VarChar,100),
                    };
                objp[0].Value = intEmpID;
                return ExecuteTable("SPSelEmpOfficialWOROLnewchanges", objp);
            }
            else if (stremp.Length == 10)
            {
                empObj.GetDataBase(Clientcode);
                intEmpID = empObj.GetEmpidphone(stremp);
                SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@emp",SqlDbType.VarChar,100),
                    };
                objp[0].Value = intEmpID;
                return ExecuteTable("SPSelEmpOfficialWOROLnewchanges", objp);
            }
            else
            {
                empObj.GetDataBase(Clientcode);
                intEmpID = empObj.GetEmpidemployeeid(stremp);
                SqlParameter[] objp = new SqlParameter[]
                    { 
                        new SqlParameter("@emp",SqlDbType.VarChar,100),
                    };
                objp[0].Value = intEmpID;
                return ExecuteTable("SPSelEmpOfficialWOROLnewchanges", objp);
            }

        }


        public DataTable portid()
        {
            return ExecuteTable("portsearch_NEW");
        }
        public DataTable portname_new(string portname)
        {
            SqlParameter[] pass = new SqlParameter[]
            {
                new SqlParameter("@portid",SqlDbType.NVarChar,100)
            };

            pass[0].Value = portname;
            return ExecuteTable("portname_new", pass);
        }
    }
}
