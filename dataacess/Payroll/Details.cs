using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Payroll
{
    public class Details : DBObject
    {
        //public DataTable InsInvestPlan(int empid, string investplan, double investamt, int section, int fy)
        //{
        //    SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
        //                                               new SqlParameter("@investplan",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@investamt",SqlDbType.Money,8),
        //                                               new SqlParameter("@section",SqlDbType.Int),
        //                                               new SqlParameter("@fy",SqlDbType.Int),
        //                                               new SqlParameter("@cancel",SqlDbType.VarChar,10)                                      
        //                                             };
        //    objinvest[0].Value = empid;
        //    objinvest[1].Value = investplan;
        //    objinvest[2].Value = investamt;
        //    objinvest[3].Value = section;
        //    objinvest[4].Value = fy;
        //    objinvest[5].Value = "yes";

        //    return ExecuteTable("SPInsInvestPlan", objinvest);
        //}


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public Details()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable InsInvestPlan(int empid, string investplan, double investamt, int section, int fy, DateTime receivedon)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                       new SqlParameter("@investplan",SqlDbType.VarChar,50),
                                                       new SqlParameter("@investamt",SqlDbType.Money,8),
                                                       new SqlParameter("@section",SqlDbType.Int),
                                                       new SqlParameter("@fy",SqlDbType.Int),
                                                       new SqlParameter("@cancel",SqlDbType.VarChar,10),
                new SqlParameter("@proofreceivedon",SqlDbType.DateTime,10)                      
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = investplan;
            objinvest[2].Value = investamt;
            objinvest[3].Value = section;
            objinvest[4].Value = fy;
            objinvest[5].Value = "no";
            objinvest[6].Value = receivedon;
            return ExecuteTable("SPInsInvestPlan", objinvest);
        }
        //public void UpdInvestPlan(int empid, string investplan, double investamt, int section, string oldinvplan, int fy, DateTime receivedon, double recvamt)
        //{
        //    SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
        //                                               new SqlParameter("@investplan",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@investamt",SqlDbType.Money,8),
        //                                               new SqlParameter("@section",SqlDbType.Int),
        //                                               new SqlParameter("@oldinvplan",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@fy",SqlDbType.Int),
        //                                               new SqlParameter("@proofreceivedon",SqlDbType.DateTime,10),
        //         new SqlParameter("@recvamt",SqlDbType.Money,8)
                                                    
                                                      
        //                                             };
        //    objinvest[0].Value = empid;
        //    objinvest[1].Value = investplan;
        //    objinvest[2].Value = investamt;
        //    objinvest[3].Value = section;
        //    objinvest[4].Value = oldinvplan;
        //    objinvest[5].Value = fy;
        //    objinvest[6].Value = receivedon;
        //    objinvest[7].Value = recvamt;

        //    ExecuteQuery("SPUpdInvestPlan", objinvest);
        //}
        ///Modifyied above DA
        public void UpdInvestPlan(int empid, string investplan, double investamt, int section, string oldinvplan, int fy, DateTime receivedon, double recvamt, int secid)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                       new SqlParameter("@investplan",SqlDbType.VarChar,50),
                                                       new SqlParameter("@investamt",SqlDbType.Money,8),
                                                       new SqlParameter("@section",SqlDbType.Int),
                                                       new SqlParameter("@oldinvplan",SqlDbType.VarChar,50),
                                                       new SqlParameter("@fy",SqlDbType.Int),
                                                       new SqlParameter("@proofreceivedon",SqlDbType.DateTime,10),
                 new SqlParameter("@recvamt",SqlDbType.Money,8),
                                                       new SqlParameter("@secid",SqlDbType.Int)
                                                      
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = investplan;
            objinvest[2].Value = investamt;
            objinvest[3].Value = section;
            objinvest[4].Value = oldinvplan;
            objinvest[5].Value = fy;
            objinvest[6].Value = receivedon;
            objinvest[7].Value = recvamt;
            objinvest[8].Value = secid;
            ExecuteQuery("SPUpdInvestPlan", objinvest);
        }



        //public void UpdInvestPlan(int empid, string investplan, double investamt, int section,string oldinvplan, int fy,DateTime  receivedon)
        //{
        //    SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
        //                                               new SqlParameter("@investplan",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@investamt",SqlDbType.Money,8),
        //                                               new SqlParameter("@section",SqlDbType.Int),
        //                                               new SqlParameter("@oldinvplan",SqlDbType.VarChar,50),
        //                                               new SqlParameter("@fy",SqlDbType.Int),
        //                                               new SqlParameter("@proofreceivedon",SqlDbType.DateTime,10)
                                                    
                                                      
        //                                             };
        //    objinvest[0].Value = empid;
        //    objinvest[1].Value = investplan;
        //    objinvest[2].Value = investamt;
        //    objinvest[3].Value = section;
        //    objinvest[4].Value = oldinvplan;
        //    objinvest[5].Value = fy;
        //    objinvest[6].Value = receivedon;

        //    ExecuteQuery("SPUpdInvestPlan", objinvest);
        //}
        public DataTable SelInvestPlan(int empid,int fy)
                    {
                        SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid", SqlDbType.Int, 6),
                                                   new SqlParameter("@fy",SqlDbType.Int)
                        };

                        objinvest[0].Value = empid;
                        objinvest[1].Value = fy;
                        return ExecuteTable("SPSelInvestPlan", objinvest);

        }

        //old
        //public void DelInvestPlan(int empid, string investplan)
        //{
        //    SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
        //                                               new SqlParameter("@investplan",SqlDbType.VarChar,50)
        //                                             };
        //    objinvest[0].Value = empid;
        //    objinvest[1].Value = investplan;

        //   ExecuteQuery("SPDelInvestPlan", objinvest);
        //}

      /*  public void DelInvestPlan(int empid, string investplan, int fy,int secid)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                       new SqlParameter("@investplan",SqlDbType.VarChar,50),
                                                        new SqlParameter("@fy",SqlDbType.Int,4),
                                                        new SqlParameter("@sectionid",SqlDbType.Int,4)};

            objinvest[0].Value = empid;
            objinvest[1].Value = investplan;
            objinvest[2].Value = fy;
            objinvest[3].Value = secid;
            ExecuteQuery("SPDelInvestPlan", objinvest);
        }
        */
        public double getInvesTotAmt(int empid,int secid,int fy)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid",SqlDbType.Int,6),
                new SqlParameter("@secid",SqlDbType.Int,4),
            new SqlParameter("@fy",SqlDbType.Int,4)};
            objp[0].Value = empid;
            objp[1].Value = secid;
            objp[2].Value = fy;
            return double.Parse(ExecuteReader("SPgetInvesTotAmt", objp));
        }

        public double getMaxlimitAmt(int secid)
        {
            SqlParameter[] objp = new SqlParameter[] {
                               new SqlParameter("@secid",SqlDbType.Int,4)};
            
            objp[0].Value = secid;
            return double.Parse(ExecuteReader("SPgetMaxlimitAmt", objp));
        }

        
        //=======================================HRTaxSlab====================================


        public DataTable InsTaxSlab(char category, double slabfrom, double slabto, int taxpercent,DateTime validfrom,DateTime validto,double sur,double edu)
        {
            SqlParameter[] taxinsobj = new SqlParameter[] { new SqlParameter("@category",SqlDbType.Char,1),
                                                       new SqlParameter("@slabfrom",SqlDbType.Money,8),
                                                       new SqlParameter("@slabto",SqlDbType.Money,8),
                                                       new SqlParameter("@taxpercent",SqlDbType.Int,4),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8),
                new SqlParameter("@surcharges",SqlDbType.Money,8),
                new SqlParameter("@educhess",SqlDbType.Money,8)
                                                     };
            taxinsobj[0].Value = category;
            taxinsobj[1].Value = slabfrom;
            taxinsobj[2].Value = slabto;
            taxinsobj[3].Value = taxpercent;
            taxinsobj[4].Value = validfrom;
            taxinsobj[5].Value = validto;
            taxinsobj[6].Value = sur;
            taxinsobj[7].Value = edu;

           return ExecuteTable("SPInsTaxSlab", taxinsobj);
        }
        public void UpadTaxSlab(char category, double slabfrom, double slabto, int taxpercent, int taxid, DateTime validfrom, DateTime validto, double sur, double edu)
        {
            SqlParameter[] taxupdobj = new SqlParameter[] { new SqlParameter("@category",SqlDbType.Char,1),
                                                       new SqlParameter("@slabfrom",SqlDbType.Money,8),
                                                       new SqlParameter("@slabto",SqlDbType.Money,8),
                                                       new SqlParameter("@taxpercent",SqlDbType.Int,4),
                                                       new SqlParameter("@taxid",SqlDbType.Int,4),
                new SqlParameter("@validfrom",SqlDbType.DateTime,8),
                new SqlParameter("@validto",SqlDbType.DateTime,8),
                 new SqlParameter("@surcharges",SqlDbType.Money,8),
                new SqlParameter("@educhess",SqlDbType.Money,8)
                                                     };
            taxupdobj[0].Value = category;
            taxupdobj[1].Value = slabfrom;
            taxupdobj[2].Value = slabto;
            taxupdobj[3].Value = taxpercent;
            taxupdobj[4].Value = taxid;
            taxupdobj[5].Value = validfrom;
            taxupdobj[6].Value = validto;
            taxupdobj[7].Value = sur;
            taxupdobj[8].Value = edu;

            ExecuteQuery("SPUpdTaxSlab", taxupdobj);
        }
        public DataTable SelTaxslab(char category)
        {
            SqlParameter[] taxselobj = new SqlParameter[] {
                                    new SqlParameter("@category",SqlDbType.Char,1)
                        };
            taxselobj[0].Value = category;
            return ExecuteTable("SPSelTaxSlab", taxselobj);

        }

        //=======================Employee Details=========
        public DataTable GetEmpDetails(int logempid)
        {
            SqlParameter[] getemp = new SqlParameter[] {
                                    new SqlParameter("@employeeid",SqlDbType.Int,4)
                        };
            getemp[0].Value = logempid;
            return ExecuteTable("SPGetEmpdetails", getemp);
        }


        //======================
        public DataTable GetSection()
        {
            SqlParameter[] getsec = new SqlParameter[]{
                            };
            return ExecuteTable("SPSelInvestSection", getsec);
        }


        //=====================Select LastMonth Employees
        public DataTable getlmonthemp(int month, int year)
        {
            SqlParameter[] getlemp = new SqlParameter[]{
                               new SqlParameter("@month", SqlDbType.Int, 6),
               new SqlParameter("@year", SqlDbType.Int, 6),
                            };
            getlemp[0].Value = month;
            getlemp[1].Value = year;
            return ExecuteTable("InsTempTblpfdedstatement", getlemp);
        }

        //======================Payroll Slip Report
        public DataTable getreportdet(int month, int year, int divisionid,char param)
        {
            SqlParameter[] getdet = new SqlParameter[]{
                               new SqlParameter("@month", SqlDbType.Int, 6),
               new SqlParameter("@year", SqlDbType.Int, 6),
                new SqlParameter("@divisionid",SqlDbType.Int,6),
                 new SqlParameter("@param",SqlDbType.Char,1)
                            };
            getdet[0].Value = month;
            getdet[1].Value = year;
            getdet[2].Value = divisionid;
            getdet[3].Value = param;
            return ExecuteTable("SPHRGetReportDet", getdet);
        }
        public DataTable GetTotDet(int month, int year, int divisionid, char param)
        {
            SqlParameter[] getdet = new SqlParameter[]{
                               new SqlParameter("@month", SqlDbType.Int, 6),
               new SqlParameter("@year", SqlDbType.Int, 6),
                new SqlParameter("@divisionid",SqlDbType.Int,6),
                 new SqlParameter("@param",SqlDbType.Char,1)
                            };
            getdet[0].Value = month;
            getdet[1].Value = year;
            getdet[2].Value = divisionid;
            getdet[3].Value = param;
            return ExecuteTable("SPHRGetTotDet", getdet);
        }

        public DataTable GetEmpDetails4TDS(string logempid)
        {
            SqlParameter[] getemp = new SqlParameter[] {
                                    new SqlParameter("@employeeid",SqlDbType.VarChar,10)
                        };
            getemp[0].Value = logempid;
            return ExecuteTable("SPGetEmpdetails4TDSDtls", getemp);
        }

        public void DelTaxSlab(int taxid)
        {
            SqlParameter[] objp = new SqlParameter[] { new SqlParameter("@taxid", SqlDbType.Int) };
            objp[0].Value = taxid;
            ExecuteQuery("SPDelTaxSlab", objp);
        }
        //rpt 4 frm12A
        public void GetReportDet12A(int month, int year, int divisionid)
        {
            SqlParameter[] getdet = new SqlParameter[]{
                               new SqlParameter("@month", SqlDbType.Int, 6),
               new SqlParameter("@year", SqlDbType.Int, 6),
                new SqlParameter("@divisionid",SqlDbType.Int,6),
                   };
            getdet[0].Value = month;
            getdet[1].Value = year;
            getdet[2].Value = divisionid;
            ExecuteQuery("SPGetReportDet12A", getdet);
        }

        ///Mani
        public void UpdInvestPlanNew(int empid, string investplan, double investamt, int section, string oldinvplan, int fy, DateTime receivedon, double recvamt, int secid)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                       new SqlParameter("@investplan",SqlDbType.VarChar,50),
                                                       new SqlParameter("@investamt",SqlDbType.Money,8),
                                                       new SqlParameter("@section",SqlDbType.Int),
                                                       new SqlParameter("@oldinvplan",SqlDbType.VarChar,50),
                                                       new SqlParameter("@fy",SqlDbType.Int),
                                                       new SqlParameter("@proofreceivedon",SqlDbType.DateTime,10),
                                                       new SqlParameter("@recvamt",SqlDbType.Money,8),
                                                       new SqlParameter("@secid",SqlDbType.Int)
                                                      
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = investplan;
            objinvest[2].Value = investamt;
            objinvest[3].Value = section;
            objinvest[4].Value = oldinvplan;
            objinvest[5].Value = fy;
            objinvest[6].Value = receivedon;
            objinvest[7].Value = recvamt;
            objinvest[8].Value = secid;
            ExecuteQuery("SPUpdInvestPlanNew", objinvest);
        }

        //get Pf 4 invest plan
        public double Getpfamt4invest(int empid, int month, int year)
        {
            SqlParameter[] getlemp = new SqlParameter[]{
                                new SqlParameter("@empid",SqlDbType.Int,6),
                                new SqlParameter("@month", SqlDbType.Int, 6),
                                new SqlParameter("@year", SqlDbType.Int, 6),
                            };
            getlemp[0].Value = empid;
            getlemp[1].Value = month;
            getlemp[2].Value = year;
            return double.Parse(ExecuteReader("SPGetpfamt4invest", getlemp));
        }

        /*public DataTable UpdInsHrMedAmtRecvd(int empid, int fy, double amt, int taramt)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                      new SqlParameter("@fy",SqlDbType.Int),
                                                       new SqlParameter("@amt",SqlDbType.Money,8),
                new SqlParameter("@taramt",SqlDbType.Money,8)
                                                       
                                                      
                                                                   
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = fy;
            objinvest[2].Value = amt;
            objinvest[3].Value = taramt;

            return ExecuteTable("SPInsHrMedAmtRecvd", objinvest);
        }
        */
        //Add HRKPi by ManiG  and  Modify Dinesh
        public DataTable GetInsUpdKpiDtls(int empid, int kpiyear, string kpi, int kwage, int kpiid)
        {


            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@empid",SqlDbType.Int ,4),      
                new SqlParameter("@kyear",SqlDbType.Int ,4),                                    
                 new SqlParameter("@kpi",SqlDbType.VarChar ,250),                                                                                                                                                                                               
                 new SqlParameter("@wage",SqlDbType.Int ,4)  ,
                 new SqlParameter("@kpiid",SqlDbType.Int)        
                                                      
               
            };
            objp[0].Value = empid;
            objp[1].Value = kpiyear;
            objp[2].Value = kpi;
            objp[3].Value = kwage;
            objp[4].Value = kpiid;
            return ExecuteTable("SPInsKpiDtlsnew", objp);

        }
        public DataTable GetKpiDtls(int empid, int kyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                  new SqlParameter("@empid",SqlDbType.Int ,4),      
                new SqlParameter("@kyear",SqlDbType.Int ,4)       
               
            };
            objp[0].Value = empid;
            objp[1].Value = kyear;
            return ExecuteTable("SPGetKpiDtlsnew", objp);
        }


        public void DelKPIDetails(int empid, string kpi, int fy ,int kpiid)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,4),
                                                       new SqlParameter("@kpi",SqlDbType.VarChar,250),
                                                        new SqlParameter("@fy",SqlDbType.Int,4),
                                                        new SqlParameter("@kpiid",SqlDbType.Int)};

            objinvest[0].Value = empid;
            objinvest[1].Value = kpi;
            objinvest[2].Value = fy;
           objinvest[3].Value = kpiid;
            ExecuteQuery("SPDelKpiDtls", objinvest);
        }
        /*Dinesh*/


        public DataTable UpdInsHrMedAmtRecvd(int empid, int fy, double amt, double taramt)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                      new SqlParameter("@fy",SqlDbType.Int),
                                                       new SqlParameter("@amt",SqlDbType.Money,8),
                new SqlParameter("@taramt",SqlDbType.Money,8)
                                                       
                                                      
                                                                   
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = fy;
            objinvest[2].Value = amt;
            objinvest[3].Value = taramt;

            return ExecuteTable("SPInsHrMedAmtRecvd", objinvest);
        }
        /*Dinesh*/
       /* public void DelInvestPlan(int empid, string investplan, int fy)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                       new SqlParameter("@investplan",SqlDbType.VarChar,50),
                                                        new SqlParameter("@fy",SqlDbType.Int,4)};

            objinvest[0].Value = empid;
            objinvest[1].Value = investplan;
            objinvest[2].Value = fy;
            ExecuteQuery("SPDelInvestPlan", objinvest);
        }
        */

        public void DelInvestPlan(int empid, string investplan, int fy, int secid)
        {
            SqlParameter[] objinvest = new SqlParameter[] { new SqlParameter("@empid",SqlDbType.Int,6),
                                                       new SqlParameter("@investplan",SqlDbType.VarChar,50),
                                                        new SqlParameter("@fy",SqlDbType.Int,4),
                                                        new SqlParameter("@sectionid",SqlDbType.Int,4)};

            objinvest[0].Value = empid;
            objinvest[1].Value = investplan;
            objinvest[2].Value = fy;
            objinvest[3].Value = secid;
            ExecuteQuery("SPDelInvestPlan", objinvest);
        }

        //Dinesh
        public DataTable Getplandetails()
        {
            SqlParameter[] getsec = new SqlParameter[]{
                            };
            return ExecuteTable("SPSelInvestplannew", getsec);
        }


        public DataTable GetKpiDtlsnew(int empid, int kyear)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                  new SqlParameter("@empid",SqlDbType.Int ,4),      
                new SqlParameter("@kyear",SqlDbType.Int ,4)       
               
            };
            objp[0].Value = empid;
            objp[1].Value = kyear;
            return ExecuteTable("SPGetKpiDtlsnewappyear", objp);
        }
    }

}
