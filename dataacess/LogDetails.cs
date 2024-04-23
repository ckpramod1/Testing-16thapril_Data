
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class LogDetails : DBObject
    {
        string TName, m, y;

        string TName1, m1, y1;

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }

        public LogDetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void CreateLogTable()
        {
            m = GetDate().Month.ToString();
            if (m.Length < 2)
                m = "0" + m;
            y = GetDate().Year.ToString().Substring(2, 2);
            TName = "GRPLog" + m + y;
            Cmd = new SqlCommand("IF NOT EXISTS    (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME ='"+TName+"') create table " + TName + " ( 	[empid] [smallint] NOT NULL ,	[uiid] [smallint] NOT NULL ,	[eventid] [tinyint] NOT NULL ,	[eventdate] [smalldatetime] NOT NULL ,	[branchid] [tinyint] NOT NULL ,	[eventdocs] [varchar] (100)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL)", Conn);
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public void InsLogDetail(int empid, int uiid, int eventid, int branchid, string eventdocs)
        {
            m = GetDate().Month.ToString();
            if (m.Length < 2)
                m = "0" + m;
            y = GetDate().Year.ToString().Substring(2, 2);
            TName = "GRPLog" + m + y;
            DateTime dt = GetDate();
            //Cmd = new SqlCommand("insert into " + TName + " (empid,uiid,eventid,eventdate,branchid,eventdocs) values(@empid,@uiid,@eventid,dt,@branchid,substring(@eventdocs,1,99))", Conn);
            Cmd = new SqlCommand("insert into " + TName + " (empid,uiid,eventid,eventdate,branchid,eventdocs) values(@empid,@uiid,@eventid,getdate(),@branchid,substring(@eventdocs,1,99))", Conn);
            Cmd.Parameters.AddWithValue("@empid", empid);
            Cmd.Parameters.AddWithValue("@uiid", uiid);
            Cmd.Parameters.AddWithValue("@eventid", eventid);
            Cmd.Parameters.AddWithValue("@branchid", branchid);
            Cmd.Parameters.AddWithValue("@eventdocs", eventdocs);
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
       }







        public void CreateLogTablenew()
        {
            m1 = GetDate().Month.ToString();
            if (m1.Length < 2)
                m1 = "0" + m1;
            y = GetDate().Year.ToString().Substring(2, 2);
            TName1 = "GRPLogdevice" + m1 + y1;
            Cmd = new SqlCommand("IF NOT EXISTS    (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_NAME ='" + TName1 + "') create table " + TName1 + " ( 	[empid] [smallint] NOT NULL ,	[uiid] [smallint] NOT NULL ,	[eventid] [tinyint] NOT NULL ,	[eventdate] [smalldatetime] NOT NULL ,	[branchid] [tinyint] NOT NULL ,	[eventdocs] [varchar] (100)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,[Devicename] [varchar] (100)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL)", Conn);
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public void InsLogDetailnew(int empid, int uiid, int eventid, int branchid, string eventdocs,string devicename)
        {
            m1 = GetDate().Month.ToString();
            if (m.Length < 2)
                m1 = "0" + m1;
            y1 = GetDate().Year.ToString().Substring(2, 2);
            TName1 = "GRPLogdevice" + m1 + y1;
            DateTime dt = GetDate();
            //Cmd = new SqlCommand("insert into " + TName + " (empid,uiid,eventid,eventdate,branchid,eventdocs) values(@empid,@uiid,@eventid,dt,@branchid,substring(@eventdocs,1,99))", Conn);
            Cmd = new SqlCommand("insert into " + TName1 + " (empid,uiid,eventid,eventdate,branchid,eventdocs,Devicename) values(@empid,@uiid,@eventid,getdate(),@branchid,substring(@eventdocs,1,99),substring(@Devicename,1,99))", Conn);
            Cmd.Parameters.AddWithValue("@empid", empid);
            Cmd.Parameters.AddWithValue("@uiid", uiid);
            Cmd.Parameters.AddWithValue("@eventid", eventid);
            Cmd.Parameters.AddWithValue("@branchid", branchid);
            Cmd.Parameters.AddWithValue("@eventdocs", eventdocs);
            Cmd.Parameters.AddWithValue("@Devicename", devicename);
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public void InsLogsAll(int empid, DateTime from, DateTime to)
        {
            //DateTime ttt=from; 
            //string strqry = "";
            //while (ttt < to)
            //{
            //    string strTableName = "";
            //    if (ttt.Month < 9)
            //        strTableName = "GRPLog0" + ttt.Month + ttt.Year.ToString().Substring(2);
            //    else
            //        strTableName = "GRPLog" + ttt.Month + ttt.Year.ToString().Substring(2);
            //    if (empid == 0)
            //        strqry = "insert into GRPLogs(empid,uiid,eventid,eventdate,branchid,eventdocs) select empid,uiid,eventid,eventdate,branchid,eventdocs from " + strTableName+" where empid not in(select employeeid from masteremployee where  deptid=1 and branch=13906)";
            //    else
            //        strqry = "insert into GRPLogs(empid,uiid,eventid,eventdate,branchid,eventdocs) select empid,uiid,eventid,eventdate,branchid,eventdocs from " + strTableName + " where empid=" + empid + "  and empid not in(select employeeid from masteremployee where  deptid=1 and branch=13906)";

            //    Cmd = new SqlCommand(strqry, Conn);
            //    Conn.Open();
            //    Cmd.ExecuteNonQuery();
            //    Conn.Close();
            //    ttt = from.AddMonths(1);
            //    //to = from.AddMonths(1);
            //}
        }
        public void DelLogsAll(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int) };
            objp[0].Value = empid;
            ExecuteQuery("SPDelLogAll", objp);        
        }
        public string GetTablename()
        {
            m = GetDate().Month.ToString();
            if (m.Length < 2)
                m = "0" + m;
            y = GetDate().Year.ToString().Substring(2, 2);
            TName = "GRPLog" + m + y;
            return TName;
        }


        public DateTime GetDate()
        {
            return DateTime.Parse(ExecuteReader("SPGetDate"));
        }
        public DataTable GetCompanyNameAdd(int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.VarChar, 30) };
            objp[0].Value = branchid;
            return ExecuteTable("SPGetCompanyNameAdd", objp);
        }

        public void ChangeCustID(int oldid,int newid,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@oldid", SqlDbType.Int, 4),
                                                       new SqlParameter("@newid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4)};
            objp[0].Value = oldid;
            objp[1].Value = newid;
            objp[2].Value = branchid;
            ExecuteQuery("SPChangeCustIDRemoveDuplicate", objp);
        }
       
        public DataTable GetAllModJobIncExp(string trantype, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@bid", SqlDbType.TinyInt,1) };
            objp[0].Value = trantype;
            objp[1].Value = intBranchID;
            return ExecuteTable("SPSelAllModJobIncExp", objp);
        }
        public int CheckMBLNOWithHBL(string trantype, string strMBLNo, int intBranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                       new SqlParameter("@bid",SqlDbType.TinyInt,1),
                                                       new SqlParameter("@trantype",SqlDbType.VarChar,2)};
            objp[0].Value = strMBLNo;
            objp[1].Value = intBranchID;
            objp[2].Value = trantype;
            return int.Parse(ExecuteReader("SPCheckMBLWithHBL", objp));
        }
        public DataTable GetUpdateDts(DateTime updateon)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@updateon", SqlDbType.SmallDateTime, 4) };
            objp[0].Value = updateon;
            return ExecuteTable("SPGetUpdateDts", objp);
        }


        // log details
        public DataTable UpdAppCrdtOS4Cust(int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@division", SqlDbType.Int) };
            objp[0].Value = divid;
            return ExecuteTable("SPUpdApprovalCreditOutStandingAmountforCustomer", objp);
        }

        public string GetBranchEDIUserID(int BranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            objp[0].Value = BranchID;
            return ExecuteReader("SPGetBranchEDIUsedID", objp);
        }
        public string Encrypt(string input, string key)
        {
            int i = 0;
            string encryptPWD = "";

            for (i = 0; i < input.Length; i++)
            {
                encryptPWD = encryptPWD + ((int)input[i] + Convert.ToInt32(key)).ToString() + "~";
            }
            return encryptPWD;
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

        //Dinesh

        /*public string Getloginbranchtouchlogo(int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int, 2) };
            objp[0].Value = divid;
            return ExecuteReader("sploginbranchtouchlogo", objp);
        }*/
        public DataTable Getloginbranchtouchlogo(int divid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@divisionid", SqlDbType.Int, 2) };
            objp[0].Value = divid;
            return ExecuteTable("sploginbranchtouchlogo", objp);
        }


        public byte[] GetloginBranchUSERID(int BranchID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int, 2) };
            objp[0].Value = BranchID;
            return ExecuteReaderByte("spGetloginBranchUSERID", objp);
        }

        //GST
        //DINESH

      

        public DataTable GetGSTDts()
        {
            SqlParameter[] objp = new SqlParameter[] { 
         };

            return ExecuteTable("spmasterifupdate");
        }

        //Raj

        public DateTime GetGSTDate()
        {
            return DateTime.Parse(ExecuteReader("spmasterifupdate"));
        }
        public string getvoudate4rpt(string strformula)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@SQLStr", SqlDbType.VarChar) };
            objp[0].Value = strformula;
            return (ExecuteReader("spgetvoudate4rpt", objp));
        }

        //Dinesh

        public void InsTempGrpLogdtls(int empid, DateTime from, DateTime to, int branchid, int uiid, string events)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@from", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@to", SqlDbType.SmallDateTime, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                        new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                         new SqlParameter("@events", SqlDbType.VarChar ,50)
                                                    };
            objp[0].Value = empid;
            objp[1].Value = from;
            objp[2].Value = to;
            objp[3].Value = branchid;
            objp[4].Value = uiid;
            objp[5].Value = events;
            ExecuteQuery("SPInsTempGrpLogdtls", objp);
        }


        public DataTable get_logdetailsall(int uiid, int branchid, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                new SqlParameter("@uiid", SqlDbType.Int, 4), 
                 new SqlParameter("@branchid", SqlDbType.Int, 4), 
                  new SqlParameter("@loginempid", SqlDbType.Int, 4)
            };

            objp[0].Value = uiid;
            objp[1].Value = branchid;
            objp[2].Value = empid;
            return ExecuteTable("sp_logdetailsall", objp);
        }

        public DataTable InsTempGrpLogdtlsGet(int empid, int branchid, int uiid, string type, string typevalue, string events, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                       new SqlParameter("@type", SqlDbType.VarChar ,50),
                                                        new SqlParameter("@typevalue", SqlDbType.VarChar ,50),
                                                       new SqlParameter("@events", SqlDbType.VarChar ,100),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar ,2)

                                                    };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = uiid;
            objp[3].Value = type;
            objp[4].Value = typevalue;
            objp[5].Value = events;
            objp[6].Value = trantype;
            return ExecuteTable("SPInsTempGrpLogdtlsAll", objp);
        }

        public DataTable GetVoudetails(int branchid, DateTime fdate, DateTime tdate, string dbname, char type)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                                                        new SqlParameter("@fdate", SqlDbType.SmallDateTime, 4),
                                                        new SqlParameter("@tdate", SqlDbType.SmallDateTime, 4),
                new SqlParameter("@dbname", SqlDbType.VarChar,15),
                 new SqlParameter("@type", SqlDbType.VarChar,1)
            };
            objp[0].Value = branchid;
            objp[1].Value = fdate;
            objp[2].Value = tdate;
            objp[3].Value = dbname;
            objp[4].Value = type;
            return ExecuteTable("spgetvoudtls", objp);
        }


        //Elengo

        public void InsCrystalRPTLogDtls(string Aspx, string RptFilename, int Bid)
        {
            SqlParameter[] objp = new SqlParameter[] 
            { 
              new SqlParameter("@Aspx", SqlDbType.VarChar ,100),
              new SqlParameter("@RptFilename", SqlDbType.VarChar ,200),
              new SqlParameter("@Bid", SqlDbType.Int)
            };
            objp[0].Value = Aspx;
            objp[1].Value = RptFilename;
            objp[2].Value = Bid;
            ExecuteQuery("InsCrystalRPTLogDtls", objp);
        }



        public DataTable getrights4payrec(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int),
                                                        
            };
            objp[0].Value = empid;

            return ExecuteTable("sp_getrights4payrec", objp);
        }

        public DataTable InsTempGrpLogdtlsGet(int empid, int branchid, int uiid, string type, string typevalue, string events, string trantype, int vouyear)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 4),
                                                       new SqlParameter("@branchid", SqlDbType.Int, 4),
                                                       new SqlParameter("@uiid", SqlDbType.Int, 4),
                                                       new SqlParameter("@type", SqlDbType.VarChar ,50),
                                                       new SqlParameter("@typevalue", SqlDbType.VarChar ,50),
                                                       new SqlParameter("@events", SqlDbType.VarChar ,100),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar ,2),
                                                       new SqlParameter("@vouyear", SqlDbType.Int, 4)
                                                    };
            objp[0].Value = empid;
            objp[1].Value = branchid;
            objp[2].Value = uiid;
            objp[3].Value = type;
            objp[4].Value = typevalue;
            objp[5].Value = events;
            objp[6].Value = trantype;
            objp[7].Value = vouyear;
            return ExecuteTable("SPInsTempGrpLogdtlsAll", objp);
        }
        // Subin Mail 
        public DataTable ForgetPwdLoginMailid()
        {
            return ExecuteTable("loginForgetmailPwd");
        }
        public DataTable Forcountryid(int bid, int div)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.Int),
                new SqlParameter("@divisionid", SqlDbType.Int)
                                                        
            };
            objp[0].Value = bid;
            objp[1].Value = div;

            return ExecuteTable("spForcountryid", objp);
        }
    }
}

