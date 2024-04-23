using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess.PAYROLL
{
    public class RentDetailss : DBObject
    {
        //public DataTable HRGetRentDetails(int fy)
        //{
        //    SqlParameter[] objp = new SqlParameter[]
        //        { 
        //             new SqlParameter("@fy", SqlDbType.Int) 
        //        };
        //    objp[0].Value = fy ;
        //    return ExecuteTable("SPGetHRRentDetails", objp);

        //}


        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public RentDetailss()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable HRGetRentDetails(int employeeid, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                     new SqlParameter("@employeeid", SqlDbType.Int),
                     new SqlParameter("@fy",SqlDbType.Int)
                };
            objp[0].Value = employeeid;
            objp[1].Value = fy;
            return ExecuteTable("SPGetHRRentDetails", objp);

        }
        
        
        public void HRInsRentDetails(int empid, int fy,int rp,int rr,int rb,int taxrebate,int rf)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
               new SqlParameter("@empid",SqlDbType.Int),
               new SqlParameter("@fy",SqlDbType.Int),
               new SqlParameter("@rp",SqlDbType.Money ,2),
               new SqlParameter("@rr",SqlDbType.Money ,2),
               new SqlParameter("@rb",SqlDbType.Money ,2),
               new SqlParameter("@taxrebate",SqlDbType.Money ,2),
                new SqlParameter("@rf",SqlDbType.Money ,2)
           };
            objp[0].Value = empid;
            objp[1].Value = fy;
            objp[2].Value = rp;
            objp[3].Value = rr;
            objp[4].Value = rb;
            objp[5].Value = taxrebate ;
            objp[6].Value = rf;
            ExecuteQuery("SPInsHRRentDetails", objp);
        }

        public DataTable GetHRRentBasic(int empid,DateTime from, DateTime to)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@employeeid", SqlDbType.Int) ,
                new SqlParameter("@sfrom", SqlDbType.SmallDateTime,4) ,
                new SqlParameter("@sto", SqlDbType.SmallDateTime, 4) 
            };
            objp[0].Value = empid;
            objp[1].Value = from;
            objp[2].Value = to;
            return ExecuteTable("SPGetHRRentBasic", objp);

        }
        //public void HRInsRentDetails(int empid, int fy, int rp, int rr, int rb, int taxrebate)
        //{
        //    SqlParameter[] objp = new SqlParameter[]
        //   {
           
        //       new SqlParameter("@empid",SqlDbType.Int),
        //       new SqlParameter("@fy",SqlDbType.Int),
        //       new SqlParameter("@rp",SqlDbType.Money ,2),
        //       new SqlParameter("@rr",SqlDbType.Money ,2),
        //       new SqlParameter("@rb",SqlDbType.Money ,2),
        //       new SqlParameter("@raxrebate",SqlDbType.Money ,2)
        //   };
        //    objp[0].Value = empid;
        //    objp[1].Value = fy;
        //    objp[2].Value = rp;
        //    objp[3].Value = rr;
        //    objp[4].Value = rb;
        //    objp[5].Value = taxrebate;
        //    ExecuteQuery("SPInsHRRentDetails", objp);
        //}



        //Newly Added For House Rent
        public DataTable GetHouseRent(int empid, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@empid", SqlDbType.Int) ,
                new SqlParameter("@fy", SqlDbType.Int) 
               
            };
            objp[0].Value = empid;
            objp[1].Value = fy;
            return ExecuteTable("SPGetHouseRent", objp);

        }

        public void InsHouseRent(int empid, string othrincome, int income, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
                                                        new SqlParameter("@empid",SqlDbType.Int),                                                      
                                                       new SqlParameter("@othrincome",SqlDbType.VarChar ,50),                                                                                                                                                                                               
                                                       new SqlParameter("@income",SqlDbType.Money,8)  ,
                                                       new SqlParameter("@fy",SqlDbType.Int)
              
           };
            objp[0].Value = empid;
            objp[1].Value = othrincome;
            objp[2].Value = income;
            objp[3].Value = fy;
            ExecuteQuery("SPInsHouseRent", objp);
        }

        public void UpdHouseRent(int empid, string othrincome, int income, int fy)
        {
            SqlParameter[] objinvest = new SqlParameter[] { 
                                                       new SqlParameter("@empid",SqlDbType.Int),                                                      
                                                       new SqlParameter("@othrincome",SqlDbType.VarChar ,50),                                                                                                                                                                                               
                                                       new SqlParameter("@income",SqlDbType.Money,8)  ,
                                                       new SqlParameter("@fy",SqlDbType.Int)                                        
                                                      
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = othrincome;
            objinvest[2].Value = income;
            objinvest[3].Value = fy;
            ExecuteQuery("SPUpdHouseRent", objinvest);
        }

        //public void DelHouseRent(int empid, int fy)
        //{
        //    SqlParameter[] objp = new SqlParameter[] {
        //        new SqlParameter("@empid", SqlDbType.Int),
        //    new SqlParameter("@fy", SqlDbType.Int),
        //    };
        //    objp[0].Value = empid;
        //    objp[1].Value = fy;
        //    ExecuteQuery("SPDelHouseRent", objp);
        //}

        public void DelHouseRent(int empid, int fy, string othrincome)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid", SqlDbType.Int),
            new SqlParameter("@fy", SqlDbType.Int),
                 new SqlParameter("@othrincome",SqlDbType.VarChar ,50)
            };
            objp[0].Value = empid;
            objp[1].Value = fy;
            objp[2].Value = othrincome;
            ExecuteQuery("SPDelHouseRent", objp);
        }


        public void UpdHrRentDtls(int empid, int fy, int arp, int ataxrepat)
        {
            SqlParameter[] objinvest = new SqlParameter[] { 
                                                       new SqlParameter("@empid",SqlDbType.Int),                                               
                                                                                                                                                                                                                                                    
                                                      
                                                       new SqlParameter("@fy",SqlDbType.Int),
                 new SqlParameter("@arp",SqlDbType.Money,8)  ,       
                  new SqlParameter("@ataxrepat",SqlDbType.Money,8)  
                                                      
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = fy;
            objinvest[2].Value = arp;
            objinvest[3].Value = ataxrepat;
            ExecuteQuery("SPUpdHrRentDtls", objinvest);
        }
        public void UpdHouseRentDlsNew(int empid, int amount, int fy)//,int amount
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
                                                        new SqlParameter("@empid",SqlDbType.Int),                                                  
                                               
                                                       new SqlParameter("@fy",SqlDbType.Int),
                new SqlParameter("@amount",SqlDbType.Money,8)  
            
              
           };
            objp[0].Value = empid;
            //objp[1].Value = othrincome;
            //objp[2].Value = income;
            objp[1].Value = fy;
            objp[2].Value = amount;
            ExecuteQuery("SPUpdHouseRentNew", objp);
        }
        public DataTable GetTempInsPlanApp(int fy)
        {


            SqlParameter[] objp = new SqlParameter[]
            { 
                //new SqlParameter("@empid", SqlDbType.Int) ,
                new SqlParameter("@fy", SqlDbType.Int) 
               
            };
            objp[0].Value = fy;
            //objp[1].Value = fy;
            return ExecuteTable("SPTempInsAllProofRcv", objp);

        }



        //Added By ManiG For Quarter Details

        public DataTable GetQuarterDetails(int empid, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@empid", SqlDbType.Int) ,
                new SqlParameter("@fy", SqlDbType.Int) 
               
            };
            objp[0].Value = empid;
            objp[1].Value = fy;
            return ExecuteTable("SPGetQuarterDtls", objp);

        }
        public DataTable GetInsUpdQuarterDtl(int empid, int quarterid, string quatermark, int quateramt, int fy)
        {


            SqlParameter[] objp = new SqlParameter[]
            { 
                  new SqlParameter("@empid",SqlDbType.Int),      
                new SqlParameter("@quarterid",SqlDbType.Int),                                    
                                                       new SqlParameter("@quartermark",SqlDbType.VarChar ,50),                                                                                                                                                                                               
                                                       new SqlParameter("@quarteramt",SqlDbType.Money,8)  ,
                                                       new SqlParameter("@fy",SqlDbType.Int)  
               
            };
            objp[0].Value = empid;
            objp[1].Value = quarterid;
            objp[2].Value = quatermark;
            objp[3].Value = quateramt;
            objp[4].Value = fy;
            return ExecuteTable("SPInsUpdQuarter", objp);

        }
        public DataTable GetAllQuarterDtls(int empid, int quarterid, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@empid",SqlDbType.Int),   
               new SqlParameter("@quarterid", SqlDbType.Int) ,
                new SqlParameter("@fy", SqlDbType.Int) 
               
            };
            objp[0].Value = empid;
            objp[1].Value = quarterid;
            objp[2].Value = fy;
            return ExecuteTable("SPGetAllQuarter", objp);

        }
        public DataTable GetHRTDS4AmtQtr( /**/int empid, int quarterid, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                 new SqlParameter("@empid",SqlDbType.Int),   
               new SqlParameter("@quarterid", SqlDbType.Int) ,
                new SqlParameter("@fy", SqlDbType.Int) 
               
            };
            objp[0].Value = empid;
            objp[1].Value = quarterid;
            objp[2].Value = fy;
            return ExecuteTable("SPGetHRTDSAmt4Qtr", objp);

        }
        //public DataTable GetTempProofRcv(int bid, int divid/*,int fy*/)
        //{


        //    SqlParameter[] objp = new SqlParameter[]
        //    { 
        //      new SqlParameter("@bid", SqlDbType.SmallInt ,5)  ,
        //      new SqlParameter("@divid", SqlDbType.Int)    
        //      //  new SqlParameter("@fy", SqlDbType.Int) 
               
        //    };
        //    objp[0].Value = bid;
        //    objp[1].Value = divid;
        //    //objp[2].Value = fy;
        //    return ExecuteTable("SPGetRpt4ProofRcvd", objp);

        //}


        //Preve Emp Tax Paid
        public void InsUpdPreEmpTaxPaid(int empid, int pmont, int pyear, DateTime depdate, int tds)//,int amount
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
                                                        new SqlParameter("@empid",SqlDbType.Int),                                                  
                                                new SqlParameter("@pmont",SqlDbType.Int),
                                                       new SqlParameter("@pyear",SqlDbType.Int),
               new SqlParameter("@depdate", SqlDbType.SmallDateTime, 4) ,
                new SqlParameter("@tds",SqlDbType.Money,8)  
            
              
           };
            objp[0].Value = empid;
            objp[1].Value = pmont;
            objp[2].Value = pyear;
            objp[3].Value = depdate;
            objp[4].Value = tds;
            ExecuteQuery("SPInsUpdPreEmpTaxPaid", objp);


        }

        public double GetHouseRent4PrvEmpTpaid(int empid, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                      new SqlParameter("@empid",SqlDbType.Int),                  
                new SqlParameter("@fy", SqlDbType.Int) 

                };
            objp[0].Value = empid;
            objp[1].Value = fy;
            return double.Parse(ExecuteReader("SPGetHouseRent4PrvEmpTpaid", objp));
        }
        /*Dinesh*/
        public void HRInsRentDetailsWeb(int empid, int fy, double rp, double rr, double rb, double taxrebate, double rf)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
               new SqlParameter("@empid",SqlDbType.Int),
               new SqlParameter("@fy",SqlDbType.Int),
               new SqlParameter("@rp",SqlDbType.Money ,2),
               new SqlParameter("@rr",SqlDbType.Money ,2),
               new SqlParameter("@rb",SqlDbType.Money ,2),
               new SqlParameter("@taxrebate",SqlDbType.Money ,2),
                new SqlParameter("@rf",SqlDbType.Money ,2)
           };
            objp[0].Value = empid;
            objp[1].Value = fy;
            objp[2].Value = rp;
            objp[3].Value = rr;
            objp[4].Value = rb;
            objp[5].Value = taxrebate;
            objp[6].Value = rf;
            ExecuteQuery("SPInsHRRentDetails", objp);
        }
        /*Dinesh*/

        public void UpdHrRentDtls(int empid, int fy, double arp, double ataxrepat)
        {
            SqlParameter[] objinvest = new SqlParameter[] { 
                                                       new SqlParameter("@empid",SqlDbType.Int),                                               
                                                                                                                                                                                                                                                    
                                                      
                                                       new SqlParameter("@fy",SqlDbType.Int),
                 new SqlParameter("@arp",SqlDbType.Money,8)  ,       
                  new SqlParameter("@ataxrepat",SqlDbType.Money,8)  
                                                      
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = fy;
            objinvest[2].Value = arp;
            objinvest[3].Value = ataxrepat;
            ExecuteQuery("SPUpdHrRentDtls", objinvest);
        }
        /*Dinesh */
        public void InsHouseRentWeb(int empid, string othrincome, double income, int fy)
        {
            SqlParameter[] objp = new SqlParameter[]
           {
           
                                                        new SqlParameter("@empid",SqlDbType.Int),                                                      
                                                       new SqlParameter("@othrincome",SqlDbType.VarChar ,50),                                                                                                                                                                                               
                                                       new SqlParameter("@income",SqlDbType.Money,8)  ,
                                                       new SqlParameter("@fy",SqlDbType.Int)
              
           };
            objp[0].Value = empid;
            objp[1].Value = othrincome;
            objp[2].Value = income;
            objp[3].Value = fy;
            ExecuteQuery("SPInsHouseRent", objp);
        }

        public void UpdHouseRentWeb(int empid, string othrincome, double income, int fy)
        {
            SqlParameter[] objinvest = new SqlParameter[] { 
                                                       new SqlParameter("@empid",SqlDbType.Int),                                                      
                                                       new SqlParameter("@othrincome",SqlDbType.VarChar ,50),                                                                                                                                                                                               
                                                       new SqlParameter("@income",SqlDbType.Money,8)  ,
                                                       new SqlParameter("@fy",SqlDbType.Int)                                        
                                                      
                                                     };
            objinvest[0].Value = empid;
            objinvest[1].Value = othrincome;
            objinvest[2].Value = income;
            objinvest[3].Value = fy;
            ExecuteQuery("SPUpdHouseRent", objinvest);
        }

        /*Dinesh*/
        public void DelHouseRent(int empid, int fy)
        {
            SqlParameter[] objp = new SqlParameter[] {
                new SqlParameter("@empid", SqlDbType.Int),
            new SqlParameter("@fy", SqlDbType.Int),
            };
            objp[0].Value = empid;
            objp[1].Value = fy;
            ExecuteQuery("SPDelHouseRent", objp);
        }
    }
    
}
