using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ForwardingExports
{
    public class AmendBL : DBObject
    {

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public AmendBL()
        {
            Conn = new SqlConnection(DBCS);
        }
        public DataTable GetBLno(string strTranType, string blno, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strTranType;
            objp[1].Value = blno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetBLNo", objp);
        }

        public DataTable GetMBLno(string strTranType, string blno, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                        new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid", SqlDbType.TinyInt),
                                                        new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strTranType;
            objp[1].Value = blno;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetMBLNo", objp);
        }

        public void UpdAmendBL(string stroldblno, string strnewblno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]{ 
                                                      new SqlParameter("@oldblno",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@newblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt),
                                                      new SqlParameter("@cid",SqlDbType.TinyInt)
                                                    };
            objp[0].Value = stroldblno;
            objp[1].Value = strnewblno;
            objp[2].Value = trantype;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPAmendBL", objp);
        }


        public string GetMblForAmend(int jobno, string strtrantype, int branchid)
        {

            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@jobno",SqlDbType.Int,4),        
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,4),
                                                       new SqlParameter("@Tdbname", SqlDbType.VarChar,10),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = jobno;
            objp[1].Value = strtrantype;
            objp[2].Value = "FA" + branchid;
            objp[3].Value = branchid;
            return ExecuteReader("SPDCMBLno", objp);
        }

        //Bharath  --POTA

        public DataTable GetMBLnoToAmend(string strTranType, int intBranchID, string blno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@dbname", SqlDbType.VarChar, 10),
                                                        new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                        new SqlParameter("@bid",SqlDbType.TinyInt,1)};
            objp[0].Value = strTranType;
            objp[1].Value = "FA" + intBranchID;
            objp[2].Value = blno;
            objp[3].Value = intBranchID;
            // SPName = "SPGetMBLNoToAmend";
            return ExecuteTable("SPGetMBLNoToAmend", objp);
        }

        public void UpdAmendMBL(string stroldblno, string jobno, string strnewblno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[]{ new SqlParameter("@oldblno",SqlDbType.VarChar,30), 
                                                      new SqlParameter("@jobno",SqlDbType.Int),
                                                      new SqlParameter("@newblno",SqlDbType.VarChar,30),
                                                      new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                      new SqlParameter("@bid",SqlDbType.TinyInt,1)}
                                                        ;
            objp[0].Value = stroldblno;
            objp[1].Value = jobno;
            objp[2].Value = strnewblno;
            objp[3].Value = trantype;
            objp[4].Value = intBranchID;
            ExecuteQuery("SPAmendMBL", objp);
        }
        public DataTable GetReriveDetailsForMBLDraft(int jobno, int branchid)
        {
            SqlParameter[] array = new SqlParameter[2]
            {
            new SqlParameter("@jobno", SqlDbType.Int),
            new SqlParameter("@branchid", SqlDbType.Int)
            };
            array[0].Value = jobno;
            array[1].Value = branchid;
            return ExecuteTable("SPGetRetriveDetailsForDraft", array);
        }

        public DataTable GetReriveDetailsForMBLDraftNew(int jobno, int branchid)
        {
            SqlParameter[] array = new SqlParameter[2]
            {
            new SqlParameter("@jobno", SqlDbType.Int),
            new SqlParameter("@branchid", SqlDbType.Int)
            };
            array[0].Value = jobno;
            array[1].Value = branchid;
            return ExecuteTable("SPGetRetriveDetailsForDraftNew", array);
        }

        public void InsertForMblDraft(int jobno, int branchid, string vsl, string Shipper, string Consigne, string marks, string descn, string grweight, string ntweight, string freight, string cntrdetails, string poa, string pol, string pod, string fd, string cbm, string notify)
        {
            SqlParameter[] array = new SqlParameter[17]
            {
            new SqlParameter("@jobno", SqlDbType.Int),
            new SqlParameter("@branchid", SqlDbType.Int),
            new SqlParameter("@vslvoy", SqlDbType.VarChar, 100),
            new SqlParameter("@shipperaddress", SqlDbType.VarChar, 200),
            new SqlParameter("@consigneeaddress", SqlDbType.VarChar, 200),
            new SqlParameter("@marks", SqlDbType.VarChar, 1500),
            new SqlParameter("@descn", SqlDbType.VarChar, 4500),
            new SqlParameter("@grweight", SqlDbType.VarChar, 30),
            new SqlParameter("@ntweight", SqlDbType.VarChar, 30),
            new SqlParameter("@freight", SqlDbType.VarChar, 1),
            new SqlParameter("@cntrdetails", SqlDbType.VarChar, 8000),
            new SqlParameter("@poa", SqlDbType.VarChar, 30),
            new SqlParameter("@pol", SqlDbType.VarChar, 30),
            new SqlParameter("@pod", SqlDbType.VarChar, 30),
            new SqlParameter("@fd", SqlDbType.VarChar, 30),
            new SqlParameter("@cbm", SqlDbType.VarChar, 30),
            new SqlParameter("@notify", SqlDbType.VarChar, 200)
            };
            array[0].Value = jobno;
            array[1].Value = branchid;
            array[2].Value = vsl;
            array[3].Value = Shipper;
            array[4].Value = Consigne;
            array[5].Value = marks;
            array[6].Value = descn;
            array[7].Value = grweight;
            array[8].Value = ntweight;
            array[9].Value = freight;
            array[10].Value = cntrdetails;
            array[11].Value = poa;
            array[12].Value = pol;
            array[13].Value = pod;
            array[14].Value = fd;
            array[15].Value = cbm;
            array[16].Value = notify;
            ExecuteQuery("SPProcFEMBLDraftNew", array);
        }

        public void UpdateMblDraft(int jobno, int branchid, string vsl, string Shipper, string Consigne, string marks, string descn, string grweight, string ntweight, string freight, string cntrdetails, string poa, string pol, string pod, string fd, string cbm, string notify)
        {
            SqlParameter[] array = new SqlParameter[17]
            {
            new SqlParameter("@jobno", SqlDbType.Int),
            new SqlParameter("@branchid", SqlDbType.Int),
            new SqlParameter("@vslvoy", SqlDbType.VarChar, 100),
            new SqlParameter("@shipperaddress", SqlDbType.VarChar, 200),
            new SqlParameter("@consigneeaddress", SqlDbType.VarChar, 200),
            new SqlParameter("@marks", SqlDbType.VarChar, 1500),
            new SqlParameter("@descn", SqlDbType.VarChar, 4500),
            new SqlParameter("@grweight", SqlDbType.VarChar, 30),
            new SqlParameter("@ntweight", SqlDbType.VarChar, 30),
            new SqlParameter("@freight", SqlDbType.VarChar, 1),
            new SqlParameter("@cntrdetails", SqlDbType.VarChar, 8000),
            new SqlParameter("@poa", SqlDbType.VarChar, 30),
            new SqlParameter("@pol", SqlDbType.VarChar, 30),
            new SqlParameter("@pod", SqlDbType.VarChar, 30),
            new SqlParameter("@fd", SqlDbType.VarChar, 30),
            new SqlParameter("@cbm", SqlDbType.VarChar, 30),
            new SqlParameter("@notify", SqlDbType.VarChar, 200)
            };
            array[0].Value = jobno;
            array[1].Value = branchid;
            array[2].Value = vsl;
            array[3].Value = Shipper;
            array[4].Value = Consigne;
            array[5].Value = marks;
            array[6].Value = descn;
            array[7].Value = grweight;
            array[8].Value = ntweight;
            array[9].Value = freight;
            array[10].Value = cntrdetails;
            array[11].Value = poa;
            array[12].Value = pol;
            array[13].Value = pod;
            array[14].Value = fd;
            array[15].Value = cbm;
            array[16].Value = notify;
            ExecuteQuery("UpdateMblDraftNew", array);
        }

    }
}
