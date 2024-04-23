using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.ForwardingImports
{
    public class DODetails : DBObject
    {
        Masters.MasterCustomer CustObj = new DataAccess.Masters.MasterCustomer();
        public string SPName;

        //Update CNF and CFS in BLDetails.

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public DODetails()
        {
            Conn = new SqlConnection(DBCS);
        }

        public void UpdateBLDetailCust(string blno, string cfs, string cnf, string cfslocation, string cnflocation, int intBranchID, int intDivisionID)
        {
            int cfsid = CustObj.GetCustomerid(cfs, "CFS", cfslocation);
            int cnfid = CustObj.GetCustomerid(cnf, "CHA / CNF", cnflocation);

            SqlParameter[] objp = new SqlParameter[] { 
                                                         new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                         new SqlParameter("@cfs",SqlDbType.Int,4),
                                                         new SqlParameter("@cnf",SqlDbType.Int,4),
                                                         new SqlParameter("@bid", SqlDbType.TinyInt),
                                                         new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = blno;
            objp[1].Value = cfsid;
            objp[2].Value = cnfid;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPUpdCustOIBLDetails", objp);
        }
    }
}