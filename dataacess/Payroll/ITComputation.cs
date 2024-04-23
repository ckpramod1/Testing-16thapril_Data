using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Payroll
{
    public class ITComputation:DBObject 
    {
        int tmp_ITid;

        public void GetDataBase(string Ccode)
        {
            Clientcode = Ccode;
            xyz(Ccode);


        }
        public ITComputation()
        {
            Conn = new SqlConnection(DBCS);
        }

        public DataTable GetITDet(int empid, DateTime DtFrom, DateTime DtTo,DateTime selDate)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4),
                            new SqlParameter("@DtFrom",SqlDbType.DateTime),
                            new SqlParameter("@DtTo",SqlDbType.DateTime),
                            new SqlParameter("@selDate",SqlDbType.DateTime)
                        };
            objp[0].Value = empid ;
            objp[1].Value = DtFrom;
            objp[2].Value = DtTo;
            objp[3].Value = selDate;
            return ExecuteTable("SPHRITComputation", objp);
        }

        public DataTable GetITDet4TaxDebate(int empid,DateTime DtTo)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4),
                            new SqlParameter("@DtTo",SqlDbType.DateTime)
                        };
            objp[0].Value = empid;
            objp[1].Value = DtTo;
            return ExecuteTable("SPHRITComp4TaxDebate", objp);
        }
        public DataTable GetITDet4TaxSlabto(Char catgy, DateTime taxdate)
        {
            SqlParameter[] objp = new SqlParameter[] { 
            new SqlParameter("@catgy",SqlDbType.Char ,4),
            new SqlParameter("@taxdate",SqlDbType.DateTime)};
            objp[0].Value = catgy;
            objp[1].Value = taxdate;
            return ExecuteTable("SPHRGetSlabTo", objp);
        }
        public void SveITComp(int empid,DateTime currdate,double taxincome,double taxamount,double taxdetect,double taxpay,double taxpermonth)
        {

             SqlParameter[] objp;
              objp = new SqlParameter[]
                {
                    new SqlParameter("@itid",SqlDbType.Int ),
                    new SqlParameter("@empid",SqlDbType.Int),
                    new SqlParameter("@currdate", SqlDbType.DateTime),
                    new SqlParameter("@taxincome",SqlDbType.Money),
                    new SqlParameter("@taxamount",SqlDbType.Money),
                    new SqlParameter("@taxdetect",SqlDbType.Money),
                    new SqlParameter("@taxpay",SqlDbType.Money),
                    new SqlParameter("@taxpermonth",SqlDbType.Money),
                };
                 objp[0].Direction = ParameterDirection.Output;
                 objp[1].Value = empid;
                 objp[2].Value = currdate;
                 objp[3].Value = taxincome;
                 objp[4].Value = taxamount;
                 objp[5].Value = taxdetect;
                 objp[6].Value = taxpay;
                 objp[7].Value = taxpermonth;
                 tmp_ITid =ExecuteQuery("SPHRInsITCompHead", objp,"@itid");
        }

        public void SveITCompExcemDet(int itsec, string itdetails, double itamount)
        {
            SqlParameter[] objp;
                 objp = new SqlParameter[]
                  { 
                      new SqlParameter("@itid",SqlDbType.Int ),
                    new SqlParameter("@itsec", SqlDbType.Int,4),
                    new SqlParameter("@itdetails", SqlDbType.VarChar),
                      new SqlParameter("@itamount",SqlDbType.Money) 
                  };
                 objp[0].Value = tmp_ITid;
                 objp[1].Value = itsec;
                 objp[2].Value = itdetails;
                 objp[3].Value = itamount;
                 ExecuteQuery("SPHRInsHRITCompuExcemDetails", objp);
        }
        public void SveITProfTax(double proftax)
        {
             SqlParameter[] objp;
             objp = new SqlParameter[]
             { 
                 new SqlParameter("@itid",SqlDbType.Int ),
                 new SqlParameter("@proftax", SqlDbType.Money )
             };
             objp[0].Value = tmp_ITid;
             objp[1].Value = proftax;
             ExecuteQuery("SPHRInsHRITHRITProfTax", objp);
        }

        public void SveITComIncDet(string salary, double amount)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                  { 
                      new SqlParameter("@itid",SqlDbType.Int ),
                      new SqlParameter("@salary", SqlDbType.VarChar,300),
                      new SqlParameter("@amount", SqlDbType.Money )
                  };
            objp[0].Value = tmp_ITid;
            objp[1].Value = salary;
            objp[2].Value = amount;
            ExecuteQuery("SPHRInsHRITComIncDet", objp);
        }

        public void SveITComDedDet(string salary, double amount)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                  { 
                      new SqlParameter("@itid",SqlDbType.Int ),
                      new SqlParameter("@salary", SqlDbType.VarChar,50),
                      new SqlParameter("@amount", SqlDbType.Money )
                  };
            objp[0].Value = tmp_ITid;
            objp[1].Value = salary;
            objp[2].Value = amount;
            ExecuteQuery("SPInsHRITDedDet", objp);
        }


        public void SaveITCompDet(int empid, DateTime currdate, double proftax)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                {
                    new SqlParameter("@itid",SqlDbType.Int ),
                    new SqlParameter("@empid",SqlDbType.Int),
                    new SqlParameter("@currdate", SqlDbType.DateTime)
                };
            objp[0].Direction = ParameterDirection.Output;
            objp[1].Value = empid;
            objp[2].Value = currdate;
            tmp_ITid = ExecuteQuery("SPHRInsITCompHead", objp, "@itid");


             objp = new SqlParameter[]
             { 
                 new SqlParameter("@itid",SqlDbType.Int ),
                 new SqlParameter("@proftax", SqlDbType.Money )
             };
            objp[0].Value = tmp_ITid;
            objp[1].Value = proftax;
            ExecuteQuery("SPHRInsHRITHRITProfTax", objp);
        }
        public DataTable selitcomp(int empid)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                {
                  new SqlParameter("@empid",SqlDbType.Int,4)
                };
            objp[0].Value = empid;
            return ExecuteTable("tempitcomp", objp);
        }

        public DataTable SelITTaxDetect(int empid,DateTime DtFrom,DateTime DtITTo)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                {
                  new SqlParameter("@empid",SqlDbType.Int,4),
                    new SqlParameter("@DtFrom", SqlDbType.DateTime),
                    new SqlParameter("@DtITTo", SqlDbType.DateTime)

                };
            objp[0].Value = empid;
            objp[1].Value = DtFrom;
            objp[2].Value = DtITTo;
            return ExecuteTable("SPHRITCalcitax", objp);
        }

        public double GetHRITAmt(int paymonth, int payyear, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                     new SqlParameter("@paymonth", SqlDbType.Int) ,
                    new SqlParameter("@payyear", SqlDbType.Int),
                    new SqlParameter("@empid", SqlDbType.Int)

                };
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            objp[2].Value = empid;
            return double.Parse(ExecuteReader("GetHRITAmt", objp));
            }

       /* public double GetHRITProfTaxAmt(int empid, double gross, int fyear)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                    new SqlParameter("@empid", SqlDbType.Int),
                    new SqlParameter("@gross", SqlDbType.Float, 4),
                    new SqlParameter("@fyear", SqlDbType.Int , 4)

                };
            objp[0].Value = empid;
            objp[1].Value = gross;
            objp[2].Value = fyear;
            return double.Parse(ExecuteReader("SPGetHRITProfTaxAmt", objp));
        }*/
        public double GetHRITBnsAmt(int empid, int year)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                    new SqlParameter("@empid", SqlDbType.Int),
                    new SqlParameter("@year", SqlDbType.Int, 4)


                };
            objp[0].Value = empid;
            objp[1].Value = year;
            return double.Parse(ExecuteReader("SPGetHRITBnsAmt", objp));
        }
        public DataTable GetITComp4TaxDebateNew(int empid, DateTime DtTo, string sec)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4),
                            new SqlParameter("@DtTo",SqlDbType.DateTime),
                            new SqlParameter("@sec",SqlDbType.VarChar,10),
                        };
            objp[0].Value = empid;
            objp[1].Value = DtTo;
            objp[2].Value = sec;
            return ExecuteTable("SPHRITComp4TaxDebateNew", objp);
        }
        public DataTable GetMedicalIT(int empid, DateTime DtFrom, DateTime DtTo, DateTime selDate)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4),
                            new SqlParameter("@DtFrom",SqlDbType.DateTime),
                            new SqlParameter("@DtTo",SqlDbType.DateTime),
                            new SqlParameter("@selDate",SqlDbType.DateTime)
                        };
            objp[0].Value = empid;
            objp[1].Value = DtFrom;
            objp[2].Value = DtTo;
            objp[3].Value = selDate;
            return ExecuteTable("SPGetMedical", objp);
        }
        public DataTable GetLeaveEnchancement(int empid, DateTime DtFrom)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4),
                            new SqlParameter("@DtFrom",SqlDbType.DateTime)
                           
                        };
            objp[0].Value = empid;
            objp[1].Value = DtFrom;
            return ExecuteTable("SPGetLeaveEnchance", objp);
        }
        public DataTable GetCheckITHead(int empid, int itmonth, int ityear)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4),
                            new SqlParameter("@itmonth",SqlDbType.Int,4),
                            new SqlParameter("@ityear",SqlDbType.Int,4)

                     
                           
                        };
            objp[0].Value = empid;
            objp[1].Value = itmonth;
            objp[2].Value = ityear;

            return ExecuteTable("SPCheckITHead", objp);
        }


        /*Dinesh*/
        //public void SveHRITComputation(int empid, DateTime logindate, string particulars, double monthly, double yearly, char Header)
        //{
        //    SqlParameter[] objp;
        //    objp = new SqlParameter[]
        //          { 
        //              new SqlParameter("@empid",SqlDbType.Int ),
        //              new SqlParameter("@logindate",SqlDbType.DateTime),
        //              new SqlParameter("@particulars", SqlDbType.VarChar,100),
        //              new SqlParameter("@monthly", SqlDbType.Money ),
        //              new SqlParameter("@yearly", SqlDbType.Money ),
        //              new SqlParameter("@Header", SqlDbType.Char ,4 )
        //          };
        //    objp[0].Value = empid;
        //    objp[1].Value = logindate;
        //    objp[2].Value = particulars;
        //    objp[3].Value = monthly;
        //    objp[4].Value = yearly;
        //    objp[5].Value = Header;
        //    ExecuteQuery("SPHRITComputationNew", objp);
        //}

        public void SveHRITComputation(int empid, DateTime logindate, string particulars, double monthly, double yearly, char Header, int FAyear)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                  { 
                      new SqlParameter("@empid",SqlDbType.Int ),
                      new SqlParameter("@logindate",SqlDbType.DateTime),
                      new SqlParameter("@particulars", SqlDbType.VarChar,100),
                      new SqlParameter("@monthly", SqlDbType.Money ),
                      new SqlParameter("@yearly", SqlDbType.Money ),
                      new SqlParameter("@Header", SqlDbType.Char ,4 ),
                      new SqlParameter("@year",SqlDbType.Int )
                  };

            objp[0].Value = empid;
            objp[1].Value = logindate;
            objp[2].Value = particulars;
            objp[3].Value = monthly;
            objp[4].Value = yearly;
            objp[5].Value = Header;
            objp[6].Value = FAyear;
            ExecuteQuery("SPHRITComputationNew", objp);
        }

      /*  public void SveHRITComputation(int empid, DateTime logindate, string particulars, double monthly, double yearly, char Header, int FAyear)
        {
            SqlParameter[] objp;
            objp = new SqlParameter[]
                  { 
                      new SqlParameter("@empid",SqlDbType.Int ),
                      new SqlParameter("@logindate",SqlDbType.DateTime),
                      new SqlParameter("@particulars", SqlDbType.VarChar,100),
                      new SqlParameter("@monthly", SqlDbType.Money ),
                      new SqlParameter("@yearly", SqlDbType.Money ),
                      new SqlParameter("@Header", SqlDbType.Char ,4 ),
                      new SqlParameter("@year",SqlDbType.Int )
                  };
            objp[0].Value = empid;
            objp[1].Value = logindate;
            objp[2].Value = particulars;
            objp[3].Value = monthly;
            objp[4].Value = yearly;
            objp[5].Value = Header;
            objp[6].Value = FAyear;
            ExecuteQuery("SPHRITComputationNew", objp);
        }
        */


        public DataTable Get_PreYear_ITComputationDtls(int empid, int FAyear)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4),
                            new SqlParameter("@year",SqlDbType.Int,4)
                        };
            objp[0].Value = empid;
            objp[1].Value = FAyear;

            return ExecuteTable("Sp_GetITdtls_Preyear", objp);
        }

        public DataSet GetComparisionofITCompu(int empid)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@empid",SqlDbType.Int,4)
                        };
            objp[0].Value = empid;
            return ExecuteDataSet("SPgetCompareofItComputation", objp);
        }

        public DataSet GetComparisionofITComputation(int EmpId)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@EmpId",SqlDbType.Int,4)
                        };
            objp[0].Value = EmpId;
            return ExecuteDataSet("SPgetCompareofItComputation_Web", objp);
        }
        
        public DataTable GetProcessITcompare(int paymonth, int payyear)
        {
            SqlParameter[] objp = new SqlParameter[] 
                        {
                            new SqlParameter("@paymonth",SqlDbType.Int,4),
                            new SqlParameter("@payyear",SqlDbType.Int,4)
                        };
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            return ExecuteTable("SPGetProcessITComput", objp);
        }


        /*Dinesh*/

        //public double GetHRITProfTaxAmt(int empid, double gross)
        //{
        //    SqlParameter[] objp = new SqlParameter[]
        //        { 
        //            new SqlParameter("@empid", SqlDbType.Int),
        //            new SqlParameter("@gross", SqlDbType.Float, 4)


        //        };
        //    objp[0].Value = empid;
        //    objp[1].Value = gross;
        //    return double.Parse(ExecuteReader("SPGetHRITProfTaxAmt", objp));
        //}


        public double GetHRITProfTaxAmt(int empid, double gross, int fyear)
        {
            SqlParameter[] objp = new SqlParameter[]
                { 
                    new SqlParameter("@empid", SqlDbType.Int),
                    new SqlParameter("@gross", SqlDbType.Float, 4),
                    new SqlParameter("@fyear", SqlDbType.Int , 4)

                };
            objp[0].Value = empid;
            objp[1].Value = gross;
            objp[2].Value = fyear;
            return double.Parse(ExecuteReader("SPGetHRITProfTaxAmt", objp));
        }

        public double GetHRITAmtPrvEmpInco(int paymonth, int payyear, int empid)
        {
            SqlParameter[] objp = new SqlParameter[]
            { 
                new SqlParameter("@paymonth", SqlDbType.Int) ,
                new SqlParameter("@payyear", SqlDbType.Int),
                new SqlParameter("@empid", SqlDbType.Int)
            };
                
            objp[0].Value = paymonth;
            objp[1].Value = payyear;
            objp[2].Value = empid;
            return double.Parse(ExecuteReader("GetHRITAmt4PrvEmpInco", objp));
        }
    }

}
