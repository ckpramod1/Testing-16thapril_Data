using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;


//---------------------------------------------------------FA - M+R 

namespace DataAccess
{

    public abstract class DBObject : FAConn
    {
        //DataAccess.DashBoard.DBName dbobj = new DataAcess.DashBoard.DBName(); 
        //StreamReader rdrDB = new StreamReader("Config/DBName.inf");
        //StreamReader rdrSVR = new StreamReader("Config/Server.inf");
        //  DataAccess.Masters.MasterBranch da_obj_Branch = new DataAccess.Masters.MasterBranch();



        string ccode;

        protected string DBCS;
        public DBObject()
        {

            //Clientcode

            //string pathloc = "";

            //if (Clientcode == "CH01")
            //{
            //    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\SLDB\DB.txt"))
            //    {
            //        DBCS = reader.ReadLine();
            //    }
            //}
            //else if (Clientcode == "CH01")
            //{
            //    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\MarinAir\DB.txt"))
            //    {
            //        DBCS = reader.ReadLine();
            //    }
            //}




            //if (Clientcode != "")
            //{
            //    string DBName = "DemoFAP";

            //    if (Clientcode == "CH01")
            //    {
            //        DBName = "SL";
            //        //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
            //        //{
            //        //    DBCS = reader.ReadLine();
            //        //}
            //    }
            //    else if (Clientcode == "CH02")
            //    {
            //        DBName = "MarinAir";
            //        //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
            //        //{
            //        //    DBCS = reader.ReadLine();
            //        //}
            //    }

            //    using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
            //    {
            //        DBCS = reader.ReadLine();
            //    }

            //}
            //else
            //{
            //    if (Clientcode == "")
            //    {
            //        string DBName = "DemoFAP";
            //        using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
            //        {
            //            DBCS = reader.ReadLine();
            //        }
            //    }
            //}

            string DBName = "CopperHawk";
            string connetionString;
            // SqlConnection Conn;
            connetionString = @"Data Source=ifreight.database.windows.net;Initial Catalog=CopperHawk;User ID=ifrtAdmin;pwd=05Jun!(&%;";
            Conn = new SqlConnection(connetionString);
            Conn.Open();

            if (!String.IsNullOrEmpty(Clientcode))
            {

                DBName = GetDBName(Clientcode);
            }

            Conn.Close();

            if (Clientcode != "")
            {


                //string DBName= "CopperHawk";
                //    string connetionString;
                //    SqlConnection cnn;
                //    connetionString = @"Data Source=ifreight.database.windows.net;Initial Catalog=CopperHawk;User ID=ifrtAdmin;pwd=05Jun!(&%;";
                //    cnn = new SqlConnection(connetionString);
                //    cnn.Open();

                //    if (!String.IsNullOrEmpty(Clientcode))
                //    {
                //        DBName = GetDBName(Clientcode);
                //    }

                //    cnn.Close();







                DBCS = "Data Source=ifreight.database.windows.net;" + "Initial Catalog=" + DBName + ";" + "User ID=ifrtAdmin;" + "pwd=05Jun!(&%;";

                Conn = new SqlConnection(DBCS);

                //if (!String.IsNullOrEmpty(Clientcode))
                //{
                //    DBName = GetDBName(Clientcode);
                //}



                //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //{
                //    DBCS = reader.ReadLine();
                //}



                //  DataTable Dt = new DataTable();

                //Dt=  da_obj_Branch.GetDBName(Clientcode);


                //  DBName = Dt.Rows[0]["DBName"].ToString();

                //if (Clientcode == "SWENLOG")
                //{
                //    DBName = "SL";
                //    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //    //{
                //    //    DBCS = reader.ReadLine();
                //    //}
                //}
                //else if (Clientcode == "MARINAIR")
                //{
                //    DBName = "MarinAir";
                //    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //    //{
                //    //    DBCS = reader.ReadLine();
                //    //}
                //}
                //else if (Clientcode == "OCEANKARE")
                //{
                //    DBName = "OceanKare";
                //    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //    //{
                //    //    DBCS = reader.ReadLine();
                //    //}
                //}
                //else if (Clientcode == "DEMO")
                //{
                //    DBName = "DemoFAP";
                //}

                //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //{
                //    DBCS = reader.ReadLine();
                //}

            }
            else
            {
                if (Clientcode == "")
                {
                    //string DBName = "CopperHawk";
                    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    //{
                    //    DBCS = reader.ReadLine();
                    //}
                    //string connetionString;
                    //SqlConnection cnn;
                    connetionString = @"Data Source=ifreight.database.windows.net;Initial Catalog=CopperHawk;User ID=ifrtAdmin;pwd=05Jun!(&%;";
                    Conn = new SqlConnection(connetionString);
                    Conn.Open();
                    Conn.Close();

                }
            }


            //Conn = new SqlConnection(DBCS);

            //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\DemoFAP\DB.txt"))
            //{
            //    DBCS = reader.ReadLine();
            //}



















            //using (StreamReader reader = new StreamReader(@"dataacess\DemoFAP\DB.txt"))
            //{
            //    DBCS = reader.ReadLine();
            //}





            //DBCS = "Data Source=ifreight.database.windows.net;" + "Initial Catalog=DemoFAP;" + "User ID=ifrtAdmin;" + "pwd=05Jun!(&%;";

            //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=iNDPFAsKR;User ID=ltadmin;pwd=Acer0104#";    

            // DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=iNDPFAsKR;User ID=ltadmin;pwd=Acer0104#";
            //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=iNDPFAsKR;User ID=ltadmin;pwd=Acer0104#";     
            //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=FAMR;User ID=ltadmin;pwd=Acer0104#";     

            //   DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=Demo;User ID=ltadmin;pwd=Acer0104#";     

            //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=Demo;User ID=ltadmin;pwd=Acer0104#";

            //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=FAMR_2018-07-28T13-40Z;User ID=ltadmin;pwd=Acer0104#";
            //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=Demo;User ID=ltadmin;pwd=Acer0104#";


            //  DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=FAMR_2018-07-16T12-00Z;User ID=ltadmin;pwd=Acer0104#";  

            //------------------------------HOSTING DBCS_----------------------------------------------------------------------------//



            // DBCS = "Data Source=DINESH-PC\\SQLEXPRESS;Initial Catalog=FAMRNew;User ID=sa;pwd=FA123";


        }

        //string ccode;

        //protected string DBCS;


        //public void xyz(string Clientcode)
        //{



        //    if (Clientcode != "")
        //    {
        //        string DBName = "DemoFAP";

        //        if (Clientcode == "CH01")
        //        {
        //            DBName = "SL";
        //            //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
        //            //{
        //            //    DBCS = reader.ReadLine();
        //            //}
        //        }
        //        else if (Clientcode == "CH02")
        //        {
        //            DBName = "MarinAir";
        //            //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
        //            //{
        //            //    DBCS = reader.ReadLine();
        //            //}
        //        }
        //        else if (Clientcode == "CH03")
        //        {
        //            DBName = "OceanKare";
        //            //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
        //            //{
        //            //    DBCS = reader.ReadLine();
        //            //}
        //        }

        //        using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
        //        {
        //            DBCS = reader.ReadLine();
        //        }

        //    }
        //    else
        //    {

        //        string DBName = "DemoFAP";
        //        using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
        //        {
        //            DBCS = reader.ReadLine();
        //        }

        //    }



        public string GetDBName(string CCode)
        {
            SqlParameter[] objp = new SqlParameter[] {
                 new SqlParameter("@CCode",SqlDbType.VarChar,100)
            };
            objp[0].Value = CCode;
            return (ExecuteReader("SPGetDataBaseByCCode", objp).ToString());

        }


        public void xyz(string Clientcode)
        {

            // string DBName = "CopperHawk";

            //DataTable Dt = new DataTable();

            //Dt = da_obj_Branch.GetDBName(Clientcode);


            // DBName = Dt.Rows[0]["DBName"].ToString();
            string DBName = "CopperHawk";

            string connetionString;
            // SqlConnection Conn;
            connetionString = @"Data Source=ifreight.database.windows.net;Initial Catalog=CopperHawk;User ID=ifrtAdmin;pwd=05Jun!(&%;";
            Conn = new SqlConnection(connetionString);
            Conn.Open();

            if (!String.IsNullOrEmpty(Clientcode))
            {

                DBName = GetDBName(Clientcode);
            }

            Conn.Close();



            if (Clientcode != "")
            {
                //string DBName = "CopperHawk";

                //string connetionString;
                //SqlConnection cnn;
                //connetionString = @"Data Source=ifreight.database.windows.net;Initial Catalog=CopperHawk;User ID=ifrtAdmin;pwd=05Jun!(&%;";
                //cnn = new SqlConnection(connetionString);
                //cnn.Open();

                //if (!String.IsNullOrEmpty(Clientcode))
                //{
                //    DBName = GetDBName(Clientcode);
                //}

                //cnn.Close();







                DBCS = "Data Source=ifreight.database.windows.net;" + "Initial Catalog=" + DBName + ";" + "User ID=ifrtAdmin;" + "pwd=05Jun!(&%;";

                Conn = new SqlConnection(DBCS);

                //if (!String.IsNullOrEmpty(Clientcode))
                //{
                //    DBName = GetDBName(Clientcode);
                //}



                //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //{
                //    DBCS = reader.ReadLine();
                //}



                //  DataTable Dt = new DataTable();

                //Dt=  da_obj_Branch.GetDBName(Clientcode);


                //  DBName = Dt.Rows[0]["DBName"].ToString();

                //if (Clientcode == "SWENLOG")
                //{
                //    DBName = "SL";
                //    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //    //{
                //    //    DBCS = reader.ReadLine();
                //    //}
                //}
                //else if (Clientcode == "MARINAIR")
                //{
                //    DBName = "MarinAir";
                //    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //    //{
                //    //    DBCS = reader.ReadLine();
                //    //}
                //}
                //else if (Clientcode == "OCEANKARE")
                //{
                //    DBName = "OceanKare";
                //    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //    //{
                //    //    DBCS = reader.ReadLine();
                //    //}
                //}
                //else if (Clientcode == "DEMO")
                //{
                //    DBName = "DemoFAP";
                //}

                //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                //{
                //    DBCS = reader.ReadLine();
                //}

            }
            else
            {
                if (Clientcode == "")
                {
                    //string DBName = "CopperHawk";
                    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\" + DBName + "\\DB.txt"))
                    //{
                    //    DBCS = reader.ReadLine();
                    //}
                    //string connetionString;
                    //SqlConnection cnn;
                    connetionString = @"Data Source=ifreight.database.windows.net;Initial Catalog=CopperHawk;User ID=ifrtAdmin;pwd=05Jun!(&%;";
                    Conn = new SqlConnection(connetionString);
                    Conn.Open();
                    Conn.Close();

                }
            }




            //    //using (StreamReader reader = new StreamReader(@"C:\DataAccessLink-ConfirmBeforeDeletion\DemoFAP\DB.txt"))
            //    //{
            //    //    DBCS = reader.ReadLine();
            //    //}



















            //    //using (StreamReader reader = new StreamReader(@"dataacess\DemoFAP\DB.txt"))
            //    //{
            //    //    DBCS = reader.ReadLine();
            //    //}





            //    //DBCS = "Data Source=ifreight.database.windows.net;" + "Initial Catalog=DemoFAP;" + "User ID=ifrtAdmin;" + "pwd=05Jun!(&%;";

            //    //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=iNDPFAsKR;User ID=ltadmin;pwd=Acer0104#";    

            //    // DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=iNDPFAsKR;User ID=ltadmin;pwd=Acer0104#";
            //    //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=iNDPFAsKR;User ID=ltadmin;pwd=Acer0104#";     
            //    //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=FAMR;User ID=ltadmin;pwd=Acer0104#";     

            //    //   DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=Demo;User ID=ltadmin;pwd=Acer0104#";     

            //    //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=Demo;User ID=ltadmin;pwd=Acer0104#";

            //    //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=FAMR_2018-07-28T13-40Z;User ID=ltadmin;pwd=Acer0104#";
            //    //DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=Demo;User ID=ltadmin;pwd=Acer0104#";


            //    //  DBCS = "Data Source=sqlserverlt.database.windows.net;Initial Catalog=FAMR_2018-07-16T12-00Z;User ID=ltadmin;pwd=Acer0104#";  

            //    //------------------------------HOSTING DBCS_----------------------------------------------------------------------------//



            //    // DBCS = "Data Source=DINESH-PC\\SQLEXPRESS;Initial Catalog=FAMRNew;User ID=sa;pwd=FA123";


        }

        protected void ExecuteQuery(string SPName)
        {

            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Cmd = BuildQueryCommand(SPName);
            Cmd.CommandTimeout = 1000;
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }
        protected void ExecuteQuery(string SPName, IDataParameter[] parameters)
        {
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Cmd = BuildQueryCommand(SPName, parameters);
            Cmd.CommandTimeout = 1000;
            Cmd.ExecuteNonQuery();
            Conn.Close();
        }

        protected double ExecuteQuerydouble(string SPName, IDataParameter[] parameters, string output)
        {
            double Result;
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Cmd = BuildQueryCommand(SPName, parameters);
            Cmd.CommandTimeout = 1000;
            Cmd.ExecuteNonQuery();
            Result = double.Parse(Cmd.Parameters[output].Value.ToString());
            Conn.Close();
            return Result;
        }

        protected int ExecuteQuery(string SPName, IDataParameter[] parameters, string output)
        {
            int Result;
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Cmd = BuildQueryCommand(SPName, parameters);
            Cmd.CommandTimeout = 1000;
            Cmd.ExecuteNonQuery();
            Result = int.Parse(Cmd.Parameters[output].Value.ToString());
            Conn.Close();
            return Result;
        }
        protected string ExecuteQuery(string SPName, string output, IDataParameter[] parameters)
        {
            string Result;
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Cmd = BuildQueryCommand(SPName, parameters);
            Cmd.CommandTimeout = 1000;
            Cmd.ExecuteNonQuery();
            Result = Cmd.Parameters[output].Value.ToString();
            Conn.Close();
            return Result;
        }

        protected DataTable ExecuteTable(string SPName, IDataParameter[] parameters)
        {
            Dt = new DataTable();
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Adp = new SqlDataAdapter();
            Adp.SelectCommand = BuildQueryCommand(SPName, parameters);
            Cmd.CommandTimeout = 1000;
            Adp.Fill(Dt);
            Conn.Close();
            return Dt;
        }

        protected DataTable ExecuteTable(string SPName)
        {
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Ds = new DataSet();
            Cmd = new SqlCommand(SPName, Conn);
            Adp = new SqlDataAdapter(Cmd);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandTimeout = 1000;
            Adp.Fill(Ds);
            return Ds.Tables[0];
        }

        protected string ExecuteReader(string SPName, IDataParameter[] parameters)
        {
            string returnStr = "";
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            ////Cmd = BuildQueryCommand(SPName, parameters);
            ////Cmd.CommandTimeout = 1000;
            ////using (Reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection))
            ////{
            ////    while (Reader.Read())
            ////    {
            ////        returnStr = Reader[0].ToString();
            ////    }
            ////}
            ////Reader.Close();

            ////returnStr = returnStr.Equals("") ? "0" : returnStr;
            ////return returnStr;

            Dt = new DataTable();
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Adp = new SqlDataAdapter();
            Adp.SelectCommand = BuildQueryCommand(SPName, parameters);
            Cmd.CommandTimeout = 1000;
            Adp.Fill(Dt);
            Conn.Close();
            if (Dt.Rows.Count > 0)
            {
                returnStr = Dt.Rows[0].ItemArray[0].ToString();
            }
            returnStr = returnStr.Equals("") ? "0" : returnStr;
            return returnStr;
        }

        protected string ExecuteReader(string SPName)
        {
            string returnStr = "";
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            ////Cmd = new SqlCommand(SPName, Conn);
            ////Cmd.CommandType = CommandType.StoredProcedure;
            ////Cmd.CommandTimeout = 1000;
            ////using (Reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection))
            ////{
            ////    while (Reader.Read())
            ////    {
            ////        returnStr = Reader[0].ToString();
            ////    }
            ////}
            ////Reader.Close();
            ////return returnStr;
            Dt = new DataTable();
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Adp = new SqlDataAdapter();
            Adp.SelectCommand = BuildQueryCommand(SPName);
            Cmd.CommandTimeout = 1000;
            Adp.Fill(Dt);
            Conn.Close();
            if (Dt.Rows.Count > 0)
            {
                returnStr = Dt.Rows[0].ItemArray[0].ToString();
            }

            returnStr = returnStr.Equals("") ? "0" : returnStr;
            return returnStr;
        }




        //


        protected byte[] ExecuteReaderByte(string SPName, IDataParameter[] parameters)
        {
            Byte[] imgData1 = new Byte[64];
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            ////Cmd = BuildQueryCommand(SPName, parameters);
            ////Cmd.CommandTimeout = 1000;
            ////using (Reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection))
            ////{
            ////    while (Reader.Read())
            ////    {
            ////        returnStr = Reader[0].ToString();
            ////    }
            ////}
            ////Reader.Close();

            ////returnStr = returnStr.Equals("") ? "0" : returnStr;
            ////return returnStr;

            Dt = new DataTable();
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Cmd = BuildQueryCommand(SPName, parameters);
            SqlDataReader r = Cmd.ExecuteReader();

            if (r.Read())
            {
                if (!string.IsNullOrEmpty(r["touchclogo"].ToString()))
                {
                    imgData1 = (byte[])r["touchclogo"];
                }
            }


            Conn.Close();

            return imgData1;
        }





        protected SqlCommand BuildQueryCommand(string SPName, IDataParameter[] parameters)
        {
            Cmd = new SqlCommand(SPName, Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter;
            foreach (SqlParameter tempparameter in parameters)
            {
                parameter = tempparameter;
                Cmd.Parameters.Add(parameter);
            }
            Cmd.CommandTimeout = 1000;
            return Cmd;
        }
        protected SqlCommand BuildQueryCommand(string SPName)
        {
            Cmd = new SqlCommand(SPName, Conn);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandTimeout = 1000;
            return Cmd;
        }

        protected DataSet ExecuteDataSet(string SPName, IDataParameter[] parameters)
        {
            Ds = new DataSet();
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Adp = new SqlDataAdapter();
            Adp.SelectCommand = BuildQueryCommand(SPName, parameters);
            Cmd.CommandTimeout = 1000;
            Adp.Fill(Ds);
            Conn.Close();
            return Ds;
        }
        protected DataSet ExecuteDataSet(string SPName)
        {
            Ds = new DataSet();
            if (Conn.State == 0)
            {
                Conn.Open();
            }
            Adp = new SqlDataAdapter();
            Adp.SelectCommand = BuildQueryCommand(SPName);
            Cmd.CommandTimeout = 1000;
            Adp.Fill(Ds);
            Conn.Close();
            return Ds;
        }



    }
}
