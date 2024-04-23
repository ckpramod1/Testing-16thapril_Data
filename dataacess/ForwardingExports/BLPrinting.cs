using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ForwardingExports
{
    public class BLPrinting: DBObject
    {
        DataAccess.Masters.MasterCustomer custobj = new DataAccess.Masters.MasterCustomer();


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public BLPrinting()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetBLPrintingDt(string strBlno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
                                                                           
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPSelBLPrintingDt", objp);
        }


        public DataTable GetBLPrintInvDt(string strBlno, string trantype,int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLPrintInvDt", objp);
        }



        public DataTable GetBLPrintOtherDNDt(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLPrintOtherDNDt", objp);
        }

        public DataTable GetBLPrintOtherCNDt(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };

            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLPrintOtherCNDt", objp);
        }

        public DataTable GetBLPrintRcptDt(string strBlno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = branchid;
            return ExecuteTable("SPSelBLPrintRcptDt", objp);
        }

        public DataTable GetBLPrintrcptcheck(string strBlno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = branchid;
            return ExecuteTable("SPSelBLPrintrcptcheck", objp);
        }
        public DataTable GetSCDt(string customername, string trantype, string custtypename, int intBranchID, int intDivisionID)
        {
            string custtype = "";
            if ((trantype == "FE") || (trantype == "AE"))
            {
                custtype = "C";
            }
            else
            {
                custtype = "C";
            }
            int custid = custobj.GetCustomeridwcusttype(customername, custtype);
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@customerid", SqlDbType.Int,4),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@custtypename", SqlDbType.VarChar, 15),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = custid;
            objp[1].Value = trantype;
            objp[2].Value = custtypename;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            return ExecuteTable("SPGetSCDetails", objp);
        }

        public DataTable GetSCDtMBL(string mblno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@mblno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = mblno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetSCDetailsMBL", objp);
        }

        public DataTable GetSCDtMAWBL(string mawblno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@mawblno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = mawblno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetSCDetailsMAWBL", objp);
        }

        public DataTable GetSCDtFlight(string flightno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@flightno", SqlDbType.VarChar,30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = flightno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetSCDetailsFlight", objp);
        }


        public DataTable GetSCDtCont(string containerno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@containerno", SqlDbType.VarChar,12),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };

            objp[0].Value = containerno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPGetSCDetailsCont", objp);
        }


        public DataTable GetCBMTues(int jobno, string strBlno, string jobtype, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@jobtype", SqlDbType.VarChar, 10),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = jobno;
            objp[1].Value = strBlno;
            objp[2].Value = jobtype;
            objp[3].Value = trantype;
            objp[4].Value = intBranchID;
            objp[5].Value = intDivisionID;
            return ExecuteTable("SPGetCbmWJobtype", objp);
        }

        ////public void UpdCNFFI(string blno, string cnf, int intBranchID, int DOIssuedBy, int intDivisionID)
        ////{
        ////    string custtype = "C";
        ////    int custid = custobj.GetCustomeridwcusttype(cnf, custtype);
        ////    SqlParameter[] objp = new SqlParameter[]
        ////                                            {
        ////                                                    new SqlParameter("@blno",SqlDbType.VarChar,30),
        ////                                                    new SqlParameter("@cnfid",SqlDbType.Int,4),
        ////                                                    new SqlParameter("@doissuedby",SqlDbType.Int),
        ////                                                    new SqlParameter("@bid", SqlDbType.TinyInt),
        ////                                                    new SqlParameter("@cid", SqlDbType.TinyInt)
        ////                                            };
        ////    objp[0].Value = blno;
        ////    objp[1].Value = custid;
        ////    objp[2].Value = DOIssuedBy;
        ////    objp[3].Value = intBranchID;
        ////    objp[4].Value = intDivisionID;
        ////    ExecuteQuery("SPUpdFICNF", objp);        
        ////}
        //KUMAR   For CNF ID         //START 31-01-2012
        public void UpdCNFFI(string blno, int cnfID, int intBranchID, int DOIssuedBy, int intDivisionID)
        {
            //string custtype = "C";
            //int custid = custobj.GetCustomeridwcusttype(cnf, custtype);
            SqlParameter[] objp = new SqlParameter[]
                                                    {
                                                            new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                            new SqlParameter("@cnfid",SqlDbType.Int,4),
                                                            new SqlParameter("@doissuedby",SqlDbType.Int),
                                                            new SqlParameter("@bid", SqlDbType.TinyInt),
                                                            new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = blno;
            objp[1].Value = cnfID;
            objp[2].Value = DOIssuedBy;
            objp[3].Value = intBranchID;
            objp[4].Value = intDivisionID;
            ExecuteQuery("SPUpdFICNF", objp);
        }
        //KUMAR   For CNF ID         //END 31-01-2012
        public DataTable GetBLQuery(string strBlNo, int intBranchID, int intDivisionID)
        {
            string strTempDBName = GetBLDBName(strBlNo,intBranchID,intDivisionID);
            if (strTempDBName != "")
            {
                SqlParameter[] objp = new SqlParameter[] { 
                                                               new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                               new SqlParameter("@bid", SqlDbType.TinyInt),
                                                               new SqlParameter("@cid", SqlDbType.TinyInt)
                                                         };
                objp[0].Value = strBlNo;
                objp[1].Value = intBranchID;
                objp[2].Value = intDivisionID;
                Dt = ExecuteTable("SPFIBLQuery", objp);
            }
            else

                Dt = null;
            return Dt;
        }

        public DataTable GetBLQueryInvoice(string strBlNo, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                          new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                          new SqlParameter("@bid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = GetBLDBName(strBlNo,intBranchID,intDivisionID);
            objp[1].Value = intBranchID;
            return ExecuteTable("SPFIBLQryInvDetail", objp);
        }

        public DataTable GetBLQueryShipperName(string strBlNo,int intBranchID, int intDivisionID)
        {
            string strTempDBName = GetBLDBName(strBlNo,intBranchID,intDivisionID);
            SqlParameter[] objp = new SqlParameter[] 
                                                    { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                    };
            objp[0].Value = strBlNo;
            objp[1].Value = intBranchID;
            objp[2].Value = intDivisionID;
            return ExecuteTable("SPFIBLQrySprName", objp);
        }

        public string GetBLDBName(string strBLNo, int intBranchID, int intDivisionID)
        {
            string strTemp = "";
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@trantype",SqlDbType.VarChar,2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strBLNo;
            objp[1].Value = "FI";
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            Dt = ExecuteTable("SPSelBranchByBLNo", objp);
            if (Dt.Rows.Count > 0)
            {
                strTemp = "FA" + Dt.Rows[0][0].ToString();
            }
            return strTemp;
        }

        public DataTable GetBLQryContainerDtl(int intJobNo, string strBLNo,int intBranchID, int intDivisionID)
        {
            string strTempDBName = GetBLDBName(strBLNo,intBranchID,intDivisionID);
            SqlParameter[] objp = new SqlParameter[] 
                                                      { 
                                                           new SqlParameter("@jobno",SqlDbType.Int),
                                                           new SqlParameter("@blno",SqlDbType.VarChar,30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                      };
            objp[0].Value = intJobNo;
            objp[1].Value = strBLNo;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPFIContDtls", objp);
        }

        public DataTable GetLikeContno(string strContno, string trantype, int intBranchID, int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@containerno", SqlDbType.VarChar, 10),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = strContno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPLikeContno", objp);
        }


        public DataTable GetLikeALLBranchContno(string strContno, string trantype, int empid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@contno", SqlDbType.VarChar, 15),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@empid", SqlDbType.Int)
                                                     };
            objp[0].Value = strContno;
            objp[1].Value = trantype;
            objp[2].Value = empid;
            return ExecuteTable("SPLikeALLBranchContNo", objp);
        }


        public DataTable GetLikeFlightno(string flightno, string trantype, int intBranchID,int intDivisionID)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@flightno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt)
                                                     };
            objp[0].Value = flightno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            return ExecuteTable("SPLikeAIEFlightno", objp);
        }

        public DataTable GetBLPrintPADt(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLPrintPADt", objp);
        }

        public DataTable GetBLFreightDetails(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@branchid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPGetAllFreightDetails", objp);
        }
        public DataTable GetLikeSalesContno(string strContno, string trantype, int intBranchID, int intDivisionID, int salesid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@containerno", SqlDbType.VarChar, 10),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt),
                                                           new SqlParameter("@cid", SqlDbType.TinyInt),
                                                           new SqlParameter ("@salesid",SqlDbType .Int ,4)  
                                                     };
            objp[0].Value = strContno;
            objp[1].Value = trantype;
            objp[2].Value = intBranchID;
            objp[3].Value = intDivisionID;
            objp[4].Value = salesid;
            return ExecuteTable("SPLikeSalesNContno", objp);
        }


        public DataTable GetBLPrintDNDt(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLPrintDNDt", objp);
        }
        public DataTable getMothervslDtls(string bookingno, int bid, int cid)
        {
            SqlParameter[] objp = new SqlParameter[]
            {
                new SqlParameter("@bookingno",SqlDbType.VarChar,30),
                new SqlParameter("@bid",SqlDbType.TinyInt),
                new SqlParameter("@cid",SqlDbType.TinyInt)

            };
            objp[0].Value = bookingno;
            objp[1].Value = bid;
            objp[2].Value = cid;
            return ExecuteTable("SPGetMvesselDtls", objp);

        }
        //RAJA FOR INVOICE CHECK
        public DataTable GetBLPrintInvDtCHK(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLPrintInvDt4chk", objp);
        }
        public DataTable GetBLPrintRcptDtchk(string strBlno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = branchid;
            return ExecuteTable("SPSelBLPrintRcptDtchk", objp);
        }
        //Dinesh

        public DataTable GetBLContDesuffOtNot(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLContDesuffOtNot", objp);
        }
        public string GetFlightNum(string flightno, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {new SqlParameter("@flightno",SqlDbType.VarChar,30),
                new SqlParameter("@trantype", SqlDbType.VarChar,2)
              };

            objp[0].Value = flightno;
            objp[1].Value = trantype;
            return ExecuteReader("SpGetFlightNum", objp);
        }

        public DataSet Getgsk(int customerid, int jobno, string trantype, int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
                        {
                            new SqlParameter("@customerid",SqlDbType.Int,4),
                             new SqlParameter("@jobno",SqlDbType.Int,4),
                             new SqlParameter("@trantype",SqlDbType.VarChar ,4),
                              new SqlParameter("@bid",SqlDbType.Int,4)
                        };
            objp[0].Value = customerid;
            objp[1].Value = jobno;
            objp[2].Value = trantype;
            objp[3].Value = bid;

            return ExecuteDataSet("spgsk", objp);
        }


        public DataTable GetBLPrintInvDt4JobClose(string strBlno, string trantype, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = strBlno;
            objp[1].Value = trantype;
            objp[2].Value = branchid;
            return ExecuteTable("SPSelBLPrintInvDt4JobClose", objp);

        }

        public DataTable SP_BLPRINT(string Blno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = Blno;
            objp[1].Value = branchid;

            return ExecuteTable("SP_BLPRINT", objp);
        }

        public DataTable SP_BLPRINTAI(string Blno, int branchid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                           new SqlParameter("@blno", SqlDbType.VarChar, 30),
                                                           new SqlParameter("@bid", SqlDbType.TinyInt, 1)
                                                     };
            objp[0].Value = Blno;
            objp[1].Value = branchid;

            return ExecuteTable("SP_BLPRINTAI", objp);
        }

        // yuvaraj 30-12-2022
        public DataTable getsp_salespersonget(string blno)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@blno",SqlDbType.VarChar,50),
               
              };

            objp[0].Value = blno;

            return ExecuteTable("sp_salespersonget", objp);
        }

    }
}
