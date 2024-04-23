using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Windows.Forms.LinkLabel;

// FAConn is the class from which all classes in the Data Services Tier
// inherit. The core functionality of establishing a connection with the
// database and executing  stored procedures is  provided by
// this base class.
// ---
namespace DataAccess
{
    public class FAConn
    {
        //Object declaration for connection-based classes.
        protected SqlConnection Conn;
        protected SqlCommand Cmd;
        protected SqlDataAdapter Adp;
        protected SqlDataReader Reader;
        //Object declaration for content-based classes.
        protected DataSet Ds;
        protected DataTable Dt;
        protected DataColumn Dc;
        protected DataRow Dr;


        protected string Clientcode;

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;

            //xyz(Clientcode); 
            //DataAccess.DBObject dBObject = new DataAccess.DBObject();




        }
    }
}
