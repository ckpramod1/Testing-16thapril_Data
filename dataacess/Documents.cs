using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class Documents : DBObject
    {


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Documents()
        {
            Conn = new SqlConnection(DBCS);
        }
        //public string InsDocuments(int BranchID, string Trantype, int JobNo, int DocType,string Remarks)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
        //                                               new SqlParameter("@trantype", SqlDbType.VarChar, 2),
        //                                               new SqlParameter("@jobno", SqlDbType.Int, 4),
        //                                               new SqlParameter("@doctype", SqlDbType.Int, 4),
        //                                               new SqlParameter("@remarks", SqlDbType.VarChar, 30),
        //                                               new SqlParameter("@docid",SqlDbType.Int,4),};
        //    objp[0].Value = BranchID;
        //    objp[1].Value = Trantype;
        //    objp[2].Value = JobNo;
        //    objp[3].Value = DocType;
        //    objp[4].Value = Remarks;
        //    objp[5].Direction  = ParameterDirection.Output;

        //    return ExecuteQuery("SPInsDocDtls", "@docid", objp);
        //}

        //public string InsDocuments(int BranchID, string Trantype, int JobNo, int DocType, string Remarks, string pathtype, string pathothers, int empid, string recgid, string docdate)
        //{
        //    SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
        //                                               new SqlParameter("@trantype", SqlDbType.VarChar, 2),
        //                                               new SqlParameter("@jobno", SqlDbType.Int, 4),
        //                                               new SqlParameter("@doctype", SqlDbType.Int, 4),
        //                                               new SqlParameter("@remarks", SqlDbType.VarChar, 30),
        //                                               new SqlParameter("@docid",SqlDbType.Int,4),
        //          new SqlParameter("@pathtype", SqlDbType.VarChar, 50),
        //          new SqlParameter("@pathothers", SqlDbType.VarChar, 50),
        //          new SqlParameter("@empid", SqlDbType.Int, 4),
        //         new SqlParameter("@recgid", SqlDbType.VarChar, 50),
        //            new SqlParameter("@docdate", SqlDbType.VarChar, 50)
        //    };
        //    objp[0].Value = BranchID;
        //    objp[1].Value = Trantype;
        //    objp[2].Value = JobNo;
        //    objp[3].Value = DocType;
        //    objp[4].Value = Remarks;

        //    objp[5].Direction = ParameterDirection.Output;
        //    objp[6].Value = pathtype;
        //    objp[7].Value = pathothers;
        //    objp[8].Value = empid;
        //    objp[9].Value = recgid;
        //    objp[10].Value = docdate;
        //    //objp[8].Value = rgdocno;
        //    return ExecuteQuery("SPInsDocDtls", "@docid", objp);
        //}
        public string InsDocuments(int BranchID, string Trantype, int JobNo, int DocType, string Remarks, string pathtype, string pathothers, int empid, string recgid, string docdate, string alltype, string updateondate)//,string alltype,string updateondate
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4),
                                                       new SqlParameter("@doctype", SqlDbType.Int, 4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 30),
                                                       new SqlParameter("@docid",SqlDbType.Int,4),
                  new SqlParameter("@pathtype", SqlDbType.VarChar, 300),
                  new SqlParameter("@pathothers", SqlDbType.VarChar, 300),
                  new SqlParameter("@empid", SqlDbType.Int, 4),
                 new SqlParameter("@recgid", SqlDbType.VarChar, 50),
                    new SqlParameter("@docdate", SqlDbType.VarChar, 1500),
                new SqlParameter("@alltype", SqlDbType.VarChar, 1500),
                new SqlParameter("@docupdon", SqlDbType.VarChar, 50)
            };
            objp[0].Value = BranchID;
            objp[1].Value = Trantype;
            objp[2].Value = JobNo;
            objp[3].Value = DocType;
            objp[4].Value = Remarks;

            objp[5].Direction = ParameterDirection.Output;
            objp[6].Value = pathtype;
            objp[7].Value = pathothers;
            objp[8].Value = empid;
            objp[9].Value = recgid;
            objp[10].Value = docdate;
            objp[11].Value = alltype;
            objp[12].Value = updateondate;
            //objp[8].Value = rgdocno;
            return ExecuteQuery("SPInsDocDtls", "@docid", objp);
        }

        public string InsDocumentsnew(int BranchID, string Trantype, int JobNo, int DocType, string Remarks, string pathtype, string pathothers, int empid, string recgid, string docdate, string alltype, string updateondate, int uiid, string refno, string voutype, int voutypeid)
        {
            SqlParameter[] array = new SqlParameter[17]
            {
            new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
            new SqlParameter("@trantype", SqlDbType.VarChar, 2),
            new SqlParameter("@jobno", SqlDbType.Int, 4),
            new SqlParameter("@doctype", SqlDbType.Int, 4),
            new SqlParameter("@remarks", SqlDbType.VarChar, 30),
            new SqlParameter("@docid", SqlDbType.Int, 4),
            new SqlParameter("@pathtype", SqlDbType.VarChar, 50),
            new SqlParameter("@pathothers", SqlDbType.VarChar, 50),
            new SqlParameter("@empid", SqlDbType.Int, 4),
            new SqlParameter("@recgid", SqlDbType.VarChar, 50),
            new SqlParameter("@docdate", SqlDbType.VarChar, 1500),
            new SqlParameter("@alltype", SqlDbType.VarChar, 1500),
            new SqlParameter("@docupdon", SqlDbType.VarChar, 50),
            new SqlParameter("@uiid", SqlDbType.Int),
            new SqlParameter("@refno", SqlDbType.VarChar, 30),
            new SqlParameter("@voutype", SqlDbType.VarChar, 30),
            new SqlParameter("@voutypeid", SqlDbType.Int, 4)
            };
            array[0].Value = BranchID;
            array[1].Value = Trantype;
            array[2].Value = JobNo;
            array[3].Value = DocType;
            array[4].Value = Remarks;
            array[5].Direction = ParameterDirection.Output;
            array[6].Value = pathtype;
            array[7].Value = pathothers;
            array[8].Value = empid;
            array[9].Value = recgid;
            array[10].Value = docdate;
            array[11].Value = alltype;
            array[12].Value = updateondate;
            array[13].Value = uiid;
            array[14].Value = refno;
            array[15].Value = voutype;
            array[16].Value = voutypeid;
            IDataParameter[] array2 = array;
            IDataParameter[] parameters = array2;
            return ExecuteQuery("SPInsDocDtls", "@docid", parameters);
        }

        public DataTable GetDocDtls4RecGurunew(int bid, string trantype, int jobno, string refno)
        {
            SqlParameter[] array = new SqlParameter[4]
            {
    new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
    new SqlParameter("@trantype", SqlDbType.VarChar, 2),
    new SqlParameter("@jobno", SqlDbType.Int, 4),
    new SqlParameter("@refno", SqlDbType.VarChar, 100)
            };
            array[0].Value = bid;
            array[1].Value = trantype;
            array[2].Value = jobno;
            array[3].Value = refno;
            IDataParameter[] parameters = array;
            return ExecuteTable("SPGetDocDtls4RecGurunew", parameters);
        }

        public DataTable cnops_reportview(string refno, int branchid, string trantype)
        {
            SqlParameter[] array = new SqlParameter[3]
            {
            new SqlParameter("@refno", SqlDbType.VarChar, 30),
            new SqlParameter("@branchid", SqlDbType.Int),
            new SqlParameter("@trantype", SqlDbType.VarChar, 2)
            };
            array[0].Value = refno;
            array[1].Value = branchid;
            array[2].Value = trantype;
            IDataParameter[] array2 = array;
            IDataParameter[] parameters = array2;
            return ExecuteTable("sp_cnops_reportview", parameters);
        }

        public string ddldoctypename(string ddltype)
        {
            SqlParameter[] array = new SqlParameter[1]
            {
            new SqlParameter("@docname", SqlDbType.VarChar, 30)
            };
            array[0].Value = ddltype;
            IDataParameter[] array2 = array;
            IDataParameter[] parameters = array2;
            return ExecuteReader("SPSelDoctypename", parameters);
        }

        public DataTable GetDocDtls(int Branchid, string Trantype, int JobNo)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@jobno", SqlDbType.Int, 4) };
            objp[0].Value = Branchid;
            objp[1].Value = Trantype;
            objp[2].Value = JobNo;
            return ExecuteTable("SPGetDocDtls", objp);
        }
                
        public DataTable GetDocImg(int DocID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int, 4) };
            objp[0].Value = DocID;
            return ExecuteTable("SPGetDocImg", objp);
        }

        public DataTable GetJobDtls4CODoc(int branchid,string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};
            
            objp[0].Value = trantype;
            objp[1].Value = branchid;
            return ExecuteTable("SPDocJobDtls", objp);
        }
        public DataTable GetJobDtls4CODocUP(int branchid, string trantype)
        {
            SqlParameter[] objp = new SqlParameter[] {  new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                        new SqlParameter("@branchid",SqlDbType.TinyInt,1)};

            objp[0].Value = trantype;
            objp[1].Value = branchid;
            return ExecuteTable("SPDocJobDtls4Up", objp);
        }
        public void UpdDocument(int DocID, int DocType,  string Remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int, 4),
                                                       new SqlParameter("@doctype", SqlDbType.Int, 4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 30)};
            objp[0].Value = DocID;
            objp[1].Value = DocType;
            objp[2].Value = Remarks;
            ExecuteQuery("SPUpdDocDtls", objp);
        }

        public void DelDocument(int DocID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int, 4) };
            objp[0].Value = DocID;
            ExecuteQuery("SPDelDocument", objp);
        }
        public string GetShortname(int Branchid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1)
                                                        };
            objp[0].Value = Branchid;
            return (ExecuteReader("SPGetShortname", objp));
        }
        public void UpdShortname(int docid, string filename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int, 4),
                                                       new SqlParameter("@filename", SqlDbType.VarChar, 300)
                                                        };
            objp[0].Value = docid;
            objp[1].Value = filename; 

            ExecuteQuery("SPUPdDocfilename", objp);
        }
        public void InsDocumentDup(int DocID)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int, 4) };
            objp[0].Value = DocID;
            ExecuteQuery("SPInsDocumentDup", objp);
        }



        //its added only to  DOCuments

        public void UpdShortNameRecGuru(int docuid, string filename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int, 4),
                                                       new SqlParameter("@filename", SqlDbType.VarChar, 300)
                                                        };
            objp[0].Value = docuid;
            objp[1].Value = filename;

            ExecuteQuery("SPUPdDocfilenameupld", objp);
        }

        //Get Records for RecordsGuru
        public DataTable GetDocDtls4RecGuru(int bid, string trantype, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@branchid",SqlDbType.TinyInt,1),                                                     
                                                         new SqlParameter("@trantype", SqlDbType.VarChar, 2),
               new SqlParameter("@jobno", SqlDbType.Int, 4)                                                     
                                                        };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = jobno;
            return ExecuteTable("SPGetDocDtls4RecGuru", objp);
        }

        //Dinesh
        public void Getdeleteftpdile(int docid, int branchid, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@jobno", SqlDbType.Int) };
            objp[0].Value = docid;
            objp[1].Value = branchid;
            objp[2].Value = jobno;
            ExecuteQuery("sp_deleteftpdile", objp);
        }



        public string InsebookingDocuments(int BranchID, string Trantype, string ebookingno, int DocType, string Remarks, string pathtype, string pathothers, string username, string recgid, string docdate, string alltype, string updateondate, int webgroupid, int customerid, int shipperid, int consigneeid, int notifypartyid)//,string alltype,string updateondate
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@branchid", SqlDbType.TinyInt, 1),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar, 2),
                                                       new SqlParameter("@ebookingno", SqlDbType.VarChar, 100),
                                                       new SqlParameter("@doctype", SqlDbType.Int, 4),
                                                       new SqlParameter("@remarks", SqlDbType.VarChar, 30),
                                                      
                  new SqlParameter("@pathtype", SqlDbType.VarChar, 300),
                  new SqlParameter("@pathothers", SqlDbType.VarChar, 300),
                  new SqlParameter("@username",SqlDbType.VarChar, 300),
                 new SqlParameter("@recgid", SqlDbType.VarChar, 50),
                    new SqlParameter("@docdate", SqlDbType.VarChar, 1500),
                new SqlParameter("@alltype", SqlDbType.VarChar, 1500),
                new SqlParameter("@docupdon", SqlDbType.VarChar, 50),
                 new SqlParameter("@webgroupid", SqlDbType.Int, 4),
                   new SqlParameter("@shipperid", SqlDbType.Int, 4),
                 new SqlParameter("@customerid", SqlDbType.Int, 4),
                  new SqlParameter("@consigneeid", SqlDbType.Int, 4),
                   new SqlParameter("@notifypartyid", SqlDbType.Int, 4),
                    new SqlParameter("@docid",SqlDbType.Int,4)
            };
            objp[0].Value = BranchID;
            objp[1].Value = Trantype;
            objp[2].Value = ebookingno;
            objp[3].Value = DocType;
            objp[4].Value = Remarks;          
            objp[5].Value = pathtype;
            objp[6].Value = pathothers;
            objp[7].Value = username;
            objp[8].Value = recgid;
            objp[9].Value = docdate;
            objp[10].Value = alltype;
            objp[11].Value = updateondate;
            objp[12].Value = webgroupid;
            objp[13].Value = customerid;
            objp[14].Value = shipperid;
            objp[15].Value = consigneeid;
            objp[16].Value = notifypartyid;
            objp[17].Direction = ParameterDirection.Output;
            //objp[8].Value = rgdocno;
            return ExecuteQuery("SPInsebookingdocdocumentsdocDtls", "@docid", objp);
        }





        public void updatefileforEbooking(int docuid, string filename)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int, 4),
                                                       new SqlParameter("@filename", SqlDbType.VarChar, 300)
                                                        };
            objp[0].Value = docuid;
            objp[1].Value = filename;

            ExecuteQuery("SPUPdDocebookingfilenameupld", objp);
        }



        //Get Records for RecordsGuru
        public DataTable GetDocDtls4ebooking(int bid, string trantype, string ebookingno)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@branchid",SqlDbType.TinyInt,1),                                                     
                                                         new SqlParameter("@trantype", SqlDbType.VarChar, 2),
               new SqlParameter("@ebookingno", SqlDbType.VarChar, 100),    
                             
                                                        };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = ebookingno;
            return ExecuteTable("SPGetEbookingDOCDocumentsDtls", objp);
        }



        //Dinesh
        public void Geteboookingdeleteftpdile(int docid, int branchid, string bookingno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@docid", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@ebookno", SqlDbType.VarChar, 50)};
            objp[0].Value = docid;
            objp[1].Value = branchid;
            objp[2].Value = bookingno;
            ExecuteQuery("sp_eboookingdeleteftpdile", objp);
        }



        public String getloctdetails(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = custid;

            return ExecuteReader("spgetloctdetails", objp);
        }

        public String getinsmastergstdetailsMR(int cid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@cid", SqlDbType.Int) };
            objp[0].Value = cid;

            return ExecuteReader("spinsmastergstdetailsMR", objp);
        }

        public String getunregcustvouchers(int vouno, int vouyear, int bid, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@vouno", SqlDbType.Int) ,
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.Int),
                                                         new SqlParameter("@voutype", SqlDbType.VarChar,1),
            
            };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = bid;
            objp[3].Value = voutype;
            return ExecuteReader("spgetunregcustvouchers", objp);
        }


        //GST changes IRN
        public string getgstdetails(int vouno, int bid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@vouno",SqlDbType.Int),                                                     
                                                        new SqlParameter("@bid",SqlDbType.Int),  
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                       
                                                        new SqlParameter("@voutype", SqlDbType.VarChar, 10)
                                                                
                                                        };
            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;

            objp[3].Value = voutype;
            return ExecuteReader("sp_getgstindetjsonliveInv", objp);

        }






        public void insmastergstdetails(int vouno, int vouyear, int bid, int cid, string status, string message,
             string Irn, string AckDt, string AckNo, string Status1, string SignedQRCode, string SignedInvoice, string uuid, string SignedQrCodeImgUrl, string IrnStatus, string EwbStatus,
            string Irp, string voutype, string EwbDt, string EwbNo, string EwbValidTill, string Remarks)
        {
            SqlParameter[] objp = new SqlParameter[] { 
                                                       new SqlParameter("@vouno", SqlDbType.Int),
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                       new SqlParameter("@bid",  SqlDbType.Int),
                                                       new SqlParameter("@cid", SqlDbType.Int),
                                                        new SqlParameter("@status", SqlDbType.NVarChar,5000),
                                                         new SqlParameter("@message", SqlDbType.NVarChar,5000),
                                                        
                                                          new SqlParameter("@Irn", SqlDbType.NVarChar,5000),
                                                             new SqlParameter("@AckDt", SqlDbType.NVarChar,5000),
                                                               new SqlParameter("@AckNo", SqlDbType.NVarChar,5000),
                                                                  new SqlParameter("@Status1", SqlDbType.NVarChar,5000),
                                                                   new SqlParameter("@SignedQRCode", SqlDbType.NVarChar,5000),
                                                                         new SqlParameter("@SignedInvoice", SqlDbType.NVarChar,5000),
                                                                           new SqlParameter("@uuid", SqlDbType.NVarChar,5000),
                                                                             new SqlParameter("@SignedQrCodeImgUrl", SqlDbType.NVarChar,5000),
                                                                            new SqlParameter("@IrnStatus", SqlDbType.NVarChar,5000),
                                                                               new SqlParameter("@EwbStatus", SqlDbType.NVarChar,5000),
                                                                                            new SqlParameter("@Irp", SqlDbType.NVarChar,5000),
                                                                                            new SqlParameter("@voutype", SqlDbType.NVarChar,5000),


                                                                                             new SqlParameter("@EwbDt", SqlDbType.NVarChar,5000),
                                                                             new SqlParameter("@EwbNo", SqlDbType.NVarChar,5000),
                                                                            new SqlParameter("@EwbValidTill", SqlDbType.NVarChar,5000),
                                                                               new SqlParameter("@Remarks", SqlDbType.NVarChar,5000),
                                                                          


                                                     };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = bid;
            objp[3].Value = cid;
            objp[4].Value = status;
            objp[5].Value = message;

            objp[6].Value = Irn;
            objp[7].Value = AckDt;
            objp[8].Value = AckNo;
            objp[9].Value = Status1;
            objp[10].Value = SignedQRCode;
            objp[11].Value = SignedInvoice;
            objp[12].Value = uuid;
            objp[13].Value = SignedQrCodeImgUrl;
            objp[14].Value = IrnStatus;
            objp[15].Value = EwbStatus;
            objp[16].Value = Irp;
            objp[17].Value = voutype;
            objp[18].Value = EwbDt;
            objp[19].Value = EwbNo;
            objp[20].Value = EwbValidTill;
            objp[21].Value = Remarks;



            ExecuteQuery("spinsmastergstdetails", objp);
        }

        public DataTable GetPendingGSTDetails(int bid)
        {
            SqlParameter[] objp = new SqlParameter[]
                                 {
                                     new SqlParameter("@bid",SqlDbType.Int),
                                    
                                 };
            objp[0].Value = bid;

            return ExecuteTable("spgetgstdetails4vou", objp);
        }

        public DataTable GetCompletedGSTDetails(int bid, DateTime From, DateTime To)
        {
            SqlParameter[] objp = new SqlParameter[]
                                 {
                                     new SqlParameter("@bid",SqlDbType.TinyInt),
                                     new SqlParameter("@From",SqlDbType.SmallDateTime,4),
                                     new SqlParameter("@To",SqlDbType.SmallDateTime,4)
                                 };
            objp[0].Value = bid;
            objp[1].Value = From;
            objp[2].Value = To;

            return ExecuteTable("GetCompletedGSTDetails", objp);
        }


        public DataTable getdetails4gstdetails(int branchid, int invoiceno, int vouyear, string bltype)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@bid",SqlDbType.Int, 4),
                                                      
                                                       new SqlParameter("@vouno", SqlDbType.Int, 4),
                                                       new SqlParameter("@vouyear",SqlDbType.Int, 4),
                                                       new SqlParameter("@bltype", SqlDbType.VarChar,1),
                                                     
                                                     };
            objp[0].Value = branchid;
            objp[1].Value = invoiceno;
            objp[2].Value = vouyear;
            objp[3].Value = bltype;

            return ExecuteTable("spgetdetails4gstdetails", objp);


        }

        public DataTable Getgstdetails4voushedule()
        {
            SqlParameter[] objp = new SqlParameter[]
                                 {
                                
                                    
                                 };


            return ExecuteTable("spgetgstdetails4voushedule", objp);
        }

        public String geteinvoicetoken(int divid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@divid", SqlDbType.Int)
                                                      
            
            };
            objp[0].Value = divid;

            return ExecuteReader("sp_geteinvoicetoken", objp);
        }
        public String getholdcutdetails(int custid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@customerid", SqlDbType.Int) };
            objp[0].Value = custid;

            return ExecuteReader("spgetholdcutdetails", objp);
        }
        //  bhuvi newly added
        public DataTable getgstpod(int vouno, int bid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@vouno",SqlDbType.Int),                                                    
                                                        new SqlParameter("@bid",SqlDbType.Int),  
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                       
                                                        new SqlParameter("@voutype", SqlDbType.VarChar, 10)
                                                               
                                                        };
            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;

            objp[3].Value = voutype;
            //return ExecuteReader("sp_getSuppyToPlaceofSupply", objp);
            return ExecuteTable("sp_getSuppyToPlaceofSupply", objp);

        }

        //new

        public string getgstdetailsFC(int vouno, int bid, int vouyear, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@vouno",SqlDbType.Int),                                                     
                                                        new SqlParameter("@bid",SqlDbType.Int),  
                                                        new SqlParameter("@vouyear",SqlDbType.Int),
                                                       
                                                        new SqlParameter("@voutype", SqlDbType.VarChar, 10)
                                                                
                                                        };
            objp[0].Value = vouno;
            objp[1].Value = bid;
            objp[2].Value = vouyear;

            objp[3].Value = voutype;

            return ExecuteReader("sp_getgstindetjsonliveInv", objp);
            // return ExecuteReader("sp_getgstindetjsonliveInvFC", objp);

        }

        public String getunregcustvouchersFC(int vouno, int vouyear, int bid, string voutype)
        {
            SqlParameter[] objp = new SqlParameter[] {
                                                       new SqlParameter("@vouno", SqlDbType.Int) ,
                                                       new SqlParameter("@vouyear", SqlDbType.Int),
                                                        new SqlParameter("@bid", SqlDbType.Int),
                                                         new SqlParameter("@voutype", SqlDbType.VarChar,1),
            
            };
            objp[0].Value = vouno;
            objp[1].Value = vouyear;
            objp[2].Value = bid;
            objp[3].Value = voutype;
            return ExecuteReader("spgetunregcustvouchersFC", objp);
        }
        public DataTable cnops_view_addnew(int jobno, int branchid, string trantype, string refno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
                                                       new SqlParameter("@trantype", SqlDbType.VarChar,2),
             new SqlParameter("@refno", SqlDbType.VarChar,30)};

            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = trantype;
            objp[3].Value = refno;

            return ExecuteTable("sp_cnops_view_addnew", objp);
        }
        public DataTable cnops_view_new(int jobno, int branchid, string refno)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@jobno", SqlDbType.Int),
                                                       new SqlParameter("@branchid", SqlDbType.Int),
            new SqlParameter("@refno", SqlDbType.VarChar,30),
           };

            objp[0].Value = jobno;
            objp[1].Value = branchid;
            objp[2].Value = refno;

            return ExecuteTable("sp_cnops_view_new", objp);
        }
        public DataTable SPGetDocRefNo(int bid, string trantype, int jobno)
        {
            SqlParameter[] objp = new SqlParameter[] {   new SqlParameter("@branchid",SqlDbType.TinyInt,1),
                                                         new SqlParameter("@trantype", SqlDbType.VarChar, 2),
               new SqlParameter("@jobno", SqlDbType.Int, 4)
                                                        };
            objp[0].Value = bid;
            objp[1].Value = trantype;
            objp[2].Value = jobno;
            return ExecuteTable("SPGetDocRefNo", objp);
        }

    }
}
